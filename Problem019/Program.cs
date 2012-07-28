using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem019
{
    class Problem019
    {

        private static int[] _daysInMonth = new int[] {
            31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
        };

        /// <summary>
        /// Returns whether the given day (as an offset from 1st Jan 1901)
        /// is a sunday
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        private static bool IsSunday(long day)
        {
            return day % 7 == 5;
        }

        private static bool IsLeapYear(int year)
        {
            if (year % 400 == 0) return true;
            else if (year % 100 == 0) return false;
            else if (year % 4 == 0) return true;
            else return false;
        }

        /// <summary>
        /// Returns number of days in a given month
        /// </summary>
        /// <param name="month">zero indexed - e.g. jan == 0, dec == 11</param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static int DaysInMonth(int month, int year)
        {
            if (month == 1 && IsLeapYear(year))
            {
                // this is the only special case - feb/leap years
                return 29;
            }
            else return _daysInMonth[month];
        }

        static void Main(string[] args)
        {
            int year = 1901;
            int month = 0;
            long numDays = 0;
            long sundayCount = 0;

            while (year <= 2000)
            {

                if (IsSunday(numDays))
                {
                    sundayCount++;
                    Console.WriteLine("1st {0} {1} was a leap year", month, year);
                }
                numDays += DaysInMonth(month, year);
                month++;
                if (month == 12)
                {
                    year++;
                    month = 0;
                }
            }
            Euler.Utils.OutputAnswer(sundayCount.ToString());
        }
    }
}
