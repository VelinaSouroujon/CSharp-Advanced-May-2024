using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CustomQueue
{
    public class CustomQueue
    {
        private const int Capacity = 4;

        private int[] items;
        private int counter;

        public CustomQueue()
        {
            items = new int[Capacity];
        }
        public CustomQueue(params int[] items)
        {
            this.items = items;
        }

        public int Count => counter;
        public void Enqueue(int value)
        {
            if(counter == items.Length)
            {
                int[] tempArray = new int[items.Length * 2];
                Array.Copy(items, tempArray, items.Length);
                items = tempArray;
            }

            items[counter++] = value;
        }
        public int Dequeue()
        {
            if(counter == 0)
            {
                throw new InvalidOperationException();
            }

            int removedElement = items[0];

            counter--;

            for(int i = 0; i < counter; i++)
            {
                items[i] = items[i + 1];
            }

            if(items.Length / 2 >= counter)
            {
                int[] tempArray = new int[items.Length / 2];
                Array.Copy(items, tempArray, tempArray.Length);
                items = tempArray;
            }

            for (int i = counter; i < items.Length; i++)
            {
                items[i] = default;
            }

            return removedElement;
        }

        public int Peek()
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
            items = new int[Capacity];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < counter; i++)
            {
                action(items[i]);
            }
        }
    }
}
