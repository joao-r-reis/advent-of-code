using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._6
{
    public class Six : BaseRunnable
    {
        private const string RootVertexId = "COM";

        public override string Run(StreamReader reader)
        {
            var tree = BuildTree(reader);
            ComputeWeights(tree);
            return ComputeWeightSum(tree).ToString();
        }

        public int ComputeWeightSum(IDictionary<string, Vertex> tree)
        {
            return tree.Values.Sum(v => v.Weight);
        }

        public void ComputeWeights(IDictionary<string, Vertex> tree)
        {
            ICollection<Vertex> currentLevelVertices = new List<Vertex> { tree[RootVertexId] };
            var level = 0;
            while (currentLevelVertices.Count > 0)
            {
                currentLevelVertices = SetWeights(currentLevelVertices, level);
                level++;
            }
        }

        private ICollection<Vertex> SetWeights(IEnumerable<Vertex> currentLevelVertices, int level)
        {
            var nextLevelVertices = new List<Vertex>();
            foreach (var vertex in currentLevelVertices)
            {
                vertex.SetWeight(level);
                nextLevelVertices.AddRange(vertex.GetOutEdges());
            }

            return nextLevelVertices;
        }

        public IDictionary<string, Vertex> BuildTree(StreamReader reader)
        {
            var tree = new Dictionary<string, Vertex>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var (parentBody, satellite) = Parse(line);
                FillTree(tree, parentBody, satellite);
            }

            return tree;
        }

        public void FillTree(IDictionary<string, Vertex> tree, string parentBody, string satellite)
        {
            if (!tree.ContainsKey(satellite))
            {
                tree.Add(satellite, new Vertex(satellite));
            }

            if (!tree.ContainsKey(parentBody))
            {
                tree.Add(parentBody, new Vertex(parentBody));
            }

            var satelliteVertex = tree[satellite];
            var parentBodyVertex = tree[parentBody];

            parentBodyVertex.AddOutEdge(satelliteVertex);
        }

        private (string parentBody, string satellite) Parse(string line)
        {
            var split = line.Split(')');
            return (split.First(), split.Skip(1).First());
        }
    }
}