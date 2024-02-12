using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Day2Task2
{
    public class Shapes : IComparable<Shapes>
    {
        public Shapes(string shape, double area)
        {
            Shape = shape;
            Area = area;
        }

        public string Shape { get; set; }
        public double Area { get; set; }

        public int CompareTo(Shapes? other)
        {
            if (other == null) return 1;
            if (other == this) return 0;
            return this.Area.CompareTo(other.Area);
        }

        public override string ToString()
        {
            return $"{Shape} - Area {Area}";
        }

    }
}
