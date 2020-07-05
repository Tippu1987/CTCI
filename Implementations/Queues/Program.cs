using System;
using System.Xml.Linq;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Queue Using Arrays....");
            Queue q = new Queue(20);
            q.Insert(11);
            q.Insert(22);
            q.Insert(33);
            q.Insert(44);
            q.PrintQueue();
            Console.WriteLine(q.Delete());
            q.PrintQueue();
            Console.WriteLine("..........................");
            Console.WriteLine(q.Delete());
            q.PrintQueue();
            Console.WriteLine(q.Delete());
            q.PrintQueue();
            q.Delete();
            q.PrintQueue();

        }
    }

    class Queue
    {
        int[] queue = null;
        int front, rear, Capacity;
        public Queue(int capacity)
        {
            front = rear = -1;
            queue = new int[capacity];
            Capacity = capacity;
        }

        public void Insert(int number)
        {
            if(front<0)
            {
                queue[++rear] = number;
                front = rear;
                    
            }
            else if (rear < Capacity)
            {
                queue[++rear] = number;
            }
            else
            {
                Console.WriteLine($"Queue Overflow..");
            }
        }

        public int Delete()
        {
            if (front <= rear)
            {
                int num = queue[front];
                for (int i = 1; i < Capacity; i++)
                {
                    queue[i - 1] = queue[i];
                }
                rear--;
                return num;
            }
            else
            {
                Console.WriteLine($"Queue Underflow..");
                return -1;
            }
        }
        public void PrintQueue()
        {
            if (front < 0)
            {
                Console.WriteLine($"Queue is Empty");
            }
            else
            {
                int i = front;
                while (i <= rear)
                    Console.Write($"{queue[i++]}->");
            }
        }
    }
}
