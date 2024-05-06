using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service.Interface
{
    internal interface IEmailService
    {
        //void SendEmail(string to, string subject, string body);
        void SendEmail(string subject, string body);
    }
}
