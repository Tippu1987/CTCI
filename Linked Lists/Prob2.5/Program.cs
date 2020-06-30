using System;
using System.Security;

namespace Prob2._5
{
    class Program
    {
        static Node number1 = null, number2 = null;
        static void Main(string[] args)
        {
            InitializeNumbers();
            Node ptr1 = number1, ptr2 = number2, result = null;
            int left = 0, right = 0, quotient = -1, rem = -1, sum = 0,carry=0;
            
            while(ptr1!=null || ptr2 != null)
            {
                left = ptr1 != null ? ptr1.Data : 0;
                right = ptr2 != null ? ptr2.Data : 0;
                sum = left + right + carry;
                if (sum > 9)
                {
                    quotient = sum / 10;
                    rem = sum % 10;
                    carry = quotient;
                    if (result == null)
                        result = new Node(rem);
                    else
                        result.AppendNode(rem);
                }
                else
                {
                    if (result == null)
                        result = new Node(sum);
                    else
                        result.AppendNode(sum);
                }
                ptr1 = ptr1 != null ? ptr1.next : null;
                ptr2 = ptr2 != null ? ptr2.next : null;
            }

            Node resptr = result;
            while(resptr!=null)
            {
                Console.Write($"{resptr.Data}->");
                resptr = resptr.next;
            }
        }

        private static void InitializeNumbers()
        {
            //617
            Node num1 = new Node(7);
            Node num2 = new Node(1);
            Node num3 = new Node(6);
            num1.next = num2;
            num2.next = num3;
            num3.next = null;
            number1 = num1;

            //295
            Node num4 = new Node(5);
            Node num5 = new Node(9);
            //Node num6 = new Node(2);
            num4.next = num5;
            //num5.next = num6;
            num5.next = null;
            number2 = num4;
        }

        private static Node NormalAddition(Node num1, Node num2)
        {
            Node result = null;


            return result;
        }
    }

    public class Node
    {
        public int Data;
        public Node next;
        public Node(int Data)
        {
            this.Data = Data;
        }

        public void AppendNode(int num)
        {
            Node n = new Node(num);
            Node node = this;
            while (node.next != null)
                node = node.next;
            node.next = n;
        }
    }
}
