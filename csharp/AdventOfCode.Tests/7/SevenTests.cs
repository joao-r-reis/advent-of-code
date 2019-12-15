using System;
using System.IO;
using System.Linq;
using AdventOfCode.IntCodeComputer;
using AdventOfCode._7;
using Xunit;

namespace AdventOfCode.Tests._7
{
    public class SevenTests : IDisposable
    {
        private StreamReader _streamReader;

        [Theory]
        [InlineData(43210, new [] { 4, 3, 2, 1, 0 }, new [] { 3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0 })]
        [InlineData(54321, new[] { 0, 1, 2, 3, 4 }, new[] { 3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0 })]
        [InlineData(65210, new[] { 1, 0, 4, 3, 2 }, new[] { 3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0 })]
        public void Should_ComputeCorrectSignal(int expected, int[] phaseSettings, int[] data)
        {
            var result = new Seven().ComputeSignal(phaseSettings.Select(IntCodeValue.FromInt).ToArray(), data);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(43210, new[] { 3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0 })]
        [InlineData(54321, new[] { 3, 23, 3, 24, 1002, 24, 10, 24, 1002, 23, -1, 23, 101, 5, 23, 23, 1, 24, 23, 23, 4, 23, 99, 0, 0 })]
        [InlineData(65210, new[] { 3, 31, 3, 32, 1002, 32, 10, 32, 1001, 31, -2, 31, 1007, 31, 0, 33, 1002, 33, 7, 33, 1, 33, 31, 31, 1, 32, 31, 31, 4, 31, 99, 0, 0, 0 })]
        public void Should_ComputeCorrectMaxSignal(int expected, int[] data)
        {
            var result = new Seven().ComputeMaxSignal(data);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Should_ParseInputAndComputeCorrectMaxSignal()
        {
            var input = "3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33," +
                        "1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0";
            var expected = "65210";
            _streamReader = StreamHelper.GetStream(input);
            var result = new Seven().Run(_streamReader);
            Assert.Equal(expected, result);
        }

        public void Dispose()
        {
            _streamReader?.Dispose();
        }
    }
}