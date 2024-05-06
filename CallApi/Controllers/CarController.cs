using CallApi.Services;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace CallApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly IHttpClientExtension _httpClientExtension;
        private ILogger<CarController> _logger;

        public CarController(IHttpClientExtension httpClientExtension, ILogger<CarController> logger)
        {
            _httpClientExtension = httpClientExtension;
            _logger = logger;
        }

        [HttpGet(Name = "GetCarList")]
        public async Task<IActionResult> GetCarInformation()
        {
            try
            {

                var car = await _httpClientExtension.GetListCarInformation();


                return Ok(car);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpGet(Name = "GetCarbyColor")]
        //public async Task<IActionResult> GetCarbyColor()
        //{
        //    try
        //    {

        //        var car = await _httpClientExtension.GetCarbyColor();


        //        return Ok(car);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}
    }
}
