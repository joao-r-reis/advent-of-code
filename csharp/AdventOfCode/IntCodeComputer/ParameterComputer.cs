using System;

namespace AdventOfCode.IntCodeComputer
{
    public class ParameterComputer : IAdjustableParameterComputer
    {
        public const int PositionMode = 0;
        public const int ImmediateMode = 1;
        public const int RelativeMode = 2;

        private IntCodeValue _base = IntCodeValue.FromInt(0);
        
        public IntCodeValue FetchParameter(IIntCodeData data, IntCodeValue parsedValue, int? parameterMode)
        {
            var paramModeOrDefault = GetParameterModeOrDefault(parameterMode);
            switch (paramModeOrDefault)
            {
                case PositionMode:
                    return data[parsedValue];
                case ImmediateMode:
                    return parsedValue;
                case RelativeMode:
                    return data[_base + parsedValue];
                default:
                    throw new ArgumentException("Invalid parameter mode");
            }
        }

        public void WriteParameter(IIntCodeData data, IntCodeValue input, IntCodeValue parsedValue, int? parameterMode)
        {
            var paramModeOrDefault = GetParameterModeOrDefault(parameterMode);
            switch (paramModeOrDefault)
            {
                case PositionMode:
                    data[parsedValue] = input;
                    return;
                case ImmediateMode:
                    throw new InvalidOperationException("Writing instructions can't have parameters in immediate mode.");
                case RelativeMode:
                    data[_base + parsedValue] = input;
                    return;
                default:
                    throw new ArgumentException("Invalid parameter mode");
            }
        }

        private int GetParameterModeOrDefault(int? parameterMode)
        {
            return parameterMode ?? ParameterComputer.PositionMode;
        }

        public void AdjustBase(IntCodeValue parameter)
        {
            _base = _base + parameter;
        }
    }
}