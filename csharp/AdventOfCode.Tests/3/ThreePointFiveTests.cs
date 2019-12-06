using System;
using System.IO;

using AdventOfCode._3;

using Xunit;

namespace AdventOfCode.Tests._3
{
    public class ThreePointFiveTests : IDisposable
    {
        private StreamReader _streamReader;

        [Theory]
        [InlineData(610, "R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83")]
        [InlineData(410, "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7")]
        public void Should_ReturnCorrectResult(int expected, string wire1, string wire2)
        {
            var result = new ThreePointFive().Process(wire1, wire2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Should_ReturnOutputCorrectly_When_ComputedWithInput()
        {
            _streamReader =
                StreamHelper.GetStream(@"R75,D30,R83,U83,L12,D49,R71,U7,L72", @"U62,R66,U55,R34,D71,R55,D58,R83");

            var result = new ThreePointFive().Run(_streamReader);

            Assert.Equal("610", result);
        }

        public void Dispose()
        {
            _streamReader?.Dispose();
        }
    }
}