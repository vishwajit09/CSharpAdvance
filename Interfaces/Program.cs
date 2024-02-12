using Interfaces.Day2;
using Interfaces.Day2Task2;
using Interfaces.Day2Task3;

namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task1();
            //Task2();
            //Task3();
            //  Day2Task1();
            Day2Task2();
            // Day2Task3();
        }

        public static void Task1()
        {
            Car bmw = new Car("BMW", 10, 50);
            Car audi = new Car("Audi", 20, 70);

            bmw.Drive();
            bmw.Refuel(30);

            audi.Drive();
            audi.Refuel(100);

            Console.WriteLine(audi.Model);
            Console.WriteLine(bmw.Model);
        }
        public static void Task2()
        {
            var bmw = new BmWCar("BMW", 10, 50, true);
            var audi = new AudiCar("Audi", 20, 70, false);

            bmw.Drive();
            bmw.Refuel(30);

            audi.Drive();
            audi.Refuel(100);

            Console.WriteLine(audi.Model);
            Console.WriteLine(bmw.Model);


        }
        public static void Task3()
        {
            var bmwcars = new List<Car> { new Car("BMW", 10, 50), new Car("Audi", 10, 50) };
            var carcomparer = new CarComparer();

            bmwcars.Sort(carcomparer);

            foreach (var item in bmwcars)
            {
                Console.WriteLine(item.Model);
            }

        }


        public static void Day2Task1()
        {
            List<Cat> cats = new List<Cat> { new Cat("Charlie"), new Cat("Lily"), new Cat("Kitty") };
            List<Dog> dogs = new List<Dog> { new Dog("Bella"), new Dog("Max"), new Dog("Luna") };

            List<Bass> basses = new List<Bass> { new Bass("Spotted"), new Bass("White"), new Bass("Striped") };

            List<Carp> carps = new List<Carp> { new Carp("Grass "), new Carp("Bighead "), new Carp("Catla") };



            foreach (var item in cats)
            {
                item.Sleep();
                item.Drink();
                item.Eat();
                item.Sound();
            }
            Console.WriteLine("---------------After Compare----------------------");

            cats.Sort();

            foreach (var item in cats)
            {
                item.Sleep();
                item.Drink();
                item.Eat();
                item.Sound();
            }
            Console.WriteLine("--------------------Dogs--------------------");



            foreach (var item in dogs)
            {
                item.Sleep();
                item.Drink();
                item.Eat();
                item.Sound();
            }
            dogs.Sort();
            Console.WriteLine("---------------After Compare----------------------");

            foreach (var item in dogs)
            {
                item.Sleep();
                item.Drink();
                item.Eat();
                item.Sound();
            }
            dogs.Sort();
            Console.WriteLine("--------------------------------------------");

            foreach (var item in basses)
            {
                item.Sleep();
                item.Drink();
                item.Eat();
                item.Sound();
                item.Swim();
            }
            Console.WriteLine("--------------------------------------------");

            foreach (var item in carps)
            {
                item.Sleep();
                item.Drink();
                item.Eat();
                item.Sound();
                item.Swim();
                item.Drink();
            }
        }

        public static void Day2Task2()
        {


            Hexagon hexagon = new Hexagon(10);
            Console.WriteLine($"Area of Hexagon is - {hexagon.GetArea()} ");


            Quadrilateral quadrilateral = new Quadrilateral(2, 10, 12, 14);
            Console.WriteLine($"Area of Quadrilateral is - {quadrilateral.GetArea()} ");


            Triangle triangle = new Triangle(10, 12);
            Console.WriteLine($"Area of Triangle is - {triangle.GetArea()} ");



            List<Shapes> Shapes = new List<Shapes> {new Shapes("Hexagon", hexagon.GetArea())
             ,new Shapes("Quadrilateral", quadrilateral.GetArea()),
             new Shapes("Triangle", triangle.GetArea())

            };
            Console.WriteLine("--------------------------------");
            AreaComparer areaComparer = new AreaComparer();

            foreach (var item in Shapes)
            {
                Console.WriteLine($"{item}");
            }

            Shapes.Sort(areaComparer);

            Console.WriteLine("--------------After compare---------------");


            foreach (var item in Shapes)
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine("------------------Using I comparable-----------");
            Shapes.Sort();



            foreach (var item in Shapes)
            {
                Console.WriteLine($"{item}");
            }
        }

        public static void Day2Task3()
        {
            List<IWritable> list = new List<IWritable> { new Hexagon(10), new Quadrilateral(2, 10, 12, 14), new Triangle(10, 12) };

            string path = @"D:\C#learning\LearningFiles\test.txt";

            foreach (var item in list)
            {
                item.WriteToFile(path);
            }

        }
    }
}
