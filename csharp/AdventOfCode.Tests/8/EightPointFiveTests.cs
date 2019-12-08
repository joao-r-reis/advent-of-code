using System;
using System.Collections.Generic;
using System.IO;

using AdventOfCode._8;

using Xunit;

namespace AdventOfCode.Tests._8
{
    public class EightPointFiveTests
    {
        [Theory]
        [MemberData(nameof(DataV2))]
        public void Should_ComputeAnswerCorrectly(int[] expected, int[][] layers, int width, int height)
        {
            var result = new EightPointFive(new Eight(width, height)).ComputeImage(layers);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> DataV2 =>
            new List<object[]>
            {
                new object[] { new [] { 0, 1, 1, 0}, new[] { new[] { 0, 2, 2, 2 }, new[] { 1, 1, 2, 2 }, new[] { 2, 2, 1, 2 }, new[] { 0, 0, 0, 0 } }, 2, 2 }
            };
    }
}