using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CustomStack
{
    public class CustomStack
    {
        private const int Capacity = 4;

        private int[] items;
        private int counter;

        public CustomStack()
        {
            items = new int[Capacity];
        }

        public int Count => counter;
        public void Push(int value)
        {
            if(counter == items.Length)
            {
                int[] tempArray = new int[items.Length * 2];
                Array.Copy(items, tempArray, items.Length);
                items = tempArray;
            }

            items[counter++] = value;
        }

        public int Pop()
        {
            if(counter == 0)
            {
                throw new InvalidOperationException();
            }

            int removedElement = items[counter - 1];
            items[counter - 1] = default;

            counter--;

            if(items.Length / 2 >= counter)
            {
                int[] tempArray = new int[items.Length / 2];
                Array.Copy(items, tempArray, tempArray.Length);
                items = tempArray;
            }

            return removedElement;
        }

        public int Peek()
        {
            if (counter == 0)
            {
                throw new InvalidOperationException();
            }

            return items[counter - 1];
        }

        public void ForEach(Action<int> action)
        {
            for(int i = counter - 1; i >= 0; i--)
            {
                action(items[i]);
            }
        }
    }
}
