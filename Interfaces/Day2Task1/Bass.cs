using Interfaces.Day2Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Day2
{
    internal class Bass : Animal, IFish, IAnimal
    {
        public string Name { get; set; }
        public Bass(string name) : base(name) { }

        public void Drink()
        {
            Console.WriteLine($"{Name} is Drinking");
        }

        public void Eat()
        {
            Console.WriteLine($"{Name} is Eating");
        }

        public void Sleep()
        {
            Console.WriteLine($"{Name} is Sleeping");
        }

        public void Sound()
        {
            Console.WriteLine($"{Name}is making sound");
        }

        public void Swim()
        {
            Console.WriteLine($"{Name} is making Swimming");
        }
    }
}
