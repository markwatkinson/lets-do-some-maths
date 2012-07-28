using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Problem022
{
    class Program
    {
        static void Main(string[] args)
        {
            TextReader tr = new StreamReader("names.txt");
            string data = tr.ReadToEnd();
            tr.Close();

            // nice and legible - gets quotes and respects backslash escaping
            Regex pattern = new Regex("\"(([^\"\\\\]+|\\\\.)*)\"");
            MatchCollection matches = pattern.Matches(data);
            var names = new List<string>();
            foreach (Match match in matches)
            {
                string value = match.Groups[1].Value;
                names.Add(value);
            }
            names.Sort();
            var values = new List<int>();

            foreach (string name in names)
            {
                IEnumerable<int> nameValues = name.ToUpper().ToCharArray().Select(c => c - 'A' + 1);
                int sum = nameValues.Sum();
                values.Add(sum);
            }

            long total = 0;
            for (int i = 0; i < values.Count(); i++)
            {
                total += (i + 1) * values[i];
                if (i == 937)
                {
                    int x;
                }
            }
            Euler.Utils.OutputAnswer(total.ToString());

        }
    }
}
