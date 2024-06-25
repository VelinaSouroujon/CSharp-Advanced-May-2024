using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            list.AddFirst(3);
            list.AddFirst(2);
            list.AddFirst(1);
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(6);

            ListNode<int> node = list.Find(4);
            list.AddBefore(node, 100);

            list.ForEach(n => Console.WriteLine(n));
        }
    }
}
