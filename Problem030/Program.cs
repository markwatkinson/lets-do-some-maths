using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem030
{
    class Program
    {
        static IEnumerable<int> Digits(int n)
        {
            // cheating
            foreach (char s in n.ToString()) {
                yield return System.Convert.ToInt32("" + s);
            }
        }

        static void Main(string[] args)
        {
            // not really sure how to derive an upper limit, so
            // let's just go indefinitely and see what it throws
            // back
            ulong sum = 0;
            for (int i = 2; ; i++)
            {
                var digits = Digits(i).ToList();
                // explicit powering should be faster and avoids doubles
                var fithPowers = digits.Select(x => x * x * x * x * x );
                int sumOfFithPowers = fithPowers.Sum();
                if (sumOfFithPowers == i)
                {
                    sum += (ulong)sumOfFithPowers;
                    Console.WriteLine(sum);
                }
            }

        }
    }
}
