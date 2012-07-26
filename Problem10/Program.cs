using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem10
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<long> primes = Euler.Utils.GeneratePrimes(2000000);
            Euler.Utils.OutputAnswer(primes.Sum().ToString());
        }
    }
}
