using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    internal static class GenericListExtension
    {

        public static T? FindAndReturnIfEqual<T>(this List<T> obj, T objparm)
        {

            return obj.Contains(objparm) ? objparm : default(T);

        }

        public static List<T> EveryOtherWord<T>(this List<T> list)
        {
            List<T> result = new List<T>();

            for (int i = 0; i < list.Count; i = i + 2)
            {
                result.Add(list[i]);
            }
            return result;
        }
    }
}
