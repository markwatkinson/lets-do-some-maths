using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem032
{
    class Program
    {
        static Boolean Pandigital(int n)
        {
            string s = n.ToString();
            for (int i = 1; i <= s.Length; i++)
            {
                if (!s.Contains("" + i)) { return false; }
            }
            return true;
        }
        static void Main(string[] args)
        {
            double limit = Math.Ceiling(Math.Sqrt(999999999));
            var products = new List<long>();
            for (int a = 1; a < limit; a++)
            {
                for (int b = 1; b < limit; b++)
                {
                    long product = a * b;
                    string abc = "" + a + b + product;

                    if (abc.Length > 9) { 
                        break;
                    }
                    if (abc.Length == 9 && Pandigital(System.Convert.ToInt32(abc)))
                    {
                        products.Add(product);
                        Console.WriteLine(abc);
                    }
                }
            }

            products = products.Distinct().ToList();
            Euler.Utils.OutputAnswer(products.Sum().ToString());
        }
    }
}
