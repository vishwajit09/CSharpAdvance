//using ATM.Database.Models;
//using ATM.Service;
//using Microsoft.Identity.Client;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ATM.Database
//{

//    public class AccountRepository
//    {
//        public readonly ATMContext db = new ATMContext();

//        public AccountRepository()
//        {
//        }

//        public List<Account> Accounts { get; set; }

//        public Account GetAccountDetails(string accountno)
//        {

//            Account acconts = db.accounts.FirstOrDefault(x => x.AccountNo == accountno);
//            return acconts;


//        }

//        public void UpdateAccountAmount(double amount, string accountno)
//        {
//            Account acconts = db.accounts.FirstOrDefault(x => x.AccountNo == accountno);
//            if (acconts != null)
//            {
//                acconts.Balance = acconts.Balance + amount;
//                db.accounts.Update(acconts);
//                db.SaveChanges();
//            }
//            Console.WriteLine("Account not found");
//        }

//        public Account? FinaaccountViaCardNo(int cardnumber, int pin)
//        {

//            return db.accounts.FirstOrDefault(x => x.CardNumber == cardnumber && x.Pin == pin);
//        }

//        public void AddAccount(Account account)
//        {
//            db.accounts.Add(account);
//            db.SaveChanges();
//        }

//        public void RemoveAccount(string accountno)
//        {

//            db.accounts.Remove(GetAccountDetails(accountno));
//            db.SaveChanges();
//        }
//    }
//}
