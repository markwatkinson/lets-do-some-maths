using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem028
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 1001;
            // instead of generating the whole grid, just generate the
            // diagonals
            long sum = 1;
            long lower = 1;
            // we increment by 2 because you can't have an even number in the
            // spiral - it centers around 1
            // 1 is a special case, so start at 3
            for (int i = 3; i <= limit; i+=2)
            {
                long upper = i * i;
                long a, b, c, d;
                long range = upper - lower;
                a = lower + range / 4;
                b = lower + range / 2;
                c = lower + 3 * (range / 4);
                d = upper;

                sum += (a + b + c + d);

                lower = upper;
            }
            Euler.Utils.OutputAnswer(sum.ToString());
        }
    }
}
