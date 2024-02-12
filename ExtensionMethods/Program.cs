using System.IO;
using System.Runtime.InteropServices;

namespace ExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1_1();

            //Task1_2();
            //Task1_3();
            ////  Task1_4();
            //Task1_5();
            //Task1_6();
            //Task1_7();
            Task1_8();
        }

        public static void Task1_1()
        {
            int number = 0;

            Console.WriteLine($"{number} is positive {number.PositiveOrNegative()}");

            number = -1;

            Console.WriteLine($"{number} is positive {number.PositiveOrNegative()}");
            Console.WriteLine("------------------------");
        }

        public static void Task1_2()
        {
            int number = 10;

            Console.WriteLine($"{number} is Even :{number.EvenOdd()}");

            number = 3;

            Console.WriteLine($"{number} is Even : {number.EvenOdd()}");
            Console.WriteLine("------------------------");
        }

        public static void Task1_3()
        {
            int number = 10;

            Console.WriteLine($"number is greater then value passed  {number.Greater(5)}");

            Console.WriteLine($"number is greater then value passed {number.Greater(11)}");
            Console.WriteLine("------------------------");
        }

        public static void Task1_4()
        {
            Console.WriteLine("Enter a string to find if it has spaces or not ");
            string str = Console.ReadLine();

            Console.WriteLine($"string contains space :   {str.ContainSpace()}");

            Console.WriteLine("------------------------");
        }

        public static void Task1_5()
        {

            string email = string.Empty;

            Console.WriteLine($"your email Email address is :   {email.BuildEmail("Aadvik", 2021, "gmail.com")}");

            Console.WriteLine("------------------------");
        }

        public static void Task1_6()
        {
            List<object> list = new List<object>();


            object email = "email";
            list.Add(email);
            object test = "Test";
            list.Add(test);

            object five = "four";
            Console.WriteLine(list.FindAndReturnIfEqual(email));
            Console.WriteLine(list.FindAndReturnIfEqual(five));

            Console.WriteLine("------------------------");
        }

        public static void Task1_7()
        {
            List<string> list = new List<string>() { "a", "b", "c", "e", "f", "g", "h", "i", "j" };

            foreach (string str in list)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine("------------------------");

            foreach (var item in list.EveryOtherWord())
            {
                Console.WriteLine(item);
            }
        }

        public static void Task1_8()
        {
            string path = "text.txt";
            FileStream fs = File.OpenRead(path);

            string data = fs.EverySecondLine();

            Console.WriteLine(data);





        }


    }
}
