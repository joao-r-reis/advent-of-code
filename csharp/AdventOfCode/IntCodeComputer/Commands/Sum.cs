namespace AdventOfCode.IntCodeComputer.Commands
{
    public class Sum : BaseCommand
    {
        public Sum(IParameterComputer parameterComputer) : base(parameterComputer)
        {
        }

        public override IntCodeValue OpCode => IntCodeValue.FromInt(1);

        public override bool Process(IIntCodeData data, int[] parameterModes, ref IntCodeValue offset)
        {
            var parameter1 = ReadData(data, data[offset++], parameterModes, 0);
            var parameter2 = ReadData(data, data[offset++], parameterModes, 1);
            WriteData(data, parameter1 + parameter2, data[offset++], parameterModes, 2);
            return false;
        }
    }
}