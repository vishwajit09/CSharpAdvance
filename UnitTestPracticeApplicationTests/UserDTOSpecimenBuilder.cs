using AutoFixture.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnitTestPracticeApplication.DTOs;
using UnitTestPracticeApplication.Models;

namespace UnitTestPracticeApplicationTests
{
    public class UserDTOSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (request is Type type && type == typeof(UserDto))
            {
               
                return new UserDto { Username = "Vish" ,Password = "Test"};
            }

            if (request is Type type1 && type1 == typeof(ResponseDto))
            {

                return new ResponseDto (true , "User logged in" );
            }
            return new NoSpecimen();
        }

        
    }
}
