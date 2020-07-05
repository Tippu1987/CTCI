using System;

namespace Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Array Implementation of Stack............\n");
            LLStack stack = new LLStack();
            stack.Push(11);
            stack.Push(22);
            stack.Push(33);
            stack.Push(44);
            stack.PrintStack();
            Console.WriteLine($"Popped Element: {stack.Pop()}");
            Console.WriteLine($"Current Top Element: {stack.Peek()}");
            Console.WriteLine($"Popped Element: {stack.Pop()}");
            Console.WriteLine($"Current Top Element: {stack.Peek()}");
            Console.WriteLine($"Popped Element: {stack.Pop()}");
            Console.WriteLine($"Current Top Element: {stack.Peek()}");
            Console.WriteLine($"Popped Element: {stack.Pop()}");
            Console.WriteLine($"Current Top Element: {stack.Peek()}");

        }
    }

    class Stack
    {
        int[] myArr = new int[20];
        public int Top;
        public Stack()
        {
            Top = -1;
        }
        public void Push(int number)
        {
            if (Top < myArr.Length - 1)
                myArr[++Top] = number;
        }
        public int Pop()
        {
            if (Top >= 0)
                return myArr[Top--];
            return -1;
        }
        public int Peek()
        {
            if (Top >= 0 && Top <= myArr.Length - 1)
            {
                return myArr[Top];
            }
            else
                return -1;
        }

        public void PrintStack()
        {
            if (Top == -1)
            {
                Console.WriteLine("Stack is Empty");

            }
            else
            {
                for (int i = Top; i >= 0; i--)
                {
                    Console.Write($"{myArr[i]}->");
                }
            }

        }
    }

    class LLStack
    {
        Node Head;
        Node Top;
        public LLStack()
        {
            Head = Top = null;
        }

        public bool Push(int num)
        {
            bool bRet;
            try
            {
                if (IsEmpty())
                {
                    Head = Top = new Node(num);
                    bRet = true;
                }
                else
                {
                    Top.Next = new Node(num);
                    Top = Top.Next;
                    bRet = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Occurred while pushing on Stack:\n {ex.Message} ");
                bRet = false;
            }
            return bRet;
        }
        public int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine($"Stack Underflow Error..");
                return -1;
            }
            else
            {
                if (Head == Top)
                {
                    int numbr = Top.Data;
                    Head = Top = null;
                    return numbr;
                }
                else
                {
                    Node ptr = Head;
                    while (ptr.Next != Top)
                    {
                        ptr = ptr.Next;
                    }
                    int num = Top.Data;
                    Top = ptr;
                    Top.Next = null;
                    return num;
                }
            }
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine($"Stack is Empty..");
                return -1;
            }
            else
            {
                return Top.Data;
            }
        }

        public bool IsEmpty()
        {
            return Top == null;
        }

        public void PrintStack()
        {
            if (IsEmpty())
            {
                Console.WriteLine($"Stack is Empty..");
            }
            else
            {
                Node ptr = Head;
                while (ptr != null)
                {
                    Console.WriteLine($"{ptr.Data}->");
                    ptr = ptr.Next;
                }
            }
        }
    }

    class Node
    {
        public int Data;
        public Node Next;
        public Node(int Data)
        {
            this.Data = Data;
        }
    }
}
