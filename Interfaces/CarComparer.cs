using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class CarComparer : IComparer<Car>
    {
        int IComparer<Car>.Compare(Car? x, Car? y)
        {
            if (x == null && y == null)
            { return 0; }
            if (x == null) return 1; if (y == null) return -1;

            return string.Compare(x.Model, y.Model, StringComparison.OrdinalIgnoreCase);
        }



    }
}
