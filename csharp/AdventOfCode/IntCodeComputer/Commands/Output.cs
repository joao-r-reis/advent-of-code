using System.Collections.Generic;

namespace AdventOfCode.IntCodeComputer.Commands
{
    public class Output : BaseCommand
    {
        public Queue<int> OutputQueue { get; } = new Queue<int>();

        public override int OpCode => 4;

        public override bool Process(int[] data, int[] parameterModes, ref int offset)
        {
            var output = FetchParameter(data, data[offset++], parameterModes, 0);
            OutputQueue.Enqueue(output);
            return false;
        }
    }
}