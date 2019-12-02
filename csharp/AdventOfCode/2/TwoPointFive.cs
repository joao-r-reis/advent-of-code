using System;
using System.IO;
using System.Linq;
using AdventOfCode._1;

namespace AdventOfCode._2
{
    public class TwoPointFive : BaseRunnable
    {
        public override string Run(StreamReader reader)
        {
            var data = Parse(reader);
            return Compute(data, 19690720).ToString();
        }

        private int[] Parse(StreamReader reader)
        {
            var text = reader.ReadToEnd();
            return text.Split(",").Select(int.Parse).ToArray();
        }

        public int Compute(int[] data, int output)
        {
            var (noun, verb) = FindInputsThatMatchOutput(data, output);
            return 100 * noun + verb;
        }

        public (int, int) FindInputsThatMatchOutput(int[] data, int output)
        {
            for (var noun = 0; noun <= 99; noun++)
            for (var verb = 0; verb <= 99; verb++)
            {
                var result = new Two().ComputeWithInputAndGetOutput(data.ToArray(), noun, verb);
                if (result == output)
                {
                    return (noun, verb);
                }
            }

            throw new ArgumentException("No set of inputs match that output.");
        }
    }
}