using Restaurant.Model;
using Restaurant.Repositories;
using Restaurant.Repositories.Interface;
using Restaurant.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service
{
    internal class OrderService : IOrderService
    {
        private readonly IOrderRespository _orderRepository;
        private readonly string path = "D:\\C#learning\\LearningFiles\\Restaurant\\Voucher\\";

        public OrderService(IOrderRespository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public Order getOrder(int tableNumber)
        {
            return _orderRepository.GetOrderDetails(tableNumber);
        }

        public void PrintReceiptService(int tableNumber, bool forCustomer)
        {
            var order = _orderRepository.GetOrderDetails(tableNumber);
            if (order == null)
            {
                Console.WriteLine("Nothing to Print");
                Thread.Sleep(500);
                return;
            }
            string receiptHeader = forCustomer ? "Customer Receipt" : "Restaurant Receipt";
            string fileName = forCustomer ? $"CustomerReceipt_{order.DateTime:yyyyMMddHHmmss}.txt" : $"RestaurantReceipt_{order.DateTime:yyyyMMddHHmmss}.txt";

            string text = GetReceiptText(order, forCustomer);

            using (StreamWriter writer = new StreamWriter(path+ fileName))
            {
                writer.WriteLine(text);
                Console.WriteLine(text);
            }
            Console.WriteLine();
            Console.WriteLine($"{receiptHeader} saved to file: {fileName}");
            Console.ReadLine();

        }

        public void CreateOrder(Order order)
        {
            CalculateTotal(order);
            _orderRepository.CreateOrder(order);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
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

        public string GetReceiptText(Order order, bool forCustomer)
        {

            string receiptHeader = forCustomer ? "Customer Receipt" : "Restaurant Receipt";
            string receiptText = string.Empty;


            receiptText += $"      {receiptHeader}         \n";
            receiptText += "\n";

            receiptText += $"Date: {order.DateTime} \n";
            receiptText += $"Table Number: {(order.Table != null ? order.Table.Number : "N/A")} \n";


            receiptText += "+-----------+-----------+------------+\n";

            // Print headers
            receiptText += "| Item      | Quantity  | Price      |\n";
            // Print middle border
            receiptText += "+-----------+-----------+------------+\n";

            receiptText += "\nOrder Details:\n";
            foreach (var orderItem in order.Items)
            {
                receiptText += $"| {orderItem.MenuItem.Name,-10}| {orderItem.Quantity,-10}| {orderItem.MenuItem.Price * orderItem.Quantity,-10} |\n";




            }
            receiptText += "+-------------------------------------\n";
            receiptText += $"Total Amount:            ${order.TotalAmount}\n";

            return receiptText;

        }




    }
}
