using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningGeneric
{
    //internal static class Validation
    internal class Validation<T>
    {
        public void Validate<T>(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
        }
    }


    public static class Validation1<T>
    {
        public static void Validate<T>(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
        }
    }
}
