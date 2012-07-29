using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler;
namespace Problem023
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 28123; // given to us by the Q
            List<int> abundants = new List<int>();
            for (int i = 2; i <= limit; i++)
            {
                if (Utils.Divisors(i).Sum() > i)
                {
                    abundants.Add(i);
                }
            }

            int[] numbers = new int[limit + 1];
            for (int i = 0; i <= limit; i++)
            {
                numbers[i] = i;
            }
            int c = abundants.Count();
            for (int i = 0; i < c; i++)
            {
                int a = abundants[i];
                for (int j = i; j < c; j++) {
                    int b = abundants[j];
                    int sum = a + b;
                    if (sum >= numbers.Count()) break;
                    numbers[sum] = 0;
                }
            }
            Euler.Utils.OutputAnswer(numbers.Sum().ToString());

        }
    }
}
