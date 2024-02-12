using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    abstract class VehicleAbstract
    {
        public string Model { get; set; }

        public VehicleAbstract(string model)
        {
            Model = model;
        }
        public abstract void Drive();

        public abstract void Refuel(int refill);



    }
}
