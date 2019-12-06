using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._3
{
    public class GridPoint : IEquatable<GridPoint>
    {
        private readonly IDictionary<int, int> _wires = new Dictionary<int, int>();

        public GridPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public int? Steps { get; private set; }

        public void Mark(int wire, int steps)
        {
            if (!_wires.TryGetValue(wire, out var s))
            {
                _wires.Add(wire, steps);
            }
            else
            {
                if (steps < s)
                {
                    _wires[wire] = steps;
                }
            }

            if (_wires.Count > 1)
            {
                Steps = _wires.Values.Sum();
            }
        }

        public bool IsIntersection()
        {
            return Steps.HasValue;
        }

        public bool Equals(GridPoint other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GridPoint) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}