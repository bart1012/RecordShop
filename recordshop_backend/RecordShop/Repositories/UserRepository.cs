using RecordShop.Backend.DbContexts;
using RecordShop.Backend.Exceptions;
using RecordShop.Backend.Models;

namespace RecordShop.Backend.Repositories
{
    public interface IUserRepository
    {
        List<User> RetrieveAllUserData();
        User? FindUser(string email);
        User UpdateUserDetails();
        bool DeleteUser();
        User AddUser(string email, string firstName, string lastName, string password);
    }
    public class UserRepository(UserLoginDbContext db) : IUserRepository
    {
        private readonly UserLoginDbContext _db = db;

        public User AddUser(string email, string firstName, string lastName, string password)
        {
            if (_db.Users.Any(user => user.Email == email)) throw new DuplicateUserException("This email is already associated with an existing account.");
            User newUser = new User()
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Password = password
            };
            _db.Users.Add(newUser);
            _db.SaveChanges();
            return newUser;

        }

        public bool DeleteUser()
        {
            throw new NotImplementedException();
        }

        public User? FindUser(string email)
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
