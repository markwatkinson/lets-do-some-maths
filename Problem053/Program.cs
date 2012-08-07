using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Problem053
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            for (int n = 1; n <= 100; n++)
            {
                for (int r = 1; r <= n; r++)
                {
                    BigInteger c = Euler.Utils.Choose(n, r);
                    if (c > 1000000)
                        count++;
                }
            }
            Euler.Utils.OutputAnswer(count.ToString());
        }
    }
}
