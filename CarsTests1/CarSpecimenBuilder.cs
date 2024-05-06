using AutoFixture.Kernel;
using Cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsTests1
{
    internal class CarSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
         
            if(request is Type type && type == typeof(Car)) {

                return new Car { Color = "Red", Id = 1, Model = "BMW", Make = "Sseries", Year = 2004 } ;
            
            }
            return new NoSpecimen();
        }
    }
}
