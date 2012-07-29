using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
namespace Problem025
{
    class Problem025
    {
        static void Main(string[] args)
        {
            // index (1-based) of the first term in the fibonacci
            // sequence to have over 1000 digits.
            // Easy enough with big integers

            BigInteger a = new BigInteger(1),
                b = new BigInteger(1),
                c;

            long term = 2;
            while (b.ToString().Length != 1000)
            {
                c = a + b;
                a = b;
                b = c;
                term++;
            }
            Euler.Utils.OutputAnswer(term.ToString());

        }
    }
}
