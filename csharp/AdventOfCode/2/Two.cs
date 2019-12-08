using System.IO;
using System.Linq;
using AdventOfCode.IntCodeComputer;

namespace AdventOfCode._2
{
    public class Two : BaseRunnable
    {
        public override string Run(StreamReader reader)
        {
            var data = Parse(reader);
            return ComputeWithInputAndGetOutput(data, 12, 2).ToString();
        }

        private int[] Parse(StreamReader reader)
        {
            var text = reader.ReadToEnd();
            return text.Split(",").Select(int.Parse).ToArray();
        }

        public int ComputeWithInputAndGetOutput(int[] data, int noun, int verb)
        {
            data[1] = noun;
            data[2] = verb;
            return ComputeAndGetOutput(data);
        }

        public int ComputeAndGetOutput(int[] data)
        {
            return IntCodeProgram.NewDay2().Compute(data)[0];
        }
    }
}