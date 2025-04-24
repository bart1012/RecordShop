using RecordShop.Backend.Models;
using RecordShop.Backend.Repositories;

namespace RecordShop.Backend.Services
{
    public interface IUserService
    {
        List<User> RetrieveAllUserData();
        User? FindUser(string email);
        User UpdateUserDetails();
        bool DeleteUser(int id);
        User AddUser(User user);
    }
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepo = userRepository;
        public User AddUser(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return _userRepo.AddUser(user);
        }

        public bool DeleteUser(int id)
        {
            return _userRepo.DeleteUser(id);
        }

        public User? FindUser(string email)
        {
            throw new NotImplementedException();
        }

        public List<User> RetrieveAllUserData()
        {
            return _userRepo.RetrieveAllUserData();
        }

        public User UpdateUserDetails()
        {

            throw new NotImplementedException();
        }
    }
}
