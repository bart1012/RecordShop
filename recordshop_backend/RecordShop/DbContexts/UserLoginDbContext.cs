using Microsoft.EntityFrameworkCore;
using RecordShop.Backend.Models;

namespace RecordShop.Backend.DbContexts
{


    public class UserLoginDbContext(DbContextOptions<UserLoginDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-QA5JG2D\\SQLEXPRESS01;Database=RecordShopUsersDB;User Id=bart1012;Password=Krakers51!;TrustServerCertificate = True");
        }
    }
}
