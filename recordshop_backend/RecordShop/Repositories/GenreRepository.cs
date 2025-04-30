using RecordShop.Backend.DbContexts;
using RecordShop.Models;

namespace RecordShop.Backend.Repositories
{
    public interface IGenreRepository
    {
        List<Genre> FetchAllGenres();
        Genre UpdateGenreDetails(int id);
        bool DeleteGenreById(int id);
        Genre AddNewGenre(string gName);
    }
    public class GenreRepository(RecordShopDbContext db) : IGenreRepository
    {
        private readonly RecordShopDbContext _db = db;
        public Genre AddNewGenre(string gName)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGenreById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Genre> FetchAllGenres()
        {
            return _db.Genres.ToList();
        }

        public Genre UpdateGenreDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
