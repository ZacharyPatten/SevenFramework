// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Structures
{
	/// <summary>An unsorted structure of unique items.</summary>
	/// <typeparam name="T">The generic type of the structure.</typeparam>
	public interface Set<T> : Structure<T>
	{
		#region member

		/// <summary>The number of items in this structure.</summary>
		int Count { get; }
		/// <summary>Determines if an item is contained in this set.</summary>
		/// <param name="key">The item to check for existence in this set.</param>
		/// <returns>True if the item is contained in this set; False if not.</returns>
		bool Contains(T key);
		/// <summary>Adds an item to this set.</summary>
		/// <param name="key">The item to add.</param>
		void Add(T key);
		/// <summary>Removes and item frmo this set.</summary>
		/// <param name="key">The item to remove.</param>
		void Remove(T key);
		/// <summary>Returns this set to an empty state.</summary>
		void Clear();

		#endregion
	}

	/// <summary>An unsorted structure of unique items.</summary>
	/// <typeparam name="T">The generic type of the structure.</typeparam>
	public class Set_Hash<T> : Set<T>
	{
		#region Node

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

		#region Set_Hash<T>

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
		private Hash<T> _hash;
		private Node[] _table;
		private int _count;
		private int _sizeIndex;

		#endregion

		#region property
		
		/// <summary>Returns the current size of the actual table. You will want this if you 
		/// wish to multithread structure traversals.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public int TableSize { get { return _table.Length; } }

		#endregion

		#region construct

		/// <summary>Constructs a new hash table instance.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public Set_Hash(Equate<T> equate, Hash<T> hash)
		{
			this._equate = equate;
			this._hash = hash;
			this._table = new Node[_tableSizes[0]];
			this._count = 0;
			this._sizeIndex = 0;
		}

		/// <summary>Constructs a new hash table instance.</summary>
		/// <remarks>Runtime: O(stepper).</remarks>
		public Set_Hash(Equate<T> equate, Hash<T> hash, Stepper<T> stepper)
		{
			this._equate = equate;
			this._hash = hash;
			this._table = new Node[_tableSizes[0]];
			this._count = 0;
			this._sizeIndex = 0;
			stepper(this.Add);
		}

		#endregion

		#region method

		private Node Find(T key, int loc)
		{
			for (Node bucket = _table[loc]; bucket != null; bucket = bucket.Next)
				if (_equate(bucket.Key, key))
					return bucket;
			return null;
		}

		private int ComputeHash(T key)
		{
			return (_hash(key) & 0x7fffffff) % _table.Length;
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

		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public Set_Hash<T> Clone()
		{
			return new Set_Hash<T>(this._equate, this._hash, this.Stepper);
		}

		#endregion

		#endregion

		#region Set<T>

		/// <summary>Returns the current number of items in the structure.</summary>
		/// <remarks>Runetime: O(1).</remarks>
		public int Count { get { return _count; } }

		/// <summary>The function for calculating hash codes for this table.</summary>
		public Hash<T> Hash { get { return _hash; } }

		/// <summary>The function for equating keys in this table.</summary>
		public Equate<T> Equate { get { return _equate; } }

		/// <summary>Determines if this structure contains a given item.</summary>
		/// <param name="item">The item to see if theis structure contains.</param>
		/// <returns>True if the item is in the structure; False if not.</returns>
		public bool Contains(T item)
		{
			Node cell = Find(item, ComputeHash(item));
			if (cell == null)
				return false;
			else
				return true;
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

		public void Clear()
		{
			_table = new Node[107];
			_count = 0;
			_sizeIndex = 0;
		}

		#endregion

		#region Structure<T>

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<T> function)
		{
			Node node;
			for (int i = 0; i < _table.Length; i++)
				if ((node = _table[i]) != null)
					do
					{
						function(node.Key);
					} while ((node = node.Next) != null);
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(StepRef<T> function)
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
		public StepStatus Stepper(StepBreak<T> function)
		{
			Node node;
			for (int i = 0; i < _table.Length; i++)
				if ((node = _table[i]) != null)
					do
					{
						if (function(node.Key) == StepStatus.Break)
							return StepStatus.Break;
					} while ((node = node.Next) != null);
			return StepStatus.Continue;
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepRefBreak<T> function)
		{
			Node node;
			for (int i = 0; i < _table.Length; i++)
				if ((node = _table[i]) != null)
					do
					{
						T temp = node.Key;
						StepStatus status = function(ref temp);
						node.Key = temp;
						if (status == StepStatus.Break)
							return StepStatus.Break;
					} while ((node = node.Next) != null);
			return StepStatus.Continue;
		}

		#endregion

		#region IEnumerator<T>

		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			Node node;
			for (int i = 0; i < _table.Length; i++)
				if ((node = _table[i]) != null)
					do
					{
						yield return node.Key;
					} while ((node = node.Next) != null);
		}

		System.Collections.Generic.IEnumerator<T>
			System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		{
			Node node;
			for (int i = 0; i < _table.Length; i++)
				if ((node = _table[i]) != null)
					do
					{
						yield return node.Key;
					} while ((node = node.Next) != null);
		}

		#endregion
	}
}
