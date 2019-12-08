namespace AdventOfCode.IntCodeComputer.Commands
{
    public class Halt : BaseCommand
    {
        public override int OpCode => 99;

        public override bool Process(int[] data, int[] parameterModes, ref int offset)
        {
            return true;
        }
    }
}