using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorFuncation
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Subtract(double x, double y)
        {
            return x - y;
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Divide(double x, double y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return x / y;
        }

        public double Power(double x, double y)
        {
            return Math.Pow(x, y);
        }

        public double SquareRoot(double x)
        {
            if (x < 0)
            {
                throw new ArithmeticException("Cannot take square root of a negative number.");
            }
            return Math.Sqrt(x);
        }
    }

}
