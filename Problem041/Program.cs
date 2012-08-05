using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem041
{
    class Program
    {
        static void Main(string[] args)
        {
            // What is the largest n-digit pandigital prime that exists?
            // this is really easy drawing on our permutation function for
            // the heavy lifting
            int n = 9;
            while (n > 1) {

                List<int> numbers = Enumerable.Range(1, n).ToList();

                var permutations = new List<long>();

                while (true)
                {
                    string s = String.Join("", numbers);
                    permutations.Add(System.Convert.ToInt64(s));
                    IEnumerable<int> numbersE = Euler.Utils.LexicographicPermutation(numbers);
                    if (numbersE == null) break;
                    numbers = numbersE.ToList();
                }

                permutations.Sort();
                permutations.Reverse();
                foreach (long p in permutations)
                {
                    if (Euler.Utils.IsPrime(p)) {
                        Euler.Utils.OutputAnswer(p.ToString());
                        System.Environment.Exit(0);
                    }
                }
                n--;
            }
           

        }
    }
}
