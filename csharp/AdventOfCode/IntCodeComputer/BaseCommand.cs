namespace AdventOfCode.IntCodeComputer
{
    public abstract class BaseCommand : ICommand
    {
        private readonly IParameterComputer _parameterComputer;

        protected BaseCommand(IParameterComputer parameterComputer)
        {
            _parameterComputer = parameterComputer;
        }

        protected IntCodeValue ReadData(IIntCodeData data, IntCodeValue parsedParameterValue, int[] parameterModes, int parameterIndex)
        {
            return _parameterComputer.FetchParameter(data, parsedParameterValue, GetParameterMode(parameterModes, parameterIndex));
        }

        protected void WriteData(IIntCodeData data, IntCodeValue valueToBeWritten, IntCodeValue parsedParameterValue, int[] parameterModes, int parameterIndex)
        {
            _parameterComputer.WriteParameter(data, valueToBeWritten, parsedParameterValue, GetParameterMode(parameterModes, parameterIndex));
        }

        private int? GetParameterMode(int[] parameterModes, int parameterIndex)
        {
            return parameterIndex >= parameterModes.Length ? (int?)null : parameterModes[parameterIndex];
        }

        public abstract IntCodeValue OpCode { get; }

        public abstract bool Process(IIntCodeData data, int[] parameterModes, ref IntCodeValue offset);
    }
}