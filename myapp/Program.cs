
using System;
using System.Collections.Generic;
using System.IO;

namespace RestaurantSystem
{
    class Table
    {
        public int Number { get; set; }
        public int Seats { get; set; }
        public bool Occupied { get; set; }
    }

    class MenuItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class OrderItem
    {
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
    }

    class Order
    {
        public Table Table { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime DateTime { get; set; }
        public double TotalAmount { get; set; }
    }

    class Program
    {
        static List<Table> tables = new List<Table>();
        static List<MenuItem> menu = new List<MenuItem>();
        static List<Order> orders = new List<Order>();

        static void Main(string[] args)
        {
            LoadTables();
            LoadMenu();

            Console.WriteLine("Welcome to Our Restaurant!");

            while (true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Register Order");
                Console.WriteLine("2. Mark Table Vacant");
                Console.WriteLine("3. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterOrder();
                        break;
                    case "2":
                        MarkTableVacant();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void LoadTables()
        {
            // Load tables from file or initialize manually
            // For simplicity, let's initialize some tables manually
            tables.Add(new Table { Number = 1, Seats = 4, Occupied = false });
            tables.Add(new Table { Number = 2, Seats = 6, Occupied = false });
            // Add more tables as needed
        }

        static void LoadMenu()
        {
            // Load menu items from file or initialize manually
            // For simplicity, let's initialize some menu items manually
            menu.Add(new MenuItem { Name = "Burger", Price = 5.99 });
            menu.Add(new MenuItem { Name = "Pizza", Price = 8.99 });
            // Add more menu items as needed
        }

        static void RegisterOrder()
        {
            Console.WriteLine("\nAvailable Tables:");
            DisplayTables();

            Console.WriteLine("Enter the table number:");
            int tableNumber = int.Parse(Console.ReadLine());

            Table table = tables.Find(t => t.Number == tableNumber);
            if (table == null)
            {
                Console.WriteLine("Invalid table number.");
                return;
            }

            table.Occupied = true;

            Order order = new Order
            {
                Table = table,
                Items = new List<OrderItem>(),
                DateTime = DateTime.Now
            };

            while (true)
            {
                Console.WriteLine("\nMenu:");
                DisplayMenu();

                Console.WriteLine("\nEnter the number of the item you'd like to order (or type 'done' to finish):");
                string input = Console.ReadLine();

                if (input.ToLower() == "done")
                {
                    break;
                }

                int menuItemIndex;
                if (int.TryParse(input, out menuItemIndex) && menuItemIndex > 0 && menuItemIndex <= menu.Count)
                {
                    Console.WriteLine("Enter the quantity:");
                    int quantity = int.Parse(Console.ReadLine());

                    if (quantity > 0)
                    {
                        OrderItem orderItem = new OrderItem
                        {
                            MenuItem = menu[menuItemIndex - 1],
                            Quantity = quantity
                        };
                        order.Items.Add(orderItem);
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid item number.");
                }
            }

            order.TotalAmount = CalculateTotal(order);

            orders.Add(order);

            Console.WriteLine("\nOrder registered successfully!");

            PrintReceipt(order, true);

            SendReceiptByEmail(order, true);
        }

        static void DisplayTables()
        {
            foreach (var table in tables)
            {
                Console.WriteLine($"Table {table.Number} ({table.Seats} seats) - {(table.Occupied ? "Occupied" : "Vacant")}");
            }
        }

        static void DisplayMenu()
        {
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menu[i].Name} - ${menu[i].Price}");
            }
        }

        static double CalculateTotal(Order order)
        {
            double total = 0;
            foreach (var orderItem in order.Items)
            {
                total += orderItem.MenuItem.Price * orderItem.Quantity;
            }
            return total;
        }

        static void PrintReceipt(Order order, bool forCustomer)
        {
            string receiptHeader = forCustomer ? "Customer Receipt" : "Restaurant Receipt";
            string fileName = forCustomer ? $"CustomerReceipt_{order.DateTime:yyyyMMddHHmmss}.txt" : $"RestaurantReceipt_{order.DateTime:yyyyMMddHHmmss}.txt";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(receiptHeader);
                writer.WriteLine($"Date: {order.DateTime}");
                writer.WriteLine($"Table Number: {order.Table.Number}");
                writer.WriteLine($"Number of Seats: {order.Table.Seats}");

                writer.WriteLine("\nOrder Details:");
                foreach (var orderItem in order.Items)
                {
                    writer.WriteLine($"{orderItem.Quantity} x {orderItem.MenuItem.Name} - ${orderItem.MenuItem.Price * orderItem.Quantity}");
                }

                writer.WriteLine($"\nTotal Amount: ${order.TotalAmount}");
            }

            Console.WriteLine($"{receiptHeader} saved to file: {fileName}");
        }

        static void SendReceiptByEmail(Order order, bool forCustomer)
        {
            string recipientEmail = forCustomer ? "customer@example.com" : "restaurant@example.com";
            string subject = forCustomer ? "Your Receipt" : "Restaurant Receipt";
            string body = $"Thank you for your order!\n\n{GetReceiptText(order, forCustomer)}";

            // Code to send email
            Console.WriteLine($"Email sent to {recipientEmail} with subject: {subject}");
        }

        static string GetReceiptText(Order order, bool forCustomer)
        {
            string receiptHeader = forCustomer ? "Customer Receipt" : "Restaurant Receipt";
            string receiptText = $"{receiptHeader}\n";
            receiptText += $"Date: {order.DateTime}\n";
            receiptText += $"Table Number: {order.Table.Number}\n";
            receiptText += $"Number of Seats: {order.Table.Seats}\n\n";

            receiptText += "Order Details:\n";
            foreach (var orderItem in order.Items)
            {
                receiptText += $"{orderItem.Quantity} x {orderItem.MenuItem.Name} - ${orderItem.MenuItem.Price * orderItem.Quantity}\n";
            }

            receiptText += $"\nTotal Amount: ${order.TotalAmount}\n";

            return receiptText;
        }

        static void MarkTableVacant()
        {
            Console.WriteLine("\nOccupied Tables:");
            DisplayOccupiedTables();

            Console.WriteLine("Enter the table number to mark as vacant:");
            int tableNumber = int.Parse(Console.ReadLine());

            Table table = tables.Find(t => t.Number == tableNumber);
            if (table == null)
            {
                Console.WriteLine("Invalid table number.");
                return;
            }

            table.Occupied = false;

            Console.WriteLine($"Table {table.Number} marked as vacant.");
        }

        static void DisplayOccupiedTables()
        {
            foreach (var table in tables)
            {
                if (table.Occupied)
                {
                    Console.WriteLine($"Table {table.Number} ({table.Seats} seats)");
                }
            }
        }
    }
}


