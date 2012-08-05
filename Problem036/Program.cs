using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem036
{
    class Program
    {
        static void Main(string[] args)
        {
            long sum = 0;
            for (long i = 0; i < 1000000; i++)
            {
                string bString = Euler.Utils.ToBinary(i);
                bool p  = Euler.Utils.IsPalindrome(i);
                p = p && Euler.Utils.IsPalindrome(bString);

                if (p)
                {
                    sum += i;
                }
            }
            Euler.Utils.OutputAnswer(sum.ToString());
        }
    }
}
