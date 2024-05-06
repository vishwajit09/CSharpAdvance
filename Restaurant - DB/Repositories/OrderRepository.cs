using Restaurant.Interface;
using Restaurant.Model;
using Restaurant.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    internal class OrderRepository : IOrderRespository
    {
        private readonly string _path = "D:\\C#learning\\LearningFiles\\Restaurant\\Voucher\\";
        private readonly List<Order> _order = new();


        public void CreateOrder(Order order)
        {
            _order.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = _order.FirstOrDefault(x => x.Id == order.Id);
            if (existingOrder != null)
            {
                existingOrder = order;
            }
        }
        //public void AddOrder(Order order)
        //{

        //    var indexOf = _order.IndexOf(_order.Find(x => x.Table.Number == order.Table.Number));
        //    if (indexOf == -1)
        //    {
        //        order.TotalAmount = CalculateTotal(order);
        //        _order.Add(order);
        //    }
        //    else
        //    {
        //        foreach (var item in order.Items)
        //        {
        //            _order[indexOf].Items.Add(item);
        //        }
        //        _order[indexOf].TotalAmount += CalculateTotal(order);
        //    }


        //}

        //public void RemoveOrder(Order order)
        //{

        //    var indexOf = _order.IndexOf(_order.Find(x => x.Table.Number == order.Table.Number));
        //    foreach (var item in order.Items)
        //    {
        //        _order[indexOf].Items.Remove(item);
        //    }
        //    _order[indexOf].TotalAmount -= CalculateTotal(order);

        //}

        public Order? GetOrderDetails(int tableNumber)
        {

            return _order.FirstOrDefault(x => x.Table.Number == tableNumber);



            //  return order;
            //if (_order.Find(x => x.Table.Number == tableNumber == null){
            //    return null;
            //};

        }

        public double CalculateTotal(Order order)
        {
            if (order != null)
            {
                double total = 0;
                foreach (var orderItem in order.Items)
                {
                    total += orderItem.MenuItem.Price * orderItem.Quantity;
                }
                return total;
            }
            return 0;
        }
    }
}
