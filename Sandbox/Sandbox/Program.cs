using System;
using System.IO;

namespace Sandbox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"C:\Users\MikeBayles\Desktop\input.txt");

            var obj = new Day23(input);
            obj.Part1();           
        }
    }
}