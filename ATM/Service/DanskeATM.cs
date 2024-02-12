using ATM.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ATM.Service
{
    internal class DanskeATM
    {
        private Account currentAccount = new Account();

        public void Menu()
        {

            Screen.ShowMenu1();
            while (true)
            {

                switch (GetSelection())
                {
                    case 1:
                        CheckCardNoPin();

                        while (true)
                        {
                            Console.ReadKey();
                            Screen.ShowMenu2();
                            switch (GetSelection())
                            {
                                case 1:
                                    CheckBalance(currentAccount);
                                    break;
                                case 2:
                                    Deposit(currentAccount);
                                    break;
                                case 3:
                                    Withdraw(currentAccount);
                                    break;
                                case 4:
                                    ViewTransaction(currentAccount);
                                    break;

                                case 5:
                                    Console.WriteLine("You have succesfully logout. Please collect your ATM card..");

                                    Menu();
                                    break;
                                default:
                                    Console.WriteLine("Invalid Option Entered.");
                                    break;
                            }
                        }


                    case 2:
                        Console.Write("\nThank you for using Danske Bank. Exiting program now .");
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid Option Entered.");
                        break;

                }

            }
        }


        public int GetSelection()
        {
            bool valid = false;
            int input = 0;

            while (!valid)
            {
                Console.Write($"Enter your option: ");

                valid = int.TryParse(Console.ReadLine(), out input);
                if (!valid)
                    Console.WriteLine("Invalid input. Try again.");
            }
            return input;

        }

        public void CheckCardNoPin()
        {
            Login login = new Login();
            login.CheckCardNoPIN();
            currentAccount = login.Account;
            CheckBalance(currentAccount);
        }

        public void CheckBalance(Account account)
        {
            Account account1 = new Account();
            account1.CheckBalance(account.BankAccount);

        }

        public void Deposit(Account account)
        {

            Console.WriteLine("Enter Amount you want to Deposit");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            Transaction transaction = new Transaction(Guid.NewGuid(), account.BankAccount, TransactionType.Deposit, amount, DateTime.Now);
            if (!transaction.MaxTransactionLimitReached(10))
            {
                transaction.InsertTransaction();
            }

        }

        public void Withdraw(Account account)
        {

            Console.WriteLine("Enter Amount you want to WithDraw");

            decimal amount = Convert.ToDecimal(Console.ReadLine());

            if (amount > 1000)
            {
                Console.WriteLine("Maximun withdrawl allowed is 1000");


            }
            else if (account.Balance - amount <= 0)
            {
                Console.WriteLine($"You can only Withdraw{account.Balance}");
            }
            else
            {

                Transaction transaction = new Transaction(Guid.NewGuid(), account.BankAccount, TransactionType.WithDraw, -amount, DateTime.Now);
                transaction.InsertTransaction();
                if (!transaction.MaxTransactionLimitReached(10))
                {
                    transaction.InsertTransaction();
                }


            }


        }

        public void ViewTransaction(Account account)
        {

            Transaction transaction = new Transaction(account.BankAccount);
            transaction.ViewtTransaction();
        }
    }
}

//private static List<Account> accountList = new List<Account>();
//string transactionFilePath = @"D:\C#learning\LearningFiles\ATM\Transaction.txt";
//string path = @"D:\C#learning\LearningFiles\ATM\Files\Account.txt";

//public void CheckCardNoPin()
//{


//    //StreamReader streamReader = new StreamReader(path);

//    //string line = string.Empty;
//    //while ((line = streamReader.ReadLine()) != null)
//    //{
//    //    string[] word = line.Split(',');
//    //    Account newaccount = new Account();
//    //    //newaccount.FullName = word[0];
//    //    //newaccount.BankAccount = word[1];
//    //    //newaccount.CardNumber = int.Parse(word[2]);
//    //    //newaccount.Pin = int.Parse(word[3]);
//    //    //newaccount.Balance = int.Parse(word[4]);
//    //    accountList.Add(new Account
//    //    {
//    //        FullName = word[0],
//    //        BankAccount = word[1],
//    //        CardNumber = int.Parse(word[2]),
//    //        Pin = int.Parse(word[3]),
//    //        Balance = int.Parse(word[4])


//    //    });

//    //}
//    //streamReader.Close();

//    //foreach (var item in accountList)
//    //{
//    //    Console.WriteLine(item.CardNumber);
//    //}
//    //Thread.Sleep(1000);


//    //  currentAccount = FindAccount();

//    Login login = new Login();
//    login.CheckCardNoPIN();
//    currentAccount = login.Account;
//    CheckBalance(currentAccount);
//}

//public static Account FindAccount()
//{
//    Account inputAccount = new Account();
//    Console.Write("Enter ATM Card Number: ");
//    inputAccount.CardNumber = Convert.ToInt32(Console.ReadLine());

//    Console.WriteLine("Enter 4 digit pin");

//    inputAccount.Pin = Convert.ToInt32(Console.ReadLine());

//    var result = (from account in accountList
//                  where account.CardNumber == inputAccount.CardNumber
//                  && account.Pin == inputAccount.Pin
//                  select account).First();
//    return result;
//}

//public void UpdateAccountFile(decimal amount, string account)
//{
//    //string[] lines = File.ReadAllLines(path);
//    //for (int i = 0; i < lines.Length; i++)
//    //{
//    //    string[] parts = lines[i].Split(',');
//    //    Account newaccount = new Account();
//    //    newaccount.BankAccount = parts[1];
//    //    newaccount.Balance = int.Parse(parts[4]);
//    //    if (parts[1] == account)
//    //    {
//    //        decimal currentamount = decimal.Parse(parts[4]);
//    //        currentamount += amount;
//    //        //lines[i] = parts;
//    //        lines[i] = parts[0] + "," + parts[1] + "," + parts[2] + "," + parts[3] + "," + currentamount;
//    //        break;
//    //    }
//    //}
//    //File.WriteAllLines(path, lines);



//}

//public void ViewTransaction(Account account)
//{
//    //int count = 0;
//    //string[] lines = File.ReadAllLines(transactionFilePath);
//    //for (int i = 0; i < lines.Length; i++)
//    //{
//    //    string[] parts = lines[i].Split(',');

//    //    if (parts[0] == account.BankAccount && count <= 5)
//    //    {
//    //        Console.WriteLine($"{parts[0]}   {parts[1]}  {parts[2]}  {parts[3]}  {parts[4]}");

//    //        count++;
//    //    }
//    //}

//    //Console.ReadLine();

//    Transaction transaction = new Transaction();
//    transaction.ViewtTransaction(account);
//}

//public void CheckBalance(Account account)
//{
//    Account account1 = new Account();
//    account1.CheckBalance(account.BankAccount);

//    //Balance balance = new Balance();
//    //balance.CheckBalance(account.BankAccount, path);
//    ////decimal currentamount = 0;
//    ////string[] lines = File.ReadAllLines(path);
//    ////for (int i = 0; i < lines.Length; i++)
//    ////{
//    ////    string[] parts = lines[i].Split(',');
//    ////    Account newaccount = new Account();
//    ////    newaccount.BankAccount = parts[1];
//    ////    newaccount.Balance = int.Parse(parts[4]);
//    ////    if (parts[1] == account.BankAccount)
//    ////    {
//    ////        currentamount = decimal.Parse(parts[4]);

//    ////        break;
//    ////    }
//    ////}


//    //Console.WriteLine($"Your Balance is {account1.a}");
//    //Thread.Sleep(1000);
//}

//public void Deposit(Account account)
//{

//    Console.WriteLine("Enter Amount you want to Deposit");

//    decimal amount = Convert.ToDecimal(Console.ReadLine());

//    //Deposit deposit = new Deposit(account.BankAccount, amount);
//    //deposit.WriteToFile(transactionFilePath);
//    //UpdateAccountFile(amount, account.BankAccount);

//    Transaction transaction = new Transaction(Guid.NewGuid(), account.BankAccount, TransactionType.Deposit, amount, DateTime.Now);
//    transaction.InsertTransaction();

//}

//public void Withdraw(Account account)
//{

//    Console.WriteLine("Enter Amount you want to WithDraw");

//    decimal amount = Convert.ToDecimal(Console.ReadLine());

//    if (amount > 1000)
//    {
//        Console.WriteLine("Maximun withdrawl allowed is 1000");
//    }
//    else
//    {

//        Transaction transaction = new Transaction(Guid.NewGuid(), account.BankAccount, TransactionType.WithDraw, -amount, DateTime.Now);
//        transaction.InsertTransaction();
//        //WithDrawl deposit = new WithDrawl(account.BankAccount, amount);
//        //deposit.WriteToFile(transactionFilePath);
//        //UpdateAccountFile(-amount, account.BankAccount);
//    }


//}