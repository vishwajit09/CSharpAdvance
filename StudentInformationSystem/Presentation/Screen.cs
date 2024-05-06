using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Presentation
{
    internal class Screen
    {


        public static void ShowMenu1()
        {
            Console.Clear();
            Console.WriteLine(" --------------------------------------------------------------");
            Console.WriteLine("|  Student Information System                                  |");
            Console.WriteLine("|                                                              |");
            Console.WriteLine("| 1. Create Department                                         |");
            Console.WriteLine("| 2. Add Student Dept                                          |");
            Console.WriteLine("| 3. Add Lecture to Dept                                       |");
            Console.WriteLine("| 4. Create Lecture AssignDept                                 |");
            Console.WriteLine("| 5. create Student assign existing dept & lecture             |");
            Console.WriteLine("| 6. Transfer Student                                          |");
            Console.WriteLine("| 7. Display Student in dept                                   |");
            Console.WriteLine("| 8. Display Lectures in dept                                  |");
            Console.WriteLine("| 9. Display Lectures by student                               |");
            Console.WriteLine("| 10. Add Student to Lecture                                   |");
            Console.WriteLine("| 11. EXIT                                                     |");
            Console.WriteLine(" --------------------------------------------------------------");
        }


    }
}
