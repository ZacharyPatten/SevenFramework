// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven
{
	/// <summary>Comparison operator between two operands in a logical expression.</summary>
	[System.Serializable]
	public enum Comparison
	{
		/// <summary>The left operand is less than the right operand.</summary>
		Less = -1,
		/// <summary>The left operand is equal to the right operand.</summary>
		Equal = 0,
		/// <summary>The left operand is greater than the right operand.</summary>
		Greater = 1
	};

	/// <summary>Delegate for comparing two instances of the same type.</summary>
	/// <typeparam name="T">The type of the istances to compare.</typeparam>
	/// <param name="left">The left operand of the comparison.</param>
	/// <param name="right">The right operand of the comparison.</param>
	/// <returns>The Comparison operator between the operands to form a true logic statement.</returns>
	[System.Serializable]
	public delegate Comparison Compare<T>(T left, T right);

	/// <summary>Delegate for comparing two instances of different types.</summary>
	/// <typeparam name="Left">The type of the left istance to compare.</typeparam>
	/// <typeparam name="Right">The type of the right instance to compare.</typeparam>
	/// <param name="left">The left operand of the comparison.</param>
	/// <param name="right">The right operand of the comparison.</param>
	/// <returns>The Comparison operator between the operands to form a true logic statement.</returns>
	[System.Serializable]
	public delegate Comparison Compare<Left, Right>(Left left, Right right);

	/// <summary>Static wrapper for "CompareTo" methods on IComparables.</summary>
	public static class Compare
	{
		/// <summary>Inverts a comparison delegate.</summary>
		/// <returns>The invert of the compare delegate.</returns>
		public static Compare<L, R> Invert<L, R>(Compare<L, R> comparison)
		{
			return (L left, R right) =>
			{
				return Compare.Invert(comparison(left, right));
			};
		}

		/// <summary>Inverts a comparison delegate.</summary>
		/// <returns>The invert of the compare delegate.</returns>
		public static Compare<T> Invert<T>(Compare<T> comparison)
		{
			return (T left, T right) =>
				{
					return Compare.Invert(comparison(left, right));
				};
		}

		/// <summary>Inverts a comparison value.</summary>
		/// <returns>The invert of the comparison value.</returns>
		public static Comparison Invert(Comparison comparison)
		{
			switch (comparison)
			{
				case Comparison.Greater:
					return Comparison.Less;
				case Comparison.Less:
					return Comparison.Greater;
				case Comparison.Equal:
					return Comparison.Equal;
				default:
					throw new Error("Not Implemented");
			}
		}

		/// <summary>Static wrapper for "CompareTo" methods on IComparables.</summary>
		public static Comparison Default<T>(T left, T right)
			where T : System.IComparable<T>
		{
			int comparison = left.CompareTo(right);
			if (comparison < 0)
				return Comparison.Less;
			else if (comparison > 0)
				return Comparison.Greater;
			else
				return Comparison.Equal;
		}
	}
}
