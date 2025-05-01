using RecordShop.Backend.DbContexts;
using RecordShop.Backend.Exceptions;
using RecordShop.Backend.Models;

namespace RecordShop.Backend.Repositories
{
    public interface IUserRepository
    {
        List<User> RetrieveAllUserData();
        User? FindUserByEmail(string email);
        User UpdateUserDetails();
        bool DeleteUser(int id);
        User AddUser(User user);
        User? RetrieveUserByEmail(string email);
    }
    public class UserRepository(UserLoginDbContext db) : IUserRepository
    {
        private readonly UserLoginDbContext _db = db;

        public User AddUser(User user)
        {
            if (_db.Users.Any(u => u.Email == user.Email)) throw new DuplicateUserException("This email is already associated with an existing account.");
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }

        public bool DeleteUser(int id)
        {
            if (_db.Users.Any(u => u.Id == id))
            {
                _db.Users.Remove(_db.Users.FirstOrDefault(u => u.Id == id));
                _db.SaveChanges();
                return true;
            }
            else
            {
                throw new DuplicateUserException("User not found.");

            }

        }

        public User? FindUserByEmail(string email)
        {
            return _db.Users.FirstOrDefault(u => u.Email == email);
        }

        public User? RetrieveUserByEmail(string email)
        {
            return _db.Users.FirstOrDefault(u => u.Email == email);
        }

        public List<User> RetrieveAllUserData()
        {
            return _db.Users.ToList();
        }

        public User UpdateUserDetails()
        {
            throw new NotImplementedException();
        }
    }
}
