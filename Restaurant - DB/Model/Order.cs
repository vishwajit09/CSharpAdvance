using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    internal class Order
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public Table? Table { get; set; }
        public List<OrderItem>? Items { get; set; }
        public DateTime DateTime { get; set; }
        public double TotalAmount { get; set; }


    }
}


