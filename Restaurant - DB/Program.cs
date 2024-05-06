using Restaurant.Model;
using Restaurant.Repositories;
using Restaurant.Repositories.Interface;
using Restaurant.Service;
using Restaurant.Service.Interface;
using System.Net.Http.Headers;

namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITableRepository tableRepository = new TableRepository();
            ITableService tableService = new TableService(tableRepository);
            IMenuItemRepository menuItemRepository = new MenuItemRepository();
            IMenuService menuService = new MenuService(menuItemRepository);

            IOrderRespository orderRespository = new OrderRepository();
            IOrderService orderService = new OrderService(orderRespository);
            IEmailService emailService = new EmailService();




            RestaurantUI ui = new RestaurantUI(tableService, menuService, emailService, orderService);
            ui.Menu();


        }
    }
}
