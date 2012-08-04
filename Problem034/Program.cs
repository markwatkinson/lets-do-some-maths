using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem034
{
    class Program
    {
        static int[] factorial = new int[10] {
            1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880
        };


        static long FactorialSum(long n) {
            long sum = 0;
            foreach (char c in n.ToString()) {
                int d = c - '0';
                sum += factorial[d];
            }
            return sum;
        }
        
        static void Main(string[] args)
        {
            // Find the sum of all numbers which are equal to the sum of the factorial of their digits.

            // it's not obvious what the upper limit is so let's just go with it
            long s = 0;
            for (long i = 10; i < 9999999; i++)
            {
                if (FactorialSum(i) == i)
                {
                    s += i;
                    Console.WriteLine(s);
                }
            }
            Console.ReadLine();
        }
    }
}
