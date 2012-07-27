﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public class Utils
    {
        public static void OutputAnswer(string s)
        {
            Console.WriteLine(s);
            Console.ReadLine();
        }


        public static bool IsPrime(long n)
        {
            if (n < 2) { return false; }
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

        public static IEnumerable<long> Triangles(long upTo = 0)
        {
            long i = 1;
            long sum = i;
            while (upTo <= 0 || sum < upTo)
            {
                yield return sum;
                sum += ++i;
            }
        }

        public static long NumDivisors(long n)
        {
            // if memory serves, if a number n has prime factors
            // a^x * b^y * c^z, then it has 
            // (x+1) * (y+1)* (z+1) divisors
            List<long> factors = PrimeFactors(n).ToList();
            long product = 1;
            foreach (long factor in factors.Distinct())
            {
                int count = factors.Where(x => x == factor).Count();
                product *= (count + 1);
            }
            return product;
        }

        public static IEnumerable<long> Collatz(long n)
        {            
            while (n > 1)
            {
                yield return n;
                if (n % 2 == 0)
                {
                    n /= 2;
                }
                else
                {
                    n = 3 * n + 1;
                }
            }
            yield return n;
        }
    }
}
