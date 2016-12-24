using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day21
    {
        string[] input;

        public Day21(string[] input)
        {
            this.input = input;
        }

        private string ShiftLeft(string key, int shift)
        {
            shift %= key.Length;
            return key.Substring(shift) + key.Substring(0, shift);
        }

        private string ShiftRight(string key, int shift)
        {
            shift %= key.Length;
            return key.Substring(key.Length - shift) + key.Substring(0, key.Length - shift);
        }

        private string Swap(string word, int firstIndex, int secondIndex)
        {
            char firstChar = word[firstIndex];
            char secondChar = word[secondIndex];

            string newWord = "";
            for (int i = 0; i < word.Length; i++)
            {

                if (i == firstIndex) { newWord += secondChar; }
                else if (i == secondIndex) { newWord += firstChar; }
                else newWord += word[i];
            }
            return newWord;
        }

        private string Swap(string word, char firstChar, char secondChar)
        {
            string newWord = "";
            foreach (var c in word)
            {
                if (c == firstChar) newWord += secondChar;
                else if (c == secondChar) newWord += firstChar;
                else newWord += c;
            }

            return newWord;
        }

        private string ReverseFromTo(string word, int x, int y)
        {
            var reversed = string.Join("", word.Substring(x, y - x + 1).Reverse());
            int i = 0;
            string newWord = "";
            while (i < word.Length)
            {
                if (i == x)
                {
                    newWord += reversed;
                    i += (y - x + 1);
                }
                else
                {
                    newWord += word[i];
                    i++;
                }
            }

            return newWord;
        }

        private string MoveFromTo(string word, int x, int y)
        {
            char c = word[x];
            word = word.Remove(x, 1);
            word = word.Insert(y, c.ToString());

            return word;
        }

        public string Part1(string word)
        {
            foreach (var line in input)
            {
                var parts = line.Split();
                if (parts[0] == "swap" && parts[1] == "position")
                {
                    int firstIndex = int.Parse(parts[2]);
                    int secondIndex = int.Parse(parts[5]);

                    word = Swap(word, firstIndex, secondIndex);
                }
                else if (parts[0] == "swap" && parts[1] == "letter")
                {
                    char firstChar = char.Parse(parts[2]);
                    char secondChar = char.Parse(parts[5]);

                    word = Swap(word, firstChar, secondChar);
                }
                else if (parts[0] == "rotate" && parts[3].StartsWith("step"))
                {
                    var steps = int.Parse(parts[2]);
                    if (parts[1] == "left")
                    {
                        word = ShiftLeft(word, steps);
                    }
                    else
                    {
                        word = ShiftRight(word, steps);
                    }
                }
                else if (parts[0] == "rotate" && parts[1] == "based")
                {
                    var needle = char.Parse(parts[6]);
                    var index = word.IndexOf(needle);

                    if (index > -1)
                    {
                        word = ShiftRight(word, (1 + index) + (index >= 4 ? 1 : 0));
                    }
                }
                else if (parts[0] == "reverse")
                {
                    var x = int.Parse(parts[2]);
                    var y = int.Parse(parts[4]);

                    word = ReverseFromTo(word, x, y);
                }
                else if (parts[0] == "move")
                {
                    var x = int.Parse(parts[2]);
                    var y = int.Parse(parts[5]);

                    word = MoveFromTo(word, x, y);
                }
            }
            return word;
        }

        private static IEnumerable<T[]> GetPermutations<T>(T[] values)
        {
            if (values.Length == 1)
                return new[] { values };

            return values.SelectMany(v => GetPermutations(values.Except(new[] { v }).ToArray()),
                (v, p) => new[] { v }.Concat(p).ToArray());
        }

        public string Part2(string word)
        {
            var perms = GetPermutations(word.ToArray()).Select(a => string.Join("", a));

            foreach (var perm in perms)
            {
                var scrambled = Part1(perm);
                if (scrambled == word)
                {
                    return perm;
                }
            }

            return null;
        }
    }
}
