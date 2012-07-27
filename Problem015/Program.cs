using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem015
{
    class Grid
    {
        private int width;
        private int height;

        public long[,] cache;

        public Grid(int w, int h)
        {
            cache = new long[w+1, h+1];
            width = w;
            height = h;
            for (int i = 0; i < w+1; i++)
            {
                for (int j = 0; j < h+1; j++)
                {
                    cache[i, j] = -1;
                }
            }
        }

        public long Routes(int x, int y)
        {
            if (x == 0 && y == 0) return 0;
            else if (x == 0) return 1;
            else if (y == 0) return 1;
            long routes = cache[x, y];
            if (routes < 0)
            {
                routes = Routes(x - 1, y) + Routes(x, y - 1);
                cache[x, y] = routes;
            }
            return routes;
        }
        public long Routes()
        {
            return Routes(width, height);
        }

        static void Main(string[] args)
        {
            Grid g = new Grid(20, 20);
            long output = g.Routes();
            Euler.Utils.OutputAnswer(output.ToString());
        }
    }
}
