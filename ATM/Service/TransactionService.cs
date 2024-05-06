//using ATM.Interface;
//using CsvHelper;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Security.Principal;
//using System.Text;
//using System.Threading.Tasks;
//using System.Transactions;

//namespace ATM.Service
//{
//    public enum TransactionType
//    {
//        Deposit,
//        WithDraw
//    }
//    internal class TransactionService : ITransaction
//    {

//        private readonly string Path = @"D:\C#learning\LearningFiles\ATM\Files\";



//        public Guid TransactionId { get; set; }

//        public string AccountNo { get; set; }

//        public TransactionType TransactionType { get; set; }
//        public decimal TransactionAmount { get; set; }

//        public DateTime TransactionDate { get; set; }


//        public TransactionService(Guid transactionId, string accountNo, TransactionType transactionType, decimal transactionAmount, DateTime transactionDate)
//        {
//            TransactionId = transactionId;
//            AccountNo = accountNo;
//            TransactionType = transactionType;
//            TransactionAmount = transactionAmount;
//            TransactionDate = transactionDate;
//        }

//        public TransactionService(string accountNo)
//        {
//            AccountNo = accountNo;
//        }

//        public void InsertTransaction()
//        {
//            WriteToFile();
//        }
//        public void ViewtTransaction()
//        {
//            //string transactionFilePath = Path + "/" + AccountNo + ".txt";

//            int count = 0;
//            string[] lines = File.ReadAllLines(CheckFileExist());



//            for (int i = 0; i < lines.Length; i++)
//            {
//                string[] parts = lines[i].Split(',');

//                if (parts[0] == AccountNo && count <= 5)
//                {
//                    Console.WriteLine($"{parts[0]}   {parts[1]}  {parts[2]}  {parts[3]}  {parts[4]}");

//                    count++;
//                }
//            }


//        }


//        public override string ToString()
//        {
//            return AccountNo + ","
//                + TransactionAmount + "," +
//                TransactionId + "," +
//                TransactionDate + "," +
//                TransactionType
//                ;
//        }

//        public void WriteToFile()
//        {

//            using (StreamWriter writetext = File.AppendText(CheckFileExist()))
//            {

//                writetext.WriteLine(ToString());
//            }

//            //AccountService Account = new AccountService();
//            // Account.UpdateAccountDetails(TransactionAmount, AccountNo);

//        }

//        public bool MaxTransactionLimitReached(int maxTransactionLimit)
//        {

//            int count = 0;



//            string[] lines = File.ReadAllLines(CheckFileExist());

//            string dateOnly = DateTime.Today.ToString().Substring(0, 10);
//            string dateinFile = string.Empty;


//            for (int i = 0; i < lines.Length; i++)
//            {
//                string[] parts = lines[i].Split(',');
//                dateinFile = parts[3].Substring(0, 10);

//                if (parts[0] == AccountNo && dateinFile == dateOnly)
//                {
//                    if (count >= maxTransactionLimit)
//                    {
//                        Console.WriteLine("Max Transaction reached");
//                        return true;

//                    }
//                    count++;

//                }
//            }

//            return false;
//        }

//        public string CheckFileExist()
//        {
//            string transactionFilePath = Path + AccountNo + ".txt";
//            //FileInfo fileInfo = new FileInfo(transactionFilePath);

//            //if (!fileInfo.Exists)
//            if (!File.Exists(transactionFilePath))
//            {
//                File.Create(transactionFilePath).Dispose();
//            }

//            //   File.Open(transactionFilePath, FileMode.Append, FileAccess.ReadWrite);

//            return transactionFilePath;
//        }

//    }




//}
