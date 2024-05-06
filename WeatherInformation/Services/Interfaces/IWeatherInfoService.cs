using WeatherInformation.Dto;
using WeatherInformation.Models;

namespace WeatherInformation.Services.Interfaces
{
    public interface IWeatherInfoService
    {
        Task<WeatherInfo> AddWeather(WeatherDto weatherDto);
    }
}
