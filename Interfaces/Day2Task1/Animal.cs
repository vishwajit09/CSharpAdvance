using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Day2Task1
{
    internal class Animal : IComparable<Animal>
    {
        public string Name { get; set; }
        public Animal(string name)
        {
            Name = name;
        }

        public int CompareTo(Animal? other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
