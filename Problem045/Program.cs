using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem045
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            long term = 0;

            // Hexagonals are sparser so iterate over them instead of the others
            foreach (long num in Euler.Utils.Hexagonals())
            {
                n++;
                if (n <= 285) { continue; }
                // I think that all triangles are also hexagonal so whatever
                if (Euler.Utils.IsPentagonal(num) && Euler.Utils.IsTriangle(num))
                {
                    term = num;
                    break;
                }
            }

            Euler.Utils.OutputAnswer(term.ToString());
        }
    }
}
