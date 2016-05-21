// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven
{
	/// <summary>Delegate for hash code computation.</summary>
	/// <typeparam name="T">The type of this hash function.</typeparam>
	/// <param name="item">The instance to compute the hash of.</param>
	/// <returns>The computed hash of the given item.</returns>
	[System.Serializable]
	public delegate int Hash<T>(T item);

	/// <summary>Static wrapper for the based "object.GetHashCode" fuction.</summary>
	public static class Hash
	{
		/// <summary>Static wrapper for the instance based "object.GetHashCode" fuction.</summary>
		/// <typeparam name="T">The generic type of the hash operation.</typeparam>
		/// <param name="item">The item to get the hash code of.</param>
		/// <returns>The computed hash code using the base GetHashCode instance method.</returns>
		public static int Default<T>(T item) { return item.GetHashCode(); }

		/// <summary>used for hash tables in this project. NOTE: CHANGING THESE VALUES MIGHT BREAK HASH TABLES</summary>
		internal static readonly int[] TableSizes = {
			2, 3, 7, 11, 17, 23, 29, 37, 47, 59, 71, 89, 107, 131, 163, 197, 239, 293, 353, 431, 521, 631, 761, 919, 
			1103, 1327, 1597, 1931, 2333, 2801, 3371, 4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591, 17519,
			21023, 25229, 30293, 36353, 43627, 52361, 62851, 75431, 90523, 108631, 130363, 156437, 187751, 225307,
			270371, 324449, 389357, 467237, 560689, 672827, 807403, 968897, 1162687, 1395263, 1674319, 2009191,
			2411033, 2893249, 3471899, 4166287, 4999559, 5999471, 7199369, 8639243, 10367097, 12440522, 14928634,
			17914370, 21497255, 25796719, 30956079, 37147314, 44576800, 53492188, 64190659, 77028831, 92434645,
			110921632, 133106028, 159727317, 191672881, 230007578, 276009239, 331211261, 397453722, 476944718,
			572333963, 686801118, 824161776, 988994653, 1186794210, 1424153803, 1708985465, 2050783640, int.MaxValue };

		///// <summary>A hash table of linked lists.</summary>
		///// <typeparam name="T">The generic type of the structure.</typeparam>
		//internal class HashLinked<NODE>
		//	where NODE : class, HashLinked<NODE>.Node
		//{
		//	// fields
		//	internal const float _maxLoadFactor = .7f;
		//	internal const float _minLoadFactor = .3f;
		//	internal NODE[] _table;
		//	internal int _count;

		//	//internal Equate<>
		//	//internal Compare<NODE> _compare; 
		//	// nested types
		//	#region internal abstract class Node
		//	internal abstract class Node
		//	{
		//		internal NODE Next { get; set; }
		//		internal bool HashObjectEquate(NODE b);
		//		internal int HashObjectGetHashCode();
		//	}
		//	#endregion
		//	// constructors
		//	#region public HashList()
		//	/// <summary>Constructs a new hash table instance.</summary>
		//	/// <remarks>Runtime: O(1).</remarks>
		//	internal HashLinked() : this(Hash.TableSizes[0]) { }
		//	#endregion
		//	#region public HashList(int expectedCount)
		//	/// <summary>Constructs a new hash table instance.</summary>
		//	/// <remarks>Runtime: O(1).</remarks>
		//	internal HashLinked(int expectedCount)
		//	{
		//		if (expectedCount < 0)
		//			throw new System.ArgumentOutOfRangeException("expectedCount");
		//		if (expectedCount > 0)
		//		{
		//			int prime = (int)(expectedCount * (1 / _maxLoadFactor));
		//			while (Seven.Mathematics.Compute<int>.IsPrime(prime))
		//				prime++;
		//			this._table = new NODE[prime];
		//		}
		//		else
		//		{
		//			this._table = new NODE[Seven.Hash.TableSizes[0]];
		//		}
		//		this._count = 0;
		//	}
		//	#endregion
		//	#region private HashList(SetHashList<T> setHashList)
		//	private HashLinked(HashLinked<NODE> setHashList)
		//	{
		//		this._table = setHashList._table.Clone() as NODE[];
		//		this._count = setHashList._count;
		//	}
		//	#endregion
		//	// properties
		//	#region public int TableSize
		//	/// <summary>Returns the current size of the actual table. You will want this if you 
		//	/// wish to multithread structure traversals.</summary>
		//	/// <remarks>Runtime: O(1).</remarks>
		//	public int TableSize { get { return _table.Length; } }
		//	#endregion
		//	#region public int Count
		//	/// <summary>Returns the current number of items in the structure.</summary>
		//	/// <remarks>Runetime: O(1).</remarks>
		//	public int Count { get { return _count; } }
		//	#endregion
		//	// methods (public)
		//	#region public Set_Hash<T> Clone()
		//	/// <summary>Creates a shallow clone of this data structure.</summary>
		//	/// <returns>A shallow clone of this data structure.</returns>
		//	public HashLinked<NODE> Clone()
		//	{
		//		return new HashLinked<NODE>(this);
		//	}
		//	#endregion
		//	#region public bool Contains(K key)
		//	/// <summary>Determines if this structure contains a given item.</summary>
		//	/// <param name="item">The item to see if theis structure contains.</param>
		//	/// <returns>True if the item is in the structure; False if not.</returns>
		//	public bool Contains(NODE node)
		//	{
		//		if (Find(node, node.HashObjectGetHashCode()) == null)
		//			return false;
		//		else
		//			return true;
		//	}
		//	#endregion
		//	#region System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		//	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		//	{
		//		return this.GetEnumerator();
		//	}
		//	#endregion
		//	#region System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		//	internal System.Collections.Generic.IEnumerator<NODE> GetEnumerator()
		//	{
		//		NODE node;
		//		for (int i = 0; i < _table.Length; i++)
		//			if ((node = _table[i]) != null)
		//				do
		//				{
		//					yield return node;
		//				} while ((node = node.Next) != null);
		//	}
		//	#endregion
		//	#region public void Set(NODE node)
		//	public void Set(NODE node)
		//	{
		//		int hash = node.HashObjectGetHashCode();
		//		if (this.Contains(key))
		//		{
		//			for (NODE bucket = this._table[this._hash(key)]; bucket != null; bucket = bucket.Next)
		//				if (this._equate(bucket.Key, key))
		//				{
		//					bucket.Value = value;
		//				}
		//		}
		//		else
		//		{
		//			this.Add(key, value);
		//		}
		//	}
		//	#endregion
		//	#region public void Remove(T key)
		//	/// <summary>Removes a value from the hash table.</summary>
		//	/// <param name="key">The key of the value to remove.</param>
		//	/// <remarks>Runtime: N/A. (I'm still editing this structure)</remarks>
		//	public void Remove(K key)
		//	{
		//		Remove_private(key);
		//		if (this._count > Seven.Hash.TableSizes[0] && _count < this._table.Length * _minLoadFactor)
		//			Resize(GetSmallerSize());
		//	}
		//	#endregion
		//	#region public void RemoveWithoutTrim(T key)
		//	/// <summary>Removes a value from the hash table.</summary>
		//	/// <param name="key">The key of the value to remove.</param>
		//	/// <remarks>Runtime: N/A. (I'm still editing this structure)</remarks>
		//	public void RemoveWithoutTrim(K key)
		//	{
		//		Remove_private(key);
		//	}
		//	#endregion
		//	#region public void Add(T addition)
		//	/// <summary>Adds a value to the hash table.</summary>
		//	/// <param name="key">The key value to use as the look-up reference in the hash table.</param>
		//	/// <remarks>Runtime: O(n), Omega(1).</remarks>
		//	public void Add(K key, T value)
		//	{
		//		if (object.ReferenceEquals(null, key))
		//			throw new Error("attempting to add a null key to the structure.");
		//		int location = ComputeHash(key);
		//		if (Find(key, location) == null)
		//		{
		//			if (++_count > _table.Length * _maxLoadFactor)
		//			{
		//				if (Count == int.MaxValue)
		//					throw new Error("maximum size of hash table reached.");

		//				Resize(GetLargerSize());
		//				location = ComputeHash(key);
		//			}
		//			Node p = new Node(key, value, null);
		//			Add(p, location);
		//		}
		//		else
		//			throw new Error("\nMember: \"Add(TKey key, TValue value)\"\nThe key is already in the table.");
		//	}
		//	#endregion
		//	#region public void Clear()
		//	public void Clear()
		//	{
		//		_table = new Node[Seven.Hash.TableSizes[0]];
		//		_count = 0;
		//	}
		//	#endregion
		//	#region public void Keys(Step<K> function)
		//	/// <summary>Steps through all the keys.</summary>
		//	/// <param name="function">The step function.</param>
		//	public void Keys(Step<K> function)
		//	{
		//		Node node;
		//		for (int i = 0; i < _table.Length; i++)
		//			if ((node = _table[i]) != null)
		//				do
		//				{
		//					function(node.Key);
		//				} while ((node = node.Next) != null);
		//	}
		//	#endregion
		//	#region public StepStatus Keys(StepBreak<K> function)
		//	/// <summary>Steps through all the keys.</summary>
		//	/// <param name="step_function">The step function.</param>
		//	public StepStatus Keys(StepBreak<K> function)
		//	{
		//	Restart:
		//		Node node;
		//		for (int i = 0; i < _table.Length; i++)
		//			if ((node = _table[i]) != null)
		//				do
		//				{
		//					switch (function(node.Key))
		//					{
		//						case StepStatus.Break:
		//							return StepStatus.Break;
		//						case StepStatus.Continue:
		//							continue;
		//						case StepStatus.Previous:
		//							throw new System.NotImplementedException();
		//						case StepStatus.Restart:
		//							goto Restart;
		//						default:
		//							throw new System.NotImplementedException();
		//					}
		//				} while ((node = node.Next) != null);
		//		return StepStatus.Continue;
		//	}
		//	#endregion
		//	#region public void Stepper(Step<T> function)
		//	/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		//	/// <param name="function">The delegate to invoke on each item in the structure.</param>
		//	public void Stepper(Step<T> function)
		//	{
		//		Node node;
		//		for (int i = 0; i < _table.Length; i++)
		//			if ((node = _table[i]) != null)
		//				do
		//				{
		//					function(node.Value);
		//				} while ((node = node.Next) != null);
		//	}
		//	#endregion
		//	#region public StepStatus Stepper(StepBreak<T> function)
		//	/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		//	/// <param name="function">The delegate to invoke on each item in the structure.</param>
		//	/// <returns>The resulting status of the iteration.</returns>
		//	public StepStatus Stepper(StepBreak<T> function)
		//	{
		//	Restart:
		//		Node node;
		//		for (int i = 0; i < _table.Length; i++)
		//			if ((node = _table[i]) != null)
		//				do
		//				{
		//					switch (function(node.Value))
		//					{
		//						case StepStatus.Break:
		//							return StepStatus.Break;
		//						case StepStatus.Continue:
		//							continue;
		//						case StepStatus.Previous:
		//							throw new System.NotImplementedException();
		//						case StepStatus.Restart:
		//							goto Restart;
		//						default:
		//							throw new System.NotImplementedException();
		//					}
		//				} while ((node = node.Next) != null);
		//		return StepStatus.Continue;
		//	}
		//	#endregion
		//	#region public T[] ToArray()
		//	public T[] ToArray()
		//	{
		//		T[] array = new T[_count];
		//		int index = 0;
		//		Node node;
		//		for (int i = 0; i < _table.Length; i++)
		//			if ((node = _table[i]) != null)
		//				do
		//				{
		//					array[index++] = node.Value;
		//				} while ((node = node.Next) != null);
		//		return array;
		//	}
		//	#endregion
		//	#region public void Trim()
		//	public void Trim()
		//	{
		//		int prime = this._count;
		//		while (Seven.Mathematics.Compute<int>.IsPrime(prime))
		//			prime++;
		//		if (prime != this._table.Length)
		//			Resize(prime);
		//	}
		//	#endregion
		//	// methods internal
		//	#region internal void Add(Node cell, int location)
		//	internal void Add(Node cell, int location)
		//	{
		//		cell.Next = _table[location];
		//		_table[location] = cell;
		//	}
		//	#endregion
		//	#region internal int ComputeHash(T key)
		//	internal int ComputeHash(K key)
		//	{
		//		return (_hash(key) & 0x7fffffff) % _table.Length;
		//	}
		//	#endregion
		//	#region internal Node Find(T key, int loc)
		//	internal Node Find(NODE node, int loc)
		//	{
		//		for (Node bucket = _table[loc]; bucket != null; bucket = bucket.Next)
		//			if (node.HashObjectEquate(this._equate(bucket.Key, key))
		//				return bucket;
		//		return null;
		//	}
		//	#endregion
		//	#region internal int GetLargerSize()
		//	internal int GetLargerSize()
		//	{
		//		for (int i = 0; i < Seven.Hash.TableSizes.Length; i++)
		//			if (this._table.Length < Seven.Hash.TableSizes[i])
		//				return Seven.Hash.TableSizes[i];
		//		return Seven.Hash.TableSizes[Seven.Hash.TableSizes[Seven.Hash.TableSizes.Length - 1]];
		//	}
		//	#endregion
		//	#region internal int GetSmallerSize()
		//	internal int GetSmallerSize()
		//	{
		//		for (int i = Seven.Hash.TableSizes.Length - 1; i > -1; i--)
		//			if (this._table.Length > Seven.Hash.TableSizes[i])
		//				return Seven.Hash.TableSizes[i];
		//		return Seven.Hash.TableSizes[0];
		//	}
		//	#endregion
		//	#region internal void Remove_private(T key)
		//	/// <summary>Removes a value from the hash table.</summary>
		//	/// <param name="key">The key of the value to remove.</param>
		//	/// <remarks>Runtime: N/A. (I'm still editing this structure)</remarks>
		//	internal void Remove_private(K key)
		//	{
		//		if (key == null)
		//			throw new Error("attempting to remove \"null\" from the structure.");
		//		int location = ComputeHash(key);
		//		if (this._equate(this._table[location].Key, key))
		//			_table[location] = _table[location].Next;
		//		for (Node bucket = _table[location]; bucket != null; bucket = bucket.Next)
		//		{
		//			if (bucket.Next == null)
		//				throw new Error("attempting to remove a non-existing value.");
		//			else if (this._equate(bucket.Next.Key, key))
		//				bucket.Next = bucket.Next.Next;
		//		}
		//		_count--;
		//	}
		//	#endregion
		//	#region internal Node RemoveFirst(Node[] t, int i)
		//	internal Node RemoveFirst(Node[] t, int i)
		//	{
		//		Node first = t[i];
		//		t[i] = first.Next;
		//		return first;
		//	}
		//	#endregion
		//	#region internal void Resize(int size)
		//	internal void Resize(int size)
		//	{
		//		Node[] temp = _table;
		//		_table = new Node[size];
		//		for (int i = 0; i < temp.Length; i++)
		//		{
		//			while (temp[i] != null)
		//			{
		//				Node cell = RemoveFirst(temp, i);
		//				Add(cell, ComputeHash(cell.Key));
		//			}
		//		}
		//	}
		//	#endregion
		//}
	}
}
