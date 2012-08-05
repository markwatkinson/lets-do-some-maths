using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Problem042
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string raw;
            using (StreamReader tr = new StreamReader("words.txt")) {
                raw = tr.ReadToEnd();
            }
            // obviously this won't work if any fields contain a comma
            // but they don't, so it will.
            string[] fields = raw.Split(',');
            foreach (string f in fields)
            {
                // trim the quotes
                string s = f.Substring(1, f.Length - 2);
                List<int> vals = s.Select(c => c - 'A' + 1).ToList();
                int value = vals.Sum();
                if (Euler.Utils.IsTriangle(value))
                {
                    counter++;
                }
            }
            Euler.Utils.OutputAnswer(counter.ToString());
        }
    }
}
