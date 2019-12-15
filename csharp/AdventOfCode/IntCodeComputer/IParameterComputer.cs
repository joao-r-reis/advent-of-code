namespace AdventOfCode.IntCodeComputer
{
    public interface IParameterComputer
    {
        IntCodeValue FetchParameter(IIntCodeData data, IntCodeValue parsedValue, int? parameterMode);

        void WriteParameter(IIntCodeData data, IntCodeValue input, IntCodeValue parsedValue, int? parameterMode);
    }
}