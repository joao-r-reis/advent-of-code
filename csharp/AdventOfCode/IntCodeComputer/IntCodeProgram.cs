using System.Collections.Generic;
using System.Linq;
using AdventOfCode.IntCodeComputer.Commands;

namespace AdventOfCode.IntCodeComputer
{
    public class IntCodeProgram : IIntCodeProgram
    {
        private readonly Dictionary<int, ICommand> _commands;

        public static IIntCodeProgram NewDay2()
        {
            return new IntCodeProgram(new Halt(), new Multiply(), new Sum());
        }

        public static IIntCodeProgram NewDay5(Queue<int> input, out Queue<int> output)
        {
            var outputCmd = new Output();
            output = outputCmd.OutputQueue;
            return new IntCodeProgram(
                new Halt(), new Multiply(), new Sum(), new Input(input), outputCmd);
        }

        public static IIntCodeProgram NewDay5PointFive(Queue<int> input, out Queue<int> output)
        {
            var outputCmd = new Output();
            output = outputCmd.OutputQueue;
            return new IntCodeProgram(
                new Halt(), new Multiply(), new Sum(), new Input(input), outputCmd, new JumpIfFalse(), new JumpIfTrue(), new LessThan(), new Equals());
        }

        private IntCodeProgram(params ICommand[] commands)
        {
            _commands = commands.ToDictionary(cmd => cmd.OpCode, cmd => cmd);
        }

        public int[] Compute(int[] data)
        {
            var n = 0;
            while (!Compute(data, ref n))
            {
            }

            return data;
        }

        private bool Compute(int[] data, ref int offset)
        {
            var parsedOpCode = data[offset].ToString();
            var opCodeLength = parsedOpCode.Length < 2 ? parsedOpCode.Length : 2;
            var opcode = 
                opCodeLength == parsedOpCode.Length 
                    ? int.Parse(parsedOpCode)
                    : int.Parse(parsedOpCode.Substring(parsedOpCode.Length - opCodeLength, opCodeLength));
            var parameterModes = parsedOpCode.Length <= 2
                ? new int[0] :
                parsedOpCode
                    .Substring(0, parsedOpCode.Length - opCodeLength)
                    .Select(c => int.Parse(c.ToString()))
                    .Reverse()
                    .ToArray();
            offset++;

            var cmd = _commands[opcode];

            return cmd.Process(data, parameterModes, ref offset);
        }
    }
}