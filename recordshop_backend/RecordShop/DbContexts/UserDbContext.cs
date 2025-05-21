using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecordShop.Backend.Models;
namespace RecordShop.Backend.DbContexts
{


    public class UserDbContext(DbContextOptions<UserDbContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<User> Users { get; set; }
    }

    //public class UserDbContext : IdentityDbContext<User>
    //{
    //    public DbSet<User> Users { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder.UseSqlServer("Server=DESKTOP-QA5JG2D\\SQLEXPRESS01;Database=RecordShopAccountsDB;User Id=bart1012;Password=ScrumONI93_;TrustServerCertificate = True");
    //    }
    //}
}

