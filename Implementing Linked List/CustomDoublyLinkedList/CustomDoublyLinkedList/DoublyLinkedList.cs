using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;
        private int count;
        public int Count => count;

        public void AddFirst(T value)
        {
            ListNode<T> newHead = new ListNode<T>(value);

            if (head == null)
            {
                head = newHead;
                tail = newHead;

                count++;

                return;
            }
            head.Previous = newHead;
            newHead.Next = head;
            head = newHead;

            count++;
        }
        public void AddLast(T value)
        {
            ListNode<T> newTail = new ListNode<T>(value);

            if(tail == null)
            {
                head = newTail;
                tail = newTail;

                count++;

                return;
            }
            tail.Next = newTail;
            newTail.Previous = tail;
            tail = newTail;

            count++;
        }
        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            T removedValue = head.Value;

            head = head.Next;

            if(head != null)
            {
                head.Previous = null;
            }
            else
            {
                tail = null;
            }

            count--;
            return removedValue;
        }
        public T RemoveLast()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            T removedValue = tail.Value;

            tail = tail.Previous;

            if(tail != null)
            {
                tail.Next = null;
            }
            else
            {
                head = null;
            }

            count--;
            return removedValue;
        }
        public void ForEach(Action<T> action)
        {
            ListNode<T> node = head;

            while (node != null)
            {
                action(node.Value);
                node = node.Next;
            }
        }
        public T[] ToArray()
        {
            T[] array = new T[count];

            ListNode<T> node = head;

            int counter = 0;

            while(node != null)
            {
                array[counter] = node.Value;
                node = node.Next;

                counter++;
            }
            return array;
        }
        public void ForEachBackwards(Action<T> action)
        {
            ListNode<T> node = tail;

            while (node != null)
            {
                action(node.Value);
                node = node.Previous;
            }
        }
        public ListNode<T> Find(T value)
        {
            ListNode<T> node = head;

            while(node != null)
            {
                if(node.Value.Equals(value))
                {
                    return node;
                }

                node = node.Next;
            }

            return null;
        }
        public void AddBefore(ListNode<T> currentNode, T value)
        {
            if(currentNode == null)
            {
                throw new InvalidOperationException("Cannot insert before unexisting node");
            }

            ListNode<T> newNode = new ListNode<T>(value);
            ListNode<T> previousNode = currentNode.Previous;

            newNode.Previous = previousNode;
            newNode.Next = currentNode;

            previousNode.Next = newNode;
            currentNode.Previous = newNode;

            count++;
        }
    }
}
