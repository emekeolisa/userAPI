using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UserRegistrationAPI.Context;
using UserRegistrationAPI.Models;

namespace UserRegistrationAPI.Services
{
    public class UserServices : IUserServices
    {
        private UserContext db;
        public UserServices(UserContext _db)
        {
            db = _db;
        }

        public User AddUser(User user)
        {
            var userPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                Email = user.Email,
                AccountNumber = user.AccountNumber,
                CreateDate = user.CreateDate,
                ModifyDate = user.ModifyDate,
              

            };

            db.UserRegistrationDB.Add(newUser);
            db.SaveChangesAsync();
            return user;


        }
        
        public void DeleteUser(string id)
        {
            var user = db.UserRegistrationDB.SingleOrDefault(x => x.Id == id);
            if (user != null)
            {
                db.UserRegistrationDB.Remove(user);
                db.SaveChanges();
            }

        }

        public User Login(string UserName, string Password)
        {


            var loginUser = db.UserRegistrationDB.SingleOrDefault(x => x.UserName == UserName);
            Console.WriteLine(loginUser);
            bool isValid = BCrypt.Net.BCrypt.Verify(Password, loginUser.Password);

            if (loginUser == null)
            {
                throw new NotImplementedException("Incorrect UserName or Password");
            }

            if (isValid == false)
            {
                throw new NotImplementedException("UserName or Password not correct");
            }

            return loginUser;


        }

        public IEnumerable<User> GetAllUsers()
        {
            return db.UserRegistrationDB.Select(u => u).ToList();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(string id)
        {
            var user = db.UserRegistrationDB.SingleOrDefault(x => x.Id == id);
            if (user != null)
               
            {
                
                return user;
            }

            throw new NotImplementedException();
        }

        public User GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChangesAsync();
        }

    }
}
