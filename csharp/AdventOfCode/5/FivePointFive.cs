using System.Collections.Generic;
using AdventOfCode.IntCodeComputer;

namespace AdventOfCode._5
{
    public class FivePointFive : Five
    {
        public FivePointFive() : base(5)
        {
        }

        public FivePointFive(int input) : base(input)
        {
        }

        protected override IIntCodeProgram CreateIntCodeProgram(Queue<int> input, out Queue<int> output)
        {
            return IntCodeProgram.NewDay5PointFive(input, out output);
        }
    }
}