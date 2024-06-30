using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] items;
        public Lake(IEnumerable<int> collection)
        {
            items = collection.ToArray();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < items.Length; i += 2)
            {
                yield return items[i];
            }

            int startIdx = items.Length % 2 == 0 ? items.Length - 1 : items.Length - 2;
            for (int i = startIdx; i >= 0; i -= 2)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
