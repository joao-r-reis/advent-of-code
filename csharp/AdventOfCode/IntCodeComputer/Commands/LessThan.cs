namespace AdventOfCode.IntCodeComputer.Commands
{
    public class LessThan : BaseCommand
    {
        public override int OpCode => 7;

        public override bool Process(int[] data, int[] parameterModes, ref int offset)
        {
            var parameter1 = FetchParameter(data, data[offset++], parameterModes, 0);
            var parameter2 = FetchParameter(data, data[offset++], parameterModes, 1);

            var value = 0;
            if (parameter1 < parameter2)
            {
                value = 1;
            }

            data[data[offset++]] = value;

            return false;
        }
    }
}