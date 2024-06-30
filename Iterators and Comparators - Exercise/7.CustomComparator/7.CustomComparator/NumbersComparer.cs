using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.CustomComparator
{
    public class NumbersComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            int result;

            if ((x % 2 == 0 && y % 2 == 0)
                || (x % 2 != 0 && y % 2 != 0))
            {
                result = x.CompareTo(y);
            }
            else if(x % 2 == 0)
            {
                result = -1;
            }
            else
            {
                result = 1;
            }

            return result;
        }
    }
}
