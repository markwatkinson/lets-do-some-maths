using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem052
{
    class Program
    {
        static bool IsPermutation(long n1, long n2)
        {
            string s1 = n1.ToString(), s2 = n2.ToString();
            if (s1.Length != s2.Length) { return false; }

            foreach (char c in s1)
            {
                if (s1.Count(x => c == x) != s2.Count(x => c == x))
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            List<int> l;
            for (int i = 10; ; i++)
            {
                l = new List<int>() {
                    i*2, i*3, i*4, i*5, i*6
                };

                IEnumerable<int> match = l.Where(x => IsPermutation(x, i));

                if (match.Count() == l.Count())
                {
                    Euler.Utils.OutputAnswer(i.ToString());
                    break;
                }


            }
        }
    }
}
