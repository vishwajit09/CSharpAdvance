using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests
{
    public class Level1TaskMethodTest
    {

        [Theory]
        [InlineData("A", 10, 20)]
        [InlineData("B", 20, 40)]
        [InlineData("C", 30, 60)]
        public void TotalCartValue_Returns_Correct_Total(string product, double value, double expectedTotal)
        {
            //Static method

            // Act
            double total = Leve1TaskMethod.TotalCartValue(product, value);

            // Assert
            Assert.Equal(expectedTotal, total);
        }

        [Theory]
        [InlineData(101, "The number is greater than 100")]
        [InlineData(100, "The number is equal to 100")]
        [InlineData(99, "The number is less than 100")]
        public void Task1_Returns_Correct_Message(int num, string expectedMessage)
        {
            // Arrange
            var leve1TaskMethod = new Leve1TaskMethod();

            // Act
            string message = leve1TaskMethod.Task1(num);

            // Assert
            Assert.Equal(expectedMessage, message);
        }

        [Theory]
        [InlineData(1, "Monday")]
        [InlineData(2, "Tuesday")]
        [InlineData(3, "Wednesday")]
        [InlineData(4, "Thursday")]
        [InlineData(5, "Friday")]
        [InlineData(6, "Saturday")]
        [InlineData(7, "Sunday")]
        [InlineData(8, "Incorrect day number")]
        public void Task2_Returns_Correct_Day(int day, string expectedDay)
        {
            // Arrange
            var leve1TaskMethod = new Leve1TaskMethod();

            // Act
            string actualDay = leve1TaskMethod.Task2(day);

            // Assert
            Assert.Equal(expectedDay, actualDay);
        }

        [Fact]
        public void DayOfTheWeek_ReturnsMonday_ForDay1()
        {
            // Arrange
            var leve1TaskMethod = new Leve1TaskMethod();
            int day = 1;

            // Act
            var result = leve1TaskMethod.DayOfTheWeek(day);

            // Assert
            Assert.Equal("Monday", result);
        }

        [Fact]
        public void DayOfTheWeek_ReturnsSunday_ForDay7()
        {
            // Arrange
            var leve1TaskMethod = new Leve1TaskMethod();
            int day = 7;

            // Act
            var result = leve1TaskMethod.DayOfTheWeek(day);

            // Assert
            Assert.Equal("Sunday", result);
        }

        [Theory]
        [InlineData(10, "Sutdent")]
        [InlineData(20, "Student")]
        [InlineData(30, "Employee")]
        [InlineData(70, "Retired")]
        public void PersonStatus_ReturnsCorrectStatus(int age, string expectedStatus)
        {
            // Arrange
            var leve1TaskMethod = new Leve1TaskMethod();

            // Act
            var result = leve1TaskMethod.PersonStatus(age);

            // Assert
            Assert.Equal(expectedStatus, result);
        }


        [Fact]

        public void FirstLetterCaps_ReturnsStringWithFirstLetterCapitalized()
        {
            // Arrange
            var leve1TaskMethod = new Leve1TaskMethod();
            string inputString = "hello";

            // Act
            var result = leve1TaskMethod.FirstLetterCaps(inputString);

            // Assert
            Assert.Equal("Hello", result);
        }

        [Fact]
        public void WhileAdd_Returns5_WhenInitialValueIsLessThan5()
        {
            // Arrange
            var leve1TaskMethod = new Leve1TaskMethod();
            int value = 3;

            // Act
            var result = leve1TaskMethod.WhileAdd(value);

            // Assert
            Assert.Equal(5, result);
        }
    }
}
