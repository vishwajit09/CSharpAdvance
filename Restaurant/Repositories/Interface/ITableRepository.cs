using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interface
{
    internal interface ITableRepository
    {
        public void BookOrFreeTable(Table table);
        public IEnumerable<Table> DisplayTable();
        public Table GetTable(int tableNumber);
    }
}
