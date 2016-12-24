using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day23
    {
        string[] input;
        int a = 12;
        int b = 0;
        int c = 0;
        int d = 0;
        public Day23(string[] input)
        {
            this.input = input;
        }
        public void Part1()
        {


            for (int i = 0; i < input.Length; i++)
            {
                var line = input[i];
                var parts = line.Split();
                string command = parts[0];
                int value = GetValue(parts[1]);
                switch (command)
                {
                    case "tgl":
                        var nextCmdIndex = i + GetValue(parts[1]);
                        if (nextCmdIndex >= input.Length) break;

                        var nextCmd = input[nextCmdIndex];
                        var nextCmdParts = nextCmd.Split();
                        if (nextCmdParts[0] == "inc")
                        {
                            nextCmd = "dec" + " " + nextCmdParts[1];
                            input[nextCmdIndex] = nextCmd;
                        }
                        else if (nextCmdParts.Length == 2)
                        {
                            nextCmd = "inc" + " " + nextCmdParts[1];
                            input[nextCmdIndex] = nextCmd;
                        }
                        else if (nextCmdParts[0] == "jnz")
                        {
                            nextCmdParts[0] = "cpy";
                            nextCmd = string.Join(" ", nextCmdParts);
                            input[nextCmdIndex] = nextCmd;
                        }
                        else if (nextCmdParts.Length == 3)
                        {
                            nextCmdParts[0] = "jnz";
                            nextCmd = string.Join(" ", nextCmdParts);
                            input[nextCmdIndex] = nextCmd;
                        }

                        break;
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

