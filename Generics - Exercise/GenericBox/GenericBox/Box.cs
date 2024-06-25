using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBox
{
    public class Box<T> where T : IComparable<T>
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }
        public int CountElementsGreaterThanValue(List<T> list)
        {
            return list
                .Count(x => x.CompareTo(value) == 1);
        }

        public override string ToString()
        {
            return $"{value.GetType()}: {value}";
        }
    }
}
