namespace AdventOfCode.IntCodeComputer.Commands
{
    public class JumpIfFalse : BaseCommand
    {
        public override int OpCode => 6;

        public override bool Process(int[] data, int[] parameterModes, ref int offset)
        {
            var parameter1 = FetchParameter(data, data[offset++], parameterModes, 0);
            var parameter2 = FetchParameter(data, data[offset++], parameterModes, 1);

            if (parameter1 == 0)
            {
                offset = parameter2;
            }

            return false;
        }
    }
}