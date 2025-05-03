using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecordShop.Backend.DbContexts;
using RecordShop.Backend.Repositories;
using RecordShop.Backend.Services;
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
            builder.Services.AddCors(options => options.AddPolicy("AllowReactApp", policy =>
            {
                policy.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader();
            }));
            builder.Services.AddControllers().AddNewtonsoftJson(); ;
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<RecordShopDbContext>(options =>
            {

                options.UseSqlServer("Server=DESKTOP-QA5JG2D\\SQLEXPRESS01;Database=RecordShopDB;User Id=bart1012;Password=Krakers51!;TrustServerCertificate = True");


            });
            builder.Services.AddDbContext<UserDbContext>(options =>
            {

                options.UseSqlServer("Server=DESKTOP-QA5JG2D\\SQLEXPRESS01;Database=RecordShopUsersDB;User Id=bart1012;Password=Krakers51!;TrustServerCertificate = True");


            });
            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
            builder.Services.AddScoped<IAlbumService, AlbumService>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddSwaggerGen(c => c.DocumentFilter<JsonPatchDocumentFilter>());
            builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);
            builder.Services.AddAuthorization();
            builder.Services.AddIdentityCore<IdentityUser>().AddEntityFrameworkStores<UserDbContext>().AddApiEndpoints();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();


            var app = builder.Build();




            // Configure the HTTP request pipeline.
            app.UseCors("AllowReactApp");
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapIdentityApi<IdentityUser>();
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
