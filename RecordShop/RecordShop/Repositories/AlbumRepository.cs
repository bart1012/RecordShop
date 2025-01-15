using RecordShop.Classes;
using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;

namespace RecordShop.Repositories
{
    public interface IAlbumRepository
    {
        public List<Album> GetAllAlbums();
        public Album GetAlbumByID(int id);
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

        public Album? GetAlbumByID(int id)
        {
            try
            {
                var albumByID = _db.Albums.Single(a => a.ID == id);
                return albumByID;

            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }

        public List<Album> GetAllAlbums()
        {
            return _db.Albums.ToList();
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
