using System.Collections.Concurrent;

namespace AdventOfCode.IntCodeComputer.Commands
{
    public class Output : BaseCommand
    {
        public Output(BlockingCollection<int> output)
        {
            OutputQueue = output;
        }

        public Output()
        {
        }

        public BlockingCollection<int> OutputQueue { get; } = new BlockingCollection<int>();

        public override int OpCode => 4;

        public override bool Process(int[] data, int[] parameterModes, ref int offset)
        {
            var output = FetchParameter(data, data[offset++], parameterModes, 0);
            OutputQueue.Add(output);
            return false;
        }
    }
}