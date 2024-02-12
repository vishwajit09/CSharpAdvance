using Interfaces.Day2Task3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Day2Task2
{
    internal class Triangle : IPolygon, IWritable
    {
        public Triangle(double @base, double height)
        {
            Base = @base;
            Height = height;
        }

        public double Base { get; set; }
        public double Height { get; set; }

        public Triangle()
        {

        }

        public double GetArea()
        {
            return (Height * Base) / 2;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} - Area {(Height * Base) / 2}";
        }

        public void WriteToFile(string fileName)
        {
            using (StreamWriter writetext = File.AppendText(fileName))
            {
                writetext.WriteLine($"{DateTime.Now} -Log --{ToString()}");
            }
        }
    }
}
