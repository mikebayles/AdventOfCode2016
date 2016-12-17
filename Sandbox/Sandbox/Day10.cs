using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Day10
    {
        List<Bot> bots = new List<Bot>();
        int[] outputs = new int[21];
        public int Part1(string[] input, int findLow, int findHigh)
        {

            foreach (var line in input.Where(l => l.StartsWith("value")))
            {
                //value 31 goes to bot 114
                var parts = line.Split();
                int value = Int32.Parse(parts[1]);
                int bot = Int32.Parse(parts[5]);
                GiveToBot(bots, value, bot);
            }

            while (true)
            {
                Console.WriteLine("Outputs {0} {1} {2}", outputs[0], outputs[1], outputs[2]);
                List<Bot> botsToAdd = new List<Bot>();
                List<Bot> botsToRemove = new List<Bot>();

                foreach (var bot in bots.Where(a => a.Nums.Count == 2))
                {
                    foreach (var line in input.Where(a => a.StartsWith("bot " + bot.Id + " ")))
                    {
                        var parts = line.Split();
                        string lowHigh = parts[3];
                        int firstReceiver = Int32.Parse(parts[6]);
                        int secondReceiver = Int32.Parse(parts[11]);


                        if (parts[5] == "bot")
                            GiveToBot(botsToAdd, lowHigh == "low" ? bot.Nums.Min() : bot.Nums.Max(), firstReceiver);
                        else
                            outputs[firstReceiver] = lowHigh == "low" ? bot.Nums.Min() : bot.Nums.Max();
                        if (parts[10] == "bot")
                            GiveToBot(botsToAdd, lowHigh == "low" ? bot.Nums.Max() : bot.Nums.Min(), secondReceiver);
                        else
                            outputs[firstReceiver] = lowHigh == "low" ? bot.Nums.Max() : outputs[firstReceiver] = lowHigh == "low" ? bot.Nums.Min() : bot.Nums.Max();
                        botsToRemove.Add(bot);
                        //bot.Nums.Clear();
                        //bot 17 gives low to bot 181 and high to bot 162
                    }
                }

                bots.AddRange(botsToAdd);
                //bots.RemoveAll(a => botsToRemove.Contains(a));
            }

            return bots.First(a => a.Nums.Contains(findLow) && a.Nums.Contains(findHigh)).Id;
        }

        private void GiveToBot(List<Bot> botsToAdd, int value, int bot)
        {
            if (value == Int32.MaxValue || value == Int32.MinValue) return;
            if (bots.Count == 0)
            {
                botsToAdd.Add(new Bot(bot) { Nums = new HashSet<int>() { value } });
                return;
            }
            Bot firstMatch = bots.FirstOrDefault(a => a.Id == bot);
            if (firstMatch != null)
            {
                firstMatch.Nums.Add(value);
            }
            else
            {
                botsToAdd.Add(new Bot(bot) { Nums = new HashSet<int>() { value } });
            }
        }
    }

    public class Bot
    {
        public int Id { get; set; }
        public HashSet<int> Nums { get; set; }

        public Bot(int id)
        {
            this.Id = id;
            Nums = new HashSet<int>();
        }

        public override string ToString()
        {
            return string.Format("Bot {0}: {1} - {2}", Id, Nums.Min(), Nums.Max());
        }

        public override bool Equals(object obj)
        {
            var item = obj as Bot;

            if (item == null)
            {
                return false;
            }

            return Id.Equals(item.Id);
        }
    }
}
