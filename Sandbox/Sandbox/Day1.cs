using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day1
    {
        Direction currentDirection = Direction.North;
        List<Tuple<int, int>> visited = new List<Tuple<int, int>>();
        IEnumerable<string> input;
        int x = 0;
        int y = 0;

        public Day1(string input)
        {
            this.input = input.Split(',').Select(a => a.Trim());
        }

        public int Part1()
        {

            foreach (var cmd in input)
            {
                var distance = Convert.ToInt32(string.Join("", cmd.Skip(1)));
                currentDirection = cmd[0] == 'R' ? NextDirection() : PreviousDirection();
                switch (currentDirection)
                {
                    case Direction.North:
                        y += distance;
                        break;
                    case Direction.East:
                        x += distance;
                        break;
                    case Direction.South:
                        y -= distance;
                        break;
                    case Direction.West:
                        x -= distance;
                        break;
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }

        public int Part2()
        {
            foreach (var cmd in input)
            {
                var distance = Convert.ToInt32(string.Join("", cmd.Skip(1)));
                currentDirection = cmd[0] == 'R' ? NextDirection() : PreviousDirection();
                switch (currentDirection)
                {
                    case Direction.North:
                        for (int i = 1; i <= distance; i++)
                        {
                            if (CheckVisitedAndAdd(x, ++y)) return Math.Abs(x) + Math.Abs(y);
                        }
                        break;
                    case Direction.East:
                        for (int i = 1; i <= distance; i++)
                        {
                            if (CheckVisitedAndAdd(++x, y)) return Math.Abs(x) + Math.Abs(y);
                        }
                        break;
                    case Direction.South:
                        for (int i = 1; i <= distance; i++)
                        {
                            if (CheckVisitedAndAdd(x, --y)) return Math.Abs(x) + Math.Abs(y);
                        }
                        break;
                    case Direction.West:
                        for (int i = 1; i <= distance; i++)
                        {
                            if (CheckVisitedAndAdd(--x, y)) return Math.Abs(x) + Math.Abs(y);
                        }
                        break;
                }
            }

            return -1;
        }

        private bool CheckVisitedAndAdd(int x, int y)
        {
            var newPoint = Tuple.Create(x, y);
            if (visited.Contains(newPoint))
            {
                return true;
            }

            visited.Add(newPoint);

            return false;
        }

        enum Direction
        {
            North = 1,
            East,
            South,
            West
        }

        private Direction NextDirection()
        {
            if (currentDirection == Direction.West) return Direction.North;

            return ++currentDirection;
        }

        private Direction PreviousDirection()
        {
            if (currentDirection == Direction.North) return Direction.West;

            return --currentDirection;
        }
    }
}
