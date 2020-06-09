using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

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
            if (isUniqueNoExtraMemory(inputStr))
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
                for (int i = 0; i < inputStr.Length; i++)
                {
                    if (!charDict.ContainsKey(inputStr[i]))
                        charDict.Add(inputStr[i], 1);
                    else
                        return false;
                }
                return true;
            }
        }
        public static bool isUniqueAssumingAsciiString(string inputStr)
        {
            if (string.IsNullOrEmpty(inputStr))
                return false;
            else
            {
                bool[] resultArray = new bool[128];
                for (int i = 0; i < resultArray.Length; i++)
                {
                    resultArray[i] = false;
                }
                for (int i = 0; i < inputStr.Length; i++)
                {
                    int charAt = inputStr[i];
                    if (resultArray[charAt])
                        return false;
                    else
                        resultArray[charAt] = true;
                }
                return true;
            }



        }

        public static bool isUniqueNoExtraMemory(string inputStr)
        {
            if (string.IsNullOrEmpty(inputStr))
                return false;
            else
            {
                for (int i = 0; i < inputStr.Length; i++)
                {
                    for (int j = i+1; j < inputStr.Length; j++)
                    {
                        if (inputStr[j] == inputStr[i])
                            return false;
                    }
                }
                return true;
            }
        }
        //Shud Clear the Bitwise Operation Solution..:(
    }
}
