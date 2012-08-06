using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem047
{
    class Program
    {
        static void Main(string[] args)
        {
            // first four consecutive integers to have 4 distinct prime factors
            // seems easy enough if we cache the last three and rotate them...

            int nMinus3 = 0,
                nMinus2 = 0,
                nMinus1 = 0,
                n = 0;

            for (long i = 1; ; i++)
            {
                nMinus3 = nMinus2;
                nMinus2 = nMinus1;
                nMinus1 = n;
                n = Euler.Utils.PrimeFactors(i).Distinct().Count();
                if (nMinus3 >= 4 && nMinus2 >= 4 && nMinus1 >= 4 && n >= 4)
                {
                    Euler.Utils.OutputAnswer((i - 3).ToString());
                    break;
                }
            }
        }
    }
}
