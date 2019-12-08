using System;

namespace AdventOfCode.IntCodeComputer
{
    public abstract class BaseCommand : ICommand
    {
        public const int PositionMode = 0;
        public const int ImmediateMode = 1;

        protected int FetchParameter(int[] data, int parsedValue, int[] parameterModes, int parameterIndex)
        {
            var parameterMode = parameterIndex >= parameterModes.Length ? PositionMode : parameterModes[parameterIndex];
            switch (parameterMode)
            {
                case PositionMode:
                    return data[parsedValue];
                case ImmediateMode:
                    return parsedValue;
                default:
                    throw new ArgumentException("Invalid parameter mode");
            }
        }

        public abstract int OpCode { get; }

        public abstract bool Process(int[] data, int[] parameterModes, ref int offset);
    }
}