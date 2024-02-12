using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interface
{
    internal interface IOrderRespository
    {
        //public void AddOrder(Order order);
        //public void RemoveOrder(Order order);
        public Order GetOrderDetails(int tableNumber);
        public double CalculateTotal(Order order);
        public void CreateOrder(Order order);
        public void UpdateOrder(Order order);



    }
}
