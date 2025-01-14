using RecordShop.Classes;

namespace RecordShop.Repositories
{
    public interface IAlbumRepository
    {
        public List<Album> GetAllAlbums();
        public Album GetAlbumByID();
        public Album UpdateAlbumDetails();
        public bool DeleteAlbum();
    }

    public class AlbumRepository(RecordShopDbContext db) : IAlbumRepository
    {
        private readonly RecordShopDbContext _db = db;

        public bool DeleteAlbum()
        {
            throw new NotImplementedException();
        }

        public Album GetAlbumByID()
        {
            throw new NotImplementedException();
        }

        public List<Album> GetAllAlbums()
        {
            throw new NotImplementedException();
        }

        public Album UpdateAlbumDetails()
        {
            throw new NotImplementedException();
        }
    }


}
