using System;
using System.IO;

using AdventOfCode._5;

using Xunit;

namespace AdventOfCode.Tests._5
{
    public class FiveTests : IDisposable
    {
        private StreamReader _streamReader;

        [Theory]
        [InlineData("1101,100,-1,4,0", "null")]
        public void Should_ReturnCorrectResult(string input, string expected)
        {
            _streamReader = StreamHelper.GetStream(input);
            var result = new Five().Run(_streamReader);
            Assert.Equal(expected, result);
        }

        public void Dispose()
        {
            _streamReader?.Dispose();
        }
    }
}