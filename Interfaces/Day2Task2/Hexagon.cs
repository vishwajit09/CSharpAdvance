using Interfaces.Day2;
using Interfaces.Day2Task3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Day2Task2
{
    internal class Hexagon : IPolygon, IWritable
    {
        public int Side { get; set; }

        public Hexagon(int side)
        {
            Side = side;
        }

        public Hexagon() { }
        public double GetArea()
        {
            return ((3 * Math.Sqrt(3) *
               (Side * Side)) / 2);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} - Area {((3 * Math.Sqrt(3) *
               (Side * Side)) / 2)}";
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
