namespace AdventOfCode.IntCodeComputer.Commands
{
    public class Multiply : BaseCommand
    {
        public Multiply(IParameterComputer parameterComputer) : base(parameterComputer)
        {
        }

        public override IntCodeValue OpCode => IntCodeValue.FromInt(2);

        public override bool Process(IIntCodeData data, int[] parameterModes, ref IntCodeValue offset)
        {
            var parameter1 = ReadData(data, data[offset++], parameterModes, 0);
            var parameter2 = ReadData(data, data[offset++], parameterModes, 1);
            WriteData(data, parameter1 * parameter2, data[offset++], parameterModes, 2);
            return false;
        }
    }
}