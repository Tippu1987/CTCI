using System;
using System.Collections.Generic;
using System.Xml;

namespace Prob2._7
{
    class Program
    {
        static Node list1 = null, list2 = null;
        static void Main(string[] args)
        {
            Initialize();
            if (FindIntersectionCTCI(list1, list2) == null)
                Console.WriteLine($"Lists do not intersect");
            else
                Console.WriteLine($"{FindIntersection(list1, list2).value}");
        }

        /// <summary>
        /// This is Pavan's Implementation
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        private static Node FindIntersection(Node list1, Node list2)
        {
            Node result = new Node(0);
            if (list1 == null || list2 == null)
            {
                return result;
            }
            else
            {
                Node ptr1 = list1, ptr2 = list2;
                int list1len = 1, list2len = 1;
                while(ptr1.next!=null || ptr2.next != null)
                {
                    if (ptr1.next != null)
                    {
                        list1len++;
                        ptr1 = ptr1.next;
                    }
                    if (ptr2.next != null)
                    {
                        list2len++;
                        ptr2 = ptr2.next;
                    }
                }
                if (ptr1 != ptr2)
                    return result;
                else
                {
                    if (list1len > list2len)
                    {
                        for (int i = 0; i < list1len - list2len; i++)
                        {
                            list1 = list1.next;
                        }
                    }
                    if (list1len < list2len)
                    {
                        for (int i = 0; i < list2len - list1len; i++)
                        {
                            list2 = list2.next;
                        }
                    }
                    ptr1 = list1;
                    ptr2 = list2;
                    while (ptr1 != null && ptr2 != null)
                    {
                        if (ptr1 == ptr2)
                        {
                            result= ptr1;
                            break;
                        }
                        else
                        {
                            ptr1 = ptr1.next;
                            ptr2 = ptr2.next;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// This is CTCI Implementation
        /// </summary>
        private static Node FindIntersectionCTCI(Node list1, Node list2)
        {
            if(list1==null || list2 == null)
                return null;
            Result list1Result = getTailAndLength(list1);
            Result list2Result = getTailAndLength(list2);
            if (list1Result.tailNode != list2Result.tailNode)
                return null;
            Node shorter = list1Result.length < list2Result.length ? list1 : list2;
            Node longer = list1Result.length > list2Result.length ? list1 : list2;

            longer = ShiftListbyKNodes(longer, Math.Abs(list1Result.length - list2Result.length));
            while (longer != shorter)
            {
                longer = longer.next;
                shorter = shorter.next;
            }
            return longer;
        }

        private static Node ShiftListbyKNodes(Node longer, int v)
        {
            if (longer == null) return null;
            for (int i = 0; i < v; i++)
            {
                longer = longer.next;
            }
            return longer;
        }

        private static Result getTailAndLength(Node list)
        {
            if (list == null) return null;
            int length = 1;
            Node ptr = list;
            while (ptr.next != null)
            {
                length++;
                ptr = ptr.next;
            }
            return new Result(ptr, length);
        }



        private static void Initialize()
        {
            Node node3 = new Node(3);
            Node node1 = new Node(1);
            Node node5 = new Node(5);
            Node node9 = new Node(9);
            Node node7 = new Node(7);
            Node node2 = new Node(2);
            Node node12 = new Node(1);
            Node node4 = new Node(4);
            Node node6 = new Node(6);

            list1 = node3;
            node3.next = node1;
            node1.next = node5;
            node5.next = node9;
            node9.next = node7;
            node7.next = node2;
            node2.next = node12;

            list2 = node4;
            node4.next = node6;
            node6.next = node7;
        }
    }

    class Node
    {
        public int value;
        public Node next;
        public Node(int val)
        {
            value = val;
        }
        public void AppendToTail(int val)
        {
            Node newnode = new Node(val);
            Node head = this;
            while (head.next != null)
            {
                head = head.next;
            }
            head.next = newnode;
        }
    }
    class Result
    {
        public int length;
        public Node tailNode;
        public Result(Node tail, int length)
        {
            this.length = length;
            tailNode = tail;
        }
    }
}
