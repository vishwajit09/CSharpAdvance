using Restaurant.Model;
using Restaurant.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service.Interface
{
    internal interface IOrderService
    {

        //public void AddOrder(Order order);

        //public void RemoveOrder(Order order);

        public Order getOrder(int tableNumber);
        public void PrintReceiptService(int tableNumber, bool forCustomer);
        public void CreateOrder(Order order);
        public void UpdateOrder(Order order);
        public string GetReceiptText(Order order, bool forCustomer);
        // public void PrintReceipt(Order order, bool forCustomer);

        public double CalculateTotal(Order order);

    }
}
