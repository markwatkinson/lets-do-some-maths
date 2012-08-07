using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Problem055
{
    class Program
    {
        static int LychrelIterations(BigInteger n, int t=0)
        {
            if (t > 50) {
                return t;
            }
            if (t > 0 && Euler.Utils.IsPalindrome(n.ToString()))
            {
                return t;
            }
            char[] s_ = n.ToString().ToCharArray();
            Array.Reverse(s_);
            string s = new String(s_);
            BigInteger n2;
            BigInteger.TryParse(s, out n2);
            n += n2;
            t++;
            return LychrelIterations(n, t);
        }
        static void Main(string[] args)
        {
            
            var seq = Enumerable.Range(0, 10000);
            var iterations = seq.Select(i => LychrelIterations(i));
            Euler.Utils.OutputAnswer(iterations.Count(i => i >= 50).ToString());

        }
    }
}
