using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic2
{
    internal class TypeClass<T1, T2>
    {
        public T1 T11 { get; set; }
        public T2 T21 { get; set; }

        public void GetType<T>(T input)
        {
            Console.WriteLine(input.GetType().Name);


        }
    }
}
