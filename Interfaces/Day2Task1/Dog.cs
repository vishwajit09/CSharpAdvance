using Interfaces.Day2Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Day2
{
    internal class Dog : Animal, IAnimal, IMammal
    {

        public Dog(string name) : base(name) { }

        public void Drink()
        {
            Console.WriteLine($"{Name} Drinking");
        }

        public void Eat()
        {
            Console.WriteLine($"{Name} Eating");
        }

        public void GiveBith()
        {
            Console.WriteLine($"{Name} Giving Birth");
        }

        public void Run()
        {
            Console.WriteLine($"{Name}is Running");
        }

        public void Sleep()
        {
            Console.WriteLine($"{Name} is Sleeping");
        }

        public void Sound()
        {
            Console.WriteLine($"{Name} is making Boww Boww.. sound"); ;
        }
    }
}
