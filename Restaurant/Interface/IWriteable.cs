using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Interface
{
    internal interface IWriteable
    {
        public void WriteToFile(string fileName);
    }
}
