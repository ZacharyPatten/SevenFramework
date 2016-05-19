// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Structures
{
	/// <summary>A primitive dynamic sized data structure.</summary>
	/// <typeparam name="T">The type of items to store in the list.</typeparam>
	public interface List<T> : Structure<T>,
		// Structure Properties
		Structure.Addable<T>,
		Structure.Countable<T>,
		Structure.Removable<T>,
		Structure.Clearable<T>,
		Structure.Equating<T>
	{
		#region void Remove(Predicate<T> predicate);
		/// <summary>Removes the first occurence of an item in the list.</summary>
		/// <param name="predicate">The function to determine equality.</param>
		void Remove(Predicate<T> predicate);
		#endregion
		#region bool TryRemove(Predicate<T> predicate);
		/// <summary>Removes the first occurence of an item in the list or returns false.</summary>
		/// <param name="predicate">The function to determine equality.</param>
		/// <returns>True if the item was found and removed; False if not.</returns>
		bool TryRemove(Predicate<T> predicate);
		#endregion
		#region void RemoveAll(Predicate<T> predicate);
		/// <summary>Removes all occurences of an item in the list.</summary>
		/// <param name="predicate">The function to determine equality.</param>
		void RemoveAll(Predicate<T> predicate);
		#endregion
	}

	/// <summary>Implements a growing, singularly-linked list data structure that inherits InterfaceTraversable.</summary>
	/// <typeparam name="T">The type of objects to be placed in the list.</typeparam>
	/// <remarks>The runtimes of each public member are included in the "remarks" xml tags.</remarks>
	[System.Serializable]
	public class ListLinked<T> : List<T>
	{
		// fields
		internal int _count;
		internal Node _head;
		internal Node _tail;
		internal Equate<T> _equate;
		// nested types
		#region internal class Node
		/// <summary>This class just holds the data for each individual node of the list.</summary>
		[System.Serializable]
		internal class Node
		{
			internal Node _next;
			internal T _value;

			internal Node(T data) { _value = data; }

			internal Node Next { get { return _next; } set { _next = value; } }
			internal T Value { get { return _value; } set { _value = value; } }
		}
		#endregion
		//constructors
		#region public List_Linked()
		/// <summary>Creates an instance of a stalistck.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public ListLinked() : this(Seven.Equate.Default) { }
		#endregion
		#region public List_Linked(Equate<T> equate)
		/// <summary>Creates an instance of a stalistck.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public ListLinked(Equate<T> equate)
		{
			this._equate = equate;
			this._head = _tail = null;
			this._count = 0;
		}
		#endregion
		// properties
		#region public int Count
		/// <summary>Returns the number of items in the list.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public int Count { get { return _count; } }
		#endregion
		#region public Equate<T> Equate
		public Equate<T> Equate { get { return this._equate; } }
		#endregion
		// methods
		#region public void Add(T addition)
		/// <summary>Adds an item to the list.</summary>
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
		#endregion
		#region public void Clear()
		/// <summary>Resets the list to an empty state. WARNING could cause excessive garbage collection.</summary>
		public void Clear()
		{
			_head = _tail = null;
			_count = 0;
		}
		#endregion
		#region public List_Linked<T> Clone()
		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public ListLinked<T> Clone()
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
			ListLinked<T> clone = new ListLinked<T>();
			clone._head = head;
			clone._tail = current_clone;
			clone._count = this._count;
			return clone;
		}
		#endregion
		#region System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			for (Node looper = this._head; looper != null; looper = looper.Next)
				yield return looper.Value;
		}
		#endregion
		#region System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<T>
			System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		{
			for (Node looper = this._head; looper != null; looper = looper.Next)
				yield return looper.Value;
		}
		#endregion
		#region public void Remove(T removal)
		/// <summary>Removes the first equality by object reference.</summary>
		/// <param name="removal">The reference to the item to remove.</param>
		public void Remove(T removal)
		{
			if (_head == null)
				throw new Error("Attempting to remove a non-existing id value.");
			if (this._equate(removal, _head.Value))
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
				else if (this._equate(removal, listNode.Value))
				{
					if (object.ReferenceEquals(listNode.Next, this._tail))
						_tail = listNode;
					listNode.Next = listNode.Next.Next;
					return;
				}
				else
					listNode = listNode.Next;
			}
			throw new Error("Attempting to remove a non-existing id value.");
		}
		#endregion
		#region public void Remove(Predicate<T> predicate)
		/// <summary>Removes the first equality by object reference.</summary>
		/// <param name="removal">The reference to the item to remove.</param>
		public void Remove(Predicate<T> predicate)
		{
			if (_head == null)
				throw new Error("Attempting to remove a non-existing id value.");
			if (predicate(_head.Value))
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
				else if (predicate(_head.Value))
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
		#endregion
		#region public void RemoveAll(Predicate<T> predicate)
		/// <summary>Removes the first equality by object reference.</summary>
		/// <param name="removal">The reference to the item to remove.</param>
		public void RemoveAll(Predicate<T> predicate)
		{
			if (_head == null)
				return;
			if (predicate(_head.Value))
			{
				_head = _head.Next;
				_count--;
			}
			Node listNode = _head;
			while (listNode != null)
			{
				if (listNode.Next == null)
					break;
				else if (predicate(_head.Value))
				{
					if (listNode.Next.Equals(_tail))
						_tail = listNode;
					listNode.Next = listNode.Next.Next;
				}
				listNode = listNode.Next;
			}
		}
		#endregion
		#region public void Stepper(Step<T> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<T> function)
		{
			for (Node looper = this._head; looper != null; looper = looper.Next)
				function(looper.Value);
		}
		#endregion
		#region public void Stepper(StepRef<T> function)
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
		#endregion
		#region public StepStatus Stepper(StepBreak<T> function)
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
		#endregion
		#region public StepStatus Stepper(StepRefBreak<T> function)
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
		#region public T[] ToArray()
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
		#region public bool TryRemove(Predicate<T> predicate)
		/// <summary>Removes the first equality by object reference.</summary>
		/// <param name="removal">The reference to the item to remove.</param>
		/// <returns>True if the item was removed; false if not.</returns>
		public bool TryRemove(Predicate<T> predicate)
		{
			if (_head == null)
				return false;
			if (predicate(_head.Value))
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
				else if (predicate(_head.Value))
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
		#endregion
	}

	/// <summary>Implements a growing list as an array (with expansions/contractions)
	/// data structure that inherits InterfaceTraversable.</summary>
	/// <typeparam name="T">The type of objects to be placed in the list.</typeparam>
	/// <remarks>The runtimes of each public member are included in the "remarks" xml tags.</remarks>
	[System.Serializable]
	public class ListArray<T> : List<T>
	{
		// fields
		internal T[] _list;
		internal int _count;
		internal int _minimumCapacity;
		internal Equate<T> _equate;
		// constructors
		#region public List_Array()
		/// <summary>Creates an instance of a ListArray, and sets it's minimum capacity.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public ListArray() : this(1, Seven.Equate.Default<T>) { }
		#endregion
		#region public List_Array(int minimumCapacity)
		/// <summary>Creates an instance of a ListArray, and sets it's minimum capacity.</summary>
		/// <param name="minimumCapacity">The initial and smallest array size allowed by this list.</param>
		/// <remarks>Runtime: O(1).</remarks>
		public ListArray(int minimumCapacity) : this(minimumCapacity, Seven.Equate.Default) { }
		#endregion
		#region public List_Array(int minimumCapacity, Equa)
		/// <summary>Creates an instance of a ListArray, and sets it's minimum capacity.</summary>
		/// <param name="minimumCapacity">The initial and smallest array size allowed by this list.</param>
		/// <remarks>Runtime: O(1).</remarks>
		public ListArray(int minimumCapacity, Equate<T> equate)
		{
			this._equate = equate;
			_list = new T[minimumCapacity];
			_count = 0;
			_minimumCapacity = minimumCapacity;
		}
		#endregion
		// properties
		#region public T this[int index]
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
		#region public int Count
		/// <summary>Gets the number of items in the list.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public int Count { get { return this._count; } }
		#endregion
		#region public int CurrentCapacity
		/// <summary>Gets the current capacity of the list.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public int CurrentCapacity { get { return _list.Length; } }
		#endregion
		#region public int MinimumCapacity
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
		#endregion
		#region public Equate<T> Equate
		public Equate<T> Equate { get { return this._equate; } }
		#endregion
		// methods
		#region public void Add(T addition)
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
				this._list.CopyTo(newList, 0);
				this._list = newList;
			}
			_list[_count++] = addition;
		}
		#endregion
		#region public void Add(T addition, int index)
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
		#endregion
		#region public void Clear()
		/// <summary>Empties the list back and reduces it back to its original capacity.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public void Clear()
		{
			_list = new T[_minimumCapacity];
			_count = 0;
		}
		#endregion
		#region public List_Array<T> Clone()
		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public ListArray<T> Clone()
		{
			ListArray<T> clone = new ListArray<T>(this._minimumCapacity);
			for (int i = 0; i < this._count; i++)
				clone.Add(this._list[i]);
			return clone;
		}
		#endregion
		#region System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			for (int i = 0; i < this._count; i++)
				yield return this._list[i];
		}
		#endregion
		#region System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<T>
			System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		{
			for (int i = 0; i < this._count; i++)
				yield return this._list[i];
		}
		#endregion
		#region public void Remove(int index)
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
		#endregion
		#region public void RemoveAll(Predicate<T> predicate)
		/// <summary>Removes all occurences of a given item.</summary>
		/// <param name="item">The itme to genocide.</param>
		/// <remarks>Runtime: Theta(n).</remarks>
		public void RemoveAll(Predicate<T> predicate)
		{
			if (this._count == 0)
				return;
			int removed = 0;
			for (int i = 0; i < this._count; i++)
				if (predicate(this._list[i]))
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
		#endregion
		#region public void Remove(Predicate<T> predicate)
		/// <summary>Removes the item at a specific index.</summary>
		/// <param name="compare">The technique of determining equality.</param>
		/// <remarks>Runtime: Theta(n).</remarks>
		public void Remove(T removal)
		{
			int i;
			for (i = 0; i < this._count; i++)
				if (this._equate(removal, this._list[i]))
					break;
			if (i == this._count)
				throw new Error("Attempting to remove a non-existing item from this list.");
			this.Remove(i);
		}
		#endregion
		#region public void Remove(Predicate<T> predicate)
		/// <summary>Removes the item at a specific index.</summary>
		/// <param name="compare">The technique of determining equality.</param>
		/// <remarks>Runtime: Theta(n).</remarks>
		public void Remove(Predicate<T> predicate)
		{
			int i;
			for (i = 0; i < this._count; i++)
				if (predicate(this._list[i]))
					break;
			if (i == this._count)
				throw new Error("Attempting to remove a non-existing item from this list.");
			this.Remove(i);
		}
		#endregion
		#region public void Stepper(Step<T> step_function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="step_function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<T> step_function)
		{
			for (int i = 0; i < this._count; i++)
				step_function(this._list[i]);
		}
		#endregion
		#region public void Stepper(StepRef<T> step_function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="step_function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(StepRef<T> step_function)
		{
			for (int i = 0; i < this._count; i++)
				step_function(ref this._list[i]);
		}
		#endregion
		#region public StepStatus Stepper(StepBreak<T> step_function)
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
		#endregion
		#region public StepStatus Stepper(StepRefBreak<T> step_function)
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
		#region public T[] ToArray()
		/// <summary>Converts the list array into a standard array.</summary>
		/// <returns>A standard array of all the elements.</returns>
		public T[] ToArray()
		{
			T[] array = new T[_count];
			for (int i = 0; i < _count; i++) array[i] = _list[i];
			return array;
		}
		#endregion
		#region public void Trim()
		/// <summary>Resizes this allocation to the current count.</summary>
		public void Trim()
		{
			T[] newList = new T[this._count];
			for (int i = 0; i < this._count; i++)
				newList[i] = this._list[i];
			this._list = newList;
		}
		#endregion
		#region public bool TryRemove(Predicate<T> predicate)
		/// <summary>Removes the item at a specific index.</summary>
		/// <param name="compare">The technique of determining equality.</param>
		/// <returns>True if the item was found and removed; false if not.</returns>
		/// <remarks>Runtime: Theta(n).</remarks>
		public bool TryRemove(Predicate<T> predicate)
		{
			int i;
			for (i = 0; i < this._count; i++)
				if (predicate(this._list[i]))
					break;
			if (i == this._count)
				return false;
			this.Remove(i);
			return true;
		}
		#endregion
	}
}
