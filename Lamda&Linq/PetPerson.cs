using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamda_Linq
{
    internal class PetPerson
    {
        public string Name { get; set; }
        public List<Pet> Pets = new List<Pet>();

        public PetPerson(string name, List<Pet> pet)
        {
            Name = name;
            Pets = pet;


        }
        public PetPerson()
        {

        }
    }
}
