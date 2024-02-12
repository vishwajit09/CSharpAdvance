using Interfaces.Day2;
using Interfaces.Day2Task3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Day2Task2
{
    internal class Quadrilateral : IPolygon, IWritable
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        public double SideD { get; set; }

        public Quadrilateral(double sideA, double sideB, double sideC, double sideD)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            SideD = sideD;

        }
        public Quadrilateral()
        {

        }
        public double GetArea()
        {
            // Calculating the semi-perimeter 
            // of the given quadrilateral
            double semiperimeter = (SideA + SideB + SideC + SideC) / 2;

            // Applying Brahmagupta's formula to
            // get maximum area of quadrilateral
            return Math.Sqrt((semiperimeter - SideA) *
                             (semiperimeter - SideB) *
                             (semiperimeter - SideC) *
                             (semiperimeter - SideC));
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} - Area {GetArea()}";
        }

        public void WriteToFile(string fileName)
        {
            using (StreamWriter writetext = File.AppendText(fileName))
            {
                writetext.WriteLine(ToString());
            }
        }

    }
}
