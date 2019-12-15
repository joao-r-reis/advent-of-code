using System.Collections.Concurrent;

namespace AdventOfCode.IntCodeComputer.Commands
{
    public class Output : BaseCommand
    {
        public Output(IParameterComputer parameterComputer, BlockingCollection<IntCodeValue> output) : base(parameterComputer)
        {
            OutputQueue = output;
        }

        public BlockingCollection<IntCodeValue> OutputQueue { get; }

        public override IntCodeValue OpCode => IntCodeValue.FromInt(4);

        public override bool Process(IIntCodeData data, int[] parameterModes, ref IntCodeValue offset)
        {
            var output = ReadData(data, data[offset++], parameterModes, 0);
            OutputQueue.Add(output);
            return false;
        }
    }
}