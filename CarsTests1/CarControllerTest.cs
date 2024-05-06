using AutoFixture;
using AutoFixture.Xunit2;
using Cars.Controllers;
using Cars.Models;
using Cars.Repositories;
using Cars.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Runtime.InteropServices;

namespace CarsTests1
{
    public class CarControllerTest
    {

        //private readonly Fixture _fixture = new Fixture();
        


        //public CarControllerTest()
        //{
        //    _fixture.Customizations.Add(new CarSpecimenBuilder());
        //}

        [Theory,AutoData]
        public void Test1(List<Car> cars)
        {
            //Arrange
           
            var loggerMock = new Mock<ILogger<CarController>>();
            var carServiceMock = new Mock<ICarService>();
         //   var repositortMock = new Mock<ICarsRepository>();
            var sut = new CarController(carServiceMock.Object, loggerMock.Object);
            carServiceMock.Setup(x=>x.GetAllCars()).Returns(cars);

            //Act
            var testResponse = sut.GetAllCars();

            //Assert

            Assert.IsType<OkObjectResult>(testResponse);




        }

        [Theory, CustomerDataAttribute]
        public void Repository_Return_Car_Object_Correctly(List<Car> cars)
        {
            //Arrange      
            var loggerMock = new Mock<ILogger<CarController>>();
            var carServiceMock = new Mock<ICarService>();
          //  var repositortMock = new Mock<ICarsRepository>();
            var sut = new CarController(carServiceMock.Object, loggerMock.Object);
            carServiceMock.Setup(x => x.GetAllCars()).Returns(cars);

            //Act
            var testResponse = sut.GetAllCars();

            //Assert

            Assert.IsType<OkObjectResult>(testResponse);

        }

    }
}