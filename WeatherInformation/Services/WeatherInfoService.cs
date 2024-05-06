using System;
using WeatherInformation.Dto;
using WeatherInformation.Models;
using WeatherInformation.Repositories;
using WeatherInformation.Services.Interfaces;

namespace WeatherInformation.Services
{
    public class WeatherInfoService: IWeatherInfoService
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly Logger<WeatherInfoService> _logger;

        public WeatherInfoService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
           
        }

        public async Task<WeatherInfo> AddWeather(WeatherDto weatherDto)
        {
            WeatherInfo weatherInfo = new WeatherInfo { city = weatherDto.address, timezone = weatherDto.timezone, resolvedAddress = weatherDto.resolvedAddress ,
                datetime = weatherDto.days[0].datetime, tempmax = weatherDto.days[0].tempmax , tempmin = weatherDto.days[0].tempmin};
           await _weatherRepository.AddWeatherInfoAsync(weatherInfo);
            return weatherInfo;
        }
    }
}
