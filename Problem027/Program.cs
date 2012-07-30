using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem027
{
    class Problem027
    {
        // cache the primes
        Dictionary<long, bool> primes = new Dictionary<long, bool>();
        
        public bool IsPrime(long n)
        {
            if (primes.ContainsKey(n))
            {
                return primes[n];
            }
            else
            {
                bool p = Euler.Utils.IsPrime(n);
                primes[n] = p;
                return p;
            }
        }

        static long f(int n, int a, int b)
        {
            return n * n + a * n + b;
        }

        static void Main(string[] args)
        {
            Problem027 p = new Problem027();
            int limit = 999;
            int max = 0;
            int maxA = 0, maxB = 0;
            for (int a = -limit; a <= limit; a++)
            {
                for (int b = -limit; b <= limit; b++)
                {
                    int n = 0;
                    long term;
                    do
                    {
                        term = f(n, a, b);
                        n++;
                    } while (p.IsPrime(term));

                    if (n > max)
                    {
                        maxA = a;
                        maxB = b;
                        max = n;
                        Console.WriteLine("n^2 + {0}n + {1} => {2}", a, b, n);
                    }
                }
            }
            Euler.Utils.OutputAnswer((maxA * maxB).ToString());

        }
    }
}
