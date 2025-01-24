using Microsoft.EntityFrameworkCore;
using RecordShop.Repositories;
using RecordShop.Services;
using RecordShop.Utils;

namespace RecordShop
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson(); ;
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<RecordShopDbContext>(options =>
            {
                if (builder.Environment.IsDevelopment())
                {

                    options.UseInMemoryDatabase("InMemoryDB");
                }
                else if (builder.Environment.IsProduction())
                {
                    options.UseSqlServer("Server=DESKTOP-QA5JG2D\\SQLEXPRESS01;Database=RecordShopDB;User Id=bart1012;Password=Scamper123!;TrustServerCertificate = True");

                }
            });
            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
            builder.Services.AddScoped<IAlbumService, AlbumService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                Seeder.AddAlbumData(app);
            }


            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
