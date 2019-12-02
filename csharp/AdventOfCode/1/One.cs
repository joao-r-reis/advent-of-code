using System;
using System.IO;

namespace AdventOfCode._1
{
    public class One : BaseRunnable
    {
        public override string Run(StreamReader reader)
        {
            long sum = 0;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var mass = int.Parse(line);
                sum += ComputeRequiredFuel(mass);
            }

            return sum.ToString();
        }

        public int ComputeRequiredFuel(int mass)
        {
            return ((int)Math.Floor(mass / 3d)) - 2;
        }
    }
}