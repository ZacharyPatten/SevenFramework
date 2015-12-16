// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Structures
{
	/// <summary>A map between instances of two types. The polymorphism base for Map implementations in Seven.</summary>
	/// <typeparam name="T">The generic type to be stored in this data structure.</typeparam>
	/// <typeparam name="K">The type of keys used to look up items in this structure.</typeparam>
	public interface Map<T, K> : Structure<T>
	{
		#region member

		/// <summary>Allows indexed look-up of the structure. (Set does not replace the Add() method)</summary>
		/// <param name="key">The "index" to access of the structure.</param>
		/// <returns>The value at the index of the requested key.</returns>
		T this[K key] { get; set; }
		/// <summary>Returns the current number of items in the structure.</summary>
		int Count { get; }
		/// <summary>The function for calculating hash codes for this table.</summary>
		Hash<K> Hash { get; }
		/// <summary>The function for equating keys in this table.</summary>
		Equate<K> Equate { get; }

		/// <summary>Gets an item by key.</summary>
		/// <param name="key">The key of the item to get.</param>
		/// <returns>The by the provided key.</returns>
		T Get(K key);
		/// <summary>Typical try-get functionality for data structures.</summary>
		/// <param name="key">The key to look up the value for.</param>
		/// <param name="value">The return value if the value is found (returns default if not).</param>
		/// <returns>True if the requested key look up found a value.</returns>
		bool TryGet(K key, out T value);
		/// <summary>Checks if this map already contains a given key.</summary>
		/// <param name="key">The key to check for.</param>
		/// <returns>True if contains. False if not contained.</returns>
		bool Contains(K key);
		/// <summary>Adds a value to the hash table.</summary>
		/// <param name="key">The key value to use as the look-up reference in the hash table.</param>
		/// <param name="value">The value to store in the hash table.</param>
		void Add(K key, T value);
		/// <summary>Removes a value from the hash table.</summary>
		/// <param name="key">The key of the value to remove.</param>
		void Remove(K key);
		/// <summary>Steps through all the keys.</summary>
		/// <param name="step_function">The step function.</param>
		void Keys(Step<K> step_function);
		/// <summary>Steps through all the keys.</summary>
		/// <param name="step_function">The step function.</param>
		StepStatus Keys(StepBreak<K> step_function);
		/// <summary>Returns the map to an empty state.</summary>
		void Clear();

		#endregion
	}

	/// <summary>A map between instances of two types. The polymorphism base for Map implementations in Seven.</summary>
	/// <typeparam name="T">The generic type to be stored in this data structure.</typeparam>
	/// <typeparam name="K">The type of keys used to look up items in this structure.</typeparam>
	[System.Serializable]
	public class Map_Linked<T, K> : Map<T, K>
	{
		#region Node

		[System.Serializable]
		private class Node
		{
			private K _key;
			private T _value;
			private Node _next;

			internal K Key { get { return _key; } set { _key = value; } }
			internal T Value { get { return _value; } set { _value = value; } }
			internal Node Next { get { return _next; } set { _next = value; } }

			internal Node(K key, T value, Node next)
			{
				_key = key;
				_value = value;
				_next = next;
			}
		}

		#endregion

		#region Map_Linked<T, K>

		#region field

		/// <summary>A set of allowable table sizes, all of which are prime.</summary>
		private static readonly int[] _tableSizes = new int[]
		{
				1, 2, 5, 11, 23, 47, 97, 197, 397, 797, 1597, 3203, 6421, 12853, 25717, 51437,
				102877, 205759, 411527, 823117, 1646237, 3292489, 6584983, 13169977, 26339969,
				52679969, 105359939, 210719881, 421439783, 842879579, 1685759167
		};

		private const double _maxLoadFactor = 1.0d;

		private Equate<K> _equate;
		private Hash<K> _hash;
		private Node[] _table;
		private int _count;
		private int _sizeIndex;

		#endregion

		#region property

		/// <summary>The function for calculating hash codes for this table.</summary>
		public Hash<K> Hash { get { return _hash; } }

		/// <summary>The function for equating keys in this table.</summary>
		public Equate<K> Equate { get { return _equate; } }

		/// <summary>Returns the current number of items in the structure.</summary>
		/// <remarks>Runetime: O(1).</remarks>
		public int Count { get { return _count; } }

		/// <summary>Returns the current size of the actual table. You will want this if you 
		/// wish to multithread structure traversals.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public int TableSize { get { return _table.Length; } }

		/// <summary>Allows indexed look-up of the structure. (Set does not replace the Add() method)</summary>
		/// <param name="key">The "index" to access of the structure.</param>
		/// <returns>The value at the index of the requested key.</returns>
		/// <remarks>Runtime: N/A.</remarks>
		public T this[K key]
		{
			get
			{
				T temp;
				if (TryGet(key, out temp))
					return temp;
				else
					throw new Error("Attempting to look up a non-existing key.");
			}
			set
			{
				Node cell = Find(key, ComputeHash(key));
				if (cell == null)
					throw new Error("Index out of range (key not found). This does not replace the add method.");
				else
					cell.Value = value;
			}
		}

		#endregion

		#region construct

		/// <summary>Constructs a new hash table instance.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public Map_Linked(Equate<K> equate, Hash<K> hash)
		{
			this._equate = equate;
			this._hash = hash;
			_table = new Node[_tableSizes[0]];
			_count = 0;
			_sizeIndex = 0;
		}

		#endregion

		#region method

		private Node Find(K key, int loc)
		{
			for (Node bucket = this._table[loc]; bucket != null; bucket = bucket.Next)
				if (this._equate(bucket.Key, key))
					return bucket;
			return null;
		}

		private int ComputeHash(K key)
		{
			return (this._hash(key) & 0x7fffffff) % this._table.Length;
		}

		public T[] ToArray()
		{
			T[] array = new T[this._count];
			int index = 0;
			Node node;
			for (int i = 0; i < this._table.Length; i++)
				if ((node = this._table[i]) != null)
					do
					{
						array[index++] = node.Value;
					} while ((node = node.Next) != null);
			return array;
		}

		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public Structure<T> Clone()
		{
			throw new System.NotImplementedException();
		}

		#endregion

		#endregion

		#region Map<T, K>

		/// <summary>Checks if this map already contains a given key.</summary>
		/// <param name="key">The key to check for.</param>
		/// <returns>True if contains. False if not contained.</returns>
		public bool Contains(K key)
		{
			Node cell = Find(key, ComputeHash(key));
			if (cell == null)
				return false;
			else
				return true;
		}

		/// <summary>Gets an item by key.</summary>
		/// <param name="key">The key of the item to get.</param>
		/// <returns>The by the provided key.</returns>
		public T Get(K key)
		{
			Node cell = Find(key, ComputeHash(key));
			if (cell == null)
				throw new Error("attempting to get a non-existing key value.");
			else
			{
				T returnValue = cell.Value;
				return returnValue;
			}
		}

		/// <summary>Typical try-get functionality for data structures.</summary>
		/// <param name="key">The key to look up the value for.</param>
		/// <param name="value">The return value if the value is found (returns default if not).</param>
		/// <returns>True if the requested key look up found a value.</returns>
		/// <remarks>Runtime: O(1).</remarks>
		public bool TryGet(K key, out T value)
		{
			Node cell = Find(key, ComputeHash(key));
			if (cell == null)
			{
				value = default(T);
				return false;
			}
			else
			{
				value = cell.Value;
				return true;
			}
		}

		/// <summary>Adds a value to the hash table.</summary>
		/// <param name="key">The key value to use as the look-up reference in the hash table.</param>
		/// <param name="value">The value to store in the hash table.</param>
		/// <remarks>Runtime: O(n), Omega(1).</remarks>
		public void Add(K key, T value)
		{
			if (key == null)
				throw new Error("attempting to add a null key to the structure.");
			int location = ComputeHash(key);
			if (this.Find(key, location) == null)
			{
				if (++this._count > this._table.Length * Map_Linked<T, K>._maxLoadFactor)
				{
					if (this._sizeIndex + 1 == Map_Linked<T, K>._tableSizes.Length)
						throw new Error("maximum size " + Map_Linked<T, K>._tableSizes[Map_Linked<T, K>._tableSizes.Length - 1] + " of hash table reached.");
					Node[] old_table = this._table;
					this._table = new Node[_tableSizes[++this._sizeIndex]];
					for (int i = 0; i < old_table.Length; i++)
					{
						while (old_table[i] != null)
						{
							Node cell = old_table[i];
							old_table[i] = old_table[i].Next;
							int hash = ComputeHash(cell.Key);
							cell.Next = this._table[hash];
							this._table[hash] = cell;
						}
					}
					location = ComputeHash(key);
				}
				Node p = new Node(key, value, null);
				p.Next = this._table[location];
				this._table[location] = p;
			}
			else
				throw new Error("adding an already existing key a map");
		}

		/// <summary>Removes a value from the hash table.</summary>
		/// <param name="key">The key of the value to remove.</param>
		/// <remarks>Runtime: N/A. (I'm still editing this structure)</remarks>
		public void Remove(K key)
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

		/// <summary>Steps through all the keys.</summary>
		/// <param name="step_function">The step function.</param>
		public void Keys(Step<K> step_function)
		{
			Node node;
			for (int i = 0; i < _table.Length; i++)
				if ((node = _table[i]) != null)
					do
					{
						step_function(node.Key);
					} while ((node = node.Next) != null);
		}

		/// <summary>Steps through all the keys.</summary>
		/// <param name="step_function">The step function.</param>
		public StepStatus Keys(StepBreak<K> function)
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

		/// <summary>Returns the map to an empty state.</summary>
		public void Clear()
		{
			this._table = new Node[_tableSizes[0]];
			this._count = 0;
			this._sizeIndex = 0;
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
						function(node.Value);
					} while ((node = node.Next) != null);
		}

		///// <summary>Invokes a delegate for each entry in the data structure.</summary>
		///// <param name="function">The delegate to invoke on each item in the structure.</param>
		//public void Stepper(StepRef<T> function)
		//{
		//	Node node;
		//	for (int i = 0; i < _table.Length; i++)
		//		if ((node = _table[i]) != null)
		//			do
		//			{
		//				T temp = node.Value;
		//				function(ref temp);
		//				node.Value = temp;
		//			} while ((node = node.Next) != null);
		//}

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
						if (function(node.Value) == StepStatus.Break)
							return StepStatus.Break;
					} while ((node = node.Next) != null);
			return StepStatus.Continue;
		}

		///// <summary>Invokes a delegate for each entry in the data structure.</summary>
		///// <param name="function">The delegate to invoke on each item in the structure.</param>
		///// <returns>The resulting status of the iteration.</returns>
		//public StepStatus Stepper(StepRefBreak<T> function)
		//{
		//	Node node;
		//	for (int i = 0; i < _table.Length; i++)
		//		if ((node = _table[i]) != null)
		//			do
		//			{
		//				T temp = node.Value;
		//				StepStatus status = function(ref temp);
		//				node.Value = temp;
		//				if (status == StepStatus.Break)
		//					return StepStatus.Break;
		//			} while ((node = node.Next) != null);
		//	return StepStatus.Continue;
		//}

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
						yield return node.Value;
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
						yield return node.Value;
					} while ((node = node.Next) != null);
		}

		#endregion
	}
}
