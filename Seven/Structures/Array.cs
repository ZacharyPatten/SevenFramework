// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Structures
{
	/// <summary>Contiguous fixed-sized data structure.</summary>
	/// <typeparam name="T">The generic type within the structure.</typeparam>
	public interface Array<T> : Structure<T>
	{
		#region member

		/// <summary>Allows indexed access of the array.</summary>
		/// <param name="index">The index of the array to get/set.</param>
		/// <returns>The value at the desired index.</returns>
		T this[int index] { get; set; }
		/// <summary>The length of the array.</summary>
		int Length { get; }

		#endregion
	}

	/// <summary>Contiguous fixed-sized data structure.</summary>
	/// <typeparam name="T">The generic type within the structure.</typeparam>
	[System.Serializable]
	public class Array_Array<T> : Array<T>
	{
		#region Array_Array<T>

		#region field

		public T[] _array;

		#endregion

		#region operators

		/// <summary>Implicitly converts a C# System array into a Seven array.</summary>
		/// <param name="array">The array to be represented as a Seven array.</param>
		/// <returns>The array wrapped in a Seven array.</returns>
		public static implicit operator Array_Array<T>(T[] array)
		{
			return new Array_Array<T>(array);
		}

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		public static implicit operator T[](Array_Array<T> array)
		{
			return array.ToArray();
		}

		#endregion

		#region constructor

		/// <summary>Constructs an array that implements a traversal delegate function 
		/// which is an optimized "foreach" implementation.</summary>
		/// <param name="size">The length of the array in memory.</param>
		public Array_Array(int size)
		{
			if (size < 1)
				throw new Error("size of the array must be at least 1.");
			this._array = new T[size];
		}

		/// <summary>Constructs by wrapping an existing array.</summary>
		/// <param name="array">The array to be wrapped.</param>
		public Array_Array(params T[] array)
		{
			this._array = new T[array.Length];
			for (int i = 0; i < array.Length; i++)
				this._array[i] = array[i];
		}

		#endregion

		#region method

		/// <summary>Creates a shallow clone of this data structure.</summary>
		/// <returns>A shallow clone of this data structure.</returns>
		public Array_Array<T> Clone()
		{
			Array_Array<T> clone = new Array_Array<T>(_array.Length);
			for (int i = 0; i < this._array.Length; i++)
				clone._array[i] = this._array[i];
			return clone;
		}

		/// <summary>Converts the structure into an array.</summary>
		/// <returns>An array containing all the item in the structure.</returns>
		public T[] ToArray()
		{
			T[] array = new T[this._array.Length];
			for (int i = 0; i < this._array.Length; i++)
				array[i] = this._array[i];
			return array;
		}

		#endregion

		#endregion

		#region Array<T>

		/// <summary>The length of the array.</summary>
		public int Length { get { return _array.Length; } }

		/// <summary>Allows indexed access of the array.</summary>
		/// <param name="index">The index of the array to get/set.</param>
		/// <returns>The value at the desired index.</returns>
		public T this[int index]
		{
			get
			{
				try { return _array[index]; }
				catch { throw new Error("index out of bounds."); }
			}
			set
			{
				try { _array[index] = value; }
				catch { throw new Error("index out of bounds."); }
			}
		}

		#endregion

		#region Structure<T>

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(Step<T> function)
		{

			for (int i = 0; i < _array.Length; i++)
				function(_array[i]);
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		public void Stepper(StepRef<T> function)
		{
			for (int i = 0; i < _array.Length; i++)
				function(ref _array[i]);
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepBreak<T> function)
		{
			for (int i = 0; i < _array.Length; i++)
				if (function(_array[i]) == StepStatus.Break)
					return StepStatus.Break;
			return StepStatus.Continue;
		}

		/// <summary>Invokes a delegate for each entry in the data structure.</summary>
		/// <param name="function">The delegate to invoke on each item in the structure.</param>
		/// <returns>The resulting status of the iteration.</returns>
		public StepStatus Stepper(StepRefBreak<T> function)
		{
			for (int i = 0; i < _array.Length; i++)
				if (function(ref _array[i]) == StepStatus.Break)
					return StepStatus.Break;
			return StepStatus.Continue;
		}

		#endregion

		#region IEnumerable<T>

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.IEnumerator
			System.Collections.IEnumerable.GetEnumerator()
		{
			for (int i = 0; i < _array.Length; i++)
				yield return _array[i];
		}

		/// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
		System.Collections.Generic.IEnumerator<T>
			System.Collections.Generic.IEnumerable<T>.GetEnumerator()
		{
			for (int i = 0; i < _array.Length; i++)
				yield return _array[i];
		}

		#endregion
	}
}
