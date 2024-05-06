using WeatherInformation.Dto;
using WeatherInformation.Models;

namespace WeatherInformation.Services.Interfaces
{
    public interface IHttpClientExtensioncs
    {
        Task<WeatherDto> GetWeatherInfoAsync(string city);
    }
}
