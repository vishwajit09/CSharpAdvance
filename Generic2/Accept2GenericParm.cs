using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningGeneric
{
    internal class Accept2GenericParm<T1, T2>
    {

        private T1? t1;
        private T2? t2;

        public T1 T11 { get => t1; set => t1 = value; }
        public T2 T12 { get => t2; set => t2 = value; }

        public void PrintFirstGeneric()
        {
            Console.WriteLine(t1);
        }

        public void PrintSecondGeneric() { Console.WriteLine(t2); }
    }


}

