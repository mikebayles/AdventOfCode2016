using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"C:\Users\MikeBayles\Desktop\input.txt");

            var obj = new Day4(input);
            Console.WriteLine(obj.Part2());
        }
    }
}