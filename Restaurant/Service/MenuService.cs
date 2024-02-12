using Restaurant.Model;
using Restaurant.Repositories;
using Restaurant.Repositories.Interface;
using Restaurant.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service
{
    internal class MenuService : IMenuService
    {
        private readonly IMenuItemRepository _menuItem;

        public MenuService(IMenuItemRepository menuItem)
        {
            _menuItem = menuItem;
        }

        public IEnumerable<Menu> GetMenu(string type)
        {
            return _menuItem.DisplayMenu(type);
        }

        public void DisplayMenu(string type)
        {
            var menu = GetMenu(type);

            menu.Select((item, idx) => { Console.WriteLine("{0}: {1}", idx + 1, item); return item; }).ToList();

        }

    }
}
