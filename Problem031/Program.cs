using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Problem031
{
    class Problem031
    {
        static List<int> denominations = new List<int>() {
                1, 2, 5, 10, 20, 50, 100, 200
            };

        static void Main(string[] args)
        {
            int[] combinations = new int[201];
            combinations[0] = 1;
            foreach (int coin in denominations)
            {
                for (int i = coin; i <= 200; i++)
                {
                    combinations[i] += combinations[i - coin];
                }
            }
            Euler.Utils.OutputAnswer( combinations[200].ToString() );
        }
    }
}
