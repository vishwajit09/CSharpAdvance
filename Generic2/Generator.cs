using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic2
{
    internal class Generator<T>
    {
        public void show()
        {
            FourSideGeometricFigure fourSideGeometricFigure = new FourSideGeometricFigure("rectangle", 10, 20);
            Console.WriteLine(fourSideGeometricFigure.ToString());
        }
    }
}
