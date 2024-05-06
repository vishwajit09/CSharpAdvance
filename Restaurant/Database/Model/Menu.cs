using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurant.Database.Model
{
    internal class Menu
    {
        public string? Name { get; set; }
        public double Price { get; set; }


        public override string ToString()
        {
            return Name + " - " + " Price" + " - " + Price;
        }
    }

}
