using System;
using System.IO;
using System.Linq;

namespace AdventOfCode._2
{
    public class Two : BaseRunnable
    {
        public const int Halt = 99;
        public const int Sum = 1;
        public const int Multiply = 2;
        
        public override string Run(StreamReader reader)
        {
            var data = Parse(reader);
            return ComputeWithInputAndGetOutput(data, 12, 2).ToString();
        }

        private int[] Parse(StreamReader reader)
        {
            var text = reader.ReadToEnd();
            return text.Split(",").Select(int.Parse).ToArray();
        }

        public int ComputeWithInputAndGetOutput(int[] data, int noun, int verb)
        {
            data[1] = noun;
            data[2] = verb;
            return ComputeAndGetOutput(data);
        }

        public int ComputeAndGetOutput(int[] data)
        {
            return Compute(data)[0];
        }

        public int[] Compute(int[] data)
        {
            for (var n = 0; !Compute(data, n); n++)
            {
            }

            return data;
        }

        private bool Compute(int[] data, int n)
        {
            var offset = n * 4;
            var opcode = data[offset];

            if (opcode == Halt)
            {
                return true;
            }

            var input1 = data[offset + 1];
            var input2 = data[offset + 2];
            var output = data[offset + 3];
            Func<int, int, int> func;

            if (opcode == Sum)
            {
                func = (p1, p2) => p1 + p2;
            }
            else if (opcode == Multiply)
            {
                func = (p1, p2) => p1 * p2;
            }
            else
            {
                throw new InvalidOperationException("Invalid opcode detected: " + opcode);
            }

            var result = func(data[input1], data[input2]);
            data[output] = result;

            return false;
        }
    }
}