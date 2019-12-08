using System;
using System.IO;

using AdventOfCode._5;

using Xunit;

namespace AdventOfCode.Tests._5
{
    public class FivePointFiveTests : IDisposable
    {
        private StreamReader _streamReader;

        [Theory]
        [InlineData("999", 7)]
        [InlineData("999", 6)]
        [InlineData("999", 2)]
        [InlineData("999", 0)]
        [InlineData("1000", 8)]
        [InlineData("1001", 9)]
        [InlineData("1001", 100)]
        [InlineData("1001", 2000)]
        public void Should_ReturnCorrectResult(string expected, int input)
        {
            var program = "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31," +
                        "1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104," +
                        "999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99";

            _streamReader = StreamHelper.GetStream(program);
            var result = new FivePointFive(input).Run(_streamReader);
            Assert.Equal(expected, result);
        }

        public void Dispose()
        {
            _streamReader?.Dispose();
        }
    }
}