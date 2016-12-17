using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day6
    {
        public void Part1(string[] input)
        {
            string[] ret = new string[input[0].Length];
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    ret[j] += input[i][j] + "";
                }
            }

            foreach(var s in ret)
            {
                var query = s.GroupBy(a => a).OrderByDescending(g => g.Count()).Select(g => g.Key).First();
                Console.Write(query.ToString());
            }
        }

        public void Part2(string[] input)
        {
            string[] ret = new string[input[0].Length];
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    ret[j] += input[i][j] + "";
                }
            }

            foreach (var s in ret)
            {
                var query = s.GroupBy(a => a).OrderBy(g => g.Count()).Select(g => g.Key).First();
                Console.Write(query.ToString());
            }
        }
    }
}
