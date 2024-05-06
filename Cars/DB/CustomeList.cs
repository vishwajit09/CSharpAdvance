using Cars.Models;

namespace Cars.DB
{
    public class CustomeList:List<Car>
    {
        private int _id =0;
        public new void Add(Car car) {
          car.Id = _id++;
base.Add(car);
        }
    }
}
