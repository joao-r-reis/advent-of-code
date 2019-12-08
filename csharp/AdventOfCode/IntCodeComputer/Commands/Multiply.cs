namespace AdventOfCode.IntCodeComputer.Commands
{
    public class Multiply : BaseCommand
    {
        public override int OpCode => 2;

        public override bool Process(int[] data, int[] parameterModes, ref int offset)
        {
            var parameter1 = FetchParameter(data, data[offset++], parameterModes, 0);
            var parameter2 = FetchParameter(data, data[offset++], parameterModes, 1);
            data[data[offset++]] = parameter1 * parameter2;
            return false;
        }
    }
}