using Microsoft.IdentityModel.Tokens;
using RecordShop.Models;
using RecordShop.Repositories;
using System.Data;
using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;


namespace RecordShop.Services
{
    public interface IAlbumService
    {
        public Task<List<AlbumDTO>?> RetrieveAllAlbumsAsync();
        public Task<List<AlbumDTO>?> RetrieveFilteredAlbumsAsync(string q);
        public Task<AlbumDTO?> RetrieveAlbumByIDAsync(int id);
        public Task<Album> UpdateAlbumAsync(int id, JsonPatchDocument jsonPatch);
        public Task<bool> AlbumDeletedAsync(int id);
        public Task<Album> AddNewAlbumAsync(AlbumDTO album);
        public Task<List<AlbumDTO>?> RetrieveNewReleasesAsync();
    }
    public class AlbumService(IAlbumRepository albumRepo) : IAlbumService
    {
        private readonly IAlbumRepository _albumRepo = albumRepo;

        public async Task<Album> AddNewAlbumAsync(AlbumDTO album)
        {
            return await _albumRepo.AddAlbumAsync(album);
        }

        public async Task<bool> AlbumDeletedAsync(int id)
        {
            return await _albumRepo.AlbumDeletedAsync(id);
        }

        public async Task<AlbumDTO?> RetrieveAlbumByIDAsync(int id)
        {
            var albumData = await _albumRepo.FindAlbumByIDAsync(id);
            return albumData is null ? null : new AlbumDTO()
            {
                ID = albumData.ID,
                Name = albumData.Name,
                ReleaseYear = albumData.ReleaseYear,
                TotalMinutes = albumData.TotalMinutes,
                PricePence = albumData.PricePence,
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

        public async Task<List<AlbumDTO>?> RetrieveFilteredAlbumsAsync(string q)
        {
            var albumsData = await _albumRepo.FetchFilteredAlbumsAsync(q);
            return albumsData.IsNullOrEmpty() ? null : albumsData.Select(a => new AlbumDTO()
            {
                ID = a.ID,
                Name = a.Name,
                ReleaseYear = a.ReleaseYear,
                TotalMinutes = a.TotalMinutes,
                PricePence = a.PricePence,
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

        public async Task<List<AlbumDTO>?> RetrieveAllAlbumsAsync()
        {
            var albumData = await _albumRepo.RetrieveAllAlbumsAsync();
            return albumData.IsNullOrEmpty() ? null : albumData.Select(a => new AlbumDTO
            {
                ID = a.ID,
                Name = a.Name,
                ReleaseYear = a.ReleaseYear,
                TotalMinutes = a.TotalMinutes,
                PricePence = a.PricePence,
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

        public async Task<List<AlbumDTO>?> RetrieveNewReleasesAsync()
        {

            DateTime oldestPossibleDate = DateTime.Now.Subtract(new TimeSpan(547, 0, 0, 0));

            var albumData = await _albumRepo.RetrieveAllAlbumsAsync();
            var mostRecentAlbums = albumData.Where(a => a.ReleaseYear <= DateTime.Now && a.ReleaseYear > oldestPossibleDate).ToList();
            return mostRecentAlbums.IsNullOrEmpty() ? null : mostRecentAlbums.Select(a => new AlbumDTO
            {
                ID = a.ID,
                Name = a.Name,
                ReleaseYear = a.ReleaseYear,
                TotalMinutes = a.TotalMinutes,
                PricePence = a.PricePence,
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

        public async Task<Album> UpdateAlbumAsync(int id, JsonPatchDocument jsonPatch)
        {
            return await _albumRepo.UpdateAlbumDetailsAsync(id, jsonPatch);
        }
    }



}
