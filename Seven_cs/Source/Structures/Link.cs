// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Structures
{
	/// <summary>Represents a link between objects.</summary>
	public interface Link : Structure<object>
	{
		/// <summary>The number of objects in the tuple.</summary>
		int Size { get; }
	}

	/// <summary>Represents a link between objects.</summary>
	/// <typeparam name="T1">The type of the left item to be linked.</typeparam>
	[System.Serializable]
	public class Link<T1> : Link
	{
		#region Link<T1>

		#region field

		protected object _one;

		#endregion

		#region property

		/// <summary>The left item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T1 One { get { return (T1)this._one; } set { this._one = value; } }

		#endregion

		#region construct

		/// <summary>Creates a link between objects.</summary>
		/// <param name="one">The first item to be linked.</param>
		/// <remarks>Runtime: O(1).</remarks>
		public Link(T1 one)
		{
			this._one = one;
		}

		#endregion

		#endregion

		#region Link

		/// <summary>The number of objects in the tuple.</summary>
		public int Size { get { return 1; } }

		#endregion
		
		#region method

		/// <summary>explicitly casts a System.Tuple to a Seven.Structures.Link.</summary>
		/// <param name="tuple">The System.Tuple to be casted.</param>
		/// <returns>A Seven.Structures.Link casted from the System.Tuple.</returns>
		public static explicit operator Link<T1>(System.Tuple<T1> tuple)
		{
			return new Link<T1>(tuple.Item1);
		}

		/// <summary>explicitly casts a Seven.Structures.Link to a System.Tuple.</summary>
		/// <param name="tuple">The Seven.Structures.Link to be casted.</param>
		/// <returns>The System.Tuple casted Seven.Structures.Link.</returns>
		public static explicit operator System.Tuple<T1>(Link<T1> link)
		{
			return new System.Tuple<T1>((T1)link._one);
		}

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			yield return this._one;
		}

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<object>
			System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		{
			yield return this._one;
		}

		/// <summary>Gets an array with all the types contained in this link in respective order.</summary>
		/// <returns>An array of all the types in this link in respective order.</returns>
		public System.Type[] Types()
		{
			return new System.Type[]
			{
				typeof(T1)
			};
		}

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

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<object> function)
		{
			function(this._one);
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(StepRef<object> function)
		{
			function(ref this._one);
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepBreak<object> function)
		{
			return function(this._one);
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepRefBreak<object> function)
		{
			return function(ref this._one);
		}

		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public Structure<object> Clone()
		{
			return new Link<T1>((T1)this._one);
		}

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
		#region property

		protected object _one;
		protected object _two;

		#endregion

		#region field

		/// <summary>The number of objects in the tuple.</summary>
		public	int Size { get { return 2; } }

		/// <summary>The left item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T1 One { get { return (T1)this._one; } set { this._one = value; } }
		/// <summary>The right item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T2 Two { get { return (T2)this._two; } set { this._two = value; } }

		#endregion

		#region construct

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

		#region method

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		public static explicit operator Link<T1, T2>(System.Tuple<T1, T2> tuple)
		{
			return new Link<T1, T2>(tuple.Item1, tuple.Item2);
		}

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		public static explicit operator System.Tuple<T1, T2>(Link<T1, T2> link)
		{
			return new System.Tuple<T1, T2>((T1)link._one, (T2)link._two);
		}

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
		}

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<object>
			System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
		}

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

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<object> function)
		{
			function(this._one);
			function(this._two);
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(StepRef<object> function)
		{
			function(ref this._one);
			function(ref this._two);
		}

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

		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public	Structure<object> Clone()
		{
			return new Link<T1, T2>((T1)this._one, (T2)this._two);
		}

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
		#region field

		protected object _one;
		protected object _two;
		protected object _three;

		#endregion

		#region property

		/// <summary>The number of objects in the tuple.</summary>
		public	int Size { get { return 3; } }

		/// <summary>The left item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T1 One { get { return (T1)this._one; } set { this._one = value; } }
		/// <summary>The right item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T2 Two { get { return (T2)this._two; } set { this._two = value; } }
		/// <summary>The third item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T3 Three { get { return (T3)this._three; } set { this._three = value; } }

		#endregion

		#region construct

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

		#region method

		/// <summary>explicitly casts a System.Tuple to a Seven.Structures.Link.</summary>
		/// <param name="tuple">The System.Tuple to be casted.</param>
		/// <returns>A Seven.Structures.Link casted from the System.Tuple.</returns>
		public static explicit operator Link<T1, T2, T3>(System.Tuple<T1, T2, T3> tuple)
		{
			return new Link<T1, T2, T3>(tuple.Item1, tuple.Item2, tuple.Item3);
		}

		/// <summary>explicitly casts a Seven.Structures.Link to a System.Tuple.</summary>
		/// <param name="tuple">The Seven.Structures.Link to be casted.</param>
		/// <returns>The System.Tuple casted Seven.Structures.Link.</returns>
		public static explicit operator System.Tuple<T1, T2, T3>(Link<T1, T2, T3> link)
		{
			return new System.Tuple<T1, T2, T3>((T1)link._one, (T2)link._two, (T3)link._three);
		}

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
			yield return this._three;
		}

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<object>
			System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
			yield return this._three;
		}

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

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public	void Stepper(Step<object> function)
		{
			function(this._one);
			function(this._two);
			function(this._three);
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public	void Stepper(StepRef<object> function)
		{
			function(ref this._one);
			function(ref this._two);
			function(ref this._three);
		}

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

		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public	Structure<object> Clone()
		{
			return new Link<T1, T2, T3>
				((T1)this._one, (T2)this._two, (T3)this._three);
		}

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
		#region field

		protected object _one;
		protected object _two;
		protected object _three;
		protected object _four;

		#endregion

		#region property

		/// <summary>The number of objects in the tuple.</summary>
		public	int Size { get { return 4; } }

		/// <summary>The left item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T1 One { get { return (T1)this._one; } set { this._one = value; } }
		/// <summary>The right item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T2 Two { get { return (T2)this._two; } set { this._two = value; } }
		/// <summary>The third item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T3 Three { get { return (T3)this._three; } set { this._three = value; } }
		/// <summary>The fourth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T4 Four { get { return (T4)this._four; } set { this._four = value; } }

		#endregion

		#region construct

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

		#region method

		/// <summary>explicitly casts a System.Tuple to a Seven.Structures.Link.</summary>
		/// <param name="tuple">The System.Tuple to be casted.</param>
		/// <returns>A Seven.Structures.Link casted from the System.Tuple.</returns>
		public static explicit operator Link<T1, T2, T3, T4>
			(System.Tuple<T1, T2, T3, T4> tuple)
		{
			return new Link<T1, T2, T3, T4>
				(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
		}

		/// <summary>explicitly casts a Seven.Structures.Link to a System.Tuple.</summary>
		/// <param name="tuple">The Seven.Structures.Link to be casted.</param>
		/// <returns>The System.Tuple casted Seven.Structures.Link.</returns>
		public static explicit operator System.Tuple<T1, T2, T3, T4>
			(Link<T1, T2, T3, T4> link)
		{
			return new System.Tuple<T1, T2, T3, T4>
				((T1)link._one, (T2)link._two, (T3)link._three, (T4)link._four);
		}

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
			yield return this._three;
			yield return this._four;
		}

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<object>
			System.Collections.Generic.IEnumerable<object>.GetEnumerator()
		{
			yield return this._one;
			yield return this._two;
			yield return this._three;
			yield return this._four;
		}

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

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public	void Stepper(Step<object> function)
		{
			function(this._one);
			function(this._two);
			function(this._three);
			function(this._four);
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public	void Stepper(StepRef<object> function)
		{
			function(ref this._one);
			function(ref this._two);
			function(ref this._three);
			function(ref this._four);
		}

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

		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public	Structure<object> Clone()
		{
			return new Link<T1, T2, T3, T4>
				((T1)this._one, (T2)this._two, (T3)this._three, (T4)this._four);
		}

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
		#region field

		protected object _one;
		protected object _two;
		protected object _three;
		protected object _four;
		protected object _five;

		#endregion

		#region property

		/// <summary>The number of objects in the tuple.</summary>
		public	int Size { get { return 5; } }

		/// <summary>The left item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T1 One { get { return (T1)this._one; } set { this._one = value; } }
		/// <summary>The right item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T2 Two { get { return (T2)this._two; } set { this._two = value; } }
		/// <summary>The third item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T3 Three { get { return (T3)this._three; } set { this._three = value; } }
		/// <summary>The fourth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T4 Four { get { return (T4)this._four; } set { this._four = value; } }
		/// <summary>The fifth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T5 Five { get { return (T5)this._five; } set { this._five = value; } }

		#endregion

		#region construct

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

		#region method

		/// <summary>explicitly casts a System.Tuple to a Seven.Structures.Link.</summary>
		/// <param name="tuple">The System.Tuple to be casted.</param>
		/// <returns>A Seven.Structures.Link casted from the System.Tuple.</returns>
		public static explicit operator Link<T1, T2, T3, T4, T5>
			(System.Tuple<T1, T2, T3, T4, T5> tuple)
		{
			return new Link<T1, T2, T3, T4, T5>
				(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5);
		}

		/// <summary>explicitly casts a Seven.Structures.Link to a System.Tuple.</summary>
		/// <param name="tuple">The Seven.Structures.Link to be casted.</param>
		/// <returns>The System.Tuple casted Seven.Structures.Link.</returns>
		public static explicit operator System.Tuple<T1, T2, T3, T4, T5>
			(Link<T1, T2, T3, T4, T5> link)
		{
			return new System.Tuple<T1, T2, T3, T4, T5>
				((T1)link._one, (T2)link._two, (T3)link._three, (T4)link._four, (T5)link._five);
		}

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

		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public	Structure<object> Clone()
		{
			return new Link<T1, T2, T3, T4, T5>
				((T1)this._one, (T2)this._two, (T3)this._three, (T4)this._four, (T5)this._five);
		}

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
		#region field

		protected object _one;
		protected object _two;
		protected object _three;
		protected object _four;
		protected object _five;
		protected object _six;

		#endregion

		#region property

		/// <summary>The number of objects in the tuple.</summary>
		public	int Size { get { return 6; } }

		/// <summary>The left item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T1 One { get { return (T1)this._one; } set { this._one = value; } }
		/// <summary>The right item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T2 Two { get { return (T2)this._two; } set { this._two = value; } }
		/// <summary>The third item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T3 Three { get { return (T3)this._three; } set { this._three = value; } }
		/// <summary>The fourth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T4 Four { get { return (T4)this._four; } set { this._four = value; } }
		/// <summary>The fifth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T5 Five { get { return (T5)this._five; } set { this._five = value; } }
		/// <summary>The sixth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T6 Six { get { return (T6)this._six; } set { this._six = value; } }

		#endregion

		#region construct

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

		#region method

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

		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public	Structure<object> Clone()
		{
			return new Link<T1, T2, T3, T4, T5, T6>
				((T1)this._one, (T2)this._two, (T3)this._three, (T4)this._four, (T5)this._five, (T6)this._six);
		}

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
		#region field

		protected object _one;
		protected object _two;
		protected object _three;
		protected object _four;
		protected object _five;
		protected object _six;
		protected object _seven;

		#endregion

		#region property

		/// <summary>The number of objects in the tuple.</summary>
		public	int Size { get { return 7; } }

		/// <summary>The left item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T1 One { get { return (T1)this._one; } set { this._one = value; } }
		/// <summary>The right item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T2 Two { get { return (T2)this._two; } set { this._two = value; } }
		/// <summary>The third item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T3 Three { get { return (T3)this._three; } set { this._three = value; } }
		/// <summary>The fourth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T4 Four { get { return (T4)this._four; } set { this._four = value; } }
		/// <summary>The fifth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T5 Five { get { return (T5)this._five; } set { this._five = value; } }
		/// <summary>The sixth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T6 Six { get { return (T6)this._six; } set { this._six = value; } }
		/// <summary>The sixth item in the link.</summary>
		/// <remarks>Runtime: O(1).</remarks>
		public T7 Seven { get { return (T7)this._seven; } set { this._seven = value; } }

		#endregion

		#region construct

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

		#region method

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

		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public	Structure<object> Clone()
		{
			return new Link<T1, T2, T3, T4, T5, T6, T7>
				((T1)this._one, (T2)this._two, (T3)this._three, (T4)this._four, (T5)this._five, (T6)this._six, (T7)this._seven);
		}

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