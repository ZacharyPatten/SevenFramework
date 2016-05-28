// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Structures
{
	/// <summary>A map between instances of two types. The polymorphism base for Map implementations in Seven.</summary>
	/// <typeparam name="T">The generic type to be stored in this data structure.</typeparam>
	/// <typeparam name="K">The type of keys used to look up items in this structure.</typeparam>
	public interface Map<T, K> : Structure<T>,
		// Structure Properties
		Structure.Countable<T>,
		Structure.Clearable<T>,
		Structure.Auditable<K>,
		Structure.Removable<K>,
		Structure.Equating<K>
	{
		// properties
		#region T this[K key]
		/// <summary>Allows indexed look-up of the structure. (Set does not replace the Add() method)</summary>
		/// <param name="key">The "index" to access of the structure.</param>
		/// <returns>The value at the index of the requested key.</returns>
		T this[K key] { get; set; }
		#endregion
		// methods
		#region T Get(K key);
		/// <summary>Gets an item by key.</summary>
		/// <param name="key">The key of the item to get.</param>
		/// <returns>The by the provided key.</returns>
		T Get(K key);
		#endregion
		#region void Set(K key, T Value);
		/// <summary>Gets an item by key.</summary>
		/// <param name="key">The key of the item to get.</param>
		/// <returns>The by the provided key.</returns>
		void Set(K key, T Value);
		#endregion
		#region void Add(K key, T value);
		/// <summary>Adds a value to the hash table.</summary>
		/// <param name="key">The key value to use as the look-up reference in the hash table.</param>
		/// <param name="value">The value to store in the hash table.</param>
		void Add(K key, T value);
		#endregion
		#region void Keys(Step<K> step_function);
		/// <summary>Steps through all the keys.</summary>
		/// <param name="step_function">The step function.</param>
		void Keys(Step<K> step_function);
		#endregion
		#region StepStatus Keys(StepBreak<K> step_function);
		/// <summary>Steps through all the keys.</summary>
		/// <param name="step_function">The step function.</param>
		StepStatus Keys(StepBreak<K> step_function);
		#endregion
	}

	public static class Map
	{
		// extensions
		#region public static bool TryGet<T, Key>(this AvlTree<T> structure, Key get, Compare<T, Key> comparison, out T item)
		public static bool TryGet<T, K>(this Map<T, K> map, K key, out T item)
		{
			try
			{
				item = map.Get(key);
				return true;
			}
			catch
			{
				item = default(T);
				return false;
			}
		}
		#endregion
	}

	/// <summary>An unsorted structure of unique items.</summary>
	/// <typeparam name="T">The generic type of the structure.</typeparam>
	[System.Serializable]
	public class MapHashLinked<T, K> : Map<T, K>,
		// Structure Properties
		Structure.Hashing<K>
	{
		// fields
		internal const float _maxLoadFactor = .7f;
		internal const float _minLoadFactor = .3f;
		internal Equate<K> _equate;
		internal Hash<K> _hash;
		internal Node[] _table;
		internal int _count;
		// nested types
		#region private class Node
		[System.Serializable]
		internal class Node
		{
			internal K _key;
			internal T _value;
			internal Node _next;

			internal K Key { get { return _key; } set { _key = value; } }
			internal T Value { get { return _value; } set { _value = value; } }
			internal Node Next { get { return _next; } set { _next = value; } }

			internal Node(K key, T value, Node next)
			{
				this._key = key;
				this._value = value;
				this._next = next;
			}
		}
		#endregion
		// constructors
		#region public MapHashList()
		/// <summary>Constructs a new hash table instance.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public MapHashLinked() : this(Seven.Equate.Default, Seven.Hash.Default) { }
		#endregion
		#region public MapHashList(int expectedCount)
		/// <summary>Constructs a new hash table instance.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public MapHashLinked(int expectedCount) : this(Seven.Equate.Default, Seven.Hash.Default, expectedCount) { }
		#endregion
		#region public MapHashList(Equate<T> equate, Hash<T> hash)
		/// <summary>Constructs a new hash table instance.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public MapHashLinked(Equate<K> equate, Hash<K> hash) : this(Seven.Equate.Default, Seven.Hash.Default, 0) { }
		#endregion
		#region public MapHashList(Equate<T> equate, Hash<T> hash, int expectedCount)
		/// <summary>Constructs a new hash table instance.</summary>
		/// <remarks>Runtime: O(stepper).</remarks>
		public MapHashLinked(Equate<K> equate, Hash<K> hash, int expectedCount)
		{
			if (expectedCount > 0)
			{
				int prime = (int)(expectedCount * (1 / _maxLoadFactor));
				while (Seven.Mathematics.Compute<int>.IsPrime(prime))
					prime++;
				this._table = new Node[prime];
			}
			else
			{
				this._table = new Node[Seven.Hash.TableSizes[0]];
			}
			this._equate = equate;
			this._hash = hash;
			this._count = 0;
		}
		#endregion
		#region private MapHashList(SetHashList<T> setHashList)
		private MapHashLinked(MapHashLinked<T, K> setHashList)
		{
			this._equate = setHashList._equate;
			this._hash = setHashList._hash;
			this._table = setHashList._table.Clone() as Node[];
			this._count = setHashList._count;
		}
		#endregion
		// properties
		#region public T this[K key]
		public T this[K key]
		{
			get { return Get(key); }
			set { Set(key, value); }
		}
		#endregion
		#region public int TableSize
		/// <summary>Returns the current size of the actual table. You will want this if you 
		/// wish to multithread structure traversals.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public int TableSize { get { return _table.Length; } }
		#endregion
		#region public int Count
		/// <summary>Returns the current number of items in the structure.</summary>
		/// <remarks>Runetime: O(1).</remarks>
		public int Count { get { return _count; } }
		#endregion
		#region public Hash<T> Hash
		/// <summary>The function for calculating hash codes for this table.</summary>
		public Hash<K> Hash { get { return _hash; } }
		#endregion
		#region public Equate<T> Equate
		/// <summary>The function for equating keys in this table.</summary>
		public Equate<K> Equate { get { return _equate; } }
		#endregion
		// methods (public)
		#region public Set_Hash<T> Clone()
		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public MapHashLinked<T, K> Clone()
		{
			return new MapHashLinked<T, K>(this);
		}
		#endregion
		#region public bool Contains(K key)
		/// <summary>Determines if this structure contains a given item.</summary>
		/// <param name="item">The item to see if theis structure contains.</param>
		/// <returns>True if the item is in the structure; False if not.</returns>
		public bool Contains(K key)
		{
			if (Find(key, ComputeHash(key)) == null)
				return false;
			else
				return true;
		}
		#endregion
		#region System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
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
		#endregion
		#region System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
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
		#region public T Get(K key)
		/// <summary>Gets an item by key.</summary>
		/// <param name="key">The key of the item to get.</param>
		/// <returns>The by the provided key.</returns>
		public T Get(K key)
		{
			for (Node bucket = this._table[this._hash(key)]; bucket != null; bucket = bucket.Next)
				if (this._equate(bucket.Key, key))
					return bucket.Value;
			throw new System.InvalidOperationException("attempting to get a non-existing key from a map");
		}
		#endregion
		#region public void Set(K key, T value)
		public void Set(K key, T value)
		{
			if (this.Contains(key))
			{
				for (Node bucket = this._table[this._hash(key)]; bucket != null; bucket = bucket.Next)
					if (this._equate(bucket.Key, key))
					{
						bucket.Value = value;
					}
			}
			else
			{
				this.Add(key, value);
			}
		}
		#endregion
		#region public void Remove(T key)
		/// <summary>Removes a value from the hash table.</summary>
		/// <param name="key">The key of the value to remove.</param>
		/// <remarks>Runtime: N/A. (I'm still editing this structure)</remarks>
		public void Remove(K key)
		{
			Remove_private(key);
			if (this._count > Seven.Hash.TableSizes[0] && _count < this._table.Length * _minLoadFactor)
				Resize(GetSmallerSize());
		}
		#endregion
		#region public void RemoveWithoutTrim(T key)
		/// <summary>Removes a value from the hash table.</summary>
		/// <param name="key">The key of the value to remove.</param>
		/// <remarks>Runtime: N/A. (I'm still editing this structure)</remarks>
		public void RemoveWithoutTrim(K key)
		{
			Remove_private(key);
		}
		#endregion
		#region public void Add(T addition)
		/// <summary>Adds a value to the hash table.</summary>
		/// <param name="key">The key value to use as the look-up reference in the hash table.</param>
		/// <remarks>Runtime: O(n), Omega(1).</remarks>
		public void Add(K key, T value)
		{
			if (object.ReferenceEquals(null, key))
				throw new System.ArgumentNullException("key");
			int location = ComputeHash(key);
			if (Find(key, location) == null)
			{
				if (++_count > _table.Length * _maxLoadFactor)
				{
					if (Count == int.MaxValue)
						throw new System.InvalidOperationException("maximum size of hash table reached.");

					Resize(GetLargerSize());
					location = ComputeHash(key);
				}
				Node p = new Node(key, value, null);
				Add(p, location);
			}
			else
				throw new System.InvalidOperationException("\nMember: \"Add(TKey key, TValue value)\"\nThe key is already in the table.");
		}
		#endregion
		#region public void Clear()
		public void Clear()
		{
			_table = new Node[Seven.Hash.TableSizes[0]];
			_count = 0;
		}
		#endregion
		#region public void Keys(Step<K> function)
		/// <summary>Steps through all the keys.</summary>
		/// <param name="function">The step function.</param>
		public void Keys(Step<K> function)
		{
			Node node;
			for (int i = 0; i < _table.Length; i++)
				if ((node = _table[i]) != null)
					do
					{
						function(node.Key);
					} while ((node = node.Next) != null);
		}
		#endregion
		#region public StepStatus Keys(StepBreak<K> function)
		/// <summary>Steps through all the keys.</summary>
		/// <param name="step_function">The step function.</param>
		public StepStatus Keys(StepBreak<K> function)
		{
		Restart:
			Node node;
			for (int i = 0; i < _table.Length; i++)
				if ((node = _table[i]) != null)
					do
					{
						switch (function(node.Key))
						{
							case StepStatus.Break:
								return StepStatus.Break;
							case StepStatus.Continue:
								continue;
							case StepStatus.Previous:
								throw new System.NotImplementedException();
							case StepStatus.Restart:
								goto Restart;
							default:
								throw new System.NotImplementedException();
						}
					} while ((node = node.Next) != null);
			return StepStatus.Continue;
		}
		#endregion
		#region public void Stepper(Step<T> function)
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
		#endregion
		#region public StepStatus Stepper(StepBreak<T> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepBreak<T> function)
		{
		Restart:
			Node node;
			for (int i = 0; i < _table.Length; i++)
				if ((node = _table[i]) != null)
					do
					{
						switch (function(node.Value))
						{
							case StepStatus.Break:
								return StepStatus.Break;
							case StepStatus.Continue:
								continue;
							case StepStatus.Previous:
								throw new System.NotImplementedException();
							case StepStatus.Restart:
								goto Restart;
							default:
								throw new System.NotImplementedException();
						}
					} while ((node = node.Next) != null);
			return StepStatus.Continue;
		}
		#endregion
		#region public T[] ToArray()
		public T[] ToArray()
		{
			T[] array = new T[_count];
			int index = 0;
			Node node;
			for (int i = 0; i < _table.Length; i++)
				if ((node = _table[i]) != null)
					do
					{
						array[index++] = node.Value;
					} while ((node = node.Next) != null);
			return array;
		}
		#endregion
		#region public void Trim()
		public void Trim()
		{
			int prime = this._count;
			while (Seven.Mathematics.Compute<int>.IsPrime(prime))
				prime++;
			if (prime != this._table.Length)
				Resize(prime);
		}
		#endregion
		// methods internal
		#region internal void Add(Node cell, int location)
		internal void Add(Node cell, int location)
		{
			cell.Next = _table[location];
			_table[location] = cell;
		}
		#endregion
		#region internal int ComputeHash(T key)
		internal int ComputeHash(K key)
		{
			return (_hash(key) & 0x7fffffff) % _table.Length;
		}
		#endregion
		#region internal Node Find(T key, int loc)
		internal Node Find(K key, int loc)
		{
			for (Node bucket = _table[loc]; bucket != null; bucket = bucket.Next)
				if (this._equate(bucket.Key, key))
					return bucket;
			return null;
		}
		#endregion
		#region internal int GetLargerSize()
		internal int GetLargerSize()
		{
			for (int i = 0; i < Seven.Hash.TableSizes.Length; i++)
				if (this._table.Length < Seven.Hash.TableSizes[i])
					return Seven.Hash.TableSizes[i];
			return Seven.Hash.TableSizes[Seven.Hash.TableSizes[Seven.Hash.TableSizes.Length - 1]];
		}
		#endregion
		#region internal int GetSmallerSize()
		internal int GetSmallerSize()
		{
			for (int i = Seven.Hash.TableSizes.Length - 1; i > -1; i--)
				if (this._table.Length > Seven.Hash.TableSizes[i])
					return Seven.Hash.TableSizes[i];
			return Seven.Hash.TableSizes[0];
		}
		#endregion
		#region internal void Remove_private(T key)
		/// <summary>Removes a value from the hash table.</summary>
		/// <param name="key">The key of the value to remove.</param>
		/// <remarks>Runtime: N/A. (I'm still editing this structure)</remarks>
		internal void Remove_private(K key)
		{
			if (key == null)
				throw new System.ArgumentNullException("key");
			int location = ComputeHash(key);
			if (this._equate(this._table[location].Key, key))
				_table[location] = _table[location].Next;
			for (Node bucket = _table[location]; bucket != null; bucket = bucket.Next)
			{
				if (bucket.Next == null)
					throw new System.InvalidOperationException("attempting to remove a non-existing value.");
				else if (this._equate(bucket.Next.Key, key))
					bucket.Next = bucket.Next.Next;
			}
			_count--;
		}
		#endregion
		#region internal Node RemoveFirst(Node[] t, int i)
		internal Node RemoveFirst(Node[] t, int i)
		{
			Node first = t[i];
			t[i] = first.Next;
			return first;
		}
		#endregion
		#region internal void Resize(int size)
		internal void Resize(int size)
		{
			Node[] temp = _table;
			_table = new Node[size];
			for (int i = 0; i < temp.Length; i++)
			{
				while (temp[i] != null)
				{
					Node cell = RemoveFirst(temp, i);
					Add(cell, ComputeHash(cell.Key));
				}
			}
		}
		#endregion
	}

	/// <summary>An unsorted structure of unique items.</summary>
	/// <typeparam name="T">The generic type of the structure.</typeparam>
	[System.Serializable]
	public class MapHashArray<T, K> : Map<T, K>,
		// Structure Properties
		Structure.Hashing<K>
	{
		// fields
		private Equate<K> _equate;
		private Hash<K> _hash;
		private int[] _table;
		private Node[] _nodes;
		private int _count;
		private int _lastIndex;
		private int _freeList;
		// nested types
		#region private class Node
		[System.Serializable]
		private struct Node
		{
			private int _hash;
			private K _key;
			private T _value;
			private int _next;

			internal int Hash { get { return this._hash; } set { this._hash = value; } }
			internal K Key { get { return this._key; } set { this._key = value; } }
			internal T Value { get { return this._value; } set { this._value = value; } }
			internal int Next { get { return this._next; } set { this._next = value; } }

			internal Node(int hash, K key, T value, int next)
			{
				this._hash = hash;
				this._key = key;
				this._value = value;
				this._next = next;
			}
		}
		#endregion
		// constructors
		#region public SetHash()
		public MapHashArray() : this(Seven.Equate.Default, Seven.Hash.Default) { }
		#endregion
		#region public SetHashArray(int expectedCount)
		public MapHashArray(int expectedCount) : this(Seven.Equate.Default, Seven.Hash.Default) { }
		#endregion
		#region public Set_Hash(Equate<T> equate, Hash<T> hash)
		/// <summary>Constructs a new hash table instance.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public MapHashArray(Equate<K> equate, Hash<K> hash)
		{
			this._nodes = new Node[Seven.Hash.TableSizes[0]];
			this._table = new int[Seven.Hash.TableSizes[0]];
			this._equate = equate;
			this._hash = hash;
			this._lastIndex = 0;
			this._count = 0;
			this._freeList = -1;
		}
		#endregion
		// properties
		#region public T this[K key]
		public T this[K key]
		{
			get { return Get(key); }
			set { Set(key, value); }
		}
		#endregion
		#region public int TableSize
		/// <summary>Returns the current size of the actual table. You will want this if you 
		/// wish to multithread structure traversals.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public int TableSize { get { return _table.Length; } }
		#endregion
		#region public int Count
		/// <summary>Returns the current number of items in the structure.</summary>
		/// <remarks>Runetime: O(1).</remarks>
		public int Count { get { return _count; } }
		#endregion
		#region public Hash<T> Hash
		/// <summary>The function for calculating hash codes for this table.</summary>
		public Hash<K> Hash { get { return _hash; } }
		#endregion
		#region public Equate<T> Equate
		/// <summary>The function for equating keys in this table.</summary>
		public Equate<K> Equate { get { return _equate; } }
		#endregion
		// methods (public)
		#region public void Add(T addition)
		public void Add(K key, T value)
		{
			//if (this._buckets == null)
			//	this.Initialize(0);
			int hashCode = this._hash(key);
			int index1 = hashCode % this._table.Length;
			int num = 0;
			for (int index2 = this._table[hashCode % this._table.Length] - 1; index2 >= 0; index2 = this._nodes[index2].Next)
			{
				if (this._nodes[index2].Hash == hashCode && this._equate(this._nodes[index2].Key, key))
					throw new System.InvalidOperationException("attempting to add an already existing value in the SetHash");
				++num;
			}
			int index3;
			if (this._freeList >= 0)
			{
				index3 = this._freeList;
				this._freeList = this._nodes[index3].Next;
			}
			else
			{
				if (this._lastIndex == this._nodes.Length)
				{
					GrowTableSize(GetLargerSize());
					index1 = hashCode % this._table.Length;
				}
				index3 = this._lastIndex;
				this._lastIndex = this._lastIndex + 1;
			}
			this._nodes[index3].Hash = hashCode;
			this._nodes[index3].Key = key;
			this._nodes[index3].Value = value;
			this._nodes[index3].Next = this._table[index1] - 1;
			this._table[index1] = index3 + 1;
			this._count += 1;
		}
		#endregion
		#region public void Clear()
		public void Clear()
		{
			if (this._lastIndex > 0)
			{
				this._nodes = new Node[Seven.Hash.TableSizes[0]];
				this._table = new int[Seven.Hash.TableSizes[0]];
				this._lastIndex = 0;
				this._count = 0;
				this._freeList = -1;
			}
		}
		#endregion
		#region public void ClearWithoutShrink()
		public void ClearWithoutShrink()
		{
			if (this._lastIndex > 0)
			{
				System.Array.Clear((System.Array)this._nodes, 0, this._lastIndex);
				System.Array.Clear((System.Array)this._table, 0, this._table.Length);
				this._lastIndex = 0;
				this._count = 0;
				this._freeList = -1;
			}
		}
		#endregion
		#region public bool Contains(T value)
		public bool Contains(K key)
		{
			int hashCode = this._hash(key);
			for (int index = this._table[hashCode % this._table.Length] - 1; index >= 0; index = this._nodes[index].Next)
			{
				if (this._nodes[index].Hash == hashCode && this._equate(this._nodes[index].Key, key))
					return true;
			}
			return false;
		}
		#endregion
		#region System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			int num = 0;
			for (int index = 0; index < this._lastIndex && num < this._count; ++index)
			{
				if (this._nodes[index].Hash >= 0)
				{
					++num;
					yield return this._nodes[index].Value;
				}
			}
		}
		#endregion
		#region System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		System.Collections.Generic.IEnumerator<T>
			System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		{
			int num = 0;
			for (int index = 0; index < this._lastIndex && num < this._count; ++index)
			{
				if (this._nodes[index].Hash >= 0)
				{
					++num;
					yield return this._nodes[index].Value;
				}
			}
		}
		#endregion
		#region public T Get(K key)
		/// <summary>Gets an item by key.</summary>
		/// <param name="key">The key of the item to get.</param>
		/// <returns>The by the provided key.</returns>
		public T Get(K key)
		{
			int hashCode = this._hash(key);
			for (int index = this._table[hashCode % this._table.Length] - 1; index >= 0; index = this._nodes[index].Next)
			{
				if (this._nodes[index].Hash == hashCode && this._equate(this._nodes[index].Key, key))
					return this._nodes[index].Value;
			}
			throw new System.InvalidOperationException("attempting to get a non-existing key from a map");
		}
		#endregion
		#region public void Set(K key, T value)
		public void Set(K key, T value)
		{
			if (this.Contains(key))
			{
				int hashCode = this._hash(key);
				for (int index = this._table[hashCode % this._table.Length] - 1; index >= 0; index = this._nodes[index].Next)
				{
					if (this._nodes[index].Hash == hashCode && this._equate(this._nodes[index].Key, key))
						this._nodes[index].Value = value;
				}
			}
			else
			{
				this.Add(key, value);
			}
		}
		#endregion
		#region public void Remove(K removal)
		public void Remove(K removal)
		{
			this.Remove_private(removal);
			int smallerSize = GetSmallerSize();
			if (this._count < smallerSize)
				ShrinkTableSize(smallerSize);
		}
		#endregion
		#region public void RemoveWithoutShrink(T removal)
		public void RemoveWithoutShrink(K removal)
		{
			this.Remove_private(removal);
		}
		#endregion
		#region public T[] ToArray()
		public T[] ToArray()
		{
			T[] array = new T[this._count];
			int num = 0;
			for (int index = 0; index < this._lastIndex && num < this._count; ++index)
			{
				if (this._nodes[index].Hash >= 0)
				{
					array[num] = this._nodes[index].Value;
					++num;
				}
			}
			return array;
		}
		#endregion
		#region public void Trim()
		public void Trim()
		{
			int prime = this._count;
			while (Seven.Mathematics.Compute<int>.IsPrime(prime))
				prime++;
			if (prime != this._table.Length)
				ShrinkTableSize(prime);
		}
		#endregion
		#region public void Keys(Step<K> function)
		/// <summary>Steps through all the keys.</summary>
		/// <param name="function">The step function.</param>
		public void Keys(Step<K> function)
		{
			int num = 0;
			for (int index = 0; index < this._lastIndex && num < this._count; ++index)
			{
				if (this._nodes[index].Hash >= 0)
				{
					++num;
					function(this._nodes[index].Key);
				}
			}
		}
		#endregion
		#region public StepStatus Keys(StepBreak<K> function)
		/// <summary>Steps through all the keys.</summary>
		/// <param name="step_function">The step function.</param>
		public StepStatus Keys(StepBreak<K> function)
		{
		Restart:
			int num = 0;
			for (int index = 0; index < this._lastIndex && num < this._count; ++index)
			{
				if (this._nodes[index].Hash >= 0)
				{
					++num;
					switch (function(this._nodes[index].Key))
					{
						case StepStatus.Break:
							return StepStatus.Break;
						case StepStatus.Continue:
							continue;
						case StepStatus.Previous:
							throw new System.NotImplementedException();
						case StepStatus.Restart:
							goto Restart;
						default:
							throw new System.NotImplementedException();
					}
				}
			}
			return StepStatus.Continue;
		}
		#endregion
		#region public void Stepper(Step<T> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<T> function)
		{
			int num = 0;
			for (int index = 0; index < this._lastIndex && num < this._count; ++index)
			{
				if (this._nodes[index].Hash >= 0)
				{
					++num;
					function(this._nodes[index].Value);
				}
			}
		}
		#endregion
		#region public StepStatus Stepper(StepBreak<T> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepBreak<T> function)
		{
		Restart:
			int num = 0;
			for (int index = 0; index < this._lastIndex && num < this._count; ++index)
			{
				if (this._nodes[index].Hash >= 0)
				{
					++num;
					switch (function(this._nodes[index].Value))
					{
						case StepStatus.Break:
							return StepStatus.Break;
						case StepStatus.Continue:
							continue;
						case StepStatus.Previous:
							throw new System.NotImplementedException();
						case StepStatus.Restart:
							goto Restart;
						default:
							throw new System.NotImplementedException();
					}
				}
			}
			return StepStatus.Continue;
		}
		#endregion
		// methods (private)
		#region private int GetLargerSize()
		private int GetLargerSize()
		{
			for (int i = 0; i < Seven.Hash.TableSizes.Length; i++)
				if (this._table.Length < Seven.Hash.TableSizes[i])
					return Seven.Hash.TableSizes[i];
			return Seven.Hash.TableSizes[Seven.Hash.TableSizes[Seven.Hash.TableSizes.Length - 1]];
		}
		#endregion
		#region private int GetSmallerSize()
		private int GetSmallerSize()
		{
			for (int i = Seven.Hash.TableSizes.Length - 1; i > -1; i--)
				if (this._table.Length > Seven.Hash.TableSizes[i])
					return Seven.Hash.TableSizes[i];
			return Seven.Hash.TableSizes[0];
		}
		#endregion
		#region private void GrowTableSize(int newSize)
		private void GrowTableSize(int newSize)
		{
			Node[] slotArray = new Node[newSize];
			if (this._nodes != null)
			{
				//System.Array.Copy((System.Array)this._nodes, 0, (System.Array)slotArray, 0, this._lastIndex);

				for (int i = 0; i < this._lastIndex; i++)
					slotArray[i] = this._nodes[i];
			}
			int[] numArray = new int[newSize];
			for (int index1 = 0; index1 < this._lastIndex; ++index1)
			{
				int index2 = slotArray[index1].Hash % newSize;
				slotArray[index1].Next = numArray[index2] - 1;
				numArray[index2] = index1 + 1;
			}
			this._nodes = slotArray;
			this._table = numArray;
		}
		#endregion
		#region private void Remove_private(T removal)
		private void Remove_private(K removal)
		{
			int hashCode = this._hash(removal);
			int index1 = hashCode % this._table.Length;
			int index2 = -1;
			for (int index3 = this._table[index1] - 1; index3 >= 0; index3 = this._nodes[index3].Next)
			{
				if (this._nodes[index3].Hash == hashCode && this._equate(this._nodes[index3].Key, removal))
				{
					if (index2 < 0)
						this._table[index1] = this._nodes[index3].Next + 1;
					else
						this._nodes[index2].Next = this._nodes[index3].Next;
					this._nodes[index3].Hash = -1;
					this._nodes[index3].Value = default(T);
					this._nodes[index3].Next = this._freeList;
					this._count -= 1;
					if (this._count == 0)
					{
						this._lastIndex = 0;
						this._freeList = -1;
					}
					else
						this._freeList = index3;
					return;
				}
				else
					index2 = index3;
			}
			throw new System.InvalidOperationException("attempting to remove a non-existing value in a SetHash");
		}
		#endregion
		#region private void ShrinkTableSize(int newSize)
		private void ShrinkTableSize(int newSize)
		{
			Node[] slotArray = new Node[newSize];
			int[] numArray = new int[newSize];
			int index1 = 0;
			for (int index2 = 0; index2 < this._lastIndex; ++index2)
			{
				if (this._nodes[index2].Hash >= 0)
				{
					slotArray[index1] = this._nodes[index2];
					int index3 = slotArray[index1].Hash % newSize;
					slotArray[index1].Next = numArray[index3] - 1;
					numArray[index3] = index1 + 1;
					++index1;
				}
			}
			this._lastIndex = index1;
			this._nodes = slotArray;
			this._table = numArray;
			this._freeList = -1;
		}
		#endregion
	}

	#region using set

	///// <summary>A map between instances of two types. The polymorphism base for Map implementations in Seven.</summary>
	///// <typeparam name="T">The generic type to be stored in this data structure.</typeparam>
	///// <typeparam name="K">The type of keys used to look up items in this structure.</typeparam>
	//[System.Serializable]
	//public class MapSetHashList<T, K> : Map<T, K>,
	//	// Structure Properties
	//	Structure.Hashing<K>
	//{
	//	private SetHashList<Node> _set_Hash;
	//	private Equate<K> _equate;
	//	private Hash<K> _hash;
	//	// nested types
	//	#region public interface Node
	//	internal interface Node
	//	{
	//		K Key { get; }
	//		T Value { get; set; }
	//	}
	//	#endregion
	//	#region public struct PairNode
	//	internal struct PairNode : Node
	//	{
	//		internal K _key;
	//		internal T _value;

	//		public K Key { get { return this._key; } }
	//		public T Value
	//		{
	//			get { return this._value; }
	//			set { this._value = value; }
	//		}

	//		public PairNode(K key, T value)
	//		{
	//			this._key = key;
	//			this._value = value;
	//		}
	//	}
	//	#endregion
	//	#region public struct KeyNode
	//	internal struct KeyNode : Node
	//	{
	//		internal K _key;

	//		public K Key { get { return this._key; } }
	//		public T Value
	//		{
	//			get { throw new System.InvalidOperationException("There is a bug in " + this.GetType().ToCsharpSource() + " (attempted to get the value of a KeyNode)"); }
	//			set { throw new System.InvalidOperationException("There is a bug in " + this.GetType().ToCsharpSource() + " (attempted to set the value of a KeyNode)"); }
	//		}

	//		public KeyNode(K key)
	//		{
	//			this._key = key;
	//		}

	//		public static implicit operator KeyNode(K key)
	//		{
	//			return new KeyNode(key);
	//		}
	//	}
	//	#endregion
	//	//constructors
	//	#region public MapSetHash()
	//	public MapSetHashList() : this(Seven.Equate.Default, Seven.Hash.Default, 0) { }
	//	#endregion
	//	#region public MapSetHash(int expectedCount)
	//	public MapSetHashList(int expectedCount) : this(Seven.Equate.Default, Seven.Hash.Default, expectedCount) { }
	//	#endregion
	//	#region public MapSetHash(Equate<K> equate, Hash<K> hash)
	//	public MapSetHashList(Equate<K> equate, Hash<K> hash) : this(equate, hash, 0) { }
	//	#endregion
	//	#region public MapSetHash(Equate<K> equate, Hash<K> hash, int expectedCount)
	//	/// <summary>Constructs a new hash table instance.</summary>
	//	/// <remarks>Runtime: O(1).</remarks>
	//	public MapSetHashList(Equate<K> equate, Hash<K> hash, int expectedCount)
	//	{
	//		this._equate = equate;
	//		this._hash = hash;
	//		this._set_Hash = new SetHashList<Node>(
	//			(Node a, Node b) => { return equate(a.Key, b.Key); },
	//			(Node a) => { return hash(a.Key); },
	//			expectedCount);
	//	}
	//	#endregion
	//	// properties
	//	#region public Hash<K> Hash
	//	/// <summary>The function for calculating hash codes for this table.</summary>
	//	public Hash<K> Hash { get { return this._hash; } }
	//	#endregion
	//	#region public Equate<K> Equate
	//	/// <summary>The function for equating keys in this table.</summary>
	//	public Equate<K> Equate { get { return _equate; } }
	//	#endregion
	//	#region public int Count
	//	/// <summary>Returns the current number of items in the structure.</summary>
	//	/// <remarks>Runetime: O(1).</remarks>
	//	public int Count { get { return this._set_Hash.Count; } }
	//	#endregion
	//	#region public int TableSize
	//	/// <summary>Returns the current size of the actual table. You will want this if you 
	//	/// wish to multithread structure traversals.</summary>
	//	/// <remarks>Runtime: O(1).</remarks>
	//	public int TableSize { get { return this._set_Hash.TableSize; } }
	//	#endregion
	//	#region public T this[K key]
	//	/// <summary>Allows indexed look-up of the structure. (Set does not replace the Add() method)</summary>
	//	/// <param name="key">The "index" to access of the structure.</param>
	//	/// <returns>The value at the index of the requested key.</returns>
	//	/// <remarks>Runtime: N/A.</remarks>
	//	public T this[K key]
	//	{
	//		get { return this.Get(key); }
	//		set { this.Set(key, value); }
	//	}
	//	#endregion
	//	// methods
	//	#region public T[] ToArray()
	//	public T[] ToArray()
	//	{
	//		if (this._set_Hash.Count == 0)
	//			return null;
	//		T[] array = new T[this._set_Hash.Count];
	//		int i = 0;
	//		this._set_Hash.Stepper((Node node) => { array[i++] = node.Value; });
	//		return array;
	//	}
	//	#endregion
	//	#region public Structure<T> Clone()
	//	/// <summary>Creates a shallow clone of this data structure.</summary>
	//	/// <returns>A shallow clone of this data structure.</returns>
	//	public Structure<T> Clone()
	//	{
	//		throw new System.NotImplementedException();
	//	}
	//	#endregion
	//	#region public bool Contains(K key)
	//	/// <summary>Checks if this map already contains a given key.</summary>
	//	/// <param name="key">The key to check for.</param>
	//	/// <returns>True if contains. False if not contained.</returns>
	//	public bool Contains(K key)
	//	{
	//		return this._set_Hash.Contains(new KeyNode(key));
	//	}
	//	#endregion
	//	#region public T Get(K key)
	//	/// <summary>Gets an item by key.</summary>
	//	/// <param name="key">The key of the item to get.</param>
	//	/// <returns>The by the provided key.</returns>
	//	public T Get(K key)
	//	{
	//		for (SetHashList<Node>.Node bucket = this._set_Hash._table[this._hash(key)]; bucket != null; bucket = bucket.Next)
	//			if (this._equate(bucket.Value.Key, key))
	//				return bucket._value.Value;
	//		throw new System.InvalidOperationException("attempting to get a non-existing key from a map");
	//	}
	//	#endregion
	//	#region public void Set(K key, T value)
	//	public void Set(K key, T value)
	//	{
	//		if (this._set_Hash.Contains(new KeyNode(key)))
	//		{
	//			for (SetHashList<Node>.Node bucket = this._set_Hash._table[this._hash(key)]; bucket != null; bucket = bucket.Next)
	//				if (this._equate(bucket.Value.Key, key))
	//				{
	//					bucket._value.Value = value;
	//				}
	//		}
	//		else
	//		{
	//			this._set_Hash.Add(new PairNode(key, value));
	//		}
	//	}
	//	#endregion
	//	#region public void Add(K key, T value)
	//	/// <summary>Adds a value to the hash table.</summary>
	//	/// <param name="key">The key value to use as the look-up reference in the hash table.</param>
	//	/// <param name="value">The value to store in the hash table.</param>
	//	/// <remarks>Runtime: O(n), Omega(1).</remarks>
	//	public void Add(K key, T value)
	//	{
	//		this._set_Hash.Add(new PairNode(key, value));
	//	}
	//	#endregion
	//	#region public void Remove(K key)
	//	/// <summary>Removes a value from the hash table.</summary>
	//	/// <param name="key">The key of the value to remove.</param>
	//	/// <remarks>Runtime: N/A. (I'm still editing this structure)</remarks>
	//	public void Remove(K key)
	//	{
	//		this._set_Hash.Remove(new KeyNode(key));
	//	}
	//	#endregion
	//	#region public void Keys(Step<K> function)
	//	/// <summary>Steps through all the keys.</summary>
	//	/// <param name="function">The step function.</param>
	//	public void Keys(Step<K> function)
	//	{
	//		this._set_Hash.Stepper((Node node) => { function(node.Key); });
	//	}
	//	#endregion
	//	#region public StepStatus Keys(StepBreak<K> function)
	//	/// <summary>Steps through all the keys.</summary>
	//	/// <param name="step_function">The step function.</param>
	//	public StepStatus Keys(StepBreak<K> function)
	//	{
	//		return this._set_Hash.Stepper((Node node) => { return function(node.Key); });
	//	}
	//	#endregion
	//	#region public void Clear()
	//	/// <summary>Returns the map to an empty state.</summary>
	//	public void Clear()
	//	{
	//		this._set_Hash.Clear();
	//	}
	//	#endregion
	//	#region public void Stepper(Step<T> function)
	//	/// <summary>Invokes a delegate for each entry in the data structure.</summary>
	//	/// <param name="function">The delegate to invoke on each item in the structure.</param>
	//	public void Stepper(Step<T> function)
	//	{
	//		this._set_Hash.Stepper((Node node) => { function(node.Value); });
	//	}
	//	#endregion
	//	#region public StepStatus Stepper(StepBreak<T> function)
	//	/// <summary>Invokes a delegate for each entry in the data structure.</summary>
	//	/// <param name="function">The delegate to invoke on each item in the structure.</param>
	//	/// <returns>The resulting status of the iteration.</returns>
	//	public StepStatus Stepper(StepBreak<T> function)
	//	{
	//		return this._set_Hash.Stepper((Node node) => { return function(node.Value); });
	//	}
	//	#endregion
	//	#region System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
	//	System.Collections.IEnumerator
	//		System.Collections.IEnumerable.GetEnumerator()
	//	{
	//		return (this._set_Hash as System.Collections.IEnumerable).GetEnumerator();
	//	}
	//	#endregion
	//	#region System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
	//	System.Collections.Generic.IEnumerator<T>
	//		System.Collections.Generic.IEnumerable<T>.GetEnumerator()
	//	{
	//		return (this._set_Hash as System.Collections.Generic.IEnumerable<T>).GetEnumerator();
	//	}
	//	#endregion
	//}

	#endregion
}
