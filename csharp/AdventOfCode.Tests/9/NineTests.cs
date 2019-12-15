using System;
using System.IO;
using System.Linq;
using System.Numerics;
using AdventOfCode.IntCodeComputer;
using AdventOfCode._9;
using Xunit;

namespace AdventOfCode.Tests._9
{
    public class NineTests : IDisposable
    {
        private StreamReader _streamReader;

        [Theory]
        [InlineData(new[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 }, new[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 })]
        public void Should_ComputeCorrectSignal(int[] expected, int[] data)
        {
            var program = IntCodeProgram.New();
            program.Compute(data);
            Assert.Equal(expected, program.Output.Select(val => (int)val).ToArray());
        }

        [Fact]
        public void Should_Output16DigitNumber()
        {
            var data = new int[] {1102, 34915192, 34915192, 7, 4, 7, 99, 0};
            var program = IntCodeProgram.New();
            program.Compute(IntCodeData.FromIntArray(data));
            var number = program.Output.Single();
            Assert.Equal(16, number.ToString().Length);
        }

        [Fact]
        public void Should_OutputLargeNumberInTheMiddle()
        {
            var data = new BigInteger[] { 104, 1125899906842624, 99 };
            var program = IntCodeProgram.New();
            program.Compute(IntCodeData.FromBigIntArray(data));
            var number = program.Output.Single();
            Assert.Equal(IntCodeValue.FromBigInteger(data[1]), number);
        }

        //[Theory]
        //[InlineData(43210, new[] { 3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0 })]
        //[InlineData(54321, new[] { 3, 23, 3, 24, 1002, 24, 10, 24, 1002, 23, -1, 23, 101, 5, 23, 23, 1, 24, 23, 23, 4, 23, 99, 0, 0 })]
        //[InlineData(65210, new[] { 3, 31, 3, 32, 1002, 32, 10, 32, 1001, 31, -2, 31, 1007, 31, 0, 33, 1002, 33, 7, 33, 1, 33, 31, 31, 1, 32, 31, 31, 4, 31, 99, 0, 0, 0 })]
        //public void Should_ComputeCorrectMaxSignal(int expected, int[] data)
        //{
        //    var result = new Nine().ComputeMaxSignal(data);
        //    Assert.Equal(expected, result);
        //}

        //[Fact]
        //public void Should_ParseInputAndComputeCorrectMaxSignal()
        //{
        //    var input = "3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33," +
        //                "1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0";
        //    var expected = "65210";
        //    _streamReader = StreamHelper.GetStream(input);
        //    var result = new Nine().Run(_streamReader);
        //    Assert.Equal(expected, result);
        //}

        public void Dispose()
        {
            _streamReader?.Dispose();
        }
    }
}