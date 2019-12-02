using System;
using System.IO;
using AdventOfCode._1;
using Xunit;

namespace AdventOfCode.Tests._1
{
    public class OnePointFiveTests : IDisposable
    {
        private StreamReader _streamReader;

        [Theory]
        [InlineData(2, 12)]
        [InlineData(966, 1969)]
        [InlineData(50346, 100756)]
        public void Should_ReturnCorrectFuel(int expectedFuel, int mass)
        {
            var fuel = new OnePointFive().ComputeRequiredFuel(mass);
            Assert.Equal(expectedFuel, fuel);
        }

        [Fact]
        public void Should_ReturnCorrectSum()
        {
            var expectedFuel = 2 + 966 + 50346;
            _streamReader = StreamHelper.GetStream("12", "1969", "100756");

            var fuel = new OnePointFive().Run(_streamReader);

            Assert.Equal(expectedFuel.ToString(), fuel);
        }

        public void Dispose()
        {
            _streamReader?.Dispose();
            _streamReader = null;
        }
    }
}
