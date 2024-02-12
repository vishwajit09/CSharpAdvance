namespace LearningGeneric
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // var validate = new Validation<string>();
            //validate.Validate(null);
            //validate.Validate<string>(null);

            // ShowValues("Test", 1);

            var mylist = new MySelfCreateList<string>();
            mylist.Add("a");
            mylist.Add("b");
            mylist.Add("c");
            mylist.Add("d");
            mylist.Print();

            mylist.DeleteElement("b");
            mylist.Print();

        }


        static void ShowValues<T1, T2>(T1 item1, T2 item2)
        {
            Console.WriteLine($"{item1}");
            Console.WriteLine($"{item2}");
        }




    }
}
