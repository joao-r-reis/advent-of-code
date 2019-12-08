using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.IntCodeComputer;

namespace AdventOfCode._5
{
    public class FivePointFive : BaseRunnable
    {
        private readonly int _input;

        public FivePointFive(int input)
        {
            _input = input;
        }

        public FivePointFive() : this(5) { }

        public override string Run(StreamReader reader)
        {
            var data = Parse(reader);
            var input = new Queue<int>(new[] { _input });
            IntCodeProgram.NewDay5PointFive(input, out var output).Compute(data);
            var outputCodes = output.ToArray();
            if (outputCodes.SkipLast(1).Any(code => code != 0))
            {
                throw new InvalidOperationException("Found non zero output code.");
            }

            if (!outputCodes.Any())
            {
                return "null";
            }

            return outputCodes.Last().ToString();
        }

        private int[] Parse(StreamReader reader)
        {
            var text = reader.ReadToEnd();
            return text.Split(",").Select(int.Parse).ToArray();
        }
    }
}