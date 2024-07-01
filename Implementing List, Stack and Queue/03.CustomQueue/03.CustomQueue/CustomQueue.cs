using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CustomQueue
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        private const int Capacity = 4;

        private T[] items;
        private int counter;

        public CustomQueue()
        {
            items = new T[Capacity];
        }
        public CustomQueue(params T[] items)
        {
            this.items = items;
        }

        public int Count => counter;
        public void Enqueue(T value)
        {
            if(counter == items.Length)
            {
                T[] tempArray = new T[items.Length * 2];
                Array.Copy(items, tempArray, items.Length);
                items = tempArray;
            }

            items[counter++] = value;
        }
        public T Dequeue()
        {
            if(counter == 0)
            {
                throw new InvalidOperationException();
            }

            T removedElement = items[0];

            counter--;

            for(int i = 0; i < counter; i++)
            {
                items[i] = items[i + 1];
            }

            if(items.Length / 2 >= counter)
            {
                T[] tempArray = new T[items.Length / 2];
                Array.Copy(items, tempArray, tempArray.Length);
                items = tempArray;
            }

            for (int i = counter; i < items.Length; i++)
            {
                items[i] = default;
            }

            return removedElement;
        }

        public T Peek()
        {
            if (counter == 0)
            {
                throw new InvalidOperationException();
            }

            return items[0];
        }

        public void Clear()
        {
            counter = 0;
            items = new T[Capacity];
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < counter; i++)
            {
                action(items[i]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < counter; i++)
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
