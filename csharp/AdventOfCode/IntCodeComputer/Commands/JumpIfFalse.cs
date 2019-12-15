namespace AdventOfCode.IntCodeComputer.Commands
{
    public class JumpIfFalse : BaseCommand
    {
        public JumpIfFalse(IParameterComputer parameterComputer) : base(parameterComputer)
        {
        }

        public override IntCodeValue OpCode => IntCodeValue.FromInt(6);

        public override bool Process(IIntCodeData data, int[] parameterModes, ref IntCodeValue offset)
        {
            var parameter1 = ReadData(data, data[offset++], parameterModes, 0);
            var parameter2 = ReadData(data, data[offset++], parameterModes, 1);

            if (parameter1 == IntCodeValue.FromInt(0))
            {
                offset = parameter2;
            }

            return false;
        }
    }
}