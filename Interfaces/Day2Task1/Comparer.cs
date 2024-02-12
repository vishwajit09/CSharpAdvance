using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Day2
{
    internal class DogComparer : IComparer<Dog>
    {
        public int Compare(Dog? x, Dog? y)
        {
            if (x == null && y == null) return 0;

            if (x == null) { return 1; }

            if (y == null) { return -1; }

            return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }
    }

    internal class CatComparer : IComparer<Cat>
    {
        public int Compare(Cat? x, Cat? y)
        {
            if (x == null && y == null) return 0;

            if (x == null) { return 1; }

            if (y == null) { return -1; }

            return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }
    }

    internal class BassComparer : IComparer<Bass>
    {
        public int Compare(Bass? x, Bass? y)
        {
            if (x == null && y == null) return 0;

            if (x == null) { return 1; }

            if (y == null) { return -1; }

            return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }
    }

    internal class CarpComparer : IComparer<Carp>
    {
        public int Compare(Carp? x, Carp? y)
        {
            if (x == null && y == null) return 0;

            if (x == null) { return 1; }

            if (y == null) { return -1; }

            return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}
