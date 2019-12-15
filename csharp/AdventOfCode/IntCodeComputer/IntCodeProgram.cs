using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

using AdventOfCode.IntCodeComputer.Commands;

namespace AdventOfCode.IntCodeComputer
{
    public class IntCodeProgram : IIntCodeProgram
    {
        private readonly Dictionary<IntCodeValue, ICommand> _commands;

        public static IIntCodeProgram New()
        {
            return New(new BlockingCollection<IntCodeValue>(), new BlockingCollection<IntCodeValue>());
        }

        public static IIntCodeProgram New(BlockingCollection<IntCodeValue> input)
        {
            return New(input, new BlockingCollection<IntCodeValue>());
        }

        public static IIntCodeProgram New(BlockingCollection<IntCodeValue> input, BlockingCollection<IntCodeValue> output)
        {
            var parameterComputer = new ParameterComputer();
            return new IntCodeProgram(
                new Halt(parameterComputer),
                new Multiply(parameterComputer),
                new Sum(parameterComputer),
                new Input(parameterComputer, input),
                new Output(parameterComputer, output),
                new JumpIfFalse(parameterComputer),
                new JumpIfTrue(parameterComputer),
                new LessThan(parameterComputer),
                new Equals(parameterComputer),
                new AdjustBase(parameterComputer));
        }

        private IntCodeProgram(params ICommand[] commands)
        {
            Output = ((Output)commands.SingleOrDefault(cmd => cmd is Output))?.OutputQueue;
            _commands = commands.ToDictionary(cmd => cmd.OpCode, cmd => cmd);
        }

        public BlockingCollection<IntCodeValue> Output { get; }

        public int[] Compute(int[] data)
        {
            var result = Compute(IntCodeData.FromIntArray(data));
            return result.GetAll().Select(n => (int)n.Value).ToArray();
        }

        public IIntCodeData Compute(IIntCodeData data)
        {
            var n = IntCodeValue.FromInt(0);
            while (!Compute(data, ref n))
            {
            }

            return data;
        }

        private bool Compute(IIntCodeData data, ref IntCodeValue offset)
        {
            var parsedOpCode = data[offset].ToString();
            var opCodeLength = parsedOpCode.Length < 2 ? parsedOpCode.Length : 2;
            var opcode =
                opCodeLength == parsedOpCode.Length
                    ? IntCodeValue.Parse(parsedOpCode)
                    : IntCodeValue.Parse(parsedOpCode.Substring(parsedOpCode.Length - opCodeLength, opCodeLength));
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

    public struct IntCodeValue : IEquatable<IntCodeValue>, IFormattable, IComparable, IComparable<IntCodeValue>
    {
        private readonly BigInteger _value;

        private IntCodeValue(BigInteger integer)
        {
            _value = integer;
        }

        public static IntCodeValue FromInt(int val)
        {
            return new IntCodeValue(val);
        }

        public static IntCodeValue FromBigInteger(BigInteger val)
        {
            return new IntCodeValue(val);
        }

        public static IntCodeValue Parse(string value)
        {
            return new IntCodeValue(BigInteger.Parse(value));
        }

        public static IntCodeValue operator ++(IntCodeValue val)
        {
            return new IntCodeValue(val._value + 1);
        }

        public static IntCodeValue operator +(IntCodeValue left, IntCodeValue right)
        {
            return new IntCodeValue(left._value + right._value);
        }

        public static IntCodeValue operator *(IntCodeValue left, IntCodeValue right)
        {
            return new IntCodeValue(left._value * right._value);
        }

        public static explicit operator int(IntCodeValue value)
        {
            return (int)value._value;
        }

        public static bool operator <(IntCodeValue left, IntCodeValue right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(IntCodeValue left, IntCodeValue right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(IntCodeValue left, IntCodeValue right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(IntCodeValue left, IntCodeValue right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static bool operator ==(IntCodeValue left, IntCodeValue right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(IntCodeValue left, IntCodeValue right)
        {
            return !left.Equals(right);
        }

        public bool Equals(IntCodeValue other)
        {
            return _value.Equals(other._value);
        }

        public int CompareTo(IntCodeValue other)
        {
            return _value.CompareTo(other._value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is IntCodeValue other && Equals(other);
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return _value.ToString(format, formatProvider);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;
            if (!(obj is IntCodeValue))
                throw new ArgumentException("obj must be of type IntCodeValue");
            return this.CompareTo((IntCodeValue)obj);
        }
    }

    public class IntCodeData : IIntCodeData
    {
        private readonly IDictionary<IntCodeValue, IntCodeValue> _dictionary;

        private IntCodeData(IDictionary<IntCodeValue, IntCodeValue> data)
        {
            _dictionary = data;
        }

        public static IIntCodeData FromIntArray(int[] data)
        {
            var d = data.Select((value, index) => new KeyValuePair<IntCodeValue, IntCodeValue>(IntCodeValue.FromInt(index), IntCodeValue.FromInt(value)))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            return new IntCodeData(d);
        }

        public static IIntCodeData FromBigIntArray(BigInteger[] data)
        {
            var d = data.Select((value, index) => new KeyValuePair<IntCodeValue, IntCodeValue>(IntCodeValue.FromInt(index), IntCodeValue.FromBigInteger(value)))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            return new IntCodeData(d);
        }

        public static IIntCodeData FromIntCodeValueArray(IntCodeValue[] data)
        {
            var d = data.Select((value, index) => new KeyValuePair<IntCodeValue, IntCodeValue>(IntCodeValue.FromInt(index), value))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            return new IntCodeData(d);
        }

        public static IIntCodeData FromStreamReader(StreamReader stream)
        {
            var text = stream.ReadToEnd();
            var data = text.Split(",").Select(IntCodeValue.Parse).ToArray();
            return FromIntCodeValueArray(data);
        }

        public IEnumerable<KeyValuePair<IntCodeValue, IntCodeValue>> GetAll()
        {
            return _dictionary.OrderBy(kvp => kvp.Key);
        }

        public IntCodeValue Get(IntCodeValue key)
        {
            return _dictionary[key];
        }

        public void Set(IntCodeValue key, IntCodeValue value)
        {
            _dictionary[key] = value;
        }

        public IntCodeValue this[IntCodeValue i]
        {
            get => _dictionary.TryGetValue(i, out var value) ? value : IntCodeValue.FromInt(0);
            set => _dictionary[i] = value;
        }
    }

    public interface IIntCodeData
    {
        IEnumerable<KeyValuePair<IntCodeValue, IntCodeValue>> GetAll();

        IntCodeValue Get(IntCodeValue key);

        void Set(IntCodeValue key, IntCodeValue value);

        IntCodeValue this[IntCodeValue i] { get; set; }
    }
}