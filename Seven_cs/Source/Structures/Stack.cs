// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Structures
{
	/// <summary>Implements a First-In-Last-Out stack data structure.</summary>
	/// <typeparam name="T">The generic type within the structure.</typeparam>
	public interface Stack<T> : Structure<T>
	{
		#region member

		/// <summary>Returns the number of items in the stack.</summary>
		int Count { get; }
		/// <summary>Adds an item to the top of the stack.</summary>
		/// <param name="push">The item to add to the stack.</param>
		void Push(T push);
		/// <summary>Returns the most recent addition to the stack.</summary>
		/// <returns>The most recent addition to the stack.</returns>
		T Peek();
		/// <summary>Removes and returns the most recent addition to the stack.</summary>
		/// <returns>The most recent addition to the stack.</returns>
		T Pop();
		/// <summary>Clears the stack to an empty state.</summary>
		void Clear();

		#endregion
	}

	/// <summary>Implements a First-In-Last-Out stack data structure using a linked list.</summary>
	/// <typeparam name="T">The generic type within the structure.</typeparam>
	[System.Serializable]
	public class Stack_Linked<T> : Stack<T>
	{
		#region Node

		/// <summary>This class just holds the data for each individual node of the stack.</summary>
		[System.Serializable]
		private class Node
		{
			private T _value;
			private Node _down;

			internal T Value { get { return _value; } set { _value = value; } }
			internal Node Down { get { return _down; } set { _down = value; } }

			internal Node(T data, Node down) 
			{
				_value = data;
				_down = down;
			}
		}

		#endregion

		#region Stack_Linked<T>

		#region field

		private Node _top;
		private int _count;

		#endregion
		
		#region construct

		/// <summary>Creates an instance of a stack.</summary>
		/// <runtime>O(1)</runtime>
		public Stack_Linked()
		{
			_top = null;
			_count = 0;
		}

		#endregion

		#region method

		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public Stack_Linked<T> Clone()
		{
			Stack_Linked<T> clone = new Stack_Linked<T>();
			if (this._count == 0)
				return clone;
			Node copying = this._top;
			Node cloneTop = new Node(this._top.Value, null);
			Node cloning = cloneTop;
			while (copying != null)
			{
				copying = copying.Down;
				cloning.Down = new Node(copying.Value, null);
				cloning = cloning.Down;
			}
			clone._top = cloneTop;
			return clone;
		}

		/// <summary>Converts the structure into an array.</summary>
		/// <returns>An array containing all the item in the structure.</returns>
		/// <remarks>Runtime: Theta(n).</remarks>
		public T[] ToArray()
		{
			if (_count == 0)
				return null;
			T[] array = new T[_count];
			Node looper = _top;
			for (int i = 0; i < _count; i++)
			{
				array[i] = looper.Value;
				looper = looper.Down;
			}
			return array;
		}

		#endregion

		#endregion

		#region Stack<T>

		/// <summary>Returns the number of items in the stack.</summary>
		/// <runtime>O(1)</runtime>
		public int Count { get { return this._count; } }

		/// <summary>Adds an item to the top of the stack.</summary>
		/// <param name="addition">The item to add to the stack.</param>
		/// <runtime>O(1)</runtime>
		public void Push(T addition)
		{
			_top = new Node(addition, _top);
			_count++;
		}

		/// <summary>Returns the most recent addition to the stack.</summary>
		/// <returns>The most recent addition to the stack.</returns>
		/// <remarks>Runtime: O(1).</remarks>
		public T Peek()
		{
			if (_top == null)
				throw new Error("Attempting to remove from an empty queue.");
			T peek = _top.Value;
			return peek;
		}

		/// <summary>Removes and returns the most recent addition to the stack.</summary>
		/// <returns>The most recent addition to the stack.</returns>
		/// <remarks>Runtime: O(1).</remarks>
		public T Pop()
		{
			T x = _top.Value;
			_top = _top.Down;
			_count--;
			return x;
		}

		/// <summary>Clears the stack to an empty state.</summary>
		/// <remarks>Runtime: O(1). Note: causes considerable garbage collection.</remarks>
		public void Clear()
		{
			_top = null;
			_count = 0;
		}

		#endregion

		#region Structure<T>

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<T> function)
		{
			for (Node looper = this._top; looper != null; looper = looper.Down)
				function(looper.Value);
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(StepRef<T> function)
		{
			for (Node looper = this._top; looper != null; looper = looper.Down)
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
			for (Node looper = this._top; looper != null; looper = looper.Down)
				if (function(looper.Value) == StepStatus.Break)
					return StepStatus.Break;
			return StepStatus.Continue;
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepRefBreak<T> function)
		{
			for (Node looper = this._top; looper != null; looper = looper.Down)
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
			for (Node looper = this._top; looper != null; looper = looper.Down)
				yield return looper.Value;
		}

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<T>
			System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		{
			for (Node looper = this._top; looper != null; looper = looper.Down)
				yield return looper.Value;
		}

		#endregion
	}

	/// <summary>Implements a First-In-Last-Out stack data structure using an array.</summary>
	/// <typeparam name="T">The generic type within the structure.</typeparam>
	[System.Serializable]
	public class Stack_Array<T> : Stack<T>
	{
		#region Stack_Array<T>

		#region field

		private T[] _stack;
		private int _count;
		private int _minimumCapacity;

		#endregion

		#region property

		/// <summary>Gets the current capacity of the list.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public int CurrentCapacity { get { return _stack.Length; } }

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
				else if (value > _stack.Length)
				{
					T[] newList = new T[value];
					_stack.CopyTo(newList, 0);
					_stack = newList;
				}
				else
					_minimumCapacity = value;
			}
		}

		#endregion

		#region construct

		/// <summary>Creates an instance of a ListArray, and sets it's minimum capacity.</summary>
		/// <param name="minimumCapacity">The initial and smallest array size allowed by this list.</param>
		/// <remarks>Runtime: O(1).</remarks>
		public Stack_Array()
		{
			_stack = new T[1];
			_count = 0;
			_minimumCapacity = 1;
		}

		/// <summary>Creates an instance of a ListArray, and sets it's minimum capacity.</summary>
		/// <param name="minimumCapacity">The initial and smallest array size allowed by this list.</param>
		/// <remarks>Runtime: O(1).</remarks>
		public Stack_Array(int minimumCapacity)
		{
			_stack = new T[minimumCapacity];
			_count = 0;
			_minimumCapacity = minimumCapacity;
		}

		#endregion

		#region method

		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public Stack_Array<T> Clone()
		{
			Stack_Array<T> clone = new Stack_Array<T>();
			clone._stack = new T[this._stack.Length];
			for (int i = 0; i < this._count; i++)
				clone._stack[i] = this._stack[i];
			clone._minimumCapacity = this._minimumCapacity;
			clone._count = this._count;
			return clone;
		}

		/// <summary>Converts the list array into a standard array.</summary>
		/// <returns>A standard array of all the elements.</returns>
		public T[] ToArray()
		{
			T[] array = new T[this._count];
			for (int i = 0; i < this._count; i++)
				array[i] = this._stack[i];
			return array;
		}

		#endregion

		#endregion

		#region Stack<T>

		/// <summary>Gets the number of items in the list.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public int Count { get { return _count; } }

		/// <summary>Adds an item to the end of the list.</summary>
		/// <param name="addition">The item to be added.</param>
		/// <remarks>Runtime: O(n), EstAvg(1). </remarks>
		public void Push(T addition)
		{
			if (_count == _stack.Length)
			{
				if (_stack.Length > int.MaxValue / 2)
					throw new Error("your queue is so large that it can no longer double itself (Int32.MaxValue barrier reached).");
				T[] newStack = new T[_stack.Length * 2];
				for (int i = 0; i < _count; i++)
					newStack[i] = _stack[i];
				_stack = newStack;
			}
			_stack[_count++] = addition;
		}

		/// <summary>Removes the item at a specific index.</summary>
		/// <remarks>Runtime: Theta(n - index).</remarks>
		public T Pop()
		{
			if (_count == 0)
				throw new Error("attempting to dequeue from an empty queue.");
			if (_count < _stack.Length / 4 && _stack.Length / 2 > _minimumCapacity)
			{
				T[] newQueue = new T[_stack.Length / 2];
				for (int i = 0; i < _count; i++)
					newQueue[i] = _stack[i];
				_stack = newQueue;
			}
			T returnValue = _stack[--_count];
			return returnValue;
		}

		/// <summary>Returns the most recent addition to the stack.</summary>
		/// <returns>The most recent addition to the stack.</returns>
		/// <remarks>Runtime: O(1).</remarks>
		public T Peek()
		{
			T returnValue = _stack[_count - 1];
			return returnValue;
		}

		/// <summary>Empties the list back and reduces it back to its original capacity.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public void Clear()
		{
			_stack = new T[_minimumCapacity];
			_count = 0;
		}

		#endregion

		#region Structure<T>

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="step_function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<T> step_function)
		{
			for (int i = 0; i < this._stack.Length; i++)
				step_function(this._stack[i]);
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="step_function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(StepRef<T> step_function)
		{
			for (int i = 0; i < this._stack.Length; i++)
				step_function(ref this._stack[i]);
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="step_function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepBreak<T> step_function)
		{
			for (int i = 0; i < this._stack.Length; i++)
				switch (step_function(this._stack[i]))
				{
					case StepStatus.Break:
						return StepStatus.Break;
					case StepStatus.Continue:
						continue;
					default:
						throw new Error("not implemented");
				}
			return StepStatus.Continue;
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="step_function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepRefBreak<T> step_function)
		{
			for (int i = 0; i < this._stack.Length; i++)
				switch (step_function(ref this._stack[i]))
				{
					case StepStatus.Break:
						return StepStatus.Break;
					case StepStatus.Continue:
						continue;
					default:
						throw new Error("not implemented");
				}
			return StepStatus.Continue;
		}

		#endregion

		#region IEnumerator<T>

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			for (int i = 0; i < this._count; i++)
				yield return this._stack[i];
		}

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<T>
			System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		{
			for (int i = 0; i < this._count; i++)
				yield return this._stack[i];
		}

		#endregion
	}
}
