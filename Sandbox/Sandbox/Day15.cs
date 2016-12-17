using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day15
    {
        public void Part1()
        {
            List<Disk> disks = new List<Disk>()
            {
                //new Disk(1,5,4),
                //new Disk(2,2,1)
                new Disk(1,5,2),
                new Disk(2,13,7),
                new Disk(3,17,10),
                new Disk(4,3,2),
                new Disk(5,19,9),
                new Disk(6,7,0),
                new Disk(7,11,0),
            };

            int time = 1;
            while (true)
            {
                if (time >= disks.Count && disks.All(disk => disk.CurrentPosition == 0))
                {
                    break;
                }

                foreach (var disk in disks)
                {                    
                    disk.CurrentPosition = (disk.StartPosition + time + disk.Number) % disk.Positions;
                }

                time++;
            }

            Console.WriteLine(time - 1);
        }
    }
    public class Disk
    {
        public int Number { get; set; }
        public int Positions { get; set; }
        public int StartPosition { get; set; }

        public int CurrentPosition { get; set; }

        public Disk(int number, int positions, int startPosition)
        {
            this.Number = number;
            this.Positions = positions;
            this.StartPosition = startPosition;
            CurrentPosition = startPosition;
        }
    }
}
