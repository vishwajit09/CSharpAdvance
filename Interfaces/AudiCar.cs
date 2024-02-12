using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class AudiCar : VehicleAbstract
    {

        public readonly int _TankSize;
        public bool IsQuattro { get; set; }
        public int Fuel { get; set; }


        public AudiCar(string model, int fuel, int tanksize, bool isQuattro) : base(model)
        {

            _TankSize = tanksize;
            IsQuattro = isQuattro;
            Fuel = fuel;

        }


        public override void Drive()
        {
            if (Fuel > 2)
            {
                Console.WriteLine($"Driving  : {Model}");
            }
            else { Console.WriteLine("Time to refill"); }
        }

        public override void Refuel(int refill)
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