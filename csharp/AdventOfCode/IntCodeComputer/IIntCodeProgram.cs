using System.Collections.Concurrent;

namespace AdventOfCode.IntCodeComputer
{
    public interface IIntCodeProgram
    {
        BlockingCollection<int> Output { get; }

        int[] Compute(int[] data);
    }
}