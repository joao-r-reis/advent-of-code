using System.Collections.Concurrent;

namespace AdventOfCode.IntCodeComputer.Commands
{
    public class Input : BaseCommand
    {
        private readonly BlockingCollection<IntCodeValue> _input;

        public Input(IParameterComputer computer, BlockingCollection<IntCodeValue> input) : base(computer)
        {
            _input = input;
        }

        public override IntCodeValue OpCode => IntCodeValue.FromInt(3);

        public override bool Process(IIntCodeData data, int[] parameterModes, ref IntCodeValue offset)
        {
            var input = _input.Take();
            var value = data[offset++];
            WriteData(data, input, value, parameterModes, 0);
            return false;
        }
    }
}