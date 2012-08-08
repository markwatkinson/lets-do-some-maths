using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Problem056
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int a = 1; a < 100; a++)
            {
                for (int b = 1; b < 100; b++)
                {
                    var val = BigInteger.Pow(a, b);
                    sum = Math.Max(sum,
                        val.ToString().Select(c => c - '0').Sum()
                    );
                }
            }
            Euler.Utils.OutputAnswer(sum.ToString());
        }
    }
}
