using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem043
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>() {
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9
            };

            IEnumerable<IEnumerable<int>> pandigitalSet = Euler.Utils.Permutations(numbers).ToList();
            List<long> pandigitals = new List<long>();
            foreach (IEnumerable<int> pandigital in pandigitalSet)
            {
                string p = string.Join("", pandigital);
                if (p[0] == '0') continue;
                pandigitals.Add(System.Convert.ToInt64(p));
            }
            int[] divisors = new int[9] {
                0, 0, 2, 3, 5, 7, 11, 13, 17
            };
            long sum = 0;
            foreach (long p in pandigitals)
            {
                string ps = p.ToString();
                bool valid = true;
                for (int i = 2; i <= 8 && valid; i++)
                {
                    string substring = ps.Substring(i-1, 3);
                    int divisor = divisors[i];
                    int substringI = System.Convert.ToInt32(substring);
                    valid = substringI % divisor == 0;
                }
                if (valid)
                {
                    sum += p;
                }
            }

            Euler.Utils.OutputAnswer(sum.ToString());
            
        }
    }
}
