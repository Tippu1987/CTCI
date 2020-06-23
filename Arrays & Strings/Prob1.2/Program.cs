using System;
using System.ComponentModel;
using System.Linq;

namespace Prob1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Source String");
            var src = Console.ReadLine();
            Console.WriteLine("Please Enter Permutated String");
            var target = Console.ReadLine();

            if (isPermutatedBySort(src, target))
                Console.WriteLine($"Target is Permutated String of Src String");
            else
                Console.WriteLine($"Target is NOT A Permutated String of Src String");

        }

        private static bool isPermutated(string src, string target)
        {
            if (src.Length != target.Length)
                return false;
            else
            {
                //Search every string in src in Target using 2 loops O(N2)
                
                foreach(char chr in src)
                {
                    //this assumes each char is unique
                    if (!target.Contains(chr))
                        return false;
                }
            }
            return true;
        }

        private static bool isPermutatedByCount(string src, string target)
        {
            //This assumes only ASCII values are in the string
            int[] cntarray = new int[128];
            int[] trgcntarray = new int[128];
            //use an array for counting the occurances of each char and compare the resulted array for both O(N) with Auxillary Space
            if (src.Length != target.Length)
                return false;
            else
            {
                foreach (char chr in src)
                {
                    //this assumes each char is unique
                    cntarray[chr]++;
                }
                Console.WriteLine(string.Join(',', cntarray));
                foreach (char chr in target)
                {
                    //this assumes each char is unique
                    trgcntarray[chr]++;
                }
                Console.WriteLine(string.Join(',', trgcntarray));

                for(int i = 0; i < 128; i++)
                {
                    if (!(cntarray[i] == trgcntarray[i]))
                        return false;
                }
            }
            return true;
        }

        private static bool isPermutatedBySort(string src, string target)
        {
            //Sort Arrays and compare 
            if (src.Length != target.Length)
                return false;
            else
            {
                char[] trgArray = target.ToCharArray();
                char[] srcArray = src.ToCharArray();
                Array.Sort(trgArray);
                Array.Sort(srcArray);
                Console.WriteLine($"Sorted Source: {string.Join(',',srcArray)}");
                Console.WriteLine($"Sorted Target: {string.Join(',',trgArray)}");
                for(int i = 0; i < src.Length; i++)
                {
                    if (!(trgArray[i] == srcArray[i]))
                        return false;
                }
            }
            return true;
        }
        
        
    }
}
