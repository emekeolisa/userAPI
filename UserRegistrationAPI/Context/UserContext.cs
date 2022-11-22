using Microsoft.EntityFrameworkCore;
using UserRegistrationAPI.Models;


namespace UserRegistrationAPI.Context
{
    public class UserContext : DbContext

    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

       
        public DbSet<User> UserRegistrationDB { get; set; }
    }
}
