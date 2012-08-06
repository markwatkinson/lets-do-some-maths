using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem048
{
    class Program
    {
        static void Main(string[] args)
        {
            // find the last 10 digits of the sum
            // x^x , 1 >= x >= 1000

            // We can do something clever here with modulo arithmetic - we only care about the last
            // 10 digits so we can calculate all our powers mod 10**10 (much faster)
            // then we can sum them, and mod them again and hey presto

            long mod = 10000000000;
            IEnumerable<int> powers = Enumerable.Range(1, 1000).ToList();
            IEnumerable<long> series = powers.Select(x => Euler.Utils.ModPow(x, x, mod));

            Euler.Utils.OutputAnswer((series.Sum() % mod).ToString());

        }
    }
}
