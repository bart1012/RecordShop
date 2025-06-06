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
                policy.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
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
            builder.Services.AddDbContext<OrdersDbContext>(options =>
            {

                options.UseSqlServer(builder.Configuration.GetConnectionString("OrdersDb"));


            });
            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
            builder.Services.AddScoped<IAlbumService, AlbumService>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
            builder.Services.AddScoped<IOrdersService, OrdersService>();
            builder.Services.AddSwaggerGen(c => c.DocumentFilter<JsonPatchDocumentFilter>());
            builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;

            });
            builder.Services.AddAuthorization();
            builder.Services.AddIdentityCore<User>().AddEntityFrameworkStores<UserDbContext>().AddApiEndpoints();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddScoped<UserManager<User>>();



            var app = builder.Build();




            // Configure the HTTP request pipeline.
            app.UseCors("AllowReactApp");
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapCustomIdentityApi<User>();
            app.MapControllers();

            app.Run();
        }
    }
}
