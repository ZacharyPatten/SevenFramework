// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Structures
{
	/// <summary>A generic tree data structure.</summary>
	/// <typeparam name="T">The generic type stored in this data structure.</typeparam>
	public interface Tree<T> : Structure<T>
	{
		#region member

		/// <summary>The head of the tree.</summary>
		T Head { get; }
		/// <summary>The number of nodes in this tree.</summary>
		int Count { get; }
		/// <summary>Determines if a node is the child of another node.</summary>
		/// <param name="node">The child to check the parent of.</param>
		/// <param name="parent">The parent to check the child of.</param>
		/// <returns>True if the node is a child of the parent; False if not.</returns>
		bool IsChildOf(T node, T parent);
		/// <summary>Stepper function for the children of a given node.</summary>
		/// <param name="parent">The node to step through the children of.</param>
		/// <param name="step_function">The step function.</param>
		void Children(T parent, Step<T> step_function);
		/// <summary>Adds a node to the tree.</summary>
		/// <param name="addition">The node to be added.</param>
		/// <param name="parent">The parent of the node to be added.</param>
		void Add(T addition, T parent);

		/// <summary>Removes a node from the tree and all the child nodes.</summary>
		/// <param name="removal">The node to be removed.</param>
		void Remove(T removal);

		#endregion
	}

	/// <summary>A generic tree data structure using a dictionary to store node data.</summary>
	/// <typeparam name="T">The generic type stored in this data structure.</typeparam>
	public class Tree_Map<T> : Tree<T>
	{
		#region Node

		private class NodeData
		{
			private T _parent;
			private Set_Hash<T> _children;

			public T Parent { get { return this._parent; } set { this._parent = value; } }
			public Set_Hash<T> Children { get { return this._children; } set { this._children = value; } }

			public NodeData(T parent, Set_Hash<T> children)
			{
				this._parent = parent;
				this._children = children;
			}
		}

		#endregion

		#region Tree_SetHash<T>

		#region fields

		private Equate<T> _equate;
		private Hash<T> _hash;
		private T _head;
		private Map_Linked<NodeData, T> _tree;

		#endregion

		#region constructor

		public Tree_Map(
			T head,
			Equate<T> equate,
			Hash<T> hash)
		{
			this._equate = equate;
			this._hash = hash;
			this._head = head;
			this._tree = new Map_Linked<NodeData, T>(this._equate, this._hash);
			this._tree.Add(this._head, new NodeData(default(T), new Set_Hash<T>(this._equate, this._hash)));
		}

		#endregion

		#region property

		/// <summary>The head of the tree.</summary>
		public T Head { get { return this._head; } }
		/// <summary>The hash function being used (was passed into the constructor).</summary>
		public Hash<T> Hash { get { return this._hash; } }
		/// <summary>The equate function being used (was passed into the constructor).</summary>
		public Equate<T> Equate { get { return this._equate; } }

		#endregion

		#endregion

		#region Tree<T>

		/// <summary>The number of nodes in this tree.</summary>
		public int Count { get { return this._tree.Count; } }

		/// <summary>Determines if a node is the child of another node.</summary>
		/// <param name="node">The child to check the parent of.</param>
		/// <param name="parent">The parent to check the child of.</param>
		/// <returns>True if the node is a child of the parent; False if not.</returns>
		public bool IsChildOf(T node, T parent)
		{
			NodeData nodeData;
			if (this._tree.TryGet(parent, out nodeData))
				return nodeData.Children.Contains(node);
			else
				throw new Error("Attempting to get the children of a non-existing node");
		}

		/// <summary>Gets the parent of a given node.</summary>
		/// <param name="child">The child to get the parent of.</param>
		/// <returns>The parent of the given child.</returns>
		public T Parent(T child)
		{
			NodeData nodeData;
			if (this._tree.TryGet(child, out nodeData))
				return nodeData.Parent;
			else
				throw new Error("Attempting to get the parent of a non-existing node");
		}

		/// <summary>Stepper function for the children of a given node.</summary>
		/// <param name="parent">The node to step through the children of.</param>
		/// <param name="step_function">The step function.</param>
		public void Children(T parent, Step<T> step_function)
		{
			NodeData nodeData;
			if (this._tree.TryGet(parent, out nodeData))
				nodeData.Children.Stepper(step_function);
			else
				throw new Error("Attempting to get the children of a non-existing node");
		}

		/// <summary>Adds a node to the tree.</summary>
		/// <param name="addition">The node to be added.</param>
		/// <param name="parent">The parent of the node to be added.</param>
		public void Add(T addition, T parent)
		{
			NodeData nodeData;
			if (this._tree.TryGet(parent, out nodeData))
			{
				this._tree.Add(addition, new NodeData(parent, new Set_Hash<T>(this._equate, this._hash)));
				nodeData.Children.Add(addition);
			}
			else
				throw new Error("Attempting to add a node to a non-existing parent");
		}

		/// <summary>Removes a node from the tree and all the child nodes.</summary>
		/// <param name="removal">The node to be removed.</param>
		public void Remove(T removal)
		{
			NodeData nodeData;
			if (this._tree.TryGet(removal, out nodeData))
			{
				this._tree[nodeData.Parent].Children.Remove(removal);
				RemoveRecursive(removal);
			}
			else
				throw new Error("Attempting to remove a non-existing node");
		}
		private void RemoveRecursive(T current)
		{
			this._tree[current].Children.Stepper(
				(T child) =>
					{
						RemoveRecursive(child);
					});
			this._tree.Remove(current);
		}

		#endregion

		#region Structure<T>

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="step_function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<T> step_function)
		{
			this._tree.Keys(step_function);
		}
		
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="step_function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepBreak<T> step_function)
		{
			return this._tree.Keys(step_function);
		}

		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public Tree_Map<T> Clone()
		{
			throw new System.NotImplementedException();
		}

		#endregion

		#region IEnumerable<T>

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
