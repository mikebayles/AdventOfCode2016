using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day3
    {
        string[] input;
        public Day3(string[] input)
        {
            this.input = input;
        }
        public int Part1()
        {
            int count = 0;
            foreach (var line in input)
            {
                var parts = line.Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(a => int.Parse(a)).ToArray();
                if (IsGood(parts[0], parts[1], parts[2]))
                    count++;
            }

            return count;
        }

        public int Part2()
        {
            int count = 0;
            for (int i = 0; i < input.Length; i += 3)
            {
                var line0 = input[i].Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(a => int.Parse(a)).ToArray();
                var line1 = input[i + 1].Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(a => int.Parse(a)).ToArray();
                var line2 = input[i + 2].Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(a => int.Parse(a)).ToArray();

                if (IsGood(line0[0], line1[0], line2[0])) count++;
                if (IsGood(line0[1], line1[1], line2[1])) count++;
                if (IsGood(line0[2], line1[2], line2[2])) count++;

            }

            return count;
        }

        private bool IsGood(int a, int b, int c)
        {
            return a + b > c && a + c > b && b + c > a;
        }


    }
}
