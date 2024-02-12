using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic3
{
    internal static class Validator<T>
    {
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
}
