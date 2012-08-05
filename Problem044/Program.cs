using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem044
{
    class Program
    {
        static long NthPentagonal(int n)
        {
            // pn = n(3n-1)/2
            return n * (3 * n - 1) / 2;
        }
        static void Main(string[] args)
        {
            for (int i = 1; ; i++)
            {
                long p1 = NthPentagonal(i);
                for (int j = 1; j < i; j++)
                {
                    long p2 = NthPentagonal(j);
                    long sum = p1 + p2;
                    long diff = p1 - p2;
                    if (Euler.Utils.IsPentagonal(sum) && Euler.Utils.IsPentagonal(diff))
                    {
                        Euler.Utils.OutputAnswer(diff.ToString());
                        System.Environment.Exit(0);
                    }
                }
            }
        }
    }
}
