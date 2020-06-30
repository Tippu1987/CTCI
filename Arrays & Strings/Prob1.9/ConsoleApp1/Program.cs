using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter String 1:");
            string str1 = Console.ReadLine();
            Console.WriteLine("Enter String 2:");
            string str2 = Console.ReadLine();

            Console.WriteLine(IsS1ARotationOfS2(str1, str2));
            Console.WriteLine(IsS1ARotationOfS2InBook(str1, str2));

        }

        private static bool IsS1ARotationOfS2InBook(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2) || str1.Length != str2.Length)
                return false;
            else
                return isSubString(str1 + str1, str2);
            //TC: O(isSubstring)
        }

        private static bool IsS1ARotationOfS2(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2) || str1.Length != str2.Length)
                return false;
            else 
            {
                int j = 0, s2Index = str2.IndexOf(str1[j]);
                for (int i = s2Index; i < str2.Length; i++)
                {
                    if (str2[i] != str1[j++])
                        return false;
                }
                return (isSubString(str2, str1.Substring(j)));
            }
            //TC: O(N) +O(isSubstring)
        }

        static bool isSubString(string s1, string s2)
        {
            return s1.Contains(s2);
        }
    }
}
