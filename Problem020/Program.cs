using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Problem020
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger b = new BigInteger(100);
            for (int i = 99; i >= 2; i--)
            {
                b *= i;
            }

            IEnumerable<int> digits = b.ToString().Select(x => Convert.ToInt32(x.ToString()));
            long sum = digits.Sum();

            Euler.Utils.OutputAnswer(sum.ToString());
        }
    }
}
