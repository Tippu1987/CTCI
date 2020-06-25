using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the String");
            string input = Console.ReadLine();
            Console.WriteLine(IsPalindromePermutation(input));
        }

        private static bool IsPalindromePermutation(string input)
        {
            bool bret = true;
            if (string.IsNullOrEmpty(input))
            {
                bret = true;
            }
            else
            {
                Dictionary<char, int> charCount = new Dictionary<char, int>();
                for (int i = 0; i < input.Length; i++)
                {
                    if(input[i] != ' ')
                    {
                        if (charCount.ContainsKey(input[i]))
                            charCount[input[i]] = charCount[input[i]] + 1;
                        else
                            charCount.Add(input[i], 1);
                    }
                    
                }

                bool oddcount = false;
                foreach (var kvp in charCount)
                {
                    if (kvp.Value % 2 == 0)
                        continue;
                    else
                    {
                        if (!oddcount)
                        {
                            oddcount = true;
                            continue;
                        }
                        else
                        {
                            bret = false;
                            break;
                        }
                    }
                }
            }
            return bret;
        }
    }
}
