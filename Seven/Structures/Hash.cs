// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Structures
{
  /// <summary>Delegate for hash code computation.</summary>
  /// <typeparam name="T">The type of this hash function.</typeparam>
  /// <param name="item">The instance to compute the hash of.</param>
  /// <returns>The computed hash of the given item.</returns>
  public delegate int Hash<T>(T item);

  /// <summary>Static wrapper for the based "object.GetHashCode" fuction.</summary>
  public static class Hash
  {
    /// <summary>Static wrapper for the instance based "object.GetHashCode" fuction.</summary>
    /// <typeparam name="T">The generic type of the hash operation.</typeparam>
    /// <param name="item">The item to get the hash code of.</param>
    /// <returns>The computed hash code using the base GetHashCode instance method.</returns>
    public static int Compute<T>(T item) { return item.GetHashCode(); }
  }
}
