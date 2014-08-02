// Seven
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
}