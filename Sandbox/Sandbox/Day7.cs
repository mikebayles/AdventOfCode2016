using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day7
    {
        string[] inputs;
        public Day7(string[] inputs)
        {
            this.inputs = inputs;
        }

        public int Part1()
        {
            int counter = 0;

            foreach (var input in inputs)
            {
                //ioxxoj[asdfgh]zxcvbn
                string a = input[0] + "";
                bool inSquare = false;
                bool good = false;
                for (int i = 1; i < input.Length - 2; i++)
                {
                    if (a == "[")
                    {
                        inSquare = true;
                    }
                    else if (a == "]")
                    {
                        inSquare = false;
                    }

                    string b = input[i] + "";
                    string c = input[i + 1] + "";
                    string d = input[i + 2] + "";

                    if (a == d && b == c && a != c)
                    {
                        good = true;
                        if (inSquare)
                        {
                            good = false;
                            break;
                        }
                    }

                    a = b;
                }

                if (good)
                {
                    counter++;
                }
            }

            return counter;

        }

        public int Part2()
        {
            int counter = 0;

            foreach (var input in inputs)
            {
                List<String> hypernets = new List<string>();
                string hypernetPattern = @"\[\w+\]";
                Regex regex = new Regex(hypernetPattern);
                foreach (Match match in regex.Matches(input))
                {
                    if (match.Success)
                    {
                        for (int i = 0; i < match.Value.Length - 2; i++)
                        {
                            if (match.Value[i] == match.Value[i + 2])
                            {
                                hypernets.Add(match.Value[i + 1].ToString() + match.Value[i].ToString() + match.Value[i + 1].ToString());
                            }
                        }
                    }
                }

                var cleanInput = Regex.Replace(input, hypernetPattern, "");

                if (hypernets.Any(a => cleanInput.Contains(a)))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
