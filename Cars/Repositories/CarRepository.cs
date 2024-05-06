using Cars.DB;
using Cars.Dto;
using Cars.Models;

namespace Cars.Repositories
{
    public class CarRepository:ICarsRepository
    {
       // private CarDb _dbContext;

        private readonly CarDBContext _dbContext;
        private readonly ILogger<CarRepository> _logger;
       

        public CarRepository(CarDBContext dBContext, ILogger<CarRepository> logger)
        {
            _dbContext = dBContext;
            _logger = logger;
        }

        public IEnumerable<Car> GetAllCars()
        {
            
            return _dbContext.Cars.ToList(); 
        }

        public IEnumerable<Car> GetCarsByColor(string color)
        {
            return _dbContext.Cars.Where(c => c.Color == color);
        }

        public Car AddNewCar(Car car)
        {
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();
            return car;
        }

        public void UpdateCar( Car car)
        {
                        
                _dbContext.Update(car);
                _dbContext.SaveChanges();        
            
            //_dbContext.Cars.Remove(existingCar);
            //_dbContext.Cars.Add(car);
            
        }

        public void DeleteCar(int id)
        {
            var existingCar = _dbContext.Cars.FirstOrDefault(c => c.Id == id);
            if (existingCar == null)
                return;
            else
            {
                _dbContext.Cars.Remove(existingCar);
                _dbContext.SaveChanges();
            }
        }

        public Car GetCarById(int id)
        {
            return _dbContext.Cars.FirstOrDefault(c => c.Id == id);
        }
    }
}
