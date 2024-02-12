using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service.Interface
{
    internal interface IMenuService
    {
        public void DisplayMenu(string type);
        public IEnumerable<Menu> GetMenu(string type);
    }
}
