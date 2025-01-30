using RecordShop.Models;
using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;

namespace RecordShop.Repositories
{
    public interface IAlbumRepository
    {
        public List<AlbumDTO> GetAllAlbums();
        public AlbumDTO GetAlbumByID(int id);
        public Album UpdateAlbumDetails(int id, JsonPatchDocument jsonPatch);
        public bool DeleteAlbum(int id);
        Album InsertAlbum(Album album);
    }

    public class AlbumRepository(RecordShopDbContext db) : IAlbumRepository
    {
        private readonly RecordShopDbContext _db = db;

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

        public AlbumDTO? GetAlbumByID(int id)
        {
            try
            {
                var albumRecord = _db.Albums.Single(a => a.ID == id);
                return new AlbumDTO()
                {

                    ID = albumRecord.ID,
                    Name = albumRecord.Name,
                    ReleaseYear = albumRecord.ReleaseYear,
                    TotalMinutes = albumRecord.TotalMinutes,
                    Artists = _db.AlbumArtists
                    .Where(aa => aa.AlbumID == albumRecord.ID)
                    .Select(r => r.Artist.Name)
                    .ToList(),
                    Genres = _db.AlbumGenres
                    .Where(g => g.AlbumID == albumRecord.ID)
                    .Select(r => r.Genre.Name)
                    .ToList(),
                    Songs = _db.AlbumSongs.Where(g => g.AlbumID == albumRecord.ID)
                    .Select(r => r.Song)
                    .ToList()
                };
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }

        public List<AlbumDTO> GetAllAlbums()
        {
            var dbAlbums = _db.Albums
            .Select(album => new AlbumDTO()
            {
                ID = album.ID,
                Name = album.Name,
                ReleaseYear = album.ReleaseYear,
                TotalMinutes = album.TotalMinutes,
                Artists = _db.AlbumArtists
                    .Where(aa => aa.AlbumID == album.ID)
                    .Select(r => r.Artist.Name)
                    .ToList(),
                Genres = _db.AlbumGenres
                    .Where(g => g.AlbumID == album.ID)
                    .Select(r => r.Genre.Name)
                    .ToList(),
            }).ToList();

            return dbAlbums;
        }

        public Album InsertAlbum(Album album)
        {
            try
            {
                _db.Albums.Add(album);
                _db.SaveChanges();
                return album;

            }
            catch (Exception e)
            {
                return null;
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
