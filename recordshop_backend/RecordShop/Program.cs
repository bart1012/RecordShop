using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecordShop.Backend.DbContexts;
using RecordShop.Backend.Models;
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
            builder.Services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<RecordShopDbContext>(options =>
            {

                options.UseSqlServer(builder.Configuration.GetConnectionString("AlbumDb"));


            });
            builder.Services.AddDbContext<UserDbContext>(options =>
            {

                options.UseSqlServer(builder.Configuration.GetConnectionString("UserDb"));


            });
            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
            builder.Services.AddScoped<IAlbumService, AlbumService>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddSwaggerGen(c => c.DocumentFilter<JsonPatchDocumentFilter>());
            builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);
            builder.Services.AddAuthorization();
            builder.Services.AddIdentityCore<User>().AddEntityFrameworkStores<UserDbContext>().AddApiEndpoints();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddScoped<UserManager<User>>();


            var app = builder.Build();




            // Configure the HTTP request pipeline.
            app.UseCors("AllowReactApp");
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapCustomIdentityApi<User>();
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
