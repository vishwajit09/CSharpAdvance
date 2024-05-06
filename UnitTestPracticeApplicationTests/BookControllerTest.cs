using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTestPracticeApplication.Controllers;
using UnitTestPracticeApplication.DTOs;
using UnitTestPracticeApplication.Models;
using UnitTestPracticeApplication.Services;

namespace UnitTestPracticeApplicationTests
{
    public class BookControllerTest
    {
        [Theory,PracticeData]
        public void BookController_Returns_Book_Object_Correctly(Book book)
        {
            //Arrange
            var bookServiceMock = new Mock<IBookService>();
            var sut = new BookController(bookServiceMock.Object);

            bookServiceMock.Setup(x=>x.GetBook(It.IsAny<string>())).Returns(book);
            //Act

            var testResponse = sut.GetBooks(It.IsAny<string>());

            //Assert

            Assert.Equal(testResponse.Value, book);
        }

        [Theory, PracticeData]
        public void BookController_RemoveBook_Book_Object_Correctly(Book book)
        {
            //Arrange
            var bookServiceMock = new Mock<IBookService>();
            var sut = new BookController(bookServiceMock.Object);

            //bookServiceMock.Setup(x => x.RemoveBook(It.IsAny<Guid>()));
            //Act

            sut.RemoveBook(It.IsAny<Guid>());

            //Assert
            bookServiceMock.Verify(x => x.RemoveBook(It.IsAny<Guid>()), Times.Once);
          
        }

        [Theory, PracticeData]
        public void BookController_Add_Book_Object_Correctly(ResponseDto responseDto)
        {
            //Arrange
            var bookServiceMock = new Mock<IBookService>();
            var sut = new BookController(bookServiceMock.Object);

            bookServiceMock.Setup(x => x.AddBook(It.IsAny<Book>())).Returns(responseDto);
            //Act

            var testResponse = sut.AddBook(It.IsAny<Book>());

            //Assert
            Assert.Equal(testResponse.Value, responseDto);

        }
    }
}