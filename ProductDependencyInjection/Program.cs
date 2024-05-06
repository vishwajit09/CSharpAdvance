
using ProductDependencyInjection.Database;
using ProductDependencyInjection.Repositories;
using ProductDependencyInjection.Repositories.Interfaces;
using ProductDependencyInjection.Services;
using ProductDependencyInjection.Services.Interfaces;

namespace ProductDependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //my service
            builder.Services.AddSingleton<ProductDb>();
            builder.Services.AddScoped<IProductRepositories , ProductRepositories> ();
            builder.Services.AddScoped<IProductService, ProductService>();

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
