using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day12
    {
        int a = 0;
        int b = 0;
        int c = 1;
        int d = 0;
        public void Part1(string[] input)
        {

            for (int i = 0; i < input.Length; i++)
            {
                var line = input[i];
                var parts = line.Split();
                string command = parts[0];
                int value = GetValue(parts[1]);
                switch (command)
                {
                    case "cpy":
                        switch (parts[2])
                        {
                            case "a":
                                a = value;
                                break;
                            case "b":
                                b = value;
                                break;
                            case "c":
                                c = value;
                                break;
                            case "d":
                                d = value;
                                break;
                        }
                        break;
                    case "jnz":
                        if (value != 0)
                        {
                            i += GetValue(parts[2]);
                            i--;
                        }
                        break;
                    case "dec":
                        switch (parts[1])
                        {
                            case "a":
                                a--;
                                break;
                            case "b":
                                b--;
                                break;
                            case "c":
                                c--;
                                break;
                            case "d":
                                d--;
                                break;
                        }
                        break;
                    case "inc":
                        switch (parts[1])
                        {
                            case "a":
                                a++;
                                break;
                            case "b":
                                b++;
                                break;
                            case "c":
                                c++;
                                break;
                            case "d":
                                d++;
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine(a);
        }

        private int GetValue(string part)
        {
            int ret;
            if (Int32.TryParse(part, out ret)) return ret;

            switch (part)
            {
                case "a":
                    return a;
                case "b": return b;
                case "c": return c;
                case "d": return d;
            }

            return -1;
        }
    }
}
