namespace AdventOfCode.IntCodeComputer.Commands
{
    public class LessThan : BaseCommand
    {
        public LessThan(IParameterComputer parameterComputer) : base(parameterComputer)
        {
        }

        public override IntCodeValue OpCode => IntCodeValue.FromInt(7);

        public override bool Process(IIntCodeData data, int[] parameterModes, ref IntCodeValue offset)
        {
            var parameter1 = ReadData(data, data[offset++], parameterModes, 0);
            var parameter2 = ReadData(data, data[offset++], parameterModes, 1);
            var parsedParameter3 = data[offset++];

            var value = IntCodeValue.FromInt(0);
            if (parameter1 < parameter2)
            {
                value = IntCodeValue.FromInt(1);
            }

            WriteData(data, value, parsedParameter3, parameterModes, 2);

            return false;
        }
    }
}