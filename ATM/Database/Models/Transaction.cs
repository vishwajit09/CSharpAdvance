using ATM.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Database.Models
{
    public class Transaction
    {

        [Key]
        public Guid TransactionId { get; set; }
        [ForeignKey("Account")]
        public string AccountNo { get; set; }

        public TransactionType TransactionType { get; set; }
        public double TransactionAmount { get; set; }

        public DateTime TransactionDate { get; set; }
        public virtual Account Account { get; set; }
    }
    public enum TransactionType
    {
        Deposit,
        WithDraw
    }
}
