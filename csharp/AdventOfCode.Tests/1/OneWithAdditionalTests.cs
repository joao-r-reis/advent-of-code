using System.IO;
using AdventOfCode._1;
using Xunit;

namespace AdventOfCode.Tests._1
{
    public class OneWithAdditionalTests
    {
        [Theory]
        [InlineData(2, 12)]
        [InlineData(966, 1969)]
        [InlineData(50346, 100756)]
        public void Should_ReturnCorrectFuel(int expectedFuel, int mass)
        {
            var fuel = new OnePointFive().ComputeRequiredFuel(mass);
            Assert.Equal(expectedFuel, fuel);
        }

        [Fact]
        public void Should_ReturnCorrectSum()
        {
            var expectedFuel = 2 + 966 + 50346;
            using (var input = new MemoryStream())
            {
                var writer = new StreamWriter(input);
                writer.WriteLine("12");
                writer.WriteLine("1969");
                writer.WriteLine("100756");
                writer.Flush();

                input.Seek(0, SeekOrigin.Begin);

                var fuel = new OnePointFive().Run(new StreamReader(input));

                Assert.Equal(expectedFuel, fuel);
            }
        }
    }
}
