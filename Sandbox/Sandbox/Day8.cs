using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day8
    {
        string[,] grid = new string[6,50];

        public Day8()
        {
            InitGrid();
        }

        private void InitGrid()
        {
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    grid[r, c] = ".";
                }
            }
        }

        private void PrintGrid()
        {
            int rowLength = grid.GetLength(0);
            int colLength = grid.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", grid[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            Console.WriteLine();
        }

        private void RotateColumn(int col, int val)
        {
            string[] tempCol = new string[grid.GetLength(0)];
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    if (c == col)
                    {
                        var old = grid[r, c];
                        int newRow = r + val;

                        if (newRow >= grid.GetLength(0))
                        {
                            newRow = newRow - grid.GetLength(0);
                        }

                        tempCol[newRow] = old;

                    }
                }
            }

            for (int r = 0; r < grid.GetLength(0); r++)
            {
                if (tempCol[r] != null)
                {
                    grid[r, col] = tempCol[r];
                }

            }
        }

        private void RotateRow(int row, int val)
        {
            string[] tempRow = new string[grid.GetLength(1)];
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    if (r == row)
                    {
                        var old = grid[r, c];
                        int newCol = c + val;

                        if (newCol >= grid.GetLength(1))
                        {
                            newCol = newCol - grid.GetLength(1);
                        }

                        tempRow[newCol] = old;

                    }
                }
            }

            for (int c = 0; c < grid.GetLength(1); c++)
            {
                if (tempRow[c] != null)
                {
                    grid[row, c] = tempRow[c];
                }
            }
        }

        private void CreateRect(int x, int y)
        {
            for (int r = 0; r < y; r++)
            {
                for (int c = 0; c < x; c++)
                {
                    grid[r, c] = "#";
                }
            }
        }

        public void Part1(string[] input)
        {
            foreach (var line in input)
            {
                
                string[] parts = line.Split();
                if (parts[0] == "rect")
                {
                    var xy = parts[1].Split('x');
                    int x = Int32.Parse(xy[0]);
                    int y = Int32.Parse(xy[1]);
                    CreateRect(x, y);
                }
                else if (parts[0] == "rotate" && parts[1] == "row")
                {
                    //rotate row y=0 by 7
                    int row = Int32.Parse(parts[2].Split('=')[1]);
                    int val = Int32.Parse(parts[4]);
                    RotateRow(row, val);
                }
                else if (parts[0] == "rotate" && parts[1] == "column")
                {
                    //rotate column x=0 by 1
                    int col = Int32.Parse(parts[2].Split('=')[1]);
                    int val = Int32.Parse(parts[4]);
                    RotateColumn(col, val);

                }
            }

            int count = 0;
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    if (grid[r, c] == "#")
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
            PrintGrid();
        }
    }
}
