using System;
using System.IO;
using AdventOfCode._1;

using Xunit;

namespace AdventOfCode.Tests._1
{
    public class OneTests : IDisposable
    {
        private StreamReader _streamReader;

        [Theory]
        [InlineData(2, 12)]
        [InlineData(2, 14)]
        [InlineData(654, 1969)]
        [InlineData(33583, 100756)]
        public void Should_ReturnCorrectFuel(int expectedFuel, int mass)
        {
            var fuel = new One().ComputeRequiredFuel(mass);
            Assert.Equal(expectedFuel, fuel);
        }

        [Fact]
        public void Should_ReturnCorrectSum()
        {
            var expectedFuel = 2 + 2 + 654 + 33583;
            _streamReader = StreamHelper.GetStream("12", "14", "1969", "100756");

            var fuel = new One().Run(_streamReader);

            Assert.Equal(expectedFuel.ToString(), fuel);
        }

        public void Dispose()
        {
            _streamReader?.Dispose();
            _streamReader = null;
        }
    }
}