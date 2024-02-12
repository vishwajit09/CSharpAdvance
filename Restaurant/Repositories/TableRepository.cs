using Microsoft.VisualBasic;
using Restaurant.Model;
using Restaurant.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Restaurant.Repositories
{
    internal class TableRepository : ITableRepository
    {
        private readonly string _fileName = @"D:\C#learning\LearningFiles\Restaurant\Data\Table.txt";
        private readonly List<Table> _table = new();

        public TableRepository()
        {
            var contents = File.ReadAllLines(_fileName);
            for (int i = 0; i < contents.Length; i++)
            {
                string[] table = contents[i].Split(',');
                _table.Add(new Table { Number = int.Parse(table[0]), Seats = int.Parse(table[1]), IsOccupied = bool.Parse(table[2]) });

            }
        }
        public void BookOrFreeTable(Table tableNumber)
        {

            _table.Find(x => x.Number == tableNumber.Number).IsOccupied = tableNumber.IsOccupied;

            string[] tables = File.ReadAllLines(_fileName);

            for (int i = 0; i < _table.Count; i++)
            {
                tables[i] = _table[i].Number + "," + _table[i].Seats + "," + _table[i].IsOccupied;

            }
            File.WriteAllLines(_fileName, tables);
        }
        public Table GetTable(int tableNumber)
        {
            return _table.Find(x => x.Number == tableNumber);
        }

        public IEnumerable<Table> DisplayTable()
        {
            return _table;
        }


    }
}
