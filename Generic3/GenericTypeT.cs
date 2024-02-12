using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Generic3
{
    internal class GenericTypeT<T>
    {
        private readonly List<T> values;

        public GenericTypeT(List<T> values)
        {

            this.values = values;
        }



        public void Print()
        {
            foreach (var item in values)
            {

                Console.WriteLine(item);
            }
        }


        public T[] ConvertToArray()
        {

            return values.ToArray();

        }

        public T FindMatch(T value)
        {
            int count = values.Where(x => x.Equals(value)).Count();
            if (count > 1)
            {

                throw new Exception("More then 1");
            }
            else if (count == 0) { return default; }
            return value;



        }

        public T FindMatchOne(T value)
        {
            int count = values.Where(x => x.Equals(value)).Count();
            if (count > 1)
            {

                throw new Exception("More then 1");
            }
            return value;
        }

        public bool FindMatchBool(T value)
        {
            int count = values.Where(x => x.Equals(value)).Count();
            if (count > 0)
            {

                return true;
            }
            return false;
        }


    }


}
