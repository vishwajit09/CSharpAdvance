using System.Globalization;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task();
            //Task2();
            //Task3();
            Task4();


        }

        static void Task()
        {

            object[] values = { "123.456.789,0123", 0, DateTime.Now, 'c' };

            Console.WriteLine("{0,-22} {1,-20} \n", "String to Convert",
                              "Default/Exception");

            // Convert each string to a Double with and without the provider.
            foreach (var value in values)
            {
                Console.Write("{0,-22} ", value);
                try
                {
                    Console.WriteLine("{0,-20} ", Convert.ToDouble(value));
                }
                catch (FormatException e)
                {
                    Console.WriteLine("{0,-20} ", e.GetType().Name);
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine("{0,-20} ", e.GetType().Name);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0,-20} ", e.GetType().Name);
                }

            }

            var doublemax = double.MaxValue + double.MaxValue;
            Console.WriteLine(Convert.ToDouble(doublemax));

        }

        static void Task2()
        {
            int[] arr = { 1, 2, 3, 4, 5 };

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            try
            {
                Console.WriteLine(arr[7]);
            }
            catch (IndexOutOfRangeException e)
            {

                Console.WriteLine(e.ToString());
            }
            ;

        }

        static void Task3()
        {
            //int[] arr = { 19, 0, 75, 52 };
            int[] arr = { 19, 1, 75, 52 };
            int length = 10;

            try
            {
                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine(arr[i] / arr[i + 1]);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        static void Task4()
        {
            FileReading fileReading = new FileReading();
            //fileReading.FileRead("test.txt");

            string path;
            //  path = null; //ArgumentNullException:
            //path = "c.test\\ee"; //DirectoryNotFoundException:
            path = "--\\-!";
            fileReading.FileRead(path);

        }





    }
}
