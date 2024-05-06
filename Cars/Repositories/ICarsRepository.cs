using Cars.DB;
using Cars.Models;

namespace Cars.Repositories
{
    public interface ICarsRepository
    {
        public IEnumerable<Car> GetAllCars()
        ;

        public IEnumerable<Car> GetCarsByColor(string color)
        ;

        public Car AddNewCar(Car car)
       ;

        public void UpdateCar( Car car)
        ;

        public void DeleteCar(int id)
        ;

        public Car GetCarById(int id);
    }
}
