// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Structures
{
	/// <summary>A primitive dynamic sized data structure.</summary>
	/// <typeparam name="T">The type of items to store in the list.</typeparam>
	public interface List<T> : Structure<T>
	{
		#region member

		/// <summary>Returns the number of items in the list.</summary>
		int Count { get; }
		/// <summary>Adds an item to the end of this list.</summary>
		/// <param name="addition">The item to add to the list.</param>
		void Add(T addition);
		/// <summary>Removes the first occurence of an item in the list.</summary>
		/// <param name="removal">The item to remove.</param>
		/// <param name="compare">The function to determine equality.</param>
		void RemoveFirst(T removal, Compare<T> compare);
		/// <summary>Removes the first occurence of an item in the list or returns false.</summary>
		/// <param name="removal">The item to remove.</param>
		/// <param name="compare">The function to determine equality.</param>
		/// <returns>True if the item was found and removed; False if not.</returns>
		bool TryRemoveFirst(T removal, Compare<T> compare);
		/// <summary>Removes all occurences of an item in the list.</summary>
		/// <param name="removal">The item to genocide (hell yeah that is a verb...).</param>
		/// <param name="compare">The function to determine equality.</param>
		void RemoveAll(T removal, Compare<T> compare);
		/// <summary>Resets the list to an empty state. WARNING could cause excessive garbage collection.</summary>
		void Clear();

		#endregion
	}

	/// <summary>Implements a growing, singularly-linked list data structure that inherits InterfaceTraversable.</summary>
	/// <typeparam name="T">The type of objects to be placed in the list.</typeparam>
	/// <remarks>The runtimes of each public member are included in the "remarks" xml tags.</remarks>
	[System.Serializable]
	public class List_Linked<T> : List<T>
	{
		#region Node

		/// <summary>This class just holds the data for each individual node of the list.</summary>
		internal class Node
		{
			internal T _value;
			internal Node _next;

			internal T Value { get { return _value; } set { _value = value; } }
			internal Node Next { get { return _next; } set { _next = value; } }

			internal Node(T data) { _value = data; }
		}

		#endregion

		#region List_Linked<T>

		#region field

		internal Node _head;
		internal Node _tail;
		internal int _count;

		#endregion

		#region construct

		/// <summary>Creates an instance of a stalistck.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public List_Linked()
		{
			_head = _tail = null;
			_count = 0;
		}

		#endregion

		#region method

		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public List_Linked<T> Clone()
		{
			Node head = new Node(this._head.Value);
			Node current = this._head.Next;
			Node current_clone = head;
			while (current != null)
			{
				current_clone.Next = new Node(current.Value);
				current_clone = current_clone.Next;
				current = current.Next;
			}
			List_Linked<T> clone = new List_Linked<T>();
			clone._head = head;
			clone._tail = current_clone;
			clone._count = this._count;
			return clone;
		}

		/// <summary>Converts the list into a standard array.</summary>
		/// <returns>A standard array of all the items.</returns>
		/// <remarks>Runtime: Theta(n).</remarks>
		public T[] ToArray()
		{
			if (_count == 0)
				return null;
			T[] array = new T[_count];
			Node looper = _head;
			for (int i = 0; i < _count; i++)
			{
				array[i] = looper.Value;
				looper = looper.Next;
			}
			return array;
		}

		#endregion

		#endregion

		#region List<T>

		/// <summary>Returns the number of items in the list.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public int Count { get { return _count; } }

		/// <summary>Adds an item to the list.</summary>
		/// <param name="id">The string id of the item to add to the list.</param>
		/// <param name="addition">The item to add to the list.</param>
		/// <remarks>Runtime: O(1).</remarks>
		public void Add(T addition)
		{
			if (_tail == null)
				_head = _tail = new Node(addition);
			else
				_tail = _tail.Next = new Node(addition);
			_count++;
		}

		/// <summary>Removes the first equality by object reference.</summary>
		/// <param name="removal">The reference to the item to remove.</param>
		public void RemoveFirst(T removal, Compare<T> compare)
		{
			if (_head == null)
				throw new Error("Attempting to remove a non-existing id value.");
			if (compare(removal, _head.Value) == Comparison.Equal)
			{
				_head = _head.Next;
				_count--;
				return;
			}
			Node listNode = _head;
			while (listNode != null)
			{
				if (listNode.Next == null)
					throw new Error("Attempting to remove a non-existing id value.");
				else if (compare(removal, _head.Value) == Comparison.Equal)
				{
					if (listNode.Next.Equals(_tail))
						_tail = listNode;
					listNode.Next = listNode.Next.Next;
					return;
				}
				else
					listNode = listNode.Next;
			}
			throw new Error("Attempting to remove a non-existing id value.");
		}

		/// <summary>Removes the first equality by object reference.</summary>
		/// <param name="removal">The reference to the item to remove.</param>
		/// <returns>True if the item was removed; false if not.</returns>
		public bool TryRemoveFirst(T removal, Compare<T> compare)
		{
			if (_head == null)
				return false;
			if (compare(removal, _head.Value) == Comparison.Equal)
			{
				_head = _head.Next;
				_count--;
				return true;
			}
			Node listNode = _head;
			while (listNode != null)
			{
				if (listNode.Next == null)
					return false;
				else if (compare(removal, _head.Value) == Comparison.Equal)
				{
					if (listNode.Next.Equals(_tail))
						_tail = listNode;
					listNode.Next = listNode.Next.Next;
					return true;
				}
				else
					listNode = listNode.Next;
			}
			return false;
		}

		/// <summary>Removes the first equality by object reference.</summary>
		/// <param name="removal">The reference to the item to remove.</param>
		public void RemoveAll(T removal, Compare<T> compare)
		{
			if (_head == null)
				return;
			if (compare(removal, _head.Value) == Comparison.Equal)
			{
				_head = _head.Next;
				_count--;
			}
			Node listNode = _head;
			while (listNode != null)
			{
				if (listNode.Next == null)
					break;
				else if (compare(removal, _head.Value) == Comparison.Equal)
				{
					if (listNode.Next.Equals(_tail))
						_tail = listNode;
					listNode.Next = listNode.Next.Next;
				}
				listNode = listNode.Next;
			}
		}

		/// <summary>Resets the list to an empty state. WARNING could cause excessive garbage collection.</summary>
		public void Clear()
		{
			_head = _tail = null;
			_count = 0;
		}

		#endregion

		#region Structure<T>

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<T> function)
		{
			for (Node looper = this._head; looper != null; looper = looper.Next)
				function(looper.Value);
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(StepRef<T> function)
		{
			for (Node looper = this._head; looper != null; looper = looper.Next)
			{
				T temp = looper.Value;
				function(ref temp);
				looper.Value = temp;
			}
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepBreak<T> function)
		{
			for (Node looper = this._head; looper != null; looper = looper.Next)
			{
				if (function(looper.Value) == StepStatus.Break)
					return StepStatus.Break;
			}
			return StepStatus.Continue;
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepRefBreak<T> function)
		{
			for (Node looper = this._head; looper != null; looper = looper.Next)
			{
				T temp = looper.Value;
				if (function(ref temp) == StepStatus.Break)
				{
					looper.Value = temp;
					return StepStatus.Break;
				}
				looper.Value = temp;
			}
			return StepStatus.Continue;
		}

		#endregion

		#region IEnumerable<T>

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			for (Node looper = this._head; looper != null; looper = looper.Next)
				yield return looper.Value;
		}

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<T>
			System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		{
			for (Node looper = this._head; looper != null; looper = looper.Next)
				yield return looper.Value;
		}

		#endregion
	}

	/// <summary>Implements a growing list as an array (with expansions/contractions) 
	/// data structure that inherits InterfaceTraversable.</summary>
	/// <typeparam name="T">The type of objects to be placed in the list.</typeparam>
	/// <remarks>The runtimes of each public member are included in the "remarks" xml tags.</remarks>
	[System.Serializable]
	public class List_Array<T> : List<T>
	{
		#region List_Array<T>

		#region field

		internal T[] _list;
		internal int _count;
		internal int _minimumCapacity;

		#endregion

		#region property

		/// <summary>Gets the current capacity of the list.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public int CurrentCapacity
		{
			get
			{
				int returnValue = _list.Length;
				return returnValue;
			}
		}

		/// <summary>Allows you to adjust the minimum capacity of this list.</summary>
		/// <remarks>Runtime: O(n), Omega(1).</remarks>
		public int MinimumCapacity
		{
			get
			{
				int returnValue = _minimumCapacity;
				return returnValue;
			}
			set
			{
				if (value < 1)
					throw new Error("Attempting to set a minimum capacity to a negative or zero value.");
				else if (value > _list.Length)
				{
					T[] newList = new T[value];
					_list.CopyTo(newList, 0);
					_list = newList;
				}
				else
					_minimumCapacity = value;
			}
		}

		/// <summary>Look-up and set an indexed item in the list.</summary>
		/// <param name="index">The index of the item to get or set.</param>
		/// <returns>The value at the given index.</returns>
		public T this[int index]
		{
			get
			{
				if (index < 0 || index > _count)
				{
					throw new Error("Attempting an index look-up outside the ListArray's current size.");
				}
				T returnValue = _list[index];
				return returnValue;
			}
			set
			{
				if (index < 0 || index > _count)
				{
					throw new Error("Attempting an index assignment outside the ListArray's current size.");
				}
				_list[index] = value;
			}
		}

		#endregion

		#region construct

		/// <summary>Creates an instance of a ListArray, and sets it's minimum capacity.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public List_Array()
		{
			_list = new T[1];
			_count = 0;
			_minimumCapacity = 1;
		}

		/// <summary>Creates an instance of a ListArray, and sets it's minimum capacity.</summary>
		/// <param name="minimumCapacity">The initial and smallest array size allowed by this list.</param>
		/// <remarks>Runtime: O(1).</remarks>
		public List_Array(int minimumCapacity)
		{
			_list = new T[minimumCapacity];
			_count = 0;
			_minimumCapacity = minimumCapacity;
		}

		#endregion

		#region method

		/// <summary>Resizes this allocation to the current count.</summary>
		public void Trim()
		{
			T[] newList = new T[this._count];
			for (int i = 0; i < this._count; i++)
				newList[i] = this._list[i];
			this._list = newList;
		}

		/// <summary>Converts the list array into a standard array.</summary>
		/// <returns>A standard array of all the elements.</returns>
		public T[] ToArray()
		{
			T[] array = new T[_count];
			for (int i = 0; i < _count; i++) array[i] = _list[i];
			return array;
		}

		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public List_Array<T> Clone()
		{
			List_Array<T> clone = new List_Array<T>(this._minimumCapacity);
			for (int i = 0; i < this._count; i++)
				clone.Add(this._list[i]);
			return clone;
		}

		#endregion

		#endregion

		#region List<T>

		/// <summary>Gets the number of items in the list.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public int Count { get { return this._count; } }

		/// <summary>Adds an item to the end of the list.</summary>
		/// <param name="addition">The item to be added.</param>
		/// <remarks>Runtime: O(n), EstAvg(1). </remarks>
		public void Add(T addition)
		{
			if (_count == _list.Length)
			{
				if (_list.Length > int.MaxValue / 2)
					throw new Error("Your list is so large that it can no longer double itself (int.MaxValue barrier reached).");
				T[] newList = new T[_list.Length * 2];
				_list.CopyTo(newList, 0);
				_list = newList;
			}
			_list[_count++] = addition;
		}
		
		/// <summary>Adds an item at a given index.</summary>
		/// <param name="addition">The item to be added.</param>
		/// <param name="index">The index to add the item at.</param>
		public void Add(T addition, int index)
		{
			if (_count == _list.Length)
			{
				if (_list.Length > int.MaxValue / 2)
					throw new Error("Your list is so large that it can no longer double itself (int.MaxValue barrier reached).");
				T[] newList = new T[_list.Length * 2];
				_list.CopyTo(newList, 0);
				_list = newList;
			}
			for (int i = this._count; i > index; i--)
				this._list[i] = this._list[i - 1];
			this._list[index] = addition;
		}

		/// <summary>Removes the item at a specific index.</summary>
		/// <param name="removal">The item to be removed.</param>
		/// <param name="compare">The technique of determining equality.</param>
		/// <remarks>Runtime: Theta(n).</remarks>
		public void RemoveFirst(T removal, Compare<T> compare)
		{
			int i;
			for (i = 0; i < this._count; i++)
				if (compare(removal, this._list[i]) == Comparison.Equal)
					break;
			if (i == this._count)
				throw new Error("Attempting to remove a non-existing item from this list.");
			this.Remove(i);
		}

		/// <summary>Removes the item at a specific index.</summary>
		/// <param name="removal">The item to be removed.</param>
		/// <param name="compare">The technique of determining equality.</param>
		/// <returns>True if the item was found and removed; false if not.</returns>
		/// <remarks>Runtime: Theta(n).</remarks>
		public bool TryRemoveFirst(T removal, Compare<T> compare)
		{
			int i;
			for (i = 0; i < this._count; i++)
				if (compare(removal, this._list[i]) == Comparison.Equal)
					break;
			if (i == this._count)
				return false;
			this.Remove(i);
			return true;
		}

		/// <summary>Removes the item at a specific index.</summary>
		/// <param name="index">The index of the item to be removed.</param>
		/// <remarks>Runtime: Theta(n - index).</remarks>
		public void Remove(int index)
		{
			if (index < 0 || index > this._count)
				throw new Error("Attempting to remove an index outside the ListArray's current size.");
			if (_count < this._list.Length / 4 && this._list.Length / 2 > this._minimumCapacity)
			{
				T[] newList = new T[this._list.Length / 2];
				for (int i = 0; i < this._count; i++)
					newList[i] = this._list[i];
				this._list = newList;
			}
			for (int i = index; i < this._count; i++)
				this._list[i] = this._list[i + 1];
			_count--;
		}

		/// <summary>Removes all occurences of a given item.</summary>
		/// <param name="item">The itme to genocide.</param>
		/// <remarks>Runtime: Theta(n).</remarks>
		public void RemoveAll(T item, Compare<T> compare)
		{
			if (this._count == 0)
				return;
			int removed = 0;
			for (int i = 0; i < this._count; i++)
				if (compare(item, this._list[i]) == Comparison.Equal)
					removed++;
				else
					this._list[i - removed] = this._list[i];
			this._count -= removed;
			if (_count < _list.Length / 4 && _list.Length / 2 > _minimumCapacity)
			{
				T[] newList = new T[_list.Length / 2];
				for (int i = 0; i < this._count; i++)
					newList[i] = this._list[i];
				this._list = newList;
			}
		}

		/// <summary>Empties the list back and reduces it back to its original capacity.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public void Clear()
		{
			_list = new T[_minimumCapacity];
			_count = 0;
		}

		#endregion

		#region Structure<T>

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="step_function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<T> step_function)
		{
			for (int i = 0; i < this._count; i++)
				step_function(this._list[i]);
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="step_function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(StepRef<T> step_function)
		{
			for (int i = 0; i < this._count; i++)
				step_function(ref this._list[i]);
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="step_function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepBreak<T> step_function)
		{
			for (int i = 0; i < this._count; i++)
				if (step_function(this._list[i]) == StepStatus.Break)
					return StepStatus.Break;
			return StepStatus.Continue;
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="step_function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepRefBreak<T> step_function)
		{
			for (int i = 0; i < this._count; i++)
				if (step_function(ref this._list[i]) == StepStatus.Break)
					return StepStatus.Break;
			return StepStatus.Continue;
		}

		#endregion

		#region IEnumerator<T>

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			for (int i = 0; i < this._count; i++)
				yield return this._list[i];
		}

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<T>
			System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		{
			for (int i = 0; i < this._count; i++)
				yield return this._list[i];
		}

		#endregion
	}

	// WARNING: THIS IMPLEMENTATION IS INTENDED FOR EDUCATIONAL PURPOSES ONLY
	#region public class List_Delegate<T> : List<T>

	///// <summary>WARNING: THIS IMPLEMENTATION IS INTENDED FOR EDUCATIONAL PURPOSES VS USAGE.</summary>
	///// <typeparam name="Type">The type of objects to be placed in the list.</typeparam>
	///// <remarks>The runtimes of each public member are included in the "remarks" xml tags.</remarks>
	//[System.Serializable]
	//public class List_Delegate<T> : List<T>
	//{
	//	protected delegate void List();
	//	protected List _list;
	//	protected Step<T> _operation;
	//	protected int _count;

	//	/// <summary>Gets the number of items in the list.</summary>
	//	/// <remarks>Runtime: O(1).</remarks>
	//	public int Count { get { return _count; } }

	//	/// <summary>Creates an instance of a ListArray, and sets it's minimum capacity.</summary>
	//	/// <param name="minimumCapacity">The initial and smallest array size allowed by this list.</param>
	//	/// <remarks>Runtime: O(1).</remarks>
	//	public List_Delegate()
	//	{
	//		_count = 0;
	//	}

	//	/// <summary>Determines if an object reference exists in the array.</summary>
	//	/// <param name="reference">The reference to the object.</param>
	//	/// <returns>Whether or not the object reference exists.</returns>
	//	public bool Contains(Type reference)
	//	{
	//		throw new Error("not implemented");
	//	}

	//	/// <summary>Adds an item to the end of the list.</summary>
	//	/// <param name="addition">The item to be added.</param>
	//	/// <remarks>Runtime: O(n), EstAvg(1). </remarks>
	//	public void Add(Type addition)
	//	{
	//		this._list = () => { this._list(); this._operation(addition); };
	//		this._count++;
	//	}

	//	/// <summary>Removes the first equality by object reference.</summary>
	//	/// <param name="removal">The reference to the item to remove.</param>
	//	public void RemoveFirst(Type removal)
	//	{
	//		throw new Error("not implemented");
	//		//this._list -= () => { this._operation(addition); };
	//		//this._count--;
	//	}

	//	/// <summary>Empties the list back and reduces it back to its original capacity.</summary>
	//	/// <remarks>Runtime: O(1).</remarks>
	//	public void Clear()
	//	{
	//		_list = null;
	//		_count = 0;
	//	}

	//	#region .Net Framework Compatibility

	//	///// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
	//	//public static explicit operator System.Collections.Generic.L<T>(Type[] array)
	//	//{
	//	//	return new Array_Array<T>(array);
	//	//}

	//	///// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
	//	//public static explicit operator Type[](Array_Array<T> array)
	//	//{
	//	//	return array._array;
	//	//}

	//	/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
	//	System.Collections.IEnumerator
	//		System.Collections.IEnumerable.GetEnumerator()
	//	{
	//		//_operation = (Type current) => { yield return current; };

	//		throw new Error("List_Delegate does not support contains checking");
	//		//yield return this._list();
	//	}

	//	/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
	//	System.Collections.Generic.IEnumerator<T>
	//		System.Collections.Generic.IEnumerable<T>.GetEnumerator()
	//	{
	//		throw new Error("List_Delegate does not support contains checking");
	//		//_operation = () => yield return 
	//		//yield return this._list();
	//	}
	//	#endregion

	//	/// <summary>Pulls out all the values in the structure that are equivalent to the key.</summary>
	//	/// <typeparam name="Key">The type of the key to check for.</typeparam>
	//	/// <param name="key">The key to check for.</param>
	//	/// <param name="compare">Delegate representing comparison technique.</param>
	//	/// <returns>An array containing all the values matching the key or null if non were found.</returns>
	//	//Type[] GetValues<Key>(Key key, Compare<Type, Key> compare);

	//	/// <summary>Pulls out all the values in the structure that are equivalent to the key.</summary>
	//	/// <typeparam name="Key">The type of the key to check for.</typeparam>
	//	/// <param name="key">The key to check for.</param>
	//	/// <param name="compare">Delegate representing comparison technique.</param>
	//	/// <returns>An array containing all the values matching the key or null if non were found.</returns>
	//	/// <param name="values">The values that matched the given key.</param>
	//	/// <returns>true if 1 or more values were found; false if no values were found.</returns>
	//	//bool TryGetValues<Key>(Key key, Compare<Type, Key> compare, out Type[] values);

	//	/// <summary>Checks to see if a given object is in this data structure.</summary>
	//	/// <param name="item">The item to check for.</param>
	//	/// <param name="compare">Delegate representing comparison technique.</param>
	//	/// <returns>true if the item is in this structure; false if not.</returns>
	//	public bool Contains(Type item, Compare<T> compare)
	//	{
	//		throw new Error("List_Delegate does not support contains checking");
	//	}

	//	/// <summary>Checks to see if a given object is in this data structure.</summary>
	//	/// <typeparam name="Key">The type of the key to check for.</typeparam>
	//	/// <param name="key">The key to check for.</param>
	//	/// <param name="compare">Delegate representing comparison technique.</param>
	//	/// <returns>true if the item is in this structure; false if not.</returns>
	//	public bool Contains<Key>(Key key, Compare<Type, Key> compare)
	//	{
	//		throw new Error("List_Delegate does not support contains checking");
	//	}

	//	/// <summary>Invokes a delegate for each entry in the data structure.</summary>
	//	/// <param name="function">The delegate to invoke on each item in the structure.</param>
	//	public void Stepper(Step<T> function)
	//	{
	//		this._operation = function;
	//		this._list();
	//	}

	//	/// <summary>Invokes a delegate for each entry in the data structure.</summary>
	//	/// <param name="function">The delegate to invoke on each item in the structure.</param>
	//	public void Stepper(StepRef<T> function)
	//	{
	//		throw new Error("List_Delegate does not support contains checking");
	//	}

	//	/// <summary>Invokes a delegate for each entry in the data structure.</summary>
	//	/// <param name="function">The delegate to invoke on each item in the structure.</param>
	//	/// <returns>The resulting status of the iteration.</returns>
	//	public StepStatus Stepper(StepBreak<T> function)
	//	{
	//		throw new Error("List_Delegate does not support contains checking");
	//		//this._operation = function;
	//		//this._list();
	//	}

	//	/// <summary>Invokes a delegate for each entry in the data structure.</summary>
	//	/// <param name="function">The delegate to invoke on each item in the structure.</param>
	//	/// <returns>The resulting status of the iteration.</returns>
	//	public StepStatus Stepper(StepRefBreak<T> function)
	//	{
	//		throw new Error("List_Delegate does not support contains checking");
	//	}

	//	/// <summary>Creates a shallow clone of this data structure.</summary>
	//	/// <returns>A shallow clone of this data structure.</returns>
	//	public Structure<T> Clone()
	//	{
	//		List_Delegate<T> clone = new List_Delegate<T>();
	//		clone._list = (List)this._list.Clone();
	//		clone._count = this._count;
	//		return clone;
	//	}

	//	/// <summary>Converts the list array into a standard array.</summary>
	//	/// <returns>A standard array of all the elements.</returns>
	//	public Type[] ToArray()
	//	{
	//		throw new Error("List_Delegate does not support contains checking");
	//	}

	//	/// <summary>This is used for throwing AVL Tree exceptions only to make debugging faster.</summary>
	//	protected class Exception : Error { public Exception(string message) : base(message) { } }
	//}

	#endregion
}
