using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;

using AdventOfCode.IntCodeComputer;

namespace AdventOfCode._5
{
    public class Five : BaseRunnable
    {
        private readonly int _input;

        public Five(int input)
        {
            _input = input;
        }

        public Five() : this(1)
        {
        }

        public override string Run(StreamReader reader)
        {
            var data = Parse(reader);
            var input = new BlockingCollection<int>
            {
                _input
            };
            var program = CreateIntCodeProgram(input);
            program.Compute(data);
            var output = program.Output;
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

        protected virtual IIntCodeProgram CreateIntCodeProgram(BlockingCollection<int> input)
        {
            return IntCodeProgram.NewDay5(input);
        }

        private int[] Parse(StreamReader reader)
        {
            var text = reader.ReadToEnd();
            return text.Split(",").Select(int.Parse).ToArray();
        }
    }
}