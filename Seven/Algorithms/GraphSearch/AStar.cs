using Seven.Structures;
using Seven.Mathematics;

namespace Seven.Algorithms.GraphSearch
{
	/// <summary>A* graph search algorithm.</summary>
	/// <typeparam name="T">The generic type of nodes in the graph.</typeparam>
	/// <typeparam name="Math">The numeric type to perform calculations on.</typeparam>
	public static class AStar<T, Math>
	{
		/// <summary>Runs the A* search algorithm algorithm on a graph.</summary>
		/// <param name="start">The node to start at.</param>
		/// <param name="neighbors">Step function for all neigbors of a given node.</param>
		/// <param name="heuristic">Computes the heuristic value of a given node in a graph.</param>
		/// <param name="cost">Computes the cost of moving from the current node to a specific neighbor.</param>
		/// <param name="goal">Predicate for determining if we have reached the goal node.</param>
		/// <returns>Stepper of the shortest path or null if no path exists.</returns>
		public static Stepper<T> Run(
			T start,
			Neighbors neighbors,
			Heuristic heuristic,
			Cost cost,
			Goal goal)
		{
			// using a heap (aka priority queue) to store nodes based on their computed A* f(n) value
			Heap<Node> fringe = new HeapArray<Node>(
				// NOTE: Typical A* implementations prioritize smaller values
				(Node left, Node right) => { return Compute<Math>.Compare(right.Priority, left.Priority); });

			// using a map (aka dictionary) to store costs from start to current nodes
			Map<Math, Node> computed_costs = new MapHashArray<Math, Node>();

			// construct the f(n) for this A* execution
			function function = (T node, Node previous) =>
			{
				Math costFromStart = Compute<Math>.Add(computed_costs.Get(previous), cost(previous.Value, node));
				return Compute<Math>.Add(costFromStart, heuristic(node));
			};

			// push starting node
			Node start_node = new Node(null, start, default(Math));
			fringe.Enqueue(start_node);
			computed_costs.Add(start_node, default(Math));

			// run the algorithm
			while (fringe.Count != 0)
			{
				Node current = fringe.Dequeue();
				if (goal(current.Value))
				{
					return BuildPath(current);
				}
				else
				{
					neighbors(current.Value,
						(T neighbor) =>
						{
							Node newNode = new Node(current, neighbor, function(neighbor, current));
							Math costValue = Compute<Math>.Add(computed_costs.Get(current), cost(current.Value, neighbor));
							computed_costs.Add(newNode, costValue);
							fringe.Enqueue(newNode);
						});
				}
			}
			return null; // goal node was not reached (no path exists)
		}

		// nested types
		#region private class Node
		/// <summary>Wraps a T node to include path and priority for this algorithm.</summary>
		private class Node
		{
			private Node _previous;
			private T _value;
			private Math _priority;

			public Node Previous { get { return this._previous; } }
			public T Value { get { return this._value; } }
			public Math Priority { get { return this._priority; } }

			public Node(Node previous, T value, Math priority)
			{
				this._previous = previous;
				this._value = value;
				this._priority = priority;
			}
		}
		#endregion
		#region private class PathNode
		/// <summary>Needed for ordering computed path after the goal node is found.</summary>
		private class PathNode
		{
			private T _value;
			private PathNode _next;

			public T Value { get { return this._value; } }
			public PathNode Next { get { return this._next; } set { this._next = value; } }

			public PathNode(T value)
			{
				this._value = value;
			}
		}
		#endregion
		// delegates
		#region public delegate void Neighbors(T current, Step<T> neighbors);
		/// <summary>Step function for all neigbors of a given node.</summary>
		/// <param name="current">The node to step through all the neighbors of.</param>
		/// <param name="neighbors">Step function to perform on all neighbors.</param>
		public delegate void Neighbors(T current, Step<T> neighbors);
		#endregion
		#region public delegate Math Heuristic(T node);
		/// <summary>Computes the heuristic value of a given node in a graph (smaller values mean closer to goal node).</summary>
		/// <param name="node">The node to compute the heuristic value of.</param>
		/// <returns>The computed heuristic value for this node.</returns>
		public delegate Math Heuristic(T node);
		#endregion
		#region public delegate Math Cost(T current, T neighbor);
		/// <summary>Computes the cost of moving from the current node to a specific neighbor.</summary>
		/// <param name="current">The current (starting) node.</param>
		/// <param name="neighbor">The node to compute the cost of movign to.</param>
		/// <returns>The computed cost value of movign from current to neighbor.</returns>
		public delegate Math Cost(T current, T neighbor);
		#endregion
		#region public delegate bool Goal(T current);
		/// <summary>Predicate for determining if we have reached the goal node.</summary>
		/// <typeparam name="T">The generic type of nodes in this graph.</typeparam>
		/// <param name="current">The current node.</param>
		/// <returns>True if the current node is a/the goal node; False if not.</returns>
		public delegate bool Goal(T current);
		#endregion
		#region private delegate Math function(T node, Node previous);
		/// <summary>Computes "f(n) = g(n) + h(n)" where g(n) is the known cost of getting from the initial node to n,
		/// h(n) is a heuristic estimate of the cost to get from n to any goal node, and f(n) is the node priority.
		/// Smaller f(n) means higher node priority.</summary>
		/// <param name="node">The node to compute the A* function of.</param>
		/// <param name="previous">The previous node (needed to compute the cost).</param>
		/// <returns>The A* computed value for searching.</returns>
		private delegate Math function(T node, Node previous);
		#endregion
		// methods (private)
		#region private static Stepper<T> BuildPath(Node node)
		/// <summary>Builds the path from resulting from the A* algorithm.</summary>
		/// <param name="node">The resulting final node fromt he A* algorithm.</param>
		/// <returns>A stepper function of the computed path frmo the A* algorithm.</returns>
		private static Stepper<T> BuildPath(Node node)
		{
			PathNode end;
			PathNode start = BuildPath(node, out end);
			return (Step<T> step) =>
				{
					PathNode current = start;
					while (current != null)
					{
						step(current.Value);
						current = current.Next;
					}
				};
		}
		#endregion
		#region private static PathNode BuildPath(Node currentNode, out PathNode currentPathNode)
		private static PathNode BuildPath(Node currentNode, out PathNode currentPathNode)
		{
			if (currentNode.Previous == null)
			{
				PathNode start = new PathNode(currentNode.Value);
				currentPathNode = start;
				return start;
			}
			else
			{
				PathNode previous;
				PathNode start = BuildPath(currentNode.Previous, out previous);
				currentPathNode = new PathNode(currentNode.Value);
				previous.Next = currentPathNode;
				return start;
			}
		}
		#endregion
	}
}
