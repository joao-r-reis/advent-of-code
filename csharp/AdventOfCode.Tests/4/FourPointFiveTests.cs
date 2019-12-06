using System;
using System.IO;

using AdventOfCode._4;

using Xunit;

namespace AdventOfCode.Tests._4
{
    public class FourPointFiveTests : IDisposable
    {
        private StreamReader _streamReader;

        [Theory]
        [InlineData(true, 112233)]
        [InlineData(false, 123444)]
        [InlineData(true, 111122)]
        public void Should_ComputeIfNumberIsValidCorrectly(bool expected, int number)
        {
            var result = new FourPointFive().IsValid(number);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1", "112233-112233")]
        [InlineData("0", "123444-123444")]
        [InlineData("1", "111122-111122")]
        public void Should_ReturnNumberOfValidNumbersCorrectly(string expected, string input)
        {
            _streamReader =
                StreamHelper.GetStream(input);

            var result = new FourPointFive().Run(_streamReader);

            Assert.Equal(expected, result);
        }

        public void Dispose()
        {
            _streamReader?.Dispose();
        }
    }
}