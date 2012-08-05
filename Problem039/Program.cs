using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem039
{
    class Program
    {
        /*
If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.

{20,48,52}, {24,45,51}, {30,40,50}

For which value of p <= 1000, is the number of solutions maximised?
         * 
         * Assuming that we are looking for integer solutions...
         */



        static void Main(string[] args)
        {
             // I don't see a smart way to do this so let's just brute force it, 
            // shouldn't take long if we just pre-generate all solutions instead of
            // doing it forwards
            // remember c > b >= a
            int a, b, c;

            int[] solutions = new int[1001];
            for (int i = 0; i < 1001; i++) { solutions[i] = 0; }

            for (c = 1; c < 1000; c++) {
                for (a = 1; a < c; a++)
                {
                    for (b = a; b < c; b++)
                    {
                        int p = a + b + c;
                        if (p > 1000) { break; }
                        bool pythagorean = a * a + b * b == c * c;
                        if (pythagorean)
                        {
                            solutions[p] += 1;
                        }
                    }
                }
            }

            int max = 0, index = 0;
            for (int i = 0; i < 1001; i++)
            {
                if (solutions[i] > max)
                {
                    max = solutions[i];
                    index = i;
                }
            }
            Euler.Utils.OutputAnswer(index.ToString());
        }
    }
}
