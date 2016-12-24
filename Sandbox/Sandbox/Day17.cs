using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    class State
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Letters { get; set; }
        public override string ToString()
        {
            return Letters;
        }
    }

    public class Day17
    {
        string input;
        Queue<State> queue = new Queue<State>();
        int x = 0;
        int y = 0;
        public Day17(string input)
        {
            this.input = input;
            queue.Enqueue(NextState("", ""));
        }

        private State NextState(string nextLetter, string firstFour)
        {
            var newState = new State()
            {
                X = x,
                Y = y,
                Letters = input + nextLetter,
            };

            switch (nextLetter)
            {
                case "R": newState.X++; break;
                case "D": newState.Y++; break;
                case "L": newState.X--; break;
                case "U": newState.Y--; break;
                default: break;
            }

            return newState;
        }

        public string Part1()
        {
            string initial = input;
            int finalX = 3;
            int finalY = 3;
            List<string> solutions = new List<string>();
            Dictionary<string, string> hashes = new Dictionary<string, string>();

            while (queue.Any())
            {
                var currentState = queue.Dequeue();
                var currentLetters = currentState.Letters;


                x = currentState.X;
                y = currentState.Y;

                if (x == finalX && y == finalY)
                {
                    solutions.Add(currentLetters.Replace(initial, ""));
                    continue;
                }


                if (!hashes.ContainsKey(currentLetters))
                {
                    hashes[currentLetters] = MD5Hash(currentLetters);
                }

                var hash = hashes[currentLetters];
                if (IsDoorOpen(hash[1]) && y < 3)
                {
                    var sb = new StringBuilder(currentLetters);
                    sb.Append("D");
                    var newState = new State()
                    {
                        X = x,
                        Y = y + 1,
                        Letters = sb.ToString()

                    };

                    queue.Enqueue(newState);

                }

                if (IsDoorOpen(hash[3]) && x < 3)
                {
                    var sb = new StringBuilder(currentLetters);
                    sb.Append("R");
                    var newState = new State()
                    {
                        X = x + 1,
                        Y = y,
                        Letters = sb.ToString()

                    };

                    queue.Enqueue(newState);

                }
                if (IsDoorOpen(hash[0]) && y > 0)
                {
                    var sb = new StringBuilder(currentLetters);
                    sb.Append("U");
                    var newState = new State()
                    {
                        X = x,
                        Y = y - 1,
                        Letters = sb.ToString(),
                    };

                    queue.Enqueue(newState);
                }

                if (IsDoorOpen(hash[2]) && x > 0)
                {
                    var sb = new StringBuilder(currentLetters);
                    sb.Append("L");
                    var newState = new State()
                    {
                        X = x - 1,
                        Y = y,
                        Letters = sb.ToString(),
                    };

                    queue.Enqueue(newState);
                }
            }

            Console.WriteLine(solutions.OrderBy(a => a.Length).First());

            return solutions.OrderByDescending(a => a.Length).First().Length.ToString();
        }
        public bool IsDoorOpen(char c)
        {
            return "bcdef".Contains(c);
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
