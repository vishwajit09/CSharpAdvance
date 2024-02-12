using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Interface
{
    internal interface IBalance
    {
        void CheckBalance(string account, string path);
    }
}
