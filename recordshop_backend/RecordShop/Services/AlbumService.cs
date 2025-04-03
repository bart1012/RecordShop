using Microsoft.IdentityModel.Tokens;
using RecordShop.Models;
using RecordShop.Repositories;
using System.Data;
using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;


namespace RecordShop.Services
{
    public interface IAlbumService
    {
        public List<AlbumDTO>? RetrieveAllAlbums();
        public AlbumDTO RetrieveAlbumByID(int id);
        public Album UpdateAlbum(int id, JsonPatchDocument jsonPatch);
        public bool DeleteAlbum(int id);
        public Album AddNewAlbum(AlbumDTO album);
        public List<AlbumDTO>? RetrieveNewReleases();
    }
    public class AlbumService(IAlbumRepository albumRepo) : IAlbumService
    {
        private readonly IAlbumRepository _albumRepo = albumRepo;

        public Album AddNewAlbum(AlbumDTO album)
        {
            return _albumRepo.AddAlbum(album);
        }

        public bool DeleteAlbum(int id)
        {
            return _albumRepo.DeleteAlbum(id);
        }

        public AlbumDTO? RetrieveAlbumByID(int id)
        {
            var albumData = _albumRepo.FindAlbumByID(id);
            return albumData is null ? null : new AlbumDTO()
            {
                ID = albumData.ID,
                Name = albumData.Name,
                ReleaseYear = albumData.ReleaseYear,
                TotalMinutes = albumData.TotalMinutes,
                ImgURL = albumData.ImgURL,
                Artists = albumData.AlbumArtists.Select(aa => aa.Artist.Name).ToList(),
                Genres = albumData.AlbumGenres.Select(ag => ag.Genre.Name).ToList(),
                Songs = albumData.AlbumSongs.Select(asg => new Song
                {
                    ID = asg.Song.ID,
                    Name = asg.Song.Name,
                    Duration = asg.Song.Duration
                }).ToList(),
            };
        }

        public List<AlbumDTO>? RetrieveAllAlbums()
        {
            var albumData = _albumRepo.RetrieveAllAlbums();
            return albumData.IsNullOrEmpty() ? null : albumData.Select(a => new AlbumDTO
            {
                ID = a.ID,
                Name = a.Name,
                ReleaseYear = a.ReleaseYear,
                TotalMinutes = a.TotalMinutes,
                ImgURL = a.ImgURL,
                Artists = a.AlbumArtists.Select(aa => aa.Artist.Name).ToList(),
                Genres = a.AlbumGenres.Select(ag => ag.Genre.Name).ToList(),
                Songs = a.AlbumSongs.Select(asg => new Song
                {
                    ID = asg.Song.ID,
                    Name = asg.Song.Name,
                    Duration = asg.Song.Duration
                }).ToList(),

            }).ToList();
        }

        public List<AlbumDTO>? RetrieveNewReleases()
        {

            DateTime oldestPossibleDate = DateTime.Now.Subtract(new TimeSpan(30 * 3, 0, 0, 0));

            var albumData = _albumRepo.RetrieveAllAlbums().Where(a => a.ReleaseYear <= DateTime.Now && a.ReleaseYear > oldestPossibleDate).ToList();
            return albumData.IsNullOrEmpty() ? null : albumData.Select(a => new AlbumDTO
            {
                ID = a.ID,
                Name = a.Name,
                ReleaseYear = a.ReleaseYear,
                TotalMinutes = a.TotalMinutes,
                ImgURL = a.ImgURL,
                Artists = a.AlbumArtists.Select(aa => aa.Artist.Name).ToList(),
                Genres = a.AlbumGenres.Select(ag => ag.Genre.Name).ToList(),
                Songs = a.AlbumSongs.Select(asg => new Song
                {
                    ID = asg.Song.ID,
                    Name = asg.Song.Name,
                    Duration = asg.Song.Duration
                }).ToList(),

            }).ToList();
        }

        public Album UpdateAlbum(int id, JsonPatchDocument jsonPatch)
        {
            return _albumRepo.UpdateAlbumDetails(id, jsonPatch);
        }
    }



}
