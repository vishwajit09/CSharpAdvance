using Cars.Dto;
using Cars.Models;

namespace Cars.Services.Interface
{
    public interface ICarService
    {
        public IEnumerable<Car> GetAllCars()
       ;

        public IEnumerable<Car> GetCarsByColor(string color)
        ;

        public Car AddNewCar(Car car)
       ;

        public void UpdateCar(int id, CarDto carDto) ;

        public void DeleteCar(int id)
        ;
       
    }
}
