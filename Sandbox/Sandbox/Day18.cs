using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day18
    {
        public void Part1(string firstRow, int rows)
        {
            string previousRow = firstRow;
            int count = 0;

            for (int row = 0; row < rows; row++)
            {
                count += previousRow.Count(a => a == '.');
                previousRow = "." + previousRow + ".";
                string nextRow = "";
                for (int i = 1; i < previousRow.Length - 1; i++)
                {
                    //Its left and center tiles are traps, but its right tile is not.
                    //Its center and right tiles are traps, but its left tile is not.
                    //Only its left tile is a trap.
                    //Only its right tile is a trap.
                    char left = previousRow[i - 1];
                    char center = previousRow[i];
                    char right = previousRow[i + 1];

                    if (left == '^' && center == '^' && right != '^')
                    {
                        nextRow += "^";
                    }
                    else if (left != '^' && center == '^' && right == '^')
                    {
                        nextRow += "^";
                    }
                    else if (left == '^' && center != '^' && right != '^')
                    {
                        nextRow += "^";
                    }
                    else if (left != '^' && center != '^' && right == '^')
                    {
                        nextRow += "^";
                    }
                    else
                    {
                        nextRow += ".";
                    }
                }
                //Console.WriteLine(previousRow);
                previousRow = nextRow;
            }

            Console.WriteLine(count);
        }
    }
}
