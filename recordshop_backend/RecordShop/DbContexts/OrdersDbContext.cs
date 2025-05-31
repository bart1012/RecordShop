using Microsoft.EntityFrameworkCore;
using RecordShop.Backend.Models;

namespace RecordShop.Backend.DbContexts
{
    public class OrdersDbContext(DbContextOptions<OrdersDbContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

    }


    //public class OrdersDbContext : DbContext
    //{
    //    public DbSet<Order> Orders { get; set; }
    //    public DbSet<OrderItem> OrderItems { get; set; }
    //    public DbSet<OrderDetails> OrderDetails { get; set; }


    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder.UseSqlServer("Server=DESKTOP-QA5JG2D\\SQLEXPRESS01;Database=RecordShopOrdersDB;User Id=bart1012;Password=ScrumONI93_;TrustServerCertificate = True");
    //    }
    //}
}
