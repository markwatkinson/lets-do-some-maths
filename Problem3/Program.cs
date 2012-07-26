using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<long> factors = Euler.Utils.PrimeFactors(600851475143);
            Console.WriteLine(factors.Last());
            Console.ReadLine();
        }
    }
}
