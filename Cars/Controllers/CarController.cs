using Cars.ActionFilters;
using Cars.Dto;
using Cars.DTOs;
using Cars.Models;
using Cars.Services;
using Cars.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Cars.Controllers
{
    public class CarController : Controller
    {
        private ICarService _carService;
        private readonly ILogger<CarController> _logger;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        public CarController(ICarService carService, ILogger<CarController> logger, IUserService userService = null, IJwtService jwtService = null)
        {
            _carService = carService;
            _logger = logger;
            _userService = userService;
            _jwtService = jwtService;
        }


        [HttpPost("Login")]
       
        public ActionResult<ResponseDto> Login([FromBody] UserDto request)
        {
            var response = _userService.Login(request.Username, request.Password);
            //var role = string.Empty;
            if (!response.IsSuccess)
                return BadRequest(response.Message);
            else
            {
                
              response.Message =   _jwtService.GetJwtToken(request.Username,response.Role);
                return Ok(response);
            }
            
        }

        [HttpPost("CreateAdmin")]
        public ActionResult<ResponseDto> SignupAdmin([FromBody] UserDto request)
        {
            var response = _userService.SignupAdmin(request.Username, request.Password);
            if (!response.IsSuccess)
                return BadRequest(response.Message);
            return response;
        }

        [HttpPost("Signup")]
        public ActionResult<ResponseDto> Signup([FromBody] UserDto request)
        {
            var response = _userService.Signup(request.Username, request.Password);
            if (!response.IsSuccess)
                return BadRequest(response.Message);
            return response;
        }

        [HttpPost("UpdateRole")]
        //[Authorize(Roles = "Admin")]
        public ActionResult<ResponseDto> UpdateRole([FromQuery] string userName ,string Role)
        {
            var response = _userService.UpdateUserRole(userName, Role);
            if (!response.IsSuccess)
                return BadRequest(response.Message);
            return response;
        }

        [HttpGet("GetAllCars")]
        //[Authorize(Roles = "Admin")]   //Jwt
        [ApiKeyAuth] //apikey
        public IActionResult GetAllCars()
        {
            return Ok(_carService.GetAllCars());
        }

        [HttpGet("GetCarsbyColor")]
        //[Authorize(Roles = "User")]  //jwt
        [ApiKeyAuth]  //APiKEy
        public IActionResult GetCarsbyColor([FromQuery] string color)
        {
            return Ok(_carService.GetCarsByColor(color)); ;
        }

        // POST: CarController/Create
        [HttpPost("AddNewCar")]
        //[Authorize]
        public ActionResult AddNewCar([FromBody] CarDto carDto)
        {
            _logger.LogInformation("Started adding new Car");
            var car = new Car {
                Make = carDto.Make,
                Model = carDto.Model,
                Year = carDto.Year,
                Color = carDto.Color
            };
             _carService.AddNewCar(car);
            
            _logger.LogInformation("in AddNewCar with new car id:{Id} Make:{Make} Year:{ Year} Colour:{Colour}", car.Id, car.Make, car.Year, car.Color);
            return Ok(car);
        }

        [HttpPut("UpdateCar")]
        //[Authorize]
        public IActionResult UpdateCar([FromQuery] int id, [FromBody] CarDto carDto)
        {
            _carService.UpdateCar(id, carDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            _carService.DeleteCar(id);
            return NoContent();
        }
    }
}
