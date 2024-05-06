
using Restaurant.Interface;
using Restaurant.Repositories.Interface;
using Restaurant.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    internal class TableService : ITableService

    {
        private readonly ITableRepository _tableRepository;


        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public void BookTable(int tableNumber)
        {

            var table = _tableRepository.GetTable(tableNumber);
            table.IsOccupied = true;
            _tableRepository.BookOrFreeTable(table);
        }

        public IEnumerable<Table> DisplayTable()
        {
            return _tableRepository.DisplayTable();
        }
        public void FreeTable(int tableNumber)
        {
            var table = _tableRepository.GetTable(tableNumber);
            if (table == null)
            {
                Console.WriteLine("Wrong table number ");
                return;
            }
            table.IsOccupied = false;
            _tableRepository.BookOrFreeTable(table); ;
        }

        public Table GetTable(int tableNumber)
        {
            return _tableRepository.GetTable(tableNumber);
        }
    }
}
