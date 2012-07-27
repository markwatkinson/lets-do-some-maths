using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem012
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (long n in Euler.Utils.Triangles())
            {
                long numDivisors = Euler.Utils.NumDivisors(n);
                if (numDivisors > 500)
                {
                    Euler.Utils.OutputAnswer(n.ToString());
                    return;
                }
            }

        }
    }
}
