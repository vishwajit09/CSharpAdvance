using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ATM.Interface;

namespace ATM.Service
{
    internal class Login : Ilogin
    {
        public Account Account { get; set; }
        public Login()
        {
        }

        public void CheckCardNoPIN()
        {
            int retry = 0;
            Account inputAccount = new Account();
            Console.Write("Enter ATM Card Number: ");
            inputAccount.CardNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter 4 digit pin");

            inputAccount.Pin = Convert.ToInt32(Console.ReadLine());

            Account = inputAccount.FindAccount(inputAccount.CardNumber, inputAccount.Pin);

            while (Account == null && retry < 2)
            {
                Console.WriteLine($"Enter Correct Pin - Retry left {3 - retry - 1}");
                inputAccount.Pin = Convert.ToInt32(Console.ReadLine());
                Account = inputAccount.FindAccount(inputAccount.CardNumber, inputAccount.Pin);
                retry++;
            }
            if (Account == null)
            {
                Console.WriteLine("Account is Locked !!!  ");
                //Console.Clear();
                Environment.Exit(1);
                Console.ReadKey();
            }



        }
    }
}

