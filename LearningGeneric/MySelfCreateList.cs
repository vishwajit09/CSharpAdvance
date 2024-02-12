using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LearningGeneric
{
    internal class MySelfCreateList<T>
    {
        private T[] _list;
        private int _index = 0;
        private int _size = 3;

        public MySelfCreateList()
        {
            _list = new T[_size];
        }
        public void Add(T item)
        {
            if (CheckIfFull())
            {
                _list = IncreasedList();
            }
            if (item != null)
            {
                _list[_index] = item;
                _index++;
            }
            else
            {
                throw new ArgumentException(nameof(item));
            }

        }

        private bool CheckIfFull()
        {
            if (_index == _size)
                return true;
            else return false;
        }

        private T[] IncreasedList()
        {
            _size += _size / 2;
            var newList = new T[_size];
            _list.CopyTo(newList, 0);
            return newList;
        }

        public void DeleteElement(T item)
        {
            if (_list.Contains(item))
            {
                int index = Array.IndexOf(_list, item);
                _list = _list.Where((val, idx) => idx != index).ToArray();
            }

        }

        public void Print()
        {
            foreach (var item in _list)
            {

                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------");
        }

    }
}
