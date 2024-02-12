using Restaurant.Model;
using Restaurant.Presentation;
using Restaurant.Repositories.Interface;
using Restaurant.Service;
using Restaurant.Service.Interface;
using RestaurantSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

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
        static List<Order> orders = new List<Order>();

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
                        // RegisterOrder(tableNumber);
                        RegisterOrderService(tableNumber);
                        break;
                    case 3:
                        Console.WriteLine("Yet to be implemented");
                        UpdateOrderService(tableNumber);
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

            var tables = _tableService.DisplayTable();

            foreach (var item in tables)
            {
                Console.WriteLine(item);
            }
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

        public void FreeTable()
        {

            var tables = _tableService.DisplayTable();

            foreach (var item in tables)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Enter the table that you want to free");

            int tableNumber = GetSelection(); ;
            _tableService.FreeTable(tableNumber);

            tables = _tableService.DisplayTable();

            if (!_tableService.GetTable(tableNumber).IsOccupied)
            {
                Console.WriteLine($"{tableNumber} is free to use again");
                Thread.Sleep(500);
            }
        }

        //public void RegisterOrder(int tableNumber)
        //{
        //    string type = string.Empty;

        //    Order order = new Order
        //    {
        //        Table = _tableService.GetTable(tableNumber),
        //        Items = new List<OrderItem>(),
        //        DateTime = DateTime.Now
        //    };

        //    while (true)
        //    {
        //        Console.Clear();
        //        Screen.ShowFoodAndDrink();
        //        while (true)
        //        {
        //            Console.Clear();
        //            Screen.ShowFoodAndDrink();

        //            switch (GetSelection())
        //            {
        //                case 1:
        //                    _menuService.DisplayMenu("Food");
        //                    type = "Food";
        //                    // AddToOrder(order, "Drink");
        //                    break;
        //                case 2:
        //                    _menuService.DisplayMenu("Drink");
        //                    //  AddToOrder(order, "Drink");
        //                    type = "Drink";
        //                    break;
        //                case 3:
        //                    Menu();
        //                    break;
        //                default:
        //                    Console.WriteLine("Invalid Option Entered.");
        //                    break;

        //            }

        //            Console.WriteLine("\nEnter the Item number you'd like to add to order (or type 'done' to finish):");
        //            string? input = Console.ReadLine();

        //            if (input.Equals("done", StringComparison.CurrentCultureIgnoreCase))
        //            {
        //                break;
        //            }

        //            int menuItemIndex;
        //            List<Menu> menu = _menuService.GetMenu(type).ToList();
        //            if (int.TryParse(input, out menuItemIndex) && menuItemIndex > 0 && menuItemIndex <= menu.Count())
        //            {
        //                Console.WriteLine("Enter the quantity:");
        //                int quantity = int.Parse(Console.ReadLine());

        //                if (quantity > 0)
        //                {
        //                    OrderItem orderItem = new OrderItem
        //                    {
        //                        MenuItem = menu[menuItemIndex - 1],
        //                        Quantity = quantity
        //                    };
        //                    order.Items.Add(orderItem);
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Invalid quantity.");
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("Invalid input. Please enter a valid item number.");
        //            }
        //            order.TotalAmount = CalculateTotal(order);

        //            orders.Add(order);

        //            Console.WriteLine("\nOrder registered successfully!");

        //            // orders.Add(order);
        //        }
        //    }

        //}

        //public void AddToOrder(Order order, string type)
        //{
        //    List<Menu> menu = _menuService.GetMenu(type).ToList();
        //    while (true)
        //    {
        //        Console.WriteLine("\nEnter the Item number you'd like to add to order (or type 'done' to finish):");
        //        string? input = Console.ReadLine();

        //        if (input.Equals("done", StringComparison.CurrentCultureIgnoreCase))
        //        {
        //            break;
        //        }

        //        int menuItemIndex;

        //        if (int.TryParse(input, out menuItemIndex) && menuItemIndex > 0 && menuItemIndex <= menu.Count())
        //        {
        //            Console.WriteLine("Enter the quantity:");
        //            int quantity = int.Parse(Console.ReadLine());

        //            if (quantity > 0)
        //            {
        //                OrderItem orderItem = new OrderItem
        //                {
        //                    MenuItem = menu[menuItemIndex - 1],
        //                    Quantity = quantity
        //                };
        //                order.Items.Add(orderItem);
        //            }
        //            else
        //            {
        //                Console.WriteLine("Invalid quantity.");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid input. Please enter a valid item number.");
        //        }
        //        order.TotalAmount = CalculateTotal(order);



        //        Console.WriteLine("\nOrder registered successfully!");
        //    }
        //}



        //static double CalculateTotal(Order order)
        //{
        //    double total = 0;
        //    foreach (var orderItem in order.Items)
        //    {
        //        total += orderItem.MenuItem.Price * orderItem.Quantity;
        //    }
        //    return total;
        //}

        public void PrintVoucher()
        {
            Console.WriteLine("Does customer need recipt Enter Y or N");
            string IsreciptNeeded = Console.ReadLine();

            // var order = GetTable();
            //  PrintReceipt(order, false);
            Console.WriteLine("Enter the table number");
            int tablenumber = GetSelection();


            if (IsreciptNeeded.ToUpper() == "Y")
            {
                PrintReceiptService(tablenumber, false);
                //PrintReceipt(order, true);
            }


        }
        public Order GetTable()
        {
            Console.WriteLine("Enter the table number");
            int tablenumber = GetSelection();

            return orders.Find(o => o.Table.Number == tablenumber);


        }

        public void SendEmail()
        {
            Console.WriteLine("Does customer need Email Enter Y or N");
            string IsemailNeeded = Console.ReadLine();

            var order = GetTable();

            if (IsemailNeeded.ToUpper() == "Y")
            {
                Console.WriteLine("Enter Customer Email");
                string email = Console.ReadLine();
                SendReceiptByEmail(order, true, email);
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
            string body = $"Thank you for your order!\n\n{_orderService.GetReceiptText(order, forCustomer)}";

            _emailSender.SendEmail(recipientEmail, "Invoice", body);

            // Console.WriteLine($"Email sent to {recipientEmail} with subject: {subject}");
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

                            break;
                        case 2:
                            _menuService.DisplayMenu("Drink");
                            type = "Drink";
                            break;
                        case 3:
                            _orderService.CreateOrder(order);
                            Menu();
                            break;
                        default:
                            Console.WriteLine("Invalid Option Entered.");
                            break;

                    }

                    AddOrder(order, type);

                }

            }


        }

        public void UpdateOrderService(int tableNumber)
        {


            string type = string.Empty;

            Order order = _orderService.getOrder(tableNumber);

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
                            // AddToOrder(order, "Drink");
                            break;
                        case 2:
                            _menuService.DisplayMenu("Drink");
                            type = "Drink";
                            break;
                        case 3:
                            _orderService.UpdateOrder(order);
                            Menu();
                            break;
                        default:
                            Console.WriteLine("Invalid Option Entered.");
                            break;

                    }

                    AddOrder(order, type);

                }

            }


        }

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
        }


        public void PrintReceiptService(int number, bool forCustomer)
        {
            _orderService.PrintReceiptService(number, forCustomer);
        }

    }
}
