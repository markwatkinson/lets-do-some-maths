using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Problem029
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger pow;
            var results = new List<BigInteger>();

            for (int a = 2; a <= 100; a++)
            {
                for (int b = 2; b <= 100; b++)
                {
                    results.Add(
                        BigInteger.Pow(new BigInteger(a), b)
                    );
                }
            }
            Euler.Utils.OutputAnswer(results.Distinct().Count().ToString());
        }
    }
}
