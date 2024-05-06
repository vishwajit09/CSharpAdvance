using AutoFixture;
using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestPracticeApplicationTests
{
    internal class PracticeDataAttribute :AutoDataAttribute
    {
        public PracticeDataAttribute() : base(() =>
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new UserDTOSpecimenBuilder());
            fixture.Customizations.Add(new BookSpecimenBuilder());
            fixture.Customizations.Add( new UserSpecimenBuilder());
            
            return fixture;
        }
        )        
        { }
    }
}
    