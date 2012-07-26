using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem9
{
    class Program
    {
        static void Main(string[] args)
        {
            // can optimise this by checking for a+b+c>1000 but I don't think there's
            // any need to
            for (int a = 0; a < 1000; a++)
            {
                for (int b = a+1; b < 1000; b++)
                {
                    for (int c = b+1; c < 1000; c++)
                    {
                        int sum = a + b + c;
                        bool isTriplet = a * a + b * b == c * c;
                        if (sum == 1000 && isTriplet)
                        {
                            Euler.Utils.OutputAnswer((a * b * c).ToString());
                            return;
                        }
                    }
                }
            }
        }
    }
}
