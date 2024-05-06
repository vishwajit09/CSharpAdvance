using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Presentation
{
    internal class Screen
    {


        public static void ShowMenu1()
        {
            Console.Clear();
            Console.WriteLine(" ---------------------------");
            Console.WriteLine("|  Resturant                 |");
            Console.WriteLine("|                            |");
            Console.WriteLine("| 1. Book a Table            |");
            Console.WriteLine("| 2. Take Order              |");
            Console.WriteLine("| 3. Add new Item to Order   |");
            Console.WriteLine("| 4. Print Voucher           |");
            Console.WriteLine("| 5. Send Email              |");
            Console.WriteLine("| 6. Free table              |");
            Console.WriteLine("| 7. Exit                    |");
            Console.WriteLine("|                            |");
            Console.WriteLine(" ---------------------------");
        }

        public static void ShowFoodAndDrink()
        {
            Console.Clear();
            Console.WriteLine(" ---------------------------");
            Console.WriteLine("|  Food & Drink Menu         |");
            Console.WriteLine("|                            |");
            Console.WriteLine("| 1. Food                    |");
            Console.WriteLine("| 2. Drink                   |");
            Console.WriteLine("| 3. Exit                    |");
            Console.WriteLine("|                            |");
            Console.WriteLine(" ---------------------------");
        }
    }
}
