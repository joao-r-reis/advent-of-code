using System.Linq;

using AdventOfCode.IntCodeComputer;
using AdventOfCode._2;
using Xunit;

namespace AdventOfCode.Tests._2
{
    public class TwoTests
    {
        [Theory]
        [InlineData(new[] { 1, 0, 0, 0, 99 }, new[] { 2, 0, 0, 0, 99 })]
        [InlineData(new[] { 2, 3, 0, 3, 99 }, new[] { 2, 3, 0, 6, 99 })]
        [InlineData(new[] { 2, 4, 4, 5, 99, 0 }, new[] { 2, 4, 4, 5, 99, 9801 })]
        [InlineData(new[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, new[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 })]
        public void Should_ReturnCorrectResult(int[] data, int[] expected)
        {
            var result = IntCodeProgram.NewDay2().Compute(data);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new[] { 1, 0, 0, 0, 99 }, "2")]
        [InlineData(new[] { 2, 3, 0, 3, 99 }, "2")]
        [InlineData(new[] { 2, 4, 4, 5, 99, 0 }, "2")]
        [InlineData(new[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, "30")]
        public void Should_ReturnFirstElementCorrectly(int[] data, string expected)
        {
            var result = new Two().ComputeAndGetOutput(data);

            Assert.Equal(expected, result.ToString());
        }

        [Fact]
        public void Should_ReturnOutputCorrectly_When_ComputedWithInput()
        {
            var text =
                @"1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,10,1,19,2,19,6,23,2,13,23,27,1,9,27,31,2,31,9,35,1,6,35,39,2,10,39,43,1,5,43,47,1,5,47,51,2,51,6,55,2,10,55,59,1,59,9,63,2,13,63,67,1,10,67,71,1,71,5,75,1,75,6,79,1,10,79,83,1,5,83,87,1,5,87,91,2,91,6,95,2,6,95,99,2,10,99,103,1,103,5,107,1,2,107,111,1,6,111,0,99,2,14,0,0";
            var data = text.Split(",").Select(int.Parse).ToArray();

            var result = new Two().ComputeWithInputAndGetOutput(data, 12, 2);

            Assert.Equal(3716293, result);
        }
    }
}