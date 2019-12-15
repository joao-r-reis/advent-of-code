using System.Collections.Concurrent;

namespace AdventOfCode.IntCodeComputer
{
    public interface IIntCodeProgram
    {
        BlockingCollection<IntCodeValue> Output { get; }

        int[] Compute(int[] data);

        IIntCodeData Compute(IIntCodeData data);
    }
}