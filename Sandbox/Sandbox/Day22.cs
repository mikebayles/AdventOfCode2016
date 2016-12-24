using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day22
    {
        List<Node> nodes = new List<Node>();

        public void MoveData(Node from, Node to)
        {
            to.Used += from.Used;
        }

        public bool CanMove(Node from, Node to)
        {
            return to.Avail >= from.Used;
        }

        public Day22(string[] input)
        {
            foreach (var line in input.Skip(2))
            {
                var smallLine = new Regex(@"\s+").Replace(line, "|");
                var lineParts = smallLine.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                var nameParts = lineParts[0].Split('-');

                Node newNode = new Node()
                {
                    X = int.Parse(nameParts[1].Replace("x", "")),
                    Y = int.Parse(nameParts[2].Replace("y", "")),
                    Size = int.Parse(lineParts[1].Replace("T", "")),
                    Used = int.Parse(lineParts[2].Replace("T", ""))

                };

                nodes.Add(newNode);
            }
        }
        public static void Print2DArray<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void Part1()
        {
            int counter = 0;
            for (int i = 0; i < nodes.Count; i++)
            {
                Node current = nodes[i];
                if (current.Used == 0) continue;
                for (int j = 0; j < nodes.Count; j++)
                {
                    if (i == j) continue;
                    if (CanMove(current, nodes[j])) counter++;
                }
            }

            Console.WriteLine(counter);
        }

        public void Part2()
        {
            int finalY = 0;
            int finalX = 0;
            int maxX = nodes.Max(a => a.X);
            int maxY = nodes.Max(a => a.Y);

            var state = new Node[maxY + 1, maxX + 1];


            foreach (var node in nodes)
            {
                state[node.Y, node.X] = node;
            }

            Console.WriteLine(nodes.Average(a => a.Size));

            Print2DArray(state);
            Queue<Node> queue = new Queue<Node>();
            Node root = nodes.First(a => a.Used == 0);
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                //check right
                if (current.X > 0 && current.X <= maxX)
                {
                }
            }
        }
    }



    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public int Used { get; set; }
        public int Avail { get { return Size - Used; } }

        public override string ToString()
        {
            if (Used == 0) return "_";
            if (Size > 96) return "#";
            return ".";
        }
    }
}
