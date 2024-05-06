using AutoFixture;
using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsTests1
{
    internal class CustomerDataAttribute :AutoDataAttribute
    {
        public CustomerDataAttribute() : base(()=>

        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new CarSpecimenBuilder());
            return fixture;
        }
        )
        { }
    }
}
