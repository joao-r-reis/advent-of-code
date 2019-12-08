using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.IntCodeComputer;

namespace AdventOfCode._5
{
    public class Five : BaseRunnable
    {
        public override string Run(StreamReader reader)
        {
            var data = Parse(reader);
            var input = new Queue<int>(new[] { 1 });
            IntCodeProgram.NewDay5(input, out var output).Compute(data);
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