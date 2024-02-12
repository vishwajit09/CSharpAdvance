using System;
using System.Security.Cryptography.X509Certificates;
using AnonymousMethods;

namespace Lamda_Linq
{
    internal class Program
    {
        public delegate bool Filter(Person person);

        static void Main(string[] args)
        {
            // MyTask();

            //  Task1_1();
            //  Task1_2();
            //Task1_3();
            //Task1_4();
            //Task1_5();
            //Task1_6();
            // Task1_7();

            // Task1_2();
            //  Task2();
            //  Task2_1();

            //var strings = Task2_2("THIS is METHOD for FINDING all UPPER case");
            //foreach (string s in strings)
            //{
            //    Console.WriteLine(s);
            //}
            Task3();





        }
        //Doube the number
        static void Task1_1()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            var newList = numbers.Select(x => x * x).ToList();
            foreach (int x in newList)
            {
                Console.WriteLine(x);
            }
        }

        static void Task1_2()
        {
            List<int> positiveNegative = Enumerable.Range(-10, 40).ToList();

            foreach (int x in positiveNegative)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("------------------------");
            var postiveNumberOnly = positiveNegative.Where(x => x >= 0).ToList();
            foreach (var item in postiveNumberOnly)
            {
                Console.WriteLine(item);
            }
        }
        static void Task1_3()
        {
            List<int> positiveNegative = Enumerable.Range(-10, 40).ToList();

            foreach (int x in positiveNegative)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("------------------------");
            var postiveNumberOnly = positiveNegative.Where(x => x > 10).ToList();
            foreach (var item in postiveNumberOnly)
            {
                Console.WriteLine(item);
            }


        }
        static void Task1_4()
        {
            Random random = new Random();
            List<int> positiveNegative = Enumerable.Range(20, 10).OrderBy(i => random.Next()).ToList();

            foreach (int x in positiveNegative)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("------------------------");
            var postiveNumberOnly = positiveNegative.OrderByDescending(x => x);
            foreach (var item in postiveNumberOnly)
            {
                Console.WriteLine(item);
            }


        }
        static void Task1_5()
        {
            Random random = new Random();
            List<int> positiveNegative = Enumerable.Range(40, 10).OrderBy(i => random.Next()).ToList();

            foreach (int x in positiveNegative)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("------------------------");
            var postiveNumberOnly = from num in positiveNegative
                                    orderby num descending
                                    select num;
            foreach (var item in postiveNumberOnly)
            {
                Console.WriteLine(item);
            }


        }

        static void Task1_6()
        {
            Random random = new Random();
            List<int> positivenumber = Enumerable.Range(40, 10).OrderBy(i => random.Next()).ToList();

            foreach (int x in positivenumber)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("------------------------");
            var postiveNumberOnly = positivenumber.Max();
            Console.WriteLine(postiveNumberOnly);

        }


        static void Task1_7()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person("Aest1", 17));
            people.Add(new Person("Test2", 15));
            people.Add(new Person("Test3", 82));
            people.Add(new Person("aest4", 10));
            people.Add(new Person("Test5", 65));
            people.Add(new Person("Test6", 24));
            people.Add(new Person("Aest7", 67));
            people.Add(new Person("Test8", 39));
            people.Add(new Person("Aest3", 42));

            var peopleNames = people.Select(person => person.Name).ToList(); ;
            var peopleAges = people.Select(person => person.Age).OrderByDescending(people => people);


            foreach (var item in peopleAges)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine("------------------------------");

            var peopleWithNameStartWithA = people.Where(people => people.Name.ToUpper().StartsWith("A")).Select(people => people.Name);

            foreach (var item in peopleWithNameStartWithA)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine("------------------------------");

            var peopleWithAge40Plus = people.Where(x => x.Age > 40).OrderByDescending(x => x.Name).Select(people => people.Name);

            foreach (var item1 in peopleWithAge40Plus)
            {
                Console.WriteLine($"{item1}");
            }
            Console.WriteLine("------------------------------");
        }


        public static void Task2()
        {


            List<AnimalPerson> animalPerson = new List<AnimalPerson>();


            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal("Dog"));
            animals.Add(new Animal("CAT"));
            AnimalPerson animalPerson1 = new AnimalPerson("Test", animals);


            List<Animal> animal1 = new List<Animal>();
            animal1.Add(new Animal("Hamster"));
            animal1.Add(new Animal("Monkey"));
            animal1.Add(new Animal("Mouse"));

            AnimalPerson animalPerson2 = new AnimalPerson("Test2", animal1);


            animalPerson.Add(animalPerson1);
            animalPerson.Add(animalPerson2);

            var allAnimal = animalPerson.Select(x => x.animals);

            foreach (var item in allAnimal)
            {
                foreach (var item1 in item)
                {
                    Console.WriteLine(item1.Name);
                }
            }

            Console.WriteLine("------------------------");

            var allAminalSelectmay = animalPerson.SelectMany(animalPerson => animalPerson.animals, (n, a) => (n.Name, a.Name)).Where(x => x.Item2.StartsWith("C")).Select(x => x.Item2);

            foreach (var item in allAminalSelectmay)
            {
                Console.WriteLine(item);
            }

        }
        public static void Task2_1()
        {


            List<Pet> pets = [new Pet("Angle", 10),
                new Pet("Demon", 4),
                new Pet("Araku", 7),
                new Pet("Abu", 3)

                ];


            var aminalstartA = from pet in pets
                               where pet.Age > 5 && pet.Name.StartsWith("A")
                               select pet;

            foreach (var item in aminalstartA)
            {
                Console.WriteLine(item.Name);
            }



        }

        public static IEnumerable<string> Task2_2(string parm)
        {
            string[] strings = parm.Split(new char[] { ' ' });

            var UpperWord = strings.Where(x => String.Equals(x, x.ToUpper(), StringComparison.Ordinal));

            return UpperWord;

        }

        public static void Task3()
        {
            string path = @"D:\C#learning\LearningFiles\Lamda&Linq";
            DirectoryInfo _directory = new DirectoryInfo(path);

            var AllfileTypes = _directory.GetFiles()
                                    .Select(file => file.Extension).Distinct().ToList();

            foreach (var file in AllfileTypes)
            {
                Console.WriteLine(file);
            }
            Console.WriteLine("---------------------");
            var fileTypes = _directory.GetFiles()
                                    .Where(file => file.Name.EndsWith(".txt"))
                                    .Select(file => file.Name).ToList();

            foreach (var file in fileTypes)
            {
                Console.WriteLine(file);
            }
            Console.WriteLine("---------------------");
            var fileNameTxt =
                    _directory.GetFiles().Where(file => file.Name.EndsWith(".txt")).Select(x => Path.GetFileNameWithoutExtension(x.FullName));

            foreach (var file in fileNameTxt)
            {
                Console.WriteLine(file);
            }

        }


    }

}

