using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter String:");
            string str1 = Console.ReadLine();
            Console.WriteLine(CompressStringDict(str1));
        }

        private static string CompressString(string input)
        {
            Dictionary<char, int> chars = new Dictionary<char, int>();
            StringBuilder output = new StringBuilder();

            char[] inpstr = input.ToCharArray();
            int counter = 1;
            for (int i = 0, j = 1; j < inpstr.Length; i++, j++)
            {
                if (j == inpstr.Length - 1)
                {
                    if (inpstr[i] == inpstr[j])
                        output.Append(inpstr[i] + (++counter).ToString());
                    else
                    {
                        output.Append(inpstr[i] + counter.ToString());
                        output.Append(inpstr[j] + 1.ToString());
                    }
                }
                else
                {
                    if (inpstr[i] == inpstr[j])
                        counter++;
                    else
                    {
                        output.Append(inpstr[i] + counter.ToString());
                        counter = 1;
                    }
                }
            }
            return output.ToString();
        }
        private static string CompressStringDict(string input)
        {
            Dictionary<char, int> chars = new Dictionary<char, int>();
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (chars.ContainsKey(input[i]))
                    chars[input[i]] = ++chars[input[i]];
                else
                {
                    if (chars.Count > 0)
                    {
                        output.Append(chars.First().Key + chars.First().Value.ToString());
                        chars.Clear();
                    }
                    chars.Add(input[i], 1);
                }
                if (i == input.Length - 1)
                {
                    output.Append(chars.First().Key + chars.First().Value.ToString());
                    chars.Clear();
                }
            }

            return output.Length >= input.Length ? input : output.ToString();
        }
    }
}
