using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private ListNode head;
        private ListNode tail;
        private int count;
        public int Count => count;

        public void AddFirst(int value)
        {
            ListNode newHead = new ListNode(value);

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
        public void AddLast(int value)
        {
            ListNode newTail = new ListNode(value);

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
        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            int removedValue = head.Value;

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
        public int RemoveLast()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            int removedValue = tail.Value;

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
        public void ForEach(Action<int> action)
        {
            ListNode node = head;

            while (node != null)
            {
                action(node.Value);
                node = node.Next;
            }
        }
        public int[] ToArray()
        {
            int[] array = new int[count];

            ListNode node = head;

            int counter = 0;

            while(node != null)
            {
                array[counter] = node.Value;
                node = node.Next;

                counter++;
            }
            return array;
        }
        public void ForEachBackwards(Action<int> action)
        {
            ListNode node = tail;

            while (node != null)
            {
                action(node.Value);
                node = node.Previous;
            }
        }
        public ListNode Find(int value)
        {
            ListNode node = head;

            while(node != null)
            {
                if(node.Value == value)
                {
                    return node;
                }

                node = node.Next;
            }

            return null;
        }
        public void AddBefore(ListNode currentNode, int value)
        {
            if(currentNode == null)
            {
                throw new InvalidOperationException("Cannot insert before unexisting node");
            }

            ListNode newNode = new ListNode(value);
            ListNode previousNode = currentNode.Previous;

            newNode.Previous = previousNode;
            newNode.Next = currentNode;

            previousNode.Next = newNode;
            currentNode.Previous = newNode;

            count++;
        }
    }
}
