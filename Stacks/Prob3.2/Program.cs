using System;

namespace Prob3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack mtstack = new Stack();
            mtstack.Push(10);
            mtstack.Push(20);
            mtstack.Push(30);
            Console.WriteLine(mtstack.Peek().min);
            mtstack.Push(5);
            Console.WriteLine(mtstack.Peek().min);
        }
    }

    class Stack
    {
        private int top;
        private int min;
        StackNodeWithMin[] stackarray = new StackNodeWithMin[20];
        public Stack()
        {
            top = -1;
            min = int.MaxValue;
        }

        public void Push(int val)
        {
            if (top < stackarray.Length)
            {
                StackNodeWithMin node = null;
                if (val < min)
                {
                    node = new StackNodeWithMin(val, val);
                    min = val;
                }
                else
                    node = new StackNodeWithMin(val, min);
                stackarray[++top] = node;
            }
            else
                Console.WriteLine($"Max Stack Capacity Exceeded..");
        }
        public StackNodeWithMin Pop()
        {
            if (top > -1 && top < stackarray.Length)
                return stackarray[top--];
            else
            {
                Console.WriteLine($"Stack is Empty at this time");
                return null;
            }
                
        }
         
        public void PrintStack()
        {
            for (int i = top; i > -1; i--)
            {
                Console.WriteLine($"Element @ {i} = ({stackarray[i].data},{stackarray[i].min})");
            }
        }
        public bool IsEmpty()
        {
            return top == -1;
        }

        public StackNodeWithMin Peek()
        {

            return IsEmpty() ? null : stackarray[top];
        }
    }

    class StackNodeWithMin {
       public int data;
        public int min;
        public StackNodeWithMin(int data, int min)
        {
            this.data = data;
            this.min = min;
        }
    }

}
