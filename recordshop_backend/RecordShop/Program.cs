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
            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
            builder.Services.AddScoped<IAlbumService, AlbumService>();
            builder.Services.AddSwaggerGen(c => c.DocumentFilter<JsonPatchDocumentFilter>());



            var app = builder.Build();




            // Configure the HTTP request pipeline.
            app.UseCors("AllowReactApp");
            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
