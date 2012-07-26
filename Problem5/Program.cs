using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem5
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = 0, i;
            bool found = false;
            while (!found)
            {
                found = true;
                n += 20;
                for (i = 20; i > 1 && found; i--)
                {
                    found = (n % i == 0);
                }
            }
            Euler.Utils.OutputAnswer(n.ToString());
        }
    }
}
