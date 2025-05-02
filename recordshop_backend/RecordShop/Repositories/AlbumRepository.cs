using Microsoft.EntityFrameworkCore;
using RecordShop.Backend.DbContexts;
using RecordShop.Models;
using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;

namespace RecordShop.Repositories
{
    public interface IAlbumRepository
    {
        public Task<List<Album>> RetrieveAllAlbumsAsync();
        public Task<Album?> FindAlbumByIDAsync(int id);
        public Task<Album> UpdateAlbumDetailsAsync(int id, JsonPatchDocument jsonPatch);
        public Task<bool> AlbumDeletedAsync(int id);
        public Task<Album> AddAlbumAsync(AlbumDTO album);
        public Task<List<Album>> FetchFilteredAlbumsAsync(string q);
    }

    public class AlbumRepository(RecordShopDbContext db) : IAlbumRepository
    {
        private readonly RecordShopDbContext _db = db;

        public async Task<List<Album>> RetrieveAllAlbumsAsync()
        {

            return await _db.Albums
             .Include(a => a.AlbumArtists)
                 .ThenInclude(aa => aa.Artist)
             .Include(a => a.AlbumSongs)
                 .ThenInclude(asg => asg.Song)
             .Include(a => a.AlbumGenres)
                 .ThenInclude(ag => ag.Genre)
             .ToListAsync();
        }

        public async Task<bool> AlbumDeletedAsync(int id)
        {
            try
            {
                var targetAlbum = await _db.Albums.SingleAsync(a => a.ID == id);
                _db.Albums.Remove(targetAlbum);
                await _db.SaveChangesAsync();
                return true;

            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public async Task<Album?> FindAlbumByIDAsync(int id)
        {
            return await _db.Albums.Include(a => a.AlbumArtists)
                 .ThenInclude(aa => aa.Artist)
             .Include(a => a.AlbumSongs)
                 .ThenInclude(asg => asg.Song)
             .Include(a => a.AlbumGenres)
                 .ThenInclude(ag => ag.Genre)
             .FirstOrDefaultAsync(a => a.ID == id);
        }

        public async Task<Album> AddAlbumAsync(AlbumDTO album)
        {
            if (await _db.Albums.AnyAsync(a => a.Name == album.Name && a.ReleaseYear == album.ReleaseYear)) throw new InvalidOperationException("An album with the given name and release date already exists.");

            using var transaction = await _db.Database.BeginTransactionAsync();

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
                await _db.Albums.AddAsync(albumEntity);
                await _db.SaveChangesAsync();

                //add to artist and albumArtists table 
                foreach (var artistName in album.Artists)
                {
                    var artist = await _db.Artists.FirstOrDefaultAsync(a => a.Name == artistName) ?? new Artist() { Name = artistName, ImgURL = "" };
                    if (artist.ID == 0) { await _db.Artists.AddAsync(artist); await _db.SaveChangesAsync(); }
                    await _db.AlbumArtists.AddAsync(new AlbumArtists() { AlbumID = albumEntity.ID, ArtistID = artist.ID });
                }

                //add to genre and albumGenres table 
                foreach (var genreName in album.Genres)
                {
                    var genre = await _db.Genres.FirstOrDefaultAsync(g => g.Name == genreName) ?? new Genre()
                    {
                        Name = genreName
                    };
                    if (genre.ID == 0) { await _db.Genres.AddAsync(genre); await _db.SaveChangesAsync(); }
                    await _db.AlbumGenres.AddAsync(new AlbumGenre() { AlbumID = albumEntity.ID, GenreID = genre.ID });
                }

                foreach (var song in album.Songs)
                {
                    var songEntity = await _db.Songs.FirstOrDefaultAsync(s => s.Name == song.Name && s.Duration == song.Duration) ?? song;
                    if (songEntity.ID == 0) { await _db.Songs.AddAsync(songEntity); await _db.SaveChangesAsync(); }
                    await _db.AlbumSongs.AddAsync(new AlbumSong() { AlbumID = albumEntity.ID, SongID = songEntity.ID });
                }
                await transaction.CommitAsync();
                return albumEntity;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }

        }

        public async Task<Album> UpdateAlbumDetailsAsync(int id, JsonPatchDocument jsonPatch)
        {

            try
            {
                var dbAlbum = await _db.Albums.SingleAsync(a => a.ID == id);
                jsonPatch.ApplyTo(dbAlbum);
                await _db.SaveChangesAsync();
                return dbAlbum;

            }
            catch (Exception e) //General exception if the album is not found OR the jsonPatch path is invalid
            {
                return null;
            }

        }

        public async Task<List<Album>> FetchFilteredAlbumsAsync(string q)
        {

            var filteredAlbums = await _db.Albums
                       .Include(a => a.AlbumArtists)
                           .ThenInclude(aa => aa.Artist)
                       .Include(a => a.AlbumSongs)
                           .ThenInclude(asg => asg.Song)
                       .Include(a => a.AlbumGenres)
                           .ThenInclude(ag => ag.Genre)
                       .Where(album =>
                           album.Name.Contains(q) ||
                           album.AlbumArtists.Any(aa => aa.Artist.Name.Contains(q))
                       ).ToListAsync();

            return filteredAlbums;

        }
    }
}