using System;

namespace Prob2._2
{
    class Program
    {
        private static Node Head = null;
        static void Main(string[] args)
        {
            InitializeLL();
            int k = 2;
            Console.WriteLine($"Kth element from the last is {GetKthElement(k).Data}");

        }

        private static Node GetKthElement(int k)
        {
            if (k < 0) return null;

            Node ptr = Head, ptr2=Head;
            for (int i = 0; i < k; i++)
            {
                ptr = ptr.next;
            }
            while (ptr != null)
            {
                ptr = ptr.next;
                ptr2 = ptr2.next;
            }
            return ptr2;
        }

        private static void InitializeLL()
        {
            Head = new Node(10);
            Head.AppendtoTail(20);
            Head.AppendtoTail(30);
            Head.AppendtoTail(40);
            Head.AppendtoTail(50);
            Head.AppendtoTail(60);
            Head.AppendtoTail(70);
        }
    }
    class Node
    {
        public Node next = null;
        public int Data { get; set; }
        public Node(int data)
        {
            Data = data;
        }
        public void AppendtoTail(int data)
        {
            Node nxtnode = new Node(data);
            Node n = this;
            while (n.next != null)
            {
                n = n.next;
            }
            n.next = nxtnode;
        }
    }

    
}
