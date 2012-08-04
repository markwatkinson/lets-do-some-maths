using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler;

namespace Project033
{



    class Program
    {
        static Boolean Cancels(Fraction frac)
        {
            if (frac.numerator % 10 == 0 && frac.denominator % 10 == 0)
            {
                // trivial case, zeroes cancel
                return false;
            }

            double realFraction = frac.numerator / Convert.ToDouble(frac.denominator);
            string ns = frac.numerator.ToString(),
                   ds = frac.denominator.ToString();

            foreach (char c in ns)
            {
                int n = System.Convert.ToInt16("" + c);
                string n1 = ns.Replace("" + c, ""),
                       d1 = ds.Replace("" + c, "");
                if (n1.Length == 0 || d1.Length == 0) { continue; }
                int ni = System.Convert.ToInt32(n1),
                    di = System.Convert.ToInt32(d1);
                if (di == 0) { continue; }
                double f = ni / Convert.ToDouble(di);
                if (f == realFraction)
                {
                    return true;
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            Fraction product = new Fraction() { denominator = 1, numerator = 1 };
            for (int a = 10; a < 100; a++)
            {
                for (int b = a+1; b < 100; b++)
                {
                    Fraction f = new Fraction() { numerator = a, denominator = b };
                    if (Cancels(f))
                    {
                        product = product * f;
                    }
                }
            }
            product.Simplify();
            Euler.Utils.OutputAnswer(product.denominator.ToString());
                

        }
    }
}
