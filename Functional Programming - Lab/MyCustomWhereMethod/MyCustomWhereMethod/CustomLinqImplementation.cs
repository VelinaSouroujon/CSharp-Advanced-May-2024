using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomWhereMethod
{
    internal static class CustomLinqImplementation
    {
        public static IEnumerable<int> Where(this IEnumerable<int> collection, Func<int, bool> filter)
        {
            List<int> items = new List<int>();

            foreach (int item in collection)
            {
                if (filter(item))
                {
                    items.Add(item);
                }
            }

            return items;
        }

        public static List<int> ToList(this IEnumerable<int> collection)
        {
            List<int> items = new List<int>();

            foreach (int item in collection)
            {
                items.Add(item);
            }

            return items;
        }
    }
}
