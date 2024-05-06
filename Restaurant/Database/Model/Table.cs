using Restaurant.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Database.Model
{
    internal class Table
    {
        public int? Number { get; set; }
        public int? Seats { get; set; }
        public bool IsOccupied { get; set; }

        public override string ToString()
        {
            return "Table " + Number + " - " + "No of Seats " + Seats + " - " + " Status - " + (IsOccupied ? "Occupied" : "Free");
        }
    }
}
