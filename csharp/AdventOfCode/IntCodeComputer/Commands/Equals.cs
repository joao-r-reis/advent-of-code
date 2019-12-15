namespace AdventOfCode.IntCodeComputer.Commands
{
    public class Equals : BaseCommand
    {
        public Equals(IParameterComputer parameterComputer) : base(parameterComputer)
        {
        }

        public override IntCodeValue OpCode => IntCodeValue.FromInt(8);

        public override bool Process(IIntCodeData data, int[] parameterModes, ref IntCodeValue offset)
        {
            var parameter1 = ReadData(data, data[offset++], parameterModes, 0);
            var parameter2 = ReadData(data, data[offset++], parameterModes, 1);

            var value = IntCodeValue.FromInt(0);
            if (parameter1 == parameter2)
            {
                value = IntCodeValue.FromInt(1);
            }

            WriteData(data, value, data[offset++], parameterModes, 2);

            return false;
        }
    }
}