using System.Collections.Concurrent;

namespace AdventOfCode.IntCodeComputer.Commands
{
    public class Input : BaseCommand
    {
        private readonly BlockingCollection<int> _input;

        public Input(BlockingCollection<int> input)
        {
            _input = input;
        }

        public override int OpCode => 3;

        public override bool Process(int[] data, int[] parameterModes, ref int offset)
        {
            var input = _input.Take();
            var value = data[offset++];
            data[value] = input;
            return false;
        }
    }
}