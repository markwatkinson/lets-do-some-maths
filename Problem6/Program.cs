using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem6
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<long> range = Euler.Utils.Range(1, 101);
            IEnumerable<long> squares = range.Select(a => a * a);

            long sumOfSquares = squares.Sum();
            long sum = range.Sum();
            long squareOfSum = sum * sum;
            Euler.Utils.OutputAnswer(Math.Abs(sumOfSquares - squareOfSum).ToString());


        }
    }
}
