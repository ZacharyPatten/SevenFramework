using Seven.Structures;
using Seven.Mathematics;

namespace Seven.Algorithms.GraphSearch
{
	/// <summary>Greedy graph search algorithm.</summary>
	/// <typeparam name="T">The generic type of nodes in the graph.</typeparam>
	/// <typeparam name="Math">The numeric type to perform calculations on.</typeparam>
	public static class Greedy<T, Math>
	{
		#region private members

		#region classes

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

		#region methods

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

		#endregion

		#region delegates

		/// <summary>Step function for all neigbors of a given node.</summary>
		/// <param name="current">The node to step through all the neighbors of.</param>
		/// <param name="neighbors">Step function to perform on all neighbors.</param>
		public delegate void Neighbors(T current, Step<T> neighbors);

		/// <summary>Computes the heuristic value of a given node in a graph (smaller values mean closer to goal node).</summary>
		/// <param name="node">The node to compute the heuristic value of.</param>
		/// <returns>The computed heuristic value for this node.</returns>
		public delegate Math Heuristic(T node);

		/// <summary>Predicate for determining if we have reached the goal node.</summary>
		/// <typeparam name="T">The generic type of nodes in this graph.</typeparam>
		/// <param name="current">The current node.</param>
		/// <returns>True if the current node is a/the goal node; False if not.</returns>
		public delegate bool Goal(T current);

		#endregion

		/// <summary>Runs the Greedy search algorithm algorithm on a graph.</summary>
		/// <param name="start">The node to start at.</param>
		/// <param name="neighbors">Step function for all neigbors of a given node.</param>
		/// <param name="heuristic">Computes the heuristic value of a given node in a graph.</param>
		/// <param name="goal">Predicate for determining if we have reached the goal node.</param>
		/// <returns>Stepper of the shortest path or null if no path exists.</returns>
		public static Stepper<T> Run(
			T start,
			Neighbors neighbors,
			Heuristic heuristic,
			Goal goal)
		{
			// using a heap (aka priority queue) to store nodes based on their computed heuristic value
			Heap<Node> fringe = new Heap_Array<Node>(
				// NOTE: I just reversed the order of left and right because smaller values are higher priority
				(Node left, Node right) => { return Logic<Math>.compare(right.Priority, left.Priority); });

			// push starting node
			Node start_node = new Node(null, start, default(Math));
			fringe.Enqueue(start_node);

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
							Node newNode = new Node(current, neighbor, heuristic(neighbor));
							fringe.Enqueue(newNode);
						});
				}
			}
			return null; // goal node was not reached (no path exists)
		}
	}
}
