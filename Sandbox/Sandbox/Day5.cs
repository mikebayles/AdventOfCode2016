using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day5
    {
        public string Part2(string door)
        {
            string[] ans = new string[8];

            int index = 0;
            int found = 0;
            while (found < 8)
            {
                string res = MD5Hash(door + index);
                if (res.StartsWith("00000"))
                {
                    int i;
                    if (Int32.TryParse(res[5].ToString(), out i) && i < 8 && string.IsNullOrEmpty(ans[i]))
                    {
                        ans[i] = res[6].ToString();
                        found++;
                    }
                }

                index++;
            }

            return string.Join("", ans);
        }

        public string Part1(string door)
        {
            string ans = "";
            int index = 0;
            int found = 0;
            while (found < 8)
            {
                string res = MD5Hash(door + index);
                if (res.StartsWith("00000"))
                {
                    found++;
                    ans += res[5];
                }
                index++;
            }

            return ans;
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
