namespace AdventOfCode.IntCodeComputer
{
    public interface ICommand
    {
        int OpCode { get; }

        /// <summary>
        /// Returns whether the program should be stopped.
        /// </summary>
        bool Process(int[] data, int[] parameterModes, ref int offset);
    }
}