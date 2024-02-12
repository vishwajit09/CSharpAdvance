using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Service
{
    internal class Account
    {
        string path = @"D:\C#learning\LearningFiles\ATM\Files\Account.txt";

        public string FullName { get; set; }
        public string BankAccount { get; set; }
        public int CardNumber { get; set; }
        public int Pin { get; set; }
        public decimal Balance { get; set; }

        List<Account> accounts = new List<Account>();

        public void UpdateAccountDetails(decimal amount, string account)
        {

            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts[1] == account)
                {
                    decimal currentamount = decimal.Parse(parts[4]);
                    currentamount += amount;
                    lines[i] = parts[0] + "," + parts[1] + "," + parts[2] + "," + parts[3] + "," + currentamount;
                    break;
                }
            }
            File.WriteAllLines(path, lines);
        }

        public void CheckBalance(string account)
        {
            decimal currentamount = 0;
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


        public Account FindAccount(int cardNumber, int pin)
        {

            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] word = lines[i].Split(',');

                accounts.Add(new Account
                {
                    FullName = word[0],
                    BankAccount = word[1],
                    CardNumber = int.Parse(word[2]),
                    Pin = int.Parse(word[3]),
                    Balance = int.Parse(word[4])


                });
            }


            var result = (from account in accounts
                          where account.CardNumber == cardNumber
                          && account.Pin == pin
                          select account).FirstOrDefault();
            return result;
        }
    }


}
