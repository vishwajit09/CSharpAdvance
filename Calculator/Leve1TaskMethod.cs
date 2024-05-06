using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Leve1TaskMethod
    {
        public static double TotalCartValue(string product, double value)
        {
            double total = 0;

            if (product == "A")
                total = value + 10;
            else if (product == "B")
                total = value + 20;
            else if (product == "C")
                total = value + 30;
            return total;
        }

        public string Task1(int num)
        {


            if (num > 100)
                return "The number is greater than 100";
            else if (num == 100)
                return "The number is equal to 100";

            else
                return "The number is less than 100";
        }

        public string Task2(int day)
        {

            if (day == 1)
                return "Monday";
            else if (day == 2)
                return "Tuesday";
            else if (day == 3)
                return "Wednesday";
            else if (day == 4)
                return "Thursday";
            else if (day == 5)
                return "Friday";
            else if (day == 6)
                return "Saturday";
            else if (day == 7)
                return "Sunday";
            else return "Incorrect day number";
        }

        public string DayOfTheWeek(int day)
        {
            string dayOfTheWeek = day switch
            {

                1 => "Monday",
                2 => "Tuesday",
                3 => "Wednesday",
                4 => "Thursday",
                5 => "Friday",
                6 => "Saturday",
                7 => "Sunday",
                _ => "unknows number "
            };
            return dayOfTheWeek;
        }

        public string PersonStatus(int age)
        {
            var status = age switch
            {

                >= 7 and <= 18 => "Sutdent",
                <= 25 => "Student",
                < 65 => "Employee",
                > 65 => "Retired",
                _ => "Still kid ;-)"
            };
            return status;

        }

        public string FirstLetterCaps(string firstLetter)
        {
            string word;
            char[] character;




            if (string.IsNullOrEmpty(firstLetter))
            {
                return "Please enter the string ";
            }
            else
            {
                char[] chars = firstLetter.ToCharArray();
                chars[0] = Char.ToUpper(chars[0]);
                return new string(chars);


            }

        }

        public int WhileAdd(int value)
        {

            while (value < 5)
            {
                value++;


            }
            return value;
        }


    }
}
