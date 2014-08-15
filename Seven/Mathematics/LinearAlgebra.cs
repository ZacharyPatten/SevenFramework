// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics
{
	/// <summary>Supplies linear algebra mathematics for generic types.</summary>
	/// <typeparam name="T">The type this linear algebra library can perform on.</typeparam>
	public interface LinearAlgebra<T>
  {
    #region vector

    /// <summary>Adds two vectors together.</summary>
    LinearAlgebra.delegates.Vector_Add<T> Vector_Add { get; }
    /// <summary>Negates all the values in a vector.</summary>
    LinearAlgebra.delegates.Vector_Negate<T> Vector_Negate { get; }
    /// <summary>Subtracts two vectors.</summary>
    LinearAlgebra.delegates.Vector_Subtract<T> Vector_Subtract { get; }
    /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
    LinearAlgebra.delegates.Vector_Multiply<T> Vector_Multiply { get; }
    /// <summary>Divides all the components of a vector by a scalar.</summary>
    LinearAlgebra.delegates.Vector_Divide<T> Vector_Divide { get; }
    /// <summary>Computes the dot product between two vectors.</summary>
    LinearAlgebra.delegates.Vector_DotProduct<T> Vector_DotProduct { get; }
    /// <summary>Computes teh cross product of two vectors.</summary>
    LinearAlgebra.delegates.Vector_CrossProduct<T> Vector_CrossProduct { get; }
    /// <summary>Normalizes a vector.</summary>
    LinearAlgebra.delegates.Vector_Normalize<T> Vector_Normalize { get; }
    /// <summary>Computes the length of a vector.</summary>
    LinearAlgebra.delegates.Vector_Magnitude<T> Vector_Magnitude { get; }
    /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
    LinearAlgebra.delegates.Vector_MagnitudeSquared<T> Vector_MagnitudeSquared { get; }
    /// <summary>Computes the angle between two vectors.</summary>
    LinearAlgebra.delegates.Vector_Angle<T> Vector_Angle { get; }
    /// <summary>Rotates a vector by the specified axis and rotation values.</summary>
    LinearAlgebra.delegates.Vector_RotateBy<T> Vector_RotateBy { get; }
    /// <summary>Computes the linear interpolation between two vectors.</summary>
    LinearAlgebra.delegates.Vector_Lerp<T> Vector_Lerp { get; }
    /// <summary>Sphereically interpolates between two vectors.</summary>
    LinearAlgebra.delegates.Vector_Slerp<T> Vector_Slerp { get; }
    /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
    LinearAlgebra.delegates.Vector_Blerp<T> Vector_Blerp { get; }
    /// <summary>Checks for equality between two vectors.</summary>
    LinearAlgebra.delegates.Vector_EqualsValue<T> Vector_EqualsValue { get; }
    /// <summary>Checks for equality between two vectors with a leniency.</summary>
    LinearAlgebra.delegates.Vector_EqualsValue_leniency<T> Vector_EqualsValue_leniency { get; }
    /// <summary>Rotates a vector by a quaternion.</summary>
    LinearAlgebra.delegates.Vector_RotateBy_quaternion<T> Vector_RotateBy_quaternion { get; }

    #endregion

    #region matrix

    /// <summary>Negates all the values in this matrix.</summary>
    LinearAlgebra.delegates.Matrix_Negate<T> Matrix_Negate { get; }
		/// <summary>Does a standard matrix addition.</summary>
    LinearAlgebra.delegates.Matrix_Add<T> Matrix_Add { get; }
    /// <summary>Does a standard matrix subtraction.</summary>
    LinearAlgebra.delegates.Matrix_Subtract<T> Matrix_Subtract { get; }
		/// <summary>Does a standard matrix multiplication (triple for loop).</summary>
    LinearAlgebra.delegates.Matrix_Multiply<T> Matrix_Multiply { get; }
		/// <summary>Multiplies all the values in this matrix by a scalar.</summary>
    LinearAlgebra.delegates.Matrix_Multiply_scalar<T> Matrix_Multiply_scalar { get; }
    /// <summary>Premultiplies a vector by a matrix.</summary>
    LinearAlgebra.delegates.Matrix_Multiply_vector<T> Matrix_Multiply_vector { get; }
		/// <summary>Divides all the values in this matrix by a scalar.</summary>
    LinearAlgebra.delegates.Matrix_Divide<T> Matrix_Divide { get; }
    /// <summary>Takes the matrix to the given int power.</summary>
    LinearAlgebra.delegates.Matrix_Power<T> Matrix_Power { get; }
		/// <summary>Gets the minor of a matrix.</summary>
    LinearAlgebra.delegates.Matrix_Minor<T> Matrix_Minor { get; }
		/// <summary>Combines two matrices from left to right (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
    LinearAlgebra.delegates.Matrix_ConcatenateRowWise<T> Matrix_ConcatenateRowWise { get; }
		/// <summary>Computes the determinent if this matrix is square.</summary>
    LinearAlgebra.delegates.Matrix_Determinent<T> Matrix_Determinent { get; }
		/// <summary>Computes the echelon form of this matrix (aka REF).</summary>
    LinearAlgebra.delegates.Matrix_Echelon<T> Matrix_Echelon { get; }
		/// <summary>Computes the reduced echelon form of this matrix (aka RREF).</summary>
    LinearAlgebra.delegates.Matrix_ReducedEchelon<T> Matrix_ReducedEchelon { get; }
		/// <summary>Computes the inverse of this matrix.</summary>
    LinearAlgebra.delegates.Matrix_Inverse<T> Matrix_Inverse { get; }
		/// <summary>Gets the adjoint of this matrix.</summary>
    LinearAlgebra.delegates.Matrix_Adjoint<T> Matrix_Adjoint { get; }
		/// <summary>Transposes this matrix.</summary>
    LinearAlgebra.delegates.Matrix_Transpose<T> Matrix_Transpose { get; }
    /// <summary>Decomposes a matrix to lower/upper components.</summary>
    LinearAlgebra.delegates.Matrix_DecomposeLU<T> Matrix_DecomposeLU { get; }
    /// <summary>Dtermines equality but value.</summary>
    LinearAlgebra.delegates.Matrix_EqualsByValue<T> Matrix_EqualsByValue { get; }
    /// <summary>Determines equality by value with leniency.</summary>
    LinearAlgebra.delegates.Matrix_EqualsByValue_leniency<T> Matrix_EqualsByValue_leniency { get; }

    #endregion

    #region quaternion

    /// <summary>Computes the magnitude of quaternion.</summary>
    LinearAlgebra.delegates.Quaternion_Magnitude<T> Quaternion_Magnitude { get; }
    /// <summary>Computes the magnitude of a quaternion, but doesn't square root it.</summary>
    LinearAlgebra.delegates.Quaternion_MagnitudeSquared<T> Quaternion_MagnitudeSquared { get; }
    /// <summary>Gets the conjugate of the quaternion.</summary>
    LinearAlgebra.delegates.Quaternion_Conjugate<T> Quaternion_Conjugate { get; }
    /// <summary>Adds two quaternions together.</summary>
    LinearAlgebra.delegates.Quaternion_Add<T> Quaternion_Add { get; }
    /// <summary>Subtracts two quaternions.</summary>
    LinearAlgebra.delegates.Quaternion_Subtract<T> Quaternion_Subtract { get; }
    /// <summary>Multiplies two quaternions together.</summary>
    LinearAlgebra.delegates.Quaternion_Multiply<T> Quaternion_Multiply { get; }
    /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
    LinearAlgebra.delegates.Quaternion_Multiply_scalar<T> Quaternion_Multiply_scalar { get; }
    /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
    LinearAlgebra.delegates.Quaternion_Multiply_Vector<T> Quaternion_Multiply_Vector { get; }
    /// <summary>Normalizes the quaternion.</summary>
    LinearAlgebra.delegates.Quaternion_Normalize<T> Quaternion_Normalize { get; }
    /// <summary>Inverts a quaternion.</summary>
    LinearAlgebra.delegates.Quaternion_Invert<T> Quaternion_Invert { get; }
    /// <summary>Lenearly interpolates between two quaternions.</summary>
    LinearAlgebra.delegates.Quaternion_Lerp<T> Quaternion_Lerp { get; }
    /// <summary>Sphereically interpolates between two quaternions.</summary>
    LinearAlgebra.delegates.Quaternion_Slerp<T> Quaternion_Slerp { get; }
    /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
    LinearAlgebra.delegates.Quaternion_Rotate<T> Quaternion_Rotate { get; }
    /// <summary>Does a value equality check.</summary>
    LinearAlgebra.delegates.Quaternion_EqualsValue<T> Quaternion_EqualsValue { get; }
    /// <summary>Does a value equality check with leniency.</summary>
    LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<T> Quaternion_EqualsValue_leniency { get; }

    #endregion
  }

  /// <summary>Makes and stores implementations of linear algebra.</summary>
	public static class LinearAlgebra
  {
    #region static controls

    // The minimum size (rows x columns) that will trigger multithreading 
    // of matrix operations. Example: "A.Multiply_parallel(B)"
    public static int _parallelMinimum = 49;

    #endregion

    #region delegate

    /// <summary>Stores the delegates used for linear algebra.</summary>
    public static class delegates
    {

      #region vector

      /// <summary>Adds two vectors together.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The first vector of the addition.</param>
      /// <param name="right">The second vector of the addiiton.</param>
      /// <returns>The result of the addiion.</returns>
      public delegate Vector<T> Vector_Add<T>(Vector<T> left, Vector<T> right);
      /// <summary>Negates all the values in a vector.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="vector">The vector to have its values negated.</param>
      /// <returns>The result of the negations.</returns>
      public delegate Vector<T> Vector_Negate<T>(Vector<T> vector);
      /// <summary>Subtracts two vectors.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The left vector of the subtraction.</param>
      /// <param name="right">The right vector of the subtraction.</param>
      /// <returns>The result of the vector subtracton.</returns>
      public delegate Vector<T> Vector_Subtract<T>(Vector<T> left, Vector<T> right);
      /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The vector to have the components multiplied by.</param>
      /// <param name="right">The scalars to multiply the vector components by.</param>
      /// <returns>The result of the multiplications.</returns>
      public delegate Vector<T> Vector_Multiply<T>(Vector<T> left, T right);
      /// <summary>Divides all the components of a vector by a scalar.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The vector to have the components divided by.</param>
      /// <param name="right">The scalar to divide the vector components by.</param>
      /// <returns>The resulting vector after teh divisions.</returns>
      public delegate Vector<T> Vector_Divide<T>(Vector<T> vector, T right);
      /// <summary>Computes the dot product between two vectors.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The first vector of the dot product operation.</param>
      /// <param name="right">The second vector of the dot product operation.</param>
      /// <returns>The result of the dot product operation.</returns>
      public delegate T Vector_DotProduct<T>(Vector<T> left, Vector<T> right);
      /// <summary>Computes teh cross product of two vectors.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The first vector of the cross product operation.</param>
      /// <param name="right">The second vector of the cross product operation.</param>
      /// <returns>The result of the cross product operation.</returns>
      public delegate Vector<T> Vector_CrossProduct<T>(Vector<T> left, Vector<T> right);
      /// <summary>Normalizes a vector.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="vector">The vector to normalize.</param>
      /// <returns>The result of the normalization.</returns>
      public delegate Vector<T> Vector_Normalize<T>(Vector<T> vector);
      /// <summary>Computes the length of a vector.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="vector">The vector to calculate the length of.</param>
      /// <returns>The computed length of the vector.</returns>
      public delegate T Vector_Magnitude<T>(Vector<T> vector);
      /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="vector">The vector to compute the length squared of.</param>
      /// <returns>The computed length squared of the vector.</returns>
      public delegate T Vector_MagnitudeSquared<T>(Vector<T> vector);
      /// <summary>Computes the angle between two vectors.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="first">The first vector to determine the angle between.</param>
      /// <param name="second">The second vector to determine the angle between.</param>
      /// <returns>The angle between the two vectors in radians.</returns>
      public delegate T Vector_Angle<T>(Vector<T> first, Vector<T> second);
      /// <summary>Rotates a vector by the specified axis and rotation values.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="vector">The vector to rotate.</param>
      /// <param name="angle">The angle of the rotation.</param>
      /// <param name="x">The x component of the axis vector to rotate about.</param>
      /// <param name="y">The y component of the axis vector to rotate about.</param>
      /// <param name="z">The z component of the axis vector to rotate about.</param>
      /// <returns>The result of the rotation.</returns>
      public delegate Vector<T> Vector_RotateBy<T>(Vector<T> vector, T angle, T x, T y, T z);
      /// <summary>Computes the linear interpolation between two vectors.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The starting vector of the interpolation.</param>
      /// <param name="right">The ending vector of the interpolation.</param>
      /// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
      /// <returns>The result of the interpolation.</returns>
      public delegate Vector<T> Vector_Lerp<T>(Vector<T> left, Vector<T> right, T blend);
      /// <summary>Sphereically interpolates between two vectors.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The starting vector of the interpolation.</param>
      /// <param name="right">The ending vector of the interpolation.</param>
      /// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
      /// <returns>The result of the slerp operation.</returns>
      public delegate Vector<T> Vector_Slerp<T>(Vector<T> left, Vector<T> right, T blend);
      /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="a">The first vector of the interpolation.</param>
      /// <param name="b">The second vector of the interpolation.</param>
      /// <param name="c">The thrid vector of the interpolation.</param>
      /// <param name="u">The "U" value of the barycentric interpolation equation.</param>
      /// <param name="v">The "V" value of the barycentric interpolation equation.</param>
      /// <returns>The resulting vector of the barycentric interpolation.</returns>
      public delegate Vector<T> Vector_Blerp<T>(Vector<T> a, Vector<T> b, Vector<T> c, T u, T v);
      /// <summary>Does a value equality check.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The first vector to check for equality.</param>
      /// <param name="right">The second vector  to check for equality.</param>
      /// <returns>True if values are equal, false if not.</returns>
      public delegate bool Vector_EqualsValue<T>(Vector<T> left, Vector<T> right);
      /// <summary>Does a value equality check with leniency.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The first vector to check for equality.</param>
      /// <param name="right">The second vector to check for equality.</param>
      /// <param name="leniency">How much the values can vary but still be considered equal.</param>
      /// <returns>True if values are equal, false if not.</returns>
      public delegate bool Vector_EqualsValue_leniency<T>(Vector<T> left, Vector<T> right, T leniency);
      /// <summary>Rotates a vector by a quaternion.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="vector">The vector to rotate.</param>
      /// <param name="rotation">The quaternion to rotate the 3-component vector by.</param>
      /// <returns>The result of the rotation.</returns>
      public delegate Vector<T> Vector_RotateBy_quaternion<T>(Vector<T> vector, Quaternion<T> rotation);

      #endregion

      #region matrix

      /// <summary>Determines if a matrix is symetric.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="matrix">The matrix to determine symetry on.</param>
      /// <returns>True if the matrix is symetric; false if not.</returns>
      public delegate bool Matrix_IsSymetric<T>(Matrix<T> matrix);
      /// <summary>Negates all the values in a matrix.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="matrix">The matrix to have its values negated.</param>
      /// <returns>The resulting matrix after the negations.</returns>
      public delegate Matrix<T> Matrix_Negate<T>(Matrix<T> matrix);
      /// <summary>Does standard addition of two matrices.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The left matrix of the addition.</param>
      /// <param name="right">The right matrix of the addition.</param>
      /// <returns>The resulting matrix after the addition.</returns>
      public delegate Matrix<T> Matrix_Add<T>(Matrix<T> left, Matrix<T> right);
      /// <summary>Subtracts a scalar from all the values in a matrix.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The matrix to have the values subtracted from.</param>
      /// <param name="right">The scalar to subtract from all the matrix values.</param>
      /// <returns>The resulting matrix after the subtractions.</returns>
      public delegate Matrix<T> Matrix_Subtract<T>(Matrix<T> left, Matrix<T> right);
      /// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The left matrix of the multiplication.</param>
      /// <param name="right">The right matrix of the multiplication.</param>
      /// <returns>The resulting matrix of the multiplication.</returns>
      public delegate Matrix<T> Matrix_Multiply<T>(Matrix<T> left, Matrix<T> right);
      /// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="matrix">The left matrix of the multiplication.</param>
      /// <param name="right">The right matrix of the multiplication.</param>
      /// <returns>The resulting matrix of the multiplication.</returns>
      public delegate Vector<T> Matrix_Multiply_vector<T>(Matrix<T> matrix, Vector<T> right);
      /// <summary>Multiplies all the values in a matrix by a scalar.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="matrix">The matrix to have the values multiplied.</param>
      /// <param name="right">The scalar to multiply the values by.</param>
      /// <returns>The resulting matrix after the multiplications.</returns>
      public delegate Matrix<T> Matrix_Multiply_scalar<T>(Matrix<T> matrix, T right);
      /// <summary>Divides all the values in the matrix by a scalar.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The matrix to divide the values of.</param>
      /// <param name="right">The scalar to divide all the matrix values by.</param>
      /// <returns>The resulting matrix with the divided values.</returns>
      public delegate Matrix<T> Matrix_Divide<T>(Matrix<T> left, T right);
      /// <summary>Applies a power to a square matrix.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="matrix">The matrix to be powered by.</param>
      /// <param name="power">The power to apply to the matrix.</param>
      /// <returns>The resulting matrix of the power operation.</returns>
      public delegate Matrix<T> Matrix_Power<T>(Matrix<T> matrix, int power);
      /// <summary>Gets the minor of a matrix.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="matrix">The matrix to get the minor of.</param>
      /// <param name="row">The restricted row to form the minor.</param>
      /// <param name="column">The restricted column to form the minor.</param>
      /// <returns>The minor of the matrix.</returns>
      public delegate Matrix<T> Matrix_Minor<T>(Matrix<T> matrix, int row, int column);
      /// <summary>Combines two matrices from left to right 
      /// (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The left matrix of the concatenation.</param>
      /// <param name="right">The right matrix of the concatenation.</param>
      /// <returns>The resulting matrix of the concatenation.</returns>
      public delegate Matrix<T> Matrix_ConcatenateRowWise<T>(Matrix<T> left, Matrix<T> right);
      /// <summary>Calculates the determinent of a square matrix.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="matrix">The matrix to calculate the determinent of.</param>
      /// <returns>The determinent of the matrix.</returns>
      public delegate T Matrix_Determinent<T>(Matrix<T> matrix);
      /// <summary>Calculates the echelon of a matrix (aka REF).</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="matrix">The matrix to calculate the echelon of (aka REF).</param>
      /// <returns>The echelon of the matrix (aka REF).</returns>
      public delegate Matrix<T> Matrix_Echelon<T>(Matrix<T> matrix);
      /// <summary>Calculates the echelon of a matrix and reduces it (aka RREF).</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="matrix">The matrix matrix to calculate the reduced echelon of (aka RREF).</param>
      /// <returns>The reduced echelon of the matrix (aka RREF).</returns>
      public delegate Matrix<T> Matrix_ReducedEchelon<T>(Matrix<T> matrix);
      /// <summary>Calculates the inverse of a matrix.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="matrix">The matrix to calculate the inverse of.</param>
      /// <returns>The inverse of the matrix.</returns>
      public delegate Matrix<T> Matrix_Inverse<T>(Matrix<T> matrix);
      /// <summary>Calculates the adjoint of a matrix.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="matrix">The matrix to calculate the adjoint of.</param>
      /// <returns>The adjoint of the matrix.</returns>
      public delegate Matrix<T> Matrix_Adjoint<T>(Matrix<T> matrix);
      /// <summary>Returns the transpose of a matrix.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="matrix">The matrix to transpose.</param>
      /// <returns>The transpose of the matrix.</returns>
      public delegate Matrix<T> Matrix_Transpose<T>(Matrix<T> matrix);
      /// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="matrix">The matrix to decompose.</param>
      /// <param name="lower">The computed lower triangular matrix.</param>
      /// <param name="upper">The computed upper triangular matrix.</param>
      public delegate void Matrix_DecomposeLU<T>(Matrix<T> matrix, out Matrix<T> lower, out Matrix<T> upper);
      /// <summary>Does a value equality check.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The first matrix to check for equality.</param>
      /// <param name="right">The second matrix to check for equality.</param>
      /// <returns>True if values are equal, false if not.</returns>
      public delegate bool Matrix_EqualsByValue<T>(Matrix<T> left, Matrix<T> right);
      /// <summary>Does a value equality check with leniency.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The first matrix to check for equality.</param>
      /// <param name="right">The second matrix to check for equality.</param>
      /// <param name="leniency">How much the values can vary but still be considered equal.</param>
      /// <returns>True if values are equal, false if not.</returns>
      public delegate bool Matrix_EqualsByValue_leniency<T>(Matrix<T> left, Matrix<T> right, T leniency);

      #endregion

      #region quaternion

      /// <summary>Computes the length of quaternion.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="quaternion">The quaternion to compute the length of.</param>
      /// <returns>The length of the given quaternion.</returns>
      public delegate T Quaternion_Magnitude<T>(Quaternion<T> quaternion);
      /// <summary>Computes the length of a quaternion, but doesn't square root it.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="quaternion">The quaternion to compute the length squared of.</param>
      /// <returns>The squared length of the given quaternion.</returns>
      public delegate T Quaternion_MagnitudeSquared<T>(Quaternion<T> quaternion);
      /// <summary>Gets the conjugate of the quaternion.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="quaternion">The quaternion to conjugate.</param>
      /// <returns>The conjugate of teh given quaternion.</returns>
      public delegate Quaternion<T> Quaternion_Conjugate<T>(Quaternion<T> quaternion);
      /// <summary>Adds two quaternions together.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The first quaternion of the addition.</param>
      /// <param name="right">The second quaternion of the addition.</param>
      /// <returns>The result of the addition.</returns>
      public delegate Quaternion<T> Quaternion_Add<T>(Quaternion<T> left, Quaternion<T> right);
      /// <summary>Subtracts two quaternions.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The left quaternion of the subtraction.</param>
      /// <param name="right">The right quaternion of the subtraction.</param>
      /// <returns>The resulting quaternion after the subtraction.</returns>
      public delegate Quaternion<T> Quaternion_Subtract<T>(Quaternion<T> left, Quaternion<T> right);
      /// <summary>Multiplies two quaternions together.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The first quaternion of the multiplication.</param>
      /// <param name="right">The second quaternion of the multiplication.</param>
      /// <returns>The resulting quaternion after the multiplication.</returns>
      public delegate Quaternion<T> Quaternion_Multiply<T>(Quaternion<T> left, Quaternion<T> right);
      /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The quaternion of the multiplication.</param>
      /// <param name="right">The scalar of the multiplication.</param>
      /// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
      public delegate Quaternion<T> Quaternion_Multiply_scalar<T>(Quaternion<T> left, T right);
      /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The quaternion to pre-multiply the vector by.</param>
      /// <param name="right">The vector to be multiplied.</param>
      /// <returns>The resulting quaternion of the multiplication.</returns>
      public delegate Quaternion<T> Quaternion_Multiply_Vector<T>(Quaternion<T> left, Vector<T> right);
      /// <summary>Normalizes the quaternion.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="quaternion">The quaternion to normalize.</param>
      /// <returns>The normalization of the given quaternion.</returns>
      public delegate Quaternion<T> Quaternion_Normalize<T>(Quaternion<T> quaternion);
      /// <summary>Inverts a quaternion.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="quaternion">The quaternion to find the inverse of.</param>
      /// <returns>The inverse of the given quaternion.</returns>
      public delegate Quaternion<T> Quaternion_Invert<T>(Quaternion<T> quaternion);
      /// <summary>Lenearly interpolates between two quaternions.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The starting point of the interpolation.</param>
      /// <param name="right">The ending point of the interpolation.</param>
      /// <param name="blend">The ratio 0.0-1.0 of how far to interpolate between the left and right quaternions.</param>
      /// <returns>The result of the interpolation.</returns>
      public delegate Quaternion<T> Quaternion_Lerp<T>(Quaternion<T> left, Quaternion<T> right, T blend);
      /// <summary>Sphereically interpolates between two quaternions.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The starting point of the interpolation.</param>
      /// <param name="right">The ending point of the interpolation.</param>
      /// <param name="blend">The ratio of how far to interpolate between the left and right quaternions.</param>
      /// <returns>The result of the interpolation.</returns>
      public delegate Quaternion<T> Quaternion_Slerp<T>(Quaternion<T> left, Quaternion<T> right, T blend);
      /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="rotation">The quaternion to rotate the vector by.</param>
      /// <param name="vector">The vector to be rotated by.</param>
      /// <returns>The result of the rotation.</returns>
      public delegate Vector<T> Quaternion_Rotate<T>(Quaternion<T> rotation, Vector<T> vector);
      /// <summary>Does a value equality check.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The first quaternion to check for equality.</param>
      /// <param name="right">The second quaternion  to check for equality.</param>
      /// <returns>True if values are equal, false if not.</returns>
      public delegate bool Quaternion_EqualsValue<T>(Quaternion<T> left, Quaternion<T> right);
      /// <summary>Does a value equality check with leniency.</summary>
      /// <typeparam name="T">The numeric type of the operation.</typeparam>
      /// <param name="left">The first quaternion to check for equality.</param>
      /// <param name="right">The second quaternion to check for equality.</param>
      /// <param name="leniency">How much the values can vary but still be considered equal.</param>
      /// <returns>True if values are equal, false if not.</returns>
      public delegate bool Quaternion_EqualsValue_leniency<T>(Quaternion<T> left, Quaternion<T> right, T leniency);

      #endregion

    }

    #endregion

    #region libraries

    private static Seven.Structures.Map<object, System.Type> _linearAlgebras =
      new Seven.Structures.Map_Linked<object, System.Type>(
        (System.Type left, System.Type right) => { return left == right; },
        (System.Type type) => { return type.GetHashCode(); })
        {
          // provided libraries
          { typeof(int), LinearAlgebra.LinearAlgebra_int.Get },
          { typeof(double), LinearAlgebra.LinearAlgebra_double.Get },
          { typeof(float), LinearAlgebra.LinearAlgebra_float.Get },
          { typeof(decimal), LinearAlgebra.LinearAlgebra_decimal.Get },
          { typeof(long), LinearAlgebra.LinearAlgebra_long.Get },
          { typeof(Fraction64), LinearAlgebra.LinearAlgebra_Fraction64.Get },
          { typeof(Fraction128), LinearAlgebra.LinearAlgebra_Fraction128.Get },
        };

    /// <summary>Checks to see if a linear algebra implementaton exists for the given type.</summary>
    /// <typeparam name="T">The type to check for a linear algebra implementation.</typeparam>
    /// <returns>True is an implementation exists; false if not.</returns>
    public static bool Check<T>()
    {
      return _linearAlgebras.Contains(typeof(T));
    }

    /// <summary>Adds an implementation of linear algebra for a given type.</summary>
    /// <typeparam name="T">The type the linear algebra library operates on.</typeparam>
    /// <param name="linearAlgebra">The linear algebra library.</param>
    public static void Set<T>(LinearAlgebra<T> linearAlgebra)
    {
      _linearAlgebras[typeof(T)] = linearAlgebra;
    }

    /// <summary>Gets a linear algebra library for the given type.</summary>
    /// <typeparam name="T">The type to get a linear algebra library for.</typeparam>
    /// <returns>A linear algebra library for the given type.</returns>
    public static LinearAlgebra<T> Get<T>()
    {
      if (_linearAlgebras.Contains(typeof(T)))
        return (LinearAlgebra<T>)_linearAlgebras[typeof(T)];
      else
        return new LinearAlgebra_unsupported<T>();
    }

    #region provided

    private class LinearAlgebra_Fraction128 : LinearAlgebra<Fraction128>
    {
      #region construct-simpleton

      private LinearAlgebra_Fraction128() { _instance = this; }
      private static LinearAlgebra_Fraction128 _instance;
      private static LinearAlgebra_Fraction128 Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new LinearAlgebra_Fraction128();
          else
            return _instance;
        }
      }

      /// <summary>Gets Arithmetic for "byte" types.</summary>
      public static LinearAlgebra_Fraction128 Get { get { return Instance; } }

      #endregion

      #region vector

      /// <summary>Adds two vectors together.</summary>
      public LinearAlgebra.delegates.Vector_Add<Fraction128> Vector_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Negates all the values in a vector.</summary>
      public LinearAlgebra.delegates.Vector_Negate<Fraction128> Vector_Negate { get { return LinearAlgebra.Negate; } }
      /// <summary>Subtracts two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Subtract<Fraction128> Vector_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Multiply<Fraction128> Vector_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Divides all the components of a vector by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Divide<Fraction128> Vector_Divide { get { return LinearAlgebra.Divide; } }
      /// <summary>Computes the dot product between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_DotProduct<Fraction128> Vector_DotProduct { get { return LinearAlgebra.DotProduct; } }
      /// <summary>Computes teh cross product of two vectors.</summary>
      public LinearAlgebra.delegates.Vector_CrossProduct<Fraction128> Vector_CrossProduct { get { return LinearAlgebra.CrossProduct; } }
      /// <summary>Normalizes a vector.</summary>
      public LinearAlgebra.delegates.Vector_Normalize<Fraction128> Vector_Normalize { get { return LinearAlgebra.Normalize; } }
      /// <summary>Computes the length of a vector.</summary>
      public LinearAlgebra.delegates.Vector_Magnitude<Fraction128> Vector_Magnitude { get { return LinearAlgebra.Magnitude; } }
      /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
      public LinearAlgebra.delegates.Vector_MagnitudeSquared<Fraction128> Vector_MagnitudeSquared { get { return LinearAlgebra.MagnitudeSquared; } }
      /// <summary>Computes the angle between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Angle<Fraction128> Vector_Angle { get { return LinearAlgebra.Angle; } }
      /// <summary>Rotates a vector by the specified axis and rotation values.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy<Fraction128> Vector_RotateBy { get { return LinearAlgebra.RotateBy; } }
      /// <summary>Computes the linear interpolation between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Lerp<Fraction128> Vector_Lerp { get { return LinearAlgebra.Lerp; } }
      /// <summary>Sphereically interpolates between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Slerp<Fraction128> Vector_Slerp { get { return LinearAlgebra.Slerp; } }
      /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
      public LinearAlgebra.delegates.Vector_Blerp<Fraction128> Vector_Blerp { get { return LinearAlgebra.Blerp; } }
      /// <summary>Checks for equality by value.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue<Fraction128> Vector_EqualsValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Checks for equality by value with leniency.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue_leniency<Fraction128> Vector_EqualsValue_leniency { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Rotates a vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy_quaternion<Fraction128> Vector_RotateBy_quaternion { get { return LinearAlgebra.RotateBy; } }

      #endregion

      #region matix

      /// <summary>Negates all the values in this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Negate<Fraction128> Matrix_Negate { get { return LinearAlgebra.Negate; } }
      /// <summary>Does a standard matrix addition.</summary>
      public LinearAlgebra.delegates.Matrix_Add<Fraction128> Matrix_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Does a standard matrix subtraction.</summary>
      public LinearAlgebra.delegates.Matrix_Subtract<Fraction128> Matrix_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Does a standard matrix multiplication (triple for loop).</summary>
      public LinearAlgebra.delegates.Matrix_Multiply<Fraction128> Matrix_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Multiplies all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_scalar<Fraction128> Matrix_Multiply_scalar { get { return LinearAlgebra.Multiply; } }
      /// <summary>Premultiplies a vector by a matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_vector<Fraction128> Matrix_Multiply_vector { get { return LinearAlgebra.Multiply; } }
      /// <summary>Divides all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Divide<Fraction128> Matrix_Divide { get { return LinearAlgebra.Divide; } }
      /// <summary>Takes the matrix to the given int power.</summary>
      public LinearAlgebra.delegates.Matrix_Power<Fraction128> Matrix_Power { get { return LinearAlgebra.Power; } }
      /// <summary>Gets the minor of a matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Minor<Fraction128> Matrix_Minor { get { return LinearAlgebra.Minor; } }
      /// <summary>Combines two matrices from left to right (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
      public LinearAlgebra.delegates.Matrix_ConcatenateRowWise<Fraction128> Matrix_ConcatenateRowWise { get { return LinearAlgebra.ConcatenateRowWise; } }
      /// <summary>Computes the determinent if this matrix is square.</summary>
      public LinearAlgebra.delegates.Matrix_Determinent<Fraction128> Matrix_Determinent { get { return LinearAlgebra.Determinent; } }
      /// <summary>Computes the echelon form of this matrix (aka REF).</summary>
      public LinearAlgebra.delegates.Matrix_Echelon<Fraction128> Matrix_Echelon { get { return LinearAlgebra.Echelon; } }
      /// <summary>Computes the reduced echelon form of this matrix (aka RREF).</summary>
      public LinearAlgebra.delegates.Matrix_ReducedEchelon<Fraction128> Matrix_ReducedEchelon { get { return LinearAlgebra.ReducedEchelon; } }
      /// <summary>Computes the inverse of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Inverse<Fraction128> Matrix_Inverse { get { return LinearAlgebra.Inverse; } }
      /// <summary>Gets the adjoint of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Adjoint<Fraction128> Matrix_Adjoint { get { return LinearAlgebra.Adjoint; } }
      /// <summary>Transposes this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Transpose<Fraction128> Matrix_Transpose { get { return LinearAlgebra.Transpose; } }
      /// <summary>Decomposes a matrix to lower/upper components.</summary>
      public LinearAlgebra.delegates.Matrix_DecomposeLU<Fraction128> Matrix_DecomposeLU { get { return LinearAlgebra.DecomposeLU; } }
      /// <summary>Dtermines equality but value.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue<Fraction128> Matrix_EqualsByValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Determines equality by value with leniency.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue_leniency<Fraction128> Matrix_EqualsByValue_leniency { get { return LinearAlgebra.EqualsValue; } }

      #endregion

      #region quaterion

      /// <summary>Computes the length of quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Magnitude<Fraction128> Quaternion_Magnitude { get { return LinearAlgebra.Magnitude; } }
      /// <summary>Computes the length of a quaternion, but doesn't square root it.</summary>
      public LinearAlgebra.delegates.Quaternion_MagnitudeSquared<Fraction128> Quaternion_MagnitudeSquared { get { return LinearAlgebra.MagnitudeSquared; } }
      /// <summary>Gets the conjugate of the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Conjugate<Fraction128> Quaternion_Conjugate { get { return LinearAlgebra.Conjugate; } }
      /// <summary>Adds two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Add<Fraction128> Quaternion_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Subtracts two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Subtract<Fraction128> Quaternion_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Multiplies two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply<Fraction128> Quaternion_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_scalar<Fraction128> Quaternion_Multiply_scalar { get { return LinearAlgebra.Multiply; } }
      /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_Vector<Fraction128> Quaternion_Multiply_Vector { get { return LinearAlgebra.Multiply; } }
      /// <summary>Normalizes the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Normalize<Fraction128> Quaternion_Normalize { get { return LinearAlgebra.Normalize; } }
      /// <summary>Inverts a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Invert<Fraction128> Quaternion_Invert { get { return LinearAlgebra.Invert; } }
      /// <summary>Lenearly interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Lerp<Fraction128> Quaternion_Lerp { get { return LinearAlgebra.Lerp; } }
      /// <summary>Sphereically interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Slerp<Fraction128> Quaternion_Slerp { get { return LinearAlgebra.Slerp; } }
      /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
      public LinearAlgebra.delegates.Quaternion_Rotate<Fraction128> Quaternion_Rotate { get { return LinearAlgebra.Rotate; } }
      /// <summary>Does a value equality check.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue<Fraction128> Quaternion_EqualsValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Does a value equality check with leniency.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<Fraction128> Quaternion_EqualsValue_leniency { get { return LinearAlgebra.EqualsValue; } }

      #endregion
    }

    private class LinearAlgebra_Fraction64 : LinearAlgebra<Fraction64>
    {
      #region construct-simpleton

      private LinearAlgebra_Fraction64() { _instance = this; }
      private static LinearAlgebra_Fraction64 _instance;
      private static LinearAlgebra_Fraction64 Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new LinearAlgebra_Fraction64();
          else
            return _instance;
        }
      }

      /// <summary>Gets Arithmetic for "byte" types.</summary>
      public static LinearAlgebra_Fraction64 Get { get { return Instance; } }

      #endregion

      #region vector

      /// <summary>Adds two vectors together.</summary>
      public LinearAlgebra.delegates.Vector_Add<Fraction64> Vector_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Negates all the values in a vector.</summary>
      public LinearAlgebra.delegates.Vector_Negate<Fraction64> Vector_Negate { get { return LinearAlgebra.Negate; } }
      /// <summary>Subtracts two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Subtract<Fraction64> Vector_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Multiply<Fraction64> Vector_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Divides all the components of a vector by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Divide<Fraction64> Vector_Divide { get { return LinearAlgebra.Divide; } }
      /// <summary>Computes the dot product between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_DotProduct<Fraction64> Vector_DotProduct { get { return LinearAlgebra.DotProduct; } }
      /// <summary>Computes teh cross product of two vectors.</summary>
      public LinearAlgebra.delegates.Vector_CrossProduct<Fraction64> Vector_CrossProduct { get { return LinearAlgebra.CrossProduct; } }
      /// <summary>Normalizes a vector.</summary>
      public LinearAlgebra.delegates.Vector_Normalize<Fraction64> Vector_Normalize { get { return LinearAlgebra.Normalize; } }
      /// <summary>Computes the length of a vector.</summary>
      public LinearAlgebra.delegates.Vector_Magnitude<Fraction64> Vector_Magnitude { get { return LinearAlgebra.Magnitude; } }
      /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
      public LinearAlgebra.delegates.Vector_MagnitudeSquared<Fraction64> Vector_MagnitudeSquared { get { return LinearAlgebra.MagnitudeSquared; } }
      /// <summary>Computes the angle between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Angle<Fraction64> Vector_Angle { get { return LinearAlgebra.Angle; } }
      /// <summary>Rotates a vector by the specified axis and rotation values.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy<Fraction64> Vector_RotateBy { get { return LinearAlgebra.RotateBy; } }
      /// <summary>Computes the linear interpolation between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Lerp<Fraction64> Vector_Lerp { get { return LinearAlgebra.Lerp; } }
      /// <summary>Sphereically interpolates between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Slerp<Fraction64> Vector_Slerp { get { return LinearAlgebra.Slerp; } }
      /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
      public LinearAlgebra.delegates.Vector_Blerp<Fraction64> Vector_Blerp { get { return LinearAlgebra.Blerp; } }
      /// <summary>Checks for equality by value.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue<Fraction64> Vector_EqualsValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Checks for equality by value with leniency.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue_leniency<Fraction64> Vector_EqualsValue_leniency { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Rotates a vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy_quaternion<Fraction64> Vector_RotateBy_quaternion { get { return LinearAlgebra.RotateBy; } }

      #endregion

      #region matix

      /// <summary>Negates all the values in this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Negate<Fraction64> Matrix_Negate { get { return LinearAlgebra.Negate; } }
      /// <summary>Does a standard matrix addition.</summary>
      public LinearAlgebra.delegates.Matrix_Add<Fraction64> Matrix_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Does a standard matrix subtraction.</summary>
      public LinearAlgebra.delegates.Matrix_Subtract<Fraction64> Matrix_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Does a standard matrix multiplication (triple for loop).</summary>
      public LinearAlgebra.delegates.Matrix_Multiply<Fraction64> Matrix_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Multiplies all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_scalar<Fraction64> Matrix_Multiply_scalar { get { return LinearAlgebra.Multiply; } }
      /// <summary>Premultiplies a vector by a matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_vector<Fraction64> Matrix_Multiply_vector { get { return LinearAlgebra.Multiply; } }
      /// <summary>Divides all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Divide<Fraction64> Matrix_Divide { get { return LinearAlgebra.Divide; } }
      /// <summary>Takes the matrix to the given int power.</summary>
      public LinearAlgebra.delegates.Matrix_Power<Fraction64> Matrix_Power { get { return LinearAlgebra.Power; } }
      /// <summary>Gets the minor of a matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Minor<Fraction64> Matrix_Minor { get { return LinearAlgebra.Minor; } }
      /// <summary>Combines two matrices from left to right (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
      public LinearAlgebra.delegates.Matrix_ConcatenateRowWise<Fraction64> Matrix_ConcatenateRowWise { get { return LinearAlgebra.ConcatenateRowWise; } }
      /// <summary>Computes the determinent if this matrix is square.</summary>
      public LinearAlgebra.delegates.Matrix_Determinent<Fraction64> Matrix_Determinent { get { return LinearAlgebra.Determinent; } }
      /// <summary>Computes the echelon form of this matrix (aka REF).</summary>
      public LinearAlgebra.delegates.Matrix_Echelon<Fraction64> Matrix_Echelon { get { return LinearAlgebra.Echelon; } }
      /// <summary>Computes the reduced echelon form of this matrix (aka RREF).</summary>
      public LinearAlgebra.delegates.Matrix_ReducedEchelon<Fraction64> Matrix_ReducedEchelon { get { return LinearAlgebra.ReducedEchelon; } }
      /// <summary>Computes the inverse of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Inverse<Fraction64> Matrix_Inverse { get { return LinearAlgebra.Inverse; } }
      /// <summary>Gets the adjoint of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Adjoint<Fraction64> Matrix_Adjoint { get { return LinearAlgebra.Adjoint; } }
      /// <summary>Transposes this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Transpose<Fraction64> Matrix_Transpose { get { return LinearAlgebra.Transpose; } }
      /// <summary>Decomposes a matrix to lower/upper components.</summary>
      public LinearAlgebra.delegates.Matrix_DecomposeLU<Fraction64> Matrix_DecomposeLU { get { return LinearAlgebra.DecomposeLU; } }
      /// <summary>Dtermines equality but value.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue<Fraction64> Matrix_EqualsByValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Determines equality by value with leniency.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue_leniency<Fraction64> Matrix_EqualsByValue_leniency { get { return LinearAlgebra.EqualsValue; } }

      #endregion

      #region quaterion

      /// <summary>Computes the length of quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Magnitude<Fraction64> Quaternion_Magnitude { get { return LinearAlgebra.Magnitude; } }
      /// <summary>Computes the length of a quaternion, but doesn't square root it.</summary>
      public LinearAlgebra.delegates.Quaternion_MagnitudeSquared<Fraction64> Quaternion_MagnitudeSquared { get { return LinearAlgebra.MagnitudeSquared; } }
      /// <summary>Gets the conjugate of the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Conjugate<Fraction64> Quaternion_Conjugate { get { return LinearAlgebra.Conjugate; } }
      /// <summary>Adds two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Add<Fraction64> Quaternion_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Subtracts two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Subtract<Fraction64> Quaternion_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Multiplies two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply<Fraction64> Quaternion_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_scalar<Fraction64> Quaternion_Multiply_scalar { get { return LinearAlgebra.Multiply; } }
      /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_Vector<Fraction64> Quaternion_Multiply_Vector { get { return LinearAlgebra.Multiply; } }
      /// <summary>Normalizes the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Normalize<Fraction64> Quaternion_Normalize { get { return LinearAlgebra.Normalize; } }
      /// <summary>Inverts a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Invert<Fraction64> Quaternion_Invert { get { return LinearAlgebra.Invert; } }
      /// <summary>Lenearly interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Lerp<Fraction64> Quaternion_Lerp { get { return LinearAlgebra.Lerp; } }
      /// <summary>Sphereically interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Slerp<Fraction64> Quaternion_Slerp { get { return LinearAlgebra.Slerp; } }
      /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
      public LinearAlgebra.delegates.Quaternion_Rotate<Fraction64> Quaternion_Rotate { get { return LinearAlgebra.Rotate; } }
      /// <summary>Does a value equality check.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue<Fraction64> Quaternion_EqualsValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Does a value equality check with leniency.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<Fraction64> Quaternion_EqualsValue_leniency { get { return LinearAlgebra.EqualsValue; } }

      #endregion
    }

    private class LinearAlgebra_decimal : LinearAlgebra<decimal>
    {
      #region construct-simpleton

      private LinearAlgebra_decimal() { _instance = this; }
      private static LinearAlgebra_decimal _instance;
      private static LinearAlgebra_decimal Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new LinearAlgebra_decimal();
          else
            return _instance;
        }
      }

      /// <summary>Gets Arithmetic for "byte" types.</summary>
      public static LinearAlgebra_decimal Get { get { return Instance; } }

      #endregion

      #region vector

      /// <summary>Adds two vectors together.</summary>
      public LinearAlgebra.delegates.Vector_Add<decimal> Vector_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Negates all the values in a vector.</summary>
      public LinearAlgebra.delegates.Vector_Negate<decimal> Vector_Negate { get { return LinearAlgebra.Negate; } }
      /// <summary>Subtracts two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Subtract<decimal> Vector_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Multiply<decimal> Vector_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Divides all the components of a vector by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Divide<decimal> Vector_Divide { get { return LinearAlgebra.Divide; } }
      /// <summary>Computes the dot product between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_DotProduct<decimal> Vector_DotProduct { get { return LinearAlgebra.DotProduct; } }
      /// <summary>Computes teh cross product of two vectors.</summary>
      public LinearAlgebra.delegates.Vector_CrossProduct<decimal> Vector_CrossProduct { get { return LinearAlgebra.CrossProduct; } }
      /// <summary>Normalizes a vector.</summary>
      public LinearAlgebra.delegates.Vector_Normalize<decimal> Vector_Normalize { get { return LinearAlgebra.Normalize; } }
      /// <summary>Computes the length of a vector.</summary>
      public LinearAlgebra.delegates.Vector_Magnitude<decimal> Vector_Magnitude { get { return LinearAlgebra.Magnitude; } }
      /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
      public LinearAlgebra.delegates.Vector_MagnitudeSquared<decimal> Vector_MagnitudeSquared { get { return LinearAlgebra.MagnitudeSquared; } }
      /// <summary>Computes the angle between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Angle<decimal> Vector_Angle { get { return LinearAlgebra.Angle; } }
      /// <summary>Rotates a vector by the specified axis and rotation values.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy<decimal> Vector_RotateBy { get { return LinearAlgebra.RotateBy; } }
      /// <summary>Computes the linear interpolation between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Lerp<decimal> Vector_Lerp { get { return LinearAlgebra.Lerp; } }
      /// <summary>Sphereically interpolates between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Slerp<decimal> Vector_Slerp { get { return LinearAlgebra.Slerp; } }
      /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
      public LinearAlgebra.delegates.Vector_Blerp<decimal> Vector_Blerp { get { return LinearAlgebra.Blerp; } }
      /// <summary>Checks for equality by value.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue<decimal> Vector_EqualsValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Checks for equality by value with leniency.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue_leniency<decimal> Vector_EqualsValue_leniency { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Rotates a vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy_quaternion<decimal> Vector_RotateBy_quaternion { get { return LinearAlgebra.RotateBy; } }

      #endregion

      #region matix

      /// <summary>Negates all the values in this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Negate<decimal> Matrix_Negate { get { return LinearAlgebra.Negate; } }
      /// <summary>Does a standard matrix addition.</summary>
      public LinearAlgebra.delegates.Matrix_Add<decimal> Matrix_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Does a standard matrix subtraction.</summary>
      public LinearAlgebra.delegates.Matrix_Subtract<decimal> Matrix_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Does a standard matrix multiplication (triple for loop).</summary>
      public LinearAlgebra.delegates.Matrix_Multiply<decimal> Matrix_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Multiplies all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_scalar<decimal> Matrix_Multiply_scalar { get { return LinearAlgebra.Multiply; } }
      /// <summary>Premultiplies a vector by a matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_vector<decimal> Matrix_Multiply_vector { get { return LinearAlgebra.Multiply; } }
      /// <summary>Divides all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Divide<decimal> Matrix_Divide { get { return LinearAlgebra.Divide; } }
      /// <summary>Takes the matrix to the given int power.</summary>
      public LinearAlgebra.delegates.Matrix_Power<decimal> Matrix_Power { get { return LinearAlgebra.Power; } }
      /// <summary>Gets the minor of a matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Minor<decimal> Matrix_Minor { get { return LinearAlgebra.Minor; } }
      /// <summary>Combines two matrices from left to right (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
      public LinearAlgebra.delegates.Matrix_ConcatenateRowWise<decimal> Matrix_ConcatenateRowWise { get { return LinearAlgebra.ConcatenateRowWise; } }
      /// <summary>Computes the determinent if this matrix is square.</summary>
      public LinearAlgebra.delegates.Matrix_Determinent<decimal> Matrix_Determinent { get { return LinearAlgebra.Determinent; } }
      /// <summary>Computes the echelon form of this matrix (aka REF).</summary>
      public LinearAlgebra.delegates.Matrix_Echelon<decimal> Matrix_Echelon { get { return LinearAlgebra.Echelon; } }
      /// <summary>Computes the reduced echelon form of this matrix (aka RREF).</summary>
      public LinearAlgebra.delegates.Matrix_ReducedEchelon<decimal> Matrix_ReducedEchelon { get { return LinearAlgebra.ReducedEchelon; } }
      /// <summary>Computes the inverse of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Inverse<decimal> Matrix_Inverse { get { return LinearAlgebra.Inverse; } }
      /// <summary>Gets the adjoint of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Adjoint<decimal> Matrix_Adjoint { get { return LinearAlgebra.Adjoint; } }
      /// <summary>Transposes this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Transpose<decimal> Matrix_Transpose { get { return LinearAlgebra.Transpose; } }
      /// <summary>Decomposes a matrix to lower/upper components.</summary>
      public LinearAlgebra.delegates.Matrix_DecomposeLU<decimal> Matrix_DecomposeLU { get { return LinearAlgebra.DecomposeLU; } }
      /// <summary>Dtermines equality but value.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue<decimal> Matrix_EqualsByValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Determines equality by value with leniency.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue_leniency<decimal> Matrix_EqualsByValue_leniency { get { return LinearAlgebra.EqualsValue; } }

      #endregion

      #region quaterion

      /// <summary>Computes the length of quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Magnitude<decimal> Quaternion_Magnitude { get { return LinearAlgebra.Magnitude; } }
      /// <summary>Computes the length of a quaternion, but doesn't square root it.</summary>
      public LinearAlgebra.delegates.Quaternion_MagnitudeSquared<decimal> Quaternion_MagnitudeSquared { get { return LinearAlgebra.MagnitudeSquared; } }
      /// <summary>Gets the conjugate of the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Conjugate<decimal> Quaternion_Conjugate { get { return LinearAlgebra.Conjugate; } }
      /// <summary>Adds two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Add<decimal> Quaternion_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Subtracts two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Subtract<decimal> Quaternion_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Multiplies two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply<decimal> Quaternion_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_scalar<decimal> Quaternion_Multiply_scalar { get { return LinearAlgebra.Multiply; } }
      /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_Vector<decimal> Quaternion_Multiply_Vector { get { return LinearAlgebra.Multiply; } }
      /// <summary>Normalizes the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Normalize<decimal> Quaternion_Normalize { get { return LinearAlgebra.Normalize; } }
      /// <summary>Inverts a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Invert<decimal> Quaternion_Invert { get { return LinearAlgebra.Invert; } }
      /// <summary>Lenearly interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Lerp<decimal> Quaternion_Lerp { get { return LinearAlgebra.Lerp; } }
      /// <summary>Sphereically interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Slerp<decimal> Quaternion_Slerp { get { return LinearAlgebra.Slerp; } }
      /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
      public LinearAlgebra.delegates.Quaternion_Rotate<decimal> Quaternion_Rotate { get { return LinearAlgebra.Rotate; } }
      /// <summary>Does a value equality check.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue<decimal> Quaternion_EqualsValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Does a value equality check with leniency.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<decimal> Quaternion_EqualsValue_leniency { get { return LinearAlgebra.EqualsValue; } }

      #endregion
    }

    private class LinearAlgebra_double : LinearAlgebra<double>
    {
      #region construct-simpleton

      private LinearAlgebra_double() { _instance = this; }
      private static LinearAlgebra_double _instance;
      private static LinearAlgebra_double Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new LinearAlgebra_double();
          else
            return _instance;
        }
      }

      /// <summary>Gets Arithmetic for "byte" types.</summary>
      public static LinearAlgebra_double Get { get { return Instance; } }

      #endregion

      #region vector

      /// <summary>Adds two vectors together.</summary>
      public LinearAlgebra.delegates.Vector_Add<double> Vector_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Negates all the values in a vector.</summary>
      public LinearAlgebra.delegates.Vector_Negate<double> Vector_Negate { get { return LinearAlgebra.Negate; } }
      /// <summary>Subtracts two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Subtract<double> Vector_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Multiply<double> Vector_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Divides all the components of a vector by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Divide<double> Vector_Divide { get { return LinearAlgebra.Divide; } }
      /// <summary>Computes the dot product between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_DotProduct<double> Vector_DotProduct { get { return LinearAlgebra.DotProduct; } }
      /// <summary>Computes teh cross product of two vectors.</summary>
      public LinearAlgebra.delegates.Vector_CrossProduct<double> Vector_CrossProduct { get { return LinearAlgebra.CrossProduct; } }
      /// <summary>Normalizes a vector.</summary>
      public LinearAlgebra.delegates.Vector_Normalize<double> Vector_Normalize { get { return LinearAlgebra.Normalize; } }
      /// <summary>Computes the length of a vector.</summary>
      public LinearAlgebra.delegates.Vector_Magnitude<double> Vector_Magnitude { get { return LinearAlgebra.Magnitude; } }
      /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
      public LinearAlgebra.delegates.Vector_MagnitudeSquared<double> Vector_MagnitudeSquared { get { return LinearAlgebra.MagnitudeSquared; } }
      /// <summary>Computes the angle between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Angle<double> Vector_Angle { get { return LinearAlgebra.Angle; } }
      /// <summary>Rotates a vector by the specified axis and rotation values.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy<double> Vector_RotateBy { get { return LinearAlgebra.RotateBy; } }
      /// <summary>Computes the linear interpolation between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Lerp<double> Vector_Lerp { get { return LinearAlgebra.Lerp; } }
      /// <summary>Sphereically interpolates between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Slerp<double> Vector_Slerp { get { return LinearAlgebra.Slerp; } }
      /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
      public LinearAlgebra.delegates.Vector_Blerp<double> Vector_Blerp { get { return LinearAlgebra.Blerp; } }
      /// <summary>Checks for equality by value.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue<double> Vector_EqualsValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Checks for equality by value with leniency.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue_leniency<double> Vector_EqualsValue_leniency { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Rotates a vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy_quaternion<double> Vector_RotateBy_quaternion { get { return LinearAlgebra.RotateBy; } }

      #endregion

      #region matrix

      /// <summary>Negates all the values in this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Negate<double> Matrix_Negate { get { return LinearAlgebra.Negate; } }
      /// <summary>Does a standard matrix addition.</summary>
      public LinearAlgebra.delegates.Matrix_Add<double> Matrix_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Does a standard matrix subtraction.</summary>
      public LinearAlgebra.delegates.Matrix_Subtract<double> Matrix_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Does a standard matrix multiplication (triple for loop).</summary>
      public LinearAlgebra.delegates.Matrix_Multiply<double> Matrix_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Multiplies all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_scalar<double> Matrix_Multiply_scalar { get { return LinearAlgebra.Multiply; } }
      /// <summary>Premultiplies a vector by a matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_vector<double> Matrix_Multiply_vector { get { return LinearAlgebra.Multiply; } }
      /// <summary>Divides all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Divide<double> Matrix_Divide { get { return LinearAlgebra.Divide; } }
      /// <summary>Takes the matrix to the given int power.</summary>
      public LinearAlgebra.delegates.Matrix_Power<double> Matrix_Power { get { return LinearAlgebra.Power; } }
      /// <summary>Gets the minor of a matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Minor<double> Matrix_Minor { get { return LinearAlgebra.Minor; } }
      /// <summary>Combines two matrices from left to right (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
      public LinearAlgebra.delegates.Matrix_ConcatenateRowWise<double> Matrix_ConcatenateRowWise { get { return LinearAlgebra.ConcatenateRowWise; } }
      /// <summary>Computes the determinent if this matrix is square.</summary>
      public LinearAlgebra.delegates.Matrix_Determinent<double> Matrix_Determinent { get { return LinearAlgebra.Determinent; } }
      /// <summary>Computes the echelon form of this matrix (aka REF).</summary>
      public LinearAlgebra.delegates.Matrix_Echelon<double> Matrix_Echelon { get { return LinearAlgebra.Echelon; } }
      /// <summary>Computes the reduced echelon form of this matrix (aka RREF).</summary>
      public LinearAlgebra.delegates.Matrix_ReducedEchelon<double> Matrix_ReducedEchelon { get { return LinearAlgebra.ReducedEchelon; } }
      /// <summary>Computes the inverse of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Inverse<double> Matrix_Inverse { get { return LinearAlgebra.Inverse; } }
      /// <summary>Gets the adjoint of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Adjoint<double> Matrix_Adjoint { get { return LinearAlgebra.Adjoint; } }
      /// <summary>Transposes this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Transpose<double> Matrix_Transpose { get { return LinearAlgebra.Transpose; } }
      /// <summary>Decomposes a matrix to lower/upper components.</summary>
      public LinearAlgebra.delegates.Matrix_DecomposeLU<double> Matrix_DecomposeLU { get { return LinearAlgebra.DecomposeLU; } }
      /// <summary>Dtermines equality but value.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue<double> Matrix_EqualsByValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Determines equality by value with leniency.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue_leniency<double> Matrix_EqualsByValue_leniency { get { return LinearAlgebra.EqualsValue; } }

      #endregion

      #region quaterion

      /// <summary>Computes the length of quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Magnitude<double> Quaternion_Magnitude { get { return LinearAlgebra.Magnitude; } }
      /// <summary>Computes the length of a quaternion, but doesn't square root it.</summary>
      public LinearAlgebra.delegates.Quaternion_MagnitudeSquared<double> Quaternion_MagnitudeSquared { get { return LinearAlgebra.MagnitudeSquared; } }
      /// <summary>Gets the conjugate of the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Conjugate<double> Quaternion_Conjugate { get { return LinearAlgebra.Conjugate; } }
      /// <summary>Adds two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Add<double> Quaternion_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Subtracts two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Subtract<double> Quaternion_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Multiplies two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply<double> Quaternion_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_scalar<double> Quaternion_Multiply_scalar { get { return LinearAlgebra.Multiply; } }
      /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_Vector<double> Quaternion_Multiply_Vector { get { return LinearAlgebra.Multiply; } }
      /// <summary>Normalizes the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Normalize<double> Quaternion_Normalize { get { return LinearAlgebra.Normalize; } }
      /// <summary>Inverts a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Invert<double> Quaternion_Invert { get { return LinearAlgebra.Invert; } }
      /// <summary>Lenearly interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Lerp<double> Quaternion_Lerp { get { return LinearAlgebra.Lerp; } }
      /// <summary>Sphereically interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Slerp<double> Quaternion_Slerp { get { return LinearAlgebra.Slerp; } }
      /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
      public LinearAlgebra.delegates.Quaternion_Rotate<double> Quaternion_Rotate { get { return LinearAlgebra.Rotate; } }
      /// <summary>Does a value equality check.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue<double> Quaternion_EqualsValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Does a value equality check with leniency.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<double> Quaternion_EqualsValue_leniency { get { return LinearAlgebra.EqualsValue; } }

      #endregion
    }

    private class LinearAlgebra_float : LinearAlgebra<float>
    {
      #region construct-simpleton

      private LinearAlgebra_float() { _instance = this; }
      private static LinearAlgebra_float _instance;
      private static LinearAlgebra_float Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new LinearAlgebra_float();
          else
            return _instance;
        }
      }

      /// <summary>Gets Arithmetic for "byte" types.</summary>
      public static LinearAlgebra_float Get { get { return Instance; } }

      #endregion

      #region vector

      /// <summary>Adds two vectors together.</summary>
      public LinearAlgebra.delegates.Vector_Add<float> Vector_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Negates all the values in a vector.</summary>
      public LinearAlgebra.delegates.Vector_Negate<float> Vector_Negate { get { return LinearAlgebra.Negate; } }
      /// <summary>Subtracts two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Subtract<float> Vector_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Multiply<float> Vector_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Divides all the components of a vector by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Divide<float> Vector_Divide { get { return LinearAlgebra.Divide; } }
      /// <summary>Computes the dot product between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_DotProduct<float> Vector_DotProduct { get { return LinearAlgebra.DotProduct; } }
      /// <summary>Computes teh cross product of two vectors.</summary>
      public LinearAlgebra.delegates.Vector_CrossProduct<float> Vector_CrossProduct { get { return LinearAlgebra.CrossProduct; } }
      /// <summary>Normalizes a vector.</summary>
      public LinearAlgebra.delegates.Vector_Normalize<float> Vector_Normalize { get { return LinearAlgebra.Normalize; } }
      /// <summary>Computes the length of a vector.</summary>
      public LinearAlgebra.delegates.Vector_Magnitude<float> Vector_Magnitude { get { return LinearAlgebra.Magnitude; } }
      /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
      public LinearAlgebra.delegates.Vector_MagnitudeSquared<float> Vector_MagnitudeSquared { get { return LinearAlgebra.MagnitudeSquared; } }
      /// <summary>Computes the angle between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Angle<float> Vector_Angle { get { return LinearAlgebra.Angle; } }
      /// <summary>Rotates a vector by the specified axis and rotation values.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy<float> Vector_RotateBy { get { return LinearAlgebra.RotateBy; } }
      /// <summary>Computes the linear interpolation between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Lerp<float> Vector_Lerp { get { return LinearAlgebra.Lerp; } }
      /// <summary>Sphereically interpolates between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Slerp<float> Vector_Slerp { get { return LinearAlgebra.Slerp; } }
      /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
      public LinearAlgebra.delegates.Vector_Blerp<float> Vector_Blerp { get { return LinearAlgebra.Blerp; } }
      /// <summary>Checks for equality by value.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue<float> Vector_EqualsValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Checks for equality by value with leniency.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue_leniency<float> Vector_EqualsValue_leniency { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Rotates a vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy_quaternion<float> Vector_RotateBy_quaternion { get { return LinearAlgebra.RotateBy; } }

      #endregion

      #region matrix

      /// <summary>Negates all the values in this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Negate<float> Matrix_Negate { get { return LinearAlgebra.Negate; } }
      /// <summary>Does a standard matrix addition.</summary>
      public LinearAlgebra.delegates.Matrix_Add<float> Matrix_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Does a standard matrix subtraction.</summary>
      public LinearAlgebra.delegates.Matrix_Subtract<float> Matrix_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Does a standard matrix multiplication (triple for loop).</summary>
      public LinearAlgebra.delegates.Matrix_Multiply<float> Matrix_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Multiplies all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_scalar<float> Matrix_Multiply_scalar { get { return LinearAlgebra.Multiply; } }
      /// <summary>Premultiplies a vector by a matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_vector<float> Matrix_Multiply_vector { get { return LinearAlgebra.Multiply; } }
      /// <summary>Divides all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Divide<float> Matrix_Divide { get { return LinearAlgebra.Divide; } }
      /// <summary>Takes the matrix to the given int power.</summary>
      public LinearAlgebra.delegates.Matrix_Power<float> Matrix_Power { get { return LinearAlgebra.Power; } }
      /// <summary>Gets the minor of a matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Minor<float> Matrix_Minor { get { return LinearAlgebra.Minor; } }
      /// <summary>Combines two matrices from left to right (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
      public LinearAlgebra.delegates.Matrix_ConcatenateRowWise<float> Matrix_ConcatenateRowWise { get { return LinearAlgebra.ConcatenateRowWise; } }
      /// <summary>Computes the determinent if this matrix is square.</summary>
      public LinearAlgebra.delegates.Matrix_Determinent<float> Matrix_Determinent { get { return LinearAlgebra.Determinent; } }
      /// <summary>Computes the echelon form of this matrix (aka REF).</summary>
      public LinearAlgebra.delegates.Matrix_Echelon<float> Matrix_Echelon { get { return LinearAlgebra.Echelon; } }
      /// <summary>Computes the reduced echelon form of this matrix (aka RREF).</summary>
      public LinearAlgebra.delegates.Matrix_ReducedEchelon<float> Matrix_ReducedEchelon { get { return LinearAlgebra.ReducedEchelon; } }
      /// <summary>Computes the inverse of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Inverse<float> Matrix_Inverse { get { return LinearAlgebra.Inverse; } }
      /// <summary>Gets the adjoint of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Adjoint<float> Matrix_Adjoint { get { return LinearAlgebra.Adjoint; } }
      /// <summary>Transposes this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Transpose<float> Matrix_Transpose { get { return LinearAlgebra.Transpose; } }
      /// <summary>Decomposes a matrix to lower/upper components.</summary>
      public LinearAlgebra.delegates.Matrix_DecomposeLU<float> Matrix_DecomposeLU { get { return LinearAlgebra.DecomposeLU; } }
      /// <summary>Dtermines equality but value.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue<float> Matrix_EqualsByValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Determines equality by value with leniency.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue_leniency<float> Matrix_EqualsByValue_leniency { get { return LinearAlgebra.EqualsValue; } }

      #endregion

      #region quaterion

      /// <summary>Computes the length of quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Magnitude<float> Quaternion_Magnitude { get { return LinearAlgebra.Magnitude; } }
      /// <summary>Computes the length of a quaternion, but doesn't square root it.</summary>
      public LinearAlgebra.delegates.Quaternion_MagnitudeSquared<float> Quaternion_MagnitudeSquared { get { return LinearAlgebra.MagnitudeSquared; } }
      /// <summary>Gets the conjugate of the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Conjugate<float> Quaternion_Conjugate { get { return LinearAlgebra.Conjugate; } }
      /// <summary>Adds two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Add<float> Quaternion_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Subtracts two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Subtract<float> Quaternion_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Multiplies two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply<float> Quaternion_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_scalar<float> Quaternion_Multiply_scalar { get { return LinearAlgebra.Multiply; } }
      /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_Vector<float> Quaternion_Multiply_Vector { get { return LinearAlgebra.Multiply; } }
      /// <summary>Normalizes the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Normalize<float> Quaternion_Normalize { get { return LinearAlgebra.Normalize; } }
      /// <summary>Inverts a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Invert<float> Quaternion_Invert { get { return LinearAlgebra.Invert; } }
      /// <summary>Lenearly interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Lerp<float> Quaternion_Lerp { get { return LinearAlgebra.Lerp; } }
      /// <summary>Sphereically interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Slerp<float> Quaternion_Slerp { get { return LinearAlgebra.Slerp; } }
      /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
      public LinearAlgebra.delegates.Quaternion_Rotate<float> Quaternion_Rotate { get { return LinearAlgebra.Rotate; } }
      /// <summary>Does a value equality check.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue<float> Quaternion_EqualsValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Does a value equality check with leniency.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<float> Quaternion_EqualsValue_leniency { get { return LinearAlgebra.EqualsValue; } }

      #endregion
    }

    private class LinearAlgebra_long : LinearAlgebra<long>
    {
      #region construct-simpleton

      private LinearAlgebra_long() { _instance = this; }
      private static LinearAlgebra_long _instance;
      private static LinearAlgebra_long Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new LinearAlgebra_long();
          else
            return _instance;
        }
      }

      /// <summary>Gets Arithmetic for "byte" types.</summary>
      public static LinearAlgebra_long Get { get { return Instance; } }

      #endregion

      #region vector

      /// <summary>Adds two vectors together.</summary>
      public LinearAlgebra.delegates.Vector_Add<long> Vector_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Negates all the values in a vector.</summary>
      public LinearAlgebra.delegates.Vector_Negate<long> Vector_Negate { get { return LinearAlgebra.Negate; } }
      /// <summary>Subtracts two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Subtract<long> Vector_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Multiply<long> Vector_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Divides all the components of a vector by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Divide<long> Vector_Divide { get { return LinearAlgebra.Divide; } }
      /// <summary>Computes the dot product between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_DotProduct<long> Vector_DotProduct { get { return LinearAlgebra.DotProduct; } }
      /// <summary>Computes teh cross product of two vectors.</summary>
      public LinearAlgebra.delegates.Vector_CrossProduct<long> Vector_CrossProduct { get { return LinearAlgebra.CrossProduct; } }
      /// <summary>Normalizes a vector.</summary>
      public LinearAlgebra.delegates.Vector_Normalize<long> Vector_Normalize { get { return LinearAlgebra.Normalize; } }
      /// <summary>Computes the length of a vector.</summary>
      public LinearAlgebra.delegates.Vector_Magnitude<long> Vector_Magnitude { get { return LinearAlgebra.Magnitude; } }
      /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
      public LinearAlgebra.delegates.Vector_MagnitudeSquared<long> Vector_MagnitudeSquared { get { return LinearAlgebra.MagnitudeSquared; } }
      /// <summary>Computes the angle between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Angle<long> Vector_Angle { get { return LinearAlgebra.Angle; } }
      /// <summary>Rotates a vector by the specified axis and rotation values.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy<long> Vector_RotateBy { get { return LinearAlgebra.RotateBy; } }
      /// <summary>Computes the linear interpolation between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Lerp<long> Vector_Lerp { get { return LinearAlgebra.Lerp; } }
      /// <summary>Sphereically interpolates between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Slerp<long> Vector_Slerp { get { return LinearAlgebra.Slerp; } }
      /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
      public LinearAlgebra.delegates.Vector_Blerp<long> Vector_Blerp { get { return LinearAlgebra.Blerp; } }
      /// <summary>Checks for equality by value.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue<long> Vector_EqualsValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Checks for equality by value with leniency.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue_leniency<long> Vector_EqualsValue_leniency { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Rotates a vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy_quaternion<long> Vector_RotateBy_quaternion { get { return LinearAlgebra.RotateBy; } }

      #endregion

      #region matrix

      /// <summary>Negates all the values in this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Negate<long> Matrix_Negate { get { return LinearAlgebra.Negate; } }
      /// <summary>Does a standard matrix addition.</summary>
      public LinearAlgebra.delegates.Matrix_Add<long> Matrix_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Does a standard matrix subtraction.</summary>
      public LinearAlgebra.delegates.Matrix_Subtract<long> Matrix_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Does a standard matrix multiplication (triple for loop).</summary>
      public LinearAlgebra.delegates.Matrix_Multiply<long> Matrix_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Multiplies all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_scalar<long> Matrix_Multiply_scalar { get { return LinearAlgebra.Multiply; } }
      /// <summary>Premultiplies a vector by a matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_vector<long> Matrix_Multiply_vector { get { return LinearAlgebra.Multiply; } }
      /// <summary>Divides all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Divide<long> Matrix_Divide { get { return LinearAlgebra.Divide; } }
      /// <summary>Takes the matrix to the given int power.</summary>
      public LinearAlgebra.delegates.Matrix_Power<long> Matrix_Power { get { return LinearAlgebra.Power; } }
      /// <summary>Gets the minor of a matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Minor<long> Matrix_Minor { get { return LinearAlgebra.Minor; } }
      /// <summary>Combines two matrices from left to right (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
      public LinearAlgebra.delegates.Matrix_ConcatenateRowWise<long> Matrix_ConcatenateRowWise { get { return LinearAlgebra.ConcatenateRowWise; } }
      /// <summary>Computes the determinent if this matrix is square.</summary>
      public LinearAlgebra.delegates.Matrix_Determinent<long> Matrix_Determinent { get { return LinearAlgebra.Determinent; } }
      /// <summary>Computes the echelon form of this matrix (aka REF).</summary>
      public LinearAlgebra.delegates.Matrix_Echelon<long> Matrix_Echelon { get { return LinearAlgebra.Echelon; } }
      /// <summary>Computes the reduced echelon form of this matrix (aka RREF).</summary>
      public LinearAlgebra.delegates.Matrix_ReducedEchelon<long> Matrix_ReducedEchelon { get { return LinearAlgebra.ReducedEchelon; } }
      /// <summary>Computes the inverse of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Inverse<long> Matrix_Inverse { get { return LinearAlgebra.Inverse; } }
      /// <summary>Gets the adjoint of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Adjoint<long> Matrix_Adjoint { get { return LinearAlgebra.Adjoint; } }
      /// <summary>Transposes this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Transpose<long> Matrix_Transpose { get { return LinearAlgebra.Transpose; } }
      /// <summary>Decomposes a matrix to lower/upper components.</summary>
      public LinearAlgebra.delegates.Matrix_DecomposeLU<long> Matrix_DecomposeLU { get { return LinearAlgebra.DecomposeLU; } }
      /// <summary>Dtermines equality but value.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue<long> Matrix_EqualsByValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Determines equality by value with leniency.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue_leniency<long> Matrix_EqualsByValue_leniency { get { return LinearAlgebra.EqualsValue; } }

      #endregion

      #region quaterion

      /// <summary>Computes the length of quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Magnitude<long> Quaternion_Magnitude { get { return LinearAlgebra.Magnitude; } }
      /// <summary>Computes the length of a quaternion, but doesn't square root it.</summary>
      public LinearAlgebra.delegates.Quaternion_MagnitudeSquared<long> Quaternion_MagnitudeSquared { get { return LinearAlgebra.MagnitudeSquared; } }
      /// <summary>Gets the conjugate of the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Conjugate<long> Quaternion_Conjugate { get { return LinearAlgebra.Conjugate; } }
      /// <summary>Adds two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Add<long> Quaternion_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Subtracts two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Subtract<long> Quaternion_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Multiplies two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply<long> Quaternion_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_scalar<long> Quaternion_Multiply_scalar { get { return LinearAlgebra.Multiply; } }
      /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_Vector<long> Quaternion_Multiply_Vector { get { return LinearAlgebra.Multiply; } }
      /// <summary>Normalizes the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Normalize<long> Quaternion_Normalize { get { return LinearAlgebra.Normalize; } }
      /// <summary>Inverts a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Invert<long> Quaternion_Invert { get { return LinearAlgebra.Invert; } }
      /// <summary>Lenearly interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Lerp<long> Quaternion_Lerp { get { return LinearAlgebra.Lerp; } }
      /// <summary>Sphereically interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Slerp<long> Quaternion_Slerp { get { return LinearAlgebra.Slerp; } }
      /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
      public LinearAlgebra.delegates.Quaternion_Rotate<long> Quaternion_Rotate { get { return LinearAlgebra.Rotate; } }
      /// <summary>Does a value equality check.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue<long> Quaternion_EqualsValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Does a value equality check with leniency.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<long> Quaternion_EqualsValue_leniency { get { return LinearAlgebra.EqualsValue; } }

      #endregion
    }

    private class LinearAlgebra_int : LinearAlgebra<int>
    {
      #region construct-simpleton

      private LinearAlgebra_int() { _instance = this; }
      private static LinearAlgebra_int _instance;
      private static LinearAlgebra_int Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new LinearAlgebra_int();
          else
            return _instance;
        }
      }

      /// <summary>Gets Arithmetic for "byte" types.</summary>
      public static LinearAlgebra_int Get { get { return Instance; } }

      #endregion

      #region vector

      /// <summary>Adds two vectors together.</summary>
      public LinearAlgebra.delegates.Vector_Add<int> Vector_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Negates all the values in a vector.</summary>
      public LinearAlgebra.delegates.Vector_Negate<int> Vector_Negate { get { return LinearAlgebra.Negate; } }
      /// <summary>Subtracts two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Subtract<int> Vector_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Multiply<int> Vector_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Divides all the components of a vector by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Divide<int> Vector_Divide { get { return LinearAlgebra.Divide; } }
      /// <summary>Computes the dot product between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_DotProduct<int> Vector_DotProduct { get { return LinearAlgebra.DotProduct; } }
      /// <summary>Computes teh cross product of two vectors.</summary>
      public LinearAlgebra.delegates.Vector_CrossProduct<int> Vector_CrossProduct { get { return LinearAlgebra.CrossProduct; } }
      /// <summary>Normalizes a vector.</summary>
      public LinearAlgebra.delegates.Vector_Normalize<int> Vector_Normalize { get { return LinearAlgebra.Normalize; } }
      /// <summary>Computes the length of a vector.</summary>
      public LinearAlgebra.delegates.Vector_Magnitude<int> Vector_Magnitude { get { return LinearAlgebra.Magnitude; } }
      /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
      public LinearAlgebra.delegates.Vector_MagnitudeSquared<int> Vector_MagnitudeSquared { get { return LinearAlgebra.MagnitudeSquared; } }
      /// <summary>Computes the angle between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Angle<int> Vector_Angle { get { return LinearAlgebra.Angle; } }
      /// <summary>Rotates a vector by the specified axis and rotation values.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy<int> Vector_RotateBy { get { return LinearAlgebra.RotateBy; } }
      /// <summary>Computes the linear interpolation between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Lerp<int> Vector_Lerp { get { return LinearAlgebra.Lerp; } }
      /// <summary>Sphereically interpolates between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Slerp<int> Vector_Slerp { get { return LinearAlgebra.Slerp; } }
      /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
      public LinearAlgebra.delegates.Vector_Blerp<int> Vector_Blerp { get { return LinearAlgebra.Blerp; } }
      /// <summary>Checks for equality by value.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue<int> Vector_EqualsValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Checks for equality by value with leniency.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue_leniency<int> Vector_EqualsValue_leniency { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Rotates a vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy_quaternion<int> Vector_RotateBy_quaternion { get { return LinearAlgebra.RotateBy; } }

      #endregion

      #region matrix

      /// <summary>Negates all the values in this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Negate<int> Matrix_Negate { get { return LinearAlgebra.Negate; } }
      /// <summary>Does a standard matrix addition.</summary>
      public LinearAlgebra.delegates.Matrix_Add<int> Matrix_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Does a standard matrix subtraction.</summary>
      public LinearAlgebra.delegates.Matrix_Subtract<int> Matrix_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Does a standard matrix multiplication (triple for loop).</summary>
      public LinearAlgebra.delegates.Matrix_Multiply<int> Matrix_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Multiplies all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_scalar<int> Matrix_Multiply_scalar { get { return LinearAlgebra.Multiply; } }
      /// <summary>Premultiplies a vector by a matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_vector<int> Matrix_Multiply_vector { get { return LinearAlgebra.Multiply; } }
      /// <summary>Divides all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Divide<int> Matrix_Divide { get { return LinearAlgebra.Divide; } }
      /// <summary>Takes the matrix to the given int power.</summary>
      public LinearAlgebra.delegates.Matrix_Power<int> Matrix_Power { get { return LinearAlgebra.Power; } }
      /// <summary>Gets the minor of a matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Minor<int> Matrix_Minor { get { return LinearAlgebra.Minor; } }
      /// <summary>Combines two matrices from left to right (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
      public LinearAlgebra.delegates.Matrix_ConcatenateRowWise<int> Matrix_ConcatenateRowWise { get { return LinearAlgebra.ConcatenateRowWise; } }
      /// <summary>Computes the determinent if this matrix is square.</summary>
      public LinearAlgebra.delegates.Matrix_Determinent<int> Matrix_Determinent { get { return LinearAlgebra.Determinent; } }
      /// <summary>Computes the echelon form of this matrix (aka REF).</summary>
      public LinearAlgebra.delegates.Matrix_Echelon<int> Matrix_Echelon { get { return LinearAlgebra.Echelon; } }
      /// <summary>Computes the reduced echelon form of this matrix (aka RREF).</summary>
      public LinearAlgebra.delegates.Matrix_ReducedEchelon<int> Matrix_ReducedEchelon { get { return LinearAlgebra.ReducedEchelon; } }
      /// <summary>Computes the inverse of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Inverse<int> Matrix_Inverse { get { return LinearAlgebra.Inverse; } }
      /// <summary>Gets the adjoint of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Adjoint<int> Matrix_Adjoint { get { return LinearAlgebra.Adjoint; } }
      /// <summary>Transposes this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Transpose<int> Matrix_Transpose { get { return LinearAlgebra.Transpose; } }
      /// <summary>Decomposes a matrix to lower/upper components.</summary>
      public LinearAlgebra.delegates.Matrix_DecomposeLU<int> Matrix_DecomposeLU { get { return LinearAlgebra.DecomposeLU; } }
      /// <summary>Dtermines equality but value.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue<int> Matrix_EqualsByValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Determines equality by value with leniency.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue_leniency<int> Matrix_EqualsByValue_leniency { get { return LinearAlgebra.EqualsValue; } }

      #endregion

      #region quaterion

      /// <summary>Computes the length of quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Magnitude<int> Quaternion_Magnitude { get { return LinearAlgebra.Magnitude; } }
      /// <summary>Computes the length of a quaternion, but doesn't square root it.</summary>
      public LinearAlgebra.delegates.Quaternion_MagnitudeSquared<int> Quaternion_MagnitudeSquared { get { return LinearAlgebra.MagnitudeSquared; } }
      /// <summary>Gets the conjugate of the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Conjugate<int> Quaternion_Conjugate { get { return LinearAlgebra.Conjugate; } }
      /// <summary>Adds two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Add<int> Quaternion_Add { get { return LinearAlgebra.Add; } }
      /// <summary>Subtracts two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Subtract<int> Quaternion_Subtract { get { return LinearAlgebra.Subtract; } }
      /// <summary>Multiplies two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply<int> Quaternion_Multiply { get { return LinearAlgebra.Multiply; } }
      /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_scalar<int> Quaternion_Multiply_scalar { get { return LinearAlgebra.Multiply; } }
      /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_Vector<int> Quaternion_Multiply_Vector { get { return LinearAlgebra.Multiply; } }
      /// <summary>Normalizes the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Normalize<int> Quaternion_Normalize { get { return LinearAlgebra.Normalize; } }
      /// <summary>Inverts a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Invert<int> Quaternion_Invert { get { return LinearAlgebra.Invert; } }
      /// <summary>Lenearly interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Lerp<int> Quaternion_Lerp { get { return LinearAlgebra.Lerp; } }
      /// <summary>Sphereically interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Slerp<int> Quaternion_Slerp { get { return LinearAlgebra.Slerp; } }
      /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
      public LinearAlgebra.delegates.Quaternion_Rotate<int> Quaternion_Rotate { get { return LinearAlgebra.Rotate; } }
      /// <summary>Does a value equality check.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue<int> Quaternion_EqualsValue { get { return LinearAlgebra.EqualsValue; } }
      /// <summary>Does a value equality check with leniency.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<int> Quaternion_EqualsValue_leniency { get { return LinearAlgebra.EqualsValue; } }

      #endregion
    }

    /// <summary>Creates a linear algebra for an arbitray type.</summary>
    /// <typeparam name="T">The type to create a linear algebra library for.</typeparam>
    public class LinearAlgebra_generic<T> : LinearAlgebra<T>
    {
      #region field

      // Constants
      private T _zero;
      private T _one;
      private T _two;

      // Logic
      private Logic.delegates.abs<T> _abs;
      private Equate<T> _equate;
      private Compare<T> _compare;

      // Arithmetic
      private Arithmetic.delegates.Negate<T> _negate;
      private Arithmetic.delegates.Add<T> _add;
      private Arithmetic.delegates.Subtract<T> _subtract;
      private Arithmetic.delegates.Multiply<T> _multiply;
      private Arithmetic.delegates.Divide<T> _divide;

      // Algebra
      private Algebra.delegates.sqrt<T> _sqrt;
      private Algebra.delegates.invert<T> _Invert_Multiplicative;

      // Trigonometry
      private Trigonometry.delegates.sin<T> _sin;
      private Trigonometry.delegates.cos<T> _cos;
      private Trigonometry.delegates.acos<T> _acos;

      #endregion

      #region construct

      private LinearAlgebra_generic(
        Constants<T> constants,
        Logic<T> logic,
        Arithmetic<T> arithmetic,
        Algebra<T> algebra,
        Trigonometry<T> trigonometry)
      {
        this._zero = constants.factory(0);
        this._one = constants.factory(1);
        this._two = constants.factory(2);
        this._abs = logic.abs;
        this._equate = logic.equ;
        this._compare = logic.comp;
        this._negate = arithmetic.Negate;
        this._add = arithmetic.Add;
        this._subtract = arithmetic.Subtract;
        this._multiply = arithmetic.Multiply;
        this._divide = arithmetic.Divide;
        this._sqrt = algebra.sqrt;
        this._Invert_Multiplicative = algebra.invert_mult;
        this._sin = trigonometry.sin;
        this._cos = trigonometry.cos;
        this._acos = trigonometry.acos;
      }

      private LinearAlgebra_generic(
        T zero,
        T one,
        T two,
        Logic.delegates.abs<T> abs,
        Equate<T> equate,
        Compare<T> compare,
        Arithmetic.delegates.Negate<T> negate,
        Arithmetic.delegates.Add<T> add,
        Arithmetic.delegates.Subtract<T> subtract,
        Arithmetic.delegates.Multiply<T> multiply,
        Arithmetic.delegates.Divide<T> divide,
        Algebra.delegates.sqrt<T> sqrt,
        Algebra.delegates.invert<T> invert,
        Trigonometry.delegates.sin<T> sin,
        Trigonometry.delegates.cos<T> cos,
        Trigonometry.delegates.acos<T> arccos)
      {
        this._zero = zero;
        this._one = one;
        this._two = two;
        this._abs = abs;
        this._equate = equate;
        this._compare = compare;
        this._negate = negate;
        this._add = add;
        this._subtract = subtract;
        this._multiply = multiply;
        this._divide = divide;
        this._sqrt = sqrt;
        this._Invert_Multiplicative = invert;
        this._sin = sin;
        this._cos = cos;
        this._acos = arccos;
      }

      #endregion

      #region vector

      /// <summary>Adds two vectors together.</summary>
      public LinearAlgebra.delegates.Vector_Add<T> Vector_Add
      {
        get
        {
          return
            (Vector<T> left, Vector<T> right) =>
            {
              if (left.Dimensions != right.Dimensions)
                throw new Error("invalid dimensions on vector addition.");
              Vector<T> result = new T[left.Dimensions];
              for (int i = 0; i < left.Dimensions; i++)
                result[i] = _add(left[i], right[i]);
              return result;
            };
        }
      }

      /// <summary>Negates all the values in a vector.</summary>
      public LinearAlgebra.delegates.Vector_Negate<T> Vector_Negate
      {
        get
        {
          return
            (Vector<T> vector) =>
            {
              Vector<T> result = new T[vector.Dimensions];
              for (int i = 0; i < vector.Dimensions; i++)
                result[i] = _negate(vector[i]);
              return result;
            };
        }
      }

      /// <summary>Subtracts two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Subtract<T> Vector_Subtract
      {
        get
        {
          return
            (Vector<T> left, Vector<T> right) =>
            {
              Vector<T> result = new T[left.Dimensions];
              if (left.Dimensions != right.Dimensions)
                throw new Error("invalid dimensions on vector subtraction.");
              for (int i = 0; i < left.Dimensions; i++)
                result[i] = _subtract(left[i], right[i]);
              return result;
            };
        }
      }

      /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Multiply<T> Vector_Multiply
      {
        get
        {
          return
            (Vector<T> left, T right) =>
            {
              Vector<T> result = new T[left.Dimensions];
              for (int i = 0; i < left.Dimensions; i++)
                result[i] = _multiply(left[i], right);
              return result;
            };
        }
      }

      /// <summary>Divides all the components of a vector by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Divide<T> Vector_Divide
      {
        get
        {
          return
            (Vector<T> left, T right) =>
            {
              Vector<T> result = new T[left.Dimensions];
              for (int i = 0; i < left.Dimensions; i++)
                result[i] = _divide(left[i], right);
              return result;
            };
        }
      }

      /// <summary>Computes the dot product between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_DotProduct<T> Vector_DotProduct
      {
        get
        {
          return
            (Vector<T> left, Vector<T> right) =>
            {
              if (left.Dimensions != right.Dimensions)
                throw new Error("invalid dimensions on vector dot product.");
              T result = _zero;
              for (int i = 0; i < left.Dimensions; i++)
                result = _add(result, _multiply(left[i], right[i]));
              return result;
            };
        }
      }

      /// <summary>Computes teh cross product of two vectors.</summary>
      public LinearAlgebra.delegates.Vector_CrossProduct<T> Vector_CrossProduct
      {
        get
        {
          return
            (Vector<T> left, Vector<T> right) =>
            {
              if (left.Dimensions != right.Dimensions)
                throw new Error("invalid cross product !(left.Dimensions == right.Dimensions)");
              if (left.Dimensions == 3 || left.Dimensions == 4)
              {
                return new T[] {
                _subtract(_multiply(left[1], right[2]), _multiply(left[2], right[1])),
                _subtract(_multiply(left[2], right[0]), _multiply(left[0], right[2])),
                _subtract(_multiply(left[0], right[1]), _multiply(left[1], right[0])) };
              }
              throw new Error("my cross product function is only defined for 3-component vectors.");
            };
        }
      }

      /// <summary>Normalizes a vector.</summary>
      public LinearAlgebra.delegates.Vector_Normalize<T> Vector_Normalize
      {
        get
        {
          return
            (Vector<T> vector) =>
            {
              T length = Vector<T>.Magnitude(vector);
              if (!_equate(length, _zero))
              {
                Vector<T> result = new T[vector.Dimensions];
                for (int i = 0; i < vector.Dimensions; i++)
                  result[i] = _divide(vector[i], length);
                return result;
              }
              else
                return new T[vector.Dimensions];
            };
        }
      }

      /// <summary>Computes the length of a vector.</summary>
      public LinearAlgebra.delegates.Vector_Magnitude<T> Vector_Magnitude
      {
        get
        {
          return
            (Vector<T> vector) =>
            {
              T result = _zero;
              for (int i = 0; i < vector.Dimensions; i++)
                result = _add(result, _multiply(vector[i], vector[i]));
              return _sqrt(result);
            };
        }
      }

      /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
      public LinearAlgebra.delegates.Vector_MagnitudeSquared<T> Vector_MagnitudeSquared
      {
        get
        {
          return
            (Vector<T> vector) =>
            {
              T result = _zero;
              for (int i = 0; i < vector.Dimensions; i++)
                result = _add(result, _multiply(vector[i], vector[i]));
              return result;
            };
        }
      }

      /// <summary>Computes the angle between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Angle<T> Vector_Angle
      {
        get
        {
          return
            (Vector<T> first, Vector<T> second) =>
            {
              return _acos(_divide(Vector<T>.DotProduct(first, second), (_multiply(Vector<T>.Magnitude(first), Vector<T>.Magnitude(second)))));
            };
        }
      }

      /// <summary>Rotates a vector by the specified axis and rotation values.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy<T> Vector_RotateBy
      {
        get
        {
          return
            (Vector<T> vector, T angle, T x, T y, T z) =>
            {
              if (vector.Dimensions == 3)
              {
                // Note: the angle is in radians
                T sinHalfAngle = _sin(_divide(angle, _two));
                T cosHalfAngle = _cos(_divide(angle, _two));
                x = _multiply(x, sinHalfAngle);
                y = _multiply(y, sinHalfAngle);
                z = _multiply(z, sinHalfAngle);
                T x2 = _subtract(_add(_multiply(cosHalfAngle, vector[0]), _multiply(y, vector[2])), _multiply(z, vector[1]));
                T y2 = _subtract(_add(_multiply(cosHalfAngle, vector[1]), _multiply(z, vector[0])), _multiply(x, vector[2]));
                T z2 = _subtract(_add(_multiply(cosHalfAngle, vector[2]), _multiply(x, vector[1])), _multiply(y, vector[0]));
                T w2 = _add(_add(_multiply(_negate(x), vector[0]), _multiply(_negate(y), vector[1])), _multiply(_negate(z), vector[2]));
                return new T[] {
          _subtract(_add(_add(_multiply(x, w2), _multiply(cosHalfAngle, x2)), _multiply(y, z2)), _multiply(z, y2)),
          _subtract(_add(_add(_multiply(y, w2), _multiply(cosHalfAngle, y2)), _multiply(z, x2)), _multiply(x, z2)),
          _subtract(_add(_add(_multiply(z, w2), _multiply(cosHalfAngle, z2)), _multiply(x, y2)), _multiply(y, x2)) };
              }
              throw new Error("my RotateBy() function is only defined for 3-component vectors.");
            };
        }
      }

      /// <summary>Rotates a vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy_quaternion<T> Vector_RotateBy_quaternion
      {
        get
        {
          return
            (Vector<T> vector, Quaternion<T> quaternion) =>
            {
              return this.Quaternion_Rotate(quaternion, vector);
            };
        }
      }


      /// <summary>Computes the linear Terpolation between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Lerp<T> Vector_Lerp
      {
        get
        {
          return
            (Vector<T> left, Vector<T> right, T blend) =>
            {
              throw new System.NotImplementedException();
              //float[] leftFloats = left.Floats;
              //float[] rightFloats = right.Floats;
              //if (blend < 0 || blend > 1.0f)
              //	throw new Error("invalid lerp blend value: (blend < 0.0f || blend > 1.0f).");
              //if (leftFloats.Dimensions != rightFloats.Dimensions)
              //	throw new Error("invalid lerp matrix length: (left.Dimensions != right.Dimensions)");
              //Vector<T> result = new Vector<T>(leftFloats.Dimensions);
              //float[] resultFloats = result.Floats;
              //for (int i = 0; i < leftFloats.Dimensions; i++)
              //	resultFloats[i] = leftFloats[i] + blend * (rightFloats[i] - leftFloats[i]);
              //return result;
            };
        }
      }

      /// <summary>Sphereically Terpolates between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Slerp<T> Vector_Slerp
      {
        get
        {
          return
            (Vector<T> left, Vector<T> right, T blend) =>
            {
              throw new System.NotImplementedException();
              //if (blend < 0 || blend > 1.0f)
              //	throw new Error("invalid slerp blend value: (blend < 0.0f || blend > 1.0f).");
              //float dot = Calc.Clamp(Vector<T>.DotProduct(left, right), -1.0f, 1.0f);
              //float theta = Calc.ArcCos(dot) * blend;
              //return left * Calc.Cos(theta) + (right - left * dot).Normalize() * Calc.Sin(theta);
            };
        }
      }

      /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
      public LinearAlgebra.delegates.Vector_Blerp<T> Vector_Blerp
      {
        get
        {
          return
            (Vector<T> a, Vector<T> b, Vector<T> c, T u, T v) =>
            {
              throw new System.NotImplementedException();
              //return Vector<T>.Add(Vector<T>.Add(Vector<T>.Multiply(Vector<T>.Subtract(b, a), u), Vector<T>.Multiply(Vector<T>.Subtract(c, a), v)), a);
            };
        }
      }

      /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue<T> Vector_EqualsValue
      {
        get
        {
          return
            (Vector<T> left, Vector<T> right) =>
            {
              if (left.Dimensions != right.Dimensions)
                return false;
              for (int i = 0; i < left.Dimensions; i++)
                if (!_equate(left[i], right[i]))
                  return false;
              return true;
            };
        }
      }

      /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue_leniency<T> Vector_EqualsValue_leniency
      {
        get
        {
          return
            (Vector<T> left, Vector<T> right, T leniency) =>
            {
              if (left.Dimensions != right.Dimensions)
                return false;
              for (int i = 0; i < left.Dimensions; i++)
                if (_compare(_abs(_subtract(left[i], right[i])), leniency) == Comparison.Greater)
                  return false;
              return true;
            };
        }
      }

      #endregion

      #region matix

      /// <summary>Negates all the values in this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Negate<T> Matrix_Negate
      {
        get
        {
          return
            (Matrix<T> matrix) =>
            {
              Matrix<T> result = new Matrix<T>(matrix.Rows, matrix.Columns);
              for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Columns; j++)
                  result[i, j] = _negate(matrix[i, j]);
              return result;
            };
        }
      }

      /// <summary>Does a standard matrix addition.</summary>
      public LinearAlgebra.delegates.Matrix_Add<T> Matrix_Add
      {
        get
        {
          return
            (Matrix<T> left, Matrix<T> right) =>
            {
              if (left.Rows != right.Rows || left.Columns != right.Columns)
                throw new Error("invalid addition (size miss-match).");
              Matrix<T> result = new Matrix<T>(left.Rows, left.Columns);
              for (int i = 0; i < left.Rows; i++)
                for (int j = 0; j < left.Columns; j++)
                  result[i, j] = _add(left[i, j], right[i, j]);
              return result;
            };
        }
      }

      /// <summary>Does a standard matrix addition.</summary>
      public LinearAlgebra.delegates.Matrix_Subtract<T> Matrix_Subtract
      {
        get
        {
          return
            (Matrix<T> left, Matrix<T> right) =>
            {
              if (left.Rows != right.Rows || left.Columns != right.Columns)
                throw new Error("invalid subtraction (size miss-match).");
              Matrix<T> result = new Matrix<T>(left.Rows, left.Columns);
              for (int i = 0; i < result.Rows; i++)
                for (int j = 0; j < result.Columns; j++)
                  result[i, j] = _subtract(left[i, j], right[i, j]);
              return result;
            };
        }
      }

      /// <summary>Does a standard matrix multiplication (triple for loop).</summary>
      public LinearAlgebra.delegates.Matrix_Multiply<T> Matrix_Multiply
      {
        get
        {
          return
            (Matrix<T> left, Matrix<T> right) =>
            {
              if (left.Columns != right.Rows)
                throw new Error("invalid multiplication (size miss-match).");
              Matrix<T> result = new Matrix<T>(left.Rows, right.Columns);
              for (int i = 0; i < left.Rows; i++)
                for (int j = 0; j < right.Columns; j++)
                  for (int k = 0; k < left.Columns; k++)
                    result[i, j] = _add(result[i, j], _multiply(left[i, k], right[k, j]));
              return result;
            };
        }
      }

      /// <summary>Multiplies all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_scalar<T> Matrix_Multiply_scalar
      {
        get
        {
          return
            (Matrix<T> left, T right) =>
            {
              Matrix<T> result = new Matrix<T>(left.Rows, left.Columns);
              for (int i = 0; i < left.Rows; i++)
                for (int j = 0; j < left.Columns; j++)
                  result[i, j] = _multiply(left[i, j], right);
              return result;
            };
        }
      }

      /// <summary>Multiplies all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_vector<T> Matrix_Multiply_vector
      {
        get
        {
          return
            (Matrix<T> left, Vector<T> right) =>
            {
              if (left.Columns != right.Dimensions)
                throw new Error("invalid multiplication (size miss-match).");
              T[] result = new T[left.Columns];
              for (int i = 0; i < left.Rows; i++)
                for (int j = 0; j < left.Columns; j++)
                  result[i] = _add(result[i], _multiply(left[i, j], right[j]));
              return result;
            };
        }
      }

      /// <summary>Divides all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Divide<T> Matrix_Divide
      {
        get
        {
          return
            (Matrix<T> matrix, T right) =>
            {
              Matrix<T> result = new Matrix<T>(matrix.Rows, matrix.Columns);
              for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Columns; j++)
                  result[i, j] = _divide(matrix[i, j], right);
              return result;
            };
        }
      }

      /// <summary>Takes a matrix to the given int power.</summary>
      public LinearAlgebra.delegates.Matrix_Power<T> Matrix_Power
      {
        get
        {
          return
            (Matrix<T> matrix, int power) =>
            {
              if (!(matrix.Rows == matrix.Columns))
                throw new Error("invalid power (!matrix.IsSquare).");
              if (!(power > -1))
                throw new Error("invalid power !(power > -1)");
              if (power == 0)
                return Matrix<T>.FactoryIdentity(matrix.Rows, matrix.Columns);
              Matrix<T> result = matrix.Clone() as Matrix<T>;
              for (int i = 0; i < power; i++)
                result = Matrix<T>.Multiply(result, result);
              return result;
            };
        }
      }

      /// <summary>Gets the minor of a matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Minor<T> Matrix_Minor
      {
        get
        {
          return
            (Matrix<T> matrix, int row, int column) =>
            {
              Matrix<T> minor = new Matrix<T>(matrix.Rows - 1, matrix.Columns - 1);
              int m = 0, n = 0;
              for (int i = 0; i < matrix.Rows; i++)
              {
                if (i == row) continue;
                n = 0;
                for (int j = 0; j < matrix.Columns; j++)
                {
                  if (j == column) continue;
                  minor[m, n] = matrix[i, j];
                  n++;
                }
                m++;
              }
              return minor;
            };
        }
      }

      /// <summary>Combines two matrices from left to right (result..Rows = left..Rows && result..Columns = left..Columns + right..Columns).</summary>
      public LinearAlgebra.delegates.Matrix_ConcatenateRowWise<T> Matrix_ConcatenateRowWise
      {
        get
        {
          return
            (Matrix<T> left, Matrix<T> right) =>
            {
              if (left.Rows != right.Rows)
                throw new Error("invalid row-wise concatenation !(left..Rows == right..Rows).");
              Matrix<T> result = new Matrix<T>(left.Rows, left.Columns + right.Columns);
              for (int i = 0; i < left.Rows; i++)
                for (int j = 0; j < result.Columns; j++)
                {
                  if (j < left.Columns) result[i, j] = left[i, j];
                  else result[i, j] = right[i, j - left.Columns];
                }
              return result;
            };
        }
      }

      /// <summary>Computes the determinent if this matrix is square.</summary>
      public LinearAlgebra.delegates.Matrix_Determinent<T> Matrix_Determinent
      {
        get
        {
          return
            (Matrix<T> matrix) =>
            {
              if (!(matrix.Rows == matrix.Columns))
                throw new Error("invalid determinent !(matrix.IsSquare).");
              T det = _one;
              try
              {
                Matrix<T> rref = matrix.Clone() as Matrix<T>;
                for (int i = 0; i < matrix.Rows; i++)
                {
                  if (_equate(rref[i, i], _zero))
                    for (int j = i + 1; j < rref.Rows; j++)
                      if (!_equate(rref[j, i], _zero))
                      {
                        this.SwapRows(rref, i, j);
                        det = _negate(det);
                      }
                  det = _multiply(det, rref[i, i]);
                  this.RowMultiplication(rref, i, _Invert_Multiplicative(rref[i, i]));
                  for (int j = i + 1; j < rref.Rows; j++)
                    this.RowAddition(rref, j, i, _negate(rref[j, i]));
                  for (int j = i - 1; j >= 0; j--)
                    this.RowAddition(rref, j, i, _negate(rref[j, i]));
                }
                return det;
              }
              catch { throw new Error("determinent computation failed."); }
            };
        }
      }

      /// <summary>Computes the echelon form of this matrix (aka REF).</summary>
      public LinearAlgebra.delegates.Matrix_Echelon<T> Matrix_Echelon
      {
        get
        {
          return
            (Matrix<T> matrix) =>
            {
              try
              {
                Matrix<T> result = matrix.Clone() as Matrix<T>;
                for (int i = 0; i < matrix.Rows; i++)
                {
                  if (_equate(result[i, i], _zero))
                    for (int j = i + 1; j < result.Rows; j++)
                      if (!_equate(result[j, i], _zero))
                        this.SwapRows(result, i, j);
                  if (_equate(result[i, i], _zero))
                    continue;
                  if (!_equate(result[i, i], _one))
                    for (int j = i + 1; j < result.Rows; j++)
                      if (_equate(result[j, i], _one))
                        this.SwapRows(result, i, j);
                  this.RowMultiplication(result, i, _Invert_Multiplicative(result[i, i]));
                  for (int j = i + 1; j < result.Rows; j++)
                    this.RowAddition(result, j, i, _negate(result[j, i]));
                }
                return result;
              }
              catch { throw new Error("echelon computation failed."); }
            };
        }
      }

      /// <summary>Computes the reduced echelon form of this matrix (aka RREF).</summary>
      public LinearAlgebra.delegates.Matrix_ReducedEchelon<T> Matrix_ReducedEchelon
      {
        get
        {
          return
            (Matrix<T> matrix) =>
            {
              try
              {
                Matrix<T> result = matrix.Clone() as Matrix<T>;
                for (int i = 0; i < matrix.Rows; i++)
                {
                  if (_equate(result[i, i], _one))
                    for (int j = i + 1; j < result.Rows; j++)
                      if (!_equate(result[j, i], _zero))
                        this.SwapRows(result, i, j);
                  if (_equate(result[i, i], _zero)) continue;
                  if (!_equate(result[i, i], _one))
                    for (int j = i + 1; j < result.Rows; j++)
                      if (_equate(result[j, i], _one))
                        this.SwapRows(result, i, j);
                  this.RowMultiplication(result, i, _Invert_Multiplicative(result[i, i]));
                  for (int j = i + 1; j < result.Rows; j++)
                    this.RowAddition(result, j, i, _negate(result[j, i]));
                  for (int j = i - 1; j >= 0; j--)
                    this.RowAddition(result, j, i, _negate(result[j, i]));
                }
                return result;
              }
              catch { throw new Error("reduced echelon calculation failed."); }
            };
        }
      }

      /// <summary>Computes the inverse of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Inverse<T> Matrix_Inverse
      {
        get
        {
          return
            (Matrix<T> matrix) =>
            {
              if (_equate(Matrix<T>.Determinent(matrix), _zero))
                throw new Error("inverse calculation failed.");
              try
              {
                Matrix<T> identity = Matrix<T>.FactoryIdentity(matrix.Rows, matrix.Columns);
                Matrix<T> rref = matrix.Clone() as Matrix<T>;
                for (int i = 0; i < matrix.Rows; i++)
                {
                  if (_equate(rref[i, i], _zero))
                    for (int j = i + 1; j < rref.Rows; j++)
                      if (!_equate(rref[j, i], _zero))
                      {
                        this.SwapRows(rref, i, j);
                        this.SwapRows(identity, i, j);
                      }
                  this.RowMultiplication(identity, i, _Invert_Multiplicative(rref[i, i]));
                  this.RowMultiplication(rref, i, _Invert_Multiplicative(rref[i, i]));
                  for (int j = i + 1; j < rref.Rows; j++)
                  {
                    this.RowAddition(identity, j, i, _negate(rref[j, i]));
                    this.RowAddition(rref, j, i, _negate(rref[j, i]));
                  }
                  for (int j = i - 1; j >= 0; j--)
                  {
                    this.RowAddition(identity, j, i, _negate(rref[j, i]));
                    this.RowAddition(rref, j, i, _negate(rref[j, i]));
                  }
                }
                return identity;
              }
              catch { throw new Error("inverse calculation failed."); }
            };
        }
      }

      /// <summary>Gets the adjoT of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Adjoint<T> Matrix_Adjoint
      {
        get
        {
          return
            (Matrix<T> matrix) =>
            {
              if (!(matrix.Rows == matrix.Columns))
                throw new Error("Adjoint of a non-square matrix does not exists");
              Matrix<T> AdjointMatrix = new Matrix<T>(matrix.Rows, matrix.Columns);
              for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Columns; j++)
                  if ((i + j) % 2 == 0)
                    AdjointMatrix[i, j] = Matrix<T>.Determinent(Matrix<T>.Minor(matrix, i, j));
                  else
                    AdjointMatrix[i, j] = _negate(Matrix<T>.Determinent(Matrix<T>.Minor(matrix, i, j)));
              return Matrix<T>.Transpose(AdjointMatrix);
            };
        }
      }

      /// <summary>Transposes this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Transpose<T> Matrix_Transpose
      {
        get
        {
          return
            (Matrix<T> matrix) =>
            {
              Matrix<T> transpose = new Matrix<T>(matrix.Columns, matrix.Rows);
              for (int i = 0; i < transpose.Rows; i++)
                for (int j = 0; j < transpose.Columns; j++)
                  transpose[i, j] = matrix[j, i];
              return transpose;
            };
        }
      }

      /// <summary>Decomposes a matrix to lower/upper components.</summary>
      public LinearAlgebra.delegates.Matrix_DecomposeLU<T> Matrix_DecomposeLU
      {
        get
        {
          return
            (Matrix<T> matrix, out Matrix<T> lower, out Matrix<T> upper) =>
            {
              if (!(matrix.Rows == matrix.Columns))
                throw new Error("The matrix is not square!");
              lower = Matrix<T>.FactoryIdentity(matrix.Rows, matrix.Columns);
              upper = matrix.Clone() as Matrix<T>;
              int[] permutation = new int[matrix.Rows];
              for (int i = 0; i < matrix.Rows; i++) permutation[i] = i;
              T p = _zero, pom2, detOfP = _one;
              int k0 = 0, pom1 = 0;
              for (int k = 0; k < matrix.Columns - 1; k++)
              {
                p = _zero;
                for (int i = k; i < matrix.Rows; i++)
                  if (_compare(_abs(upper[i, k]), p) == Comparison.Greater)
                  {
                    p = _abs(upper[i, k]);
                    k0 = i;
                  }
                if (_equate(p, _zero))
                  throw new Error("The matrix is singular!");
                pom1 = permutation[k];
                permutation[k] = permutation[k0];
                permutation[k0] = pom1;
                for (int i = 0; i < k; i++)
                {
                  pom2 = lower[k, i];
                  lower[k, i] = lower[k0, i];
                  lower[k0, i] = pom2;
                }
                if (k != k0)
                  detOfP = _negate(detOfP);
                for (int i = 0; i < matrix.Columns; i++)
                {
                  pom2 = upper[k, i];
                  upper[k, i] = upper[k0, i];
                  upper[k0, i] = pom2;
                }
                for (int i = k + 1; i < matrix.Rows; i++)
                {
                  lower[i, k] = _divide(upper[i, k], upper[k, k]);
                  for (int j = k; j < matrix.Columns; j++)
                    upper[i, j] = _subtract(upper[i, j], _multiply(lower[i, k], upper[k, j]));
                }
              }
            };
        }
      }

      /// <summary>Transposes this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue<T> Matrix_EqualsByValue
      {
        get
        {
          return
            (Matrix<T> left, Matrix<T> right) =>
            {
              if (left.Rows != right.Rows || left.Columns != right.Columns)
                return false;
              for (int i = 0; i < left.Rows; i++)
                for (int j = 0; j < left.Columns; j++)
                  if (!_equate(left[i, j], right[i, j]))
                    return false;
              return true;
            };
        }
      }

      /// <summary>Transposes this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue_leniency<T> Matrix_EqualsByValue_leniency
      {
        get
        {
          return
            (Matrix<T> left, Matrix<T> right, T leniency) =>
            {
              if (left.Rows != right.Rows || left.Columns != right.Columns)
                return false;
              for (int i = 0; i < left.Rows; i++)
                for (int j = 0; j < left.Columns; j++)
                  if (_compare(_abs(_subtract(left[i, j], right[i, j])), leniency) == Comparison.Greater)
                    return false;
              return true;
            };
        }
      }

      /// <summary>Does a value equality check.</summary>
      /// <param name="left">The first vector to check for equality.</param>
      /// <param name="right">The second vector  to check for equality.</param>
      /// <returns>True if values are equal, false if not.</returns>
      public bool EqualsValue(T[] left, T[] right)
      {
        if (left.Length != right.Length)
          return false;
        for (int i = 0; i < left.Length; i++)
          if (!_equate(left[i], right[i]))
            return false;
        return true;
      }

      /// <summary>Does a value equality check with leniency.</summary>
      /// <param name="left">The first vector to check for equality.</param>
      /// <param name="right">The second vector to check for equality.</param>
      /// <param name="leniency">How much the values can vary but still be considered equal.</param>
      /// <returns>True if values are equal, false if not.</returns>
      public bool EqualsValue(T[] left, T[] right, T leniency)
      {
        if (left.Length != right.Length)
          return false;
        for (int i = 0; i < left.Length; i++)
          if (_compare(_abs(_subtract(left[i], right[i])), leniency) == Comparison.Greater)
            return false;
        return true;
      }

      private void RowMultiplication(Matrix<T> matrix, int row, T scalar)
      {
        for (int j = 0; j < matrix.Columns; j++)
          matrix[row, j] = _multiply(matrix[row, j], scalar);
      }

      private void RowAddition(Matrix<T> matrix, int target, int second, T scalar)
      {
        for (int j = 0; j < matrix.Columns; j++)
          matrix[target, j] = _add(matrix[target, j], _multiply(matrix[second, j], scalar));
      }

      private void SwapRows(Matrix<T> matrix, int row1, int row2)
      {
        for (int j = 0; j < matrix.Columns; j++)
        {
          T temp = matrix[row1, j];
          matrix[row1, j] = matrix[row2, j];
          matrix[row2, j] = temp;
        }
      }

      #endregion

      #region quaternion

      /// <summary>Computes the length of quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Magnitude<T> Quaternion_Magnitude
      {
        get
        {
          return
            (Quaternion<T> quaternion) =>
            {
              return
                _sqrt(_add(_add(_add(
                  _multiply(quaternion.X, quaternion.X),
                  _multiply(quaternion.Y, quaternion.Y)),
                  _multiply(quaternion.Z, quaternion.Z)),
                  _multiply(quaternion.W, quaternion.W)));
            };
        }
      }

      /// <summary>Computes the length of a quaternion, but doesn't square root it.</summary>
      public LinearAlgebra.delegates.Quaternion_MagnitudeSquared<T> Quaternion_MagnitudeSquared
      {
        get
        {
          return
            (Quaternion<T> quaternion) =>
            {
              return
                _add(_add(_add(
                  _multiply(quaternion.X, quaternion.X),
                  _multiply(quaternion.Y, quaternion.Y)),
                  _multiply(quaternion.Z, quaternion.Z)),
                  _multiply(quaternion.W, quaternion.W));
            };
        }
      }

      /// <summary>Gets the conjugate of the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Conjugate<T> Quaternion_Conjugate
      {
        get
        {
          return
            (Quaternion<T> quaternion) =>
            {
              return new Quaternion<T>(
                _negate(quaternion.X),
                _negate(quaternion.Y),
                _negate(quaternion.Z),
                quaternion.W);
            };
        }
      }

      /// <summary>Adds two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Add<T> Quaternion_Add
      {
        get
        {
          return
            (Quaternion<T> left, Quaternion<T> right) =>
            {
              return new Quaternion<T>(
                _add(left.X, right.X),
                _add(left.Y, right.Y),
                _add(left.Z, right.Z),
                _add(left.W, right.W));
            };
        }
      }

      /// <summary>Subtracts two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Subtract<T> Quaternion_Subtract
      {
        get
        {
          return
            (Quaternion<T> left, Quaternion<T> right) =>
            {
              return new Quaternion<T>(
                _subtract(left.X, right.X),
                _subtract(left.Y, right.Y),
                _subtract(left.Z, right.Z),
                _subtract(left.W, right.W));
            };
        }
      }

      /// <summary>Multiplies two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply<T> Quaternion_Multiply
      {
        get
        {
          return
            (Quaternion<T> left, Quaternion<T> right) =>
            {
              return new Quaternion<T>(
                _subtract(_add(_add(_multiply(left.X, right.W), _multiply(left.W, right.X)), _multiply(left.Y, right.Z)), _multiply(left.Z, right.Y)),
                _subtract(_add(_add(_multiply(left.Y, right.W), _multiply(left.W, right.Y)), _multiply(left.Z, right.X)), _multiply(left.X, right.Z)),
                _subtract(_add(_add(_multiply(left.Z, right.W), _multiply(left.W, right.Z)), _multiply(left.X, right.Y)), _multiply(left.Y, right.X)),
                _subtract(_subtract(_subtract(_multiply(left.W, right.W), _multiply(left.X, right.X)), _multiply(left.Y, right.Y)), _multiply(left.Z, right.Z)));
            };
        }
      }

      /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_scalar<T> Quaternion_Multiply_scalar
      {
        get
        {
          return
            (Quaternion<T> left, T right) =>
            {
              return new Quaternion<T>(
                _multiply(left.X, right),
                _multiply(left.Y, right),
                _multiply(left.Z, right),
                _multiply(left.W, right));
            };
        }
      }

      /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_Vector<T> Quaternion_Multiply_Vector
      {
        get
        {
          return
            (Quaternion<T> left, Vector<T> right) =>
            {
              if (right.Dimensions == 3)
              {
                return new Quaternion<T>(
                  _subtract(_add(_multiply(left.W, right.X), _multiply(left.Y, right.Z)), _multiply(left.Z, right.Y)),
                  _subtract(_add(_multiply(left.W, right.Y), _multiply(left.Z, right.X)), _multiply(left.X, right.Z)),
                  _subtract(_add(_multiply(left.W, right.Z), _multiply(left.X, right.Y)), _multiply(left.Y, right.X)),
                  _subtract(_subtract(_multiply(_negate(left.X), right.X), _multiply(left.Y, right.Y)), _multiply(left.Z, right.Z)));
              }
              else
                throw new Error("my quaternion rotations are only defined for 3-component vectors.");
            };
        }
      }

      /// <summary>Normalizes the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Normalize<T> Quaternion_Normalize
      {
        get
        {
          return
            (Quaternion<T> quaternion) =>
            {
              T normalizer = Quaternion<T>.Magnitude(quaternion);
              if (!_equate(normalizer, _zero))
                return quaternion * _Invert_Multiplicative(normalizer);
              else
                return Quaternion<T>.FactoryIdentity;
            };
        }
      }

      /// <summary>Inverts a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Invert<T> Quaternion_Invert
      {
        get
        {
          return
            (Quaternion<T> quaternion) =>
            {
              // EQUATION: invert = quaternion.Conjugate()).Normalized()
              T normalizer = Quaternion<T>.MagnitudeSquared(quaternion);
              if (_equate(normalizer, _zero))
                return new Quaternion<T>(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
              normalizer = _Invert_Multiplicative(normalizer);
              return new Quaternion<T>(
                _multiply(_negate(quaternion.X), normalizer),
                _multiply(_negate(quaternion.Y), normalizer),
                _multiply(_negate(quaternion.Z), normalizer),
                _multiply(quaternion.W, normalizer));
            };
        }
      }

      /// <summary>Lenearly interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Lerp<T> Quaternion_Lerp
      {
        get
        {
          return
            (Quaternion<T> left, Quaternion<T> right, T blend) =>
            {
              if (_compare(blend, _zero) == Comparison.Less || _compare(blend, _one) == Comparison.Greater)
                throw new Error("invalid blending value during lerp !(blend < 0.0f || blend > 1.0f).");
              if (_equate(Quaternion<T>.MagnitudeSquared(left), _zero))
              {
                if (_equate(Quaternion<T>.MagnitudeSquared(right), _zero))
                  return Quaternion<T>.FactoryIdentity;
                else
                  return new Quaternion<T>(right.X, right.Y, right.Z, right.W);
              }
              else if (_equate(Quaternion<T>.MagnitudeSquared(right), _zero))
                return new Quaternion<T>(left.X, left.Y, left.Z, left.W);
              Quaternion<T> result = new Quaternion<T>(
                _add(_multiply(_subtract(_one, blend), left.X), _multiply(blend, right.X)),
                _add(_multiply(_subtract(_one, blend), left.Y), _multiply(blend, right.Y)),
                _add(_multiply(_subtract(_one, blend), left.Z), _multiply(blend, right.Z)),
                _add(_multiply(_subtract(_one, blend), left.W), _multiply(blend, right.W)));
              if (_compare(Quaternion<T>.MagnitudeSquared(result), _zero) == Comparison.Greater)
                return Quaternion<T>.Normalize(result);
              else
                return Quaternion<T>.FactoryIdentity;
            };
        }
      }

      /// <summary>Sphereically interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Slerp<T> Quaternion_Slerp
      {
        get
        {
          return
            (Quaternion<T> left, Quaternion<T> right, T blend) =>
            {
              throw new System.NotImplementedException();
              //if (_compare(blend, _zero) == Comparison.Less || _compare(blend, _one) == Comparison.Greater)
              //	throw new Error("invalid blending value during lerp !(blend < 0.0f || blend > 1.0f).");
              //if (_equate(Quaternion<T>.MagnitudeSquared(left), _zero))
              //{
              //	if (_equate(Quaternion<T>.MagnitudeSquared(right), _zero))
              //		return FactoryIdentity;
              //	else
              //		return new Quaternion<T>(right.X, right.Y, right.Z, right.W);
              //}
              //else if (_equate(Quaternion<T>.MagnitudeSquared(right), _zero))
              //	return new Quaternion<T>(left.X, left.Y, left.Z, left.W);
              //float cosHalfAngle = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
              //if (cosHalfAngle >= 1.0f || cosHalfAngle <= -1.0f)
              //	return new Quaternion<T>(left.X, left.Y, left.Z, left.W);
              //else if (cosHalfAngle < 0.0f)
              //{
              //	right = new Quaternion<T>(-left.X, -left.Y, -left.Z, -left.W);
              //	cosHalfAngle = -cosHalfAngle;
              //}
              //float halfAngle = (float)Math.Acos(cosHalfAngle);
              //float sinHalfAngle = Calc.Sin(halfAngle);
              //float blendA = Calc.Sin(halfAngle * (_subtract(_one, blend)) / sinHalfAngle;
              //float blendB = Calc.Sin(halfAngle * blend) / sinHalfAngle;
              //Quaternion<T> result = new Quaternion<T>(
              //	blendA * left.X + blendB * right.X,
              //	blendA * left.Y + blendB * right.Y,
              //	blendA * left.Z + blendB * right.Z,
              //	blendA * left.W + blendB * right.W);
              //if (_compare(Quaternion<T>.MagnitudeSquared(result), _zero) == Comparison.Greater)
              //	return Quaternion<T>.Normalize(result);
              //else
              //	return Quaternion<T>.FactoryIdentity;
            };
        }
      }

      /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
      public LinearAlgebra.delegates.Quaternion_Rotate<T> Quaternion_Rotate
      {
        get
        {
          return
            (Quaternion<T> rotation, Vector<T> vector) =>
            {
              if (vector.Dimensions != 3)
                throw new Error("my quaternion rotations are only defined for 3-component vectors.");
              Quaternion<T> answer = this.Quaternion_Multiply(this.Quaternion_Multiply_Vector(rotation, vector), Quaternion<T>.Conjugate(rotation));
              return new Vector<T>(answer.X, answer.Y, answer.Z);
            };
        }
      }

      /// <summary>Does a value equality check.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue<T> Quaternion_EqualsValue
      {
        get
        {
          return
            (Quaternion<T> left, Quaternion<T> right) =>
            {
              return
                _equate(left.X, right.X) &&
                _equate(left.Y, right.Y) &&
                _equate(left.Z, right.Z) &&
                _equate(left.W, right.W);
            };
        }
      }

      /// <summary>Does a value equality check with leniency.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<T> Quaternion_EqualsValue_leniency
      {
        get
        {
          return
            (Quaternion<T> left, Quaternion<T> right, T leniency) =>
            {
              return
                _compare(_abs(_subtract(left.X, right.X)), leniency) == Comparison.Less &&
                _compare(_abs(_subtract(left.Y, right.Y)), leniency) == Comparison.Less &&
                _compare(_abs(_subtract(left.Z, right.Z)), leniency) == Comparison.Less &&
                _compare(_abs(_subtract(left.W, right.W)), leniency) == Comparison.Less;
            };
        }
      }

      #endregion
    }

    private class LinearAlgebra_unsupported<T> : LinearAlgebra<T>
    {
      #region construct

      public LinearAlgebra_unsupported() { }

      #endregion

      #region vector

      /// <summary>Adds two vectors together.</summary>
      public LinearAlgebra.delegates.Vector_Add<T> Vector_Add
      { get { return (Vector<T> left, Vector<T> right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Negates all the values in a vector.</summary>
      public LinearAlgebra.delegates.Vector_Negate<T> Vector_Negate
      { get { return (Vector<T> left) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Subtracts two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Subtract<T> Vector_Subtract
      { get { return (Vector<T> left, Vector<T> right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Multiply<T> Vector_Multiply
      { get { return (Vector<T> left, T right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Divides all the components of a vector by a scalar.</summary>
      public LinearAlgebra.delegates.Vector_Divide<T> Vector_Divide
      { get { return (Vector<T> left, T right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Computes the dot product between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_DotProduct<T> Vector_DotProduct
      { get { return (Vector<T> left, Vector<T> right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Computes teh cross product of two vectors.</summary>
      public LinearAlgebra.delegates.Vector_CrossProduct<T> Vector_CrossProduct
      { get { return (Vector<T> left, Vector<T> right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Normalizes a vector.</summary>
      public LinearAlgebra.delegates.Vector_Normalize<T> Vector_Normalize
      { get { return (Vector<T> left) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Computes the length of a vector.</summary>
      public LinearAlgebra.delegates.Vector_Magnitude<T> Vector_Magnitude
      { get { return (Vector<T> left) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
      public LinearAlgebra.delegates.Vector_MagnitudeSquared<T> Vector_MagnitudeSquared
      { get { return (Vector<T> left) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Computes the angle between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Angle<T> Vector_Angle
      { get { return (Vector<T> left, Vector<T> right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Rotates a vector by the specified axis and rotation values.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy<T> Vector_RotateBy
      { get { return (Vector<T> left, T angle, T x, T y, T z) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Computes the linear Terpolation between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Lerp<T> Vector_Lerp
      { get { return (Vector<T> left, Vector<T> right, T blend) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Sphereically Terpolates between two vectors.</summary>
      public LinearAlgebra.delegates.Vector_Slerp<T> Vector_Slerp
      { get { return (Vector<T> left, Vector<T> right, T blend) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
      public LinearAlgebra.delegates.Vector_Blerp<T> Vector_Blerp
      { get { return (Vector<T> a, Vector<T> b, Vector<T> c, T u, T v) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Checks for equality by value.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue<T> Vector_EqualsValue
      { get { return (Vector<T> left, Vector<T> right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Checks for equality by value with leniency.</summary>
      public LinearAlgebra.delegates.Vector_EqualsValue_leniency<T> Vector_EqualsValue_leniency
      { get { return (Vector<T> left, Vector<T> right, T leniency) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Rotates a vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Vector_RotateBy_quaternion<T> Vector_RotateBy_quaternion
      { get { return (Vector<T> left, Quaternion<T> right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }

      #endregion

      #region matrix

      /// <summary>Negates all the values in this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Negate<T> Matrix_Negate
      { get { return (Matrix<T> left) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Does a standard matrix addition.</summary>
      public LinearAlgebra.delegates.Matrix_Add<T> Matrix_Add
      { get { return (Matrix<T> left, Matrix<T> right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Does a standard matrix subtraction.</summary>
      public LinearAlgebra.delegates.Matrix_Subtract<T> Matrix_Subtract
      { get { return (Matrix<T> left, Matrix<T> right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Does a standard matrix multiplication (triple for loop).</summary>
      public LinearAlgebra.delegates.Matrix_Multiply<T> Matrix_Multiply
      { get { return (Matrix<T> left, Matrix<T> right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Multiplies all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_scalar<T> Matrix_Multiply_scalar
      { get { return (Matrix<T> left, T right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Multiplies all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Multiply_vector<T> Matrix_Multiply_vector
      { get { return (Matrix<T> left, Vector<T> right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Divides all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Divide<T> Matrix_Divide
      { get { return (Matrix<T> left, T right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Divides all the values in this matrix by a scalar.</summary>
      public LinearAlgebra.delegates.Matrix_Power<T> Matrix_Power
      { get { return (Matrix<T> left, int right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Gets the minor of a matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Minor<T> Matrix_Minor
      { get { return (Matrix<T> left, int row, int column) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Combines two matrices from left to right (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
      public LinearAlgebra.delegates.Matrix_ConcatenateRowWise<T> Matrix_ConcatenateRowWise
      { get { return (Matrix<T> left, Matrix<T> right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Computes the determinent if this matrix is square.</summary>
      public LinearAlgebra.delegates.Matrix_Determinent<T> Matrix_Determinent
      { get { return (Matrix<T> left) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Computes the echelon form of this matrix (aka REF).</summary>
      public LinearAlgebra.delegates.Matrix_Echelon<T> Matrix_Echelon
      { get { return (Matrix<T> left) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Computes the reduced echelon form of this matrix (aka RREF).</summary>
      public LinearAlgebra.delegates.Matrix_ReducedEchelon<T> Matrix_ReducedEchelon
      { get { return (Matrix<T> left) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Computes the inverse of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Inverse<T> Matrix_Inverse
      { get { return (Matrix<T> left) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Gets the adjoT of this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Adjoint<T> Matrix_Adjoint
      { get { return (Matrix<T> left) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Transposes this matrix.</summary>
      public LinearAlgebra.delegates.Matrix_Transpose<T> Matrix_Transpose
      { get { return (Matrix<T> left) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Decomposes a matrix to lower/upper components.</summary>
      public LinearAlgebra.delegates.Matrix_DecomposeLU<T> Matrix_DecomposeLU
      { get { return (Matrix<T> m, out Matrix<T> l, out Matrix<T> u) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Dtermines equality but value.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue<T> Matrix_EqualsByValue
      { get { return (Matrix<T> left, Matrix<T> right) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Determines equality by value with leniency.</summary>
      public LinearAlgebra.delegates.Matrix_EqualsByValue_leniency<T> Matrix_EqualsByValue_leniency
      { get { return (Matrix<T> left, Matrix<T> right, T leniency) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }

      #endregion

      #region quaterion

      /// <summary>Computes the length of quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Magnitude<T> Quaternion_Magnitude
      { get { return (Quaternion<T> a) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Computes the length of a quaternion, but doesn't square root it.</summary>
      public LinearAlgebra.delegates.Quaternion_MagnitudeSquared<T> Quaternion_MagnitudeSquared
      { get { return (Quaternion<T> a) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Gets the conjugate of the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Conjugate<T> Quaternion_Conjugate
      { get { return (Quaternion<T> a) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Adds two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Add<T> Quaternion_Add
      { get { return (Quaternion<T> a, Quaternion<T> b) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Subtracts two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Subtract<T> Quaternion_Subtract
      { get { return (Quaternion<T> a, Quaternion<T> b) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Multiplies two quaternions together.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply<T> Quaternion_Multiply
      { get { return (Quaternion<T> a, Quaternion<T> b) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_scalar<T> Quaternion_Multiply_scalar
      { get { return (Quaternion<T> a, T b) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Multiply_Vector<T> Quaternion_Multiply_Vector
      { get { return (Quaternion<T> a, Vector<T> b) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Normalizes the quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Normalize<T> Quaternion_Normalize
      { get { return (Quaternion<T> a) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Inverts a quaternion.</summary>
      public LinearAlgebra.delegates.Quaternion_Invert<T> Quaternion_Invert
      { get { return (Quaternion<T> a) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Lenearly interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Lerp<T> Quaternion_Lerp
      { get { return (Quaternion<T> a, Quaternion<T> b, T blend) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Sphereically interpolates between two quaternions.</summary>
      public LinearAlgebra.delegates.Quaternion_Slerp<T> Quaternion_Slerp
      { get { return (Quaternion<T> a, Quaternion<T> b, T blend) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
      public LinearAlgebra.delegates.Quaternion_Rotate<T> Quaternion_Rotate
      { get { return (Quaternion<T> a, Vector<T> b) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Does a value equality check.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue<T> Quaternion_EqualsValue
      { get { return (Quaternion<T> a, Quaternion<T> b) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }
      /// <summary>Does a value equality check with leniency.</summary>
      public LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<T> Quaternion_EqualsValue_leniency
      { get { return (Quaternion<T> a, Quaternion<T> b, T leniency) => { throw new Error("a linear algebra for " + typeof(T) + " could not be found or created"); }; } }

      #endregion
    }

    #endregion

    #endregion

    #region implementations

    #region generic

    #region vector

    /// <summary>Adds two vectors together.</summary>
    /// <param name="left">The first vector of the addition.</param>
    /// <param name="right">The second vector of the addiiton.</param>
    /// <returns>The result of the addiion.</returns>
    public static Vector<T> Add<T>(Vector<T> left, Vector<T> right)
    { return Get<T>().Vector_Add(left, right); }
    /// <summary>Negates all the values in a vector.</summary>
    /// <param name="vector">The vector to have its values negated.</param>
    /// <returns>The result of the negations.</returns>
    public static Vector<T> Negate<T>(Vector<T> vector)
    { return Get<T>().Vector_Negate(vector); }
    /// <summary>Subtracts two vectors.</summary>
    /// <param name="left">The left vector of the subtraction.</param>
    /// <param name="right">The right vector of the subtraction.</param>
    /// <returns>The result of the vector subtracton.</returns>
    public static Vector<T> Subtract<T>(Vector<T> left, Vector<T> right)
    { return Get<T>().Vector_Subtract(left, right); }
    /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
    /// <param name="left">The vector to have the components multiplied by.</param>
    /// <param name="right">The scalars to multiply the vector components by.</param>
    /// <returns>The result of the multiplications.</returns>
    public static Vector<T> Multiply<T>(Vector<T> left, T right)
    { return Get<T>().Vector_Multiply(left, right); }
    /// <summary>Divides all the components of a vector by a scalar.</summary>
    /// <param name="vector">The vector to have the components divided by.</param>
    /// <param name="right">The scalar to divide the vector components by.</param>
    /// <returns>The resulting vector after teh divisions.</returns>
    public static Vector<T> Divide<T>(Vector<T> vector, T right)
    { return Get<T>().Vector_Divide(vector, right); }
    /// <summary>Computes the dot product between two vectors.</summary>
    /// <param name="left">The first vector of the dot product operation.</param>
    /// <param name="right">The second vector of the dot product operation.</param>
    /// <returns>The result of the dot product operation.</returns>
    public static T DotProduct<T>(Vector<T> left, Vector<T> right)
    { return Get<T>().Vector_DotProduct(left, right); }
    /// <summary>Computes teh cross product of two vectors.</summary>
    /// <param name="left">The first vector of the cross product operation.</param>
    /// <param name="right">The second vector of the cross product operation.</param>
    /// <returns>The result of the cross product operation.</returns>
    public static Vector<T> CrossProduct<T>(Vector<T> left, Vector<T> right)
    { return Get<T>().Vector_CrossProduct(left, right); }
    /// <summary>Normalizes a vector.</summary>
    /// <param name="vector">The vector to normalize.</param>
    /// <returns>The result of the normalization.</returns>
    public static Vector<T> Normalize<T>(Vector<T> vector)
    { return Get<T>().Vector_Normalize(vector); }
    /// <summary>Computes the length of a vector.</summary>
    /// <param name="vector">The vector to calculate the length of.</param>
    /// <returns>The computed length of the vector.</returns>
    public static T Magnitude<T>(Vector<T> vector)
    { return Get<T>().Vector_Magnitude(vector); }
    /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
    /// <param name="vector">The vector to compute the length squared of.</param>
    /// <returns>The computed length squared of the vector.</returns>
    public static T MagnitudeSquared<T>(Vector<T> vector)
    { return Get<T>().Vector_MagnitudeSquared(vector); }
    /// <summary>Computes the angle between two vectors.</summary>
    /// <param name="first">The first vector to determine the angle between.</param>
    /// <param name="second">The second vector to determine the angle between.</param>
    /// <returns>The angle between the two vectors in radians.</returns>
    public static T Angle<T>(Vector<T> first, Vector<T> second)
    { return Get<T>().Vector_Angle(first, second); }
    /// <summary>Rotates a vector by the specified axis and rotation values.</summary>
    /// <param name="vector">The vector to rotate.</param>
    /// <param name="angle">The angle of the rotation.</param>
    /// <param name="x">The x component of the axis vector to rotate about.</param>
    /// <param name="y">The y component of the axis vector to rotate about.</param>
    /// <param name="z">The z component of the axis vector to rotate about.</param>
    /// <returns>The result of the rotation.</returns>
    public static Vector<T> RotateBy<T>(Vector<T> vector, T angle, T x, T y, T z)
    { return Get<T>().Vector_RotateBy(vector, angle, x, y, z); } 
    /// <summary>Rotates a vector by a quaternion rotation.</summary>
    /// <param name="vector">The vector to be rotated.</param>
    /// <param name="quaternion">The rotation to be applied.</param>
    /// <returns>The vector after the rotation.</returns>
    public static Vector<T> RotateBy<T>(Vector<T> vector, Quaternion<T> quaternion)
    { return Get<T>().Vector_RotateBy_quaternion(vector, quaternion); }
    /// <summary>Computes the linear interpolation between two vectors.</summary>
    /// <param name="left">The starting vector of the interpolation.</param>
    /// <param name="right">The ending vector of the interpolation.</param>
    /// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Vector<T> Lerp<T>(Vector<T> left, Vector<T> right, T blend)
    { return Get<T>().Vector_Lerp(left, right, blend); } 
    /// <summary>Sphereically interpolates between two vectors.</summary>
    /// <param name="left">The starting vector of the interpolation.</param>
    /// <param name="right">The ending vector of the interpolation.</param>
    /// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
    /// <returns>The result of the slerp operation.</returns>
    public static Vector<T> Slerp<T>(Vector<T> left, Vector<T> right, T blend)
    { return Get<T>().Vector_Slerp(left, right, blend); }
    /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
    /// <param name="a">The first vector of the interpolation.</param>
    /// <param name="b">The second vector of the interpolation.</param>
    /// <param name="c">The thrid vector of the interpolation.</param>
    /// <param name="u">The "U" value of the barycentric interpolation equation.</param>
    /// <param name="v">The "V" value of the barycentric interpolation equation.</param>
    /// <returns>The resulting vector of the barycentric interpolation.</returns>
    public static Vector<T> Blerp<T>(Vector<T> a, Vector<T> b, Vector<T> c, T u, T v)
    { return Get<T>().Vector_Blerp(a, b, c, u, v); } 
    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue<T>(Vector<T> left, Vector<T> right)
    { return Get<T>().Vector_EqualsValue(left, right); } 
    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue<T>(Vector<T> left, Vector<T> right, T leniency)
    { return Get<T>().Vector_EqualsValue_leniency(left, right, leniency); }

    #endregion

    #region matrix

    ///// <summary>Constructs a new identity-matrix of the given dimensions.</summary>
    ///// <param name="rows">The number of rows of the matrix.</param>
    ///// <param name="columns">The number of columns of the matrix.</param>
    ///// <returns>The newly constructed identity-matrix.</returns>
    //public static Matrix<T> MatrixFactoryIdentity_T<T>(int rows, int columns)
    //{
    //  return Get<T>().Matrix_Add(left, right);
    //}

    ///// <summary>Determines if a matrix is symetric or not.</summary>
    ///// <param name="matrix">The matrix to determine symetry of.</param>
    ///// <returns>True if symetric; false if not.</returns>
    //public static bool IsSymmetric<T>(Matrix<T> matrix)
    //{
    //  return Get<T>().Matrix_IsSymetric(matrix);
    //}

    /// <summary>Negates all the values in a matrix.</summary>
    /// <param name="matrix">The matrix to have its values negated.</param>
    /// <returns>The resulting matrix after the negations.</returns>
    public static Matrix<T> Negate<T>(Matrix<T> matrix)
    { return Get<T>().Matrix_Negate(matrix); }
    /// <summary>Does standard addition of two matrices.</summary>
    /// <param name="left">The left matrix of the addition.</param>
    /// <param name="right">The right matrix of the addition.</param>
    /// <returns>The resulting matrix after the addition.</returns>
    public static Matrix<T> Add<T>(Matrix<T> left, Matrix<T> right)
    { return Get<T>().Matrix_Add(left, right); }
    /// <summary>Subtracts a scalar from all the values in a matrix.</summary>
    /// <param name="left">The matrix to have the values subtracted from.</param>
    /// <param name="right">The scalar to subtract from all the matrix values.</param>
    /// <returns>The resulting matrix after the subtractions.</returns>
    public static Matrix<T> Subtract<T>(Matrix<T> left, Matrix<T> right)
    { return Get<T>().Matrix_Add(left, right); }
    /// <summary>Performs multiplication on two matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Matrix<T> Multiply<T>(Matrix<T> left, Matrix<T> right)
    { return Get<T>().Matrix_Multiply(left, right); }
    /// <summary>Does a standard <T>(triple for looped) multiplication between matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Vector<T> Multiply<T>(Matrix<T> left, Vector<T> right)
    { return Get<T>().Matrix_Multiply_vector(left, right); }
    /// <summary>Multiplies all the values in a matrix by a scalar.</summary>
    /// <param name="left">The matrix to have the values multiplied.</param>
    /// <param name="right">The scalar to multiply the values by.</param>
    /// <returns>The resulting matrix after the multiplications.</returns>
    public static Matrix<T> Multiply<T>(Matrix<T> left, T right)
    { return Get<T>().Matrix_Multiply_scalar(left, right); }
    /// <summary>Applies a power to a square matrix.</summary>
    /// <param name="matrix">The matrix to be powered by.</param>
    /// <param name="power">The power to apply to the matrix.</param>
    /// <returns>The resulting matrix of the power operation.</returns>
    public static Matrix<T> Power<T>(Matrix<T> matrix, int power)
    { return Get<T>().Matrix_Power(matrix, power); }
    /// <summary>Divides all the values in the matrix by a scalar.</summary>
    /// <param name="matrix">The matrix to divide the values of.</param>
    /// <param name="right">The scalar to divide all the matrix values by.</param>
    /// <returns>The resulting matrix with the divided values.</returns>
    public static Matrix<T> Divide<T>(Matrix<T> matrix, T right)
    { return Get<T>().Matrix_Divide(matrix, right); }
    /// <summary>Gets the minor of a matrix.</summary>
    /// <param name="matrix">The matrix to get the minor of.</param>
    /// <param name="row">The restricted row to form the minor.</param>
    /// <param name="column">The restricted column to form the minor.</param>
    /// <returns>The minor of the matrix.</returns>
    public static Matrix<T> Minor<T>(Matrix<T> matrix, int row, int column)
    { return Get<T>().Matrix_Minor(matrix, row, column); }
    /// <summary>Combines two matrices from left to right 
    /// <T>(result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
    /// <param name="left">The left matrix of the concatenation.</param>
    /// <param name="right">The right matrix of the concatenation.</param>
    /// <returns>The resulting matrix of the concatenation.</returns>
    public static Matrix<T> ConcatenateRowWise<T>(Matrix<T> left, Matrix<T> right)
    { return Get<T>().Matrix_ConcatenateRowWise(left, right); }
    /// <summary>Calculates the echelon of a matrix <T>(aka REF).</summary>
    /// <param name="matrix">The matrix to calculate the echelon of <T>(aka REF).</param>
    /// <returns>The echelon of the matrix <T>(aka REF).</returns>
    public static Matrix<T> Echelon<T>(Matrix<T> matrix)
    { return Get<T>().Matrix_Echelon(matrix); }
    /// <summary>Calculates the echelon of a matrix and reduces it <T>(aka RREF).</summary>
    /// <param name="matrix">The matrix matrix to calculate the reduced echelon of <T>(aka RREF).</param>
    /// <returns>The reduced echelon of the matrix <T>(aka RREF).</returns>
    public static Matrix<T> ReducedEchelon<T>(Matrix<T> matrix)
    { return Get<T>().Matrix_ReducedEchelon(matrix); } 
    /// <summary>Calculates the determinent of a square matrix.</summary>
    /// <param name="matrix">The matrix to calculate the determinent of.</param>
    /// <returns>The determinent of the matrix.</returns>
    public static T Determinent<T>(Matrix<T> matrix)
    { return Get<T>().Matrix_Determinent(matrix); }
    /// <summary>Calculates the inverse of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the inverse of.</param>
    /// <returns>The inverse of the matrix.</returns>
    public static Matrix<T> Inverse<T>(Matrix<T> matrix)
    { return Get<T>().Matrix_Inverse(matrix); }
    /// <summary>Calculates the adjoint of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the adjoint of.</param>
    /// <returns>The adjoint of the matrix.</returns>
    public static Matrix<T> Adjoint<T>(Matrix<T> matrix)
    { return Get<T>().Matrix_Adjoint(matrix); }
    /// <summary>Returns the transpose of a matrix.</summary>
    /// <param name="matrix">The matrix to transpose.</param>
    /// <returns>The transpose of the matrix.</returns>
    public static Matrix<T> Transpose<T>(Matrix<T> matrix)
    { return Get<T>().Matrix_Transpose(matrix); }
    /// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
    /// <param name="matrix">The matrix to decompose.</param>
    /// <param name="Lower">The computed lower triangular matrix.</param>
    /// <param name="Upper">The computed upper triangular matrix.</param>
    public static void DecomposeLU<T>(Matrix<T> matrix, out Matrix<T> Lower, out Matrix<T> Upper)
    { Get<T>().Matrix_DecomposeLU(matrix, out Lower, out Upper); }
    ///// <summary>Creates a copy of a matrix.</summary>
    ///// <param name="matrix">The matrix to copy.</param>
    ///// <returns>A copy of the matrix.</returns>
    //public static Matrix<T> Clone<T>(Matrix<T> matrix)
    //{ return Get<T>().Matrix_Clone(matrix); }
    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue<T>(Matrix<T> left, Matrix<T> right)
    { return Get<T>().Matrix_EqualsByValue(left, right); } 
    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue<T>(Matrix<T> left, Matrix<T> right, T leniency)
    { return Get<T>().Matrix_EqualsByValue_leniency(left, right, leniency); }

    #endregion

    #region quaterion

    /// <summary>Computes the length of quaternion.</summary>
    /// <param name="quaternion">The quaternion to compute the length of.</param>
    /// <returns>The length of the given quaternion.</returns>
    public static T Magnitude<T>(Quaternion<T> quaternion)
    { return Get<T>().Quaternion_Magnitude(quaternion); } 
    /// <summary>Computes the length of a quaternion, but doesn't square root it
    /// for optimization possibilities.</summary>
    /// <param name="quaternion">The quaternion to compute the length squared of.</param>
    /// <returns>The squared length of the given quaternion.</returns>
    public static T MagnitudeSquared<T>(Quaternion<T> quaternion)
    { return Get<T>().Quaternion_MagnitudeSquared(quaternion); }
    /// <summary>Gets the conjugate of the quaternion.</summary>
    /// <param name="quaternion">The quaternion to conjugate.</param>
    /// <returns>The conjugate of teh given quaternion.</returns>
    public static Quaternion<T> Conjugate<T>(Quaternion<T> quaternion)
    { return Get<T>().Quaternion_Conjugate(quaternion); }
    /// <summary>Adds two quaternions together.</summary>
    /// <param name="left">The first quaternion of the addition.</param>
    /// <param name="right">The second quaternion of the addition.</param>
    /// <returns>The result of the addition.</returns>
    public static Quaternion<T> Add<T>(Quaternion<T> left, Quaternion<T> right)
    { return Get<T>().Quaternion_Add(left, right); } 
    /// <summary>Subtracts two quaternions.</summary>
    /// <param name="left">The left quaternion of the subtraction.</param>
    /// <param name="right">The right quaternion of the subtraction.</param>
    /// <returns>The resulting quaternion after the subtraction.</returns>
    public static Quaternion<T> Subtract<T>(Quaternion<T> left, Quaternion<T> right)
    { return Get<T>().Quaternion_Subtract(left, right); }
    /// <summary>Multiplies two quaternions together.</summary>
    /// <param name="left">The first quaternion of the multiplication.</param>
    /// <param name="right">The second quaternion of the multiplication.</param>
    /// <returns>The resulting quaternion after the multiplication.</returns>
    public static Quaternion<T> Multiply<T>(Quaternion<T> left, Quaternion<T> right)
    { return Get<T>().Quaternion_Multiply(left, right); }
    /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
    /// <param name="left">The quaternion of the multiplication.</param>
    /// <param name="right">The scalar of the multiplication.</param>
    /// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
    public static Quaternion<T> Multiply<T>(Quaternion<T> left, T right)
    { return Get<T>().Quaternion_Multiply_scalar(left, right); }
    /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
    /// <param name="left">The quaternion to pre-multiply the vector by.</param>
    /// <param name="right">The vector to be multiplied.</param>
    /// <returns>The resulting quaternion of the multiplication.</returns>
    public static Quaternion<T> Multiply<T>(Quaternion<T> left, Vector<T> right)
    { return Get<T>().Quaternion_Multiply_Vector(left, right); }
    /// <summary>Normalizes the quaternion.</summary>
    /// <param name="quaternion">The quaternion to normalize.</param>
    /// <returns>The normalization of the given quaternion.</returns>
    public static Quaternion<T> Normalize<T>(Quaternion<T> quaternion)
    { return Get<T>().Quaternion_Normalize(quaternion); }
    /// <summary>Inverts a quaternion.</summary>
    /// <param name="quaternion">The quaternion to find the inverse of.</param>
    /// <returns>The inverse of the given quaternion.</returns>
    public static Quaternion<T> Invert<T>(Quaternion<T> quaternion)
    { return Get<T>().Quaternion_Invert(quaternion); }
    /// <summary>Lenearly interpolates between two quaternions.</summary>
    /// <param name="left">The starting point of the interpolation.</param>
    /// <param name="right">The ending point of the interpolation.</param>
    /// <param name="blend">The ratio 0.0-1.0 of how far to interpolate between the left and right quaternions.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Quaternion<T> Lerp<T>(Quaternion<T> left, Quaternion<T> right, T blend)
    { return Get<T>().Quaternion_Lerp(left, right, blend); }
    /// <summary>Sphereically interpolates between two quaternions.</summary>
    /// <param name="left">The starting point of the interpolation.</param>
    /// <param name="right">The ending point of the interpolation.</param>
    /// <param name="blend">The ratio of how far to interpolate between the left and right quaternions.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Quaternion<T> Slerp<T>(Quaternion<T> left, Quaternion<T> right, T blend)
    { return Get<T>().Quaternion_Slerp(left, right, blend); }
    /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
    /// <param name="rotation">The quaternion to rotate the vector by.</param>
    /// <param name="vector">The vector to be rotated by.</param>
    /// <returns>The result of the rotation.</returns>
    public static Vector<T> Rotate<T>(Quaternion<T> rotation, Vector<T> vector)
    { return Get<T>().Quaternion_Rotate(rotation, vector); }
    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first quaternion to check for equality.</param>
    /// <param name="right">The second quaternion  to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue<T>(Quaternion<T> left, Quaternion<T> right)
    { return Get<T>().Quaternion_EqualsValue(left, right); }
    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first quaternion to check for equality.</param>
    /// <param name="right">The second quaternion to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue<T>(Quaternion<T> left, Quaternion<T> right, T leniency)
    { return Get<T>().Quaternion_EqualsValue_leniency(left, right, leniency); }

    #endregion

    #endregion

    #region Fraction128

    #region vector

    /// <summary>Adds two vectors together.</summary>
    /// <param name="left">The first vector of the addition.</param>
    /// <param name="right">The second vector of the addiiton.</param>
    /// <returns>The result of the addiion.</returns>
    public static Vector<Fraction128> Add(Vector<Fraction128> left, Vector<Fraction128> right)
    {
      #region pre-optimization

      //Vector<Fraction128> result =
      //  new Vector<Fraction128>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] + right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector addition.");
#endif

      int length = left.Dimensions;
      Vector<Fraction128> result =
        new Vector<Fraction128>(left.Dimensions);

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
      }
#else
      Fraction128[] left_flat = left._vector;
      Fraction128[] right_flat = right._vector;
      Fraction128[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
#endif

      return result;
    }

    /// <summary>Negates all the values in a vector.</summary>
    /// <param name="vector">The vector to have its values negated.</param>
    /// <returns>The result of the negations.</returns>
    public static Vector<Fraction128> Negate(Vector<Fraction128> vector)
    {
      #region pre-optimization

      //Vector<Fraction128> result =
      //  new Vector<Fraction128>(vector.Dimensions);
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result[i] = -vector[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Vector<Fraction128> result =
        new Vector<Fraction128>(length);

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = -vector_flat[i];
      }
#else
      Fraction128[] vector_flat = vector._vector;
      Fraction128[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = -vector_flat[i];
#endif

      return result;
    }

    /// <summary>Subtracts two vectors.</summary>
    /// <param name="left">The left vector of the subtraction.</param>
    /// <param name="right">The right vector of the subtraction.</param>
    /// <returns>The result of the vector subtracton.</returns>
    public static Vector<Fraction128> Subtract(Vector<Fraction128> left, Vector<Fraction128> right)
    {
      #region pre-optimization

      //Vector<Fraction128> result =
      //  new Vector<Fraction128>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] - right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector subtraction.");
#endif

      int length = left.Dimensions;
      Vector<Fraction128> result =
        new Vector<Fraction128>(length);

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] - right_flat[i];
      }
#else
      Fraction128[] left_flat = left._vector;
      Fraction128[] right_flat = right._vector;
      Fraction128[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] - right_flat[i];
#endif

      return result;
    }

    /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
    /// <param name="left">The vector to have the components multiplied by.</param>
    /// <param name="right">The scalars to multiply the vector components by.</param>
    /// <returns>The result of the multiplications.</returns>
    public static Vector<Fraction128> Multiply(Vector<Fraction128> left, Fraction128 right)
    {
      #region pre-optimization

      //Vector<Fraction128> result =
      //  new Vector<Fraction128>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] * right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      int length = left.Dimensions;
      Vector<Fraction128> result =
        new Vector<Fraction128>(length);

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          left_flat = left._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] * right;
      }
#else
      Fraction128[] left_flat = left._vector;
      Fraction128[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] * right;
#endif

      return result;
    }

    /// <summary>Divides all the components of a vector by a scalar.</summary>
    /// <param name="vector">The vector to have the components divided by.</param>
    /// <param name="right">The scalar to divide the vector components by.</param>
    /// <returns>The resulting vector after teh divisions.</returns>
    public static Vector<Fraction128> Divide(Vector<Fraction128> vector, Fraction128 right)
    {
      #region pre-optimization

      //Vector<Fraction128> result =
      //  new Vector<Fraction128>(vector.Dimensions);
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result[i] = vector[i] / right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: left");
#endif

      int length = vector.Dimensions;
      Vector<Fraction128> result =
        new Vector<Fraction128>(length);

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = vector_flat[i] / right;
      }
#else
      Fraction128[] vector_flat = vector._vector;
      Fraction128[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = vector_flat[i] / right;
#endif

      return result;
    }

    /// <summary>Computes the dot product between two vectors.</summary>
    /// <param name="left">The first vector of the dot product operation.</param>
    /// <param name="right">The second vector of the dot product operation.</param>
    /// <returns>The result of the dot product operation.</returns>
    public static Fraction128 DotProduct(Vector<Fraction128> left, Vector<Fraction128> right)
    {
      #region pre-optimization

      //Fraction128 result = 0;
      //for (int i = 0; i < left.Dimensions; i++)
      //  result += left[i] * right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector dot product.");
#endif

      int length = left.Dimensions;
      Fraction128 result = 0;

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          left_flat = left._vector,
          right_flat = right._vector)
          for (int i = 0; i < length; i++)
            result += left_flat[i] * right_flat[i];
      }
#else
      Fraction128[] left_flat = left._vector;
      Fraction128[] right_flat = right._vector;
      for (int i = 0; i < length; i++)
        result += left_flat[i] * right_flat[i];
#endif

      return result;
    }

    /// <summary>Computes teh cross product of two vectors.</summary>
    /// <param name="left">The first vector of the cross product operation.</param>
    /// <param name="right">The second vector of the cross product operation.</param>
    /// <returns>The result of the cross product operation.</returns>
    public static Vector<Fraction128> CrossProduct(Vector<Fraction128> left, Vector<Fraction128> right)
    {
      #region pre-optimization

      //Vector<Fraction128> result = new Vector<Fraction128>(3);
      //result[0] = left[1] * right[2] - left[2] * right[1];
      //result[1] = left[2] * right[0] - left[0] * right[2];
      //result[2] = left[0] * right[1] - left[1] * right[0];

      #endregion

#if no_error_checking

#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid cross product (left.Dimensions != right.Dimensions)");
      if (left.Dimensions != 3)
        throw new Error("my cross product function is only defined for 3-component vectors.");
#endif

      Vector<Fraction128> result =
        new Vector<Fraction128>(3);

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
        {
          result_flat[0] = left_flat[1] * right_flat[2] - left_flat[2] * right_flat[1];
          result_flat[1] = left_flat[2] * right_flat[0] - left_flat[0] * right_flat[2];
          result_flat[2] = left_flat[0] * right_flat[1] - left_flat[1] * right_flat[0];
        }
      }
#else
      Fraction128[] left_flat = left._vector;
      Fraction128[] right_flat = right._vector;
      Fraction128[] result_flat = result._vector;
      result_flat[0] = left_flat[1] * right_flat[2] - left_flat[2] * right_flat[1];
      result_flat[1] = left_flat[2] * right_flat[0] - left_flat[0] * right_flat[2];
      result_flat[2] = left_flat[0] * right_flat[1] - left_flat[1] * right_flat[0];
#endif

      return result;
    }

    /// <summary>Normalizes a vector.</summary>
    /// <param name="vector">The vector to normalize.</param>
    /// <returns>The result of the normalization.</returns>
    public static Vector<Fraction128> Normalize(Vector<Fraction128> vector)
    {
      #region pre-optimization

      //Fraction128 magnitude = LinearAlgebra.Magnitude(vector);
      //if (magnitude != 0)
      //{
      //  Vector<Fraction128> result = 
      //    new Vector<Fraction128>(vector.Dimensions);
      //  for (int i = 0; i < vector.Dimensions; i++)
      //    result[i] = vector[i] / magnitude;
      //  return result;
      //}
      //else
      //  return new Fraction128[vector.Dimensions];

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Vector<Fraction128> result =
        new Vector<Fraction128>(vector.Dimensions);
      Fraction128 magnitude = LinearAlgebra.Magnitude(vector);
      if (magnitude != 0)
        return result;

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = vector_flat[i] / magnitude;
      }
#else
      Fraction128[] vector_flat = vector._vector;
      Fraction128[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = vector_flat[i] / magnitude;
#endif

      return result;

    }

    /// <summary>Computes the length of a vector.</summary>
    /// <param name="vector">The vector to calculate the length of.</param>
    /// <returns>The computed length of the vector.</returns>
    public static Fraction128 Magnitude(Vector<Fraction128> vector)
    {
      #region pre-optimization

      //Fraction128 result = 0;
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result += vector[i] * vector[i];
      //return Algebra.sqrt(result);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Fraction128 result = 0;

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          vector_flat = vector._vector)
          for (int i = 0; i < length; i++)
            result += vector_flat[i] * vector_flat[i];
      }
#else
      Fraction128[] vector_flat = vector._vector;
      for (int i = 0; i < length; i++)
        result += vector_flat[i] * vector_flat[i];
#endif

      return Algebra.sqrt(result);
    }

    /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
    /// <param name="vector">The vector to compute the length squared of.</param>
    /// <returns>The computed length squared of the vector.</returns>
    public static Fraction128 MagnitudeSquared(Vector<Fraction128> vector)
    {
      #region pre-optimization

      //Fraction128 result = 0;
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result += vector[i] * vector[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Fraction128 result = 0;

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          vector_flat = vector._vector)
          for (int i = 0; i < length; i++)
            result += vector_flat[i] * vector_flat[i];
      }
#else
      Fraction128[] vector_flat = vector._vector;
      for (int i = 0; i < length; i++)
        result += vector_flat[i] * vector_flat[i];
#endif

      return result;
    }

    /// <summary>Computes the angle between two vectors.</summary>
    /// <param name="first">The first vector to determine the angle between.</param>
    /// <param name="second">The second vector to determine the angle between.</param>
    /// <returns>The angle between the two vectors in radians.</returns>
    public static Fraction128 Angle(Vector<Fraction128> first, Vector<Fraction128> second)
    {
      #region pre-optimization

      //return Trigonometry.arccos(
      //  LinearAlgebra.DotProduct(first, second) / 
      //  (LinearAlgebra.Magnitude(first) * 
      //  LinearAlgebra.Magnitude(second)));

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(first, null))
        throw new Error("null reference: first");
      if (object.ReferenceEquals(second, null))
        throw new Error("null reference: second");
#endif

      return Trigonometry.arccos(
        LinearAlgebra.DotProduct(first, second) /
        (LinearAlgebra.Magnitude(first) *
        LinearAlgebra.Magnitude(second)));
    }

    /// <summary>Rotates a 3-component vector by the specified axis and rotation values.</summary>
    /// <param name="vector">The vector to rotate.</param>
    /// <param name="angle">The angle of the rotation in radians.</param>
    /// <param name="x">The x component of the axis vector to rotate about.</param>
    /// <param name="y">The y component of the axis vector to rotate about.</param>
    /// <param name="z">The z component of the axis vector to rotate about.</param>
    /// <returns>The result of the rotation.</returns>
    public static Vector<Fraction128> RotateBy(Vector<Fraction128> vector, Fraction128 angle, Fraction128 x, Fraction128 y, Fraction128 z)
    {
      #region pre-optimization

      //Fraction128 sinHalfAngle = Trigonometry.sin(angle / 2);
      //Fraction128 cosHalfAngle = Trigonometry.cos(angle / 2);
      //x *= sinHalfAngle;
      //y *= sinHalfAngle;
      //z *= sinHalfAngle;
      //Fraction128 x2 = cosHalfAngle * vector[0] + y * vector[2] - z * vector[1];
      //Fraction128 y2 = cosHalfAngle * vector[1] + z * vector[0] - x * vector[2];
      //Fraction128 z2 = cosHalfAngle * vector[2] + x * vector[1] - y * vector[0];
      //Fraction128 w2 = -x * vector[0] - y * vector[1] - z * vector[2];
      //Vector<Fraction128> result = new Vector<Fraction128>();
      //result[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
      //result[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
      //result[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
      if (vector.Dimensions == 3)
        throw new Error("my RotateBy() function is only defined for 3-component vectors.");
#endif

      Vector<Fraction128> result = new Vector<Fraction128>(3);
      Fraction128 sinHalfAngle = Trigonometry.sin(angle / 2);
      Fraction128 cosHalfAngle = Trigonometry.cos(angle / 2);
      x *= sinHalfAngle;
      y *= sinHalfAngle;
      z *= sinHalfAngle;

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          vector_flat = vector._vector,
          result_flat = result._vector)
        {
          Fraction128 x2 = cosHalfAngle * vector_flat[0] + y * vector_flat[2] - z * vector_flat[1];
          Fraction128 y2 = cosHalfAngle * vector_flat[1] + z * vector_flat[0] - x * vector_flat[2];
          Fraction128 z2 = cosHalfAngle * vector_flat[2] + x * vector_flat[1] - y * vector_flat[0];
          Fraction128 w2 = -x * vector_flat[0] - y * vector_flat[1] - z * vector_flat[2];
          result_flat[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
          result_flat[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
          result_flat[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;
        }
      }
#else
      Fraction128[] vector_flat = vector._vector;
      Fraction128[] result_flat = result._vector;
      Fraction128 x2 = cosHalfAngle * vector_flat[0] + y * vector_flat[2] - z * vector_flat[1];
      Fraction128 y2 = cosHalfAngle * vector_flat[1] + z * vector_flat[0] - x * vector_flat[2];
      Fraction128 z2 = cosHalfAngle * vector_flat[2] + x * vector_flat[1] - y * vector_flat[0];
      Fraction128 w2 = -x * vector_flat[0] - y * vector_flat[1] - z * vector_flat[2];
      result_flat[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
      result_flat[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
      result_flat[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;
#endif

      return result;
    }

    /// <summary>Rotates a vector by a quaternion rotation.</summary>
    /// <param name="vector">The vector to be rotated.</param>
    /// <param name="quaternion">The rotation to be applied.</param>
    /// <returns>The vector after the rotation.</returns>
    public static Vector<Fraction128> RotateBy(Vector<Fraction128> vector, Quaternion<Fraction128> quaternion)
    {
      return Rotate(quaternion, vector);
    }

    /// <summary>Computes the linear interpolation between two vectors.</summary>
    /// <param name="left">The starting vector of the interpolation.</param>
    /// <param name="right">The ending vector of the interpolation.</param>
    /// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Vector<Fraction128> Lerp(Vector<Fraction128> left, Vector<Fraction128> right, Fraction128 blend)
    {
      #region pre-optimization

      //Vector<Fraction128> result = new Vector<Fraction128>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] + blend * (right[i] - left[i]);
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (blend < 0 || blend > 1)
        throw new Error("invalid vector lerp blend value: (blend < 0.0f || blend > 1.0f).");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid vector lerp length: (left.Dimensions != right.Dimensions)");
#endif

      int length = left.Dimensions;
      Vector<Fraction128> result =
        new Vector<Fraction128>(length);

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + blend * (right_flat[i] - left_flat[i]);
      }
#else
      Fraction128[] left_flat = left._vector;
      Fraction128[] right_flat = right._vector;
      Fraction128[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] + blend * (right_flat[i] - left_flat[i]);
#endif

      return result;
    }

    /// <summary>Sphereically interpolates between two vectors.</summary>
    /// <param name="left">The starting vector of the interpolation.</param>
    /// <param name="right">The ending vector of the interpolation.</param>
    /// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
    /// <returns>The result of the slerp operation.</returns>
    public static Vector<Fraction128> Slerp(Vector<Fraction128> left, Vector<Fraction128> right, Fraction128 blend)
    {
      #region pre-optimization

      //Fraction128 dot = LinearAlgebra.DotProduct(left, right);
      //dot = dot < -1 ? -1 : dot;
      //dot = dot > 1 ? 1 : dot;
      //Fraction128 theta = Trigonometry.arccos(dot) * blend;
      //return LinearAlgebra.Multiply(LinearAlgebra.Add(LinearAlgebra.Multiply(left, Trigonometry.cos(theta)),
      //  LinearAlgebra.Normalize(LinearAlgebra.Subtract(right, LinearAlgebra.Multiply(left, dot)))), Trigonometry.sin(theta));

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (blend < 0 || blend > 1)
        throw new Error("invalid slerp blend value: (blend < 0.0f || blend > 1.0f).");
#endif

      Fraction128 dot = LinearAlgebra.DotProduct(left, right);
      dot = dot < -1 ? -1 : dot;
      dot = dot > 1 ? 1 : dot;
      Fraction128 theta = Trigonometry.arccos(dot) * blend;
      return LinearAlgebra.Multiply(LinearAlgebra.Add(LinearAlgebra.Multiply(left, Trigonometry.cos(theta)),
        LinearAlgebra.Normalize(LinearAlgebra.Subtract(right, LinearAlgebra.Multiply(left, dot)))), Trigonometry.sin(theta));
    }

    /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
    /// <param name="a">The first vector of the interpolation.</param>
    /// <param name="b">The second vector of the interpolation.</param>
    /// <param name="c">The thrid vector of the interpolation.</param>
    /// <param name="u">The "U" value of the barycentric interpolation equation.</param>
    /// <param name="v">The "V" value of the barycentric interpolation equation.</param>
    /// <returns>The resulting vector of the barycentric interpolation.</returns>
    public static Vector<Fraction128> Blerp(Vector<Fraction128> a, Vector<Fraction128> b, Vector<Fraction128> c, Fraction128 u, Fraction128 v)
    {
      #region pre-optimization

      //return 
      //  LinearAlgebra.Add(
      //    LinearAlgebra.Add(
      //      LinearAlgebra.Multiply(
      //        LinearAlgebra.Subtract(b, a), u),
      //          LinearAlgebra.Multiply(
      //            LinearAlgebra.Subtract(c, a), v)), a);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(a, null))
        throw new Error("null reference: a");
      if (object.ReferenceEquals(b, null))
        throw new Error("null reference: b");
      if (object.ReferenceEquals(c, null))
        throw new Error("null reference: c");
#endif

      return
        LinearAlgebra.Add(
          LinearAlgebra.Add(
            LinearAlgebra.Multiply(
              LinearAlgebra.Subtract(b, a), u),
                LinearAlgebra.Multiply(
                  LinearAlgebra.Subtract(c, a), v)), a);
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Vector<Fraction128> left, Vector<Fraction128> right)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;

      //if (left.Dimensions != right.Dimensions)
      //  return false;
      //for (int i = 0; i < left.Dimensions; i++)
      //  if (left[i] != right[i])
      //    return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Dimensions != right.Dimensions)
        return false;
      for (int i = 0; i < left.Dimensions; i++)
        if (left[i] != right[i])
          return false;
      return true;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Vector<Fraction128> left, Vector<Fraction128> right, Fraction128 leniency)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;

      //if (left.Dimensions != right.Dimensions)
      //  return false;
      //for (int i = 0; i < left.Dimensions; i++)
      //  if (Logic.Abs(left[i] - right[i]) > leniency)
      //    return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Dimensions != right.Dimensions)
        return false;
      for (int i = 0; i < left.Dimensions; i++)
        if (Logic.Abs(left[i] - right[i]) > leniency)
          return false;
      return true;
    }

    #endregion

    #region matrix

    /// <summary>Determines if a matrix is symetric or not.</summary>
    /// <param name="matrix">The matrix to determine symetry of.</param>
    /// <returns>True if symetric; false if not.</returns>
    public static bool IsSymmetric(Matrix<Fraction128> matrix)
    {
      #region pre-optimization

      //if (matrix.Rows != matrix.Columns)
      //  return false;
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    if (matrix[i, j] != matrix[j, i])
      //      return false;
      //return true;

      #endregion

#if no_errorchecking
      //nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        return false;
#endif
      int size = matrix.Columns;
#if unsafe_code
      unsafe
      {
        fixed (Fraction128* matrix_flat = matrix._matrix)
          for (var row = 0; row < size; row++)
            for (var column = row + 1; column < size; column++)
              if (matrix_flat[row * size + column] != matrix_flat[column * size + row])
                return false;
      }
#else
      Fraction128[] matrix_flat = matrix._matrix;
      for (var row = 0; row < size; row++)
        for (var column = row + 1; column < size; column++)
          if (matrix_flat[row * size + column] != matrix_flat[column * size + row])
            return false;
#endif
      return true;
    }

    /// <summary>Constructs a new identity-matrix of the given dimensions.</summary>
    /// <param name="rows">The number of rows of the matrix.</param>
    /// <param name="columns">The number of columns of the matrix.</param>
    /// <returns>The newly constructed identity-matrix.</returns>
    public static Matrix<Fraction128> MatrixFactoryIdentity_Fraction128(int rows, int columns)
    {
      #region pre-optimization

      //Matrix<Fraction128> matrix = 
      //  new Matrix<Fraction128>(rows, columns);
      //for (int i = 0; i < Logic.Min(rows, columns); i++)
      //  matrix[i, i] = 1;
      //return matrix;

      #endregion

#if no_error_checking
      //nothing
#else
      if (rows < 1)
        throw new Error("invalid row count on matrix creation");
      if (columns < 1)
        throw new Error("invalid column count on matrix creation");
#endif

      Matrix<Fraction128> matrix = new Matrix<Fraction128>(rows, columns);
      if (rows <= columns)
        for (int i = 0; i < rows; i++)
          matrix[i, i] = 1;
      else
        for (int i = 0; i < columns; i++)
          matrix[i, i] = 1;
      return matrix;
    }

    /// <summary>Negates all the values in a matrix.</summary>
    /// <param name="matrix">The matrix to have its values negated.</param>
    /// <returns>The resulting matrix after the negations.</returns>
    public static Matrix<Fraction128> Negate(Matrix<Fraction128> matrix)
    {
      #region pre-optimization

      //Matrix<Fraction128> result =
      //  new Matrix<Fraction128>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Rows; j++)
      //    result[i, j] = -matrix[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
        if (object.ReferenceEquals(matrix, null))
          throw new Error("null reference: matirx");
#endif

      Matrix<Fraction128> result =
        new Matrix<Fraction128>(matrix.Rows, matrix.Columns);
      int size = matrix.Rows * matrix.Columns;

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          result_flat = result._matrix,
          matrix_flat = matrix._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = -matrix_flat[i];
        return result;
      }
#else
      Fraction128[] result_flat = result._matrix;
      Fraction128[] matrix_flat = matrix._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = -matrix_flat[i];
      return result;
#endif
    }

    /// <summary>Negates all the values in a matrix.</summary>
    /// <param name="matrix">The matrix to have its values negated.</param>
    /// <returns>The resulting matrix after the negations.</returns>
    public static Matrix<Fraction128> Negate_parallel(Matrix<Fraction128> matrix)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matirx");
#endif

      if (matrix.Rows * matrix.Columns > _parallelMinimum)
      {
        Matrix<Fraction128> result =
        new Matrix<Fraction128>(matrix.Rows, matrix.Columns);
        int size = matrix.Rows * matrix.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (Fraction128*
                  result_flat = result._matrix,
                  matrix_flat = matrix._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = -matrix_flat[i];
              };
            }, Logic.Max(matrix.Rows, matrix.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                Fraction128[] matrix_flat = matrix._matrix;
                Fraction128[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = -matrix_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Negate(matrix);
    }

    /// <summary>Does standard addition of two matrices.</summary>
    /// <param name="left">The left matrix of the addition.</param>
    /// <param name="right">The right matrix of the addition.</param>
    /// <returns>The resulting matrix after the addition.</returns>
    public static Matrix<Fraction128> Add(Matrix<Fraction128> left, Matrix<Fraction128> right)
    {
      #region pre-optimization

      //Matrix<Fraction128> result =
      //  new Matrix<Fraction128>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] + right[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
          throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix addition (dimension miss-match).");
#endif

      Matrix<Fraction128> result =
        new Matrix<Fraction128>(left.Rows, left.Columns);
      int size = left.Rows * left.Columns;

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
      }
#else
      Fraction128[] left_flat = left._matrix;
      Fraction128[] right_flat = right._matrix;
      Fraction128[] result_flat = result._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = left_flat[i] + right_flat[i];
#endif

      return result;
    }

    /// <summary>Does standard addition of two matrices.</summary>
    /// <param name="left">The left matrix of the addition.</param>
    /// <param name="right">The right matrix of the addition.</param>
    /// <returns>The resulting matrix after the addition.</returns>
    public static Matrix<Fraction128> Add_parallel(Matrix<Fraction128> left, Matrix<Fraction128> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix addition (dimension miss-match).");
#endif

      if (left.Rows * left.Columns > _parallelMinimum)
      {
        Matrix<Fraction128> result =
        new Matrix<Fraction128>(left.Rows, left.Columns);
        int size = left.Rows * left.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (Fraction128*
                  left_flat = left._matrix,
                  right_flat = right._matrix,
                  result_flat = result._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = left_flat[i] + right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                Fraction128[] left_flat = left._matrix;
                Fraction128[] right_flat = right._matrix;
                Fraction128[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = left_flat[i] + right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Add(left, right);
    }

    /// <summary>Subtracts a scalar from all the values in a matrix.</summary>
    /// <param name="left">The matrix to have the values subtracted from.</param>
    /// <param name="right">The scalar to subtract from all the matrix values.</param>
    /// <returns>The resulting matrix after the subtractions.</returns>
    public static Matrix<Fraction128> Subtract(Matrix<Fraction128> left, Matrix<Fraction128> right)
    {
      #region pre-optimization

      //Matrix<Fraction128> result =
      //  new Matrix<Fraction128>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] - right[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix subtraction (dimension miss-match).");
#endif

      Matrix<Fraction128> result =
        new Matrix<Fraction128>(left.Rows, left.Columns);
      int size = left.Rows * left.Columns;

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = left_flat[i] - right_flat[i];
      }
#else
      Fraction128[] left_flat = left._matrix;
      Fraction128[] right_flat = right._matrix;
      Fraction128[] result_flat = result._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = left_flat[i] - right_flat[i];
#endif

      return result;
    }

    /// <summary>Subtracts a scalar from all the values in a matrix.</summary>
    /// <param name="left">The matrix to have the values subtracted from.</param>
    /// <param name="right">The scalar to subtract from all the matrix values.</param>
    /// <returns>The resulting matrix after the subtractions.</returns>
    public static Matrix<Fraction128> Subtract_parallel(Matrix<Fraction128> left, Matrix<Fraction128> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix subtraction (dimension miss-match).");
#endif

      if (left.Rows * left.Columns > _parallelMinimum)
      {
        Matrix<Fraction128> result =
        new Matrix<Fraction128>(left.Rows, left.Columns);
        int size = left.Rows * left.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (Fraction128*
                  left_flat = left._matrix,
                  right_flat = right._matrix,
                  result_flat = result._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = left_flat[i] - right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
          (int current, int max) =>
          {
            return () =>
            {
              Fraction128[] left_flat = left._matrix;
              Fraction128[] right_flat = right._matrix;
              Fraction128[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = left_flat[i] - right_flat[i];
            };
          }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Subtract(left, right);
    }

    /// <summary>Performs multiplication on two matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Matrix<Fraction128> Multiply(Matrix<Fraction128> left, Matrix<Fraction128> right)
    {
      #region pre-optimization

      //Matrix<Fraction128> result = 
      //  new Matrix<Fraction128>(left.Rows, right.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < right.Columns; j++)
      //    for (int k = 0; k < left.Columns; k++)
      //      result[i, j] += left[i, k] * right[k, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (left == null)
        throw new Error("null reference: left");
      if (right == null)
        throw new Error("null reference: right");
      if (left.Columns != right.Rows)
        throw new LinearAlgebra.Error("invalid multiplication (size miss-match).");
#endif

      Fraction128 sum;
      int result_rows = left.Rows;
      int left_cols = left.Columns;
      int result_cols = right.Columns;
      Matrix<Fraction128> result =
        new Matrix<Fraction128>(result_rows, result_cols);

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          result_flat = result._matrix,
          left_flat = left._matrix,
          right_flat = right._matrix)
          for (int i = 0; i < result_rows; i++)
            for (int j = 0; j < result_cols; j++)
            {
              sum = 0;
              for (int k = 0; k < left_cols; k++)
                sum += left_flat[i * left_cols + k] * right_flat[k * result_cols + j];
              result_flat[i * result_cols + j] = sum;
            }
      }
#else
      Fraction128[] result_flat = result._matrix;
      Fraction128[] left_flat = left._matrix;
      Fraction128[] right_flat = right._matrix;

      for (int i = 0; i < result_rows; i++)
        for (int j = 0; j < result_cols; j++)
        {
          sum = 0;
          for (int k = 0; k < left_cols; k++)
            sum += left_flat[i * left_cols + k] * right_flat[k * result_cols + j];
          result_flat[i * result_cols + j] = sum;
        }
#endif

      return result;
    }

    /// <summary>Performs multiplication on two matrices using multi-threading.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Matrix<Fraction128> Multiply_parrallel(Matrix<Fraction128> left, Matrix<Fraction128> right)
    {
#if no_error_checking
      // nothing
#else
      if (left == null)
        throw new Error("null reference: left");
      if (right == null)
        throw new Error("null reference: right");
      if (left.Columns != right.Rows)
        throw new LinearAlgebra.Error("invalid multiplication (dimension miss-match).");
#endif

      int result_rows = left.Rows;
      int left_cols = left.Columns;
      int result_cols = right.Columns;

      // If there are enough rows to warrant multi-threading,
      // then multithread the row for-loop.
      if (result_rows * result_cols > _parallelMinimum &&
        result_rows >= result_cols)
      {
        Matrix<Fraction128> result =
          new Matrix<Fraction128>(result_rows, result_cols);
#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                Fraction128 sum;
                int left_i_offest;
                int result_i_offset;

                fixed (Fraction128*
                  result_flat = result._matrix,
                  left_flat = left._matrix,
                  right_flat = right._matrix)
                  for (int i = current; i < result_rows; i += max)
                  {
                    left_i_offest = i * left_cols;
                    result_i_offset = i * result_cols;
                    for (int j = 0; j < result_cols; j++)
                    {
                      sum = 0;
                      for (int k = 0; k < left_cols; k++)
                        sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                      result_flat[result_i_offset + j] = sum;
                    }
                  }
              };
            }, result_rows);
        }
#else
              Fraction128[] result_flat = result._matrix;
              Fraction128[] left_flat = left._matrix;
              Fraction128[] right_flat = right._matrix;

              Seven.Parallels.AutoParallel.Divide(
                  (int current, int max) =>
                  {
                    return () =>
                    {
                      Fraction128 sum;
                      int left_i_offest;
                      int result_i_offset;

                      for (int i = current; i < result_rows; i += max)
                      {
                        left_i_offest = i * left_cols;
                        result_i_offset = i * result_cols;
                        for (int j = 0; j < result_cols; j++)
                        {
                          sum = 0;
                          for (int k = 0; k < left_cols; k++)
                            sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                          result_flat[result_i_offset + j] = sum;
                        }
                      }
                    };
                  }, result_rows);

#endif
        return result;
      }
      // If there are enough columns to warrant multi-threading,
      // then multithread the column for-loop.
      else if (result_rows * result_cols > _parallelMinimum &&
        result_rows < result_cols)
      {
        Matrix<Fraction128> result =
          new Matrix<Fraction128>(result_rows, result_cols);
#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                Fraction128 sum;
                int left_i_offest;
                int result_i_offset;

                fixed (Fraction128*
                  result_flat = result._matrix,
                  left_flat = left._matrix,
                  right_flat = right._matrix)
                  for (int i = 0; i < result_rows; i++)
                  {
                    left_i_offest = i * left_cols;
                    result_i_offset = i * result_cols;
                    for (int j = current; j < result_cols; j += max)
                    {
                      sum = 0;
                      for (int k = 0; k < left_cols; k++)
                        sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                      result_flat[result_i_offset + j] = sum;
                    }
                  }
              };
            }, result_cols);
        }
#else
              Fraction128[] result_flat = result._matrix;
              Fraction128[] left_flat = left._matrix;
              Fraction128[] right_flat = right._matrix;

              Seven.Parallels.AutoParallel.Divide(
                  (int current, int max) =>
                  {
                    return () =>
                    {
                      Fraction128 sum;
                      int left_i_offest;
                      int result_i_offset;

                      for (int i = 0; i < result_rows; i++)
                      {
                        left_i_offest = i * left_cols;
                        result_i_offset = i * result_cols;
                        for (int j = current; j < result_cols; j += max)
                        {
                          sum = 0;
                          for (int k = 0; k < left_cols; k++)
                            sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                          result_flat[result_i_offset + j] = sum;
                        }
                      }
                    };
                  }, result_cols);
#endif
        return result;
      }
      // Multi-threading is not necessary.
      else
        return LinearAlgebra.Multiply(left, right);
    }

    /// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Vector<Fraction128> Multiply(Matrix<Fraction128> left, Vector<Fraction128> right)
    {
      #region pre-optimization

      //Vector<Fraction128> result = 
      //  new Vector<Fraction128>(right.Dimensions);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i] += left[i, j] * right[j];
      //return result;

      #endregion

#if no_error_checking
      int left_row = left.Rows;
      int left_col = left.Columns;
#else
      int left_row = left.Rows;
      int left_col = left.Columns;
      if (left.Columns != right.Dimensions)
        throw new Error("invalid multiplication (size miss-match).");
#endif

      Vector<Fraction128> result = new Vector<Fraction128>(right.Dimensions);

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          left_flat = left._matrix,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < left_row; i++)
            for (int j = 0; j < left_col; j++)
              result_flat[i] += left_flat[i * left_col + j] * right_flat[j];
        return result;
      }
#else
      Fraction128[] left_flat = left._matrix;
      Fraction128[] right_flat = right._vector;
      Fraction128[] result_flat = result._vector;
      for (int i = 0; i < left_row; i++)
        for (int j = 0; j < left_col; j++)
          result_flat[i] += left_flat[i * left_col + j] * right_flat[j];
      return result;
#endif
      return result;
    }

    /// <summary>Multiplies all the values in a matrix by a scalar.</summary>
    /// <param name="left">The matrix to have the values multiplied.</param>
    /// <param name="right">The scalar to multiply the values by.</param>
    /// <returns>The resulting matrix after the multiplications.</returns>
    public static Matrix<Fraction128> Multiply(Matrix<Fraction128> left, Fraction128 right)
    {
      #region pre-optimization

      //Matrix<Fraction128> result = 
      //  new Matrix<Fraction128>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] * right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      int rows = left.Rows;
      int columns = left.Columns;
      Matrix<Fraction128> result = new Matrix<Fraction128>(rows, columns);

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          left_flat = left._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
              result_flat[i * columns + j] = left_flat[i * columns + j] * right;
      }
#else
      for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
          result[i, j] = left[i, j] * right;
#endif

      return result;
    }

    /// <summary>Applies a power to a square matrix.</summary>
    /// <param name="matrix">The matrix to be powered by.</param>
    /// <param name="power">The power to apply to the matrix.</param>
    /// <returns>The resulting matrix of the power operation.</returns>
    public static Matrix<Fraction128> Power(Matrix<Fraction128> matrix, int power)
    {
      #region pre-optimization

      //Matrix<Fraction128> result = matrix.Clone();
      //for (int i = 0; i < power; i++)
      //  result = LinearAlgebra.Multiply(result, result);
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (!(matrix.Rows == matrix.Columns))
        throw new Error("invalid power (!matrix.IsSquare).");
      if (!(power >= 0))
        throw new Error("invalid power !(power > -1)");
#endif
      // this is not optimized...
      if (power == 0)
        return LinearAlgebra.MatrixFactoryIdentity_Fraction128(matrix.Rows, matrix.Columns);
      Matrix<Fraction128> result = matrix.Clone();
      for (int i = 0; i < power; i++)
        result = LinearAlgebra.Multiply(result, matrix);
      return result;
    }

    /// <summary>Divides all the values in the matrix by a scalar.</summary>
    /// <param name="matrix">The matrix to divide the values of.</param>
    /// <param name="right">The scalar to divide all the matrix values by.</param>
    /// <returns>The resulting matrix with the divided values.</returns>
    public static Matrix<Fraction128> Divide(Matrix<Fraction128> matrix, Fraction128 right)
    {
      #region pre-optimization

      //Matrix<Fraction128> result = 
      //  new Matrix<Fraction128>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    result[i, j] = matrix[i, j] / right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      int matrix_row = matrix.Rows;
      int matrix_col = matrix.Columns;
      Matrix<Fraction128> result =
        new Matrix<Fraction128>(matrix_row, matrix_col);

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          matrix_flat = matrix._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < matrix_row; i++)
            for (int j = 0; j < matrix_col; j++)
              result_flat[i * matrix_col + j] =
                matrix_flat[i * matrix_col + j] / right;
      }
#else
      Fraction128[] matrix_flat = matrix._matrix;
      Fraction128[] result_flat = result._matrix;
      for (int i = 0; i < matrix_row; i++)
        for (int j = 0; j < matrix_col; j++)
          result_flat[i * matrix_col + j] = 
            matrix_flat[i * matrix_col + j] / right;

#endif
      return result;
    }

    /// <summary>Gets the minor of a matrix.</summary>
    /// <param name="matrix">The matrix to get the minor of.</param>
    /// <param name="row">The restricted row to form the minor.</param>
    /// <param name="column">The restricted column to form the minor.</param>
    /// <returns>The minor of the matrix.</returns>
    public static Matrix<Fraction128> Minor(Matrix<Fraction128> matrix, int row, int column)
    {
      #region pre-optimization

      //Matrix<Fraction128> minor = 
      //  new Matrix<Fraction128>(matrix.Rows - 1, matrix.Columns - 1);
      //int m = 0, n = 0;
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (i == row) continue;
      //  n = 0;
      //  for (int j = 0; j < matrix.Columns; j++)
      //  {
      //    if (j == column) continue;
      //    minor[m, n] = matrix[i, j];
      //    n++;
      //  }
      //  m++;
      //}
      //return minor;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows < 2 || matrix.Columns < 2)
        throw new Error("invalid matrix minor: (matrix.Rows < 2 || matrix.Columns < 2)");
      if (row < 0 || row >= matrix.Rows)
        throw new Error("invalid row on matrix minor: !(0 <= row < matrix.Rows)");
      if (column < 0 || row >= matrix.Columns)
        throw new Error("invalid column on matrix minor: !(0 <= column < matrix.Columns)");
#endif

      Matrix<Fraction128> minor =
        new Matrix<Fraction128>(matrix.Rows - 1, matrix.Columns - 1);
      int matrix_rows = matrix.Rows;
      int matrix_cols = matrix.Columns;

#if unsafe_code
      unsafe
      {
        fixed (Fraction128*
          matrix_flat = matrix._matrix,
          minor_flat = minor._matrix)
        {
          int m = 0, n = 0;
          for (int i = 0; i < matrix_rows; i++)
          {
            if (i == row) continue;
            n = 0;
            for (int j = 0; j < matrix_cols; j++)
            {
              if (j == column) continue;
              minor_flat[m * matrix_cols + n] =
                matrix_flat[i * matrix_cols + j];
              n++;
            }
            m++;
          }
        }
      }
#else
      int m = 0, n = 0;
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (i == row) continue;
        n = 0;
        for (int j = 0; j < matrix.Columns; j++)
        {
          if (j == column) continue;
          minor[m, n] = matrix[i, j];
          n++;
        }
        m++;
      }
#endif
      return minor;
    }

    /// <summary>Combines two matrices from left to right 
    /// (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
    /// <param name="left">The left matrix of the concatenation.</param>
    /// <param name="right">The right matrix of the concatenation.</param>
    /// <returns>The resulting matrix of the concatenation.</returns>
    public static Matrix<Fraction128> ConcatenateRowWise(Matrix<Fraction128> left, Matrix<Fraction128> right)
    {
      #region pre-optimization

      //Matrix<Fraction128> result =
      //  new Matrix<Fraction128>(left.Rows, left.Columns + right.Columns);
      //for (int i = 0; i < result.Rows; i++)
      //  for (int j = 0; j < result.Columns; j++)
      //    if (j < left.Columns)
      //      result[i, j] = left[i, j];
      //    else
      //      result[i, j] = right[i, j - left.Columns];
      //return result;

      #endregion

#if no_errorChecking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows)
        throw new Error("invalid row-wise concatenation !(left.Rows == right.Rows).");
#endif

      Matrix<Fraction128> result =
        new Matrix<Fraction128>(left.Rows, left.Columns + right.Columns);
      int result_rows = result.Rows;
      int result_cols = result.Columns;

      int left_cols = left.Columns;
      int right_cols = right.Columns;

#if unsafe_code
      unsafe
      {
        // OptimizeMe (jump statement)
        fixed (Fraction128*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < result_rows; i++)
            for (int j = 0; j < result_cols; j++)
              if (j < left_cols)
                result_flat[i * result_cols + j] =
                  left_flat[i * left_cols + j];
              else
                result_flat[i * result_cols + j] =
                  right_flat[i * right_cols + j - left_cols];
      }
#else
      for (int i = 0; i < result_rows; i++)
        for (int j = 0; j < result_cols; j++)
        {
          if (j < left.Columns)
            result[i, j] = left[i, j];
          else
            result[i, j] = right[i, j - left.Columns];
        }
#endif

      return result;
    }

    /// <summary>Calculates the echelon of a matrix (aka REF).</summary>
    /// <param name="matrix">The matrix to calculate the echelon of (aka REF).</param>
    /// <returns>The echelon of the matrix (aka REF).</returns>
    public static Matrix<Fraction128> Echelon(Matrix<Fraction128> matrix)
    {
      #region pre-optimization

      //Matrix<Fraction128> result = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (result[i, i] == 0)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] != 0)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  if (result[i, i] == 0)
      //    continue;
      //  if (result[i, i] != 1)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] == 1)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
      //  for (int j = i + 1; j < result.Rows; j++)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<Fraction128> result = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (result[i, i] == 0)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] != 0)
              LinearAlgebra.SwapRows(result, i, j);
        if (result[i, i] == 0)
          continue;
        if (result[i, i] != 1)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] == 1)
              LinearAlgebra.SwapRows(result, i, j);
        LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
        for (int j = i + 1; j < result.Rows; j++)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      }
      return result;
    }

    /// <summary>Calculates the echelon of a matrix and reduces it (aka RREF).</summary>
    /// <param name="matrix">The matrix matrix to calculate the reduced echelon of (aka RREF).</param>
    /// <returns>The reduced echelon of the matrix (aka RREF).</returns>
    public static Matrix<Fraction128> ReducedEchelon(Matrix<Fraction128> matrix)
    {
      #region pre-optimization

      //Matrix<Fraction128> result = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (result[i, i] == 0)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] != 0)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  if (result[i, i] == 0) continue;
      //  if (result[i, i] != 1)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] == 1)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
      //  for (int j = i + 1; j < result.Rows; j++)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      //  for (int j = i - 1; j >= 0; j--)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<Fraction128> result = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (result[i, i] == 0)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] != 0)
              LinearAlgebra.SwapRows(result, i, j);
        if (result[i, i] == 0) continue;
        if (result[i, i] != 1)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] == 1)
              LinearAlgebra.SwapRows(result, i, j);
        LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
        for (int j = i + 1; j < result.Rows; j++)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
        for (int j = i - 1; j >= 0; j--)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      }
      return result;
    }

    /// <summary>Calculates the determinent of a square matrix.</summary>
    /// <param name="matrix">The matrix to calculate the determinent of.</param>
    /// <returns>The determinent of the matrix.</returns>
    public static Fraction128 Determinent(Matrix<Fraction128> matrix)
    {
      #region pre-optimization

      //Fraction128 det = 1;
      //Matrix<Fraction128> rref = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (rref[i, i] == 0)
      //    for (int j = i + 1; j < rref.Rows; j++)
      //      if (rref[j, i] != 0)
      //      {
      //        LinearAlgebra.SwapRows(rref, i, j);
      //        det *= -1;
      //      }
      //  det *= rref[i, i];
      //  LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
      //  for (int j = i + 1; j < rref.Rows; j++)
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  for (int j = i - 1; j >= 0; j--)
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //}
      //return det;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        throw new Error("invalid matrix determinent: !(matrix.IsSquare)");
#endif

      Fraction128 det = 1;
      Matrix<Fraction128> rref = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (rref[i, i] == 0)
          for (int j = i + 1; j < rref.Rows; j++)
            if (rref[j, i] != 0)
            {
              LinearAlgebra.SwapRows(rref, i, j);
              det *= -1;
            }
        det *= rref[i, i];
        LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
        for (int j = i + 1; j < rref.Rows; j++)
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        for (int j = i - 1; j >= 0; j--)
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      }
      return det;
    }

    /// <summary>Calculates the inverse of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the inverse of.</param>
    /// <returns>The inverse of the matrix.</returns>
    public static Matrix<Fraction128> Inverse(Matrix<Fraction128> matrix)
    {
      #region pre-optimization

      //Matrix<Fraction128> identity = 
      //  LinearAlgebra.MatrixFactoryIdentity_Fraction128(matrix.Rows, matrix.Columns);
      //Matrix<Fraction128> rref = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (rref[i, i] == 0)
      //    for (int j = i + 1; j < rref.Rows; j++)
      //      if (rref[j, i] != 0)
      //      {
      //        LinearAlgebra.SwapRows(rref, i, j);
      //        LinearAlgebra.SwapRows(identity, i, j);
      //      }
      //  LinearAlgebra.RowMultiplication(identity, i, 1 / rref[i, i]);
      //  LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
      //  for (int j = i + 1; j < rref.Rows; j++)
      //  {
      //    LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  }
      //  for (int j = i - 1; j >= 0; j--)
      //  {
      //    LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  }
      //}
      //return identity;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (LinearAlgebra.Determinent(matrix) == 0)
        throw new Error("inverse calculation failed.");
#endif

      Matrix<Fraction128> identity = LinearAlgebra.MatrixFactoryIdentity_Fraction128(matrix.Rows, matrix.Columns);
      Matrix<Fraction128> rref = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (rref[i, i] == 0)
          for (int j = i + 1; j < rref.Rows; j++)
            if (rref[j, i] != 0)
            {
              LinearAlgebra.SwapRows(rref, i, j);
              LinearAlgebra.SwapRows(identity, i, j);
            }
        LinearAlgebra.RowMultiplication(identity, i, 1 / rref[i, i]);
        LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
        for (int j = i + 1; j < rref.Rows; j++)
        {
          LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        }
        for (int j = i - 1; j >= 0; j--)
        {
          LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        }
      }
      return identity;
    }

    /// <summary>Calculates the adjoint of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the adjoint of.</param>
    /// <returns>The adjoint of the matrix.</returns>
    public static Matrix<Fraction128> Adjoint(Matrix<Fraction128> matrix)
    {
      #region pre-optimization

      //Matrix<Fraction128> AdjointMatrix = new Matrix<Fraction128>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    if ((i + j) % 2 == 0)
      //      AdjointMatrix[i, j] = LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      //    else
      //      AdjointMatrix[i, j] = -LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      //return LinearAlgebra.Transpose(AdjointMatrix);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (!(matrix.Rows == matrix.Columns))
        throw new Error("Adjoint of a non-square matrix does not exists");
#endif

      Matrix<Fraction128> AdjointMatrix = new Matrix<Fraction128>(matrix.Rows, matrix.Columns);
      for (int i = 0; i < matrix.Rows; i++)
        for (int j = 0; j < matrix.Columns; j++)
          if ((i + j) % 2 == 0)
            AdjointMatrix[i, j] = LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
          else
            AdjointMatrix[i, j] = -LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      return LinearAlgebra.Transpose(AdjointMatrix);
    }

    /// <summary>Returns the transpose of a matrix.</summary>
    /// <param name="matrix">The matrix to transpose.</param>
    /// <returns>The transpose of the matrix.</returns>
    public static Matrix<Fraction128> Transpose(Matrix<Fraction128> matrix)
    {
      #region pre-optimization

      //Matrix<Fraction128> transpose = 
      //  new Matrix<Fraction128>(matrix.Columns, matrix.Rows);
      //for (int i = 0; i < transpose.Rows; i++)
      //  for (int j = 0; j < transpose.Columns; j++)
      //    transpose[i, j] = matrix[j, i];
      //return transpose;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<Fraction128> transpose =
        new Matrix<Fraction128>(matrix.Columns, matrix.Rows);
      for (int i = 0; i < transpose.Rows; i++)
        for (int j = 0; j < transpose.Columns; j++)
          transpose[i, j] = matrix[j, i];
      return transpose;
    }

    /// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
    /// <param name="matrix">The matrix to decompose.</param>
    /// <param name="Lower">The computed lower triangular matrix.</param>
    /// <param name="Upper">The computed upper triangular matrix.</param>
    public static void DecomposeLU(Matrix<Fraction128> matrix, out Matrix<Fraction128> Lower, out Matrix<Fraction128> Upper)
    {
      #region pre-optimization

      //Lower = LinearAlgebra.MatrixFactoryIdentity_Fraction128(matrix.Rows, matrix.Columns);
      //Upper = matrix.Clone();
      //int[] permutation = new int[matrix.Rows];
      //for (int i = 0; i < matrix.Rows; i++) permutation[i] = i;
      //Fraction128 p = 0, pom2, detOfP = 1;
      //int k0 = 0, pom1 = 0;
      //for (int k = 0; k < matrix.Columns - 1; k++)
      //{
      //  p = 0;
      //  for (int i = k; i < matrix.Rows; i++)
      //    if ((Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k]) > p)
      //    {
      //      p = Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k];
      //      k0 = i;
      //    }
      //  if (p == 0)
      //    throw new Error("The matrix is singular!");
      //  pom1 = permutation[k];
      //  permutation[k] = permutation[k0];
      //  permutation[k0] = pom1;
      //  for (int i = 0; i < k; i++)
      //  {
      //    pom2 = Lower[k, i];
      //    Lower[k, i] = Lower[k0, i];
      //    Lower[k0, i] = pom2;
      //  }
      //  if (k != k0)
      //    detOfP *= -1;
      //  for (int i = 0; i < matrix.Columns; i++)
      //  {
      //    pom2 = Upper[k, i];
      //    Upper[k, i] = Upper[k0, i];
      //    Upper[k0, i] = pom2;
      //  }
      //  for (int i = k + 1; i < matrix.Rows; i++)
      //  {
      //    Lower[i, k] = Upper[i, k] / Upper[k, k];
      //    for (int j = k; j < matrix.Columns; j++)
      //      Upper[i, j] = Upper[i, j] - Lower[i, k] * Upper[k, j];
      //  }
      //}

      #endregion

#if no_error_checking
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        throw new Error("non-square matrix during DecomposeLU function");
#endif

      Lower = LinearAlgebra.MatrixFactoryIdentity_Fraction128(matrix.Rows, matrix.Columns);
      Upper = matrix.Clone();
      int[] permutation = new int[matrix.Rows];
      for (int i = 0; i < matrix.Rows; i++) permutation[i] = i;
      Fraction128 p = 0, pom2, detOfP = 1;
      int k0 = 0, pom1 = 0;
      for (int k = 0; k < matrix.Columns - 1; k++)
      {
        p = 0;
        for (int i = k; i < matrix.Rows; i++)
          if ((Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k]) > p)
          {
            p = Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k];
            k0 = i;
          }
        if (p == 0)
          throw new Error("The matrix is singular!");
        pom1 = permutation[k];
        permutation[k] = permutation[k0];
        permutation[k0] = pom1;
        for (int i = 0; i < k; i++)
        {
          pom2 = Lower[k, i];
          Lower[k, i] = Lower[k0, i];
          Lower[k0, i] = pom2;
        }
        if (k != k0)
          detOfP *= -1;
        for (int i = 0; i < matrix.Columns; i++)
        {
          pom2 = Upper[k, i];
          Upper[k, i] = Upper[k0, i];
          Upper[k0, i] = pom2;
        }
        for (int i = k + 1; i < matrix.Rows; i++)
        {
          Lower[i, k] = Upper[i, k] / Upper[k, k];
          for (int j = k; j < matrix.Columns; j++)
            Upper[i, j] = Upper[i, j] - Lower[i, k] * Upper[k, j];
        }
      }
    }

    private static void RowMultiplication(Matrix<Fraction128> matrix, int row, Fraction128 scalar)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //  matrix[row, j] *= scalar;

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
        matrix[row, j] *= scalar;
    }

    private static void RowAddition(Matrix<Fraction128> matrix, int target, int second, Fraction128 scalar)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //  matrix[target, j] += (matrix[second, j] * scalar);

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
        matrix[target, j] += (matrix[second, j] * scalar);
    }

    private static void SwapRows(Matrix<Fraction128> matrix, int row1, int row2)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //{
      //  Fraction128 temp = matrix[row1, j];
      //  matrix[row1, j] = matrix[row2, j];
      //  matrix[row2, j] = temp;
      //}

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
      {
        Fraction128 temp = matrix[row1, j];
        matrix[row1, j] = matrix[row2, j];
        matrix[row2, j] = temp;
      }
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Matrix<Fraction128> left, Matrix<Fraction128> right)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;
      //if (left.Rows != right.Rows || left.Columns != right.Columns)
      //  return false;
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    if (left[i, j] != right[i, j])
      //      return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Rows != right.Rows || left.Columns != right.Columns)
        return false;
      for (int i = 0; i < left.Rows; i++)
        for (int j = 0; j < left.Columns; j++)
          if (left[i, j] != right[i, j])
            return false;

      return true;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Matrix<Fraction128> left, Matrix<Fraction128> right, Fraction128 leniency)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;
      //if (left.Rows != right.Rows || left.Columns != right.Columns)
      //  return false;
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    if (Logic.Abs(left[i, j] - right[i, j]) > leniency)
      //      return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        return false;
      for (int i = 0; i < left.Rows; i++)
        for (int j = 0; j < left.Columns; j++)
          if (Logic.Abs(left[i, j] - right[i, j]) > leniency)
            return false;
      return true;
    }

    #endregion

    #region quaterion

    /// <summary>Computes the length of quaternion.</summary>
    /// <param name="quaternion">The quaternion to compute the length of.</param>
    /// <returns>The length of the given quaternion.</returns>
    public static Fraction128 Magnitude(Quaternion<Fraction128> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return Algebra.sqrt(
          (quaternion.X * quaternion.X +
          quaternion.Y * quaternion.Y +
          quaternion.Z * quaternion.Z +
          quaternion.W * quaternion.W));
    }

    /// <summary>Computes the length of a quaternion, but doesn't square root it
    /// for optimization possibilities.</summary>
    /// <param name="quaternion">The quaternion to compute the length squared of.</param>
    /// <returns>The squared length of the given quaternion.</returns>
    public static Fraction128 MagnitudeSquared(Quaternion<Fraction128> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return
        quaternion.X * quaternion.X +
        quaternion.Y * quaternion.Y +
        quaternion.Z * quaternion.Z +
        quaternion.W * quaternion.W;
    }

    /// <summary>Gets the conjugate of the quaternion.</summary>
    /// <param name="quaternion">The quaternion to conjugate.</param>
    /// <returns>The conjugate of teh given quaternion.</returns>
    public static Quaternion<Fraction128> Conjugate(Quaternion<Fraction128> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return new Quaternion<Fraction128>(
        -quaternion.X,
        -quaternion.Y,
        -quaternion.Z,
        quaternion.W);
    }

    /// <summary>Adds two quaternions together.</summary>
    /// <param name="left">The first quaternion of the addition.</param>
    /// <param name="right">The second quaternion of the addition.</param>
    /// <returns>The result of the addition.</returns>
    public static Quaternion<Fraction128> Add(Quaternion<Fraction128> left, Quaternion<Fraction128> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<Fraction128>(
        left.X + right.X,
        left.Y + right.Y,
        left.Z + right.Z,
        left.W + right.W);
    }

    /// <summary>Subtracts two quaternions.</summary>
    /// <param name="left">The left quaternion of the subtraction.</param>
    /// <param name="right">The right quaternion of the subtraction.</param>
    /// <returns>The resulting quaternion after the subtraction.</returns>
    public static Quaternion<Fraction128> Subtract(Quaternion<Fraction128> left, Quaternion<Fraction128> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<Fraction128>(
        left.X - right.X,
        left.Y - right.Y,
        left.Z - right.Z,
        left.W - right.W);
    }

    /// <summary>Multiplies two quaternions together.</summary>
    /// <param name="left">The first quaternion of the multiplication.</param>
    /// <param name="right">The second quaternion of the multiplication.</param>
    /// <returns>The resulting quaternion after the multiplication.</returns>
    public static Quaternion<Fraction128> Multiply(Quaternion<Fraction128> left, Quaternion<Fraction128> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<Fraction128>(
        left.X * right.W + left.W * right.X + left.Y * right.Z - left.Z * right.Y,
        left.Y * right.W + left.W * right.Y + left.Z * right.X - left.X * right.Z,
        left.Z * right.W + left.W * right.Z + left.X * right.Y - left.Y * right.X,
        left.W * right.W - left.X * right.X - left.Y * right.Y - left.Z * right.Z);
    }

    /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
    /// <param name="left">The quaternion of the multiplication.</param>
    /// <param name="right">The scalar of the multiplication.</param>
    /// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
    public static Quaternion<Fraction128> Multiply(Quaternion<Fraction128> left, Fraction128 right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      return new Quaternion<Fraction128>(
        left.X * right,
        left.Y * right,
        left.Z * right,
        left.W * right);
    }

    /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
    /// <param name="left">The quaternion to pre-multiply the vector by.</param>
    /// <param name="right">The vector to be multiplied.</param>
    /// <returns>The resulting quaternion of the multiplication.</returns>
    public static Quaternion<Fraction128> Multiply(Quaternion<Fraction128> left, Vector<Fraction128> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (right.Dimensions != 3)
        throw new Error("my quaternion rotations are only defined for 3-component vectors.");
#endif

      return new Quaternion<Fraction128>(
        left.W * right.X + left.Y * right.Z - left.Z * right.Y,
        left.W * right.Y + left.Z * right.X - left.X * right.Z,
        left.W * right.Z + left.X * right.Y - left.Y * right.X,
        -left.X * right.X - left.Y * right.Y - left.Z * right.Z);
    }

    /// <summary>Normalizes the quaternion.</summary>
    /// <param name="quaternion">The quaternion to normalize.</param>
    /// <returns>The normalization of the given quaternion.</returns>
    public static Quaternion<Fraction128> Normalize(Quaternion<Fraction128> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      Fraction128 normalizer = Quaternion<Fraction128>.Magnitude(quaternion);
      if (normalizer != 0)
        return quaternion * (1 / normalizer);
      else
        return Quaternion<Fraction128>.FactoryIdentity;
    }

    /// <summary>Inverts a quaternion.</summary>
    /// <param name="quaternion">The quaternion to find the inverse of.</param>
    /// <returns>The inverse of the given quaternion.</returns>
    public static Quaternion<Fraction128> Invert(Quaternion<Fraction128> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      Fraction128 normalizer = Quaternion<Fraction128>.MagnitudeSquared(quaternion);
      if (normalizer == 0)
        return new Quaternion<Fraction128>(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
      normalizer = 1 / normalizer;
      return new Quaternion<Fraction128>(
        -quaternion.X * normalizer,
        -quaternion.Y * normalizer,
        -quaternion.Z * normalizer,
        quaternion.W * normalizer);
    }

    /// <summary>Lenearly interpolates between two quaternions.</summary>
    /// <param name="left">The starting point of the interpolation.</param>
    /// <param name="right">The ending point of the interpolation.</param>
    /// <param name="blend">The ratio 0.0-1.0 of how far to interpolate between the left and right quaternions.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Quaternion<Fraction128> Lerp(Quaternion<Fraction128> left, Quaternion<Fraction128> right, Fraction128 blend)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      if (blend < 0 || blend > 1)
        throw new Error("invalid blending value during lerp !(blend < 0.0f || blend > 1.0f).");
      if (Quaternion<Fraction128>.MagnitudeSquared(left) == 0)
      {
        if (Quaternion<Fraction128>.MagnitudeSquared(right) == 0)
          return Quaternion<Fraction128>.FactoryIdentity;
        else
          return new Quaternion<Fraction128>(right.X, right.Y, right.Z, right.W);
      }
      else if (Quaternion<Fraction128>.MagnitudeSquared(right) == 0)
        return new Quaternion<Fraction128>(left.X, left.Y, left.Z, left.W);
      Quaternion<Fraction128> result = new Quaternion<Fraction128>(
        1 - blend * left.X + blend * right.X,
        1 - blend * left.Y + blend * right.Y,
        1 - blend * left.Z + blend * right.Z,
        1 - blend * left.W + blend * right.W);
      if (Quaternion<Fraction128>.MagnitudeSquared(result) > 0)
        return Quaternion<Fraction128>.Normalize(result);
      else
        return Quaternion<Fraction128>.FactoryIdentity;
    }

    /// <summary>Sphereically interpolates between two quaternions.</summary>
    /// <param name="left">The starting point of the interpolation.</param>
    /// <param name="right">The ending point of the interpolation.</param>
    /// <param name="blend">The ratio of how far to interpolate between the left and right quaternions.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Quaternion<Fraction128> Slerp(Quaternion<Fraction128> left, Quaternion<Fraction128> right, Fraction128 blend)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      if (blend < 0 || blend > 1)
        throw new Error("invalid blending value during slerp !(blend < 0.0f || blend > 1.0f).");
      if (LinearAlgebra.MagnitudeSquared(left) == 0)
      {
        if (LinearAlgebra.MagnitudeSquared(right) == 0)
          return Quaternion<Fraction128>.FactoryIdentity;
        else
          return new Quaternion<Fraction128>(right.X, right.Y, right.Z, right.W);
      }
      else if (LinearAlgebra.MagnitudeSquared(right) == 0)
        return new Quaternion<Fraction128>(left.X, left.Y, left.Z, left.W);
      Fraction128 cosHalfAngle = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
      if (cosHalfAngle >= 1 || cosHalfAngle <= -1)
        return new Quaternion<Fraction128>(left.X, left.Y, left.Z, left.W);
      else if (cosHalfAngle < 0)
      {
        right = new Quaternion<Fraction128>(-left.X, -left.Y, -left.Z, -left.W);
        cosHalfAngle = -cosHalfAngle;
      }
      Fraction128 halfAngle = Trigonometry.arccos(cosHalfAngle);
      Fraction128 sinHalfAngle = Trigonometry.sin(halfAngle);
      Fraction128 blendA = Trigonometry.sin(halfAngle * (1 - blend)) / sinHalfAngle;
      Fraction128 blendB = Trigonometry.sin(halfAngle * blend) / sinHalfAngle;
      Quaternion<Fraction128> result = new Quaternion<Fraction128>(
        blendA * left.X + blendB * right.X,
        blendA * left.Y + blendB * right.Y,
        blendA * left.Z + blendB * right.Z,
        blendA * left.W + blendB * right.W);
      if (LinearAlgebra.MagnitudeSquared(result) > 0)
        return LinearAlgebra.Normalize(result);
      else
        return Quaternion<Fraction128>.FactoryIdentity;
    }

    /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
    /// <param name="rotation">The quaternion to rotate the vector by.</param>
    /// <param name="vector">The vector to be rotated by.</param>
    /// <returns>The result of the rotation.</returns>
    public static Vector<Fraction128> Rotate(Quaternion<Fraction128> rotation, Vector<Fraction128> vector)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(rotation, null))
        throw new Error("null reference: rotation");
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      if (vector.Dimensions != 3 && vector.Dimensions != 4)
        throw new Error("my quaternion rotations are only defined for 3-component vectors.");
      Quaternion<Fraction128> answer = LinearAlgebra.Multiply(LinearAlgebra.Multiply(rotation, vector), LinearAlgebra.Conjugate(rotation));
      return new Vector<Fraction128>(answer.X, answer.Y, answer.Z);
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first quaternion to check for equality.</param>
    /// <param name="right">The second quaternion  to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Quaternion<Fraction128> left, Quaternion<Fraction128> right)
    {
      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      return
        left.X == right.X &&
        left.Y == right.Y &&
        left.Z == right.Z &&
        left.W == right.W;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first quaternion to check for equality.</param>
    /// <param name="right">The second quaternion to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Quaternion<Fraction128> left, Quaternion<Fraction128> right, Fraction128 leniency)
    {
      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      return
        Logic.Abs(left.X - right.X) < leniency &&
        Logic.Abs(left.Y - right.Y) < leniency &&
        Logic.Abs(left.Z - right.Z) < leniency &&
        Logic.Abs(left.W - right.W) < leniency;
    }

    #endregion

    #region tableau

    //const Fraction128 epsilon = 1.0e-8;
    ////int equal(Fraction128 a, Fraction128 b) { return fabs(a - b) < epsilon; }

    //static void pivot_on(ref Fraction128[,] tableau, int row, int col)
    //{
    //  int i, j;
    //  Fraction128 pivot;

    //  pivot = tableau[row, col];
    //  if (!(pivot > 0))
    //    throw new Error("possible invalid tableau values (IDK)");
    //  for (j = 0; j < tableau.GetLength(1); j++)
    //    tableau[row, j] /= pivot;
    //  if (!(Logic.Equate(tableau[row, col], 1, epsilon)))
    //    throw new Error("possible invalid tableau values (IDK)");

    //  for (i = 0; i < tableau.GetLength(0); i++)
    //  { // foreach remaining row i do
    //    Fraction128 multiplier = tableau[i, col];
    //    if (i == row) continue;
    //    for (j = 0; j < tableau.GetLength(1); j++)
    //    { // r[i] = r[i] - z * r[row];
    //      tableau[i, j] -= multiplier * tableau[row, j];
    //    }
    //  }
    //}

    //// Find pivot_col = most negative column in mat[0][1..n]
    //static int find_pivot_column(ref Fraction128[,] tableau)
    //{
    //  int j, pivot_col = 1;
    //  Fraction128 lowest = tableau[0, pivot_col];
    //  for (j = 1; j < tableau.GetLength(1); j++)
    //  {
    //    if (tableau[0, j] < lowest)
    //    {
    //      lowest = tableau[0, j];
    //      pivot_col = j;
    //    }
    //  }
    //  //printf("Most negative column in row[0] is col %d = %g.\n", pivot_col, lowest);
    //  if (lowest >= 0)
    //  {
    //    return -1; // All positive columns in row[0], this is optimal.
    //  }
    //  return pivot_col;
    //}

    //// Find the pivot_row, with smallest positive ratio = col[0] / col[pivot]
    //static int find_pivot_row(ref Fraction128[,] tableau, int pivot_col)
    //{
    //  int i, pivot_row = 0;
    //  Fraction128 min_ratio = -1;
    //  //printf("Ratios A[row_i,0]/A[row_i,%d] = [", pivot_col);
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    Fraction128 ratio = tableau[i, 0] / tableau[i, pivot_col];
    //    //printf("%3.2lf, ", ratio);
    //    if ((ratio > 0 && ratio < min_ratio) || min_ratio < 0)
    //    {
    //      min_ratio = ratio;
    //      pivot_row = i;
    //    }
    //  }
    //  //printf("].\n");
    //  if (min_ratio == -1)
    //    return -1; // Unbounded.
    //  //printf("Found pivot A[%d,%d], min positive ratio=%g in row=%d.\n",
    //  //  pivot_row, pivot_col, min_ratio, pivot_row);
    //  return pivot_row;
    //}

    //static void add_slack_variables(ref Fraction128[,] tableau)
    //{

    //  Fraction128[,] newTableau =
    //    new Fraction128[tableau.GetLength(0), tableau.GetLength(1) + tableau.GetLength(0) - 1];

    //  for (int a = 0, a_max = tableau.GetLength(0); a < a_max; a++)
    //    for (int b = 0, b_max = tableau.GetLength(1); b < b_max; b++)
    //      newTableau[a, b] = tableau[a, b];

    //  int i, j;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    for (j = 1; j < tableau.GetLength(0); j++)
    //      newTableau[i, j + tableau.GetLength(1) - 1] = (i == j ? 1d : 0d);
    //  }

    //  tableau = newTableau;
    //}

    //static void check_b_positive(ref Fraction128[,] tableau)
    //{
    //  int i;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //    if (!(tableau[i, 0] >= 0))
    //      throw new Error("possible invalid tableau values (IDK)");
    //}

    //// Given a column of identity matrix, find the row containing 1.
    //// return -1, if the column as not from an identity matrix.
    //static int find_basis_variable(ref Fraction128[,] tableau, int col)
    //{
    //  int i, xi = -1;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    if (Logic.Equate(tableau[i, col], 1, epsilon))
    //      if (xi == -1)
    //        xi = i;   // found first '1', save this row number.
    //      else
    //        return -1; // found second '1', not an identity matrix.
    //    else if (!Logic.Equate(tableau[i, col], 0, epsilon))
    //      return -1; // not an identity matrix column.
    //  }
    //  return xi;
    //}

    //static Fraction128[] print_optimal_vector(ref Fraction128[,] tableau)
    //{
    //  Fraction128[] vector = new Fraction128[tableau.GetLength(1)];
    //  int j, xi;
    //  //printf("%s at ", message);
    //  for (j = 1; j < tableau.GetLength(1); j++)
    //  { // for each column.
    //    xi = find_basis_variable(ref tableau, j);
    //    if (xi != -1)
    //      vector[j] = tableau[xi, 0];
    //    else
    //      vector[j] = j;
    //  }
    //  return vector;
    //}

    //public static Fraction128[] Simplex(ref Fraction128[,] tableau)
    //{
    //  int loop = 0;
    //  add_slack_variables(ref tableau);
    //  check_b_positive(ref tableau);
    //  while (++loop > 0)
    //  {
    //    int pivot_col, pivot_row;

    //    pivot_col = find_pivot_column(ref tableau);
    //    if (pivot_col < 0)
    //      //printf("Found optimal value=A[0,0]=%3.2lf (no negatives in row 0).\n",
    //      //  tableau->mat[0][0]);
    //      return print_optimal_vector(ref tableau);
    //    //printf("Entering variable x%d to be made basic, so pivot_col=%d.\n",
    //    //  pivot_col, pivot_col);

    //    pivot_row = find_pivot_row(ref tableau, pivot_col);
    //    if (pivot_row < 0)
    //      throw new Error("unbounded (no pivot_row)");
    //    //printf("Leaving variable x%d, so pivot_row=%d\n", pivot_row, pivot_row);

    //    pivot_on(ref tableau, pivot_row, pivot_col);
    //    //print_tableau(tableau, "After pivoting");
    //    //return print_optimal_vector(ref tableau);
    //  }
    //  throw new Error("Simplex has a glitch");
    //}

    #endregion

    #endregion

    #region Fraction64

    #region vector

    /// <summary>Adds two vectors together.</summary>
    /// <param name="left">The first vector of the addition.</param>
    /// <param name="right">The second vector of the addiiton.</param>
    /// <returns>The result of the addiion.</returns>
    public static Vector<Fraction64> Add(Vector<Fraction64> left, Vector<Fraction64> right)
    {
      #region pre-optimization

      //Vector<Fraction64> result =
      //  new Vector<Fraction64>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] + right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector addition.");
#endif

      int length = left.Dimensions;
      Vector<Fraction64> result =
        new Vector<Fraction64>(left.Dimensions);

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
      }
#else
      Fraction64[] left_flat = left._vector;
      Fraction64[] right_flat = right._vector;
      Fraction64[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
#endif

      return result;
    }

    /// <summary>Negates all the values in a vector.</summary>
    /// <param name="vector">The vector to have its values negated.</param>
    /// <returns>The result of the negations.</returns>
    public static Vector<Fraction64> Negate(Vector<Fraction64> vector)
    {
      #region pre-optimization

      //Vector<Fraction64> result =
      //  new Vector<Fraction64>(vector.Dimensions);
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result[i] = -vector[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Vector<Fraction64> result =
        new Vector<Fraction64>(length);

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = -vector_flat[i];
      }
#else
      Fraction64[] vector_flat = vector._vector;
      Fraction64[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = -vector_flat[i];
#endif

      return result;
    }

    /// <summary>Subtracts two vectors.</summary>
    /// <param name="left">The left vector of the subtraction.</param>
    /// <param name="right">The right vector of the subtraction.</param>
    /// <returns>The result of the vector subtracton.</returns>
    public static Vector<Fraction64> Subtract(Vector<Fraction64> left, Vector<Fraction64> right)
    {
      #region pre-optimization

      //Vector<Fraction64> result =
      //  new Vector<Fraction64>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] - right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector subtraction.");
#endif

      int length = left.Dimensions;
      Vector<Fraction64> result =
        new Vector<Fraction64>(length);

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] - right_flat[i];
      }
#else
      Fraction64[] left_flat = left._vector;
      Fraction64[] right_flat = right._vector;
      Fraction64[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] - right_flat[i];
#endif

      return result;
    }

    /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
    /// <param name="left">The vector to have the components multiplied by.</param>
    /// <param name="right">The scalars to multiply the vector components by.</param>
    /// <returns>The result of the multiplications.</returns>
    public static Vector<Fraction64> Multiply(Vector<Fraction64> left, Fraction64 right)
    {
      #region pre-optimization

      //Vector<Fraction64> result =
      //  new Vector<Fraction64>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] * right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      int length = left.Dimensions;
      Vector<Fraction64> result =
        new Vector<Fraction64>(length);

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          left_flat = left._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] * right;
      }
#else
      Fraction64[] left_flat = left._vector;
      Fraction64[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] * right;
#endif

      return result;
    }

    /// <summary>Divides all the components of a vector by a scalar.</summary>
    /// <param name="vector">The vector to have the components divided by.</param>
    /// <param name="right">The scalar to divide the vector components by.</param>
    /// <returns>The resulting vector after teh divisions.</returns>
    public static Vector<Fraction64> Divide(Vector<Fraction64> vector, Fraction64 right)
    {
      #region pre-optimization

      //Vector<Fraction64> result =
      //  new Vector<Fraction64>(vector.Dimensions);
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result[i] = vector[i] / right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: left");
#endif

      int length = vector.Dimensions;
      Vector<Fraction64> result =
        new Vector<Fraction64>(length);

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = vector_flat[i] / right;
      }
#else
      Fraction64[] vector_flat = vector._vector;
      Fraction64[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = vector_flat[i] / right;
#endif

      return result;
    }

    /// <summary>Computes the dot product between two vectors.</summary>
    /// <param name="left">The first vector of the dot product operation.</param>
    /// <param name="right">The second vector of the dot product operation.</param>
    /// <returns>The result of the dot product operation.</returns>
    public static Fraction64 DotProduct(Vector<Fraction64> left, Vector<Fraction64> right)
    {
      #region pre-optimization

      //Fraction64 result = 0;
      //for (int i = 0; i < left.Dimensions; i++)
      //  result += left[i] * right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector dot product.");
#endif

      int length = left.Dimensions;
      Fraction64 result = 0;

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          left_flat = left._vector,
          right_flat = right._vector)
          for (int i = 0; i < length; i++)
            result += left_flat[i] * right_flat[i];
      }
#else
      Fraction64[] left_flat = left._vector;
      Fraction64[] right_flat = right._vector;
      for (int i = 0; i < length; i++)
        result += left_flat[i] * right_flat[i];
#endif

      return result;
    }

    /// <summary>Computes teh cross product of two vectors.</summary>
    /// <param name="left">The first vector of the cross product operation.</param>
    /// <param name="right">The second vector of the cross product operation.</param>
    /// <returns>The result of the cross product operation.</returns>
    public static Vector<Fraction64> CrossProduct(Vector<Fraction64> left, Vector<Fraction64> right)
    {
      #region pre-optimization

      //Vector<Fraction64> result = new Vector<Fraction64>(3);
      //result[0] = left[1] * right[2] - left[2] * right[1];
      //result[1] = left[2] * right[0] - left[0] * right[2];
      //result[2] = left[0] * right[1] - left[1] * right[0];

      #endregion

#if no_error_checking

#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid cross product (left.Dimensions != right.Dimensions)");
      if (left.Dimensions != 3)
        throw new Error("my cross product function is only defined for 3-component vectors.");
#endif

      Vector<Fraction64> result =
        new Vector<Fraction64>(3);

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
        {
          result_flat[0] = left_flat[1] * right_flat[2] - left_flat[2] * right_flat[1];
          result_flat[1] = left_flat[2] * right_flat[0] - left_flat[0] * right_flat[2];
          result_flat[2] = left_flat[0] * right_flat[1] - left_flat[1] * right_flat[0];
        }
      }
#else
      Fraction64[] left_flat = left._vector;
      Fraction64[] right_flat = right._vector;
      Fraction64[] result_flat = result._vector;
      result_flat[0] = left_flat[1] * right_flat[2] - left_flat[2] * right_flat[1];
      result_flat[1] = left_flat[2] * right_flat[0] - left_flat[0] * right_flat[2];
      result_flat[2] = left_flat[0] * right_flat[1] - left_flat[1] * right_flat[0];
#endif

      return result;
    }

    /// <summary>Normalizes a vector.</summary>
    /// <param name="vector">The vector to normalize.</param>
    /// <returns>The result of the normalization.</returns>
    public static Vector<Fraction64> Normalize(Vector<Fraction64> vector)
    {
      #region pre-optimization

      //Fraction64 magnitude = LinearAlgebra.Magnitude(vector);
      //if (magnitude != 0)
      //{
      //  Vector<Fraction64> result = 
      //    new Vector<Fraction64>(vector.Dimensions);
      //  for (int i = 0; i < vector.Dimensions; i++)
      //    result[i] = vector[i] / magnitude;
      //  return result;
      //}
      //else
      //  return new Fraction64[vector.Dimensions];

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Vector<Fraction64> result =
        new Vector<Fraction64>(vector.Dimensions);
      Fraction64 magnitude = LinearAlgebra.Magnitude(vector);
      if (magnitude != 0)
        return result;

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = vector_flat[i] / magnitude;
      }
#else
      Fraction64[] vector_flat = vector._vector;
      Fraction64[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = vector_flat[i] / magnitude;
#endif

      return result;

    }

    /// <summary>Computes the length of a vector.</summary>
    /// <param name="vector">The vector to calculate the length of.</param>
    /// <returns>The computed length of the vector.</returns>
    public static Fraction64 Magnitude(Vector<Fraction64> vector)
    {
      #region pre-optimization

      //Fraction64 result = 0;
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result += vector[i] * vector[i];
      //return Algebra.sqrt(result);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Fraction64 result = 0;

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          vector_flat = vector._vector)
          for (int i = 0; i < length; i++)
            result += vector_flat[i] * vector_flat[i];
      }
#else
      Fraction64[] vector_flat = vector._vector;
      for (int i = 0; i < length; i++)
        result += vector_flat[i] * vector_flat[i];
#endif

      return Algebra.sqrt(result);
    }

    /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
    /// <param name="vector">The vector to compute the length squared of.</param>
    /// <returns>The computed length squared of the vector.</returns>
    public static Fraction64 MagnitudeSquared(Vector<Fraction64> vector)
    {
      #region pre-optimization

      //Fraction64 result = 0;
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result += vector[i] * vector[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Fraction64 result = 0;

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          vector_flat = vector._vector)
          for (int i = 0; i < length; i++)
            result += vector_flat[i] * vector_flat[i];
      }
#else
      Fraction64[] vector_flat = vector._vector;
      for (int i = 0; i < length; i++)
        result += vector_flat[i] * vector_flat[i];
#endif

      return result;
    }

    /// <summary>Computes the angle between two vectors.</summary>
    /// <param name="first">The first vector to determine the angle between.</param>
    /// <param name="second">The second vector to determine the angle between.</param>
    /// <returns>The angle between the two vectors in radians.</returns>
    public static Fraction64 Angle(Vector<Fraction64> first, Vector<Fraction64> second)
    {
      #region pre-optimization

      //return Trigonometry.arccos(
      //  LinearAlgebra.DotProduct(first, second) / 
      //  (LinearAlgebra.Magnitude(first) * 
      //  LinearAlgebra.Magnitude(second)));

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(first, null))
        throw new Error("null reference: first");
      if (object.ReferenceEquals(second, null))
        throw new Error("null reference: second");
#endif

      return Trigonometry.arccos(
        LinearAlgebra.DotProduct(first, second) /
        (LinearAlgebra.Magnitude(first) *
        LinearAlgebra.Magnitude(second)));
    }

    /// <summary>Rotates a 3-component vector by the specified axis and rotation values.</summary>
    /// <param name="vector">The vector to rotate.</param>
    /// <param name="angle">The angle of the rotation in radians.</param>
    /// <param name="x">The x component of the axis vector to rotate about.</param>
    /// <param name="y">The y component of the axis vector to rotate about.</param>
    /// <param name="z">The z component of the axis vector to rotate about.</param>
    /// <returns>The result of the rotation.</returns>
    public static Vector<Fraction64> RotateBy(Vector<Fraction64> vector, Fraction64 angle, Fraction64 x, Fraction64 y, Fraction64 z)
    {
      #region pre-optimization

      //Fraction64 sinHalfAngle = Trigonometry.sin(angle / 2);
      //Fraction64 cosHalfAngle = Trigonometry.cos(angle / 2);
      //x *= sinHalfAngle;
      //y *= sinHalfAngle;
      //z *= sinHalfAngle;
      //Fraction64 x2 = cosHalfAngle * vector[0] + y * vector[2] - z * vector[1];
      //Fraction64 y2 = cosHalfAngle * vector[1] + z * vector[0] - x * vector[2];
      //Fraction64 z2 = cosHalfAngle * vector[2] + x * vector[1] - y * vector[0];
      //Fraction64 w2 = -x * vector[0] - y * vector[1] - z * vector[2];
      //Vector<Fraction64> result = new Vector<Fraction64>();
      //result[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
      //result[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
      //result[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
      if (vector.Dimensions == 3)
        throw new Error("my RotateBy() function is only defined for 3-component vectors.");
#endif

      Vector<Fraction64> result = new Vector<Fraction64>(3);
      Fraction64 sinHalfAngle = Trigonometry.sin(angle / 2);
      Fraction64 cosHalfAngle = Trigonometry.cos(angle / 2);
      x *= sinHalfAngle;
      y *= sinHalfAngle;
      z *= sinHalfAngle;

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          vector_flat = vector._vector,
          result_flat = result._vector)
        {
          Fraction64 x2 = cosHalfAngle * vector_flat[0] + y * vector_flat[2] - z * vector_flat[1];
          Fraction64 y2 = cosHalfAngle * vector_flat[1] + z * vector_flat[0] - x * vector_flat[2];
          Fraction64 z2 = cosHalfAngle * vector_flat[2] + x * vector_flat[1] - y * vector_flat[0];
          Fraction64 w2 = -x * vector_flat[0] - y * vector_flat[1] - z * vector_flat[2];
          result_flat[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
          result_flat[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
          result_flat[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;
        }
      }
#else
      Fraction64[] vector_flat = vector._vector;
      Fraction64[] result_flat = result._vector;
      Fraction64 x2 = cosHalfAngle * vector_flat[0] + y * vector_flat[2] - z * vector_flat[1];
      Fraction64 y2 = cosHalfAngle * vector_flat[1] + z * vector_flat[0] - x * vector_flat[2];
      Fraction64 z2 = cosHalfAngle * vector_flat[2] + x * vector_flat[1] - y * vector_flat[0];
      Fraction64 w2 = -x * vector_flat[0] - y * vector_flat[1] - z * vector_flat[2];
      result_flat[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
      result_flat[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
      result_flat[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;
#endif

      return result;
    }

    /// <summary>Rotates a vector by a quaternion rotation.</summary>
    /// <param name="vector">The vector to be rotated.</param>
    /// <param name="quaternion">The rotation to be applied.</param>
    /// <returns>The vector after the rotation.</returns>
    public static Vector<Fraction64> RotateBy(Vector<Fraction64> vector, Quaternion<Fraction64> quaternion)
    {
      return Rotate(quaternion, vector);
    }

    /// <summary>Computes the linear interpolation between two vectors.</summary>
    /// <param name="left">The starting vector of the interpolation.</param>
    /// <param name="right">The ending vector of the interpolation.</param>
    /// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Vector<Fraction64> Lerp(Vector<Fraction64> left, Vector<Fraction64> right, Fraction64 blend)
    {
      #region pre-optimization

      //Vector<Fraction64> result = new Vector<Fraction64>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] + blend * (right[i] - left[i]);
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (blend < 0 || blend > 1)
        throw new Error("invalid vector lerp blend value: (blend < 0.0f || blend > 1.0f).");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid vector lerp length: (left.Dimensions != right.Dimensions)");
#endif

      int length = left.Dimensions;
      Vector<Fraction64> result =
        new Vector<Fraction64>(length);

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + blend * (right_flat[i] - left_flat[i]);
      }
#else
      Fraction64[] left_flat = left._vector;
      Fraction64[] right_flat = right._vector;
      Fraction64[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] + blend * (right_flat[i] - left_flat[i]);
#endif

      return result;
    }

    /// <summary>Sphereically interpolates between two vectors.</summary>
    /// <param name="left">The starting vector of the interpolation.</param>
    /// <param name="right">The ending vector of the interpolation.</param>
    /// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
    /// <returns>The result of the slerp operation.</returns>
    public static Vector<Fraction64> Slerp(Vector<Fraction64> left, Vector<Fraction64> right, Fraction64 blend)
    {
      #region pre-optimization

      //Fraction64 dot = LinearAlgebra.DotProduct(left, right);
      //dot = dot < -1 ? -1 : dot;
      //dot = dot > 1 ? 1 : dot;
      //Fraction64 theta = Trigonometry.arccos(dot) * blend;
      //return LinearAlgebra.Multiply(LinearAlgebra.Add(LinearAlgebra.Multiply(left, Trigonometry.cos(theta)),
      //  LinearAlgebra.Normalize(LinearAlgebra.Subtract(right, LinearAlgebra.Multiply(left, dot)))), Trigonometry.sin(theta));

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (blend < 0 || blend > 1)
        throw new Error("invalid slerp blend value: (blend < 0.0f || blend > 1.0f).");
#endif

      Fraction64 dot = LinearAlgebra.DotProduct(left, right);
      dot = dot < -1 ? -1 : dot;
      dot = dot > 1 ? 1 : dot;
      Fraction64 theta = Trigonometry.arccos(dot) * blend;
      return LinearAlgebra.Multiply(LinearAlgebra.Add(LinearAlgebra.Multiply(left, Trigonometry.cos(theta)),
        LinearAlgebra.Normalize(LinearAlgebra.Subtract(right, LinearAlgebra.Multiply(left, dot)))), Trigonometry.sin(theta));
    }

    /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
    /// <param name="a">The first vector of the interpolation.</param>
    /// <param name="b">The second vector of the interpolation.</param>
    /// <param name="c">The thrid vector of the interpolation.</param>
    /// <param name="u">The "U" value of the barycentric interpolation equation.</param>
    /// <param name="v">The "V" value of the barycentric interpolation equation.</param>
    /// <returns>The resulting vector of the barycentric interpolation.</returns>
    public static Vector<Fraction64> Blerp(Vector<Fraction64> a, Vector<Fraction64> b, Vector<Fraction64> c, Fraction64 u, Fraction64 v)
    {
      #region pre-optimization

      //return 
      //  LinearAlgebra.Add(
      //    LinearAlgebra.Add(
      //      LinearAlgebra.Multiply(
      //        LinearAlgebra.Subtract(b, a), u),
      //          LinearAlgebra.Multiply(
      //            LinearAlgebra.Subtract(c, a), v)), a);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(a, null))
        throw new Error("null reference: a");
      if (object.ReferenceEquals(b, null))
        throw new Error("null reference: b");
      if (object.ReferenceEquals(c, null))
        throw new Error("null reference: c");
#endif

      return
        LinearAlgebra.Add(
          LinearAlgebra.Add(
            LinearAlgebra.Multiply(
              LinearAlgebra.Subtract(b, a), u),
                LinearAlgebra.Multiply(
                  LinearAlgebra.Subtract(c, a), v)), a);
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Vector<Fraction64> left, Vector<Fraction64> right)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;

      //if (left.Dimensions != right.Dimensions)
      //  return false;
      //for (int i = 0; i < left.Dimensions; i++)
      //  if (left[i] != right[i])
      //    return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Dimensions != right.Dimensions)
        return false;
      for (int i = 0; i < left.Dimensions; i++)
        if (left[i] != right[i])
          return false;
      return true;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Vector<Fraction64> left, Vector<Fraction64> right, Fraction64 leniency)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;

      //if (left.Dimensions != right.Dimensions)
      //  return false;
      //for (int i = 0; i < left.Dimensions; i++)
      //  if (Logic.Abs(left[i] - right[i]) > leniency)
      //    return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Dimensions != right.Dimensions)
        return false;
      for (int i = 0; i < left.Dimensions; i++)
        if (Logic.Abs(left[i] - right[i]) > leniency)
          return false;
      return true;
    }

    #endregion

    #region matrix

    /// <summary>Determines if a matrix is symetric or not.</summary>
    /// <param name="matrix">The matrix to determine symetry of.</param>
    /// <returns>True if symetric; false if not.</returns>
    public static bool IsSymmetric(Matrix<Fraction64> matrix)
    {
      #region pre-optimization

      //if (matrix.Rows != matrix.Columns)
      //  return false;
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    if (matrix[i, j] != matrix[j, i])
      //      return false;
      //return true;

      #endregion

#if no_errorchecking
      //nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        return false;
#endif
      int size = matrix.Columns;
#if unsafe_code
      unsafe
      {
        fixed (Fraction64* matrix_flat = matrix._matrix)
          for (var row = 0; row < size; row++)
            for (var column = row + 1; column < size; column++)
              if (matrix_flat[row * size + column] != matrix_flat[column * size + row])
                return false;
      }
#else
      Fraction64[] matrix_flat = matrix._matrix;
      for (var row = 0; row < size; row++)
        for (var column = row + 1; column < size; column++)
          if (matrix_flat[row * size + column] != matrix_flat[column * size + row])
            return false;
#endif
      return true;
    }

    /// <summary>Constructs a new identity-matrix of the given dimensions.</summary>
    /// <param name="rows">The number of rows of the matrix.</param>
    /// <param name="columns">The number of columns of the matrix.</param>
    /// <returns>The newly constructed identity-matrix.</returns>
    public static Matrix<Fraction64> MatrixFactoryIdentity_Fraction64(int rows, int columns)
    {
      #region pre-optimization

      //Matrix<Fraction64> matrix = 
      //  new Matrix<Fraction64>(rows, columns);
      //for (int i = 0; i < Logic.Min(rows, columns); i++)
      //  matrix[i, i] = 1;
      //return matrix;

      #endregion

#if no_error_checking
      //nothing
#else
      if (rows < 1)
        throw new Error("invalid row count on matrix creation");
      if (columns < 1)
        throw new Error("invalid column count on matrix creation");
#endif

      Matrix<Fraction64> matrix = new Matrix<Fraction64>(rows, columns);
      if (rows <= columns)
        for (int i = 0; i < rows; i++)
          matrix[i, i] = 1;
      else
        for (int i = 0; i < columns; i++)
          matrix[i, i] = 1;
      return matrix;
    }

    /// <summary>Negates all the values in a matrix.</summary>
    /// <param name="matrix">The matrix to have its values negated.</param>
    /// <returns>The resulting matrix after the negations.</returns>
    public static Matrix<Fraction64> Negate(Matrix<Fraction64> matrix)
    {
      #region pre-optimization

      //Matrix<Fraction64> result =
      //  new Matrix<Fraction64>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Rows; j++)
      //    result[i, j] = -matrix[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
        if (object.ReferenceEquals(matrix, null))
          throw new Error("null reference: matirx");
#endif

      Matrix<Fraction64> result =
        new Matrix<Fraction64>(matrix.Rows, matrix.Columns);
      int size = matrix.Rows * matrix.Columns;

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          result_flat = result._matrix,
          matrix_flat = matrix._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = -matrix_flat[i];
        return result;
      }
#else
      Fraction64[] result_flat = result._matrix;
      Fraction64[] matrix_flat = matrix._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = -matrix_flat[i];
      return result;
#endif
    }

    /// <summary>Negates all the values in a matrix.</summary>
    /// <param name="matrix">The matrix to have its values negated.</param>
    /// <returns>The resulting matrix after the negations.</returns>
    public static Matrix<Fraction64> Negate_parallel(Matrix<Fraction64> matrix)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matirx");
#endif

      if (matrix.Rows * matrix.Columns > _parallelMinimum)
      {
        Matrix<Fraction64> result =
        new Matrix<Fraction64>(matrix.Rows, matrix.Columns);
        int size = matrix.Rows * matrix.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (Fraction64*
                  result_flat = result._matrix,
                  matrix_flat = matrix._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = -matrix_flat[i];
              };
            }, Logic.Max(matrix.Rows, matrix.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                Fraction64[] matrix_flat = matrix._matrix;
                Fraction64[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = -matrix_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Negate(matrix);
    }

    /// <summary>Does standard addition of two matrices.</summary>
    /// <param name="left">The left matrix of the addition.</param>
    /// <param name="right">The right matrix of the addition.</param>
    /// <returns>The resulting matrix after the addition.</returns>
    public static Matrix<Fraction64> Add(Matrix<Fraction64> left, Matrix<Fraction64> right)
    {
      #region pre-optimization

      //Matrix<Fraction64> result =
      //  new Matrix<Fraction64>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] + right[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
          throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix addition (dimension miss-match).");
#endif

      Matrix<Fraction64> result =
        new Matrix<Fraction64>(left.Rows, left.Columns);
      int size = left.Rows * left.Columns;

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
      }
#else
      Fraction64[] left_flat = left._matrix;
      Fraction64[] right_flat = right._matrix;
      Fraction64[] result_flat = result._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = left_flat[i] + right_flat[i];
#endif

      return result;
    }

    /// <summary>Does standard addition of two matrices.</summary>
    /// <param name="left">The left matrix of the addition.</param>
    /// <param name="right">The right matrix of the addition.</param>
    /// <returns>The resulting matrix after the addition.</returns>
    public static Matrix<Fraction64> Add_parallel(Matrix<Fraction64> left, Matrix<Fraction64> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix addition (dimension miss-match).");
#endif

      if (left.Rows * left.Columns > _parallelMinimum)
      {
        Matrix<Fraction64> result =
        new Matrix<Fraction64>(left.Rows, left.Columns);
        int size = left.Rows * left.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (Fraction64*
                  left_flat = left._matrix,
                  right_flat = right._matrix,
                  result_flat = result._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = left_flat[i] + right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                Fraction64[] left_flat = left._matrix;
                Fraction64[] right_flat = right._matrix;
                Fraction64[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = left_flat[i] + right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Add(left, right);
    }

    /// <summary>Subtracts a scalar from all the values in a matrix.</summary>
    /// <param name="left">The matrix to have the values subtracted from.</param>
    /// <param name="right">The scalar to subtract from all the matrix values.</param>
    /// <returns>The resulting matrix after the subtractions.</returns>
    public static Matrix<Fraction64> Subtract(Matrix<Fraction64> left, Matrix<Fraction64> right)
    {
      #region pre-optimization

      //Matrix<Fraction64> result =
      //  new Matrix<Fraction64>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] - right[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix subtraction (dimension miss-match).");
#endif

      Matrix<Fraction64> result =
        new Matrix<Fraction64>(left.Rows, left.Columns);
      int size = left.Rows * left.Columns;

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = left_flat[i] - right_flat[i];
      }
#else
      Fraction64[] left_flat = left._matrix;
      Fraction64[] right_flat = right._matrix;
      Fraction64[] result_flat = result._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = left_flat[i] - right_flat[i];
#endif

      return result;
    }

    /// <summary>Subtracts a scalar from all the values in a matrix.</summary>
    /// <param name="left">The matrix to have the values subtracted from.</param>
    /// <param name="right">The scalar to subtract from all the matrix values.</param>
    /// <returns>The resulting matrix after the subtractions.</returns>
    public static Matrix<Fraction64> Subtract_parallel(Matrix<Fraction64> left, Matrix<Fraction64> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix subtraction (dimension miss-match).");
#endif

      if (left.Rows * left.Columns > _parallelMinimum)
      {
        Matrix<Fraction64> result =
        new Matrix<Fraction64>(left.Rows, left.Columns);
        int size = left.Rows * left.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (Fraction64*
                  left_flat = left._matrix,
                  right_flat = right._matrix,
                  result_flat = result._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = left_flat[i] - right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
          (int current, int max) =>
          {
            return () =>
            {
              Fraction64[] left_flat = left._matrix;
              Fraction64[] right_flat = right._matrix;
              Fraction64[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = left_flat[i] - right_flat[i];
            };
          }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Subtract(left, right);
    }

    /// <summary>Performs multiplication on two matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Matrix<Fraction64> Multiply(Matrix<Fraction64> left, Matrix<Fraction64> right)
    {
      #region pre-optimization

      //Matrix<Fraction64> result = 
      //  new Matrix<Fraction64>(left.Rows, right.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < right.Columns; j++)
      //    for (int k = 0; k < left.Columns; k++)
      //      result[i, j] += left[i, k] * right[k, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (left == null)
        throw new Error("null reference: left");
      if (right == null)
        throw new Error("null reference: right");
      if (left.Columns != right.Rows)
        throw new LinearAlgebra.Error("invalid multiplication (size miss-match).");
#endif

      Fraction64 sum;
      int result_rows = left.Rows;
      int left_cols = left.Columns;
      int result_cols = right.Columns;
      Matrix<Fraction64> result =
        new Matrix<Fraction64>(result_rows, result_cols);

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          result_flat = result._matrix,
          left_flat = left._matrix,
          right_flat = right._matrix)
          for (int i = 0; i < result_rows; i++)
            for (int j = 0; j < result_cols; j++)
            {
              sum = 0;
              for (int k = 0; k < left_cols; k++)
                sum += left_flat[i * left_cols + k] * right_flat[k * result_cols + j];
              result_flat[i * result_cols + j] = sum;
            }
      }
#else
      Fraction64[] result_flat = result._matrix;
      Fraction64[] left_flat = left._matrix;
      Fraction64[] right_flat = right._matrix;

      for (int i = 0; i < result_rows; i++)
        for (int j = 0; j < result_cols; j++)
        {
          sum = 0;
          for (int k = 0; k < left_cols; k++)
            sum += left_flat[i * left_cols + k] * right_flat[k * result_cols + j];
          result_flat[i * result_cols + j] = sum;
        }
#endif

      return result;
    }

    /// <summary>Performs multiplication on two matrices using multi-threading.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Matrix<Fraction64> Multiply_parrallel(Matrix<Fraction64> left, Matrix<Fraction64> right)
    {
#if no_error_checking
      // nothing
#else
      if (left == null)
        throw new Error("null reference: left");
      if (right == null)
        throw new Error("null reference: right");
      if (left.Columns != right.Rows)
        throw new LinearAlgebra.Error("invalid multiplication (dimension miss-match).");
#endif

      int result_rows = left.Rows;
      int left_cols = left.Columns;
      int result_cols = right.Columns;

      // If there are enough rows to warrant multi-threading,
      // then multithread the row for-loop.
      if (result_rows * result_cols > _parallelMinimum &&
        result_rows >= result_cols)
      {
        Matrix<Fraction64> result =
          new Matrix<Fraction64>(result_rows, result_cols);
#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                Fraction64 sum;
                int left_i_offest;
                int result_i_offset;

                fixed (Fraction64*
                  result_flat = result._matrix,
                  left_flat = left._matrix,
                  right_flat = right._matrix)
                  for (int i = current; i < result_rows; i += max)
                  {
                    left_i_offest = i * left_cols;
                    result_i_offset = i * result_cols;
                    for (int j = 0; j < result_cols; j++)
                    {
                      sum = 0;
                      for (int k = 0; k < left_cols; k++)
                        sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                      result_flat[result_i_offset + j] = sum;
                    }
                  }
              };
            }, result_rows);
        }
#else
              Fraction64[] result_flat = result._matrix;
              Fraction64[] left_flat = left._matrix;
              Fraction64[] right_flat = right._matrix;

              Seven.Parallels.AutoParallel.Divide(
                  (int current, int max) =>
                  {
                    return () =>
                    {
                      Fraction64 sum;
                      int left_i_offest;
                      int result_i_offset;

                      for (int i = current; i < result_rows; i += max)
                      {
                        left_i_offest = i * left_cols;
                        result_i_offset = i * result_cols;
                        for (int j = 0; j < result_cols; j++)
                        {
                          sum = 0;
                          for (int k = 0; k < left_cols; k++)
                            sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                          result_flat[result_i_offset + j] = sum;
                        }
                      }
                    };
                  }, result_rows);

#endif
        return result;
      }
      // If there are enough columns to warrant multi-threading,
      // then multithread the column for-loop.
      else if (result_rows * result_cols > _parallelMinimum &&
        result_rows < result_cols)
      {
        Matrix<Fraction64> result =
          new Matrix<Fraction64>(result_rows, result_cols);
#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                Fraction64 sum;
                int left_i_offest;
                int result_i_offset;

                fixed (Fraction64*
                  result_flat = result._matrix,
                  left_flat = left._matrix,
                  right_flat = right._matrix)
                  for (int i = 0; i < result_rows; i++)
                  {
                    left_i_offest = i * left_cols;
                    result_i_offset = i * result_cols;
                    for (int j = current; j < result_cols; j += max)
                    {
                      sum = 0;
                      for (int k = 0; k < left_cols; k++)
                        sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                      result_flat[result_i_offset + j] = sum;
                    }
                  }
              };
            }, result_cols);
        }
#else
              Fraction64[] result_flat = result._matrix;
              Fraction64[] left_flat = left._matrix;
              Fraction64[] right_flat = right._matrix;

              Seven.Parallels.AutoParallel.Divide(
                  (int current, int max) =>
                  {
                    return () =>
                    {
                      Fraction64 sum;
                      int left_i_offest;
                      int result_i_offset;

                      for (int i = 0; i < result_rows; i++)
                      {
                        left_i_offest = i * left_cols;
                        result_i_offset = i * result_cols;
                        for (int j = current; j < result_cols; j += max)
                        {
                          sum = 0;
                          for (int k = 0; k < left_cols; k++)
                            sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                          result_flat[result_i_offset + j] = sum;
                        }
                      }
                    };
                  }, result_cols);
#endif
        return result;
      }
      // Multi-threading is not necessary.
      else
        return LinearAlgebra.Multiply(left, right);
    }

    /// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Vector<Fraction64> Multiply(Matrix<Fraction64> left, Vector<Fraction64> right)
    {
      #region pre-optimization

      //Vector<Fraction64> result = 
      //  new Vector<Fraction64>(right.Dimensions);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i] += left[i, j] * right[j];
      //return result;

      #endregion

#if no_error_checking
      int left_row = left.Rows;
      int left_col = left.Columns;
#else
      int left_row = left.Rows;
      int left_col = left.Columns;
      if (left.Columns != right.Dimensions)
        throw new Error("invalid multiplication (size miss-match).");
#endif

      Vector<Fraction64> result = new Vector<Fraction64>(right.Dimensions);

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          left_flat = left._matrix,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < left_row; i++)
            for (int j = 0; j < left_col; j++)
              result_flat[i] += left_flat[i * left_col + j] * right_flat[j];
        return result;
      }
#else
      Fraction64[] left_flat = left._matrix;
      Fraction64[] right_flat = right._vector;
      Fraction64[] result_flat = result._vector;
      for (int i = 0; i < left_row; i++)
        for (int j = 0; j < left_col; j++)
          result_flat[i] += left_flat[i * left_col + j] * right_flat[j];
      return result;
#endif
      return result;
    }

    /// <summary>Multiplies all the values in a matrix by a scalar.</summary>
    /// <param name="left">The matrix to have the values multiplied.</param>
    /// <param name="right">The scalar to multiply the values by.</param>
    /// <returns>The resulting matrix after the multiplications.</returns>
    public static Matrix<Fraction64> Multiply(Matrix<Fraction64> left, Fraction64 right)
    {
      #region pre-optimization

      //Matrix<Fraction64> result = 
      //  new Matrix<Fraction64>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] * right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      int rows = left.Rows;
      int columns = left.Columns;
      Matrix<Fraction64> result = new Matrix<Fraction64>(rows, columns);

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          left_flat = left._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
              result_flat[i * columns + j] = left_flat[i * columns + j] * right;
      }
#else
      for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
          result[i, j] = left[i, j] * right;
#endif

      return result;
    }

    /// <summary>Applies a power to a square matrix.</summary>
    /// <param name="matrix">The matrix to be powered by.</param>
    /// <param name="power">The power to apply to the matrix.</param>
    /// <returns>The resulting matrix of the power operation.</returns>
    public static Matrix<Fraction64> Power(Matrix<Fraction64> matrix, int power)
    {
      #region pre-optimization

      //Matrix<Fraction64> result = matrix.Clone();
      //for (int i = 0; i < power; i++)
      //  result = LinearAlgebra.Multiply(result, result);
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (!(matrix.Rows == matrix.Columns))
        throw new Error("invalid power (!matrix.IsSquare).");
      if (!(power >= 0))
        throw new Error("invalid power !(power > -1)");
#endif
      // this is not optimized...
      if (power == 0)
        return LinearAlgebra.MatrixFactoryIdentity_Fraction64(matrix.Rows, matrix.Columns);
      Matrix<Fraction64> result = matrix.Clone();
      for (int i = 0; i < power; i++)
        result = LinearAlgebra.Multiply(result, matrix);
      return result;
    }

    /// <summary>Divides all the values in the matrix by a scalar.</summary>
    /// <param name="matrix">The matrix to divide the values of.</param>
    /// <param name="right">The scalar to divide all the matrix values by.</param>
    /// <returns>The resulting matrix with the divided values.</returns>
    public static Matrix<Fraction64> Divide(Matrix<Fraction64> matrix, Fraction64 right)
    {
      #region pre-optimization

      //Matrix<Fraction64> result = 
      //  new Matrix<Fraction64>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    result[i, j] = matrix[i, j] / right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      int matrix_row = matrix.Rows;
      int matrix_col = matrix.Columns;
      Matrix<Fraction64> result =
        new Matrix<Fraction64>(matrix_row, matrix_col);

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          matrix_flat = matrix._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < matrix_row; i++)
            for (int j = 0; j < matrix_col; j++)
              result_flat[i * matrix_col + j] =
                matrix_flat[i * matrix_col + j] / right;
      }
#else
      Fraction64[] matrix_flat = matrix._matrix;
      Fraction64[] result_flat = result._matrix;
      for (int i = 0; i < matrix_row; i++)
        for (int j = 0; j < matrix_col; j++)
          result_flat[i * matrix_col + j] = 
            matrix_flat[i * matrix_col + j] / right;

#endif
      return result;
    }

    /// <summary>Gets the minor of a matrix.</summary>
    /// <param name="matrix">The matrix to get the minor of.</param>
    /// <param name="row">The restricted row to form the minor.</param>
    /// <param name="column">The restricted column to form the minor.</param>
    /// <returns>The minor of the matrix.</returns>
    public static Matrix<Fraction64> Minor(Matrix<Fraction64> matrix, int row, int column)
    {
      #region pre-optimization

      //Matrix<Fraction64> minor = 
      //  new Matrix<Fraction64>(matrix.Rows - 1, matrix.Columns - 1);
      //int m = 0, n = 0;
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (i == row) continue;
      //  n = 0;
      //  for (int j = 0; j < matrix.Columns; j++)
      //  {
      //    if (j == column) continue;
      //    minor[m, n] = matrix[i, j];
      //    n++;
      //  }
      //  m++;
      //}
      //return minor;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows < 2 || matrix.Columns < 2)
        throw new Error("invalid matrix minor: (matrix.Rows < 2 || matrix.Columns < 2)");
      if (row < 0 || row >= matrix.Rows)
        throw new Error("invalid row on matrix minor: !(0 <= row < matrix.Rows)");
      if (column < 0 || row >= matrix.Columns)
        throw new Error("invalid column on matrix minor: !(0 <= column < matrix.Columns)");
#endif

      Matrix<Fraction64> minor =
        new Matrix<Fraction64>(matrix.Rows - 1, matrix.Columns - 1);
      int matrix_rows = matrix.Rows;
      int matrix_cols = matrix.Columns;

#if unsafe_code
      unsafe
      {
        fixed (Fraction64*
          matrix_flat = matrix._matrix,
          minor_flat = minor._matrix)
        {
          int m = 0, n = 0;
          for (int i = 0; i < matrix_rows; i++)
          {
            if (i == row) continue;
            n = 0;
            for (int j = 0; j < matrix_cols; j++)
            {
              if (j == column) continue;
              minor_flat[m * matrix_cols + n] =
                matrix_flat[i * matrix_cols + j];
              n++;
            }
            m++;
          }
        }
      }
#else
      int m = 0, n = 0;
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (i == row) continue;
        n = 0;
        for (int j = 0; j < matrix.Columns; j++)
        {
          if (j == column) continue;
          minor[m, n] = matrix[i, j];
          n++;
        }
        m++;
      }
#endif
      return minor;
    }

    /// <summary>Combines two matrices from left to right 
    /// (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
    /// <param name="left">The left matrix of the concatenation.</param>
    /// <param name="right">The right matrix of the concatenation.</param>
    /// <returns>The resulting matrix of the concatenation.</returns>
    public static Matrix<Fraction64> ConcatenateRowWise(Matrix<Fraction64> left, Matrix<Fraction64> right)
    {
      #region pre-optimization

      //Matrix<Fraction64> result =
      //  new Matrix<Fraction64>(left.Rows, left.Columns + right.Columns);
      //for (int i = 0; i < result.Rows; i++)
      //  for (int j = 0; j < result.Columns; j++)
      //    if (j < left.Columns)
      //      result[i, j] = left[i, j];
      //    else
      //      result[i, j] = right[i, j - left.Columns];
      //return result;

      #endregion

#if no_errorChecking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows)
        throw new Error("invalid row-wise concatenation !(left.Rows == right.Rows).");
#endif

      Matrix<Fraction64> result =
        new Matrix<Fraction64>(left.Rows, left.Columns + right.Columns);
      int result_rows = result.Rows;
      int result_cols = result.Columns;

      int left_cols = left.Columns;
      int right_cols = right.Columns;

#if unsafe_code
      unsafe
      {
        // OptimizeMe (jump statement)
        fixed (Fraction64*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < result_rows; i++)
            for (int j = 0; j < result_cols; j++)
              if (j < left_cols)
                result_flat[i * result_cols + j] =
                  left_flat[i * left_cols + j];
              else
                result_flat[i * result_cols + j] =
                  right_flat[i * right_cols + j - left_cols];
      }
#else
      for (int i = 0; i < result_rows; i++)
        for (int j = 0; j < result_cols; j++)
        {
          if (j < left.Columns)
            result[i, j] = left[i, j];
          else
            result[i, j] = right[i, j - left.Columns];
        }
#endif

      return result;
    }

    /// <summary>Calculates the echelon of a matrix (aka REF).</summary>
    /// <param name="matrix">The matrix to calculate the echelon of (aka REF).</param>
    /// <returns>The echelon of the matrix (aka REF).</returns>
    public static Matrix<Fraction64> Echelon(Matrix<Fraction64> matrix)
    {
      #region pre-optimization

      //Matrix<Fraction64> result = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (result[i, i] == 0)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] != 0)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  if (result[i, i] == 0)
      //    continue;
      //  if (result[i, i] != 1)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] == 1)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
      //  for (int j = i + 1; j < result.Rows; j++)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<Fraction64> result = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (result[i, i] == 0)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] != 0)
              LinearAlgebra.SwapRows(result, i, j);
        if (result[i, i] == 0)
          continue;
        if (result[i, i] != 1)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] == 1)
              LinearAlgebra.SwapRows(result, i, j);
        LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
        for (int j = i + 1; j < result.Rows; j++)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      }
      return result;
    }

    /// <summary>Calculates the echelon of a matrix and reduces it (aka RREF).</summary>
    /// <param name="matrix">The matrix matrix to calculate the reduced echelon of (aka RREF).</param>
    /// <returns>The reduced echelon of the matrix (aka RREF).</returns>
    public static Matrix<Fraction64> ReducedEchelon(Matrix<Fraction64> matrix)
    {
      #region pre-optimization

      //Matrix<Fraction64> result = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (result[i, i] == 0)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] != 0)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  if (result[i, i] == 0) continue;
      //  if (result[i, i] != 1)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] == 1)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
      //  for (int j = i + 1; j < result.Rows; j++)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      //  for (int j = i - 1; j >= 0; j--)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<Fraction64> result = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (result[i, i] == 0)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] != 0)
              LinearAlgebra.SwapRows(result, i, j);
        if (result[i, i] == 0) continue;
        if (result[i, i] != 1)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] == 1)
              LinearAlgebra.SwapRows(result, i, j);
        LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
        for (int j = i + 1; j < result.Rows; j++)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
        for (int j = i - 1; j >= 0; j--)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      }
      return result;
    }

    /// <summary>Calculates the determinent of a square matrix.</summary>
    /// <param name="matrix">The matrix to calculate the determinent of.</param>
    /// <returns>The determinent of the matrix.</returns>
    public static Fraction64 Determinent(Matrix<Fraction64> matrix)
    {
      #region pre-optimization

      //Fraction64 det = 1;
      //Matrix<Fraction64> rref = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (rref[i, i] == 0)
      //    for (int j = i + 1; j < rref.Rows; j++)
      //      if (rref[j, i] != 0)
      //      {
      //        LinearAlgebra.SwapRows(rref, i, j);
      //        det *= -1;
      //      }
      //  det *= rref[i, i];
      //  LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
      //  for (int j = i + 1; j < rref.Rows; j++)
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  for (int j = i - 1; j >= 0; j--)
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //}
      //return det;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        throw new Error("invalid matrix determinent: !(matrix.IsSquare)");
#endif

      Fraction64 det = 1;
      Matrix<Fraction64> rref = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (rref[i, i] == 0)
          for (int j = i + 1; j < rref.Rows; j++)
            if (rref[j, i] != 0)
            {
              LinearAlgebra.SwapRows(rref, i, j);
              det *= -1;
            }
        det *= rref[i, i];
        LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
        for (int j = i + 1; j < rref.Rows; j++)
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        for (int j = i - 1; j >= 0; j--)
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      }
      return det;
    }

    /// <summary>Calculates the inverse of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the inverse of.</param>
    /// <returns>The inverse of the matrix.</returns>
    public static Matrix<Fraction64> Inverse(Matrix<Fraction64> matrix)
    {
      #region pre-optimization

      //Matrix<Fraction64> identity = 
      //  LinearAlgebra.MatrixFactoryIdentity_Fraction64(matrix.Rows, matrix.Columns);
      //Matrix<Fraction64> rref = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (rref[i, i] == 0)
      //    for (int j = i + 1; j < rref.Rows; j++)
      //      if (rref[j, i] != 0)
      //      {
      //        LinearAlgebra.SwapRows(rref, i, j);
      //        LinearAlgebra.SwapRows(identity, i, j);
      //      }
      //  LinearAlgebra.RowMultiplication(identity, i, 1 / rref[i, i]);
      //  LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
      //  for (int j = i + 1; j < rref.Rows; j++)
      //  {
      //    LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  }
      //  for (int j = i - 1; j >= 0; j--)
      //  {
      //    LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  }
      //}
      //return identity;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (LinearAlgebra.Determinent(matrix) == 0)
        throw new Error("inverse calculation failed.");
#endif

      Matrix<Fraction64> identity = LinearAlgebra.MatrixFactoryIdentity_Fraction64(matrix.Rows, matrix.Columns);
      Matrix<Fraction64> rref = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (rref[i, i] == 0)
          for (int j = i + 1; j < rref.Rows; j++)
            if (rref[j, i] != 0)
            {
              LinearAlgebra.SwapRows(rref, i, j);
              LinearAlgebra.SwapRows(identity, i, j);
            }
        LinearAlgebra.RowMultiplication(identity, i, 1 / rref[i, i]);
        LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
        for (int j = i + 1; j < rref.Rows; j++)
        {
          LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        }
        for (int j = i - 1; j >= 0; j--)
        {
          LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        }
      }
      return identity;
    }

    /// <summary>Calculates the adjoint of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the adjoint of.</param>
    /// <returns>The adjoint of the matrix.</returns>
    public static Matrix<Fraction64> Adjoint(Matrix<Fraction64> matrix)
    {
      #region pre-optimization

      //Matrix<Fraction64> AdjointMatrix = new Matrix<Fraction64>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    if ((i + j) % 2 == 0)
      //      AdjointMatrix[i, j] = LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      //    else
      //      AdjointMatrix[i, j] = -LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      //return LinearAlgebra.Transpose(AdjointMatrix);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (!(matrix.Rows == matrix.Columns))
        throw new Error("Adjoint of a non-square matrix does not exists");
#endif

      Matrix<Fraction64> AdjointMatrix = new Matrix<Fraction64>(matrix.Rows, matrix.Columns);
      for (int i = 0; i < matrix.Rows; i++)
        for (int j = 0; j < matrix.Columns; j++)
          if ((i + j) % 2 == 0)
            AdjointMatrix[i, j] = LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
          else
            AdjointMatrix[i, j] = -LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      return LinearAlgebra.Transpose(AdjointMatrix);
    }

    /// <summary>Returns the transpose of a matrix.</summary>
    /// <param name="matrix">The matrix to transpose.</param>
    /// <returns>The transpose of the matrix.</returns>
    public static Matrix<Fraction64> Transpose(Matrix<Fraction64> matrix)
    {
      #region pre-optimization

      //Matrix<Fraction64> transpose = 
      //  new Matrix<Fraction64>(matrix.Columns, matrix.Rows);
      //for (int i = 0; i < transpose.Rows; i++)
      //  for (int j = 0; j < transpose.Columns; j++)
      //    transpose[i, j] = matrix[j, i];
      //return transpose;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<Fraction64> transpose =
        new Matrix<Fraction64>(matrix.Columns, matrix.Rows);
      for (int i = 0; i < transpose.Rows; i++)
        for (int j = 0; j < transpose.Columns; j++)
          transpose[i, j] = matrix[j, i];
      return transpose;
    }

    /// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
    /// <param name="matrix">The matrix to decompose.</param>
    /// <param name="Lower">The computed lower triangular matrix.</param>
    /// <param name="Upper">The computed upper triangular matrix.</param>
    public static void DecomposeLU(Matrix<Fraction64> matrix, out Matrix<Fraction64> Lower, out Matrix<Fraction64> Upper)
    {
      #region pre-optimization

      //Lower = LinearAlgebra.MatrixFactoryIdentity_Fraction64(matrix.Rows, matrix.Columns);
      //Upper = matrix.Clone();
      //int[] permutation = new int[matrix.Rows];
      //for (int i = 0; i < matrix.Rows; i++) permutation[i] = i;
      //Fraction64 p = 0, pom2, detOfP = 1;
      //int k0 = 0, pom1 = 0;
      //for (int k = 0; k < matrix.Columns - 1; k++)
      //{
      //  p = 0;
      //  for (int i = k; i < matrix.Rows; i++)
      //    if ((Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k]) > p)
      //    {
      //      p = Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k];
      //      k0 = i;
      //    }
      //  if (p == 0)
      //    throw new Error("The matrix is singular!");
      //  pom1 = permutation[k];
      //  permutation[k] = permutation[k0];
      //  permutation[k0] = pom1;
      //  for (int i = 0; i < k; i++)
      //  {
      //    pom2 = Lower[k, i];
      //    Lower[k, i] = Lower[k0, i];
      //    Lower[k0, i] = pom2;
      //  }
      //  if (k != k0)
      //    detOfP *= -1;
      //  for (int i = 0; i < matrix.Columns; i++)
      //  {
      //    pom2 = Upper[k, i];
      //    Upper[k, i] = Upper[k0, i];
      //    Upper[k0, i] = pom2;
      //  }
      //  for (int i = k + 1; i < matrix.Rows; i++)
      //  {
      //    Lower[i, k] = Upper[i, k] / Upper[k, k];
      //    for (int j = k; j < matrix.Columns; j++)
      //      Upper[i, j] = Upper[i, j] - Lower[i, k] * Upper[k, j];
      //  }
      //}

      #endregion

#if no_error_checking
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        throw new Error("non-square matrix during DecomposeLU function");
#endif

      Lower = LinearAlgebra.MatrixFactoryIdentity_Fraction64(matrix.Rows, matrix.Columns);
      Upper = matrix.Clone();
      int[] permutation = new int[matrix.Rows];
      for (int i = 0; i < matrix.Rows; i++) permutation[i] = i;
      Fraction64 p = 0, pom2, detOfP = 1;
      int k0 = 0, pom1 = 0;
      for (int k = 0; k < matrix.Columns - 1; k++)
      {
        p = 0;
        for (int i = k; i < matrix.Rows; i++)
          if ((Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k]) > p)
          {
            p = Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k];
            k0 = i;
          }
        if (p == 0)
          throw new Error("The matrix is singular!");
        pom1 = permutation[k];
        permutation[k] = permutation[k0];
        permutation[k0] = pom1;
        for (int i = 0; i < k; i++)
        {
          pom2 = Lower[k, i];
          Lower[k, i] = Lower[k0, i];
          Lower[k0, i] = pom2;
        }
        if (k != k0)
          detOfP *= -1;
        for (int i = 0; i < matrix.Columns; i++)
        {
          pom2 = Upper[k, i];
          Upper[k, i] = Upper[k0, i];
          Upper[k0, i] = pom2;
        }
        for (int i = k + 1; i < matrix.Rows; i++)
        {
          Lower[i, k] = Upper[i, k] / Upper[k, k];
          for (int j = k; j < matrix.Columns; j++)
            Upper[i, j] = Upper[i, j] - Lower[i, k] * Upper[k, j];
        }
      }
    }

    private static void RowMultiplication(Matrix<Fraction64> matrix, int row, Fraction64 scalar)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //  matrix[row, j] *= scalar;

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
        matrix[row, j] *= scalar;
    }

    private static void RowAddition(Matrix<Fraction64> matrix, int target, int second, Fraction64 scalar)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //  matrix[target, j] += (matrix[second, j] * scalar);

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
        matrix[target, j] += (matrix[second, j] * scalar);
    }

    private static void SwapRows(Matrix<Fraction64> matrix, int row1, int row2)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //{
      //  Fraction64 temp = matrix[row1, j];
      //  matrix[row1, j] = matrix[row2, j];
      //  matrix[row2, j] = temp;
      //}

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
      {
        Fraction64 temp = matrix[row1, j];
        matrix[row1, j] = matrix[row2, j];
        matrix[row2, j] = temp;
      }
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Matrix<Fraction64> left, Matrix<Fraction64> right)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;
      //if (left.Rows != right.Rows || left.Columns != right.Columns)
      //  return false;
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    if (left[i, j] != right[i, j])
      //      return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Rows != right.Rows || left.Columns != right.Columns)
        return false;
      for (int i = 0; i < left.Rows; i++)
        for (int j = 0; j < left.Columns; j++)
          if (left[i, j] != right[i, j])
            return false;

      return true;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Matrix<Fraction64> left, Matrix<Fraction64> right, Fraction64 leniency)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;
      //if (left.Rows != right.Rows || left.Columns != right.Columns)
      //  return false;
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    if (Logic.Abs(left[i, j] - right[i, j]) > leniency)
      //      return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        return false;
      for (int i = 0; i < left.Rows; i++)
        for (int j = 0; j < left.Columns; j++)
          if (Logic.Abs(left[i, j] - right[i, j]) > leniency)
            return false;
      return true;
    }

    #endregion

    #region quaterion

    /// <summary>Computes the length of quaternion.</summary>
    /// <param name="quaternion">The quaternion to compute the length of.</param>
    /// <returns>The length of the given quaternion.</returns>
    public static Fraction64 Magnitude(Quaternion<Fraction64> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return Algebra.sqrt(
          (quaternion.X * quaternion.X +
          quaternion.Y * quaternion.Y +
          quaternion.Z * quaternion.Z +
          quaternion.W * quaternion.W));
    }

    /// <summary>Computes the length of a quaternion, but doesn't square root it
    /// for optimization possibilities.</summary>
    /// <param name="quaternion">The quaternion to compute the length squared of.</param>
    /// <returns>The squared length of the given quaternion.</returns>
    public static Fraction64 MagnitudeSquared(Quaternion<Fraction64> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return
        quaternion.X * quaternion.X +
        quaternion.Y * quaternion.Y +
        quaternion.Z * quaternion.Z +
        quaternion.W * quaternion.W;
    }

    /// <summary>Gets the conjugate of the quaternion.</summary>
    /// <param name="quaternion">The quaternion to conjugate.</param>
    /// <returns>The conjugate of teh given quaternion.</returns>
    public static Quaternion<Fraction64> Conjugate(Quaternion<Fraction64> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return new Quaternion<Fraction64>(
        -quaternion.X,
        -quaternion.Y,
        -quaternion.Z,
        quaternion.W);
    }

    /// <summary>Adds two quaternions together.</summary>
    /// <param name="left">The first quaternion of the addition.</param>
    /// <param name="right">The second quaternion of the addition.</param>
    /// <returns>The result of the addition.</returns>
    public static Quaternion<Fraction64> Add(Quaternion<Fraction64> left, Quaternion<Fraction64> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<Fraction64>(
        left.X + right.X,
        left.Y + right.Y,
        left.Z + right.Z,
        left.W + right.W);
    }

    /// <summary>Subtracts two quaternions.</summary>
    /// <param name="left">The left quaternion of the subtraction.</param>
    /// <param name="right">The right quaternion of the subtraction.</param>
    /// <returns>The resulting quaternion after the subtraction.</returns>
    public static Quaternion<Fraction64> Subtract(Quaternion<Fraction64> left, Quaternion<Fraction64> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<Fraction64>(
        left.X - right.X,
        left.Y - right.Y,
        left.Z - right.Z,
        left.W - right.W);
    }

    /// <summary>Multiplies two quaternions together.</summary>
    /// <param name="left">The first quaternion of the multiplication.</param>
    /// <param name="right">The second quaternion of the multiplication.</param>
    /// <returns>The resulting quaternion after the multiplication.</returns>
    public static Quaternion<Fraction64> Multiply(Quaternion<Fraction64> left, Quaternion<Fraction64> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<Fraction64>(
        left.X * right.W + left.W * right.X + left.Y * right.Z - left.Z * right.Y,
        left.Y * right.W + left.W * right.Y + left.Z * right.X - left.X * right.Z,
        left.Z * right.W + left.W * right.Z + left.X * right.Y - left.Y * right.X,
        left.W * right.W - left.X * right.X - left.Y * right.Y - left.Z * right.Z);
    }

    /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
    /// <param name="left">The quaternion of the multiplication.</param>
    /// <param name="right">The scalar of the multiplication.</param>
    /// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
    public static Quaternion<Fraction64> Multiply(Quaternion<Fraction64> left, Fraction64 right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      return new Quaternion<Fraction64>(
        left.X * right,
        left.Y * right,
        left.Z * right,
        left.W * right);
    }

    /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
    /// <param name="left">The quaternion to pre-multiply the vector by.</param>
    /// <param name="right">The vector to be multiplied.</param>
    /// <returns>The resulting quaternion of the multiplication.</returns>
    public static Quaternion<Fraction64> Multiply(Quaternion<Fraction64> left, Vector<Fraction64> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (right.Dimensions != 3)
        throw new Error("my quaternion rotations are only defined for 3-component vectors.");
#endif

      return new Quaternion<Fraction64>(
        left.W * right.X + left.Y * right.Z - left.Z * right.Y,
        left.W * right.Y + left.Z * right.X - left.X * right.Z,
        left.W * right.Z + left.X * right.Y - left.Y * right.X,
        -left.X * right.X - left.Y * right.Y - left.Z * right.Z);
    }

    /// <summary>Normalizes the quaternion.</summary>
    /// <param name="quaternion">The quaternion to normalize.</param>
    /// <returns>The normalization of the given quaternion.</returns>
    public static Quaternion<Fraction64> Normalize(Quaternion<Fraction64> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      Fraction64 normalizer = Quaternion<Fraction64>.Magnitude(quaternion);
      if (normalizer != 0)
        return quaternion * (1 / normalizer);
      else
        return Quaternion<Fraction64>.FactoryIdentity;
    }

    /// <summary>Inverts a quaternion.</summary>
    /// <param name="quaternion">The quaternion to find the inverse of.</param>
    /// <returns>The inverse of the given quaternion.</returns>
    public static Quaternion<Fraction64> Invert(Quaternion<Fraction64> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      Fraction64 normalizer = Quaternion<Fraction64>.MagnitudeSquared(quaternion);
      if (normalizer == 0)
        return new Quaternion<Fraction64>(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
      normalizer = 1 / normalizer;
      return new Quaternion<Fraction64>(
        -quaternion.X * normalizer,
        -quaternion.Y * normalizer,
        -quaternion.Z * normalizer,
        quaternion.W * normalizer);
    }

    /// <summary>Lenearly interpolates between two quaternions.</summary>
    /// <param name="left">The starting point of the interpolation.</param>
    /// <param name="right">The ending point of the interpolation.</param>
    /// <param name="blend">The ratio 0.0-1.0 of how far to interpolate between the left and right quaternions.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Quaternion<Fraction64> Lerp(Quaternion<Fraction64> left, Quaternion<Fraction64> right, Fraction64 blend)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      if (blend < 0 || blend > 1)
        throw new Error("invalid blending value during lerp !(blend < 0.0f || blend > 1.0f).");
      if (Quaternion<Fraction64>.MagnitudeSquared(left) == 0)
      {
        if (Quaternion<Fraction64>.MagnitudeSquared(right) == 0)
          return Quaternion<Fraction64>.FactoryIdentity;
        else
          return new Quaternion<Fraction64>(right.X, right.Y, right.Z, right.W);
      }
      else if (Quaternion<Fraction64>.MagnitudeSquared(right) == 0)
        return new Quaternion<Fraction64>(left.X, left.Y, left.Z, left.W);
      Quaternion<Fraction64> result = new Quaternion<Fraction64>(
        1 - blend * left.X + blend * right.X,
        1 - blend * left.Y + blend * right.Y,
        1 - blend * left.Z + blend * right.Z,
        1 - blend * left.W + blend * right.W);
      if (Quaternion<Fraction64>.MagnitudeSquared(result) > 0)
        return Quaternion<Fraction64>.Normalize(result);
      else
        return Quaternion<Fraction64>.FactoryIdentity;
    }

    /// <summary>Sphereically interpolates between two quaternions.</summary>
    /// <param name="left">The starting point of the interpolation.</param>
    /// <param name="right">The ending point of the interpolation.</param>
    /// <param name="blend">The ratio of how far to interpolate between the left and right quaternions.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Quaternion<Fraction64> Slerp(Quaternion<Fraction64> left, Quaternion<Fraction64> right, Fraction64 blend)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      if (blend < 0 || blend > 1)
        throw new Error("invalid blending value during slerp !(blend < 0.0f || blend > 1.0f).");
      if (LinearAlgebra.MagnitudeSquared(left) == 0)
      {
        if (LinearAlgebra.MagnitudeSquared(right) == 0)
          return Quaternion<Fraction64>.FactoryIdentity;
        else
          return new Quaternion<Fraction64>(right.X, right.Y, right.Z, right.W);
      }
      else if (LinearAlgebra.MagnitudeSquared(right) == 0)
        return new Quaternion<Fraction64>(left.X, left.Y, left.Z, left.W);
      Fraction64 cosHalfAngle = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
      if (cosHalfAngle >= 1 || cosHalfAngle <= -1)
        return new Quaternion<Fraction64>(left.X, left.Y, left.Z, left.W);
      else if (cosHalfAngle < 0)
      {
        right = new Quaternion<Fraction64>(-left.X, -left.Y, -left.Z, -left.W);
        cosHalfAngle = -cosHalfAngle;
      }
      Fraction64 halfAngle = Trigonometry.arccos(cosHalfAngle);
      Fraction64 sinHalfAngle = Trigonometry.sin(halfAngle);
      Fraction64 blendA = Trigonometry.sin(halfAngle * (1 - blend)) / sinHalfAngle;
      Fraction64 blendB = Trigonometry.sin(halfAngle * blend) / sinHalfAngle;
      Quaternion<Fraction64> result = new Quaternion<Fraction64>(
        blendA * left.X + blendB * right.X,
        blendA * left.Y + blendB * right.Y,
        blendA * left.Z + blendB * right.Z,
        blendA * left.W + blendB * right.W);
      if (LinearAlgebra.MagnitudeSquared(result) > 0)
        return LinearAlgebra.Normalize(result);
      else
        return Quaternion<Fraction64>.FactoryIdentity;
    }

    /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
    /// <param name="rotation">The quaternion to rotate the vector by.</param>
    /// <param name="vector">The vector to be rotated by.</param>
    /// <returns>The result of the rotation.</returns>
    public static Vector<Fraction64> Rotate(Quaternion<Fraction64> rotation, Vector<Fraction64> vector)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(rotation, null))
        throw new Error("null reference: rotation");
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      if (vector.Dimensions != 3 && vector.Dimensions != 4)
        throw new Error("my quaternion rotations are only defined for 3-component vectors.");
      Quaternion<Fraction64> answer = LinearAlgebra.Multiply(LinearAlgebra.Multiply(rotation, vector), LinearAlgebra.Conjugate(rotation));
      return new Vector<Fraction64>(answer.X, answer.Y, answer.Z);
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first quaternion to check for equality.</param>
    /// <param name="right">The second quaternion  to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Quaternion<Fraction64> left, Quaternion<Fraction64> right)
    {
      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      return
        left.X == right.X &&
        left.Y == right.Y &&
        left.Z == right.Z &&
        left.W == right.W;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first quaternion to check for equality.</param>
    /// <param name="right">The second quaternion to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Quaternion<Fraction64> left, Quaternion<Fraction64> right, Fraction64 leniency)
    {
      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      return
        Logic.Abs(left.X - right.X) < leniency &&
        Logic.Abs(left.Y - right.Y) < leniency &&
        Logic.Abs(left.Z - right.Z) < leniency &&
        Logic.Abs(left.W - right.W) < leniency;
    }

    #endregion

    #region tableau

    //const Fraction64 epsilon = 1.0e-8;
    ////int equal(Fraction64 a, Fraction64 b) { return fabs(a - b) < epsilon; }

    //static void pivot_on(ref Fraction64[,] tableau, int row, int col)
    //{
    //  int i, j;
    //  Fraction64 pivot;

    //  pivot = tableau[row, col];
    //  if (!(pivot > 0))
    //    throw new Error("possible invalid tableau values (IDK)");
    //  for (j = 0; j < tableau.GetLength(1); j++)
    //    tableau[row, j] /= pivot;
    //  if (!(Logic.Equate(tableau[row, col], 1, epsilon)))
    //    throw new Error("possible invalid tableau values (IDK)");

    //  for (i = 0; i < tableau.GetLength(0); i++)
    //  { // foreach remaining row i do
    //    Fraction64 multiplier = tableau[i, col];
    //    if (i == row) continue;
    //    for (j = 0; j < tableau.GetLength(1); j++)
    //    { // r[i] = r[i] - z * r[row];
    //      tableau[i, j] -= multiplier * tableau[row, j];
    //    }
    //  }
    //}

    //// Find pivot_col = most negative column in mat[0][1..n]
    //static int find_pivot_column(ref Fraction64[,] tableau)
    //{
    //  int j, pivot_col = 1;
    //  Fraction64 lowest = tableau[0, pivot_col];
    //  for (j = 1; j < tableau.GetLength(1); j++)
    //  {
    //    if (tableau[0, j] < lowest)
    //    {
    //      lowest = tableau[0, j];
    //      pivot_col = j;
    //    }
    //  }
    //  //printf("Most negative column in row[0] is col %d = %g.\n", pivot_col, lowest);
    //  if (lowest >= 0)
    //  {
    //    return -1; // All positive columns in row[0], this is optimal.
    //  }
    //  return pivot_col;
    //}

    //// Find the pivot_row, with smallest positive ratio = col[0] / col[pivot]
    //static int find_pivot_row(ref Fraction64[,] tableau, int pivot_col)
    //{
    //  int i, pivot_row = 0;
    //  Fraction64 min_ratio = -1;
    //  //printf("Ratios A[row_i,0]/A[row_i,%d] = [", pivot_col);
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    Fraction64 ratio = tableau[i, 0] / tableau[i, pivot_col];
    //    //printf("%3.2lf, ", ratio);
    //    if ((ratio > 0 && ratio < min_ratio) || min_ratio < 0)
    //    {
    //      min_ratio = ratio;
    //      pivot_row = i;
    //    }
    //  }
    //  //printf("].\n");
    //  if (min_ratio == -1)
    //    return -1; // Unbounded.
    //  //printf("Found pivot A[%d,%d], min positive ratio=%g in row=%d.\n",
    //  //  pivot_row, pivot_col, min_ratio, pivot_row);
    //  return pivot_row;
    //}

    //static void add_slack_variables(ref Fraction64[,] tableau)
    //{

    //  Fraction64[,] newTableau =
    //    new Fraction64[tableau.GetLength(0), tableau.GetLength(1) + tableau.GetLength(0) - 1];

    //  for (int a = 0, a_max = tableau.GetLength(0); a < a_max; a++)
    //    for (int b = 0, b_max = tableau.GetLength(1); b < b_max; b++)
    //      newTableau[a, b] = tableau[a, b];

    //  int i, j;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    for (j = 1; j < tableau.GetLength(0); j++)
    //      newTableau[i, j + tableau.GetLength(1) - 1] = (i == j ? 1d : 0d);
    //  }

    //  tableau = newTableau;
    //}

    //static void check_b_positive(ref Fraction64[,] tableau)
    //{
    //  int i;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //    if (!(tableau[i, 0] >= 0))
    //      throw new Error("possible invalid tableau values (IDK)");
    //}

    //// Given a column of identity matrix, find the row containing 1.
    //// return -1, if the column as not from an identity matrix.
    //static int find_basis_variable(ref Fraction64[,] tableau, int col)
    //{
    //  int i, xi = -1;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    if (Logic.Equate(tableau[i, col], 1, epsilon))
    //      if (xi == -1)
    //        xi = i;   // found first '1', save this row number.
    //      else
    //        return -1; // found second '1', not an identity matrix.
    //    else if (!Logic.Equate(tableau[i, col], 0, epsilon))
    //      return -1; // not an identity matrix column.
    //  }
    //  return xi;
    //}

    //static Fraction64[] print_optimal_vector(ref Fraction64[,] tableau)
    //{
    //  Fraction64[] vector = new Fraction64[tableau.GetLength(1)];
    //  int j, xi;
    //  //printf("%s at ", message);
    //  for (j = 1; j < tableau.GetLength(1); j++)
    //  { // for each column.
    //    xi = find_basis_variable(ref tableau, j);
    //    if (xi != -1)
    //      vector[j] = tableau[xi, 0];
    //    else
    //      vector[j] = j;
    //  }
    //  return vector;
    //}

    //public static Fraction64[] Simplex(ref Fraction64[,] tableau)
    //{
    //  int loop = 0;
    //  add_slack_variables(ref tableau);
    //  check_b_positive(ref tableau);
    //  while (++loop > 0)
    //  {
    //    int pivot_col, pivot_row;

    //    pivot_col = find_pivot_column(ref tableau);
    //    if (pivot_col < 0)
    //      //printf("Found optimal value=A[0,0]=%3.2lf (no negatives in row 0).\n",
    //      //  tableau->mat[0][0]);
    //      return print_optimal_vector(ref tableau);
    //    //printf("Entering variable x%d to be made basic, so pivot_col=%d.\n",
    //    //  pivot_col, pivot_col);

    //    pivot_row = find_pivot_row(ref tableau, pivot_col);
    //    if (pivot_row < 0)
    //      throw new Error("unbounded (no pivot_row)");
    //    //printf("Leaving variable x%d, so pivot_row=%d\n", pivot_row, pivot_row);

    //    pivot_on(ref tableau, pivot_row, pivot_col);
    //    //print_tableau(tableau, "After pivoting");
    //    //return print_optimal_vector(ref tableau);
    //  }
    //  throw new Error("Simplex has a glitch");
    //}

    #endregion

    #endregion

    #region decimal

    #region vector

    /// <summary>Adds two vectors together.</summary>
    /// <param name="left">The first vector of the addition.</param>
    /// <param name="right">The second vector of the addiiton.</param>
    /// <returns>The result of the addiion.</returns>
    public static Vector<decimal> Add(Vector<decimal> left, Vector<decimal> right)
    {
      #region pre-optimization

      //Vector<decimal> result =
      //  new Vector<decimal>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] + right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector addition.");
#endif

      int length = left.Dimensions;
      Vector<decimal> result =
        new Vector<decimal>(left.Dimensions);

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
      }
#else
      decimal[] left_flat = left._vector;
      decimal[] right_flat = right._vector;
      decimal[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
#endif

      return result;
    }

    /// <summary>Negates all the values in a vector.</summary>
    /// <param name="vector">The vector to have its values negated.</param>
    /// <returns>The result of the negations.</returns>
    public static Vector<decimal> Negate(Vector<decimal> vector)
    {
      #region pre-optimization

      //Vector<decimal> result =
      //  new Vector<decimal>(vector.Dimensions);
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result[i] = -vector[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Vector<decimal> result =
        new Vector<decimal>(length);

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = -vector_flat[i];
      }
#else
      decimal[] vector_flat = vector._vector;
      decimal[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = -vector_flat[i];
#endif

      return result;
    }

    /// <summary>Subtracts two vectors.</summary>
    /// <param name="left">The left vector of the subtraction.</param>
    /// <param name="right">The right vector of the subtraction.</param>
    /// <returns>The result of the vector subtracton.</returns>
    public static Vector<decimal> Subtract(Vector<decimal> left, Vector<decimal> right)
    {
      #region pre-optimization

      //Vector<decimal> result =
      //  new Vector<decimal>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] - right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector subtraction.");
#endif

      int length = left.Dimensions;
      Vector<decimal> result =
        new Vector<decimal>(length);

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] - right_flat[i];
      }
#else
      decimal[] left_flat = left._vector;
      decimal[] right_flat = right._vector;
      decimal[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] - right_flat[i];
#endif

      return result;
    }

    /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
    /// <param name="left">The vector to have the components multiplied by.</param>
    /// <param name="right">The scalars to multiply the vector components by.</param>
    /// <returns>The result of the multiplications.</returns>
    public static Vector<decimal> Multiply(Vector<decimal> left, decimal right)
    {
      #region pre-optimization

      //Vector<decimal> result =
      //  new Vector<decimal>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] * right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      int length = left.Dimensions;
      Vector<decimal> result =
        new Vector<decimal>(length);

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          left_flat = left._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] * right;
      }
#else
      decimal[] left_flat = left._vector;
      decimal[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] * right;
#endif

      return result;
    }

    /// <summary>Divides all the components of a vector by a scalar.</summary>
    /// <param name="vector">The vector to have the components divided by.</param>
    /// <param name="right">The scalar to divide the vector components by.</param>
    /// <returns>The resulting vector after teh divisions.</returns>
    public static Vector<decimal> Divide(Vector<decimal> vector, decimal right)
    {
      #region pre-optimization

      //Vector<decimal> result =
      //  new Vector<decimal>(vector.Dimensions);
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result[i] = vector[i] / right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: left");
#endif

      int length = vector.Dimensions;
      Vector<decimal> result =
        new Vector<decimal>(length);

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = vector_flat[i] / right;
      }
#else
      decimal[] vector_flat = vector._vector;
      decimal[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = vector_flat[i] / right;
#endif

      return result;
    }

    /// <summary>Computes the dot product between two vectors.</summary>
    /// <param name="left">The first vector of the dot product operation.</param>
    /// <param name="right">The second vector of the dot product operation.</param>
    /// <returns>The result of the dot product operation.</returns>
    public static decimal DotProduct(Vector<decimal> left, Vector<decimal> right)
    {
      #region pre-optimization

      //decimal result = 0;
      //for (int i = 0; i < left.Dimensions; i++)
      //  result += left[i] * right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector dot product.");
#endif

      int length = left.Dimensions;
      decimal result = 0;

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          left_flat = left._vector,
          right_flat = right._vector)
          for (int i = 0; i < length; i++)
            result += left_flat[i] * right_flat[i];
      }
#else
      decimal[] left_flat = left._vector;
      decimal[] right_flat = right._vector;
      for (int i = 0; i < length; i++)
        result += left_flat[i] * right_flat[i];
#endif

      return result;
    }

    /// <summary>Computes teh cross product of two vectors.</summary>
    /// <param name="left">The first vector of the cross product operation.</param>
    /// <param name="right">The second vector of the cross product operation.</param>
    /// <returns>The result of the cross product operation.</returns>
    public static Vector<decimal> CrossProduct(Vector<decimal> left, Vector<decimal> right)
    {
      #region pre-optimization

      //Vector<decimal> result = new Vector<decimal>(3);
      //result[0] = left[1] * right[2] - left[2] * right[1];
      //result[1] = left[2] * right[0] - left[0] * right[2];
      //result[2] = left[0] * right[1] - left[1] * right[0];

      #endregion

#if no_error_checking

#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid cross product (left.Dimensions != right.Dimensions)");
      if (left.Dimensions != 3)
        throw new Error("my cross product function is only defined for 3-component vectors.");
#endif

      Vector<decimal> result =
        new Vector<decimal>(3);

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
        {
          result_flat[0] = left_flat[1] * right_flat[2] - left_flat[2] * right_flat[1];
          result_flat[1] = left_flat[2] * right_flat[0] - left_flat[0] * right_flat[2];
          result_flat[2] = left_flat[0] * right_flat[1] - left_flat[1] * right_flat[0];
        }
      }
#else
      decimal[] left_flat = left._vector;
      decimal[] right_flat = right._vector;
      decimal[] result_flat = result._vector;
      result_flat[0] = left_flat[1] * right_flat[2] - left_flat[2] * right_flat[1];
      result_flat[1] = left_flat[2] * right_flat[0] - left_flat[0] * right_flat[2];
      result_flat[2] = left_flat[0] * right_flat[1] - left_flat[1] * right_flat[0];
#endif

      return result;
    }

    /// <summary>Normalizes a vector.</summary>
    /// <param name="vector">The vector to normalize.</param>
    /// <returns>The result of the normalization.</returns>
    public static Vector<decimal> Normalize(Vector<decimal> vector)
    {
      #region pre-optimization

      //decimal magnitude = LinearAlgebra.Magnitude(vector);
      //if (magnitude != 0)
      //{
      //  Vector<decimal> result = 
      //    new Vector<decimal>(vector.Dimensions);
      //  for (int i = 0; i < vector.Dimensions; i++)
      //    result[i] = vector[i] / magnitude;
      //  return result;
      //}
      //else
      //  return new decimal[vector.Dimensions];

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Vector<decimal> result =
        new Vector<decimal>(vector.Dimensions);
      decimal magnitude = LinearAlgebra.Magnitude(vector);
      if (magnitude != 0)
        return result;

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = vector_flat[i] / magnitude;
      }
#else
      decimal[] vector_flat = vector._vector;
      decimal[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = vector_flat[i] / magnitude;
#endif

      return result;

    }

    /// <summary>Computes the length of a vector.</summary>
    /// <param name="vector">The vector to calculate the length of.</param>
    /// <returns>The computed length of the vector.</returns>
    public static decimal Magnitude(Vector<decimal> vector)
    {
      #region pre-optimization

      //decimal result = 0;
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result += vector[i] * vector[i];
      //return Algebra.sqrt(result);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      decimal result = 0;

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          vector_flat = vector._vector)
          for (int i = 0; i < length; i++)
            result += vector_flat[i] * vector_flat[i];
      }
#else
      decimal[] vector_flat = vector._vector;
      for (int i = 0; i < length; i++)
        result += vector_flat[i] * vector_flat[i];
#endif

      return Algebra.sqrt(result);
    }

    /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
    /// <param name="vector">The vector to compute the length squared of.</param>
    /// <returns>The computed length squared of the vector.</returns>
    public static decimal MagnitudeSquared(Vector<decimal> vector)
    {
      #region pre-optimization

      //decimal result = 0;
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result += vector[i] * vector[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      decimal result = 0;

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          vector_flat = vector._vector)
          for (int i = 0; i < length; i++)
            result += vector_flat[i] * vector_flat[i];
      }
#else
      decimal[] vector_flat = vector._vector;
      for (int i = 0; i < length; i++)
        result += vector_flat[i] * vector_flat[i];
#endif

      return result;
    }

    /// <summary>Computes the angle between two vectors.</summary>
    /// <param name="first">The first vector to determine the angle between.</param>
    /// <param name="second">The second vector to determine the angle between.</param>
    /// <returns>The angle between the two vectors in radians.</returns>
    public static decimal Angle(Vector<decimal> first, Vector<decimal> second)
    {
      #region pre-optimization

      //return Trigonometry.arccos(
      //  LinearAlgebra.DotProduct(first, second) / 
      //  (LinearAlgebra.Magnitude(first) * 
      //  LinearAlgebra.Magnitude(second)));

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(first, null))
        throw new Error("null reference: first");
      if (object.ReferenceEquals(second, null))
        throw new Error("null reference: second");
#endif

      return Trigonometry.arccos(
        LinearAlgebra.DotProduct(first, second) /
        (LinearAlgebra.Magnitude(first) *
        LinearAlgebra.Magnitude(second)));
    }

    /// <summary>Rotates a 3-component vector by the specified axis and rotation values.</summary>
    /// <param name="vector">The vector to rotate.</param>
    /// <param name="angle">The angle of the rotation in radians.</param>
    /// <param name="x">The x component of the axis vector to rotate about.</param>
    /// <param name="y">The y component of the axis vector to rotate about.</param>
    /// <param name="z">The z component of the axis vector to rotate about.</param>
    /// <returns>The result of the rotation.</returns>
    public static Vector<decimal> RotateBy(Vector<decimal> vector, decimal angle, decimal x, decimal y, decimal z)
    {
      #region pre-optimization

      //decimal sinHalfAngle = Trigonometry.sin(angle / 2);
      //decimal cosHalfAngle = Trigonometry.cos(angle / 2);
      //x *= sinHalfAngle;
      //y *= sinHalfAngle;
      //z *= sinHalfAngle;
      //decimal x2 = cosHalfAngle * vector[0] + y * vector[2] - z * vector[1];
      //decimal y2 = cosHalfAngle * vector[1] + z * vector[0] - x * vector[2];
      //decimal z2 = cosHalfAngle * vector[2] + x * vector[1] - y * vector[0];
      //decimal w2 = -x * vector[0] - y * vector[1] - z * vector[2];
      //Vector<decimal> result = new Vector<decimal>();
      //result[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
      //result[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
      //result[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
      if (vector.Dimensions == 3)
        throw new Error("my RotateBy() function is only defined for 3-component vectors.");
#endif

      Vector<decimal> result = new Vector<decimal>(3);
      decimal sinHalfAngle = Trigonometry.sin(angle / 2);
      decimal cosHalfAngle = Trigonometry.cos(angle / 2);
      x *= sinHalfAngle;
      y *= sinHalfAngle;
      z *= sinHalfAngle;

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          vector_flat = vector._vector,
          result_flat = result._vector)
        {
          decimal x2 = cosHalfAngle * vector_flat[0] + y * vector_flat[2] - z * vector_flat[1];
          decimal y2 = cosHalfAngle * vector_flat[1] + z * vector_flat[0] - x * vector_flat[2];
          decimal z2 = cosHalfAngle * vector_flat[2] + x * vector_flat[1] - y * vector_flat[0];
          decimal w2 = -x * vector_flat[0] - y * vector_flat[1] - z * vector_flat[2];
          result_flat[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
          result_flat[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
          result_flat[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;
        }
      }
#else
      decimal[] vector_flat = vector._vector;
      decimal[] result_flat = result._vector;
      decimal x2 = cosHalfAngle * vector_flat[0] + y * vector_flat[2] - z * vector_flat[1];
      decimal y2 = cosHalfAngle * vector_flat[1] + z * vector_flat[0] - x * vector_flat[2];
      decimal z2 = cosHalfAngle * vector_flat[2] + x * vector_flat[1] - y * vector_flat[0];
      decimal w2 = -x * vector_flat[0] - y * vector_flat[1] - z * vector_flat[2];
      result_flat[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
      result_flat[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
      result_flat[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;
#endif

      return result;
    }

    /// <summary>Rotates a vector by a quaternion rotation.</summary>
    /// <param name="vector">The vector to be rotated.</param>
    /// <param name="quaternion">The rotation to be applied.</param>
    /// <returns>The vector after the rotation.</returns>
    public static Vector<decimal> RotateBy(Vector<decimal> vector, Quaternion<decimal> quaternion)
    {
      return Rotate(quaternion, vector);
    }

    /// <summary>Computes the linear interpolation between two vectors.</summary>
    /// <param name="left">The starting vector of the interpolation.</param>
    /// <param name="right">The ending vector of the interpolation.</param>
    /// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Vector<decimal> Lerp(Vector<decimal> left, Vector<decimal> right, decimal blend)
    {
      #region pre-optimization

      //Vector<decimal> result = new Vector<decimal>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] + blend * (right[i] - left[i]);
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (blend < 0 || blend > 1)
        throw new Error("invalid vector lerp blend value: (blend < 0.0f || blend > 1.0f).");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid vector lerp length: (left.Dimensions != right.Dimensions)");
#endif

      int length = left.Dimensions;
      Vector<decimal> result =
        new Vector<decimal>(length);

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + blend * (right_flat[i] - left_flat[i]);
      }
#else
      decimal[] left_flat = left._vector;
      decimal[] right_flat = right._vector;
      decimal[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] + blend * (right_flat[i] - left_flat[i]);
#endif

      return result;
    }

    /// <summary>Sphereically interpolates between two vectors.</summary>
    /// <param name="left">The starting vector of the interpolation.</param>
    /// <param name="right">The ending vector of the interpolation.</param>
    /// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
    /// <returns>The result of the slerp operation.</returns>
    public static Vector<decimal> Slerp(Vector<decimal> left, Vector<decimal> right, decimal blend)
    {
      #region pre-optimization

      //decimal dot = LinearAlgebra.DotProduct(left, right);
      //dot = dot < -1 ? -1 : dot;
      //dot = dot > 1 ? 1 : dot;
      //decimal theta = Trigonometry.arccos(dot) * blend;
      //return LinearAlgebra.Multiply(LinearAlgebra.Add(LinearAlgebra.Multiply(left, Trigonometry.cos(theta)),
      //  LinearAlgebra.Normalize(LinearAlgebra.Subtract(right, LinearAlgebra.Multiply(left, dot)))), Trigonometry.sin(theta));

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (blend < 0 || blend > 1)
        throw new Error("invalid slerp blend value: (blend < 0.0f || blend > 1.0f).");
#endif

      decimal dot = LinearAlgebra.DotProduct(left, right);
      dot = dot < -1 ? -1 : dot;
      dot = dot > 1 ? 1 : dot;
      decimal theta = Trigonometry.arccos(dot) * blend;
      return LinearAlgebra.Multiply(LinearAlgebra.Add(LinearAlgebra.Multiply(left, Trigonometry.cos(theta)),
        LinearAlgebra.Normalize(LinearAlgebra.Subtract(right, LinearAlgebra.Multiply(left, dot)))), Trigonometry.sin(theta));
    }

    /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
    /// <param name="a">The first vector of the interpolation.</param>
    /// <param name="b">The second vector of the interpolation.</param>
    /// <param name="c">The thrid vector of the interpolation.</param>
    /// <param name="u">The "U" value of the barycentric interpolation equation.</param>
    /// <param name="v">The "V" value of the barycentric interpolation equation.</param>
    /// <returns>The resulting vector of the barycentric interpolation.</returns>
    public static Vector<decimal> Blerp(Vector<decimal> a, Vector<decimal> b, Vector<decimal> c, decimal u, decimal v)
    {
      #region pre-optimization

      //return 
      //  LinearAlgebra.Add(
      //    LinearAlgebra.Add(
      //      LinearAlgebra.Multiply(
      //        LinearAlgebra.Subtract(b, a), u),
      //          LinearAlgebra.Multiply(
      //            LinearAlgebra.Subtract(c, a), v)), a);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(a, null))
        throw new Error("null reference: a");
      if (object.ReferenceEquals(b, null))
        throw new Error("null reference: b");
      if (object.ReferenceEquals(c, null))
        throw new Error("null reference: c");
#endif

      return
        LinearAlgebra.Add(
          LinearAlgebra.Add(
            LinearAlgebra.Multiply(
              LinearAlgebra.Subtract(b, a), u),
                LinearAlgebra.Multiply(
                  LinearAlgebra.Subtract(c, a), v)), a);
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Vector<decimal> left, Vector<decimal> right)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;

      //if (left.Dimensions != right.Dimensions)
      //  return false;
      //for (int i = 0; i < left.Dimensions; i++)
      //  if (left[i] != right[i])
      //    return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Dimensions != right.Dimensions)
        return false;
      for (int i = 0; i < left.Dimensions; i++)
        if (left[i] != right[i])
          return false;
      return true;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Vector<decimal> left, Vector<decimal> right, decimal leniency)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;

      //if (left.Dimensions != right.Dimensions)
      //  return false;
      //for (int i = 0; i < left.Dimensions; i++)
      //  if (Logic.Abs(left[i] - right[i]) > leniency)
      //    return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Dimensions != right.Dimensions)
        return false;
      for (int i = 0; i < left.Dimensions; i++)
        if (Logic.Abs(left[i] - right[i]) > leniency)
          return false;
      return true;
    }

    #endregion

    #region matrix

    /// <summary>Determines if a matrix is symetric or not.</summary>
    /// <param name="matrix">The matrix to determine symetry of.</param>
    /// <returns>True if symetric; false if not.</returns>
    public static bool IsSymmetric(Matrix<decimal> matrix)
    {
      #region pre-optimization

      //if (matrix.Rows != matrix.Columns)
      //  return false;
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    if (matrix[i, j] != matrix[j, i])
      //      return false;
      //return true;

      #endregion

#if no_errorchecking
      //nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        return false;
#endif
      int size = matrix.Columns;
#if unsafe_code
      unsafe
      {
        fixed (decimal* matrix_flat = matrix._matrix)
          for (var row = 0; row < size; row++)
            for (var column = row + 1; column < size; column++)
              if (matrix_flat[row * size + column] != matrix_flat[column * size + row])
                return false;
      }
#else
      decimal[] matrix_flat = matrix._matrix;
      for (var row = 0; row < size; row++)
        for (var column = row + 1; column < size; column++)
          if (matrix_flat[row * size + column] != matrix_flat[column * size + row])
            return false;
#endif
      return true;
    }

    /// <summary>Constructs a new identity-matrix of the given dimensions.</summary>
    /// <param name="rows">The number of rows of the matrix.</param>
    /// <param name="columns">The number of columns of the matrix.</param>
    /// <returns>The newly constructed identity-matrix.</returns>
    public static Matrix<decimal> MatrixFactoryIdentity_decimal(int rows, int columns)
    {
      #region pre-optimization

      //Matrix<decimal> matrix = 
      //  new Matrix<decimal>(rows, columns);
      //for (int i = 0; i < Logic.Min(rows, columns); i++)
      //  matrix[i, i] = 1;
      //return matrix;

      #endregion

#if no_error_checking
      //nothing
#else
      if (rows < 1)
        throw new Error("invalid row count on matrix creation");
      if (columns < 1)
        throw new Error("invalid column count on matrix creation");
#endif

      Matrix<decimal> matrix = new Matrix<decimal>(rows, columns);
      if (rows <= columns)
        for (int i = 0; i < rows; i++)
          matrix[i, i] = 1;
      else
        for (int i = 0; i < columns; i++)
          matrix[i, i] = 1;
      return matrix;
    }

    /// <summary>Negates all the values in a matrix.</summary>
    /// <param name="matrix">The matrix to have its values negated.</param>
    /// <returns>The resulting matrix after the negations.</returns>
    public static Matrix<decimal> Negate(Matrix<decimal> matrix)
    {
      #region pre-optimization

      //Matrix<decimal> result =
      //  new Matrix<decimal>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Rows; j++)
      //    result[i, j] = -matrix[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
        if (object.ReferenceEquals(matrix, null))
          throw new Error("null reference: matirx");
#endif

      Matrix<decimal> result =
        new Matrix<decimal>(matrix.Rows, matrix.Columns);
      int size = matrix.Rows * matrix.Columns;

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          result_flat = result._matrix,
          matrix_flat = matrix._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = -matrix_flat[i];
        return result;
      }
#else
      decimal[] result_flat = result._matrix;
      decimal[] matrix_flat = matrix._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = -matrix_flat[i];
      return result;
#endif
    }

    /// <summary>Negates all the values in a matrix.</summary>
    /// <param name="matrix">The matrix to have its values negated.</param>
    /// <returns>The resulting matrix after the negations.</returns>
    public static Matrix<decimal> Negate_parallel(Matrix<decimal> matrix)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matirx");
#endif

      if (matrix.Rows * matrix.Columns > _parallelMinimum)
      {
        Matrix<decimal> result =
        new Matrix<decimal>(matrix.Rows, matrix.Columns);
        int size = matrix.Rows * matrix.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (decimal*
                  result_flat = result._matrix,
                  matrix_flat = matrix._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = -matrix_flat[i];
              };
            }, Logic.Max(matrix.Rows, matrix.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                decimal[] matrix_flat = matrix._matrix;
                decimal[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = -matrix_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Negate(matrix);
    }

    /// <summary>Does standard addition of two matrices.</summary>
    /// <param name="left">The left matrix of the addition.</param>
    /// <param name="right">The right matrix of the addition.</param>
    /// <returns>The resulting matrix after the addition.</returns>
    public static Matrix<decimal> Add(Matrix<decimal> left, Matrix<decimal> right)
    {
      #region pre-optimization

      //Matrix<decimal> result =
      //  new Matrix<decimal>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] + right[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
          throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix addition (dimension miss-match).");
#endif

      Matrix<decimal> result =
        new Matrix<decimal>(left.Rows, left.Columns);
      int size = left.Rows * left.Columns;

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
      }
#else
      decimal[] left_flat = left._matrix;
      decimal[] right_flat = right._matrix;
      decimal[] result_flat = result._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = left_flat[i] + right_flat[i];
#endif

      return result;
    }

    /// <summary>Does standard addition of two matrices.</summary>
    /// <param name="left">The left matrix of the addition.</param>
    /// <param name="right">The right matrix of the addition.</param>
    /// <returns>The resulting matrix after the addition.</returns>
    public static Matrix<decimal> Add_parallel(Matrix<decimal> left, Matrix<decimal> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix addition (dimension miss-match).");
#endif

      if (left.Rows * left.Columns > _parallelMinimum)
      {
        Matrix<decimal> result =
        new Matrix<decimal>(left.Rows, left.Columns);
        int size = left.Rows * left.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (decimal*
                  left_flat = left._matrix,
                  right_flat = right._matrix,
                  result_flat = result._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = left_flat[i] + right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                decimal[] left_flat = left._matrix;
                decimal[] right_flat = right._matrix;
                decimal[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = left_flat[i] + right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Add(left, right);
    }

    /// <summary>Subtracts a scalar from all the values in a matrix.</summary>
    /// <param name="left">The matrix to have the values subtracted from.</param>
    /// <param name="right">The scalar to subtract from all the matrix values.</param>
    /// <returns>The resulting matrix after the subtractions.</returns>
    public static Matrix<decimal> Subtract(Matrix<decimal> left, Matrix<decimal> right)
    {
      #region pre-optimization

      //Matrix<decimal> result =
      //  new Matrix<decimal>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] - right[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix subtraction (dimension miss-match).");
#endif

      Matrix<decimal> result =
        new Matrix<decimal>(left.Rows, left.Columns);
      int size = left.Rows * left.Columns;

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = left_flat[i] - right_flat[i];
      }
#else
      decimal[] left_flat = left._matrix;
      decimal[] right_flat = right._matrix;
      decimal[] result_flat = result._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = left_flat[i] - right_flat[i];
#endif

      return result;
    }

    /// <summary>Subtracts a scalar from all the values in a matrix.</summary>
    /// <param name="left">The matrix to have the values subtracted from.</param>
    /// <param name="right">The scalar to subtract from all the matrix values.</param>
    /// <returns>The resulting matrix after the subtractions.</returns>
    public static Matrix<decimal> Subtract_parallel(Matrix<decimal> left, Matrix<decimal> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix subtraction (dimension miss-match).");
#endif

      if (left.Rows * left.Columns > _parallelMinimum)
      {
        Matrix<decimal> result =
        new Matrix<decimal>(left.Rows, left.Columns);
        int size = left.Rows * left.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (decimal*
                  left_flat = left._matrix,
                  right_flat = right._matrix,
                  result_flat = result._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = left_flat[i] - right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
          (int current, int max) =>
          {
            return () =>
            {
              decimal[] left_flat = left._matrix;
              decimal[] right_flat = right._matrix;
              decimal[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = left_flat[i] - right_flat[i];
            };
          }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Subtract(left, right);
    }

    /// <summary>Performs multiplication on two matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Matrix<decimal> Multiply(Matrix<decimal> left, Matrix<decimal> right)
    {
      #region pre-optimization

      //Matrix<decimal> result = 
      //  new Matrix<decimal>(left.Rows, right.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < right.Columns; j++)
      //    for (int k = 0; k < left.Columns; k++)
      //      result[i, j] += left[i, k] * right[k, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (left == null)
        throw new Error("null reference: left");
      if (right == null)
        throw new Error("null reference: right");
      if (left.Columns != right.Rows)
        throw new LinearAlgebra.Error("invalid multiplication (size miss-match).");
#endif

      decimal sum;
      int result_rows = left.Rows;
      int left_cols = left.Columns;
      int result_cols = right.Columns;
      Matrix<decimal> result =
        new Matrix<decimal>(result_rows, result_cols);

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          result_flat = result._matrix,
          left_flat = left._matrix,
          right_flat = right._matrix)
          for (int i = 0; i < result_rows; i++)
            for (int j = 0; j < result_cols; j++)
            {
              sum = 0;
              for (int k = 0; k < left_cols; k++)
                sum += left_flat[i * left_cols + k] * right_flat[k * result_cols + j];
              result_flat[i * result_cols + j] = sum;
            }
      }
#else
      decimal[] result_flat = result._matrix;
      decimal[] left_flat = left._matrix;
      decimal[] right_flat = right._matrix;

      for (int i = 0; i < result_rows; i++)
        for (int j = 0; j < result_cols; j++)
        {
          sum = 0;
          for (int k = 0; k < left_cols; k++)
            sum += left_flat[i * left_cols + k] * right_flat[k * result_cols + j];
          result_flat[i * result_cols + j] = sum;
        }
#endif

      return result;
    }

    /// <summary>Performs multiplication on two matrices using multi-threading.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Matrix<decimal> Multiply_parrallel(Matrix<decimal> left, Matrix<decimal> right)
    {
#if no_error_checking
      // nothing
#else
      if (left == null)
        throw new Error("null reference: left");
      if (right == null)
        throw new Error("null reference: right");
      if (left.Columns != right.Rows)
        throw new LinearAlgebra.Error("invalid multiplication (dimension miss-match).");
#endif

      int result_rows = left.Rows;
      int left_cols = left.Columns;
      int result_cols = right.Columns;

      // If there are enough rows to warrant multi-threading,
      // then multithread the row for-loop.
      if (result_rows * result_cols > _parallelMinimum &&
        result_rows >= result_cols)
      {
        Matrix<decimal> result =
          new Matrix<decimal>(result_rows, result_cols);
#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                decimal sum;
                int left_i_offest;
                int result_i_offset;

                fixed (decimal*
                  result_flat = result._matrix,
                  left_flat = left._matrix,
                  right_flat = right._matrix)
                  for (int i = current; i < result_rows; i += max)
                  {
                    left_i_offest = i * left_cols;
                    result_i_offset = i * result_cols;
                    for (int j = 0; j < result_cols; j++)
                    {
                      sum = 0;
                      for (int k = 0; k < left_cols; k++)
                        sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                      result_flat[result_i_offset + j] = sum;
                    }
                  }
              };
            }, result_rows);
        }
#else
              decimal[] result_flat = result._matrix;
              decimal[] left_flat = left._matrix;
              decimal[] right_flat = right._matrix;

              Seven.Parallels.AutoParallel.Divide(
                  (int current, int max) =>
                  {
                    return () =>
                    {
                      decimal sum;
                      int left_i_offest;
                      int result_i_offset;

                      for (int i = current; i < result_rows; i += max)
                      {
                        left_i_offest = i * left_cols;
                        result_i_offset = i * result_cols;
                        for (int j = 0; j < result_cols; j++)
                        {
                          sum = 0;
                          for (int k = 0; k < left_cols; k++)
                            sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                          result_flat[result_i_offset + j] = sum;
                        }
                      }
                    };
                  }, result_rows);

#endif
        return result;
      }
      // If there are enough columns to warrant multi-threading,
      // then multithread the column for-loop.
      else if (result_rows * result_cols > _parallelMinimum &&
        result_rows < result_cols)
      {
        Matrix<decimal> result =
          new Matrix<decimal>(result_rows, result_cols);
#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                decimal sum;
                int left_i_offest;
                int result_i_offset;

                fixed (decimal*
                  result_flat = result._matrix,
                  left_flat = left._matrix,
                  right_flat = right._matrix)
                  for (int i = 0; i < result_rows; i++)
                  {
                    left_i_offest = i * left_cols;
                    result_i_offset = i * result_cols;
                    for (int j = current; j < result_cols; j += max)
                    {
                      sum = 0;
                      for (int k = 0; k < left_cols; k++)
                        sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                      result_flat[result_i_offset + j] = sum;
                    }
                  }
              };
            }, result_cols);
        }
#else
              decimal[] result_flat = result._matrix;
              decimal[] left_flat = left._matrix;
              decimal[] right_flat = right._matrix;

              Seven.Parallels.AutoParallel.Divide(
                  (int current, int max) =>
                  {
                    return () =>
                    {
                      decimal sum;
                      int left_i_offest;
                      int result_i_offset;

                      for (int i = 0; i < result_rows; i++)
                      {
                        left_i_offest = i * left_cols;
                        result_i_offset = i * result_cols;
                        for (int j = current; j < result_cols; j += max)
                        {
                          sum = 0;
                          for (int k = 0; k < left_cols; k++)
                            sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                          result_flat[result_i_offset + j] = sum;
                        }
                      }
                    };
                  }, result_cols);
#endif
        return result;
      }
      // Multi-threading is not necessary.
      else
        return LinearAlgebra.Multiply(left, right);
    }

    /// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Vector<decimal> Multiply(Matrix<decimal> left, Vector<decimal> right)
    {
      #region pre-optimization

      //Vector<decimal> result = 
      //  new Vector<decimal>(right.Dimensions);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i] += left[i, j] * right[j];
      //return result;

      #endregion

#if no_error_checking
      int left_row = left.Rows;
      int left_col = left.Columns;
#else
      int left_row = left.Rows;
      int left_col = left.Columns;
      if (left.Columns != right.Dimensions)
        throw new Error("invalid multiplication (size miss-match).");
#endif

      Vector<decimal> result = new Vector<decimal>(right.Dimensions);

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          left_flat = left._matrix,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < left_row; i++)
            for (int j = 0; j < left_col; j++)
              result_flat[i] += left_flat[i * left_col + j] * right_flat[j];
        return result;
      }
#else
      decimal[] left_flat = left._matrix;
      decimal[] right_flat = right._vector;
      decimal[] result_flat = result._vector;
      for (int i = 0; i < left_row; i++)
        for (int j = 0; j < left_col; j++)
          result_flat[i] += left_flat[i * left_col + j] * right_flat[j];
      return result;
#endif
      return result;
    }

    /// <summary>Multiplies all the values in a matrix by a scalar.</summary>
    /// <param name="left">The matrix to have the values multiplied.</param>
    /// <param name="right">The scalar to multiply the values by.</param>
    /// <returns>The resulting matrix after the multiplications.</returns>
    public static Matrix<decimal> Multiply(Matrix<decimal> left, decimal right)
    {
      #region pre-optimization

      //Matrix<decimal> result = 
      //  new Matrix<decimal>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] * right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      int rows = left.Rows;
      int columns = left.Columns;
      Matrix<decimal> result = new Matrix<decimal>(rows, columns);

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          left_flat = left._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
              result_flat[i * columns + j] = left_flat[i * columns + j] * right;
      }
#else
      for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
          result[i, j] = left[i, j] * right;
#endif

      return result;
    }

    /// <summary>Applies a power to a square matrix.</summary>
    /// <param name="matrix">The matrix to be powered by.</param>
    /// <param name="power">The power to apply to the matrix.</param>
    /// <returns>The resulting matrix of the power operation.</returns>
    public static Matrix<decimal> Power(Matrix<decimal> matrix, int power)
    {
      #region pre-optimization

      //Matrix<decimal> result = matrix.Clone();
      //for (int i = 0; i < power; i++)
      //  result = LinearAlgebra.Multiply(result, result);
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (!(matrix.Rows == matrix.Columns))
        throw new Error("invalid power (!matrix.IsSquare).");
      if (!(power >= 0))
        throw new Error("invalid power !(power > -1)");
#endif
      // this is not optimized...
      if (power == 0)
        return LinearAlgebra.MatrixFactoryIdentity_decimal(matrix.Rows, matrix.Columns);
      Matrix<decimal> result = matrix.Clone();
      for (int i = 0; i < power; i++)
        result = LinearAlgebra.Multiply(result, matrix);
      return result;
    }

    /// <summary>Divides all the values in the matrix by a scalar.</summary>
    /// <param name="matrix">The matrix to divide the values of.</param>
    /// <param name="right">The scalar to divide all the matrix values by.</param>
    /// <returns>The resulting matrix with the divided values.</returns>
    public static Matrix<decimal> Divide(Matrix<decimal> matrix, decimal right)
    {
      #region pre-optimization

      //Matrix<decimal> result = 
      //  new Matrix<decimal>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    result[i, j] = matrix[i, j] / right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      int matrix_row = matrix.Rows;
      int matrix_col = matrix.Columns;
      Matrix<decimal> result =
        new Matrix<decimal>(matrix_row, matrix_col);

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          matrix_flat = matrix._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < matrix_row; i++)
            for (int j = 0; j < matrix_col; j++)
              result_flat[i * matrix_col + j] =
                matrix_flat[i * matrix_col + j] / right;
      }
#else
      decimal[] matrix_flat = matrix._matrix;
      decimal[] result_flat = result._matrix;
      for (int i = 0; i < matrix_row; i++)
        for (int j = 0; j < matrix_col; j++)
          result_flat[i * matrix_col + j] = 
            matrix_flat[i * matrix_col + j] / right;

#endif
      return result;
    }

    /// <summary>Gets the minor of a matrix.</summary>
    /// <param name="matrix">The matrix to get the minor of.</param>
    /// <param name="row">The restricted row to form the minor.</param>
    /// <param name="column">The restricted column to form the minor.</param>
    /// <returns>The minor of the matrix.</returns>
    public static Matrix<decimal> Minor(Matrix<decimal> matrix, int row, int column)
    {
      #region pre-optimization

      //Matrix<decimal> minor = 
      //  new Matrix<decimal>(matrix.Rows - 1, matrix.Columns - 1);
      //int m = 0, n = 0;
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (i == row) continue;
      //  n = 0;
      //  for (int j = 0; j < matrix.Columns; j++)
      //  {
      //    if (j == column) continue;
      //    minor[m, n] = matrix[i, j];
      //    n++;
      //  }
      //  m++;
      //}
      //return minor;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows < 2 || matrix.Columns < 2)
        throw new Error("invalid matrix minor: (matrix.Rows < 2 || matrix.Columns < 2)");
      if (row < 0 || row >= matrix.Rows)
        throw new Error("invalid row on matrix minor: !(0 <= row < matrix.Rows)");
      if (column < 0 || row >= matrix.Columns)
        throw new Error("invalid column on matrix minor: !(0 <= column < matrix.Columns)");
#endif

      Matrix<decimal> minor =
        new Matrix<decimal>(matrix.Rows - 1, matrix.Columns - 1);
      int matrix_rows = matrix.Rows;
      int matrix_cols = matrix.Columns;

#if unsafe_code
      unsafe
      {
        fixed (decimal*
          matrix_flat = matrix._matrix,
          minor_flat = minor._matrix)
        {
          int m = 0, n = 0;
          for (int i = 0; i < matrix_rows; i++)
          {
            if (i == row) continue;
            n = 0;
            for (int j = 0; j < matrix_cols; j++)
            {
              if (j == column) continue;
              minor_flat[m * matrix_cols + n] =
                matrix_flat[i * matrix_cols + j];
              n++;
            }
            m++;
          }
        }
      }
#else
      int m = 0, n = 0;
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (i == row) continue;
        n = 0;
        for (int j = 0; j < matrix.Columns; j++)
        {
          if (j == column) continue;
          minor[m, n] = matrix[i, j];
          n++;
        }
        m++;
      }
#endif
      return minor;
    }

    /// <summary>Combines two matrices from left to right 
    /// (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
    /// <param name="left">The left matrix of the concatenation.</param>
    /// <param name="right">The right matrix of the concatenation.</param>
    /// <returns>The resulting matrix of the concatenation.</returns>
    public static Matrix<decimal> ConcatenateRowWise(Matrix<decimal> left, Matrix<decimal> right)
    {
      #region pre-optimization

      //Matrix<decimal> result =
      //  new Matrix<decimal>(left.Rows, left.Columns + right.Columns);
      //for (int i = 0; i < result.Rows; i++)
      //  for (int j = 0; j < result.Columns; j++)
      //    if (j < left.Columns)
      //      result[i, j] = left[i, j];
      //    else
      //      result[i, j] = right[i, j - left.Columns];
      //return result;

      #endregion

#if no_errorChecking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows)
        throw new Error("invalid row-wise concatenation !(left.Rows == right.Rows).");
#endif

      Matrix<decimal> result =
        new Matrix<decimal>(left.Rows, left.Columns + right.Columns);
      int result_rows = result.Rows;
      int result_cols = result.Columns;

      int left_cols = left.Columns;
      int right_cols = right.Columns;

#if unsafe_code
      unsafe
      {
        // OptimizeMe (jump statement)
        fixed (decimal*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < result_rows; i++)
            for (int j = 0; j < result_cols; j++)
              if (j < left_cols)
                result_flat[i * result_cols + j] =
                  left_flat[i * left_cols + j];
              else
                result_flat[i * result_cols + j] =
                  right_flat[i * right_cols + j - left_cols];
      }
#else
      for (int i = 0; i < result_rows; i++)
        for (int j = 0; j < result_cols; j++)
        {
          if (j < left.Columns)
            result[i, j] = left[i, j];
          else
            result[i, j] = right[i, j - left.Columns];
        }
#endif

      return result;
    }

    /// <summary>Calculates the echelon of a matrix (aka REF).</summary>
    /// <param name="matrix">The matrix to calculate the echelon of (aka REF).</param>
    /// <returns>The echelon of the matrix (aka REF).</returns>
    public static Matrix<decimal> Echelon(Matrix<decimal> matrix)
    {
      #region pre-optimization

      //Matrix<decimal> result = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (result[i, i] == 0)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] != 0)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  if (result[i, i] == 0)
      //    continue;
      //  if (result[i, i] != 1)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] == 1)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
      //  for (int j = i + 1; j < result.Rows; j++)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<decimal> result = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (result[i, i] == 0)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] != 0)
              LinearAlgebra.SwapRows(result, i, j);
        if (result[i, i] == 0)
          continue;
        if (result[i, i] != 1)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] == 1)
              LinearAlgebra.SwapRows(result, i, j);
        LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
        for (int j = i + 1; j < result.Rows; j++)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      }
      return result;
    }

    /// <summary>Calculates the echelon of a matrix and reduces it (aka RREF).</summary>
    /// <param name="matrix">The matrix matrix to calculate the reduced echelon of (aka RREF).</param>
    /// <returns>The reduced echelon of the matrix (aka RREF).</returns>
    public static Matrix<decimal> ReducedEchelon(Matrix<decimal> matrix)
    {
      #region pre-optimization

      //Matrix<decimal> result = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (result[i, i] == 0)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] != 0)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  if (result[i, i] == 0) continue;
      //  if (result[i, i] != 1)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] == 1)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
      //  for (int j = i + 1; j < result.Rows; j++)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      //  for (int j = i - 1; j >= 0; j--)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<decimal> result = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (result[i, i] == 0)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] != 0)
              LinearAlgebra.SwapRows(result, i, j);
        if (result[i, i] == 0) continue;
        if (result[i, i] != 1)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] == 1)
              LinearAlgebra.SwapRows(result, i, j);
        LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
        for (int j = i + 1; j < result.Rows; j++)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
        for (int j = i - 1; j >= 0; j--)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      }
      return result;
    }

    /// <summary>Calculates the determinent of a square matrix.</summary>
    /// <param name="matrix">The matrix to calculate the determinent of.</param>
    /// <returns>The determinent of the matrix.</returns>
    public static decimal Determinent(Matrix<decimal> matrix)
    {
      #region pre-optimization

      //decimal det = 1;
      //Matrix<decimal> rref = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (rref[i, i] == 0)
      //    for (int j = i + 1; j < rref.Rows; j++)
      //      if (rref[j, i] != 0)
      //      {
      //        LinearAlgebra.SwapRows(rref, i, j);
      //        det *= -1;
      //      }
      //  det *= rref[i, i];
      //  LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
      //  for (int j = i + 1; j < rref.Rows; j++)
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  for (int j = i - 1; j >= 0; j--)
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //}
      //return det;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        throw new Error("invalid matrix determinent: !(matrix.IsSquare)");
#endif

      decimal det = 1;
      Matrix<decimal> rref = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (rref[i, i] == 0)
          for (int j = i + 1; j < rref.Rows; j++)
            if (rref[j, i] != 0)
            {
              LinearAlgebra.SwapRows(rref, i, j);
              det *= -1;
            }
        det *= rref[i, i];
        LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
        for (int j = i + 1; j < rref.Rows; j++)
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        for (int j = i - 1; j >= 0; j--)
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      }
      return det;
    }

    /// <summary>Calculates the inverse of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the inverse of.</param>
    /// <returns>The inverse of the matrix.</returns>
    public static Matrix<decimal> Inverse(Matrix<decimal> matrix)
    {
      #region pre-optimization

      //Matrix<decimal> identity = 
      //  LinearAlgebra.MatrixFactoryIdentity_decimal(matrix.Rows, matrix.Columns);
      //Matrix<decimal> rref = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (rref[i, i] == 0)
      //    for (int j = i + 1; j < rref.Rows; j++)
      //      if (rref[j, i] != 0)
      //      {
      //        LinearAlgebra.SwapRows(rref, i, j);
      //        LinearAlgebra.SwapRows(identity, i, j);
      //      }
      //  LinearAlgebra.RowMultiplication(identity, i, 1 / rref[i, i]);
      //  LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
      //  for (int j = i + 1; j < rref.Rows; j++)
      //  {
      //    LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  }
      //  for (int j = i - 1; j >= 0; j--)
      //  {
      //    LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  }
      //}
      //return identity;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (LinearAlgebra.Determinent(matrix) == 0)
        throw new Error("inverse calculation failed.");
#endif

      Matrix<decimal> identity = LinearAlgebra.MatrixFactoryIdentity_decimal(matrix.Rows, matrix.Columns);
      Matrix<decimal> rref = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (rref[i, i] == 0)
          for (int j = i + 1; j < rref.Rows; j++)
            if (rref[j, i] != 0)
            {
              LinearAlgebra.SwapRows(rref, i, j);
              LinearAlgebra.SwapRows(identity, i, j);
            }
        LinearAlgebra.RowMultiplication(identity, i, 1 / rref[i, i]);
        LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
        for (int j = i + 1; j < rref.Rows; j++)
        {
          LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        }
        for (int j = i - 1; j >= 0; j--)
        {
          LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        }
      }
      return identity;
    }

    /// <summary>Calculates the adjoint of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the adjoint of.</param>
    /// <returns>The adjoint of the matrix.</returns>
    public static Matrix<decimal> Adjoint(Matrix<decimal> matrix)
    {
      #region pre-optimization

      //Matrix<decimal> AdjointMatrix = new Matrix<decimal>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    if ((i + j) % 2 == 0)
      //      AdjointMatrix[i, j] = LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      //    else
      //      AdjointMatrix[i, j] = -LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      //return LinearAlgebra.Transpose(AdjointMatrix);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (!(matrix.Rows == matrix.Columns))
        throw new Error("Adjoint of a non-square matrix does not exists");
#endif

      Matrix<decimal> AdjointMatrix = new Matrix<decimal>(matrix.Rows, matrix.Columns);
      for (int i = 0; i < matrix.Rows; i++)
        for (int j = 0; j < matrix.Columns; j++)
          if ((i + j) % 2 == 0)
            AdjointMatrix[i, j] = LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
          else
            AdjointMatrix[i, j] = -LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      return LinearAlgebra.Transpose(AdjointMatrix);
    }

    /// <summary>Returns the transpose of a matrix.</summary>
    /// <param name="matrix">The matrix to transpose.</param>
    /// <returns>The transpose of the matrix.</returns>
    public static Matrix<decimal> Transpose(Matrix<decimal> matrix)
    {
      #region pre-optimization

      //Matrix<decimal> transpose = 
      //  new Matrix<decimal>(matrix.Columns, matrix.Rows);
      //for (int i = 0; i < transpose.Rows; i++)
      //  for (int j = 0; j < transpose.Columns; j++)
      //    transpose[i, j] = matrix[j, i];
      //return transpose;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<decimal> transpose =
        new Matrix<decimal>(matrix.Columns, matrix.Rows);
      for (int i = 0; i < transpose.Rows; i++)
        for (int j = 0; j < transpose.Columns; j++)
          transpose[i, j] = matrix[j, i];
      return transpose;
    }

    /// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
    /// <param name="matrix">The matrix to decompose.</param>
    /// <param name="Lower">The computed lower triangular matrix.</param>
    /// <param name="Upper">The computed upper triangular matrix.</param>
    public static void DecomposeLU(Matrix<decimal> matrix, out Matrix<decimal> Lower, out Matrix<decimal> Upper)
    {
      #region pre-optimization

      //Lower = LinearAlgebra.MatrixFactoryIdentity_decimal(matrix.Rows, matrix.Columns);
      //Upper = matrix.Clone();
      //int[] permutation = new int[matrix.Rows];
      //for (int i = 0; i < matrix.Rows; i++) permutation[i] = i;
      //decimal p = 0, pom2, detOfP = 1;
      //int k0 = 0, pom1 = 0;
      //for (int k = 0; k < matrix.Columns - 1; k++)
      //{
      //  p = 0;
      //  for (int i = k; i < matrix.Rows; i++)
      //    if ((Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k]) > p)
      //    {
      //      p = Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k];
      //      k0 = i;
      //    }
      //  if (p == 0)
      //    throw new Error("The matrix is singular!");
      //  pom1 = permutation[k];
      //  permutation[k] = permutation[k0];
      //  permutation[k0] = pom1;
      //  for (int i = 0; i < k; i++)
      //  {
      //    pom2 = Lower[k, i];
      //    Lower[k, i] = Lower[k0, i];
      //    Lower[k0, i] = pom2;
      //  }
      //  if (k != k0)
      //    detOfP *= -1;
      //  for (int i = 0; i < matrix.Columns; i++)
      //  {
      //    pom2 = Upper[k, i];
      //    Upper[k, i] = Upper[k0, i];
      //    Upper[k0, i] = pom2;
      //  }
      //  for (int i = k + 1; i < matrix.Rows; i++)
      //  {
      //    Lower[i, k] = Upper[i, k] / Upper[k, k];
      //    for (int j = k; j < matrix.Columns; j++)
      //      Upper[i, j] = Upper[i, j] - Lower[i, k] * Upper[k, j];
      //  }
      //}

      #endregion

#if no_error_checking
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        throw new Error("non-square matrix during DecomposeLU function");
#endif

      Lower = LinearAlgebra.MatrixFactoryIdentity_decimal(matrix.Rows, matrix.Columns);
      Upper = matrix.Clone();
      int[] permutation = new int[matrix.Rows];
      for (int i = 0; i < matrix.Rows; i++) permutation[i] = i;
      decimal p = 0, pom2, detOfP = 1;
      int k0 = 0, pom1 = 0;
      for (int k = 0; k < matrix.Columns - 1; k++)
      {
        p = 0;
        for (int i = k; i < matrix.Rows; i++)
          if ((Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k]) > p)
          {
            p = Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k];
            k0 = i;
          }
        if (p == 0)
          throw new Error("The matrix is singular!");
        pom1 = permutation[k];
        permutation[k] = permutation[k0];
        permutation[k0] = pom1;
        for (int i = 0; i < k; i++)
        {
          pom2 = Lower[k, i];
          Lower[k, i] = Lower[k0, i];
          Lower[k0, i] = pom2;
        }
        if (k != k0)
          detOfP *= -1;
        for (int i = 0; i < matrix.Columns; i++)
        {
          pom2 = Upper[k, i];
          Upper[k, i] = Upper[k0, i];
          Upper[k0, i] = pom2;
        }
        for (int i = k + 1; i < matrix.Rows; i++)
        {
          Lower[i, k] = Upper[i, k] / Upper[k, k];
          for (int j = k; j < matrix.Columns; j++)
            Upper[i, j] = Upper[i, j] - Lower[i, k] * Upper[k, j];
        }
      }
    }

    private static void RowMultiplication(Matrix<decimal> matrix, int row, decimal scalar)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //  matrix[row, j] *= scalar;

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
        matrix[row, j] *= scalar;
    }

    private static void RowAddition(Matrix<decimal> matrix, int target, int second, decimal scalar)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //  matrix[target, j] += (matrix[second, j] * scalar);

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
        matrix[target, j] += (matrix[second, j] * scalar);
    }

    private static void SwapRows(Matrix<decimal> matrix, int row1, int row2)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //{
      //  decimal temp = matrix[row1, j];
      //  matrix[row1, j] = matrix[row2, j];
      //  matrix[row2, j] = temp;
      //}

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
      {
        decimal temp = matrix[row1, j];
        matrix[row1, j] = matrix[row2, j];
        matrix[row2, j] = temp;
      }
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Matrix<decimal> left, Matrix<decimal> right)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;
      //if (left.Rows != right.Rows || left.Columns != right.Columns)
      //  return false;
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    if (left[i, j] != right[i, j])
      //      return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Rows != right.Rows || left.Columns != right.Columns)
        return false;
      for (int i = 0; i < left.Rows; i++)
        for (int j = 0; j < left.Columns; j++)
          if (left[i, j] != right[i, j])
            return false;

      return true;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Matrix<decimal> left, Matrix<decimal> right, decimal leniency)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;
      //if (left.Rows != right.Rows || left.Columns != right.Columns)
      //  return false;
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    if (Logic.Abs(left[i, j] - right[i, j]) > leniency)
      //      return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        return false;
      for (int i = 0; i < left.Rows; i++)
        for (int j = 0; j < left.Columns; j++)
          if (Logic.Abs(left[i, j] - right[i, j]) > leniency)
            return false;
      return true;
    }

    #endregion

    #region quaterion

    /// <summary>Computes the length of quaternion.</summary>
    /// <param name="quaternion">The quaternion to compute the length of.</param>
    /// <returns>The length of the given quaternion.</returns>
    public static decimal Magnitude(Quaternion<decimal> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return Algebra.sqrt(
          (quaternion.X * quaternion.X +
          quaternion.Y * quaternion.Y +
          quaternion.Z * quaternion.Z +
          quaternion.W * quaternion.W));
    }

    /// <summary>Computes the length of a quaternion, but doesn't square root it
    /// for optimization possibilities.</summary>
    /// <param name="quaternion">The quaternion to compute the length squared of.</param>
    /// <returns>The squared length of the given quaternion.</returns>
    public static decimal MagnitudeSquared(Quaternion<decimal> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return
        quaternion.X * quaternion.X +
        quaternion.Y * quaternion.Y +
        quaternion.Z * quaternion.Z +
        quaternion.W * quaternion.W;
    }

    /// <summary>Gets the conjugate of the quaternion.</summary>
    /// <param name="quaternion">The quaternion to conjugate.</param>
    /// <returns>The conjugate of teh given quaternion.</returns>
    public static Quaternion<decimal> Conjugate(Quaternion<decimal> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return new Quaternion<decimal>(
        -quaternion.X,
        -quaternion.Y,
        -quaternion.Z,
        quaternion.W);
    }

    /// <summary>Adds two quaternions together.</summary>
    /// <param name="left">The first quaternion of the addition.</param>
    /// <param name="right">The second quaternion of the addition.</param>
    /// <returns>The result of the addition.</returns>
    public static Quaternion<decimal> Add(Quaternion<decimal> left, Quaternion<decimal> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<decimal>(
        left.X + right.X,
        left.Y + right.Y,
        left.Z + right.Z,
        left.W + right.W);
    }

    /// <summary>Subtracts two quaternions.</summary>
    /// <param name="left">The left quaternion of the subtraction.</param>
    /// <param name="right">The right quaternion of the subtraction.</param>
    /// <returns>The resulting quaternion after the subtraction.</returns>
    public static Quaternion<decimal> Subtract(Quaternion<decimal> left, Quaternion<decimal> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<decimal>(
        left.X - right.X,
        left.Y - right.Y,
        left.Z - right.Z,
        left.W - right.W);
    }

    /// <summary>Multiplies two quaternions together.</summary>
    /// <param name="left">The first quaternion of the multiplication.</param>
    /// <param name="right">The second quaternion of the multiplication.</param>
    /// <returns>The resulting quaternion after the multiplication.</returns>
    public static Quaternion<decimal> Multiply(Quaternion<decimal> left, Quaternion<decimal> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<decimal>(
        left.X * right.W + left.W * right.X + left.Y * right.Z - left.Z * right.Y,
        left.Y * right.W + left.W * right.Y + left.Z * right.X - left.X * right.Z,
        left.Z * right.W + left.W * right.Z + left.X * right.Y - left.Y * right.X,
        left.W * right.W - left.X * right.X - left.Y * right.Y - left.Z * right.Z);
    }

    /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
    /// <param name="left">The quaternion of the multiplication.</param>
    /// <param name="right">The scalar of the multiplication.</param>
    /// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
    public static Quaternion<decimal> Multiply(Quaternion<decimal> left, decimal right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      return new Quaternion<decimal>(
        left.X * right,
        left.Y * right,
        left.Z * right,
        left.W * right);
    }

    /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
    /// <param name="left">The quaternion to pre-multiply the vector by.</param>
    /// <param name="right">The vector to be multiplied.</param>
    /// <returns>The resulting quaternion of the multiplication.</returns>
    public static Quaternion<decimal> Multiply(Quaternion<decimal> left, Vector<decimal> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (right.Dimensions != 3)
        throw new Error("my quaternion rotations are only defined for 3-component vectors.");
#endif

      return new Quaternion<decimal>(
        left.W * right.X + left.Y * right.Z - left.Z * right.Y,
        left.W * right.Y + left.Z * right.X - left.X * right.Z,
        left.W * right.Z + left.X * right.Y - left.Y * right.X,
        -left.X * right.X - left.Y * right.Y - left.Z * right.Z);
    }

    /// <summary>Normalizes the quaternion.</summary>
    /// <param name="quaternion">The quaternion to normalize.</param>
    /// <returns>The normalization of the given quaternion.</returns>
    public static Quaternion<decimal> Normalize(Quaternion<decimal> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      decimal normalizer = Quaternion<decimal>.Magnitude(quaternion);
      if (normalizer != 0)
        return quaternion * (1 / normalizer);
      else
        return Quaternion<decimal>.FactoryIdentity;
    }

    /// <summary>Inverts a quaternion.</summary>
    /// <param name="quaternion">The quaternion to find the inverse of.</param>
    /// <returns>The inverse of the given quaternion.</returns>
    public static Quaternion<decimal> Invert(Quaternion<decimal> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      decimal normalizer = Quaternion<decimal>.MagnitudeSquared(quaternion);
      if (normalizer == 0)
        return new Quaternion<decimal>(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
      normalizer = 1 / normalizer;
      return new Quaternion<decimal>(
        -quaternion.X * normalizer,
        -quaternion.Y * normalizer,
        -quaternion.Z * normalizer,
        quaternion.W * normalizer);
    }

    /// <summary>Lenearly interpolates between two quaternions.</summary>
    /// <param name="left">The starting point of the interpolation.</param>
    /// <param name="right">The ending point of the interpolation.</param>
    /// <param name="blend">The ratio 0.0-1.0 of how far to interpolate between the left and right quaternions.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Quaternion<decimal> Lerp(Quaternion<decimal> left, Quaternion<decimal> right, decimal blend)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      if (blend < 0 || blend > 1)
        throw new Error("invalid blending value during lerp !(blend < 0.0f || blend > 1.0f).");
      if (Quaternion<decimal>.MagnitudeSquared(left) == 0)
      {
        if (Quaternion<decimal>.MagnitudeSquared(right) == 0)
          return Quaternion<decimal>.FactoryIdentity;
        else
          return new Quaternion<decimal>(right.X, right.Y, right.Z, right.W);
      }
      else if (Quaternion<decimal>.MagnitudeSquared(right) == 0)
        return new Quaternion<decimal>(left.X, left.Y, left.Z, left.W);
      Quaternion<decimal> result = new Quaternion<decimal>(
        1 - blend * left.X + blend * right.X,
        1 - blend * left.Y + blend * right.Y,
        1 - blend * left.Z + blend * right.Z,
        1 - blend * left.W + blend * right.W);
      if (Quaternion<decimal>.MagnitudeSquared(result) > 0)
        return Quaternion<decimal>.Normalize(result);
      else
        return Quaternion<decimal>.FactoryIdentity;
    }

    /// <summary>Sphereically interpolates between two quaternions.</summary>
    /// <param name="left">The starting point of the interpolation.</param>
    /// <param name="right">The ending point of the interpolation.</param>
    /// <param name="blend">The ratio of how far to interpolate between the left and right quaternions.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Quaternion<decimal> Slerp(Quaternion<decimal> left, Quaternion<decimal> right, decimal blend)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      if (blend < 0 || blend > 1)
        throw new Error("invalid blending value during slerp !(blend < 0.0f || blend > 1.0f).");
      if (LinearAlgebra.MagnitudeSquared(left) == 0)
      {
        if (LinearAlgebra.MagnitudeSquared(right) == 0)
          return Quaternion<decimal>.FactoryIdentity;
        else
          return new Quaternion<decimal>(right.X, right.Y, right.Z, right.W);
      }
      else if (LinearAlgebra.MagnitudeSquared(right) == 0)
        return new Quaternion<decimal>(left.X, left.Y, left.Z, left.W);
      decimal cosHalfAngle = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
      if (cosHalfAngle >= 1 || cosHalfAngle <= -1)
        return new Quaternion<decimal>(left.X, left.Y, left.Z, left.W);
      else if (cosHalfAngle < 0)
      {
        right = new Quaternion<decimal>(-left.X, -left.Y, -left.Z, -left.W);
        cosHalfAngle = -cosHalfAngle;
      }
      decimal halfAngle = Trigonometry.arccos(cosHalfAngle);
      decimal sinHalfAngle = Trigonometry.sin(halfAngle);
      decimal blendA = Trigonometry.sin(halfAngle * (1 - blend)) / sinHalfAngle;
      decimal blendB = Trigonometry.sin(halfAngle * blend) / sinHalfAngle;
      Quaternion<decimal> result = new Quaternion<decimal>(
        blendA * left.X + blendB * right.X,
        blendA * left.Y + blendB * right.Y,
        blendA * left.Z + blendB * right.Z,
        blendA * left.W + blendB * right.W);
      if (LinearAlgebra.MagnitudeSquared(result) > 0)
        return LinearAlgebra.Normalize(result);
      else
        return Quaternion<decimal>.FactoryIdentity;
    }

    /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
    /// <param name="rotation">The quaternion to rotate the vector by.</param>
    /// <param name="vector">The vector to be rotated by.</param>
    /// <returns>The result of the rotation.</returns>
    public static Vector<decimal> Rotate(Quaternion<decimal> rotation, Vector<decimal> vector)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(rotation, null))
        throw new Error("null reference: rotation");
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      if (vector.Dimensions != 3 && vector.Dimensions != 4)
        throw new Error("my quaternion rotations are only defined for 3-component vectors.");
      Quaternion<decimal> answer = LinearAlgebra.Multiply(LinearAlgebra.Multiply(rotation, vector), LinearAlgebra.Conjugate(rotation));
      return new Vector<decimal>(answer.X, answer.Y, answer.Z);
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first quaternion to check for equality.</param>
    /// <param name="right">The second quaternion  to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Quaternion<decimal> left, Quaternion<decimal> right)
    {
      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      return
        left.X == right.X &&
        left.Y == right.Y &&
        left.Z == right.Z &&
        left.W == right.W;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first quaternion to check for equality.</param>
    /// <param name="right">The second quaternion to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Quaternion<decimal> left, Quaternion<decimal> right, decimal leniency)
    {
      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      return
        Logic.Abs(left.X - right.X) < leniency &&
        Logic.Abs(left.Y - right.Y) < leniency &&
        Logic.Abs(left.Z - right.Z) < leniency &&
        Logic.Abs(left.W - right.W) < leniency;
    }

    #endregion

    #region tableau

    //const decimal epsilon = 1.0e-8;
    ////int equal(decimal a, decimal b) { return fabs(a - b) < epsilon; }

    //static void pivot_on(ref decimal[,] tableau, int row, int col)
    //{
    //  int i, j;
    //  decimal pivot;

    //  pivot = tableau[row, col];
    //  if (!(pivot > 0))
    //    throw new Error("possible invalid tableau values (IDK)");
    //  for (j = 0; j < tableau.GetLength(1); j++)
    //    tableau[row, j] /= pivot;
    //  if (!(Logic.Equate(tableau[row, col], 1, epsilon)))
    //    throw new Error("possible invalid tableau values (IDK)");

    //  for (i = 0; i < tableau.GetLength(0); i++)
    //  { // foreach remaining row i do
    //    decimal multiplier = tableau[i, col];
    //    if (i == row) continue;
    //    for (j = 0; j < tableau.GetLength(1); j++)
    //    { // r[i] = r[i] - z * r[row];
    //      tableau[i, j] -= multiplier * tableau[row, j];
    //    }
    //  }
    //}

    //// Find pivot_col = most negative column in mat[0][1..n]
    //static int find_pivot_column(ref decimal[,] tableau)
    //{
    //  int j, pivot_col = 1;
    //  decimal lowest = tableau[0, pivot_col];
    //  for (j = 1; j < tableau.GetLength(1); j++)
    //  {
    //    if (tableau[0, j] < lowest)
    //    {
    //      lowest = tableau[0, j];
    //      pivot_col = j;
    //    }
    //  }
    //  //printf("Most negative column in row[0] is col %d = %g.\n", pivot_col, lowest);
    //  if (lowest >= 0)
    //  {
    //    return -1; // All positive columns in row[0], this is optimal.
    //  }
    //  return pivot_col;
    //}

    //// Find the pivot_row, with smallest positive ratio = col[0] / col[pivot]
    //static int find_pivot_row(ref decimal[,] tableau, int pivot_col)
    //{
    //  int i, pivot_row = 0;
    //  decimal min_ratio = -1;
    //  //printf("Ratios A[row_i,0]/A[row_i,%d] = [", pivot_col);
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    decimal ratio = tableau[i, 0] / tableau[i, pivot_col];
    //    //printf("%3.2lf, ", ratio);
    //    if ((ratio > 0 && ratio < min_ratio) || min_ratio < 0)
    //    {
    //      min_ratio = ratio;
    //      pivot_row = i;
    //    }
    //  }
    //  //printf("].\n");
    //  if (min_ratio == -1)
    //    return -1; // Unbounded.
    //  //printf("Found pivot A[%d,%d], min positive ratio=%g in row=%d.\n",
    //  //  pivot_row, pivot_col, min_ratio, pivot_row);
    //  return pivot_row;
    //}

    //static void add_slack_variables(ref decimal[,] tableau)
    //{

    //  decimal[,] newTableau =
    //    new decimal[tableau.GetLength(0), tableau.GetLength(1) + tableau.GetLength(0) - 1];

    //  for (int a = 0, a_max = tableau.GetLength(0); a < a_max; a++)
    //    for (int b = 0, b_max = tableau.GetLength(1); b < b_max; b++)
    //      newTableau[a, b] = tableau[a, b];

    //  int i, j;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    for (j = 1; j < tableau.GetLength(0); j++)
    //      newTableau[i, j + tableau.GetLength(1) - 1] = (i == j ? 1d : 0d);
    //  }

    //  tableau = newTableau;
    //}

    //static void check_b_positive(ref decimal[,] tableau)
    //{
    //  int i;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //    if (!(tableau[i, 0] >= 0))
    //      throw new Error("possible invalid tableau values (IDK)");
    //}

    //// Given a column of identity matrix, find the row containing 1.
    //// return -1, if the column as not from an identity matrix.
    //static int find_basis_variable(ref decimal[,] tableau, int col)
    //{
    //  int i, xi = -1;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    if (Logic.Equate(tableau[i, col], 1, epsilon))
    //      if (xi == -1)
    //        xi = i;   // found first '1', save this row number.
    //      else
    //        return -1; // found second '1', not an identity matrix.
    //    else if (!Logic.Equate(tableau[i, col], 0, epsilon))
    //      return -1; // not an identity matrix column.
    //  }
    //  return xi;
    //}

    //static decimal[] print_optimal_vector(ref decimal[,] tableau)
    //{
    //  decimal[] vector = new decimal[tableau.GetLength(1)];
    //  int j, xi;
    //  //printf("%s at ", message);
    //  for (j = 1; j < tableau.GetLength(1); j++)
    //  { // for each column.
    //    xi = find_basis_variable(ref tableau, j);
    //    if (xi != -1)
    //      vector[j] = tableau[xi, 0];
    //    else
    //      vector[j] = j;
    //  }
    //  return vector;
    //}

    //public static decimal[] Simplex(ref decimal[,] tableau)
    //{
    //  int loop = 0;
    //  add_slack_variables(ref tableau);
    //  check_b_positive(ref tableau);
    //  while (++loop > 0)
    //  {
    //    int pivot_col, pivot_row;

    //    pivot_col = find_pivot_column(ref tableau);
    //    if (pivot_col < 0)
    //      //printf("Found optimal value=A[0,0]=%3.2lf (no negatives in row 0).\n",
    //      //  tableau->mat[0][0]);
    //      return print_optimal_vector(ref tableau);
    //    //printf("Entering variable x%d to be made basic, so pivot_col=%d.\n",
    //    //  pivot_col, pivot_col);

    //    pivot_row = find_pivot_row(ref tableau, pivot_col);
    //    if (pivot_row < 0)
    //      throw new Error("unbounded (no pivot_row)");
    //    //printf("Leaving variable x%d, so pivot_row=%d\n", pivot_row, pivot_row);

    //    pivot_on(ref tableau, pivot_row, pivot_col);
    //    //print_tableau(tableau, "After pivoting");
    //    //return print_optimal_vector(ref tableau);
    //  }
    //  throw new Error("Simplex has a glitch");
    //}

    #endregion

    #endregion

    #region double

    #region vector

    /// <summary>Adds two vectors together.</summary>
    /// <param name="left">The first vector of the addition.</param>
    /// <param name="right">The second vector of the addiiton.</param>
    /// <returns>The result of the addiion.</returns>
    public static Vector<double> Add(Vector<double> left, Vector<double> right)
    {
      #region pre-optimization

      //Vector<double> result =
      //  new Vector<double>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] + right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector addition.");
#endif

      int length = left.Dimensions;
      Vector<double> result = 
        new Vector<double>(left.Dimensions);

#if unsafe_code
      unsafe
      {
        fixed (double*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
      }
#else
      double[] left_flat = left._vector;
      double[] right_flat = right._vector;
      double[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
#endif

      return result;
    }

    /// <summary>Negates all the values in a vector.</summary>
    /// <param name="vector">The vector to have its values negated.</param>
    /// <returns>The result of the negations.</returns>
    public static Vector<double> Negate(Vector<double> vector)
    {
      #region pre-optimization

      //Vector<double> result =
      //  new Vector<double>(vector.Dimensions);
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result[i] = -vector[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Vector<double> result =
        new Vector<double>(length);

#if unsafe_code
      unsafe
      {
        fixed (double*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = -vector_flat[i];
      }
#else
      double[] vector_flat = vector._vector;
      double[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = -vector_flat[i];
#endif

      return result;
    }

    /// <summary>Subtracts two vectors.</summary>
    /// <param name="left">The left vector of the subtraction.</param>
    /// <param name="right">The right vector of the subtraction.</param>
    /// <returns>The result of the vector subtracton.</returns>
    public static Vector<double> Subtract(Vector<double> left, Vector<double> right)
    {
      #region pre-optimization

      //Vector<double> result =
      //  new Vector<double>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] - right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector subtraction.");
#endif

      int length = left.Dimensions;
      Vector<double> result =
        new Vector<double>(length);

#if unsafe_code
      unsafe
      {
        fixed (double*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] - right_flat[i];
      }
#else
      double[] left_flat = left._vector;
      double[] right_flat = right._vector;
      double[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] - right_flat[i];
#endif

      return result;
    }

    /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
    /// <param name="left">The vector to have the components multiplied by.</param>
    /// <param name="right">The scalars to multiply the vector components by.</param>
    /// <returns>The result of the multiplications.</returns>
    public static Vector<double> Multiply(Vector<double> left, double right)
    {
      #region pre-optimization

      //Vector<double> result =
      //  new Vector<double>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] * right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      int length = left.Dimensions;
      Vector<double> result =
        new Vector<double>(length);

#if unsafe_code
      unsafe
      {
        fixed (double*
          left_flat = left._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] * right;
      }
#else
      double[] left_flat = left._vector;
      double[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] * right;
#endif

      return result;
    }

    /// <summary>Divides all the components of a vector by a scalar.</summary>
    /// <param name="vector">The vector to have the components divided by.</param>
    /// <param name="right">The scalar to divide the vector components by.</param>
    /// <returns>The resulting vector after teh divisions.</returns>
    public static Vector<double> Divide(Vector<double> vector, double right)
    {
      #region pre-optimization

      //Vector<double> result =
      //  new Vector<double>(vector.Dimensions);
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result[i] = vector[i] / right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: left");
#endif

      int length = vector.Dimensions;
      Vector<double> result =
        new Vector<double>(length);

#if unsafe_code
      unsafe
      {
        fixed (double*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = vector_flat[i] / right;
      }
#else
      double[] vector_flat = vector._vector;
      double[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = vector_flat[i] / right;
#endif

      return result;
    }

    /// <summary>Computes the dot product between two vectors.</summary>
    /// <param name="left">The first vector of the dot product operation.</param>
    /// <param name="right">The second vector of the dot product operation.</param>
    /// <returns>The result of the dot product operation.</returns>
    public static double DotProduct(Vector<double> left, Vector<double> right)
    {
      #region pre-optimization

      //double result = 0;
      //for (int i = 0; i < left.Dimensions; i++)
      //  result += left[i] * right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector dot product.");
#endif

      int length = left.Dimensions;
      double result = 0;

#if unsafe_code
      unsafe
      {
        fixed (double*
          left_flat = left._vector,
          right_flat = right._vector)
          for (int i = 0; i < length; i++)
            result += left_flat[i] * right_flat[i];
      }
#else
      double[] left_flat = left._vector;
      double[] right_flat = right._vector;
      for (int i = 0; i < length; i++)
        result += left_flat[i] * right_flat[i];
#endif

      return result;
    }

    /// <summary>Computes teh cross product of two vectors.</summary>
    /// <param name="left">The first vector of the cross product operation.</param>
    /// <param name="right">The second vector of the cross product operation.</param>
    /// <returns>The result of the cross product operation.</returns>
    public static Vector<double> CrossProduct(Vector<double> left, Vector<double> right)
    {
      #region pre-optimization

      //Vector<double> result = new Vector<double>(3);
      //result[0] = left[1] * right[2] - left[2] * right[1];
      //result[1] = left[2] * right[0] - left[0] * right[2];
      //result[2] = left[0] * right[1] - left[1] * right[0];

      #endregion

#if no_error_checking

#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid cross product (left.Dimensions != right.Dimensions)");
      if (left.Dimensions != 3)
        throw new Error("my cross product function is only defined for 3-component vectors.");
#endif

      Vector<double> result = 
        new Vector<double>(3);

#if unsafe_code
      unsafe
      {
        fixed (double*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
        {
          result_flat[0] = left_flat[1] * right_flat[2] - left_flat[2] * right_flat[1];
          result_flat[1] = left_flat[2] * right_flat[0] - left_flat[0] * right_flat[2];
          result_flat[2] = left_flat[0] * right_flat[1] - left_flat[1] * right_flat[0];
        }
      }
#else
      double[] left_flat = left._vector;
      double[] right_flat = right._vector;
      double[] result_flat = result._vector;
      result_flat[0] = left_flat[1] * right_flat[2] - left_flat[2] * right_flat[1];
      result_flat[1] = left_flat[2] * right_flat[0] - left_flat[0] * right_flat[2];
      result_flat[2] = left_flat[0] * right_flat[1] - left_flat[1] * right_flat[0];
#endif

      return result;
    }

    /// <summary>Normalizes a vector.</summary>
    /// <param name="vector">The vector to normalize.</param>
    /// <returns>The result of the normalization.</returns>
    public static Vector<double> Normalize(Vector<double> vector)
    {
      #region pre-optimization

      //double magnitude = LinearAlgebra.Magnitude(vector);
      //if (magnitude != 0)
      //{
      //  Vector<double> result = 
      //    new Vector<double>(vector.Dimensions);
      //  for (int i = 0; i < vector.Dimensions; i++)
      //    result[i] = vector[i] / magnitude;
      //  return result;
      //}
      //else
      //  return new double[vector.Dimensions];

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Vector<double> result =
        new Vector<double>(vector.Dimensions);
      double magnitude = LinearAlgebra.Magnitude(vector);
      if (magnitude != 0)
        return result;

#if unsafe_code
      unsafe
      {
        fixed (double*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = vector_flat[i] / magnitude;
      }
#else
      double[] vector_flat = vector._vector;
      double[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = vector_flat[i] / magnitude;
#endif

      return result;
      
    }

    /// <summary>Computes the length of a vector.</summary>
    /// <param name="vector">The vector to calculate the length of.</param>
    /// <returns>The computed length of the vector.</returns>
    public static double Magnitude(Vector<double> vector)
    {
      #region pre-optimization

      //double result = 0;
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result += vector[i] * vector[i];
      //return Algebra.sqrt(result);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      double result = 0;

#if unsafe_code
      unsafe
      {
        fixed (double*
          vector_flat = vector._vector)
          for (int i = 0; i < length; i++)
            result += vector_flat[i] * vector_flat[i];
      }
#else
      double[] vector_flat = vector._vector;
      for (int i = 0; i < length; i++)
        result += vector_flat[i] * vector_flat[i];
#endif

      return Algebra.sqrt(result);
    }

    /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
    /// <param name="vector">The vector to compute the length squared of.</param>
    /// <returns>The computed length squared of the vector.</returns>
    public static double MagnitudeSquared(Vector<double> vector)
    {
      #region pre-optimization

      //double result = 0;
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result += vector[i] * vector[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      double result = 0;

#if unsafe_code
      unsafe
      {
        fixed (double*
          vector_flat = vector._vector)
          for (int i = 0; i < length; i++)
            result += vector_flat[i] * vector_flat[i];
      }
#else
      double[] vector_flat = vector._vector;
      for (int i = 0; i < length; i++)
        result += vector_flat[i] * vector_flat[i];
#endif

      return result;
    }

    /// <summary>Computes the angle between two vectors.</summary>
    /// <param name="first">The first vector to determine the angle between.</param>
    /// <param name="second">The second vector to determine the angle between.</param>
    /// <returns>The angle between the two vectors in radians.</returns>
    public static double Angle(Vector<double> first, Vector<double> second)
    {
      #region pre-optimization

      //return Trigonometry.arccos(
      //  LinearAlgebra.DotProduct(first, second) / 
      //  (LinearAlgebra.Magnitude(first) * 
      //  LinearAlgebra.Magnitude(second)));

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(first, null))
        throw new Error("null reference: first");
      if (object.ReferenceEquals(second, null))
        throw new Error("null reference: second");
#endif

      return Trigonometry.arccos(
        LinearAlgebra.DotProduct(first, second) /
        (LinearAlgebra.Magnitude(first) *
        LinearAlgebra.Magnitude(second)));
    }

    /// <summary>Rotates a 3-component vector by the specified axis and rotation values.</summary>
    /// <param name="vector">The vector to rotate.</param>
    /// <param name="angle">The angle of the rotation in radians.</param>
    /// <param name="x">The x component of the axis vector to rotate about.</param>
    /// <param name="y">The y component of the axis vector to rotate about.</param>
    /// <param name="z">The z component of the axis vector to rotate about.</param>
    /// <returns>The result of the rotation.</returns>
    public static Vector<double> RotateBy(Vector<double> vector, double angle, double x, double y, double z)
    {
      #region pre-optimization

      //double sinHalfAngle = Trigonometry.sin(angle / 2);
      //double cosHalfAngle = Trigonometry.cos(angle / 2);
      //x *= sinHalfAngle;
      //y *= sinHalfAngle;
      //z *= sinHalfAngle;
      //double x2 = cosHalfAngle * vector[0] + y * vector[2] - z * vector[1];
      //double y2 = cosHalfAngle * vector[1] + z * vector[0] - x * vector[2];
      //double z2 = cosHalfAngle * vector[2] + x * vector[1] - y * vector[0];
      //double w2 = -x * vector[0] - y * vector[1] - z * vector[2];
      //Vector<double> result = new Vector<double>();
      //result[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
      //result[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
      //result[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
      if (vector.Dimensions == 3)
        throw new Error("my RotateBy() function is only defined for 3-component vectors.");
#endif

      Vector<double> result = new Vector<double>(3);
      double sinHalfAngle = Trigonometry.sin(angle / 2);
      double cosHalfAngle = Trigonometry.cos(angle / 2);
      x *= sinHalfAngle;
      y *= sinHalfAngle;
      z *= sinHalfAngle;

#if unsafe_code
      unsafe
      {
        fixed (double*
          vector_flat = vector._vector,
          result_flat = result._vector)
        {
          double x2 = cosHalfAngle * vector_flat[0] + y * vector_flat[2] - z * vector_flat[1];
          double y2 = cosHalfAngle * vector_flat[1] + z * vector_flat[0] - x * vector_flat[2];
          double z2 = cosHalfAngle * vector_flat[2] + x * vector_flat[1] - y * vector_flat[0];
          double w2 = -x * vector_flat[0] - y * vector_flat[1] - z * vector_flat[2];
          result_flat[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
          result_flat[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
          result_flat[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;
        }
      }
#else
      double[] vector_flat = vector._vector;
      double[] result_flat = result._vector;
      double x2 = cosHalfAngle * vector_flat[0] + y * vector_flat[2] - z * vector_flat[1];
      double y2 = cosHalfAngle * vector_flat[1] + z * vector_flat[0] - x * vector_flat[2];
      double z2 = cosHalfAngle * vector_flat[2] + x * vector_flat[1] - y * vector_flat[0];
      double w2 = -x * vector_flat[0] - y * vector_flat[1] - z * vector_flat[2];
      result_flat[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
      result_flat[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
      result_flat[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;
#endif

      return result;
    }

    /// <summary>Rotates a vector by a quaternion rotation.</summary>
    /// <param name="vector">The vector to be rotated.</param>
    /// <param name="quaternion">The rotation to be applied.</param>
    /// <returns>The vector after the rotation.</returns>
    public static Vector<double> RotateBy(Vector<double> vector, Quaternion<double> quaternion)
    {
      return Rotate(quaternion, vector);
    }

    /// <summary>Computes the linear interpolation between two vectors.</summary>
    /// <param name="left">The starting vector of the interpolation.</param>
    /// <param name="right">The ending vector of the interpolation.</param>
    /// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Vector<double> Lerp(Vector<double> left, Vector<double> right, double blend)
    {
      #region pre-optimization

      //Vector<double> result = new Vector<double>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] + blend * (right[i] - left[i]);
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (blend < 0 || blend > 1)
        throw new Error("invalid vector lerp blend value: (blend < 0.0f || blend > 1.0f).");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid vector lerp length: (left.Dimensions != right.Dimensions)");
#endif

      int length = left.Dimensions;
      Vector<double> result = 
        new Vector<double>(length);

#if unsafe_code
      unsafe
      {
        fixed (double*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + blend * (right_flat[i] - left_flat[i]);
      }
#else
      double[] left_flat = left._vector;
      double[] right_flat = right._vector;
      double[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] + blend * (right_flat[i] - left_flat[i]);
#endif

      return result;
    }

    /// <summary>Sphereically interpolates between two vectors.</summary>
    /// <param name="left">The starting vector of the interpolation.</param>
    /// <param name="right">The ending vector of the interpolation.</param>
    /// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
    /// <returns>The result of the slerp operation.</returns>
    public static Vector<double> Slerp(Vector<double> left, Vector<double> right, double blend)
    {
      #region pre-optimization

      //double dot = LinearAlgebra.DotProduct(left, right);
      //dot = dot < -1 ? -1 : dot;
      //dot = dot > 1 ? 1 : dot;
      //double theta = Trigonometry.arccos(dot) * blend;
      //return LinearAlgebra.Multiply(LinearAlgebra.Add(LinearAlgebra.Multiply(left, Trigonometry.cos(theta)),
      //  LinearAlgebra.Normalize(LinearAlgebra.Subtract(right, LinearAlgebra.Multiply(left, dot)))), Trigonometry.sin(theta));

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (blend < 0 || blend > 1)
        throw new Error("invalid slerp blend value: (blend < 0.0f || blend > 1.0f).");
#endif

      double dot = LinearAlgebra.DotProduct(left, right);
      dot = dot < -1 ? -1 : dot;
      dot = dot > 1 ? 1 : dot;
      double theta = Trigonometry.arccos(dot) * blend;
      return LinearAlgebra.Multiply(LinearAlgebra.Add(LinearAlgebra.Multiply(left, Trigonometry.cos(theta)),
        LinearAlgebra.Normalize(LinearAlgebra.Subtract(right, LinearAlgebra.Multiply(left, dot)))), Trigonometry.sin(theta));
    }

    /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
    /// <param name="a">The first vector of the interpolation.</param>
    /// <param name="b">The second vector of the interpolation.</param>
    /// <param name="c">The thrid vector of the interpolation.</param>
    /// <param name="u">The "U" value of the barycentric interpolation equation.</param>
    /// <param name="v">The "V" value of the barycentric interpolation equation.</param>
    /// <returns>The resulting vector of the barycentric interpolation.</returns>
    public static Vector<double> Blerp(Vector<double> a, Vector<double> b, Vector<double> c, double u, double v)
    {
      #region pre-optimization

      //return 
      //  LinearAlgebra.Add(
      //    LinearAlgebra.Add(
      //      LinearAlgebra.Multiply(
      //        LinearAlgebra.Subtract(b, a), u),
      //          LinearAlgebra.Multiply(
      //            LinearAlgebra.Subtract(c, a), v)), a);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(a, null))
        throw new Error("null reference: a");
      if (object.ReferenceEquals(b, null))
        throw new Error("null reference: b");
      if (object.ReferenceEquals(c, null))
        throw new Error("null reference: c");
#endif

      return
        LinearAlgebra.Add(
          LinearAlgebra.Add(
            LinearAlgebra.Multiply(
              LinearAlgebra.Subtract(b, a), u),
                LinearAlgebra.Multiply(
                  LinearAlgebra.Subtract(c, a), v)), a);
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Vector<double> left, Vector<double> right)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;

      //if (left.Dimensions != right.Dimensions)
      //  return false;
      //for (int i = 0; i < left.Dimensions; i++)
      //  if (left[i] != right[i])
      //    return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Dimensions != right.Dimensions)
        return false;
      for (int i = 0; i < left.Dimensions; i++)
        if (left[i] != right[i])
          return false;
      return true;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Vector<double> left, Vector<double> right, double leniency)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;

      //if (left.Dimensions != right.Dimensions)
      //  return false;
      //for (int i = 0; i < left.Dimensions; i++)
      //  if (Logic.Abs(left[i] - right[i]) > leniency)
      //    return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Dimensions != right.Dimensions)
        return false;
      for (int i = 0; i < left.Dimensions; i++)
        if (Logic.Abs(left[i] - right[i]) > leniency)
          return false;
      return true;
    }

    #endregion

    #region matrix

    /// <summary>Determines if a matrix is symetric or not.</summary>
    /// <param name="matrix">The matrix to determine symetry of.</param>
    /// <returns>True if symetric; false if not.</returns>
    public static bool IsSymmetric(Matrix<double> matrix)
    {
      #region pre-optimization

      //if (matrix.Rows != matrix.Columns)
      //  return false;
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    if (matrix[i, j] != matrix[j, i])
      //      return false;
      //return true;

      #endregion

#if no_errorchecking
      //nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        return false;
#endif
      int size = matrix.Columns;
#if unsafe_code
      unsafe
      {
        fixed (double* matrix_flat = matrix._matrix)
          for (var row = 0; row < size; row++)
            for (var column = row + 1; column < size; column++)
              if (matrix_flat[row * size + column] != matrix_flat[column * size + row])
                return false;
      }
#else
      double[] matrix_flat = matrix._matrix;
      for (var row = 0; row < size; row++)
        for (var column = row + 1; column < size; column++)
          if (matrix_flat[row * size + column] != matrix_flat[column * size + row])
            return false;
#endif
      return true;
    }
    
    /// <summary>Constructs a new identity-matrix of the given dimensions.</summary>
    /// <param name="rows">The number of rows of the matrix.</param>
    /// <param name="columns">The number of columns of the matrix.</param>
    /// <returns>The newly constructed identity-matrix.</returns>
    public static Matrix<double> MatrixFactoryIdentity_double(int rows, int columns)
    {
      #region pre-optimization

      //Matrix<double> matrix = 
      //  new Matrix<double>(rows, columns);
      //for (int i = 0; i < Logic.Min(rows, columns); i++)
      //  matrix[i, i] = 1;
      //return matrix;

      #endregion

#if no_error_checking
      //nothing
#else
      if (rows < 1)
        throw new Error("invalid row count on matrix creation");
      if (columns < 1)
        throw new Error("invalid column count on matrix creation");
#endif

      Matrix<double> matrix = new Matrix<double>(rows, columns);
      if (rows <= columns)
        for (int i = 0; i < rows; i++)
          matrix[i, i] = 1;
      else
        for (int i = 0; i < columns; i++)
          matrix[i, i] = 1;
      return matrix;
    }

    /// <summary>Negates all the values in a matrix.</summary>
    /// <param name="matrix">The matrix to have its values negated.</param>
    /// <returns>The resulting matrix after the negations.</returns>
    public static Matrix<double> Negate(Matrix<double> matrix)
    {
      #region pre-optimization

      //Matrix<double> result =
      //  new Matrix<double>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Rows; j++)
      //    result[i, j] = -matrix[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
        if (object.ReferenceEquals(matrix, null))
          throw new Error("null reference: matirx");
#endif

      Matrix<double> result =
        new Matrix<double>(matrix.Rows, matrix.Columns);
      int size = matrix.Rows * matrix.Columns;

#if unsafe_code
      unsafe
      {
        fixed (double*
          result_flat = result._matrix,
          matrix_flat = matrix._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = -matrix_flat[i];
        return result;
      }
#else
      double[] result_flat = result._matrix;
      double[] matrix_flat = matrix._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = -matrix_flat[i];
      return result;
#endif
    }

    /// <summary>Negates all the values in a matrix.</summary>
    /// <param name="matrix">The matrix to have its values negated.</param>
    /// <returns>The resulting matrix after the negations.</returns>
    public static Matrix<double> Negate_parallel(Matrix<double> matrix)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matirx");
#endif

      if (matrix.Rows * matrix.Columns > _parallelMinimum)
      {
        Matrix<double> result =
        new Matrix<double>(matrix.Rows, matrix.Columns);
        int size = matrix.Rows * matrix.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (double*
                  result_flat = result._matrix,
                  matrix_flat = matrix._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = -matrix_flat[i];
              };
            }, Logic.Max(matrix.Rows, matrix.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                double[] matrix_flat = matrix._matrix;
                double[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = -matrix_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Negate(matrix);
    }

    /// <summary>Does standard addition of two matrices.</summary>
    /// <param name="left">The left matrix of the addition.</param>
    /// <param name="right">The right matrix of the addition.</param>
    /// <returns>The resulting matrix after the addition.</returns>
    public static Matrix<double> Add(Matrix<double> left, Matrix<double> right)
    {
      #region pre-optimization

      //Matrix<double> result =
      //  new Matrix<double>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] + right[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
          throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix addition (dimension miss-match).");
#endif

      Matrix<double> result =
        new Matrix<double>(left.Rows, left.Columns);
      int size = left.Rows * left.Columns;

#if unsafe_code
      unsafe
      {
        fixed (double*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
      }
#else
      double[] left_flat = left._matrix;
      double[] right_flat = right._matrix;
      double[] result_flat = result._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = left_flat[i] + right_flat[i];
#endif

      return result;
    }

    /// <summary>Does standard addition of two matrices.</summary>
    /// <param name="left">The left matrix of the addition.</param>
    /// <param name="right">The right matrix of the addition.</param>
    /// <returns>The resulting matrix after the addition.</returns>
    public static Matrix<double> Add_parallel(Matrix<double> left, Matrix<double> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix addition (dimension miss-match).");
#endif

      if (left.Rows * left.Columns > _parallelMinimum)
      {
        Matrix<double> result =
        new Matrix<double>(left.Rows, left.Columns);
        int size = left.Rows * left.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (double*
                  left_flat = left._matrix,
                  right_flat = right._matrix,
                  result_flat = result._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = left_flat[i] + right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                double[] left_flat = left._matrix;
                double[] right_flat = right._matrix;
                double[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = left_flat[i] + right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Add(left, right);
    }

    /// <summary>Subtracts a scalar from all the values in a matrix.</summary>
    /// <param name="left">The matrix to have the values subtracted from.</param>
    /// <param name="right">The scalar to subtract from all the matrix values.</param>
    /// <returns>The resulting matrix after the subtractions.</returns>
    public static Matrix<double> Subtract(Matrix<double> left, Matrix<double> right)
    {
      #region pre-optimization

      //Matrix<double> result =
      //  new Matrix<double>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] - right[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix subtraction (dimension miss-match).");
#endif

      Matrix<double> result =
        new Matrix<double>(left.Rows, left.Columns);
      int size = left.Rows * left.Columns;

#if unsafe_code
      unsafe
      {
        fixed (double*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = left_flat[i] - right_flat[i];
      }
#else
      double[] left_flat = left._matrix;
      double[] right_flat = right._matrix;
      double[] result_flat = result._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = left_flat[i] - right_flat[i];
#endif

      return result;
    }

    /// <summary>Subtracts a scalar from all the values in a matrix.</summary>
    /// <param name="left">The matrix to have the values subtracted from.</param>
    /// <param name="right">The scalar to subtract from all the matrix values.</param>
    /// <returns>The resulting matrix after the subtractions.</returns>
    public static Matrix<double> Subtract_parallel(Matrix<double> left, Matrix<double> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix subtraction (dimension miss-match).");
#endif
      
      if (left.Rows * left.Columns > _parallelMinimum)
      {
        Matrix<double> result =
        new Matrix<double>(left.Rows, left.Columns);
        int size = left.Rows * left.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (double*
                  left_flat = left._matrix,
                  right_flat = right._matrix,
                  result_flat = result._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = left_flat[i] - right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
          (int current, int max) =>
          {
            return () =>
            {
              double[] left_flat = left._matrix;
              double[] right_flat = right._matrix;
              double[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = left_flat[i] - right_flat[i];
            };
          }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Subtract(left, right);
    }

    /// <summary>Performs multiplication on two matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Matrix<double> Multiply(Matrix<double> left, Matrix<double> right)
    {
      #region pre-optimization

      //Matrix<double> result = 
      //  new Matrix<double>(left.Rows, right.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < right.Columns; j++)
      //    for (int k = 0; k < left.Columns; k++)
      //      result[i, j] += left[i, k] * right[k, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (left == null)
        throw new Error("null reference: left");
      if (right == null)
        throw new Error("null reference: right");
      if (left.Columns != right.Rows)
        throw new LinearAlgebra.Error("invalid multiplication (size miss-match).");
#endif

      double sum;
      int result_rows = left.Rows;
      int left_cols = left.Columns;
      int result_cols = right.Columns;
      Matrix<double> result =
        new Matrix<double>(result_rows, result_cols);

#if unsafe_code
      unsafe
      {
        fixed (double*
          result_flat = result._matrix,
          left_flat = left._matrix,
          right_flat = right._matrix)
          for (int i = 0; i < result_rows; i++)
            for (int j = 0; j < result_cols; j++)
            {
              sum = 0;
              for (int k = 0; k < left_cols; k++)
                sum += left_flat[i * left_cols + k] * right_flat[k * result_cols + j];
              result_flat[i * result_cols + j] = sum;
            }
      }
#else
      double[] result_flat = result._matrix;
      double[] left_flat = left._matrix;
      double[] right_flat = right._matrix;

      for (int i = 0; i < result_rows; i++)
        for (int j = 0; j < result_cols; j++)
        {
          sum = 0;
          for (int k = 0; k < left_cols; k++)
            sum += left_flat[i * left_cols + k] * right_flat[k * result_cols + j];
          result_flat[i * result_cols + j] = sum;
        }
#endif

      return result;
    }

    /// <summary>Performs multiplication on two matrices using multi-threading.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Matrix<double> Multiply_parrallel(Matrix<double> left, Matrix<double> right)
    {
#if no_error_checking
      // nothing
#else
      if (left == null)
        throw new Error("null reference: left");
      if (right == null)
        throw new Error("null reference: right");
      if (left.Columns != right.Rows)
        throw new LinearAlgebra.Error("invalid multiplication (dimension miss-match).");
#endif

      int result_rows = left.Rows;
      int left_cols = left.Columns;
      int result_cols = right.Columns;

      // If there are enough rows to warrant multi-threading,
      // then multithread the row for-loop.
      if (result_rows * result_cols > _parallelMinimum && 
        result_rows >= result_cols)
      {
        Matrix<double> result =
          new Matrix<double>(result_rows, result_cols);
#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
                {
                  double sum;
                  int left_i_offest;
                  int result_i_offset;

                  fixed (double*
                    result_flat = result._matrix,
                    left_flat = left._matrix,
                    right_flat = right._matrix)
                    for (int i = current; i < result_rows; i += max)
                    {
                      left_i_offest = i * left_cols;
                      result_i_offset = i * result_cols;
                      for (int j = 0; j < result_cols; j++)
                      {
                        sum = 0;
                        for (int k = 0; k < left_cols; k++)
                          sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                        result_flat[result_i_offset + j] = sum;
                      }
                    }
                };
            }, result_rows);
        }
#else
              double[] result_flat = result._matrix;
              double[] left_flat = left._matrix;
              double[] right_flat = right._matrix;

              Seven.Parallels.AutoParallel.Divide(
                  (int current, int max) =>
                  {
                    return () =>
                    {
                      double sum;
                      int left_i_offest;
                      int result_i_offset;

                      for (int i = current; i < result_rows; i += max)
                      {
                        left_i_offest = i * left_cols;
                        result_i_offset = i * result_cols;
                        for (int j = 0; j < result_cols; j++)
                        {
                          sum = 0;
                          for (int k = 0; k < left_cols; k++)
                            sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                          result_flat[result_i_offset + j] = sum;
                        }
                      }
                    };
                  }, result_rows);

#endif
        return result;
      }
      // If there are enough columns to warrant multi-threading,
      // then multithread the column for-loop.
      else if (result_rows * result_cols > _parallelMinimum &&
        result_rows < result_cols)
      {
        Matrix<double> result =
          new Matrix<double>(result_rows, result_cols);
#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
                {
                  double sum;
                  int left_i_offest;
                  int result_i_offset;

                  fixed (double*
                    result_flat = result._matrix,
                    left_flat = left._matrix,
                    right_flat = right._matrix)
                    for (int i = 0; i < result_rows; i++)
                    {
                      left_i_offest = i * left_cols;
                      result_i_offset = i * result_cols;
                      for (int j = current; j < result_cols; j += max)
                      {
                        sum = 0;
                        for (int k = 0; k < left_cols; k++)
                          sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                        result_flat[result_i_offset + j] = sum;
                      }
                    }
                };
            }, result_cols);
        }
#else
              double[] result_flat = result._matrix;
              double[] left_flat = left._matrix;
              double[] right_flat = right._matrix;

              Seven.Parallels.AutoParallel.Divide(
                  (int current, int max) =>
                  {
                    return () =>
                    {
                      double sum;
                      int left_i_offest;
                      int result_i_offset;

                      for (int i = 0; i < result_rows; i++)
                      {
                        left_i_offest = i * left_cols;
                        result_i_offset = i * result_cols;
                        for (int j = current; j < result_cols; j += max)
                        {
                          sum = 0;
                          for (int k = 0; k < left_cols; k++)
                            sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                          result_flat[result_i_offset + j] = sum;
                        }
                      }
                    };
                  }, result_cols);
#endif
        return result;
      }
      // Multi-threading is not necessary.
      else
        return LinearAlgebra.Multiply(left, right);
    }
        
    /// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Vector<double> Multiply(Matrix<double> left, Vector<double> right)
    {
      #region pre-optimization

      //Vector<double> result = 
      //  new Vector<double>(right.Dimensions);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i] += left[i, j] * right[j];
      //return result;

      #endregion

#if no_error_checking
      int left_row = left.Rows;
      int left_col = left.Columns;
#else
      int left_row = left.Rows;
      int left_col = left.Columns;
      if (left.Columns != right.Dimensions)
        throw new Error("invalid multiplication (size miss-match).");
#endif

      Vector<double> result = new Vector<double>(right.Dimensions);

#if unsafe_code
      unsafe
      {
        fixed (double* 
          left_flat = left._matrix,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < left_row; i++)
            for (int j = 0; j < left_col; j++)
              result_flat[i] += left_flat[i * left_col + j] * right_flat[j];
        return result;
      }
#else
      double[] left_flat = left._matrix;
      double[] right_flat = right._vector;
      double[] result_flat = result._vector;
      for (int i = 0; i < left_row; i++)
        for (int j = 0; j < left_col; j++)
          result_flat[i] += left_flat[i * left_col + j] * right_flat[j];
      return result;
#endif
      return result;
    }

    /// <summary>Multiplies all the values in a matrix by a scalar.</summary>
    /// <param name="left">The matrix to have the values multiplied.</param>
    /// <param name="right">The scalar to multiply the values by.</param>
    /// <returns>The resulting matrix after the multiplications.</returns>
    public static Matrix<double> Multiply(Matrix<double> left, double right)
    {
      #region pre-optimization

      //Matrix<double> result = 
      //  new Matrix<double>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] * right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      int rows = left.Rows;
      int columns = left.Columns;
      Matrix<double> result = new Matrix<double>(rows, columns);

#if unsafe_code
      unsafe
      {
        fixed (double*
          left_flat = left._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
              result_flat[i * columns + j] = left_flat[i * columns + j] * right;
      }
#else
      for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
          result[i, j] = left[i, j] * right;
#endif

      return result;
    }

    /// <summary>Applies a power to a square matrix.</summary>
    /// <param name="matrix">The matrix to be powered by.</param>
    /// <param name="power">The power to apply to the matrix.</param>
    /// <returns>The resulting matrix of the power operation.</returns>
    public static Matrix<double> Power(Matrix<double> matrix, int power)
    {
      #region pre-optimization

      //Matrix<double> result = matrix.Clone();
      //for (int i = 0; i < power; i++)
      //  result = LinearAlgebra.Multiply(result, result);
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (!(matrix.Rows == matrix.Columns))
        throw new Error("invalid power (!matrix.IsSquare).");
      if (!(power >= 0))
        throw new Error("invalid power !(power > -1)");
#endif
      // this is not optimized...
      if (power == 0)
        return LinearAlgebra.MatrixFactoryIdentity_double(matrix.Rows, matrix.Columns);
      Matrix<double> result = matrix.Clone();
      for (int i = 0; i < power; i++)
        result = LinearAlgebra.Multiply(result, matrix);
      return result;
    }

    /// <summary>Divides all the values in the matrix by a scalar.</summary>
    /// <param name="matrix">The matrix to divide the values of.</param>
    /// <param name="right">The scalar to divide all the matrix values by.</param>
    /// <returns>The resulting matrix with the divided values.</returns>
    public static Matrix<double> Divide(Matrix<double> matrix, double right)
    {
      #region pre-optimization

      //Matrix<double> result = 
      //  new Matrix<double>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    result[i, j] = matrix[i, j] / right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      int matrix_row = matrix.Rows;
      int matrix_col = matrix.Columns;
      Matrix<double> result =
        new Matrix<double>(matrix_row, matrix_col);

#if unsafe_code
      unsafe
      {
        fixed (double*
          matrix_flat = matrix._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < matrix_row; i++)
            for (int j = 0; j < matrix_col; j++)
              result_flat[i * matrix_col + j] = 
                matrix_flat[i * matrix_col + j] / right;
      }
#else
      double[] matrix_flat = matrix._matrix;
      double[] result_flat = result._matrix;
      for (int i = 0; i < matrix_row; i++)
        for (int j = 0; j < matrix_col; j++)
          result_flat[i * matrix_col + j] = 
            matrix_flat[i * matrix_col + j] / right;

#endif
      return result;
    }

    /// <summary>Gets the minor of a matrix.</summary>
    /// <param name="matrix">The matrix to get the minor of.</param>
    /// <param name="row">The restricted row to form the minor.</param>
    /// <param name="column">The restricted column to form the minor.</param>
    /// <returns>The minor of the matrix.</returns>
    public static Matrix<double> Minor(Matrix<double> matrix, int row, int column)
    {
      #region pre-optimization

      //Matrix<double> minor = 
      //  new Matrix<double>(matrix.Rows - 1, matrix.Columns - 1);
      //int m = 0, n = 0;
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (i == row) continue;
      //  n = 0;
      //  for (int j = 0; j < matrix.Columns; j++)
      //  {
      //    if (j == column) continue;
      //    minor[m, n] = matrix[i, j];
      //    n++;
      //  }
      //  m++;
      //}
      //return minor;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows < 2 || matrix.Columns < 2)
        throw new Error("invalid matrix minor: (matrix.Rows < 2 || matrix.Columns < 2)");
      if (row < 0 || row >= matrix.Rows)
        throw new Error("invalid row on matrix minor: !(0 <= row < matrix.Rows)");
      if (column < 0 || row >= matrix.Columns)
        throw new Error("invalid column on matrix minor: !(0 <= column < matrix.Columns)");
#endif

      Matrix<double> minor = 
        new Matrix<double>(matrix.Rows - 1, matrix.Columns - 1);
      int matrix_rows = matrix.Rows;
      int matrix_cols = matrix.Columns;

#if unsafe_code
      unsafe
      {
        fixed (double*
          matrix_flat = matrix._matrix,
          minor_flat = minor._matrix)
        {
          int m = 0, n = 0;
          for (int i = 0; i < matrix_rows; i++)
          {
            if (i == row) continue;
            n = 0;
            for (int j = 0; j < matrix_cols; j++)
            {
              if (j == column) continue;
              minor_flat[m * matrix_cols + n] =
                matrix_flat[i * matrix_cols + j];
              n++;
            }
            m++;
          }
        }
      }
#else
      int m = 0, n = 0;
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (i == row) continue;
        n = 0;
        for (int j = 0; j < matrix.Columns; j++)
        {
          if (j == column) continue;
          minor[m, n] = matrix[i, j];
          n++;
        }
        m++;
      }
#endif
      return minor;
    }

    /// <summary>Combines two matrices from left to right 
    /// (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
    /// <param name="left">The left matrix of the concatenation.</param>
    /// <param name="right">The right matrix of the concatenation.</param>
    /// <returns>The resulting matrix of the concatenation.</returns>
    public static Matrix<double> ConcatenateRowWise(Matrix<double> left, Matrix<double> right)
    {
      #region pre-optimization

      //Matrix<double> result =
      //  new Matrix<double>(left.Rows, left.Columns + right.Columns);
      //for (int i = 0; i < result.Rows; i++)
      //  for (int j = 0; j < result.Columns; j++)
      //    if (j < left.Columns)
      //      result[i, j] = left[i, j];
      //    else
      //      result[i, j] = right[i, j - left.Columns];
      //return result;

      #endregion

#if no_errorChecking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows)
        throw new Error("invalid row-wise concatenation !(left.Rows == right.Rows).");
#endif

      Matrix<double> result =
        new Matrix<double>(left.Rows, left.Columns + right.Columns);
      int result_rows = result.Rows;
      int result_cols = result.Columns;

      int left_cols = left.Columns;
      int right_cols = right.Columns;

#if unsafe_code
      unsafe
      {
        // OptimizeMe (jump statement)
        fixed (double*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < result_rows; i++)
            for (int j = 0; j < result_cols; j++)
              if (j < left_cols)
                result_flat[i * result_cols + j] =
                  left_flat[i * left_cols + j];
              else
                result_flat[i * result_cols + j] =
                  right_flat[i * right_cols + j - left_cols];
      }
#else
      for (int i = 0; i < result_rows; i++)
        for (int j = 0; j < result_cols; j++)
        {
          if (j < left.Columns)
            result[i, j] = left[i, j];
          else
            result[i, j] = right[i, j - left.Columns];
        }
#endif

      return result;
    }

    /// <summary>Calculates the echelon of a matrix (aka REF).</summary>
    /// <param name="matrix">The matrix to calculate the echelon of (aka REF).</param>
    /// <returns>The echelon of the matrix (aka REF).</returns>
    public static Matrix<double> Echelon(Matrix<double> matrix)
    {
      #region pre-optimization

      //Matrix<double> result = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (result[i, i] == 0)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] != 0)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  if (result[i, i] == 0)
      //    continue;
      //  if (result[i, i] != 1)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] == 1)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
      //  for (int j = i + 1; j < result.Rows; j++)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<double> result = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (result[i, i] == 0)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] != 0)
              LinearAlgebra.SwapRows(result, i, j);
        if (result[i, i] == 0)
          continue;
        if (result[i, i] != 1)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] == 1)
              LinearAlgebra.SwapRows(result, i, j);
        LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
        for (int j = i + 1; j < result.Rows; j++)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      }
      return result;
    }

    /// <summary>Calculates the echelon of a matrix and reduces it (aka RREF).</summary>
    /// <param name="matrix">The matrix matrix to calculate the reduced echelon of (aka RREF).</param>
    /// <returns>The reduced echelon of the matrix (aka RREF).</returns>
    public static Matrix<double> ReducedEchelon(Matrix<double> matrix)
    {
      #region pre-optimization

      //Matrix<double> result = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (result[i, i] == 0)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] != 0)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  if (result[i, i] == 0) continue;
      //  if (result[i, i] != 1)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] == 1)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
      //  for (int j = i + 1; j < result.Rows; j++)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      //  for (int j = i - 1; j >= 0; j--)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<double> result = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (result[i, i] == 0)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] != 0)
              LinearAlgebra.SwapRows(result, i, j);
        if (result[i, i] == 0) continue;
        if (result[i, i] != 1)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] == 1)
              LinearAlgebra.SwapRows(result, i, j);
        LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
        for (int j = i + 1; j < result.Rows; j++)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
        for (int j = i - 1; j >= 0; j--)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      }
      return result;
    }

    /// <summary>Calculates the determinent of a square matrix.</summary>
    /// <param name="matrix">The matrix to calculate the determinent of.</param>
    /// <returns>The determinent of the matrix.</returns>
    public static double Determinent(Matrix<double> matrix)
    {
      #region pre-optimization

      //double det = 1;
      //Matrix<double> rref = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (rref[i, i] == 0)
      //    for (int j = i + 1; j < rref.Rows; j++)
      //      if (rref[j, i] != 0)
      //      {
      //        LinearAlgebra.SwapRows(rref, i, j);
      //        det *= -1;
      //      }
      //  det *= rref[i, i];
      //  LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
      //  for (int j = i + 1; j < rref.Rows; j++)
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  for (int j = i - 1; j >= 0; j--)
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //}
      //return det;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        throw new Error("invalid matrix determinent: !(matrix.IsSquare)");
#endif

      double det = 1;
      Matrix<double> rref = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (rref[i, i] == 0)
          for (int j = i + 1; j < rref.Rows; j++)
            if (rref[j, i] != 0)
            {
              LinearAlgebra.SwapRows(rref, i, j);
              det *= -1;
            }
        det *= rref[i, i];
        LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
        for (int j = i + 1; j < rref.Rows; j++)
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        for (int j = i - 1; j >= 0; j--)
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      }
      return det;
    }

    /// <summary>Calculates the inverse of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the inverse of.</param>
    /// <returns>The inverse of the matrix.</returns>
    public static Matrix<double> Inverse(Matrix<double> matrix)
    {
      #region pre-optimization

      //Matrix<double> identity = 
      //  LinearAlgebra.MatrixFactoryIdentity_double(matrix.Rows, matrix.Columns);
      //Matrix<double> rref = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (rref[i, i] == 0)
      //    for (int j = i + 1; j < rref.Rows; j++)
      //      if (rref[j, i] != 0)
      //      {
      //        LinearAlgebra.SwapRows(rref, i, j);
      //        LinearAlgebra.SwapRows(identity, i, j);
      //      }
      //  LinearAlgebra.RowMultiplication(identity, i, 1 / rref[i, i]);
      //  LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
      //  for (int j = i + 1; j < rref.Rows; j++)
      //  {
      //    LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  }
      //  for (int j = i - 1; j >= 0; j--)
      //  {
      //    LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  }
      //}
      //return identity;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (LinearAlgebra.Determinent(matrix) == 0)
        throw new Error("inverse calculation failed.");
#endif

      Matrix<double> identity = LinearAlgebra.MatrixFactoryIdentity_double(matrix.Rows, matrix.Columns);
      Matrix<double> rref = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (rref[i, i] == 0)
          for (int j = i + 1; j < rref.Rows; j++)
            if (rref[j, i] != 0)
            {
              LinearAlgebra.SwapRows(rref, i, j);
              LinearAlgebra.SwapRows(identity, i, j);
            }
        LinearAlgebra.RowMultiplication(identity, i, 1 / rref[i, i]);
        LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
        for (int j = i + 1; j < rref.Rows; j++)
        {
          LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        }
        for (int j = i - 1; j >= 0; j--)
        {
          LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        }
      }
      return identity;
    }

    /// <summary>Calculates the adjoint of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the adjoint of.</param>
    /// <returns>The adjoint of the matrix.</returns>
    public static Matrix<double> Adjoint(Matrix<double> matrix)
    {
      #region pre-optimization

      //Matrix<double> AdjointMatrix = new Matrix<double>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    if ((i + j) % 2 == 0)
      //      AdjointMatrix[i, j] = LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      //    else
      //      AdjointMatrix[i, j] = -LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      //return LinearAlgebra.Transpose(AdjointMatrix);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (!(matrix.Rows == matrix.Columns))
        throw new Error("Adjoint of a non-square matrix does not exists");
#endif

      Matrix<double> AdjointMatrix = new Matrix<double>(matrix.Rows, matrix.Columns);
      for (int i = 0; i < matrix.Rows; i++)
        for (int j = 0; j < matrix.Columns; j++)
          if ((i + j) % 2 == 0)
            AdjointMatrix[i, j] = LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
          else
            AdjointMatrix[i, j] = -LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      return LinearAlgebra.Transpose(AdjointMatrix);
    }

    /// <summary>Returns the transpose of a matrix.</summary>
    /// <param name="matrix">The matrix to transpose.</param>
    /// <returns>The transpose of the matrix.</returns>
    public static Matrix<double> Transpose(Matrix<double> matrix)
    {
      #region pre-optimization

      //Matrix<double> transpose = 
      //  new Matrix<double>(matrix.Columns, matrix.Rows);
      //for (int i = 0; i < transpose.Rows; i++)
      //  for (int j = 0; j < transpose.Columns; j++)
      //    transpose[i, j] = matrix[j, i];
      //return transpose;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<double> transpose = 
        new Matrix<double>(matrix.Columns, matrix.Rows);
      for (int i = 0; i < transpose.Rows; i++)
        for (int j = 0; j < transpose.Columns; j++)
          transpose[i, j] = matrix[j, i];
      return transpose;
    }

    /// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
    /// <param name="matrix">The matrix to decompose.</param>
    /// <param name="Lower">The computed lower triangular matrix.</param>
    /// <param name="Upper">The computed upper triangular matrix.</param>
    public static void DecomposeLU(Matrix<double> matrix, out Matrix<double> Lower, out Matrix<double> Upper)
    {
      #region pre-optimization

      //Lower = LinearAlgebra.MatrixFactoryIdentity_double(matrix.Rows, matrix.Columns);
      //Upper = matrix.Clone();
      //int[] permutation = new int[matrix.Rows];
      //for (int i = 0; i < matrix.Rows; i++) permutation[i] = i;
      //double p = 0, pom2, detOfP = 1;
      //int k0 = 0, pom1 = 0;
      //for (int k = 0; k < matrix.Columns - 1; k++)
      //{
      //  p = 0;
      //  for (int i = k; i < matrix.Rows; i++)
      //    if ((Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k]) > p)
      //    {
      //      p = Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k];
      //      k0 = i;
      //    }
      //  if (p == 0)
      //    throw new Error("The matrix is singular!");
      //  pom1 = permutation[k];
      //  permutation[k] = permutation[k0];
      //  permutation[k0] = pom1;
      //  for (int i = 0; i < k; i++)
      //  {
      //    pom2 = Lower[k, i];
      //    Lower[k, i] = Lower[k0, i];
      //    Lower[k0, i] = pom2;
      //  }
      //  if (k != k0)
      //    detOfP *= -1;
      //  for (int i = 0; i < matrix.Columns; i++)
      //  {
      //    pom2 = Upper[k, i];
      //    Upper[k, i] = Upper[k0, i];
      //    Upper[k0, i] = pom2;
      //  }
      //  for (int i = k + 1; i < matrix.Rows; i++)
      //  {
      //    Lower[i, k] = Upper[i, k] / Upper[k, k];
      //    for (int j = k; j < matrix.Columns; j++)
      //      Upper[i, j] = Upper[i, j] - Lower[i, k] * Upper[k, j];
      //  }
      //}

      #endregion

#if no_error_checking
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        throw new Error("non-square matrix during DecomposeLU function");
#endif

      Lower = LinearAlgebra.MatrixFactoryIdentity_double(matrix.Rows, matrix.Columns);
      Upper = matrix.Clone();
      int[] permutation = new int[matrix.Rows];
      for (int i = 0; i < matrix.Rows; i++) permutation[i] = i;
      double p = 0, pom2, detOfP = 1;
      int k0 = 0, pom1 = 0;
      for (int k = 0; k < matrix.Columns - 1; k++)
      {
        p = 0;
        for (int i = k; i < matrix.Rows; i++)
          if ((Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k]) > p)
          {
            p = Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k];
            k0 = i;
          }
        if (p == 0)
          throw new Error("The matrix is singular!");
        pom1 = permutation[k];
        permutation[k] = permutation[k0];
        permutation[k0] = pom1;
        for (int i = 0; i < k; i++)
        {
          pom2 = Lower[k, i];
          Lower[k, i] = Lower[k0, i];
          Lower[k0, i] = pom2;
        }
        if (k != k0)
          detOfP *= -1;
        for (int i = 0; i < matrix.Columns; i++)
        {
          pom2 = Upper[k, i];
          Upper[k, i] = Upper[k0, i];
          Upper[k0, i] = pom2;
        }
        for (int i = k + 1; i < matrix.Rows; i++)
        {
          Lower[i, k] = Upper[i, k] / Upper[k, k];
          for (int j = k; j < matrix.Columns; j++)
            Upper[i, j] = Upper[i, j] - Lower[i, k] * Upper[k, j];
        }
      }
    }

    private static void RowMultiplication(Matrix<double> matrix, int row, double scalar)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //  matrix[row, j] *= scalar;

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
        matrix[row, j] *= scalar;
    }

    private static void RowAddition(Matrix<double> matrix, int target, int second, double scalar)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //  matrix[target, j] += (matrix[second, j] * scalar);

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
        matrix[target, j] += (matrix[second, j] * scalar);
    }

    private static void SwapRows(Matrix<double> matrix, int row1, int row2)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //{
      //  double temp = matrix[row1, j];
      //  matrix[row1, j] = matrix[row2, j];
      //  matrix[row2, j] = temp;
      //}

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
      {
        double temp = matrix[row1, j];
        matrix[row1, j] = matrix[row2, j];
        matrix[row2, j] = temp;
      }
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Matrix<double> left, Matrix<double> right)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;
      //if (left.Rows != right.Rows || left.Columns != right.Columns)
      //  return false;
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    if (left[i, j] != right[i, j])
      //      return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;
        
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        return false;
      for (int i = 0; i < left.Rows; i++)
        for (int j = 0; j < left.Columns; j++)
          if (left[i, j] != right[i, j])
            return false;

      return true;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Matrix<double> left, Matrix<double> right, double leniency)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;
      //if (left.Rows != right.Rows || left.Columns != right.Columns)
      //  return false;
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    if (Logic.Abs(left[i, j] - right[i, j]) > leniency)
      //      return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        return false;
      for (int i = 0; i < left.Rows; i++)
        for (int j = 0; j < left.Columns; j++)
          if (Logic.Abs(left[i, j] - right[i, j]) > leniency)
            return false;
      return true;
    }

    #endregion

    #region quaterion

    /// <summary>Computes the length of quaternion.</summary>
    /// <param name="quaternion">The quaternion to compute the length of.</param>
    /// <returns>The length of the given quaternion.</returns>
    public static double Magnitude(Quaternion<double> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return Algebra.sqrt(
          (quaternion.X * quaternion.X +
          quaternion.Y * quaternion.Y +
          quaternion.Z * quaternion.Z +
          quaternion.W * quaternion.W));
    }

    /// <summary>Computes the length of a quaternion, but doesn't square root it
    /// for optimization possibilities.</summary>
    /// <param name="quaternion">The quaternion to compute the length squared of.</param>
    /// <returns>The squared length of the given quaternion.</returns>
    public static double MagnitudeSquared(Quaternion<double> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return
        quaternion.X * quaternion.X +
        quaternion.Y * quaternion.Y +
        quaternion.Z * quaternion.Z +
        quaternion.W * quaternion.W;
    }

    /// <summary>Gets the conjugate of the quaternion.</summary>
    /// <param name="quaternion">The quaternion to conjugate.</param>
    /// <returns>The conjugate of teh given quaternion.</returns>
    public static Quaternion<double> Conjugate(Quaternion<double> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return new Quaternion<double>(
        -quaternion.X,
        -quaternion.Y,
        -quaternion.Z,
        quaternion.W);
    }

    /// <summary>Adds two quaternions together.</summary>
    /// <param name="left">The first quaternion of the addition.</param>
    /// <param name="right">The second quaternion of the addition.</param>
    /// <returns>The result of the addition.</returns>
    public static Quaternion<double> Add(Quaternion<double> left, Quaternion<double> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<double>(
        left.X + right.X,
        left.Y + right.Y,
        left.Z + right.Z,
        left.W + right.W);
    }

    /// <summary>Subtracts two quaternions.</summary>
    /// <param name="left">The left quaternion of the subtraction.</param>
    /// <param name="right">The right quaternion of the subtraction.</param>
    /// <returns>The resulting quaternion after the subtraction.</returns>
    public static Quaternion<double> Subtract(Quaternion<double> left, Quaternion<double> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<double>(
        left.X - right.X,
        left.Y - right.Y,
        left.Z - right.Z,
        left.W - right.W);
    }

    /// <summary>Multiplies two quaternions together.</summary>
    /// <param name="left">The first quaternion of the multiplication.</param>
    /// <param name="right">The second quaternion of the multiplication.</param>
    /// <returns>The resulting quaternion after the multiplication.</returns>
    public static Quaternion<double> Multiply(Quaternion<double> left, Quaternion<double> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<double>(
        left.X * right.W + left.W * right.X + left.Y * right.Z - left.Z * right.Y,
        left.Y * right.W + left.W * right.Y + left.Z * right.X - left.X * right.Z,
        left.Z * right.W + left.W * right.Z + left.X * right.Y - left.Y * right.X,
        left.W * right.W - left.X * right.X - left.Y * right.Y - left.Z * right.Z);
    }

    /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
    /// <param name="left">The quaternion of the multiplication.</param>
    /// <param name="right">The scalar of the multiplication.</param>
    /// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
    public static Quaternion<double> Multiply(Quaternion<double> left, double right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      return new Quaternion<double>(
        left.X * right,
        left.Y * right,
        left.Z * right,
        left.W * right);
    }

    /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
    /// <param name="left">The quaternion to pre-multiply the vector by.</param>
    /// <param name="right">The vector to be multiplied.</param>
    /// <returns>The resulting quaternion of the multiplication.</returns>
    public static Quaternion<double> Multiply(Quaternion<double> left, Vector<double> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (right.Dimensions != 3)
        throw new Error("my quaternion rotations are only defined for 3-component vectors.");
#endif

      return new Quaternion<double>(
        left.W * right.X + left.Y * right.Z - left.Z * right.Y,
        left.W * right.Y + left.Z * right.X - left.X * right.Z,
        left.W * right.Z + left.X * right.Y - left.Y * right.X,
        -left.X * right.X - left.Y * right.Y - left.Z * right.Z);
    }

    /// <summary>Normalizes the quaternion.</summary>
    /// <param name="quaternion">The quaternion to normalize.</param>
    /// <returns>The normalization of the given quaternion.</returns>
    public static Quaternion<double> Normalize(Quaternion<double> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      double normalizer = Quaternion<double>.Magnitude(quaternion);
      if (normalizer != 0)
        return quaternion * (1 / normalizer);
      else
        return Quaternion<double>.FactoryIdentity;
    }

    /// <summary>Inverts a quaternion.</summary>
    /// <param name="quaternion">The quaternion to find the inverse of.</param>
    /// <returns>The inverse of the given quaternion.</returns>
    public static Quaternion<double> Invert(Quaternion<double> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      double normalizer = Quaternion<double>.MagnitudeSquared(quaternion);
      if (normalizer == 0)
        return new Quaternion<double>(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
      normalizer = 1 / normalizer;
      return new Quaternion<double>(
        -quaternion.X * normalizer,
        -quaternion.Y * normalizer,
        -quaternion.Z * normalizer,
        quaternion.W * normalizer);
    }

    /// <summary>Lenearly interpolates between two quaternions.</summary>
    /// <param name="left">The starting point of the interpolation.</param>
    /// <param name="right">The ending point of the interpolation.</param>
    /// <param name="blend">The ratio 0.0-1.0 of how far to interpolate between the left and right quaternions.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Quaternion<double> Lerp(Quaternion<double> left, Quaternion<double> right, double blend)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      if (blend < 0 || blend > 1)
        throw new Error("invalid blending value during lerp !(blend < 0.0f || blend > 1.0f).");
      if (Quaternion<double>.MagnitudeSquared(left) == 0)
      {
        if (Quaternion<double>.MagnitudeSquared(right) == 0)
          return Quaternion<double>.FactoryIdentity;
        else
          return new Quaternion<double>(right.X, right.Y, right.Z, right.W);
      }
      else if (Quaternion<double>.MagnitudeSquared(right) == 0)
        return new Quaternion<double>(left.X, left.Y, left.Z, left.W);
      Quaternion<double> result = new Quaternion<double>(
        1 - blend * left.X + blend * right.X,
        1 - blend * left.Y + blend * right.Y,
        1 - blend * left.Z + blend * right.Z,
        1 - blend * left.W + blend * right.W);
      if (Quaternion<double>.MagnitudeSquared(result) > 0)
        return Quaternion<double>.Normalize(result);
      else
        return Quaternion<double>.FactoryIdentity;
    }

    /// <summary>Sphereically interpolates between two quaternions.</summary>
    /// <param name="left">The starting point of the interpolation.</param>
    /// <param name="right">The ending point of the interpolation.</param>
    /// <param name="blend">The ratio of how far to interpolate between the left and right quaternions.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Quaternion<double> Slerp(Quaternion<double> left, Quaternion<double> right, double blend)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      if (blend < 0 || blend > 1)
        throw new Error("invalid blending value during slerp !(blend < 0.0f || blend > 1.0f).");
      if (LinearAlgebra.MagnitudeSquared(left) == 0)
      {
        if (LinearAlgebra.MagnitudeSquared(right) == 0)
          return Quaternion<double>.FactoryIdentity;
        else
          return new Quaternion<double>(right.X, right.Y, right.Z, right.W);
      }
      else if (LinearAlgebra.MagnitudeSquared(right) == 0)
        return new Quaternion<double>(left.X, left.Y, left.Z, left.W);
      double cosHalfAngle = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
      if (cosHalfAngle >= 1 || cosHalfAngle <= -1)
        return new Quaternion<double>(left.X, left.Y, left.Z, left.W);
      else if (cosHalfAngle < 0)
      {
        right = new Quaternion<double>(-left.X, -left.Y, -left.Z, -left.W);
        cosHalfAngle = -cosHalfAngle;
      }
      double halfAngle = Trigonometry.arccos(cosHalfAngle);
      double sinHalfAngle = Trigonometry.sin(halfAngle);
      double blendA = Trigonometry.sin(halfAngle * (1 - blend)) / sinHalfAngle;
      double blendB = Trigonometry.sin(halfAngle * blend) / sinHalfAngle;
      Quaternion<double> result = new Quaternion<double>(
        blendA * left.X + blendB * right.X,
        blendA * left.Y + blendB * right.Y,
        blendA * left.Z + blendB * right.Z,
        blendA * left.W + blendB * right.W);
      if (LinearAlgebra.MagnitudeSquared(result) > 0)
        return LinearAlgebra.Normalize(result);
      else
        return Quaternion<double>.FactoryIdentity;
    }

    /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
    /// <param name="rotation">The quaternion to rotate the vector by.</param>
    /// <param name="vector">The vector to be rotated by.</param>
    /// <returns>The result of the rotation.</returns>
    public static Vector<double> Rotate(Quaternion<double> rotation, Vector<double> vector)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(rotation, null))
        throw new Error("null reference: rotation");
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      if (vector.Dimensions != 3 && vector.Dimensions != 4)
        throw new Error("my quaternion rotations are only defined for 3-component vectors.");
      Quaternion<double> answer = LinearAlgebra.Multiply(LinearAlgebra.Multiply(rotation, vector), LinearAlgebra.Conjugate(rotation));
      return new Vector<double>(answer.X, answer.Y, answer.Z);
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first quaternion to check for equality.</param>
    /// <param name="right">The second quaternion  to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Quaternion<double> left, Quaternion<double> right)
    {
      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      return
        left.X == right.X &&
        left.Y == right.Y &&
        left.Z == right.Z &&
        left.W == right.W;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first quaternion to check for equality.</param>
    /// <param name="right">The second quaternion to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Quaternion<double> left, Quaternion<double> right, double leniency)
    {
      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      return
        Logic.Abs(left.X - right.X) < leniency &&
        Logic.Abs(left.Y - right.Y) < leniency &&
        Logic.Abs(left.Z - right.Z) < leniency &&
        Logic.Abs(left.W - right.W) < leniency;
    }

    #endregion

    #region tableau

    const double epsilon = 1.0e-8;
    //int equal(double a, double b) { return fabs(a - b) < epsilon; }

    static void pivot_on(ref double[,] tableau, int row, int col)
    {
      int i, j;
      double pivot;

      pivot = tableau[row, col];
      if (!(pivot > 0))
        throw new Error("possible invalid tableau values (IDK)");
      for (j = 0; j < tableau.GetLength(1); j++)
        tableau[row, j] /= pivot;
      if (!(Logic.Equate(tableau[row, col], 1, epsilon)))
        throw new Error("possible invalid tableau values (IDK)");

      for (i = 0; i < tableau.GetLength(0); i++)
      { // foreach remaining row i do
        double multiplier = tableau[i, col];
        if (i == row) continue;
        for (j = 0; j < tableau.GetLength(1); j++)
        { // r[i] = r[i] - z * r[row];
          tableau[i, j] -= multiplier * tableau[row, j];
        }
      }
    }

    // Find pivot_col = most negative column in mat[0][1..n]
    static int find_pivot_column(ref double[,] tableau)
    {
      int j, pivot_col = 1;
      double lowest = tableau[0, pivot_col];
      for (j = 1; j < tableau.GetLength(1); j++)
      {
        if (tableau[0, j] < lowest)
        {
          lowest = tableau[0, j];
          pivot_col = j;
        }
      }
      //printf("Most negative column in row[0] is col %d = %g.\n", pivot_col, lowest);
      if (lowest >= 0)
      {
        return -1; // All positive columns in row[0], this is optimal.
      }
      return pivot_col;
    }

    // Find the pivot_row, with smallest positive ratio = col[0] / col[pivot]
    static int find_pivot_row(ref double[,] tableau, int pivot_col)
    {
      int i, pivot_row = 0;
      double min_ratio = -1;
      //printf("Ratios A[row_i,0]/A[row_i,%d] = [", pivot_col);
      for (i = 1; i < tableau.GetLength(0); i++)
      {
        double ratio = tableau[i, 0] / tableau[i, pivot_col];
        //printf("%3.2lf, ", ratio);
        if ((ratio > 0 && ratio < min_ratio) || min_ratio < 0)
        {
          min_ratio = ratio;
          pivot_row = i;
        }
      }
      //printf("].\n");
      if (min_ratio == -1)
        return -1; // Unbounded.
      //printf("Found pivot A[%d,%d], min positive ratio=%g in row=%d.\n",
      //  pivot_row, pivot_col, min_ratio, pivot_row);
      return pivot_row;
    }

    static void add_slack_variables(ref double[,] tableau)
    {

      double[,] newTableau =
        new double[tableau.GetLength(0), tableau.GetLength(1) + tableau.GetLength(0) - 1];

      for (int a = 0, a_max = tableau.GetLength(0); a < a_max; a++)
        for (int b = 0, b_max = tableau.GetLength(1); b < b_max; b++)
          newTableau[a, b] = tableau[a, b];

      int i, j;
      for (i = 1; i < tableau.GetLength(0); i++)
      {
        for (j = 1; j < tableau.GetLength(0); j++)
          newTableau[i, j + tableau.GetLength(1) - 1] = (i == j ? 1d : 0d);
      }

      tableau = newTableau;
    }

    static void check_b_positive(ref double[,] tableau)
    {
      int i;
      for (i = 1; i < tableau.GetLength(0); i++)
        if (!(tableau[i, 0] >= 0))
          throw new Error("possible invalid tableau values (IDK)");
    }

    // Given a column of identity matrix, find the row containing 1.
    // return -1, if the column as not from an identity matrix.
    static int find_basis_variable(ref double[,] tableau, int col)
    {
      int i, xi = -1;
      for (i = 1; i < tableau.GetLength(0); i++)
      {
        if (Logic.Equate(tableau[i, col], 1, epsilon))
          if (xi == -1)
            xi = i;   // found first '1', save this row number.
          else
            return -1; // found second '1', not an identity matrix.
        else if (!Logic.Equate(tableau[i, col], 0, epsilon))
          return -1; // not an identity matrix column.
      }
      return xi;
    }

    static double[] print_optimal_vector(ref double[,] tableau)
    {
      double[] vector = new double[tableau.GetLength(1)];
      int j, xi;
      //printf("%s at ", message);
      for (j = 1; j < tableau.GetLength(1); j++)
      { // for each column.
        xi = find_basis_variable(ref tableau, j);
        if (xi != -1)
          vector[j] = tableau[xi, 0];
        else
          vector[j] = j;
      }
      return vector;
    }

    public static double[] Simplex(ref double[,] tableau)
    {
      int loop = 0;
      add_slack_variables(ref tableau);
      check_b_positive(ref tableau);
      while (++loop > 0)
      {
        int pivot_col, pivot_row;

        pivot_col = find_pivot_column(ref tableau);
        if (pivot_col < 0)
          //printf("Found optimal value=A[0,0]=%3.2lf (no negatives in row 0).\n",
          //  tableau->mat[0][0]);
          return print_optimal_vector(ref tableau);
        //printf("Entering variable x%d to be made basic, so pivot_col=%d.\n",
        //  pivot_col, pivot_col);

        pivot_row = find_pivot_row(ref tableau, pivot_col);
        if (pivot_row < 0)
          throw new Error("unbounded (no pivot_row)");
        //printf("Leaving variable x%d, so pivot_row=%d\n", pivot_row, pivot_row);

        pivot_on(ref tableau, pivot_row, pivot_col);
        //print_tableau(tableau, "After pivoting");
        //return print_optimal_vector(ref tableau);
      }
      throw new Error("Simplex has a glitch");
    }

    #endregion

    #endregion

    #region float

    #region vector

    /// <summary>Adds two vectors together.</summary>
    /// <param name="left">The first vector of the addition.</param>
    /// <param name="right">The second vector of the addiiton.</param>
    /// <returns>The result of the addiion.</returns>
    public static Vector<float> Add(Vector<float> left, Vector<float> right)
    {
      #region pre-optimization

      //Vector<float> result =
      //  new Vector<float>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] + right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector addition.");
#endif

      int length = left.Dimensions;
      Vector<float> result =
        new Vector<float>(left.Dimensions);

#if unsafe_code
      unsafe
      {
        fixed (float*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
      }
#else
      float[] left_flat = left._vector;
      float[] right_flat = right._vector;
      float[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
#endif

      return result;
    }

    /// <summary>Negates all the values in a vector.</summary>
    /// <param name="vector">The vector to have its values negated.</param>
    /// <returns>The result of the negations.</returns>
    public static Vector<float> Negate(Vector<float> vector)
    {
      #region pre-optimization

      //Vector<float> result =
      //  new Vector<float>(vector.Dimensions);
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result[i] = -vector[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Vector<float> result =
        new Vector<float>(length);

#if unsafe_code
      unsafe
      {
        fixed (float*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = -vector_flat[i];
      }
#else
      float[] vector_flat = vector._vector;
      float[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = -vector_flat[i];
#endif

      return result;
    }

    /// <summary>Subtracts two vectors.</summary>
    /// <param name="left">The left vector of the subtraction.</param>
    /// <param name="right">The right vector of the subtraction.</param>
    /// <returns>The result of the vector subtracton.</returns>
    public static Vector<float> Subtract(Vector<float> left, Vector<float> right)
    {
      #region pre-optimization

      //Vector<float> result =
      //  new Vector<float>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] - right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector subtraction.");
#endif

      int length = left.Dimensions;
      Vector<float> result =
        new Vector<float>(length);

#if unsafe_code
      unsafe
      {
        fixed (float*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] - right_flat[i];
      }
#else
      float[] left_flat = left._vector;
      float[] right_flat = right._vector;
      float[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] - right_flat[i];
#endif

      return result;
    }

    /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
    /// <param name="left">The vector to have the components multiplied by.</param>
    /// <param name="right">The scalars to multiply the vector components by.</param>
    /// <returns>The result of the multiplications.</returns>
    public static Vector<float> Multiply(Vector<float> left, float right)
    {
      #region pre-optimization

      //Vector<float> result =
      //  new Vector<float>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] * right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      int length = left.Dimensions;
      Vector<float> result =
        new Vector<float>(length);

#if unsafe_code
      unsafe
      {
        fixed (float*
          left_flat = left._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] * right;
      }
#else
      float[] left_flat = left._vector;
      float[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] * right;
#endif

      return result;
    }

    /// <summary>Divides all the components of a vector by a scalar.</summary>
    /// <param name="vector">The vector to have the components divided by.</param>
    /// <param name="right">The scalar to divide the vector components by.</param>
    /// <returns>The resulting vector after teh divisions.</returns>
    public static Vector<float> Divide(Vector<float> vector, float right)
    {
      #region pre-optimization

      //Vector<float> result =
      //  new Vector<float>(vector.Dimensions);
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result[i] = vector[i] / right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: left");
#endif

      int length = vector.Dimensions;
      Vector<float> result =
        new Vector<float>(length);

#if unsafe_code
      unsafe
      {
        fixed (float*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = vector_flat[i] / right;
      }
#else
      float[] vector_flat = vector._vector;
      float[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = vector_flat[i] / right;
#endif

      return result;
    }

    /// <summary>Computes the dot product between two vectors.</summary>
    /// <param name="left">The first vector of the dot product operation.</param>
    /// <param name="right">The second vector of the dot product operation.</param>
    /// <returns>The result of the dot product operation.</returns>
    public static float DotProduct(Vector<float> left, Vector<float> right)
    {
      #region pre-optimization

      //float result = 0;
      //for (int i = 0; i < left.Dimensions; i++)
      //  result += left[i] * right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector dot product.");
#endif

      int length = left.Dimensions;
      float result = 0;

#if unsafe_code
      unsafe
      {
        fixed (float*
          left_flat = left._vector,
          right_flat = right._vector)
          for (int i = 0; i < length; i++)
            result += left_flat[i] * right_flat[i];
      }
#else
      float[] left_flat = left._vector;
      float[] right_flat = right._vector;
      for (int i = 0; i < length; i++)
        result += left_flat[i] * right_flat[i];
#endif

      return result;
    }

    /// <summary>Computes teh cross product of two vectors.</summary>
    /// <param name="left">The first vector of the cross product operation.</param>
    /// <param name="right">The second vector of the cross product operation.</param>
    /// <returns>The result of the cross product operation.</returns>
    public static Vector<float> CrossProduct(Vector<float> left, Vector<float> right)
    {
      #region pre-optimization

      //Vector<float> result = new Vector<float>(3);
      //result[0] = left[1] * right[2] - left[2] * right[1];
      //result[1] = left[2] * right[0] - left[0] * right[2];
      //result[2] = left[0] * right[1] - left[1] * right[0];

      #endregion

#if no_error_checking

#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid cross product (left.Dimensions != right.Dimensions)");
      if (left.Dimensions != 3)
        throw new Error("my cross product function is only defined for 3-component vectors.");
#endif

      Vector<float> result =
        new Vector<float>(3);

#if unsafe_code
      unsafe
      {
        fixed (float*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
        {
          result_flat[0] = left_flat[1] * right_flat[2] - left_flat[2] * right_flat[1];
          result_flat[1] = left_flat[2] * right_flat[0] - left_flat[0] * right_flat[2];
          result_flat[2] = left_flat[0] * right_flat[1] - left_flat[1] * right_flat[0];
        }
      }
#else
      float[] left_flat = left._vector;
      float[] right_flat = right._vector;
      float[] result_flat = result._vector;
      result_flat[0] = left_flat[1] * right_flat[2] - left_flat[2] * right_flat[1];
      result_flat[1] = left_flat[2] * right_flat[0] - left_flat[0] * right_flat[2];
      result_flat[2] = left_flat[0] * right_flat[1] - left_flat[1] * right_flat[0];
#endif

      return result;
    }

    /// <summary>Normalizes a vector.</summary>
    /// <param name="vector">The vector to normalize.</param>
    /// <returns>The result of the normalization.</returns>
    public static Vector<float> Normalize(Vector<float> vector)
    {
      #region pre-optimization

      //float magnitude = LinearAlgebra.Magnitude(vector);
      //if (magnitude != 0)
      //{
      //  Vector<float> result = 
      //    new Vector<float>(vector.Dimensions);
      //  for (int i = 0; i < vector.Dimensions; i++)
      //    result[i] = vector[i] / magnitude;
      //  return result;
      //}
      //else
      //  return new float[vector.Dimensions];

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Vector<float> result =
        new Vector<float>(vector.Dimensions);
      float magnitude = LinearAlgebra.Magnitude(vector);
      if (magnitude != 0)
        return result;

#if unsafe_code
      unsafe
      {
        fixed (float*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = vector_flat[i] / magnitude;
      }
#else
      float[] vector_flat = vector._vector;
      float[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = vector_flat[i] / magnitude;
#endif

      return result;

    }

    /// <summary>Computes the length of a vector.</summary>
    /// <param name="vector">The vector to calculate the length of.</param>
    /// <returns>The computed length of the vector.</returns>
    public static float Magnitude(Vector<float> vector)
    {
      #region pre-optimization

      //float result = 0;
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result += vector[i] * vector[i];
      //return Algebra.sqrt(result);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      float result = 0;

#if unsafe_code
      unsafe
      {
        fixed (float*
          vector_flat = vector._vector)
          for (int i = 0; i < length; i++)
            result += vector_flat[i] * vector_flat[i];
      }
#else
      float[] vector_flat = vector._vector;
      for (int i = 0; i < length; i++)
        result += vector_flat[i] * vector_flat[i];
#endif

      return Algebra.sqrt(result);
    }

    /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
    /// <param name="vector">The vector to compute the length squared of.</param>
    /// <returns>The computed length squared of the vector.</returns>
    public static float MagnitudeSquared(Vector<float> vector)
    {
      #region pre-optimization

      //float result = 0;
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result += vector[i] * vector[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      float result = 0;

#if unsafe_code
      unsafe
      {
        fixed (float*
          vector_flat = vector._vector)
          for (int i = 0; i < length; i++)
            result += vector_flat[i] * vector_flat[i];
      }
#else
      float[] vector_flat = vector._vector;
      for (int i = 0; i < length; i++)
        result += vector_flat[i] * vector_flat[i];
#endif

      return result;
    }

    /// <summary>Computes the angle between two vectors.</summary>
    /// <param name="first">The first vector to determine the angle between.</param>
    /// <param name="second">The second vector to determine the angle between.</param>
    /// <returns>The angle between the two vectors in radians.</returns>
    public static float Angle(Vector<float> first, Vector<float> second)
    {
      #region pre-optimization

      //return Trigonometry.arccos(
      //  LinearAlgebra.DotProduct(first, second) / 
      //  (LinearAlgebra.Magnitude(first) * 
      //  LinearAlgebra.Magnitude(second)));

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(first, null))
        throw new Error("null reference: first");
      if (object.ReferenceEquals(second, null))
        throw new Error("null reference: second");
#endif

      return Trigonometry.arccos(
        LinearAlgebra.DotProduct(first, second) /
        (LinearAlgebra.Magnitude(first) *
        LinearAlgebra.Magnitude(second)));
    }

    /// <summary>Rotates a 3-component vector by the specified axis and rotation values.</summary>
    /// <param name="vector">The vector to rotate.</param>
    /// <param name="angle">The angle of the rotation in radians.</param>
    /// <param name="x">The x component of the axis vector to rotate about.</param>
    /// <param name="y">The y component of the axis vector to rotate about.</param>
    /// <param name="z">The z component of the axis vector to rotate about.</param>
    /// <returns>The result of the rotation.</returns>
    public static Vector<float> RotateBy(Vector<float> vector, float angle, float x, float y, float z)
    {
      #region pre-optimization

      //float sinHalfAngle = Trigonometry.sin(angle / 2);
      //float cosHalfAngle = Trigonometry.cos(angle / 2);
      //x *= sinHalfAngle;
      //y *= sinHalfAngle;
      //z *= sinHalfAngle;
      //float x2 = cosHalfAngle * vector[0] + y * vector[2] - z * vector[1];
      //float y2 = cosHalfAngle * vector[1] + z * vector[0] - x * vector[2];
      //float z2 = cosHalfAngle * vector[2] + x * vector[1] - y * vector[0];
      //float w2 = -x * vector[0] - y * vector[1] - z * vector[2];
      //Vector<float> result = new Vector<float>();
      //result[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
      //result[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
      //result[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
      if (vector.Dimensions == 3)
        throw new Error("my RotateBy() function is only defined for 3-component vectors.");
#endif

      Vector<float> result = new Vector<float>(3);
      float sinHalfAngle = Trigonometry.sin(angle / 2);
      float cosHalfAngle = Trigonometry.cos(angle / 2);
      x *= sinHalfAngle;
      y *= sinHalfAngle;
      z *= sinHalfAngle;

#if unsafe_code
      unsafe
      {
        fixed (float*
          vector_flat = vector._vector,
          result_flat = result._vector)
        {
          float x2 = cosHalfAngle * vector_flat[0] + y * vector_flat[2] - z * vector_flat[1];
          float y2 = cosHalfAngle * vector_flat[1] + z * vector_flat[0] - x * vector_flat[2];
          float z2 = cosHalfAngle * vector_flat[2] + x * vector_flat[1] - y * vector_flat[0];
          float w2 = -x * vector_flat[0] - y * vector_flat[1] - z * vector_flat[2];
          result_flat[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
          result_flat[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
          result_flat[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;
        }
      }
#else
      float[] vector_flat = vector._vector;
      float[] result_flat = result._vector;
      float x2 = cosHalfAngle * vector_flat[0] + y * vector_flat[2] - z * vector_flat[1];
      float y2 = cosHalfAngle * vector_flat[1] + z * vector_flat[0] - x * vector_flat[2];
      float z2 = cosHalfAngle * vector_flat[2] + x * vector_flat[1] - y * vector_flat[0];
      float w2 = -x * vector_flat[0] - y * vector_flat[1] - z * vector_flat[2];
      result_flat[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
      result_flat[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
      result_flat[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;
#endif

      return result;
    }

    /// <summary>Rotates a vector by a quaternion rotation.</summary>
    /// <param name="vector">The vector to be rotated.</param>
    /// <param name="quaternion">The rotation to be applied.</param>
    /// <returns>The vector after the rotation.</returns>
    public static Vector<float> RotateBy(Vector<float> vector, Quaternion<float> quaternion)
    {
      return Rotate(quaternion, vector);
    }

    /// <summary>Computes the linear interpolation between two vectors.</summary>
    /// <param name="left">The starting vector of the interpolation.</param>
    /// <param name="right">The ending vector of the interpolation.</param>
    /// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Vector<float> Lerp(Vector<float> left, Vector<float> right, float blend)
    {
      #region pre-optimization

      //Vector<float> result = new Vector<float>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] + blend * (right[i] - left[i]);
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (blend < 0 || blend > 1)
        throw new Error("invalid vector lerp blend value: (blend < 0.0f || blend > 1.0f).");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid vector lerp length: (left.Dimensions != right.Dimensions)");
#endif

      int length = left.Dimensions;
      Vector<float> result =
        new Vector<float>(length);

#if unsafe_code
      unsafe
      {
        fixed (float*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + blend * (right_flat[i] - left_flat[i]);
      }
#else
      float[] left_flat = left._vector;
      float[] right_flat = right._vector;
      float[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] + blend * (right_flat[i] - left_flat[i]);
#endif

      return result;
    }

    /// <summary>Sphereically interpolates between two vectors.</summary>
    /// <param name="left">The starting vector of the interpolation.</param>
    /// <param name="right">The ending vector of the interpolation.</param>
    /// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
    /// <returns>The result of the slerp operation.</returns>
    public static Vector<float> Slerp(Vector<float> left, Vector<float> right, float blend)
    {
      #region pre-optimization

      //float dot = LinearAlgebra.DotProduct(left, right);
      //dot = dot < -1 ? -1 : dot;
      //dot = dot > 1 ? 1 : dot;
      //float theta = Trigonometry.arccos(dot) * blend;
      //return LinearAlgebra.Multiply(LinearAlgebra.Add(LinearAlgebra.Multiply(left, Trigonometry.cos(theta)),
      //  LinearAlgebra.Normalize(LinearAlgebra.Subtract(right, LinearAlgebra.Multiply(left, dot)))), Trigonometry.sin(theta));

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (blend < 0 || blend > 1)
        throw new Error("invalid slerp blend value: (blend < 0.0f || blend > 1.0f).");
#endif

      float dot = LinearAlgebra.DotProduct(left, right);
      dot = dot < -1 ? -1 : dot;
      dot = dot > 1 ? 1 : dot;
      float theta = Trigonometry.arccos(dot) * blend;
      return LinearAlgebra.Multiply(LinearAlgebra.Add(LinearAlgebra.Multiply(left, Trigonometry.cos(theta)),
        LinearAlgebra.Normalize(LinearAlgebra.Subtract(right, LinearAlgebra.Multiply(left, dot)))), Trigonometry.sin(theta));
    }

    /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
    /// <param name="a">The first vector of the interpolation.</param>
    /// <param name="b">The second vector of the interpolation.</param>
    /// <param name="c">The thrid vector of the interpolation.</param>
    /// <param name="u">The "U" value of the barycentric interpolation equation.</param>
    /// <param name="v">The "V" value of the barycentric interpolation equation.</param>
    /// <returns>The resulting vector of the barycentric interpolation.</returns>
    public static Vector<float> Blerp(Vector<float> a, Vector<float> b, Vector<float> c, float u, float v)
    {
      #region pre-optimization

      //return 
      //  LinearAlgebra.Add(
      //    LinearAlgebra.Add(
      //      LinearAlgebra.Multiply(
      //        LinearAlgebra.Subtract(b, a), u),
      //          LinearAlgebra.Multiply(
      //            LinearAlgebra.Subtract(c, a), v)), a);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(a, null))
        throw new Error("null reference: a");
      if (object.ReferenceEquals(b, null))
        throw new Error("null reference: b");
      if (object.ReferenceEquals(c, null))
        throw new Error("null reference: c");
#endif

      return
        LinearAlgebra.Add(
          LinearAlgebra.Add(
            LinearAlgebra.Multiply(
              LinearAlgebra.Subtract(b, a), u),
                LinearAlgebra.Multiply(
                  LinearAlgebra.Subtract(c, a), v)), a);
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Vector<float> left, Vector<float> right)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;

      //if (left.Dimensions != right.Dimensions)
      //  return false;
      //for (int i = 0; i < left.Dimensions; i++)
      //  if (left[i] != right[i])
      //    return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Dimensions != right.Dimensions)
        return false;
      for (int i = 0; i < left.Dimensions; i++)
        if (left[i] != right[i])
          return false;
      return true;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Vector<float> left, Vector<float> right, float leniency)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;

      //if (left.Dimensions != right.Dimensions)
      //  return false;
      //for (int i = 0; i < left.Dimensions; i++)
      //  if (Logic.Abs(left[i] - right[i]) > leniency)
      //    return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Dimensions != right.Dimensions)
        return false;
      for (int i = 0; i < left.Dimensions; i++)
        if (Logic.Abs(left[i] - right[i]) > leniency)
          return false;
      return true;
    }

    #endregion

    #region matrix

    /// <summary>Determines if a matrix is symetric or not.</summary>
    /// <param name="matrix">The matrix to determine symetry of.</param>
    /// <returns>True if symetric; false if not.</returns>
    public static bool IsSymmetric(Matrix<float> matrix)
    {
      #region pre-optimization

      //if (matrix.Rows != matrix.Columns)
      //  return false;
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    if (matrix[i, j] != matrix[j, i])
      //      return false;
      //return true;

      #endregion

#if no_errorchecking
      //nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        return false;
#endif
      int size = matrix.Columns;
#if unsafe_code
      unsafe
      {
        fixed (float* matrix_flat = matrix._matrix)
          for (var row = 0; row < size; row++)
            for (var column = row + 1; column < size; column++)
              if (matrix_flat[row * size + column] != matrix_flat[column * size + row])
                return false;
      }
#else
      float[] matrix_flat = matrix._matrix;
      for (var row = 0; row < size; row++)
        for (var column = row + 1; column < size; column++)
          if (matrix_flat[row * size + column] != matrix_flat[column * size + row])
            return false;
#endif
      return true;
    }

    /// <summary>Constructs a new identity-matrix of the given dimensions.</summary>
    /// <param name="rows">The number of rows of the matrix.</param>
    /// <param name="columns">The number of columns of the matrix.</param>
    /// <returns>The newly constructed identity-matrix.</returns>
    public static Matrix<float> MatrixFactoryIdentity_float(int rows, int columns)
    {
      #region pre-optimization

      //Matrix<float> matrix = 
      //  new Matrix<float>(rows, columns);
      //for (int i = 0; i < Logic.Min(rows, columns); i++)
      //  matrix[i, i] = 1;
      //return matrix;

      #endregion

#if no_error_checking
      //nothing
#else
      if (rows < 1)
        throw new Error("invalid row count on matrix creation");
      if (columns < 1)
        throw new Error("invalid column count on matrix creation");
#endif

      Matrix<float> matrix = new Matrix<float>(rows, columns);
      if (rows <= columns)
        for (int i = 0; i < rows; i++)
          matrix[i, i] = 1;
      else
        for (int i = 0; i < columns; i++)
          matrix[i, i] = 1;
      return matrix;
    }

    /// <summary>Negates all the values in a matrix.</summary>
    /// <param name="matrix">The matrix to have its values negated.</param>
    /// <returns>The resulting matrix after the negations.</returns>
    public static Matrix<float> Negate(Matrix<float> matrix)
    {
      #region pre-optimization

      //Matrix<float> result =
      //  new Matrix<float>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Rows; j++)
      //    result[i, j] = -matrix[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
        if (object.ReferenceEquals(matrix, null))
          throw new Error("null reference: matirx");
#endif

      Matrix<float> result =
        new Matrix<float>(matrix.Rows, matrix.Columns);
      int size = matrix.Rows * matrix.Columns;

#if unsafe_code
      unsafe
      {
        fixed (float*
          result_flat = result._matrix,
          matrix_flat = matrix._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = -matrix_flat[i];
        return result;
      }
#else
      float[] result_flat = result._matrix;
      float[] matrix_flat = matrix._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = -matrix_flat[i];
      return result;
#endif
    }

    /// <summary>Negates all the values in a matrix.</summary>
    /// <param name="matrix">The matrix to have its values negated.</param>
    /// <returns>The resulting matrix after the negations.</returns>
    public static Matrix<float> Negate_parallel(Matrix<float> matrix)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matirx");
#endif

      if (matrix.Rows * matrix.Columns > _parallelMinimum)
      {
        Matrix<float> result =
        new Matrix<float>(matrix.Rows, matrix.Columns);
        int size = matrix.Rows * matrix.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (float*
                  result_flat = result._matrix,
                  matrix_flat = matrix._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = -matrix_flat[i];
              };
            }, Logic.Max(matrix.Rows, matrix.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                float[] matrix_flat = matrix._matrix;
                float[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = -matrix_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Negate(matrix);
    }

    /// <summary>Does standard addition of two matrices.</summary>
    /// <param name="left">The left matrix of the addition.</param>
    /// <param name="right">The right matrix of the addition.</param>
    /// <returns>The resulting matrix after the addition.</returns>
    public static Matrix<float> Add(Matrix<float> left, Matrix<float> right)
    {
      #region pre-optimization

      //Matrix<float> result =
      //  new Matrix<float>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] + right[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
          throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix addition (dimension miss-match).");
#endif

      Matrix<float> result =
        new Matrix<float>(left.Rows, left.Columns);
      int size = left.Rows * left.Columns;

#if unsafe_code
      unsafe
      {
        fixed (float*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
      }
#else
      float[] left_flat = left._matrix;
      float[] right_flat = right._matrix;
      float[] result_flat = result._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = left_flat[i] + right_flat[i];
#endif

      return result;
    }

    /// <summary>Does standard addition of two matrices.</summary>
    /// <param name="left">The left matrix of the addition.</param>
    /// <param name="right">The right matrix of the addition.</param>
    /// <returns>The resulting matrix after the addition.</returns>
    public static Matrix<float> Add_parallel(Matrix<float> left, Matrix<float> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix addition (dimension miss-match).");
#endif

      if (left.Rows * left.Columns > _parallelMinimum)
      {
        Matrix<float> result =
        new Matrix<float>(left.Rows, left.Columns);
        int size = left.Rows * left.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (float*
                  left_flat = left._matrix,
                  right_flat = right._matrix,
                  result_flat = result._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = left_flat[i] + right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                float[] left_flat = left._matrix;
                float[] right_flat = right._matrix;
                float[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = left_flat[i] + right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Add(left, right);
    }

    /// <summary>Subtracts a scalar from all the values in a matrix.</summary>
    /// <param name="left">The matrix to have the values subtracted from.</param>
    /// <param name="right">The scalar to subtract from all the matrix values.</param>
    /// <returns>The resulting matrix after the subtractions.</returns>
    public static Matrix<float> Subtract(Matrix<float> left, Matrix<float> right)
    {
      #region pre-optimization

      //Matrix<float> result =
      //  new Matrix<float>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] - right[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix subtraction (dimension miss-match).");
#endif

      Matrix<float> result =
        new Matrix<float>(left.Rows, left.Columns);
      int size = left.Rows * left.Columns;

#if unsafe_code
      unsafe
      {
        fixed (float*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = left_flat[i] - right_flat[i];
      }
#else
      float[] left_flat = left._matrix;
      float[] right_flat = right._matrix;
      float[] result_flat = result._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = left_flat[i] - right_flat[i];
#endif

      return result;
    }

    /// <summary>Subtracts a scalar from all the values in a matrix.</summary>
    /// <param name="left">The matrix to have the values subtracted from.</param>
    /// <param name="right">The scalar to subtract from all the matrix values.</param>
    /// <returns>The resulting matrix after the subtractions.</returns>
    public static Matrix<float> Subtract_parallel(Matrix<float> left, Matrix<float> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix subtraction (dimension miss-match).");
#endif

      if (left.Rows * left.Columns > _parallelMinimum)
      {
        Matrix<float> result =
        new Matrix<float>(left.Rows, left.Columns);
        int size = left.Rows * left.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (float*
                  left_flat = left._matrix,
                  right_flat = right._matrix,
                  result_flat = result._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = left_flat[i] - right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
          (int current, int max) =>
          {
            return () =>
            {
              float[] left_flat = left._matrix;
              float[] right_flat = right._matrix;
              float[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = left_flat[i] - right_flat[i];
            };
          }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Subtract(left, right);
    }

    /// <summary>Performs multiplication on two matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Matrix<float> Multiply(Matrix<float> left, Matrix<float> right)
    {
      #region pre-optimization

      //Matrix<float> result = 
      //  new Matrix<float>(left.Rows, right.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < right.Columns; j++)
      //    for (int k = 0; k < left.Columns; k++)
      //      result[i, j] += left[i, k] * right[k, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (left == null)
        throw new Error("null reference: left");
      if (right == null)
        throw new Error("null reference: right");
      if (left.Columns != right.Rows)
        throw new LinearAlgebra.Error("invalid multiplication (size miss-match).");
#endif

      float sum;
      int result_rows = left.Rows;
      int left_cols = left.Columns;
      int result_cols = right.Columns;
      Matrix<float> result =
        new Matrix<float>(result_rows, result_cols);

#if unsafe_code
      unsafe
      {
        fixed (float*
          result_flat = result._matrix,
          left_flat = left._matrix,
          right_flat = right._matrix)
          for (int i = 0; i < result_rows; i++)
            for (int j = 0; j < result_cols; j++)
            {
              sum = 0;
              for (int k = 0; k < left_cols; k++)
                sum += left_flat[i * left_cols + k] * right_flat[k * result_cols + j];
              result_flat[i * result_cols + j] = sum;
            }
      }
#else
      float[] result_flat = result._matrix;
      float[] left_flat = left._matrix;
      float[] right_flat = right._matrix;

      for (int i = 0; i < result_rows; i++)
        for (int j = 0; j < result_cols; j++)
        {
          sum = 0;
          for (int k = 0; k < left_cols; k++)
            sum += left_flat[i * left_cols + k] * right_flat[k * result_cols + j];
          result_flat[i * result_cols + j] = sum;
        }
#endif

      return result;
    }

    /// <summary>Performs multiplication on two matrices using multi-threading.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Matrix<float> Multiply_parrallel(Matrix<float> left, Matrix<float> right)
    {
#if no_error_checking
      // nothing
#else
      if (left == null)
        throw new Error("null reference: left");
      if (right == null)
        throw new Error("null reference: right");
      if (left.Columns != right.Rows)
        throw new LinearAlgebra.Error("invalid multiplication (dimension miss-match).");
#endif

      int result_rows = left.Rows;
      int left_cols = left.Columns;
      int result_cols = right.Columns;

      // If there are enough rows to warrant multi-threading,
      // then multithread the row for-loop.
      if (result_rows * result_cols > _parallelMinimum &&
        result_rows >= result_cols)
      {
        Matrix<float> result =
          new Matrix<float>(result_rows, result_cols);
#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                float sum;
                int left_i_offest;
                int result_i_offset;

                fixed (float*
                  result_flat = result._matrix,
                  left_flat = left._matrix,
                  right_flat = right._matrix)
                  for (int i = current; i < result_rows; i += max)
                  {
                    left_i_offest = i * left_cols;
                    result_i_offset = i * result_cols;
                    for (int j = 0; j < result_cols; j++)
                    {
                      sum = 0;
                      for (int k = 0; k < left_cols; k++)
                        sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                      result_flat[result_i_offset + j] = sum;
                    }
                  }
              };
            }, result_rows);
        }
#else
              float[] result_flat = result._matrix;
              float[] left_flat = left._matrix;
              float[] right_flat = right._matrix;

              Seven.Parallels.AutoParallel.Divide(
                  (int current, int max) =>
                  {
                    return () =>
                    {
                      float sum;
                      int left_i_offest;
                      int result_i_offset;

                      for (int i = current; i < result_rows; i += max)
                      {
                        left_i_offest = i * left_cols;
                        result_i_offset = i * result_cols;
                        for (int j = 0; j < result_cols; j++)
                        {
                          sum = 0;
                          for (int k = 0; k < left_cols; k++)
                            sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                          result_flat[result_i_offset + j] = sum;
                        }
                      }
                    };
                  }, result_rows);

#endif
        return result;
      }
      // If there are enough columns to warrant multi-threading,
      // then multithread the column for-loop.
      else if (result_rows * result_cols > _parallelMinimum &&
        result_rows < result_cols)
      {
        Matrix<float> result =
          new Matrix<float>(result_rows, result_cols);
#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                float sum;
                int left_i_offest;
                int result_i_offset;

                fixed (float*
                  result_flat = result._matrix,
                  left_flat = left._matrix,
                  right_flat = right._matrix)
                  for (int i = 0; i < result_rows; i++)
                  {
                    left_i_offest = i * left_cols;
                    result_i_offset = i * result_cols;
                    for (int j = current; j < result_cols; j += max)
                    {
                      sum = 0;
                      for (int k = 0; k < left_cols; k++)
                        sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                      result_flat[result_i_offset + j] = sum;
                    }
                  }
              };
            }, result_cols);
        }
#else
              float[] result_flat = result._matrix;
              float[] left_flat = left._matrix;
              float[] right_flat = right._matrix;

              Seven.Parallels.AutoParallel.Divide(
                  (int current, int max) =>
                  {
                    return () =>
                    {
                      float sum;
                      int left_i_offest;
                      int result_i_offset;

                      for (int i = 0; i < result_rows; i++)
                      {
                        left_i_offest = i * left_cols;
                        result_i_offset = i * result_cols;
                        for (int j = current; j < result_cols; j += max)
                        {
                          sum = 0;
                          for (int k = 0; k < left_cols; k++)
                            sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                          result_flat[result_i_offset + j] = sum;
                        }
                      }
                    };
                  }, result_cols);
#endif
        return result;
      }
      // Multi-threading is not necessary.
      else
        return LinearAlgebra.Multiply(left, right);
    }

    /// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Vector<float> Multiply(Matrix<float> left, Vector<float> right)
    {
      #region pre-optimization

      //Vector<float> result = 
      //  new Vector<float>(right.Dimensions);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i] += left[i, j] * right[j];
      //return result;

      #endregion

#if no_error_checking
      int left_row = left.Rows;
      int left_col = left.Columns;
#else
      int left_row = left.Rows;
      int left_col = left.Columns;
      if (left.Columns != right.Dimensions)
        throw new Error("invalid multiplication (size miss-match).");
#endif

      Vector<float> result = new Vector<float>(right.Dimensions);

#if unsafe_code
      unsafe
      {
        fixed (float*
          left_flat = left._matrix,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < left_row; i++)
            for (int j = 0; j < left_col; j++)
              result_flat[i] += left_flat[i * left_col + j] * right_flat[j];
        return result;
      }
#else
      float[] left_flat = left._matrix;
      float[] right_flat = right._vector;
      float[] result_flat = result._vector;
      for (int i = 0; i < left_row; i++)
        for (int j = 0; j < left_col; j++)
          result_flat[i] += left_flat[i * left_col + j] * right_flat[j];
      return result;
#endif
      return result;
    }

    /// <summary>Multiplies all the values in a matrix by a scalar.</summary>
    /// <param name="left">The matrix to have the values multiplied.</param>
    /// <param name="right">The scalar to multiply the values by.</param>
    /// <returns>The resulting matrix after the multiplications.</returns>
    public static Matrix<float> Multiply(Matrix<float> left, float right)
    {
      #region pre-optimization

      //Matrix<float> result = 
      //  new Matrix<float>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] * right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      int rows = left.Rows;
      int columns = left.Columns;
      Matrix<float> result = new Matrix<float>(rows, columns);

#if unsafe_code
      unsafe
      {
        fixed (float*
          left_flat = left._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
              result_flat[i * columns + j] = left_flat[i * columns + j] * right;
      }
#else
      for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
          result[i, j] = left[i, j] * right;
#endif

      return result;
    }

    /// <summary>Applies a power to a square matrix.</summary>
    /// <param name="matrix">The matrix to be powered by.</param>
    /// <param name="power">The power to apply to the matrix.</param>
    /// <returns>The resulting matrix of the power operation.</returns>
    public static Matrix<float> Power(Matrix<float> matrix, int power)
    {
      #region pre-optimization

      //Matrix<float> result = matrix.Clone();
      //for (int i = 0; i < power; i++)
      //  result = LinearAlgebra.Multiply(result, result);
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (!(matrix.Rows == matrix.Columns))
        throw new Error("invalid power (!matrix.IsSquare).");
      if (!(power >= 0))
        throw new Error("invalid power !(power > -1)");
#endif
      // this is not optimized...
      if (power == 0)
        return LinearAlgebra.MatrixFactoryIdentity_float(matrix.Rows, matrix.Columns);
      Matrix<float> result = matrix.Clone();
      for (int i = 0; i < power; i++)
        result = LinearAlgebra.Multiply(result, matrix);
      return result;
    }

    /// <summary>Divides all the values in the matrix by a scalar.</summary>
    /// <param name="matrix">The matrix to divide the values of.</param>
    /// <param name="right">The scalar to divide all the matrix values by.</param>
    /// <returns>The resulting matrix with the divided values.</returns>
    public static Matrix<float> Divide(Matrix<float> matrix, float right)
    {
      #region pre-optimization

      //Matrix<float> result = 
      //  new Matrix<float>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    result[i, j] = matrix[i, j] / right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      int matrix_row = matrix.Rows;
      int matrix_col = matrix.Columns;
      Matrix<float> result =
        new Matrix<float>(matrix_row, matrix_col);

#if unsafe_code
      unsafe
      {
        fixed (float*
          matrix_flat = matrix._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < matrix_row; i++)
            for (int j = 0; j < matrix_col; j++)
              result_flat[i * matrix_col + j] =
                matrix_flat[i * matrix_col + j] / right;
      }
#else
      float[] matrix_flat = matrix._matrix;
      float[] result_flat = result._matrix;
      for (int i = 0; i < matrix_row; i++)
        for (int j = 0; j < matrix_col; j++)
          result_flat[i * matrix_col + j] = 
            matrix_flat[i * matrix_col + j] / right;

#endif
      return result;
    }

    /// <summary>Gets the minor of a matrix.</summary>
    /// <param name="matrix">The matrix to get the minor of.</param>
    /// <param name="row">The restricted row to form the minor.</param>
    /// <param name="column">The restricted column to form the minor.</param>
    /// <returns>The minor of the matrix.</returns>
    public static Matrix<float> Minor(Matrix<float> matrix, int row, int column)
    {
      #region pre-optimization

      //Matrix<float> minor = 
      //  new Matrix<float>(matrix.Rows - 1, matrix.Columns - 1);
      //int m = 0, n = 0;
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (i == row) continue;
      //  n = 0;
      //  for (int j = 0; j < matrix.Columns; j++)
      //  {
      //    if (j == column) continue;
      //    minor[m, n] = matrix[i, j];
      //    n++;
      //  }
      //  m++;
      //}
      //return minor;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows < 2 || matrix.Columns < 2)
        throw new Error("invalid matrix minor: (matrix.Rows < 2 || matrix.Columns < 2)");
      if (row < 0 || row >= matrix.Rows)
        throw new Error("invalid row on matrix minor: !(0 <= row < matrix.Rows)");
      if (column < 0 || row >= matrix.Columns)
        throw new Error("invalid column on matrix minor: !(0 <= column < matrix.Columns)");
#endif

      Matrix<float> minor =
        new Matrix<float>(matrix.Rows - 1, matrix.Columns - 1);
      int matrix_rows = matrix.Rows;
      int matrix_cols = matrix.Columns;

#if unsafe_code
      unsafe
      {
        fixed (float*
          matrix_flat = matrix._matrix,
          minor_flat = minor._matrix)
        {
          int m = 0, n = 0;
          for (int i = 0; i < matrix_rows; i++)
          {
            if (i == row) continue;
            n = 0;
            for (int j = 0; j < matrix_cols; j++)
            {
              if (j == column) continue;
              minor_flat[m * matrix_cols + n] =
                matrix_flat[i * matrix_cols + j];
              n++;
            }
            m++;
          }
        }
      }
#else
      int m = 0, n = 0;
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (i == row) continue;
        n = 0;
        for (int j = 0; j < matrix.Columns; j++)
        {
          if (j == column) continue;
          minor[m, n] = matrix[i, j];
          n++;
        }
        m++;
      }
#endif
      return minor;
    }

    /// <summary>Combines two matrices from left to right 
    /// (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
    /// <param name="left">The left matrix of the concatenation.</param>
    /// <param name="right">The right matrix of the concatenation.</param>
    /// <returns>The resulting matrix of the concatenation.</returns>
    public static Matrix<float> ConcatenateRowWise(Matrix<float> left, Matrix<float> right)
    {
      #region pre-optimization

      //Matrix<float> result =
      //  new Matrix<float>(left.Rows, left.Columns + right.Columns);
      //for (int i = 0; i < result.Rows; i++)
      //  for (int j = 0; j < result.Columns; j++)
      //    if (j < left.Columns)
      //      result[i, j] = left[i, j];
      //    else
      //      result[i, j] = right[i, j - left.Columns];
      //return result;

      #endregion

#if no_errorChecking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows)
        throw new Error("invalid row-wise concatenation !(left.Rows == right.Rows).");
#endif

      Matrix<float> result =
        new Matrix<float>(left.Rows, left.Columns + right.Columns);
      int result_rows = result.Rows;
      int result_cols = result.Columns;

      int left_cols = left.Columns;
      int right_cols = right.Columns;

#if unsafe_code
      unsafe
      {
        // OptimizeMe (jump statement)
        fixed (float*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < result_rows; i++)
            for (int j = 0; j < result_cols; j++)
              if (j < left_cols)
                result_flat[i * result_cols + j] =
                  left_flat[i * left_cols + j];
              else
                result_flat[i * result_cols + j] =
                  right_flat[i * right_cols + j - left_cols];
      }
#else
      for (int i = 0; i < result_rows; i++)
        for (int j = 0; j < result_cols; j++)
        {
          if (j < left.Columns)
            result[i, j] = left[i, j];
          else
            result[i, j] = right[i, j - left.Columns];
        }
#endif

      return result;
    }

    /// <summary>Calculates the echelon of a matrix (aka REF).</summary>
    /// <param name="matrix">The matrix to calculate the echelon of (aka REF).</param>
    /// <returns>The echelon of the matrix (aka REF).</returns>
    public static Matrix<float> Echelon(Matrix<float> matrix)
    {
      #region pre-optimization

      //Matrix<float> result = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (result[i, i] == 0)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] != 0)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  if (result[i, i] == 0)
      //    continue;
      //  if (result[i, i] != 1)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] == 1)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
      //  for (int j = i + 1; j < result.Rows; j++)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<float> result = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (result[i, i] == 0)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] != 0)
              LinearAlgebra.SwapRows(result, i, j);
        if (result[i, i] == 0)
          continue;
        if (result[i, i] != 1)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] == 1)
              LinearAlgebra.SwapRows(result, i, j);
        LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
        for (int j = i + 1; j < result.Rows; j++)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      }
      return result;
    }

    /// <summary>Calculates the echelon of a matrix and reduces it (aka RREF).</summary>
    /// <param name="matrix">The matrix matrix to calculate the reduced echelon of (aka RREF).</param>
    /// <returns>The reduced echelon of the matrix (aka RREF).</returns>
    public static Matrix<float> ReducedEchelon(Matrix<float> matrix)
    {
      #region pre-optimization

      //Matrix<float> result = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (result[i, i] == 0)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] != 0)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  if (result[i, i] == 0) continue;
      //  if (result[i, i] != 1)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] == 1)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
      //  for (int j = i + 1; j < result.Rows; j++)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      //  for (int j = i - 1; j >= 0; j--)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<float> result = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (result[i, i] == 0)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] != 0)
              LinearAlgebra.SwapRows(result, i, j);
        if (result[i, i] == 0) continue;
        if (result[i, i] != 1)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] == 1)
              LinearAlgebra.SwapRows(result, i, j);
        LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
        for (int j = i + 1; j < result.Rows; j++)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
        for (int j = i - 1; j >= 0; j--)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      }
      return result;
    }

    /// <summary>Calculates the determinent of a square matrix.</summary>
    /// <param name="matrix">The matrix to calculate the determinent of.</param>
    /// <returns>The determinent of the matrix.</returns>
    public static float Determinent(Matrix<float> matrix)
    {
      #region pre-optimization

      //float det = 1;
      //Matrix<float> rref = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (rref[i, i] == 0)
      //    for (int j = i + 1; j < rref.Rows; j++)
      //      if (rref[j, i] != 0)
      //      {
      //        LinearAlgebra.SwapRows(rref, i, j);
      //        det *= -1;
      //      }
      //  det *= rref[i, i];
      //  LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
      //  for (int j = i + 1; j < rref.Rows; j++)
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  for (int j = i - 1; j >= 0; j--)
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //}
      //return det;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        throw new Error("invalid matrix determinent: !(matrix.IsSquare)");
#endif

      float det = 1;
      Matrix<float> rref = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (rref[i, i] == 0)
          for (int j = i + 1; j < rref.Rows; j++)
            if (rref[j, i] != 0)
            {
              LinearAlgebra.SwapRows(rref, i, j);
              det *= -1;
            }
        det *= rref[i, i];
        LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
        for (int j = i + 1; j < rref.Rows; j++)
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        for (int j = i - 1; j >= 0; j--)
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      }
      return det;
    }

    /// <summary>Calculates the inverse of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the inverse of.</param>
    /// <returns>The inverse of the matrix.</returns>
    public static Matrix<float> Inverse(Matrix<float> matrix)
    {
      #region pre-optimization

      //Matrix<float> identity = 
      //  LinearAlgebra.MatrixFactoryIdentity_float(matrix.Rows, matrix.Columns);
      //Matrix<float> rref = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (rref[i, i] == 0)
      //    for (int j = i + 1; j < rref.Rows; j++)
      //      if (rref[j, i] != 0)
      //      {
      //        LinearAlgebra.SwapRows(rref, i, j);
      //        LinearAlgebra.SwapRows(identity, i, j);
      //      }
      //  LinearAlgebra.RowMultiplication(identity, i, 1 / rref[i, i]);
      //  LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
      //  for (int j = i + 1; j < rref.Rows; j++)
      //  {
      //    LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  }
      //  for (int j = i - 1; j >= 0; j--)
      //  {
      //    LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  }
      //}
      //return identity;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (LinearAlgebra.Determinent(matrix) == 0)
        throw new Error("inverse calculation failed.");
#endif

      Matrix<float> identity = LinearAlgebra.MatrixFactoryIdentity_float(matrix.Rows, matrix.Columns);
      Matrix<float> rref = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (rref[i, i] == 0)
          for (int j = i + 1; j < rref.Rows; j++)
            if (rref[j, i] != 0)
            {
              LinearAlgebra.SwapRows(rref, i, j);
              LinearAlgebra.SwapRows(identity, i, j);
            }
        LinearAlgebra.RowMultiplication(identity, i, 1 / rref[i, i]);
        LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
        for (int j = i + 1; j < rref.Rows; j++)
        {
          LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        }
        for (int j = i - 1; j >= 0; j--)
        {
          LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        }
      }
      return identity;
    }

    /// <summary>Calculates the adjoint of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the adjoint of.</param>
    /// <returns>The adjoint of the matrix.</returns>
    public static Matrix<float> Adjoint(Matrix<float> matrix)
    {
      #region pre-optimization

      //Matrix<float> AdjointMatrix = new Matrix<float>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    if ((i + j) % 2 == 0)
      //      AdjointMatrix[i, j] = LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      //    else
      //      AdjointMatrix[i, j] = -LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      //return LinearAlgebra.Transpose(AdjointMatrix);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (!(matrix.Rows == matrix.Columns))
        throw new Error("Adjoint of a non-square matrix does not exists");
#endif

      Matrix<float> AdjointMatrix = new Matrix<float>(matrix.Rows, matrix.Columns);
      for (int i = 0; i < matrix.Rows; i++)
        for (int j = 0; j < matrix.Columns; j++)
          if ((i + j) % 2 == 0)
            AdjointMatrix[i, j] = LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
          else
            AdjointMatrix[i, j] = -LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      return LinearAlgebra.Transpose(AdjointMatrix);
    }

    /// <summary>Returns the transpose of a matrix.</summary>
    /// <param name="matrix">The matrix to transpose.</param>
    /// <returns>The transpose of the matrix.</returns>
    public static Matrix<float> Transpose(Matrix<float> matrix)
    {
      #region pre-optimization

      //Matrix<float> transpose = 
      //  new Matrix<float>(matrix.Columns, matrix.Rows);
      //for (int i = 0; i < transpose.Rows; i++)
      //  for (int j = 0; j < transpose.Columns; j++)
      //    transpose[i, j] = matrix[j, i];
      //return transpose;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<float> transpose =
        new Matrix<float>(matrix.Columns, matrix.Rows);
      for (int i = 0; i < transpose.Rows; i++)
        for (int j = 0; j < transpose.Columns; j++)
          transpose[i, j] = matrix[j, i];
      return transpose;
    }

    /// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
    /// <param name="matrix">The matrix to decompose.</param>
    /// <param name="Lower">The computed lower triangular matrix.</param>
    /// <param name="Upper">The computed upper triangular matrix.</param>
    public static void DecomposeLU(Matrix<float> matrix, out Matrix<float> Lower, out Matrix<float> Upper)
    {
      #region pre-optimization

      //Lower = LinearAlgebra.MatrixFactoryIdentity_float(matrix.Rows, matrix.Columns);
      //Upper = matrix.Clone();
      //int[] permutation = new int[matrix.Rows];
      //for (int i = 0; i < matrix.Rows; i++) permutation[i] = i;
      //float p = 0, pom2, detOfP = 1;
      //int k0 = 0, pom1 = 0;
      //for (int k = 0; k < matrix.Columns - 1; k++)
      //{
      //  p = 0;
      //  for (int i = k; i < matrix.Rows; i++)
      //    if ((Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k]) > p)
      //    {
      //      p = Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k];
      //      k0 = i;
      //    }
      //  if (p == 0)
      //    throw new Error("The matrix is singular!");
      //  pom1 = permutation[k];
      //  permutation[k] = permutation[k0];
      //  permutation[k0] = pom1;
      //  for (int i = 0; i < k; i++)
      //  {
      //    pom2 = Lower[k, i];
      //    Lower[k, i] = Lower[k0, i];
      //    Lower[k0, i] = pom2;
      //  }
      //  if (k != k0)
      //    detOfP *= -1;
      //  for (int i = 0; i < matrix.Columns; i++)
      //  {
      //    pom2 = Upper[k, i];
      //    Upper[k, i] = Upper[k0, i];
      //    Upper[k0, i] = pom2;
      //  }
      //  for (int i = k + 1; i < matrix.Rows; i++)
      //  {
      //    Lower[i, k] = Upper[i, k] / Upper[k, k];
      //    for (int j = k; j < matrix.Columns; j++)
      //      Upper[i, j] = Upper[i, j] - Lower[i, k] * Upper[k, j];
      //  }
      //}

      #endregion

#if no_error_checking
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        throw new Error("non-square matrix during DecomposeLU function");
#endif

      Lower = LinearAlgebra.MatrixFactoryIdentity_float(matrix.Rows, matrix.Columns);
      Upper = matrix.Clone();
      int[] permutation = new int[matrix.Rows];
      for (int i = 0; i < matrix.Rows; i++) permutation[i] = i;
      float p = 0, pom2, detOfP = 1;
      int k0 = 0, pom1 = 0;
      for (int k = 0; k < matrix.Columns - 1; k++)
      {
        p = 0;
        for (int i = k; i < matrix.Rows; i++)
          if ((Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k]) > p)
          {
            p = Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k];
            k0 = i;
          }
        if (p == 0)
          throw new Error("The matrix is singular!");
        pom1 = permutation[k];
        permutation[k] = permutation[k0];
        permutation[k0] = pom1;
        for (int i = 0; i < k; i++)
        {
          pom2 = Lower[k, i];
          Lower[k, i] = Lower[k0, i];
          Lower[k0, i] = pom2;
        }
        if (k != k0)
          detOfP *= -1;
        for (int i = 0; i < matrix.Columns; i++)
        {
          pom2 = Upper[k, i];
          Upper[k, i] = Upper[k0, i];
          Upper[k0, i] = pom2;
        }
        for (int i = k + 1; i < matrix.Rows; i++)
        {
          Lower[i, k] = Upper[i, k] / Upper[k, k];
          for (int j = k; j < matrix.Columns; j++)
            Upper[i, j] = Upper[i, j] - Lower[i, k] * Upper[k, j];
        }
      }
    }

    private static void RowMultiplication(Matrix<float> matrix, int row, float scalar)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //  matrix[row, j] *= scalar;

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
        matrix[row, j] *= scalar;
    }

    private static void RowAddition(Matrix<float> matrix, int target, int second, float scalar)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //  matrix[target, j] += (matrix[second, j] * scalar);

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
        matrix[target, j] += (matrix[second, j] * scalar);
    }

    private static void SwapRows(Matrix<float> matrix, int row1, int row2)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //{
      //  float temp = matrix[row1, j];
      //  matrix[row1, j] = matrix[row2, j];
      //  matrix[row2, j] = temp;
      //}

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
      {
        float temp = matrix[row1, j];
        matrix[row1, j] = matrix[row2, j];
        matrix[row2, j] = temp;
      }
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Matrix<float> left, Matrix<float> right)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;
      //if (left.Rows != right.Rows || left.Columns != right.Columns)
      //  return false;
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    if (left[i, j] != right[i, j])
      //      return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Rows != right.Rows || left.Columns != right.Columns)
        return false;
      for (int i = 0; i < left.Rows; i++)
        for (int j = 0; j < left.Columns; j++)
          if (left[i, j] != right[i, j])
            return false;

      return true;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Matrix<float> left, Matrix<float> right, float leniency)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;
      //if (left.Rows != right.Rows || left.Columns != right.Columns)
      //  return false;
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    if (Logic.Abs(left[i, j] - right[i, j]) > leniency)
      //      return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        return false;
      for (int i = 0; i < left.Rows; i++)
        for (int j = 0; j < left.Columns; j++)
          if (Logic.Abs(left[i, j] - right[i, j]) > leniency)
            return false;
      return true;
    }

    #endregion

    #region quaterion

    /// <summary>Computes the length of quaternion.</summary>
    /// <param name="quaternion">The quaternion to compute the length of.</param>
    /// <returns>The length of the given quaternion.</returns>
    public static float Magnitude(Quaternion<float> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return Algebra.sqrt(
          (quaternion.X * quaternion.X +
          quaternion.Y * quaternion.Y +
          quaternion.Z * quaternion.Z +
          quaternion.W * quaternion.W));
    }

    /// <summary>Computes the length of a quaternion, but doesn't square root it
    /// for optimization possibilities.</summary>
    /// <param name="quaternion">The quaternion to compute the length squared of.</param>
    /// <returns>The squared length of the given quaternion.</returns>
    public static float MagnitudeSquared(Quaternion<float> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return
        quaternion.X * quaternion.X +
        quaternion.Y * quaternion.Y +
        quaternion.Z * quaternion.Z +
        quaternion.W * quaternion.W;
    }

    /// <summary>Gets the conjugate of the quaternion.</summary>
    /// <param name="quaternion">The quaternion to conjugate.</param>
    /// <returns>The conjugate of teh given quaternion.</returns>
    public static Quaternion<float> Conjugate(Quaternion<float> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return new Quaternion<float>(
        -quaternion.X,
        -quaternion.Y,
        -quaternion.Z,
        quaternion.W);
    }

    /// <summary>Adds two quaternions together.</summary>
    /// <param name="left">The first quaternion of the addition.</param>
    /// <param name="right">The second quaternion of the addition.</param>
    /// <returns>The result of the addition.</returns>
    public static Quaternion<float> Add(Quaternion<float> left, Quaternion<float> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<float>(
        left.X + right.X,
        left.Y + right.Y,
        left.Z + right.Z,
        left.W + right.W);
    }

    /// <summary>Subtracts two quaternions.</summary>
    /// <param name="left">The left quaternion of the subtraction.</param>
    /// <param name="right">The right quaternion of the subtraction.</param>
    /// <returns>The resulting quaternion after the subtraction.</returns>
    public static Quaternion<float> Subtract(Quaternion<float> left, Quaternion<float> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<float>(
        left.X - right.X,
        left.Y - right.Y,
        left.Z - right.Z,
        left.W - right.W);
    }

    /// <summary>Multiplies two quaternions together.</summary>
    /// <param name="left">The first quaternion of the multiplication.</param>
    /// <param name="right">The second quaternion of the multiplication.</param>
    /// <returns>The resulting quaternion after the multiplication.</returns>
    public static Quaternion<float> Multiply(Quaternion<float> left, Quaternion<float> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<float>(
        left.X * right.W + left.W * right.X + left.Y * right.Z - left.Z * right.Y,
        left.Y * right.W + left.W * right.Y + left.Z * right.X - left.X * right.Z,
        left.Z * right.W + left.W * right.Z + left.X * right.Y - left.Y * right.X,
        left.W * right.W - left.X * right.X - left.Y * right.Y - left.Z * right.Z);
    }

    /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
    /// <param name="left">The quaternion of the multiplication.</param>
    /// <param name="right">The scalar of the multiplication.</param>
    /// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
    public static Quaternion<float> Multiply(Quaternion<float> left, float right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      return new Quaternion<float>(
        left.X * right,
        left.Y * right,
        left.Z * right,
        left.W * right);
    }

    /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
    /// <param name="left">The quaternion to pre-multiply the vector by.</param>
    /// <param name="right">The vector to be multiplied.</param>
    /// <returns>The resulting quaternion of the multiplication.</returns>
    public static Quaternion<float> Multiply(Quaternion<float> left, Vector<float> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (right.Dimensions != 3)
        throw new Error("my quaternion rotations are only defined for 3-component vectors.");
#endif

      return new Quaternion<float>(
        left.W * right.X + left.Y * right.Z - left.Z * right.Y,
        left.W * right.Y + left.Z * right.X - left.X * right.Z,
        left.W * right.Z + left.X * right.Y - left.Y * right.X,
        -left.X * right.X - left.Y * right.Y - left.Z * right.Z);
    }

    /// <summary>Normalizes the quaternion.</summary>
    /// <param name="quaternion">The quaternion to normalize.</param>
    /// <returns>The normalization of the given quaternion.</returns>
    public static Quaternion<float> Normalize(Quaternion<float> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      float normalizer = Quaternion<float>.Magnitude(quaternion);
      if (normalizer != 0)
        return quaternion * (1 / normalizer);
      else
        return Quaternion<float>.FactoryIdentity;
    }

    /// <summary>Inverts a quaternion.</summary>
    /// <param name="quaternion">The quaternion to find the inverse of.</param>
    /// <returns>The inverse of the given quaternion.</returns>
    public static Quaternion<float> Invert(Quaternion<float> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      float normalizer = Quaternion<float>.MagnitudeSquared(quaternion);
      if (normalizer == 0)
        return new Quaternion<float>(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
      normalizer = 1 / normalizer;
      return new Quaternion<float>(
        -quaternion.X * normalizer,
        -quaternion.Y * normalizer,
        -quaternion.Z * normalizer,
        quaternion.W * normalizer);
    }

    /// <summary>Lenearly interpolates between two quaternions.</summary>
    /// <param name="left">The starting point of the interpolation.</param>
    /// <param name="right">The ending point of the interpolation.</param>
    /// <param name="blend">The ratio 0.0-1.0 of how far to interpolate between the left and right quaternions.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Quaternion<float> Lerp(Quaternion<float> left, Quaternion<float> right, float blend)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      if (blend < 0 || blend > 1)
        throw new Error("invalid blending value during lerp !(blend < 0.0f || blend > 1.0f).");
      if (Quaternion<float>.MagnitudeSquared(left) == 0)
      {
        if (Quaternion<float>.MagnitudeSquared(right) == 0)
          return Quaternion<float>.FactoryIdentity;
        else
          return new Quaternion<float>(right.X, right.Y, right.Z, right.W);
      }
      else if (Quaternion<float>.MagnitudeSquared(right) == 0)
        return new Quaternion<float>(left.X, left.Y, left.Z, left.W);
      Quaternion<float> result = new Quaternion<float>(
        1 - blend * left.X + blend * right.X,
        1 - blend * left.Y + blend * right.Y,
        1 - blend * left.Z + blend * right.Z,
        1 - blend * left.W + blend * right.W);
      if (Quaternion<float>.MagnitudeSquared(result) > 0)
        return Quaternion<float>.Normalize(result);
      else
        return Quaternion<float>.FactoryIdentity;
    }

    /// <summary>Sphereically interpolates between two quaternions.</summary>
    /// <param name="left">The starting point of the interpolation.</param>
    /// <param name="right">The ending point of the interpolation.</param>
    /// <param name="blend">The ratio of how far to interpolate between the left and right quaternions.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Quaternion<float> Slerp(Quaternion<float> left, Quaternion<float> right, float blend)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      if (blend < 0 || blend > 1)
        throw new Error("invalid blending value during slerp !(blend < 0.0f || blend > 1.0f).");
      if (LinearAlgebra.MagnitudeSquared(left) == 0)
      {
        if (LinearAlgebra.MagnitudeSquared(right) == 0)
          return Quaternion<float>.FactoryIdentity;
        else
          return new Quaternion<float>(right.X, right.Y, right.Z, right.W);
      }
      else if (LinearAlgebra.MagnitudeSquared(right) == 0)
        return new Quaternion<float>(left.X, left.Y, left.Z, left.W);
      float cosHalfAngle = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
      if (cosHalfAngle >= 1 || cosHalfAngle <= -1)
        return new Quaternion<float>(left.X, left.Y, left.Z, left.W);
      else if (cosHalfAngle < 0)
      {
        right = new Quaternion<float>(-left.X, -left.Y, -left.Z, -left.W);
        cosHalfAngle = -cosHalfAngle;
      }
      float halfAngle = Trigonometry.arccos(cosHalfAngle);
      float sinHalfAngle = Trigonometry.sin(halfAngle);
      float blendA = Trigonometry.sin(halfAngle * (1 - blend)) / sinHalfAngle;
      float blendB = Trigonometry.sin(halfAngle * blend) / sinHalfAngle;
      Quaternion<float> result = new Quaternion<float>(
        blendA * left.X + blendB * right.X,
        blendA * left.Y + blendB * right.Y,
        blendA * left.Z + blendB * right.Z,
        blendA * left.W + blendB * right.W);
      if (LinearAlgebra.MagnitudeSquared(result) > 0)
        return LinearAlgebra.Normalize(result);
      else
        return Quaternion<float>.FactoryIdentity;
    }

    /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
    /// <param name="rotation">The quaternion to rotate the vector by.</param>
    /// <param name="vector">The vector to be rotated by.</param>
    /// <returns>The result of the rotation.</returns>
    public static Vector<float> Rotate(Quaternion<float> rotation, Vector<float> vector)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(rotation, null))
        throw new Error("null reference: rotation");
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      if (vector.Dimensions != 3 && vector.Dimensions != 4)
        throw new Error("my quaternion rotations are only defined for 3-component vectors.");
      Quaternion<float> answer = LinearAlgebra.Multiply(LinearAlgebra.Multiply(rotation, vector), LinearAlgebra.Conjugate(rotation));
      return new Vector<float>(answer.X, answer.Y, answer.Z);
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first quaternion to check for equality.</param>
    /// <param name="right">The second quaternion  to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Quaternion<float> left, Quaternion<float> right)
    {
      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      return
        left.X == right.X &&
        left.Y == right.Y &&
        left.Z == right.Z &&
        left.W == right.W;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first quaternion to check for equality.</param>
    /// <param name="right">The second quaternion to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Quaternion<float> left, Quaternion<float> right, float leniency)
    {
      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      return
        Logic.Abs(left.X - right.X) < leniency &&
        Logic.Abs(left.Y - right.Y) < leniency &&
        Logic.Abs(left.Z - right.Z) < leniency &&
        Logic.Abs(left.W - right.W) < leniency;
    }

    #endregion

    #region tableau

    //const float epsilon = 1.0e-8;
    ////int equal(float a, float b) { return fabs(a - b) < epsilon; }

    //static void pivot_on(ref float[,] tableau, int row, int col)
    //{
    //  int i, j;
    //  float pivot;

    //  pivot = tableau[row, col];
    //  if (!(pivot > 0))
    //    throw new Error("possible invalid tableau values (IDK)");
    //  for (j = 0; j < tableau.GetLength(1); j++)
    //    tableau[row, j] /= pivot;
    //  if (!(Logic.Equate(tableau[row, col], 1, epsilon)))
    //    throw new Error("possible invalid tableau values (IDK)");

    //  for (i = 0; i < tableau.GetLength(0); i++)
    //  { // foreach remaining row i do
    //    float multiplier = tableau[i, col];
    //    if (i == row) continue;
    //    for (j = 0; j < tableau.GetLength(1); j++)
    //    { // r[i] = r[i] - z * r[row];
    //      tableau[i, j] -= multiplier * tableau[row, j];
    //    }
    //  }
    //}

    //// Find pivot_col = most negative column in mat[0][1..n]
    //static int find_pivot_column(ref float[,] tableau)
    //{
    //  int j, pivot_col = 1;
    //  float lowest = tableau[0, pivot_col];
    //  for (j = 1; j < tableau.GetLength(1); j++)
    //  {
    //    if (tableau[0, j] < lowest)
    //    {
    //      lowest = tableau[0, j];
    //      pivot_col = j;
    //    }
    //  }
    //  //printf("Most negative column in row[0] is col %d = %g.\n", pivot_col, lowest);
    //  if (lowest >= 0)
    //  {
    //    return -1; // All positive columns in row[0], this is optimal.
    //  }
    //  return pivot_col;
    //}

    //// Find the pivot_row, with smallest positive ratio = col[0] / col[pivot]
    //static int find_pivot_row(ref float[,] tableau, int pivot_col)
    //{
    //  int i, pivot_row = 0;
    //  float min_ratio = -1;
    //  //printf("Ratios A[row_i,0]/A[row_i,%d] = [", pivot_col);
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    float ratio = tableau[i, 0] / tableau[i, pivot_col];
    //    //printf("%3.2lf, ", ratio);
    //    if ((ratio > 0 && ratio < min_ratio) || min_ratio < 0)
    //    {
    //      min_ratio = ratio;
    //      pivot_row = i;
    //    }
    //  }
    //  //printf("].\n");
    //  if (min_ratio == -1)
    //    return -1; // Unbounded.
    //  //printf("Found pivot A[%d,%d], min positive ratio=%g in row=%d.\n",
    //  //  pivot_row, pivot_col, min_ratio, pivot_row);
    //  return pivot_row;
    //}

    //static void add_slack_variables(ref float[,] tableau)
    //{

    //  float[,] newTableau =
    //    new float[tableau.GetLength(0), tableau.GetLength(1) + tableau.GetLength(0) - 1];

    //  for (int a = 0, a_max = tableau.GetLength(0); a < a_max; a++)
    //    for (int b = 0, b_max = tableau.GetLength(1); b < b_max; b++)
    //      newTableau[a, b] = tableau[a, b];

    //  int i, j;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    for (j = 1; j < tableau.GetLength(0); j++)
    //      newTableau[i, j + tableau.GetLength(1) - 1] = (i == j ? 1d : 0d);
    //  }

    //  tableau = newTableau;
    //}

    //static void check_b_positive(ref float[,] tableau)
    //{
    //  int i;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //    if (!(tableau[i, 0] >= 0))
    //      throw new Error("possible invalid tableau values (IDK)");
    //}

    //// Given a column of identity matrix, find the row containing 1.
    //// return -1, if the column as not from an identity matrix.
    //static int find_basis_variable(ref float[,] tableau, int col)
    //{
    //  int i, xi = -1;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    if (Logic.Equate(tableau[i, col], 1, epsilon))
    //      if (xi == -1)
    //        xi = i;   // found first '1', save this row number.
    //      else
    //        return -1; // found second '1', not an identity matrix.
    //    else if (!Logic.Equate(tableau[i, col], 0, epsilon))
    //      return -1; // not an identity matrix column.
    //  }
    //  return xi;
    //}

    //static float[] print_optimal_vector(ref float[,] tableau)
    //{
    //  float[] vector = new float[tableau.GetLength(1)];
    //  int j, xi;
    //  //printf("%s at ", message);
    //  for (j = 1; j < tableau.GetLength(1); j++)
    //  { // for each column.
    //    xi = find_basis_variable(ref tableau, j);
    //    if (xi != -1)
    //      vector[j] = tableau[xi, 0];
    //    else
    //      vector[j] = j;
    //  }
    //  return vector;
    //}

    //public static float[] Simplex(ref float[,] tableau)
    //{
    //  int loop = 0;
    //  add_slack_variables(ref tableau);
    //  check_b_positive(ref tableau);
    //  while (++loop > 0)
    //  {
    //    int pivot_col, pivot_row;

    //    pivot_col = find_pivot_column(ref tableau);
    //    if (pivot_col < 0)
    //      //printf("Found optimal value=A[0,0]=%3.2lf (no negatives in row 0).\n",
    //      //  tableau->mat[0][0]);
    //      return print_optimal_vector(ref tableau);
    //    //printf("Entering variable x%d to be made basic, so pivot_col=%d.\n",
    //    //  pivot_col, pivot_col);

    //    pivot_row = find_pivot_row(ref tableau, pivot_col);
    //    if (pivot_row < 0)
    //      throw new Error("unbounded (no pivot_row)");
    //    //printf("Leaving variable x%d, so pivot_row=%d\n", pivot_row, pivot_row);

    //    pivot_on(ref tableau, pivot_row, pivot_col);
    //    //print_tableau(tableau, "After pivoting");
    //    //return print_optimal_vector(ref tableau);
    //  }
    //  throw new Error("Simplex has a glitch");
    //}

    #endregion

    #endregion

    #region long

    #region vector

    /// <summary>Adds two vectors together.</summary>
    /// <param name="left">The first vector of the addition.</param>
    /// <param name="right">The second vector of the addiiton.</param>
    /// <returns>The result of the addiion.</returns>
    public static Vector<long> Add(Vector<long> left, Vector<long> right)
    {
      #region pre-optimization

      //Vector<long> result =
      //  new Vector<long>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] + right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector addition.");
#endif

      int length = left.Dimensions;
      Vector<long> result =
        new Vector<long>(left.Dimensions);

#if unsafe_code
      unsafe
      {
        fixed (long*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
      }
#else
      long[] left_flat = left._vector;
      long[] right_flat = right._vector;
      long[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
#endif

      return result;
    }

    /// <summary>Negates all the values in a vector.</summary>
    /// <param name="vector">The vector to have its values negated.</param>
    /// <returns>The result of the negations.</returns>
    public static Vector<long> Negate(Vector<long> vector)
    {
      #region pre-optimization

      //Vector<long> result =
      //  new Vector<long>(vector.Dimensions);
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result[i] = -vector[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Vector<long> result =
        new Vector<long>(length);

#if unsafe_code
      unsafe
      {
        fixed (long*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = -vector_flat[i];
      }
#else
      long[] vector_flat = vector._vector;
      long[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = -vector_flat[i];
#endif

      return result;
    }

    /// <summary>Subtracts two vectors.</summary>
    /// <param name="left">The left vector of the subtraction.</param>
    /// <param name="right">The right vector of the subtraction.</param>
    /// <returns>The result of the vector subtracton.</returns>
    public static Vector<long> Subtract(Vector<long> left, Vector<long> right)
    {
      #region pre-optimization

      //Vector<long> result =
      //  new Vector<long>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] - right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector subtraction.");
#endif

      int length = left.Dimensions;
      Vector<long> result =
        new Vector<long>(length);

#if unsafe_code
      unsafe
      {
        fixed (long*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] - right_flat[i];
      }
#else
      long[] left_flat = left._vector;
      long[] right_flat = right._vector;
      long[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] - right_flat[i];
#endif

      return result;
    }

    /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
    /// <param name="left">The vector to have the components multiplied by.</param>
    /// <param name="right">The scalars to multiply the vector components by.</param>
    /// <returns>The result of the multiplications.</returns>
    public static Vector<long> Multiply(Vector<long> left, long right)
    {
      #region pre-optimization

      //Vector<long> result =
      //  new Vector<long>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] * right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      int length = left.Dimensions;
      Vector<long> result =
        new Vector<long>(length);

#if unsafe_code
      unsafe
      {
        fixed (long*
          left_flat = left._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] * right;
      }
#else
      long[] left_flat = left._vector;
      long[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] * right;
#endif

      return result;
    }

    /// <summary>Divides all the components of a vector by a scalar.</summary>
    /// <param name="vector">The vector to have the components divided by.</param>
    /// <param name="right">The scalar to divide the vector components by.</param>
    /// <returns>The resulting vector after teh divisions.</returns>
    public static Vector<long> Divide(Vector<long> vector, long right)
    {
      #region pre-optimization

      //Vector<long> result =
      //  new Vector<long>(vector.Dimensions);
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result[i] = vector[i] / right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: left");
#endif

      int length = vector.Dimensions;
      Vector<long> result =
        new Vector<long>(length);

#if unsafe_code
      unsafe
      {
        fixed (long*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = vector_flat[i] / right;
      }
#else
      long[] vector_flat = vector._vector;
      long[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = vector_flat[i] / right;
#endif

      return result;
    }

    /// <summary>Computes the dot product between two vectors.</summary>
    /// <param name="left">The first vector of the dot product operation.</param>
    /// <param name="right">The second vector of the dot product operation.</param>
    /// <returns>The result of the dot product operation.</returns>
    public static long DotProduct(Vector<long> left, Vector<long> right)
    {
      #region pre-optimization

      //long result = 0;
      //for (int i = 0; i < left.Dimensions; i++)
      //  result += left[i] * right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector dot product.");
#endif

      int length = left.Dimensions;
      long result = 0;

#if unsafe_code
      unsafe
      {
        fixed (long*
          left_flat = left._vector,
          right_flat = right._vector)
          for (int i = 0; i < length; i++)
            result += left_flat[i] * right_flat[i];
      }
#else
      long[] left_flat = left._vector;
      long[] right_flat = right._vector;
      for (int i = 0; i < length; i++)
        result += left_flat[i] * right_flat[i];
#endif

      return result;
    }

    /// <summary>Computes teh cross product of two vectors.</summary>
    /// <param name="left">The first vector of the cross product operation.</param>
    /// <param name="right">The second vector of the cross product operation.</param>
    /// <returns>The result of the cross product operation.</returns>
    public static Vector<long> CrossProduct(Vector<long> left, Vector<long> right)
    {
      #region pre-optimization

      //Vector<long> result = new Vector<long>(3);
      //result[0] = left[1] * right[2] - left[2] * right[1];
      //result[1] = left[2] * right[0] - left[0] * right[2];
      //result[2] = left[0] * right[1] - left[1] * right[0];

      #endregion

#if no_error_checking

#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid cross product (left.Dimensions != right.Dimensions)");
      if (left.Dimensions != 3)
        throw new Error("my cross product function is only defined for 3-component vectors.");
#endif

      Vector<long> result =
        new Vector<long>(3);

#if unsafe_code
      unsafe
      {
        fixed (long*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
        {
          result_flat[0] = left_flat[1] * right_flat[2] - left_flat[2] * right_flat[1];
          result_flat[1] = left_flat[2] * right_flat[0] - left_flat[0] * right_flat[2];
          result_flat[2] = left_flat[0] * right_flat[1] - left_flat[1] * right_flat[0];
        }
      }
#else
      long[] left_flat = left._vector;
      long[] right_flat = right._vector;
      long[] result_flat = result._vector;
      result_flat[0] = left_flat[1] * right_flat[2] - left_flat[2] * right_flat[1];
      result_flat[1] = left_flat[2] * right_flat[0] - left_flat[0] * right_flat[2];
      result_flat[2] = left_flat[0] * right_flat[1] - left_flat[1] * right_flat[0];
#endif

      return result;
    }

    /// <summary>Normalizes a vector.</summary>
    /// <param name="vector">The vector to normalize.</param>
    /// <returns>The result of the normalization.</returns>
    public static Vector<long> Normalize(Vector<long> vector)
    {
      #region pre-optimization

      //long magnitude = LinearAlgebra.Magnitude(vector);
      //if (magnitude != 0)
      //{
      //  Vector<long> result = 
      //    new Vector<long>(vector.Dimensions);
      //  for (int i = 0; i < vector.Dimensions; i++)
      //    result[i] = vector[i] / magnitude;
      //  return result;
      //}
      //else
      //  return new long[vector.Dimensions];

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Vector<long> result =
        new Vector<long>(vector.Dimensions);
      long magnitude = LinearAlgebra.Magnitude(vector);
      if (magnitude != 0)
        return result;

#if unsafe_code
      unsafe
      {
        fixed (long*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = vector_flat[i] / magnitude;
      }
#else
      long[] vector_flat = vector._vector;
      long[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = vector_flat[i] / magnitude;
#endif

      return result;

    }

    /// <summary>Computes the length of a vector.</summary>
    /// <param name="vector">The vector to calculate the length of.</param>
    /// <returns>The computed length of the vector.</returns>
    public static long Magnitude(Vector<long> vector)
    {
      #region pre-optimization

      //long result = 0;
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result += vector[i] * vector[i];
      //return Algebra.sqrt(result);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      long result = 0;

#if unsafe_code
      unsafe
      {
        fixed (long*
          vector_flat = vector._vector)
          for (int i = 0; i < length; i++)
            result += vector_flat[i] * vector_flat[i];
      }
#else
      long[] vector_flat = vector._vector;
      for (int i = 0; i < length; i++)
        result += vector_flat[i] * vector_flat[i];
#endif

      return Algebra.sqrt(result);
    }

    /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
    /// <param name="vector">The vector to compute the length squared of.</param>
    /// <returns>The computed length squared of the vector.</returns>
    public static long MagnitudeSquared(Vector<long> vector)
    {
      #region pre-optimization

      //long result = 0;
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result += vector[i] * vector[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      long result = 0;

#if unsafe_code
      unsafe
      {
        fixed (long*
          vector_flat = vector._vector)
          for (int i = 0; i < length; i++)
            result += vector_flat[i] * vector_flat[i];
      }
#else
      long[] vector_flat = vector._vector;
      for (int i = 0; i < length; i++)
        result += vector_flat[i] * vector_flat[i];
#endif

      return result;
    }

    /// <summary>Computes the angle between two vectors.</summary>
    /// <param name="first">The first vector to determine the angle between.</param>
    /// <param name="second">The second vector to determine the angle between.</param>
    /// <returns>The angle between the two vectors in radians.</returns>
    public static long Angle(Vector<long> first, Vector<long> second)
    {
      throw new Error("requiers rational numeric types");

//      #region pre-optimization

//      //return Trigonometry.arccos(
//      //  LinearAlgebra.DotProduct(first, second) / 
//      //  (LinearAlgebra.Magnitude(first) * 
//      //  LinearAlgebra.Magnitude(second)));

//      #endregion

//#if no_error_checking
//      // nothing
//#else
//      if (object.ReferenceEquals(first, null))
//        throw new Error("null reference: first");
//      if (object.ReferenceEquals(second, null))
//        throw new Error("null reference: second");
//#endif

//      return Trigonometry.arccos(
//        LinearAlgebra.DotProduct(first, second) /
//        (LinearAlgebra.Magnitude(first) *
//        LinearAlgebra.Magnitude(second)));
    }

    /// <summary>Rotates a 3-component vector by the specified axis and rotation values.</summary>
    /// <param name="vector">The vector to rotate.</param>
    /// <param name="angle">The angle of the rotation in radians.</param>
    /// <param name="x">The x component of the axis vector to rotate about.</param>
    /// <param name="y">The y component of the axis vector to rotate about.</param>
    /// <param name="z">The z component of the axis vector to rotate about.</param>
    /// <returns>The result of the rotation.</returns>
    public static Vector<long> RotateBy(Vector<long> vector, long angle, long x, long y, long z)
    {
      throw new Error("requiers rational numeric types");

//      #region pre-optimization

//      //long sinHalfAngle = Trigonometry.sin(angle / 2);
//      //long cosHalfAngle = Trigonometry.cos(angle / 2);
//      //x *= sinHalfAngle;
//      //y *= sinHalfAngle;
//      //z *= sinHalfAngle;
//      //long x2 = cosHalfAngle * vector[0] + y * vector[2] - z * vector[1];
//      //long y2 = cosHalfAngle * vector[1] + z * vector[0] - x * vector[2];
//      //long z2 = cosHalfAngle * vector[2] + x * vector[1] - y * vector[0];
//      //long w2 = -x * vector[0] - y * vector[1] - z * vector[2];
//      //Vector<long> result = new Vector<long>();
//      //result[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
//      //result[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
//      //result[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;

//      #endregion

//#if no_error_checking
//      // nothing
//#else
//      if (object.ReferenceEquals(vector, null))
//        throw new Error("null reference: vector");
//      if (vector.Dimensions == 3)
//        throw new Error("my RotateBy() function is only defined for 3-component vectors.");
//#endif

//      Vector<long> result = new Vector<long>(3);
//      long sinHalfAngle = Trigonometry.sin(angle / 2);
//      long cosHalfAngle = Trigonometry.cos(angle / 2);
//      x *= sinHalfAngle;
//      y *= sinHalfAngle;
//      z *= sinHalfAngle;

//#if unsafe_code
//      unsafe
//      {
//        fixed (long*
//          vector_flat = vector._vector,
//          result_flat = result._vector)
//        {
//          long x2 = cosHalfAngle * vector_flat[0] + y * vector_flat[2] - z * vector_flat[1];
//          long y2 = cosHalfAngle * vector_flat[1] + z * vector_flat[0] - x * vector_flat[2];
//          long z2 = cosHalfAngle * vector_flat[2] + x * vector_flat[1] - y * vector_flat[0];
//          long w2 = -x * vector_flat[0] - y * vector_flat[1] - z * vector_flat[2];
//          result_flat[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
//          result_flat[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
//          result_flat[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;
//        }
//      }
//#else
//      long[] vector_flat = vector._vector;
//      long[] result_flat = result._vector;
//      long x2 = cosHalfAngle * vector_flat[0] + y * vector_flat[2] - z * vector_flat[1];
//      long y2 = cosHalfAngle * vector_flat[1] + z * vector_flat[0] - x * vector_flat[2];
//      long z2 = cosHalfAngle * vector_flat[2] + x * vector_flat[1] - y * vector_flat[0];
//      long w2 = -x * vector_flat[0] - y * vector_flat[1] - z * vector_flat[2];
//      result_flat[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
//      result_flat[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
//      result_flat[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;
//#endif

//      return result;
    }

    /// <summary>Rotates a vector by a quaternion rotation.</summary>
    /// <param name="vector">The vector to be rotated.</param>
    /// <param name="quaternion">The rotation to be applied.</param>
    /// <returns>The vector after the rotation.</returns>
    public static Vector<long> RotateBy(Vector<long> vector, Quaternion<long> quaternion)
    {
      return Rotate(quaternion, vector);
    }

    /// <summary>Computes the linear interpolation between two vectors.</summary>
    /// <param name="left">The starting vector of the interpolation.</param>
    /// <param name="right">The ending vector of the interpolation.</param>
    /// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Vector<long> Lerp(Vector<long> left, Vector<long> right, long blend)
    {
      #region pre-optimization

      //Vector<long> result = new Vector<long>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] + blend * (right[i] - left[i]);
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (blend < 0 || blend > 1)
        throw new Error("invalid vector lerp blend value: (blend < 0.0f || blend > 1.0f).");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid vector lerp length: (left.Dimensions != right.Dimensions)");
#endif

      int length = left.Dimensions;
      Vector<long> result =
        new Vector<long>(length);

#if unsafe_code
      unsafe
      {
        fixed (long*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + blend * (right_flat[i] - left_flat[i]);
      }
#else
      long[] left_flat = left._vector;
      long[] right_flat = right._vector;
      long[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] + blend * (right_flat[i] - left_flat[i]);
#endif

      return result;
    }

    /// <summary>Sphereically interpolates between two vectors.</summary>
    /// <param name="left">The starting vector of the interpolation.</param>
    /// <param name="right">The ending vector of the interpolation.</param>
    /// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
    /// <returns>The result of the slerp operation.</returns>
    public static Vector<long> Slerp(Vector<long> left, Vector<long> right, long blend)
    {
      throw new Error("requiers rational numeric types");

//      #region pre-optimization

//      //long dot = LinearAlgebra.DotProduct(left, right);
//      //dot = dot < -1 ? -1 : dot;
//      //dot = dot > 1 ? 1 : dot;
//      //long theta = Trigonometry.arccos(dot) * blend;
//      //return LinearAlgebra.Multiply(LinearAlgebra.Add(LinearAlgebra.Multiply(left, Trigonometry.cos(theta)),
//      //  LinearAlgebra.Normalize(LinearAlgebra.Subtract(right, LinearAlgebra.Multiply(left, dot)))), Trigonometry.sin(theta));

//      #endregion

//#if no_error_checking
//      // nothing
//#else
//      if (object.ReferenceEquals(left, null))
//        throw new Error("null reference: left");
//      if (object.ReferenceEquals(right, null))
//        throw new Error("null reference: right");
//      if (blend < 0 || blend > 1)
//        throw new Error("invalid slerp blend value: (blend < 0.0f || blend > 1.0f).");
//#endif

//      long dot = LinearAlgebra.DotProduct(left, right);
//      dot = dot < -1 ? -1 : dot;
//      dot = dot > 1 ? 1 : dot;
//      long theta = Trigonometry.arccos(dot) * blend;
//      return LinearAlgebra.Multiply(LinearAlgebra.Add(LinearAlgebra.Multiply(left, Trigonometry.cos(theta)),
//        LinearAlgebra.Normalize(LinearAlgebra.Subtract(right, LinearAlgebra.Multiply(left, dot)))), Trigonometry.sin(theta));
    }

    /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
    /// <param name="a">The first vector of the interpolation.</param>
    /// <param name="b">The second vector of the interpolation.</param>
    /// <param name="c">The thrid vector of the interpolation.</param>
    /// <param name="u">The "U" value of the barycentric interpolation equation.</param>
    /// <param name="v">The "V" value of the barycentric interpolation equation.</param>
    /// <returns>The resulting vector of the barycentric interpolation.</returns>
    public static Vector<long> Blerp(Vector<long> a, Vector<long> b, Vector<long> c, long u, long v)
    {
      #region pre-optimization

      //return 
      //  LinearAlgebra.Add(
      //    LinearAlgebra.Add(
      //      LinearAlgebra.Multiply(
      //        LinearAlgebra.Subtract(b, a), u),
      //          LinearAlgebra.Multiply(
      //            LinearAlgebra.Subtract(c, a), v)), a);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(a, null))
        throw new Error("null reference: a");
      if (object.ReferenceEquals(b, null))
        throw new Error("null reference: b");
      if (object.ReferenceEquals(c, null))
        throw new Error("null reference: c");
#endif

      return
        LinearAlgebra.Add(
          LinearAlgebra.Add(
            LinearAlgebra.Multiply(
              LinearAlgebra.Subtract(b, a), u),
                LinearAlgebra.Multiply(
                  LinearAlgebra.Subtract(c, a), v)), a);
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Vector<long> left, Vector<long> right)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;

      //if (left.Dimensions != right.Dimensions)
      //  return false;
      //for (int i = 0; i < left.Dimensions; i++)
      //  if (left[i] != right[i])
      //    return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Dimensions != right.Dimensions)
        return false;
      for (int i = 0; i < left.Dimensions; i++)
        if (left[i] != right[i])
          return false;
      return true;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Vector<long> left, Vector<long> right, long leniency)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;

      //if (left.Dimensions != right.Dimensions)
      //  return false;
      //for (int i = 0; i < left.Dimensions; i++)
      //  if (Logic.Abs(left[i] - right[i]) > leniency)
      //    return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Dimensions != right.Dimensions)
        return false;
      for (int i = 0; i < left.Dimensions; i++)
        if (Logic.Abs(left[i] - right[i]) > leniency)
          return false;
      return true;
    }

    #endregion

    #region matrix

    /// <summary>Determines if a matrix is symetric or not.</summary>
    /// <param name="matrix">The matrix to determine symetry of.</param>
    /// <returns>True if symetric; false if not.</returns>
    public static bool IsSymmetric(Matrix<long> matrix)
    {
      #region pre-optimization

      //if (matrix.Rows != matrix.Columns)
      //  return false;
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    if (matrix[i, j] != matrix[j, i])
      //      return false;
      //return true;

      #endregion

#if no_errorchecking
      //nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        return false;
#endif
      int size = matrix.Columns;
#if unsafe_code
      unsafe
      {
        fixed (long* matrix_flat = matrix._matrix)
          for (var row = 0; row < size; row++)
            for (var column = row + 1; column < size; column++)
              if (matrix_flat[row * size + column] != matrix_flat[column * size + row])
                return false;
      }
#else
      long[] matrix_flat = matrix._matrix;
      for (var row = 0; row < size; row++)
        for (var column = row + 1; column < size; column++)
          if (matrix_flat[row * size + column] != matrix_flat[column * size + row])
            return false;
#endif
      return true;
    }

    /// <summary>Constructs a new identity-matrix of the given dimensions.</summary>
    /// <param name="rows">The number of rows of the matrix.</param>
    /// <param name="columns">The number of columns of the matrix.</param>
    /// <returns>The newly constructed identity-matrix.</returns>
    public static Matrix<long> MatrixFactoryIdentity_long(int rows, int columns)
    {
      #region pre-optimization

      //Matrix<long> matrix = 
      //  new Matrix<long>(rows, columns);
      //for (int i = 0; i < Logic.Min(rows, columns); i++)
      //  matrix[i, i] = 1;
      //return matrix;

      #endregion

#if no_error_checking
      //nothing
#else
      if (rows < 1)
        throw new Error("invalid row count on matrix creation");
      if (columns < 1)
        throw new Error("invalid column count on matrix creation");
#endif

      Matrix<long> matrix = new Matrix<long>(rows, columns);
      if (rows <= columns)
        for (int i = 0; i < rows; i++)
          matrix[i, i] = 1;
      else
        for (int i = 0; i < columns; i++)
          matrix[i, i] = 1;
      return matrix;
    }

    /// <summary>Negates all the values in a matrix.</summary>
    /// <param name="matrix">The matrix to have its values negated.</param>
    /// <returns>The resulting matrix after the negations.</returns>
    public static Matrix<long> Negate(Matrix<long> matrix)
    {
      #region pre-optimization

      //Matrix<long> result =
      //  new Matrix<long>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Rows; j++)
      //    result[i, j] = -matrix[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
        if (object.ReferenceEquals(matrix, null))
          throw new Error("null reference: matirx");
#endif

      Matrix<long> result =
        new Matrix<long>(matrix.Rows, matrix.Columns);
      int size = matrix.Rows * matrix.Columns;

#if unsafe_code
      unsafe
      {
        fixed (long*
          result_flat = result._matrix,
          matrix_flat = matrix._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = -matrix_flat[i];
        return result;
      }
#else
      long[] result_flat = result._matrix;
      long[] matrix_flat = matrix._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = -matrix_flat[i];
      return result;
#endif
    }

    /// <summary>Negates all the values in a matrix.</summary>
    /// <param name="matrix">The matrix to have its values negated.</param>
    /// <returns>The resulting matrix after the negations.</returns>
    public static Matrix<long> Negate_parallel(Matrix<long> matrix)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matirx");
#endif

      if (matrix.Rows * matrix.Columns > _parallelMinimum)
      {
        Matrix<long> result =
        new Matrix<long>(matrix.Rows, matrix.Columns);
        int size = matrix.Rows * matrix.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (long*
                  result_flat = result._matrix,
                  matrix_flat = matrix._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = -matrix_flat[i];
              };
            }, Logic.Max(matrix.Rows, matrix.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                long[] matrix_flat = matrix._matrix;
                long[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = -matrix_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Negate(matrix);
    }

    /// <summary>Does standard addition of two matrices.</summary>
    /// <param name="left">The left matrix of the addition.</param>
    /// <param name="right">The right matrix of the addition.</param>
    /// <returns>The resulting matrix after the addition.</returns>
    public static Matrix<long> Add(Matrix<long> left, Matrix<long> right)
    {
      #region pre-optimization

      //Matrix<long> result =
      //  new Matrix<long>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] + right[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
          throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix addition (dimension miss-match).");
#endif

      Matrix<long> result =
        new Matrix<long>(left.Rows, left.Columns);
      int size = left.Rows * left.Columns;

#if unsafe_code
      unsafe
      {
        fixed (long*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
      }
#else
      long[] left_flat = left._matrix;
      long[] right_flat = right._matrix;
      long[] result_flat = result._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = left_flat[i] + right_flat[i];
#endif

      return result;
    }

    /// <summary>Does standard addition of two matrices.</summary>
    /// <param name="left">The left matrix of the addition.</param>
    /// <param name="right">The right matrix of the addition.</param>
    /// <returns>The resulting matrix after the addition.</returns>
    public static Matrix<long> Add_parallel(Matrix<long> left, Matrix<long> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix addition (dimension miss-match).");
#endif

      if (left.Rows * left.Columns > _parallelMinimum)
      {
        Matrix<long> result =
        new Matrix<long>(left.Rows, left.Columns);
        int size = left.Rows * left.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (long*
                  left_flat = left._matrix,
                  right_flat = right._matrix,
                  result_flat = result._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = left_flat[i] + right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                long[] left_flat = left._matrix;
                long[] right_flat = right._matrix;
                long[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = left_flat[i] + right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Add(left, right);
    }

    /// <summary>Subtracts a scalar from all the values in a matrix.</summary>
    /// <param name="left">The matrix to have the values subtracted from.</param>
    /// <param name="right">The scalar to subtract from all the matrix values.</param>
    /// <returns>The resulting matrix after the subtractions.</returns>
    public static Matrix<long> Subtract(Matrix<long> left, Matrix<long> right)
    {
      #region pre-optimization

      //Matrix<long> result =
      //  new Matrix<long>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] - right[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix subtraction (dimension miss-match).");
#endif

      Matrix<long> result =
        new Matrix<long>(left.Rows, left.Columns);
      int size = left.Rows * left.Columns;

#if unsafe_code
      unsafe
      {
        fixed (long*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = left_flat[i] - right_flat[i];
      }
#else
      long[] left_flat = left._matrix;
      long[] right_flat = right._matrix;
      long[] result_flat = result._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = left_flat[i] - right_flat[i];
#endif

      return result;
    }

    /// <summary>Subtracts a scalar from all the values in a matrix.</summary>
    /// <param name="left">The matrix to have the values subtracted from.</param>
    /// <param name="right">The scalar to subtract from all the matrix values.</param>
    /// <returns>The resulting matrix after the subtractions.</returns>
    public static Matrix<long> Subtract_parallel(Matrix<long> left, Matrix<long> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix subtraction (dimension miss-match).");
#endif

      if (left.Rows * left.Columns > _parallelMinimum)
      {
        Matrix<long> result =
        new Matrix<long>(left.Rows, left.Columns);
        int size = left.Rows * left.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (long*
                  left_flat = left._matrix,
                  right_flat = right._matrix,
                  result_flat = result._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = left_flat[i] - right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
          (int current, int max) =>
          {
            return () =>
            {
              long[] left_flat = left._matrix;
              long[] right_flat = right._matrix;
              long[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = left_flat[i] - right_flat[i];
            };
          }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Subtract(left, right);
    }

    /// <summary>Performs multiplication on two matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Matrix<long> Multiply(Matrix<long> left, Matrix<long> right)
    {
      #region pre-optimization

      //Matrix<long> result = 
      //  new Matrix<long>(left.Rows, right.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < right.Columns; j++)
      //    for (int k = 0; k < left.Columns; k++)
      //      result[i, j] += left[i, k] * right[k, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (left == null)
        throw new Error("null reference: left");
      if (right == null)
        throw new Error("null reference: right");
      if (left.Columns != right.Rows)
        throw new LinearAlgebra.Error("invalid multiplication (size miss-match).");
#endif

      long sum;
      int result_rows = left.Rows;
      int left_cols = left.Columns;
      int result_cols = right.Columns;
      Matrix<long> result =
        new Matrix<long>(result_rows, result_cols);

#if unsafe_code
      unsafe
      {
        fixed (long*
          result_flat = result._matrix,
          left_flat = left._matrix,
          right_flat = right._matrix)
          for (int i = 0; i < result_rows; i++)
            for (int j = 0; j < result_cols; j++)
            {
              sum = 0;
              for (int k = 0; k < left_cols; k++)
                sum += left_flat[i * left_cols + k] * right_flat[k * result_cols + j];
              result_flat[i * result_cols + j] = sum;
            }
      }
#else
      long[] result_flat = result._matrix;
      long[] left_flat = left._matrix;
      long[] right_flat = right._matrix;

      for (int i = 0; i < result_rows; i++)
        for (int j = 0; j < result_cols; j++)
        {
          sum = 0;
          for (int k = 0; k < left_cols; k++)
            sum += left_flat[i * left_cols + k] * right_flat[k * result_cols + j];
          result_flat[i * result_cols + j] = sum;
        }
#endif

      return result;
    }

    /// <summary>Performs multiplication on two matrices using multi-threading.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Matrix<long> Multiply_parrallel(Matrix<long> left, Matrix<long> right)
    {
#if no_error_checking
      // nothing
#else
      if (left == null)
        throw new Error("null reference: left");
      if (right == null)
        throw new Error("null reference: right");
      if (left.Columns != right.Rows)
        throw new LinearAlgebra.Error("invalid multiplication (dimension miss-match).");
#endif

      int result_rows = left.Rows;
      int left_cols = left.Columns;
      int result_cols = right.Columns;

      // If there are enough rows to warrant multi-threading,
      // then multithread the row for-loop.
      if (result_rows * result_cols > _parallelMinimum &&
        result_rows >= result_cols)
      {
        Matrix<long> result =
          new Matrix<long>(result_rows, result_cols);
#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                long sum;
                int left_i_offest;
                int result_i_offset;

                fixed (long*
                  result_flat = result._matrix,
                  left_flat = left._matrix,
                  right_flat = right._matrix)
                  for (int i = current; i < result_rows; i += max)
                  {
                    left_i_offest = i * left_cols;
                    result_i_offset = i * result_cols;
                    for (int j = 0; j < result_cols; j++)
                    {
                      sum = 0;
                      for (int k = 0; k < left_cols; k++)
                        sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                      result_flat[result_i_offset + j] = sum;
                    }
                  }
              };
            }, result_rows);
        }
#else
              long[] result_flat = result._matrix;
              long[] left_flat = left._matrix;
              long[] right_flat = right._matrix;

              Seven.Parallels.AutoParallel.Divide(
                  (int current, int max) =>
                  {
                    return () =>
                    {
                      long sum;
                      int left_i_offest;
                      int result_i_offset;

                      for (int i = current; i < result_rows; i += max)
                      {
                        left_i_offest = i * left_cols;
                        result_i_offset = i * result_cols;
                        for (int j = 0; j < result_cols; j++)
                        {
                          sum = 0;
                          for (int k = 0; k < left_cols; k++)
                            sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                          result_flat[result_i_offset + j] = sum;
                        }
                      }
                    };
                  }, result_rows);

#endif
        return result;
      }
      // If there are enough columns to warrant multi-threading,
      // then multithread the column for-loop.
      else if (result_rows * result_cols > _parallelMinimum &&
        result_rows < result_cols)
      {
        Matrix<long> result =
          new Matrix<long>(result_rows, result_cols);
#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                long sum;
                int left_i_offest;
                int result_i_offset;

                fixed (long*
                  result_flat = result._matrix,
                  left_flat = left._matrix,
                  right_flat = right._matrix)
                  for (int i = 0; i < result_rows; i++)
                  {
                    left_i_offest = i * left_cols;
                    result_i_offset = i * result_cols;
                    for (int j = current; j < result_cols; j += max)
                    {
                      sum = 0;
                      for (int k = 0; k < left_cols; k++)
                        sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                      result_flat[result_i_offset + j] = sum;
                    }
                  }
              };
            }, result_cols);
        }
#else
              long[] result_flat = result._matrix;
              long[] left_flat = left._matrix;
              long[] right_flat = right._matrix;

              Seven.Parallels.AutoParallel.Divide(
                  (int current, int max) =>
                  {
                    return () =>
                    {
                      long sum;
                      int left_i_offest;
                      int result_i_offset;

                      for (int i = 0; i < result_rows; i++)
                      {
                        left_i_offest = i * left_cols;
                        result_i_offset = i * result_cols;
                        for (int j = current; j < result_cols; j += max)
                        {
                          sum = 0;
                          for (int k = 0; k < left_cols; k++)
                            sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                          result_flat[result_i_offset + j] = sum;
                        }
                      }
                    };
                  }, result_cols);
#endif
        return result;
      }
      // Multi-threading is not necessary.
      else
        return LinearAlgebra.Multiply(left, right);
    }

    /// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Vector<long> Multiply(Matrix<long> left, Vector<long> right)
    {
      #region pre-optimization

      //Vector<long> result = 
      //  new Vector<long>(right.Dimensions);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i] += left[i, j] * right[j];
      //return result;

      #endregion

#if no_error_checking
      int left_row = left.Rows;
      int left_col = left.Columns;
#else
      int left_row = left.Rows;
      int left_col = left.Columns;
      if (left.Columns != right.Dimensions)
        throw new Error("invalid multiplication (size miss-match).");
#endif

      Vector<long> result = new Vector<long>(right.Dimensions);

#if unsafe_code
      unsafe
      {
        fixed (long*
          left_flat = left._matrix,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < left_row; i++)
            for (int j = 0; j < left_col; j++)
              result_flat[i] += left_flat[i * left_col + j] * right_flat[j];
        return result;
      }
#else
      long[] left_flat = left._matrix;
      long[] right_flat = right._vector;
      long[] result_flat = result._vector;
      for (int i = 0; i < left_row; i++)
        for (int j = 0; j < left_col; j++)
          result_flat[i] += left_flat[i * left_col + j] * right_flat[j];
      return result;
#endif
      return result;
    }

    /// <summary>Multiplies all the values in a matrix by a scalar.</summary>
    /// <param name="left">The matrix to have the values multiplied.</param>
    /// <param name="right">The scalar to multiply the values by.</param>
    /// <returns>The resulting matrix after the multiplications.</returns>
    public static Matrix<long> Multiply(Matrix<long> left, long right)
    {
      #region pre-optimization

      //Matrix<long> result = 
      //  new Matrix<long>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] * right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      int rows = left.Rows;
      int columns = left.Columns;
      Matrix<long> result = new Matrix<long>(rows, columns);

#if unsafe_code
      unsafe
      {
        fixed (long*
          left_flat = left._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
              result_flat[i * columns + j] = left_flat[i * columns + j] * right;
      }
#else
      for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
          result[i, j] = left[i, j] * right;
#endif

      return result;
    }

    /// <summary>Applies a power to a square matrix.</summary>
    /// <param name="matrix">The matrix to be powered by.</param>
    /// <param name="power">The power to apply to the matrix.</param>
    /// <returns>The resulting matrix of the power operation.</returns>
    public static Matrix<long> Power(Matrix<long> matrix, int power)
    {
      #region pre-optimization

      //Matrix<long> result = matrix.Clone();
      //for (int i = 0; i < power; i++)
      //  result = LinearAlgebra.Multiply(result, result);
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (!(matrix.Rows == matrix.Columns))
        throw new Error("invalid power (!matrix.IsSquare).");
      if (!(power >= 0))
        throw new Error("invalid power !(power > -1)");
#endif
      // this is not optimized...
      if (power == 0)
        return LinearAlgebra.MatrixFactoryIdentity_long(matrix.Rows, matrix.Columns);
      Matrix<long> result = matrix.Clone();
      for (int i = 0; i < power; i++)
        result = LinearAlgebra.Multiply(result, matrix);
      return result;
    }

    /// <summary>Divides all the values in the matrix by a scalar.</summary>
    /// <param name="matrix">The matrix to divide the values of.</param>
    /// <param name="right">The scalar to divide all the matrix values by.</param>
    /// <returns>The resulting matrix with the divided values.</returns>
    public static Matrix<long> Divide(Matrix<long> matrix, long right)
    {
      #region pre-optimization

      //Matrix<long> result = 
      //  new Matrix<long>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    result[i, j] = matrix[i, j] / right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      int matrix_row = matrix.Rows;
      int matrix_col = matrix.Columns;
      Matrix<long> result =
        new Matrix<long>(matrix_row, matrix_col);

#if unsafe_code
      unsafe
      {
        fixed (long*
          matrix_flat = matrix._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < matrix_row; i++)
            for (int j = 0; j < matrix_col; j++)
              result_flat[i * matrix_col + j] =
                matrix_flat[i * matrix_col + j] / right;
      }
#else
      long[] matrix_flat = matrix._matrix;
      long[] result_flat = result._matrix;
      for (int i = 0; i < matrix_row; i++)
        for (int j = 0; j < matrix_col; j++)
          result_flat[i * matrix_col + j] = 
            matrix_flat[i * matrix_col + j] / right;

#endif
      return result;
    }

    /// <summary>Gets the minor of a matrix.</summary>
    /// <param name="matrix">The matrix to get the minor of.</param>
    /// <param name="row">The restricted row to form the minor.</param>
    /// <param name="column">The restricted column to form the minor.</param>
    /// <returns>The minor of the matrix.</returns>
    public static Matrix<long> Minor(Matrix<long> matrix, int row, int column)
    {
      #region pre-optimization

      //Matrix<long> minor = 
      //  new Matrix<long>(matrix.Rows - 1, matrix.Columns - 1);
      //int m = 0, n = 0;
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (i == row) continue;
      //  n = 0;
      //  for (int j = 0; j < matrix.Columns; j++)
      //  {
      //    if (j == column) continue;
      //    minor[m, n] = matrix[i, j];
      //    n++;
      //  }
      //  m++;
      //}
      //return minor;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows < 2 || matrix.Columns < 2)
        throw new Error("invalid matrix minor: (matrix.Rows < 2 || matrix.Columns < 2)");
      if (row < 0 || row >= matrix.Rows)
        throw new Error("invalid row on matrix minor: !(0 <= row < matrix.Rows)");
      if (column < 0 || row >= matrix.Columns)
        throw new Error("invalid column on matrix minor: !(0 <= column < matrix.Columns)");
#endif

      Matrix<long> minor =
        new Matrix<long>(matrix.Rows - 1, matrix.Columns - 1);
      int matrix_rows = matrix.Rows;
      int matrix_cols = matrix.Columns;

#if unsafe_code
      unsafe
      {
        fixed (long*
          matrix_flat = matrix._matrix,
          minor_flat = minor._matrix)
        {
          int m = 0, n = 0;
          for (int i = 0; i < matrix_rows; i++)
          {
            if (i == row) continue;
            n = 0;
            for (int j = 0; j < matrix_cols; j++)
            {
              if (j == column) continue;
              minor_flat[m * matrix_cols + n] =
                matrix_flat[i * matrix_cols + j];
              n++;
            }
            m++;
          }
        }
      }
#else
      int m = 0, n = 0;
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (i == row) continue;
        n = 0;
        for (int j = 0; j < matrix.Columns; j++)
        {
          if (j == column) continue;
          minor[m, n] = matrix[i, j];
          n++;
        }
        m++;
      }
#endif
      return minor;
    }

    /// <summary>Combines two matrices from left to right 
    /// (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
    /// <param name="left">The left matrix of the concatenation.</param>
    /// <param name="right">The right matrix of the concatenation.</param>
    /// <returns>The resulting matrix of the concatenation.</returns>
    public static Matrix<long> ConcatenateRowWise(Matrix<long> left, Matrix<long> right)
    {
      #region pre-optimization

      //Matrix<long> result =
      //  new Matrix<long>(left.Rows, left.Columns + right.Columns);
      //for (int i = 0; i < result.Rows; i++)
      //  for (int j = 0; j < result.Columns; j++)
      //    if (j < left.Columns)
      //      result[i, j] = left[i, j];
      //    else
      //      result[i, j] = right[i, j - left.Columns];
      //return result;

      #endregion

#if no_errorChecking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows)
        throw new Error("invalid row-wise concatenation !(left.Rows == right.Rows).");
#endif

      Matrix<long> result =
        new Matrix<long>(left.Rows, left.Columns + right.Columns);
      int result_rows = result.Rows;
      int result_cols = result.Columns;

      int left_cols = left.Columns;
      int right_cols = right.Columns;

#if unsafe_code
      unsafe
      {
        // OptimizeMe (jump statement)
        fixed (long*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < result_rows; i++)
            for (int j = 0; j < result_cols; j++)
              if (j < left_cols)
                result_flat[i * result_cols + j] =
                  left_flat[i * left_cols + j];
              else
                result_flat[i * result_cols + j] =
                  right_flat[i * right_cols + j - left_cols];
      }
#else
      for (int i = 0; i < result_rows; i++)
        for (int j = 0; j < result_cols; j++)
        {
          if (j < left.Columns)
            result[i, j] = left[i, j];
          else
            result[i, j] = right[i, j - left.Columns];
        }
#endif

      return result;
    }

    /// <summary>Calculates the echelon of a matrix (aka REF).</summary>
    /// <param name="matrix">The matrix to calculate the echelon of (aka REF).</param>
    /// <returns>The echelon of the matrix (aka REF).</returns>
    public static Matrix<long> Echelon(Matrix<long> matrix)
    {
      #region pre-optimization

      //Matrix<long> result = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (result[i, i] == 0)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] != 0)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  if (result[i, i] == 0)
      //    continue;
      //  if (result[i, i] != 1)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] == 1)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
      //  for (int j = i + 1; j < result.Rows; j++)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<long> result = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (result[i, i] == 0)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] != 0)
              LinearAlgebra.SwapRows(result, i, j);
        if (result[i, i] == 0)
          continue;
        if (result[i, i] != 1)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] == 1)
              LinearAlgebra.SwapRows(result, i, j);
        LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
        for (int j = i + 1; j < result.Rows; j++)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      }
      return result;
    }

    /// <summary>Calculates the echelon of a matrix and reduces it (aka RREF).</summary>
    /// <param name="matrix">The matrix matrix to calculate the reduced echelon of (aka RREF).</param>
    /// <returns>The reduced echelon of the matrix (aka RREF).</returns>
    public static Matrix<long> ReducedEchelon(Matrix<long> matrix)
    {
      #region pre-optimization

      //Matrix<long> result = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (result[i, i] == 0)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] != 0)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  if (result[i, i] == 0) continue;
      //  if (result[i, i] != 1)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] == 1)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
      //  for (int j = i + 1; j < result.Rows; j++)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      //  for (int j = i - 1; j >= 0; j--)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<long> result = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (result[i, i] == 0)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] != 0)
              LinearAlgebra.SwapRows(result, i, j);
        if (result[i, i] == 0) continue;
        if (result[i, i] != 1)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] == 1)
              LinearAlgebra.SwapRows(result, i, j);
        LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
        for (int j = i + 1; j < result.Rows; j++)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
        for (int j = i - 1; j >= 0; j--)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      }
      return result;
    }

    /// <summary>Calculates the determinent of a square matrix.</summary>
    /// <param name="matrix">The matrix to calculate the determinent of.</param>
    /// <returns>The determinent of the matrix.</returns>
    public static long Determinent(Matrix<long> matrix)
    {
      #region pre-optimization

      //long det = 1;
      //Matrix<long> rref = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (rref[i, i] == 0)
      //    for (int j = i + 1; j < rref.Rows; j++)
      //      if (rref[j, i] != 0)
      //      {
      //        LinearAlgebra.SwapRows(rref, i, j);
      //        det *= -1;
      //      }
      //  det *= rref[i, i];
      //  LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
      //  for (int j = i + 1; j < rref.Rows; j++)
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  for (int j = i - 1; j >= 0; j--)
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //}
      //return det;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        throw new Error("invalid matrix determinent: !(matrix.IsSquare)");
#endif

      long det = 1;
      Matrix<long> rref = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (rref[i, i] == 0)
          for (int j = i + 1; j < rref.Rows; j++)
            if (rref[j, i] != 0)
            {
              LinearAlgebra.SwapRows(rref, i, j);
              det *= -1;
            }
        det *= rref[i, i];
        LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
        for (int j = i + 1; j < rref.Rows; j++)
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        for (int j = i - 1; j >= 0; j--)
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      }
      return det;
    }

    /// <summary>Calculates the inverse of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the inverse of.</param>
    /// <returns>The inverse of the matrix.</returns>
    public static Matrix<long> Inverse(Matrix<long> matrix)
    {
      #region pre-optimization

      //Matrix<long> identity = 
      //  LinearAlgebra.MatrixFactoryIdentity_long(matrix.Rows, matrix.Columns);
      //Matrix<long> rref = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (rref[i, i] == 0)
      //    for (int j = i + 1; j < rref.Rows; j++)
      //      if (rref[j, i] != 0)
      //      {
      //        LinearAlgebra.SwapRows(rref, i, j);
      //        LinearAlgebra.SwapRows(identity, i, j);
      //      }
      //  LinearAlgebra.RowMultiplication(identity, i, 1 / rref[i, i]);
      //  LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
      //  for (int j = i + 1; j < rref.Rows; j++)
      //  {
      //    LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  }
      //  for (int j = i - 1; j >= 0; j--)
      //  {
      //    LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  }
      //}
      //return identity;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (LinearAlgebra.Determinent(matrix) == 0)
        throw new Error("inverse calculation failed.");
#endif

      Matrix<long> identity = LinearAlgebra.MatrixFactoryIdentity_long(matrix.Rows, matrix.Columns);
      Matrix<long> rref = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (rref[i, i] == 0)
          for (int j = i + 1; j < rref.Rows; j++)
            if (rref[j, i] != 0)
            {
              LinearAlgebra.SwapRows(rref, i, j);
              LinearAlgebra.SwapRows(identity, i, j);
            }
        LinearAlgebra.RowMultiplication(identity, i, 1 / rref[i, i]);
        LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
        for (int j = i + 1; j < rref.Rows; j++)
        {
          LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        }
        for (int j = i - 1; j >= 0; j--)
        {
          LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        }
      }
      return identity;
    }

    /// <summary>Calculates the adjoint of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the adjoint of.</param>
    /// <returns>The adjoint of the matrix.</returns>
    public static Matrix<long> Adjoint(Matrix<long> matrix)
    {
      #region pre-optimization

      //Matrix<long> AdjointMatrix = new Matrix<long>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    if ((i + j) % 2 == 0)
      //      AdjointMatrix[i, j] = LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      //    else
      //      AdjointMatrix[i, j] = -LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      //return LinearAlgebra.Transpose(AdjointMatrix);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (!(matrix.Rows == matrix.Columns))
        throw new Error("Adjoint of a non-square matrix does not exists");
#endif

      Matrix<long> AdjointMatrix = new Matrix<long>(matrix.Rows, matrix.Columns);
      for (int i = 0; i < matrix.Rows; i++)
        for (int j = 0; j < matrix.Columns; j++)
          if ((i + j) % 2 == 0)
            AdjointMatrix[i, j] = LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
          else
            AdjointMatrix[i, j] = -LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      return LinearAlgebra.Transpose(AdjointMatrix);
    }

    /// <summary>Returns the transpose of a matrix.</summary>
    /// <param name="matrix">The matrix to transpose.</param>
    /// <returns>The transpose of the matrix.</returns>
    public static Matrix<long> Transpose(Matrix<long> matrix)
    {
      #region pre-optimization

      //Matrix<long> transpose = 
      //  new Matrix<long>(matrix.Columns, matrix.Rows);
      //for (int i = 0; i < transpose.Rows; i++)
      //  for (int j = 0; j < transpose.Columns; j++)
      //    transpose[i, j] = matrix[j, i];
      //return transpose;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<long> transpose =
        new Matrix<long>(matrix.Columns, matrix.Rows);
      for (int i = 0; i < transpose.Rows; i++)
        for (int j = 0; j < transpose.Columns; j++)
          transpose[i, j] = matrix[j, i];
      return transpose;
    }

    /// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
    /// <param name="matrix">The matrix to decompose.</param>
    /// <param name="Lower">The computed lower triangular matrix.</param>
    /// <param name="Upper">The computed upper triangular matrix.</param>
    public static void DecomposeLU(Matrix<long> matrix, out Matrix<long> Lower, out Matrix<long> Upper)
    {
      #region pre-optimization

      //Lower = LinearAlgebra.MatrixFactoryIdentity_long(matrix.Rows, matrix.Columns);
      //Upper = matrix.Clone();
      //int[] permutation = new int[matrix.Rows];
      //for (int i = 0; i < matrix.Rows; i++) permutation[i] = i;
      //long p = 0, pom2, detOfP = 1;
      //int k0 = 0, pom1 = 0;
      //for (int k = 0; k < matrix.Columns - 1; k++)
      //{
      //  p = 0;
      //  for (int i = k; i < matrix.Rows; i++)
      //    if ((Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k]) > p)
      //    {
      //      p = Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k];
      //      k0 = i;
      //    }
      //  if (p == 0)
      //    throw new Error("The matrix is singular!");
      //  pom1 = permutation[k];
      //  permutation[k] = permutation[k0];
      //  permutation[k0] = pom1;
      //  for (int i = 0; i < k; i++)
      //  {
      //    pom2 = Lower[k, i];
      //    Lower[k, i] = Lower[k0, i];
      //    Lower[k0, i] = pom2;
      //  }
      //  if (k != k0)
      //    detOfP *= -1;
      //  for (int i = 0; i < matrix.Columns; i++)
      //  {
      //    pom2 = Upper[k, i];
      //    Upper[k, i] = Upper[k0, i];
      //    Upper[k0, i] = pom2;
      //  }
      //  for (int i = k + 1; i < matrix.Rows; i++)
      //  {
      //    Lower[i, k] = Upper[i, k] / Upper[k, k];
      //    for (int j = k; j < matrix.Columns; j++)
      //      Upper[i, j] = Upper[i, j] - Lower[i, k] * Upper[k, j];
      //  }
      //}

      #endregion

#if no_error_checking
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        throw new Error("non-square matrix during DecomposeLU function");
#endif

      Lower = LinearAlgebra.MatrixFactoryIdentity_long(matrix.Rows, matrix.Columns);
      Upper = matrix.Clone();
      int[] permutation = new int[matrix.Rows];
      for (int i = 0; i < matrix.Rows; i++) permutation[i] = i;
      long p = 0, pom2, detOfP = 1;
      int k0 = 0, pom1 = 0;
      for (int k = 0; k < matrix.Columns - 1; k++)
      {
        p = 0;
        for (int i = k; i < matrix.Rows; i++)
          if ((Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k]) > p)
          {
            p = Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k];
            k0 = i;
          }
        if (p == 0)
          throw new Error("The matrix is singular!");
        pom1 = permutation[k];
        permutation[k] = permutation[k0];
        permutation[k0] = pom1;
        for (int i = 0; i < k; i++)
        {
          pom2 = Lower[k, i];
          Lower[k, i] = Lower[k0, i];
          Lower[k0, i] = pom2;
        }
        if (k != k0)
          detOfP *= -1;
        for (int i = 0; i < matrix.Columns; i++)
        {
          pom2 = Upper[k, i];
          Upper[k, i] = Upper[k0, i];
          Upper[k0, i] = pom2;
        }
        for (int i = k + 1; i < matrix.Rows; i++)
        {
          Lower[i, k] = Upper[i, k] / Upper[k, k];
          for (int j = k; j < matrix.Columns; j++)
            Upper[i, j] = Upper[i, j] - Lower[i, k] * Upper[k, j];
        }
      }
    }

    private static void RowMultiplication(Matrix<long> matrix, int row, long scalar)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //  matrix[row, j] *= scalar;

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
        matrix[row, j] *= scalar;
    }

    private static void RowAddition(Matrix<long> matrix, int target, int second, long scalar)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //  matrix[target, j] += (matrix[second, j] * scalar);

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
        matrix[target, j] += (matrix[second, j] * scalar);
    }

    private static void SwapRows(Matrix<long> matrix, int row1, int row2)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //{
      //  long temp = matrix[row1, j];
      //  matrix[row1, j] = matrix[row2, j];
      //  matrix[row2, j] = temp;
      //}

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
      {
        long temp = matrix[row1, j];
        matrix[row1, j] = matrix[row2, j];
        matrix[row2, j] = temp;
      }
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Matrix<long> left, Matrix<long> right)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;
      //if (left.Rows != right.Rows || left.Columns != right.Columns)
      //  return false;
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    if (left[i, j] != right[i, j])
      //      return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Rows != right.Rows || left.Columns != right.Columns)
        return false;
      for (int i = 0; i < left.Rows; i++)
        for (int j = 0; j < left.Columns; j++)
          if (left[i, j] != right[i, j])
            return false;

      return true;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Matrix<long> left, Matrix<long> right, long leniency)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;
      //if (left.Rows != right.Rows || left.Columns != right.Columns)
      //  return false;
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    if (Logic.Abs(left[i, j] - right[i, j]) > leniency)
      //      return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        return false;
      for (int i = 0; i < left.Rows; i++)
        for (int j = 0; j < left.Columns; j++)
          if (Logic.Abs(left[i, j] - right[i, j]) > leniency)
            return false;
      return true;
    }

    #endregion

    #region quaterion

    /// <summary>Computes the length of quaternion.</summary>
    /// <param name="quaternion">The quaternion to compute the length of.</param>
    /// <returns>The length of the given quaternion.</returns>
    public static long Magnitude(Quaternion<long> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return Algebra.sqrt(
          (quaternion.X * quaternion.X +
          quaternion.Y * quaternion.Y +
          quaternion.Z * quaternion.Z +
          quaternion.W * quaternion.W));
    }

    /// <summary>Computes the length of a quaternion, but doesn't square root it
    /// for optimization possibilities.</summary>
    /// <param name="quaternion">The quaternion to compute the length squared of.</param>
    /// <returns>The squared length of the given quaternion.</returns>
    public static long MagnitudeSquared(Quaternion<long> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return
        quaternion.X * quaternion.X +
        quaternion.Y * quaternion.Y +
        quaternion.Z * quaternion.Z +
        quaternion.W * quaternion.W;
    }

    /// <summary>Gets the conjugate of the quaternion.</summary>
    /// <param name="quaternion">The quaternion to conjugate.</param>
    /// <returns>The conjugate of teh given quaternion.</returns>
    public static Quaternion<long> Conjugate(Quaternion<long> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return new Quaternion<long>(
        -quaternion.X,
        -quaternion.Y,
        -quaternion.Z,
        quaternion.W);
    }

    /// <summary>Adds two quaternions together.</summary>
    /// <param name="left">The first quaternion of the addition.</param>
    /// <param name="right">The second quaternion of the addition.</param>
    /// <returns>The result of the addition.</returns>
    public static Quaternion<long> Add(Quaternion<long> left, Quaternion<long> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<long>(
        left.X + right.X,
        left.Y + right.Y,
        left.Z + right.Z,
        left.W + right.W);
    }

    /// <summary>Subtracts two quaternions.</summary>
    /// <param name="left">The left quaternion of the subtraction.</param>
    /// <param name="right">The right quaternion of the subtraction.</param>
    /// <returns>The resulting quaternion after the subtraction.</returns>
    public static Quaternion<long> Subtract(Quaternion<long> left, Quaternion<long> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<long>(
        left.X - right.X,
        left.Y - right.Y,
        left.Z - right.Z,
        left.W - right.W);
    }

    /// <summary>Multiplies two quaternions together.</summary>
    /// <param name="left">The first quaternion of the multiplication.</param>
    /// <param name="right">The second quaternion of the multiplication.</param>
    /// <returns>The resulting quaternion after the multiplication.</returns>
    public static Quaternion<long> Multiply(Quaternion<long> left, Quaternion<long> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<long>(
        left.X * right.W + left.W * right.X + left.Y * right.Z - left.Z * right.Y,
        left.Y * right.W + left.W * right.Y + left.Z * right.X - left.X * right.Z,
        left.Z * right.W + left.W * right.Z + left.X * right.Y - left.Y * right.X,
        left.W * right.W - left.X * right.X - left.Y * right.Y - left.Z * right.Z);
    }

    /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
    /// <param name="left">The quaternion of the multiplication.</param>
    /// <param name="right">The scalar of the multiplication.</param>
    /// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
    public static Quaternion<long> Multiply(Quaternion<long> left, long right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      return new Quaternion<long>(
        left.X * right,
        left.Y * right,
        left.Z * right,
        left.W * right);
    }

    /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
    /// <param name="left">The quaternion to pre-multiply the vector by.</param>
    /// <param name="right">The vector to be multiplied.</param>
    /// <returns>The resulting quaternion of the multiplication.</returns>
    public static Quaternion<long> Multiply(Quaternion<long> left, Vector<long> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (right.Dimensions != 3)
        throw new Error("my quaternion rotations are only defined for 3-component vectors.");
#endif

      return new Quaternion<long>(
        left.W * right.X + left.Y * right.Z - left.Z * right.Y,
        left.W * right.Y + left.Z * right.X - left.X * right.Z,
        left.W * right.Z + left.X * right.Y - left.Y * right.X,
        -left.X * right.X - left.Y * right.Y - left.Z * right.Z);
    }

    /// <summary>Normalizes the quaternion.</summary>
    /// <param name="quaternion">The quaternion to normalize.</param>
    /// <returns>The normalization of the given quaternion.</returns>
    public static Quaternion<long> Normalize(Quaternion<long> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      long normalizer = Quaternion<long>.Magnitude(quaternion);
      if (normalizer != 0)
        return quaternion * (1 / normalizer);
      else
        return Quaternion<long>.FactoryIdentity;
    }

    /// <summary>Inverts a quaternion.</summary>
    /// <param name="quaternion">The quaternion to find the inverse of.</param>
    /// <returns>The inverse of the given quaternion.</returns>
    public static Quaternion<long> Invert(Quaternion<long> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      long normalizer = Quaternion<long>.MagnitudeSquared(quaternion);
      if (normalizer == 0)
        return new Quaternion<long>(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
      normalizer = 1 / normalizer;
      return new Quaternion<long>(
        -quaternion.X * normalizer,
        -quaternion.Y * normalizer,
        -quaternion.Z * normalizer,
        quaternion.W * normalizer);
    }

    /// <summary>Lenearly interpolates between two quaternions.</summary>
    /// <param name="left">The starting point of the interpolation.</param>
    /// <param name="right">The ending point of the interpolation.</param>
    /// <param name="blend">The ratio 0.0-1.0 of how far to interpolate between the left and right quaternions.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Quaternion<long> Lerp(Quaternion<long> left, Quaternion<long> right, long blend)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      if (blend < 0 || blend > 1)
        throw new Error("invalid blending value during lerp !(blend < 0.0f || blend > 1.0f).");
      if (Quaternion<long>.MagnitudeSquared(left) == 0)
      {
        if (Quaternion<long>.MagnitudeSquared(right) == 0)
          return Quaternion<long>.FactoryIdentity;
        else
          return new Quaternion<long>(right.X, right.Y, right.Z, right.W);
      }
      else if (Quaternion<long>.MagnitudeSquared(right) == 0)
        return new Quaternion<long>(left.X, left.Y, left.Z, left.W);
      Quaternion<long> result = new Quaternion<long>(
        1 - blend * left.X + blend * right.X,
        1 - blend * left.Y + blend * right.Y,
        1 - blend * left.Z + blend * right.Z,
        1 - blend * left.W + blend * right.W);
      if (Quaternion<long>.MagnitudeSquared(result) > 0)
        return Quaternion<long>.Normalize(result);
      else
        return Quaternion<long>.FactoryIdentity;
    }

    /// <summary>Sphereically interpolates between two quaternions.</summary>
    /// <param name="left">The starting point of the interpolation.</param>
    /// <param name="right">The ending point of the interpolation.</param>
    /// <param name="blend">The ratio of how far to interpolate between the left and right quaternions.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Quaternion<long> Slerp(Quaternion<long> left, Quaternion<long> right, long blend)
    {
      throw new Error("requiers rational numeric types");

//#if no_error_checking
//      // nothing
//#else
//      if (object.ReferenceEquals(left, null))
//        throw new Error("null reference: left");
//      if (object.ReferenceEquals(right, null))
//        throw new Error("null reference: right");
//#endif

//      if (blend < 0 || blend > 1)
//        throw new Error("invalid blending value during slerp !(blend < 0.0f || blend > 1.0f).");
//      if (LinearAlgebra.MagnitudeSquared(left) == 0)
//      {
//        if (LinearAlgebra.MagnitudeSquared(right) == 0)
//          return Quaternion<long>.FactoryIdentity;
//        else
//          return new Quaternion<long>(right.X, right.Y, right.Z, right.W);
//      }
//      else if (LinearAlgebra.MagnitudeSquared(right) == 0)
//        return new Quaternion<long>(left.X, left.Y, left.Z, left.W);
//      long cosHalfAngle = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
//      if (cosHalfAngle >= 1 || cosHalfAngle <= -1)
//        return new Quaternion<long>(left.X, left.Y, left.Z, left.W);
//      else if (cosHalfAngle < 0)
//      {
//        right = new Quaternion<long>(-left.X, -left.Y, -left.Z, -left.W);
//        cosHalfAngle = -cosHalfAngle;
//      }
//      long halfAngle = Trigonometry.arccos(cosHalfAngle);
//      long sinHalfAngle = Trigonometry.sin(halfAngle);
//      long blendA = Trigonometry.sin(halfAngle * (1 - blend)) / sinHalfAngle;
//      long blendB = Trigonometry.sin(halfAngle * blend) / sinHalfAngle;
//      Quaternion<long> result = new Quaternion<long>(
//        blendA * left.X + blendB * right.X,
//        blendA * left.Y + blendB * right.Y,
//        blendA * left.Z + blendB * right.Z,
//        blendA * left.W + blendB * right.W);
//      if (LinearAlgebra.MagnitudeSquared(result) > 0)
//        return LinearAlgebra.Normalize(result);
//      else
//        return Quaternion<long>.FactoryIdentity;
    }

    /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
    /// <param name="rotation">The quaternion to rotate the vector by.</param>
    /// <param name="vector">The vector to be rotated by.</param>
    /// <returns>The result of the rotation.</returns>
    public static Vector<long> Rotate(Quaternion<long> rotation, Vector<long> vector)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(rotation, null))
        throw new Error("null reference: rotation");
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      if (vector.Dimensions != 3 && vector.Dimensions != 4)
        throw new Error("my quaternion rotations are only defined for 3-component vectors.");
      Quaternion<long> answer = LinearAlgebra.Multiply(LinearAlgebra.Multiply(rotation, vector), LinearAlgebra.Conjugate(rotation));
      return new Vector<long>(answer.X, answer.Y, answer.Z);
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first quaternion to check for equality.</param>
    /// <param name="right">The second quaternion  to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Quaternion<long> left, Quaternion<long> right)
    {
      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      return
        left.X == right.X &&
        left.Y == right.Y &&
        left.Z == right.Z &&
        left.W == right.W;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first quaternion to check for equality.</param>
    /// <param name="right">The second quaternion to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Quaternion<long> left, Quaternion<long> right, long leniency)
    {
      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      return
        Logic.Abs(left.X - right.X) < leniency &&
        Logic.Abs(left.Y - right.Y) < leniency &&
        Logic.Abs(left.Z - right.Z) < leniency &&
        Logic.Abs(left.W - right.W) < leniency;
    }

    #endregion

    #region tableau

    //const long epsilon = 1.0e-8;
    ////int equal(long a, long b) { return fabs(a - b) < epsilon; }

    //static void pivot_on(ref long[,] tableau, int row, int col)
    //{
    //  int i, j;
    //  long pivot;

    //  pivot = tableau[row, col];
    //  if (!(pivot > 0))
    //    throw new Error("possible invalid tableau values (IDK)");
    //  for (j = 0; j < tableau.GetLength(1); j++)
    //    tableau[row, j] /= pivot;
    //  if (!(Logic.Equate(tableau[row, col], 1, epsilon)))
    //    throw new Error("possible invalid tableau values (IDK)");

    //  for (i = 0; i < tableau.GetLength(0); i++)
    //  { // foreach remaining row i do
    //    long multiplier = tableau[i, col];
    //    if (i == row) continue;
    //    for (j = 0; j < tableau.GetLength(1); j++)
    //    { // r[i] = r[i] - z * r[row];
    //      tableau[i, j] -= multiplier * tableau[row, j];
    //    }
    //  }
    //}

    //// Find pivot_col = most negative column in mat[0][1..n]
    //static int find_pivot_column(ref long[,] tableau)
    //{
    //  int j, pivot_col = 1;
    //  long lowest = tableau[0, pivot_col];
    //  for (j = 1; j < tableau.GetLength(1); j++)
    //  {
    //    if (tableau[0, j] < lowest)
    //    {
    //      lowest = tableau[0, j];
    //      pivot_col = j;
    //    }
    //  }
    //  //printf("Most negative column in row[0] is col %d = %g.\n", pivot_col, lowest);
    //  if (lowest >= 0)
    //  {
    //    return -1; // All positive columns in row[0], this is optimal.
    //  }
    //  return pivot_col;
    //}

    //// Find the pivot_row, with smallest positive ratio = col[0] / col[pivot]
    //static int find_pivot_row(ref long[,] tableau, int pivot_col)
    //{
    //  int i, pivot_row = 0;
    //  long min_ratio = -1;
    //  //printf("Ratios A[row_i,0]/A[row_i,%d] = [", pivot_col);
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    long ratio = tableau[i, 0] / tableau[i, pivot_col];
    //    //printf("%3.2lf, ", ratio);
    //    if ((ratio > 0 && ratio < min_ratio) || min_ratio < 0)
    //    {
    //      min_ratio = ratio;
    //      pivot_row = i;
    //    }
    //  }
    //  //printf("].\n");
    //  if (min_ratio == -1)
    //    return -1; // Unbounded.
    //  //printf("Found pivot A[%d,%d], min positive ratio=%g in row=%d.\n",
    //  //  pivot_row, pivot_col, min_ratio, pivot_row);
    //  return pivot_row;
    //}

    //static void add_slack_variables(ref long[,] tableau)
    //{

    //  long[,] newTableau =
    //    new long[tableau.GetLength(0), tableau.GetLength(1) + tableau.GetLength(0) - 1];

    //  for (int a = 0, a_max = tableau.GetLength(0); a < a_max; a++)
    //    for (int b = 0, b_max = tableau.GetLength(1); b < b_max; b++)
    //      newTableau[a, b] = tableau[a, b];

    //  int i, j;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    for (j = 1; j < tableau.GetLength(0); j++)
    //      newTableau[i, j + tableau.GetLength(1) - 1] = (i == j ? 1d : 0d);
    //  }

    //  tableau = newTableau;
    //}

    //static void check_b_positive(ref long[,] tableau)
    //{
    //  int i;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //    if (!(tableau[i, 0] >= 0))
    //      throw new Error("possible invalid tableau values (IDK)");
    //}

    //// Given a column of identity matrix, find the row containing 1.
    //// return -1, if the column as not from an identity matrix.
    //static int find_basis_variable(ref long[,] tableau, int col)
    //{
    //  int i, xi = -1;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    if (Logic.Equate(tableau[i, col], 1, epsilon))
    //      if (xi == -1)
    //        xi = i;   // found first '1', save this row number.
    //      else
    //        return -1; // found second '1', not an identity matrix.
    //    else if (!Logic.Equate(tableau[i, col], 0, epsilon))
    //      return -1; // not an identity matrix column.
    //  }
    //  return xi;
    //}

    //static long[] print_optimal_vector(ref long[,] tableau)
    //{
    //  long[] vector = new long[tableau.GetLength(1)];
    //  int j, xi;
    //  //printf("%s at ", message);
    //  for (j = 1; j < tableau.GetLength(1); j++)
    //  { // for each column.
    //    xi = find_basis_variable(ref tableau, j);
    //    if (xi != -1)
    //      vector[j] = tableau[xi, 0];
    //    else
    //      vector[j] = j;
    //  }
    //  return vector;
    //}

    //public static long[] Simplex(ref long[,] tableau)
    //{
    //  int loop = 0;
    //  add_slack_variables(ref tableau);
    //  check_b_positive(ref tableau);
    //  while (++loop > 0)
    //  {
    //    int pivot_col, pivot_row;

    //    pivot_col = find_pivot_column(ref tableau);
    //    if (pivot_col < 0)
    //      //printf("Found optimal value=A[0,0]=%3.2lf (no negatives in row 0).\n",
    //      //  tableau->mat[0][0]);
    //      return print_optimal_vector(ref tableau);
    //    //printf("Entering variable x%d to be made basic, so pivot_col=%d.\n",
    //    //  pivot_col, pivot_col);

    //    pivot_row = find_pivot_row(ref tableau, pivot_col);
    //    if (pivot_row < 0)
    //      throw new Error("unbounded (no pivot_row)");
    //    //printf("Leaving variable x%d, so pivot_row=%d\n", pivot_row, pivot_row);

    //    pivot_on(ref tableau, pivot_row, pivot_col);
    //    //print_tableau(tableau, "After pivoting");
    //    //return print_optimal_vector(ref tableau);
    //  }
    //  throw new Error("Simplex has a glitch");
    //}

    #endregion

    #endregion

    #region int

    #region vector

    /// <summary>Adds two vectors together.</summary>
    /// <param name="left">The first vector of the addition.</param>
    /// <param name="right">The second vector of the addiiton.</param>
    /// <returns>The result of the addiion.</returns>
    public static Vector<int> Add(Vector<int> left, Vector<int> right)
    {
      #region pre-optimization

      //Vector<int> result =
      //  new Vector<int>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] + right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector addition.");
#endif

      int length = left.Dimensions;
      Vector<int> result =
        new Vector<int>(left.Dimensions);

#if unsafe_code
      unsafe
      {
        fixed (int*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
      }
#else
      int[] left_flat = left._vector;
      int[] right_flat = right._vector;
      int[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
#endif

      return result;
    }

    /// <summary>Negates all the values in a vector.</summary>
    /// <param name="vector">The vector to have its values negated.</param>
    /// <returns>The result of the negations.</returns>
    public static Vector<int> Negate(Vector<int> vector)
    {
      #region pre-optimization

      //Vector<int> result =
      //  new Vector<int>(vector.Dimensions);
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result[i] = -vector[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Vector<int> result =
        new Vector<int>(length);

#if unsafe_code
      unsafe
      {
        fixed (int*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = -vector_flat[i];
      }
#else
      int[] vector_flat = vector._vector;
      int[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = -vector_flat[i];
#endif

      return result;
    }

    /// <summary>Subtracts two vectors.</summary>
    /// <param name="left">The left vector of the subtraction.</param>
    /// <param name="right">The right vector of the subtraction.</param>
    /// <returns>The result of the vector subtracton.</returns>
    public static Vector<int> Subtract(Vector<int> left, Vector<int> right)
    {
      #region pre-optimization

      //Vector<int> result =
      //  new Vector<int>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] - right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector subtraction.");
#endif

      int length = left.Dimensions;
      Vector<int> result =
        new Vector<int>(length);

#if unsafe_code
      unsafe
      {
        fixed (int*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] - right_flat[i];
      }
#else
      int[] left_flat = left._vector;
      int[] right_flat = right._vector;
      int[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] - right_flat[i];
#endif

      return result;
    }

    /// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
    /// <param name="left">The vector to have the components multiplied by.</param>
    /// <param name="right">The scalars to multiply the vector components by.</param>
    /// <returns>The result of the multiplications.</returns>
    public static Vector<int> Multiply(Vector<int> left, int right)
    {
      #region pre-optimization

      //Vector<int> result =
      //  new Vector<int>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] * right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      int length = left.Dimensions;
      Vector<int> result =
        new Vector<int>(length);

#if unsafe_code
      unsafe
      {
        fixed (int*
          left_flat = left._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] * right;
      }
#else
      int[] left_flat = left._vector;
      int[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] * right;
#endif

      return result;
    }

    /// <summary>Divides all the components of a vector by a scalar.</summary>
    /// <param name="vector">The vector to have the components divided by.</param>
    /// <param name="right">The scalar to divide the vector components by.</param>
    /// <returns>The resulting vector after teh divisions.</returns>
    public static Vector<int> Divide(Vector<int> vector, int right)
    {
      #region pre-optimization

      //Vector<int> result =
      //  new Vector<int>(vector.Dimensions);
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result[i] = vector[i] / right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: left");
#endif

      int length = vector.Dimensions;
      Vector<int> result =
        new Vector<int>(length);

#if unsafe_code
      unsafe
      {
        fixed (int*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = vector_flat[i] / right;
      }
#else
      int[] vector_flat = vector._vector;
      int[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = vector_flat[i] / right;
#endif

      return result;
    }

    /// <summary>Computes the dot product between two vectors.</summary>
    /// <param name="left">The first vector of the dot product operation.</param>
    /// <param name="right">The second vector of the dot product operation.</param>
    /// <returns>The result of the dot product operation.</returns>
    public static int DotProduct(Vector<int> left, Vector<int> right)
    {
      #region pre-optimization

      //int result = 0;
      //for (int i = 0; i < left.Dimensions; i++)
      //  result += left[i] * right[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid dimensions on vector dot product.");
#endif

      int length = left.Dimensions;
      int result = 0;

#if unsafe_code
      unsafe
      {
        fixed (int*
          left_flat = left._vector,
          right_flat = right._vector)
          for (int i = 0; i < length; i++)
            result += left_flat[i] * right_flat[i];
      }
#else
      int[] left_flat = left._vector;
      int[] right_flat = right._vector;
      for (int i = 0; i < length; i++)
        result += left_flat[i] * right_flat[i];
#endif

      return result;
    }

    /// <summary>Computes teh cross product of two vectors.</summary>
    /// <param name="left">The first vector of the cross product operation.</param>
    /// <param name="right">The second vector of the cross product operation.</param>
    /// <returns>The result of the cross product operation.</returns>
    public static Vector<int> CrossProduct(Vector<int> left, Vector<int> right)
    {
      #region pre-optimization

      //Vector<int> result = new Vector<int>(3);
      //result[0] = left[1] * right[2] - left[2] * right[1];
      //result[1] = left[2] * right[0] - left[0] * right[2];
      //result[2] = left[0] * right[1] - left[1] * right[0];

      #endregion

#if no_error_checking

#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid cross product (left.Dimensions != right.Dimensions)");
      if (left.Dimensions != 3)
        throw new Error("my cross product function is only defined for 3-component vectors.");
#endif

      Vector<int> result =
        new Vector<int>(3);

#if unsafe_code
      unsafe
      {
        fixed (int*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
        {
          result_flat[0] = left_flat[1] * right_flat[2] - left_flat[2] * right_flat[1];
          result_flat[1] = left_flat[2] * right_flat[0] - left_flat[0] * right_flat[2];
          result_flat[2] = left_flat[0] * right_flat[1] - left_flat[1] * right_flat[0];
        }
      }
#else
      int[] left_flat = left._vector;
      int[] right_flat = right._vector;
      int[] result_flat = result._vector;
      result_flat[0] = left_flat[1] * right_flat[2] - left_flat[2] * right_flat[1];
      result_flat[1] = left_flat[2] * right_flat[0] - left_flat[0] * right_flat[2];
      result_flat[2] = left_flat[0] * right_flat[1] - left_flat[1] * right_flat[0];
#endif

      return result;
    }

    /// <summary>Normalizes a vector.</summary>
    /// <param name="vector">The vector to normalize.</param>
    /// <returns>The result of the normalization.</returns>
    public static Vector<int> Normalize(Vector<int> vector)
    {
      #region pre-optimization

      //int magnitude = LinearAlgebra.Magnitude(vector);
      //if (magnitude != 0)
      //{
      //  Vector<int> result = 
      //    new Vector<int>(vector.Dimensions);
      //  for (int i = 0; i < vector.Dimensions; i++)
      //    result[i] = vector[i] / magnitude;
      //  return result;
      //}
      //else
      //  return new int[vector.Dimensions];

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      Vector<int> result =
        new Vector<int>(vector.Dimensions);
      int magnitude = LinearAlgebra.Magnitude(vector);
      if (magnitude != 0)
        return result;

#if unsafe_code
      unsafe
      {
        fixed (int*
          vector_flat = vector._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = vector_flat[i] / magnitude;
      }
#else
      int[] vector_flat = vector._vector;
      int[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = vector_flat[i] / magnitude;
#endif

      return result;

    }

    /// <summary>Computes the length of a vector.</summary>
    /// <param name="vector">The vector to calculate the length of.</param>
    /// <returns>The computed length of the vector.</returns>
    public static int Magnitude(Vector<int> vector)
    {
      #region pre-optimization

      //int result = 0;
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result += vector[i] * vector[i];
      //return Algebra.sqrt(result);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      int result = 0;

#if unsafe_code
      unsafe
      {
        fixed (int*
          vector_flat = vector._vector)
          for (int i = 0; i < length; i++)
            result += vector_flat[i] * vector_flat[i];
      }
#else
      int[] vector_flat = vector._vector;
      for (int i = 0; i < length; i++)
        result += vector_flat[i] * vector_flat[i];
#endif

      return Algebra.sqrt(result);
    }

    /// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
    /// <param name="vector">The vector to compute the length squared of.</param>
    /// <returns>The computed length squared of the vector.</returns>
    public static int MagnitudeSquared(Vector<int> vector)
    {
      #region pre-optimization

      //int result = 0;
      //for (int i = 0; i < vector.Dimensions; i++)
      //  result += vector[i] * vector[i];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      int length = vector.Dimensions;
      int result = 0;

#if unsafe_code
      unsafe
      {
        fixed (int*
          vector_flat = vector._vector)
          for (int i = 0; i < length; i++)
            result += vector_flat[i] * vector_flat[i];
      }
#else
      int[] vector_flat = vector._vector;
      for (int i = 0; i < length; i++)
        result += vector_flat[i] * vector_flat[i];
#endif

      return result;
    }

    /// <summary>Computes the angle between two vectors.</summary>
    /// <param name="first">The first vector to determine the angle between.</param>
    /// <param name="second">The second vector to determine the angle between.</param>
    /// <returns>The angle between the two vectors in radians.</returns>
    public static int Angle(Vector<int> first, Vector<int> second)
    {
      throw new Error("requiers rational numeric types");

//      #region pre-optimization

//      //return Trigonometry.arccos(
//      //  LinearAlgebra.DotProduct(first, second) / 
//      //  (LinearAlgebra.Magnitude(first) * 
//      //  LinearAlgebra.Magnitude(second)));

//      #endregion

//#if no_error_checking
//      // nothing
//#else
//      if (object.ReferenceEquals(first, null))
//        throw new Error("null reference: first");
//      if (object.ReferenceEquals(second, null))
//        throw new Error("null reference: second");
//#endif

//      return Trigonometry.arccos(
//        LinearAlgebra.DotProduct(first, second) /
//        (LinearAlgebra.Magnitude(first) *
//        LinearAlgebra.Magnitude(second)));
    }

    /// <summary>Rotates a 3-component vector by the specified axis and rotation values.</summary>
    /// <param name="vector">The vector to rotate.</param>
    /// <param name="angle">The angle of the rotation in radians.</param>
    /// <param name="x">The x component of the axis vector to rotate about.</param>
    /// <param name="y">The y component of the axis vector to rotate about.</param>
    /// <param name="z">The z component of the axis vector to rotate about.</param>
    /// <returns>The result of the rotation.</returns>
    public static Vector<int> RotateBy(Vector<int> vector, int angle, int x, int y, int z)
    {
      throw new Error("requiers rational numeric types");

//      #region pre-optimization

//      //int sinHalfAngle = Trigonometry.sin(angle / 2);
//      //int cosHalfAngle = Trigonometry.cos(angle / 2);
//      //x *= sinHalfAngle;
//      //y *= sinHalfAngle;
//      //z *= sinHalfAngle;
//      //int x2 = cosHalfAngle * vector[0] + y * vector[2] - z * vector[1];
//      //int y2 = cosHalfAngle * vector[1] + z * vector[0] - x * vector[2];
//      //int z2 = cosHalfAngle * vector[2] + x * vector[1] - y * vector[0];
//      //int w2 = -x * vector[0] - y * vector[1] - z * vector[2];
//      //Vector<int> result = new Vector<int>();
//      //result[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
//      //result[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
//      //result[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;

//      #endregion

//#if no_error_checking
//      // nothing
//#else
//      if (object.ReferenceEquals(vector, null))
//        throw new Error("null reference: vector");
//      if (vector.Dimensions == 3)
//        throw new Error("my RotateBy() function is only defined for 3-component vectors.");
//#endif

//      Vector<int> result = new Vector<int>(3);
//      int sinHalfAngle = Trigonometry.sin(angle / 2);
//      int cosHalfAngle = Trigonometry.cos(angle / 2);
//      x *= sinHalfAngle;
//      y *= sinHalfAngle;
//      z *= sinHalfAngle;

//#if unsafe_code
//      unsafe
//      {
//        fixed (int*
//          vector_flat = vector._vector,
//          result_flat = result._vector)
//        {
//          int x2 = cosHalfAngle * vector_flat[0] + y * vector_flat[2] - z * vector_flat[1];
//          int y2 = cosHalfAngle * vector_flat[1] + z * vector_flat[0] - x * vector_flat[2];
//          int z2 = cosHalfAngle * vector_flat[2] + x * vector_flat[1] - y * vector_flat[0];
//          int w2 = -x * vector_flat[0] - y * vector_flat[1] - z * vector_flat[2];
//          result_flat[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
//          result_flat[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
//          result_flat[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;
//        }
//      }
//#else
//      int[] vector_flat = vector._vector;
//      int[] result_flat = result._vector;
//      int x2 = cosHalfAngle * vector_flat[0] + y * vector_flat[2] - z * vector_flat[1];
//      int y2 = cosHalfAngle * vector_flat[1] + z * vector_flat[0] - x * vector_flat[2];
//      int z2 = cosHalfAngle * vector_flat[2] + x * vector_flat[1] - y * vector_flat[0];
//      int w2 = -x * vector_flat[0] - y * vector_flat[1] - z * vector_flat[2];
//      result_flat[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
//      result_flat[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
//      result_flat[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;
//#endif

//      return result;
    }

    /// <summary>Rotates a vector by a quaternion rotation.</summary>
    /// <param name="vector">The vector to be rotated.</param>
    /// <param name="quaternion">The rotation to be applied.</param>
    /// <returns>The vector after the rotation.</returns>
    public static Vector<int> RotateBy(Vector<int> vector, Quaternion<int> quaternion)
    {
      return Rotate(quaternion, vector);
    }

    /// <summary>Computes the linear interpolation between two vectors.</summary>
    /// <param name="left">The starting vector of the interpolation.</param>
    /// <param name="right">The ending vector of the interpolation.</param>
    /// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Vector<int> Lerp(Vector<int> left, Vector<int> right, int blend)
    {
      #region pre-optimization

      //Vector<int> result = new Vector<int>(left.Dimensions);
      //for (int i = 0; i < left.Dimensions; i++)
      //  result[i] = left[i] + blend * (right[i] - left[i]);
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (blend < 0 || blend > 1)
        throw new Error("invalid vector lerp blend value: (blend < 0.0f || blend > 1.0f).");
      if (left.Dimensions != right.Dimensions)
        throw new Error("invalid vector lerp length: (left.Dimensions != right.Dimensions)");
#endif

      int length = left.Dimensions;
      Vector<int> result =
        new Vector<int>(length);

#if unsafe_code
      unsafe
      {
        fixed (int*
          left_flat = left._vector,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < length; i++)
            result_flat[i] = left_flat[i] + blend * (right_flat[i] - left_flat[i]);
      }
#else
      int[] left_flat = left._vector;
      int[] right_flat = right._vector;
      int[] result_flat = result._vector;
      for (int i = 0; i < length; i++)
        result_flat[i] = left_flat[i] + blend * (right_flat[i] - left_flat[i]);
#endif

      return result;
    }

    /// <summary>Sphereically interpolates between two vectors.</summary>
    /// <param name="left">The starting vector of the interpolation.</param>
    /// <param name="right">The ending vector of the interpolation.</param>
    /// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
    /// <returns>The result of the slerp operation.</returns>
    public static Vector<int> Slerp(Vector<int> left, Vector<int> right, int blend)
    {
      throw new Error("requiers rational numeric types");

//      #region pre-optimization

//      //int dot = LinearAlgebra.DotProduct(left, right);
//      //dot = dot < -1 ? -1 : dot;
//      //dot = dot > 1 ? 1 : dot;
//      //int theta = Trigonometry.arccos(dot) * blend;
//      //return LinearAlgebra.Multiply(LinearAlgebra.Add(LinearAlgebra.Multiply(left, Trigonometry.cos(theta)),
//      //  LinearAlgebra.Normalize(LinearAlgebra.Subtract(right, LinearAlgebra.Multiply(left, dot)))), Trigonometry.sin(theta));

//      #endregion

//#if no_error_checking
//      // nothing
//#else
//      if (object.ReferenceEquals(left, null))
//        throw new Error("null reference: left");
//      if (object.ReferenceEquals(right, null))
//        throw new Error("null reference: right");
//      if (blend < 0 || blend > 1)
//        throw new Error("invalid slerp blend value: (blend < 0.0f || blend > 1.0f).");
//#endif

//      int dot = LinearAlgebra.DotProduct(left, right);
//      dot = dot < -1 ? -1 : dot;
//      dot = dot > 1 ? 1 : dot;
//      int theta = Trigonometry.arccos(dot) * blend;
//      return LinearAlgebra.Multiply(LinearAlgebra.Add(LinearAlgebra.Multiply(left, Trigonometry.cos(theta)),
//        LinearAlgebra.Normalize(LinearAlgebra.Subtract(right, LinearAlgebra.Multiply(left, dot)))), Trigonometry.sin(theta));
    }

    /// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
    /// <param name="a">The first vector of the interpolation.</param>
    /// <param name="b">The second vector of the interpolation.</param>
    /// <param name="c">The thrid vector of the interpolation.</param>
    /// <param name="u">The "U" value of the barycentric interpolation equation.</param>
    /// <param name="v">The "V" value of the barycentric interpolation equation.</param>
    /// <returns>The resulting vector of the barycentric interpolation.</returns>
    public static Vector<int> Blerp(Vector<int> a, Vector<int> b, Vector<int> c, int u, int v)
    {
      #region pre-optimization

      //return 
      //  LinearAlgebra.Add(
      //    LinearAlgebra.Add(
      //      LinearAlgebra.Multiply(
      //        LinearAlgebra.Subtract(b, a), u),
      //          LinearAlgebra.Multiply(
      //            LinearAlgebra.Subtract(c, a), v)), a);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(a, null))
        throw new Error("null reference: a");
      if (object.ReferenceEquals(b, null))
        throw new Error("null reference: b");
      if (object.ReferenceEquals(c, null))
        throw new Error("null reference: c");
#endif

      return
        LinearAlgebra.Add(
          LinearAlgebra.Add(
            LinearAlgebra.Multiply(
              LinearAlgebra.Subtract(b, a), u),
                LinearAlgebra.Multiply(
                  LinearAlgebra.Subtract(c, a), v)), a);
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Vector<int> left, Vector<int> right)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;

      //if (left.Dimensions != right.Dimensions)
      //  return false;
      //for (int i = 0; i < left.Dimensions; i++)
      //  if (left[i] != right[i])
      //    return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Dimensions != right.Dimensions)
        return false;
      for (int i = 0; i < left.Dimensions; i++)
        if (left[i] != right[i])
          return false;
      return true;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Vector<int> left, Vector<int> right, int leniency)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;

      //if (left.Dimensions != right.Dimensions)
      //  return false;
      //for (int i = 0; i < left.Dimensions; i++)
      //  if (Logic.Abs(left[i] - right[i]) > leniency)
      //    return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Dimensions != right.Dimensions)
        return false;
      for (int i = 0; i < left.Dimensions; i++)
        if (Logic.Abs(left[i] - right[i]) > leniency)
          return false;
      return true;
    }

    #endregion

    #region matrix

    /// <summary>Determines if a matrix is symetric or not.</summary>
    /// <param name="matrix">The matrix to determine symetry of.</param>
    /// <returns>True if symetric; false if not.</returns>
    public static bool IsSymmetric(Matrix<int> matrix)
    {
      #region pre-optimization

      //if (matrix.Rows != matrix.Columns)
      //  return false;
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    if (matrix[i, j] != matrix[j, i])
      //      return false;
      //return true;

      #endregion

#if no_errorchecking
      //nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        return false;
#endif
      int size = matrix.Columns;
#if unsafe_code
      unsafe
      {
        fixed (int* matrix_flat = matrix._matrix)
          for (var row = 0; row < size; row++)
            for (var column = row + 1; column < size; column++)
              if (matrix_flat[row * size + column] != matrix_flat[column * size + row])
                return false;
      }
#else
      int[] matrix_flat = matrix._matrix;
      for (var row = 0; row < size; row++)
        for (var column = row + 1; column < size; column++)
          if (matrix_flat[row * size + column] != matrix_flat[column * size + row])
            return false;
#endif
      return true;
    }

    /// <summary>Constructs a new identity-matrix of the given dimensions.</summary>
    /// <param name="rows">The number of rows of the matrix.</param>
    /// <param name="columns">The number of columns of the matrix.</param>
    /// <returns>The newly constructed identity-matrix.</returns>
    public static Matrix<int> MatrixFactoryIdentity_int(int rows, int columns)
    {
      #region pre-optimization

      //Matrix<int> matrix = 
      //  new Matrix<int>(rows, columns);
      //for (int i = 0; i < Logic.Min(rows, columns); i++)
      //  matrix[i, i] = 1;
      //return matrix;

      #endregion

#if no_error_checking
      //nothing
#else
      if (rows < 1)
        throw new Error("invalid row count on matrix creation");
      if (columns < 1)
        throw new Error("invalid column count on matrix creation");
#endif

      Matrix<int> matrix = new Matrix<int>(rows, columns);
      if (rows <= columns)
        for (int i = 0; i < rows; i++)
          matrix[i, i] = 1;
      else
        for (int i = 0; i < columns; i++)
          matrix[i, i] = 1;
      return matrix;
    }

    /// <summary>Negates all the values in a matrix.</summary>
    /// <param name="matrix">The matrix to have its values negated.</param>
    /// <returns>The resulting matrix after the negations.</returns>
    public static Matrix<int> Negate(Matrix<int> matrix)
    {
      #region pre-optimization

      //Matrix<int> result =
      //  new Matrix<int>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Rows; j++)
      //    result[i, j] = -matrix[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
        if (object.ReferenceEquals(matrix, null))
          throw new Error("null reference: matirx");
#endif

      Matrix<int> result =
        new Matrix<int>(matrix.Rows, matrix.Columns);
      int size = matrix.Rows * matrix.Columns;

#if unsafe_code
      unsafe
      {
        fixed (int*
          result_flat = result._matrix,
          matrix_flat = matrix._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = -matrix_flat[i];
        return result;
      }
#else
      int[] result_flat = result._matrix;
      int[] matrix_flat = matrix._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = -matrix_flat[i];
      return result;
#endif
    }

    /// <summary>Negates all the values in a matrix.</summary>
    /// <param name="matrix">The matrix to have its values negated.</param>
    /// <returns>The resulting matrix after the negations.</returns>
    public static Matrix<int> Negate_parallel(Matrix<int> matrix)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matirx");
#endif

      if (matrix.Rows * matrix.Columns > _parallelMinimum)
      {
        Matrix<int> result =
        new Matrix<int>(matrix.Rows, matrix.Columns);
        int size = matrix.Rows * matrix.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (int*
                  result_flat = result._matrix,
                  matrix_flat = matrix._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = -matrix_flat[i];
              };
            }, Logic.Max(matrix.Rows, matrix.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                int[] matrix_flat = matrix._matrix;
                int[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = -matrix_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Negate(matrix);
    }

    /// <summary>Does standard addition of two matrices.</summary>
    /// <param name="left">The left matrix of the addition.</param>
    /// <param name="right">The right matrix of the addition.</param>
    /// <returns>The resulting matrix after the addition.</returns>
    public static Matrix<int> Add(Matrix<int> left, Matrix<int> right)
    {
      #region pre-optimization

      //Matrix<int> result =
      //  new Matrix<int>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] + right[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
          throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix addition (dimension miss-match).");
#endif

      Matrix<int> result =
        new Matrix<int>(left.Rows, left.Columns);
      int size = left.Rows * left.Columns;

#if unsafe_code
      unsafe
      {
        fixed (int*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = left_flat[i] + right_flat[i];
      }
#else
      int[] left_flat = left._matrix;
      int[] right_flat = right._matrix;
      int[] result_flat = result._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = left_flat[i] + right_flat[i];
#endif

      return result;
    }

    /// <summary>Does standard addition of two matrices.</summary>
    /// <param name="left">The left matrix of the addition.</param>
    /// <param name="right">The right matrix of the addition.</param>
    /// <returns>The resulting matrix after the addition.</returns>
    public static Matrix<int> Add_parallel(Matrix<int> left, Matrix<int> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix addition (dimension miss-match).");
#endif

      if (left.Rows * left.Columns > _parallelMinimum)
      {
        Matrix<int> result =
        new Matrix<int>(left.Rows, left.Columns);
        int size = left.Rows * left.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (int*
                  left_flat = left._matrix,
                  right_flat = right._matrix,
                  result_flat = result._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = left_flat[i] + right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                int[] left_flat = left._matrix;
                int[] right_flat = right._matrix;
                int[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = left_flat[i] + right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Add(left, right);
    }

    /// <summary>Subtracts a scalar from all the values in a matrix.</summary>
    /// <param name="left">The matrix to have the values subtracted from.</param>
    /// <param name="right">The scalar to subtract from all the matrix values.</param>
    /// <returns>The resulting matrix after the subtractions.</returns>
    public static Matrix<int> Subtract(Matrix<int> left, Matrix<int> right)
    {
      #region pre-optimization

      //Matrix<int> result =
      //  new Matrix<int>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] - right[i, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix subtraction (dimension miss-match).");
#endif

      Matrix<int> result =
        new Matrix<int>(left.Rows, left.Columns);
      int size = left.Rows * left.Columns;

#if unsafe_code
      unsafe
      {
        fixed (int*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < size; i++)
            result_flat[i] = left_flat[i] - right_flat[i];
      }
#else
      int[] left_flat = left._matrix;
      int[] right_flat = right._matrix;
      int[] result_flat = result._matrix;
      for (int i = 0; i < size; i++)
        result_flat[i] = left_flat[i] - right_flat[i];
#endif

      return result;
    }

    /// <summary>Subtracts a scalar from all the values in a matrix.</summary>
    /// <param name="left">The matrix to have the values subtracted from.</param>
    /// <param name="right">The scalar to subtract from all the matrix values.</param>
    /// <returns>The resulting matrix after the subtractions.</returns>
    public static Matrix<int> Subtract_parallel(Matrix<int> left, Matrix<int> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        throw new Error("invalid matrix subtraction (dimension miss-match).");
#endif

      if (left.Rows * left.Columns > _parallelMinimum)
      {
        Matrix<int> result =
        new Matrix<int>(left.Rows, left.Columns);
        int size = left.Rows * left.Columns;

#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                fixed (int*
                  left_flat = left._matrix,
                  right_flat = right._matrix,
                  result_flat = result._matrix)
                  for (int i = current; i < size; i += max)
                    result_flat[i] = left_flat[i] - right_flat[i];
              };
            }, Logic.Max(left.Rows, left.Columns));
        }
#else
          Seven.Parallels.AutoParallel.Divide(
          (int current, int max) =>
          {
            return () =>
            {
              int[] left_flat = left._matrix;
              int[] right_flat = right._matrix;
              int[] result_flat = result._matrix;
                for (int i = current; i < size; i += max)
                  result_flat[i] = left_flat[i] - right_flat[i];
            };
          }, Logic.Max(left.Rows, left.Columns));
#endif
        return result;
      }
      else
        return LinearAlgebra.Subtract(left, right);
    }

    /// <summary>Performs multiplication on two matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Matrix<int> Multiply(Matrix<int> left, Matrix<int> right)
    {
      #region pre-optimization

      //Matrix<int> result = 
      //  new Matrix<int>(left.Rows, right.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < right.Columns; j++)
      //    for (int k = 0; k < left.Columns; k++)
      //      result[i, j] += left[i, k] * right[k, j];
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (left == null)
        throw new Error("null reference: left");
      if (right == null)
        throw new Error("null reference: right");
      if (left.Columns != right.Rows)
        throw new LinearAlgebra.Error("invalid multiplication (size miss-match).");
#endif

      int sum;
      int result_rows = left.Rows;
      int left_cols = left.Columns;
      int result_cols = right.Columns;
      Matrix<int> result =
        new Matrix<int>(result_rows, result_cols);

#if unsafe_code
      unsafe
      {
        fixed (int*
          result_flat = result._matrix,
          left_flat = left._matrix,
          right_flat = right._matrix)
          for (int i = 0; i < result_rows; i++)
            for (int j = 0; j < result_cols; j++)
            {
              sum = 0;
              for (int k = 0; k < left_cols; k++)
                sum += left_flat[i * left_cols + k] * right_flat[k * result_cols + j];
              result_flat[i * result_cols + j] = sum;
            }
      }
#else
      int[] result_flat = result._matrix;
      int[] left_flat = left._matrix;
      int[] right_flat = right._matrix;

      for (int i = 0; i < result_rows; i++)
        for (int j = 0; j < result_cols; j++)
        {
          sum = 0;
          for (int k = 0; k < left_cols; k++)
            sum += left_flat[i * left_cols + k] * right_flat[k * result_cols + j];
          result_flat[i * result_cols + j] = sum;
        }
#endif

      return result;
    }

    /// <summary>Performs multiplication on two matrices using multi-threading.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Matrix<int> Multiply_parrallel(Matrix<int> left, Matrix<int> right)
    {
#if no_error_checking
      // nothing
#else
      if (left == null)
        throw new Error("null reference: left");
      if (right == null)
        throw new Error("null reference: right");
      if (left.Columns != right.Rows)
        throw new LinearAlgebra.Error("invalid multiplication (dimension miss-match).");
#endif

      int result_rows = left.Rows;
      int left_cols = left.Columns;
      int result_cols = right.Columns;

      // If there are enough rows to warrant multi-threading,
      // then multithread the row for-loop.
      if (result_rows * result_cols > _parallelMinimum &&
        result_rows >= result_cols)
      {
        Matrix<int> result =
          new Matrix<int>(result_rows, result_cols);
#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                int sum;
                int left_i_offest;
                int result_i_offset;

                fixed (int*
                  result_flat = result._matrix,
                  left_flat = left._matrix,
                  right_flat = right._matrix)
                  for (int i = current; i < result_rows; i += max)
                  {
                    left_i_offest = i * left_cols;
                    result_i_offset = i * result_cols;
                    for (int j = 0; j < result_cols; j++)
                    {
                      sum = 0;
                      for (int k = 0; k < left_cols; k++)
                        sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                      result_flat[result_i_offset + j] = sum;
                    }
                  }
              };
            }, result_rows);
        }
#else
              int[] result_flat = result._matrix;
              int[] left_flat = left._matrix;
              int[] right_flat = right._matrix;

              Seven.Parallels.AutoParallel.Divide(
                  (int current, int max) =>
                  {
                    return () =>
                    {
                      int sum;
                      int left_i_offest;
                      int result_i_offset;

                      for (int i = current; i < result_rows; i += max)
                      {
                        left_i_offest = i * left_cols;
                        result_i_offset = i * result_cols;
                        for (int j = 0; j < result_cols; j++)
                        {
                          sum = 0;
                          for (int k = 0; k < left_cols; k++)
                            sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                          result_flat[result_i_offset + j] = sum;
                        }
                      }
                    };
                  }, result_rows);

#endif
        return result;
      }
      // If there are enough columns to warrant multi-threading,
      // then multithread the column for-loop.
      else if (result_rows * result_cols > _parallelMinimum &&
        result_rows < result_cols)
      {
        Matrix<int> result =
          new Matrix<int>(result_rows, result_cols);
#if unsafe_code
        unsafe
        {
          Seven.Parallels.AutoParallel.Divide(
            (int current, int max) =>
            {
              return () =>
              {
                int sum;
                int left_i_offest;
                int result_i_offset;

                fixed (int*
                  result_flat = result._matrix,
                  left_flat = left._matrix,
                  right_flat = right._matrix)
                  for (int i = 0; i < result_rows; i++)
                  {
                    left_i_offest = i * left_cols;
                    result_i_offset = i * result_cols;
                    for (int j = current; j < result_cols; j += max)
                    {
                      sum = 0;
                      for (int k = 0; k < left_cols; k++)
                        sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                      result_flat[result_i_offset + j] = sum;
                    }
                  }
              };
            }, result_cols);
        }
#else
              int[] result_flat = result._matrix;
              int[] left_flat = left._matrix;
              int[] right_flat = right._matrix;

              Seven.Parallels.AutoParallel.Divide(
                  (int current, int max) =>
                  {
                    return () =>
                    {
                      int sum;
                      int left_i_offest;
                      int result_i_offset;

                      for (int i = 0; i < result_rows; i++)
                      {
                        left_i_offest = i * left_cols;
                        result_i_offset = i * result_cols;
                        for (int j = current; j < result_cols; j += max)
                        {
                          sum = 0;
                          for (int k = 0; k < left_cols; k++)
                            sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
                          result_flat[result_i_offset + j] = sum;
                        }
                      }
                    };
                  }, result_cols);
#endif
        return result;
      }
      // Multi-threading is not necessary.
      else
        return LinearAlgebra.Multiply(left, right);
    }

    /// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Vector<int> Multiply(Matrix<int> left, Vector<int> right)
    {
      #region pre-optimization

      //Vector<int> result = 
      //  new Vector<int>(right.Dimensions);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i] += left[i, j] * right[j];
      //return result;

      #endregion

#if no_error_checking
      int left_row = left.Rows;
      int left_col = left.Columns;
#else
      int left_row = left.Rows;
      int left_col = left.Columns;
      if (left.Columns != right.Dimensions)
        throw new Error("invalid multiplication (size miss-match).");
#endif

      Vector<int> result = new Vector<int>(right.Dimensions);

#if unsafe_code
      unsafe
      {
        fixed (int*
          left_flat = left._matrix,
          right_flat = right._vector,
          result_flat = result._vector)
          for (int i = 0; i < left_row; i++)
            for (int j = 0; j < left_col; j++)
              result_flat[i] += left_flat[i * left_col + j] * right_flat[j];
        return result;
      }
#else
      int[] left_flat = left._matrix;
      int[] right_flat = right._vector;
      int[] result_flat = result._vector;
      for (int i = 0; i < left_row; i++)
        for (int j = 0; j < left_col; j++)
          result_flat[i] += left_flat[i * left_col + j] * right_flat[j];
      return result;
#endif
      return result;
    }

    /// <summary>Multiplies all the values in a matrix by a scalar.</summary>
    /// <param name="left">The matrix to have the values multiplied.</param>
    /// <param name="right">The scalar to multiply the values by.</param>
    /// <returns>The resulting matrix after the multiplications.</returns>
    public static Matrix<int> Multiply(Matrix<int> left, int right)
    {
      #region pre-optimization

      //Matrix<int> result = 
      //  new Matrix<int>(left.Rows, left.Columns);
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    result[i, j] = left[i, j] * right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      int rows = left.Rows;
      int columns = left.Columns;
      Matrix<int> result = new Matrix<int>(rows, columns);

#if unsafe_code
      unsafe
      {
        fixed (int*
          left_flat = left._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
              result_flat[i * columns + j] = left_flat[i * columns + j] * right;
      }
#else
      for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
          result[i, j] = left[i, j] * right;
#endif

      return result;
    }

    /// <summary>Applies a power to a square matrix.</summary>
    /// <param name="matrix">The matrix to be powered by.</param>
    /// <param name="power">The power to apply to the matrix.</param>
    /// <returns>The resulting matrix of the power operation.</returns>
    public static Matrix<int> Power(Matrix<int> matrix, int power)
    {
      #region pre-optimization

      //Matrix<int> result = matrix.Clone();
      //for (int i = 0; i < power; i++)
      //  result = LinearAlgebra.Multiply(result, result);
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (!(matrix.Rows == matrix.Columns))
        throw new Error("invalid power (!matrix.IsSquare).");
      if (!(power >= 0))
        throw new Error("invalid power !(power > -1)");
#endif
      // this is not optimized...
      if (power == 0)
        return LinearAlgebra.MatrixFactoryIdentity_int(matrix.Rows, matrix.Columns);
      Matrix<int> result = matrix.Clone();
      for (int i = 0; i < power; i++)
        result = LinearAlgebra.Multiply(result, matrix);
      return result;
    }

    /// <summary>Divides all the values in the matrix by a scalar.</summary>
    /// <param name="matrix">The matrix to divide the values of.</param>
    /// <param name="right">The scalar to divide all the matrix values by.</param>
    /// <returns>The resulting matrix with the divided values.</returns>
    public static Matrix<int> Divide(Matrix<int> matrix, int right)
    {
      #region pre-optimization

      //Matrix<int> result = 
      //  new Matrix<int>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    result[i, j] = matrix[i, j] / right;
      //return result;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      int matrix_row = matrix.Rows;
      int matrix_col = matrix.Columns;
      Matrix<int> result =
        new Matrix<int>(matrix_row, matrix_col);

#if unsafe_code
      unsafe
      {
        fixed (int*
          matrix_flat = matrix._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < matrix_row; i++)
            for (int j = 0; j < matrix_col; j++)
              result_flat[i * matrix_col + j] =
                matrix_flat[i * matrix_col + j] / right;
      }
#else
      int[] matrix_flat = matrix._matrix;
      int[] result_flat = result._matrix;
      for (int i = 0; i < matrix_row; i++)
        for (int j = 0; j < matrix_col; j++)
          result_flat[i * matrix_col + j] = 
            matrix_flat[i * matrix_col + j] / right;

#endif
      return result;
    }

    /// <summary>Gets the minor of a matrix.</summary>
    /// <param name="matrix">The matrix to get the minor of.</param>
    /// <param name="row">The restricted row to form the minor.</param>
    /// <param name="column">The restricted column to form the minor.</param>
    /// <returns>The minor of the matrix.</returns>
    public static Matrix<int> Minor(Matrix<int> matrix, int row, int column)
    {
      #region pre-optimization

      //Matrix<int> minor = 
      //  new Matrix<int>(matrix.Rows - 1, matrix.Columns - 1);
      //int m = 0, n = 0;
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (i == row) continue;
      //  n = 0;
      //  for (int j = 0; j < matrix.Columns; j++)
      //  {
      //    if (j == column) continue;
      //    minor[m, n] = matrix[i, j];
      //    n++;
      //  }
      //  m++;
      //}
      //return minor;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows < 2 || matrix.Columns < 2)
        throw new Error("invalid matrix minor: (matrix.Rows < 2 || matrix.Columns < 2)");
      if (row < 0 || row >= matrix.Rows)
        throw new Error("invalid row on matrix minor: !(0 <= row < matrix.Rows)");
      if (column < 0 || row >= matrix.Columns)
        throw new Error("invalid column on matrix minor: !(0 <= column < matrix.Columns)");
#endif

      Matrix<int> minor =
        new Matrix<int>(matrix.Rows - 1, matrix.Columns - 1);
      int matrix_rows = matrix.Rows;
      int matrix_cols = matrix.Columns;

#if unsafe_code
      unsafe
      {
        fixed (int*
          matrix_flat = matrix._matrix,
          minor_flat = minor._matrix)
        {
          int m = 0, n = 0;
          for (int i = 0; i < matrix_rows; i++)
          {
            if (i == row) continue;
            n = 0;
            for (int j = 0; j < matrix_cols; j++)
            {
              if (j == column) continue;
              minor_flat[m * matrix_cols + n] =
                matrix_flat[i * matrix_cols + j];
              n++;
            }
            m++;
          }
        }
      }
#else
      int m = 0, n = 0;
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (i == row) continue;
        n = 0;
        for (int j = 0; j < matrix.Columns; j++)
        {
          if (j == column) continue;
          minor[m, n] = matrix[i, j];
          n++;
        }
        m++;
      }
#endif
      return minor;
    }

    /// <summary>Combines two matrices from left to right 
    /// (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
    /// <param name="left">The left matrix of the concatenation.</param>
    /// <param name="right">The right matrix of the concatenation.</param>
    /// <returns>The resulting matrix of the concatenation.</returns>
    public static Matrix<int> ConcatenateRowWise(Matrix<int> left, Matrix<int> right)
    {
      #region pre-optimization

      //Matrix<int> result =
      //  new Matrix<int>(left.Rows, left.Columns + right.Columns);
      //for (int i = 0; i < result.Rows; i++)
      //  for (int j = 0; j < result.Columns; j++)
      //    if (j < left.Columns)
      //      result[i, j] = left[i, j];
      //    else
      //      result[i, j] = right[i, j - left.Columns];
      //return result;

      #endregion

#if no_errorChecking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (left.Rows != right.Rows)
        throw new Error("invalid row-wise concatenation !(left.Rows == right.Rows).");
#endif

      Matrix<int> result =
        new Matrix<int>(left.Rows, left.Columns + right.Columns);
      int result_rows = result.Rows;
      int result_cols = result.Columns;

      int left_cols = left.Columns;
      int right_cols = right.Columns;

#if unsafe_code
      unsafe
      {
        // OptimizeMe (jump statement)
        fixed (int*
          left_flat = left._matrix,
          right_flat = right._matrix,
          result_flat = result._matrix)
          for (int i = 0; i < result_rows; i++)
            for (int j = 0; j < result_cols; j++)
              if (j < left_cols)
                result_flat[i * result_cols + j] =
                  left_flat[i * left_cols + j];
              else
                result_flat[i * result_cols + j] =
                  right_flat[i * right_cols + j - left_cols];
      }
#else
      for (int i = 0; i < result_rows; i++)
        for (int j = 0; j < result_cols; j++)
        {
          if (j < left.Columns)
            result[i, j] = left[i, j];
          else
            result[i, j] = right[i, j - left.Columns];
        }
#endif

      return result;
    }

    /// <summary>Calculates the echelon of a matrix (aka REF).</summary>
    /// <param name="matrix">The matrix to calculate the echelon of (aka REF).</param>
    /// <returns>The echelon of the matrix (aka REF).</returns>
    public static Matrix<int> Echelon(Matrix<int> matrix)
    {
      #region pre-optimization

      //Matrix<int> result = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (result[i, i] == 0)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] != 0)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  if (result[i, i] == 0)
      //    continue;
      //  if (result[i, i] != 1)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] == 1)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
      //  for (int j = i + 1; j < result.Rows; j++)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<int> result = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (result[i, i] == 0)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] != 0)
              LinearAlgebra.SwapRows(result, i, j);
        if (result[i, i] == 0)
          continue;
        if (result[i, i] != 1)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] == 1)
              LinearAlgebra.SwapRows(result, i, j);
        LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
        for (int j = i + 1; j < result.Rows; j++)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      }
      return result;
    }

    /// <summary>Calculates the echelon of a matrix and reduces it (aka RREF).</summary>
    /// <param name="matrix">The matrix matrix to calculate the reduced echelon of (aka RREF).</param>
    /// <returns>The reduced echelon of the matrix (aka RREF).</returns>
    public static Matrix<int> ReducedEchelon(Matrix<int> matrix)
    {
      #region pre-optimization

      //Matrix<int> result = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (result[i, i] == 0)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] != 0)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  if (result[i, i] == 0) continue;
      //  if (result[i, i] != 1)
      //    for (int j = i + 1; j < result.Rows; j++)
      //      if (result[j, i] == 1)
      //        LinearAlgebra.SwapRows(result, i, j);
      //  LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
      //  for (int j = i + 1; j < result.Rows; j++)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      //  for (int j = i - 1; j >= 0; j--)
      //    LinearAlgebra.RowAddition(result, j, i, -result[j, i]);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<int> result = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (result[i, i] == 0)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] != 0)
              LinearAlgebra.SwapRows(result, i, j);
        if (result[i, i] == 0) continue;
        if (result[i, i] != 1)
          for (int j = i + 1; j < result.Rows; j++)
            if (result[j, i] == 1)
              LinearAlgebra.SwapRows(result, i, j);
        LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
        for (int j = i + 1; j < result.Rows; j++)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
        for (int j = i - 1; j >= 0; j--)
          LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
      }
      return result;
    }

    /// <summary>Calculates the determinent of a square matrix.</summary>
    /// <param name="matrix">The matrix to calculate the determinent of.</param>
    /// <returns>The determinent of the matrix.</returns>
    public static int Determinent(Matrix<int> matrix)
    {
      #region pre-optimization

      //int det = 1;
      //Matrix<int> rref = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (rref[i, i] == 0)
      //    for (int j = i + 1; j < rref.Rows; j++)
      //      if (rref[j, i] != 0)
      //      {
      //        LinearAlgebra.SwapRows(rref, i, j);
      //        det *= -1;
      //      }
      //  det *= rref[i, i];
      //  LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
      //  for (int j = i + 1; j < rref.Rows; j++)
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  for (int j = i - 1; j >= 0; j--)
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //}
      //return det;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        throw new Error("invalid matrix determinent: !(matrix.IsSquare)");
#endif

      int det = 1;
      Matrix<int> rref = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (rref[i, i] == 0)
          for (int j = i + 1; j < rref.Rows; j++)
            if (rref[j, i] != 0)
            {
              LinearAlgebra.SwapRows(rref, i, j);
              det *= -1;
            }
        det *= rref[i, i];
        LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
        for (int j = i + 1; j < rref.Rows; j++)
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        for (int j = i - 1; j >= 0; j--)
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      }
      return det;
    }

    /// <summary>Calculates the inverse of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the inverse of.</param>
    /// <returns>The inverse of the matrix.</returns>
    public static Matrix<int> Inverse(Matrix<int> matrix)
    {
      #region pre-optimization

      //Matrix<int> identity = 
      //  LinearAlgebra.MatrixFactoryIdentity_int(matrix.Rows, matrix.Columns);
      //Matrix<int> rref = matrix.Clone();
      //for (int i = 0; i < matrix.Rows; i++)
      //{
      //  if (rref[i, i] == 0)
      //    for (int j = i + 1; j < rref.Rows; j++)
      //      if (rref[j, i] != 0)
      //      {
      //        LinearAlgebra.SwapRows(rref, i, j);
      //        LinearAlgebra.SwapRows(identity, i, j);
      //      }
      //  LinearAlgebra.RowMultiplication(identity, i, 1 / rref[i, i]);
      //  LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
      //  for (int j = i + 1; j < rref.Rows; j++)
      //  {
      //    LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  }
      //  for (int j = i - 1; j >= 0; j--)
      //  {
      //    LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
      //    LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
      //  }
      //}
      //return identity;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (LinearAlgebra.Determinent(matrix) == 0)
        throw new Error("inverse calculation failed.");
#endif

      Matrix<int> identity = LinearAlgebra.MatrixFactoryIdentity_int(matrix.Rows, matrix.Columns);
      Matrix<int> rref = matrix.Clone();
      for (int i = 0; i < matrix.Rows; i++)
      {
        if (rref[i, i] == 0)
          for (int j = i + 1; j < rref.Rows; j++)
            if (rref[j, i] != 0)
            {
              LinearAlgebra.SwapRows(rref, i, j);
              LinearAlgebra.SwapRows(identity, i, j);
            }
        LinearAlgebra.RowMultiplication(identity, i, 1 / rref[i, i]);
        LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
        for (int j = i + 1; j < rref.Rows; j++)
        {
          LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        }
        for (int j = i - 1; j >= 0; j--)
        {
          LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
          LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
        }
      }
      return identity;
    }

    /// <summary>Calculates the adjoint of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the adjoint of.</param>
    /// <returns>The adjoint of the matrix.</returns>
    public static Matrix<int> Adjoint(Matrix<int> matrix)
    {
      #region pre-optimization

      //Matrix<int> AdjointMatrix = new Matrix<int>(matrix.Rows, matrix.Columns);
      //for (int i = 0; i < matrix.Rows; i++)
      //  for (int j = 0; j < matrix.Columns; j++)
      //    if ((i + j) % 2 == 0)
      //      AdjointMatrix[i, j] = LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      //    else
      //      AdjointMatrix[i, j] = -LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      //return LinearAlgebra.Transpose(AdjointMatrix);

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (!(matrix.Rows == matrix.Columns))
        throw new Error("Adjoint of a non-square matrix does not exists");
#endif

      Matrix<int> AdjointMatrix = new Matrix<int>(matrix.Rows, matrix.Columns);
      for (int i = 0; i < matrix.Rows; i++)
        for (int j = 0; j < matrix.Columns; j++)
          if ((i + j) % 2 == 0)
            AdjointMatrix[i, j] = LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
          else
            AdjointMatrix[i, j] = -LinearAlgebra.Determinent(LinearAlgebra.Minor(matrix, i, j));
      return LinearAlgebra.Transpose(AdjointMatrix);
    }

    /// <summary>Returns the transpose of a matrix.</summary>
    /// <param name="matrix">The matrix to transpose.</param>
    /// <returns>The transpose of the matrix.</returns>
    public static Matrix<int> Transpose(Matrix<int> matrix)
    {
      #region pre-optimization

      //Matrix<int> transpose = 
      //  new Matrix<int>(matrix.Columns, matrix.Rows);
      //for (int i = 0; i < transpose.Rows; i++)
      //  for (int j = 0; j < transpose.Columns; j++)
      //    transpose[i, j] = matrix[j, i];
      //return transpose;

      #endregion

#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
#endif

      Matrix<int> transpose =
        new Matrix<int>(matrix.Columns, matrix.Rows);
      for (int i = 0; i < transpose.Rows; i++)
        for (int j = 0; j < transpose.Columns; j++)
          transpose[i, j] = matrix[j, i];
      return transpose;
    }

    /// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
    /// <param name="matrix">The matrix to decompose.</param>
    /// <param name="Lower">The computed lower triangular matrix.</param>
    /// <param name="Upper">The computed upper triangular matrix.</param>
    public static void DecomposeLU(Matrix<int> matrix, out Matrix<int> Lower, out Matrix<int> Upper)
    {
      #region pre-optimization

      //Lower = LinearAlgebra.MatrixFactoryIdentity_int(matrix.Rows, matrix.Columns);
      //Upper = matrix.Clone();
      //int[] permutation = new int[matrix.Rows];
      //for (int i = 0; i < matrix.Rows; i++) permutation[i] = i;
      //int p = 0, pom2, detOfP = 1;
      //int k0 = 0, pom1 = 0;
      //for (int k = 0; k < matrix.Columns - 1; k++)
      //{
      //  p = 0;
      //  for (int i = k; i < matrix.Rows; i++)
      //    if ((Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k]) > p)
      //    {
      //      p = Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k];
      //      k0 = i;
      //    }
      //  if (p == 0)
      //    throw new Error("The matrix is singular!");
      //  pom1 = permutation[k];
      //  permutation[k] = permutation[k0];
      //  permutation[k0] = pom1;
      //  for (int i = 0; i < k; i++)
      //  {
      //    pom2 = Lower[k, i];
      //    Lower[k, i] = Lower[k0, i];
      //    Lower[k0, i] = pom2;
      //  }
      //  if (k != k0)
      //    detOfP *= -1;
      //  for (int i = 0; i < matrix.Columns; i++)
      //  {
      //    pom2 = Upper[k, i];
      //    Upper[k, i] = Upper[k0, i];
      //    Upper[k0, i] = pom2;
      //  }
      //  for (int i = k + 1; i < matrix.Rows; i++)
      //  {
      //    Lower[i, k] = Upper[i, k] / Upper[k, k];
      //    for (int j = k; j < matrix.Columns; j++)
      //      Upper[i, j] = Upper[i, j] - Lower[i, k] * Upper[k, j];
      //  }
      //}

      #endregion

#if no_error_checking
#else
      if (object.ReferenceEquals(matrix, null))
        throw new Error("null reference: matrix");
      if (matrix.Rows != matrix.Columns)
        throw new Error("non-square matrix during DecomposeLU function");
#endif

      Lower = LinearAlgebra.MatrixFactoryIdentity_int(matrix.Rows, matrix.Columns);
      Upper = matrix.Clone();
      int[] permutation = new int[matrix.Rows];
      for (int i = 0; i < matrix.Rows; i++) permutation[i] = i;
      int p = 0, pom2, detOfP = 1;
      int k0 = 0, pom1 = 0;
      for (int k = 0; k < matrix.Columns - 1; k++)
      {
        p = 0;
        for (int i = k; i < matrix.Rows; i++)
          if ((Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k]) > p)
          {
            p = Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k];
            k0 = i;
          }
        if (p == 0)
          throw new Error("The matrix is singular!");
        pom1 = permutation[k];
        permutation[k] = permutation[k0];
        permutation[k0] = pom1;
        for (int i = 0; i < k; i++)
        {
          pom2 = Lower[k, i];
          Lower[k, i] = Lower[k0, i];
          Lower[k0, i] = pom2;
        }
        if (k != k0)
          detOfP *= -1;
        for (int i = 0; i < matrix.Columns; i++)
        {
          pom2 = Upper[k, i];
          Upper[k, i] = Upper[k0, i];
          Upper[k0, i] = pom2;
        }
        for (int i = k + 1; i < matrix.Rows; i++)
        {
          Lower[i, k] = Upper[i, k] / Upper[k, k];
          for (int j = k; j < matrix.Columns; j++)
            Upper[i, j] = Upper[i, j] - Lower[i, k] * Upper[k, j];
        }
      }
    }

    private static void RowMultiplication(Matrix<int> matrix, int row, int scalar)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //  matrix[row, j] *= scalar;

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
        matrix[row, j] *= scalar;
    }

    private static void RowAddition(Matrix<int> matrix, int target, int second, int scalar)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //  matrix[target, j] += (matrix[second, j] * scalar);

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
        matrix[target, j] += (matrix[second, j] * scalar);
    }

    private static void SwapRows(Matrix<int> matrix, int row1, int row2)
    {
      #region pre-optimization

      //for (int j = 0; j < matrix.Columns; j++)
      //{
      //  int temp = matrix[row1, j];
      //  matrix[row1, j] = matrix[row2, j];
      //  matrix[row2, j] = temp;
      //}

      #endregion

      for (int j = 0; j < matrix.Columns; j++)
      {
        int temp = matrix[row1, j];
        matrix[row1, j] = matrix[row2, j];
        matrix[row2, j] = temp;
      }
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Matrix<int> left, Matrix<int> right)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;
      //if (left.Rows != right.Rows || left.Columns != right.Columns)
      //  return false;
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    if (left[i, j] != right[i, j])
      //      return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      if (left.Rows != right.Rows || left.Columns != right.Columns)
        return false;
      for (int i = 0; i < left.Rows; i++)
        for (int j = 0; j < left.Columns; j++)
          if (left[i, j] != right[i, j])
            return false;

      return true;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Matrix<int> left, Matrix<int> right, int leniency)
    {
      #region pre-optimization

      //if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
      //  return true;
      //if (object.ReferenceEquals(left, null))
      //  return false;
      //if (object.ReferenceEquals(right, null))
      //  return false;
      //if (left.Rows != right.Rows || left.Columns != right.Columns)
      //  return false;
      //for (int i = 0; i < left.Rows; i++)
      //  for (int j = 0; j < left.Columns; j++)
      //    if (Logic.Abs(left[i, j] - right[i, j]) > leniency)
      //      return false;
      //return true;

      #endregion

      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;
      if (left.Rows != right.Rows || left.Columns != right.Columns)
        return false;
      for (int i = 0; i < left.Rows; i++)
        for (int j = 0; j < left.Columns; j++)
          if (Logic.Abs(left[i, j] - right[i, j]) > leniency)
            return false;
      return true;
    }

    #endregion

    #region quaterion

    /// <summary>Computes the length of quaternion.</summary>
    /// <param name="quaternion">The quaternion to compute the length of.</param>
    /// <returns>The length of the given quaternion.</returns>
    public static int Magnitude(Quaternion<int> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return Algebra.sqrt(
          (quaternion.X * quaternion.X +
          quaternion.Y * quaternion.Y +
          quaternion.Z * quaternion.Z +
          quaternion.W * quaternion.W));
    }

    /// <summary>Computes the length of a quaternion, but doesn't square root it
    /// for optimization possibilities.</summary>
    /// <param name="quaternion">The quaternion to compute the length squared of.</param>
    /// <returns>The squared length of the given quaternion.</returns>
    public static int MagnitudeSquared(Quaternion<int> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return
        quaternion.X * quaternion.X +
        quaternion.Y * quaternion.Y +
        quaternion.Z * quaternion.Z +
        quaternion.W * quaternion.W;
    }

    /// <summary>Gets the conjugate of the quaternion.</summary>
    /// <param name="quaternion">The quaternion to conjugate.</param>
    /// <returns>The conjugate of teh given quaternion.</returns>
    public static Quaternion<int> Conjugate(Quaternion<int> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      return new Quaternion<int>(
        -quaternion.X,
        -quaternion.Y,
        -quaternion.Z,
        quaternion.W);
    }

    /// <summary>Adds two quaternions together.</summary>
    /// <param name="left">The first quaternion of the addition.</param>
    /// <param name="right">The second quaternion of the addition.</param>
    /// <returns>The result of the addition.</returns>
    public static Quaternion<int> Add(Quaternion<int> left, Quaternion<int> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<int>(
        left.X + right.X,
        left.Y + right.Y,
        left.Z + right.Z,
        left.W + right.W);
    }

    /// <summary>Subtracts two quaternions.</summary>
    /// <param name="left">The left quaternion of the subtraction.</param>
    /// <param name="right">The right quaternion of the subtraction.</param>
    /// <returns>The resulting quaternion after the subtraction.</returns>
    public static Quaternion<int> Subtract(Quaternion<int> left, Quaternion<int> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<int>(
        left.X - right.X,
        left.Y - right.Y,
        left.Z - right.Z,
        left.W - right.W);
    }

    /// <summary>Multiplies two quaternions together.</summary>
    /// <param name="left">The first quaternion of the multiplication.</param>
    /// <param name="right">The second quaternion of the multiplication.</param>
    /// <returns>The resulting quaternion after the multiplication.</returns>
    public static Quaternion<int> Multiply(Quaternion<int> left, Quaternion<int> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      return new Quaternion<int>(
        left.X * right.W + left.W * right.X + left.Y * right.Z - left.Z * right.Y,
        left.Y * right.W + left.W * right.Y + left.Z * right.X - left.X * right.Z,
        left.Z * right.W + left.W * right.Z + left.X * right.Y - left.Y * right.X,
        left.W * right.W - left.X * right.X - left.Y * right.Y - left.Z * right.Z);
    }

    /// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
    /// <param name="left">The quaternion of the multiplication.</param>
    /// <param name="right">The scalar of the multiplication.</param>
    /// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
    public static Quaternion<int> Multiply(Quaternion<int> left, int right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
#endif

      return new Quaternion<int>(
        left.X * right,
        left.Y * right,
        left.Z * right,
        left.W * right);
    }

    /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
    /// <param name="left">The quaternion to pre-multiply the vector by.</param>
    /// <param name="right">The vector to be multiplied.</param>
    /// <returns>The resulting quaternion of the multiplication.</returns>
    public static Quaternion<int> Multiply(Quaternion<int> left, Vector<int> right)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
      if (right.Dimensions != 3)
        throw new Error("my quaternion rotations are only defined for 3-component vectors.");
#endif

      return new Quaternion<int>(
        left.W * right.X + left.Y * right.Z - left.Z * right.Y,
        left.W * right.Y + left.Z * right.X - left.X * right.Z,
        left.W * right.Z + left.X * right.Y - left.Y * right.X,
        -left.X * right.X - left.Y * right.Y - left.Z * right.Z);
    }

    /// <summary>Normalizes the quaternion.</summary>
    /// <param name="quaternion">The quaternion to normalize.</param>
    /// <returns>The normalization of the given quaternion.</returns>
    public static Quaternion<int> Normalize(Quaternion<int> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      int normalizer = Quaternion<int>.Magnitude(quaternion);
      if (normalizer != 0)
        return quaternion * (1 / normalizer);
      else
        return Quaternion<int>.FactoryIdentity;
    }

    /// <summary>Inverts a quaternion.</summary>
    /// <param name="quaternion">The quaternion to find the inverse of.</param>
    /// <returns>The inverse of the given quaternion.</returns>
    public static Quaternion<int> Invert(Quaternion<int> quaternion)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(quaternion, null))
        throw new Error("null reference: quaternion");
#endif

      int normalizer = Quaternion<int>.MagnitudeSquared(quaternion);
      if (normalizer == 0)
        return new Quaternion<int>(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
      normalizer = 1 / normalizer;
      return new Quaternion<int>(
        -quaternion.X * normalizer,
        -quaternion.Y * normalizer,
        -quaternion.Z * normalizer,
        quaternion.W * normalizer);
    }

    /// <summary>Lenearly interpolates between two quaternions.</summary>
    /// <param name="left">The starting point of the interpolation.</param>
    /// <param name="right">The ending point of the interpolation.</param>
    /// <param name="blend">The ratio 0.0-1.0 of how far to interpolate between the left and right quaternions.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Quaternion<int> Lerp(Quaternion<int> left, Quaternion<int> right, int blend)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(left, null))
        throw new Error("null reference: left");
      if (object.ReferenceEquals(right, null))
        throw new Error("null reference: right");
#endif

      if (blend < 0 || blend > 1)
        throw new Error("invalid blending value during lerp !(blend < 0.0f || blend > 1.0f).");
      if (Quaternion<int>.MagnitudeSquared(left) == 0)
      {
        if (Quaternion<int>.MagnitudeSquared(right) == 0)
          return Quaternion<int>.FactoryIdentity;
        else
          return new Quaternion<int>(right.X, right.Y, right.Z, right.W);
      }
      else if (Quaternion<int>.MagnitudeSquared(right) == 0)
        return new Quaternion<int>(left.X, left.Y, left.Z, left.W);
      Quaternion<int> result = new Quaternion<int>(
        1 - blend * left.X + blend * right.X,
        1 - blend * left.Y + blend * right.Y,
        1 - blend * left.Z + blend * right.Z,
        1 - blend * left.W + blend * right.W);
      if (Quaternion<int>.MagnitudeSquared(result) > 0)
        return Quaternion<int>.Normalize(result);
      else
        return Quaternion<int>.FactoryIdentity;
    }

    /// <summary>Sphereically interpolates between two quaternions.</summary>
    /// <param name="left">The starting point of the interpolation.</param>
    /// <param name="right">The ending point of the interpolation.</param>
    /// <param name="blend">The ratio of how far to interpolate between the left and right quaternions.</param>
    /// <returns>The result of the interpolation.</returns>
    public static Quaternion<int> Slerp(Quaternion<int> left, Quaternion<int> right, int blend)
    {
      throw new Error("requiers rational numeric types");

//#if no_error_checking
//      // nothing
//#else
//      if (object.ReferenceEquals(left, null))
//        throw new Error("null reference: left");
//      if (object.ReferenceEquals(right, null))
//        throw new Error("null reference: right");
//#endif

//      if (blend < 0 || blend > 1)
//        throw new Error("invalid blending value during slerp !(blend < 0.0f || blend > 1.0f).");
//      if (LinearAlgebra.MagnitudeSquared(left) == 0)
//      {
//        if (LinearAlgebra.MagnitudeSquared(right) == 0)
//          return Quaternion<int>.FactoryIdentity;
//        else
//          return new Quaternion<int>(right.X, right.Y, right.Z, right.W);
//      }
//      else if (LinearAlgebra.MagnitudeSquared(right) == 0)
//        return new Quaternion<int>(left.X, left.Y, left.Z, left.W);
//      int cosHalfAngle = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
//      if (cosHalfAngle >= 1 || cosHalfAngle <= -1)
//        return new Quaternion<int>(left.X, left.Y, left.Z, left.W);
//      else if (cosHalfAngle < 0)
//      {
//        right = new Quaternion<int>(-left.X, -left.Y, -left.Z, -left.W);
//        cosHalfAngle = -cosHalfAngle;
//      }
//      int halfAngle = Trigonometry.arccos(cosHalfAngle);
//      int sinHalfAngle = Trigonometry.sin(halfAngle);
//      int blendA = Trigonometry.sin(halfAngle * (1 - blend)) / sinHalfAngle;
//      int blendB = Trigonometry.sin(halfAngle * blend) / sinHalfAngle;
//      Quaternion<int> result = new Quaternion<int>(
//        blendA * left.X + blendB * right.X,
//        blendA * left.Y + blendB * right.Y,
//        blendA * left.Z + blendB * right.Z,
//        blendA * left.W + blendB * right.W);
//      if (LinearAlgebra.MagnitudeSquared(result) > 0)
//        return LinearAlgebra.Normalize(result);
//      else
//        return Quaternion<int>.FactoryIdentity;
    }

    /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
    /// <param name="rotation">The quaternion to rotate the vector by.</param>
    /// <param name="vector">The vector to be rotated by.</param>
    /// <returns>The result of the rotation.</returns>
    public static Vector<int> Rotate(Quaternion<int> rotation, Vector<int> vector)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(rotation, null))
        throw new Error("null reference: rotation");
      if (object.ReferenceEquals(vector, null))
        throw new Error("null reference: vector");
#endif

      if (vector.Dimensions != 3 && vector.Dimensions != 4)
        throw new Error("my quaternion rotations are only defined for 3-component vectors.");
      Quaternion<int> answer = LinearAlgebra.Multiply(LinearAlgebra.Multiply(rotation, vector), LinearAlgebra.Conjugate(rotation));
      return new Vector<int>(answer.X, answer.Y, answer.Z);
    }

    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first quaternion to check for equality.</param>
    /// <param name="right">The second quaternion  to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Quaternion<int> left, Quaternion<int> right)
    {
      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      return
        left.X == right.X &&
        left.Y == right.Y &&
        left.Z == right.Z &&
        left.W == right.W;
    }

    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first quaternion to check for equality.</param>
    /// <param name="right">The second quaternion to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Quaternion<int> left, Quaternion<int> right, int leniency)
    {
      if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
        return true;
      if (object.ReferenceEquals(left, null))
        return false;
      if (object.ReferenceEquals(right, null))
        return false;

      return
        Logic.Abs(left.X - right.X) < leniency &&
        Logic.Abs(left.Y - right.Y) < leniency &&
        Logic.Abs(left.Z - right.Z) < leniency &&
        Logic.Abs(left.W - right.W) < leniency;
    }

    #endregion

    #region tableau

    //const int epsilon = 1.0e-8;
    ////int equal(int a, int b) { return fabs(a - b) < epsilon; }

    //static void pivot_on(ref int[,] tableau, int row, int col)
    //{
    //  int i, j;
    //  int pivot;

    //  pivot = tableau[row, col];
    //  if (!(pivot > 0))
    //    throw new Error("possible invalid tableau values (IDK)");
    //  for (j = 0; j < tableau.GetLength(1); j++)
    //    tableau[row, j] /= pivot;
    //  if (!(Logic.Equate(tableau[row, col], 1, epsilon)))
    //    throw new Error("possible invalid tableau values (IDK)");

    //  for (i = 0; i < tableau.GetLength(0); i++)
    //  { // foreach remaining row i do
    //    int multiplier = tableau[i, col];
    //    if (i == row) continue;
    //    for (j = 0; j < tableau.GetLength(1); j++)
    //    { // r[i] = r[i] - z * r[row];
    //      tableau[i, j] -= multiplier * tableau[row, j];
    //    }
    //  }
    //}

    //// Find pivot_col = most negative column in mat[0][1..n]
    //static int find_pivot_column(ref int[,] tableau)
    //{
    //  int j, pivot_col = 1;
    //  int lowest = tableau[0, pivot_col];
    //  for (j = 1; j < tableau.GetLength(1); j++)
    //  {
    //    if (tableau[0, j] < lowest)
    //    {
    //      lowest = tableau[0, j];
    //      pivot_col = j;
    //    }
    //  }
    //  //printf("Most negative column in row[0] is col %d = %g.\n", pivot_col, lowest);
    //  if (lowest >= 0)
    //  {
    //    return -1; // All positive columns in row[0], this is optimal.
    //  }
    //  return pivot_col;
    //}

    //// Find the pivot_row, with smallest positive ratio = col[0] / col[pivot]
    //static int find_pivot_row(ref int[,] tableau, int pivot_col)
    //{
    //  int i, pivot_row = 0;
    //  int min_ratio = -1;
    //  //printf("Ratios A[row_i,0]/A[row_i,%d] = [", pivot_col);
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    int ratio = tableau[i, 0] / tableau[i, pivot_col];
    //    //printf("%3.2lf, ", ratio);
    //    if ((ratio > 0 && ratio < min_ratio) || min_ratio < 0)
    //    {
    //      min_ratio = ratio;
    //      pivot_row = i;
    //    }
    //  }
    //  //printf("].\n");
    //  if (min_ratio == -1)
    //    return -1; // Unbounded.
    //  //printf("Found pivot A[%d,%d], min positive ratio=%g in row=%d.\n",
    //  //  pivot_row, pivot_col, min_ratio, pivot_row);
    //  return pivot_row;
    //}

    //static void add_slack_variables(ref int[,] tableau)
    //{

    //  int[,] newTableau =
    //    new int[tableau.GetLength(0), tableau.GetLength(1) + tableau.GetLength(0) - 1];

    //  for (int a = 0, a_max = tableau.GetLength(0); a < a_max; a++)
    //    for (int b = 0, b_max = tableau.GetLength(1); b < b_max; b++)
    //      newTableau[a, b] = tableau[a, b];

    //  int i, j;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    for (j = 1; j < tableau.GetLength(0); j++)
    //      newTableau[i, j + tableau.GetLength(1) - 1] = (i == j ? 1d : 0d);
    //  }

    //  tableau = newTableau;
    //}

    //static void check_b_positive(ref int[,] tableau)
    //{
    //  int i;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //    if (!(tableau[i, 0] >= 0))
    //      throw new Error("possible invalid tableau values (IDK)");
    //}

    //// Given a column of identity matrix, find the row containing 1.
    //// return -1, if the column as not from an identity matrix.
    //static int find_basis_variable(ref int[,] tableau, int col)
    //{
    //  int i, xi = -1;
    //  for (i = 1; i < tableau.GetLength(0); i++)
    //  {
    //    if (Logic.Equate(tableau[i, col], 1, epsilon))
    //      if (xi == -1)
    //        xi = i;   // found first '1', save this row number.
    //      else
    //        return -1; // found second '1', not an identity matrix.
    //    else if (!Logic.Equate(tableau[i, col], 0, epsilon))
    //      return -1; // not an identity matrix column.
    //  }
    //  return xi;
    //}

    //static int[] print_optimal_vector(ref int[,] tableau)
    //{
    //  int[] vector = new int[tableau.GetLength(1)];
    //  int j, xi;
    //  //printf("%s at ", message);
    //  for (j = 1; j < tableau.GetLength(1); j++)
    //  { // for each column.
    //    xi = find_basis_variable(ref tableau, j);
    //    if (xi != -1)
    //      vector[j] = tableau[xi, 0];
    //    else
    //      vector[j] = j;
    //  }
    //  return vector;
    //}

    //public static int[] Simplex(ref int[,] tableau)
    //{
    //  int loop = 0;
    //  add_slack_variables(ref tableau);
    //  check_b_positive(ref tableau);
    //  while (++loop > 0)
    //  {
    //    int pivot_col, pivot_row;

    //    pivot_col = find_pivot_column(ref tableau);
    //    if (pivot_col < 0)
    //      //printf("Found optimal value=A[0,0]=%3.2lf (no negatives in row 0).\n",
    //      //  tableau->mat[0][0]);
    //      return print_optimal_vector(ref tableau);
    //    //printf("Entering variable x%d to be made basic, so pivot_col=%d.\n",
    //    //  pivot_col, pivot_col);

    //    pivot_row = find_pivot_row(ref tableau, pivot_col);
    //    if (pivot_row < 0)
    //      throw new Error("unbounded (no pivot_row)");
    //    //printf("Leaving variable x%d, so pivot_row=%d\n", pivot_row, pivot_row);

    //    pivot_on(ref tableau, pivot_row, pivot_col);
    //    //print_tableau(tableau, "After pivoting");
    //    //return print_optimal_vector(ref tableau);
    //  }
    //  throw new Error("Simplex has a glitch");
    //}

    #endregion

    #endregion

    #endregion

    #region error

    /// <summary>Error type for all linear algebra computations.</summary>
		internal class Error : Seven.Error
		{
			public Error(string message) : base(message) { }
    }

    #endregion
  }

	/// <summary>Represents a vector with an arbitrary number of components of a generic type.</summary>
	/// <typeparam name="T">The numeric type of this Vector.</typeparam>
	public class Vector<T>
  {
    /// <summary>The array of this vector.</summary>
    public readonly T[] _vector;

    #region runtime function mapping

    private static readonly LinearAlgebra.delegates.Vector_Add<T> Vector_Add;
    private static readonly LinearAlgebra.delegates.Vector_Negate<T> Vector_Negate;
    private static readonly LinearAlgebra.delegates.Vector_Subtract<T> Vector_Subtract;
    private static readonly LinearAlgebra.delegates.Vector_Multiply<T> Vector_Multiply;
    private static readonly LinearAlgebra.delegates.Vector_Divide<T> Vector_Divide;
    private static readonly LinearAlgebra.delegates.Vector_DotProduct<T> Vector_DotProduct;
    private static readonly LinearAlgebra.delegates.Vector_CrossProduct<T> Vector_CrossProduct;
    private static readonly LinearAlgebra.delegates.Vector_Normalize<T> Vector_Normalize;
    private static readonly LinearAlgebra.delegates.Vector_Magnitude<T> Vector_Magnitude;
    private static readonly LinearAlgebra.delegates.Vector_MagnitudeSquared<T> Vector_MagnitudeSquared;
    private static readonly LinearAlgebra.delegates.Vector_Angle<T> Vector_Angle;
    private static readonly LinearAlgebra.delegates.Vector_RotateBy<T> Vector_RotateBy;
    private static readonly LinearAlgebra.delegates.Vector_Lerp<T> Vector_Lerp;
    private static readonly LinearAlgebra.delegates.Vector_Slerp<T> Vector_Slerp;
    private static readonly LinearAlgebra.delegates.Vector_Blerp<T> Vector_Blerp;
    private static readonly LinearAlgebra.delegates.Vector_EqualsValue<T> Vector_EqualsValue;
    private static readonly LinearAlgebra.delegates.Vector_EqualsValue_leniency<T> Vector_EqualsValue_leniency;
    private static readonly LinearAlgebra.delegates.Vector_RotateBy_quaternion<T> Vector_RotateBy_quaternion;

    static Vector()
    {
      LinearAlgebra<T> linearAlgebra = LinearAlgebra.Get<T>();
      Vector_Add = linearAlgebra.Vector_Add;
      Vector_Negate = linearAlgebra.Vector_Negate;
      Vector_Subtract = linearAlgebra.Vector_Subtract;
      Vector_Multiply = linearAlgebra.Vector_Multiply;
      Vector_Divide = linearAlgebra.Vector_Divide;
      Vector_DotProduct = linearAlgebra.Vector_DotProduct;
      Vector_CrossProduct = linearAlgebra.Vector_CrossProduct;
      Vector_Normalize = linearAlgebra.Vector_Normalize;
      Vector_Magnitude = linearAlgebra.Vector_Magnitude;
      Vector_MagnitudeSquared = linearAlgebra.Vector_MagnitudeSquared;
      Vector_Angle = linearAlgebra.Vector_Angle;
      Vector_RotateBy = linearAlgebra.Vector_RotateBy;
      Vector_Lerp = linearAlgebra.Vector_Lerp;
      Vector_Slerp = linearAlgebra.Vector_Slerp;
      Vector_Blerp = linearAlgebra.Vector_Blerp;
      Vector_EqualsValue = linearAlgebra.Vector_EqualsValue;
      Vector_EqualsValue_leniency = linearAlgebra.Vector_EqualsValue_leniency;
      Vector_RotateBy_quaternion = linearAlgebra.Vector_RotateBy_quaternion;
    }

    #endregion

    #region properties

    /// <summary>Sane as accessing index 0.</summary>
		public T X
		{
			get { return _vector[0]; }
			set { _vector[0] = value; }
		}

		/// <summary>Same as accessing index 1.</summary>
		public T Y
		{
			get { try { return _vector[1]; } catch { throw new Error("vector does not contains a y component."); } }
			set { try { _vector[1] = value; } catch { throw new Error("vector does not contains a y component."); } }
		}

		/// <summary>Same as accessing index 2.</summary>
		public T Z
		{
			get { try { return _vector[2]; } catch { throw new Error("vector does not contains a z component."); } }
			set { try { _vector[2] = value; } catch { throw new Error("vector does not contains a z component."); } }
		}

		/// <summary>Same as accessing index 3.</summary>
		public T W
		{
			get { try { return _vector[3]; } catch { throw new Error("vector does not contains a w component."); } }
			set { try { _vector[3] = value; } catch { throw new Error("vector does not contains a w component."); } }
		}
		
		/// <summary>The number of components in this vector.</summary>
		public int Dimensions { get { return _vector.Length; } }

		/// <summary>Allows indexed access to this vector.</summary>
		/// <param name="index">The index to access.</param>
		/// <returns>The value of the given index.</returns>
		public T this[int index]
		{
			get { try { return _vector[index]; } catch { throw new Error("index out of bounds."); } }
			set { try { _vector[index] = value; } catch { throw new Error("index out of bounds."); } }
		}

    #endregion

    #region constructors

    /// <summary>Creates a new vector with the given number of components.</summary>
		/// <param name="dimensions">The number of dimensions this vector will have.</param>
		public Vector(int dimensions) { try { _vector = new T[dimensions]; } catch { throw new Error("invalid dimensions on vector contruction."); } }

		/// <summary>Creates a vector out of the given values.</summary>
		/// <param name="vector">The values to initialize the vector to.</param>
		public Vector(params T[] vector) { _vector = vector; }

    #endregion

    #region factories

    /// <summary>Creates a vector with the given number of components with the values initialized to zeroes.</summary>
		/// <param name="dimensions">The number of components in the vector.</param>
		/// <returns>The newly constructed vector.</returns>
		public static Vector<T> FactoryZero(int dimensions) { return new Vector<T>(dimensions); }

		/// <summary>Creates a vector with the given number of components with the values initialized to ones.</summary>
		/// <param name="dimensions">The number of components in the vector.</param>
		/// <returns>The newly constructed vector.</returns>
		public static Vector<T> FactoryOne(int dimensions) { return new Vector<T>(new T[dimensions]); }

    ///// <summary>Returns a 3-component vector representing the x-axis.</summary>
    //public static readonly Vector<T> Factory_XAxis = new Vector<T>(_one, _zero, _zero);
    ///// <summary>Returns a 3-component vector representing the y-axis.</summary>
    //public static readonly Vector<T> Factory_YAxis = new Vector<T>(_zero, _one, _zero);
    ///// <summary>Returns a 3-component vector representing the z-axis.</summary>
    //public static readonly Vector<T> Factory_ZAxis = new Vector<T>(_zero, _zero, _one);
    ///// <summary>Returns a 3-component vector representing the negative x-axis.</summary>
    //public static readonly Vector<T> Factory_NegXAxis = new Vector<T>(_one, _zero, _zero);
    ///// <summary>Returns a 3-component vector representing the negative y-axis.</summary>
    //public static readonly Vector<T> Factory_NegYAxis = new Vector<T>(_zero, _one, _zero);
    ///// <summary>Returns a 3-component vector representing the negative z-axis.</summary>
    //public static readonly Vector<T> Factory_NegZAxis = new Vector<T>(_zero, _zero, _one);

    #endregion

    #region operator

    /// <summary>Adds two vectors together.</summary>
		/// <param name="left">The first vector of the addition.</param>
		/// <param name="right">The second vector of the addition.</param>
		/// <returns>The result of the addition.</returns>
		public static Vector<T> operator +(Vector<T> left, Vector<T> right)
    { return Vector_Add(left, right); }
		/// <summary>Subtracts two vectors.</summary>
		/// <param name="left">The left operand of the subtraction.</param>
		/// <param name="right">The right operand of the subtraction.</param>
		/// <returns>The result of the subtraction.</returns>
		public static Vector<T> operator -(Vector<T> left, Vector<T> right)
    { return Vector_Subtract(left, right); }
		/// <summary>Negates a vector.</summary>
		/// <param name="vector">The vector to negate.</param>
		/// <returns>The result of the negation.</returns>
		public static Vector<T> operator -(Vector<T> vector)
    { return Vector_Negate(vector); }
		/// <summary>Multiplies all the values in a vector by a scalar.</summary>
		/// <param name="left">The vector to have all its values multiplied.</param>
		/// <param name="right">The scalar to multiply all the vector values by.</param>
		/// <returns>The result of the multiplication.</returns>
		public static Vector<T> operator *(Vector<T> left, T right)
    { return Vector_Multiply(left, right); }
		/// <summary>Multiplies all the values in a vector by a scalar.</summary>
		/// <param name="left">The scalar to multiply all the vector values by.</param>
		/// <param name="right">The vector to have all its values multiplied.</param>
		/// <returns>The result of the multiplication.</returns>
		public static Vector<T> operator *(T left, Vector<T> right)
    { return Vector_Multiply(right, left); }
		/// <summary>Divides all the values in the vector by a scalar.</summary>
		/// <param name="left">The vector to have its values divided.</param>
		/// <param name="right">The scalar to divide all the vectors values by.</param>
		/// <returns>The vector after the divisions.</returns>
		public static Vector<T> operator /(Vector<T> left, T right)
    { return Vector_Divide(left, right); }
		/// <summary>Does an equality check by value. (warning for float errors)</summary>
		/// <param name="left">The first vector of the equality check.</param>
		/// <param name="right">The second vector of the equality check.</param>
		/// <returns>true if the values are equal, false if not.</returns>
		public static bool operator ==(Vector<T> left, Vector<T> right)
    { return Vector_EqualsValue(left, right); }
		/// <summary>Does an anti-equality check by value. (warning for float errors)</summary>
		/// <param name="left">The first vector of the anit-equality check.</param>
		/// <param name="right">The second vector of the anti-equality check.</param>
		/// <returns>true if the values are not equal, false if they are.</returns>
		public static bool operator !=(Vector<T> left, Vector<T> right)
    { return !Vector_EqualsValue(left, right); }
		/// <summary>Implicit conversions from Vector to T[].</summary>
		/// <param name="vector">The Vector to be converted to a T[].</param>
		/// <returns>The T[] of the vector.</returns>
		public static implicit operator T[](Vector<T> vector)
    { return vector._vector; }
		/// <summary>Implicit conversions from Vector to T[].</summary>
		/// <param name="array">The Vector to be converted to a T[].</param>
		/// <returns>The T[] of the vector.</returns>
		public static implicit operator Vector<T>(T[] array)
    { return new Vector<T>(array); }
    /// <summary>Converts a vector into a matrix.</summary>
    /// <param name="vector">The vector to convert.</param>
    /// <returns>The resulting matrix.</returns>
    public static explicit operator Matrix<T>(Vector<T> vector)
    { return new Matrix<T>(vector); }

    #endregion

    #region instance

    /// <summary>Adds two vectors together.</summary>
		/// <param name="right">The vector to add to this one.</param>
		/// <returns>The result of the vector.</returns>
		public Vector<T> Add(Vector<T> right)
    { return Vector_Add(this, right); }
		/// <summary>Negates this vector.</summary>
		/// <returns>The result of the negation.</returns>
		public Vector<T> Negate()
    { return Vector_Negate(this); }
		/// <summary>Subtracts another vector from this one.</summary>
		/// <param name="right">The vector to subtract from this one.</param>
		/// <returns>The result of the subtraction.</returns>
		public Vector<T> Subtract(Vector<T> right)
    { return Vector_Subtract(this, right); }
		/// <summary>Multiplies the values in this vector by a scalar.</summary>
		/// <param name="right">The scalar to multiply these values by.</param>
		/// <returns>The result of the multiplications</returns>
		public Vector<T> Multiply(T right)
    { return Vector_Multiply(this, right); }
		/// <summary>Divides all the values in this vector by a scalar.</summary>
		/// <param name="right">The scalar to divide the values of the vector by.</param>
		/// <returns>The resulting vector after teh divisions.</returns>
		public Vector<T> Divide(T right)
    { return Vector_Divide(this, right); }
		/// <summary>Computes the dot product between this vector and another.</summary>
		/// <param name="right">The second vector of the dot product operation.</param>
		/// <returns>The result of the dot product.</returns>
		public T DotProduct(Vector<T> right)
    { return Vector_DotProduct(this, right); }
		/// <summary>Computes the cross product between this vector and another.</summary>
		/// <param name="right">The second vector of the dot product operation.</param>
		/// <returns>The result of the dot product operation.</returns>
		public Vector<T> CrossProduct(Vector<T> right)
    { return Vector_CrossProduct(this, right); }
		/// <summary>Normalizes this vector.</summary>
		/// <returns>The result of the normalization.</returns>
		public Vector<T> Normalize()
    { return Vector_Normalize(this); }
		/// <summary>Computes the length of this vector.</summary>
		/// <returns>The length of this vector.</returns>
		public T Magnitude()
    { return Vector_Magnitude(this); }
		/// <summary>Computes the length of this vector, but doesn't square root it for 
		/// possible optimization purposes.</summary>
		/// <returns>The squared length of the vector.</returns>
		public T MagnitudeSquared()
    { return Vector_MagnitudeSquared(this); }
		/// <summary>Check for equality by value.</summary>
		/// <param name="right">The other vector of the equality check.</param>
		/// <returns>true if the values were equal, false if not.</returns>
		public bool EqualsValue(Vector<T> right)
    { return Vector_EqualsValue(this, right); }
		/// <summary>Checks for equality by value with some leniency.</summary>
		/// <param name="right">The other vector of the equality check.</param>
		/// <param name="leniency">The ammount the values can differ but still be considered equal.</param>
		/// <returns>true if the values were cinsidered equal, false if not.</returns>
		public bool EqualsValue(Vector<T> right, T leniency)
    { return Vector_EqualsValue_leniency(this, right, leniency); }
		/// <summary>Checks for equality by reference.</summary>
		/// <param name="right">The other vector of the equality check.</param>
		/// <returns>true if the references are equal, false if not.</returns>
		public bool EqualsReference(Vector<T> right)
    { return Vector<T>.EqualsReference(this, right); }
		/// <summary>Rotates this vector by quaternon values.</summary>
		/// <param name="angle">The amount of rotation about the axis.</param>
		/// <param name="x">The x component deterniming the axis of rotation.</param>
		/// <param name="y">The y component determining the axis of rotation.</param>
		/// <param name="z">The z component determining the axis of rotation.</param>
		/// <returns>The resulting vector after the rotation.</returns>
		public Vector<T> RotateBy(T angle, T x, T y, T z)
    { return Vector_RotateBy(this, angle, x, y, z); }
		/// <summary>Computes the linear interpolation between two vectors.</summary>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
		/// <returns>The result of the interpolation.</returns>
		public Vector<T> Lerp(Vector<T> right, T blend)
    { return Vector_Lerp(this, right, blend); }
		/// <summary>Sphereically interpolates between two vectors.</summary>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
		/// <returns>The result of the slerp operation.</returns>
		public Vector<T> Slerp(Vector<T> right, T blend)
    { return Vector_Slerp(this, right, blend); }
		/// <summary>Rotates a vector by a quaternion.</summary>
		/// <param name="rotation">The quaternion to rotate the 3-component vector by.</param>
		/// <returns>The result of the rotation.</returns>
    public Vector<T> RotateBy(Quaternion<T> rotation)
    { return Vector_RotateBy_quaternion(this, rotation); }

    #endregion

    #region static

    /// <summary>Adds two vectors together.</summary>
		/// <param name="left">The first vector of the addition.</param>
		/// <param name="right">The second vector of the addiiton.</param>
		/// <returns>The result of the addiion.</returns>
		public static Vector<T> Add(T[] left, T[] right)
    { return Vector_Add(left, right); }
		/// <summary>Adds two vectors together.</summary>
		/// <param name="left">The first vector of the addition.</param>
		/// <param name="right">The second vector of the addiiton.</param>
		/// <returns>The result of the addiion.</returns>
		public static Vector<T> Add(Vector<T> left, Vector<T> right)
    { return Vector_Add(left._vector, right._vector); }
		/// <summary>Negates all the values in a vector.</summary>
		/// <param name="vector">The vector to have its values negated.</param>
		/// <returns>The result of the negations.</returns>
		public static T[] Negate(T[] vector)
    { return Vector_Negate(vector); }
		/// <summary>Negates all the values in a vector.</summary>
		/// <param name="vector">The vector to have its values negated.</param>
		/// <returns>The result of the negations.</returns>
		public static Vector<T> Negate(Vector<T> vector)
    { return Vector_Negate(vector); }
		/// <summary>Subtracts two vectors.</summary>
		/// <param name="left">The left vector of the subtraction.</param>
		/// <param name="right">The right vector of the subtraction.</param>
		/// <returns>The result of the vector subtracton.</returns>
		public static T[] Subtract(T[] left, T[] right)
    { return Vector_Subtract(left, right); }
		/// <summary>Subtracts two vectors.</summary>
		/// <param name="left">The left vector of the subtraction.</param>
		/// <param name="right">The right vector of the subtraction.</param>
		/// <returns>The result of the vector subtracton.</returns>
		public static Vector<T> Subtract(Vector<T> left, Vector<T> right)
    { return Vector_Subtract(left._vector, right._vector); }
		/// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
		/// <param name="left">The vector to have the components multiplied by.</param>
		/// <param name="right">The scalars to multiply the vector components by.</param>
		/// <returns>The result of the multiplications.</returns>
		public static T[] Multiply(T[] left, T right)
    { return Vector_Multiply(left, right); }
		/// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
		/// <param name="left">The vector to have the components multiplied by.</param>
		/// <param name="right">The scalars to multiply the vector components by.</param>
		/// <returns>The result of the multiplications.</returns>
		public static Vector<T> Multiply(Vector<T> left, T right)
    { return Vector_Multiply(left._vector, right); }
		/// <summary>Divides all the components of a vector by a scalar.</summary>
		/// <param name="left">The vector to have the components divided by.</param>
		/// <param name="right">The scalar to divide the vector components by.</param>
		/// <returns>The resulting vector after teh divisions.</returns>
		public static T[] Divide(T[] left, T right)
    { return Vector_Divide(left, right); }
		/// <summary>Divides all the components of a vector by a scalar.</summary>
		/// <param name="left">The vector to have the components divided by.</param>
		/// <param name="right">The scalar to divide the vector components by.</param>
		/// <returns>The resulting vector after teh divisions.</returns>
		public static Vector<T> Divide(Vector<T> left, T right)
    { return Vector_Divide(left, right); }
		/// <summary>Computes the dot product between two vectors.</summary>
		/// <param name="left">The first vector of the dot product operation.</param>
		/// <param name="right">The second vector of the dot product operation.</param>
		/// <returns>The result of the dot product operation.</returns>
		public static T DotProduct(T[] left, T[] right)
    { return Vector_DotProduct(left, right); }
		/// <summary>Computes the dot product between two vectors.</summary>
		/// <param name="left">The first vector of the dot product operation.</param>
		/// <param name="right">The second vector of the dot product operation.</param>
		/// <returns>The result of the dot product operation.</returns>
		public static T DotProduct(Vector<T> left, Vector<T> right)
    { return Vector_DotProduct(left._vector, right._vector); }
		/// <summary>Computes teh cross product of two vectors.</summary>
		/// <param name="left">The first vector of the cross product operation.</param>
		/// <param name="right">The second vector of the cross product operation.</param>
		/// <returns>The result of the cross product operation.</returns>
		public static T[] CrossProduct(T[] left, T[] right)
    { return Vector_CrossProduct(left, right); }
		/// <summary>Computes teh cross product of two vectors.</summary>
		/// <param name="left">The first vector of the cross product operation.</param>
		/// <param name="right">The second vector of the cross product operation.</param>
		/// <returns>The result of the cross product operation.</returns>
		public static Vector<T> CrossProduct(Vector<T> left, Vector<T> right)
    { return Vector_CrossProduct(left, right); }
		/// <summary>Normalizes a vector.</summary>
		/// <param name="vector">The vector to normalize.</param>
		/// <returns>The result of the normalization.</returns>
		public static T[] Normalize(T[] vector)
    { return Vector_Normalize(vector); }
		/// <summary>Normalizes a vector.</summary>
		/// <param name="vector">The vector to normalize.</param>
		/// <returns>The result of the normalization.</returns>
		public static Vector<T> Normalize(Vector<T> vector)
    { return Vector_Normalize(vector._vector); }
		/// <summary>Computes the length of a vector.</summary>
		/// <param name="vector">The vector to calculate the length of.</param>
		/// <returns>The computed length of the vector.</returns>
		public static T Magnitude(T[] vector)
    { return Vector_Magnitude(vector); }
		/// <summary>Computes the length of a vector.</summary>
		/// <param name="vector">The vector to calculate the length of.</param>
		/// <returns>The computed length of the vector.</returns>
		public static T Magnitude(Vector<T> vector)
    { return Vector_Magnitude(vector); }
		/// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
		/// <param name="vector">The vector to compute the length squared of.</param>
		/// <returns>The computed length squared of the vector.</returns>
    public static T MagnitudeSquared(T[] vector)
    { return Vector_MagnitudeSquared(vector); }
		/// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
		/// <param name="vector">The vector to compute the length squared of.</param>
		/// <returns>The computed length squared of the vector.</returns>
    public static T MagnitudeSquared(Vector<T> vector)
    { return Vector_MagnitudeSquared(vector._vector); }
		/// <summary>Computes the angle between two vectors.</summary>
		/// <param name="first">The first vector to determine the angle between.</param>
		/// <param name="second">The second vector to determine the angle between.</param>
		/// <returns>The angle between the two vectors in radians.</returns>
		public static T Angle(T[] first, T[] second)
    { return Vector_Angle(first, second); }
		/// <summary>Computes the angle between two vectors.</summary>
		/// <param name="first">The first vector to determine the angle between.</param>
		/// <param name="second">The second vector to determine the angle between.</param>
		/// <returns>The angle between the two vectors in radians.</returns>
		public static T Angle(Vector<T> first, Vector<T> second)
    { return Vector_Angle(first._vector, second._vector); }
		/// <summary>Rotates a vector by the specified axis and rotation values.</summary>
		/// <param name="vector">The vector to rotate.</param>
		/// <param name="angle">The angle of the rotation.</param>
		/// <param name="x">The x component of the axis vector to rotate about.</param>
		/// <param name="y">The y component of the axis vector to rotate about.</param>
		/// <param name="z">The z component of the axis vector to rotate about.</param>
		/// <returns>The result of the rotation.</returns>
		public static T[] RotateBy(T[] vector, T angle, T x, T y, T z)
    { return Vector_RotateBy(vector, angle, x, y, z); }
		/// <summary>Rotates a vector by the specified axis and rotation values.</summary>
		/// <param name="vector">The vector to rotate.</param>
		/// <param name="angle">The angle of the rotation.</param>
		/// <param name="x">The x component of the axis vector to rotate about.</param>
		/// <param name="y">The y component of the axis vector to rotate about.</param>
		/// <param name="z">The z component of the axis vector to rotate about.</param>
		/// <returns>The result of the rotation.</returns>
		public static Vector<T> RotateBy(Vector<T> vector, T angle, T x, T y, T z)
    { return Vector_RotateBy(vector._vector, angle, x, y, z); }
		/// <summary>Rotates a vector by a quaternion.</summary>
		/// <param name="vector">The vector to rotate.</param>
		/// <param name="rotation">The quaternion to rotate the 3-component vector by.</param>
		/// <returns>The result of the rotation.</returns>
		public static Vector<T> RotateBy(Vector<T> vector, Quaternion<T> rotation)
    { return Vector_RotateBy_quaternion(vector._vector, rotation); }
		/// <summary>Computes the linear interpolation between two vectors.</summary>
		/// <param name="left">The starting vector of the interpolation.</param>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
		/// <returns>The result of the interpolation.</returns>
		public static T[] Lerp(T[] left, T[] right, T blend)
    { return Vector_Lerp(left, right, blend); }
		/// <summary>Computes the linear interpolation between two vectors.</summary>
		/// <param name="left">The starting vector of the interpolation.</param>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
		/// <returns>The result of the interpolation.</returns>
		public static Vector<T> Lerp(Vector<T> left, Vector<T> right, T blend)
    { return Vector_Lerp(left._vector, right._vector, blend); }
		/// <summary>Sphereically interpolates between two vectors.</summary>
		/// <param name="left">The starting vector of the interpolation.</param>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
		/// <returns>The result of the slerp operation.</returns>
		public static T[] Slerp(T[] left, T[] right, T blend)
    { return Vector_Slerp(left, right, blend); }
		/// <summary>Sphereically interpolates between two vectors.</summary>
		/// <param name="left">The starting vector of the interpolation.</param>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
		/// <returns>The result of the slerp operation.</returns>
		public static Vector<T> Slerp(Vector<T> left, Vector<T> right, T blend)
    { return Vector_Slerp(left._vector, right._vector, blend); }
		/// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
		/// <param name="a">The first vector of the interpolation.</param>
		/// <param name="b">The second vector of the interpolation.</param>
		/// <param name="c">The thrid vector of the interpolation.</param>
		/// <param name="u">The "U" value of the barycentric interpolation equation.</param>
		/// <param name="v">The "V" value of the barycentric interpolation equation.</param>
		/// <returns>The resulting vector of the barycentric interpolation.</returns>
		public static T[] Blerp(T[] a, T[] b, T[] c, T u, T v)
    { return Vector_Blerp(a, b, c, u, v); }
		/// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
		/// <param name="a">The first vector of the interpolation.</param>
		/// <param name="b">The second vector of the interpolation.</param>
		/// <param name="c">The thrid vector of the interpolation.</param>
		/// <param name="u">The "U" value of the barycentric interpolation equation.</param>
		/// <param name="v">The "V" value of the barycentric interpolation equation.</param>
		/// <returns>The resulting vector of the barycentric interpolation.</returns>
		public static Vector<T> Blerp(Vector<T> a, Vector<T> b, Vector<T> c, T u, T v)
    { return Vector_Blerp(a._vector, b._vector, c._vector, u, v); }
		/// <summary>Does a value equality check.</summary>
		/// <param name="left">The first vector to check for equality.</param>
		/// <param name="right">The second vector  to check for equality.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(T[] left, T[] right)
    { return Vector_EqualsValue(left, right); }
		/// <summary>Does a value equality check.</summary>
		/// <param name="left">The first vector to check for equality.</param>
		/// <param name="right">The second vector  to check for equality.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(Vector<T> left, Vector<T> right)
    { return Vector_EqualsValue(left._vector, right._vector); }
		/// <summary>Does a value equality check with leniency.</summary>
		/// <param name="left">The first vector to check for equality.</param>
		/// <param name="right">The second vector to check for equality.</param>
		/// <param name="leniency">How much the values can vary but still be considered equal.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(T[] left, T[] right, T leniency)
    { return Vector_EqualsValue_leniency(left, right, leniency); }
		/// <summary>Does a value equality check with leniency.</summary>
		/// <param name="left">The first vector to check for equality.</param>
		/// <param name="right">The second vector to check for equality.</param>
		/// <param name="leniency">How much the values can vary but still be considered equal.</param>
		/// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Vector<T> left, Vector<T> right, T leniency)
    { return Vector_EqualsValue_leniency(left._vector, right._vector, leniency); }
    /// <summary>Checks if two matrices are equal by reverences.</summary>
		/// <param name="left">The left vector of the equality check.</param>
		/// <param name="right">The right vector of the equality check.</param>
		/// <returns>True if the references are equal, false if not.</returns>
		public static bool EqualsReference(T[] left, T[] right)
    { return object.ReferenceEquals(left, right); }
		/// <summary>Checks if two matrices are equal by reverences.</summary>
		/// <param name="left">The left vector of the equality check.</param>
		/// <param name="right">The right vector of the equality check.</param>
		/// <returns>True if the references are equal, false if not.</returns>
		public static bool EqualsReference(Vector<T> left, Vector<T> right)
		{ return EqualsReference(left._vector, right._vector); }

    #endregion

    #region override

    /// <summary>Prints out a string representation of this matrix.</summary>
		/// <returns>A string representing this matrix.</returns>
		public override string ToString()
		{ return base.ToString(); }
		/// <summary>Computes a hash code from the values of this matrix.</summary>
		/// <returns>A hash code for the matrix.</returns>
		public override int GetHashCode()
    { return this._vector.GetHashCode(); }
		/// <summary>Does an equality check by reference.</summary>
		/// <param name="right">The object to compare to.</param>
		/// <returns>True if the references are equal, false if not.</returns>
		public override bool Equals(object right)
		{
			if (!(right is Vector<T>)) return false;
			return Vector<T>.EqualsReference(this, (Vector<T>)right);
    }

    #endregion
  }

  /// <summary>Standard 4-component quaternion [x, y, z, w]. W is the rotation ammount.</summary>
	/// <typeparam name="T">The numeric type of this Quaternion.</typeparam>
	public class Quaternion<T>
  {
    // the values of the quaternion
    protected T _x, _y, _z, _w;

    #region runtime function mapping

    private static LinearAlgebra.delegates.Quaternion_Magnitude<T> Quaternion_Magnitude;
    private static LinearAlgebra.delegates.Quaternion_MagnitudeSquared<T> Quaternion_MagnitudeSquared;
    private static LinearAlgebra.delegates.Quaternion_Conjugate<T> Quaternion_Conjugate;
    private static LinearAlgebra.delegates.Quaternion_Add<T> Quaternion_Add;
    private static LinearAlgebra.delegates.Quaternion_Subtract<T> Quaternion_Subtract;
    private static LinearAlgebra.delegates.Quaternion_Multiply<T> Quaternion_Multiply;
    private static LinearAlgebra.delegates.Quaternion_Multiply_scalar<T> Quaternion_Multiply_scalar;
    private static LinearAlgebra.delegates.Quaternion_Multiply_Vector<T> Quaternion_Multiply_Vector;
    private static LinearAlgebra.delegates.Quaternion_Normalize<T> Quaternion_Normalize;
    private static LinearAlgebra.delegates.Quaternion_Invert<T> Quaternion_Invert;
    private static LinearAlgebra.delegates.Quaternion_Lerp<T> Quaternion_Lerp;
    private static LinearAlgebra.delegates.Quaternion_Slerp<T> Quaternion_Slerp;
    private static LinearAlgebra.delegates.Quaternion_Rotate<T> Quaternion_Rotate;
    private static LinearAlgebra.delegates.Quaternion_EqualsValue<T> Quaternion_EqualsValue;
    private static LinearAlgebra.delegates.Quaternion_EqualsValue_leniency<T> Quaternion_EqualsValue_leniency;

    // Constants
    private static T _zero;
    private static T _one;
    private static T _two;

    static Quaternion()
    {
      // Constants (this needs to be changed!!!)
		  _zero = Constants.Get<T>().factory(0);
		  _one = Constants.Get<T>().factory(1);
		  _two = Constants.Get<T>().factory(2);

      LinearAlgebra<T> linearAlgebra = LinearAlgebra.Get<T>();
      Quaternion_Magnitude = linearAlgebra.Quaternion_Magnitude;
      Quaternion_MagnitudeSquared = linearAlgebra.Quaternion_MagnitudeSquared;
      Quaternion_Conjugate = linearAlgebra.Quaternion_Conjugate;
      Quaternion_Add = linearAlgebra.Quaternion_Add;
      Quaternion_Subtract = linearAlgebra.Quaternion_Subtract;
      Quaternion_Multiply = linearAlgebra.Quaternion_Multiply;
      Quaternion_Multiply_scalar = linearAlgebra.Quaternion_Multiply_scalar;
      Quaternion_Multiply_Vector = linearAlgebra.Quaternion_Multiply_Vector;
      Quaternion_Normalize = linearAlgebra.Quaternion_Normalize;
      Quaternion_Invert = linearAlgebra.Quaternion_Invert;
      Quaternion_Lerp = linearAlgebra.Quaternion_Lerp;
      Quaternion_Slerp = linearAlgebra.Quaternion_Slerp;
      Quaternion_Rotate = linearAlgebra.Quaternion_Rotate;
      Quaternion_EqualsValue = linearAlgebra.Quaternion_EqualsValue;
      Quaternion_EqualsValue_leniency = linearAlgebra.Quaternion_EqualsValue_leniency;
    }

    #endregion

    #region property

		/// <summary>The X component of the quaternion. (axis, NOT rotation ammount)</summary>
		public T X { get { return _x; } set { _x = value; } }
		/// <summary>The Y component of the quaternion. (axis, NOT rotation ammount)</summary>
		public T Y { get { return _y; } set { _y = value; } }
		/// <summary>The Z component of the quaternion. (axis, NOT rotation ammount)</summary>
		public T Z { get { return _z; } set { _z = value; } }
		/// <summary>The W component of the quaternion. (rotation ammount, NOT axis)</summary>
		public T W { get { return _w; } set { _w = value; } }

    #endregion

    #region constructor

    /// <summary>Constructs a quaternion with the desired values.</summary>
		/// <param name="x">The x component of the quaternion.</param>
		/// <param name="y">The y component of the quaternion.</param>
		/// <param name="z">The z component of the quaternion.</param>
		/// <param name="w">The w component of the quaternion.</param>
		public Quaternion(T x, T y, T z, T w) { _x = x; _y = y; _z = z; _w = w; }

    #endregion

    #region factories

    /// <summary>Returns new Quaternion(0, 0, 0, 1).</summary>
		public static readonly Quaternion<T> FactoryIdentity = new Quaternion<T>(_zero, _zero, _zero, _one);

		///// <summary>Creates a quaternion from an axis and rotation.</summary>
		///// <param name="axis">The to create the quaternion from.</param>
		///// <param name="angle">The angle to create teh quaternion from.</param>
		///// <returns>The newly created quaternion.</returns>
		//public static Quaternion<T> FactoryFromAxisAngle(Vector axis, T angle)
		//{
		//	throw new System.NotImplementedException();
		//	//if (axis.LengthSquared() == 0.0f)
		//	//	return FactoryIdentity;
		//	//T sinAngleOverAxisLength = Calc.Sin(angle / 2) / axis.Length();
		//	//return Quaternion<T>.Normalize(new Quaternion<T>(
		//	//	_multiply(axis.X, sinAngleOverAxisLength),
		//	//	axis.Y * sinAngleOverAxisLength,
		//	//	axis.Z * sinAngleOverAxisLength,
		//	//	Calc.Cos(angle / 2)));
    //}

    #endregion

    #region operator

    /// <summary>Adds two quaternions together.</summary>
		/// <param name="left">The first quaternion of the addition.</param>
		/// <param name="right">The second quaternion of the addition.</param>
		/// <returns>The result of the addition.</returns>
		public static Quaternion<T> operator +(Quaternion<T> left, Quaternion<T> right)
    { return Quaternion_Add(left, right); }
		/// <summary>Subtracts two quaternions.</summary>
		/// <param name="left">The left quaternion of the subtraction.</param>
		/// <param name="right">The right quaternion of the subtraction.</param>
		/// <returns>The resulting quaternion after the subtraction.</returns>
		public static Quaternion<T> operator -(Quaternion<T> left, Quaternion<T> right)
    { return Quaternion_Subtract(left, right); }
		/// <summary>Multiplies two quaternions together.</summary>
		/// <param name="left">The first quaternion of the multiplication.</param>
		/// <param name="right">The second quaternion of the multiplication.</param>
		/// <returns>The resulting quaternion after the multiplication.</returns>
		public static Quaternion<T> operator *(Quaternion<T> left, Quaternion<T> right)
    { return Quaternion_Multiply(left, right); }
		/// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
		/// <param name="left">The quaternion to pre-multiply the vector by.</param>
		/// <param name="vector">The vector to be multiplied.</param>
		/// <returns>The resulting quaternion of the multiplication.</returns>
		//public static Quaternion<T> operator *(Quaternion<T> left, Vector right)
    //{ return Quaternion<T>.Multiply(left, right); }
		/// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
		/// <param name="left">The quaternion of the multiplication.</param>
		/// <param name="right">The scalar of the multiplication.</param>
		/// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
		public static Quaternion<T> operator *(Quaternion<T> left, T right)
    { return Quaternion_Multiply_scalar(left, right); }
		/// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
		/// <param name="left">The scalar of the multiplication.</param>
		/// <param name="right">The quaternion of the multiplication.</param>
		/// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
		public static Quaternion<T> operator *(T left, Quaternion<T> right)
    { return Quaternion_Multiply_scalar(right, left); }
		/// <summary>Checks for equality by value. (beware float errors)</summary>
		/// <param name="left">The first quaternion of the equality check.</param>
		/// <param name="right">The second quaternion of the equality check.</param>
		/// <returns>true if the values were deemed equal, false if not.</returns>
		public static bool operator ==(Quaternion<T> left, Quaternion<T> right)
    { return Quaternion_EqualsValue(left, right); }
		/// <summary>Checks for anti-equality by value. (beware float errors)</summary>
		/// <param name="left">The first quaternion of the anti-equality check.</param>
		/// <param name="right">The second quaternion of the anti-equality check.</param>
		/// <returns>false if the values were deemed equal, true if not.</returns>
		public static bool operator !=(Quaternion<T> left, Quaternion<T> right)
    { return !Quaternion_EqualsValue(left, right); }

    #endregion

    #region instance

    /// <summary>Computes the length of quaternion.</summary>
		/// <returns>The length of the given quaternion.</returns>
		public T Magnitude() 
    { return Quaternion_Magnitude(this); }
		/// <summary>Computes the length of a quaternion, but doesn't square root it
		/// for optimization possibilities.</summary>
		/// <returns>The squared length of the given quaternion.</returns>
		public T MagnitudeSquared() 
    { return Quaternion_MagnitudeSquared(this); }
		/// <summary>Gets the conjugate of the quaternion.</summary>
		/// <returns>The conjugate of teh given quaternion.</returns>
		public Quaternion<T> Conjugate() 
    { return Quaternion_Conjugate(this); }
		/// <summary>Adds two quaternions together.</summary>
		/// <param name="right">The second quaternion of the addition.</param>
		/// <returns>The result of the addition.</returns>
		public Quaternion<T> Add(Quaternion<T> right) 
    { return Quaternion_Add(this, right); }
		/// <summary>Subtracts two quaternions.</summary>
		/// <param name="right">The right quaternion of the subtraction.</param>
		/// <returns>The resulting quaternion after the subtraction.</returns>
		public Quaternion<T> Subtract(Quaternion<T> right) 
    { return Quaternion_Subtract(this, right); }
		/// <summary>Multiplies two quaternions together.</summary>
		/// <param name="right">The second quaternion of the multiplication.</param>
		/// <returns>The resulting quaternion after the multiplication.</returns>
		public Quaternion<T> Multiply(Quaternion<T> right) 
    { return Quaternion_Multiply(this, right); }
		/// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
		/// <param name="right">The scalar of the multiplication.</param>
		/// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
		public Quaternion<T> Multiply(T right) 
    { return Quaternion_Multiply_scalar(this, right); }
		/// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
		/// <param name="right">The vector to be multiplied.</param>
		/// <returns>The resulting quaternion of the multiplication.</returns>
		//public Quaternion<T> Multiply(Vector vector) { return Quaternion<T>.Multiply(this, vector); }
		/// <summary>Normalizes the quaternion.</summary>
		/// <returns>The normalization of the given quaternion.</returns>
		public Quaternion<T> Normalize() 
    { return Quaternion_Normalize(this); }
		/// <summary>Inverts a quaternion.</summary>
		/// <returns>The inverse of the given quaternion.</returns>
		public Quaternion<T> Invert() 
    { return Quaternion_Invert(this); }
		/// <summary>Lenearly interpolates between two quaternions.</summary>
		/// <param name="right">The ending point of the interpolation.</param>
		/// <param name="blend">The ratio 0.0-1.0 of how far to interpolate between the left and right quaternions.</param>
		/// <returns>The result of the interpolation.</returns>
		public Quaternion<T> Lerp(Quaternion<T> right, T blend) 
    { return Quaternion<T>.Lerp(this, right, blend); }
		/// <summary>Sphereically interpolates between two quaternions.</summary>
		/// <param name="right">The ending point of the interpolation.</param>
		/// <param name="blend">The ratio of how far to interpolate between the left and right quaternions.</param>
		/// <returns>The result of the interpolation.</returns>
		public Quaternion<T> Slerp(Quaternion<T> right, T blend) 
    { return Quaternion<T>.Slerp(this, right, blend); }
		/// <summary>Rotates a vector by a quaternion.</summary>
		/// <param name="vector">The vector to be rotated by.</param>
		/// <returns>The result of the rotation.</returns>
		//public Vector Rotate(Vector vector) { return Quaternion<T>.Rotate(this, vector); }
		/// <summary>Does a value equality check.</summary>
		/// <param name="right">The second quaternion  to check for equality.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public bool EqualsValue(Quaternion<T> right) 
    { return Quaternion_EqualsValue(this, right); }
		/// <summary>Does a value equality check with leniency.</summary>
		/// <param name="right">The second quaternion to check for equality.</param>
		/// <param name="leniency">How much the values can vary but still be considered equal.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public bool EqualsValue(Quaternion<T> right, T leniency) 
    { return Quaternion_EqualsValue_leniency(this, right, leniency); }
		/// <summary>Checks if two matrices are equal by reverences.</summary>
		/// <param name="right">The right quaternion of the equality check.</param>
		/// <returns>True if the references are equal, false if not.</returns>
		public bool EqualsReference(Quaternion<T> right) 
    { return Quaternion<T>.EqualsReference(this, right); }

    #endregion

    #region statics

    /// <summary>Computes the length of quaternion.</summary>
		/// <param name="quaternion">The quaternion to compute the length of.</param>
		/// <returns>The length of the given quaternion.</returns>
		public static T Magnitude(Quaternion<T> quaternion)
    { return Quaternion_Magnitude(quaternion); }
		/// <summary>Computes the length of a quaternion, but doesn't square root it
		/// for optimization possibilities.</summary>
		/// <param name="quaternion">The quaternion to compute the length squared of.</param>
		/// <returns>The squared length of the given quaternion.</returns>
		public static T MagnitudeSquared(Quaternion<T> quaternion)
		{ return Quaternion_MagnitudeSquared(quaternion); }
		/// <summary>Gets the conjugate of the quaternion.</summary>
		/// <param name="quaternion">The quaternion to conjugate.</param>
		/// <returns>The conjugate of teh given quaternion.</returns>
		public static Quaternion<T> Conjugate(Quaternion<T> quaternion)
		{ return Quaternion_Conjugate(quaternion); }
		/// <summary>Adds two quaternions together.</summary>
		/// <param name="left">The first quaternion of the addition.</param>
		/// <param name="right">The second quaternion of the addition.</param>
		/// <returns>The result of the addition.</returns>
		public static Quaternion<T> Add(Quaternion<T> left, Quaternion<T> right)
		{ return Quaternion_Add(left, right); }
		/// <summary>Subtracts two quaternions.</summary>
		/// <param name="left">The left quaternion of the subtraction.</param>
		/// <param name="right">The right quaternion of the subtraction.</param>
		/// <returns>The resulting quaternion after the subtraction.</returns>
		public static Quaternion<T> Subtract(Quaternion<T> left, Quaternion<T> right)
		{ return Quaternion_Subtract(left, right); }
		/// <summary>Multiplies two quaternions together.</summary>
		/// <param name="left">The first quaternion of the multiplication.</param>
		/// <param name="right">The second quaternion of the multiplication.</param>
		/// <returns>The resulting quaternion after the multiplication.</returns>
		public static Quaternion<T> Multiply(Quaternion<T> left, Quaternion<T> right)
		{ return Quaternion_Multiply(left, right); }
		/// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
		/// <param name="left">The quaternion of the multiplication.</param>
		/// <param name="right">The scalar of the multiplication.</param>
		/// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
		public static Quaternion<T> Multiply(Quaternion<T> left, T right)
    { return Quaternion_Multiply_scalar(left, right); }
    /// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
    /// <param name="left">The quaternion to pre-multiply the vector by.</param>
    /// <param name="right">The vector to be multiplied.</param>
    /// <returns>The resulting quaternion of the multiplication.</returns>
    public static Quaternion<T> Multiply(Quaternion<T> left, Vector<T> right)
    { return Quaternion_Multiply_Vector(left, right); }
		/// <summary>Normalizes the quaternion.</summary>
		/// <param name="quaternion">The quaternion to normalize.</param>
		/// <returns>The normalization of the given quaternion.</returns>
		public static Quaternion<T> Normalize(Quaternion<T> quaternion)
    { return Quaternion_Normalize(quaternion); }
		/// <summary>Inverts a quaternion.</summary>
		/// <param name="quaternion">The quaternion to find the inverse of.</param>
		/// <returns>The inverse of the given quaternion.</returns>
		public static Quaternion<T> Invert(Quaternion<T> quaternion)
    { return Quaternion_Invert(quaternion); }
		/// <summary>Lenearly interpolates between two quaternions.</summary>
		/// <param name="left">The starting point of the interpolation.</param>
		/// <param name="right">The ending point of the interpolation.</param>
		/// <param name="blend">The ratio 0.0-1.0 of how far to interpolate between the left and right quaternions.</param>
		/// <returns>The result of the interpolation.</returns>
		public static Quaternion<T> Lerp(Quaternion<T> left, Quaternion<T> right, T blend)
    { return Quaternion_Lerp(left, right, blend); }
		/// <summary>Sphereically interpolates between two quaternions.</summary>
		/// <param name="left">The starting point of the interpolation.</param>
		/// <param name="right">The ending point of the interpolation.</param>
		/// <param name="blend">The ratio of how far to interpolate between the left and right quaternions.</param>
		/// <returns>The result of the interpolation.</returns>
		public static Quaternion<T> Slerp(Quaternion<T> left, Quaternion<T> right, T blend)
    { return Quaternion_Slerp(left, right, blend); }
    /// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
    /// <param name="rotation">The quaternion to rotate the vector by.</param>
    /// <param name="vector">The vector to be rotated by.</param>
    /// <returns>The result of the rotation.</returns>
    public static Vector<T> Rotate(Quaternion<T> rotation, Vector<T> vector)
    { return Quaternion_Rotate(rotation, vector); }
		/// <summary>Does a value equality check.</summary>
		/// <param name="left">The first quaternion to check for equality.</param>
		/// <param name="right">The second quaternion  to check for equality.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(Quaternion<T> left, Quaternion<T> right)
    { return Quaternion_EqualsValue(left, right); }
		/// <summary>Does a value equality check with leniency.</summary>
		/// <param name="left">The first quaternion to check for equality.</param>
		/// <param name="right">The second quaternion to check for equality.</param>
		/// <param name="leniency">How much the values can vary but still be considered equal.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(Quaternion<T> left, Quaternion<T> right, T leniency)
    { return Quaternion_EqualsValue_leniency(left, right, leniency); }
		/// <summary>Checks if two matrices are equal by reverences.</summary>
		/// <param name="left">The left quaternion of the equality check.</param>
		/// <param name="right">The right quaternion of the equality check.</param>
		/// <returns>True if the references are equal, false if not.</returns>
		public static bool EqualsReference(Quaternion<T> left, Quaternion<T> right)
		{ return object.ReferenceEquals(left, right); }

		///// <summary>Converts a quaternion into a matrix.</summary>
		///// <param name="quaternion">The quaternion of the conversion.</param>
		///// <returns>The resulting matrix.</returns>
		//public static Matrix_Flattened ToMatrix(Quaternion<T> quaternion)
		//{
		//	throw new NotImplementedException();
		//	//return new Matrix_Flattened(3, 3,
		//	//	quaternion.W * quaternion.W + quaternion.X * quaternion.X - quaternion.Y * quaternion.Y - quaternion.Z * quaternion.Z,
		//	//	2 * quaternion.X * quaternion.Y - 2 * quaternion.W * quaternion.Z,
		//	//	2 * quaternion.X * quaternion.Z + 2 * quaternion.W * quaternion.Y,
		//	//	2 * quaternion.X * quaternion.Y + 2 * quaternion.W * quaternion.Z,
		//	//	quaternion.W * quaternion.W - quaternion.X * quaternion.X + quaternion.Y * quaternion.Y - quaternion.Z * quaternion.Z,
		//	//	2 * quaternion.Y * quaternion.Z + 2 * quaternion.W * quaternion.X,
		//	//	2 * quaternion.X * quaternion.Z - 2 * quaternion.W * quaternion.Y,
		//	//	2 * quaternion.Y * quaternion.Z - 2 * quaternion.W * quaternion.X,
		//	//	quaternion.W * quaternion.W - quaternion.X * quaternion.X - quaternion.Y * quaternion.Y + quaternion.Z * quaternion.Z);
    //}

    #endregion

    #region overrides

    /// <summary>Converts the quaternion into a string.</summary>
		/// <returns>The resulting string after the conversion.</returns>
		public override string ToString()
		{
			// Chane this method to format it how you want...
			return base.ToString();
			//return "{ " + _x + ", " + _y + ", " + _z + ", " + _w + " }";
		}

		/// <summary>Computes a hash code from the values in this quaternion.</summary>
		/// <returns>The computed hash code.</returns>
		public override int GetHashCode()
		{
			return
				_x.GetHashCode() ^
				_y.GetHashCode() ^
				_z.GetHashCode() ^
				_w.GetHashCode();
		}

		/// <summary>Does a reference equality check.</summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public override bool Equals(object other)
		{
			if (other is Quaternion<T>)
				return Quaternion<T>.EqualsReference(this, (Quaternion<T>)other);
			return false;
		}

    #endregion
	}

  /// <summary>A matrix wrapper for T[,] to perform matrix theory in row major order. Enjoy :)</summary>
  /// <typeparam name="T">The numeric type of this Matrix.</typeparam>
  public class Matrix<T>
  {
    /// <summary>The flattened array of this matrix.</summary>
    public readonly T[] _matrix;
    private int _rows;
    private int _columns;

    #region runtime function mapping

    private static T _zero = Constants.Get<T>().factory(0);
    private static T _one = Constants.Get<T>().factory(1);
    private static T _two = Constants.Get<T>().factory(2);

    private static readonly LinearAlgebra.delegates.Matrix_Negate<T> Matrix_Negate;
    private static readonly LinearAlgebra.delegates.Matrix_Add<T> Matrix_Add;
    private static readonly LinearAlgebra.delegates.Matrix_Subtract<T> Matrix_Subtract;
    private static readonly LinearAlgebra.delegates.Matrix_Multiply<T> Matrix_Multiply;
    private static readonly LinearAlgebra.delegates.Matrix_Multiply_scalar<T> Matrix_Multiply_scalar;
    private static readonly LinearAlgebra.delegates.Matrix_Multiply_vector<T> Matrix_Multiply_vector;
    private static readonly LinearAlgebra.delegates.Matrix_Divide<T> Matrix_Divide;
    private static readonly LinearAlgebra.delegates.Matrix_Power<T> Matrix_Power;
    private static readonly LinearAlgebra.delegates.Matrix_Minor<T> Matrix_Minor;
    private static readonly LinearAlgebra.delegates.Matrix_ConcatenateRowWise<T> Matrix_ConcatenateRowWise;
    private static readonly LinearAlgebra.delegates.Matrix_Determinent<T> Matrix_Determinent;
    private static readonly LinearAlgebra.delegates.Matrix_Echelon<T> Matrix_Echelon;
    private static readonly LinearAlgebra.delegates.Matrix_ReducedEchelon<T> Matrix_ReducedEchelon;
    private static readonly LinearAlgebra.delegates.Matrix_Inverse<T> Matrix_Inverse;
    private static readonly LinearAlgebra.delegates.Matrix_Adjoint<T> Matrix_Adjoint;
    private static readonly LinearAlgebra.delegates.Matrix_Transpose<T> Matrix_Transpose;
    private static readonly LinearAlgebra.delegates.Matrix_DecomposeLU<T> Matrix_DecomposeLU;
    private static readonly LinearAlgebra.delegates.Matrix_EqualsByValue<T> Matrix_EqualsByValue;
    private static readonly LinearAlgebra.delegates.Matrix_EqualsByValue_leniency<T> Matrix_EqualsByValue_leniency;

    static Matrix()
    {
      // Constants
      _zero = Constants.Get<T>().factory(0);
      _one = Constants.Get<T>().factory(1);
      _two = Constants.Get<T>().factory(2);

      LinearAlgebra<T> linearAlgebra = LinearAlgebra.Get<T>();
      Matrix_Negate = linearAlgebra.Matrix_Negate;
      Matrix_Add = linearAlgebra.Matrix_Add;
      Matrix_Subtract = linearAlgebra.Matrix_Subtract;
      Matrix_Multiply = linearAlgebra.Matrix_Multiply;
      Matrix_Multiply_scalar = linearAlgebra.Matrix_Multiply_scalar;
      Matrix_Multiply_vector = linearAlgebra.Matrix_Multiply_vector;
      Matrix_Divide = linearAlgebra.Matrix_Divide;
      Matrix_Power = linearAlgebra.Matrix_Power;
      Matrix_Minor = linearAlgebra.Matrix_Minor;
      Matrix_ConcatenateRowWise = linearAlgebra.Matrix_ConcatenateRowWise;
      Matrix_Determinent = linearAlgebra.Matrix_Determinent;
      Matrix_Echelon = linearAlgebra.Matrix_Echelon;
      Matrix_ReducedEchelon = linearAlgebra.Matrix_ReducedEchelon;
      Matrix_Inverse = linearAlgebra.Matrix_Inverse;
      Matrix_Adjoint = linearAlgebra.Matrix_Adjoint;
      Matrix_Transpose = linearAlgebra.Matrix_Transpose;
      Matrix_DecomposeLU = linearAlgebra.Matrix_DecomposeLU;
      Matrix_EqualsByValue = linearAlgebra.Matrix_EqualsByValue;
      Matrix_EqualsByValue_leniency = linearAlgebra.Matrix_EqualsByValue_leniency;
    }

    #endregion

    #region properties

    /// <summary>The number of rows in the matrix.</summary>
    public int Rows { get { return this._rows; } }
    /// <summary>The number of columns in the matrix.</summary>
    public int Columns { get { return this._columns; } }
    /// <summary>Determines if the matrix is square.</summary>
    public bool IsSquare { get { return this._rows == this._columns; } }
    /// <summary>Determines if the matrix is a vector.</summary>
    public bool IsVector { get { return this._columns == 1; } }
    /// <summary>Determines if the matrix is a 2 component vector.</summary>
    public bool Is2x1 { get { return this._rows == 2 && this._columns == 1; } }
    /// <summary>Determines if the matrix is a 3 component vector.</summary>
    public bool Is3x1 { get { return this._rows == 3 && this._columns == 1; } }
    /// <summary>Determines if the matrix is a 4 component vector.</summary>
    public bool Is4x1 { get { return this._rows == 4 && this._columns == 1; } }
    /// <summary>Determines if the matrix is a 2 square matrix.</summary>
    public bool Is2x2 { get { return this._rows == 2 && this._columns == 2; } }
    /// <summary>Determines if the matrix is a 3 square matrix.</summary>
    public bool Is3x3 { get { return this._rows == 3 && this._columns == 3; } }
    /// <summary>Determines if the matrix is a 4 square matrix.</summary>
    public bool Is4x4 { get { return this._rows == 4 && this._columns == 4; } }

    /// <summary>Standard row-major matrix indexing.</summary>
    /// <param name="row">The row index.</param>
    /// <param name="column">The column index.</param>
    /// <returns>The value at the given indeces.</returns>
    public T this[int row, int column]
    {
      get
      {
        try { return this._matrix[row * this._columns + column]; }
        catch { throw new Error("index out of bounds."); }
      }
      set
      {
        try { this._matrix[row * this._columns + column] = value; }
        catch { throw new Error("index out of bounds."); }
      }
    }

    #endregion

    #region constructors

    /// <summary>Constructs a new zero-matrix of the given dimensions.</summary>
    /// <param name="rows">The number of row dimensions.</param>
    /// <param name="columns">The number of column dimensions.</param>
    public Matrix(int rows, int columns)
    {
      if (rows < 1)
        throw new Error("Invalid rows on matrix contruction");
      if (columns < 1)
        throw new Error("Invalid columns on matrix contruction");

      this._matrix = new T[rows * columns];
      this._rows = rows;
      this._columns = columns;
    }

    /// <summary>Constructs a matrix from a T[,].</summary>
    /// <param name="matrix">The float[,] to wrap in a matrix class.</param>
    public Matrix(T[,] matrix)
    {
      this._rows = matrix.GetLength(0);
      this._columns = matrix.GetLength(1);
      this._matrix = new T[this._rows * this._columns];
      for (int i = 0; i < this._matrix.Length; i++)
        this._matrix[i] = matrix[i / this._rows, i % this._columns];
    }

    private Matrix(Matrix<T> matrix)
    {
      this._rows = matrix._rows;
      this._columns = matrix.Columns;
      this._matrix = matrix._matrix.Clone() as T[];
    }

    internal Matrix(Vector<T> vector)
    {
      this._rows = vector.Dimensions;
      this._columns = 1;
      this._matrix = vector._vector.Clone() as T[];
    }

    #endregion

    #region factories

    /// <summary>Constructs a new zero-matrix of the given dimensions.</summary>
    /// <param name="rows">The number of rows of the matrix.</param>
    /// <param name="columns">The number of columns of the matrix.</param>
    /// <returns>The newly constructed zero-matrix.</returns>
    public static Matrix<T> FactoryZero(int rows, int columns)
    {
      try { return new Matrix<T>(rows, columns); }
      catch { throw new Error("invalid dimensions."); }
    }

    /// <summary>Constructs a new identity-matrix of the given dimensions.</summary>
    /// <param name="rows">The number of rows of the matrix.</param>
    /// <param name="columns">The number of columns of the matrix.</param>
    /// <returns>The newly constructed identity-matrix.</returns>
    public static Matrix<T> FactoryIdentity(int rows, int columns)
    {
      Matrix<T> matrix;
      try { matrix = new Matrix<T>(rows, columns); }
      catch { throw new Error("invalid dimensions."); }
      if (rows <= columns)
        for (int i = 0; i < rows; i++)
          matrix[i, i] = _one;
      else
        for (int i = 0; i < columns; i++)
          matrix[i, i] = _one;
      return matrix;
    }

    /// <summary>Constructs a new matrix where every entry is 1.</summary>
    /// <param name="rows">The number of rows of the matrix.</param>
    /// <param name="columns">The number of columns of the matrix.</param>
    /// <returns>The newly constructed matrix filled with 1's.</returns>
    public static Matrix<T> FactoryOne(int rows, int columns)
    {
      Matrix<T> matrix;
      try { matrix = new Matrix<T>(rows, columns); }
      catch { throw new Error("invalid dimensions."); }
      for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
          matrix[i, j] = _one;
      return matrix;
    }

    /// <summary>Constructs a new matrix where every entry is the same uniform value.</summary>
    /// <param name="rows">The number of rows of the matrix.</param>
    /// <param name="columns">The number of columns of the matrix.</param>
    /// <param name="uniform">The value to assign every spot in the matrix.</param>
    /// <returns>The newly constructed matrix filled with the uniform value.</returns>
    public static Matrix<T> FactoryUniform(int rows, int columns, T uniform)
    {
      Matrix<T> matrix;
      try { matrix = new Matrix<T>(rows, columns); }
      catch { throw new Error("invalid dimensions."); }
      for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
          matrix[i, j] = uniform;
      return matrix;
    }

    /// <summary>Constructs a 2-component vector matrix with all values being 0.</summary>
    /// <returns>The constructed 2-component vector matrix.</returns>
    public static Matrix<T> Factory2x1() { return new Matrix<T>(2, 1); }
    /// <summary>Constructs a 3-component vector matrix with all values being 0.</summary>
    /// <returns>The constructed 3-component vector matrix.</returns>
    public static Matrix<T> Factory3x1() { return new Matrix<T>(3, 1); }
    /// <summary>Constructs a 4-component vector matrix with all values being 0.</summary>
    /// <returns>The constructed 4-component vector matrix.</returns>
    public static Matrix<T> Factory4x1() { return new Matrix<T>(4, 1); }

    /// <summary>Constructs a 2x2 matrix with all values being 0.</summary>
    /// <returns>The constructed 2x2 matrix.</returns>
    public static Matrix<T> Factory2x2() { return new Matrix<T>(2, 2); }
    /// <summary>Constructs a 3x3 matrix with all values being 0.</summary>
    /// <returns>The constructed 3x3 matrix.</returns>
    public static Matrix<T> Factory3x3() { return new Matrix<T>(3, 3); }
    /// <summary>Constructs a 4x4 matrix with all values being 0.</summary>
    /// <returns>The constructed 4x4 matrix.</returns>
    public static Matrix<T> Factory4x4() { return new Matrix<T>(4, 4); }

    ///// <param name="angle">Angle of rotation in radians.</param>
    //public static Matrix<T> Factory3x3RotationX(T angle)
    //{
    //  T cos = _cos(angle);
    //  T sin = _sin(angle);
    //  return new Matrix<T>(new T[,] {
    //    { _one, _zero, _zero },
    //    { _zero, cos, sin },
    //    { _zero, _negate(sin), cos }});
    //}

    ///// <param name="angle">Angle of rotation in radians.</param>
    //public static Matrix<T> Factory3x3RotationY(T angle)
    //{
    //  T cos = _cos(angle);
    //  T sin = _sin(angle);
    //  return new Matrix<T>(new T[,] {
    //    { cos, _zero, _negate(sin) },
    //    { _zero, _one, _zero },
    //    { sin, _zero, cos }});
    //}

    ///// <param name="angle">Angle of rotation in radians.</param>
    //public static Matrix<T> Factory3x3RotationZ(T angle)
    //{
    //  T cos = _cos(angle);
    //  T sin = _sin(angle);
    //  return new Matrix<T>(new T[,] {
    //    { cos, _negate(sin), _zero },
    //    { sin, cos, _zero },
    //    { _zero, _zero, _zero }});
    //}

    ///// <param name="angleX">Angle about the X-axis in radians.</param>
    ///// <param name="angleY">Angle about the Y-axis in radians.</param>
    ///// <param name="angleZ">Angle about the Z-axis in radians.</param>
    //public static Matrix<T> Factory3x3RotationXthenYthenZ(T angleX, T angleY, T angleZ)
    //{
    //  T xCos = _cos(angleX), xSin = _sin(angleX),
    //    yCos = _cos(angleY), ySin = _sin(angleY),
    //    zCos = _cos(angleZ), zSin = _sin(angleZ);
    //  return new Matrix<T>(new T[,] {
    //    { _multiply(yCos, zCos), _negate(_multiply(yCos, zSin)), ySin },
    //    { _add(_multiply(xCos, zSin), _multiply(_multiply(xSin, ySin), zCos)), _add(_multiply(xCos, zCos), _multiply(_multiply(xSin, ySin), zSin)), _negate(_multiply(xSin, yCos)) },
    //    { _subtract(_multiply(xSin, zSin), _multiply(_multiply(xCos, ySin), zCos)), _add(_multiply(xSin, zCos), _multiply(_multiply(xCos, ySin), zSin)), _multiply(xCos, yCos) }});
    //}

    ///// <param name="angleX">Angle about the X-axis in radians.</param>
    ///// <param name="angleY">Angle about the Y-axis in radians.</param>
    ///// <param name="angleZ">Angle about the Z-axis in radians.</param>
    //public static Matrix<T> Factory3x3RotationZthenYthenX(T angleX, T angleY, T angleZ)
    //{
    //  T xCos = _cos(angleX), xSin = _sin(angleX),
    //    yCos = _cos(angleY), ySin = _sin(angleY),
    //    zCos = _cos(angleZ), zSin = _sin(angleZ);
    //  return new Matrix<T>(new T[,] {
    //    { _multiply(yCos, zCos), _subtract(_multiply(_multiply(zCos, xSin), ySin), _multiply(xCos, zSin)), _add(_multiply(_multiply(xCos, zCos), ySin), _multiply(xSin, zSin)) },
    //    { _multiply(yCos, zSin), _add(_multiply(xCos, zCos), _multiply(_multiply(xSin, ySin), zSin)), _add(_multiply(_negate(zCos), xSin), _multiply(_multiply(xCos, ySin), zSin)) },
    //    { _negate(ySin), _multiply(yCos, xSin), _multiply(xCos, yCos) }});
    //}

    /// <summary>Creates a 3x3 matrix initialized with a shearing transformation.</summary>
    /// <param name="shearXbyY">The shear along the X-axis in the Y-direction.</param>
    /// <param name="shearXbyZ">The shear along the X-axis in the Z-direction.</param>
    /// <param name="shearYbyX">The shear along the Y-axis in the X-direction.</param>
    /// <param name="shearYbyZ">The shear along the Y-axis in the Z-direction.</param>
    /// <param name="shearZbyX">The shear along the Z-axis in the X-direction.</param>
    /// <param name="shearZbyY">The shear along the Z-axis in the Y-direction.</param>
    /// <returns>The constructed shearing matrix.</returns>
    public static Matrix<T> Factory3x3Shear(
      T shearXbyY, T shearXbyZ, T shearYbyX,
      T shearYbyZ, T shearZbyX, T shearZbyY)
    {
      return new Matrix<T>(new T[,] {
        { _one, shearYbyX, shearZbyX },
        { shearXbyY, _one, shearYbyZ },
        { shearXbyZ, shearYbyZ, _one }});
    }

    #endregion

    #region operators

    /// <summary>Negates all the values in a matrix.</summary>
    /// <param name="matrix">The matrix to have its values negated.</param>
    /// <returns>The resulting matrix after the negations.</returns>
    public static Matrix<T> operator -(Matrix<T> matrix)
    { return Matrix_Negate(matrix); }
    /// <summary>Does a standard matrix addition.</summary>
    /// <param name="left">The left matrix of the addition.</param>
    /// <param name="right">The right matrix of the addition.</param>
    /// <returns>The resulting matrix after teh addition.</returns>
    public static Matrix<T> operator +(Matrix<T> left, Matrix<T> right)
    { return Matrix_Add(left, right); }
    /// <summary>Does a standard matrix subtraction.</summary>
    /// <param name="left">The left matrix of the subtraction.</param>
    /// <param name="right">The right matrix of the subtraction.</param>
    /// <returns>The result of the matrix subtraction.</returns>
    public static Matrix<T> operator -(Matrix<T> left, Matrix<T> right)
    { return Matrix_Subtract(left, right); }
    /// <summary>Multiplies a vector by a matrix.</summary>
    /// <param name="left">The matrix of the multiplication.</param>
    /// <param name="right">The vector of the multiplication.</param>
    /// <returns>The resulting vector after the multiplication.</returns>
    public static Vector<T> operator *(Matrix<T> left, Vector<T> right)
    { return Matrix_Multiply_vector(left, right); }
    /// <summary>Does a standard matrix multiplication.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix after the multiplication.</returns>
    public static Matrix<T> operator *(Matrix<T> left, Matrix<T> right)
    { return Matrix_Multiply(left, right); }
    /// <summary>Multiplies all the values in a matrix by a scalar.</summary>
    /// <param name="left">The matrix to have its values multiplied.</param>
    /// <param name="right">The scalar to multiply the values by.</param>
    /// <returns>The resulting matrix after the multiplications.</returns>
    public static Matrix<T> operator *(Matrix<T> left, T right)
    { return Matrix_Multiply_scalar(left, right); }
    /// <summary>Multiplies all the values in a matrix by a scalar.</summary>
    /// <param name="left">The scalar to multiply the values by.</param>
    /// <param name="right">The matrix to have its values multiplied.</param>
    /// <returns>The resulting matrix after the multiplications.</returns>
    public static Matrix<T> operator *(T left, Matrix<T> right)
    { return Matrix_Multiply_scalar(right, left); }
    /// <summary>Divides all the values in a matrix by a scalar.</summary>
    /// <param name="left">The matrix to have its values divided.</param>
    /// <param name="right">The scalar to divide the values by.</param>
    /// <returns>The resulting matrix after the divisions.</returns>
    public static Matrix<T> operator /(Matrix<T> left, T right)
    { return Matrix_Divide(left, right); }
    /// <summary>Applies a power to a matrix.</summary>
    /// <param name="left">The matrix to apply a power to.</param>
    /// <param name="right">The power to apply to the matrix.</param>
    /// <returns>The result of the power operation.</returns>
    public static Matrix<T> operator ^(Matrix<T> left, int right)
    { return Matrix_Power(left, right); }
    /// <summary>Checks for equality by value.</summary>
    /// <param name="left">The left matrix of the equality check.</param>
    /// <param name="right">The right matrix of the equality check.</param>
    /// <returns>True if the values of the matrices are equal, false if not.</returns>
    public static bool operator ==(Matrix<T> left, Matrix<T> right)
    { return Matrix_EqualsByValue(left, right); }
    /// <summary>Checks for false-equality by value.</summary>
    /// <param name="left">The left matrix of the false-equality check.</param>
    /// <param name="right">The right matrix of the false-equality check.</param>
    /// <returns>True if the values of the matrices are not equal, false if they are.</returns>
    public static bool operator !=(Matrix<T> left, Matrix<T> right)
    { return !Matrix_EqualsByValue(left, right); }
    /// <summary>Automatically converts a float[,] into a matrix if necessary.</summary>
    /// <param name="matrix">The float[,] to convert to a matrix.</param>
    /// <returns>The reference to the matrix representing the T[,].</returns>
    public static explicit operator Matrix<T>(T[,] matrix)
    { return new Matrix<T>(matrix); }
    ///// <summary>Automatically converts a matrix into a T[,] if necessary.</summary>
    ///// <param name="matrix">The matrix to convert to a T[,].</param>
    ///// <returns>The reference to the T[,] representing the matrix.</returns>
    //public static explicit operator T[,](Matrix<T> matrix)
    //{ 
    //  T[,] array = new T[matrix.Rows, matrix.Columns];
    //  for (int i = 0; i < i )
    //  return matrix; }
    #endregion

    #region instance

    /// <summary>Negates all the values in this matrix.</summary>
    /// <returns>The resulting matrix after the negations.</returns>
    public Matrix<T> Negate()
    { return Matrix_Negate(this); }
    /// <summary>Does a standard matrix addition.</summary>
    /// <param name="right">The matrix to add to this matrix.</param>
    /// <returns>The resulting matrix after the addition.</returns>
    public Matrix<T> Add(Matrix<T> right)
    { return Matrix_Add(this, right); }
    /// <summary>Does a standard matrix multiplication (triple for loop).</summary>
    /// <param name="right">The matrix to multiply this matrix by.</param>
    /// <returns>The resulting matrix after the multiplication.</returns>
    public Matrix<T> Multiply(Matrix<T> right)
    { return Matrix_Multiply(this, right); }
    /// <summary>Multiplies all the values in this matrix by a scalar.</summary>
    /// <param name="right">The scalar to multiply all the matrix values by.</param>
    /// <returns>The retulting matrix after the multiplications.</returns>
    public Matrix<T> Multiply(T right)
    { return Matrix_Multiply_scalar(this, right); }
    /// <summary>Divides all the values in this matrix by a scalar.</summary>
    /// <param name="right">The scalar to divide the matrix values by.</param>
    /// <returns>The resulting matrix after teh divisions.</returns>
    public Matrix<T> Divide(T right)
    { return Matrix_Divide(this, right); }
    /// <summary>Gets the minor of a matrix.</summary>
    /// <param name="row">The restricted row of the minor.</param>
    /// <param name="column">The restricted column of the minor.</param>
    /// <returns>The minor from the row/column restrictions.</returns>
    public Matrix<T> Minor(int row, int column)
    { return Matrix_Minor(this, row, column); }
    /// <summary>Combines two matrices from left to right 
    /// (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
    /// <param name="right">The matrix to combine with on the right side.</param>
    /// <returns>The resulting row-wise concatination.</returns>
    public Matrix<T> ConcatenateRowWise(Matrix<T> right)
    { return Matrix_ConcatenateRowWise(this, right); }
    /// <summary>Computes the determinent if this matrix is square.</summary>
    /// <returns>The computed determinent if this matrix is square.</returns>
    public T Determinent()
    { return Matrix_Determinent(this); }
    /// <summary>Computes the echelon form of this matrix (aka REF).</summary>
    /// <returns>The computed echelon form of this matrix (aka REF).</returns>
    public Matrix<T> Echelon()
    { return Matrix_Echelon(this); }
    /// <summary>Computes the reduced echelon form of this matrix (aka RREF).</summary>
    /// <returns>The computed reduced echelon form of this matrix (aka RREF).</returns>
    public Matrix<T> ReducedEchelon()
    { return Matrix_ReducedEchelon(this); }
    /// <summary>Computes the inverse of this matrix.</summary>
    /// <returns>The inverse of this matrix.</returns>
    public Matrix<T> Inverse()
    { return Matrix_Inverse(this); }
    /// <summary>Gets the adjoint of this matrix.</summary>
    /// <returns>The adjoint of this matrix.</returns>
    public Matrix<T> Adjoint()
    { return Matrix_Adjoint(this); }
    /// <summary>Transposes this matrix.</summary>
    /// <returns>The transpose of this matrix.</returns>
    public Matrix<T> Transpose()
    { return Matrix_Transpose(this); }
    /// <summary>Copies this matrix.</summary>
    /// <returns>The copy of this matrix.</returns>
    public Matrix<T> Clone()
    { return Matrix<T>.Clone(this); }

    #endregion

    #region static

    /// <summary>Negates all the values in a matrix.</summary>
    /// <param name="matrix">The matrix to have its values negated.</param>
    /// <returns>The resulting matrix after the negations.</returns>
    public static Matrix<T> Negate(Matrix<T> matrix)
    { return Matrix_Negate(matrix); }
    /// <summary>Does standard addition of two matrices.</summary>
    /// <param name="left">The left matrix of the addition.</param>
    /// <param name="right">The right matrix of the addition.</param>
    /// <returns>The resulting matrix after the addition.</returns>
    public static Matrix<T> Add(Matrix<T> left, Matrix<T> right)
    { return Matrix_Add(left, right); }
    /// <summary>Subtracts a scalar from all the values in a matrix.</summary>
    /// <param name="left">The matrix to have the values subtracted from.</param>
    /// <param name="right">The scalar to subtract from all the matrix values.</param>
    /// <returns>The resulting matrix after the subtractions.</returns>
    public static Matrix<T> Subtract(Matrix<T> left, Matrix<T> right)
    { return Matrix_Subtract(left, right); }
    /// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Matrix<T> Multiply(Matrix<T> left, Matrix<T> right)
    { return Matrix_Multiply(left, right); }
    /// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
    /// <param name="left">The left matrix of the multiplication.</param>
    /// <param name="right">The right matrix of the multiplication.</param>
    /// <returns>The resulting matrix of the multiplication.</returns>
    public static Vector<T> Multiply(Matrix<T> left, Vector<T> right)
    { return Matrix_Multiply_vector(left, right._vector); }
    /// <summary>Multiplies all the values in a matrix by a scalar.</summary>
    /// <param name="left">The matrix to have the values multiplied.</param>
    /// <param name="right">The scalar to multiply the values by.</param>
    /// <returns>The resulting matrix after the multiplications.</returns>
    public static Matrix<T> Multiply(Matrix<T> left, T right)
    { return Matrix_Multiply_scalar(left, right); }
    /// <summary>Applies a power to a square matrix.</summary>
    /// <param name="matrix">The matrix to be powered by.</param>
    /// <param name="power">The power to apply to the matrix.</param>
    /// <returns>The resulting matrix of the power operation.</returns>
    public static Matrix<T> Power(Matrix<T> matrix, int power)
    { return Matrix_Power(matrix, power); }
    /// <summary>Divides all the values in the matrix by a scalar.</summary>
    /// <param name="matrix">The matrix to divide the values of.</param>
    /// <param name="right">The scalar to divide all the matrix values by.</param>
    /// <returns>The resulting matrix with the divided values.</returns>
    public static Matrix<T> Divide(Matrix<T> matrix, T right)
    { return Matrix_Divide(matrix, right); }
    /// <summary>Gets the minor of a matrix.</summary>
    /// <param name="matrix">The matrix to get the minor of.</param>
    /// <param name="row">The restricted row to form the minor.</param>
    /// <param name="column">The restricted column to form the minor.</param>
    /// <returns>The minor of the matrix.</returns>
    public static Matrix<T> Minor(Matrix<T> matrix, int row, int column)
    { return Matrix_Minor(matrix, row, column); }
    /// <summary>Combines two matrices from left to right 
    /// (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
    /// <param name="left">The left matrix of the concatenation.</param>
    /// <param name="right">The right matrix of the concatenation.</param>
    /// <returns>The resulting matrix of the concatenation.</returns>
    public static Matrix<T> ConcatenateRowWise(Matrix<T> left, Matrix<T> right)
    { return Matrix_ConcatenateRowWise(left, right); }
    /// <summary>Calculates the determinent of a square matrix.</summary>
    /// <param name="matrix">The matrix to calculate the determinent of.</param>
    /// <returns>The determinent of the matrix.</returns>
    public static T Determinent(Matrix<T> matrix)
    { return Matrix_Determinent(matrix); }
    /// <summary>Calculates the echelon of a matrix (aka REF).</summary>
    /// <param name="matrix">The matrix to calculate the echelon of (aka REF).</param>
    /// <returns>The echelon of the matrix (aka REF).</returns>
    public static Matrix<T> Echelon(Matrix<T> matrix)
    { return Matrix_Echelon(matrix); }
    /// <summary>Calculates the echelon of a matrix and reduces it (aka RREF).</summary>
    /// <param name="matrix">The matrix matrix to calculate the reduced echelon of (aka RREF).</param>
    /// <returns>The reduced echelon of the matrix (aka RREF).</returns>
    public static Matrix<T> ReducedEchelon(Matrix<T> matrix)
    { return Matrix_ReducedEchelon(matrix); }
    /// <summary>Calculates the inverse of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the inverse of.</param>
    /// <returns>The inverse of the matrix.</returns>
    public static Matrix<T> Inverse(Matrix<T> matrix)
    { return Matrix_Inverse(matrix); }
    /// <summary>Calculates the adjoint of a matrix.</summary>
    /// <param name="matrix">The matrix to calculate the adjoint of.</param>
    /// <returns>The adjoint of the matrix.</returns>
    public static Matrix<T> Adjoint(Matrix<T> matrix)
    { return Matrix_Adjoint(matrix); }
    /// <summary>Returns the transpose of a matrix.</summary>
    /// <param name="matrix">The matrix to transpose.</param>
    /// <returns>The transpose of the matrix.</returns>
    public static Matrix<T> Transpose(Matrix<T> matrix)
    { return Matrix_Transpose(matrix); }
    /// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
    /// <param name="matrix">The matrix to decompose.</param>
    /// <param name="lower">The computed lower triangular matrix.</param>
    /// <param name="upper">The computed upper triangular matrix.</param>
    /// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
    /// <param name="matrix">The matrix to decompose.</param>
    /// <param name="lower">The computed lower triangular matrix.</param>
    /// <param name="upper">The computed upper triangular matrix.</param>
    public static void DecomposeLU(Matrix<T> matrix, out Matrix<T> lower, out Matrix<T> upper)
    { Matrix_DecomposeLU(matrix, out lower, out upper); }
    /// <summary>Creates a copy of a matrix.</summary>
    /// <param name="matrix">The matrix to copy.</param>
    /// <returns>A copy of the matrix.</returns>
    public static Matrix<T> Clone(Matrix<T> matrix)
    { return new Matrix<T>(matrix); }
    /// <summary>Does a value equality check.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Matrix<T> left, Matrix<T> right)
    { return Matrix_EqualsByValue(left, right); }
    /// <summary>Does a value equality check with leniency.</summary>
    /// <param name="left">The first matrix to check for equality.</param>
    /// <param name="right">The second matrix to check for equality.</param>
    /// <param name="leniency">How much the values can vary but still be considered equal.</param>
    /// <returns>True if values are equal, false if not.</returns>
    public static bool EqualsValue(Matrix<T> left, Matrix<T> right, T leniency)
    { return Matrix_EqualsByValue_leniency(left, right, leniency); }
    /// <summary>Checks if two matrices are equal by reverences.</summary>
    /// <param name="left">The left matric of the equality check.</param>
    /// <param name="right">The right matrix of the equality check.</param>
    /// <returns>True if the references are equal, false if not.</returns>
    public static bool EqualsReference(Matrix<T> left, Matrix<T> right)
    { return object.ReferenceEquals(left, right); }

    #endregion

    #region overrides

    /// <summary>Prints out a string representation of this matrix.</summary>
    /// <returns>A string representing this matrix.</returns>
    public override string ToString()
    { return base.ToString(); }
    /// <summary>Computes a hash code from the values of this matrix.</summary>
    /// <returns>A hash code for the matrix.</returns>
    public override int GetHashCode()
    { return this._matrix.GetHashCode(); }
    /// <summary>Does an equality check by value.</summary>
    /// <param name="right">The object to compare to.</param>
    /// <returns>True if the references are equal, false if not.</returns>
    public override bool Equals(object right)
    {
      if (!(right is Matrix<T>))
        return Matrix<T>.EqualsValue(this, (Matrix<T>)right);
      return false;
    }

    #endregion
  }
}
