using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Repositories.Interface;

namespace Restaurant.Database.Model
{
    internal class OrderItem
    {
        public Menu MenuItem { get; set; }
        public int Quantity { get; set; }
    }
}
