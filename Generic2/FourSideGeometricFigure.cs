using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Generic2
{
    internal class FourSideGeometricFigure
    {
        private string Name;
        private int Base;
        private int Height;

        public FourSideGeometricFigure(string name, int @base, int height)
        {
            Name = name;
            Base = @base;
            Height = height;
        }

        public double Area()
        {
            switch (Name.ToLower())
            {
                case "triangle":
                    return (Base * Height) / 2;

                case "rectangle":
                    return (Base * Height);
                default:
                    return 0;

            }
        }

        public override string ToString()
        {
            return "Shape: " + Name + " Area " + Area();
        }
    }
}
