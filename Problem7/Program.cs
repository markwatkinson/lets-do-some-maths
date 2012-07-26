using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem7
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            long i = 1;
            while(count < 10001) {
                i++;
                if (Euler.Utils.IsPrime(i)) count++;
            }
            Euler.Utils.OutputAnswer(i.ToString());
        }
    }
}
