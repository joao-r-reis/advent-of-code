using System;
using System.IO;

namespace AdventOfCode._1
{
    public class One : IRunnable
    {
        public string Run(string[] args)
        {
            using (var input = File.OpenText(args[1]))
            {
                return Run(input).ToString();
            }
        }

        public long Run(StreamReader reader)
        {
            long sum = 0;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var mass = int.Parse(line);
                sum += ComputeRequiredFuel(mass);
            }

            return sum;
        }

        public int ComputeRequiredFuel(int mass)
        {
            return ((int)Math.Floor(mass / 3d)) - 2;
        }
    }
}