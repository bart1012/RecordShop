using RecordShop.Backend.Repositories;
using RecordShop.Models;

namespace RecordShop.Backend.Services
{
    public interface IGenreService
    {
        List<string> RetrieveAllGenreNames();
        Genre AddNewGenre(string gName);
        bool DeleteGenreById(int id);
        Genre UpdateGenreById(int id);

    }
    public class GenreService(IGenreRepository genreRepo) : IGenreService
    {
        private readonly IGenreRepository _gRepo = genreRepo;
        public Genre AddNewGenre(string gName)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGenreById(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> RetrieveAllGenreNames()
        {
            return _gRepo.FetchAllGenres().Select(g => g.Name).ToList();
        }

        public Genre UpdateGenreById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
