namespace AnonymousMethods
{
    internal class Program
    {
        public delegate void GetFullNameAge(string firstName, string secondName, double age);
        public delegate int Number(int number1, int number2);
        public delegate List<int> GetElement(List<int> list, int step);
        public delegate string TypeFinder<T>(T element);


        public delegate bool Filter(Person person);
        static void Main(string[] args)
        {
            // Run();

            GetFullNameAge getFullNameAge = delegate (string firstName, string secondName, double age)
            {
                Console.WriteLine($"Name {firstName}  {secondName}  and Age is {age}");
            };
            getFullNameAge("Aadvik", "Singh", 2.5);

            //Task2
            Console.WriteLine("-------------------Task2-------------");

            Number number = delegate (int number1, int number2)
            {

                return number1 + number2;
            };
            Console.WriteLine(number(1, 2));

            number = delegate (int number1, int number2)
            {

                return number1 - number2;
            };
            Console.WriteLine(number(5, 2));

            //Task3()
            Console.WriteLine("-------------------Task3-------------");
            GetElement getNextElement = delegate (List<int> list, int element)
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
            };
            List<int> list = getNextElement(new List<int> { 1, 2, 3, 4, 5, 6 }, 4);
            foreach (int element in list) { Console.WriteLine(element); }

            Console.WriteLine("-------------------Task4-------------");
            //Task4()

            TypeFinder<string> type = delegate (string type)
            {
                return type.GetType().ToString();
            };
            Console.WriteLine(type("A"));

            Console.WriteLine("-------------------Task4-------------");

            //Task3


            List<Person> people = new List<Person>();
            people.Add(new Person("Test1", 17));
            people.Add(new Person("Test2", 15));
            people.Add(new Person("Test3", 82));
            people.Add(new Person("Test4", 10));
            people.Add(new Person("Test5", 65));
            people.Add(new Person("Test6", 24));
            people.Add(new Person("Test7", 67));
            people.Add(new Person("Test8", 39));

            static bool IsChild(Person person) { return person.Age < 18; }
            static bool IsAdult(Person person) { return person.Age >= 18 && person.Age < 65; }
            static bool IsSenior(Person person) { return person.Age >= 65; }

            DisplayPeople("Children", people, IsChild);
            DisplayPeople("Adult", people, IsAdult);
            DisplayPeople("Senior", people, IsSenior);

            static void DisplayPeople(string title, List<Person> people, Filter filter)
            {


                Console.WriteLine(title);

                foreach (Person person in people)
                {
                    if (filter(person))
                    {
                        Console.WriteLine($"  {person.Name}");
                    }
                }
            }


            var people1 = people.OrderBy(person => person.Age);
            List<Person> people2 = people.Where(person => person.Age > 18).ToList();
            var people3 = people.Select(person => new Person(person.Name, person.Age + 1));
            foreach (var item in people1)
            {
                Console.WriteLine($"{item.Name} {item.Age}");
            }
            Console.WriteLine("------------------------------");

            foreach (var item1 in people3)
            {
                Console.WriteLine($"{item1.Name} {item1.Age}");
            }
        }








    }
}
