namespace Seven.Structures
{
	/// <summary>Sorted linear data structure.</summary>
	/// <typeparam name="T">The generic type stored in this data structure.</typeparam>
	public interface Order<T> : Structure<T>,
		// Structure Properties
		Structure.Countable<T>,
		Structure.Clearable<T>,
		Structure.Addable<T>,
		Structure.Comparing<T>
	{
		#region void RemoveFirst(T removal);
		/// <summary>Removes the first occurence of an item in the list.</summary>
		/// <param name="removal">The item to remove.</param>
		void RemoveFirst(T removal);
		#endregion
		#region bool TryRemoveFirst(T removal);
		/// <summary>Removes the first occurence of an item in the list or returns false.</summary>
		/// <param name="removal">The item to remove.</param>
		/// <returns>True if the item was found and removed; False if not.</returns>
		bool TryRemoveFirst(T removal);
		#endregion
		#region void RemoveAll(T removal);
		/// <summary>Removes all occurences of an item in the list.</summary>
		/// <param name="removal">The item to genocide (hell yeah that is a verb...).</param>
		void RemoveAll(T removal);
		#endregion
	}

	/// <summary>Sorted linear data structure implemented using a list array.</summary>
	/// <typeparam name="T">The generic type stored in this data structure.</typeparam>
	public class OrderListArray<T> : Order<T>
	{
		// fields
		private ListArray<T> _list;
		private Compare<T> _compare;
		// constructors
		#region public Order_ListArray(Compare<T> compare)
		/// <summary>Constructs a Order_ListArray.</summary>
		/// <param name="compare">The soring technique used by this data structure.</param>
		public OrderListArray(Compare<T> compare)
		{
			this._compare = compare;
			this._list = new ListArray<T>();
		}
		#endregion
		// properties
		#region public Compare<T> Compare
		/// <summary>The comparison function utilized by this data structure.</summary>
		public Compare<T> Compare { get { return this._compare; } }
		#endregion
		#region public int Count
		/// <summary>Returns the number of items in the list.</summary>
		public int Count { get { return this._list.Count; } }
		#endregion
		// methods
		#region public void Add(T addition)
		/// <summary>Adds an item to the end of this list.</summary>
		/// <param name="addition">The item to add to the list.</param>
		public void Add(T addition)
		{
			// NOTE: this can be optimized with a binary search
			int index;
			for (index = this._list.Count; index > 0; index--)
			{
				if (this._compare(addition, this._list[index - 1]) == Comparison.Greater)
					break;
			}
			this._list.Add(addition, index);
		}
		#endregion
		#region public void RemoveFirst(T removal)
		/// <summary>Removes the first occurence of an item in the list.</summary>
		/// <param name="removal">The item to remove.</param>
		/// <param name="compare">The function to determine equality.</param>
		public void RemoveFirst(T removal)
		{
			throw new System.NotImplementedException();
			//if (!this._list.TryRemoveFirst(removal, this._compare))
			//	throw new System.Exception("attempting to remove a non-existing first item from an order");
		}
		#endregion
		#region public bool TryRemoveFirst(T removal)
		/// <summary>Removes the first occurence of an item in the list or returns false.</summary>
		/// <param name="removal">The item to remove.</param>
		/// <param name="compare">The function to determine equality.</param>
		/// <returns>True if the item was found and removed; False if not.</returns>
		public bool TryRemoveFirst(T removal)
		{
			throw new System.NotImplementedException();
			//return this._list.TryRemoveFirst(removal, this._compare);
		}
		#endregion
		#region public void RemoveAll(T removal)
		/// <summary>Removes all occurences of an item in the list.</summary>
		/// <param name="removal">The item to genocide (hell yeah that is a verb...).</param>
		/// <param name="compare">The function to determine equality.</param>
		public void RemoveAll(T removal)
		{
			throw new System.NotImplementedException();
			//this._list.RemoveAll(removal, this._compare);
		}
		#endregion
		#region public void Clear()
		/// <summary>Resets the list to an empty state. WARNING could cause excessive garbage collection.</summary>
		public void Clear()
		{
			this._list.Clear();
		}
		#endregion
		#region public void Stepper(Step<T> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<T> function)
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public void Stepper(StepRef<T> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(StepRef<T> function)
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public StepStatus Stepper(StepBreak<T> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepBreak<T> function)
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public StepStatus Stepper(StepRefBreak<T> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepRefBreak<T> function)
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		System.Collections.Generic.IEnumerator<T>
			System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}
		#endregion
	}

	/// <summary>Sorted linear data structure implemented using a list array.</summary>
	/// <typeparam name="T">The generic type stored in this data structure.</typeparam>
	public class OrderListLinked<T> : Order<T>
	{
		// fields
		internal ListLinked<T> _list;
		internal Compare<T> _compare;
		// constructores
		#region public Order_ListLinked(Compare<T> compare)
		/// <summary>Constructs a Order_ListArray.</summary>
		/// <param name="compare">The soring technique used by this data structure.</param>
		public OrderListLinked(Compare<T> compare)
		{
			this._compare = compare;
			this._list = new ListLinked<T>();
		}
		#endregion
		// properties
		#region public Compare<T> Compare
		/// <summary>The comparison function utilized by this data structure.</summary>
		public Compare<T> Compare { get { return this._compare; } }
		#endregion
		#region public int Count
		/// <summary>Returns the number of items in the list.</summary>
		public int Count { get { return this._list.Count; } }
		#endregion
		// methods
		#region public void Add(T addition)
		/// <summary>Adds an item to the end of this list.</summary>
		/// <param name="addition">The item to add to the list.</param>
		public void Add(T addition)
		{
			throw new System.NotImplementedException();
			//// NOTE: this can be optimized with a binary search
			//int index;
			//for (index = this._list.Count; index > 0; index--)
			//{
			//	if (this._compare(addition, this._list[index - 1]) == Comparison.Greater)
			//		break;
			//}
			//this._list.Add(addition, index);
		}
		#endregion
		#region public void RemoveFirst(T removal)
		/// <summary>Removes the first occurence of an item in the list.</summary>
		/// <param name="removal">The item to remove.</param>
		/// <param name="compare">The function to determine equality.</param>
		public void RemoveFirst(T removal)
		{
			throw new System.NotImplementedException();
			//if (!this._list.TryRemoveFirst(removal, this._compare))
			//	throw new System.Exception("attempting to remove a non-existing first item from an order");
		}
		#endregion
		#region public bool TryRemoveFirst(T removal)
		/// <summary>Removes the first occurence of an item in the list or returns false.</summary>
		/// <param name="removal">The item to remove.</param>
		/// <param name="compare">The function to determine equality.</param>
		/// <returns>True if the item was found and removed; False if not.</returns>
		public bool TryRemoveFirst(T removal)
		{
			throw new System.NotImplementedException(); 
			//return this._list.TryRemoveFirst(removal, this._compare);
		}
		#endregion
		#region public void RemoveAll(T removal)
		/// <summary>Removes all occurences of an item in the list.</summary>
		/// <param name="removal">The item to genocide (hell yeah that is a verb...).</param>
		/// <param name="compare">The function to determine equality.</param>
		public void RemoveAll(T removal)
		{
			throw new System.NotImplementedException(); 
			//this._list.RemoveAll(removal, this._compare);
		}
		#endregion
		#region public void Clear()
		/// <summary>Resets the list to an empty state. WARNING could cause excessive garbage collection.</summary>
		public void Clear()
		{
			this._list.Clear();
		}
		#endregion
		#region public void Stepper(Step<T> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<T> function)
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public void Stepper(StepRef<T> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(StepRef<T> function)
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public StepStatus Stepper(StepBreak<T> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepBreak<T> function)
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region public StepStatus Stepper(StepRefBreak<T> function)
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepRefBreak<T> function)
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}
		#endregion
		#region System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		System.Collections.Generic.IEnumerator<T>
			System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}
		#endregion
	}
}
