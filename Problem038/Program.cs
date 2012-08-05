using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem038
{
    class Program
    {

        static bool IsPandigital(string s)
        {
            if (s.Length != 9) return false;
            for (int i = 1; i <= 9; i++)
            {
                if (s.IndexOf(i.ToString()) < 0) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            // we can guess that the number will begin with a 9, because that places us in the
            // 9xxxxxxxx range.
            // Also, since n > 1, we can say that our number must be 8 or fewer digits
            // So our search ranges look something like:
            // 9-9
            // 90-99
            // 900-999
            // etc
            long product = 0;
            int magnitude = 0;
            int i = 9;
            while (i < 99999999) {
                int lowerI = 9 * System.Convert.ToInt32( Math.Pow(10, magnitude));
                int upperI = System.Convert.ToInt32(Math.Pow(10, magnitude+1));
                magnitude++;
                Console.WriteLine("{0}-{1}", lowerI, upperI);
                for (i = lowerI; i < upperI; i++)
                {
                    string s = "";
                    for (int j = 1; j <= 9; j++)
                    {
                        s += (i * j);
                        if (s.Length == 9)
                        {
                            if (!IsPandigital(s)) { break; }
                            else if (j > 1)
                                product = Math.Max(product, System.Convert.ToInt64(s));
                        }
                        else if (s.Length > 9)
                        {
                            break;
                        }
                    }
                }
            }
            Euler.Utils.OutputAnswer(product.ToString());
        }
    }
}
