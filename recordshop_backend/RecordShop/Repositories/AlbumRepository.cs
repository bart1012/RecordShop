using Microsoft.EntityFrameworkCore;
using RecordShop.Backend.DbContexts;
using RecordShop.Models;
using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;

namespace RecordShop.Repositories
{
    public interface IAlbumRepository
    {
        public List<Album> RetrieveAllAlbums();
        public Album FindAlbumByID(int id);
        public Album UpdateAlbumDetails(int id, JsonPatchDocument jsonPatch);
        public bool DeleteAlbum(int id);
        public Album AddAlbum(AlbumDTO album);
    }

    public class AlbumRepository(RecordShopDbContext db) : IAlbumRepository
    {
        private readonly RecordShopDbContext _db = db;

        public List<Album> RetrieveAllAlbums()
        {

            return _db.Albums
             .Include(a => a.AlbumArtists)
                 .ThenInclude(aa => aa.Artist)
             .Include(a => a.AlbumSongs)
                 .ThenInclude(asg => asg.Song)
             .Include(a => a.AlbumGenres)
                 .ThenInclude(ag => ag.Genre)
             .ToList();
        }


        public bool DeleteAlbum(int id)
        {
            try
            {
                _db.Albums.Remove(_db.Albums.Single(a => a.ID == id));
                _db.SaveChanges();
                return true;

            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public Album? FindAlbumByID(int id)
        {
            return _db.Albums.Include(a => a.AlbumArtists)
                 .ThenInclude(aa => aa.Artist)
             .Include(a => a.AlbumSongs)
                 .ThenInclude(asg => asg.Song)
             .Include(a => a.AlbumGenres)
                 .ThenInclude(ag => ag.Genre)
             .FirstOrDefault(a => a.ID == id);
        }

        public Album AddAlbum(AlbumDTO album)
        {
            if (_db.Albums.Any(a => a.Name == album.Name && a.ReleaseYear == album.ReleaseYear)) throw new InvalidOperationException("An album with the given name and release date already exists.");

            using var transaction = _db.Database.BeginTransaction();

            try
            {
                //create album
                var albumEntity = new Album()
                {
                    Name = album.Name,
                    ReleaseYear = album.ReleaseYear,
                    TotalMinutes = album.TotalMinutes,
                    ImgURL = album.ImgURL
                };
                _db.Albums.Add(albumEntity);
                _db.SaveChanges();

                //add to artist and albumArtists table 
                foreach (var artistName in album.Artists)
                {
                    var artist = _db.Artists.FirstOrDefault(a => a.Name == artistName) ?? new Artist() { Name = artistName, ImgURL = "" };
                    if (artist.ID == 0) { _db.Artists.Add(artist); _db.SaveChanges(); }
                    _db.AlbumArtists.Add(new AlbumArtists() { AlbumID = albumEntity.ID, ArtistID = artist.ID });
                }

                //add to genre and albumGenres table 
                foreach (var genreName in album.Genres)
                {
                    var genre = _db.Genres.FirstOrDefault(g => g.Name == genreName) ?? new Genre()
                    {
                        Name = genreName
                    };
                    if (genre.ID == 0) { _db.Genres.Add(genre); _db.SaveChanges(); }
                    _db.AlbumGenres.Add(new AlbumGenre() { AlbumID = albumEntity.ID, GenreID = genre.ID });
                }

                foreach (var song in album.Songs)
                {
                    var songEntity = _db.Songs.FirstOrDefault(s => s.Name == song.Name && s.Duration == song.Duration) ?? song;
                    if (songEntity.ID == 0) { _db.Songs.Add(songEntity); _db.SaveChanges(); }
                    _db.AlbumSongs.Add(new AlbumSong() { AlbumID = albumEntity.ID, SongID = songEntity.ID });
                }
                transaction.Commit();
                return albumEntity;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }

        }

        public Album? UpdateAlbumDetails(int id, JsonPatchDocument jsonPatch)
        {

            try
            {
                var dbAlbum = _db.Albums.Single(a => a.ID == id);
                jsonPatch.ApplyTo(dbAlbum);
                _db.SaveChanges();
                return dbAlbum;

            }
            catch (Exception e) //General exception if the album is not found OR the jsonPatch path is invalid
            {
                return null;
            }

        }


    }
}
