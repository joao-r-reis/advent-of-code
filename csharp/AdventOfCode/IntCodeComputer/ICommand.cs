namespace AdventOfCode.IntCodeComputer
{
    public interface ICommand
    {
        IntCodeValue OpCode { get; }

        /// <summary>
        /// Returns whether the program should be stopped.
        /// </summary>
        bool Process(IIntCodeData data, int[] parameterModes, ref IntCodeValue offset);
    }
}