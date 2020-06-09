using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Prob1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your String..");
            string inputStr = Console.ReadLine();
            Stopwatch stp = new Stopwatch();
            stp.Start();
            if (isUnique(inputStr))
                Console.WriteLine($"Input String is Char Unique: {stp.ElapsedMilliseconds}");
            else
                Console.WriteLine($"Input String is NOT Char Unique: {stp.ElapsedMilliseconds}");

        }

        public static bool isUnique(string inputStr)
        {
            if (string.IsNullOrEmpty(inputStr))
                return false;
            else
            {
                Dictionary<char, int> charDict = new Dictionary<char, int>();
                for(int i = 0; i < inputStr.Length; i++)
                {
                    if (!charDict.ContainsKey(inputStr[i]))
                        charDict.Add(inputStr[i], 1);
                    else
                        return false;
                }
                return true;
            }
        }
    }
}
