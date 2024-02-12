using System.Security.Cryptography.X509Certificates;
using ATM.Service;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DanskeATM danskeATM = new DanskeATM();
            danskeATM.Menu();

        }

    }
}

