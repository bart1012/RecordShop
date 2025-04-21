using RecordShop.Backend.Models;

namespace RecordShop.Backend.Services
{
    public interface IUserService
    {
        List<User> RetrieveAllUserData();
        User? FindUser(string email);
        User UpdateUserDetails();
        bool DeleteUser();
        User AddUser(string email, string firstName, string lastName, string password);
    }
    public class UserService : IUserService
    {
        public User AddUser(string email, string firstName, string lastName, string password)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser()
        {
            throw new NotImplementedException();
        }

        public User? FindUser(string email)
        {
            throw new NotImplementedException();
        }

        public List<User> RetrieveAllUserData()
        {
            throw new NotImplementedException();
        }

        public User UpdateUserDetails()
        {

            throw new NotImplementedException();
        }
    }
}
