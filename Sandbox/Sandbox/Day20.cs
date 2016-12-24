using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day20
    {
        List<Range> ranges = new List<Range>();
        public void Part1(string[] input)
        {
            foreach (var line in input)
            {
                var parts = line.Split('-').Select(a => Int64.Parse(a)).ToArray(); ;
                ranges.Add(new Range(parts[0], parts[1]));
            }
            int count = 0;
            ranges.Add(new Range(4294967296, 4294967296));
            ranges = ranges.OrderBy(a => a.Low).ThenByDescending(a => a.High).ToList();

            var last = ranges.First();
            for (int i = 1; i < ranges.Count; i++)
            {
                var current = ranges[i];
                if (current.Low > (last.High + 1))
                {
                    count += (int)(current.Low - (last.High + 1));
                    //count++;
                }
                last = current;
            }

            Console.WriteLine(count);
        }

        public void Part2(string[] input)
        {
            foreach (var line in input)
            {
                var parts = line.Split('-').Select(a => Int64.Parse(a)).ToArray(); ;
                ranges.Add(new Range(parts[0], parts[1]));
            }

            long result = 0;
            var entry = ranges.FirstOrDefault(x => x.Low <= result && x.High >= result);
            var ipCount = 0;

            while (result <= 4294967295)
            {
                while (entry != null)
                {
                    result = entry.High + 1;
                    entry = ranges.FirstOrDefault(x => x.Low <= result && x.High >= result);
                }

                if (result <= 4294967295)
                {
                    ipCount++;
                    result++;
                    entry = ranges.FirstOrDefault(x => x.Low <= result && x.High >= result);
                }
            }

            Console.WriteLine(ipCount.ToString());
        }

        public class Range
        {
            public long High { get; set; }
            public long Low { get; set; }

            public Range(long low, long high)
            {
                Low = low;
                High = high;
            }

            public override string ToString()
            {
                return Low + " - " + High;
            }
        }
    }
}