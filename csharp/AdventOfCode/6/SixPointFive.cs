using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace AdventOfCode._6
{
    public class SixPointFive : BaseRunnable
    {
        private const string YouVertexId = "YOU";
        private const string SantaVertexId = "SAN";

        public override string Run(StreamReader reader)
        {
            var six = new Six();
            var tree = six.BuildTree(reader);
            six.ComputeWeights(tree);
            return GetMinimumTransfer(tree[YouVertexId].InEdge, tree[SantaVertexId].InEdge).ToString();
        }

        public int GetMinimumTransfer(Vertex v1, Vertex v2)
        {
            var commonVertices = GetPathToRoot(v1).Intersect(GetPathToRoot(v2));
            var closestCommonVertex = commonVertices.OrderByDescending(v => v.Weight).First();
            return (v1.Weight - closestCommonVertex.Weight) + (v2.Weight - closestCommonVertex.Weight);
        }

        private IEnumerable<Vertex> GetPathToRoot(Vertex v)
        {
            var path = new List<Vertex>();
            var currentVertex = v;
            while ((currentVertex = currentVertex.InEdge) != null)
            {
                path.Add(currentVertex);
            }

            return path;
        }
    }
}