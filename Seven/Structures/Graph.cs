﻿// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Structures
{
  public interface Graph<T> : Structure<T>
  {
    /// <summary>Checks if b is adjacent to a.</summary>
    /// <param name="a">The starting point of the edge to check.</param>
    /// <param name="b">The ending point of the edge to check.</param>
    /// <returns>True if b is adjacent to a; False if not</returns>
    bool Adjacent(T a, T b);

    /// <summary>Gets all the nodes adjacent to a and performs the provided delegate on each.</summary>
    /// <param name="a">The node to find all the adjacent node to.</param>
    /// <param name="function">The delegate to perform on each adjacent node to a.</param>
    void Neighbors(T a, Foreach<T> function);

    /// <summary>Adds an edge to the graph starting at a and ending at b.</summary>
    /// <param name="start">The stating point of the edge to add.</param>
    /// <param name="end">The ending point of the edge to add.</param>
    void Add(T start, T end);

    /// <summary>Removes an edge from the graph.</summary>
    /// <param name="start">The starting point of the edge to remove.</param>
    /// <param name="end">The ending point of the edge to remove.</param>
    void Remove(T start, T end);

    /// <summary>Adds a node to the graph.</summary>
    /// <param name="node">The node to add to the graph.</param>
    void Add(T node);

    /// <summary>Removes a node from the graph and all the edges associated with that node.</summary>
    /// <param name="node">The node to be removed and have all its edges removed.</param>
    void Remove(T node);
  }

  /// <summary>Contains extensions for generic Graphs.</summary>
  public static class Graph
  {
    // none currently
  }

  /// <summary>Stores the graph as a set-hash of nodes and quadtree of edges.</summary>
  /// <typeparam name="T">The generic type of this data structure.</typeparam>
  public class Graph_SetOmnitree<T> : Graph<T>
  {
    #region class

    /// <summary>Represents an edge in a graph.</summary>
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

    private Graph_SetOmnitree(Graph_SetOmnitree<T> graph)
    {
      this._edges = graph._edges.Clone() as Omnitree_Array<Edge, T>;
      this._nodes = graph._nodes.Clone() as Set_Hash<T>;
    }

    public Graph_SetOmnitree(Equate<T> equate, Compare<T> compare, Hash<T> hash, T min, T max, Omnitree.Average<T> average)
    {
      this._nodes = new Set_Hash<T>(equate, hash);
      Omnitree.Locate<Edge, T> locationFunction = (Edge a, out T[] b) => { b = new T[] { a.Start, a.End }; };
      this._edges = new Omnitree_Array<Edge, T>(new T[] { min, min }, new T[] { max, max }, locationFunction, compare, average);
    }

    public Graph_SetOmnitree(Compare<T> compare, Hash<T> hash, T min, T max, Omnitree.Average<T> average)
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
      return new Graph_SetOmnitree<T>(this);
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

  /// <summary>Stores a graph as a map and nested map (adjacency matrix).</summary>
  /// <typeparam name="T">The generic node type of this graph.</typeparam>
  public class Graph_Map<T> : Graph<T>
  {
    #region class

    /// <summary>Represents an edge in a graph.</summary>
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

    public Map<Map<bool, T>, T> _map;
    int _edges;

    #endregion

    #region property

    public int EdgeCount { get { return this._edges; } }
    public int NodeCount { get { return this._map.Count; } }

    public int SizeOf { get { throw new System.NotImplementedException(); } }

    #endregion

    #region construct

    private Graph_Map(Equate<T> equate, Hash<T> hash, Graph_SetOmnitree<T> graph)
    {
      this._edges = 0;
      this._map = new Map_Linked<Map<bool, T>, T>(equate, hash);
    }

    #endregion

    #region method

    public bool Adjacent(T a, T b)
    {
      bool temp_bool;
      Map<bool, T> temp_map;
      if (this._map.TryGet(a, out temp_map))
        if (temp_map.TryGet(a, out temp_bool))
          return temp_bool;
      return false;
    }

    public void Neighbors(T a, Foreach<T> function)
    {
      throw new System.NotImplementedException();
    }

    /// <summary>Adds an edge to the graph.</summary>
    /// <param name="start">The starting point of the edge.</param>
    /// <param name="end">The ending point of the edge.</param>
    public void Add(T start, T end)
    {
#if no_error_checking
      // nothing
#else
      if (!this._map.Contains(start))
        throw new Error("Adding an edge to a non-existing starting node.");
      if (!this._map[start].Contains(end))
        throw new Error("Adding an edge to a non-existing ending node.");
#endif

      if (this._map[start] == null)
        this._map[start] = new Map_Linked<bool, T>(this._map.Equate, this._map.Hash);

      this._map[start].Add(end, true);
    }

    /// <summary>Removes an edge from the graph.</summary>
    /// <param name="start">The starting point of the edge to remove.</param>
    /// <param name="end">The ending point of the edge to remove.</param>
    public void Remove(T start, T end)
    {
#if no_error_checking
      // nothing
#else
      if (this._map[start] == null)
        throw new Error("Removing a non-existing edge from the graph.");
      if (!this._map[start].Contains(end))
        throw new Error("Removing a non-existing edge from the graph.");
#endif

      this._map[start].Remove(end);
    }

    /// <summary>Adds a node to the graph.</summary>
    /// <param name="node">The node to add to the graph.</param>
    public void Add(T node)
    {
#if no_error_checking
      // nothing
#else
      if (this._map.Count == int.MaxValue)
        throw new Error("This graph has reach its node capacity.");
#endif
      
      this._map.Add(node, new Map_Linked<bool, T>(this._map.Equate, this._map.Hash));
    }

    public void Remove(T node)
    {
      throw new System.NotImplementedException();
    }

    public void Foreach(Foreach<T> function)
    {
      throw new System.NotImplementedException();
    }

    public void Foreach(ForeachRef<T> function)
    {
      throw new System.NotImplementedException();
    }

    public ForeachStatus Foreach(ForeachBreak<T> function)
    {
      throw new System.NotImplementedException();
    }

    public ForeachStatus Foreach(ForeachRefBreak<T> function)
    {
      throw new System.NotImplementedException();
    }

    public void Foreach(Foreach<Edge> function)
    {
      throw new System.NotImplementedException();
    }

    public void Foreach(ForeachRef<Edge> function)
    {
      throw new System.NotImplementedException();
    }

    public ForeachStatus Foreach(ForeachBreak<Edge> function)
    {
      throw new System.NotImplementedException();
    }

    public ForeachStatus Foreach(ForeachRefBreak<Edge> function)
    {
      throw new System.NotImplementedException();
    }

    public Structure<T> Clone()
    {
      throw new System.NotImplementedException();
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
