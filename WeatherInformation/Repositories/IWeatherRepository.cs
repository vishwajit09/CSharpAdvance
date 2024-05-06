using WeatherInformation.Models;

namespace WeatherInformation.Repositories
{
    public interface IWeatherRepository
    {
        Task AddWeatherInfoAsync(WeatherInfo weatherInfo);
    }
}
