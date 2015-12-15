namespace Seven.Structures
{
	/// <summary>Sorted linear data structure.</summary>
	/// <typeparam name="T">The generic type stored in this data structure.</typeparam>
	public interface Order<T> : Structure<T>
	{
		#region member

		/// <summary>The comparison function utilized by this data structure.</summary>
		Compare<T> Compare { get; }
		/// <summary>Returns the number of items in the list.</summary>
		int Count { get; }
		/// <summary>Adds an item to the end of this list.</summary>
		/// <param name="addition">The item to add to the list.</param>
		void Add(T addition);
		/// <summary>Removes the first occurence of an item in the list.</summary>
		/// <param name="removal">The item to remove.</param>
		void RemoveFirst(T removal);
		/// <summary>Removes the first occurence of an item in the list or returns false.</summary>
		/// <param name="removal">The item to remove.</param>
		/// <returns>True if the item was found and removed; False if not.</returns>
		bool TryRemoveFirst(T removal);
		/// <summary>Removes all occurences of an item in the list.</summary>
		/// <param name="removal">The item to genocide (hell yeah that is a verb...).</param>
		void RemoveAll(T removal);
		/// <summary>Resets the list to an empty state. WARNING could cause excessive garbage collection.</summary>
		void Clear();

		#endregion
	}

	/// <summary>Sorted linear data structure implemented using a list array.</summary>
	/// <typeparam name="T">The generic type stored in this data structure.</typeparam>
	public class Order_ListArray<T> : Order<T>
	{
		#region Order_List<T>

		#region field

		private List_Array<T> _list;
		private Compare<T> _compare;

		#endregion

		#region construct

		/// <summary>Constructs a Order_ListArray.</summary>
		/// <param name="compare">The soring technique used by this data structure.</param>
		public Order_ListArray(Compare<T> compare)
		{
			this._compare = compare;
			this._list = new List_Array<T>();
		}

		#endregion

		#endregion

		#region Order<T>

		/// <summary>The comparison function utilized by this data structure.</summary>
		public Compare<T> Compare { get { return this._compare; } }

		/// <summary>Returns the number of items in the list.</summary>
		public int Count { get { return this._list.Count; } }

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

		/// <summary>Removes the first occurence of an item in the list.</summary>
		/// <param name="removal">The item to remove.</param>
		/// <param name="compare">The function to determine equality.</param>
		public void RemoveFirst(T removal)
		{
			if (!this._list.TryRemoveFirst(removal, this._compare))
				throw new Error("attempting to remove a non-existing first item from an order");
		}

		/// <summary>Removes the first occurence of an item in the list or returns false.</summary>
		/// <param name="removal">The item to remove.</param>
		/// <param name="compare">The function to determine equality.</param>
		/// <returns>True if the item was found and removed; False if not.</returns>
		public bool TryRemoveFirst(T removal)
		{
			return this._list.TryRemoveFirst(removal, this._compare);
		}

		/// <summary>Removes all occurences of an item in the list.</summary>
		/// <param name="removal">The item to genocide (hell yeah that is a verb...).</param>
		/// <param name="compare">The function to determine equality.</param>
		public void RemoveAll(T removal)
		{
			this._list.RemoveAll(removal, this._compare);
		}

		/// <summary>Resets the list to an empty state. WARNING could cause excessive garbage collection.</summary>
		public void Clear()
		{
			this._list.Clear();
		}

		#endregion

		#region Structure<T>

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<T> function)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(StepRef<T> function)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepBreak<T> function)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepRefBreak<T> function)
		{
			throw new System.NotImplementedException();
		}

		#endregion

		#region IEnumerator<T>

		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}

		System.Collections.Generic.IEnumerator<T>
			System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}

		#endregion
	}

	/// <summary>Sorted linear data structure implemented using a list array.</summary>
	/// <typeparam name="T">The generic type stored in this data structure.</typeparam>
	public class Order_ListLinked<T> : Order<T>
	{
		#region Order_List<T>

		#region field

		internal List_Linked<T> _list;
		internal Compare<T> _compare;

		#endregion

		#region construct

		/// <summary>Constructs a Order_ListArray.</summary>
		/// <param name="compare">The soring technique used by this data structure.</param>
		public Order_ListLinked(Compare<T> compare)
		{
			this._compare = compare;
			this._list = new List_Linked<T>();
		}

		#endregion

		#endregion

		#region Order<T>

		/// <summary>The comparison function utilized by this data structure.</summary>
		public Compare<T> Compare { get { return this._compare; } }

		/// <summary>Returns the number of items in the list.</summary>
		public int Count { get { return this._list.Count; } }

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

		/// <summary>Removes the first occurence of an item in the list.</summary>
		/// <param name="removal">The item to remove.</param>
		/// <param name="compare">The function to determine equality.</param>
		public void RemoveFirst(T removal)
		{
			if (!this._list.TryRemoveFirst(removal, this._compare))
				throw new Error("attempting to remove a non-existing first item from an order");
		}

		/// <summary>Removes the first occurence of an item in the list or returns false.</summary>
		/// <param name="removal">The item to remove.</param>
		/// <param name="compare">The function to determine equality.</param>
		/// <returns>True if the item was found and removed; False if not.</returns>
		public bool TryRemoveFirst(T removal)
		{
			return this._list.TryRemoveFirst(removal, this._compare);
		}

		/// <summary>Removes all occurences of an item in the list.</summary>
		/// <param name="removal">The item to genocide (hell yeah that is a verb...).</param>
		/// <param name="compare">The function to determine equality.</param>
		public void RemoveAll(T removal)
		{
			this._list.RemoveAll(removal, this._compare);
		}

		/// <summary>Resets the list to an empty state. WARNING could cause excessive garbage collection.</summary>
		public void Clear()
		{
			this._list.Clear();
		}

		#endregion

		#region Structure<T>

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<T> function)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(StepRef<T> function)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepBreak<T> function)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepRefBreak<T> function)
		{
			throw new System.NotImplementedException();
		}

		#endregion

		#region IEnumerator<T>

		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}

		System.Collections.Generic.IEnumerator<T>
			System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}

		#endregion
	}
}
