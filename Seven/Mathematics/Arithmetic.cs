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
    Arithmetic.delegates.Negate<T> Negate { get; }
    /// <summary>Divides two operands.</summary>
    Arithmetic.delegates.Divide<T> Divide { get; }
    /// <summary>Multiplies two operands.</summary>
    Arithmetic.delegates.Multiply<T> Multiply { get; }
    /// <summary>Adds two operands.</summary>
    Arithmetic.delegates.Add<T> Add { get; }
    /// <summary>Subtracts two operands.</summary>
    Arithmetic.delegates.Subtract<T> Subtract { get; }
    /// <summary>Takes one operand to the power of the other.</summary>
    Arithmetic.delegates.Power<T> Power { get; }

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

    #region implementation

    #region Fraction128

    public static Fraction128 Negate(Fraction128 i) { return -i; }

    public static Fraction128 Divide(Fraction128 l, Fraction128 r) { return l / r; }

    public static Fraction128 Multiply(Fraction128 l, Fraction128 r) { return l * r; }

    public static Fraction128 Add(Fraction128 l, Fraction128 r) { return l + r; }

    public static Fraction128 Subtract(Fraction128 l, Fraction128 r) { return l - r; }

    public static Fraction128 Power(Fraction128 l, Fraction128 r) { return (Fraction128)System.Math.Pow((double)l, (double)r); }

    #endregion

    #region Fraction64

    public static Fraction64 Negate(Fraction64 i) { return -i; }

    public static Fraction64 Divide(Fraction64 l, Fraction64 r) { return l / r; }

    public static Fraction64 Multiply(Fraction64 l, Fraction64 r) { return l * r; }

    public static Fraction64 Add(Fraction64 l, Fraction64 r) { return l + r; }

    public static Fraction64 Subtract(Fraction64 l, Fraction64 r) { return l - r; }

    public static Fraction64 Power(Fraction64 l, Fraction64 r) { return (Fraction64)System.Math.Pow((double)l, (double)r); }

    #endregion

    #region decimal

    public static decimal Negate(decimal i) { return -i; }

    public static decimal Divide(decimal l, decimal r) { return l / r; }

    public static decimal Multiply(decimal l, decimal r) { return l * r; }

    public static decimal Add(decimal l, decimal r) { return l + r; }

    public static decimal Subtract(decimal l, decimal r) { return l - r; }

    public static decimal Power(decimal l, decimal r) { return (decimal)System.Math.Pow((double)l, (double)r); }

    #endregion

    #region double

    public static double Negate(double i) { return -i; }

    public static double Divide(double l, double r) { return l / r; }

    public static double Multiply(double l, double r) { return l * r; }

    public static double Add(double l, double r) { return l + r; }

    public static double Subtract(double l, double r) { return l - r; }

    public static double Power(double l, double r) { return (double)System.Math.Pow(l, r); }

    #endregion

    #region float

    public static float Negate(float i) { return -i; }

    public static float Divide(float l, float r) { return l / r; }

    public static float Multiply(float l, float r) { return l * r; }

    public static float Add(float l, float r) { return l + r; }

    public static float Subtract(float l, float r) { return l - r; }

    public static float Power(float l, float r) { return (float)System.Math.Pow(l, r); }

    #endregion

    #region long

    public static long Negate(long i) { return -i; }

    public static long Divide(long l, long r) { return l / r; }

    public static long Multiply(long l, long r) { return l * r; }

    public static long Add(long l, long r) { return l + r; }

    public static long Subtract(long l, long r) { return l - r; }

    public static long Power(long l, long r) { return (long)System.Math.Pow(l, r); }

    #endregion

    #region int

    public static int Negate(int i) { return -i; }

    public static int Divide(int l, int r) { return l / r; }

    public static int Multiply(int l, int r) { return l * r; }

    public static int Add(int l, int r) { return l + r; }

    public static int Subtract(int l, int r) { return l - r; }

    public static int Power(int l, int r) { return (int)System.Math.Pow(l, r); }

    #endregion

    #endregion

    #region library

    public static Seven.Structures.Map<object, System.Type> _arithmetics =
      new Seven.Structures.Map_Linked<object, System.Type>(
        (System.Type left, System.Type right) => { return left == right; },
        (System.Type type) => { return type.GetHashCode(); })
				{
          { typeof(Fraction128), Arithmetic.Arithmetic_Fraction128.Get },
          { typeof(Fraction64), Arithmetic.Arithmetic_Fraction64.Get },
          { typeof(decimal), Arithmetic.Arithmetic_decimal.Get },
          { typeof(double), Arithmetic.Arithmetic_double.Get },
          { typeof(float), Arithmetic.Arithmetic_float.Get },
          { typeof(long), Arithmetic.Arithmetic_long.Get },
					{ typeof(int), Arithmetic.Arithmetic_int.Get },
				};

    public static Arithmetic<T> Get<T>()
    {
      try { return _arithmetics[typeof(T)] as Arithmetic<T>; }
      catch { throw new Error("Arithmetic does not yet exist for " + typeof(T).ToString()); }
    }

    #region provided

    private class Arithmetic_Fraction128 : Arithmetic<Fraction128>
    {
      private Arithmetic_Fraction128() { _instance = this; }
      private static Arithmetic_Fraction128 _instance;
      private static Arithmetic_Fraction128 Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Arithmetic_Fraction128();
          else
            return _instance;
        }
      }

      /// <summary>Gets Arithmetic for "Fraction128" types.</summary>
      public static Arithmetic_Fraction128 Get { get { return Instance; } }

      /// <summary>Negates a value.</summary>
      public Arithmetic.delegates.Negate<Fraction128> Negate { get { return Arithmetic.Negate; } }
      /// <summary>Divides two operands.</summary>
      public Arithmetic.delegates.Divide<Fraction128> Divide { get { return Arithmetic.Divide; } }
      /// <summary>Multiplies two operands.</summary>
      public Arithmetic.delegates.Multiply<Fraction128> Multiply { get { return Arithmetic.Multiply; } }
      /// <summary>Adds two operands.</summary>
      public Arithmetic.delegates.Add<Fraction128> Add { get { return Arithmetic.Add; } }
      /// <summary>Subtracts two operands.</summary>
      public Arithmetic.delegates.Subtract<Fraction128> Subtract { get { return Arithmetic.Subtract; } }
      /// <summary>Takes one operand to the power of the other.</summary>
      public Arithmetic.delegates.Power<Fraction128> Power { get { return Arithmetic.Power; } }
    }

    private class Arithmetic_Fraction64 : Arithmetic<Fraction64>
    {
      private Arithmetic_Fraction64() { _instance = this; }
      private static Arithmetic_Fraction64 _instance;
      private static Arithmetic_Fraction64 Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Arithmetic_Fraction64();
          else
            return _instance;
        }
      }

      /// <summary>Gets Arithmetic for "Fraction64" types.</summary>
      public static Arithmetic_Fraction64 Get { get { return Instance; } }

      /// <summary>Negates a value.</summary>
      public Arithmetic.delegates.Negate<Fraction64> Negate { get { return Arithmetic.Negate; } }
      /// <summary>Divides two operands.</summary>
      public Arithmetic.delegates.Divide<Fraction64> Divide { get { return Arithmetic.Divide; } }
      /// <summary>Multiplies two operands.</summary>
      public Arithmetic.delegates.Multiply<Fraction64> Multiply { get { return Arithmetic.Multiply; } }
      /// <summary>Adds two operands.</summary>
      public Arithmetic.delegates.Add<Fraction64> Add { get { return Arithmetic.Add; } }
      /// <summary>Subtracts two operands.</summary>
      public Arithmetic.delegates.Subtract<Fraction64> Subtract { get { return Arithmetic.Subtract; } }
      /// <summary>Takes one operand to the power of the other.</summary>
      public Arithmetic.delegates.Power<Fraction64> Power { get { return Arithmetic.Power; } }
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
      public Arithmetic.delegates.Negate<decimal> Negate { get { return Arithmetic.Negate; } }
      /// <summary>Divides two operands.</summary>
      public Arithmetic.delegates.Divide<decimal> Divide { get { return Arithmetic.Divide; } }
      /// <summary>Multiplies two operands.</summary>
      public Arithmetic.delegates.Multiply<decimal> Multiply { get { return Arithmetic.Multiply; } }
      /// <summary>Adds two operands.</summary>
      public Arithmetic.delegates.Add<decimal> Add { get { return Arithmetic.Add; } }
      /// <summary>Subtracts two operands.</summary>
      public Arithmetic.delegates.Subtract<decimal> Subtract { get { return Arithmetic.Subtract; } }
      /// <summary>Takes one operand to the power of the other.</summary>
      public Arithmetic.delegates.Power<decimal> Power { get { return Arithmetic.Power; } }
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
      public Arithmetic.delegates.Negate<double> Negate { get { return Arithmetic.Negate; } }
      /// <summary>Divides two operands.</summary>
      public Arithmetic.delegates.Divide<double> Divide { get { return Arithmetic.Divide; } }
      /// <summary>Multiplies two operands.</summary>
      public Arithmetic.delegates.Multiply<double> Multiply { get { return Arithmetic.Multiply; } }
      /// <summary>Adds two operands.</summary>
      public Arithmetic.delegates.Add<double> Add { get { return Arithmetic.Add; } }
      /// <summary>Subtracts two operands.</summary>
      public Arithmetic.delegates.Subtract<double> Subtract { get { return Arithmetic.Subtract; } }
      /// <summary>Takes one operand to the power of the other.</summary>
      public Arithmetic.delegates.Power<double> Power { get { return Arithmetic.Power; } }
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
      public Arithmetic.delegates.Negate<float> Negate { get { return Arithmetic.Negate; } }
      /// <summary>Divides two operands.</summary>
      public Arithmetic.delegates.Divide<float> Divide { get { return Arithmetic.Divide; } }
      /// <summary>Multiplies two operands.</summary>
      public Arithmetic.delegates.Multiply<float> Multiply { get { return Arithmetic.Multiply; } }
      /// <summary>Adds two operands.</summary>
      public Arithmetic.delegates.Add<float> Add { get { return Arithmetic.Add; } }
      /// <summary>Subtracts two operands.</summary>
      public Arithmetic.delegates.Subtract<float> Subtract { get { return Arithmetic.Subtract; } }
      /// <summary>Takes one operand to the power of the other.</summary>
      public Arithmetic.delegates.Power<float> Power { get { return Arithmetic.Power; } }
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
      public Arithmetic.delegates.Negate<long> Negate { get { return Arithmetic.Negate; } }
      /// <summary>Divides two operands.</summary>
      public Arithmetic.delegates.Divide<long> Divide { get { return Arithmetic.Divide; } }
      /// <summary>Multiplies two operands.</summary>
      public Arithmetic.delegates.Multiply<long> Multiply { get { return Arithmetic.Multiply; } }
      /// <summary>Adds two operands.</summary>
      public Arithmetic.delegates.Add<long> Add { get { return Arithmetic.Add; } }
      /// <summary>Subtracts two operands.</summary>
      public Arithmetic.delegates.Subtract<long> Subtract { get { return Arithmetic.Subtract; } }
      /// <summary>Takes one operand to the power of the other.</summary>
      public Arithmetic.delegates.Power<long> Power { get { return Arithmetic.Power; } }
    }

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
      public Arithmetic.delegates.Negate<int> Negate { get { return Arithmetic.Negate; } }
      /// <summary>Divides two operands.</summary>
      public Arithmetic.delegates.Divide<int> Divide { get { return Arithmetic.Divide; } }
      /// <summary>Multiplies two operands.</summary>
      public Arithmetic.delegates.Multiply<int> Multiply { get { return Arithmetic.Multiply; } }
      /// <summary>Adds two operands.</summary>
      public Arithmetic.delegates.Add<int> Add { get { return Arithmetic.Add; } }
      /// <summary>Subtracts two operands.</summary>
      public Arithmetic.delegates.Subtract<int> Subtract { get { return Arithmetic.Subtract; } }
      /// <summary>Takes one operand to the power of the other.</summary>
      public Arithmetic.delegates.Power<int> Power { get { return Arithmetic.Power; } }
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
