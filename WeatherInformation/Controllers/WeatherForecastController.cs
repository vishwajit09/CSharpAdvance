using Microsoft.AspNetCore.Mvc;
using WeatherInformation.Repositories;
using WeatherInformation.Services;
using WeatherInformation.Services.Interfaces;

namespace WeatherInformation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly  IHttpClientExtensioncs _httpClientExtensioncs;
        private  ILogger<WeatherForecastController> _logger;
        private   IWeatherInfoService _weatherInfoService;

        public WeatherForecastController(IHttpClientExtensioncs httpClientExtensioncs, IWeatherInfoService WeatherInfoService, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _httpClientExtensioncs = httpClientExtensioncs;
            _weatherInfoService = WeatherInfoService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> GetWeatherInfo(string city)
        {
            try
            {
                var weatherDto = await _httpClientExtensioncs.GetWeatherInfoAsync(city);
                var weatherInfo = _weatherInfoService.AddWeather(weatherDto);

                return Ok(weatherInfo.Result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
