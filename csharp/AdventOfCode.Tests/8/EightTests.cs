using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using AdventOfCode._8;
using Xunit;

namespace AdventOfCode.Tests._8
{
    public class EightTests : IDisposable
    {
        private StreamReader _streamReader;

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_CreateLayersCorrectly(int[][] expected, string input, int width, int height)
        {
            _streamReader = StreamHelper.GetStream(input);
            var result = new Eight(width, height).ComputeLayers(_streamReader);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { new [] { new [] { 1,2,3,4,5,6 }, new [] { 7,8,9,0,1,2 }}, "123456789012", 3, 2 },
                new object[] { new [] { new [] { 0,2,2,2 }, new [] { 1,1,2,2 }, new [] { 2,2,1,2 }, new [] { 0,0,0,0 }}, "0222112222120000", 2, 2 }
            };

        [Theory]
        [MemberData(nameof(DataV2))]
        public void Should_ComputeAnswerCorrectly(string expected, string input, int width, int height)
        {
            _streamReader = StreamHelper.GetStream(input);
            var result = new Eight(width, height).Run(_streamReader);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> DataV2 =>
            new List<object[]>
            {
                new object[] { "1", "123456789012", 3, 2 }
            };

        public void Dispose()
        {
            _streamReader?.Dispose();
        }
    }
}