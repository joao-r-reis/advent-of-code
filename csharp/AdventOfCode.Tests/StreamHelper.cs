using System.IO;

namespace AdventOfCode.Tests
{
    internal static class StreamHelper
    {
        public static StreamReader GetStream(params string[] lines)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            foreach (var line in lines)
            {
                writer.WriteLine(line);
            }

            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            return new StreamReader(stream);
        }

        public static StreamReader GetStream(string text)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            return new StreamReader(stream);
        }
    }
}