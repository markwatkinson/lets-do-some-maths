using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem035
{
    class Program
    {
        static int Rotate(int n)
        {
            var s = n.ToString();
            s = s.Substring(1) + s[0];
            return System.Convert.ToInt32(s);
        }

        static IEnumerable<int> Rotations(int n)
        {
            int num = n.ToString().Length;
            for (int i = 0; i < num; i++)
            {
                yield return n;
                n = Rotate(n);
            }
        }

        static bool IsCircularPrime(int n)
        {
            // 0 messes everything up, like 101 => 11, which is prime, but not
            // circular
            if (n.ToString().Contains('0')) return false;
            List<int> rotations = Rotations(n).ToList();
            List<bool> primes = rotations.Select(x => Euler.Utils.IsPrime(x)).ToList();
            return primes.IndexOf(false) == -1;
        }

        static void Main(string[] args)
        {
            var circulars = new List<int>() {2};

            for (int i = 3; i < 1000000; i += 2)
            {
                if (IsCircularPrime(i))
                {
                    circulars.Add(i);
                }
            }
            
            Euler.Utils.OutputAnswer(circulars.Count().ToString());
        }
    }
}
