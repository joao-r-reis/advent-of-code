namespace AdventOfCode.IntCodeComputer
{
    public interface IAdjustableParameterComputer : IParameterComputer
    {
        void AdjustBase(IntCodeValue parameter);
    }
}