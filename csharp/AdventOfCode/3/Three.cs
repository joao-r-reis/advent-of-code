using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._3
{
    public class Three : BaseRunnable
    {
        private readonly bool _v2;

        public Three() : this(false)
        {
        }

        protected Three(bool v2)
        {
            _v2 = v2;
        }

        public override string Run(StreamReader reader)
        {
            var (wire1, wire2) = Parse(reader);
            return Process(wire1, wire2).ToString();
        }

        private (string, string) Parse(StreamReader reader)
        {
            return (reader.ReadLine(), reader.ReadLine());
        }
        
        public int Process(string wire1, string wire2)
        {
            var data = new SortedList<int, List<GridPoint>>();
            data = Process(data, wire1, 1);
            data = Process(data, wire2, 2);

            var intersections = data.Skip(1).Where(kvp => kvp.Value.Any(pt => pt.IsIntersection()));

            if (!_v2)
            {
                return intersections.First().Key;
            }

            return intersections
                .Select(kvp => 
                    new KeyValuePair<int, int>(
                        kvp.Key, 
                        kvp.Value.Where(pt => pt.IsIntersection()).Min(pt => pt.Steps.Value))).OrderBy(kvp => kvp.Value)
                .First()
                .Value;
        }

        public SortedList<int, List<GridPoint>> Process(SortedList<int, List<GridPoint>> data, string wire, int wireId)
        {
            var commands = wire.Split(",");

            var x = 0;
            var y = 0;
            var steps = 0;

            foreach (var cmd in commands)
            {
                var deltaX = 0;
                var deltaY = 0;
                var direction = cmd.First();
                var distance = int.Parse(cmd.Substring(1));

                switch (direction)
                {
                    case 'R':
                        deltaX = distance;
                        break;
                    case 'U':
                        deltaY = distance;
                        break;
                    case 'L':
                        deltaX = -1 * distance;
                        break;
                    case 'D':
                        deltaY = -1 * distance;
                        break;
                    default:
                        throw new InvalidOperationException("Invalid direction: " + direction);
                }

                (x, y, steps) = MarkGridPoints(wireId, data, x, y, deltaX, deltaY, steps);
            }

            return data;
        }

        private (int, int, int) MarkGridPoints(int wire, SortedList<int, List<GridPoint>> data, int curX, int curY, int deltaX, int deltaY, int numberSteps)
        {
            var absoluteDeltaX = Math.Abs(deltaX);
            var absoluteDeltaY = Math.Abs(deltaY);
            var multiplierX = deltaX < 0 ? -1 : 1;
            var multiplierY = deltaY < 0 ? -1 : 1;

            for (var i = 0; i < absoluteDeltaX; i++)
            {
                var steps = numberSteps + i;
                var x = curX + i * multiplierX;
                var distance = Math.Abs(x) + Math.Abs(curY);
                if (!data.ContainsKey(distance))
                {
                    data[distance] = new List<GridPoint>();
                }

                var list = data[distance];

                var point = list.SingleOrDefault(p => p.X == x && p.Y == curY);

                if (point == null)
                {
                    point = new GridPoint(x, curY);
                    list.Add(point);
                }

                point.Mark(wire, steps);
            }

            for (var i = 0; i < absoluteDeltaY; i++)
            {
                var steps = numberSteps + i;
                var y = curY + i * multiplierY;
                var distance = Math.Abs(y) + Math.Abs(curX);
                if (!data.ContainsKey(distance))
                {
                    data[distance] = new List<GridPoint>();
                }

                var list = data[distance];

                var point = list.SingleOrDefault(p => p.X == curX && p.Y == y);

                if (point == null)
                {
                    point = new GridPoint(curX, y);
                    list.Add(point);
                }

                point.Mark(wire, steps);
            }

            return (curX + deltaX, curY + deltaY, numberSteps + absoluteDeltaX + absoluteDeltaY);
        }
    }
}