using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using WeatherInformation.Dto;
using WeatherInformation.Models;
using WeatherInformation.Services.Interfaces;

namespace WeatherInformation.Services
{
    public class HttpClientExtensioncs : IHttpClientExtensioncs
    {

        private readonly IConfiguration _configuration;
        private readonly ILogger<HttpClientExtensioncs> _logger;
        public HttpClientExtensioncs(IConfiguration configuration, ILogger<HttpClientExtensioncs> logger)
        {

            _configuration = configuration;
            _logger = logger;
        }

        public async Task<WeatherDto> GetWeatherInfoAsync(string city)
        {
            string key = _configuration.GetValue<string>("ApiKey");
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/Vilnius?unitGroup=us&key=55WRFVDYT8K9H498JT47YZ23W&contentType=json")
            };
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode) 
            {
                var body = await response.Content.ReadAsStringAsync();
                WeatherDto weatherDto = JsonConvert.DeserializeObject<WeatherDto>(body);
                return weatherDto;
            }
            else
            {
               _logger.LogError(response.ToString());
                 throw new UnauthorizedAccessException();
            }
        }
    }
}
