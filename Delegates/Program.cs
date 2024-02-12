using static Delegates.Program;
using static System.Net.Mime.MediaTypeNames;

namespace Delegates
{
    internal class Program
    {
        public delegate void Logger(string message);
        public delegate string GetFullNameAge(string firstName, string secondName, double age);
        public delegate int Number(int number1, int number2);
        public delegate List<int> GetElement(List<int> list, int step);
        public delegate string TypeFinder<T>(T element);
        static void Main(string[] args)
        {
            // Run();

            GetFullNameAge getFullNameAge = new GetFullNameAge(NameAge);
            Console.WriteLine(getFullNameAge("Aadvik", "Singh", 2.5));

            //Task2
            Console.WriteLine("-------------------Task2-------------");

            Number number = new Number(Add);
            Console.WriteLine(number(1, 2));
            number = new Number(substract);
            Console.WriteLine(substract(5, 2));

            //Task3()
            Console.WriteLine("-------------------Task3-------------");
            GetElement getNextElement = new GetElement(GetNextElement);
            List<int> list = getNextElement(new List<int> { 1, 2, 3, 4, 5, 6 }, 4);
            foreach (int element in list) { Console.WriteLine(element); }

            Console.WriteLine("-------------------Task4-------------");
            //Task4()

            TypeFinder<string> type = new TypeFinder<string>(FindType);
            Console.WriteLine(type("A"));
        }




        public static string NameAge(string firstName, string secondName, double age)
        {
            return $" Name {firstName + " " + secondName}  and Age is {age}";
        }

        public static int Add(int number1, int number2)
        {

            return number1 + number2;
        }
        public static int substract(int number1, int number2)
        {

            return number1 - number2;
        }

        public static List<int> GetNextElement(List<int> list, int element)
        {
            bool Isfound = false;
            List<int> newList = new List<int>();
            //if (list.Contains(element))
            //{
            //    foreach (var item in list)
            //    {
            //        if (item == element)
            //        {
            //            Isfound = true;
            //        }
            //        if (Isfound)
            //        {
            //            newList.Add(item);
            //        }
            //    }
            //}
            newList = list.SkipWhile(x => x != element).Skip(1).ToList();
            return newList;
        }


        public static string FindType<T>(T type)
        {
            return type.GetType().ToString();
        }





        //static void ProcessData(Logger logMethod)
        //{
        //    // Do some data processing...
        //    logMethod("Data processed successfully.");
        //}

        //static void Run()
        //{
        //    Logger consoleLogger = message => Console.WriteLine("Console: " + message);
        //    Logger fileLogger = message => System.IO.File.WriteAllText("log.txt", message);

        //    ProcessData(consoleLogger);  // Logs to console
        //    ProcessData(fileLogger);  // Logs to a file
        //}
    }

}
