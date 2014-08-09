// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics
{
  /// <summary>Supplies logic mathematics for generic types.</summary>
  /// <typeparam name="T">The type this logic library can perform on.</typeparam>
  public interface Logic<T>
  {
    #region property

    /// <summary>Computes the absolute value of a value.</summary>
    Logic.delegates.abs<T> abs { get; }
    /// <summary>Finds the max value in a set.</summary>
    Logic.delegates.max_params<T>  max_params { get; }
    /// <summary>Computes the max value between two operands.</summary>
    Logic.delegates.max<T> max { get; }
    /// <summary>Finds the min value in a set.</summary>
    Logic.delegates.min_params<T> min_params { get; }
    /// <summary>Computes the min value between two operands.</summary>
    Logic.delegates.min<T> min { get; }
    /// <summary>Restricts a value to a min-max range.</summary>
    Logic.delegates.clamp<T> clamp { get; }
    /// <summary>Checks for equality by value with a leniency.</summary>
    Logic.delegates.equ_len<T> equ_len { get; }
    Equate<T> equ { get; }
    Equate_params<T> equ_params { get; }
    Compare<T> comp { get; }

    #endregion
  }

  /// <summary>Makes and stores implementations of logic.</summary>
  public static class Logic
  {
    #region delegate

    /// <summary>Contaisn the delegates for logic mathematical operations.</summary>
    public static class delegates
    {
      /// <summary>Computes the absolute value of a value.</summary>
      /// <typeparam name="T">The numeric type of this operation.</typeparam>
      /// <param name="n">The value to be absolut-ed.</param>
      /// <returns>The result of the absolute value operation.</returns>
      public delegate T abs<T>(T n);
      /// <summary>Finds the max value in a set.</summary>
      /// <typeparam name="T">The numeric type of the min operation.</typeparam>
      /// <param name="values">The set to find the max value within.</param>
      /// <returns>The max value in the set.</returns>
      public delegate T max_params<T>(params T[] values);
      /// <summary>Computes the max value between two operands.</summary>
      /// <typeparam name="T">The numeric type of this operation.</typeparam>
      /// <param name="a">The first operand of the max operation.</param>
      /// <param name="b">The second operand of the max operation.</param>
      /// <returns>The max value between a and b.</returns>
      public delegate T max<T>(T a, T b);
      /// <summary>Finds the min value in a set.</summary>
      /// <typeparam name="T">The numeric type of the min operation.</typeparam>
      /// <param name="values">The set to find the min value within.</param>
      /// <returns>The min value in the set.</returns>
      public delegate T min_params<T>(params T[] values);
      /// <summary>Computes the min value between two operands.</summary>
      /// <typeparam name="T">The numeric type of this operation.</typeparam>
      /// <param name="a">The first operand of the min operation.</param>
      /// <param name="b">The second operand of the min operation.</param>
      /// <returns>The min value between a and b.</returns>
      public delegate T min<T>(T a, T b);
      /// <summary>Restricts a value to a min-max range.</summary>
      /// <typeparam name="T">The numeric type of the min operation.</typeparam>
      /// <param name="value">The value to be clamped.</param>
      /// <param name="minimum">The minimum value allowed.</param>
      /// <param name="maximum">The maximum value allowed.</param>
      /// <returns>The possibly clamped value.</returns>
      public delegate T clamp<T>(T value, T minimum, T maximum);
      /// <summary>Checks for equality by value with a leniency.</summary>
      /// <typeparam name="T">The numeric type of the min operation.</typeparam>
      /// <param name="left">The left operand of the equate operation.</param>
      /// <param name="right">The right operand of the equate operation.</param>
      /// <param name="leniency">The leniency of the equate operation.</param>
      /// <returns>True if the operand are within the leniency of each other.</returns>
      public delegate bool equ_len<T>(T left, T right, T leniency);

    }

    #endregion

    #region library

    private static Seven.Structures.Map<object, System.Type> _logics =
			new Seven.Structures.Map_Linked<object, System.Type>(
				(System.Type left, System.Type right) => { return left == right; },
				(System.Type type) => { return type.GetHashCode(); })
				{
					{ typeof(int), Logic_int.Get },
					{ typeof(double), Logic_double.Get },
					{ typeof(float), Logic_float.Get },
					{ typeof(decimal), Logic_decimal.Get },
					{ typeof(long), Logic_long.Get },
					{ typeof(short), Logic_short.Get },
					{ typeof(byte), Logic_byte.Get },
          { typeof(string), Logic_string.Get }
				};

    /// <summary>Checks to see if a logic implementaton exists for the given type.</summary>
    /// <typeparam name="T">The type to check for a logic implementation.</typeparam>
    /// <returns>True is an implementation exists; false if not.</returns>
    public static bool Check<T>()
    {
      return _logics.Contains(typeof(T));
    }

    /// <summary>Adds an implementation of logic for a given type.</summary>
    /// <typeparam name="T">The type the logic library operates on.</typeparam>
    /// <param name="linearAlgebra">The logic library.</param>
    public static void Set<T>(Logic<T> linearAlgebra)
    {
      _logics[typeof(T)] = linearAlgebra;
    }

    /// <summary>Gets a logic library for the given type.</summary>
    /// <typeparam name="T">The type to get a logic library for.</typeparam>
    /// <returns>A linear logic for the given type.</returns>
    public static Logic<T> Get<T>()
    {
      if (_logics.Contains(typeof(T)))
        return (Logic<T>)_logics[typeof(T)];
      else
        return new Logic_unsupported<T>();
    }

    #region provided

    private class Logic_string : Logic<string>
    {
      private Logic_string() { _instance = this; }
      private static Logic_string _instance;
      private static Logic_string Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Logic_string();
          else
            return _instance;
        }
      }

      public static Logic_string Get { get { return Instance; } }

      public Logic.delegates.abs<string> abs { get { return Logic.Abs; } }
      public Logic.delegates.max_params<string> max_params { get { return Logic.Max; } }
      public Logic.delegates.max<string> max { get { return Logic.Max; } }
      public Logic.delegates.min_params<string> min_params { get { return Logic.Min; } }
      public Logic.delegates.min<string> min { get { return Logic.Min; } }
      public Logic.delegates.clamp<string> clamp { get { return Logic.Clamp; } }
      public Logic.delegates.equ_len<string> equ_len { get { return Logic.Equate; } }
      public Equate<string> equ { get { return Logic.Equate; } }
      public Equate_params<string> equ_params { get { return Logic.Equate; } }
      public Compare<string> comp { get { return Logic.Compare; } }
    }

    private class Logic_decimal : Logic<decimal>
    {
      private Logic_decimal() { _instance = this; }
      private static Logic_decimal _instance;
      private static Logic_decimal Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Logic_decimal();
          else
            return _instance;
        }
      }

      public static Logic_decimal Get { get { return Instance; } }

      public Logic.delegates.abs<decimal> abs { get { return Logic.Abs; } }
      public Logic.delegates.max_params<decimal> max_params { get { return Logic.Max; } }
      public Logic.delegates.max<decimal> max { get { return Logic.Max; } }
      public Logic.delegates.min_params<decimal> min_params { get { return Logic.Min; } }
      public Logic.delegates.min<decimal> min { get { return Logic.Min; } }
      public Logic.delegates.clamp<decimal> clamp { get { return Logic.Clamp; } }
      public Logic.delegates.equ_len<decimal> equ_len { get { return Logic.Equate; } }
      public Equate<decimal> equ { get { return Logic.Equate; } }
      public Equate_params<decimal> equ_params { get { return Logic.Equate; } }
      public Compare<decimal> comp { get { return Logic.Compare; } }
    }

    private class Logic_double : Logic<double>
    {
      private Logic_double() { _instance = this; }
      private static Logic_double _instance;
      private static Logic_double Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Logic_double();
          else
            return _instance;
        }
      }

      public static Logic_double Get { get { return Instance; } }

      public Logic.delegates.abs<double> abs { get { return Logic.Abs; } }
      public Logic.delegates.max_params<double> max_params { get { return Logic.Max; } }
      public Logic.delegates.max<double> max { get { return Logic.Max; } }
      public Logic.delegates.min_params<double> min_params { get { return Logic.Min; } }
      public Logic.delegates.min<double> min { get { return Logic.Min; } }
      public Logic.delegates.clamp<double> clamp { get { return Logic.Clamp; } }
      public Logic.delegates.equ_len<double> equ_len { get { return Logic.Equate; } }
      public Equate<double> equ { get { return Logic.Equate; } }
      public Equate_params<double> equ_params { get { return Logic.Equate; } }
      public Compare<double> comp { get { return Logic.Compare; } }
    }

    private class Logic_float : Logic<float>
    {
      private Logic_float() { _instance = this; }
      private static Logic_float _instance;
      private static Logic_float Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Logic_float();
          else
            return _instance;
        }
      }

      public static Logic_float Get { get { return Instance; } }

      public Logic.delegates.abs<float> abs { get { return Logic.Abs; } }
      public Logic.delegates.max_params<float> max_params { get { return Logic.Max; } }
      public Logic.delegates.max<float> max { get { return Logic.Max; } }
      public Logic.delegates.min_params<float> min_params { get { return Logic.Min; } }
      public Logic.delegates.min<float> min { get { return Logic.Min; } }
      public Logic.delegates.clamp<float> clamp { get { return Logic.Clamp; } }
      public Logic.delegates.equ_len<float> equ_len { get { return Logic.Equate; } }
      public Equate<float> equ { get { return Logic.Equate; } }
      public Equate_params<float> equ_params { get { return Logic.Equate; } }
      public Compare<float> comp { get { return Logic.Compare; } }
    }

    private class Logic_long : Logic<long>
    {
      private Logic_long() { _instance = this; }
      private static Logic_long _instance;
      private static Logic_long Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Logic_long();
          else
            return _instance;
        }
      }

      public static Logic_long Get { get { return Instance; } }

      public Logic.delegates.abs<long> abs { get { return Logic.Abs; } }
      public Logic.delegates.max_params<long> max_params { get { return Logic.Max; } }
      public Logic.delegates.max<long> max { get { return Logic.Max; } }
      public Logic.delegates.min_params<long> min_params { get { return Logic.Min; } }
      public Logic.delegates.min<long> min { get { return Logic.Min; } }
      public Logic.delegates.clamp<long> clamp { get { return Logic.Clamp; } }
      public Logic.delegates.equ_len<long> equ_len { get { return Logic.Equate; } }
      public Equate<long> equ { get { return Logic.Equate; } }
      public Equate_params<long> equ_params { get { return Logic.Equate; } }
      public Compare<long> comp { get { return Logic.Compare; } }
    }

    private class Logic_int : Logic<int>
    {
      private Logic_int() { _instance = this; }
      private static Logic_int _instance;
      private static Logic_int Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Logic_int();
          else
            return _instance;
        }
      }

      public static Logic_int Get { get { return Instance; } }

      public Logic.delegates.abs<int> abs { get { return Logic.Abs; } }
      public Logic.delegates.max_params<int> max_params { get { return Logic.Max; } }
      public Logic.delegates.max<int> max { get { return Logic.Max; } }
      public Logic.delegates.min_params<int> min_params { get { return Logic.Min; } }
      public Logic.delegates.min<int> min { get { return Logic.Min; } }
      public Logic.delegates.clamp<int> clamp { get { return Logic.Clamp; } }
      public Logic.delegates.equ_len<int> equ_len { get { return Logic.Equate; } }
      public Equate<int> equ { get { return Logic.Equate; } }
      public Equate_params<int> equ_params { get { return Logic.Equate; } }
      public Compare<int> comp { get { return Logic.Compare; } }
    }

    private class Logic_short : Logic<short>
    {
      private Logic_short() { _instance = this; }
      private static Logic_short _instance;
      private static Logic_short Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Logic_short();
          else
            return _instance;
        }
      }

      public static Logic_short Get { get { return Instance; } }

      public Logic.delegates.abs<short> abs { get { return Logic.Abs; } }
      public Logic.delegates.max_params<short> max_params { get { return Logic.Max; } }
      public Logic.delegates.max<short> max { get { return Logic.Max; } }
      public Logic.delegates.min_params<short> min_params { get { return Logic.Min; } }
      public Logic.delegates.min<short> min { get { return Logic.Min; } }
      public Logic.delegates.clamp<short> clamp { get { return Logic.Clamp; } }
      public Logic.delegates.equ_len<short> equ_len { get { return Logic.Equate; } }
      public Equate<short> equ { get { return Logic.Equate; } }
      public Equate_params<short> equ_params { get { return Logic.Equate; } }
      public Compare<short> comp { get { return Logic.Compare; } }
    }

    private class Logic_byte : Logic<byte>
    {
      private Logic_byte() { _instance = this; }
      private static Logic_byte _instance;
      private static Logic_byte Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Logic_byte();
          else
            return _instance;
        }
      }

      public static Logic_byte Get { get { return Instance; } }

      public Logic.delegates.abs<byte> abs { get { return Logic.Abs; } }
      public Logic.delegates.max_params<byte> max_params { get { return Logic.Max; } }
      public Logic.delegates.max<byte> max { get { return Logic.Max; } }
      public Logic.delegates.min_params<byte> min_params { get { return Logic.Min; } }
      public Logic.delegates.min<byte> min { get { return Logic.Min; } }
      public Logic.delegates.clamp<byte> clamp { get { return Logic.Clamp; } }
      public Logic.delegates.equ_len<byte> equ_len { get { return Logic.Equate; } }
      public Equate<byte> equ { get { return Logic.Equate; } }
      public Equate_params<byte> equ_params { get { return Logic.Equate; } }
      public Compare<byte> comp { get { return Logic.Compare; } }
    }

    public class Logic_unsupported<T> : Logic<T>
    {
      public Logic_unsupported() {  }

      public Logic.delegates.abs<T> abs { get { return (T value) => { throw new Error("Logic is undefined for type: " + typeof(T)); }; } }
      public Logic.delegates.max_params<T> max_params { get { return (T[] value) => { throw new Error("Logic is undefined for type: " + typeof(T)); }; } }
      public Logic.delegates.max<T> max { get { return (T a, T b) => { throw new Error("Logic is undefined for type: " + typeof(T)); }; } }
      public Logic.delegates.min_params<T> min_params { get { return (T[] value) => { throw new Error("Logic is undefined for type: " + typeof(T)); }; } }
      public Logic.delegates.min<T> min { get { return (T a, T b) => { throw new Error("Logic is undefined for type: " + typeof(T)); }; } }
      public Logic.delegates.clamp<T> clamp { get { return (T a, T b, T c) => { throw new Error("Logic is undefined for type: " + typeof(T)); }; } }
      public Logic.delegates.equ_len<T> equ_len { get { return (T a, T b, T c) => { throw new Error("Logic is undefined for type: " + typeof(T)); }; } }
      public Equate<T> equ { get { return (T a, T b) => { throw new Error("Logic is undefined for type: " + typeof(T)); }; } }
      public Equate_params<T> equ_params { get { return (T[] a) => { throw new Error("Logic is undefined for type: " + typeof(T)); }; } }
      public Compare<T> comp { get { return (T a, T b) => { throw new Error("Logic is undefined for type: " + typeof(T)); }; } }
    }

    #endregion

    #endregion

    #region Implementations

    #region string

    /// <summary>Returns a less/greater/equal comparison.</summary>
    public static Comparison Compare(string left, string right)
    {
      int result = left.CompareTo(right);
      if (result > 0)
        return Comparison.Greater;
      else if (result < 0)
        return Comparison.Less;
      else
        return Comparison.Equal;
    }

    /// <summary>Returns true if all values are equal.</summary>
    public static bool Equate(params string[] values)
    {
      for (int i = 0; i < values.Length - 1; i++)
        if (values[i] != values[i + 1])
          return false;
      return true;
    }

    /// <summary>Returns left == right.</summary>
    public static bool Equate(string left, string right)
    {
      return left.CompareTo(right) == 0;
    }

    /// <summary>Returns Abs(left - right) < leniency.</summary>
    public static bool Equate(string left, string right, string leniency)
    {
      throw new Error("not yet implemented");
    }

    /// <summary>Returns the maximum value.</summary>
    public static string Max(params string[] values)
    {
      string max = values[0];
      for (int i = 0; i < values.Length; i++)
        if (values[i].CompareTo(max) > 0)
          max = values[i];
      return max;
    }

    /// <summary>Returns the maximum value.</summary>
    public static string Max(string first, string second)
    {
      if (second.CompareTo(first) > 0)
        return second;
      return first;
    }

    /// <summary>Returns the minimum value.</summary>
    public static string Min(params string[] values)
    {
      string max = values[0];
      for (int i = 0; i < values.Length; i++)
        if (values[i].CompareTo(max) < 0)
          max = values[i];
      return max;
    }

    /// <summary>Returns the minimum value.</summary>
    public static string Min(string first, string second)
    {
      if (second.CompareTo(first) < 0)
        return second;
      return first;
    }

    /// <summary>Returns the absolute value of the provided value.</summary>
    public static string Abs(string number)
    {
      throw new Error("Abs is undefined for type string");
    }

    /// <summary>Returns left < right.</summary>
    public static bool LessThan(string left, string right)
    {
      return left.CompareTo(right) < 0;
    }

    /// <summary>Returns left > right.</summary>
    public static bool GreaterThan(string left, string right)
    {
      return left.CompareTo(right) > 0;
    }

    /// <summary>Clamps a value to be within a given minimum and maximum range.</summary>
    public static string Clamp(string value, string minimum, string maximum)
    {
      if (value.CompareTo(minimum) < 0)
        return minimum;
      if (value.CompareTo(maximum) > 0)
        return maximum;
      return value;
    }

    #endregion

    #region Fraction128

    /// <summary>Returns a less/greater/equal comparison.</summary>
    public static Comparison Compare(Fraction128 left, Fraction128 right)
    {
      int result = left.CompareTo(right);
      if (result > 0)
        return Comparison.Greater;
      else if (result < 0)
        return Comparison.Less;
      else
        return Comparison.Equal;
    }

    /// <summary>Returns true if all values are equal.</summary>
    public static bool Equate(params Fraction128[] values)
    {
      for (int i = 0; i < values.Length - 1; i++)
        if (values[i] != values[i + 1])
          return false;
      return true;
    }

    /// <summary>Returns left == right.</summary>
    public static bool Equate(Fraction128 left, Fraction128 right)
    {
      return left == right;
    }

    /// <summary>Returns Abs(left - right) < leniency.</summary>
    public static bool Equate(Fraction128 left, Fraction128 right, Fraction128 leniency)
    {
      return Abs(left - right) < leniency;
    }

    /// <summary>Returns the maximum value.</summary>
    public static Fraction128 Max(params Fraction128[] values)
    {
      Fraction128 max = values[0];
      for (int i = 0; i < values.Length; i++)
        if (values[i] > max)
          max = values[i];
      return max;
    }

    /// <summary>Returns the maximum value.</summary>
    public static Fraction128 Max(Fraction128 first, Fraction128 second)
    {
      if (second > first)
        return second;
      return first;
    }

    /// <summary>Returns the minimum value.</summary>
    public static Fraction128 Min(params Fraction128[] values)
    {
      Fraction128 max = values[0];
      for (int i = 0; i < values.Length; i++)
        if (values[i] < max)
          max = values[i];
      return max;
    }

    /// <summary>Returns the minimum value.</summary>
    public static Fraction128 Min(Fraction128 first, Fraction128 second)
    {
      if (second < first)
        return second;
      return first;
    }

    /// <summary>Returns the absolute value of the provided value.</summary>
    public static Fraction128 Abs(Fraction128 number)
    {
      if (number < 0)
        return -number;
      return number;
    }

    /// <summary>Returns left < right.</summary>
    public static bool LessThan(Fraction128 left, Fraction128 right)
    {
      return left < right;
    }

    /// <summary>Returns left > right.</summary>
    public static bool GreaterThan(Fraction128 left, Fraction128 right)
    {
      return left > right;
    }

    /// <summary>Clamps a value to be within a given minimum and maximum range.</summary>
    public static Fraction128 Clamp(Fraction128 value, Fraction128 minimum, Fraction128 maximum)
    {
      if (value < minimum)
        return minimum;
      if (value > maximum)
        return maximum;
      return value;
    }

    #endregion

    #region Fraction64

    /// <summary>Returns a less/greater/equal comparison.</summary>
    public static Comparison Compare(Fraction64 left, Fraction64 right)
    {
      int result = left.CompareTo(right);
      if (result > 0)
        return Comparison.Greater;
      else if (result < 0)
        return Comparison.Less;
      else
        return Comparison.Equal;
    }

    /// <summary>Returns true if all values are equal.</summary>
    public static bool Equate(params Fraction64[] values)
    {
      for (int i = 0; i < values.Length - 1; i++)
        if (values[i] != values[i + 1])
          return false;
      return true;
    }

    /// <summary>Returns left == right.</summary>
    public static bool Equate(Fraction64 left, Fraction64 right)
    {
      return left == right;
    }

    /// <summary>Returns Abs(left - right) < leniency.</summary>
    public static bool Equate(Fraction64 left, Fraction64 right, Fraction64 leniency)
    {
      return Abs(left - right) < leniency;
    }

    /// <summary>Returns the maximum value.</summary>
    public static Fraction64 Max(params Fraction64[] values)
    {
      Fraction64 max = values[0];
      for (int i = 0; i < values.Length; i++)
        if (values[i] > max)
          max = values[i];
      return max;
    }

    /// <summary>Returns the maximum value.</summary>
    public static Fraction64 Max(Fraction64 first, Fraction64 second)
    {
      if (second > first)
        return second;
      return first;
    }

    /// <summary>Returns the minimum value.</summary>
    public static Fraction64 Min(params Fraction64[] values)
    {
      Fraction64 max = values[0];
      for (int i = 0; i < values.Length; i++)
        if (values[i] < max)
          max = values[i];
      return max;
    }

    /// <summary>Returns the minimum value.</summary>
    public static Fraction64 Min(Fraction64 first, Fraction64 second)
    {
      if (second < first)
        return second;
      return first;
    }

    /// <summary>Returns the absolute value of the provided value.</summary>
    public static Fraction64 Abs(Fraction64 number)
    {
      if (number < 0)
        return -number;
      return number;
    }

    /// <summary>Returns left < right.</summary>
    public static bool LessThan(Fraction64 left, Fraction64 right)
    {
      return left < right;
    }

    /// <summary>Returns left > right.</summary>
    public static bool GreaterThan(Fraction64 left, Fraction64 right)
    {
      return left > right;
    }

    /// <summary>Clamps a value to be within a given minimum and maximum range.</summary>
    public static Fraction64 Clamp(Fraction64 value, Fraction64 minimum, Fraction64 maximum)
    {
      if (value < minimum)
        return minimum;
      if (value > maximum)
        return maximum;
      return value;
    }

    #endregion

		#region decimal

		/// <summary>Returns a less/greater/equal comparison.</summary>
		public static Comparison Compare(decimal left, decimal right)
		{
			int result = left.CompareTo(right);
			if (result > 0)
				return Comparison.Greater;
			else if (result < 0)
				return Comparison.Less;
			else
				return Comparison.Equal;
		}

		/// <summary>Returns true if all values are equal.</summary>
		public static bool Equate(params decimal[] values)
		{
			for (int i = 0; i < values.Length - 1; i++)
				if (values[i] != values[i + 1])
					return false;
			return true;
		}

		/// <summary>Returns left == right.</summary>
		public static bool Equate(decimal left, decimal right)
		{
			return left == right;
		}

		/// <summary>Returns Abs(left - right) < leniency.</summary>
		public static bool Equate(decimal left, decimal right, decimal leniency)
		{
			return Abs(left - right) < leniency;
		}

		/// <summary>Returns the maximum value.</summary>
		public static decimal Max(params decimal[] values)
		{
			decimal max = values[0];
			for (int i = 0; i < values.Length; i++)
				if (values[i] > max)
					max = values[i];
			return max;
		}

		/// <summary>Returns the maximum value.</summary>
		public static decimal Max(decimal first, decimal second)
		{
			if (second > first)
				return second;
			return first;
		}

		/// <summary>Returns the minimum value.</summary>
		public static decimal Min(params decimal[] values)
		{
			decimal max = values[0];
			for (int i = 0; i < values.Length; i++)
				if (values[i] < max)
					max = values[i];
			return max;
		}

		/// <summary>Returns the minimum value.</summary>
		public static decimal Min(decimal first, decimal second)
		{
			if (second < first)
				return second;
			return first;
		}

		/// <summary>Returns the absolute value of the provided value.</summary>
		public static decimal Abs(decimal number)
		{
			if (number < 0)
				return -number;
			return number;
		}

		/// <summary>Returns left < right.</summary>
		public static bool LessThan(decimal left, decimal right)
		{
			return left < right;
		}

		/// <summary>Returns left > right.</summary>
		public static bool GreaterThan(decimal left, decimal right)
		{
			return left > right;
		}

		/// <summary>Clamps a value to be within a given minimum and maximum range.</summary>
		public static decimal Clamp(decimal value, decimal minimum, decimal maximum)
		{
			if (value < minimum)
				return minimum;
			if (value > maximum)
				return maximum;
			return value;
		}

		#endregion

		#region double

		/// <summary>Returns a less/greater/equal comparison.</summary>
		public static Comparison Compare(double left, double right)
		{
			int result = left.CompareTo(right);
			if (result > 0)
				return Comparison.Greater;
			else if (result < 0)
				return Comparison.Less;
			else
				return Comparison.Equal;
		}

		/// <summary>Returns true if all values are equal.</summary>
		public static bool Equate(params double[] values)
		{
			for (int i = 0; i < values.Length - 1; i++)
				if (values[i] != values[i + 1])
					return false;
			return true;
		}

		/// <summary>Returns left == right.</summary>
		public static bool Equate(double left, double right)
		{
			return left == right;
		}

		/// <summary>Returns Abs(left - right) < leniency.</summary>
		public static bool Equate(double left, double right, double leniency)
		{
			return Abs(left - right) < leniency;
		}

		/// <summary>Returns the maximum value.</summary>
		public static double Max(params double[] values)
		{
			double max = values[0];
			for (int i = 0; i < values.Length; i++)
				if (values[i] > max)
					max = values[i];
			return max;
		}

		/// <summary>Returns the maximum value.</summary>
		public static double Max(double first, double second)
		{
			if (second > first)
				return second;
			return first;
		}

		/// <summary>Returns the minimum value.</summary>
		public static double Min(params double[] values)
		{
			double max = values[0];
			for (int i = 0; i < values.Length; i++)
				if (values[i] < max)
					max = values[i];
			return max;
		}

		/// <summary>Returns the minimum value.</summary>
		public static double Min(double first, double second)
		{
			if (second < first)
				return second;
			return first;
		}

		/// <summary>Returns the absolute value of the provided value.</summary>
		public static double Abs(double number)
		{
			if (number < 0)
				return -number;
			return number;
		}

		/// <summary>Returns left < right.</summary>
		public static bool LessThan(double left, double right)
		{
			return left < right;
		}

		/// <summary>Returns left > right.</summary>
		public static bool GreaterThan(double left, double right)
		{
			return left > right;
		}

		/// <summary>Clamps a value to be within a given minimum and maximum range.</summary>
		public static double Clamp(double value, double minimum, double maximum)
		{
			if (value < minimum)
				return minimum;
			if (value > maximum)
				return maximum;
			return value;
		}

		#endregion

		#region float

		/// <summary>Returns a less/greater/equal comparison.</summary>
		public static Comparison Compare(float left, float right)
		{
			int result = left.CompareTo(right);
			if (result > 0)
				return Comparison.Greater;
			else if (result < 0)
				return Comparison.Less;
			else
				return Comparison.Equal;
		}

		/// <summary>Returns true if all values are equal.</summary>
		public static bool Equate(params float[] values)
		{
			for (int i = 0; i < values.Length - 1; i++)
				if (values[i] != values[i + 1])
					return false;
			return true;
		}

		/// <summary>Returns left == right.</summary>
		public static bool Equate(float left, float right)
		{
			return left == right;
		}

		/// <summary>Returns Abs(left - right) < leniency.</summary>
		public static bool Equate(float left, float right, float leniency)
		{
			return Abs(left - right) < leniency;
		}

		/// <summary>Returns the maximum value.</summary>
		public static float Max(params float[] values)
		{
			float max = values[0];
			for (int i = 0; i < values.Length; i++)
				if (values[i] > max)
					max = values[i];
			return max;
		}

		/// <summary>Returns the maximum value.</summary>
		public static float Max(float first, float second)
		{
			if (second > first)
				return second;
			return first;
		}

		/// <summary>Returns the minimum value.</summary>
		public static float Min(params float[] values)
		{
			float max = values[0];
			for (int i = 0; i < values.Length; i++)
				if (values[i] < max)
					max = values[i];
			return max;
		}

		/// <summary>Returns the minimum value.</summary>
		public static float Min(float first, float second)
		{
			if (second < first)
				return second;
			return first;
		}

		/// <summary>Returns the absolute value of the provided value.</summary>
		public static float Abs(float number)
		{
			if (number < 0)
				return -number;
			return number;
		}

		/// <summary>Returns left < right.</summary>
		public static bool LessThan(float left, float right)
		{
			return left < right;
		}

		/// <summary>Returns left > right.</summary>
		public static bool GreaterThan(float left, float right)
		{
			return left > right;
		}

		/// <summary>Clamps a value to be within a given minimum and maximum range.</summary>
		public static float Clamp(float value, float minimum, float maximum)
		{
			if (value < minimum)
				return minimum;
			if (value > maximum)
				return maximum;
			return value;
		}

		#endregion

		#region long

		/// <summary>Returns a less/greater/equal comparison.</summary>
		public static Comparison Compare(long left, long right)
		{
			long result = left.CompareTo(right);
			if (result > 0)
				return Comparison.Greater;
			else if (result < 0)
				return Comparison.Less;
			else
				return Comparison.Equal;
		}

		/// <summary>Returns true if all values are equal.</summary>
		public static bool Equate(params long[] values)
		{
			for (long i = 0; i < values.Length - 1; i++)
				if (values[i] != values[i + 1])
					return false;
			return true;
		}

		/// <summary>Returns left == right.</summary>
		public static bool Equate(long left, long right)
		{
			return left == right;
		}

		/// <summary>Returns Abs(left - right) < leniency.</summary>
		public static bool Equate(long left, long right, long leniency)
		{
			return Abs(left - right) < leniency;
		}

		/// <summary>Returns the maximum value.</summary>
		public static long Max(params long[] values)
		{
			long max = values[0];
			for (long i = 0; i < values.Length; i++)
				if (values[i] > max)
					max = values[i];
			return max;
		}

		/// <summary>Returns the maximum value.</summary>
		public static long Max(long first, long second)
		{
			if (second > first)
				return second;
			return first;
		}

		/// <summary>Returns the minimum value.</summary>
		public static long Min(params long[] values)
		{
			long max = values[0];
			for (long i = 0; i < values.Length; i++)
				if (values[i] < max)
					max = values[i];
			return max;
		}

		/// <summary>Returns the minimum value.</summary>
		public static long Min(long first, long second)
		{
			if (second < first)
				return second;
			return first;
		}

		/// <summary>Returns the absolute value of the provided value.</summary>
		public static long Abs(long number)
		{
			if (number < 0)
				return -number;
			return number;
		}

		/// <summary>Returns left < right.</summary>
		public static bool LessThan(long left, long right)
		{
			return left < right;
		}

		/// <summary>Returns left > right.</summary>
		public static bool GreaterThan(long left, long right)
		{
			return left > right;
		}

		/// <summary>Clamps a value to be within a given minimum and maximum range.</summary>
		public static long Clamp(long value, long minimum, long maximum)
		{
			if (value < minimum)
				return minimum;
			if (value > maximum)
				return maximum;
			return value;
		}

		#endregion

		#region int

		/// <summary>Returns a less/greater/equal comparison.</summary>
		public static Comparison Compare(int left, int right)
		{
			int result = left.CompareTo(right);
			if (result > 0)
				return Comparison.Greater;
			else if (result < 0)
				return Comparison.Less;
			else
				return Comparison.Equal;
		}

		/// <summary>Returns true if all values are equal.</summary>
		public static bool Equate(params int[] values)
		{
			for (int i = 0; i < values.Length - 1; i++)
				if (values[i] != values[i + 1])
					return false;
			return true;
		}

		/// <summary>Returns left == right.</summary>
		public static bool Equate(int left, int right)
		{
			return left == right;
		}

		/// <summary>Returns Abs(left - right) < leniency.</summary>
		public static bool Equate(int left, int right, int leniency)
		{
			return Abs(left - right) < leniency;
		}

		/// <summary>Returns the maximum value.</summary>
		public static int Max(params int[] values)
		{
			int max = values[0];
			for (int i = 0; i < values.Length; i++)
				if (values[i] > max)
					max = values[i];
			return max;
		}

		/// <summary>Returns the maximum value.</summary>
		public static int Max(int first, int second)
		{
			if (second > first)
				return second;
			return first;
		}

		/// <summary>Returns the minimum value.</summary>
		public static int Min(params int[] values)
		{
			int max = values[0];
			for (int i = 0; i < values.Length; i++)
				if (values[i] < max)
					max = values[i];
			return max;
		}

		/// <summary>Returns the minimum value.</summary>
		public static int Min(int first, int second)
		{
			if (second < first)
				return second;
			return first;
		}

		/// <summary>Returns the absolute value of the provided value.</summary>
		public static int Abs(int number)
		{
			if (number < 0)
				return -number;
			return number;
		}

		/// <summary>Returns left < right.</summary>
		public static bool LessThan(int left, int right)
		{
			return left < right;
		}

		/// <summary>Returns left > right.</summary>
		public static bool GreaterThan(int left, int right)
		{
			return left > right;
		}

		/// <summary>Clamps a value to be within a given minimum and maximum range.</summary>
		public static int Clamp(int value, int minimum, int maximum)
		{
			if (value < minimum)
				return minimum;
			if (value > maximum)
				return maximum;
			return value;
		}

		#endregion

		#region short

		/// <summary>Returns a less/greater/equal comparison.</summary>
		public static Comparison Compare(short left, short right)
		{
			short result = (short)left.CompareTo(right);
			if (result > 0)
				return Comparison.Greater;
			else if (result < 0)
				return Comparison.Less;
			else
				return Comparison.Equal;
		}

		/// <summary>Returns true if all values are equal.</summary>
		public static bool Equate(params short[] values)
		{
			for (short i = 0; i < values.Length - 1; i++)
				if (values[i] != values[i + 1])
					return false;
			return true;
		}

		/// <summary>Returns left == right.</summary>
		public static bool Equate(short left, short right)
		{
			return left == right;
		}

		/// <summary>Returns Abs(left - right) < leniency.</summary>
		public static bool Equate(short left, short right, short leniency)
		{
			return Abs(left - right) < leniency;
		}

		/// <summary>Returns the maximum value.</summary>
		public static short Max(params short[] values)
		{
			short max = values[0];
			for (short i = 0; i < values.Length; i++)
				if (values[i] > max)
					max = values[i];
			return max;
		}

		/// <summary>Returns the maximum value.</summary>
		public static short Max(short first, short second)
		{
			if (second > first)
				return second;
			return first;
		}

		/// <summary>Returns the minimum value.</summary>
		public static short Min(params short[] values)
		{
			short max = values[0];
			for (short i = 0; i < values.Length; i++)
				if (values[i] < max)
					max = values[i];
			return max;
		}

		/// <summary>Returns the minimum value.</summary>
		public static short Min(short first, short second)
		{
			if (second < first)
				return second;
			return first;
		}

		/// <summary>Returns the absolute value of the provided value.</summary>
		public static short Abs(short number)
		{
			if (number < 0)
				return (short)-number;
			return number;
		}

		/// <summary>Returns left < right.</summary>
		public static bool LessThan(short left, short right)
		{
			return left < right;
		}

		/// <summary>Returns left > right.</summary>
		public static bool GreaterThan(short left, short right)
		{
			return left > right;
		}

		/// <summary>Clamps a value to be within a given minimum and maximum range.</summary>
		public static short Clamp(short value, short minimum, short maximum)
		{
			if (value < minimum)
				return minimum;
			if (value > maximum)
				return maximum;
			return value;
		}

		#endregion

		#region byte

		/// <summary>Returns a less/greater/equal comparison.</summary>
		public static Comparison Compare(byte left, byte right)
		{
			byte result = (byte)left.CompareTo(right);
			if (result > 0)
				return Comparison.Greater;
			else if (result < 0)
				return Comparison.Less;
			else
				return Comparison.Equal;
		}

		/// <summary>Returns true if all values are equal.</summary>
		public static bool Equate(params byte[] values)
		{
			for (byte i = 0; i < values.Length - 1; i++)
				if (values[i] != values[i + 1])
					return false;
			return true;
		}

		/// <summary>Returns left == right.</summary>
		public static bool Equate(byte left, byte right)
		{
			return left == right;
		}

		/// <summary>Returns Abs(left - right) < leniency.</summary>
		public static bool Equate(byte left, byte right, byte leniency)
		{
			return Abs(left - right) < leniency;
		}

		/// <summary>Returns the maximum value.</summary>
		public static byte Max(params byte[] values)
		{
			byte max = values[0];
			for (byte i = 0; i < values.Length; i++)
				if (values[i] > max)
					max = values[i];
			return max;
		}

		/// <summary>Returns the maximum value.</summary>
		public static byte Max(byte first, byte second)
		{
			if (second > first)
				return second;
			return first;
		}

		/// <summary>Returns the minimum value.</summary>
		public static byte Min(params byte[] values)
		{
			byte max = values[0];
			for (byte i = 0; i < values.Length; i++)
				if (values[i] < max)
					max = values[i];
			return max;
		}

		/// <summary>Returns the minimum value.</summary>
		public static byte Min(byte first, byte second)
		{
			if (second < first)
				return second;
			return first;
		}

		/// <summary>Returns the absolute value of the provided value.</summary>
		public static byte Abs(byte number)
		{
			return number;
		}

		/// <summary>Returns left < right.</summary>
		public static bool LessThan(byte left, byte right)
		{
			return left < right;
		}

		/// <summary>Returns left > right.</summary>
		public static bool GreaterThan(byte left, byte right)
		{
			return left > right;
		}

		/// <summary>Clamps a value to be within a given minimum and maximum range.</summary>
		public static byte Clamp(byte value, byte minimum, byte maximum)
		{
			if (value < minimum)
				return minimum;
			if (value > maximum)
				return maximum;
			return value;
		}

		#endregion

		#endregion

    #region error

    public class Error : Seven.Error
    {
      public Error(string message) : base(message) { }
    }

    #endregion
  }
}
