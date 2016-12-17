using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day13
    {
        static int rows = 1000;
        static int cols = 1000;
        int FavoriteNum = 1362;
        int myX = 1;
        int myY = 1;
        int finalX = 31;
        int finalY = 39;
        int moves = 0;
        HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
        Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
        List<int> solutions = new List<int>();
        public void Part1(string[] input)
        {

            while (true)
            {
                if (myY == finalY && myX == finalX)
                    solutions.Add(moves);

                if (myX - 1 >= 0 && IsClear(myX - 1, myY) && !visited.Any(a => a.Item1 == myX - 1 && a.Item2 == myY))
                {
                    myX--;
                    moves++;
                    visited.Add(Tuple.Create(myX, myY));
                    stack.Push((Tuple.Create(myX, myY)));
                }
                else if (myY - 1 >= 0 && IsClear(myX, myY - 1) && !visited.Any(a => a.Item1 == myX && a.Item2 == myY - 1))
                {
                    myY--;
                    moves++;
                    visited.Add(Tuple.Create(myX, myY));
                    stack.Push((Tuple.Create(myX, myY)));
                }
                else if (myX + 1 < cols && IsClear(myX + 1, myY) && !visited.Any(a => a.Item1 == myX + 1 && a.Item2 == myY))
                {
                    myX++;
                    moves++;
                    visited.Add(Tuple.Create(myX, myY));
                    stack.Push((Tuple.Create(myX, myY)));
                }
                else if (myY + 1 < rows && IsClear(myX, myY + 1) && !visited.Any(a => a.Item1 == myX && a.Item2 == myY + 1))
                {
                    myY++;
                    moves++;
                    visited.Add(Tuple.Create(myX, myY));
                    stack.Push((Tuple.Create(myX, myY)));
                }
                else
                {
                    if (stack.Count == 0) break;
                    var last = stack.Pop();
                    myX = last.Item1;
                    myY = last.Item2;
                    moves--;
                }
            }

            Console.WriteLine(solutions.Min());
        }

        public void DoWhile(Tuple<int, int, int> root)
        {
            Queue<Tuple<int, int, int>> q = new Queue<Tuple<int, int, int>>();
            q.Enqueue(root);
            while (true)
            {
                Tuple<int, int, int> current = q.Dequeue();
                visited.Add(Tuple.Create(current.Item1, current.Item2));

                if (current.Item3 == 50)
                {
                    Console.WriteLine(visited.Count);
                }

                if (current.Item1 == finalX && current.Item2 == finalY)
                {
                    break;
                }

                if (!WasVisited(current.Item1 + 1, current.Item2) && IsClear(current.Item1 + 1, current.Item2))
                {
                    q.Enqueue(Tuple.Create(current.Item1 + 1, current.Item2, current.Item3 + 1));
                }
                if (!WasVisited(current.Item1 - 1, current.Item2) && IsClear(current.Item1 - 1, current.Item2))
                {
                    q.Enqueue(Tuple.Create(current.Item1 - 1, current.Item2, current.Item3 + 1));
                }
                if (!WasVisited(current.Item1, current.Item2 + 1) && IsClear(current.Item1, current.Item2 + 1))
                {
                    q.Enqueue(Tuple.Create(current.Item1, current.Item2 + 1, current.Item3 + 1));
                }
                if (!WasVisited(current.Item1, current.Item2 - 1) && IsClear(current.Item1, current.Item2 - 1))
                {
                    q.Enqueue(Tuple.Create(current.Item1, current.Item2 - 1, current.Item3 + 1));
                }
            }
        }

        public bool WasVisited(int x, int y)
        {
            return visited.Any(a => a.Item1 == x && a.Item2 == y);
        }

        public bool IsClear(int x, int y)
        {
            if (x < 0 || y < 0) return false;
            int ret = x * x + 3 * x + 2 * x * y + y + y * y;
            ret += FavoriteNum;
            string binary = Convert.ToString(ret, 2);
            return binary.Count(a => a == '1') % 2 == 0;
        }

    }
}
