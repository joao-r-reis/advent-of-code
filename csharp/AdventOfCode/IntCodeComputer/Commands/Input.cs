using System.Collections.Generic;

namespace AdventOfCode.IntCodeComputer.Commands
{
    public class Input : BaseCommand
    {
        private readonly Queue<int> _input;

        public Input(Queue<int> input)
        {
            _input = input;
        }

        public override int OpCode => 3;

        public override bool Process(int[] data, int[] parameterModes, ref int offset)
        {
            var input = _input.Dequeue();
            var value = data[offset++];
            data[value] = input;
            return false;
        }
    }
}