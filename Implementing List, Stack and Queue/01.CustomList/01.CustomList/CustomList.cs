using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CustomList
{
    public class CustomList<T>
    {
        private const int InitialSize = 2;

        private T[] items;
        private int counter = 0;

        public CustomList()
        {
            items = new T[InitialSize];
        }

        public int Count => counter;

        public T this[int i]
        {
            get
            {
                ValidateRange(i);
                return items[i];
            }
            set
            {
                ValidateRange(i);
                items[i] = value;
            }
        }
        public void Add(T value)
        {
            if (counter == items.Length)
            {
                Resize();
            }

            items[counter++] = value;
        }
        public T RemoveAt(int index)
        {
            ValidateRange(index);

            T removedValue = items[index];

            for(int i = index; i < counter - 1; i++)
            {
                items[i] = items[i + 1];
            }

            counter--;

            if (items.Length / 2 >= counter)
            {
                T[] tempArray = new T[counter];
                Array.Copy(items, tempArray, counter);
                items = tempArray;
            }
            else
            {
                for(int i = counter; i < items.Length; i++)
                {
                    items[i] = default;
                }
            }

            return removedValue;
        }
        public bool Contains(int value)
        {
            for(int i = 0; i < counter; i++)
            {
                if(items[i].Equals(value))
                {
                    return true;
                }
            }

            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateRange(firstIndex);
            ValidateRange(secondIndex);

            T tempValue = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = tempValue;
        }

        public void Insert(int index, T item)
        {
            ValidateRange(index);

            counter++;

            if (counter == items.Length)
            {
                Resize();
            }

            for(int i = counter - 1; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
        }
        private void ValidateRange(int index)
        {
            if(index < 0 || index >= counter)
            {
                throw new IndexOutOfRangeException();
            }
        }
        private void Resize()
        {
            T[] tempArray = new T[items.Length * 2];
            Array.Copy(items, tempArray, items.Length);
            items = tempArray;
        }
    }
}
