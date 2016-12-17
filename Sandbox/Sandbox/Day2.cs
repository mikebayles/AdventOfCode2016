using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day2
    {
        string[] input;
        public Day2(string[] input)
        {
            this.input = input;
        }

        public string Part1()
        {
            StringBuilder ret = new StringBuilder();
            int[,] grid = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int r = 1;
            int c = 1;
            foreach (var line in input)
            {
                foreach (var cmd in line.Select(a => a.ToString()))
                {
                    if (cmd == "U" && r > 0)
                    {
                        r--;
                    }
                    else if (cmd == "R" && c < 2)
                    {
                        c++;
                    }
                    else if (cmd == "D" && r < 2)
                    {
                        r++;
                    }
                    else if (cmd == "L" && c > 0)
                    {
                        c--;
                    }
                }

                ret.Append(grid[r, c]);
            }

            return ret.ToString();
        }

        public string Part2()
        {
            StringBuilder ret = new StringBuilder();
            string[,] grid = { { ".", ".", "1", ".", "." }, { ".", "2", "3", "4", "." }, { "5", "6", "7", "8", "9" }, { ".", "A", "B", "C", "." }, { ".", ".", "D", ".", "." } };
            int r = 2;
            int c = 0;
            foreach (var line in input)
            {
                foreach (var cmd in line.Select(a => a.ToString()))
                {
                    if (cmd == "U" && r > 0 && grid[r - 1, c] != ".")
                    {
                        r--;
                    }
                    else if (cmd == "R" && c < 4 && grid[r, c + 1] != ".")
                    {
                        c++;
                    }
                    else if (cmd == "D" && r < 4 && grid[r + 1, c] != ".")
                    {
                        r++;
                    }
                    else if (cmd == "L" && c > 0 && grid[r, c - 1] != ".")
                    {
                        c--;
                    }
                }

                ret.Append(grid[r, c]);
            }

            return ret.ToString();
        }
    }
}
