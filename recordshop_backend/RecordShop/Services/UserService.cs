using RecordShop.Backend.Models;
using RecordShop.Backend.Repositories;

namespace RecordShop.Backend.Services
{
    public interface IUserService
    {
        List<User> RetrieveAllUserData();
        bool EmailExists(string email);
        User UpdateUserDetails();
        bool DeleteUser(int id);
        User AddUser(User user);
        User? AuthenticateUser(string email, string password);
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


        public User? AuthenticateUser(string email, string password)
        {
            var user = _userRepo.RetrieveUserByEmail(email);
            if (user is null) return null;
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password)) return null;
            return user;
        }

        public List<User> RetrieveAllUserData()
        {
            return _userRepo.RetrieveAllUserData();
        }

        public User UpdateUserDetails()
        {

            throw new NotImplementedException();
        }

        public bool EmailExists(string email)
        {
            return _userRepo.FindUserByEmail(email) != null;
        }
    }
}
