using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day6
    {
        string[] input;

        public Day6(string[] input)
        {
            this.input = input;
        }

        public string Part1()
        {
            return FindMostPopular(true);
        }

        public string Part2()
        {
            return FindMostPopular(false);
        }

        private string FindMostPopular(bool desc)
        {
            var columns = LinesToColumns();

            string ans = "";

            foreach (var str in columns)
            {
                var query = str.GroupBy(a => a).OrderByDescending(g => g.Count()).Select(g => g.Key);
                ans += desc ? query.First().ToString() : query.Last().ToString();
            }

            return ans;
        }

        private string[] LinesToColumns()
        {
            string[] columns = new string[input[0].Length];
            for (int r = 0; r < input.Length; r++)
            {
                for (int c = 0; c < input[r].Length; c++)
                {
                    columns[c] += input[r][c] + "";
                }
            }

            return columns;
        }
    }
}
