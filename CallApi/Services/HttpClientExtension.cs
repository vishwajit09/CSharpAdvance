using CallApi.Dtos;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace CallApi.Services
{
    public class HttpClientExtension : IHttpClientExtension
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<HttpClientExtension> _logger;

        public HttpClientExtension(IConfiguration configuration, ILogger<HttpClientExtension> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<List<CarDto>> GetListCarInformation()
        {
            string key = _configuration.GetValue<string>("ApiKey");

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://localhost:5152/GetAllCars")
            };
            client.DefaultRequestHeaders.Add("ApiKey", key);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var carDto = JsonConvert.DeserializeObject<List<CarDto>>(body);
                return carDto;
            }
            else
            {
                _logger.LogError(response.ToString());
                return null;
            }
        }


    }
}
