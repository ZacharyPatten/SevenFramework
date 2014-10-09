// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seven.Structures
{
  public interface Graph<T> : Structure<T>
  {
    bool Adjacent(T a, T b);

    void Neighbors(T a, Foreach<T> function);

    void Add(T start, T end);

    void Remove(T start, T end);

    void Add(T node);

    void Remove(T node);
  }

  public class Graph_SetQuadtree<T> : Graph<T>
  {
    #region class

    public class Edge
    {
      private T _start;
      private T _end;

      public T Start { get { return this._start; } set { this._start = value; } }
      public T End { get { return this._end; } set { this._end = value; } }

      public Edge(T start, T end)
      {
        this._start = start;
        this._end = end;
      }
    }

    #endregion

    #region field

    public Set_Hash<T> _nodes;
    public Omnitree_Array<Edge, T> _edges;

    #endregion

    #region property

    public int EdgeCount { get { return this._edges.Count; } }
    public int NodeCount { get { return this._nodes.Count; } }

    public int SizeOf { get { throw new System.NotImplementedException(); } }

    #endregion

    #region construct

    private Graph_SetQuadtree(Graph_SetQuadtree<T> graph)
    {
      this._edges = graph._edges.Clone() as Omnitree_Array<Edge, T>;
      this._nodes = graph._nodes.Clone() as Set_Hash<T>;
    }

    public Graph_SetQuadtree(Equate<T> equate, Compare<T> compare, Hash<T> hash, T min, T max, Omnitree.Average<T> average)
    {
      this._nodes = new Set_Hash<T>(equate, hash);
      Omnitree.Locate<Edge, T> locationFunction = (Edge a, out T[] b) => { b = new T[] { a.Start, a.End }; };
      this._edges = new Omnitree_Array<Edge, T>(new T[] { min, min }, new T[] { max, max }, locationFunction, compare, average);
    }

    public Graph_SetQuadtree(Compare<T> compare, Hash<T> hash, T min, T max, Omnitree.Average<T> average)
    {
      this._nodes = new Set_Hash<T>((T a, T b) => { return compare(a, b) == Comparison.Equal; }, hash);
      Omnitree.Locate<Edge, T> locationFunction = (Edge a, out T[] b) => { b = new T[] { a.Start, a.End }; };
      this._edges = new Omnitree_Array<Edge, T>(new T[] { min, min }, new T[] { max, max }, locationFunction, compare, average);
    }

    #endregion

    #region method

    public bool Adjacent(T a, T b)
    {
      bool exists = false;
      this._edges.Foreach((Edge edge) => { exists = true; }, new T[] { a, b }, new T[] { a, b });
      return exists;
    }

    public void Neighbors(T a, Foreach<T> function)
    {
      if (!this._nodes.Contains(a))
        throw new Error("Attempting to look up the neighbors of a node that does not belong to a graph");

      this._edges.Foreach(
          (Edge e) => { function(e.End); },
          new T[] { a, this._edges.Min[1] }, new T[] { a, this._edges.Max[1] });
    }

    public void Add(T start, T end)
    {
      if (!this._nodes.Contains(start))
        throw new Error("Adding an edge to a graph from a node that does not exists");
      if (!this._nodes.Contains(end))
        throw new Error("Adding an edge to a graph to a node that does not exists");
      this._edges.Foreach(
          (Edge e) => { throw new Error("Adding an edge to a graph that already exists"); },
          new T[] { start, end }, new T[] { start, end });

      this._edges.Add(new Edge(start, end));
    }

    public void Remove(T start, T end)
    {
      if (!this._nodes.Contains(start))
        throw new Error("Removing an edge to a graph from a node that does not exists");
      if (!this._nodes.Contains(end))
        throw new Error("Removing an edge to a graph to a node that does not exists");

      bool exists = false;
      this._edges.Foreach(
          (Edge e) => { exists = true; },
          new T[] { start, end }, new T[] { start, end });
      if (!exists)
        throw new Error("Removing a non-existing edge in a graph");

      this._edges.Remove(new T[] { start, end }, new T[] { start, end });
    }

    public void Add(T node)
    {
      if (this._nodes.Contains(node))
        throw new Error("Adding an already-existing node to a graph");

      this._nodes.Add(node);
    }

    public void Remove(T node)
    {
      if (this._nodes.Contains(node))
        throw new Error("Removing non-existing node from a graph");

      this._edges.Remove(new T[] { node, this._edges.Min[1] }, new T[] { node, this._edges.Max[1] });
      this._edges.Remove(new T[] { this._edges.Min[1], node }, new T[] { this._edges.Max[1], node });

      this._nodes.Add(node);
    }

    public void Foreach(Foreach<T> function)
    {
      this._nodes.Foreach(function);
    }

    public void Foreach(ForeachRef<T> function)
    {
      this._nodes.Foreach(function);
    }

    public ForeachStatus Foreach(ForeachBreak<T> function)
    {
      return this._nodes.Foreach(function);
    }

    public ForeachStatus Foreach(ForeachRefBreak<T> function)
    {
      return this._nodes.Foreach(function);
    }

    public void Foreach(Foreach<Edge> function)
    {
      this._edges.Foreach(function);
    }

    public void Foreach(ForeachRef<Edge> function)
    {
      this._edges.Foreach(function);
    }

    public ForeachStatus Foreach(ForeachBreak<Edge> function)
    {
      return this._edges.Foreach(function);
    }

    public ForeachStatus Foreach(ForeachRefBreak<Edge> function)
    {
      return this._edges.Foreach(function);
    }

    public Structure<T> Clone()
    {
      return new Graph_SetQuadtree<T>(this);
    }

    public T[] ToArray()
    {
      throw new System.NotImplementedException();
    }

    System.Collections.IEnumerator
      System.Collections.IEnumerable.GetEnumerator()
    {
      throw new System.NotImplementedException();
    }

    System.Collections.Generic.IEnumerator<T>
      System.Collections.Generic.IEnumerable<T>.GetEnumerator()
    {
      throw new System.NotImplementedException();
    }

    #endregion
  }
}
