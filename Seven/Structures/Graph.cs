// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Structures
{
	public interface Graph<T> : Structure<T>,
		// Structure Properties
		Structure.Addable<T>,
		Structure.Removable<T>,
		Structure.Clearable<T>
	{
		// properties
		#region int EdgeCount
		/// <summary>The number of edges in the graph.</summary>
		int EdgeCount { get; }
		#endregion
		#region int NodeCount
		/// <summary>The number of nodes in the graph.</summary>
		int NodeCount { get; }
		#endregion
		// methods
		#region bool Adjacent(T a, T b);
		/// <summary>Checks if b is adjacent to a.</summary>
		/// <param name="a">The starting point of the edge to check.</param>
		/// <param name="b">The ending point of the edge to check.</param>
		/// <returns>True if b is adjacent to a; False if not</returns>
		bool Adjacent(T a, T b);
		#endregion
		#region void Neighbors(T a, Step<T> function);
		/// <summary>Gets all the nodes adjacent to a and performs the provided delegate on each.</summary>
		/// <param name="a">The node to find all the adjacent node to.</param>
		/// <param name="function">The delegate to perform on each adjacent node to a.</param>
		void Neighbors(T a, Step<T> function);
		#endregion 
		#region void Add(T start, T end);
		/// <summary>Adds an edge to the graph starting at a and ending at b.</summary>
		/// <param name="start">The stating point of the edge to add.</param>
		/// <param name="end">The ending point of the edge to add.</param>
		void Add(T start, T end);
		#endregion
		#region void Remove(T start, T end);
		/// <summary>Removes an edge from the graph.</summary>
		/// <param name="start">The starting point of the edge to remove.</param>
		/// <param name="end">The ending point of the edge to remove.</param>
		void Remove(T start, T end);
		#endregion
	}

	/// <summary>Stores the graph as a set-hash of nodes and quadtree of edges.</summary>
	/// <typeparam name="T">The generic type of this data structure.</typeparam>
	[System.Serializable]
	public class GraphSetOmnitree<T> : Graph<T>
	{
		//fields
		public SetHashList<T> _nodes;
		public OmnitreeLinkedLinked<Edge, T> _edges;
		// nested types
		#region Edge
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
		// constructors
		#region private Graph_SetOmnitree(Graph_SetOmnitree<T> graph)
		private GraphSetOmnitree(GraphSetOmnitree<T> graph)
		{
			this._edges = graph._edges.Clone() as OmnitreeLinkedLinked<Edge, T>;
			this._nodes = graph._nodes.Clone() as SetHashList<T>;
		}
		#endregion
		#region public Graph_SetOmnitree(Equate<T> equate, Compare<T> compare, Hash<T> hash, T min, T max, Omnitree.Average<T> average)
		public GraphSetOmnitree(Equate<T> equate, Compare<T> compare, Hash<T> hash, T min, T max, Omnitree.Average<T> average)
		{
			this._nodes = new SetHashList<T>(equate, hash);
			Omnitree.Locate<Edge, T> locationFunction = (Edge a) => { return Accessor.Get(new T[] { a.Start, a.End }); };
			this._edges = new OmnitreeLinkedLinked<Edge, T>(
				new T[] { min, min },
				new T[] { max, max },
				locationFunction, compare, average);
		}
		#endregion
		#region public Graph_SetOmnitree(Compare<T> compare, Hash<T> hash, T min, T max, Omnitree.Average<T> average)
		public GraphSetOmnitree(Compare<T> compare, Hash<T> hash, T min, T max, Omnitree.Average<T> average)
		{
			this._nodes = new SetHashList<T>((T a, T b) => { return compare(a, b) == Comparison.Equal; }, hash);
			Omnitree.Locate<Edge, T> locationFunction = (Edge a) => { return Accessor.Get(new T[] { a.Start, a.End }); };
			this._edges = new OmnitreeLinkedLinked<Edge, T>(
				new T[] { min, min },
				new T[] { max, max },
				locationFunction, compare, average);
		}
		#endregion
		// properties
		#region public int EdgeCount
		public int EdgeCount { get { return this._edges.Count; } }
		#endregion
		#region public int NodeCount
		public int NodeCount { get { return this._nodes.Count; } }
		#endregion
		// methods
		#region public Structure<T> Clone()
		public Structure<T> Clone()
		{
			return new GraphSetOmnitree<T>(this);
		}
		#endregion
		#region public T[] ToArray()
		public T[] ToArray()
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public void Clear()
		public void Clear()
		{
			this._nodes = new SetHashList<T>(this._nodes.Equate, this._nodes.Hash);
			this._edges = new OmnitreeLinkedLinked<Edge, T>(
				new T[] { this._edges.Min(0), this._edges.Min(1) },
				new T[] { this._edges.Max(0), this._edges.Max(1) },
				this._edges.Locate, this._edges.Compare, this._edges.Average);
		}
		#endregion
		#region public bool Adjacent(T a, T b)
		public bool Adjacent(T a, T b)
		{
			bool exists = false;
			this._edges.Stepper((Edge edge) => { exists = true; }, new T[] { a, b }, new T[] { a, b });
			return exists;
		}
		#endregion
		#region public void Neighbors(T a, Step<T> function)
		public void Neighbors(T a, Step<T> function)
		{
			if (!this._nodes.Contains(a))
				throw new System.InvalidOperationException("Attempting to look up the neighbors of a node that does not belong to a graph");

			this._edges.Stepper(
					(Edge e) => { function(e.End); },
					new T[] { a, this._edges.Min(1) }, new T[] { a, this._edges.Max(1) });
		}
		#endregion
		#region public void Add(T start, T end)
		public void Add(T start, T end)
		{
			if (!this._nodes.Contains(start))
				throw new System.InvalidOperationException("Adding an edge to a graph from a node that does not exists");
			if (!this._nodes.Contains(end))
				throw new System.InvalidOperationException("Adding an edge to a graph to a node that does not exists");
			this._edges.Stepper(
					(Edge e) => { throw new System.InvalidOperationException("Adding an edge to a graph that already exists"); },
					new T[] { start, end }, new T[] { start, end });

			this._edges.Add(new Edge(start, end));
		}
		#endregion
		#region public void Remove(T start, T end)
		public void Remove(T start, T end)
		{
			if (!this._nodes.Contains(start))
				throw new System.InvalidOperationException("Removing an edge to a graph from a node that does not exists");
			if (!this._nodes.Contains(end))
				throw new System.InvalidOperationException("Removing an edge to a graph to a node that does not exists");

			bool exists = false;
			this._edges.Stepper(
					(Edge e) => { exists = true; },
					new T[] { start, end }, new T[] { start, end });
			if (!exists)
				throw new System.InvalidOperationException("Removing a non-existing edge in a graph");

			this._edges.Remove(new T[] { start, end }, new T[] { start, end });
		}
		#endregion
		#region public void Add(T node)
		public void Add(T node)
		{
			if (this._nodes.Contains(node))
				throw new System.InvalidOperationException("Adding an already-existing node to a graph");

			this._nodes.Add(node);
		}
		#endregion
		#region public void Remove(T node)
		public void Remove(T node)
		{
			if (this._nodes.Contains(node))
				throw new System.InvalidOperationException("Removing non-existing node from a graph");

			this._edges.Remove(new T[] { node, this._edges.Min(1) }, new T[] { node, this._edges.Max(1) });
			this._edges.Remove(new T[] { this._edges.Min(1), node }, new T[] { this._edges.Max(1), node });

			this._nodes.Add(node);
		}
		#endregion
		#region public void Stepper(Step<T> function)
		public void Stepper(Step<T> function)
		{
			this._nodes.Stepper(function);
		}
		#endregion
		#region public StepStatus Stepper(StepBreak<T> function)
		public StepStatus Stepper(StepBreak<T> function)
		{
			return this._nodes.Stepper(function);
		}
		#endregion
		#region public void Stepper(Step<Edge> function)
		public void Stepper(Step<Edge> function)
		{
			this._edges.Stepper(function);
		}
		#endregion
		#region public StepStatus Stepper(StepBreak<Edge> function)
		public StepStatus Stepper(StepBreak<Edge> function)
		{
			return this._edges.Stepper(function);
		}
		#endregion
		#region System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		System.Collections.Generic.IEnumerator<T>
			System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}
		#endregion
	}

	/// <summary>Stores a graph as a map and nested map (adjacency matrix).</summary>
	/// <typeparam name="T">The generic node type of this graph.</typeparam>
	[System.Serializable]
	public class GraphMap<T> : Graph<T>
	{
		public MapHashLinked<MapHashLinked<bool, T>, T> _map;
		int _edges;
		// nested types
		#region class Edge
		/// <summary>Represents an edge in a graph.</summary>
		public class Edge
		{
			public T _start;
			public T _end;

			public T Start { get { return this._start; } set { this._start = value; } }
			public T End { get { return this._end; } set { this._end = value; } }

			public Edge(T start, T end)
			{
				this._start = start;
				this._end = end;
			}
		}
		#endregion
		// constructors
		#region private Graph_Map(Equate<T> equate, Hash<T> hash, Graph_SetOmnitree<T> graph)
		private GraphMap(Equate<T> equate, Hash<T> hash, GraphSetOmnitree<T> graph)
		{
			this._edges = 0;
			this._map = new MapHashLinked<MapHashLinked<bool, T>, T>(equate, hash);
		}
		#endregion
		// properties
		#region public int EdgeCount
		public int EdgeCount { get { return this._edges; } }
		#endregion
		#region public int NodeCount
		public int NodeCount { get { return this._map.Count; } }
		#endregion
		// methods
		#region public bool Adjacent(T a, T b)
		public bool Adjacent(T a, T b)
		{
			bool temp_bool;
			MapHashLinked<bool, T> temp_map;
			if (this._map.TryGet(a, out temp_map))
				if (temp_map.TryGet(a, out temp_bool))
					return temp_bool;
			return false;
		}
		#endregion
		#region public void Neighbors(T a, Step<T> function)
		public void Neighbors(T a, Step<T> function)
		{
			MapHashLinked<bool, T> temp_map;
			if (this._map.TryGet(a, out temp_map))
				temp_map.Keys(function);
		}
		#endregion
		#region public void Add(T start, T end)
		/// <summary>Adds an edge to the graph.</summary>
		/// <param name="start">The starting point of the edge.</param>
		/// <param name="end">The ending point of the edge.</param>
		public void Add(T start, T end)
		{
			if (!this._map.Contains(start))
				throw new System.InvalidOperationException("Adding an edge to a non-existing starting node.");
			if (!this._map[start].Contains(end))
				throw new System.InvalidOperationException("Adding an edge to a non-existing ending node.");
			if (this._map[start] == null)
				this._map[start] = new MapHashLinked<bool, T>(this._map.Equate, this._map.Hash);

			this._map[start].Add(end, true);
		}
		#endregion
		#region public void Remove(T start, T end)
		/// <summary>Removes an edge from the graph.</summary>
		/// <param name="start">The starting point of the edge to remove.</param>
		/// <param name="end">The ending point of the edge to remove.</param>
		public void Remove(T start, T end)
		{
			if (this._map[start] == null)
				throw new System.InvalidOperationException("Removing a non-existing edge from the graph.");
			if (!this._map[start].Contains(end))
				throw new System.InvalidOperationException("Removing a non-existing edge from the graph.");
			this._map[start].Remove(end);
		}
		#endregion
		#region public void Add(T node)
		/// <summary>Adds a node to the graph.</summary>
		/// <param name="node">The node to add to the graph.</param>
		public void Add(T node)
		{
			if (this._map.Count == int.MaxValue)
				throw new System.InvalidOperationException("This graph has reach its node capacity.");
			this._map.Add(node, new MapHashLinked<bool, T>(this._map.Equate, this._map.Hash));
		}
		#endregion
		#region public void Remove(T node)
		public void Remove(T node)
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public void Stepper(Step<T> function)
		public void Stepper(Step<T> function)
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public void Stepper(StepRef<T> function)
		public void Stepper(StepRef<T> function)
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public StepStatus Stepper(StepBreak<T> function)
		public StepStatus Stepper(StepBreak<T> function)
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public StepStatus Stepper(StepRefBreak<T> function)
		public StepStatus Stepper(StepRefBreak<T> function)
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public void Stepper(Step<Edge> function)
		public void Stepper(Step<Edge> function)
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public void Stepper(StepRef<Edge> function)
		public void Stepper(StepRef<Edge> function)
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public StepStatus Stepper(StepBreak<Edge> function)
		public StepStatus Stepper(StepBreak<Edge> function)
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public StepStatus Stepper(StepRefBreak<Edge> function)
		public StepStatus Stepper(StepRefBreak<Edge> function)
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public Structure<T> Clone()
		public Structure<T> Clone()
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public T[] ToArray()
		public T[] ToArray()
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		System.Collections.Generic.IEnumerator<T>
			System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public void Clear()
		public void Clear()
		{
			this._edges = 0;
			this._map = new MapHashLinked<MapHashLinked<bool, T>, T>(this._map.Equate, this._map.Hash);
		}
		#endregion
	}
}
