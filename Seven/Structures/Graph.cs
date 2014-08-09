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

  }

  public class Graph_Array<T> : Graph<T>
  {
    #region class

    private class Node
    {
      private T _value;
      private T[] _adjacents;

      public T Value { get { return _value; } set { _value = value; } }
      public T[] Adjacents { get { return _adjacents; } set { _adjacents = value; } }

      public Node(T value)
      {
        _value = value;
      }
    }

    #endregion

    #region field

    private Equate<T> _equate;
    private Node[] _nodes;
    private int _edgeCount;

    #endregion

    #region property

    public int NodeCount { get { return this._nodes.Length; } }
    public int EdgeCount { get { return this._edgeCount; } }

    #endregion

    #region construct

    public Graph_Array(Equate<T> equate)
    {
      _equate = equate;
    }

    #endregion

    #region method

    /// <summary>Adds a node to the graph.</summary>
    /// <param name="node">The node to be added.</param>
    public void Add(T node)
    {
      if (_nodes == null)
        this._nodes = new Node[] { new Node(node) };
      else
      {
        Node[] nodes = new Node[this._nodes.Length + 1];
        Array.Copy(this._nodes, nodes, this._nodes.Length);
        nodes[nodes.Length - 1] = new Node(node);
        this._nodes = nodes;
      }
    }

    /// <summary>Adds an edge to this graph.</summary>
    /// <param name="from">The starting point of the edge.</param>
    /// <param name="to">The ending point of the edge.</param>
    public void Add(T from, T to)
    {
      int index_from = Index(from);
      int index_to = Index(from);

      if (index_from == -1 && index_to == -1)
      {
        Graph_Array<T>.Grow(ref this._nodes, 2);
        index_from = this._nodes.Length;
        index_to = this._nodes.Length + 1;
        this._nodes[index_from] = new Node(from);
        this._nodes[index_to] = new Node(to);
      }
      else if (index_from == -1)
      {
        Graph_Array<T>.Grow(ref this._nodes, 1);
        index_from = this._nodes.Length;
        this._nodes[index_from] = new Node(from);
      }
      else if (index_to == -1)
      {
        Graph_Array<T>.Grow(ref this._nodes, 1);
        index_to = this._nodes.Length;
        this._nodes[index_to] = new Node(to);
      }

      T[] temp = this._nodes[index_from].Adjacents;
      Graph_Array<T>.Grow(ref temp, 1);
      this._nodes[index_from].Adjacents = temp;

      Node node_from = this._nodes[index_from];
      node_from.Adjacents[node_from.Adjacents.Length - 1] = to;
    }

    private static void Grow(ref T[] input, int amount)
    {
      if (input == null)
        input = new T[amount];
      else
      {
        T[] temp = input;
        input = new T[input.Length + amount];
        for (int i = 0; i < input.Length; i++)
          input[i] = temp[i];
      }
    }

    private static void Grow(ref Node[] array, int amount)
    {
      if (array == null)
        array = new Node[amount];
      else
      {
        Node[] temp = array;
        array = new Node[array.Length + amount];
        for (int i = 0; i < array.Length; i++)
          array[i] = temp[i];
      }
    }

    private int Index(T node)
    {
      if (this._nodes == null)
        return -1;

      for (int i = 0; i < this._nodes.Length; i++)
        if (this._equate(this._nodes[i].Value, node))
          return i;

      return -1;
    }

    System.Collections.IEnumerator
      System.Collections.IEnumerable.GetEnumerator()
    {
      for (int i = 0; i < this._nodes.Length; i++)
        yield return this._nodes[i].Value;
    }

    System.Collections.Generic.IEnumerator<T>
      System.Collections.Generic.IEnumerable<T>.GetEnumerator()
    {
      for (int i = 0; i < this._nodes.Length; i++)
        yield return this._nodes[i].Value;
    }

    /// <summary>The current allocation size of the structure.</summary>
    /// <remarks>Returns long.MaxValue on overflow.</remarks>
    public int SizeOf { get { return this._edgeCount + this._nodes.Length; } }

    /// <summary>Invokes a delegate for each entry in the data structure.</summary>
    /// <param name="function">The delegate to invoke on each item in the structure.</param>
    public void Foreach(Foreach<T> function)
    {
      for (int i = 0; i < this._nodes.Length; i++)
        function(this._nodes[i].Value);
    }

    /// <summary>Invokes a delegate for each entry in the data structure.</summary>
    /// <param name="function">The delegate to invoke on each item in the structure.</param>
    public void Foreach(ForeachRef<T> function)
    {
      for (int i = 0; i < this._nodes.Length; i++)
      {
        T temp = this._nodes[i].Value;
        function(ref temp);
        this._nodes[i].Value = temp;
      }
    }

    /// <summary>Invokes a delegate for each entry in the data structure.</summary>
    /// <param name="function">The delegate to invoke on each item in the structure.</param>
    /// <returns>The resulting status of the iteration.</returns>
    public ForeachStatus Foreach(ForeachBreak<T> function)
    {
      for (int i = 0; i < this._nodes.Length; i++)
        if (function(this._nodes[i].Value) == ForeachStatus.Break)
          return ForeachStatus.Break;
      return ForeachStatus.Continue;
    }

    /// <summary>Invokes a delegate for each entry in the data structure.</summary>
    /// <param name="function">The delegate to invoke on each item in the structure.</param>
    /// <returns>The resulting status of the iteration.</returns>
    public ForeachStatus Foreach(ForeachRefBreak<T> function)
    {
      for (int i = 0; i < this._nodes.Length; i++)
      {
        T temp = this._nodes[i].Value;
        ForeachStatus status = function(ref temp);
        this._nodes[i].Value = temp;
        if (status == ForeachStatus.Break)
          return ForeachStatus.Break;
      }
      return ForeachStatus.Continue;
    }

    /// <summary>Creates a shallow clone of this data structure.</summary>
    /// <returns>A shallow clone of this data structure.</returns>
    public Structure<T> Clone()
    {
      throw new NotImplementedException();
    }

    /// <summary>Converts the structure into an array.</summary>
    /// <returns>An array containing all the item in the structure.</returns>
    public T[] ToArray()
    {
      throw new NotImplementedException();
    }

    #endregion
  }

  public class Graph_AdjacencyHash<T>// : Graph<T>
  {
    #region class

    private class Edge
    {
      private T _to;
      private Edge _next;

      internal T To { get { return this._to; } }
      internal Edge Next { get { return this._next; } }

      internal Edge(T to)
      {
        this._to = to;
      }
    }

    private class Node
    {
      private T _key;
      private Node _next;



      internal T Key { get { return _key; } set { _key = value; } }
      internal Node Next { get { return _next; } set { _next = value; } }

      internal Node(T key, Node next)
      {
        _key = key;
        _next = next;
      }
    }

    #endregion

    #region field

    /// <summary>A set of allowable table sizes, all of which are prime.</summary>
    private static readonly int[] _tableSizes = new int[]
    {
        1, 2, 5, 11, 23, 47, 97, 197, 397, 797, 1597, 3203, 6421, 12853, 25717, 51437,
        102877, 205759, 411527, 823117, 1646237, 3292489, 6584983, 13169977, 26339969,
        52679969, 105359939, 210719881, 421439783, 842879579, 1685759167
    };

    private const double _maxLoadFactor = 1.0d;

    private Equate<T> _equate;
    private Map.Hash<T> _hash;
    private Node[] _table;
    private int _count;
    private int _sizeIndex;

    #endregion

    #region property

    /// <summary>The function for calculating hash codes for this table.</summary>
    public Map.Hash<T> Hash { get { return _hash; } }

    /// <summary>The function for equating keys in this table.</summary>
    public Equate<T> Equate { get { return _equate; } }

    /// <summary>Returns the current number of items in the structure.</summary>
    /// <remarks>Runetime: O(1).</remarks>
    public int Count { get { return _count; } }

    /// <summary>Returns true if the structure is empty.</summary>
    /// <remarks>Runetime: O(1).</remarks>
    public bool IsEmpty { get { return _count == 0; } }

    /// <summary>Returns the current size of the actual table. You will want this if you 
    /// wish to multithread structure traversals.</summary>
    /// <remarks>Runtime: O(1).</remarks>
    public int TableSize { get { return _table.Length; } }

    #endregion

    #region construct

    /// <summary>Constructs a new hash table instance.</summary>
    /// <remarks>Runtime: O(1).</remarks>
    public Graph_AdjacencyHash(Equate<T> equate, Map.Hash<T> hash)
    {
      this._equate = equate;
      this._hash = hash;
      _table = new Node[_tableSizes[0]];
      _count = 0;
      _sizeIndex = 0;
    }

    #endregion

    #region method

    public bool Contains(T key)
    {
      Node cell = Find(key, ComputeHash(key));
      if (cell == null)
        return false;
      else
        return true;
    }
        
    private Node Find(T key, int loc)
    {
      for (Node bucket = _table[loc]; bucket != null; bucket = bucket.Next)
        if (_equate(bucket.Key, key))
          return bucket;
      return null;
    }

    private int ComputeHash(T key) { return (_hash(key) & 0x7fffffff) % _table.Length; }

    /// <summary>Adds a value to the hash table.</summary>
    /// <param name="key">The key value to use as the look-up reference in the hash table.</param>
    /// <param name="value">The value to store in the hash table.</param>
    /// <remarks>Runtime: O(n), Omega(1).</remarks>
    public void Add(T key)
    {
      if (key == null)
        throw new Error("attempting to add a null key to the structure.");
      int location = ComputeHash(key);
      if (Find(key, location) == null)
      {
        if (++_count > _table.Length * _maxLoadFactor)
        {
          if (_sizeIndex + 1 == _tableSizes.Length)
            throw new Error("maximum size " + _tableSizes[_tableSizes.Length - 1] + " of hash table reached.");

          Node[] t = _table;
          _table = new Node[_tableSizes[++_sizeIndex]];
          for (int i = 0; i < t.Length; i++)
          {
            while (t[i] != null)
            {
              Node cell = RemoveFirst(t, i);
              Add(cell, ComputeHash(cell.Key));
            }
          }
          location = ComputeHash(key);
        }
        Node p = new Node(key, null);
        Add(p, location);
      }
      else
        throw new Error("\nMember: \"Add(TKey key, TValue value)\"\nThe key is already in the table.");
    }

    private Node RemoveFirst(Node[] t, int i)
    {
      Node first = t[i];
      t[i] = first.Next;
      return first;
    }

    private void Add(Node cell, int location)
    {
      cell.Next = _table[location];
      _table[location] = cell;
    }

    /// <summary>Removes a value from the hash table.</summary>
    /// <param name="key">The key of the value to remove.</param>
    /// <remarks>Runtime: N/A. (I'm still editing this structure)</remarks>
    public void Remove(T key)
    {
      if (key == null)
        throw new Error("attempting to remove \"null\" from the structure.");
      int location = ComputeHash(key);
      if (_table[location].Key.Equals(key))
        _table[location] = _table[location].Next;
      for (Node bucket = _table[location]; bucket != null; bucket = bucket.Next)
      {
        if (bucket.Next == null)
          throw new Error("attempting to remove a non-existing value.");
        else if (bucket.Next.Key.Equals(key))
          bucket.Next = bucket.Next.Next;
      }
      _count--;
    }

    public void Clear()
    {
      _table = new Node[107];
      _count = 0;
      _sizeIndex = 0;
    }
    
    public T[] ToArray()
    {
      T[] array = new T[_count];
      int index = 0;
      Node node;
      for (int i = 0; i < _table.Length; i++)
        if ((node = _table[i]) != null)
          do
          {
            array[index++] = node.Key;
          } while ((node = node.Next) != null);
      return array;
    }

    //System.Collections.IEnumerator
    //  System.Collections.IEnumerable.GetEnumerator()
    //{
    //  Node node;
    //  for (int i = 0; i < _table.Length; i++)
    //    if ((node = _table[i]) != null)
    //      do
    //      {
    //        yield return node.Key;
    //      } while ((node = node.Next) != null);
    //}

    //System.Collections.Generic.IEnumerator<T>
    //  System.Collections.Generic.IEnumerable<T>.GetEnumerator()
    //{
    //  Node node;
    //  for (int i = 0; i < _table.Length; i++)
    //    if ((node = _table[i]) != null)
    //      do
    //      {
    //        yield return node.Key;
    //      } while ((node = node.Next) != null);
    //}

    /// <summary>Gets the current memory imprint of this structure in bytes.</summary>
    /// <remarks>Returns long.MaxValue on overflow.</remarks>
    public int SizeOf { get { return _count + _table.Length; } }
    
    /// <summary>Invokes a delegate for each entry in the data structure.</summary>
    /// <param name="function">The delegate to invoke on each item in the structure.</param>
    public void Foreach(Foreach<T> function)
    {
      Node node;
      for (int i = 0; i < _table.Length; i++)
        if ((node = _table[i]) != null)
          do {
            function(node.Key);
          } while ((node = node.Next) != null);
    }

    /// <summary>Invokes a delegate for each entry in the data structure.</summary>
    /// <param name="function">The delegate to invoke on each item in the structure.</param>
    public void Foreach(ForeachRef<T> function)
    {
      Node node;
      for (int i = 0; i < _table.Length; i++)
        if ((node = _table[i]) != null)
          do
          {
            T temp = node.Key;
            function(ref temp);
            node.Key = temp;
          } while ((node = node.Next) != null);
    }

    /// <summary>Invokes a delegate for each entry in the data structure.</summary>
    /// <param name="function">The delegate to invoke on each item in the structure.</param>
    /// <returns>The resulting status of the iteration.</returns>
    public ForeachStatus Foreach(ForeachBreak<T> function)
    {
      Node node;
      for (int i = 0; i < _table.Length; i++)
        if ((node = _table[i]) != null)
          do
          {
            if (function(node.Key) == ForeachStatus.Break)
              return ForeachStatus.Break;
          } while ((node = node.Next) != null);
      return ForeachStatus.Continue;
    }

    /// <summary>Invokes a delegate for each entry in the data structure.</summary>
    /// <param name="function">The delegate to invoke on each item in the structure.</param>
    /// <returns>The resulting status of the iteration.</returns>
    public ForeachStatus Foreach(ForeachRefBreak<T> function)
    {
      Node node;
      for (int i = 0; i < _table.Length; i++)
        if ((node = _table[i]) != null)
          do
          {
            T temp = node.Key;
            ForeachStatus status = function(ref temp);
            node.Key = temp;
            if (status == ForeachStatus.Break)
              return ForeachStatus.Break;
          } while ((node = node.Next) != null);
      return ForeachStatus.Continue;
    }

    /// <summary>Creates a shallow clone of this data structure.</summary>
    /// <returns>A shallow clone of this data structure.</returns>
    public Structure<T> Clone()
    {
      throw new System.NotImplementedException();
    }

    #endregion

    #region error

    /// <summary>This is used for throwing hash table exceptions only to make debugging faster.</summary>
    private class Error : Structure.Error
    {
      public Error(string message) : base(message) { }
    }

    #endregion
  }
}
