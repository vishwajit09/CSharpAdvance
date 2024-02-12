using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ATM.NotNeddedClass
{
    internal class Deposit
    {
        //    public Transaction DepostTransaction = new Transaction();
        //    Random random = new Random();

        //    public Deposit(string? accountNo, decimal transactionAmount)
        //    {

        //        DepostTransaction.AccountNo = accountNo;
        //        DepostTransaction.TransactionAmount = transactionAmount;
        //        DepostTransaction.TransactionId = random.Next(90000, 1000000);
        //        DepostTransaction.TransactionDate = DateTime.Now;
        //        DepostTransaction.TransactionType = "Deposit";


        //    }

        //    public override string ToString()
        //    {
        //        return DepostTransaction.AccountNo + ","
        //            + DepostTransaction.TransactionAmount + "," +
        //            DepostTransaction.TransactionId + "," +
        //            DepostTransaction.TransactionDate + "," +
        //            DepostTransaction.TransactionType
        //            ;
        //    }

        //    public void WriteToFile(string fileName)
        //    {
        //        using (StreamWriter writetext = File.AppendText(fileName))
        //        {
        //            using (var csv = new CsvWriter(writetext, CultureInfo.InvariantCulture)) { }

        //            writetext.WriteLine(ToString());
        //        }


        //    }
        //}


    }
}
