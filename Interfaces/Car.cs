using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Car : IVehicle
    {
        public string Model { get; set; }
        public int Fuel { get; set; }

        private readonly int _TankSize;
        public Car(string model, int fuel, int tankSize)
        {
            Model = model;
            Fuel = fuel;
            _TankSize = tankSize;
        }

        public void Drive()
        {
            if (Fuel > 2)
            {
                Console.WriteLine($"Driving  : {Model}");
            }
            else { Console.WriteLine("Time to refill"); }

        }

        public void Refuel(int refill)
        {
            if (refill < 0)
            {
                Console.WriteLine(" Refill cannot be negative amount");
            }
            else
            {
                if (_TankSize > (refill + Fuel))
                {
                    Console.WriteLine($" Total fuel {Fuel + refill}");
                }
                else
                {
                    Console.WriteLine($"Cannot fill that much fuel Tank capicity is {_TankSize}");
                }


            }

        }
    }
}
