using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem14
{
    class Program
    {
        static void Main(string[] args)
        {
            int chainLength = 0;
            long number = 0;
            for (long i = 1; i < 1000000; i++)
            {
                int l = Euler.Utils.Collatz(i).Count();
                if (l > chainLength)
                {
                    chainLength = l;
                    number = i;
                }
            }
            Euler.Utils.OutputAnswer(number.ToString());
        }
    }
}
