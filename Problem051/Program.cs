using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem051
{
    class Program
    {
        // this isn't really a permutation but I've no idea what to call it
        // see Q
        static IEnumerable<IEnumerable<long>> Permute(long n)
        {
            string s = n.ToString();
            // the q is unclear on whether we are limited to replacing
            // 2 digits or as many as we like
            // I'll assume 2 for now
            // edit: no small solutions for 2, let's try 3
            int len = s.Length;


            char[] repls = new char[10] {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };

            for (int i = 0; i < len; i++)
            {
                for (int j = i+1; j < len; j++)
                {
                    for (int k = j + 1; k < len; k++)
                    {
                        List<long> family = new List<long>();

                        foreach (char r in repls)
                        {
                            if (r == '0' && i == 0) { continue; }
                            char[] ca = s.ToCharArray();
                            ca[i] = r;
                            ca[j] = r;
                            ca[k] = r;
                            string s2 = String.Join("", ca);
                            family.Add(System.Convert.ToInt64(s2));

                        }
                        yield return family;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            long upperLimit = 9999999;

            var primes = Euler.Utils.GeneratePrimes(upperLimit);

            foreach(long p in primes)
            {
                IEnumerable<IEnumerable<long>> permutes = Permute(p);
                foreach(IEnumerable<long> family in permutes) {
                    IEnumerable<long> permutedPrimes = family.Distinct().Where(x => Euler.Utils.IsPrime(x));
                    if (permutedPrimes.Count() >= 8)
                    {
                        Euler.Utils.OutputAnswer(family.Min().ToString());
                        System.Environment.Exit(0);
                    }                    
                }
            }
            Console.WriteLine("No solutions");
            Console.ReadLine();
        }
    }
}
