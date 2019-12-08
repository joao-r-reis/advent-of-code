using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._8
{
    public class EightPointFive : BaseRunnable
    {
        private readonly Eight _eight;

        public EightPointFive() : this(new Eight())
        {
        }

        public EightPointFive(Eight eight)
        {
            _eight = eight;
        }

        public override string Run(StreamReader reader)
        {
            var layers = _eight.ComputeLayers(reader);
            var image = ComputeImage(layers);
            return DrawImage(image);
        }

        public int[] ComputeImage(IList<int[]> layers)
        {
            var layerSize = layers.First().Length;
            var image = new int[layerSize];

            foreach (var i in Enumerable.Range(0, layerSize))
            {
                foreach (var layer in layers)
                {
                    if (layer[i] != 2)
                    {
                        image[i] = layer[i];
                        break;
                    }
                }
            }

            return image;
        }

        public string DrawImage(int[] image)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            for (var i = 0; i < _eight.Height; i++)
            {
                stringBuilder.AppendLine(image.Skip(_eight.Width * i).Take(_eight.Width)
                    .Select(digit => digit.ToString()).Aggregate((acc, str) => $"{acc}{str}"));
            }

            return stringBuilder.ToString().Replace("0", " ");
        }
    }
}