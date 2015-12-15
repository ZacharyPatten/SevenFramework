// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Structures
{
	/// <summary>Polymorphism base for all data structures in the Seven framework.</summary>
	/// <typeparam name="T">The type of the instances to store in this data structure.</typeparam>
	public interface Structure<T> : 
		// for those who can't live without their IEnumerables... shame on you
		System.Collections.Generic.IEnumerable<T>
	{
		#region member

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="step_delegate">The delegate to invoke on each item in the structure.</param>
		void Stepper(Step<T> step_delegate);
		///// <summary>Invokes a delegate for each entry in the data structure.</summary>
		///// <param name="step_delegate">The delegate to invoke on each item in the structure.</param>
		//void Stepper(StepRef<T> step_delegate);
		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="step_delegate">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		StepStatus Stepper(StepBreak<T> step_delegate);
		///// <summary>Invokes a delegate for each entry in the data structure.</summary>
		///// <param name="step_delegate">The delegate to invoke on each item in the structure.</param>
		///// <returns>The resulting status of the iteration.</returns>
		//StepStatus Stepper(StepRefBreak<T> step_delegate);

		#endregion
	}

	/// <summary>Contains extension methods for the Structure interface.</summary>
	public static class Structure
	{
		#region extensions

		/// <summary>Checks to see if a given object is in this data structure.</summary>
		/// <typeparam name="T">The generic type stored in the structure.</typeparam>
		/// <param name="structure">The structure to check against.</param>
		/// <param name="check">The item to check for.</param>
		/// <param name="equate">Delegate for equating two instances of the same type.</param>
		/// <returns>true if the item is in this structure; false if not.</returns>
		public static bool Contains<T>(this Structure<T> structure, T check, Equate<T> equate)
		{
			bool contains = false;
			structure.Stepper((T step) =>
			{
				if (equate(step, check))
				{
					contains = true;
					return StepStatus.Break;
				}
				return StepStatus.Continue;
			});
			return contains;
		}

		/// <summary>Checks to see if a given object is in this data structure.</summary>
		/// <typeparam name="T">The generic type stored in the structure.</typeparam>
		/// <typeparam name="K">The type of the key to look up.</typeparam>
		/// <param name="structure">The structure to check against.</param>
		/// <param name="key">The key to check for.</param>
		/// <param name="equate">Delegate for equating two instances of different types.</param>
		/// <returns>true if the item is in this structure; false if not.</returns>
		public static bool Contains<T, K>(this Structure<T> structure, K key, Equate<T, K> equate)
		{
			bool contains = false;
			structure.Stepper((T step) =>
			{
				if (equate(step, key))
				{
					contains = true;
					return StepStatus.Break;
				}
				return StepStatus.Continue;
			});
			return contains;
		}

		/// <summary>Looks up an item this structure by a given key.</summary>
		/// <typeparam name="T">The generic type stored in the structure.</typeparam>
		/// <typeparam name="K">The type of the key to look up.</typeparam>
		/// <param name="structure">The structure to check against.</param>
		/// <param name="key">The key to look up.</param>
		/// <param name="equate">Delegate for equating two instances of different types.</param>
		/// <returns>The item with the corresponding to the given key.</returns>
		public static T Get<T, K>(this Structure<T> structure, K key, Equate<T, K> equate)
		{
			bool contains = false;
			T item = default(T);
			structure.Stepper((T step) =>
			{
				if (equate(step, key))
				{
					contains = true;
					item = step;
					return StepStatus.Break;
				}
				return StepStatus.Continue;
			});
			if (contains == false)
				throw new Error("item not found in structure");
			return item;
		}

		/// <summary>Trys to look up an item this structure by a given key.</summary>
		/// <typeparam name="T">The generic type stored in the structure.</typeparam>
		/// <typeparam name="K">The type of the key to look up.</typeparam>
		/// <param name="structure">The structure to check against.</param>
		/// <param name="key">The key to look up.</param>
		/// <param name="equate">Delegate for equating two instances of different types.</param>
		/// <param name="item">The item if it was found or null if not the default(Type) value.</param>
		/// <returns>true if the key was found; false if the key was not found.</returns>
		public static bool TryGet<T, K>(this Structure<T> structure, K key, Equate<T, K> equate, out T item)
		{
			bool contains = false;
			T temp = default(T);
			structure.Stepper((T step) =>
			{
				if (equate(step, key))
				{
					contains = true;
					temp = step;
					return StepStatus.Break;
				}
				return StepStatus.Continue;
			});
			item = temp;
			return contains;
		}

		#endregion
	}
}
