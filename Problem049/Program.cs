using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem049
{
    class Program
    {
        static bool IsPermutation(long n1, long n2)
        {
            string s1 = n1.ToString(), s2 = n2.ToString();
            if (s1.Length != s2.Length) { return false; }

            foreach (char c in s1)
            {
                if (s1.Count(x => c==x) != s2.Count(x => c == x))
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            // this is a bit slow but it gets there in the end
            // the permutation func is probably a bottleneck

            // all four digit primes
            IEnumerable<long> primes = Euler.Utils.GeneratePrimes(9999).Where(x => x >= 1000);
            Console.WriteLine("Generated primes");
            int numPrimes = primes.Count();
            for (int i = 0; i < numPrimes; i++)
            {
                long p1 = primes.ElementAt(i);

                for (int j = i + 1; j < numPrimes; j++)
                {
                    long p2 = primes.ElementAt(j);
                    long diff = p2 - p1;

                    long p3 = p2 + diff;
                    if (Euler.Utils.IsPrime(p3))
                    {
                        if (IsPermutation(p1, p2) && IsPermutation(p1, p3))
                        {
                            Console.WriteLine("{0} {1} {2}", p1, p2, p3);
                        }
                    }
                    
                }
            }
            Console.WriteLine("Done");
            Console.ReadLine();

        }
    }
}
