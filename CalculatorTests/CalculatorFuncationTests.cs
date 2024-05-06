

using Calculator;
using System;
using System.ComponentModel;

namespace CalculatorTests
{
    public class CalculatorFuncationTests
    {
        [Fact]
        public void Add_TwoNumber_ReturnSum()
        {
            //Arrange 
            double number1 = 1;
            double number2 = 2;
            double expected = 3;
            CalculatorFuncation calculator = new CalculatorFuncation();

            //Act

            double result = calculator.Add(number1, number2);

            //Assert

            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(10, 3, 7)]
        [InlineData(20, 5, 15)]
        [InlineData(15, -3, 18)]
        public void Substract_TwoNumber_ReturnDifference(double number1, double number2, double expected)
        {
            //Arrange 
            //double number1 = 1;
            //double number2 = 2;
            //double expected = -1;
            CalculatorFuncation calculator = new CalculatorFuncation();

            //Act

            double result = calculator.Subtract(number1, number2);

            //Assert

            Assert.Equal(result, expected);
        }
        [Fact]
        public void Multiply_TwoNumber_ReturnProduct()
        {
            //Arrange 
            double number1 = 2;
            double number2 = 2;
            double expected = 4;
            CalculatorFuncation calculator = new CalculatorFuncation();

            //Act

            double result = calculator.Multiply(number1, number2);

            //Assert

            Assert.True(result == expected);
        }
        [Fact]
        public void Divide_TwoNumber_ReturnReminder()
        {
            //Arrange 
            double number1 = 15;
            double number2 = 3;
            CalculatorFuncation calculator = new CalculatorFuncation();

            //Act

            double result = calculator.Divide(number1, number2);

            //Assert

            Assert.InRange(result, 4.9, 5.1);
        }
        [Fact]
        public void Power_TwoNumber_ReturnSquare()
        {
            //Arrange 
            double number1 = 2;
            double number2 = 2;
            double expected = 4;
            CalculatorFuncation calculator = new CalculatorFuncation();

            //Act

            double result = calculator.Power(number1, number2);

            //Assert

            Assert.Equal(result, expected);
        }
        [Theory]
        [InlineData(9, 3)]
        [InlineData(4, 2)]


        public void SquareRoot_SingleNumber_ReturnSquareRoot(double number1, double expected)
        {
            //Arrange 
            //double number1 = 9;
            //double expected = 3;
            CalculatorFuncation calculator = new CalculatorFuncation();

            //Act

            double result = calculator.SquareRoot(number1);

            //Assert

            Assert.Equal(result, expected);
        }
        [Fact]
        public void SquareRoot_SingleNumber_ThrowArithmeticException()
        {
            //Arrange 
            double number1 = -1;
            string errorMessage = "Cannot take square root of a negative number.";
            var Claculator = new CalculatorFuncation();

            var action = () => Claculator.SquareRoot(number1);

            var exception = Assert.Throws<ArithmeticException>(() => Claculator.SquareRoot(number1));
            Assert.Equal(errorMessage, exception.Message);

        }
    }
}