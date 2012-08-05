using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem037
{
    class Program
    {

        static void Main(string[] args)
        {
            long i = 11;

            int found = 0;
            long sum = 0;
            while (found != 11)
            {
                // truncate both directions at once
                bool p = Euler.Utils.IsPrime(i);
                string s = i.ToString();
                string sLtr = i.ToString();
                string sRtl = i.ToString();
                int len = sLtr.Length;
                for (int j = 1; j < len && p; j++)
                {
                    sLtr = s.Substring(j);
                    sRtl = s.Substring(0, len - j);
                    
                    p = Euler.Utils.IsPrime(System.Convert.ToInt64(sLtr)) &&
                           Euler.Utils.IsPrime(System.Convert.ToInt64(sRtl));
                }
                if (p)
                {
                    Console.WriteLine("{0} is truncatable", i.ToString());
                    sum += i;
                    found++;
                }

                i += 2;
            }
            Euler.Utils.OutputAnswer(sum.ToString());
        }
    }
}
