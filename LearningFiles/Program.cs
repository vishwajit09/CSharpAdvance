using System.Text;

namespace LearningFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Task1();
            // Task2();
            //Task2_1();
            Task2_2();


        }

        static void Task1()
        {
            string path = "Text.txt";
            Console.WriteLine(File.ReadAllText(path));
            List<string> list = new List<string>();

            Console.WriteLine("---------------------------");
            list.Add("Merry had a little lamb");
            list.Add("Liitle Lamb");
            list.Add("Whereever Merry Goes the lamb was sure to follow");

            File.WriteAllLines(path, list);

            Console.WriteLine(File.ReadAllText(path));

            File.Copy("Text.txt", "Text1.txt");
        }

        static void Task2()
        {
            string path = "LargeTextFile.txt";

            int linenumber = 1;
            foreach (var item in File.ReadAllLines(path))
            {
                Console.WriteLine($"Line : {linenumber} -- No of Character : {item.ToString().Length}");
                linenumber++;
            }
        }

        static void Task2_1()
        {

            Random random = new Random();

            using (var writer = new StreamWriter("Text2.txt"))
            {
                for (int i = 0; i < 10; i++)
                {
                    writer.WriteLine("Abcdf");
                    writer.WriteLine(random.Next(1, 10));
                }
            }
        }

        static void Task2_2()
        {


            using (var fileStream = new FileStream("Stream.txt", FileMode.Create))
            {

                using (var writer = new BinaryWriter(fileStream))
                {
                    writer.Write("Test1");
                    writer.Write("Test2");
                    writer.Write(1111);
                    writer.Write(true);
                }
            }

            string result = "";
            using (var fileStream = new FileStream("Stream.txt", FileMode.Open))
            {
                {

                    using (var reader = new BinaryReader(fileStream))
                    {
                        //byte[] buffer = reader.ReadBytes(1000);
                        //result = Encoding.ASCII.GetString(buffer);
                        //Console.WriteLine(result);
                        Console.WriteLine(reader.ReadString());
                        Console.WriteLine(reader.ReadString());
                        Console.WriteLine(reader.ReadInt32());
                        Console.WriteLine(reader.ReadBoolean());
                        Console.WriteLine(reader.PeekChar());

                    }
                }
            }


        }
    }
}
