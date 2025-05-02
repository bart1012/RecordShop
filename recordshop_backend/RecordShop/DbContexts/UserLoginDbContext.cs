using Microsoft.EntityFrameworkCore;
using RecordShop.Backend.Models;

namespace RecordShop.Backend.DbContexts
{


    public class UserLoginDbContext(DbContextOptions<UserLoginDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }


    }
}
