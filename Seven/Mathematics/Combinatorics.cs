// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics
{
  /// <summary>Supplies combinatoric mathematics for generic types.</summary>
  /// <typeparam name="T">The type this combinatoric library can perform on.</typeparam>
  public interface Combinatorics<T>
  {
    #region method

    /// <summary>Computes: [ N! ].</summary>
    Combinatorics.delegates.Factorial<T> Factorial { get; }
    /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
    Combinatorics.delegates.Combinations<T> Combinations { get; }
    /// <summary>Computes: [ N! / (N - n)! ]</summary>
    Combinatorics.delegates.Choose<T> Choose { get; }

    #endregion
  }

  /// <summary>Contains combinatoric mathematics implementations.</summary>
  public static class Combinatorics
  {
    #region delegates

    public static class delegates
    {
      /// <summary>Computes: [ N! ].</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="N">The number to compute the factorial of.</param>
      /// <returns>[ N! ]</returns>
      public delegate T Factorial<T>(T N);
      /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="N">The total number of items in the set.</param>
      /// <param name="n">The number of items in the respective sub-sets.</param>
      /// <returns>[ N! / (n[0]! + n[1]! + n[3]! ...) ]</returns>
      public delegate T Combinations<T>(T N, params T[] n);
      /// <summary>Computes: [ N! / (N - n)! ]</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="N">The total number of items.</param>
      /// <param name="n">The number of items to choose.</param>
      /// <returns>[ N! / (N - n)! ]</returns>
      public delegate T Choose<T>(T N, T n);
    }

    #endregion

    #region library

    public static Seven.Structures.Map<object, System.Type> _combinatorics =
      new Seven.Structures.Map_Linked<object, System.Type>(
        (System.Type left, System.Type right) => { return left == right; },
        (System.Type type) => { return type.GetHashCode(); })
				{
					{ typeof(int), Combinatorics_int.Get },
          { typeof(long), Combinatorics_long.Get },
          { typeof(long), Combinatorics_float.Get },
          { typeof(long), Combinatorics_double.Get },
          { typeof(long), Combinatorics_decimal.Get },
				};

    public static Combinatorics<T> Get<T>()
    {
      try { return (Combinatorics<T>)_combinatorics[typeof(T)]; }
      catch { throw new Error("LinearAlgebra does not yet exist for " + typeof(T).ToString()); }
    }

    #region provided

    private class Combinatorics_decimal : Combinatorics<decimal>
    {
      private Combinatorics_decimal() { _instance = this; }
      private static Combinatorics_decimal _instance;
      private static Combinatorics_decimal Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Combinatorics_decimal();
          else
            return _instance;
        }
      }

      public static Combinatorics_decimal Get { get { return Instance; } }

      /// <summary>Computes: [ N! ].</summary>
      public Combinatorics.delegates.Factorial<decimal> Factorial { get { return Combinatorics.Factorial; } }
      /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
      public Combinatorics.delegates.Combinations<decimal> Combinations { get { return Combinatorics.Combinations; } }
      /// <summary>Computes: [ N! / (N - n)! ]</summary>
      public Combinatorics.delegates.Choose<decimal> Choose { get { return Combinatorics.Choose; } }
    }

    private class Combinatorics_double : Combinatorics<double>
    {
      private Combinatorics_double() { _instance = this; }
      private static Combinatorics_double _instance;
      private static Combinatorics_double Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Combinatorics_double();
          else
            return _instance;
        }
      }

      public static Combinatorics_double Get { get { return Instance; } }

      /// <summary>Computes: [ N! ].</summary>
      public Combinatorics.delegates.Factorial<double> Factorial { get { return Combinatorics.Factorial; } }
      /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
      public Combinatorics.delegates.Combinations<double> Combinations { get { return Combinatorics.Combinations; } }
      /// <summary>Computes: [ N! / (N - n)! ]</summary>
      public Combinatorics.delegates.Choose<double> Choose { get { return Combinatorics.Choose; } }
    }

    private class Combinatorics_float : Combinatorics<float>
    {
      private Combinatorics_float() { _instance = this; }
      private static Combinatorics_float _instance;
      private static Combinatorics_float Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Combinatorics_float();
          else
            return _instance;
        }
      }

      public static Combinatorics_float Get { get { return Instance; } }

      /// <summary>Computes: [ N! ].</summary>
      public Combinatorics.delegates.Factorial<float> Factorial { get { return Combinatorics.Factorial; } }
      /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
      public Combinatorics.delegates.Combinations<float> Combinations { get { return Combinatorics.Combinations; } }
      /// <summary>Computes: [ N! / (N - n)! ]</summary>
      public Combinatorics.delegates.Choose<float> Choose { get { return Combinatorics.Choose; } }
    }

    private class Combinatorics_long : Combinatorics<long>
    {
      private Combinatorics_long() { _instance = this; }
      private static Combinatorics_long _instance;
      private static Combinatorics_long Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Combinatorics_long();
          else
            return _instance;
        }
      }

      public static Combinatorics_long Get { get { return Instance; } }

      /// <summary>Computes: [ N! ].</summary>
      public Combinatorics.delegates.Factorial<long> Factorial { get { return Combinatorics.Factorial; } }
      /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
      public Combinatorics.delegates.Combinations<long> Combinations { get { return Combinatorics.Combinations; } }
      /// <summary>Computes: [ N! / (N - n)! ]</summary>
      public Combinatorics.delegates.Choose<long> Choose { get { return Combinatorics.Choose; } }
    }

    private class Combinatorics_int : Combinatorics<int>
    {
      private Combinatorics_int() { _instance = this; }
      private static Combinatorics_int _instance;
      private static Combinatorics_int Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Combinatorics_int();
          else
            return _instance;
        }
      }

      public static Combinatorics_int Get { get { return Instance; } }

      /// <summary>Computes: [ N! ].</summary>
      public Combinatorics.delegates.Factorial<int> Factorial { get { return Combinatorics.Factorial; } }
      /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
      public Combinatorics.delegates.Combinations<int> Combinations { get { return Combinatorics.Combinations; } }
      /// <summary>Computes: [ N! / (N - n)! ]</summary>
      public Combinatorics.delegates.Choose<int> Choose { get { return Combinatorics.Choose; } }
    }

    private class Combinatorics_unsupported : Combinatorics<int>
    {
      private Combinatorics_unsupported() { _instance = this; }
      private static Combinatorics_unsupported _instance;
      private static Combinatorics_unsupported Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Combinatorics_unsupported();
          else
            return _instance;
        }
      }

      public static Combinatorics_unsupported Get { get { return Instance; } }

      /// <summary>Computes: [ N! ].</summary>
      public Combinatorics.delegates.Factorial<int> Factorial
      { get { return Combinatorics.Factorial; } }
      /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
      public Combinatorics.delegates.Combinations<int> Combinations
      { get { return Combinatorics.Combinations; } }
      /// <summary>Computes: [ N! / (N - n)! ]</summary>
      public Combinatorics.delegates.Choose<int> Choose
      { get { return Combinatorics.Choose; } }
    }

    #endregion

    #endregion

    #region Implementations

    #region decimal

    /// <summary>Computes: [ N! ].</summary>
    /// <param name="N">The number to compute the factorial of.</param>
    /// <returns>[ N! ]</returns>
    public static decimal Factorial(decimal N)
    {
      if (N % 1M != 0M)
        throw new Error("invalid factorial: N must be a whole number.");
      if (N < 0)
        throw new Error("invalid factorial: [ N < 0 ].");
      try
      {
        checked
        {
          decimal result = 1;
          for (; N > 1; N--)
            result *= N;
          return result;
        }
      }
      catch
      {
        throw new Error("overflow occured in factorial.");
      }
    }

    /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
    /// <param name="N">The total number of items in the set.</param>
    /// <param name="n">The number of items in the respective sub-sets.</param>
    /// <returns>[ N! / (n[0]! + n[1]! + n[3]! ...) ]</returns>
    public static decimal Combinations(decimal N, params decimal[] n)
    {
      if (N % 1M != 0M)
        throw new Error("invalid combination: N must be a whole number.");
      for (int i = 0; i < n.Length; i++)
        if (n[i] % 1M != 0M)
          throw new Error("invalid combination: n[" + i + "] must be a whole number.");
      decimal result = Combinatorics.Factorial(N);
      decimal sum = 0M;
      for (int i = 0; i < n.Length; i++)
      {
        result /= Combinatorics.Factorial(n[i]);
        sum += n[i];
      }
      if (sum > N)
        throw new Error("invalid combination: [ N < Sum(n) ].");
      return result;
    }

    /// <summary>Computes: [ N! / (N - n)! ]</summary>
    /// <param name="N">The total number of items.</param>
    /// <param name="n">The number of items to choose.</param>
    /// <returns>[ N! / (N - n)! ]</returns>
    public static decimal Choose(decimal N, decimal n)
    {
      if (N % 1M != 0M)
        throw new Error("invalid chose: N must be a whole number.");
      if (n % 1M != 0M)
        throw new Error("invalid combination: n must be a whole number.");
      if (!(N <= n || N >= 0M))
        throw new Error("invalid choose: [ !(N <= n || N >= 0) ].");
      return Combinatorics.Factorial(N) / (Combinatorics.Factorial(N) * Combinatorics.Factorial(n - N));
    }

    #endregion

    #region double

    /// <summary>Computes: [ N! ].</summary>
    /// <param name="N">The number to compute the factorial of.</param>
    /// <returns>[ N! ]</returns>
    public static double Factorial(double N)
    {
      if (N % 1d != 0d)
        throw new Error("invalid factorial: N must be a whole number.");
      if (N < 0)
        throw new Error("invalid factorial: [ N < 0 ].");
      try
      {
        checked
        {
          double result = 1;
          for (; N > 1; N--)
            result *= N;
          return result;
        }
      }
      catch
      {
        throw new Error("overflow occured in factorial.");
      }
    }

    /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
    /// <param name="N">The total number of items in the set.</param>
    /// <param name="n">The number of items in the respective sub-sets.</param>
    /// <returns>[ N! / (n[0]! + n[1]! + n[3]! ...) ]</returns>
    public static double Combinations(double N, params double[] n)
    {
      if (N % 1d != 0d)
        throw new Error("invalid combination: N must be a whole number.");
      for (int i = 0; i < n.Length; i++)
        if (n[i] % 1d != 0d)
          throw new Error("invalid combination: n[" + i + "] must be a whole number.");
      double result = Combinatorics.Factorial(N);
      double sum = 0d;
      for (int i = 0; i < n.Length; i++)
      {
        result /= Combinatorics.Factorial(n[i]);
        sum += n[i];
      }
      if (sum > N)
        throw new Error("invalid combination: [ N < Sum(n) ].");
      return result;
    }

    /// <summary>Computes: [ N! / (N - n)! ]</summary>
    /// <param name="N">The total number of items.</param>
    /// <param name="n">The number of items to choose.</param>
    /// <returns>[ N! / (N - n)! ]</returns>
    public static double Choose(double N, double n)
    {
      if (N % 1d != 0d)
        throw new Error("invalid chose: N must be a whole number.");
      if (n % 1d != 0d)
        throw new Error("invalid combination: n must be a whole number.");
      if (!(N <= n || N >= 0d))
        throw new Error("invalid choose: [ !(N <= n || N >= 0) ].");
      return Combinatorics.Factorial(N) / (Combinatorics.Factorial(N) * Combinatorics.Factorial(n - N));
    }

    #endregion

    #region float

    /// <summary>Computes: [ N! ].</summary>
    /// <param name="N">The number to compute the factorial of.</param>
    /// <returns>[ N! ]</returns>
    public static float Factorial(float N)
    {
      if (N % 1f != 0f)
        throw new Error("invalid factorial: N must be a whole number.");
      if (N < 0f)
        throw new Error("invalid factorial: [ N < 0 ].");
      try
      {
        checked
        {
          float result = 1;
          for (; N > 1; N--)
            result *= N;
          return result;
        }
      }
      catch
      {
        throw new Error("overflow occured in factorial.");
      }
    }

    /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
    /// <param name="N">The total number of items in the set.</param>
    /// <param name="n">The number of items in the respective sub-sets.</param>
    /// <returns>[ N! / (n[0]! + n[1]! + n[3]! ...) ]</returns>
    public static float Combinations(float N, params float[] n)
    {
      if (N % 1f != 0f)
        throw new Error("invalid combination: N must be a whole number.");
      for (int i = 0; i < n.Length; i++)
        if (n[i] % 1f != 0f)
          throw new Error("invalid combination: n[" + i + "] must be a whole number.");
      float result = Combinatorics.Factorial(N);
      float sum = 0f;
      for (int i = 0; i < n.Length; i++)
      {
        result /= Combinatorics.Factorial(n[i]);
        sum += n[i];
      }
      if (sum > N)
        throw new Error("invalid combination: [ N < Sum(n) ].");
      return result;
    }

    /// <summary>Computes: [ N! / (N - n)! ]</summary>
    /// <param name="N">The total number of items.</param>
    /// <param name="n">The number of items to choose.</param>
    /// <returns>[ N! / (N - n)! ]</returns>
    public static float Choose(float N, float n)
    {
      if (N % 1f != 0f)
        throw new Error("invalid chose: N must be a whole number.");
      if (n % 1f != 0f)
        throw new Error("invalid combination: n must be a whole number.");
      if (!(N <= n || N >= 0))
        throw new Error("invalid choose: [ !(N <= n || N >= 0) ].");
      return Combinatorics.Factorial(N) / (Combinatorics.Factorial(N) * Combinatorics.Factorial(n - N));
    }

    #endregion

    #region long

    /// <summary>Computes: [ N! ].</summary>
    /// <param name="N">The number to compute the factorial of.</param>
    /// <returns>[ N! ]</returns>
    public static long Factorial(long N)
    {
      if (N < 0)
        throw new Error("invalid factorial: [ N < 0 ].");
      try
      {
        checked
        {
          long result = 1;
          for (; N > 1; N--)
            result *= N;
          return result;
        }
      }
      catch
      {
        throw new Error("overflow occured in factorial.");
      }
    }

    /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
    /// <param name="N">The total number of items in the set.</param>
    /// <param name="n">The number of items in the respective sub-sets.</param>
    /// <returns>[ N! / (n[0]! + n[1]! + n[3]! ...) ]</returns>
    public static long Combinations(long N, params long[] n)
    {
      long result = Combinatorics.Factorial(N);
      long sum = 0;
      for (int i = 0; i < n.Length; i++)
      {
        result /= Combinatorics.Factorial(n[i]);
        sum += n[i];
      }
      if (sum > N)
        throw new Error("invalid combination: [ N < Sum(n) ].");
      return result;
    }

    /// <summary>Computes: [ N! / (N - n)! ]</summary>
    /// <param name="N">The total number of items.</param>
    /// <param name="n">The number of items to choose.</param>
    /// <returns>[ N! / (N - n)! ]</returns>
    public static long Choose(long N, long n)
    {
      if (!(N <= n || N >= 0))
        throw new Error("invalid choose: [ !(N <= n || N >= 0) ].");
      return Combinatorics.Factorial(N) / (Combinatorics.Factorial(N) * Combinatorics.Factorial(n - N));
    }

    #endregion

    #region int

    /// <summary>Computes: [ N! ].</summary>
    /// <param name="N">The number to compute the factorial of.</param>
    /// <returns>[ N! ]</returns>
    public static int Factorial(int N)
    {
      try
      {
        checked
        {
          int result = 1;
          for (; N > 1; N--)
            result *= N;
          return result;
        }
      }
      catch { throw new Error("overflow occured in factorial."); }
    }

    /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
    /// <param name="N">The total number of items in the set.</param>
    /// <param name="n">The number of items in the respective sub-sets.</param>
    /// <returns>[ N! / (n[0]! + n[1]! + n[3]! ...) ]</returns>
    public static int Combinations(int N, params int[] n)
    {
      int result = Combinatorics.Factorial(N);
      int sum = 0;
      for (int i = 0; i < n.Length; i++)
      {
        result /= Combinatorics.Factorial(n[i]);
        sum += n[i];
      }
      if (sum > N)
        throw new Error("invalid combination (set < Count(subsets)).");
      return result;
    }

    /// <summary>Computes: [ N! / (N - n)! ]</summary>
    /// <param name="N">The total number of items.</param>
    /// <param name="n">The number of items to choose.</param>
    /// <returns>[ N! / (N - n)! ]</returns>
    public static int Choose(int N, int n)
    {
      if (!(N <= n || N >= 0))
        throw new Error("invalid choose values !(top <= bottom || top >= 0)");
      return Combinatorics.Factorial(N) / (Combinatorics.Factorial(N) * Combinatorics.Factorial(n - N));
    }

    #endregion

    #endregion
  }
}
