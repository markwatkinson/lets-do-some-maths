using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler
{
    public class Fraction
    {
        public BigInteger numerator {get; set;}
        public BigInteger denominator { get; set; }


        public Fraction(BigInteger? numerator_ = null, BigInteger? denominator_ = null)
        {
            numerator = numerator_ ?? new BigInteger(1);
            denominator = denominator_ ?? new BigInteger(1);
        }

        public Fraction(long? numerator_ = null, long? denominator_ = null) {
            numerator = new BigInteger(numerator_ ?? 1);
            denominator = new BigInteger(denominator_?? 1);
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.numerator == b.numerator &&
                a.denominator == b.denominator;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return a.numerator != b.numerator ||
                a.denominator != b.denominator;
        }


        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            BigInteger denom = a.denominator;
            BigInteger n1 = a.numerator, n2 = b.numerator;
            if (denom != b.denominator)
            {
                denom = a.denominator * b.denominator;
                n1 = checked(n1 * b.denominator);
                n2 = checked(n2 * a.denominator);
            }


            Fraction ret = new Fraction(n1 + n2, denom);
            ret.Simplify();
            return ret;
        }

        public static Fraction operator +(int a, Fraction b)
        {
            return new Fraction(a) + b;
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            return a * b.Reciprocal();
        }
        public static Fraction operator /(int a, Fraction b)
        {
            return new Fraction(a) / b;
        }

        public Fraction Reciprocal()
        {
            return new Fraction(denominator, numerator);
        }

        public void Simplify()
        {
            BigInteger gcd;
            do {
                gcd = Euler.Utils.gcd(numerator, denominator);
                numerator /= gcd;
                denominator /= gcd;
            } while(gcd != 1);
        }

        public override String ToString()
        {
            return String.Format("{0}/{1}", numerator.ToString(), denominator.ToString());
        }
    }
}
