//using ATM.Database;
//using ATM.Database.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Principal;
//using System.Text;
//using System.Threading.Tasks;

//namespace ATM.Service
//{
//    public class AccountService
//    {
//        string path = @"D:\C#learning\LearningFiles\ATM\Files\Account.txt";

//        public AccountRepository accountRepository1 = new AccountRepository();





//        public string FullName { get; set; }
//        public string BankAccount { get; set; }
//        public int CardNumber { get; set; }
//        public int Pin { get; set; }
//        public decimal Balance { get; set; }

//        List<AccountService> accounts = new List<AccountService>();

//        public void UpdateAccountDetails(double amount, string account)
//        {
//            accountRepository1.UpdateAccountAmount(amount, account);

//            //string[] lines = File.ReadAllLines(path);
//            //for (int i = 0; i < lines.Length; i++)
//            //{
//            //    string[] parts = lines[i].Split(',');
//            //    if (parts[1] == account)
//            //    {
//            //        decimal currentamount = decimal.Parse(parts[4]);
//            //        currentamount += amount;
//            //        lines[i] = parts[0] + "," + parts[1] + "," + parts[2] + "," + parts[3] + "," + currentamount;
//            //        break;
//            //    }
//            //}
//            //File.WriteAllLines(path, lines);
//        }

//        public void AddAccount(Account account)
//        {
//            accountRepository1.AddAccount(account);
//        }

//        public void RemoveAccount(string account)
//        {
//            accountRepository1.RemoveAccount(account);
//        }
//        public void CheckBalance(string account)
//        {

//            Account account1 = accountRepository1.GetAccountDetails(account);
//            //decimal currentamount = 0;
//            //string[] lines = File.ReadAllLines(path);
//            //for (int i = 0; i < lines.Length; i++)
//            //{
//            //    string[] parts = lines[i].Split(',');
//            //    AccountService newaccount = new AccountService();
//            //    newaccount.BankAccount = parts[1];
//            //    if (parts[1] == account)
//            //    {
//            //        currentamount = decimal.Parse(parts[4]);

//            //        break;
//            //    }
//            //}
//            //Console.WriteLine($"Your Balance is {account.Balance}");
//        }


//        public Account FinaaccountViaCardNo(int cardNumber, int pin)
//        {

//            Account account = accountRepository1.FinaaccountViaCardNo(cardNumber, pin);


//            if (account == null)
//            {
//                return null;
//            }
//            return account;
//        }
//    }


//}
