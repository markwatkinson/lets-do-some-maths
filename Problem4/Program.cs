using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem4
{
    class Program
    {
        static void Main(string[] args)
        {
            int candidate = 0;
            for (int i = 999; i > 0; i--)
            {
                for (int j = i; j > 0; j--)
                {
                    int product = j * i;
                    if (Euler.Utils.IsPalindrome(product) && product > candidate)
                    {
                        candidate = product;
                    }
                }
            }
            Euler.Utils.OutputAnwser(candidate.ToString());

        }
    }
}
