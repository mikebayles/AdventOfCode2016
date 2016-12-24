using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day19
    {
        int num = 3005290;
        int startingNum = 0;

        List<Elf> elfs = new List<Elf>();
        Elf NextElf(int current)
        {

            int i = current;
            int searched = 0;
            while (searched < num)
            {
                if (i >= num) i = 0;
                var elf = elfs[i];
                if (i != (current - 1) && elf.Gifts > 0) return elf;
                i++;
                searched++;
            }

            return null;

        }

        Elf NextElf(int current, int size)
        {
            int i = (current + (size / 2)) % size;
            i += (startingNum - size);
            int searched = 0;

            while (searched < num)
            {
                if (i >= startingNum) i = 0;
                if (i == -1) i = size;
                var elf = elfs[i];
                if (i != current && elf.Gifts > 0) return elf;
                i++;
                searched++;
            }

            return null;
        }

        public void Part1()
        {
            for (int i = 0; i < num; i++)
            {
                elfs.Add(new Elf(1, i));
            }

            int elfNum = 0;
            while (true)
            {
                var elf = elfs[elfNum];

                elfNum++;
                if (elfNum >= num) elfNum = 0;
                if (elf.Gifts == 0) continue;

                var stealFrom = NextElf(elfNum);
                if (stealFrom == null) break;

                elf.Gifts += stealFrom.Gifts;
                stealFrom.Gifts = 0;



            }

            Console.WriteLine(elfNum);
        }

        public void Part2()
        {
            for (int i = 0; i < num; i++)
            {
                elfs.Add(new Elf(1, i));
            }

            int elfNum = 0;
            startingNum = num;
            while (num > 1)
            {
                var elf = elfs[elfNum];

                elfNum++;
                if (elfNum >= startingNum) elfNum = 0;
                if (elf.Gifts == 0) { continue; }

                var stealFrom = NextElf(elfNum - 1, num);
                if (stealFrom == null) break;

                elf.Gifts += stealFrom.Gifts;
                stealFrom.Gifts = 0;
                num--;
            }

            System.IO.File.WriteAllText(@"C:\Users\MikeBayles\Desktop\mike.txt", elfNum.ToString());            
        }
    }

    public class Elf
    {
        public Elf(int gifts, int num)
        {
            this.Num = num;
            this.Gifts = gifts;
        }
        public int Gifts { get; set; }
        public int Num { get; set; }

        public override string ToString()
        {
            return string.Format("Num {0} Gifts {1}", Num, Gifts);
        }
    }
}
