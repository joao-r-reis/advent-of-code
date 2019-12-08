using System;
using System.IO;

using AdventOfCode._7;
using Xunit;

namespace AdventOfCode.Tests._7
{
    public class SevenPointFiveTests : IDisposable
    {
        private StreamReader _streamReader;

        [Theory]
        [InlineData(139629729, new [] { 9, 8, 7, 6, 5 }, new [] { 3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5 })]
        [InlineData(18216, new[] { 9, 7, 8, 5, 6 }, new[] { 3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,-5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10 })]
        public void Should_ComputeCorrectSignal(int expected, int[] phaseSettings, int[] data)
        {
            var result = new SevenPointFive().ComputeSignal(phaseSettings, data);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(139629729, new[] { 3, 26, 1001, 26, -4, 26, 3, 27, 1002, 27, 2, 27, 1, 27, 26, 27, 4, 27, 1001, 28, -1, 28, 1005, 28, 6, 99, 0, 0, 5 })]
        [InlineData(18216, new[] { 3, 52, 1001, 52, -5, 52, 3, 53, 1, 52, 56, 54, 1007, 54, 5, 55, 1005, 55, 26, 1001, 54, -5, 54, 1105, 1, 12, 1, 53, 54, 53, 1008, 54, 0, 55, 1001, 55, 1, 55, 2, 53, 55, 53, 4, 53, 1001, 56, -1, 56, 1005, 56, 6, 99, 0, 0, 0, 0, 10 })]
        public void Should_ComputeCorrectMaxSignal(int expected, int[] data)
        {
            var result = new SevenPointFive().ComputeMaxSignal(data);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Should_ParseInputAndComputeCorrectMaxSignal()
        {
            var input = "3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5";
            var expected = "139629729";
            _streamReader = StreamHelper.GetStream(input);
            var result = new SevenPointFive().Run(_streamReader);
            Assert.Equal(expected, result);
        }

        public void Dispose()
        {
            _streamReader?.Dispose();
        }
    }
}