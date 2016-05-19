// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Structures
{
	/// <summary>Represents a link between objects.</summary>
	public interface Link : Structure<object>
	{
		// properties
		#region int Size
		/// <summary>The number of objects in the tuple.</summary>
		int Size { get; }
		#endregion
	}

	/// <summary>Represents a link between objects.</summary>
	/// <typeparam name="T1">The type of the left item to be linked.</typeparam>
	[System.Serializable]
	public class Link<T1> : Link
	{
		// fields
		protected object _one;
		// constructors
		#region public Link(T1 one)
		/// <summary>Creates a link between objects.</summary>
		/// <param name="one">The first item to be linked.</param>
		/// <remarks>Runtime: O(1).</remarks>
		public Link(T1 one)
		{
			this._one = one;
		}
		#endregion
		// properties
		#region public int Size
		/// <summary>The number of objects in the tuple.</summary>
		public int Size { get { return 1; } }
		#endregion
		#region public T1 One
		/// <summary>The left item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T1 One { get { return (T1)this._one; } set { this._one = value; } }
		#endregion
		// methods
		#region public static explicit operator Link<T1>(System.Tuple<T1> tuple)
		/// <summary>explicitly casts a System.Tuple to a Seven.Structures.Link.</summary>
		/// <param name="tuple">The System.Tuple to be casted.</param>
		/// <returns>A Seven.Structures.Link casted from the System.Tuple.</returns>
		public static explicit operator Link<T1>(System.Tuple<T1> tuple)
		{
			return new Link<T1>(tuple.Item1);
		}
		#endregion
		#region public static explicit operator System.Tuple<T1>(Link<T1> link)
		/// <summary>explicitly casts a Seven.Structures.Link to a System.Tuple.</summary>
		/// <param name="tuple">The Seven.Structures.Link to be casted.</param>
		/// <returns>The System.Tuple casted Seven.Structures.Link.</returns>
		public static explicit operator System.Tuple<T1>(Link<T1> link)
		{
			return new System.Tuple<T1>((T1)link._one);
		}
		#endregion
		#region System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			yield return this._one;
		}
		#endregion
		#region System.Collections.Generic.IEnumerator<object> System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<object>
			System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		{
			yield return this._one;
		}
		#endregion
		#region public System.Type[] Types()
		/// <summary>Gets an array with all the types contained in this link in respective order.</summary>
		/// <returns>An array of all the types in this link in respective order.</returns>
		public System.Type[] Types()
		{
			return new System.Type[]
			{
				typeof(T1)
			};
		}
		#endregion
		#region public bool Contains(object item, Compare<object> compare)
		/// <summary>Checks to see if a given object is in this data structure.</summary>
		/// <param name="item">The item to check for.</param>
		/// <param name="compare">Delegate representing comparison technique.</param>
		/// <returns>true if the item is in this structure; false if not.</returns>
		public bool Contains(object item, Compare<object> compare)
		{
			if (compare(this._one, item) == Comparison.Equal)
				return true;
			return false;
		}
		#endregion
		#region public bool Contains<Key>(Key key, Compare<object, Key> compare)
		/// <summary>Checks to see if a given object is in this data structure.</summary>
		/// <param name="item">The item to check for.</param>
		/// <param name="compare">Delegate representing comparison technique.</param>
		/// <returns>true if the item is in this structure; false if not.</returns>
		public bool Contains<Key>(Key key, Compare<object, Key> compare)
		{
			if (compare(this._one, key) == Comparison.Equal)
				return true;
			return false;
		}
		#endregion
		#region public void Stepper(Step<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<object> function)
		{
			function(this._one);
		}
		#endregion
		#region public void Stepper(StepRef<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(StepRef<object> function)
		{
			function(ref this._one);
		}
		#endregion
		#region public StepStatus Stepper(StepBreak<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepBreak<object> function)
		{
			return function(this._one);
		}
		#endregion
		#region public StepStatus Stepper(StepRefBreak<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepRefBreak<object> function)
		{
			return function(ref this._one);
		}
		#endregion
		#region public Structure<object> Clone()
		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public Structure<object> Clone()
		{
			return new Link<T1>((T1)this._one);
		}
		#endregion
		#region public virtual object[] ToArray()
		/// <summary>Converts the structure into an array.</summary>
		/// <returns>An array containing all the item in the structure.</returns>
		public virtual object[] ToArray()
		{
			return new object[]
			{
				this._one
			};
		}
		#endregion
	}

	/// <summary>Represents a link between objects.</summary>
	/// <typeparam name="T1">The type of the left item to be linked.</typeparam>
	/// <typeparam name="T2">The type of the right item to be linked.</typeparam>
	[System.Serializable]
	public class Link<T1, T2> : Link
	{
		// fields
		protected object _one;
		protected object _two;
		// constrctors
		#region public Link(T1 one, T2 two)
		/// <summary>Creates a link between objects.</summary>
		/// <param name="one">The first item to be linked.</param>
		/// <param name="two">The second item to be linked.</param>
		/// <remarks>Runtime: O(1).</remarks>
		public Link(T1 one, T2 two)
		{
			this._one = one;
			this._two = two;
		}
		#endregion
		// properties
		#region public	int Size
		/// <summary>The number of objects in the tuple.</summary>
		public	int Size { get { return 2; } }
		#endregion
		#region public T1 One
		/// <summary>The left item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T1 One { get { return (T1)this._one; } set { this._one = value; } }
		#endregion
		#region public T2 Two
		/// <summary>The right item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T2 Two { get { return (T2)this._two; } set { this._two = value; } }
		#endregion
		// methods
		#region public static explicit operator Link<T1, T2>(System.Tuple<T1, T2> tuple)
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		public static explicit operator Link<T1, T2>(System.Tuple<T1, T2> tuple)
		{
			return new Link<T1, T2>(tuple.Item1, tuple.Item2);
		}
		#endregion
		#region public static explicit operator System.Tuple<T1, T2>(Link<T1, T2> link)
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		public static explicit operator System.Tuple<T1, T2>(Link<T1, T2> link)
		{
			return new System.Tuple<T1, T2>((T1)link._one, (T2)link._two);
		}
		#endregion
		#region System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
		}
		#endregion
		#region System.Collections.Generic.IEnumerator<object> System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<object>
			System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
		}
		#endregion
		#region public System.Type[] Types()
		/// <summary>Gets an array with all the types contained in this link in respective order.</summary>
		/// <returns>An array of all the types in this link in respective order.</returns>
		public System.Type[] Types()
		{
			return new System.Type[]
			{
				typeof(T1),
				typeof(T2)
			};
		}
		#endregion
		#region public	bool Contains(object item, Compare<object> compare)
		/// <summary>Checks to see if a given object is in this data structure.</summary>
		/// <param name="item">The item to check for.</param>
		/// <param name="compare">Delegate representing comparison technique.</param>
		/// <returns>true if the item is in this structure; false if not.</returns>
		public	bool Contains(object item, Compare<object> compare)
		{
			if (compare(this._one, item) == Comparison.Equal)
				return true;
			if (compare(this._two, item) == Comparison.Equal)
				return true;
			return false;
		}
		#endregion
		#region public bool Contains<Key>(Key key, Compare<object, Key> compare)
		/// <summary>Checks to see if a given object is in this data structure.</summary>
		/// <param name="item">The item to check for.</param>
		/// <param name="compare">Delegate representing comparison technique.</param>
		/// <returns>true if the item is in this structure; false if not.</returns>
		public bool Contains<Key>(Key key, Compare<object, Key> compare)
		{
			if (compare(this._one, key) == Comparison.Equal)
				return true;
			if (compare(this._two, key) == Comparison.Equal)
				return true;
			return false;
		}
		#endregion
		#region public void Stepper(Step<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<object> function)
		{
			function(this._one);
			function(this._two);
		}
		#endregion
		#region public void Stepper(StepRef<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(StepRef<object> function)
		{
			function(ref this._one);
			function(ref this._two);
		}
		#endregion
		#region public	StepStatus Stepper(StepBreak<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public	StepStatus Stepper(StepBreak<object> function)
		{
			if (function(this._one) == StepStatus.Break)
				return StepStatus.Break;
			else
				return function(this._two);
		}
		#endregion
		#region public	StepStatus Stepper(StepRefBreak<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public	StepStatus Stepper(StepRefBreak<object> function)
		{
			if (function(ref this._one) == StepStatus.Break)
				return StepStatus.Break;
			else
				return function(ref this._two);
		}
		#endregion
		#region public	Structure<object> Clone()
		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public	Structure<object> Clone()
		{
			return new Link<T1, T2>((T1)this._one, (T2)this._two);
		}
		#endregion
		#region public	object[] ToArray()
		/// <summary>Converts the structure into an array.</summary>
		/// <returns>An array containing all the item in the structure.</returns>
		public	object[] ToArray()
		{
			return new object[]
			{
				this._one,
				this._two
			};
		}
		#endregion
	}

	/// <summary>Represents a link between objects.</summary>
	/// <typeparam name="T1">The type of the first item to be linked.</typeparam>
	/// <typeparam name="T2">The type of the second item to be linked.</typeparam>
	/// <typeparam name="T3">The type of the third item to be linked.</typeparam>
	[System.Serializable]
	public class Link<T1, T2, T3> : Link
	{
		// fields
		protected object _one;
		protected object _two;
		protected object _three;
		// constructors
		#region public Link(T1 one, T2 two, T3 three)
		/// <summary>Creates a link between objects.</summary>
		/// <param name="one">The first item to be linked.</param>
		/// <param name="two">The second item to be linked.</param>
		/// <param name="three">The third item to be linked.</param>
		/// <remarks>Runtime: O(1).</remarks>
		public Link(T1 one, T2 two, T3 three)
		{
			this._one = one;
			this._two = two;
			this._three = three;
		}
		#endregion
		// properties
		#region public	int Size
		/// <summary>The number of objects in the tuple.</summary>
		public	int Size { get { return 3; } }
		#endregion
		#region public T1 One
		/// <summary>The left item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T1 One { get { return (T1)this._one; } set { this._one = value; } }
		#endregion
		#region public T2 Two
		/// <summary>The right item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T2 Two { get { return (T2)this._two; } set { this._two = value; } }
		#endregion
		#region public T3 Three
		/// <summary>The third item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T3 Three { get { return (T3)this._three; } set { this._three = value; } }
		#endregion
		// methods
		#region public static explicit operator Link<T1, T2, T3>(System.Tuple<T1, T2, T3> tuple)
		/// <summary>explicitly casts a System.Tuple to a Seven.Structures.Link.</summary>
		/// <param name="tuple">The System.Tuple to be casted.</param>
		/// <returns>A Seven.Structures.Link casted from the System.Tuple.</returns>
		public static explicit operator Link<T1, T2, T3>(System.Tuple<T1, T2, T3> tuple)
		{
			return new Link<T1, T2, T3>(tuple.Item1, tuple.Item2, tuple.Item3);
		}
		#endregion
		#region public static explicit operator System.Tuple<T1, T2, T3>(Link<T1, T2, T3> link)
		/// <summary>explicitly casts a Seven.Structures.Link to a System.Tuple.</summary>
		/// <param name="tuple">The Seven.Structures.Link to be casted.</param>
		/// <returns>The System.Tuple casted Seven.Structures.Link.</returns>
		public static explicit operator System.Tuple<T1, T2, T3>(Link<T1, T2, T3> link)
		{
			return new System.Tuple<T1, T2, T3>((T1)link._one, (T2)link._two, (T3)link._three);
		}
		#endregion
		#region System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
			yield return this._three;
		}
		#endregion
		#region System.Collections.Generic.IEnumerator<object> System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<object>
			System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
			yield return this._three;
		}
		#endregion
		#region public System.Type[] Types()
		/// <summary>Gets an array with all the types contained in this link in respective order.</summary>
		/// <returns>An array of all the types in this link in respective order.</returns>
		public System.Type[] Types()
		{
			return new System.Type[]
			{
				typeof(T1),
				typeof(T2),
				typeof(T3)
			};
		}
		#endregion
		#region public	bool Contains(object item, Compare<object> compare)
		/// <summary>Checks to see if a given object is in this data structure.</summary>
		/// <param name="item">The item to check for.</param>
		/// <param name="compare">Delegate representing comparison technique.</param>
		/// <returns>true if the item is in this structure; false if not.</returns>
		public	bool Contains(object item, Compare<object> compare)
		{
			if (compare(this._one, item) == Comparison.Equal)
				return true;
			else if (compare(this._two, item) == Comparison.Equal)
				return true;
			else if (compare(this._three, item) == Comparison.Equal)
				return true;
			return false;
		}
		#endregion
		#region public	bool Contains<Key>(Key key, Compare<object, Key> compare)
		/// <summary>Checks to see if a given object is in this data structure.</summary>
		/// <param name="item">The item to check for.</param>
		/// <param name="compare">Delegate representing comparison technique.</param>
		/// <returns>true if the item is in this structure; false if not.</returns>
		public	bool Contains<Key>(Key key, Compare<object, Key> compare)
		{
			if (compare(this._one, key) == Comparison.Equal)
				return true;
			else if (compare(this._two, key) == Comparison.Equal)
				return true;
			else if (compare(this._three, key) == Comparison.Equal)
				return true;
			return false;
		}
		#endregion
		#region public	void Stepper(Step<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public	void Stepper(Step<object> function)
		{
			function(this._one);
			function(this._two);
			function(this._three);
		}
		#endregion
		#region public	void Stepper(StepRef<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public	void Stepper(StepRef<object> function)
		{
			function(ref this._one);
			function(ref this._two);
			function(ref this._three);
		}
		#endregion
		#region public	StepStatus Stepper(StepBreak<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public	StepStatus Stepper(StepBreak<object> function)
		{
			if (function(this._one) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(this._two) == StepStatus.Break)
				return StepStatus.Break;
			else
				return function(this._three);
		}
		#endregion
		#region public	StepStatus Stepper(StepRefBreak<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public	StepStatus Stepper(StepRefBreak<object> function)
		{
			if (function(ref this._one) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(ref this._two) == StepStatus.Break)
				return StepStatus.Break;
			else
				return function(ref this._three);
		}
		#endregion
		#region public	Structure<object> Clone()
		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public	Structure<object> Clone()
		{
			return new Link<T1, T2, T3>
				((T1)this._one, (T2)this._two, (T3)this._three);
		}
		#endregion
		#region public	object[] ToArray()
		/// <summary>Converts the structure into an array.</summary>
		/// <returns>An array containing all the item in the structure.</returns>
		public	object[] ToArray()
		{
			return new object[]
			{
				this._one,
				this._two,
				this._three
			};
		}
		#endregion
	}

	/// <summary>Represents a link between objects.</summary>
	/// <typeparam name="T1">The type of the first item to be linked.</typeparam>
	/// <typeparam name="T2">The type of the second item to be linked.</typeparam>
	/// <typeparam name="T3">The type of the third item to be linked.</typeparam>
	/// <typeparam name="T4">The type of the fourth item to be linked.</typeparam>
	[System.Serializable]
	public class Link<T1, T2, T3, T4> : Link
	{
		// fields
		protected object _one;
		protected object _two;
		protected object _three;
		protected object _four;
		// constructors
		#region public Link(T1 one, T2 two, T3 three, T4 four)
		/// <summary>Creates a link between objects.</summary>
		/// <param name="one">The left item to be linked.</param>
		/// <param name="two">The second item to be linked.</param>
		/// <param name="three">The third item to be linked.</param>
		/// <param name="four">The fourth item to be linked.</param>
		/// <remarks>Runtime: O(1).</remarks>
		public Link(T1 one, T2 two, T3 three, T4 four)
		{
			this._one = one;
			this._two = two;
			this._three = three;
			this._four = four;
		}
		#endregion
		// properties
		#region public	int Size
		/// <summary>The number of objects in the tuple.</summary>
		public	int Size { get { return 4; } }
		#endregion
		#region public T1 One
		/// <summary>The left item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T1 One { get { return (T1)this._one; } set { this._one = value; } }
		#endregion
		#region public T2 Two
		/// <summary>The right item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T2 Two { get { return (T2)this._two; } set { this._two = value; } }
		#endregion
		#region public T3 Three
		/// <summary>The third item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T3 Three { get { return (T3)this._three; } set { this._three = value; } }
		#endregion
		#region public T4 Four
		/// <summary>The fourth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T4 Four { get { return (T4)this._four; } set { this._four = value; } }
		#endregion
		// methods
		#region public static explicit operator Link<T1, T2, T3, T4>(System.Tuple<T1, T2, T3, T4> tuple)
		/// <summary>explicitly casts a System.Tuple to a Seven.Structures.Link.</summary>
		/// <param name="tuple">The System.Tuple to be casted.</param>
		/// <returns>A Seven.Structures.Link casted from the System.Tuple.</returns>
		public static explicit operator Link<T1, T2, T3, T4>
			(System.Tuple<T1, T2, T3, T4> tuple)
		{
			return new Link<T1, T2, T3, T4>
				(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
		}
		#endregion
		#region public static explicit operator System.Tuple<T1, T2, T3, T4>(Link<T1, T2, T3, T4> link)
		/// <summary>explicitly casts a Seven.Structures.Link to a System.Tuple.</summary>
		/// <param name="tuple">The Seven.Structures.Link to be casted.</param>
		/// <returns>The System.Tuple casted Seven.Structures.Link.</returns>
		public static explicit operator System.Tuple<T1, T2, T3, T4>
			(Link<T1, T2, T3, T4> link)
		{
			return new System.Tuple<T1, T2, T3, T4>
				((T1)link._one, (T2)link._two, (T3)link._three, (T4)link._four);
		}
		#endregion
		#region System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
			yield return this._three;
			yield return this._four;
		}
		#endregion
		#region System.Collections.Generic.IEnumerator<object> System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<object>
			System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
			yield return this._three;
			yield return this._four;
		}
		#endregion
		#region public System.Type[] Types()
		/// <summary>Gets an array with all the types contained in this link in respective order.</summary>
		/// <returns>An array of all the types in this link in respective order.</returns>
		public System.Type[] Types()
		{
			return new System.Type[]
			{
				typeof(T1),
				typeof(T2),
				typeof(T3),
				typeof(T4)
			};
		}
		#endregion
		#region public	bool Contains(object item, Compare<object> compare)
		/// <summary>Checks to see if a given object is in this data structure.</summary>
		/// <param name="item">The item to check for.</param>
		/// <param name="compare">Delegate representing comparison technique.</param>
		/// <returns>true if the item is in this structure; false if not.</returns>
		public	bool Contains(object item, Compare<object> compare)
		{
			if (compare(this._one, item) == Comparison.Equal)
				return true;
			else if (compare(this._two, item) == Comparison.Equal)
				return true;
			else if (compare(this._three, item) == Comparison.Equal)
				return true;
			else if (compare(this._four, item) == Comparison.Equal)
				return true;
			else
				return false;
		}
		#endregion
		#region public	bool Contains<Key>(Key key, Compare<object, Key> compare)
		/// <summary>Checks to see if a given object is in this data structure.</summary>
		/// <param name="item">The item to check for.</param>
		/// <param name="compare">Delegate representing comparison technique.</param>
		/// <returns>true if the item is in this structure; false if not.</returns>
		public	bool Contains<Key>(Key key, Compare<object, Key> compare)
		{
			if (compare(this._one, key) == Comparison.Equal)
				return true;
			else if (compare(this._two, key) == Comparison.Equal)
				return true;
			else if (compare(this._three, key) == Comparison.Equal)
				return true;
			else if (compare(this._four, key) == Comparison.Equal)
				return true;
			else
				return false;
		}
		#endregion
		#region public	void Stepper(Step<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public	void Stepper(Step<object> function)
		{
			function(this._one);
			function(this._two);
			function(this._three);
			function(this._four);
		}
		#endregion
		#region public	void Stepper(StepRef<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public	void Stepper(StepRef<object> function)
		{
			function(ref this._one);
			function(ref this._two);
			function(ref this._three);
			function(ref this._four);
		}
		#endregion
		#region public	StepStatus Stepper(StepBreak<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public	StepStatus Stepper(StepBreak<object> function)
		{
			if (function(this._one) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(this._two) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(this._three) == StepStatus.Break)
				return StepStatus.Break;
			else
				return function(this._four);
		}
		#endregion
		#region public	StepStatus Stepper(StepRefBreak<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public	StepStatus Stepper(StepRefBreak<object> function)
		{
			if (function(ref this._one) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(ref this._two) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(ref this._three) == StepStatus.Break)
				return StepStatus.Break;
			else
				return function(ref this._four);
		}
		#endregion
		#region public	Structure<object> Clone()
		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public	Structure<object> Clone()
		{
			return new Link<T1, T2, T3, T4>
				((T1)this._one, (T2)this._two, (T3)this._three, (T4)this._four);
		}
		#endregion
		#region public	object[] ToArray()
		/// <summary>Converts the structure into an array.</summary>
		/// <returns>An array containing all the item in the structure.</returns>
		public	object[] ToArray()
		{
			return new object[]
			{
				this._one,
				this._two,
				this._three,
				this._four
			};
		}
		#endregion
	}

	/// <summary>Represents a link between objects.</summary>
	/// <typeparam name="T1">The type of the first item to be linked.</typeparam>
	/// <typeparam name="T2">The type of the second item to be linked.</typeparam>
	/// <typeparam name="T3">The type of the third item to be linked.</typeparam>
	/// <typeparam name="T4">The type of the fourth item to be linked.</typeparam>
	/// <typeparam name="T5">The type of the fifth item to be linked.</typeparam>
	[System.Serializable]
	public class Link<T1, T2, T3, T4, T5> : Link
	{
		// fields
		protected object _one;
		protected object _two;
		protected object _three;
		protected object _four;
		protected object _five;
		// constructors
		#region public Link(T1 one, T2 two, T3 three, T4 four, T5 five)
		/// <summary>Creates a link between objects.</summary>
		/// <param name="one">The first item to be linked.</param>
		/// <param name="two">The second item to be linked.</param>
		/// <param name="three">The third item to be linked.</param>
		/// <param name="four">The fourth item to be linked.</param>
		/// <param name="five">The fourth item to be linked.</param>
		/// <remarks>Runtime: O(1).</remarks>
		public Link(T1 one, T2 two, T3 three, T4 four, T5 five)
		{
			this._one = one;
			this._two = two;
			this._three = three;
			this._four = four;
			this._five = five;
		}
		#endregion
		// properties
		#region public	int Size
		/// <summary>The number of objects in the tuple.</summary>
		public	int Size { get { return 5; } }
		#endregion
		#region public T1 One
		/// <summary>The left item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T1 One { get { return (T1)this._one; } set { this._one = value; } }
		#endregion
		#region public T2 Two
		/// <summary>The right item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T2 Two { get { return (T2)this._two; } set { this._two = value; } }
		#endregion
		#region public T3 Three
		/// <summary>The third item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T3 Three { get { return (T3)this._three; } set { this._three = value; } }
		#endregion
		#region public T4 Four
		/// <summary>The fourth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T4 Four { get { return (T4)this._four; } set { this._four = value; } }
		#endregion
		#region public T5 Five
		/// <summary>The fifth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T5 Five { get { return (T5)this._five; } set { this._five = value; } }
		#endregion
		// methods
		#region public static explicit operator Link<T1, T2, T3, T4, T5>(System.Tuple<T1, T2, T3, T4, T5> tuple)
		/// <summary>explicitly casts a System.Tuple to a Seven.Structures.Link.</summary>
		/// <param name="tuple">The System.Tuple to be casted.</param>
		/// <returns>A Seven.Structures.Link casted from the System.Tuple.</returns>
		public static explicit operator Link<T1, T2, T3, T4, T5>
			(System.Tuple<T1, T2, T3, T4, T5> tuple)
		{
			return new Link<T1, T2, T3, T4, T5>
				(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5);
		}
		#endregion
		#region public static explicit operator System.Tuple<T1, T2, T3, T4, T5>(Link<T1, T2, T3, T4, T5> link)
		/// <summary>explicitly casts a Seven.Structures.Link to a System.Tuple.</summary>
		/// <param name="tuple">The Seven.Structures.Link to be casted.</param>
		/// <returns>The System.Tuple casted Seven.Structures.Link.</returns>
		public static explicit operator System.Tuple<T1, T2, T3, T4, T5>
			(Link<T1, T2, T3, T4, T5> link)
		{
			return new System.Tuple<T1, T2, T3, T4, T5>
				((T1)link._one, (T2)link._two, (T3)link._three, (T4)link._four, (T5)link._five);
		}
		#endregion
		#region System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
			yield return this._three;
			yield return this._four;
			yield return this._five;
		}
		#endregion
		#region System.Collections.Generic.IEnumerator<object> System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<object>
			System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
			yield return this._three;
			yield return this._four;
			yield return this._five;
		}
		#endregion
		#region public System.Type[] Types()
		/// <summary>Gets an array with all the types contained in this link in respective order.</summary>
		/// <returns>An array of all the types in this link in respective order.</returns>
		public System.Type[] Types()
		{
			return new System.Type[]
			{
				typeof(T1),
				typeof(T2),
				typeof(T3),
				typeof(T4),
				typeof(T5)
			};
		}
		#endregion
		#region public	bool Contains(object item, Compare<object> compare)
		/// <summary>Checks to see if a given object is in this data structure.</summary>
		/// <param name="item">The item to check for.</param>
		/// <param name="compare">Delegate representing comparison technique.</param>
		/// <returns>true if the item is in this structure; false if not.</returns>
		public	bool Contains(object item, Compare<object> compare)
		{
			if (compare(this._one, item) == Comparison.Equal)
				return true;
			else if (compare(this._two, item) == Comparison.Equal)
				return true;
			else if (compare(this._three, item) == Comparison.Equal)
				return true;
			else if (compare(this._four, item) == Comparison.Equal)
				return true;
			else if (compare(this._five, item) == Comparison.Equal)
				return true;
			else
				return false;
		}
		#endregion
		#region public	bool Contains<Key>(Key key, Compare<object, Key> compare)
		/// <summary>Checks to see if a given object is in this data structure.</summary>
		/// <param name="item">The item to check for.</param>
		/// <param name="compare">Delegate representing comparison technique.</param>
		/// <returns>true if the item is in this structure; false if not.</returns>
		public	bool Contains<Key>(Key key, Compare<object, Key> compare)
		{
			if (compare(this._one, key) == Comparison.Equal)
				return true;
			else if (compare(this._two, key) == Comparison.Equal)
				return true;
			else if (compare(this._three, key) == Comparison.Equal)
				return true;
			else if (compare(this._four, key) == Comparison.Equal)
				return true;
			else if (compare(this._five, key) == Comparison.Equal)
				return true;
			else
				return false;
		}
		#endregion
		#region public	void Stepper(Step<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public	void Stepper(Step<object> function)
		{
			function(this._one);
			function(this._two);
			function(this._three);
			function(this._four);
			function(this._five);
		}
		#endregion
		#region public	void Stepper(StepRef<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public	void Stepper(StepRef<object> function)
		{
			function(ref this._one);
			function(ref this._two);
			function(ref this._three);
			function(ref this._four);
			function(ref this._five);
		}
		#endregion
		#region public	StepStatus Stepper(StepBreak<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public	StepStatus Stepper(StepBreak<object> function)
		{
			if (function(this._one) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(this._two) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(this._three) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(this._four) == StepStatus.Break)
				return StepStatus.Break;
			else
				return function(this._five);
		}
		#endregion
		#region public	StepStatus Stepper(StepRefBreak<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public	StepStatus Stepper(StepRefBreak<object> function)
		{
			if (function(ref this._one) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(ref this._two) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(ref this._three) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(ref this._four) == StepStatus.Break)
				return StepStatus.Break;
			else
				return function(ref this._five);
		}
		#endregion
		#region public	Structure<object> Clone()
		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public	Structure<object> Clone()
		{
			return new Link<T1, T2, T3, T4, T5>
				((T1)this._one, (T2)this._two, (T3)this._three, (T4)this._four, (T5)this._five);
		}
		#endregion
		#region public	object[] ToArray()
		/// <summary>Converts the structure into an array.</summary>
		/// <returns>An array containing all the item in the structure.</returns>
		public	object[] ToArray()
		{
			return new object[]
			{
				this._one,
				this._two,
				this._three,
				this._four,
				this._five
			};
		}
		#endregion
	}

	/// <summary>Represents a link between objects.</summary>
	/// <typeparam name="T1">The type of the first item to be linked.</typeparam>
	/// <typeparam name="T2">The type of the second item to be linked.</typeparam>
	/// <typeparam name="T3">The type of the third item to be linked.</typeparam>
	/// <typeparam name="T4">The type of the fourth item to be linked.</typeparam>
	/// <typeparam name="T5">The type of the fifth item to be linked.</typeparam>
	/// <typeparam name="T6">The type of the sixth item to be linked.</typeparam>
	[System.Serializable]
	public class Link<T1, T2, T3, T4, T5, T6> : Link
	{
		// fields
		protected object _one;
		protected object _two;
		protected object _three;
		protected object _four;
		protected object _five;
		protected object _six;
		// constructors
		#region public Link(T1 one, T2 two, T3 three, T4 four, T5 five, T6 six)
		/// <summary>Creates a link between objects.</summary>
		/// <param name="one">The first item to be linked.</param>
		/// <param name="two">The second item to be linked.</param>
		/// <param name="three">The third item to be linked.</param>
		/// <param name="four">The fourth item to be linked.</param>
		/// <param name="five">The fourth item to be linked.</param>
		/// <param name="six">The fourth item to be linked.</param>
		/// <remarks>Runtime: O(1).</remarks>
		public Link(T1 one, T2 two, T3 three, T4 four, T5 five, T6 six)
		{
			this._one = one;
			this._two = two;
			this._three = three;
			this._four = four;
			this._five = five;
			this._six = six;
		}
		#endregion
		// properties
		#region public int Size
		/// <summary>The number of objects in the tuple.</summary>
		public int Size { get { return 6; } }
		#endregion
		#region public T1 One
		/// <summary>The left item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T1 One { get { return (T1)this._one; } set { this._one = value; } }
		#endregion
		#region public T2 Two
		/// <summary>The right item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T2 Two { get { return (T2)this._two; } set { this._two = value; } }
		#endregion
		#region public T3 Three
		/// <summary>The third item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T3 Three { get { return (T3)this._three; } set { this._three = value; } }
		#endregion
		#region public T4 Four
		/// <summary>The fourth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T4 Four { get { return (T4)this._four; } set { this._four = value; } }
		#endregion
		#region public T5 Five
		/// <summary>The fifth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T5 Five { get { return (T5)this._five; } set { this._five = value; } }
		#endregion
		#region public T6 Six
		/// <summary>The sixth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T6 Six { get { return (T6)this._six; } set { this._six = value; } }
		#endregion
		// methods
		#region public static explicit operator Link<T1, T2, T3, T4, T5, T6>(System.Tuple<T1, T2, T3, T4, T5, T6> tuple)
		/// <summary>explicitly casts a System.Tuple to a Seven.Structures.Link.</summary>
		/// <param name="tuple">The System.Tuple to be casted.</param>
		/// <returns>A Seven.Structures.Link casted from the System.Tuple.</returns>
		public static explicit operator
			Link<T1, T2, T3, T4, T5, T6>
			(System.Tuple<T1, T2, T3, T4, T5, T6> tuple)
		{
			return new Link<T1, T2, T3, T4, T5, T6>
				(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6);
		}
		#endregion
		#region public static explicit operator System.Tuple<T1, T2, T3, T4, T5, T6>(Link<T1, T2, T3, T4, T5, T6> link)
		/// <summary>explicitly casts a Seven.Structures.Link to a System.Tuple.</summary>
		/// <param name="tuple">The Seven.Structures.Link to be casted.</param>
		/// <returns>The System.Tuple casted Seven.Structures.Link.</returns>
		public static explicit operator
			System.Tuple<T1, T2, T3, T4, T5, T6>
			(Link<T1, T2, T3, T4, T5, T6> link)
		{
			return new System.Tuple<T1, T2, T3, T4, T5, T6>
				((T1)link._one, (T2)link._two, (T3)link._three, (T4)link._four, (T5)link._five, (T6)link._six);
		}
		#endregion
		#region System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
			yield return this._three;
			yield return this._four;
			yield return this._five;
			yield return this._six;
		}
		#endregion
		#region System.Collections.Generic.IEnumerator<object> System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<object>
			System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
			yield return this._three;
			yield return this._four;
			yield return this._five;
			yield return this._six;
		}
		#endregion
		#region public System.Type[] Types()
		/// <summary>Gets an array with all the types contained in this link in respective order.</summary>
		/// <returns>An array of all the types in this link in respective order.</returns>
		public System.Type[] Types()
		{
			return new System.Type[]
			{
				typeof(T1),
				typeof(T2),
				typeof(T3),
				typeof(T4),
				typeof(T5),
				typeof(T6)
			};
		}
		#endregion
		#region public	bool Contains(object item, Compare<object> compare)
		/// <summary>Checks to see if a given object is in this data structure.</summary>
		/// <param name="item">The item to check for.</param>
		/// <param name="compare">Delegate representing comparison technique.</param>
		/// <returns>true if the item is in this structure; false if not.</returns>
		public	bool Contains(object item, Compare<object> compare)
		{
			if (compare(this._one, item) == Comparison.Equal)
				return true;
			else if (compare(this._two, item) == Comparison.Equal)
				return true;
			else if (compare(this._three, item) == Comparison.Equal)
				return true;
			else if (compare(this._four, item) == Comparison.Equal)
				return true;
			else if (compare(this._five, item) == Comparison.Equal)
				return true;
			else if (compare(this._six, item) == Comparison.Equal)
				return true;
			else
				return false;
		}
		#endregion
		#region public	bool Contains<Key>(Key key, Compare<object, Key> compare)
		/// <summary>Checks to see if a given object is in this data structure.</summary>
		/// <param name="item">The item to check for.</param>
		/// <param name="compare">Delegate representing comparison technique.</param>
		/// <returns>true if the item is in this structure; false if not.</returns>
		public	bool Contains<Key>(Key key, Compare<object, Key> compare)
		{
			if (compare(this._one, key) == Comparison.Equal)
				return true;
			else if (compare(this._two, key) == Comparison.Equal)
				return true;
			else if (compare(this._three, key) == Comparison.Equal)
				return true;
			else if (compare(this._four, key) == Comparison.Equal)
				return true;
			else if (compare(this._five, key) == Comparison.Equal)
				return true;
			else if (compare(this._six, key) == Comparison.Equal)
				return true;
			else
				return false;
		}
		#endregion
		#region public	void Stepper(Step<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public	void Stepper(Step<object> function)
		{
			function(this._one);
			function(this._two);
			function(this._three);
			function(this._four);
			function(this._five);
			function(this._six);
		}
		#endregion
		#region public	void Stepper(StepRef<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public	void Stepper(StepRef<object> function)
		{
			function(ref this._one);
			function(ref this._two);
			function(ref this._three);
			function(ref this._four);
			function(ref this._five);
			function(ref this._six);
		}
		#endregion
		#region public	StepStatus Stepper(StepBreak<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public	StepStatus Stepper(StepBreak<object> function)
		{
			if (function(this._one) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(this._two) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(this._three) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(this._four) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(this._five) == StepStatus.Break)
				return StepStatus.Break;
			else
				return function(this._six);
		}
		#endregion
		#region public	StepStatus Stepper(StepRefBreak<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public	StepStatus Stepper(StepRefBreak<object> function)
		{
			if (function(ref this._one) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(ref this._two) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(ref this._three) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(ref this._four) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(ref this._five) == StepStatus.Break)
				return StepStatus.Break;
			else
				return function(ref this._six);
		}
		#endregion
		#region public	Structure<object> Clone()
		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public	Structure<object> Clone()
		{
			return new Link<T1, T2, T3, T4, T5, T6>
				((T1)this._one, (T2)this._two, (T3)this._three, (T4)this._four, (T5)this._five, (T6)this._six);
		}
		#endregion
		#region public	object[] ToArray()
		/// <summary>Converts the structure into an array.</summary>
		/// <returns>An array containing all the item in the structure.</returns>
		public	object[] ToArray()
		{
			return new object[]
			{
				this._one,
				this._two,
				this._three,
				this._four,
				this._five,
				this._six
			};
		}
		#endregion
	}

	/// <summary>Represents a link between objects.</summary>
	/// <typeparam name="T1">The type of the first item to be linked.</typeparam>
	/// <typeparam name="T2">The type of the second item to be linked.</typeparam>
	/// <typeparam name="T3">The type of the third item to be linked.</typeparam>
	/// <typeparam name="T4">The type of the fourth item to be linked.</typeparam>
	/// <typeparam name="T5">The type of the fifth item to be linked.</typeparam>
	/// <typeparam name="T6">The type of the sixth item to be linked.</typeparam>
	/// <typeparam name="T7">The type of the seventh item to be linked.</typeparam>
	[System.Serializable]
	public class Link<T1, T2, T3, T4, T5, T6, T7> : Link
	{
		// fields
		protected object _one;
		protected object _two;
		protected object _three;
		protected object _four;
		protected object _five;
		protected object _six;
		protected object _seven;
		// constructors
		#region public Link(T1 one, T2 two, T3 three, T4 four, T5 five, T6 six, T7 seven)
		/// <summary>Creates a link between objects.</summary>
		/// <param name="one">The first item to be linked.</param>
		/// <param name="two">The second item to be linked.</param>
		/// <param name="three">The third item to be linked.</param>
		/// <param name="four">The fourth item to be linked.</param>
		/// <param name="five">The fourth item to be linked.</param>
		/// <param name="six">The fourth item to be linked.</param>
		/// <remarks>Runtime: O(1).</remarks>
		public Link(T1 one, T2 two, T3 three, T4 four, T5 five, T6 six, T7 seven)
		{
			this._one = one;
			this._two = two;
			this._three = three;
			this._four = four;
			this._five = five;
			this._six = six;
			this._seven = seven;
		}
		#endregion
		// properties
		#region public	int Size
		/// <summary>The number of objects in the tuple.</summary>
		public	int Size { get { return 7; } }
		#endregion
		#region public T1 One
		/// <summary>The left item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T1 One { get { return (T1)this._one; } set { this._one = value; } }
		#endregion
		#region public T2 Two
		/// <summary>The right item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T2 Two { get { return (T2)this._two; } set { this._two = value; } }
		#endregion
		#region public T3 Three
		/// <summary>The third item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T3 Three { get { return (T3)this._three; } set { this._three = value; } }
		#endregion
		#region public T4 Four
		/// <summary>The fourth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T4 Four { get { return (T4)this._four; } set { this._four = value; } }
		#endregion
		#region public T5 Five
		/// <summary>The fifth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T5 Five { get { return (T5)this._five; } set { this._five = value; } }
		#endregion
		#region public T6 Six
		/// <summary>The sixth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T6 Six { get { return (T6)this._six; } set { this._six = value; } }
		#endregion
		#region public T7 Seven
		/// <summary>The sixth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T7 Seven { get { return (T7)this._seven; } set { this._seven = value; } }
		#endregion
		// methods
		#region public static explicit operator Link<T1, T2, T3, T4, T5, T6, T7>(System.Tuple<T1, T2, T3, T4, T5, T6, T7> tuple)
		/// <summary>explicitly casts a System.Tuple to a Seven.Structures.Link.</summary>
		/// <param name="tuple">The System.Tuple to be casted.</param>
		/// <returns>A Seven.Structures.Link casted from the System.Tuple.</returns>
		public static explicit operator
			Link<T1, T2, T3, T4, T5, T6, T7>
			(System.Tuple<T1, T2, T3, T4, T5, T6, T7> tuple)
		{
			return new Link<T1, T2, T3, T4, T5, T6, T7>
				(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7);
		}
		#endregion
		#region public static explicit operator System.Tuple<T1, T2, T3, T4, T5, T6, T7>(Link<T1, T2, T3, T4, T5, T6, T7> link)
		/// <summary>explicitly casts a Seven.Structures.Link to a System.Tuple.</summary>
		/// <param name="tuple">The Seven.Structures.Link to be casted.</param>
		/// <returns>The System.Tuple casted Seven.Structures.Link.</returns>
		public static explicit operator
			System.Tuple<T1, T2, T3, T4, T5, T6, T7>
			(Link<T1, T2, T3, T4, T5, T6, T7> link)
		{
			return new System.Tuple<T1, T2, T3, T4, T5, T6, T7>
				((T1)link._one, (T2)link._two, (T3)link._three, (T4)link._four, (T5)link._five, (T6)link._six, (T7)link._seven);
		}
		#endregion
		#region System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
			yield return this._three;
			yield return this._four;
			yield return this._five;
			yield return this._six;
			yield return this._seven;
		}
		#endregion
		#region System.Collections.Generic.IEnumerator<object> System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<object>
			System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
			yield return this._three;
			yield return this._four;
			yield return this._five;
			yield return this._six;
			yield return this._seven;
		}
		#endregion
		#region public System.Type[] Types()
		/// <summary>Gets an array with all the types contained in this link in respective order.</summary>
		/// <returns>An array of all the types in this link in respective order.</returns>
		public System.Type[] Types()
		{
			return new System.Type[]
			{
				typeof(T1),
				typeof(T2),
				typeof(T3),
				typeof(T4),
				typeof(T5),
				typeof(T6),
				typeof(T7)
			};
		}
		#endregion
		#region public	bool Contains(object item, Compare<object> compare)
		/// <summary>Checks to see if a given object is in this data structure.</summary>
		/// <param name="item">The item to check for.</param>
		/// <param name="compare">Delegate representing comparison technique.</param>
		/// <returns>true if the item is in this structure; false if not.</returns>
		public	bool Contains(object item, Compare<object> compare)
		{
			if (compare(this._one, item) == Comparison.Equal)
				return true;
			if (compare(this._two, item) == Comparison.Equal)
				return true;
			if (compare(this._three, item) == Comparison.Equal)
				return true;
			if (compare(this._four, item) == Comparison.Equal)
				return true;
			if (compare(this._five, item) == Comparison.Equal)
				return true;
			if (compare(this._six, item) == Comparison.Equal)
				return true;
			if (compare(this._seven, item) == Comparison.Equal)
				return true;
			return false;
		}
		#endregion
		#region public	bool Contains<Key>(Key key, Compare<object, Key> compare)
		/// <summary>Checks to see if a given object is in this data structure.</summary>
		/// <param name="item">The item to check for.</param>
		/// <param name="compare">Delegate representing comparison technique.</param>
		/// <returns>true if the item is in this structure; false if not.</returns>
		public	bool Contains<Key>(Key key, Compare<object, Key> compare)
		{
			if (compare(this._one, key) == Comparison.Equal)
				return true;
			else if (compare(this._two, key) == Comparison.Equal)
				return true;
			else if (compare(this._three, key) == Comparison.Equal)
				return true;
			else if (compare(this._four, key) == Comparison.Equal)
				return true;
			else if (compare(this._five, key) == Comparison.Equal)
				return true;
			else if (compare(this._six, key) == Comparison.Equal)
				return true;
			else if (compare(this._seven, key) == Comparison.Equal)
				return true;
			else
				return false;
		}
		#endregion
		#region public	void Stepper(Step<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public	void Stepper(Step<object> function)
		{
			function(this._one);
			function(this._two);
			function(this._three);
			function(this._four);
			function(this._five);
			function(this._six);
			function(this._seven);
		}
		#endregion
		#region public	void Stepper(StepRef<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public	void Stepper(StepRef<object> function)
		{
			function(ref this._one);
			function(ref this._two);
			function(ref this._three);
			function(ref this._four);
			function(ref this._five);
			function(ref this._six);
			function(ref this._seven);
		}
		#endregion
		#region public	StepStatus Stepper(StepBreak<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public	StepStatus Stepper(StepBreak<object> function)
		{
			if (function(this._one) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(this._two) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(this._three) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(this._four) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(this._five) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(this._six) == StepStatus.Break)
				return StepStatus.Break;
			else
				return function(this._seven);
		}
		#endregion
		#region public	StepStatus Stepper(StepRefBreak<object> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public	StepStatus Stepper(StepRefBreak<object> function)
		{
			if (function(ref this._one) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(ref this._two) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(ref this._three) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(ref this._four) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(ref this._five) == StepStatus.Break)
				return StepStatus.Break;
			else if (function(ref this._six) == StepStatus.Break)
				return StepStatus.Break;
			else
				return function(ref this._seven);
		}
		#endregion
		#region public	Structure<object> Clone()
		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public	Structure<object> Clone()
		{
			return new Link<T1, T2, T3, T4, T5, T6, T7>
				((T1)this._one, (T2)this._two, (T3)this._three, (T4)this._four, (T5)this._five, (T6)this._six, (T7)this._seven);
		}
		#endregion
		#region public	object[] ToArray()
		/// <summary>Converts the structure into an array.</summary>
		/// <returns>An array containing all the item in the structure.</returns>
		public	object[] ToArray()
		{
			return new object[]
			{
				this._one,
				this._two,
				this._three,
				this._four,
				this._five,
				this._six,
				this._seven
			};
		}
		#endregion
	}
}