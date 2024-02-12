using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class Screen
    {
        public static void ShowMenu1()
        {
            Console.Clear();
            Console.WriteLine(" ------------------------");
            Console.WriteLine("| ATM Main Menu          |");
            Console.WriteLine("|                        |");
            Console.WriteLine("| 1. Insert ATM card     |");
            Console.WriteLine("| 2. Exit                |");
            Console.WriteLine("|                        |");
            Console.WriteLine(" ------------------------");
        }

        public static void ShowMenu2()
        {
            Console.Clear();
            Console.WriteLine(" ---------------------------");
            Console.WriteLine("|  ATM Menu                  |");
            Console.WriteLine("|                            |");
            Console.WriteLine("| 1. Balance Enquiry         |");
            Console.WriteLine("| 2. Cash Deposit            |");
            Console.WriteLine("| 3. Withdrawal              |");
            Console.WriteLine("| 4. Transactions            |");
            Console.WriteLine("| 5. Logout                  |");
            Console.WriteLine("|                            |");
            Console.WriteLine(" ---------------------------");
        }
    }
}
