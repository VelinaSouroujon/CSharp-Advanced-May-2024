using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int Capacity = 4;

        private T[] items;
        private int counter;

        public CustomStack()
        {
            items = new T[Capacity];
        }

        public int Count => counter;
        public void Push(T value)
        {
            if(counter == items.Length)
            {
                T[] tempArray = new T[items.Length * 2];
                Array.Copy(items, tempArray, items.Length);
                items = tempArray;
            }

            items[counter++] = value;
        }

        public T Pop()
        {
            if(counter == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T removedElement = items[counter - 1];
            items[counter - 1] = default;

            counter--;

            if(items.Length / 2 >= counter)
            {
                T[] tempArray = new T[items.Length / 2];
                Array.Copy(items, tempArray, tempArray.Length);
                items = tempArray;
            }

            return removedElement;
        }

        public T Peek()
        {
            if (counter == 0)
            {
                throw new InvalidOperationException();
            }

            return items[counter - 1];
        }

        public void ForEach(Action<T> action)
        {
            for(int i = counter - 1; i >= 0; i--)
            {
                action(items[i]);
            }
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
