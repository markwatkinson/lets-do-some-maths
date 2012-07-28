using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem021
{
    class Problem021
    {
        static void Main(string[] args)
        {
            int limit = 10000;
            long[] sumOfDivisors = new long[limit];

            for (int i = 1; i < limit; i++)
            {
                sumOfDivisors[i] = Euler.Utils.Divisors(i).Sum();
            }
            long sum = 0;
            for (int a = 1; a < limit; a++)
            {
                long d_a = sumOfDivisors[a];
                for (int b = a + 1; b < limit; b++)
                {
                    long d_b = sumOfDivisors[b];

                    bool areAmicable = d_b == a && d_a == b;
                    if (areAmicable)
                    {
                        sum += (a + b);
                    }
                }
            }
            Euler.Utils.OutputAnswer(sum.ToString());
        }
    }
}
