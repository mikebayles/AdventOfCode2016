using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day16
    {
        string puzzle = "01110110101001000";
        int length = 35651584;
        public void Part1()
        {
            string dragon = DragonCurve(puzzle);
            while(dragon.Length < length)
            {
                dragon = DragonCurve(dragon);
            }

            string checksum = CheckSum(dragon.Substring(0,length));

            while(checksum.Length % 2 == 0)
            {
                checksum = CheckSum(checksum);
            }

            Console.WriteLine(checksum);
           
        }

        public string CheckSum(string input)
        {
            StringBuilder ret = new StringBuilder();
            for(int i = 0; i < input.Length; i += 2)
            {
                if(input[i] == input[i+1])
                {
                    ret.Append("1");
                }
                else
                {
                    ret.Append("0");
                }
            }

            return ret.ToString();
        }

        public string DragonCurve(string input)
        {
            string a = input;
            string b = string.Join("", a.Reverse().Select(c => c == '1' ? '0' : '1'));
         
            return a + "0" + b;
        }
    }
}
