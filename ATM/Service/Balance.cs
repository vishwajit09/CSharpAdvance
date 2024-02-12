using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Interface;

namespace ATM.Service
{
    internal class Balance : IBalance
    {
        decimal currentamount = 0;

        public void CheckBalance(string account, string path)
        {

            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                Account newaccount = new Account();
                newaccount.BankAccount = parts[1];
                if (parts[1] == account)
                {
                    currentamount = decimal.Parse(parts[4]);

                    break;
                }
            }
            Console.WriteLine($"Your Balance is {currentamount}");
        }


    }
}
