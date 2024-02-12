using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamda_Linq
{
    internal class AnimalPerson
    {
        public string Name { get; set; }
        public List<Animal> animals = new List<Animal>();

        public AnimalPerson(string name, List<Animal> animals)
        {
            Name = name;
            this.animals = animals;
        }
    }
}
