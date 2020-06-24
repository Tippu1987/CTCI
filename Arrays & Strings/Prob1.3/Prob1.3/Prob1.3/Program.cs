using System;
using System.Globalization;
using System.Text;

namespace Prob1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Input String");
            string input = Console.ReadLine();
            Console.WriteLine(URLify(input));
        }

        private static string URLify(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                StringBuilder sb = new StringBuilder();
                int startIndex = 0, endIndex = input.Length - 1;
                while (input[startIndex] == ' ' && startIndex < endIndex)
                {
                    startIndex++;
                }
                while (input[endIndex] == ' ' && startIndex <= endIndex)
                {
                    endIndex--;
                }
                for (int i = startIndex; i < endIndex; i++)
                {
                    if (input[i] == ' ')
                    {
                        sb.Append("%20");
                    }
                    else
                        sb.Append(input[i]);
                }

                return sb.ToString();
            }
            else
                return "Empty String or NULL";
        }
    }
}
