namespace AdventOfCode.IntCodeComputer.Commands
{
    public class Halt : BaseCommand
    {
        public Halt(IParameterComputer parameterComputer) : base(parameterComputer)
        {
        }

        public override IntCodeValue OpCode => IntCodeValue.FromInt(99);

        public override bool Process(IIntCodeData data, int[] parameterModes, ref IntCodeValue offset)
        {
            return true;
        }
    }
}