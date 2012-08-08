using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler;
using System.Numerics;

namespace Problem057
{
    class Program
    {
        Fraction prev = new Fraction(2);

        Fraction Expand(long n)
        {
            // we're going to cache the previous one otherwise, with the
            // raw fractional numbers getting massive, the arithmetic takes
            // forever
            if (n > 1)
            {
                prev = 2 + prev;
            }
            prev = 1 / prev;
            return 1 + prev;
        }
        static void Main(string[] args)
        {
            Program p = new Program();

            int c = 0;
            for (int i = 1; i <= 1000; i++)
            {
                Fraction f = p.Expand(i);
                f.Simplify();
                
                if (f.numerator.ToString().Length > f.denominator.ToString().Length)
                {
                   
                    c++;
                }
            }
            Utils.OutputAnswer(c.ToString());
        }
    }
}
