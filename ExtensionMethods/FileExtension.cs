using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    internal static class FileExtension
    {
        public static string EverySecondLine(this FileStream file)
        {


            string data = string.Empty;
            StreamReader sr = new StreamReader(file);

            if (file == null) { throw new ArgumentNullException("file"); }


            while (sr.ReadLine() != null)
            {
                data = data + "\n" + sr.ReadLine();

            }


            return data;
        }
    }
}
