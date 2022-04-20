using System.Collections.Generic;
using UserRegistrationAPI.Models;

namespace UserRegistrationAPI.Services
{
    public interface IUserServices
    {
        //public IEnumerable<User> GetAllUsers();
        public User GetUserById(string id);
        public User GetUserByEmail(string email);
        public User GetUserByUsername(string username);
        public User GetUserByEmailAndPassword(string email, string password);
        public User GetUserByUsernameAndPassword(string username, string password);
        public User Login(string UserName, string Password);
        public IEnumerable<User> GetAllUsers();
        public User AddUser(User user);
        public void UpdateUser(User user);
        void DeleteUser(string id);
    }
}
