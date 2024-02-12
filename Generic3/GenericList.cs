using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningGeneric;

namespace Generic3
{
    internal class GenericList<T>
    {
        private List<T> _list = new List<T>();



        public void AddToList(T item)
        {

            _list.Add(item);
        }
        public void Print()
        {
            foreach (var item in _list)
            {

                Console.WriteLine(item);
            }
        }
        public T[] ConvertToArray()
        {

            return _list.ToArray();

        }
        public void AddList(List<T> list)
        {
            _list.AddRange(list);
        }

        public void RemoveList(T item)
        {

            _list.Remove(item);
        }

        public void RemoveLisATt(T index)
        {

            _list.Remove(index);
        }

        public void RemoveAllSimilarItem(T item)
        {
            _list.RemoveAll(x => x.Equals(item));
        }

    }
}
