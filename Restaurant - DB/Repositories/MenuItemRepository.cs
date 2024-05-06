using Restaurant.Model;
using Restaurant.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    internal class MenuItemRepository : IMenuItemRepository
    {
        private readonly string _drink = @"D:\C#learning\LearningFiles\Restaurant\Data\Drink.txt";
        private readonly string _food = @"D:\C#learning\LearningFiles\Restaurant\Data\Food.txt";
        private readonly List<Menu> _Fooditems = new();
        private readonly List<Menu> _Drinkitems = new();

        public MenuItemRepository()
        {

            string filename = string.Empty;
            //switch (type)
            //{
            //    case "Food":
            //        filename = _food;
            //        break;
            //    case "Drink":
            //        filename = _drink;
            //        break;
            //    default:
            //        throw new ArgumentException("Wrong Type");
            //        break;
            //}
            var contents = File.ReadAllLines(_food);

            for (int i = 0; i < contents.Length; i++)
            {
                string[] table = contents[i].Split(',');
                _Fooditems.Add(new Menu { Name = table[0], Price = double.Parse(table[1]) });

            }
            contents = File.ReadAllLines(_drink);

            for (int i = 0; i < contents.Length; i++)
            {
                string[] table = contents[i].Split(',');
                _Drinkitems.Add(new Menu { Name = table[0], Price = double.Parse(table[1]) });

            }

        }

        public IEnumerable<Menu> DisplayMenu(string type)
        {
            if (type == "Food")
                return _Fooditems;
            else return _Drinkitems;
        }

    }
}
