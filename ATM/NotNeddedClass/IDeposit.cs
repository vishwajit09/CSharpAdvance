﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.NotNeddedClass
{
    internal interface IDeposit
    {
        void MakeDeposit(string? accountNo, decimal transactionAmount);
    }
}
