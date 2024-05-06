using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestPracticeApplication.Controllers;
using UnitTestPracticeApplication.DTOs;
using UnitTestPracticeApplication.Models;
using UnitTestPracticeApplication.Services;

namespace UnitTestPracticeApplicationTests
{
    public class UserControllerTests
    {
        [Theory ,PracticeData]
        public void Login_WithValidCredentials_ReturnsOkResult(UserDto userDto, ResponseDto expectedResponse)
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            var sut = new UserController(mockUserService.Object);
            // mockUserService.Setup(x=>x.
            mockUserService.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(expectedResponse);

            //Act
            var result = sut.Login(userDto);

            //Assert
                       

           // var okresult = Assert.IsType<OkObjectResult>(result.Result);

            Assert.Equal(expectedResponse, result.Value);
        }

        [Theory]
        [PracticeData]
        public void Signup_WithValidCredentials_ReturnsOkResult(        
        [Frozen] ResponseDto expectedResponse,        
        [Frozen] UserDto userDto)
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();
            var sut = new UserController(mockUserService.Object);
            mockUserService.Setup(service => service.Signup(It.IsAny<string>(), It.IsAny<string>())).Returns(expectedResponse);

            // Act
            var result = sut.Signup(userDto);

            // Assert
            Assert.IsType<ResponseDto>(result.Value);
            
            Assert.Equal(expectedResponse, result.Value);
        }

        [Theory]
        [PracticeData]
        public void Signup_WithInvalidCredentials_ReturnsBadRequest(        
         ResponseDto errorResponse,
            UserDto request)
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();
            var sut = new UserController(mockUserService.Object);
            errorResponse.IsSuccess = false;
            mockUserService.Setup(service => service.Signup(It.IsAny<string>(), It.IsAny<string>())).Returns(errorResponse);

            // Act
            var result = sut.Signup(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal(errorResponse.Message, badRequestResult.Value);
        }
    }

    

}
