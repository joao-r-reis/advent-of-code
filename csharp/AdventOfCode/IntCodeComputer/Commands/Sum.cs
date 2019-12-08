namespace AdventOfCode.IntCodeComputer.Commands
{
    public class Sum : BaseCommand
    {
        public override int OpCode => 1;

        public override bool Process(int[] data, int[] parameterModes, ref int offset)
        {
            var parameter1 = FetchParameter(data, data[offset++], parameterModes, 0);
            var parameter2 = FetchParameter(data, data[offset++], parameterModes, 1);
            data[data[offset++]] = parameter1 + parameter2;
            return false;
        }
    }
}