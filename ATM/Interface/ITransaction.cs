using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Service;

namespace ATM.Interface
{
    internal interface ITransaction
    {
        void InsertTransaction();
        void ViewtTransaction();
    }
}
