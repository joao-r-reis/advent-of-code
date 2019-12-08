using System;
using System.Collections.Generic;

namespace AdventOfCode._6
{
    public class Vertex : IEquatable<Vertex>
    {
        private readonly ISet<Vertex> _outEdges = new HashSet<Vertex>();

        public Vertex(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public int Weight { get; private set; } = -1;

        public bool IsWeighted() => Weight != -1;

        public void AddOutEdge(Vertex v)
        {
            _outEdges.Add(v);

            if (v.InEdge != null)
            {
                throw new InvalidOperationException("vertex already has a inEdge");
            }

            v.InEdge = this;
        }

        public IEnumerable<Vertex> GetOutEdges()
        {
            return _outEdges;
        }

        public Vertex InEdge { get; private set; } = null;

        public void SetWeight(int weight)
        {
            if (weight < 0)
            {
                throw new ArgumentException("weight can't be negative: " + weight);
            }

            Weight = weight;
        }

        public bool Equals(Vertex other)
        {
            return string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Vertex)obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }
    }
}