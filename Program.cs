using System;
using System.Collections.Generic;

namespace TT
{
    class Program
    {
        static int Min_Mult = 10000;
        static int Max_Mult = 99999;        
        static void Main()
        {
            List<int> allPrimeNumbers = new List<int>(SearchPrimeNumbers(Max_Mult, Min_Mult));
            SearchMaxPalindrome(allPrimeNumbers);
        }        
        static List<int> SearchPrimeNumbers(int max, int min)
        {
            List<int> allPrimeNumbers = new List<int>();
            bool[] isPrimes = new bool[max];

            for (int i = 2; Math.Pow(i, 2) <= max; i++)
            {
                if (!isPrimes[i])
                {
                    for (int j = (int)Math.Pow(i, 2); j < max; j += i)
                    {
                        isPrimes[j] = true;
                    }
                }
            }
            for (int i = max - 1; i >= min; i--)
            {
                if (!isPrimes[i])
                {
                    allPrimeNumbers.Add(i);
                }
            }
            return allPrimeNumbers;
        }
        static void SearchMaxPalindrome(List<int> allPrimeNumbers)
        {
            long palindrome = 0;
            long mult1 = 0;
            long mult2 = 0;
            for (int j = 0; j < allPrimeNumbers.Count; j++)
            {
                for (int k = 0; k < allPrimeNumbers.Count; k++)
                {
                    long i = (long)allPrimeNumbers[j] * (long)allPrimeNumbers[k];
                    if (CheckPal(i))
                    {
                        if (i > palindrome)
                        {
                            palindrome = i;
                            mult1 = allPrimeNumbers[j];
                            mult2 = allPrimeNumbers[k];
                        }
                    }
                }
            }
            Console.WriteLine("palindrome = " + palindrome + "\nmultiplier1 = " + mult1 + "\nmultiplier2 = " + mult2);
            Console.ReadKey();
        }
        static bool CheckPal(long i)
        {
            string palindrome = i.ToString();
            int begin = 0;
            int end = palindrome.Length - 1;
            while (begin < end)
            {
                if (palindrome[begin] == palindrome[end])
                {
                    begin++;
                    end--;
                }
                else return false;
            }
            return true;
        }
    }
}
