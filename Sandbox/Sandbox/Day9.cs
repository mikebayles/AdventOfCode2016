using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day9
    {
        public void Part1(string[] input)
        {
            int count = 0;

            foreach (var line in input)
            {
                bool inGroup = false;

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '(' && !inGroup)
                    {
                        inGroup = true;
                        int sign = line.IndexOf('x', i);
                        int characterCount = Int32.Parse(line.Substring(i + 1, sign - i - 1));
                        int num = Int32.Parse(line.Substring(sign + 1, line.IndexOf(')', sign) - sign - 1));

                        count += (characterCount * (num));
                        i = line.IndexOf(')', i) + characterCount;
                        inGroup = false;
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }

        public decimal Part2Rec(string[] input)
        {
            decimal count = 0m;
            foreach (var line in input)
            {
                count += DecompressRec(line);
            }

            return count;
        }

        private decimal DecompressRec(string line)
        {
            if (line.StartsWith("("))
            {
                int sign = line.IndexOf('x');
                int characterCount = Int32.Parse(line.Substring(1, sign - 1));
                int num = Int32.Parse(line.Substring(sign + 1, line.IndexOf(')', sign) - sign - 1));
                int closer = line.IndexOf(')', sign);

                return num * DecompressRec(line.Substring(closer + 1, characterCount)) +
                    DecompressRec(line.Substring(closer + 1 + characterCount));
            }
            else
            {
                int nextParen = line.IndexOf('(');
                if (nextParen < 0)
                {
                    return line.Length;
                }
                else
                    return nextParen + DecompressRec(line.Substring(nextParen));
            }
        }

    }
}
