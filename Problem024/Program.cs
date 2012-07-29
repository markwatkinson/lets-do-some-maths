using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem024
{
    class Problem024
    {
        static void Main(string[] args)
        {
            
            IEnumerable<Int32> list = new List<Int32> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // start at 1 because the initial state is the first permutation
            for (int i = 1; i != 1000000; i++)
            {
                list = Euler.Utils.LexicographicPermutation(list);
            }
            string output = string.Join("", list);
            Euler.Utils.OutputAnswer(output);
        }
    }
}
