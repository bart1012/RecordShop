using RecordShop.Models;
using RecordShop.Repositories;
using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;


namespace RecordShop.Services
{
    public interface IAlbumService
    {
        public List<AlbumDTO> RetrieveAllAlbums();
        public Album RetrieveAlbumByID(int id);
        public Album UpdateAlbum(int id, JsonPatchDocument jsonPatch);
        public bool DeleteAlbum(int id);
        public Album AddNewAlbum(Album album);
    }
    public class AlbumService(IAlbumRepository albumRepo) : IAlbumService
    {
        private readonly IAlbumRepository _albumRepo = albumRepo;

        public Album AddNewAlbum(Album album)
        {
            return _albumRepo.InsertAlbum(album);
        }

        public bool DeleteAlbum(int id)
        {
            return _albumRepo.DeleteAlbum(id);
        }

        public Album? RetrieveAlbumByID(int id)
        {
            return _albumRepo.GetAlbumByID(id);
        }

        public List<AlbumDTO> RetrieveAllAlbums()
        {
            return _albumRepo.GetAllAlbums();
        }

        public Album UpdateAlbum(int id, JsonPatchDocument jsonPatch)
        {
            return _albumRepo.UpdateAlbumDetails(id, jsonPatch);
        }
    }



}
