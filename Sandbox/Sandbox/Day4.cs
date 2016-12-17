using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day4
    {
        string[] input;

        public Day4(string[] input)
        {
            this.input = input;
        }

        public int Part1()
        {
            int ret = 0;
            foreach (var line in input)
            {
                var roomLetters = string.Join("", string.Join("", line.Split('-').Reverse().Skip(1)).GroupBy(a => a).OrderByDescending(g => g.Count()).ThenBy(a => a.Key).Select(a => a.Key).ToList());
                var sector = int.Parse(new Regex(@"\d+").Match(line).Value);
                var checkSum = new Regex(@"\[(\w+)\]").Match(line).Groups[1].Value;

                if (roomLetters.StartsWith(checkSum)) ret += sector;
            }

            return ret;
        }

        public int Part2()
        {
            foreach (var line in input)
            {
                var roomLetters = new Regex(@"(.*)\d+.*").Match(line).Groups[1].Value;
                var sector = int.Parse(new Regex(@"\d+").Match(line).Value);

                int letterShifts = sector % 26;
                string shiftedLetters = "";
                shiftedLetters = ShiftLetters(roomLetters, letterShifts);

                if (shiftedLetters.ToLower().Contains("north"))
                    return sector;
            }

            return -1;
        }

        public string ShiftLetters(string roomLetters, int letterShifts)
        {
            string shiftedLetters = "";
            foreach (var c in roomLetters)
            {
                char tempC = c;
                for (int i = 1; i <= letterShifts; i++)
                {
                    if (tempC == 'z') tempC = 'a';
                    else if (tempC == '-') { tempC = ' '; break; }
                    else tempC++;
                }

                shiftedLetters += tempC;
            }

            return shiftedLetters;
        }
    }
}
