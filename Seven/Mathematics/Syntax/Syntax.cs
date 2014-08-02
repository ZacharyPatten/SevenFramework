// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

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

    public static int len(Fraction128[] a) { return a.Length; }
    public static Fraction128[] add(Fraction128[] l, Fraction128[] r) { return LinearAlgebra.Add(l, r); }
    public static Fraction128[] neg(Fraction128[] a) { return LinearAlgebra.Negate(a); }
    public static Fraction128[] sub(Fraction128[] l, Fraction128[] r) { return LinearAlgebra.Subtract(l, r); }
    public static Fraction128[] mul(Fraction128[] l, Fraction128 r) { return LinearAlgebra.Multiply(l, r); }
    public static Fraction128[] mul(Fraction128 l, Fraction128[] r) { return LinearAlgebra.Multiply(r, l); }
    public static Fraction128[] div(Fraction128[] l, Fraction128 r) { return LinearAlgebra.Divide(l, r); }
    public static Fraction128[] div(Fraction128 l, Fraction128[] r) { return LinearAlgebra.Divide(r, l); }
    public static Fraction128 dot(Fraction128[] l, Fraction128[] r) { return LinearAlgebra.DotProduct(l, r); }
    public static Fraction128[] cros(Fraction128[] l, Fraction128[] r) { return LinearAlgebra.CrossProduct(l, r); }
    public static Fraction128[] norm(Fraction128[] a) { return LinearAlgebra.Normalize(a); }
    public static Fraction128 mag(Fraction128[] a) { return LinearAlgebra.Magnitude(a); }
    public static Fraction128 mag2(Fraction128[] a) { return LinearAlgebra.MagnitudeSquared(a); }
    public static Fraction128 angl(Fraction128[] l, Fraction128[] r) { return LinearAlgebra.Angle(l, r); }
    public static Fraction128[] rot(Fraction128[] a, Fraction128 angle, Fraction128 x, Fraction128 y, Fraction128 z) { return LinearAlgebra.RotateBy(a, angle, x, y, z); }
    public static Fraction128[] lerp(Fraction128[] a, Fraction128[] b, Fraction128 c) { return LinearAlgebra.Lerp(a, b, c); }
    public static Fraction128[] slerp(Fraction128[] a, Fraction128[] b, Fraction128 c) { return LinearAlgebra.Slerp(a, b, c); }
    public static Fraction128[] blerp(Fraction128[] a, Fraction128[] b, Fraction128[] c, Fraction128 u, Fraction128 v) { return LinearAlgebra.Blerp(a, b, c, u, v); }
    public static bool equ(Fraction128[] l, Fraction128[] r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Fraction128[] a, Fraction128[] b, Fraction128 c) { return LinearAlgebra.EqualsValue(a, b, c); }

    #endregion

    #region matrix

    public static int row(Fraction128[,] a) { return a.GetLength(0); }
    public static int col(Fraction128[,] a) { return a.GetLength(1); }
    public static Fraction128[,] neg(Fraction128[,] a) { return LinearAlgebra.Negate(a); }
    public static Fraction128[,] add(Fraction128[,] l, Fraction128[,] r) { return LinearAlgebra.Add(l, r); }
    public static Fraction128[,] sub(Fraction128[,] l, Fraction128[,] r) { return LinearAlgebra.Subtract(l, r); }
    public static Fraction128[,] mul(Fraction128[,] l, Fraction128[,] r) { return LinearAlgebra.Multiply(l, r); }
    public static Fraction128[,] mul(Fraction128[,] l, Fraction128 r) { return LinearAlgebra.Multiply(l, r); }
    public static Fraction128[] mul(Fraction128[,] l, Fraction128[] r) { return LinearAlgebra.Multiply(l, r); }
    public static Fraction128[,] div(Fraction128[,] l, Fraction128 r) { return LinearAlgebra.Divide(l, r); }
    public static Fraction128[,] pow(Fraction128[,] a, int p) { return LinearAlgebra.Power(a, p); }
    public static Fraction128 det(Fraction128[,] a) { return LinearAlgebra.Determinent(a); }
    public static Fraction128[,] rref(Fraction128[,] a) { return LinearAlgebra.ReducedEchelon(a); }
    public static Fraction128[,] inv(Fraction128[,] a) { return LinearAlgebra.Inverse(a); }
    public static Fraction128[,] tran(Fraction128[,] a) { return LinearAlgebra.Transpose(a); }
    public static bool equ(Fraction128[,] l, Fraction128[,] r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Fraction128[,] l, Fraction128[,] r, Fraction128 c) { return LinearAlgebra.EqualsValue(l, r, c); }

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
    //public static Fraction128 combin(Fraction128 N, params Fraction128[] n) { return Combinatorics.Combinations(N, n); }
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

    public static int len(Fraction64[] a) { return a.Length; }
    public static Fraction64[] add(Fraction64[] l, Fraction64[] r) { return LinearAlgebra.Add(l, r); }
    public static Fraction64[] neg(Fraction64[] a) { return LinearAlgebra.Negate(a); }
    public static Fraction64[] sub(Fraction64[] l, Fraction64[] r) { return LinearAlgebra.Subtract(l, r); }
    public static Fraction64[] mul(Fraction64[] l, Fraction64 r) { return LinearAlgebra.Multiply(l, r); }
    public static Fraction64[] mul(Fraction64 l, Fraction64[] r) { return LinearAlgebra.Multiply(r, l); }
    public static Fraction64[] div(Fraction64[] l, Fraction64 r) { return LinearAlgebra.Divide(l, r); }
    public static Fraction64[] div(Fraction64 l, Fraction64[] r) { return LinearAlgebra.Divide(r, l); }
    public static Fraction64 dot(Fraction64[] l, Fraction64[] r) { return LinearAlgebra.DotProduct(l, r); }
    public static Fraction64[] cros(Fraction64[] l, Fraction64[] r) { return LinearAlgebra.CrossProduct(l, r); }
    public static Fraction64[] norm(Fraction64[] a) { return LinearAlgebra.Normalize(a); }
    public static Fraction64 mag(Fraction64[] a) { return LinearAlgebra.Magnitude(a); }
    public static Fraction64 mag2(Fraction64[] a) { return LinearAlgebra.MagnitudeSquared(a); }
    public static Fraction64 angl(Fraction64[] l, Fraction64[] r) { return LinearAlgebra.Angle(l, r); }
    public static Fraction64[] rot(Fraction64[] a, Fraction64 angle, Fraction64 x, Fraction64 y, Fraction64 z) { return LinearAlgebra.RotateBy(a, angle, x, y, z); }
    public static Fraction64[] lerp(Fraction64[] a, Fraction64[] b, Fraction64 c) { return LinearAlgebra.Lerp(a, b, c); }
    public static Fraction64[] slerp(Fraction64[] a, Fraction64[] b, Fraction64 c) { return LinearAlgebra.Slerp(a, b, c); }
    public static Fraction64[] blerp(Fraction64[] a, Fraction64[] b, Fraction64[] c, Fraction64 u, Fraction64 v) { return LinearAlgebra.Blerp(a, b, c, u, v); }
    public static bool equ(Fraction64[] l, Fraction64[] r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Fraction64[] a, Fraction64[] b, Fraction64 c) { return LinearAlgebra.EqualsValue(a, b, c); }

    #endregion

    #region matrix

    public static int row(Fraction64[,] a) { return a.GetLength(0); }
    public static int col(Fraction64[,] a) { return a.GetLength(1); }
    public static Fraction64[,] neg(Fraction64[,] a) { return LinearAlgebra.Negate(a); }
    public static Fraction64[,] add(Fraction64[,] l, Fraction64[,] r) { return LinearAlgebra.Add(l, r); }
    public static Fraction64[,] sub(Fraction64[,] l, Fraction64[,] r) { return LinearAlgebra.Subtract(l, r); }
    public static Fraction64[,] mul(Fraction64[,] l, Fraction64[,] r) { return LinearAlgebra.Multiply(l, r); }
    public static Fraction64[,] mul(Fraction64[,] l, Fraction64 r) { return LinearAlgebra.Multiply(l, r); }
    public static Fraction64[] mul(Fraction64[,] l, Fraction64[] r) { return LinearAlgebra.Multiply(l, r); }
    public static Fraction64[,] div(Fraction64[,] l, Fraction64 r) { return LinearAlgebra.Divide(l, r); }
    public static Fraction64[,] pow(Fraction64[,] a, int p) { return LinearAlgebra.Power(a, p); }
    public static Fraction64 det(Fraction64[,] a) { return LinearAlgebra.Determinent(a); }
    public static Fraction64[,] rref(Fraction64[,] a) { return LinearAlgebra.ReducedEchelon(a); }
    public static Fraction64[,] inv(Fraction64[,] a) { return LinearAlgebra.Inverse(a); }
    public static Fraction64[,] tran(Fraction64[,] a) { return LinearAlgebra.Transpose(a); }
    public static bool equ(Fraction64[,] l, Fraction64[,] r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(Fraction64[,] l, Fraction64[,] r, Fraction64 c) { return LinearAlgebra.EqualsValue(l, r, c); }

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
    //public static Fraction64 combin(Fraction64 N, params Fraction64[] n) { return Combinatorics.Combinations(N, n); }
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

    public static int len(decimal[] a) { return a.Length; }
    public static decimal[] add(decimal[] l, decimal[] r) { return LinearAlgebra.Add(l, r); }
    public static decimal[] neg(decimal[] a) { return LinearAlgebra.Negate(a); }
    public static decimal[] sub(decimal[] l, decimal[] r) { return LinearAlgebra.Subtract(l, r); }
    public static decimal[] mul(decimal[] l, decimal r) { return LinearAlgebra.Multiply(l, r); }
    public static decimal[] mul(decimal l, decimal[] r) { return LinearAlgebra.Multiply(r, l); }
    public static decimal[] div(decimal[] l, decimal r) { return LinearAlgebra.Divide(l, r); }
    public static decimal[] div(decimal l, decimal[] r) { return LinearAlgebra.Divide(r, l); }
    public static decimal dot(decimal[] l, decimal[] r) { return LinearAlgebra.DotProduct(l, r); }
    public static decimal[] cros(decimal[] l, decimal[] r) { return LinearAlgebra.CrossProduct(l, r); }
    public static decimal[] norm(decimal[] a) { return LinearAlgebra.Normalize(a); }
    public static decimal mag(decimal[] a) { return LinearAlgebra.Magnitude(a); }
    public static decimal mag2(decimal[] a) { return LinearAlgebra.MagnitudeSquared(a); }
    public static decimal angl(decimal[] l, decimal[] r) { return LinearAlgebra.Angle(l, r); }
    public static decimal[] rot(decimal[] a, decimal angle, decimal x, decimal y, decimal z) { return LinearAlgebra.RotateBy(a, angle, x, y, z); }
    public static decimal[] lerp(decimal[] a, decimal[] b, decimal c) { return LinearAlgebra.Lerp(a, b, c); }
    public static decimal[] slerp(decimal[] a, decimal[] b, decimal c) { return LinearAlgebra.Slerp(a, b, c); }
    public static decimal[] blerp(decimal[] a, decimal[] b, decimal[] c, decimal u, decimal v) { return LinearAlgebra.Blerp(a, b, c, u, v); }
    public static bool equ(decimal[] l, decimal[] r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(decimal[] a, decimal[] b, decimal c) { return LinearAlgebra.EqualsValue(a, b, c); }

    #endregion

    #region matrix

    public static int row(decimal[,] a) { return a.GetLength(0); }
    public static int col(decimal[,] a) { return a.GetLength(1); }
    public static decimal[,] neg(decimal[,] a) { return LinearAlgebra.Negate(a); }
    public static decimal[,] add(decimal[,] l, decimal[,] r) { return LinearAlgebra.Add(l, r); }
    public static decimal[,] sub(decimal[,] l, decimal[,] r) { return LinearAlgebra.Subtract(l, r); }
    public static decimal[,] mul(decimal[,] l, decimal[,] r) { return LinearAlgebra.Multiply(l, r); }
    public static decimal[,] mul(decimal[,] l, decimal r) { return LinearAlgebra.Multiply(l, r); }
    public static decimal[] mul(decimal[,] l, decimal[] r) { return LinearAlgebra.Multiply(l, r); }
    public static decimal[,] div(decimal[,] l, decimal r) { return LinearAlgebra.Divide(l, r); }
    public static decimal[,] pow(decimal[,] a, int p) { return LinearAlgebra.Power(a, p); }
    public static decimal det(decimal[,] a) { return LinearAlgebra.Determinent(a); }
    public static decimal[,] rref(decimal[,] a) { return LinearAlgebra.ReducedEchelon(a); }
    public static decimal[,] inv(decimal[,] a) { return LinearAlgebra.Inverse(a); }
    public static decimal[,] tran(decimal[,] a) { return LinearAlgebra.Transpose(a); }
    public static bool equ(decimal[,] l, decimal[,] r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(decimal[,] l, decimal[,] r, decimal c) { return LinearAlgebra.EqualsValue(l, r, c); }

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

    public static int len(double[] a) { return a.Length; }
    public static double[] add(double[] l, double[] r) { return LinearAlgebra.Add(l, r); }
    public static double[] neg(double[] a) { return LinearAlgebra.Negate(a); }
    public static double[] sub(double[] l, double[] r) { return LinearAlgebra.Subtract(l, r); }
    public static double[] mul(double[] l, double r) { return LinearAlgebra.Multiply(l, r); }
    public static double[] mul(double l, double[] r) { return LinearAlgebra.Multiply(r, l); }
    public static double[] div(double[] l, double r) { return LinearAlgebra.Divide(l, r); }
    public static double[] div(double l, double[] r) { return LinearAlgebra.Divide(r, l); }
    public static double dot(double[] l, double[] r) { return LinearAlgebra.DotProduct(l, r); }
    public static double[] cros(double[] l, double[] r) { return LinearAlgebra.CrossProduct(l, r); }
    public static double[] norm(double[] a) { return LinearAlgebra.Normalize(a); }
    public static double mag(double[] a) { return LinearAlgebra.Magnitude(a); }
    public static double mag2(double[] a) { return LinearAlgebra.MagnitudeSquared(a); }
    public static double angl(double[] l, double[] r) { return LinearAlgebra.Angle(l, r); }
    public static double[] rot(double[] a, double angle, double x, double y, double z) { return LinearAlgebra.RotateBy(a, angle, x, y, z); }
    public static double[] lerp(double[] a, double[] b, double c) { return LinearAlgebra.Lerp(a, b, c); }
    public static double[] slerp(double[] a, double[] b, double c) { return LinearAlgebra.Slerp(a, b, c); }
    public static double[] blerp(double[] a, double[] b, double[] c, double u, double v) { return LinearAlgebra.Blerp(a, b, c, u, v); }
    public static bool equ(double[] l, double[] r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(double[] a, double[] b, double c) { return LinearAlgebra.EqualsValue(a, b, c); }

    #endregion

    #region matrix

    public static int row(double[,] a) { return a.GetLength(0); }
    public static int col(double[,] a) { return a.GetLength(1); }
    public static double[,] neg(double[,] a) { return LinearAlgebra.Negate(a); }
    public static double[,] add(double[,] l, double[,] r) { return LinearAlgebra.Add(l, r); }
    public static double[,] sub(double[,] l, double[,] r) { return LinearAlgebra.Subtract(l, r); }
    public static double[,] mul(double[,] l, double[,] r) { return LinearAlgebra.Multiply(l, r); }
    public static double[,] mul(double[,] l, double r) { return LinearAlgebra.Multiply(l, r); }
    public static double[] mul(double[,] l, double[] r) { return LinearAlgebra.Multiply(l, r); }
    public static double[,] div(double[,] l, double r) { return LinearAlgebra.Divide(l, r); }
    public static double[,] pow(double[,] a, int p) { return LinearAlgebra.Power(a, p); }
    public static double det(double[,] a) { return LinearAlgebra.Determinent(a); }
    public static double[,] rref(double[,] a) { return LinearAlgebra.ReducedEchelon(a); }
    public static double[,] inv(double[,] a) { return LinearAlgebra.Inverse(a); }
    public static double[,] tran(double[,] a) { return LinearAlgebra.Transpose(a); }
    public static bool equ(double[,] l, double[,] r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(double[,] l, double[,] r, double c) { return LinearAlgebra.EqualsValue(l, r, c); }

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

    public static int len(float[] a) { return a.Length; }
    public static float[] add(float[] l, float[] r) { return LinearAlgebra.Add(l, r); }
    public static float[] neg(float[] a) { return LinearAlgebra.Negate(a); }
    public static float[] sub(float[] l, float[] r) { return LinearAlgebra.Subtract(l, r); }
    public static float[] mul(float[] l, float r) { return LinearAlgebra.Multiply(l, r); }
    public static float[] mul(float l, float[] r) { return LinearAlgebra.Multiply(r, l); }
    public static float[] div(float[] l, float r) { return LinearAlgebra.Divide(l, r); }
    public static float[] div(float l, float[] r) { return LinearAlgebra.Divide(r, l); }
    public static float dot(float[] l, float[] r) { return LinearAlgebra.DotProduct(l, r); }
    public static float[] cros(float[] l, float[] r) { return LinearAlgebra.CrossProduct(l, r); }
    public static float[] norm(float[] a) { return LinearAlgebra.Normalize(a); }
    public static float mag(float[] a) { return LinearAlgebra.Magnitude(a); }
    public static float mag2(float[] a) { return LinearAlgebra.MagnitudeSquared(a); }
    public static float angl(float[] l, float[] r) { return LinearAlgebra.Angle(l, r); }
    public static float[] rot(float[] a, float angle, float x, float y, float z) { return LinearAlgebra.RotateBy(a, angle, x, y, z); }
    public static float[] lerp(float[] a, float[] b, float c) { return LinearAlgebra.Lerp(a, b, c); }
    public static float[] slerp(float[] a, float[] b, float c) { return LinearAlgebra.Slerp(a, b, c); }
    public static float[] blerp(float[] a, float[] b, float[] c, float u, float v) { return LinearAlgebra.Blerp(a, b, c, u, v); }
    public static bool equ(float[] l, float[] r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(float[] a, float[] b, float c) { return LinearAlgebra.EqualsValue(a, b, c); }

    #endregion

    #region matrix

    public static int row(float[,] a) { return a.GetLength(0); }
    public static int col(float[,] a) { return a.GetLength(1); }
    public static float[,] neg(float[,] a) { return LinearAlgebra.Negate(a); }
    public static float[,] add(float[,] l, float[,] r) { return LinearAlgebra.Add(l, r); }
    public static float[,] sub(float[,] l, float[,] r) { return LinearAlgebra.Subtract(l, r); }
    public static float[,] mul(float[,] l, float[,] r) { return LinearAlgebra.Multiply(l, r); }
    public static float[,] mul(float[,] l, float r) { return LinearAlgebra.Multiply(l, r); }
    public static float[] mul(float[,] l, float[] r) { return LinearAlgebra.Multiply(l, r); }
    public static float[,] div(float[,] l, float r) { return LinearAlgebra.Divide(l, r); }
    public static float[,] pow(float[,] a, int p) { return LinearAlgebra.Power(a, p); }
    public static float det(float[,] a) { return LinearAlgebra.Determinent(a); }
    public static float[,] rref(float[,] a) { return LinearAlgebra.ReducedEchelon(a); }
    public static float[,] inv(float[,] a) { return LinearAlgebra.Inverse(a); }
    public static float[,] tran(float[,] a) { return LinearAlgebra.Transpose(a); }
    public static bool equ(float[,] l, float[,] r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(float[,] l, float[,] r, float c) { return LinearAlgebra.EqualsValue(l, r, c); }

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

    public static int len(long[] a) { return a.Length; }
    public static long[] add(long[] l, long[] r) { return LinearAlgebra.Add(l, r); }
    public static long[] neg(long[] a) { return LinearAlgebra.Negate(a); }
    public static long[] sub(long[] l, long[] r) { return LinearAlgebra.Subtract(l, r); }
    public static long[] mul(long[] l, long r) { return LinearAlgebra.Multiply(l, r); }
    public static long[] mul(long l, long[] r) { return LinearAlgebra.Multiply(r, l); }
    public static long[] div(long[] l, long r) { return LinearAlgebra.Divide(l, r); }
    public static long[] div(long l, long[] r) { return LinearAlgebra.Divide(r, l); }
    public static long dot(long[] l, long[] r) { return LinearAlgebra.DotProduct(l, r); }
    public static long[] cros(long[] l, long[] r) { return LinearAlgebra.CrossProduct(l, r); }
    public static long[] norm(long[] a) { return LinearAlgebra.Normalize(a); }
    public static long mag(long[] a) { return LinearAlgebra.Magnitude(a); }
    public static long mag2(long[] a) { return LinearAlgebra.MagnitudeSquared(a); }
    public static long angl(long[] l, long[] r) { return LinearAlgebra.Angle(l, r); }
    public static long[] rot(long[] a, long angle, long x, long y, long z) { return LinearAlgebra.RotateBy(a, angle, x, y, z); }
    public static long[] lerp(long[] a, long[] b, long c) { return LinearAlgebra.Lerp(a, b, c); }
    public static long[] slerp(long[] a, long[] b, long c) { return LinearAlgebra.Slerp(a, b, c); }
    public static long[] blerp(long[] a, long[] b, long[] c, long u, long v) { return LinearAlgebra.Blerp(a, b, c, u, v); }
    public static bool equ(long[] l, long[] r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(long[] a, long[] b, long c) { return LinearAlgebra.EqualsValue(a, b, c); }

    #endregion

    #region matrix

    public static int row(long[,] a) { return a.GetLength(0); }
    public static int col(long[,] a) { return a.GetLength(1); }
    public static long[,] neg(long[,] a) { return LinearAlgebra.Negate(a); }
    public static long[,] add(long[,] l, long[,] r) { return LinearAlgebra.Add(l, r); }
    public static long[,] sub(long[,] l, long[,] r) { return LinearAlgebra.Subtract(l, r); }
    public static long[,] mul(long[,] l, long[,] r) { return LinearAlgebra.Multiply(l, r); }
    public static long[,] mul(long[,] l, long r) { return LinearAlgebra.Multiply(l, r); }
    public static long[] mul(long[,] l, long[] r) { return LinearAlgebra.Multiply(l, r); }
    public static long[,] div(long[,] l, long r) { return LinearAlgebra.Divide(l, r); }
    public static long[,] pow(long[,] a, int p) { return LinearAlgebra.Power(a, p); }
    public static long det(long[,] a) { return LinearAlgebra.Determinent(a); }
    public static long[,] rref(long[,] a) { return LinearAlgebra.ReducedEchelon(a); }
    public static long[,] inv(long[,] a) { return LinearAlgebra.Inverse(a); }
    public static long[,] tran(long[,] a) { return LinearAlgebra.Transpose(a); }
    public static bool equ(long[,] l, long[,] r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(long[,] l, long[,] r, long c) { return LinearAlgebra.EqualsValue(l, r, c); }

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

    public static int len(int[] a) { return a.Length; }
    public static int[] add(int[] l, int[] r) { return LinearAlgebra.Add(l, r); }
    public static int[] neg(int[] a) { return LinearAlgebra.Negate(a); }
    public static int[] sub(int[] l, int[] r) { return LinearAlgebra.Subtract(l, r); }
    public static int[] mul(int[] l, int r) { return LinearAlgebra.Multiply(l, r); }
    public static int[] mul(int l, int[] r) { return LinearAlgebra.Multiply(r, l); }
    public static int[] div(int[] l, int r) { return LinearAlgebra.Divide(l, r); }
    public static int[] div(int l, int[] r) { return LinearAlgebra.Divide(r, l); }
    public static int dot(int[] l, int[] r) { return LinearAlgebra.DotProduct(l, r); }
    public static int[] cros(int[] l, int[] r) { return LinearAlgebra.CrossProduct(l, r); }
    public static int[] norm(int[] a) { return LinearAlgebra.Normalize(a); }
    public static int mag(int[] a) { return LinearAlgebra.Magnitude(a); }
    public static int mag2(int[] a) { return LinearAlgebra.MagnitudeSquared(a); }
    public static int angl(int[] l, int[] r) { return LinearAlgebra.Angle(l, r); }
    public static int[] rot(int[] a, int angle, int x, int y, int z) { return LinearAlgebra.RotateBy(a, angle, x, y, z); }
    public static int[] lerp(int[] a, int[] b, int c) { return LinearAlgebra.Lerp(a, b, c); }
    public static int[] slerp(int[] a, int[] b, int c) { return LinearAlgebra.Slerp(a, b, c); }
    public static int[] blerp(int[] a, int[] b, int[] c, int u, int v) { return LinearAlgebra.Blerp(a, b, c, u, v); }
    public static bool equ(int[] l, int[] r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(int[] a, int[] b, int c) { return LinearAlgebra.EqualsValue(a, b, c); }

    #endregion

    #region matrix

    public static int row(int[,] a) { return a.GetLength(0); }
    public static int col(int[,] a) { return a.GetLength(1); }
    public static int[,] neg(int[,] a) { return LinearAlgebra.Negate(a); }
    public static int[,] add(int[,] l, int[,] r) { return LinearAlgebra.Add(l, r); }
    public static int[,] sub(int[,] l, int[,] r) { return LinearAlgebra.Subtract(l, r); }
    public static int[,] mul(int[,] l, int[,] r) { return LinearAlgebra.Multiply(l, r); }
    public static int[,] mul(int[,] l, int r) { return LinearAlgebra.Multiply(l, r); }
    public static int[] mul(int[,] l, int[] r) { return LinearAlgebra.Multiply(l, r); }
    public static int[,] div(int[,] l, int r) { return LinearAlgebra.Divide(l, r); }
    public static int[,] pow(int[,] a, int p) { return LinearAlgebra.Power(a, p); }
    public static int det(int[,] a) { return LinearAlgebra.Determinent(a); }
    public static int[,] rref(int[,] a) { return LinearAlgebra.ReducedEchelon(a); }
    public static int[,] inv(int[,] a) { return LinearAlgebra.Inverse(a); }
    public static int[,] tran(int[,] a) { return LinearAlgebra.Transpose(a); }
    public static bool equ(int[,] l, int[,] r) { return LinearAlgebra.EqualsValue(l, r); }
    public static bool equ(int[,] l, int[,] r, int c) { return LinearAlgebra.EqualsValue(l, r, c); }

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
