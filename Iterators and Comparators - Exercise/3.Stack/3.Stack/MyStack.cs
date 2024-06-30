using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;

        private T[] items;
        private int index;

        public MyStack()
        {
            items = new T[InitialCapacity];
        }
        public int Count => index;
        public void Push(T item)
        {
            if(!IsIndexValid())
            {
                Resize();
            }

            items[index] = item;
            index++;
        }
        public T Pop()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            index--;
            return items[index];
        }
        private void Resize()
        {
            T[] temp = new T[2 * items.Length];
            Array.Copy(items, temp, items.Length);
            items = temp;
        }
        private bool IsIndexValid()
        {
            return index < items.Length;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = Count - 1; i >= 0; i--)
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
