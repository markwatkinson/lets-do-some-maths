using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public class Fraction
    {
        public long numerator {get; set;}
        public long denominator { get; set; }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction()
            {
                numerator = a.numerator * b.numerator,
                denominator = a.denominator * b.denominator
            };
        }

        public void Simplify()
        {
            long gcd;
            do {
                gcd = Euler.Utils.gcd(numerator, denominator);
                numerator /= gcd;
                denominator /= gcd;
            } while(gcd != 1);
        }
    }
}
