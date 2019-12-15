using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;

using AdventOfCode.IntCodeComputer;

namespace AdventOfCode._9
{
    public class Nine : BaseRunnable
    {
        private readonly int _input;

        public Nine(int input)
        {
            _input = input;
        }

        public Nine() : this(1)
        {
        }

        public override string Run(StreamReader reader)
        {
            var data = Parse(reader);
            var input = new BlockingCollection<IntCodeValue>
            {
                IntCodeValue.FromInt(_input)
            };
            var program = CreateIntCodeProgram(input);
            program.Compute(data);
            var output = program.Output;
            var outputCodes = output.ToArray();
            if (outputCodes.Length != 1)
            {
                throw new InvalidOperationException("Found zero or more than one values in output: " +
                                                    string.Join(",", outputCodes.Select(code => code.ToString())));
            }

            return outputCodes.Single().ToString();
        }

        protected virtual IIntCodeProgram CreateIntCodeProgram(BlockingCollection<IntCodeValue> input)
        {
            return IntCodeProgram.New(input);
        }

        private IIntCodeData Parse(StreamReader reader)
        {
            return IntCodeData.FromStreamReader(reader);
        }
    }
}