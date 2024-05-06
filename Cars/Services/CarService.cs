using Cars.Dto;
using Cars.Models;
using Cars.Repositories;
using Cars.Services.Interface;

namespace Cars.Services
{
    public class CarService:ICarService
    {
        private ICarsRepository _carsRepository;
        private readonly ILogger _logger;
        public CarService(ICarsRepository carsRepository, ILogger<CarService> logger)
        {
            _carsRepository = carsRepository;
            _logger = logger;
        }

        public Car AddNewCar(Car car)
        {
            _logger.LogTrace("Started adding new Car");
            return _carsRepository.AddNewCar(car);
        }

        public void DeleteCar(int id)
        {
            _carsRepository.DeleteCar(id);
            _logger.LogInformation("Deleted Car");
        }

        public IEnumerable<Car> GetAllCars()
        {
            _logger.LogInformation($"{nameof(GetAllCars)}");
            return _carsRepository.GetAllCars();    
            
        }

        public IEnumerable<Car> GetCarsByColor(string color)
        {
            return _carsRepository.GetCarsByColor(color);
        }

        public void UpdateCar(int id, CarDto carDto)
        {
            
            var existingCar = _carsRepository.GetCarById(id);
            if (existingCar == null)
                return ;
            
            existingCar.Make = carDto.Make;
            existingCar.Model = carDto.Model;
            existingCar.Year = carDto.Year;
            existingCar.Color = carDto.Color;

            _carsRepository.UpdateCar(existingCar);
            
        }
    }
}
