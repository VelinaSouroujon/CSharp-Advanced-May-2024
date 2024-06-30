using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> list;
        private int index;

        public ListyIterator(IEnumerable<T> collection)
        {
            list = new List<T>(collection);
        }

        public bool Move()
        {
            if(HasNext())
            {
                index++;
                return true;
            }

            return false;
        }
        public bool HasNext()
        {
            return index < list.Count - 1;
        }
        public void Print()
        {
            if(list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(list[index]);
        }
    }
}
