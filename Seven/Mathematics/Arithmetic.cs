// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics
{
  /// <summary>Supplies arithmetic mathematics for generic types.</summary>
  /// <typeparam name="T">The type this arithmetic library can perform on.</typeparam>
  public interface Arithmetic<T>
  {
    #region method

    /// <summary>Negates a value.</summary>
    T Negate(T value);
    /// <summary>Divides two operands.</summary>
    T Divide(T left, T right);
    /// <summary>Multiplies two operands.</summary>
    T Multiply(T left, T right);
    /// <summary>Adds two operands.</summary>
    T Add(T left, T right);
    /// <summary>Subtracts two operands.</summary>
    T Subtract(T left, T right);
    /// <summary>Takes one operand to the power of the other.</summary>
    T Power(T _base, T power);

    #endregion
  }

  /// <summary>Contains arithmetic mathmatic operations.</summary>
  public static class Arithmetic
  {
    #region delegate

    /// <summary>Contains the delegates for arithmetic operations.</summary>
    public static class delegates
    {

      /// <summary>Negates a value.</summary>
      /// <typeparam name="T">The type of the value to negate.</typeparam>
      /// <param name="value">The value to negate.</param>
      /// <returns>The result of the negation.</returns>
      public delegate T Negate<T>(T value);
      /// <summary>Adds two operands together.</summary>
      /// <typeparam name="T">The type of the values to be added.</typeparam>
      /// <param name="left">The left operand of the addition.</param>
      /// <param name="right">The right operand of the addition.</param>
      /// <returns>The result of the addition.</returns>
      public delegate T Add<T>(T left, T right);
      /// <summary>Subtracts two operands.</summary>
      /// <typeparam name="T">The type of the operands to subtract.</typeparam>
      /// <param name="left">The left operand of the subtraction.</param>
      /// <param name="right">The right operand of the subtraction.</param>
      /// <returns>The result of the subtraction.</returns>
      public delegate T Subtract<T>(T left, T right);
      /// <summary>Multiplies two operands together.</summary>
      /// <typeparam name="T">The type of the operands to be multiplied.</typeparam>
      /// <param name="left">The left operand of the multiplication.</param>
      /// <param name="right">The right operand of the multiplication.</param>
      /// <returns>The result of the multiplication.</returns>
      public delegate T Multiply<T>(T left, T right);
      /// <summary>Divides two operands.</summary>
      /// <typeparam name="T">The type of the operands to be divided.</typeparam>
      /// <param name="left">The left operand of the division.</param>
      /// <param name="right">The right operand of the division.</param>
      /// <returns>The result of the division.</returns>
      public delegate T Divide<T>(T left, T right);
      /// <summary>Takes one operand to the power of another.</summary>
      /// <typeparam name="T">The type of the operand os the power operation.</typeparam>
      /// <param name="left">The base of the power operaition.</param>
      /// <param name="right">The exponent of the power operation.</param>
      /// <returns>The result of the power operation.</returns>
      public delegate T Power<T>(T left, T right);

    }

    #endregion

    #region enum

    /// <summary>The operations of arithmetic.</summary>
    public enum Operation
    {
      /// <summary>Negation arithmatic operation.</summary>
      Negate,
      /// <summary>Division arithmatic operation</summary>
      Divide,
      /// <summary>Multiplication arithmatic operation</summary>
      Multiply,
      /// <summary>Addition arithmatic operation</summary>
      Add,
      /// <summary>Subtraction arithmatic operation</summary>
      Subtract,
      /// <summary>Power arithmatic operation</summary>
      Power
    }

    #endregion

    #region library

    public static Seven.Structures.Map<object, System.Type> _arithmetics =
      new Seven.Structures.Map_Linked<object, System.Type>(
        (System.Type left, System.Type right) => { return left == right; },
        (System.Type type) => { return type.GetHashCode(); })
				{
					{ typeof(int), Arithmetic.Arithmetic_int.Get },
					{ typeof(double), Arithmetic.Arithmetic_double.Get },
					{ typeof(float), Arithmetic.Arithmetic_float.Get },
					{ typeof(decimal), Arithmetic.Arithmetic_decimal.Get },
					{ typeof(long), Arithmetic.Arithmetic_long.Get },
					{ typeof(short), Arithmetic.Arithmetic_short.Get },
					{ typeof(byte), Arithmetic.Arithmetic_byte.Get }
				};

    public static Arithmetic<T> Get<T>()
    {
      try { return _arithmetics[typeof(T)] as Arithmetic<T>; }
      catch { throw new Error("Arithmetic does not yet exist for " + typeof(T).ToString()); }
    }

    #region provided

    private class Arithmetic_int : Arithmetic<int>
    {
      private Arithmetic_int() { _instance = this; }
      private static Arithmetic_int _instance;
      private static Arithmetic_int Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Arithmetic_int();
          else
            return _instance;
        }
      }

      /// <summary>Gets Arithmetic for "int" types.</summary>
      public static Arithmetic_int Get { get { return Instance; } }

      /// <summary>Negates a value.</summary>
      public int Negate(int value) { return -value; }
      /// <summary>Returns the value ignoring the sign.</summary>
      public int Absolute(int value) { return System.Math.Abs(value); }
      /// <summary>Divides two operands.</summary>
      public int Divide(int left, int right) { return left / right; }
      /// <summary>Multiplies two operands.</summary>
      public int Multiply(int left, int right) { return left * right; }
      /// <summary>Adds two operands.</summary>
      public int Add(int left, int right) { return left + right; }
      /// <summary>Subtracts two operands.</summary>
      public int Subtract(int left, int right) { return left - right; }
      /// <summary>Takes one operand to the power of the other.</summary>
      public int Power(int _base, int power) { return (int)System.Math.Pow(_base, power); }

      /// <summary>Error type for all arithmetic computations.</summary>
      public class Error : Arithmetic.Error
      {
        public Error(string message) : base(message) { }
      }
    }

    private class Arithmetic_float : Arithmetic<float>
    {
      private Arithmetic_float() { _instance = this; }
      private static Arithmetic_float _instance;
      private static Arithmetic_float Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Arithmetic_float();
          else
            return _instance;
        }
      }

      /// <summary>Gets Arithmetic for "float" types.</summary>
      public static Arithmetic_float Get { get { return Instance; } }

      /// <summary>Negates a value.</summary>
      public float Negate(float value) { return -value; }
      /// <summary>Returns the value ignoring the sign.</summary>
      public float Absolute(float value) { return System.Math.Abs(value); }
      /// <summary>Divides two operands.</summary>
      public float Divide(float left, float right) { return left / right; }
      /// <summary>Multiplies two operands.</summary>
      public float Multiply(float left, float right) { return left * right; }
      /// <summary>Adds two operands.</summary>
      public float Add(float left, float right) { return left + right; }
      /// <summary>Subtracts two operands.</summary>
      public float Subtract(float left, float right) { return left - right; }
      /// <summary>Takes one operand to the power of the other.</summary>
      public float Power(float left, float right) { return (float)System.Math.Pow(left, right); }

      /// <summary>Error type for all arithmetic computations.</summary>
      public class Error : Arithmetic.Error
      {
        public Error(string message) : base(message) { }
      }
    }

    private class Arithmetic_double : Arithmetic<double>
    {
      private Arithmetic_double() { _instance = this; }
      private static Arithmetic_double _instance;
      private static Arithmetic_double Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Arithmetic_double();
          else
            return _instance;
        }
      }

      /// <summary>Gets Arithmetic for "double" types.</summary>
      public static Arithmetic_double Get { get { return Instance; } }

      /// <summary>Negates a value.</summary>
      public double Negate(double value) { return -value; }
      /// <summary>Returns the value ignoring the sign.</summary>
      public double Absolute(double value) { return System.Math.Abs(value); }
      /// <summary>Divides two operands.</summary>
      public double Divide(double left, double right) { return left / right; }
      /// <summary>Multiplies two operands.</summary>
      public double Multiply(double left, double right) { return left * right; }
      /// <summary>Adds two operands.</summary>
      public double Add(double left, double right) { return left + right; }
      /// <summary>Subtracts two operands.</summary>
      public double Subtract(double left, double right) { return left - right; }
      /// <summary>Takes one operand to the power of the other.</summary>
      public double Power(double left, double right) { return System.Math.Pow(left, right); }

      /// <summary>Error type for all arithmetic computations.</summary>
      public class Error : Arithmetic.Error
      {
        public Error(string message) : base(message) { }
      }
    }

    private class Arithmetic_decimal : Arithmetic<decimal>
    {
      private Arithmetic_decimal() { _instance = this; }
      private static Arithmetic_decimal _instance;
      private static Arithmetic_decimal Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Arithmetic_decimal();
          else
            return _instance;
        }
      }

      /// <summary>Gets Arithmetic for "decimal" types.</summary>
      public static Arithmetic_decimal Get { get { return Instance; } }

      /// <summary>Negates a value.</summary>
      public decimal Negate(decimal value) { return -value; }
      /// <summary>Returns the value ignoring the sign.</summary>
      public decimal Absolute(decimal value) { return System.Math.Abs(value); }
      /// <summary>Divides two operands.</summary>
      public decimal Divide(decimal left, decimal right) { return left / right; }
      /// <summary>Multiplies two operands.</summary>
      public decimal Multiply(decimal left, decimal right) { return left * right; }
      /// <summary>Adds two operands.</summary>
      public decimal Add(decimal left, decimal right) { return left + right; }
      /// <summary>Subtracts two operands.</summary>
      public decimal Subtract(decimal left, decimal right) { return left - right; }
      /// <summary>Takes one operand to the power of the other.</summary>
      public decimal Power(decimal left, decimal right) { return (decimal)System.Math.Pow((double)left, (double)right); }

      /// <summary>Error type for all arithmetic computations.</summary>
      public class Error : Arithmetic.Error
      {
        public Error(string message) : base(message) { }
      }
    }

    private class Arithmetic_long : Arithmetic<long>
    {
      private Arithmetic_long() { _instance = this; }
      private static Arithmetic_long _instance;
      private static Arithmetic_long Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Arithmetic_long();
          else
            return _instance;
        }
      }

      /// <summary>Gets Arithmetic for "long" types.</summary>
      public static Arithmetic_long Get { get { return Instance; } }

      /// <summary>Negates a value.</summary>
      public long Negate(long value) { return -value; }
      /// <summary>Returns the value ignoring the sign.</summary>
      public long Absolute(long value) { return System.Math.Abs(value); }
      /// <summary>Divides two operands.</summary>
      public long Divide(long left, long right) { return left / right; }
      /// <summary>Multiplies two operands.</summary>
      public long Multiply(long left, long right) { return left * right; }
      /// <summary>Adds two operands.</summary>
      public long Add(long left, long right) { return left + right; }
      /// <summary>Subtracts two operands.</summary>
      public long Subtract(long left, long right) { return left - right; }
      /// <summary>Takes one operand to the power of the other.</summary>
      public long Power(long left, long right) { return (long)System.Math.Pow(left, right); }

      /// <summary>Error type for all arithmetic computations.</summary>
      public class Error : Arithmetic.Error
      {
        public Error(string message) : base(message) { }
      }
    }

    private class Arithmetic_short : Arithmetic<short>
    {
      private Arithmetic_short() { _instance = this; }
      private static Arithmetic_short _instance;
      private static Arithmetic_short Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Arithmetic_short();
          else
            return _instance;
        }
      }

      /// <summary>Gets Arithmetic for "short" types.</summary>
      public static Arithmetic_short Get { get { return Instance; } }

      /// <summary>Negates a value.</summary>
      public short Negate(short value) { return (short)-value; }
      /// <summary>Returns the value ignoring the sign.</summary>
      public short Absolute(short value) { return System.Math.Abs(value); }
      /// <summary>Divides two operands.</summary>
      public short Divide(short left, short right) { return (short)(left / right); }
      /// <summary>Multiplies two operands.</summary>
      public short Multiply(short left, short right) { return (short)(left * right); }
      /// <summary>Adds two operands.</summary>
      public short Add(short left, short right) { return (short)(left + right); }
      /// <summary>Subtracts two operands.</summary>
      public short Subtract(short left, short right) { return (short)(left - right); }
      /// <summary>Takes one operand to the power of the other.</summary>
      public short Power(short left, short right) { return (short)System.Math.Pow(left, right); }

      /// <summary>Error type for all arithmetic computations.</summary>
      public class Error : Arithmetic.Error
      {
        public Error(string message) : base(message) { }
      }
    }

    private class Arithmetic_byte : Arithmetic<byte>
    {
      private Arithmetic_byte() { _instance = this; }
      private static Arithmetic_byte _instance;
      private static Arithmetic_byte Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Arithmetic_byte();
          else
            return _instance;
        }
      }

      /// <summary>Gets Arithmetic for "byte" types.</summary>
      public static Arithmetic_byte Get { get { return Instance; } }

      /// <summary>Negates a value.</summary>
      public byte Negate(byte b) { throw new Arithmetic.Error("attempting to negate a byte."); }
      /// <summary>Returns the value ignoring the sign.</summary>
      public byte Absolute(byte b) { return b; }
      /// <summary>Divides two operands.</summary>
      public byte Divide(byte left, byte right) { return (byte)(left / right); }
      /// <summary>Multiplies two operands.</summary>
      public byte Multiply(byte left, byte right) { return (byte)(left * right); }
      /// <summary>Adds two operands.</summary>
      public byte Add(byte left, byte right) { return (byte)(left + right); }
      /// <summary>Subtracts two operands.</summary>
      public byte Subtract(byte left, byte right) { return (byte)(left - right); }
      /// <summary>Takes one operand to the power of the other.</summary>
      public byte Power(byte left, byte right) { return (byte)System.Math.Pow(left, right); }

      /// <summary>Error type for all arithmetic computations.</summary>
      public class Error : Arithmetic.Error
      {
        public Error(string message) : base(message) { }
      }
    }

    #endregion

    #endregion

    #region error

    /// <summary>Error type for all arithmetic computations.</summary>
    public class Error : Seven.Error
    {
      public Error(string message) : base(message) { }
    }

    #endregion
  }
}
