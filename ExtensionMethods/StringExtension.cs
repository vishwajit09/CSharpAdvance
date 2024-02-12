using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    internal static class StringExtension
    {
        public static bool ContainSpace(this string str)
        {
            return str.Contains(" ");
        }

        public static string BuildEmail(this string str, string fullName, int yearOfBirth, string domain)
        {
            return fullName + yearOfBirth + "@" + domain;
        }
    }
}
