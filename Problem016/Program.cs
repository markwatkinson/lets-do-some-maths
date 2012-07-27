using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
namespace Problem016
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger b = BigInteger.Pow(2, 1000);
            
            IEnumerable<int> digits = b.ToString().Select(c => Convert.ToInt32(c.ToString()));
            long sum = digits.Sum();
            Euler.Utils.OutputAnswer(sum.ToString());
            
        }
    }
}
