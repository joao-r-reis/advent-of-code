using System;
using System.IO;

using AdventOfCode._6;

using Xunit;

namespace AdventOfCode.Tests._6
{
    public class SixPointFiveTests : IDisposable
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
            "K)L" + Environment.NewLine +
            "K)YOU" + Environment.NewLine +
            "I)SAN";

            _streamReader = StreamHelper.GetStream(input);

            var transfers = new SixPointFive().Run(_streamReader);

            Assert.Equal("4", transfers);
        }

        public void Dispose()
        {
            _streamReader?.Dispose();
        }
    }
}