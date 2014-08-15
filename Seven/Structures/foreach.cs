// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Structures
{
  /// <summary>Status of data structure iteration.</summary>
  public enum ForeachStatus
  {
    /// <summary>Iteration has/was not broken.</summary>
    Continue = 0,
    /// <summary>Iteration has/was broken.</summary>
    Break = 1,

    // Restart // I haven't decide whether to include this one or not (I need to do some speed testing...)
  };

  /// <summary>Delegate for data structure iteration.</summary>
  /// <typeparam name="Type">The type of the instances within the data structure.</typeparam>
  /// <param name="current">The current instance of iteration through the data structure.</param>
  public delegate void Foreach<Type>(Type current);

  /// <summary>Delegate for data structure iteration.</summary>
  /// <typeparam name="Type">The type of the instances within the data structure.</typeparam>
  /// <param name="current">The current instance of iteration through the data structure.</param>
  public delegate void ForeachRef<Type>(ref Type current);

  /// <summary>Delegate for data structure iteration.</summary>
  /// <typeparam name="Type">The type of the instances within the data structure.</typeparam>
  /// <param name="current">The current instance of iteration through the data structure.</param>
  /// <returns>The status of the iteration. Allows breaking functionality.</returns>
  public delegate ForeachStatus ForeachBreak<Type>(Type current);

  /// <summary>Delegate for data structure iteration.</summary>
  /// <typeparam name="Type">The type of the instances within the data structure.</typeparam>
  /// <param name="current">The current instance of iteration through the data structure.</param>
  /// <returns>The status of the iteration. Allows breaking functionality.</returns>
  public delegate ForeachStatus ForeachRefBreak<Type>(ref Type current);

  /// <summary>Delegate for a traversal function on a data structure.</summary>
  /// <typeparam name="T">The type of instances the will be traversed.</typeparam>
  /// <param name="function">The foreach function to perform on each iteration.</param>
  public delegate void Traversal<T>(Foreach<T> function);
}
