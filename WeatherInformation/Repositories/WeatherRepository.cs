using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using WeatherInformation.Models;

namespace WeatherInformation.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly WeatherInfoDbContext _weatherInfoDbContext;
        private readonly ILogger<WeatherRepository> _logger;
        public WeatherRepository(WeatherInfoDbContext weatherInfoDbContext, ILogger<WeatherRepository> logger)
        {
            _weatherInfoDbContext = weatherInfoDbContext;
            _logger = logger;
        }

        public async Task AddWeatherInfoAsync(WeatherInfo weatherInfo)
        {
            try
            {
                _weatherInfoDbContext.WeatherInfos.Add(weatherInfo);
                await _weatherInfoDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {

                if (e.InnerException is SqlException sqlException && sqlException.Number == 2627)
                {
                    _logger.LogError("Value already present");
                }
                else
                {
                    _logger.LogError($"Error: {e.Message}");    
                }
            }
            
        }
    }
}
