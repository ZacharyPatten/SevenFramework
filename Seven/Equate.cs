﻿// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven
{
	/// <summary>Delegate for equating two instances of the same type.</summary>
	/// <typeparam name="T">The types of the instances to compare.</typeparam>
	/// <param name="left">The left operand of the comparison.</param>
	/// <param name="right">The right operand of the comparison.</param>
	/// <returns>Whether the equate is valid (true) or not (false).</returns>
	public delegate bool Equate<T>(T left, T right);

	/// <summary>Delegate for equating multiple instances of the same type.</summary>
	/// <typeparam name="T">The types of the instances to compare.</typeparam>
	/// <param name="items">The items to be compared.</param>
	/// <returns>True if all the items are considered equal.</returns>
	public delegate bool Equate_params<T>(params T[] items);

	/// <summary>Delegate for equating two instances of different types.</summary>
	/// <typeparam name="L">The type of the left instance to compare.</typeparam>
	/// <typeparam name="R">The type of the right instance to compare.</typeparam>
	/// <param name="left">The left operand of the equating.</param>
	/// <param name="right">The right operand of the equating.</param>
	/// <returns>Whether the equate is valid (true) or not (false).</returns>
	public delegate bool Equate<L, R>(L left, R right);

	/// <summary>Static wrapper for the based "object.Equals" fuction.</summary>
	public static class Equate
	{
		/// <summary>Static wrapper for the based "object.Equals" fuction.</summary>
		/// <typeparam name="T">The generic type of this operation.</typeparam>
		/// <param name="a">The first item of the equate function.</param>
		/// <param name="b">The second item of the equate function.</param>
		/// <returns>True if deemed equal; False if not.</returns>
		public static bool Default<T>(T a, T b) { return a.Equals(b); }
	}

	/// <summary>Used for optional parameters.</summary>
	/// <typeparam name="T">The generic type of the equality check.</typeparam>
	public static class Equate_CompileTimeConstant<T>
	{
		public static Equate<T> Default { get { return (T a, T b) => { return a.Equals(b); }; } }
	}
}