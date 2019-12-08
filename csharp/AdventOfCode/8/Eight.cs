using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._8
{
    public class Eight : BaseRunnable
    {
        public Eight(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Eight() : this(25, 6)
        {
        }

        public int Width { get; }
        public int Height { get; }

        public override string Run(StreamReader reader)
        {
            var layers = ComputeLayers(reader);
            return ComputeAnswer(layers).ToString();
        }

        public int ComputeAnswer(IList<int[]> layers)
        {
            var layer = layers.OrderBy(l => l.Count(digit => digit == 0)).First();
            return layer.Count(digit => digit == 1) * layer.Count(digit => digit == 2);
        }

        public IList<int[]> ComputeLayers(StreamReader input)
        {
            var layerSize = Width * Height;
            var layers = new List<int[]>();
            while (input.Peek() != '\r' && input.Peek() != '\n' && input.Peek() != -1)
            {
                var layer = new int[layerSize];
                FillLayer(input, layer);
                layers.Add(layer);
            }

            return layers;
        }

        private void FillLayer(StreamReader input, int[] layer)
        {
            for (var i = 0; i < layer.Length; i++)
            {
                layer[i] = int.Parse(((char)input.Read()).ToString());
            }
        }
    }
}