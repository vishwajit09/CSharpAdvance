using Interfaces.Day2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Day2Task2
{
    internal class AreaComparer : IComparer<Shapes>
    {
        public int Compare(Shapes? x, Shapes? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.Area.CompareTo(y.Area);
        }


    }


    internal class AreaWithComprable : IComparable<IPolygon>
    {


        public int CompareTo(IPolygon? other)
        {
            return this.CompareTo(other);
        }
    }

}
