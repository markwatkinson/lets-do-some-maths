using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem046
{
    class Program
    {
        static void Main(string[] args)
        {
            // for speed of generating primes, let's take an upper bound of a million
            // and hope for the best, this way we use a fast seive algorithm
            int limit = 1000000;
            IEnumerable<long> primes = Euler.Utils.GeneratePrimes(limit);
            List<long> squares = new List<long>();

            for (int i = 3; i < limit; i+=2)
            {
                if (Euler.Utils.IsPrime(i)) { continue; }
                bool found = false;
                foreach (long p in primes)
                {
                    if (p >= i) { break; }
                    long diff = i - p;
                    // odd number - can't be twice a square
                    if (diff % 2 == 1) { continue; }
                    if (Euler.Utils.IsSquare(diff/2))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Euler.Utils.OutputAnswer(i.ToString());
                    break;
                }
            }
        }
    }
}
