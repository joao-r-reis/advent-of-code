namespace AdventOfCode.IntCodeComputer.Commands
{
    public class AdjustBase : BaseCommand
    {
        private readonly IAdjustableParameterComputer _parameterComputer;

        public AdjustBase(IAdjustableParameterComputer parameterComputer) : base(parameterComputer)
        {
            _parameterComputer = parameterComputer;
        }

        public override IntCodeValue OpCode => IntCodeValue.FromInt(9);

        public override bool Process(IIntCodeData data, int[] parameterModes, ref IntCodeValue offset)
        {
            var parameter1 = ReadData(data, data[offset++], parameterModes, 0);
            _parameterComputer.AdjustBase(parameter1);
            return false;
        }
    }
}