using System;
using System.IO;

using AdventOfCode._4;

using Xunit;

namespace AdventOfCode.Tests._4
{
    public class FourTests : IDisposable
    {
        private StreamReader _streamReader;

        [Theory]
        [InlineData(true, 111111)]
        [InlineData(true, 122222)]
        [InlineData(false, 223450)]
        [InlineData(false, 123789)]
        [InlineData(true, 123444)]
        public void Should_ComputeIfNumberIsValidCorrectly(bool expected, int number)
        {
            var result = new Four().IsValid(number);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1", "111111-111111")]
        [InlineData("1", "122222-122222")]
        [InlineData("9", "111111-111119")]
        [InlineData("0", "223450-223450")]
        [InlineData("0", "123789-123789")]
        public void Should_ReturnNumberOfValidNumbersCorrectly(string expected, string input)
        {
            _streamReader =
                StreamHelper.GetStream(input);

            var result = new Four().Run(_streamReader);

            Assert.Equal(expected, result);
        }

        public void Dispose()
        {
            _streamReader?.Dispose();
        }
    }
}