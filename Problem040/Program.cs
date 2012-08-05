using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem040
{
    class Program
    {
        static void Main(string[] args)
        {
            // this is pretty slow but still within 1 minute
            string s = "";
            long i = 1;
            while (s.Length < 1000000) {
                s += i.ToString();
                i++;
            }
            int product = 1;
            for (i = 0; i <= 6; i++)
            {
                int index = System.Convert.ToInt32(Math.Pow(10, i)) - 1;
                product *= System.Convert.ToInt32("" + s[index]);
            }
            Euler.Utils.OutputAnswer(product.ToString());

        }
    }
}
