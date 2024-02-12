using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interface
{
    internal interface IMenuItemRepository
    {
        public IEnumerable<Menu> DisplayMenu(string type);

    }
}
