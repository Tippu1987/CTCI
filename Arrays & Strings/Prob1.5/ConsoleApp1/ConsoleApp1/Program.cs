using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList ll = new MyLinkedList();
            /*["MyLinkedList","addAtHead","Get","addAtHead","addAtHead","deleteAtIndex","addAtHead","Get","Get","Get","addAtHead","deleteAtIndex"]
[[],[4],[1],[1],[5],[3],[7],[3],[3],[3],[1],[4]]
*/
            ll.AddAtHead(1);
            Console.Write(RemoveElements(ll.Head));
              
        }

        class MyLinkedList
        {

            public Node Head;
            Node Tail;
            int Size;
            /** Initialize your data structure here. */
            public MyLinkedList()
            {
                Head = Tail = null;
                Size = 0;
            }

            /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
            public int Get(int index)
            {
                if (index < 0 || index > Size || Head == null) return -1;
                if (index == Size) return -1;
                Node ptr = Head;
                for (int i = 0; i < index; i++)
                    ptr = ptr.next;
                return ptr.data;
            }

            /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
            public void AddAtHead(int val)
            {
                Node newNode = new Node(val);
                if (Head == null)
                {
                    Head = Tail = newNode;
                }
                else
                {
                    newNode.next = Head;
                    Head = newNode;
                }
                Size++;
            }

            public  void printList()
            {
                if (Head == null) return;
                Node ptr = Head;
                while (ptr != null)
                {
                    Console.Write($"{ptr.data}->");
                    ptr = ptr.next;
                }
                Console.WriteLine("-----------------------------------");
            }

            /** Append a node of value val to the last element of the linked list. */
            public void AddAtTail(int val)
            {
                Node newNode = new Node(val);
                if (Head == null)
                {
                    Head = Tail = newNode;
                }
                else
                {
                    Tail.next = newNode;
                    Tail = newNode;
                }
                Size++;
            }

            /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
            public void AddAtIndex(int index, int val)
            {
                if (index < 0 || index > Size) return;
                if (index == 0) AddAtHead(val);
                if (index == Size) AddAtTail(val);
                else
                {
                    Node newNode = new Node(val);
                    Node ptr = Head;
                    for (int i = 0; i < index - 1; i++)
                    {
                        ptr = ptr.next;
                    }
                    Node temp = ptr.next;
                    ptr.next = newNode;
                    newNode.next = temp;
                    Size++;
                }
            }

            public void deleteAtHead()
            {
                if (Head == null) return;
                Head = Head.next;
                Size--;
            }
            /** Delete the index-th node in the linked list, if the index is valid. */
            public void DeleteAtIndex(int index)
            {
                if (index < 0 || index >= Size || Head == null) return;
                if (index == 0) deleteAtHead();
                else
                {
                    Node ptr = Head;
                    for (int i = 0; i < index - 1; i++)
                    {
                        ptr = ptr.next;
                    }
                    Node temp = ptr.next;
                    if (temp == Tail) Tail = ptr;
                    else
                    {
                        ptr.next = temp.next;
                        temp = null;
                    }
                    Size--;
                }
               
            }
        }

        public class Node
        {
            public int data;
            public Node next;
            public Node(int value)
            {
                data = value;
                next = null;
            }
        }

        public static bool RemoveElements(Node head)
        {
            if (head == null || head.next == null) return true;
            Node slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                if(fast!=null)
                    slow = slow.next;
                
            }
            Node reveresedMiddle = ReverseList(slow.next);
            Node ptr = head;
            while (reveresedMiddle != null)
            {
                if (ptr.data != reveresedMiddle.data)
                {
                    return false;
                }
                else
                {
                    ptr = ptr.next;
                    reveresedMiddle = reveresedMiddle.next;
                }
            }
            return true;

        }
        public static Node ReverseList(Node head)
        {
            if (head == null || head.next == null) return head;
            Node prev = null, current = head, next = head.next;
            while (next != null)
            {
                Node tmp = next.next;
                current.next = prev;
                next.next = current;
                prev = current;
                current = next;
                next = tmp;
            }
            return current;
        }

        /**
         * Your MyLinkedList object will be instantiated and called as such:
         * MyLinkedList obj = new MyLinkedList();
         * int param_1 = obj.Get(index);
         * obj.AddAtHead(val);
         * obj.AddAtTail(val);
         * obj.AddAtIndex(index,val);
         * obj.DeleteAtIndex(index);
         */
    }
}
