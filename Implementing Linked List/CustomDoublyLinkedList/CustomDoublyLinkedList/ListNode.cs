using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoublyLinkedList
{
    public class ListNode
    {
        public ListNode(int value)
        {
            Value = value;
        }
        public ListNode Previous { get; set; }
        public ListNode Next { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return $"{Previous?.Value} <- {Value} -> {Next?.Value}";
        }
    }
}
