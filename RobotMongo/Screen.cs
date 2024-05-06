using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMongo
{
    internal class Screen
    {
        public static void ShowMenu1()
        {
            Console.Clear();
            Console.WriteLine(" ---------------------------");
            Console.WriteLine("| ATM Main Menu             |");
            Console.WriteLine("|                           |");
            Console.WriteLine("| 1. Save Robort            |");
            Console.WriteLine("| 2. Save list of robot     |");
            Console.WriteLine("| 3. Find robot by Id       |");
            Console.WriteLine("| 4. Find robot by parameter|");
            Console.WriteLine("| 5. Delete Robot           |");
            Console.WriteLine("| 6. Modify robot           |");
            Console.WriteLine("| 7. Write all robot        |");
            Console.WriteLine("| 8. Exit                   |");
            Console.WriteLine(" ---------------------------");
        }
    }
}
