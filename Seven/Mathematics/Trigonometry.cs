// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics
{
  /// <summary>Supplies trigonometry mathematics for generic types.</summary>
  /// <typeparam name="T">The type this trigonometry library can perform on.</typeparam>
  public interface Trigonometry<T>
  {
    #region property

    Trigonometry.delegates.sin<T> sin { get; }
    Trigonometry.delegates.cos<T> cos { get; }
    Trigonometry.delegates.tan<T> tan { get; }
    Trigonometry.delegates.sec<T> sec { get; }
    Trigonometry.delegates.csc<T> csc { get; }
    Trigonometry.delegates.cot<T> cot { get; }
    Trigonometry.delegates.asin<T> asin { get; }
    Trigonometry.delegates.acos<T> acos { get; }
    Trigonometry.delegates.atan<T> atan { get; }
    Trigonometry.delegates.acsc<T> acsc { get; }
    Trigonometry.delegates.asec<T> asec { get; }
    Trigonometry.delegates.acot<T> acot { get; }
    Trigonometry.delegates.sinh<T> sinh { get; }
    Trigonometry.delegates.cosh<T> cosh { get; }
    Trigonometry.delegates.tanh<T> tanh { get; }
    Trigonometry.delegates.sech<T> sech { get; }
    Trigonometry.delegates.csch<T> csch { get; }
    Trigonometry.delegates.coth<T> coth { get; }
    Trigonometry.delegates.asinh<T> asinh { get; }
    Trigonometry.delegates.acosh<T> acosh { get; }
    Trigonometry.delegates.atanh<T> atanh { get; }
    Trigonometry.delegates.acsch<T> acsch { get; }
    Trigonometry.delegates.asech<T> asech { get; }
    Trigonometry.delegates.acoth<T> acoth { get; }

    #endregion
  }

  /// <summary>Makes and stores implementations of trigonometry.</summary>
  public static class Trigonometry
  {
    #region Delegates

    public static class delegates
    {

      public delegate T sin<T>(T angle);
      public delegate T cos<T>(T angle);
      public delegate T tan<T>(T angle);
      public delegate T sec<T>(T angle);
      public delegate T csc<T>(T angle);
      public delegate T cot<T>(T angle);
      public delegate T asin<T>(T ratio);
      public delegate T acos<T>(T ratio);
      public delegate T atan<T>(T ratio);
      public delegate T acsc<T>(T ratio);
      public delegate T asec<T>(T ratio);
      public delegate T acot<T>(T ratio);
      public delegate T sinh<T>(T angle);
      public delegate T cosh<T>(T angle);
      public delegate T tanh<T>(T angle);
      public delegate T sech<T>(T angle);
      public delegate T csch<T>(T angle);
      public delegate T coth<T>(T angle);
      public delegate T asinh<T>(T ratio);
      public delegate T acosh<T>(T ratio);
      public delegate T atanh<T>(T ratio);
      public delegate T acsch<T>(T ratio);
      public delegate T asech<T>(T ratio);
      public delegate T acoth<T>(T ratio);

    }

    #endregion

    #region Libraries

    public static Seven.Structures.Map<object, System.Type> _trigonometries =
			new Seven.Structures.Map_Linked<object, System.Type>(
				(System.Type left, System.Type right) => { return left == right; },
				(System.Type type) => { return type.GetHashCode(); })
				{
					//{ typeof(float), Trigonometry_float.Get },
          { typeof(double), Trigonometry_double.Get },
				};

    public static void Set<T>(Trigonometry<T> _algebra)
    {
      _trigonometries[typeof(T)] = _algebra;
    }

    public static bool Contains<T>()
    {
      return _trigonometries.Contains(typeof(T));
    }

    public static Trigonometry<T> Get<T>()
    {
      object temp;
      if (_trigonometries.TryGet(typeof(T), out temp))
        return temp as Trigonometry<T>;
      else
        return new Trigonometry_unsupported<T>();
    }

    #region provided

    #region Back-UP
    //private class Trigonometry_float : Trigonometry<float>
    //{
    //  private Trigonometry_float() { _instance = this; }
    //  private static Trigonometry_float _instance;
    //  private static Trigonometry_float Instance
    //  {
    //    get
    //    {
    //      if (_instance == null)
    //        return _instance = new Trigonometry_float();
    //      else
    //        return _instance;
    //    }
    //  }

    //  public static Trigonometry_float Get { get { return Instance; } }

    //  public float toRadians(float angle)
    //  {
    //    return angle * Constants.pi_float / 180f;
    //  }

    //  public float toDegrees(float angle)
    //  {
    //    return angle * 180f / Constants.pi_float;
    //  }

    //  public float sin(float angle)
    //  {
    //    return (float)System.Math.Sin(angle);

    //    // THE FOLLOWING IS PERSONAL SIN FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
    //    // THE SYSTEM FUNCTION IN ITS CURRENT STATE
    //    #region Custom Sin Function
    //    //// get the angle to be within the unit circle
    //    //angle = angle % (TwoPi);

    //    //// if the angle is negative, inverse it against the full unit circle
    //    //if (angle < 0)
    //    //  angle = TwoPi + angle;

    //    //// adjust for quadrants
    //    //// NOTE: if you want more accuracy, you can follow this pattern
    //    //// sin(x) = x - x^3/3! + x^5/5! - x^7/7! ...
    //    //// the more terms you include the more accurate it is
    //    //float angleCubed;
    //    //float angleToTheFifth;
    //    //// quadrant 1
    //    //if (angle <= HalfPi)
    //    //{
    //    //  angleCubed = angle * angle * angle;
    //    //  angleToTheFifth = angleCubed * angle * angle;
    //    //  return angle
    //    //    - ((angleCubed) / 6)
    //    //    + ((angleToTheFifth) / 120);
    //    //}
    //    //// quadrant 2
    //    //else if (angle <= Pi)
    //    //{
    //    //  angle = HalfPi - (angle % HalfPi);
    //    //  angleCubed = angle * angle * angle;
    //    //  angleToTheFifth = angleCubed * angle * angle;
    //    //  return angle
    //    //    - ((angleCubed) / 6)
    //    //    + ((angleToTheFifth) / 120);
    //    //}
    //    //// quadrant 3
    //    //else if (angle <= ThreeHalvesPi)
    //    //{
    //    //  angle = angle % Pi;
    //    //  angleCubed = angle * angle * angle;
    //    //  angleToTheFifth = angleCubed * angle * angle;
    //    //  return -(angle
    //    //      - ((angleCubed) / 6)
    //    //      + ((angleToTheFifth) / 120));
    //    //}
    //    //// quadrant 4  
    //    //else
    //    //{
    //    //  angle = HalfPi - (angle % HalfPi);
    //    //  angleCubed = angle * angle * angle;
    //    //  angleToTheFifth = angleCubed * angle * angle;
    //    //  return -(angle
    //    //      - ((angleCubed) / 6)
    //    //      + ((angleToTheFifth) / 120));
    //    //}
    //    #endregion
    //  }

    //  public float cos(float angle)
    //  {
    //    return (float)System.Math.Cos(angle);

    //    // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
    //    // THE SYSTEM FUNCTION IN ITS CURRENT STATE
    //    #region Custom Cos Function
    //    //// If you wanted to be cheap, you could just use the following commented line...
    //    //// return Sin(angle + (Pi / 2));

    //    //// get the angle to be within the unit circle
    //    //angle = angle % (TwoPi);

    //    //// if the angle is negative, inverse it against the full unit circle
    //    //if (angle < 0)
    //    //  angle = TwoPi + angle;

    //    //// adjust for quadrants
    //    //// NOTE: if you want more accuracy, you can follow this pattern
    //    //// cos(x) = 1 - x^2/2! + x^4/4! - x^6/6! ...
    //    //// the terms you include the more accuracy it is
    //    //float angleSquared;
    //    //float angleToTheFourth;
    //    //float angleToTheSixth;
    //    //// quadrant 1
    //    //if (angle <= HalfPi)
    //    //{
    //    //  angleSquared = angle * angle;
    //    //  angleToTheFourth = angleSquared * angle * angle;
    //    //  angleToTheSixth = angleToTheFourth * angle * angle;
    //    //  return 1
    //    //    - (angleSquared / 2)
    //    //    + (angleToTheFourth / 24)
    //    //    - (angleToTheSixth / 720);
    //    //}
    //    //// quadrant 2
    //    //else if (angle <= Pi)
    //    //{
    //    //  angle = HalfPi - (angle % HalfPi);
    //    //  angleSquared = angle * angle;
    //    //  angleToTheFourth = angleSquared * angle * angle;
    //    //  angleToTheSixth = angleToTheFourth * angle * angle;
    //    //  return -(1
    //    //    - (angleSquared / 2)
    //    //    + (angleToTheFourth / 24)
    //    //    - (angleToTheSixth / 720));
    //    //}
    //    //// quadrant 3
    //    //else if (angle <= ThreeHalvesPi)
    //    //{
    //    //  angle = angle % Pi;
    //    //  angleSquared = angle * angle;
    //    //  angleToTheFourth = angleSquared * angle * angle;
    //    //  angleToTheSixth = angleToTheFourth * angle * angle;
    //    //  return -(1
    //    //    - (angleSquared / 2)
    //    //    + (angleToTheFourth / 24)
    //    //    - (angleToTheSixth / 720));
    //    //}
    //    //// quadrant 4  
    //    //else
    //    //{
    //    //  angle = HalfPi - (angle % HalfPi);
    //    //  angleSquared = angle * angle;
    //    //  angleToTheFourth = angleSquared * angle * angle;
    //    //  angleToTheSixth = angleToTheFourth * angle * angle;
    //    //  return 1
    //    //    - (angleSquared / 2)
    //    //    + (angleToTheFourth / 24)
    //    //    - (angleToTheSixth / 720);
    //    //}
    //    #endregion
    //  }

    //  public float tan(float angle)
    //  {
    //    return (float)System.Math.Tan(angle);

    //    // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
    //    // THE SYSTEM FUNCTION IN ITS CURRENT STATE
    //    #region Custom Tan Function
    //    //// "sin / cos" results in "opposite side / adjacent side", which is equal to tangent
    //    //return Sin(angle) / Cos(angle);
    //    #endregion
    //  }

    //  public float sec(float angle)
    //  {
    //    return 1.0f / (float)System.Math.Cos(angle);

    //    // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
    //    // THE SYSTEM FUNCTION IN ITS CURRENT STATE
    //    #region Custom Sec Function
    //    //// by definition, sec is the reciprical of cos
    //    //return 1 / Cos(angle);
    //    #endregion
    //  }

    //  public float csc(float angle)
    //  {
    //    return 1.0f / (float)System.Math.Sin(angle);

    //    // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
    //    // THE SYSTEM FUNCTION IN ITS CURRENT STATE
    //    #region Custom Csc Function
    //    //// by definition, csc is the reciprical of sin
    //    //return 1 / Sin(angle);
    //    #endregion
    //  }

    //  public float cot(float angle)
    //  {
    //    return 1.0f / (float)System.Math.Tan(angle);

    //    // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
    //    // THE SYSTEM FUNCTION IN ITS CURRENT STATE
    //    #region Custom Cot Function
    //    //// by definition, cot is the reciprical of tan
    //    //return 1 / Tan(angle);
    //    #endregion
    //  }

    //  public float arcsin(float sinRatio)
    //  {
    //    return (float)System.Math.Asin(sinRatio);
    //    //I haven't made a custom ArcSin function yet...
    //  }

    //  public float arccos(float cosRatio)
    //  {
    //    return (float)System.Math.Acos(cosRatio);
    //    //I haven't made a custom ArcCos function yet...
    //  }

    //  public float arctan(float tanRatio)
    //  {
    //    return (float)System.Math.Atan(tanRatio);
    //    //I haven't made a custom ArcTan function yet...
    //  }

    //  public float arccsc(float cscRatio)
    //  {
    //    return (float)System.Math.Asin(1.0f / cscRatio);
    //    //I haven't made a custom ArcCsc function yet...
    //  }

    //  public float arcsec(float secRatio)
    //  {
    //    return (float)System.Math.Acos(1.0f / secRatio);
    //    //I haven't made a custom ArcSec function yet...
    //  }

    //  public float arccot(float cotRatio)
    //  {
    //    return (float)System.Math.Atan(1.0f / cotRatio);
    //    //I haven't made a custom ArcCot function yet...
    //  }
    //}
    #endregion

    private class Trigonometry_double : Trigonometry<double>
    {
      private Trigonometry_double() { _instance = this; }
      private static Trigonometry_double _instance;
      private static Trigonometry_double Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Trigonometry_double();
          else
            return _instance;
        }
      }

      public static Trigonometry_double Get { get { return Instance; } }

      public Trigonometry.delegates.sin<double> sin { get { return Trigonometry.sin; } }
      public Trigonometry.delegates.cos<double> cos { get { return Trigonometry.cos; } }
      public Trigonometry.delegates.tan<double> tan { get { return Trigonometry.tan; } }
      public Trigonometry.delegates.sec<double> sec { get { return Trigonometry.sec; } }
      public Trigonometry.delegates.csc<double> csc { get { return Trigonometry.csc; } }
      public Trigonometry.delegates.cot<double> cot { get { return Trigonometry.cot; } }
      public Trigonometry.delegates.asin<double> asin { get { return Trigonometry.arcsin; } }
      public Trigonometry.delegates.acos<double> acos { get { return Trigonometry.arccos; } }
      public Trigonometry.delegates.atan<double> atan { get { return Trigonometry.arctan; } }
      public Trigonometry.delegates.acsc<double> acsc { get { return Trigonometry.arccsc; } }
      public Trigonometry.delegates.asec<double> asec { get { return Trigonometry.arcsec; } }
      public Trigonometry.delegates.acot<double> acot { get { return Trigonometry.arccot; } }
      public Trigonometry.delegates.sinh<double> sinh { get { return Trigonometry.sinh; } }
      public Trigonometry.delegates.cosh<double> cosh { get { return Trigonometry.cosh; } }
      public Trigonometry.delegates.tanh<double> tanh { get { return Trigonometry.tanh; } }
      public Trigonometry.delegates.sech<double> sech { get { return Trigonometry.sech; } }
      public Trigonometry.delegates.csch<double> csch { get { return Trigonometry.csch; } }
      public Trigonometry.delegates.coth<double> coth { get { return Trigonometry.coth; } }
      public Trigonometry.delegates.asinh<double> asinh { get { return Trigonometry.asinh; } }
      public Trigonometry.delegates.acosh<double> acosh { get { return Trigonometry.acosh; } }
      public Trigonometry.delegates.atanh<double> atanh { get { return Trigonometry.atanh; } }
      public Trigonometry.delegates.acsch<double> acsch { get { return Trigonometry.acsch; } }
      public Trigonometry.delegates.asech<double> asech { get { return Trigonometry.asech; } }
      public Trigonometry.delegates.acoth<double> acoth { get { return Trigonometry.acoth; } }
    }

    private class Trigonometry_unsupported<T> : Trigonometry<T>
    {
      public Trigonometry_unsupported() { }

      public Trigonometry.delegates.sin<T> sin { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.cos<T> cos { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.tan<T> tan { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.sec<T> sec { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.csc<T> csc { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.cot<T> cot { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.asin<T> asin { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.acos<T> acos { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.atan<T> atan { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.acsc<T> acsc { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.asec<T> asec { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.acot<T> acot { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.sinh<T> sinh { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.cosh<T> cosh { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.tanh<T> tanh { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.sech<T> sech { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.csch<T> csch { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.coth<T> coth { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.asinh<T> asinh { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.acosh<T> acosh { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.atanh<T> atanh { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.acsch<T> acsch { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.asech<T> asech { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T)); }; } }
      public Trigonometry.delegates.acoth<T> acoth { get { return (T a) => { throw new Error("Trigonometry is undefined for type: " + typeof(T));}; } }
    }

    #endregion

    #endregion

    #region Implementations

    #region Fraction128

    public static Fraction128 toRadians(Fraction128 angle)
    {
      return (Fraction128)((double)angle * Constants.pi_double / 180d);
    }

    public static Fraction128 toDegrees(Fraction128 angle)
    {
      return (Fraction128)((double)angle * 180d / Constants.pi_double);
    }

    public static Fraction128 sin(Fraction128 angle)
    {
      return (Fraction128)System.Math.Sin((double)angle);

      // THE FOLLOWING IS PERSONAL SIN FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Sin Function
      //// get the angle to be within the unit circle
      //angle = angle % (TwoPi);

      //// if the angle is negative, inverse it against the full unit circle
      //if (angle < 0)
      //  angle = TwoPi + angle;

      //// adjust for quadrants
      //// NOTE: if you want more accuracy, you can follow this pattern
      //// sin(x) = x - x^3/3! + x^5/5! - x^7/7! ...
      //// the more terms you include the more accurate it is
      //float angleCubed;
      //float angleToTheFifth;
      //// quadrant 1
      //if (angle <= HalfPi)
      //{
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return angle
      //    - ((angleCubed) / 6)
      //    + ((angleToTheFifth) / 120);
      //}
      //// quadrant 2
      //else if (angle <= Pi)
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return angle
      //    - ((angleCubed) / 6)
      //    + ((angleToTheFifth) / 120);
      //}
      //// quadrant 3
      //else if (angle <= ThreeHalvesPi)
      //{
      //  angle = angle % Pi;
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return -(angle
      //      - ((angleCubed) / 6)
      //      + ((angleToTheFifth) / 120));
      //}
      //// quadrant 4  
      //else
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return -(angle
      //      - ((angleCubed) / 6)
      //      + ((angleToTheFifth) / 120));
      //}
      #endregion
    }

    public static Fraction128 cos(Fraction128 angle)
    {
      return (Fraction128)System.Math.Cos((double)angle);

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Cos Function
      //// If you wanted to be cheap, you could just use the following commented line...
      //// return Sin(angle + (Pi / 2));

      //// get the angle to be within the unit circle
      //angle = angle % (TwoPi);

      //// if the angle is negative, inverse it against the full unit circle
      //if (angle < 0)
      //  angle = TwoPi + angle;

      //// adjust for quadrants
      //// NOTE: if you want more accuracy, you can follow this pattern
      //// cos(x) = 1 - x^2/2! + x^4/4! - x^6/6! ...
      //// the terms you include the more accuracy it is
      //float angleSquared;
      //float angleToTheFourth;
      //float angleToTheSixth;
      //// quadrant 1
      //if (angle <= HalfPi)
      //{
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return 1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720);
      //}
      //// quadrant 2
      //else if (angle <= Pi)
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return -(1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720));
      //}
      //// quadrant 3
      //else if (angle <= ThreeHalvesPi)
      //{
      //  angle = angle % Pi;
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return -(1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720));
      //}
      //// quadrant 4  
      //else
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return 1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720);
      //}
      #endregion
    }

    public static Fraction128 tan(Fraction128 angle)
    {
      return (Fraction128)System.Math.Tan((double)angle);

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Tan Function
      //// "sin / cos" results in "opposite side / adjacent side", which is equal to tangent
      //return Sin(angle) / Cos(angle);
      #endregion
    }

    public static Fraction128 sec(Fraction128 angle)
    {
      return (Fraction128)(1d / System.Math.Cos((double)angle));

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Sec Function
      //// by definition, sec is the reciprical of cos
      //return 1 / Cos(angle);
      #endregion
    }

    public static Fraction128 csc(Fraction128 angle)
    {
      return (Fraction128)(1d / System.Math.Sin((double)angle));

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Csc Function
      //// by definition, csc is the reciprical of sin
      //return 1 / Sin(angle);
      #endregion
    }

    public static Fraction128 cot(Fraction128 angle)
    {
      return (Fraction128)(1.0d / System.Math.Tan((double)angle));

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Cot Function
      //// by definition, cot is the reciprical of tan
      //return 1 / Tan(angle);
      #endregion
    }

    public static Fraction128 arcsin(Fraction128 sinRatio)
    {
      return (Fraction128)System.Math.Asin((double)sinRatio);
      //I haven't made a custom ArcSin function yet...
    }

    public static Fraction128 arccos(Fraction128 cosRatio)
    {
      return (Fraction128)System.Math.Acos((double)cosRatio);
      //I haven't made a custom ArcCos function yet...
    }

    public static Fraction128 arctan(Fraction128 tanRatio)
    {
      return (Fraction128)System.Math.Atan((double)tanRatio);
      //I haven't made a custom ArcTan function yet...
    }

    public static Fraction128 arccsc(Fraction128 cscRatio)
    {
      return (Fraction128)System.Math.Asin(1.0d / (double)cscRatio);
      //I haven't made a custom ArcCsc function yet...
    }

    public static Fraction128 arcsec(Fraction128 secRatio)
    {
      return (Fraction128)System.Math.Acos(1.0d / (double)secRatio);
      //I haven't made a custom ArcSec function yet...
    }

    public static Fraction128 arccot(Fraction128 cotRatio)
    {
      return (Fraction128)System.Math.Atan(1.0d / (double)cotRatio);
      //I haven't made a custom ArcCot function yet...
    }

    #endregion

    #region Fraction64

    public static Fraction64 toRadians(Fraction64 angle)
    {
      return (Fraction64)((double)angle * Constants.pi_double / 180d);
    }

    public static Fraction64 toDegrees(Fraction64 angle)
    {
      return (Fraction64)((double)angle * 180d / Constants.pi_double);
    }

    public static Fraction64 sin(Fraction64 angle)
    {
      return (Fraction64)System.Math.Sin((double)angle);

      // THE FOLLOWING IS PERSONAL SIN FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Sin Function
      //// get the angle to be within the unit circle
      //angle = angle % (TwoPi);

      //// if the angle is negative, inverse it against the full unit circle
      //if (angle < 0)
      //  angle = TwoPi + angle;

      //// adjust for quadrants
      //// NOTE: if you want more accuracy, you can follow this pattern
      //// sin(x) = x - x^3/3! + x^5/5! - x^7/7! ...
      //// the more terms you include the more accurate it is
      //float angleCubed;
      //float angleToTheFifth;
      //// quadrant 1
      //if (angle <= HalfPi)
      //{
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return angle
      //    - ((angleCubed) / 6)
      //    + ((angleToTheFifth) / 120);
      //}
      //// quadrant 2
      //else if (angle <= Pi)
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return angle
      //    - ((angleCubed) / 6)
      //    + ((angleToTheFifth) / 120);
      //}
      //// quadrant 3
      //else if (angle <= ThreeHalvesPi)
      //{
      //  angle = angle % Pi;
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return -(angle
      //      - ((angleCubed) / 6)
      //      + ((angleToTheFifth) / 120));
      //}
      //// quadrant 4  
      //else
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return -(angle
      //      - ((angleCubed) / 6)
      //      + ((angleToTheFifth) / 120));
      //}
      #endregion
    }

    public static Fraction64 cos(Fraction64 angle)
    {
      return (Fraction64)System.Math.Cos((double)angle);

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Cos Function
      //// If you wanted to be cheap, you could just use the following commented line...
      //// return Sin(angle + (Pi / 2));

      //// get the angle to be within the unit circle
      //angle = angle % (TwoPi);

      //// if the angle is negative, inverse it against the full unit circle
      //if (angle < 0)
      //  angle = TwoPi + angle;

      //// adjust for quadrants
      //// NOTE: if you want more accuracy, you can follow this pattern
      //// cos(x) = 1 - x^2/2! + x^4/4! - x^6/6! ...
      //// the terms you include the more accuracy it is
      //float angleSquared;
      //float angleToTheFourth;
      //float angleToTheSixth;
      //// quadrant 1
      //if (angle <= HalfPi)
      //{
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return 1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720);
      //}
      //// quadrant 2
      //else if (angle <= Pi)
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return -(1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720));
      //}
      //// quadrant 3
      //else if (angle <= ThreeHalvesPi)
      //{
      //  angle = angle % Pi;
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return -(1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720));
      //}
      //// quadrant 4  
      //else
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return 1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720);
      //}
      #endregion
    }

    public static Fraction64 tan(Fraction64 angle)
    {
      return (Fraction64)System.Math.Tan((double)angle);

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Tan Function
      //// "sin / cos" results in "opposite side / adjacent side", which is equal to tangent
      //return Sin(angle) / Cos(angle);
      #endregion
    }

    public static Fraction64 sec(Fraction64 angle)
    {
      return (Fraction64)(1d / System.Math.Cos((double)angle));

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Sec Function
      //// by definition, sec is the reciprical of cos
      //return 1 / Cos(angle);
      #endregion
    }

    public static Fraction64 csc(Fraction64 angle)
    {
      return (Fraction64)(1d / System.Math.Sin((double)angle));

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Csc Function
      //// by definition, csc is the reciprical of sin
      //return 1 / Sin(angle);
      #endregion
    }

    public static Fraction64 cot(Fraction64 angle)
    {
      return (Fraction64)(1.0d / System.Math.Tan((double)angle));

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Cot Function
      //// by definition, cot is the reciprical of tan
      //return 1 / Tan(angle);
      #endregion
    }

    public static Fraction64 arcsin(Fraction64 sinRatio)
    {
      return (Fraction64)System.Math.Asin((double)sinRatio);
      //I haven't made a custom ArcSin function yet...
    }

    public static Fraction64 arccos(Fraction64 cosRatio)
    {
      return (Fraction64)System.Math.Acos((double)cosRatio);
      //I haven't made a custom ArcCos function yet...
    }

    public static Fraction64 arctan(Fraction64 tanRatio)
    {
      return (Fraction64)System.Math.Atan((double)tanRatio);
      //I haven't made a custom ArcTan function yet...
    }

    public static Fraction64 arccsc(Fraction64 cscRatio)
    {
      return (Fraction64)System.Math.Asin(1.0d / (double)cscRatio);
      //I haven't made a custom ArcCsc function yet...
    }

    public static Fraction64 arcsec(Fraction64 secRatio)
    {
      return (Fraction64)System.Math.Acos(1.0d / (double)secRatio);
      //I haven't made a custom ArcSec function yet...
    }

    public static Fraction64 arccot(Fraction64 cotRatio)
    {
      return (Fraction64)System.Math.Atan(1.0d / (double)cotRatio);
      //I haven't made a custom ArcCot function yet...
    }

    #endregion

    #region decimal

    public static decimal toRadians(decimal angle)
    {
      return (decimal)(angle * Constants.pi_decimal / 180M);
    }

    public static decimal toDegrees(decimal angle)
    {
      return (decimal)(angle * 180M / Constants.pi_decimal);
    }

    public static decimal sin(decimal angle)
    {
      return (decimal)System.Math.Sin((double)angle);

      // THE FOLLOWING IS PERSONAL SIN FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Sin Function
      //// get the angle to be within the unit circle
      //angle = angle % (TwoPi);

      //// if the angle is negative, inverse it against the full unit circle
      //if (angle < 0)
      //  angle = TwoPi + angle;

      //// adjust for quadrants
      //// NOTE: if you want more accuracy, you can follow this pattern
      //// sin(x) = x - x^3/3! + x^5/5! - x^7/7! ...
      //// the more terms you include the more accurate it is
      //float angleCubed;
      //float angleToTheFifth;
      //// quadrant 1
      //if (angle <= HalfPi)
      //{
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return angle
      //    - ((angleCubed) / 6)
      //    + ((angleToTheFifth) / 120);
      //}
      //// quadrant 2
      //else if (angle <= Pi)
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return angle
      //    - ((angleCubed) / 6)
      //    + ((angleToTheFifth) / 120);
      //}
      //// quadrant 3
      //else if (angle <= ThreeHalvesPi)
      //{
      //  angle = angle % Pi;
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return -(angle
      //      - ((angleCubed) / 6)
      //      + ((angleToTheFifth) / 120));
      //}
      //// quadrant 4  
      //else
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return -(angle
      //      - ((angleCubed) / 6)
      //      + ((angleToTheFifth) / 120));
      //}
      #endregion
    }

    public static decimal cos(decimal angle)
    {
      return (decimal)System.Math.Cos((double)angle);

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Cos Function
      //// If you wanted to be cheap, you could just use the following commented line...
      //// return Sin(angle + (Pi / 2));

      //// get the angle to be within the unit circle
      //angle = angle % (TwoPi);

      //// if the angle is negative, inverse it against the full unit circle
      //if (angle < 0)
      //  angle = TwoPi + angle;

      //// adjust for quadrants
      //// NOTE: if you want more accuracy, you can follow this pattern
      //// cos(x) = 1 - x^2/2! + x^4/4! - x^6/6! ...
      //// the terms you include the more accuracy it is
      //float angleSquared;
      //float angleToTheFourth;
      //float angleToTheSixth;
      //// quadrant 1
      //if (angle <= HalfPi)
      //{
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return 1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720);
      //}
      //// quadrant 2
      //else if (angle <= Pi)
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return -(1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720));
      //}
      //// quadrant 3
      //else if (angle <= ThreeHalvesPi)
      //{
      //  angle = angle % Pi;
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return -(1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720));
      //}
      //// quadrant 4  
      //else
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return 1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720);
      //}
      #endregion
    }

    public static decimal tan(decimal angle)
    {
      return (decimal)System.Math.Tan((double)angle);

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Tan Function
      //// "sin / cos" results in "opposite side / adjacent side", which is equal to tangent
      //return Sin(angle) / Cos(angle);
      #endregion
    }

    public static decimal sec(decimal angle)
    {
      return (decimal)(1d / System.Math.Cos((double)angle));

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Sec Function
      //// by definition, sec is the reciprical of cos
      //return 1 / Cos(angle);
      #endregion
    }

    public static decimal csc(decimal angle)
    {
      return (decimal)(1d / System.Math.Sin((double)angle));

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Csc Function
      //// by definition, csc is the reciprical of sin
      //return 1 / Sin(angle);
      #endregion
    }

    public static decimal cot(decimal angle)
    {
      return (decimal)(1.0d / System.Math.Tan((double)angle));

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Cot Function
      //// by definition, cot is the reciprical of tan
      //return 1 / Tan(angle);
      #endregion
    }

    public static decimal arcsin(decimal sinRatio)
    {
      return (decimal)System.Math.Asin((double)sinRatio);
      //I haven't made a custom ArcSin function yet...
    }

    public static decimal arccos(decimal cosRatio)
    {
      return (decimal)System.Math.Acos((double)cosRatio);
      //I haven't made a custom ArcCos function yet...
    }

    public static decimal arctan(decimal tanRatio)
    {
      return (decimal)System.Math.Atan((double)tanRatio);
      //I haven't made a custom ArcTan function yet...
    }

    public static decimal arccsc(decimal cscRatio)
    {
      return (decimal)System.Math.Asin(1.0d / (double)cscRatio);
      //I haven't made a custom ArcCsc function yet...
    }

    public static decimal arcsec(decimal secRatio)
    {
      return (decimal)System.Math.Acos(1.0d / (double)secRatio);
      //I haven't made a custom ArcSec function yet...
    }

    public static decimal arccot(decimal cotRatio)
    {
      return (decimal)System.Math.Atan(1.0d / (double)cotRatio);
      //I haven't made a custom ArcCot function yet...
    }

    #endregion

    #region double

    public static double toRadians(double angle)
    {
      return angle * Constants.pi_double / 180d;
    }

    public static double toDegrees(double angle)
    {
      return angle * 180d / Constants.pi_double;
    }

    public static double sin(double angle)
    {
      return System.Math.Sin(angle);

      // THE FOLLOWING IS PERSONAL SIN FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Sin Function
      //// get the angle to be within the unit circle
      //angle = angle % (TwoPi);

      //// if the angle is negative, inverse it against the full unit circle
      //if (angle < 0)
      //  angle = TwoPi + angle;

      //// adjust for quadrants
      //// NOTE: if you want more accuracy, you can follow this pattern
      //// sin(x) = x - x^3/3! + x^5/5! - x^7/7! ...
      //// the more terms you include the more accurate it is
      //float angleCubed;
      //float angleToTheFifth;
      //// quadrant 1
      //if (angle <= HalfPi)
      //{
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return angle
      //    - ((angleCubed) / 6)
      //    + ((angleToTheFifth) / 120);
      //}
      //// quadrant 2
      //else if (angle <= Pi)
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return angle
      //    - ((angleCubed) / 6)
      //    + ((angleToTheFifth) / 120);
      //}
      //// quadrant 3
      //else if (angle <= ThreeHalvesPi)
      //{
      //  angle = angle % Pi;
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return -(angle
      //      - ((angleCubed) / 6)
      //      + ((angleToTheFifth) / 120));
      //}
      //// quadrant 4  
      //else
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return -(angle
      //      - ((angleCubed) / 6)
      //      + ((angleToTheFifth) / 120));
      //}
      #endregion
    }

    public static double cos(double angle)
    {
      return System.Math.Cos(angle);

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Cos Function
      //// If you wanted to be cheap, you could just use the following commented line...
      //// return Sin(angle + (Pi / 2));

      //// get the angle to be within the unit circle
      //angle = angle % (TwoPi);

      //// if the angle is negative, inverse it against the full unit circle
      //if (angle < 0)
      //  angle = TwoPi + angle;

      //// adjust for quadrants
      //// NOTE: if you want more accuracy, you can follow this pattern
      //// cos(x) = 1 - x^2/2! + x^4/4! - x^6/6! ...
      //// the terms you include the more accuracy it is
      //float angleSquared;
      //float angleToTheFourth;
      //float angleToTheSixth;
      //// quadrant 1
      //if (angle <= HalfPi)
      //{
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return 1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720);
      //}
      //// quadrant 2
      //else if (angle <= Pi)
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return -(1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720));
      //}
      //// quadrant 3
      //else if (angle <= ThreeHalvesPi)
      //{
      //  angle = angle % Pi;
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return -(1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720));
      //}
      //// quadrant 4  
      //else
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return 1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720);
      //}
      #endregion
    }

    public static double tan(double angle)
    {
      return System.Math.Tan(angle);

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Tan Function
      //// "sin / cos" results in "opposite side / adjacent side", which is equal to tangent
      //return Sin(angle) / Cos(angle);
      #endregion
    }

    public static double sec(double angle)
    {
      return 1.0f / (double)System.Math.Cos(angle);

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Sec Function
      //// by definition, sec is the reciprical of cos
      //return 1 / Cos(angle);
      #endregion
    }

    public static double csc(double angle)
    {
      return 1.0d / System.Math.Sin(angle);

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Csc Function
      //// by definition, csc is the reciprical of sin
      //return 1 / Sin(angle);
      #endregion
    }

    public static double cot(double angle)
    {
      return 1.0d / System.Math.Tan(angle);

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Cot Function
      //// by definition, cot is the reciprical of tan
      //return 1 / Tan(angle);
      #endregion
    }

    public static double arcsin(double sinRatio)
    {
      return System.Math.Asin(sinRatio);
      //I haven't made a custom ArcSin function yet...
    }

    public static double arccos(double cosRatio)
    {
      return System.Math.Acos(cosRatio);
      //I haven't made a custom ArcCos function yet...
    }

    public static double arctan(double tanRatio)
    {
      return System.Math.Atan(tanRatio);
      //I haven't made a custom ArcTan function yet...
    }

    public static double arccsc(double cscRatio)
    {
      return System.Math.Asin(1.0d / cscRatio);
      //I haven't made a custom ArcCsc function yet...
    }

    public static double arcsec(double secRatio)
    {
      return System.Math.Acos(1.0d / secRatio);
      //I haven't made a custom ArcSec function yet...
    }

    public static double arccot(double cotRatio)
    {
      return System.Math.Atan(1.0d / cotRatio);
      //I haven't made a custom ArcCot function yet...
    }

    #endregion

    #region float

    public static float toRadians(float angle)
    {
      return angle * Constants.pi_float / 180f;
    }

    public static float toDegrees(float angle)
    {
      return angle * 180f / Constants.pi_float;
    }

    public static float sin(float angle)
    {
      return (float)System.Math.Sin(angle);

      // THE FOLLOWING IS PERSONAL SIN FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Sin Function
      //// get the angle to be within the unit circle
      //angle = angle % (TwoPi);

      //// if the angle is negative, inverse it against the full unit circle
      //if (angle < 0)
      //  angle = TwoPi + angle;

      //// adjust for quadrants
      //// NOTE: if you want more accuracy, you can follow this pattern
      //// sin(x) = x - x^3/3! + x^5/5! - x^7/7! ...
      //// the more terms you include the more accurate it is
      //float angleCubed;
      //float angleToTheFifth;
      //// quadrant 1
      //if (angle <= HalfPi)
      //{
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return angle
      //    - ((angleCubed) / 6)
      //    + ((angleToTheFifth) / 120);
      //}
      //// quadrant 2
      //else if (angle <= Pi)
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return angle
      //    - ((angleCubed) / 6)
      //    + ((angleToTheFifth) / 120);
      //}
      //// quadrant 3
      //else if (angle <= ThreeHalvesPi)
      //{
      //  angle = angle % Pi;
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return -(angle
      //      - ((angleCubed) / 6)
      //      + ((angleToTheFifth) / 120));
      //}
      //// quadrant 4  
      //else
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleCubed = angle * angle * angle;
      //  angleToTheFifth = angleCubed * angle * angle;
      //  return -(angle
      //      - ((angleCubed) / 6)
      //      + ((angleToTheFifth) / 120));
      //}
      #endregion
    }

    public static float cos(float angle)
    {
      return (float)System.Math.Cos(angle);

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Cos Function
      //// If you wanted to be cheap, you could just use the following commented line...
      //// return Sin(angle + (Pi / 2));

      //// get the angle to be within the unit circle
      //angle = angle % (TwoPi);

      //// if the angle is negative, inverse it against the full unit circle
      //if (angle < 0)
      //  angle = TwoPi + angle;

      //// adjust for quadrants
      //// NOTE: if you want more accuracy, you can follow this pattern
      //// cos(x) = 1 - x^2/2! + x^4/4! - x^6/6! ...
      //// the terms you include the more accuracy it is
      //float angleSquared;
      //float angleToTheFourth;
      //float angleToTheSixth;
      //// quadrant 1
      //if (angle <= HalfPi)
      //{
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return 1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720);
      //}
      //// quadrant 2
      //else if (angle <= Pi)
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return -(1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720));
      //}
      //// quadrant 3
      //else if (angle <= ThreeHalvesPi)
      //{
      //  angle = angle % Pi;
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return -(1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720));
      //}
      //// quadrant 4  
      //else
      //{
      //  angle = HalfPi - (angle % HalfPi);
      //  angleSquared = angle * angle;
      //  angleToTheFourth = angleSquared * angle * angle;
      //  angleToTheSixth = angleToTheFourth * angle * angle;
      //  return 1
      //    - (angleSquared / 2)
      //    + (angleToTheFourth / 24)
      //    - (angleToTheSixth / 720);
      //}
      #endregion
    }

    public static float tan(float angle)
    {
      return (float)System.Math.Tan(angle);

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Tan Function
      //// "sin / cos" results in "opposite side / adjacent side", which is equal to tangent
      //return Sin(angle) / Cos(angle);
      #endregion
    }

    public static float sec(float angle)
    {
      return 1.0f / (float)System.Math.Cos(angle);

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Sec Function
      //// by definition, sec is the reciprical of cos
      //return 1 / Cos(angle);
      #endregion
    }

    public static float csc(float angle)
    {
      return 1.0f / (float)System.Math.Sin(angle);

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Csc Function
      //// by definition, csc is the reciprical of sin
      //return 1 / Sin(angle);
      #endregion
    }

    public static float cot(float angle)
    {
      return 1.0f / (float)System.Math.Tan(angle);

      // THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
      // THE SYSTEM FUNCTION IN ITS CURRENT STATE
      #region Custom Cot Function
      //// by definition, cot is the reciprical of tan
      //return 1 / Tan(angle);
      #endregion
    }

    public static float arcsin(float sinRatio)
    {
      return (float)System.Math.Asin(sinRatio);
    }

    public static float arccos(float cosRatio)
    {
      return (float)System.Math.Acos(cosRatio);
    }

    public static float arctan(float tanRatio)
    {
      return (float)System.Math.Atan(tanRatio);
    }

    public static float arccsc(float cscRatio)
    {
      return (float)System.Math.Asin(1.0f / cscRatio);
    }

    public static float arcsec(float secRatio)
    {
      return (float)System.Math.Acos(1.0f / secRatio);
    }

    public static float arccot(float cotRatio)
    {
      return (float)Trigonometry.arctan(1.0f / cotRatio);
    }

    public static double sinh(double angle)
    {
      return (Algebra.exp(angle) - Algebra.exp(-angle)) / 2;
    }

    public static double cosh(double angle)
    {
      return (Algebra.exp(angle) + Algebra.exp(-angle)) / 2;
    }

    public static double tanh(double angle)
    {
      if (angle > 19.1)
        return 1.0;
      if (angle < -19.1)
        return -1;
      double e1 = Algebra.exp(angle);
      double e2 = Algebra.exp(-angle);
      return (e1 - e2) / (e1 + e2);
    }

    public static double coth(double angle)
    {
      if (angle > 19.115)
        return 1.0;
      if (angle < -19.115)
        return -1;
      double e1 = Algebra.exp(angle);
      double e2 = Algebra.exp(-angle);
      return (e1 + e2) / (e1 - e2);
    }

    public static double sech(double angle)
    {
      return 1d / Trigonometry.cosh(angle);
    }

    public static double csch(double angle)
    {
      return 1d / Trigonometry.sinh(angle);
    }

    public static double asinh(double value)
    {
      return Algebra.log(value + Algebra.sqrt((value * value) + 1), Constants.e_double);
    }

    public static double acosh(double value)
    {
      return Algebra.log(value + (Algebra.sqrt(value - 1d) * Algebra.sqrt(value + 1d)), Constants.e_double);
    }

    public static double atanh(double value)
    {
      return 0.5d * Algebra.log((1d + value) / (1d - value), Constants.e_double);
    }

    public static double acoth(double value)
    {
      return 0.5d * Algebra.log((value + 1d) / (value - 1d), Constants.e_double);
    }

    public static double asech(double value)
    {
      return Trigonometry.acosh(1d / value);
    }

    public static double acsch(double value)
    {
      return Trigonometry.asinh(1d / value);
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
