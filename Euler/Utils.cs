using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public class Utils
    {
        public static void OutputAnwser(string s)
        {
            Console.WriteLine(s);
            Console.ReadLine();
        }


        public static bool IsPrime(long n)
        {
            double target = Math.Sqrt((double)n);
            for (long i = 2; i <= target; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public static IEnumerable<long> Range(long start, long end, long step=1)
        {
            for (long i = start; i < end; i += step)
            {
                yield return i;
            }
        }


        public static IEnumerable<long> GeneratePrimes(long upTo = 100)
        {
            // Prime sieve, standard algorithm
            bool[] sieve = new bool[upTo];
            for (long i=0; i<upTo; i++) {
                sieve[i] = true;
            }

            for (long i = 2; i < upTo; i++ )
            {
                if (!sieve[i]) { continue; }
                yield return i;

                for (long j = i + i; j < upTo; j += i)
                {
                    sieve[j] = false;
                }
            }
        }

        public static IEnumerable<long> PrimeFactors(long n)
        {
            // http://stackoverflow.com/questions/23287/prime-factors
            long d = 2;
            while (n > 1)
            {
                while (n % d == 0)
                {
                    yield return d;
                    n /= d;
                }
                d++;
            }
        }

        public static bool IsPalindrome(long n) {
            // easiest way, I think, is to convert it to a string.
            // We could mess around with modulos base 10, but let's not.
            string s = "" + n;
            int limit = s.Length/2;
            for (int i = 0; i < limit; i++)
            {
                if (s[i] != s[s.Length - 1 - i]) { return false; }
            }
            return true;
        }
    }
}
