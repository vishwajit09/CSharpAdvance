using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service.Interface
{
    internal interface IPdfConverter
    {
        void ConvertTextToPdf(string text, string outputPath);
    }
}
