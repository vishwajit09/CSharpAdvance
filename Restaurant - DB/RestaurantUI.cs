using Restaurant.Model;
using Restaurant.Presentation;
using Restaurant.Repositories.Interface;
using Restaurant.Service;
using Restaurant.Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurant
{
    internal class RestaurantUI
    {
        private readonly ITableService _tableService;
        private readonly IMenuService _menuService;
        private readonly IEmailService _emailSender;
        private readonly IOrderService _orderService;

        // private readonly OrderService _orderService;

        int tableNumber = 0;
        //   static List<Order> orders = new List<Order>();

        public RestaurantUI(ITableService tableService, IMenuService menuService, IEmailService emailSender, IOrderService orderService)
        {
            _tableService = tableService;
            _menuService = menuService;
            _emailSender = emailSender;
            _orderService = orderService;
        }

        public void Menu()
        {
            while (true)
            {

                Screen.ShowMenu1();
                switch (GetSelection())
                {
                    case 1:
                        BookTable();
                        break;
                    case 2:
                        RegisterOrderService(tableNumber);
                        break;
                    case 3:
                        UpdateOrderService();
                        break;
                    case 4:

                        PrintVoucher();
                        break;
                    case 5:

                        SendEmail();
                        break;
                    case 6:
                        FreeTable();
                        break;
                    case 7:
                        Console.WriteLine("You have succesfully logout.");
                        Environment.Exit(1);
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Invalid Option Entered.");
                        break;


                }
                //Console.ReadKey();

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

        public void BookTable()
        {

            PrintTableDetails();

            Console.WriteLine("Enter the table you want to book");
            tableNumber = GetSelection();

            if (!_tableService.GetTable(tableNumber).IsOccupied)
            {
                _tableService.BookTable(tableNumber);
                Console.WriteLine($"{tableNumber} is booked");
            }
            else
            {
                Console.WriteLine("Table Already occupied");
                Thread.Sleep(500);
            }
            Console.Clear();
        }

        public void PrintTableDetails()
        {
            var tables = _tableService.DisplayTable();

            Console.WriteLine("+-----------+-----------+------------+");

            // Print headers
            Console.WriteLine("| Table     | Seats     | Status     |");

            // Print middle border
            Console.WriteLine("+-----------+-----------+------------+");

            // Print data rows
            foreach (var table in tables)
            {
                Console.WriteLine($"| {table.Number,-10}| {table.Seats,-10}| {(table.IsOccupied ? "Occupied" : "Free"),-10} |");
            }

            // Print bottom border
            Console.WriteLine("+-----------+-----------+-----------+");
        }

        public void FreeTable()
        {
            PrintTableDetails();

            Console.WriteLine("Enter the table that you want to free");

            int tableNumber = GetSelection(); ;
            _tableService.FreeTable(tableNumber);

            if (!_tableService.GetTable(tableNumber).IsOccupied)
            {
                Console.WriteLine($"{tableNumber} is free to use again");
                Thread.Sleep(500);
            }
        }


        public void PrintVoucher()
        {
            Console.WriteLine("Does customer need recipt Enter Y or N");
            string IsreciptNeeded = Console.ReadLine();

            Console.WriteLine("Enter the table number");
            int tablenumber = GetSelection();

            if (IsreciptNeeded.ToUpper() == "Y")
            {
                _orderService.PrintReceiptService(tablenumber, true);

            }
            _orderService.PrintReceiptService(tablenumber, false);


        }
        public Order GetTable()
        {
            Console.WriteLine("Enter the table number");
            int tablenumber = GetSelection();

            return _orderService.getOrder(tablenumber);


        }

        public void SendEmail()
        {
            Console.WriteLine("Does customer need invoice in email - Enter Y or N");
            string IsemailNeeded = Console.ReadLine();

            var order = GetTable();

            if (IsemailNeeded.ToUpper() == "Y")
            {
                Console.WriteLine("Enter Customer Email");
                string email = Console.ReadLine();
                SendReceiptByEmail(order, true, email);
                // _orderService.GetReceiptText(tablenumber, true);
            }

        }



        public void SendReceiptByEmail(Order order, bool forCustomer, string email)
        {
            if (order == null)
            {
                Console.WriteLine("Nothing to send");
                Thread.Sleep(500);
                return;
            }
            string recipientEmail = forCustomer ? email : "restaurant@example.com";
            string subject = forCustomer ? "Your Receipt" : "Restaurant Receipt";
            string body = _orderService.GetReceiptText(order, forCustomer);

            // string body = $"Thank you for your order!\n\n{_orderService.GetReceiptText(order, forCustomer)}";

            // _emailSender.SendEmail(recipientEmail, "Invoice", body);
            _emailSender.SendEmail("Invoice", body);

            Thread.Sleep(2000);
        }



        public void RegisterOrderService(int tableNumber)
        {
            string type = string.Empty;

            Order order = new Order
            {
                Table = _tableService.GetTable(tableNumber),
                Items = new List<OrderItem>(),
                DateTime = DateTime.Now
            };

            while (true)
            {
                Console.Clear();
                Screen.ShowFoodAndDrink();
                while (true)
                {
                    Console.Clear();
                    Screen.ShowFoodAndDrink();

                    switch (GetSelection())
                    {
                        case 1:
                            _menuService.DisplayMenu("Food");
                            type = "Food";
                            AddToOrder(order, "Food");
                            break;
                        case 2:
                            _menuService.DisplayMenu("Drink");
                            type = "Drink";
                            AddToOrder(order, "Drink");
                            break;
                        case 3:
                            _orderService.CreateOrder(order);
                            Menu();
                            break;
                        default:
                            Console.WriteLine("Invalid Option Entered.");
                            break;

                    }

                    // AddOrder(order, type);

                }

            }


        }

        public void UpdateOrderService()
        {
            Console.WriteLine("Enter the table number");
            int tablenumber = GetSelection();

            string type = string.Empty;

            Order order = _orderService.getOrder(tableNumber);

            if (order == null)
            {
                order = new Order
                {
                    Table = _tableService.GetTable(tableNumber),
                    Items = new List<OrderItem>(),
                    DateTime = DateTime.Now
                };
            }

            Console.Clear();
            Screen.ShowFoodAndDrink();
            while (true)
            {

                while (true)
                {
                    Console.Clear();
                    Screen.ShowFoodAndDrink();

                    switch (GetSelection())
                    {
                        case 1:
                            _menuService.DisplayMenu("Food");
                            type = "Food";
                            //AddToOrder
                            AddToOrder(order, "Food");
                            break;
                        case 2:
                            _menuService.DisplayMenu("Drink");
                            type = "Drink";
                            AddToOrder(order, "Drink");

                            break;
                        case 3:
                            _orderService.UpdateOrder(order);
                            Menu();
                            break;
                        default:
                            Console.WriteLine("Invalid Option Entered.");
                            break;

                    }

                    // AddOrder(order, type);

                }

            }


        }


        //Option to add menu with index
        public void AddOrder(Order order, string type)
        {

            Console.WriteLine("\nEnter the Item number you'd like to add to order (or type 'done' to finish):");
            string? input = Console.ReadLine();

            if (input.Equals("done", StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }


            int menuItemIndex;
            List<Menu> menu = _menuService.GetMenu(type).ToList();
            if (int.TryParse(input, out menuItemIndex) && menuItemIndex > 0 && menuItemIndex <= menu.Count())
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
            order.TotalAmount = _orderService.CalculateTotal(order);

            Console.WriteLine("\nOrder registered successfully!");
            Console.ReadLine();
        }

        public void AddToOrder(Order order, string type)
        {
            while (true)
            {
                Console.WriteLine("\nEnter the Item number you'd like to add to order (or type 'done' to finish):");
                string? input = Console.ReadLine();

                if (input.Equals("done", StringComparison.CurrentCultureIgnoreCase))
                {
                    return;
                }


                int menuItemIndex;
                List<Menu> menu = _menuService.GetMenu(type).ToList();
                if (int.TryParse(input, out menuItemIndex) && menuItemIndex > 0 && menuItemIndex <= menu.Count())
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
                order.TotalAmount = _orderService.CalculateTotal(order);

                Console.WriteLine("\nOrder registered successfully!");
            }

        }
    }
}
