
using Microsoft.EntityFrameworkCore;
using WeatherInformation.Models;
using WeatherInformation.Repositories;
using WeatherInformation.Services;
using WeatherInformation.Services.Interfaces;

namespace WeatherInformation
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Host.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });

            builder.Services.AddDbContext<WeatherInfoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
            // Add services to the container.
            builder.Services.AddScoped<IHttpClientExtensioncs, HttpClientExtensioncs>();
            builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();
            
            builder.Services.AddScoped<IWeatherInfoService, WeatherInfoService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
