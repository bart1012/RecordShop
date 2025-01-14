using RecordShop.Classes;
using RecordShop.Repositories;

namespace RecordShop.Services
{
    public interface IAlbumService
    {
        public List<Album> RetrieveAllAlbums();
        public Album RetrieveAlbumByID();
        public Album UpdateAlbum();
        public bool DeleteAlbum();
    }
    public class AlbumService(AlbumRepository albumRepo) : IAlbumService
    {
        private readonly AlbumRepository _albumRepo = albumRepo;

        public bool DeleteAlbum()
        {
            throw new NotImplementedException();
        }

        public Album RetrieveAlbumByID()
        {
            throw new NotImplementedException();
        }

        public List<Album> RetrieveAllAlbums()
        {
            return _albumRepo.GetAllAlbums();
        }

        public Album UpdateAlbum()
        {
            throw new NotImplementedException();
        }
    }



}
