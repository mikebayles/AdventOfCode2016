using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day14
    {
        string start = "ihaygndm";
        Dictionary<string, string> hashes = new Dictionary<string, string>();
        public void Part1()
        {
            int index = 0;
            int found = 0;
            string ret = "";



            while (found < 64)
            {
                if (!hashes.ContainsKey(start + index))
                {
                    hashes[start + index] = MD5Hash(start + index);
                }

                string hash = hashes[start + index];
                Regex regex = new Regex(@"(\w)\1{2}");
                var match = regex.Match(hash);
                if (match.Success)
                {

                    for (int i = 1; i <= 1000; i++)
                    {
                        int innerIndex = (index + i);
                        if (!hashes.ContainsKey(start + innerIndex))
                        {
                            hashes[start + innerIndex] = MD5Hash(start + innerIndex);
                        }

                        string innerHash = hashes[start + innerIndex];
                        if (new Regex(@"(" + match.Value[0] + @")\1{4}").IsMatch(innerHash))
                        {
                            found++;
                            ret += innerIndex;
                            break;
                        }
                    }
                }

                index++;
            }

            Console.WriteLine(--index);
        }

        public void Part2()
        {
            int index = 0;
            int found = 0;
            string ret = "";

            while (found < 64)
            {
                if (!hashes.ContainsKey(start + index))
                {                    
                    hashes[start + index] = MD5Hash2016(MD5Hash(start + index));
                }

                string hash = hashes[start + index];

                Regex regex = new Regex(@"(\w)\1{2}");
                var match = regex.Match(hash);
                if (match.Success)
                {
                    for (int i = 1; i <= 1000; i++)
                    {
                        int innerIndex = (index + i);
                        if (!hashes.ContainsKey(start + innerIndex))
                        {
                            hashes[start + innerIndex] = MD5Hash2016(MD5Hash(start + innerIndex));
                        }

                        string innerHash = hashes[start + innerIndex];
                        if (new Regex(@"(" + match.Value[0] + @")\1{4}").IsMatch(innerHash))
                        {
                            found++;
                            ret += innerIndex;
                            break;
                        }
                    }
                }

                index++;
            }

            Console.WriteLine(--index);
        }

        public string MD5Hash(string input)
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

        public string MD5Hash2016(string input)
        {
            for (int i = 0; i < 2016; i++)
            {
                input = MD5Hash(input);
            }

            return input;
        }
    }
}
