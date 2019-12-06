using System.IO;
using System.Linq;

namespace AdventOfCode._4
{
    public class Four : BaseRunnable
    {
        private readonly int _maxAdjacentLength;

        public Four() : this(int.MaxValue) { }

        protected Four(int maxAdjacentLength)
        {
            _maxAdjacentLength = maxAdjacentLength;
        }

        public override string Run(StreamReader reader)
        {
            var (lowerBound, upperBound) = Parse(reader);
            return Compute(lowerBound, upperBound).ToString();
        }

        public bool IsValid(int number)
        {
            var numberStr = number.ToString();
            var previousDigit = -1;
            var currentAdjacentLength = 1;
            var hasAdjacentDuplicates = false;
            for (var index = 0; index < numberStr.Length; index++)
            {
                var digitChar = numberStr[index];
                var digit = int.Parse(digitChar.ToString());

                if (previousDigit == -1)
                {
                    previousDigit = digit;
                    continue;
                }

                if (digit < previousDigit)
                {
                    return false;
                }

                if (digit == previousDigit)
                {
                    currentAdjacentLength++;
                }
                
                if (digit != previousDigit || index == (numberStr.Length - 1))
                {
                    if (currentAdjacentLength > 1 && currentAdjacentLength <= _maxAdjacentLength)
                    {
                        hasAdjacentDuplicates = true;
                    }

                    currentAdjacentLength = 1;
                }

                previousDigit = digit;
            }

            return hasAdjacentDuplicates;
        }
        
        private int Compute(int lowerBound, int upperBound)
        {
            var count = 0;
            for (var number = lowerBound; number <= upperBound; number++)
            {
                if (IsValid(number))
                {
                    count++;
                }
            }

            return count;
        }

        private (int, int) Parse(StreamReader reader)
        {
            var bounds = reader.ReadLine().Split('-').Select(int.Parse);
            return (bounds.First(), bounds.Skip(1).First());
        }
    }
}