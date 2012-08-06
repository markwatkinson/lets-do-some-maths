using System;
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

        /// <summary>
        /// Determines whether a number is prime.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a range of numbers 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static IEnumerable<long> Range(long start, long end, long step=1)
        {
            for (long i = start; i < end; i += step)
            {
                yield return i;
            }
        }


        /// <summary>
        /// Generates a sequence of primes, optionally up to a given number
        /// </summary>
        /// <param name="upTo"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Calculates the prime factors of a given number
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Return the set of divisors for a number. 
        /// Divisors will be sorted in ascending order, and may include 1 but
        /// not n.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IList<long> Divisors(long n)
        {
            var divisors = new List<long>();
            if (n >= 1) {
                divisors.Add(1);
            }
            double limit = Math.Sqrt(n);
            for (long i = 2; i <= limit; i++)
            {
                if (n % i == 0)
                {
                    divisors.Add(i);
                    long pair = n / i;
                    divisors.Add(n / i);
                }
            }
            divisors = divisors.Distinct().ToList();
            divisors.Sort();
            return divisors;
        }


        /// <summary>
        /// Return whether or not a string is palindromic
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsPalindrome(string s)
        {
            int limit = s.Length / 2;
            for (int i = 0; i < limit; i++)
            {
                if (s[i] != s[s.Length - 1 - i]) { return false; }
            }
            return true;
        }

        /// <summary>
        /// Return whether or not a number is palindromic
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPalindrome(long n)
        {            
            return IsPalindrome(n.ToString());
        }

        /// <summary>
        /// Return a sequence of triangular numbers
        /// </summary>
        /// <param name="upTo"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Return a sequence of hexagonal numbers
        /// </summary>
        /// <param name="upTo"></param>
        /// <returns></returns>
        public static IEnumerable<long> Hexagonals(long upTo = 0)
        {
            long n = 1;
            // H_n=n(2n-1)
            long term = 1;
            while (term <= upTo || upTo <= 0)
            {
                yield return term;
                n++;
                term = 2 * n * n - n;
            }

        }

        /// <summary>
        /// Calculates the numbers of divisors a number has
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a Collatz sequence-chain for a number
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a set of permutations (lexicocgraphically ordered) for the given 
        /// set of elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="startSet"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Permutations<T>(IEnumerable<T> startSet) where T : IComparable
        {
            List<List<T>> sets = new List<List<T>>();
            List<T> prev = startSet.ToList();
            prev.Sort();
            sets.Add(prev);
            while (true)
            {
                IEnumerable<T> next = LexicographicPermutation(prev);
                if (next != null)
                {
                    List<T> n = next.ToList();
                    sets.Add(n);
                    prev = n;
                }
                else
                {
                    break;
                }
            }
            return sets;
        }

        public static IEnumerable<T> LexicographicPermutation<T>(IEnumerable<T> previous) where T : IComparable
        {
            // http://en.wikipedia.org/wiki/Permutation#Generation_in_lexicographic_order
            int k = -1;
            // Find the largest index k such that a[k] < a[k + 1]. 
            // If no such index exists, the permutation is the last permutation.
            for (int i = previous.Count() - 2; i >= 0; i--)
            {
                T ak, akPlusOne;
                ak = previous.ElementAt(i);
                akPlusOne = previous.ElementAt(i + 1);
                if (ak.CompareTo(akPlusOne) < 0)
                {
                    k = i;
                    break;
                }
            }
            if (k == -1) { return null; }

            // Find the largest index l such that a[k] < a[l]. 
            // Since k + 1 is such an index, l is well defined and satisfies k < l.
            int l = k + 1;
            T ak_ = previous.ElementAt(k);
            for (int i = previous.Count() - 1; i > k; i--)
            {
                T al = previous.ElementAt(i);
                if (ak_.CompareTo(al) < 0)
                {
                    l = i;
                    break;
                }
            }

            //Swap a[k] with a[l].
            // we'll drop down to a list now for convenience
            List<T> list = previous.ToList();
            list[k] = previous.ElementAt(l);
            list[l] = previous.ElementAt(k);

            // Reverse the sequence from a[k + 1] up to and including the final element a[n].

            int lowerBound = k + 1;
            int upperBound = list.Count();
            int limit = lowerBound + (upperBound - lowerBound) / 2;
            for (int i = lowerBound; i < limit; i++)
            {
                int oppositeIndex = upperBound - 1 - (i - lowerBound);
                T temp = list[i];
                list[i] = list[oppositeIndex];
                list[oppositeIndex] = temp;
            }
            return list;
        }

        /// <summary>
        /// Returns fibonacci terms indefinitely
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<long> Fibonacci()
        {
            long a = 1, b = 1, t;
            yield return a;
            yield return b;

            while (true)
            {
                t = a + b;
                a = b;
                b = t;
                yield return b;
            }
            
        }

        public static long ModPow(long number, long exponent, long mod)
        {
            long product = 1;
            for (long i = 0; i < exponent; i++)
            {
                product *= number;
                product = product % mod;
            }
            return product;
        }


        /// <summary>
        /// Greatest common divisor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static long gcd(long a, long b)
        {
            //euclid's algorithm
            long t;
            while (b != 0)
            {
                t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        /// <summary>
        /// Converts a positive integer to a binary string
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string ToBinary(long n)
        {
            string s = "";
            do
            {
                string mod = (n % 2).ToString();
                s = mod + s;
                n = n >> 1;
            } while (n > 0);
            return s;
        }


        /// <summary>
        /// Determine whether the given number is a triangle number, i.e.
        /// numbers calculated by t_n = 1/2 * n * (n + 1)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsTriangle(long t)
        {
            // t = 1/2 * n(n+1)
            // and thus we have a quadratic:
            // 0 = (1/2n**2) + 1/2n - t
            // so if the determinant b**2 - 4ac is greater than or equal to zero we have
            // real solutions, but we only care about integer solutions

            double determinant = 0.25 - 2 * (-1) * t;
            if (determinant < 0) return false;
            double x1, x2;
            x1 = (-0.5 + Math.Sqrt(determinant));
            x2 = (-0.5 - Math.Sqrt(determinant));
            return (x1 % 1 == 0 && x1 >= 0 || x2 % 1 == 0 && x2 >= 0);
        }

        /// <summary>
        /// Determine whether a number is a pentagonal number, i.e.
        /// p_n =  n(3n-1)/2
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool IsPentagonal(long p)
        {
            // n(3n-1)/2
            // (3n**2 - n)/2
            // => 1.5n**2 - 0.5n - p = 0
            double d = 0.25 - 4 * 1.5 * (-1) * p;
            if (d < 0) return false;
            double x1, x2;
            x1 = (+0.5 + Math.Sqrt(d))/3;
            x2 = (+0.5 - Math.Sqrt(d))/3;
            return (x1 % 1 == 0 && x1 >= 0 || x2 % 1 == 0 && x2 >= 0);
        }

        /// <summary>
        /// Returns whether a number is square, i.e. n = x*x where x is an integer
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsSquare(long n)
        {
            // is there a fsater way to do this than relying
            // on an expensive sqrt?
            return Math.Sqrt(n) % 1 == 0;
        }
    }
}
