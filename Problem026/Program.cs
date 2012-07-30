using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem026
{
    class Program
    {
        static int CycleLength(int denominator)
        {
            // http://mathworld.wolfram.com/DecimalExpansion.html
            // 10^s == 10^(s+t) % denominator
            // solve for t 

            var cycles = new List<long>();
            int i = 0, s, t;
            long x;
            while (true) {
                // we could do modular powers but i don't think we need to
                x = Euler.Utils.ModPow(10, i, denominator);
                if (cycles.Contains(x))
                {
                    s = cycles.IndexOf(x);
                    t = i - s;
                    break;
                }
                cycles.Add(x);
                i++;
            }
            return t;

        }
        static void Main(string[] args)
        {
            var cycles = Enumerable.Range(1, 1000).Select(x => CycleLength(x)).ToList();
            int max = cycles.Max();
            int index = cycles.IndexOf(max);
            Euler.Utils.OutputAnswer((index + 1).ToString());
        }
    }
}
