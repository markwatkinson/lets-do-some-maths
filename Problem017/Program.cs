using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem017
{
    class Program
    {
        static string[] ones_ = new string[] {
                "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen",
                "nineteen"
            };
        static string[] tens_ = new string[] {
                "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
            };


        static string Format(int num)
        {
            string s = "";
            if (num <= 0)
            {
                s = "";
            }
            else if (num == 1000) {
                // special case, no point handling this cleverly
                s = "One thousand";
            }
            else if (num >= 100) {
                int hundreds, remainder;
                hundreds = num / 100;
                remainder = num % 100;
                s = ones_[hundreds - 1] + " hundred ";
                if (remainder > 0)
                {
                    s += " and ";
                    s += Format(remainder);
                }
            }
            else if (num >= 20)
            {
                int unit = num / 10, remainder = num % 10;
                s = tens_[unit - 2];
                if (remainder > 0)
                {
                    s += " " + Format(remainder);
                }
            }
            else if (num < 20)
            {
                s = ones_[num - 1];
            }
            return s;
                
        }




        static void Main(string[] args)
        {
            List<string> strings = new List<string>();
            for (int i = 1; i <= 1000; i++)
            {
                strings.Add(Format(i));
            }

            long count = 0;
            foreach (string s in strings)
            {
                string s2 = s.Replace(" ", "");
                count += s2.Length;
            }
            Euler.Utils.OutputAnswer(count.ToString());
            
            
        }
    }
}
