using System;
using System.IO;

using AdventOfCode._6;

using Xunit;

namespace AdventOfCode.Tests._6
{
    public class SixTests : IDisposable
    {
        private StreamReader _streamReader;

        [Fact]
        public void Should_ComputeWeightSumCorrectly()
        {
            var input =
            "COM)B" + Environment.NewLine +
            "B)C" + Environment.NewLine +
            "C)D" + Environment.NewLine +
            "D)E" + Environment.NewLine +
            "E)F" + Environment.NewLine +
            "B)G" + Environment.NewLine +
            "G)H" + Environment.NewLine +
            "D)I" + Environment.NewLine +
            "E)J" + Environment.NewLine +
            "J)K" + Environment.NewLine +
            "K)L";

            _streamReader = StreamHelper.GetStream(input);

            var sum = new Six().Run(_streamReader);

            Assert.Equal("42", sum);
        }

        public void Dispose()
        {
            _streamReader?.Dispose();
        }
    }
}