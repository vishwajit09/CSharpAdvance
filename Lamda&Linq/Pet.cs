using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamda_Linq
{
    internal class Pet
    {
        public string Name { get; set; }
        public double Age { get; set; }

        public Pet(string name, double age)
        {
            Name = name;
            Age = age;
        }
    }
}
