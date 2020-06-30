using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Prob_2._6
{
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
    class Program
    {
        private static Node Head = null;
        static void Main(string[] args)
        {
            InitializeLL();
            Node n = Head;
            //while (n.next != null)
            //{
            //    Console.Write($"{n.Data}->");
            //    n = n.next;
            //}
            //Console.Write($"{n.Data}->");
            Console.WriteLine($"{reverseAndClone(Head).Data}");
        }

        private static bool IsLLPalindrome(Node head)
        {
            Node reverseHead = ReverseLL(head);
            Node node = reverseHead;
            while (node != null)
            {
                Console.Write($"{node.Data}->");
                node = node.next;
            }
            return true;
        }

        private static Node ReverseLL(Node head)
        {
            Node Prev = null, current = head, next = null;
            while (current != null)
            {
                Node n = new Node(head.Data);
                n.next = head.next;
                head = n;

                //next = current.next;
                //current.next = Prev;
                //Prev = current;
                //current = next;
            }
            return Prev;
        }

        static Node reverseAndClone(Node node)
        {
            Node head = null;
            while (node != null)
            {
                Node n = new Node(node.Data);
                n.next = head;
                head = n;
                node = node.next;
            }
            return head;
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
}
