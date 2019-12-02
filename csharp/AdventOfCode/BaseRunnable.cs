using System.IO;

namespace AdventOfCode
{
    public abstract class BaseRunnable : IRunnable
    {
        public string Run(string[] args)
        {
            using (var input = File.OpenText(args[1]))
            {
                return Run(input);
            }
        }

        public abstract string Run(StreamReader reader);
    }
}