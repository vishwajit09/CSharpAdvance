using AutoFixture.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestPracticeApplication.Models;

namespace UnitTestPracticeApplicationTests
{
    internal class BookSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (request is Type type && type == typeof(Book))
            {
                return new Book { Genre= new Genre { Id = new Guid(),Name = "Children book" }, Id = new Guid() , Title = "Harry Potter" };
            }
            return new NoSpecimen();
        }
    }
}
