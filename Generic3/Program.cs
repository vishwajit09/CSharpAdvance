using System.Collections;

namespace Generic3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Task1();

            Task2();



        }

        static void Task1()
        {
            var genericTypeInt = new GenericTypeT<int>(new List<int> { 1, 2, 3, 4, 1 });


            var genericTypeString = new GenericTypeT<string>(new List<String> { "abcd", "EFCG", "Test" });

            genericTypeInt.Print();
            Console.WriteLine("--------------------------");
            genericTypeString.Print();

            var arraytest = genericTypeInt.ConvertToArray();

            foreach (var item in arraytest)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("--------------------------");

            // var found = genericTypeInt.FindMatch(1);
            //Console.WriteLine(found);
            Console.WriteLine("--------------------------");
            var found = genericTypeInt.FindMatch(5);
            var found1 = genericTypeString.FindMatch(null);
            Console.WriteLine(found);
            Console.WriteLine("--------------------------");
            found = genericTypeInt.FindMatch(4);
            Console.WriteLine("--------------------------");
            Console.WriteLine(found);

            var found2 = genericTypeString.FindMatch("A");
            Console.WriteLine(found1);
        }

        static void Task2()
        {
            var genericList = new GenericList<int>();
            genericList.AddToList(1);
            genericList.AddToList(2);
            genericList.AddToList(3);

            genericList.Print();
            //foreach (var item in genericList.ConvertToArray())
            //{
            //    Console.WriteLine(item);
            //}
            ;
            Console.WriteLine("----------------------------");

            genericList.AddList(new List<int> { 5, 6, 7, 8, 1 });

            genericList.Print();
            Console.WriteLine("----------------------------");

            genericList.RemoveList(5);
            genericList.Print();
            Console.WriteLine("----------------------------");

            genericList.RemoveLisATt(2);
            genericList.Print();
            Console.WriteLine("----------------------------");

            genericList.RemoveAllSimilarItem(1);
            genericList.Print();
            Console.WriteLine("----------------------------");



        }
    }


}
