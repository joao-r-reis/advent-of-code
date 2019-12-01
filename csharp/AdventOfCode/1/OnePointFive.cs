using System.IO;

namespace AdventOfCode._1
{
    public class OnePointFive : IRunnable
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
            var fuel = new One().ComputeRequiredFuel(mass);
            if (fuel <= 0)
            {
                return 0;
            }

            var additionalFuel = ComputeRequiredFuel(fuel);

            return fuel + additionalFuel;
        }
    }
}