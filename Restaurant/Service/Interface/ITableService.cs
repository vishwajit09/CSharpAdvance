using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service.Interface
{
    internal interface ITableService
    {
        public IEnumerable<Table> DisplayTable();
        public void BookTable(int tableNumber);
        public void FreeTable(int tableNumber);
        public Table GetTable(int tableNumber);
    }
}
