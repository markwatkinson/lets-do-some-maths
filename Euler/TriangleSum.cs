using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Euler
{
    /**
     * As used by problem 18 and 67 
     */
    public class TriangleSum
    {
        private List<List<int>> triangle;

        public TriangleSum(string s = null)
        {
            if (s != null)
            {
                Set(s);
            }
        }

        /**
         * Set the triangle from a string. Rows are delimited by newline characters and
         * individual numbers by spaces
         */
        public void Set(string s)
        {
            triangle = new List<List<int>>();
            string[] lines = s.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                var row = Regex.Split(line, "[^0-9]+").Select(x => Convert.ToInt32(x)).ToList();
                triangle.Add(row);
            }
        }

        public long calculateMaxRoute()
        {
            // the basic idea is we build a second triangle which has as its
            // elements the maximum value of the route to that point. This 
            // means we can see the maximum route without having to brute
            // force all possible routes.

            var routes = new List<List<long>>();

            for (int i=0; i< triangle.Count(); i++) {
                List<int> tRow = triangle.ElementAt(i);
                List<long> rRow = new List<long>();

                for (int j = 0; j < tRow.Count(); j++)
                {
                    int tElement = tRow.ElementAt(j);
                    int count = tRow.Count();
                    // with the way the triangle is structured in memory, we can look at the 
                    // previous row, specifically the elements in j-1 and j
                    long max = tElement, route1 = -1, route2 = -1;
                    if (i > 0)
                    {
                        if (j < count - 1)
                        {
                            route1 = routes[i - 1][j];
                        }
                        if (j > 0)
                        {
                            route2 = routes[i - 1][j - 1];
                        }
                        max = tElement + Math.Max(route1, route2);
                    }
                    rRow.Add(max);
                }
                routes.Add(rRow);
            }
            return routes.Last().Max();
        }
    }
}
