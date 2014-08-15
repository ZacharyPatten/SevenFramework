// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

using Seven.Structures;

namespace Seven.Mathematics.Syntax
{
  /// <summary>Syntax Sugar (yay hacks :P).</summary>
  public class _
  {
    // This class is just a syntax helper. Since you cannot add operators without
    // altering the C# compiler, this is as close as you'll get while still maintaining
    // fully compatible C# syntax, keep intellisense, and keep most type-checking.
    //
    // Numerics: 
    //   equ
    //   neg add sub mul div pow gdc
    //   ln log sqrt root exp inv
    //   sin cos tan sec csc cot asin acos atan acsc asec acot
    //   fact combin choos
    //
    // Vector:
    //   len
    //   equ
    //   neg add sub mul div
    //   dot cros norm mag mag2 angl
    //   lerp slerp blerp
    //
    // Matrix:
    //   row col
    //   equ
    //   neg add sub mul div pow
    //   det rref tran
    //
    // Quaternion:
    //   equ
    //   neg add sub mul div pow
    //   mag mag2 con add sub mul norm inv
    //   lerp slerp

    #region Fraction128

    #region arithmetic

    public static Fraction128 neg(Fraction128 i) { return Arithmetic.Negate(i); }
    public static Fraction128 add(Fraction128 l, Fraction128 r) { return Arithmetic.Add(l, r); }
    public static Fraction128 sub(Fraction128 l, Fraction128 r) { return Arithmetic.Subtract(l, r); }
    public static Fraction128 mul(Fraction128 l, Fraction128 r) { return Arithmetic.Multiply(l, r); }
    public static Fraction128 div(Fraction128 l, Fraction128 r) { return Arithmetic.Divide(l, r); }
    public static Fraction128 pow(Fraction128 l, Fraction128 r) { return Arithmetic.Power(l, r); }

    #endregion

    #region algebra

    public static Fraction128 ln(Fraction128 n) { return Algebra.ln(n); }
    public static Fraction128 log(Fraction128 n, Fraction128 b) { return Algebra.log(n, b); }
    public static Fraction128 sqrt(Fraction128 b) { return Algebra.sqrt(b); }
    public static Fraction128 root(Fraction128 b, Fraction128 r) { return Algebra.root(b, r); }
    public static Fraction128 exp(Fraction128 x) { return Algebra.exp(x); }
    public static Fraction128 inv(Fraction128 n) { return Algebra.invert_mult(n); }

    #endregion

    #region linear algebra

    #region vector

    public static int len(Vector<Fraction128> a) { return a.Dimensions; }
    public static Vector<Fraction128> add(Vector<Fraction128> l, Vector<Fraction128> r) { return LinearAlgebra.Add(l, r); }
    public static Vector<Fraction128> neg(Vector<Fraction128> a) { return LinearAlgebra.Negate(a); }
    public static Vector<Fraction128> sub(Vector<Fraction128> l, Vector<Fraction128> r) { return LinearAlgebra.Subtract(l, r); }
    public static Vector<Fraction128> mul(Vector<Fraction128> l, Fraction128 r) { return LinearAlgebra.Multiply(l, r); }
    public static Vector<Fraction128> mul(Fraction128 l, Vector<Fraction128> r) { return LinearAlgebra.Multiply(r, l); }
    public static Vector<Fraction128> div(Vector<Fraction128> l, Fraction128 r) { return LinearAlgebra.Divide(l, r); }
    public static Vector<Fraction128> div(Fraction128 l, Vector<Fraction128> r) { return LinearAlgebra.Divide(r, l); }
    public static Fraction128 dot(Vector<Fraction128> l, Vector<Fraction128> r) { return LinearAlgebra.DotProduct(l, r); }
    public static Vector<Fraction128> cros(Vector<Fraction128> l, Vector<Fraction128> r) { return LinearAlgebra.CrossProduct(l, r); }
    public static Vector<Fraction128> norm(Vector<Fraction128> a) { return LinearAlgebra.Normalize(a); }
    public static Fraction128 mag(Vector<Fraction128> a) { return LinearAlgebra.Magnitude(a); }
    public static Fraction128 mag2(Vector<Fraction128> a) { return LinearAlgebra.MagnitudeSquared(a); }
    public static Fraction128 angl(Vector<Fraction128> l, Vector<Fraction128> r) { return LinearAlgebra.Angle(l, r); }
    public static Vector<Fraction128> rot(Vector<Fraction128> a, Fraction128 angle, Fraction128 x, Fraction128 y, Fraction128 z) { return LinearAlgebra.RotateBy(a, angle, x, y, z); }
    public static Vector<Fraction128> lerp(Vector<Fraction128> a, Vector<Fraction128> b, Fraction128 c) { return LinearAlgebra.Lerp(a, b, c); }
    public static Vector<Fraction128> slerp(Vector<Fraction128> a, Vector<Fraction128> b, Fraction128 c) { return LinearAlgebra.Slerp(a, b, c); }
    public static Vector<Fraction128> blerp(Vector<Fraction128> a, Vector<Fraction128> b, Vector<Fraction128> c, Fraction128 u, Fraction128 v) { return LinearAlgebra.Blerp(a, b, c, u, v); }
    public static bool equ(Vector<Fraction128> l, Vector<Fraction128> r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Vector<Fraction128> a, Vector<Fraction128> b, Fraction128 c) { return LinearAlgebra.EqualsValue(a, b, c); }

    #endregion

    #region matrix

    public static int row(Matrix<Fraction128> a) { return a.Rows; }
    public static int col(Matrix<Fraction128> a) { return a.Columns; }
    public static Matrix<Fraction128> neg(Matrix<Fraction128> a) { return LinearAlgebra.Negate(a); }
    public static Matrix<Fraction128> add(Matrix<Fraction128> l, Matrix<Fraction128> r) { return LinearAlgebra.Add(l, r); }
    public static Matrix<Fraction128> sub(Matrix<Fraction128> l, Matrix<Fraction128> r) { return LinearAlgebra.Subtract(l, r); }
    public static Matrix<Fraction128> mul(Matrix<Fraction128> l, Matrix<Fraction128> r) { return LinearAlgebra.Multiply(l, r); }
    public static Matrix<Fraction128> mul(Matrix<Fraction128> l, Fraction128 r) { return LinearAlgebra.Multiply(l, r); }
    public static Vector<Fraction128> mul(Matrix<Fraction128> l, Vector<Fraction128> r) { return LinearAlgebra.Multiply(l, r); }
    public static Matrix<Fraction128> div(Matrix<Fraction128> l, Fraction128 r) { return LinearAlgebra.Divide(l, r); }
    public static Matrix<Fraction128> pow(Matrix<Fraction128> a, int p) { return LinearAlgebra.Power(a, p); }
    public static Fraction128 det(Matrix<Fraction128> a) { return LinearAlgebra.Determinent(a); }
    public static Matrix<Fraction128> rref(Matrix<Fraction128> a) { return LinearAlgebra.ReducedEchelon(a); }
    public static Matrix<Fraction128> inv(Matrix<Fraction128> a) { return LinearAlgebra.Inverse(a); }
    public static Matrix<Fraction128> tran(Matrix<Fraction128> a) { return LinearAlgebra.Transpose(a); }
    public static bool equ(Matrix<Fraction128> l, Matrix<Fraction128> r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Matrix<Fraction128> l, Matrix<Fraction128> r, Fraction128 c) { return LinearAlgebra.EqualsValue(l, r, c); }

    #endregion

    #region quaternion

    //LinearAlgebra.delegates.Quaternion_Magnitude<T> Quaternion_Magnitude { get; }
    //LinearAlgebra.delegates.Quaternion_MagnitudeSquared<T> _Quaternion_MagnitudeSquared { get; }
    //LinearAlgebra.delegates.Quaternion_Conjugate<T> Quaternion_Conjugate { get; }
    //LinearAlgebra.delegates.Quaternion_Add<T> Quaternion_Add { get; }
    //LinearAlgebra.delegates.Quaternion_Subtract<T> Quaternion_Subtract { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply<T> Quaternion_Multiply { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply_scalar<T> Quaternion_Multiply_scalar { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply_Vector<T> Multiply_Vector { get; }
    //LinearAlgebra.delegates.Quaternion_Normalize<T> Quaternion_Normalize { get; }
    //LinearAlgebra.delegates.Quaternion_Invert<T> Quaternion_Invert { get; }
    //LinearAlgebra.delegates.Quaternion_Lerp<T> Quaternion_Lerp { get; }
    //LinearAlgebra.delegates.Quaternion_Slerp<T> Quaternion_Slerp { get; }
    //LinearAlgebra.delegates.Quaternion_Rotate<T> Quaternion_Rotate { get; }
    //LinearAlgebra.delegates.Quaternion_EqualsValue<T> Quaternion_EqualsValue { get; }
    //LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<T> Quaternion_EqualsValue_leniency { get; }

    #endregion

    #endregion

    #region combinatorics

    ///// <summary>Computes: [ N! ].</summary>
    ///// <param name="N">The number to compute the factorial of.</param>
    ///// <returns>[ N! ]</returns>
    //public static Fraction128 fact(Fraction128 N) { return Combinatorics.Factorial(N); }
    ///// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
    ///// <param name="N">The total number of items in the set.</param>
    ///// <param name="n">The number of items in the respective sub-sets.</param>
    ///// <returns>[ N! / (n[0]! + n[1]! + n[3]! ...) ]</returns>
    //public static Fraction128 combin(Fraction128 N, params Vector<Fraction128> n) { return Combinatorics.Combinations(N, n); }
    ///// <summary>Computes: [ N! / (N - n)! ]</summary>
    ///// <param name="N">The total number of items.</param>
    ///// <param name="n">The number of items to choose.</param>
    ///// <returns>[ N! / (N - n)! ]</returns>
    //public static Fraction128 choose(Fraction128 N, Fraction128 n) { return Combinatorics.Choose(N, n); }

    #endregion

    #region trigonometry

    public static Fraction128 sin(Fraction128 a) { return Trigonometry.sin(a); }
    public static Fraction128 cos(Fraction128 a) { return Trigonometry.cos(a); }
    public static Fraction128 tan(Fraction128 a) { return Trigonometry.tan(a); }
    public static Fraction128 sec(Fraction128 a) { return Trigonometry.sec(a); }
    public static Fraction128 csc(Fraction128 a) { return Trigonometry.csc(a); }
    public static Fraction128 cot(Fraction128 a) { return Trigonometry.cot(a); }
    public static Fraction128 asin(Fraction128 r) { return Trigonometry.arcsin(r); }
    public static Fraction128 acos(Fraction128 r) { return Trigonometry.arccos(r); }
    public static Fraction128 atan(Fraction128 r) { return Trigonometry.arctan(r); }
    public static Fraction128 acsc(Fraction128 r) { return Trigonometry.arccsc(r); }
    public static Fraction128 asec(Fraction128 r) { return Trigonometry.arcsec(r); }
    public static Fraction128 acot(Fraction128 r) { return Trigonometry.arccot(r); }

    #endregion

    #endregion

    #region Fraction64

    #region arithmetic

    public static Fraction64 neg(Fraction64 i) { return Arithmetic.Negate(i); }
    public static Fraction64 add(Fraction64 l, Fraction64 r) { return Arithmetic.Add(l, r); }
    public static Fraction64 sub(Fraction64 l, Fraction64 r) { return Arithmetic.Subtract(l, r); }
    public static Fraction64 mul(Fraction64 l, Fraction64 r) { return Arithmetic.Multiply(l, r); }
    public static Fraction64 div(Fraction64 l, Fraction64 r) { return Arithmetic.Divide(l, r); }
    public static Fraction64 pow(Fraction64 l, Fraction64 r) { return Arithmetic.Power(l, r); }

    #endregion

    #region algebra

    public static Fraction64 ln(Fraction64 n) { return Algebra.ln(n); }
    public static Fraction64 log(Fraction64 n, Fraction64 b) { return Algebra.log(n, b); }
    public static Fraction64 sqrt(Fraction64 b) { return Algebra.sqrt(b); }
    public static Fraction64 root(Fraction64 b, Fraction64 r) { return Algebra.root(b, r); }
    public static Fraction64 exp(Fraction64 x) { return Algebra.exp(x); }
    public static Fraction64 inv(Fraction64 n) { return Algebra.invert_mult(n); }

    #endregion

    #region linear algebra

    #region vector

    public static int len(Vector<Fraction64> a) { return a.Dimensions; }
    public static Vector<Fraction64> add(Vector<Fraction64> l, Vector<Fraction64> r) { return LinearAlgebra.Add(l, r); }
    public static Vector<Fraction64> neg(Vector<Fraction64> a) { return LinearAlgebra.Negate(a); }
    public static Vector<Fraction64> sub(Vector<Fraction64> l, Vector<Fraction64> r) { return LinearAlgebra.Subtract(l, r); }
    public static Vector<Fraction64> mul(Vector<Fraction64> l, Fraction64 r) { return LinearAlgebra.Multiply(l, r); }
    public static Vector<Fraction64> mul(Fraction64 l, Vector<Fraction64> r) { return LinearAlgebra.Multiply(r, l); }
    public static Vector<Fraction64> div(Vector<Fraction64> l, Fraction64 r) { return LinearAlgebra.Divide(l, r); }
    public static Vector<Fraction64> div(Fraction64 l, Vector<Fraction64> r) { return LinearAlgebra.Divide(r, l); }
    public static Fraction64 dot(Vector<Fraction64> l, Vector<Fraction64> r) { return LinearAlgebra.DotProduct(l, r); }
    public static Vector<Fraction64> cros(Vector<Fraction64> l, Vector<Fraction64> r) { return LinearAlgebra.CrossProduct(l, r); }
    public static Vector<Fraction64> norm(Vector<Fraction64> a) { return LinearAlgebra.Normalize(a); }
    public static Fraction64 mag(Vector<Fraction64> a) { return LinearAlgebra.Magnitude(a); }
    public static Fraction64 mag2(Vector<Fraction64> a) { return LinearAlgebra.MagnitudeSquared(a); }
    public static Fraction64 angl(Vector<Fraction64> l, Vector<Fraction64> r) { return LinearAlgebra.Angle(l, r); }
    public static Vector<Fraction64> rot(Vector<Fraction64> a, Fraction64 angle, Fraction64 x, Fraction64 y, Fraction64 z) { return LinearAlgebra.RotateBy(a, angle, x, y, z); }
    public static Vector<Fraction64> lerp(Vector<Fraction64> a, Vector<Fraction64> b, Fraction64 c) { return LinearAlgebra.Lerp(a, b, c); }
    public static Vector<Fraction64> slerp(Vector<Fraction64> a, Vector<Fraction64> b, Fraction64 c) { return LinearAlgebra.Slerp(a, b, c); }
    public static Vector<Fraction64> blerp(Vector<Fraction64> a, Vector<Fraction64> b, Vector<Fraction64> c, Fraction64 u, Fraction64 v) { return LinearAlgebra.Blerp(a, b, c, u, v); }
    public static bool equ(Vector<Fraction64> l, Vector<Fraction64> r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Vector<Fraction64> a, Vector<Fraction64> b, Fraction64 c) { return LinearAlgebra.EqualsValue(a, b, c); }

    #endregion

    #region matrix

    public static int row(Matrix<Fraction64> a) { return a.Rows; }
    public static int col(Matrix<Fraction64> a) { return a.Columns; }
    public static Matrix<Fraction64> neg(Matrix<Fraction64> a) { return LinearAlgebra.Negate(a); }
    public static Matrix<Fraction64> add(Matrix<Fraction64> l, Matrix<Fraction64> r) { return LinearAlgebra.Add(l, r); }
    public static Matrix<Fraction64> sub(Matrix<Fraction64> l, Matrix<Fraction64> r) { return LinearAlgebra.Subtract(l, r); }
    public static Matrix<Fraction64> mul(Matrix<Fraction64> l, Matrix<Fraction64> r) { return LinearAlgebra.Multiply(l, r); }
    public static Matrix<Fraction64> mul(Matrix<Fraction64> l, Fraction64 r) { return LinearAlgebra.Multiply(l, r); }
    public static Vector<Fraction64> mul(Matrix<Fraction64> l, Vector<Fraction64> r) { return LinearAlgebra.Multiply(l, r); }
    public static Matrix<Fraction64> div(Matrix<Fraction64> l, Fraction64 r) { return LinearAlgebra.Divide(l, r); }
    public static Matrix<Fraction64> pow(Matrix<Fraction64> a, int p) { return LinearAlgebra.Power(a, p); }
    public static Fraction64 det(Matrix<Fraction64> a) { return LinearAlgebra.Determinent(a); }
    public static Matrix<Fraction64> rref(Matrix<Fraction64> a) { return LinearAlgebra.ReducedEchelon(a); }
    public static Matrix<Fraction64> inv(Matrix<Fraction64> a) { return LinearAlgebra.Inverse(a); }
    public static Matrix<Fraction64> tran(Matrix<Fraction64> a) { return LinearAlgebra.Transpose(a); }
    public static bool equ(Matrix<Fraction64> l, Matrix<Fraction64> r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Matrix<Fraction64> l, Matrix<Fraction64> r, Fraction64 c) { return LinearAlgebra.EqualsValue(l, r, c); }

    #endregion

    #region quaternion

    //LinearAlgebra.delegates.Quaternion_Magnitude<T> Quaternion_Magnitude { get; }
    //LinearAlgebra.delegates.Quaternion_MagnitudeSquared<T> _Quaternion_MagnitudeSquared { get; }
    //LinearAlgebra.delegates.Quaternion_Conjugate<T> Quaternion_Conjugate { get; }
    //LinearAlgebra.delegates.Quaternion_Add<T> Quaternion_Add { get; }
    //LinearAlgebra.delegates.Quaternion_Subtract<T> Quaternion_Subtract { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply<T> Quaternion_Multiply { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply_scalar<T> Quaternion_Multiply_scalar { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply_Vector<T> Multiply_Vector { get; }
    //LinearAlgebra.delegates.Quaternion_Normalize<T> Quaternion_Normalize { get; }
    //LinearAlgebra.delegates.Quaternion_Invert<T> Quaternion_Invert { get; }
    //LinearAlgebra.delegates.Quaternion_Lerp<T> Quaternion_Lerp { get; }
    //LinearAlgebra.delegates.Quaternion_Slerp<T> Quaternion_Slerp { get; }
    //LinearAlgebra.delegates.Quaternion_Rotate<T> Quaternion_Rotate { get; }
    //LinearAlgebra.delegates.Quaternion_EqualsValue<T> Quaternion_EqualsValue { get; }
    //LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<T> Quaternion_EqualsValue_leniency { get; }

    #endregion

    #endregion

    #region combinatorics

    ///// <summary>Computes: [ N! ].</summary>
    ///// <param name="N">The number to compute the factorial of.</param>
    ///// <returns>[ N! ]</returns>
    //public static Fraction64 fact(Fraction64 N) { return Combinatorics.Factorial(N); }
    ///// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
    ///// <param name="N">The total number of items in the set.</param>
    ///// <param name="n">The number of items in the respective sub-sets.</param>
    ///// <returns>[ N! / (n[0]! + n[1]! + n[3]! ...) ]</returns>
    //public static Fraction64 combin(Fraction64 N, params Vector<Fraction64> n) { return Combinatorics.Combinations(N, n); }
    ///// <summary>Computes: [ N! / (N - n)! ]</summary>
    ///// <param name="N">The total number of items.</param>
    ///// <param name="n">The number of items to choose.</param>
    ///// <returns>[ N! / (N - n)! ]</returns>
    //public static Fraction64 choose(Fraction64 N, Fraction64 n) { return Combinatorics.Choose(N, n); }

    #endregion

    #region trigonometry

    public static Fraction64 sin(Fraction64 a) { return Trigonometry.sin(a); }
    public static Fraction64 cos(Fraction64 a) { return Trigonometry.cos(a); }
    public static Fraction64 tan(Fraction64 a) { return Trigonometry.tan(a); }
    public static Fraction64 sec(Fraction64 a) { return Trigonometry.sec(a); }
    public static Fraction64 csc(Fraction64 a) { return Trigonometry.csc(a); }
    public static Fraction64 cot(Fraction64 a) { return Trigonometry.cot(a); }
    public static Fraction64 asin(Fraction64 r) { return Trigonometry.arcsin(r); }
    public static Fraction64 acos(Fraction64 r) { return Trigonometry.arccos(r); }
    public static Fraction64 atan(Fraction64 r) { return Trigonometry.arctan(r); }
    public static Fraction64 acsc(Fraction64 r) { return Trigonometry.arccsc(r); }
    public static Fraction64 asec(Fraction64 r) { return Trigonometry.arcsec(r); }
    public static Fraction64 acot(Fraction64 r) { return Trigonometry.arccot(r); }

    #endregion

    #endregion

    #region decimal

    #region arithmetic

    public static decimal neg(decimal i) { return Arithmetic.Negate(i); }
    public static decimal add(decimal l, decimal r) { return Arithmetic.Add(l, r); }
    public static decimal sub(decimal l, decimal r) { return Arithmetic.Subtract(l, r); }
    public static decimal mul(decimal l, decimal r) { return Arithmetic.Multiply(l, r); }
    public static decimal div(decimal l, decimal r) { return Arithmetic.Divide(l, r); }
    public static decimal pow(decimal l, decimal r) { return Arithmetic.Power(l, r); }

    #endregion

    #region algebra

    public static decimal ln(decimal n) { return Algebra.ln(n); }
    public static decimal log(decimal n, decimal b) { return Algebra.log(n, b); }
    public static decimal sqrt(decimal b) { return Algebra.sqrt(b); }
    public static decimal root(decimal b, decimal r) { return Algebra.root(b, r); }
    public static decimal exp(decimal x) { return Algebra.exp(x); }
    public static decimal inv(decimal n) { return Algebra.invert_mult(n); }

    #endregion

    #region linear algebra

    #region vector

    public static int len(Vector<decimal> a) { return a.Dimensions; }
    public static Vector<decimal> add(Vector<decimal> l, Vector<decimal> r) { return LinearAlgebra.Add(l, r); }
    public static Vector<decimal> neg(Vector<decimal> a) { return LinearAlgebra.Negate(a); }
    public static Vector<decimal> sub(Vector<decimal> l, Vector<decimal> r) { return LinearAlgebra.Subtract(l, r); }
    public static Vector<decimal> mul(Vector<decimal> l, decimal r) { return LinearAlgebra.Multiply(l, r); }
    public static Vector<decimal> mul(decimal l, Vector<decimal> r) { return LinearAlgebra.Multiply(r, l); }
    public static Vector<decimal> div(Vector<decimal> l, decimal r) { return LinearAlgebra.Divide(l, r); }
    public static Vector<decimal> div(decimal l, Vector<decimal> r) { return LinearAlgebra.Divide(r, l); }
    public static decimal dot(Vector<decimal> l, Vector<decimal> r) { return LinearAlgebra.DotProduct(l, r); }
    public static Vector<decimal> cros(Vector<decimal> l, Vector<decimal> r) { return LinearAlgebra.CrossProduct(l, r); }
    public static Vector<decimal> norm(Vector<decimal> a) { return LinearAlgebra.Normalize(a); }
    public static decimal mag(Vector<decimal> a) { return LinearAlgebra.Magnitude(a); }
    public static decimal mag2(Vector<decimal> a) { return LinearAlgebra.MagnitudeSquared(a); }
    public static decimal angl(Vector<decimal> l, Vector<decimal> r) { return LinearAlgebra.Angle(l, r); }
    public static Vector<decimal> rot(Vector<decimal> a, decimal angle, decimal x, decimal y, decimal z) { return LinearAlgebra.RotateBy(a, angle, x, y, z); }
    public static Vector<decimal> lerp(Vector<decimal> a, Vector<decimal> b, decimal c) { return LinearAlgebra.Lerp(a, b, c); }
    public static Vector<decimal> slerp(Vector<decimal> a, Vector<decimal> b, decimal c) { return LinearAlgebra.Slerp(a, b, c); }
    public static Vector<decimal> blerp(Vector<decimal> a, Vector<decimal> b, Vector<decimal> c, decimal u, decimal v) { return LinearAlgebra.Blerp(a, b, c, u, v); }
    public static bool equ(Vector<decimal> l, Vector<decimal> r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Vector<decimal> a, Vector<decimal> b, decimal c) { return LinearAlgebra.EqualsValue(a, b, c); }

    #endregion

    #region matrix

    public static int row(Matrix<decimal> a) { return a.Rows; }
    public static int col(Matrix<decimal> a) { return a.Columns; }
    public static Matrix<decimal> neg(Matrix<decimal> a) { return LinearAlgebra.Negate(a); }
    public static Matrix<decimal> add(Matrix<decimal> l, Matrix<decimal> r) { return LinearAlgebra.Add(l, r); }
    public static Matrix<decimal> sub(Matrix<decimal> l, Matrix<decimal> r) { return LinearAlgebra.Subtract(l, r); }
    public static Matrix<decimal> mul(Matrix<decimal> l, Matrix<decimal> r) { return LinearAlgebra.Multiply(l, r); }
    public static Matrix<decimal> mul(Matrix<decimal> l, decimal r) { return LinearAlgebra.Multiply(l, r); }
    public static Vector<decimal> mul(Matrix<decimal> l, Vector<decimal> r) { return LinearAlgebra.Multiply(l, r); }
    public static Matrix<decimal> div(Matrix<decimal> l, decimal r) { return LinearAlgebra.Divide(l, r); }
    public static Matrix<decimal> pow(Matrix<decimal> a, int p) { return LinearAlgebra.Power(a, p); }
    public static decimal det(Matrix<decimal> a) { return LinearAlgebra.Determinent(a); }
    public static Matrix<decimal> rref(Matrix<decimal> a) { return LinearAlgebra.ReducedEchelon(a); }
    public static Matrix<decimal> inv(Matrix<decimal> a) { return LinearAlgebra.Inverse(a); }
    public static Matrix<decimal> tran(Matrix<decimal> a) { return LinearAlgebra.Transpose(a); }
    public static bool equ(Matrix<decimal> l, Matrix<decimal> r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Matrix<decimal> l, Matrix<decimal> r, decimal c) { return LinearAlgebra.EqualsValue(l, r, c); }

    #endregion

    #region quaternion

    //LinearAlgebra.delegates.Quaternion_Magnitude<T> Quaternion_Magnitude { get; }
    //LinearAlgebra.delegates.Quaternion_MagnitudeSquared<T> _Quaternion_MagnitudeSquared { get; }
    //LinearAlgebra.delegates.Quaternion_Conjugate<T> Quaternion_Conjugate { get; }
    //LinearAlgebra.delegates.Quaternion_Add<T> Quaternion_Add { get; }
    //LinearAlgebra.delegates.Quaternion_Subtract<T> Quaternion_Subtract { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply<T> Quaternion_Multiply { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply_scalar<T> Quaternion_Multiply_scalar { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply_Vector<T> Multiply_Vector { get; }
    //LinearAlgebra.delegates.Quaternion_Normalize<T> Quaternion_Normalize { get; }
    //LinearAlgebra.delegates.Quaternion_Invert<T> Quaternion_Invert { get; }
    //LinearAlgebra.delegates.Quaternion_Lerp<T> Quaternion_Lerp { get; }
    //LinearAlgebra.delegates.Quaternion_Slerp<T> Quaternion_Slerp { get; }
    //LinearAlgebra.delegates.Quaternion_Rotate<T> Quaternion_Rotate { get; }
    //LinearAlgebra.delegates.Quaternion_EqualsValue<T> Quaternion_EqualsValue { get; }
    //LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<T> Quaternion_EqualsValue_leniency { get; }

    #endregion

    #endregion

    #region combinatorics

    /// <summary>Computes: [ N! ].</summary>
    /// <param name="N">The number to compute the factorial of.</param>
    /// <returns>[ N! ]</returns>
    public static decimal fact(decimal N) { return Combinatorics.Factorial(N); }
    /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
    /// <param name="N">The total number of items in the set.</param>
    /// <param name="n">The number of items in the respective sub-sets.</param>
    /// <returns>[ N! / (n[0]! + n[1]! + n[3]! ...) ]</returns>
    public static decimal combin(decimal N, params decimal[] n) { return Combinatorics.Combinations(N, n); }
    /// <summary>Computes: [ N! / (N - n)! ]</summary>
    /// <param name="N">The total number of items.</param>
    /// <param name="n">The number of items to choose.</param>
    /// <returns>[ N! / (N - n)! ]</returns>
    public static decimal choose(decimal N, decimal n) { return Combinatorics.Choose(N, n); }

    #endregion

    #region trigonometry

    public static decimal sin(decimal a) { return Trigonometry.sin(a); }
    public static decimal cos(decimal a) { return Trigonometry.cos(a); }
    public static decimal tan(decimal a) { return Trigonometry.tan(a); }
    public static decimal sec(decimal a) { return Trigonometry.sec(a); }
    public static decimal csc(decimal a) { return Trigonometry.csc(a); }
    public static decimal cot(decimal a) { return Trigonometry.cot(a); }
    public static decimal asin(decimal r) { return Trigonometry.arcsin(r); }
    public static decimal acos(decimal r) { return Trigonometry.arccos(r); }
    public static decimal atan(decimal r) { return Trigonometry.arctan(r); }
    public static decimal acsc(decimal r) { return Trigonometry.arccsc(r); }
    public static decimal asec(decimal r) { return Trigonometry.arcsec(r); }
    public static decimal acot(decimal r) { return Trigonometry.arccot(r); }

    #endregion

    #endregion

    #region double

    #region arithmetic

    public static double neg(double i) { return Arithmetic.Negate(i); }
    public static double add(double l, double r) { return Arithmetic.Add(l, r); }
    public static double sub(double l, double r) { return Arithmetic.Subtract(l, r); }
    public static double mul(double l, double r) { return Arithmetic.Multiply(l, r); }
    public static double div(double l, double r) { return Arithmetic.Divide(l, r); }
    public static double pow(double l, double r) { return Arithmetic.Power(l, r); }

    #endregion

    #region algebra

    public static double ln(double n) { return Algebra.ln(n); }
    public static double log(double n, double b) { return Algebra.log(n, b); }
    public static double sqrt(double b) { return Algebra.sqrt(b); }
    public static double root(double b, double r) { return Algebra.root(b, r); }
    public static double exp(double x) { return Algebra.exp(x); }
    public static double inv(double n) { return Algebra.invert_mult(n); }

    #endregion

    #region linear algebra

    #region vector

    public static int len(Vector<double> a) { return a.Dimensions; }
    public static Vector<double> add(Vector<double> l, Vector<double> r) { return LinearAlgebra.Add(l, r); }
    public static Vector<double> neg(Vector<double> a) { return LinearAlgebra.Negate(a); }
    public static Vector<double> sub(Vector<double> l, Vector<double> r) { return LinearAlgebra.Subtract(l, r); }
    public static Vector<double> mul(Vector<double> l, double r) { return LinearAlgebra.Multiply(l, r); }
    public static Vector<double> mul(double l, Vector<double> r) { return LinearAlgebra.Multiply(r, l); }
    public static Vector<double> div(Vector<double> l, double r) { return LinearAlgebra.Divide(l, r); }
    public static Vector<double> div(double l, Vector<double> r) { return LinearAlgebra.Divide(r, l); }
    public static double dot(Vector<double> l, Vector<double> r) { return LinearAlgebra.DotProduct(l, r); }
    public static Vector<double> cros(Vector<double> l, Vector<double> r) { return LinearAlgebra.CrossProduct(l, r); }
    public static Vector<double> norm(Vector<double> a) { return LinearAlgebra.Normalize(a); }
    public static double mag(Vector<double> a) { return LinearAlgebra.Magnitude(a); }
    public static double mag2(Vector<double> a) { return LinearAlgebra.MagnitudeSquared(a); }
    public static double angl(Vector<double> l, Vector<double> r) { return LinearAlgebra.Angle(l, r); }
    public static Vector<double> rot(Vector<double> a, double angle, double x, double y, double z) { return LinearAlgebra.RotateBy(a, angle, x, y, z); }
    public static Vector<double> lerp(Vector<double> a, Vector<double> b, double c) { return LinearAlgebra.Lerp(a, b, c); }
    public static Vector<double> slerp(Vector<double> a, Vector<double> b, double c) { return LinearAlgebra.Slerp(a, b, c); }
    public static Vector<double> blerp(Vector<double> a, Vector<double> b, Vector<double> c, double u, double v) { return LinearAlgebra.Blerp(a, b, c, u, v); }
    public static bool equ(Vector<double> l, Vector<double> r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Vector<double> a, Vector<double> b, double c) { return LinearAlgebra.EqualsValue(a, b, c); }

    #endregion

    #region matrix

    public static int row(Matrix<double> a) { return a.Rows; }
    public static int col(Matrix<double> a) { return a.Columns; }
    public static Matrix<double> neg(Matrix<double> a) { return LinearAlgebra.Negate(a); }
    public static Matrix<double> add(Matrix<double> l, Matrix<double> r) { return LinearAlgebra.Add(l, r); }
    public static Matrix<double> sub(Matrix<double> l, Matrix<double> r) { return LinearAlgebra.Subtract(l, r); }
    public static Matrix<double> mul(Matrix<double> l, Matrix<double> r) { return LinearAlgebra.Multiply(l, r); }
    public static Matrix<double> mul(Matrix<double> l, double r) { return LinearAlgebra.Multiply(l, r); }
    public static Vector<double> mul(Matrix<double> l, Vector<double> r) { return LinearAlgebra.Multiply(l, r); }
    public static Matrix<double> div(Matrix<double> l, double r) { return LinearAlgebra.Divide(l, r); }
    public static Matrix<double> pow(Matrix<double> a, int p) { return LinearAlgebra.Power(a, p); }
    public static double det(Matrix<double> a) { return LinearAlgebra.Determinent(a); }
    public static Matrix<double> rref(Matrix<double> a) { return LinearAlgebra.ReducedEchelon(a); }
    public static Matrix<double> inv(Matrix<double> a) { return LinearAlgebra.Inverse(a); }
    public static Matrix<double> tran(Matrix<double> a) { return LinearAlgebra.Transpose(a); }
    public static bool equ(Matrix<double> l, Matrix<double> r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Matrix<double> l, Matrix<double> r, double c) { return LinearAlgebra.EqualsValue(l, r, c); }

    #endregion

    #region quaternion

    //LinearAlgebra.delegates.Quaternion_Magnitude<T> Quaternion_Magnitude { get; }
    //LinearAlgebra.delegates.Quaternion_MagnitudeSquared<T> _Quaternion_MagnitudeSquared { get; }
    //LinearAlgebra.delegates.Quaternion_Conjugate<T> Quaternion_Conjugate { get; }
    //LinearAlgebra.delegates.Quaternion_Add<T> Quaternion_Add { get; }
    //LinearAlgebra.delegates.Quaternion_Subtract<T> Quaternion_Subtract { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply<T> Quaternion_Multiply { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply_scalar<T> Quaternion_Multiply_scalar { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply_Vector<T> Multiply_Vector { get; }
    //LinearAlgebra.delegates.Quaternion_Normalize<T> Quaternion_Normalize { get; }
    //LinearAlgebra.delegates.Quaternion_Invert<T> Quaternion_Invert { get; }
    //LinearAlgebra.delegates.Quaternion_Lerp<T> Quaternion_Lerp { get; }
    //LinearAlgebra.delegates.Quaternion_Slerp<T> Quaternion_Slerp { get; }
    //LinearAlgebra.delegates.Quaternion_Rotate<T> Quaternion_Rotate { get; }
    //LinearAlgebra.delegates.Quaternion_EqualsValue<T> Quaternion_EqualsValue { get; }
    //LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<T> Quaternion_EqualsValue_leniency { get; }

    #endregion

    #endregion

    #region combinatorics

    /// <summary>Computes: [ N! ].</summary>
    /// <param name="N">The number to compute the factorial of.</param>
    /// <returns>[ N! ]</returns>
    public static double fact(double N) { return Combinatorics.Factorial(N); }
    /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
    /// <param name="N">The total number of items in the set.</param>
    /// <param name="n">The number of items in the respective sub-sets.</param>
    /// <returns>[ N! / (n[0]! + n[1]! + n[3]! ...) ]</returns>
    public static double combin(double N, params double[] n) { return Combinatorics.Combinations(N, n); }
    /// <summary>Computes: [ N! / (N - n)! ]</summary>
    /// <param name="N">The total number of items.</param>
    /// <param name="n">The number of items to choose.</param>
    /// <returns>[ N! / (N - n)! ]</returns>
    public static double choose(double N, double n) { return Combinatorics.Choose(N, n); }

    #endregion

    #region trigonometry

    public static double sin(double a) { return Trigonometry.sin(a); }
    public static double cos(double a) { return Trigonometry.cos(a); }
    public static double tan(double a) { return Trigonometry.tan(a); }
    public static double sec(double a) { return Trigonometry.sec(a); }
    public static double csc(double a) { return Trigonometry.csc(a); }
    public static double cot(double a) { return Trigonometry.cot(a); }
    public static double asin(double r) { return Trigonometry.arcsin(r); }
    public static double acos(double r) { return Trigonometry.arccos(r); }
    public static double atan(double r) { return Trigonometry.arctan(r); }
    public static double acsc(double r) { return Trigonometry.arccsc(r); }
    public static double asec(double r) { return Trigonometry.arcsec(r); }
    public static double acot(double r) { return Trigonometry.arccot(r); }

    #endregion

    #region statistics

    public static Heap<Link<double, int>> mode(params double[] values) { return Statistics.Mode(values); }
    public static double mean(params double[] values) { return Statistics.Mean(values); }
    public static double mean(double a, double b) { return Statistics.Mean(a, b); }
    public static double median(params double[] values) { return Statistics.Median(values); }

    #endregion

    #endregion

    #region float

    #region arithmetic

    public static float neg(float i) { return Arithmetic.Negate(i); }
    public static float add(float l, float r) { return Arithmetic.Add(l, r); }
    public static float sub(float l, float r) { return Arithmetic.Subtract(l, r); }
    public static float mul(float l, float r) { return Arithmetic.Multiply(l, r); }
    public static float div(float l, float r) { return Arithmetic.Divide(l, r); }
    public static float pow(float l, float r) { return Arithmetic.Power(l, r); }

    #endregion

    #region algebra

    public static float ln(float n) { return Algebra.ln(n); }
    public static float log(float n, float b) { return Algebra.log(n, b); }
    public static float sqrt(float b) { return Algebra.sqrt(b); }
    public static float root(float b, float r) { return Algebra.root(b, r); }
    public static float exp(float x) { return Algebra.exp(x); }
    public static float inv(float n) { return Algebra.invert_mult(n); }

    #endregion

    #region linear algebra

    #region vector

    public static int len(Vector<float> a) { return a.Dimensions; }
    public static Vector<float> add(Vector<float> l, Vector<float> r) { return LinearAlgebra.Add(l, r); }
    public static Vector<float> neg(Vector<float> a) { return LinearAlgebra.Negate(a); }
    public static Vector<float> sub(Vector<float> l, Vector<float> r) { return LinearAlgebra.Subtract(l, r); }
    public static Vector<float> mul(Vector<float> l, float r) { return LinearAlgebra.Multiply(l, r); }
    public static Vector<float> mul(float l, Vector<float> r) { return LinearAlgebra.Multiply(r, l); }
    public static Vector<float> div(Vector<float> l, float r) { return LinearAlgebra.Divide(l, r); }
    public static Vector<float> div(float l, Vector<float> r) { return LinearAlgebra.Divide(r, l); }
    public static float dot(Vector<float> l, Vector<float> r) { return LinearAlgebra.DotProduct(l, r); }
    public static Vector<float> cros(Vector<float> l, Vector<float> r) { return LinearAlgebra.CrossProduct(l, r); }
    public static Vector<float> norm(Vector<float> a) { return LinearAlgebra.Normalize(a); }
    public static float mag(Vector<float> a) { return LinearAlgebra.Magnitude(a); }
    public static float mag2(Vector<float> a) { return LinearAlgebra.MagnitudeSquared(a); }
    public static float angl(Vector<float> l, Vector<float> r) { return LinearAlgebra.Angle(l, r); }
    public static Vector<float> rot(Vector<float> a, float angle, float x, float y, float z) { return LinearAlgebra.RotateBy(a, angle, x, y, z); }
    public static Vector<float> lerp(Vector<float> a, Vector<float> b, float c) { return LinearAlgebra.Lerp(a, b, c); }
    public static Vector<float> slerp(Vector<float> a, Vector<float> b, float c) { return LinearAlgebra.Slerp(a, b, c); }
    public static Vector<float> blerp(Vector<float> a, Vector<float> b, Vector<float> c, float u, float v) { return LinearAlgebra.Blerp(a, b, c, u, v); }
    public static bool equ(Vector<float> l, Vector<float> r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Vector<float> a, Vector<float> b, float c) { return LinearAlgebra.EqualsValue(a, b, c); }

    #endregion

    #region matrix

    public static int row(Matrix<float> a) { return a.Rows; }
    public static int col(Matrix<float> a) { return a.Columns; }
    public static Matrix<float> neg(Matrix<float> a) { return LinearAlgebra.Negate(a); }
    public static Matrix<float> add(Matrix<float> l, Matrix<float> r) { return LinearAlgebra.Add(l, r); }
    public static Matrix<float> sub(Matrix<float> l, Matrix<float> r) { return LinearAlgebra.Subtract(l, r); }
    public static Matrix<float> mul(Matrix<float> l, Matrix<float> r) { return LinearAlgebra.Multiply(l, r); }
    public static Matrix<float> mul(Matrix<float> l, float r) { return LinearAlgebra.Multiply(l, r); }
    public static Vector<float> mul(Matrix<float> l, Vector<float> r) { return LinearAlgebra.Multiply(l, r); }
    public static Matrix<float> div(Matrix<float> l, float r) { return LinearAlgebra.Divide(l, r); }
    public static Matrix<float> pow(Matrix<float> a, int p) { return LinearAlgebra.Power(a, p); }
    public static float det(Matrix<float> a) { return LinearAlgebra.Determinent(a); }
    public static Matrix<float> rref(Matrix<float> a) { return LinearAlgebra.ReducedEchelon(a); }
    public static Matrix<float> inv(Matrix<float> a) { return LinearAlgebra.Inverse(a); }
    public static Matrix<float> tran(Matrix<float> a) { return LinearAlgebra.Transpose(a); }
    public static bool equ(Matrix<float> l, Matrix<float> r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Matrix<float> l, Matrix<float> r, float c) { return LinearAlgebra.EqualsValue(l, r, c); }

    #endregion

    #region quaternion

    //LinearAlgebra.delegates.Quaternion_Magnitude<T> Quaternion_Magnitude { get; }
    //LinearAlgebra.delegates.Quaternion_MagnitudeSquared<T> _Quaternion_MagnitudeSquared { get; }
    //LinearAlgebra.delegates.Quaternion_Conjugate<T> Quaternion_Conjugate { get; }
    //LinearAlgebra.delegates.Quaternion_Add<T> Quaternion_Add { get; }
    //LinearAlgebra.delegates.Quaternion_Subtract<T> Quaternion_Subtract { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply<T> Quaternion_Multiply { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply_scalar<T> Quaternion_Multiply_scalar { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply_Vector<T> Multiply_Vector { get; }
    //LinearAlgebra.delegates.Quaternion_Normalize<T> Quaternion_Normalize { get; }
    //LinearAlgebra.delegates.Quaternion_Invert<T> Quaternion_Invert { get; }
    //LinearAlgebra.delegates.Quaternion_Lerp<T> Quaternion_Lerp { get; }
    //LinearAlgebra.delegates.Quaternion_Slerp<T> Quaternion_Slerp { get; }
    //LinearAlgebra.delegates.Quaternion_Rotate<T> Quaternion_Rotate { get; }
    //LinearAlgebra.delegates.Quaternion_EqualsValue<T> Quaternion_EqualsValue { get; }
    //LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<T> Quaternion_EqualsValue_leniency { get; }

    #endregion

    #endregion

    #region combinatorics

    /// <summary>Computes: [ N! ].</summary>
    /// <param name="N">The number to compute the factorial of.</param>
    /// <returns>[ N! ]</returns>
    public static float fact(float N) { return Combinatorics.Factorial(N); }
    /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
    /// <param name="N">The total number of items in the set.</param>
    /// <param name="n">The number of items in the respective sub-sets.</param>
    /// <returns>[ N! / (n[0]! + n[1]! + n[3]! ...) ]</returns>
    public static float combin(float N, params float[] n) { return Combinatorics.Combinations(N, n); }
    /// <summary>Computes: [ N! / (N - n)! ]</summary>
    /// <param name="N">The total number of items.</param>
    /// <param name="n">The number of items to choose.</param>
    /// <returns>[ N! / (N - n)! ]</returns>
    public static float choose(float N, float n) { return Combinatorics.Choose(N, n); }

    #endregion

    #region trigonometry

    public static float sin(float a) { return Trigonometry.sin(a); }
    public static float cos(float a) { return Trigonometry.cos(a); }
    public static float tan(float a) { return Trigonometry.tan(a); }
    public static float sec(float a) { return Trigonometry.sec(a); }
    public static float csc(float a) { return Trigonometry.csc(a); }
    public static float cot(float a) { return Trigonometry.cot(a); }
    public static float asin(float r) { return Trigonometry.arcsin(r); }
    public static float acos(float r) { return Trigonometry.arccos(r); }
    public static float atan(float r) { return Trigonometry.arctan(r); }
    public static float acsc(float r) { return Trigonometry.arccsc(r); }
    public static float asec(float r) { return Trigonometry.arcsec(r); }
    public static float acot(float r) { return Trigonometry.arccot(r); }

    #endregion

    #endregion

    #region long

    #region arithmetic

    public static long neg(long i) { return Arithmetic.Negate(i); }
    public static long add(long l, long r) { return Arithmetic.Add(l, r); }
    public static long sub(long l, long r) { return Arithmetic.Subtract(l, r); }
    public static long mul(long l, long r) { return Arithmetic.Multiply(l, r); }
    public static long div(long l, long r) { return Arithmetic.Divide(l, r); }
    public static long pow(long l, long r) { return Arithmetic.Power(l, r); }

    #endregion

    #region algebra

    public static long ln(long n) { return Algebra.ln(n); }
    public static long log(long n, long b) { return Algebra.log(n, b); }
    public static long sqrt(long b) { return Algebra.sqrt(b); }
    public static long root(long b, long r) { return Algebra.root(b, r); }
    public static long exp(long x) { return Algebra.exp(x); }
    public static long inv(long n) { return Algebra.invert_mult(n); }

    #endregion

    #region linear algebra

    #region vector

    public static int len(Vector<long> a) { return a.Dimensions; }
    public static Vector<long> add(Vector<long> l, Vector<long> r) { return LinearAlgebra.Add(l, r); }
    public static Vector<long> neg(Vector<long> a) { return LinearAlgebra.Negate(a); }
    public static Vector<long> sub(Vector<long> l, Vector<long> r) { return LinearAlgebra.Subtract(l, r); }
    public static Vector<long> mul(Vector<long> l, long r) { return LinearAlgebra.Multiply(l, r); }
    public static Vector<long> mul(long l, Vector<long> r) { return LinearAlgebra.Multiply(r, l); }
    public static Vector<long> div(Vector<long> l, long r) { return LinearAlgebra.Divide(l, r); }
    public static Vector<long> div(long l, Vector<long> r) { return LinearAlgebra.Divide(r, l); }
    public static long dot(Vector<long> l, Vector<long> r) { return LinearAlgebra.DotProduct(l, r); }
    public static Vector<long> cros(Vector<long> l, Vector<long> r) { return LinearAlgebra.CrossProduct(l, r); }
    public static Vector<long> norm(Vector<long> a) { return LinearAlgebra.Normalize(a); }
    public static long mag(Vector<long> a) { return LinearAlgebra.Magnitude(a); }
    public static long mag2(Vector<long> a) { return LinearAlgebra.MagnitudeSquared(a); }
    public static long angl(Vector<long> l, Vector<long> r) { return LinearAlgebra.Angle(l, r); }
    public static Vector<long> rot(Vector<long> a, long angle, long x, long y, long z) { return LinearAlgebra.RotateBy(a, angle, x, y, z); }
    public static Vector<long> lerp(Vector<long> a, Vector<long> b, long c) { return LinearAlgebra.Lerp(a, b, c); }
    public static Vector<long> slerp(Vector<long> a, Vector<long> b, long c) { return LinearAlgebra.Slerp(a, b, c); }
    public static Vector<long> blerp(Vector<long> a, Vector<long> b, Vector<long> c, long u, long v) { return LinearAlgebra.Blerp(a, b, c, u, v); }
    public static bool equ(Vector<long> l, Vector<long> r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Vector<long> a, Vector<long> b, long c) { return LinearAlgebra.EqualsValue(a, b, c); }

    #endregion

    #region matrix

    public static int row(Matrix<long> a) { return a.Rows; }
    public static int col(Matrix<long> a) { return a.Columns; }
    public static Matrix<long> neg(Matrix<long> a) { return LinearAlgebra.Negate(a); }
    public static Matrix<long> add(Matrix<long> l, Matrix<long> r) { return LinearAlgebra.Add(l, r); }
    public static Matrix<long> sub(Matrix<long> l, Matrix<long> r) { return LinearAlgebra.Subtract(l, r); }
    public static Matrix<long> mul(Matrix<long> l, Matrix<long> r) { return LinearAlgebra.Multiply(l, r); }
    public static Matrix<long> mul(Matrix<long> l, long r) { return LinearAlgebra.Multiply(l, r); }
    public static Vector<long> mul(Matrix<long> l, Vector<long> r) { return LinearAlgebra.Multiply(l, r); }
    public static Matrix<long> div(Matrix<long> l, long r) { return LinearAlgebra.Divide(l, r); }
    public static Matrix<long> pow(Matrix<long> a, int p) { return LinearAlgebra.Power(a, p); }
    public static long det(Matrix<long> a) { return LinearAlgebra.Determinent(a); }
    public static Matrix<long> rref(Matrix<long> a) { return LinearAlgebra.ReducedEchelon(a); }
    public static Matrix<long> inv(Matrix<long> a) { return LinearAlgebra.Inverse(a); }
    public static Matrix<long> tran(Matrix<long> a) { return LinearAlgebra.Transpose(a); }
    public static bool equ(Matrix<long> l, Matrix<long> r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Matrix<long> l, Matrix<long> r, long c) { return LinearAlgebra.EqualsValue(l, r, c); }

    #endregion

    #region quaternion

    //LinearAlgebra.delegates.Quaternion_Magnitude<T> Quaternion_Magnitude { get; }
    //LinearAlgebra.delegates.Quaternion_MagnitudeSquared<T> _Quaternion_MagnitudeSquared { get; }
    //LinearAlgebra.delegates.Quaternion_Conjugate<T> Quaternion_Conjugate { get; }
    //LinearAlgebra.delegates.Quaternion_Add<T> Quaternion_Add { get; }
    //LinearAlgebra.delegates.Quaternion_Subtract<T> Quaternion_Subtract { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply<T> Quaternion_Multiply { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply_scalar<T> Quaternion_Multiply_scalar { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply_Vector<T> Multiply_Vector { get; }
    //LinearAlgebra.delegates.Quaternion_Normalize<T> Quaternion_Normalize { get; }
    //LinearAlgebra.delegates.Quaternion_Invert<T> Quaternion_Invert { get; }
    //LinearAlgebra.delegates.Quaternion_Lerp<T> Quaternion_Lerp { get; }
    //LinearAlgebra.delegates.Quaternion_Slerp<T> Quaternion_Slerp { get; }
    //LinearAlgebra.delegates.Quaternion_Rotate<T> Quaternion_Rotate { get; }
    //LinearAlgebra.delegates.Quaternion_EqualsValue<T> Quaternion_EqualsValue { get; }
    //LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<T> Quaternion_EqualsValue_leniency { get; }

    #endregion

    #endregion

    #region combinatorics

    /// <summary>Computes: [ N! ].</summary>
    /// <param name="N">The number to compute the factorial of.</param>
    /// <returns>[ N! ]</returns>
    public static long fact(long N) { return Combinatorics.Factorial(N); }
    /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
    /// <param name="N">The total number of items in the set.</param>
    /// <param name="n">The number of items in the respective sub-sets.</param>
    /// <returns>[ N! / (n[0]! + n[1]! + n[3]! ...) ]</returns>
    public static long combin(long N, params long[] n) { return Combinatorics.Combinations(N, n); }
    /// <summary>Computes: [ N! / (N - n)! ]</summary>
    /// <param name="N">The total number of items.</param>
    /// <param name="n">The number of items to choose.</param>
    /// <returns>[ N! / (N - n)! ]</returns>
    public static long choose(long N, long n) { return Combinatorics.Choose(N, n); }

    #endregion

    #region trigonometry

    //public static long sin(long a) { return Trigonometry.sin(a); }
    //public static long cos(long a) { return Trigonometry.cos(a); }
    //public static long tan(long a) { return Trigonometry.tan(a); }
    //public static long sec(long a) { return Trigonometry.sec(a); }
    //public static long csc(long a) { return Trigonometry.csc(a); }
    //public static long cot(long a) { return Trigonometry.cot(a); }
    //public static long asin(long r) { return Trigonometry.arcsin(r); }
    //public static long acos(long r) { return Trigonometry.arccos(r); }
    //public static long atan(long r) { return Trigonometry.arctan(r); }
    //public static long acsc(long r) { return Trigonometry.arccsc(r); }
    //public static long asec(long r) { return Trigonometry.arcsec(r); }
    //public static long acot(long r) { return Trigonometry.arccot(r); }

    #endregion

    #endregion

    #region int

    #region arithmetic

    public static int neg(int i) { return Arithmetic.Negate(i); }
    public static int add(int l, int r) { return Arithmetic.Add(l, r); }
    public static int sub(int l, int r) { return Arithmetic.Subtract(l, r); }
    public static int mul(int l, int r) { return Arithmetic.Multiply(l, r); }
    public static int div(int l, int r) { return Arithmetic.Divide(l, r); }
    public static int pow(int l, int r) { return Arithmetic.Power(l, r); }

    #endregion

    #region algebra

    public static int ln(int n) { return Algebra.ln(n); }
    public static int log(int b, int n) { return Algebra.log(b, n); }
    public static int sqrt(int b) { return Algebra.sqrt(b); }
    public static int root(int b, int r) { return Algebra.root(b, r); }
    public static int exp(int x) { return Algebra.exp(x); }
    public static int inv(int n) { return Algebra.invert_mult(n); }
    public static int gdc(int a, int b) { return Algebra.GreatestCommonDenominator(a, b); }
    public static bool isprime(int a) { return Algebra.IsPrime(a); }

    #endregion

    #region linear algebra

    #region vector

    public static int len(Vector<int> a) { return a.Dimensions; }
    public static Vector<int> add(Vector<int> l, Vector<int> r) { return LinearAlgebra.Add(l, r); }
    public static Vector<int> neg(Vector<int> a) { return LinearAlgebra.Negate(a); }
    public static Vector<int> sub(Vector<int> l, Vector<int> r) { return LinearAlgebra.Subtract(l, r); }
    public static Vector<int> mul(Vector<int> l, int r) { return LinearAlgebra.Multiply(l, r); }
    public static Vector<int> mul(int l, Vector<int> r) { return LinearAlgebra.Multiply(r, l); }
    public static Vector<int> div(Vector<int> l, int r) { return LinearAlgebra.Divide(l, r); }
    public static Vector<int> div(int l, Vector<int> r) { return LinearAlgebra.Divide(r, l); }
    public static int dot(Vector<int> l, Vector<int> r) { return LinearAlgebra.DotProduct(l, r); }
    public static Vector<int> cros(Vector<int> l, Vector<int> r) { return LinearAlgebra.CrossProduct(l, r); }
    public static Vector<int> norm(Vector<int> a) { return LinearAlgebra.Normalize(a); }
    public static int mag(Vector<int> a) { return LinearAlgebra.Magnitude(a); }
    public static int mag2(Vector<int> a) { return LinearAlgebra.MagnitudeSquared(a); }
    public static int angl(Vector<int> l, Vector<int> r) { return LinearAlgebra.Angle(l, r); }
    public static Vector<int> rot(Vector<int> a, int angle, int x, int y, int z) { return LinearAlgebra.RotateBy(a, angle, x, y, z); }
    public static Vector<int> lerp(Vector<int> a, Vector<int> b, int c) { return LinearAlgebra.Lerp(a, b, c); }
    public static Vector<int> slerp(Vector<int> a, Vector<int> b, int c) { return LinearAlgebra.Slerp(a, b, c); }
    public static Vector<int> blerp(Vector<int> a, Vector<int> b, Vector<int> c, int u, int v) { return LinearAlgebra.Blerp(a, b, c, u, v); }
    public static bool equ(Vector<int> l, Vector<int> r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Vector<int> a, Vector<int> b, int c) { return LinearAlgebra.EqualsValue(a, b, c); }

    #endregion

    #region matrix

    public static int row(Matrix<int> a) { return a.Rows; }
    public static int col(Matrix<int> a) { return a.Columns; }
    public static Matrix<int> neg(Matrix<int> a) { return LinearAlgebra.Negate(a); }
    public static Matrix<int> add(Matrix<int> l, Matrix<int> r) { return LinearAlgebra.Add(l, r); }
    public static Matrix<int> sub(Matrix<int> l, Matrix<int> r) { return LinearAlgebra.Subtract(l, r); }
    public static Matrix<int> mul(Matrix<int> l, Matrix<int> r) { return LinearAlgebra.Multiply(l, r); }
    public static Matrix<int> mul(Matrix<int> l, int r) { return LinearAlgebra.Multiply(l, r); }
    public static Vector<int> mul(Matrix<int> l, Vector<int> r) { return LinearAlgebra.Multiply(l, r); }
    public static Matrix<int> div(Matrix<int> l, int r) { return LinearAlgebra.Divide(l, r); }
    public static Matrix<int> pow(Matrix<int> a, int p) { return LinearAlgebra.Power(a, p); }
    public static int det(Matrix<int> a) { return LinearAlgebra.Determinent(a); }
    public static Matrix<int> rref(Matrix<int> a) { return LinearAlgebra.ReducedEchelon(a); }
    public static Matrix<int> inv(Matrix<int> a) { return LinearAlgebra.Inverse(a); }
    public static Matrix<int> tran(Matrix<int> a) { return LinearAlgebra.Transpose(a); }
    public static bool equ(Matrix<int> l, Matrix<int> r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Matrix<int> l, Matrix<int> r, int c) { return LinearAlgebra.EqualsValue(l, r, c); }

    #endregion

    #region quaternion

    //LinearAlgebra.delegates.Quaternion_Magnitude<T> Quaternion_Magnitude { get; }
    //LinearAlgebra.delegates.Quaternion_MagnitudeSquared<T> _Quaternion_MagnitudeSquared { get; }
    //LinearAlgebra.delegates.Quaternion_Conjugate<T> Quaternion_Conjugate { get; }
    //LinearAlgebra.delegates.Quaternion_Add<T> Quaternion_Add { get; }
    //LinearAlgebra.delegates.Quaternion_Subtract<T> Quaternion_Subtract { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply<T> Quaternion_Multiply { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply_scalar<T> Quaternion_Multiply_scalar { get; }
    //LinearAlgebra.delegates.Quaternion_Multiply_Vector<T> Multiply_Vector { get; }
    //LinearAlgebra.delegates.Quaternion_Normalize<T> Quaternion_Normalize { get; }
    //LinearAlgebra.delegates.Quaternion_Invert<T> Quaternion_Invert { get; }
    //LinearAlgebra.delegates.Quaternion_Lerp<T> Quaternion_Lerp { get; }
    //LinearAlgebra.delegates.Quaternion_Slerp<T> Quaternion_Slerp { get; }
    //LinearAlgebra.delegates.Quaternion_Rotate<T> Quaternion_Rotate { get; }
    //LinearAlgebra.delegates.Quaternion_EqualsValue<T> Quaternion_EqualsValue { get; }
    //LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<T> Quaternion_EqualsValue_leniency { get; }

    #endregion

    #endregion

    #region combinatorics

    /// <summary>Computes: [ N! ].</summary>
    /// <param name="N">The number to compute the factorial of.</param>
    /// <returns>[ N! ]</returns>
    public static int fact(int N) { return Combinatorics.Factorial(N); }
    /// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
    /// <param name="N">The total number of items in the set.</param>
    /// <param name="n">The number of items in the respective sub-sets.</param>
    /// <returns>[ N! / (n[0]! + n[1]! + n[3]! ...) ]</returns>
    public static int combin(int N, params int[] n) { return Combinatorics.Combinations(N, n); }
    /// <summary>Computes: [ N! / (N - n)! ]</summary>
    /// <param name="N">The total number of items.</param>
    /// <param name="n">The number of items to choose.</param>
    /// <returns>[ N! / (N - n)! ]</returns>
    public static int choose(int N, int n) { return Combinatorics.Choose(N, n); }

    #endregion

    #region trigonometry

    //public static int sin(int a) { return Trigonometry.sin(a); }
    //public static int cos(int a) { return Trigonometry.cos(a); }
    //public static int tan(int a) { return Trigonometry.tan(a); }
    //public static int sec(int a) { return Trigonometry.sec(a); }
    //public static int csc(int a) { return Trigonometry.csc(a); }
    //public static int cot(int a) { return Trigonometry.cot(a); }
    //public static int asin(int r) { return Trigonometry.arcsin(r); }
    //public static int acos(int r) { return Trigonometry.arccos(r); }
    //public static int atan(int r) { return Trigonometry.arctan(r); }
    //public static int acsc(int r) { return Trigonometry.arccsc(r); }
    //public static int asec(int r) { return Trigonometry.arcsec(r); }
    //public static int acot(int r) { return Trigonometry.arccot(r); }

    #endregion

    #endregion
  }
}
