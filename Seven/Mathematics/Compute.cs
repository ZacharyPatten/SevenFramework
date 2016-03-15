//#define show_Numeric // This preprocesser directive is for development purposes only
//#define pre_optimization // This preprocesser directive is for development purposes only

// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

using Seven.Algorithms;
using Seven.Structures;

namespace Seven.Mathematics
{
	/// <summary>Primary class for generic mathematics in the SevenFramework.</summary>
	/// <typeparam name="T">The generic type to perform mathematics on (expected to be numeric).</typeparam>
	public static class Compute<T>
	{
		#region Delegates

		/// <summary>Static storage class for all the delegates used in the Compute class.</summary>
		public static class Delegates
		{
			#region Constant

			public delegate T IntCast(int value);

			public delegate T ComputePi();

			#endregion

			#region Arithmetic

			/// <summary>Negates a value.</summary>
			/// <param name="value">The value to negate.</param>
			/// <returns>The result of the negation.</returns>
			public delegate T Negate(T value);
			/// <summary>Adds two operands together.</summary>
			/// <typeparam name="T">The type of the values to be added.</typeparam>
			/// <param name="left">The left operand of the addition.</param>
			/// <param name="right">The right operand of the addition.</param>
			/// <returns>The result of the addition.</returns>
			public delegate T Add(T left, T right);
			/// <summary>Compuates the algebraic summation [ Σ (stepper) ].</summary>
			/// <param name="stepper">The items to perform the summation on.</param>
			/// <returns>The summation of the provided items.</returns>
			public delegate T Summation(Stepper<T> stepper);
			/// <summary>Subtracts two operands.</summary>
			/// <param name="left">The left operand of the subtraction.</param>
			/// <param name="right">The right operand of the subtraction.</param>
			/// <returns>The result of the subtraction.</returns>
			public delegate T Subtract(T left, T right);
			/// <summary>Multiplies two operands together.</summary>
			/// <param name="left">The left operand of the multiplication.</param>
			/// <param name="right">The right operand of the multiplication.</param>
			/// <returns>The result of the multiplication.</returns>
			public delegate T Multiply(T left, T right);
			/// <summary>Divides two operands.</summary>
			/// <param name="left">The left operand of the division.</param>
			/// <param name="right">The right operand of the division.</param>
			/// <returns>The result of the division.</returns>
			public delegate T Divide(T left, T right);
			/// <summary>Takes one operand to the power of another.</summary>
			/// <param name="left">The base of the power operaition.</param>
			/// <param name="right">The exponent of the power operation.</param>
			/// <returns>The result of the power operation.</returns>
			public delegate T Power(T left, T right);
			/// <summary>Solves for "x": [ x ^ 2 = b ].</summary>
			/// <param name="b">The value to be square rooted.</param>
			/// <returns>x from: [ x ^ 2 = b ]</returns>
			public delegate T SquareRoot(T b);
			/// <summary>Solves for "x": [ x ^ r = b ].</summary>
			/// <param name="b">The number to be rooted.</param>
			/// <param name="r">The root to find of b.</param>
			/// <returns>x from: [ x ^ r = b ]</returns>
			public delegate T Root(T b, T r);
			/// <summary>Computes: [ log_b(n) ].</summary>
			/// <param name="n">The value to be log-ed.</param>
			/// <param name="b">The base of the log operation.</param>
			/// <returns>[ log_b(n) ]</returns>
			public delegate T Logarithm(T n, T b);

			#endregion

			#region Logic

			/// <summary>Computes the absolute value of a value.</summary>
			/// <param name="n">The value to be absolut-ed.</param>
			/// <returns>The result of the absolute value operation.</returns>
			public delegate T AbsoluteValue(T n);
			/// <summary>Finds the max value in a set.</summary>
			/// <param name="stepper">The set to find the max value within.</param>
			/// <returns>The max value in the set.</returns>
			public delegate T Maximum(Stepper<T> stepper);
			/// <summary>Finds the min value in a set.</summary>
			/// <param name="stepper">The set to find the min value within.</param>
			/// <returns>The min value in the set.</returns>
			public delegate T Minimum(Stepper<T> stepper);
			/// <summary>Restricts a value to a min-max range.</summary>
			/// <param name="value">The value to be clamped.</param>
			/// <param name="minimum">The minimum value allowed.</param>
			/// <param name="maximum">The maximum value allowed.</param>
			/// <returns>The possibly clamped value.</returns>
			public delegate T Clamp(T value, T minimum, T maximum);
			/// <summary>Checks for equality by value with a leniency.</summary>
			/// <param name="left">The left operand of the equate operation.</param>
			/// <param name="right">The right operand of the equate operation.</param>
			/// <param name="leniency">The leniency of the equate operation.</param>
			/// <returns>True if the operand are within the leniency of each other.</returns>
			public delegate bool EqualsLeniency(T left, T right, T leniency);

			#endregion

			#region Factors & Multiples

			/// <summary>Finds the greatest common factor between multiple integers.</summary>
			/// <param name="stepper">The stepper function for the set.</param>
			/// <returns>The greatest common factor.</returns>
			public delegate T GreatestCommonFactor(Stepper<T> stepper);
			/// <summary>Finds the least common multiple between multiple integers.</summary>
			/// <param name="stepper">The stepper function for the set.</param>
			/// <returns>The least common multiple.</returns>
			public delegate T LeastCommonMultiple(Stepper<T> stepper);
			/// <summary>Computes the prime factors of n.</summary>
			/// <typeparam name="T">The numeric type of the operation.</typeparam>
			/// <param name="n">The value to find the prime roots of.</param>
			/// <returns>The prime factors.</returns>
			public delegate void FactorPrimes(T n, Step<T> step);

			#endregion

			#region Exponential / Natural Logarithm

			/// <summary>Computes: [ e ^ x ].</summary>
			/// <param name="x">The exponent.</param>
			/// <returns>[ e ^ x ]</returns>
			public delegate T Exponential(T x);
			/// <summary>Computes (natrual log): [ ln(n) ].</summary>
			/// <param name="n">The value to compute the natural log of.</param>
			/// <returns>The result of the natrual log operation.</returns>
			public delegate T NaturalLogarithm(T n);

			#endregion

			#region Angles

			public delegate T DegreesToRadians(T degrees);
			public delegate T TurnsToRadians(T turns);
			public delegate T GradiansToRadians(T gradians);
			public delegate T RadiansToDegrees(T radians);
			public delegate T RadiansToTurns(T radians);
			public delegate T RadiansToGradians(T radians);

			#endregion

			#region miscellaneous

			/// <summary>Computes: [ 1 / n ].</summary>
			/// <param name="n">The value to be inverted.</param>
			/// <returns>The result of the inversion.</returns>
			public delegate T Invert(T n);
			/// <summary>Determines if a number is a prime number.</summary>
			/// <param name="n">The number to determine the prime status of.</param>
			/// <returns>True if prime. False if not prime.</returns>
			public delegate bool IsPrime(T n);

			#endregion

			#region interpolation

			public delegate T LinearInterpolation(T x, T x0, T x1, T y0, T y1);

			#endregion

			#region Linear Algebra

			#region vector

			/// <summary>Adds two vectors together.</summary>
			/// <param name="left">The first vector of the addition.</param>
			/// <param name="right">The second vector of the addiiton.</param>
			/// <returns>The result of the addiion.</returns>
			public delegate Vector<T> Vector_Add(Vector<T> left, Vector<T> right);
			/// <summary>Negates all the values in a vector.</summary>
			/// <param name="vector">The vector to have its values negated.</param>
			/// <returns>The result of the negations.</returns>
			public delegate Vector<T> Vector_Negate(Vector<T> vector);
			/// <summary>Subtracts two vectors.</summary>
			/// <param name="left">The left vector of the subtraction.</param>
			/// <param name="right">The right vector of the subtraction.</param>
			/// <returns>The result of the vector subtracton.</returns>
			public delegate Vector<T> Vector_Subtract(Vector<T> left, Vector<T> right);
			/// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
			/// <param name="left">The vector to have the components multiplied by.</param>
			/// <param name="right">The scalars to multiply the vector components by.</param>
			/// <returns>The result of the multiplications.</returns>
			public delegate Vector<T> Vector_Multiply(Vector<T> left, T right);
			/// <summary>Divides all the components of a vector by a scalar.</summary>
			/// <param name="left">The vector to have the components divided by.</param>
			/// <param name="right">The scalar to divide the vector components by.</param>
			/// <returns>The resulting vector after teh divisions.</returns>
			public delegate Vector<T> Vector_Divide(Vector<T> vector, T right);
			/// <summary>Computes the dot product between two vectors.</summary>
			/// <param name="left">The first vector of the dot product operation.</param>
			/// <param name="right">The second vector of the dot product operation.</param>
			/// <returns>The result of the dot product operation.</returns>
			public delegate T Vector_DotProduct(Vector<T> left, Vector<T> right);
			/// <summary>Computes teh cross product of two vectors.</summary>
			/// <param name="left">The first vector of the cross product operation.</param>
			/// <param name="right">The second vector of the cross product operation.</param>
			/// <returns>The result of the cross product operation.</returns>
			public delegate Vector<T> Vector_CrossProduct(Vector<T> left, Vector<T> right);
			/// <summary>Normalizes a vector.</summary>
			/// <param name="vector">The vector to normalize.</param>
			/// <returns>The result of the normalization.</returns>
			public delegate Vector<T> Vector_Normalize(Vector<T> vector);
			/// <summary>Computes the length of a vector.</summary>
			/// <param name="vector">The vector to calculate the length of.</param>
			/// <returns>The computed length of the vector.</returns>
			public delegate T Vector_Magnitude(Vector<T> vector);
			/// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
			/// <param name="vector">The vector to compute the length squared of.</param>
			/// <returns>The computed length squared of the vector.</returns>
			public delegate T Vector_MagnitudeSquared(Vector<T> vector);
			/// <summary>Computes the angle between two vectors.</summary>
			/// <param name="first">The first vector to determine the angle between.</param>
			/// <param name="second">The second vector to determine the angle between.</param>
			/// <returns>The angle between the two vectors in radians.</returns>
			public delegate T Vector_Angle(Vector<T> first, Vector<T> second);
			/// <summary>Rotates a vector by the specified axis and rotation values.</summary>
			/// <param name="vector">The vector to rotate.</param>
			/// <param name="angle">The angle of the rotation.</param>
			/// <param name="x">The x component of the axis vector to rotate about.</param>
			/// <param name="y">The y component of the axis vector to rotate about.</param>
			/// <param name="z">The z component of the axis vector to rotate about.</param>
			/// <returns>The result of the rotation.</returns>
			public delegate Vector<T> Vector_RotateBy(Vector<T> vector, T angle, T x, T y, T z);
			/// <summary>Computes the linear interpolation between two vectors.</summary>
			/// <param name="left">The starting vector of the interpolation.</param>
			/// <param name="right">The ending vector of the interpolation.</param>
			/// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
			/// <returns>The result of the interpolation.</returns>
			public delegate Vector<T> Vector_Lerp(Vector<T> left, Vector<T> right, T blend);
			/// <summary>Sphereically interpolates between two vectors.</summary>
			/// <param name="left">The starting vector of the interpolation.</param>
			/// <param name="right">The ending vector of the interpolation.</param>
			/// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
			/// <returns>The result of the slerp operation.</returns>
			public delegate Vector<T> Vector_Slerp(Vector<T> left, Vector<T> right, T blend);
			/// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
			/// <param name="a">The first vector of the interpolation.</param>
			/// <param name="b">The second vector of the interpolation.</param>
			/// <param name="c">The thrid vector of the interpolation.</param>
			/// <param name="u">The "U" value of the barycentric interpolation equation.</param>
			/// <param name="v">The "V" value of the barycentric interpolation equation.</param>
			/// <returns>The resulting vector of the barycentric interpolation.</returns>
			public delegate Vector<T> Vector_Blerp(Vector<T> a, Vector<T> b, Vector<T> c, T u, T v);
			/// <summary>Does a value equality check.</summary>
			/// <param name="left">The first vector to check for equality.</param>
			/// <param name="right">The second vector to check for equality.</param>
			/// <returns>True if values are equal, false if not.</returns>
			public delegate bool Vector_EqualsValue(Vector<T> left, Vector<T> right);
			/// <summary>Does a value equality check with leniency.</summary>
			/// <param name="left">The first vector to check for equality.</param>
			/// <param name="right">The second vector to check for equality.</param>
			/// <param name="leniency">How much the values can vary but still be considered equal.</param>
			/// <returns>True if values are equal, false if not.</returns>
			public delegate bool Vector_EqualsValue_leniency(Vector<T> left, Vector<T> right, T leniency);
			/// <summary>Rotates a vector by a quaternion.</summary>
			/// <param name="vector">The vector to rotate.</param>
			/// <param name="rotation">The quaternion to rotate the 3-component vector by.</param>
			/// <returns>The result of the rotation.</returns>
			public delegate Vector<T> Vector_RotateBy_quaternion(Vector<T> vector, Quaternion<T> rotation);

			#endregion

			#region matrix

			/// <summary>Creates a zero matrix of the given dimensions.</summary>
			/// <param name="rows">The row count of the desired matrix.</param>
			/// <param name="columns">The column count of the desired matrix.</param>
			/// <returns>A zero matrix of the desired dimensions.</returns>
			public delegate Matrix<T> Matrix_FactoryZero(int rows, int columns);
			/// <summary>Creates a ones matrix of the given dimensions.</summary>
			/// <param name="rows">The row count of the desired matrix.</param>
			/// <param name="columns">The column count of the desired matrix.</param>
			/// <returns>A ones matrix of the desired dimensions.</returns>
			public delegate Matrix<T> Matrix_FactoryOne(int rows, int columns);
			/// <summary>Creates an identity (ones along diagnol, zeros otherwise) matrix of the given dimensions.</summary>
			/// <param name="rows">The row count of the desired matrix.</param>
			/// <param name="columns">The column count of the desired matrix.</param>
			/// <returns>An identity matrix of the desired dimensions.</returns>
			public delegate Matrix<T> Matrix_FactoryIdentity(int rows, int columns);
			/// <summary>Determines if a matrix is symetric.</summary>
			/// <param name="matrix">The matrix to determine symetry on.</param>
			/// <returns>True if the matrix is symetric; false if not.</returns>
			public delegate bool Matrix_IsSymetric(Matrix<T> matrix);
			/// <summary>Negates all the values in a matrix.</summary>
			/// <param name="matrix">The matrix to have its values negated.</param>
			/// <returns>The resulting matrix after the negations.</returns>
			public delegate Matrix<T> Matrix_Negate(Matrix<T> matrix);
			/// <summary>Does standard addition of two matrices.</summary>
			/// <param name="left">The left matrix of the addition.</param>
			/// <param name="right">The right matrix of the addition.</param>
			/// <returns>The resulting matrix after the addition.</returns>
			public delegate Matrix<T> Matrix_Add(Matrix<T> left, Matrix<T> right);
			/// <summary>Subtracts a scalar from all the values in a matrix.</summary>
			/// <param name="left">The matrix to have the values subtracted from.</param>
			/// <param name="right">The scalar to subtract from all the matrix values.</param>
			/// <returns>The resulting matrix after the subtractions.</returns>
			public delegate Matrix<T> Matrix_Subtract(Matrix<T> left, Matrix<T> right);
			/// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
			/// <param name="left">The left matrix of the multiplication.</param>
			/// <param name="right">The right matrix of the multiplication.</param>
			/// <returns>The resulting matrix of the multiplication.</returns>
			public delegate Matrix<T> Matrix_Multiply(Matrix<T> left, Matrix<T> right);
			/// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
			/// <param name="matrix">The left matrix of the multiplication.</param>
			/// <param name="right">The right matrix of the multiplication.</param>
			/// <returns>The resulting matrix of the multiplication.</returns>
			public delegate Vector<T> Matrix_Multiply_vector(Matrix<T> matrix, Vector<T> right);
			/// <summary>Multiplies all the values in a matrix by a scalar.</summary>
			/// <param name="matrix">The matrix to have the values multiplied.</param>
			/// <param name="right">The scalar to multiply the values by.</param>
			/// <returns>The resulting matrix after the multiplications.</returns>
			public delegate Matrix<T> Matrix_Multiply_scalar(Matrix<T> matrix, T right);
			/// <summary>Divides all the values in the matrix by a scalar.</summary>
			/// <param name="left">The matrix to divide the values of.</param>
			/// <param name="right">The scalar to divide all the matrix values by.</param>
			/// <returns>The resulting matrix with the divided values.</returns>
			public delegate Matrix<T> Matrix_Divide(Matrix<T> left, T right);
			/// <summary>Applies a power to a square matrix.</summary>
			/// <param name="matrix">The matrix to be powered by.</param>
			/// <param name="power">The power to apply to the matrix.</param>
			/// <returns>The resulting matrix of the power operation.</returns>
			public delegate Matrix<T> Matrix_Power(Matrix<T> matrix, int power);
			/// <summary>Gets the minor of a matrix.</summary>
			/// <param name="matrix">The matrix to get the minor of.</param>
			/// <param name="row">The restricted row to form the minor.</param>
			/// <param name="column">The restricted column to form the minor.</param>
			/// <returns>The minor of the matrix.</returns>
			public delegate Matrix<T> Matrix_Minor(Matrix<T> matrix, int row, int column);
			/// <summary>Combines two matrices from left to right 
			/// (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
			/// <param name="left">The left matrix of the concatenation.</param>
			/// <param name="right">The right matrix of the concatenation.</param>
			/// <returns>The resulting matrix of the concatenation.</returns>
			public delegate Matrix<T> Matrix_ConcatenateRowWise(Matrix<T> left, Matrix<T> right);
			/// <summary>Calculates the determinent of a square matrix.</summary>
			/// <param name="matrix">The matrix to calculate the determinent of.</param>
			/// <returns>The determinent of the matrix.</returns>
			public delegate T Matrix_Determinent(Matrix<T> matrix);
			/// <summary>Calculates the echelon of a matrix (aka REF).</summary>
			/// <param name="matrix">The matrix to calculate the echelon of (aka REF).</param>
			/// <returns>The echelon of the matrix (aka REF).</returns>
			public delegate Matrix<T> Matrix_Echelon(Matrix<T> matrix);
			/// <summary>Calculates the echelon of a matrix and reduces it (aka RREF).</summary>
			/// <param name="matrix">The matrix matrix to calculate the reduced echelon of (aka RREF).</param>
			/// <returns>The reduced echelon of the matrix (aka RREF).</returns>
			public delegate Matrix<T> Matrix_ReducedEchelon(Matrix<T> matrix);
			/// <summary>Calculates the inverse of a matrix.</summary>
			/// <param name="matrix">The matrix to calculate the inverse of.</param>
			/// <returns>The inverse of the matrix.</returns>
			public delegate Matrix<T> Matrix_Inverse(Matrix<T> matrix);
			/// <summary>Calculates the adjoint of a matrix.</summary>
			/// <param name="matrix">The matrix to calculate the adjoint of.</param>
			/// <returns>The adjoint of the matrix.</returns>
			public delegate Matrix<T> Matrix_Adjoint(Matrix<T> matrix);
			/// <summary>Returns the transpose of a matrix.</summary>
			/// <param name="matrix">The matrix to transpose.</param>
			/// <returns>The transpose of the matrix.</returns>
			public delegate Matrix<T> Matrix_Transpose(Matrix<T> matrix);
			/// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
			/// <param name="matrix">The matrix to decompose.</param>
			/// <param name="lower">The computed lower triangular matrix.</param>
			/// <param name="upper">The computed upper triangular matrix.</param>
			public delegate void Matrix_DecomposeLU(Matrix<T> matrix, out Matrix<T> lower, out Matrix<T> upper);
			/// <summary>Does a value equality check.</summary>
			/// <param name="left">The first matrix to check for equality.</param>
			/// <param name="right">The second matrix to check for equality.</param>
			/// <returns>True if values are equal, false if not.</returns>
			public delegate bool Matrix_EqualsByValue(Matrix<T> left, Matrix<T> right);
			/// <summary>Does a value equality check with leniency.</summary>
			/// <param name="left">The first matrix to check for equality.</param>
			/// <param name="right">The second matrix to check for equality.</param>
			/// <param name="leniency">How much the values can vary but still be considered equal.</param>
			/// <returns>True if values are equal, false if not.</returns>
			public delegate bool Matrix_EqualsByValue_leniency(Matrix<T> left, Matrix<T> right, T leniency);

			public delegate void Matrix_RowMultiplication(Matrix<T> matrix, int row, T scalar);
			public delegate void Matrix_RowAddition(Matrix<T> matrix, int target, int second, T scalar);
			public delegate void Matrix_SwapRows(Matrix<T> matrix, int row1, int row2);

			#endregion

			#region quaternion

			/// <summary>Computes the length of quaternion.</summary>
			/// <param name="quaternion">The quaternion to compute the length of.</param>
			/// <returns>The length of the given quaternion.</returns>
			public delegate T Quaternion_Magnitude(Quaternion<T> quaternion);
			/// <summary>Computes the length of a quaternion, but doesn't square root it.</summary>
			/// <param name="quaternion">The quaternion to compute the length squared of.</param>
			/// <returns>The squared length of the given quaternion.</returns>
			public delegate T Quaternion_MagnitudeSquared(Quaternion<T> quaternion);
			/// <summary>Gets the conjugate of the quaternion.</summary>
			/// <param name="quaternion">The quaternion to conjugate.</param>
			/// <returns>The conjugate of teh given quaternion.</returns>
			public delegate Quaternion<T> Quaternion_Conjugate(Quaternion<T> quaternion);
			/// <summary>Adds two quaternions together.</summary>
			/// <param name="left">The first quaternion of the addition.</param>
			/// <param name="right">The second quaternion of the addition.</param>
			/// <returns>The result of the addition.</returns>
			public delegate Quaternion<T> Quaternion_Add(Quaternion<T> left, Quaternion<T> right);
			/// <summary>Subtracts two quaternions.</summary>
			/// <param name="left">The left quaternion of the subtraction.</param>
			/// <param name="right">The right quaternion of the subtraction.</param>
			/// <returns>The resulting quaternion after the subtraction.</returns>
			public delegate Quaternion<T> Quaternion_Subtract(Quaternion<T> left, Quaternion<T> right);
			/// <summary>Multiplies two quaternions together.</summary>
			/// <param name="left">The first quaternion of the multiplication.</param>
			/// <param name="right">The second quaternion of the multiplication.</param>
			/// <returns>The resulting quaternion after the multiplication.</returns>
			public delegate Quaternion<T> Quaternion_Multiply(Quaternion<T> left, Quaternion<T> right);
			/// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
			/// <param name="left">The quaternion of the multiplication.</param>
			/// <param name="right">The scalar of the multiplication.</param>
			/// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
			public delegate Quaternion<T> Quaternion_Multiply_scalar(Quaternion<T> left, T right);
			/// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
			/// <param name="left">The quaternion to pre-multiply the vector by.</param>
			/// <param name="right">The vector to be multiplied.</param>
			/// <returns>The resulting quaternion of the multiplication.</returns>
			public delegate Quaternion<T> Quaternion_Multiply_Vector(Quaternion<T> left, Vector<T> right);
			/// <summary>Normalizes the quaternion.</summary>
			/// <param name="quaternion">The quaternion to normalize.</param>
			/// <returns>The normalization of the given quaternion.</returns>
			public delegate Quaternion<T> Quaternion_Normalize(Quaternion<T> quaternion);
			/// <summary>Inverts a quaternion.</summary>
			/// <param name="quaternion">The quaternion to find the inverse of.</param>
			/// <returns>The inverse of the given quaternion.</returns>
			public delegate Quaternion<T> Quaternion_Invert(Quaternion<T> quaternion);
			/// <summary>Lenearly interpolates between two quaternions.</summary>
			/// <param name="left">The starting point of the interpolation.</param>
			/// <param name="right">The ending point of the interpolation.</param>
			/// <param name="blend">The ratio 0.0-1.0 of how far to interpolate between the left and right quaternions.</param>
			/// <returns>The result of the interpolation.</returns>
			public delegate Quaternion<T> Quaternion_Lerp(Quaternion<T> left, Quaternion<T> right, T blend);
			/// <summary>Sphereically interpolates between two quaternions.</summary>
			/// <param name="left">The starting point of the interpolation.</param>
			/// <param name="right">The ending point of the interpolation.</param>
			/// <param name="blend">The ratio of how far to interpolate between the left and right quaternions.</param>
			/// <returns>The result of the interpolation.</returns>
			public delegate Quaternion<T> Quaternion_Slerp(Quaternion<T> left, Quaternion<T> right, T blend);
			/// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
			/// <param name="rotation">The quaternion to rotate the vector by.</param>
			/// <param name="vector">The vector to be rotated by.</param>
			/// <returns>The result of the rotation.</returns>
			public delegate Vector<T> Quaternion_Rotate(Quaternion<T> rotation, Vector<T> vector);
			/// <summary>Does a value equality check.</summary>
			/// <param name="left">The first quaternion to check for equality.</param>
			/// <param name="right">The second quaternion to check for equality.</param>
			/// <returns>True if values are equal, false if not.</returns>
			public delegate bool Quaternion_EqualsValue(Quaternion<T> left, Quaternion<T> right);
			/// <summary>Does a value equality check with leniency.</summary>
			/// <param name="left">The first quaternion to check for equality.</param>
			/// <param name="right">The second quaternion to check for equality.</param>
			/// <param name="leniency">How much the values can vary but still be considered equal.</param>
			/// <returns>True if values are equal, false if not.</returns>
			public delegate bool Quaternion_EqualsValue_leniency(Quaternion<T> left, Quaternion<T> right, T leniency);

			#endregion

			#endregion

			#region Combinatorics

			/// <summary>Computes: [ N! ].</summary>
			/// <typeparam name="T">The numeric type of the operation.</typeparam>
			/// <param name="N">The number to compute the factorial of.</param>
			/// <returns>[ N! ]</returns>
			public delegate T Factorial(T N);
			/// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
			/// <typeparam name="T">The numeric type of the operation.</typeparam>
			/// <param name="N">The total number of items in the set.</param>
			/// <param name="n">The number of items in the respective sub-sets.</param>
			/// <returns>[ N! / (n[0]! + n[1]! + n[3]! ...) ]</returns>
			public delegate T Combinations(T N, T[] n);
			/// <summary>Computes: [ N! / (N - n)! ]</summary>
			/// <typeparam name="T">The numeric type of the operation.</typeparam>
			/// <param name="N">The total number of items.</param>
			/// <param name="n">The number of items to choose.</param>
			/// <returns>[ N! / (N - n)! ]</returns>
			public delegate T Choose(T N, T n);

			#endregion

			#region Statistics

			/// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
			/// <param name="stepper">The values to find the mode(s) of.</param>
			/// <returns>A heap containing all the values sorted on their occurence count.</returns>
			public delegate Heap<Link<T, int>> Mode(Stepper<T> stepper);
			/// <summary>Computes the mean (or average) between multiple values.</summary>
			/// <param name="stepper">The operands in the mean operation.</param>
			/// <returns>The mean (or average between the operands).</returns>
			public delegate T Mean(Stepper<T> stepper);
			/// <summary>Computes the median of a set of values.</summary>
			/// <param name="stepper">The values to compute the median of.</param>
			/// <returns>The computed median from the set of values.</returns>
			public delegate T Median(Stepper<T> stepper);
			/// <summary>Computes the geometric mean of a set of values.</summary>
			/// <param name="stepper">The values to compute the geometric mean of.</param>
			/// <returns>The computed geometric mean from the set of values.</returns>
			public delegate T GeometricMean(Stepper<T> stepper);
			/// <summary>Computes the variance of a set of values.</summary>
			/// <param name="stepper">The values to compute the variance of.</param>
			/// <returns>The computed variance from the set of values.</returns>
			public delegate T Variance(Stepper<T> stepper);
			/// <summary>Computes the standard deviation of a set of values.</summary>
			/// <param name="stepper">The values to compute the standard deviation of.</param>
			/// <returns>The computed standard deviation from the set of values.</returns>
			public delegate T StandardDeviation(Stepper<T> stepper);
			/// <summary>Computes the mean deviation of a set of values.</summary>
			/// <param name="stepper">The values to compute the mean deviation of.</param>
			/// <returns>The computed mean deviation from the set of values.</returns>
			public delegate T MeanDeviation(Stepper<T> stepper);
			/// <summary>Computes the range of a set of values.</summary>
			/// <param name="stepper">The values to compute the range of.</param>
			/// <param name="min">The found minimum value.</param>
			/// <param name="max">The found maximum value.</param>
			/// <returns>The computed range from the set of values.</returns>
			public delegate void Range(out T min, out T max, Stepper<T> stepper);
			/// <summary>Computes the quantiles of a set of values.</summary>
			/// <param name="quantiles">The number of quntiles to split the set by.</param>
			/// <param name="stepper">The values to compute the quantiles of.</param>
			/// <returns>The computed quantiles from the set of values.</returns>
			public delegate T[] Quantiles(int quantiles, Stepper<T> stepper);
			/// <summary>Relationship between two random variables or two sets of data.</summary>
			/// <param name="a">One of the two sets to find the correlation of.</param>
			/// <param name="b">One of the two sets to find the correlation of.</param>
			/// <returns>The correlation value.</returns>
			public delegate T Correlation(Stepper<T> a, Stepper<T> b);

			#endregion

			#region Trigonometry

			/// <summary>Computes the ratio [length of the side opposite to the angle / hypotenuse] in a right triangle.</summary>
			/// <param name="angle">The angle to compute the trigonometric function of.</param>
			/// <returns>The computed ratio.</returns>
			public delegate T Sine(Angle<T> angle);
			/// <summary>Computes the ratio [length of the side adjacent to the angle / hypotenuse] in a right triangle.</summary>
			/// <param name="angle">The angle to compute the trigonometric function of.</param>
			/// <returns>The computed ratio.</returns>
			public delegate T Cosine(Angle<T> angle);
			/// <summary>Computes the ratio [length of the side opposite to the angle / length of the side adjacent to the angle] in a right triangle.</summary>
			/// <param name="angle">The angle to compute the trigonometric function of.</param>
			/// <returns>The computed ratio.</returns>
			public delegate T Tangent(Angle<T> angle);
			/// <summary>Computes the ratio [hypotenuse / length of the side opposite to the angle] in a right triangle.</summary>
			/// <param name="angle">The angle to compute the trigonometric function of.</param>
			/// <returns>The computed ratio.</returns>
			public delegate T Cosecant(Angle<T> angle);
			/// <summary>Computes the ratio [hypotenuse / length of the side adjacent to the angle] in a right triangle.</summary>
			/// <param name="angle">The angle to compute the trigonometric function of.</param>
			/// <returns>The computed ratio.</returns>
			public delegate T Secant(Angle<T> angle);
			/// <summary>Computes the ratio [length of the side adjacent to the angle / length of the side opposite to the angle] in a right triangle.</summary>
			/// <param name="angle">The angle to compute the trigonometric function of.</param>
			/// <returns>The computed ratio.</returns>
			public delegate T Cotangent(Angle<T> angle);


			public delegate Angle<T> InverseSine(T ratio);

			public delegate Angle<T> InverseCosine(T ratio);

			public delegate Angle<T> InverseTangent(T ratio);

			public delegate Angle<T> InverseCosecant(T ratio);

			public delegate Angle<T> InverseSecant(T ratio);

			public delegate Angle<T> InverseCotangent(T ratio);


			public delegate T HyperbolicSine(Angle<T> angle);

			public delegate T HyperbolicCosine(Angle<T> angle);

			public delegate T HyperbolicTangent(Angle<T> angle);

			public delegate T HyperbolicCosecant(Angle<T> angle);

			public delegate T HyperbolicSecant(Angle<T> angle);

			public delegate T HyperbolicCotangent(Angle<T> angle);


			public delegate Angle<T> InverseHyperbolicSine(T ratio);

			public delegate Angle<T> InverseHyperbolicCosine(T ratio);

			public delegate Angle<T> InverseHyperbolicTangent(T ratio);

			public delegate Angle<T> InverseHyperbolicCosecant(T ratio);

			public delegate Angle<T> InverseHyperbolicSecant(T ratio);

			public delegate Angle<T> InverseHyperbolicCotangent(T ratio);

			#endregion
		}

		#endregion

		#region Type_String

		private static bool generated_type_string = false;
		private static string type_string;
		private static string Type_String
		{
			get
			{
				if (generated_type_string)
					return type_string;
				return type_string = Meta.ConvertTypeToCsharpSource(typeof(T));
			}
		}

		#endregion

		#region Numeric
		#if show_Numeric
		/// <summary>This type is for development purposes only.</summary>
		public struct Numeric
		{
			#region operator
			public static Numeric operator ++(Numeric generic) { throw new Error("The Numeric type is for development purposes only."); }
			public static Numeric operator -(Numeric generic) { throw new Error("The Numeric type is for development purposes only."); }
			public static Numeric operator +(Numeric left, Numeric right) { throw new Error("The Numeric type is for development purposes only."); }
			public static Numeric operator -(Numeric left, Numeric right) { throw new Error("The Numeric type is for development purposes only."); }
			public static Numeric operator *(Numeric left, Numeric right) { throw new Error("The Numeric type is for development purposes only."); }
			public static Numeric operator /(Numeric left, Numeric right) { throw new Error("The Numeric type is for development purposes only."); }
			public static bool operator ==(Numeric left, Numeric right) { throw new Error("The Numeric type is for development purposes only."); }
			public static bool operator !=(Numeric left, Numeric right) { throw new Error("The Numeric type is for development purposes only."); }
			public static bool operator <(Numeric left, Numeric right) { throw new Error("The Numeric type is for development purposes only."); }
			public static bool operator >(Numeric left, Numeric right) { throw new Error("The Numeric type is for development purposes only."); }
			public static bool operator <=(Numeric left, Numeric right) { throw new Error("The Numeric type is for development purposes only."); }
			public static bool operator >=(Numeric left, Numeric right) { throw new Error("The Numeric type is for development purposes only."); }
			public static explicit operator Numeric(decimal _double) { throw new Error("The Numeric type is for development purposes only."); }
			public static explicit operator Numeric(double _double) { throw new Error("The Numeric type is for development purposes only."); }
			public static implicit operator Numeric(long _long) { throw new Error("The Numeric type is for development purposes only."); }
			public static implicit operator Numeric(string _string) { throw new Error("The Numeric type is for development purposes only."); }
			public static implicit operator string(Numeric generic) { throw new Error("The Numeric type is for development purposes only."); }
			public static explicit operator double(Numeric generic) { throw new Error("The Numeric type is for development purposes only."); }
			public static explicit operator long(Numeric generic) { throw new Error("The Numeric type is for development purposes only."); }
			public static implicit operator int(Numeric generic) { throw new Error("The Numeric type is for development purposes only."); }
			public static Numeric operator %(Numeric left, Numeric right) { throw new Error("The Numeric type is for development purposes only."); }
			public static bool CompareTo(Numeric left, Numeric right) { throw new Error("The Numeric type is for development purposes only."); }
			public static Numeric Parse(string _string) { throw new Error("The Numeric type is for development purposes only."); }
		#endregion
		}
		#endif
		#endregion

		#region Constant

		private const int pi_maximum_iterations = 100;
		// NOTE: decimal accuracy for pi requires pi_maximum_iterations = 92
		private static bool _pi_computed = false;
		private static T _pi;
		/// <summary>The mathematical constant for pi. [3.14159265...]</summary>
		/// <remarks>The accuracy can be adjusted with the "pi_maximum_iterations" constant.</remarks>
		public static T Pi
		{
			get
			{
				if (_pi_computed)
					return _pi;

				// Series: PI = 2 * (1 + 1/3 * (1 + 2/5 * (1 + 3/7 * (...))))
				// more terms in computation inproves accuracy

#if show_Numeric
				if (false)
				{
					Compute<Numeric>.delegates.ComputePi numeric_computation =
						() =>
							{
								int j = 1, max = 1;
								// the actual computation
								Compute<Numeric>.delegates.ComputePi function = null;
								function = () =>
									{
										if (j > max)
											return 1;
										return 1 + j / ((Numeric)2 * (j++) + 1) * function();
									};
								// continually compute with higher accuracy
								Numeric pi = 1, previous = 0;
								for (int i = 1; previous != pi && i < pi_maximum_iterations; i++)
								{
									previous = pi;
									j = 1;
									max = i;
									pi = ((Numeric)2) * function();
								}
								return pi;
						};
					Compute<Numeric>._pi = numeric_computation();
				}
#endif

				Compute<T>.Delegates.ComputePi computation =
					Meta.Compile<Compute<T>.Delegates.ComputePi>(
					string.Concat(
@"() =>
{
	int j = 1, max = 1;
	// the actual computation
	Compute<", Type_String, @">.delegates.ComputePi function = null;
	function = () =>
		{
			if (j > max)
				return 1;
			return 1 + j / ((", Type_String, @")2 * (j++) + 1) * function();
		};
	// continually compute with higher accuracy
	", Type_String, @" pi = 1, previous = 0;
	for (int i = 1; previous != pi && i < ", pi_maximum_iterations, @"; i++)
	{
		previous = pi;
		j = 1;
		max = i;
		pi = ((", Type_String, @")2) * function();
	}
	return pi;
}"));

				Compute<T>._pi = computation();
				Compute<T>._pi_computed = true;
				return _pi;
			}
		}

		internal static Compute<T>.Delegates.IntCast IntCast = (int value) =>
			{
				#if show_Numeric
				Compute<Numeric>.IntCast = (int _value) => { return (Numeric)_value; };
				#endif

				if (!Meta.Validate.Operator.ExplicitCast(typeof(int), typeof(T)) && !Meta.Validate.Operator.ImplicitCast(typeof(int), typeof(T)))
					throw new System.ArithmeticException(string.Concat("casting operator does not exist: implicit/explicit ", Type_String, "(int)"));

				Compute<T>.IntCast = 
					Meta.Compile<Compute<T>.Delegates.IntCast>(
						string.Concat("(int value) => { return (" + Type_String + ")value; }"));

				return Compute<T>.IntCast(value);
			};

		private static bool _zero_computed = false;
		private static T _zero;
		public static T Zero
		{
			get
			{
				if (_zero_computed)
					return _zero;
				_zero = Compute<T>.IntCast(0);
				_zero_computed = true;
				return _zero;
			}
		}

		private static bool _one_computed = false;
		private static T _one;
		public static T One
		{
			get
			{
				if (_one_computed)
					return _one;
				_one = Compute<T>.IntCast(0);
				_one_computed = true;
				return _one;
			}
		}

		#region constants

		private class constants
		{

			#region Mathematical Constants

			/// <summary>The number e</summary>
			public const double E = 2.7182818284590452353602874713526624977572470937000d;

			/// <summary>The number pi</summary>
			public const double Pi = 3.1415926535897932384626433832795028841971693993751d;

			/// <summary>The number ln(10)/20 - factor to convert from Power Decibel (dB) to Neper (Np). Use this version when the Decibel represent a power gain but the compared values are not powers (e.g. amplitude, current, voltage).</summary>
			public const double PowerDecibel = 0.11512925464970228420089957273421821038005507443144d;

			/// <summary>The number ln(10)/10 - factor to convert from Neutral Decibel (dB) to Neper (Np). Use this version when either both or neither of the Decibel and the compared values represent powers.</summary>
			public const double NeutralDecibel = 0.23025850929940456840179914546843642076011014886288d;

			/// <summary>The Catalan constant</summary>
			/// <remarks>Sum(k=0 -> inf){ (-1)^k/(2*k + 1)2 }</remarks>
			public const double Catalan = 0.9159655941772190150546035149323841107741493742816721342664981196217630197762547694794d;

			/// <summary>The Euler-Mascheroni constant</summary>
			/// <remarks>lim(n -> inf){ Sum(k=1 -> n) { 1/k - log(n) } }</remarks>
			public const double EulerMascheroni = 0.5772156649015328606065120900824024310421593359399235988057672348849d;

			/// <summary>The number (1+sqrt(5))/2, also known as the golden ratio</summary>
			public const double GoldenRatio = 1.6180339887498948482045868343656381177203091798057628621354486227052604628189024497072d;

			/// <summary>The Glaisher constant</summary>
			/// <remarks>e^(1/12 - Zeta(-1))</remarks>
			public const double Glaisher = 1.2824271291006226368753425688697917277676889273250011920637400217404063088588264611297d;

			/// <summary>The Khinchin constant</summary>
			/// <remarks>prod(k=1 -> inf){1+1/(k*(k+2))^log(k,2)}</remarks>
			public const double Khinchin = 2.6854520010653064453097148354817956938203822939944629530511523455572188595371520028011d;

			#endregion

			#region UNIVERSAL CONSTANTS

			/// <summary>Speed of Light in Vacuum: c_0 = 2.99792458e8 [m s^-1] (defined, exact; 2007 CODATA)</summary>
			public const double SpeedOfLight = 2.99792458e8;

			/// <summary>Magnetic Permeability in Vacuum: mu_0 = 4*Pi * 10^-7 [N A^-2 = kg m A^-2 s^-2] (defined, exact; 2007 CODATA)</summary>
			public const double MagneticPermeability = 1.2566370614359172953850573533118011536788677597500e-6;

			/// <summary>Electric Permittivity in Vacuum: epsilon_0 = 1/(mu_0*c_0^2) [F m^-1 = A^2 s^4 kg^-1 m^-3] (defined, exact; 2007 CODATA)</summary>
			public const double ElectricPermittivity = 8.8541878171937079244693661186959426889222899381429e-12;

			/// <summary>Characteristic Impedance of Vacuum: Z_0 = mu_0*c_0 [Ohm = m^2 kg s^-3 A^-2] (defined, exact; 2007 CODATA)</summary>
			public const double CharacteristicImpedanceVacuum = 376.73031346177065546819840042031930826862350835242;

			/// <summary>Newtonian Constant of Gravitation: G = 6.67429e-11 [m^3 kg^-1 s^-2] (2007 CODATA)</summary>
			public const double GravitationalConstant = 6.67429e-11;

			/// <summary>Planck's constant: h = 6.62606896e-34 [J s = m^2 kg s^-1] (2007 CODATA)</summary>
			public const double PlancksConstant = 6.62606896e-34;

			/// <summary>Reduced Planck's constant: h_bar = h / (2*Pi) [J s = m^2 kg s^-1] (2007 CODATA)</summary>
			public const double DiracsConstant = 1.054571629e-34;

			/// <summary>Planck mass: m_p = (h_bar*c_0/G)^(1/2) [kg] (2007 CODATA)</summary>
			public const double PlancksMass = 2.17644e-8;

			/// <summary>Planck temperature: T_p = (h_bar*c_0^5/G)^(1/2)/k [K] (2007 CODATA)</summary>
			public const double PlancksTemperature = 1.416786e32;

			/// <summary>Planck length: l_p = h_bar/(m_p*c_0) [m] (2007 CODATA)</summary>
			public const double PlancksLength = 1.616253e-35;

			/// <summary>Planck time: t_p = l_p/c_0 [s] (2007 CODATA)</summary>
			public const double PlancksTime = 5.39124e-44;

			#endregion

			#region ELECTROMAGNETIC CONSTANTS

			/// <summary>Elementary Electron Charge: e = 1.602176487e-19 [C = A s] (2007 CODATA)</summary>
			public const double ElementaryCharge = 1.602176487e-19;

			/// <summary>Magnetic Flux Quantum: theta_0 = h/(2*e) [Wb = m^2 kg s^-2 A^-1] (2007 CODATA)</summary>
			public const double MagneticFluxQuantum = 2.067833668e-15;

			/// <summary>Conductance Quantum: G_0 = 2*e^2/h [S = m^-2 kg^-1 s^3 A^2] (2007 CODATA)</summary>
			public const double ConductanceQuantum = 7.7480917005e-5;

			/// <summary>Josephson Constant: K_J = 2*e/h [Hz V^-1] (2007 CODATA)</summary>
			public const double JosephsonConstant = 483597.891e9;

			/// <summary>Von Klitzing Constant: R_K = h/e^2 [Ohm = m^2 kg s^-3 A^-2] (2007 CODATA)</summary>
			public const double VonKlitzingConstant = 25812.807557;

			/// <summary>Bohr Magneton: mu_B = e*h_bar/2*m_e [J T^-1] (2007 CODATA)</summary>
			public const double BohrMagneton = 927.400915e-26;

			/// <summary>Nuclear Magneton: mu_N = e*h_bar/2*m_p [J T^-1] (2007 CODATA)</summary>
			public const double NuclearMagneton = 5.05078324e-27;

			#endregion

			#region ATOMIC AND NUCLEAR CONSTANTS

			/// <summary>Fine Structure Constant: alpha = e^2/4*Pi*e_0*h_bar*c_0 [1] (2007 CODATA)</summary>
			public const double FineStructureConstant = 7.2973525376e-3;

			/// <summary>Rydberg Constant: R_infty = alpha^2*m_e*c_0/2*h [m^-1] (2007 CODATA)</summary>
			public const double RydbergConstant = 10973731.568528;

			/// <summary>Bor Radius: a_0 = alpha/4*Pi*R_infty [m] (2007 CODATA)</summary>
			public const double BohrRadius = 0.52917720859e-10;

			/// <summary>Hartree Energy: E_h = 2*R_infty*h*c_0 [J] (2007 CODATA)</summary>
			public const double HartreeEnergy = 4.35974394e-18;

			/// <summary>Quantum of Circulation: h/2*m_e [m^2 s^-1] (2007 CODATA)</summary>
			public const double QuantumOfCirculation = 3.6369475199e-4;

			/// <summary>Fermi Coupling Constant: G_F/(h_bar*c_0)^3 [GeV^-2] (2007 CODATA)</summary>
			public const double FermiCouplingConstant = 1.16637e-5;

			/// <summary>Weak Mixin Angle: sin^2(theta_W) [1] (2007 CODATA)</summary>
			public const double WeakMixingAngle = 0.22256;

			/// <summary>Electron Mass: [kg] (2007 CODATA)</summary>
			public const double ElectronMass = 9.10938215e-31;

			/// <summary>Electron Mass Energy Equivalent: [J] (2007 CODATA)</summary>
			public const double ElectronMassEnergyEquivalent = 8.18710438e-14;

			/// <summary>Electron Molar Mass: [kg mol^-1] (2007 CODATA)</summary>
			public const double ElectronMolarMass = 5.4857990943e-7;

			/// <summary>Electron Compton Wavelength: [m] (2007 CODATA)</summary>
			public const double ComptonWavelength = 2.4263102175e-12;

			/// <summary>Classical Electron Radius: [m] (2007 CODATA)</summary>
			public const double ClassicalElectronRadius = 2.8179402894e-15;

			/// <summary>Tomson Cross Section: [m^2] (2002 CODATA)</summary>
			public const double ThomsonCrossSection = 0.6652458558e-28;

			/// <summary>Electron Magnetic Moment: [J T^-1] (2007 CODATA)</summary>
			public const double ElectronMagneticMoment = -928.476377e-26;

			/// <summary>Electon G-Factor: [1] (2007 CODATA)</summary>
			public const double ElectronGFactor = -2.0023193043622;

			/// <summary>Muon Mass: [kg] (2007 CODATA)</summary>
			public const double MuonMass = 1.88353130e-28;

			/// <summary>Muon Mass Energy Equivalent: [J] (2007 CODATA)</summary>
			public const double MuonMassEnegryEquivalent = 1.692833511e-11;

			/// <summary>Muon Molar Mass: [kg mol^-1] (2007 CODATA)</summary>
			public const double MuonMolarMass = 0.1134289256e-3;

			/// <summary>Muon Compton Wavelength: [m] (2007 CODATA)</summary>
			public const double MuonComptonWavelength = 11.73444104e-15;

			/// <summary>Muon Magnetic Moment: [J T^-1] (2007 CODATA)</summary>
			public const double MuonMagneticMoment = -4.49044786e-26;

			/// <summary>Muon G-Factor: [1] (2007 CODATA)</summary>
			public const double MuonGFactor = -2.0023318414;

			/// <summary>Tau Mass: [kg] (2007 CODATA)</summary>
			public const double TauMass = 3.16777e-27;

			/// <summary>Tau Mass Energy Equivalent: [J] (2007 CODATA)</summary>
			public const double TauMassEnergyEquivalent = 2.84705e-10;

			/// <summary>Tau Molar Mass: [kg mol^-1] (2007 CODATA)</summary>
			public const double TauMolarMass = 1.90768e-3;

			/// <summary>Tau Compton Wavelength: [m] (2007 CODATA)</summary>
			public const double TauComptonWavelength = 0.69772e-15;

			/// <summary>Proton Mass: [kg] (2007 CODATA)</summary>
			public const double ProtonMass = 1.672621637e-27;

			/// <summary>Proton Mass Energy Equivalent: [J] (2007 CODATA)</summary>
			public const double ProtonMassEnergyEquivalent = 1.503277359e-10;

			/// <summary>Proton Molar Mass: [kg mol^-1] (2007 CODATA)</summary>
			public const double ProtonMolarMass = 1.00727646677e-3;

			/// <summary>Proton Compton Wavelength: [m] (2007 CODATA)</summary>
			public const double ProtonComptonWavelength = 1.3214098446e-15;

			/// <summary>Proton Magnetic Moment: [J T^-1] (2007 CODATA)</summary>
			public const double ProtonMagneticMoment = 1.410606662e-26;

			/// <summary>Proton G-Factor: [1] (2007 CODATA)</summary>
			public const double ProtonGFactor = 5.585694713;

			/// <summary>Proton Shielded Magnetic Moment: [J T^-1] (2007 CODATA)</summary>
			public const double ShieldedProtonMagneticMoment = 1.410570419e-26;

			/// <summary>Proton Gyro-Magnetic Ratio: [s^-1 T^-1] (2007 CODATA)</summary>
			public const double ProtonGyromagneticRatio = 2.675222099e8;

			/// <summary>Proton Shielded Gyro-Magnetic Ratio: [s^-1 T^-1] (2007 CODATA)</summary>
			public const double ShieldedProtonGyromagneticRatio = 2.675153362e8;

			/// <summary>Neutron Mass: [kg] (2007 CODATA)</summary>
			public const double NeutronMass = 1.674927212e-27;

			/// <summary>Neutron Mass Energy Equivalent: [J] (2007 CODATA)</summary>
			public const double NeutronMassEnegryEquivalent = 1.505349506e-10;

			/// <summary>Neutron Molar Mass: [kg mol^-1] (2007 CODATA)</summary>
			public const double NeutronMolarMass = 1.00866491597e-3;

			/// <summary>Neuron Compton Wavelength: [m] (2007 CODATA)</summary>
			public const double NeutronComptonWavelength = 1.3195908951e-1;

			/// <summary>Neutron Magnetic Moment: [J T^-1] (2007 CODATA)</summary>
			public const double NeutronMagneticMoment = -0.96623641e-26;

			/// <summary>Neutron G-Factor: [1] (2007 CODATA)</summary>
			public const double NeutronGFactor = -3.82608545;

			/// <summary>Neutron Gyro-Magnetic Ratio: [s^-1 T^-1] (2007 CODATA)</summary>
			public const double NeutronGyromagneticRatio = 1.83247185e8;

			/// <summary>Deuteron Mass: [kg] (2007 CODATA)</summary>
			public const double DeuteronMass = 3.34358320e-27;

			/// <summary>Deuteron Mass Energy Equivalent: [J] (2007 CODATA)</summary>
			public const double DeuteronMassEnegryEquivalent = 3.00506272e-10;

			/// <summary>Deuteron Molar Mass: [kg mol^-1] (2007 CODATA)</summary>
			public const double DeuteronMolarMass = 2.013553212725e-3;

			/// <summary>Deuteron Magnetic Moment: [J T^-1] (2007 CODATA)</summary>
			public const double DeuteronMagneticMoment = 0.433073465e-26;

			/// <summary>Helion Mass: [kg] (2007 CODATA)</summary>
			public const double HelionMass = 5.00641192e-27;

			/// <summary>Helion Mass Energy Equivalent: [J] (2007 CODATA)</summary>
			public const double HelionMassEnegryEquivalent = 4.49953864e-10;

			/// <summary>Helion Molar Mass: [kg mol^-1] (2007 CODATA)</summary>
			public const double HelionMolarMass = 3.0149322473e-3;

			/// <summary>Avogadro constant: [mol^-1] (2010 CODATA)</summary>
			public const double Avogadro = 6.0221412927e23;

			#endregion

			#region Scientific Prefixes
			/// <summary>The SI prefix factor corresponding to 1 000 000 000 000 000 000 000 000</summary>
			public const double Yotta = 1e24;

			/// <summary>The SI prefix factor corresponding to 1 000 000 000 000 000 000 000</summary>
			public const double Zetta = 1e21;

			/// <summary>The SI prefix factor corresponding to 1 000 000 000 000 000 000</summary>
			public const double Exa = 1e18;

			/// <summary>The SI prefix factor corresponding to 1 000 000 000 000 000</summary>
			public const double Peta = 1e15;

			/// <summary>The SI prefix factor corresponding to 1 000 000 000 000</summary>
			public const double Tera = 1e12;

			/// <summary>The SI prefix factor corresponding to 1 000 000 000</summary>
			public const double Giga = 1e9;

			/// <summary>The SI prefix factor corresponding to 1 000 000</summary>
			public const double Mega = 1e6;

			/// <summary>The SI prefix factor corresponding to 1 000</summary>
			public const double Kilo = 1e3;

			/// <summary>The SI prefix factor corresponding to 100</summary>
			public const double Hecto = 1e2;

			/// <summary>The SI prefix factor corresponding to 10</summary>
			public const double Deca = 1e1;

			/// <summary>The SI prefix factor corresponding to 0.1</summary>
			public const double Deci = 1e-1;

			/// <summary>The SI prefix factor corresponding to 0.01</summary>
			public const double Centi = 1e-2;

			/// <summary>The SI prefix factor corresponding to 0.001</summary>
			public const double Milli = 1e-3;

			/// <summary>The SI prefix factor corresponding to 0.000 001</summary>
			public const double Micro = 1e-6;

			/// <summary>The SI prefix factor corresponding to 0.000 000 001</summary>
			public const double Nano = 1e-9;

			/// <summary>The SI prefix factor corresponding to 0.000 000 000 001</summary>
			public const double Pico = 1e-12;

			/// <summary>The SI prefix factor corresponding to 0.000 000 000 000 001</summary>
			public const double Femto = 1e-15;

			/// <summary>The SI prefix factor corresponding to 0.000 000 000 000 000 001</summary>
			public const double Atto = 1e-18;

			/// <summary>The SI prefix factor corresponding to 0.000 000 000 000 000 000 001</summary>
			public const double Zepto = 1e-21;

			/// <summary>The SI prefix factor corresponding to 0.000 000 000 000 000 000 000 001</summary>
			public const double Yocto = 1e-24;
			#endregion

		}

		#endregion

		#endregion

		#region Arithmetic

		#region Negate
		/// <summary>Negates a value.</summary>
		public static Compute<T>.Delegates.Negate Negate = (T value) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Negate Negate = (Numeric _value) => { return -_value; };
#endif

			if (!Meta.Validate.Operator.UnaryNegation(typeof(T), typeof(T))) { throw new System.ArithmeticException(string.Concat("computation requires a unary negation operator: ", Type_String, " -(", Type_String, ")")); }

			Compute<T>.Negate =
				Meta.Compile<Compute<T>.Delegates.Negate>(
					string.Concat("(", Type_String, " _value) => { return -_value; }"));

			return Compute<T>.Negate(value);
		};
		#endregion

		#region Add
		/// <summary>Adds two operands together.</summary>
		public static Compute<T>.Delegates.Add Add = (T left, T right) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Add Add = (Numeric _left, Numeric _right) => { return _left + _right; };
#endif

			if (!Meta.Validate.Operator.Addition(typeof(T), typeof(T), typeof(T))) { throw new System.ArithmeticException(string.Concat("computation requires an addition operator: ", Type_String, " +(", Type_String, ", ", Type_String, ")")); }

			Compute<T>.Add =
				Meta.Compile<Compute<T>.Delegates.Add>(
					string.Concat("(", Type_String, " _left, ", Type_String, " _right) => { return _left + _right; }"));

			return Compute<T>.Add(left, right);
		};
		#endregion

		#region Summation
		/// <summary>Compuates the algebraic summation [ Σ (stepper) ].</summary>
		public static Compute<T>.Delegates.Summation Summation = (Stepper<T> stepper) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Summation compile_testing = (Stepper<Numeric> _stepper) => { Numeric sum = 0; _stepper((Numeric i) => { sum += i; }); return sum; };
#endif

			if (!Meta.Validate.Operator.Addition(typeof(T), typeof(T), typeof(T))) { throw new System.ArithmeticException(string.Concat("computation requires an addition operator: ", Type_String, " +(", Type_String, ", ", Type_String, ")")); }

			Compute<T>.Summation =
				Meta.Compile<Compute<T>.Delegates.Summation>(
					string.Concat(
					"(Stepper<", Type_String, "> _stepper) => { ", Type_String, " sum = 0; _stepper((", Type_String, " i) => { sum += i; }); return sum; }"));

			return Compute<T>.Summation(stepper);
		};
		#endregion

		#region Subtract
		/// <summary>Subtracts two operands.</summary>
		public static Compute<T>.Delegates.Subtract Subtract = (T left, T right) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Subtract Add = (Numeric _left, Numeric _right) => { return _left - _right; };
#endif

			if (!Meta.Validate.Operator.Subtraction(typeof(T), typeof(T), typeof(T))) { throw new System.ArithmeticException(string.Concat("computation requires a subtraction operator: ", Type_String, " -(", Type_String, ", ", Type_String, ")")); }

			Compute<T>.Subtract =
				Meta.Compile<Compute<T>.Delegates.Subtract>(
					string.Concat("(", Type_String, " _left, ", Type_String, " _right) => { return _left - _right; }"));

			return Compute<T>.Subtract(left, right);
		};
		#endregion

		#region Multiply
		/// <summary>Multiplies two operands together.</summary>
		public static Compute<T>.Delegates.Multiply Multiply = (T left, T right) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Multiply Add = (Numeric _left, Numeric _right) => { return _left * _right; };
#endif

			if (!Meta.Validate.Operator.Multiplication(typeof(T), typeof(T), typeof(T))) { throw new System.ArithmeticException(string.Concat("computation requires a multiplication operator: ", Type_String, " *(", Type_String, ", ", Type_String, ")")); }

			Compute<T>.Multiply =
				Meta.Compile<Compute<T>.Delegates.Multiply>(
					string.Concat("(", Type_String, " _left, ", Type_String, " _right) => { return _left * _right; }"));

			return Compute<T>.Multiply(left, right);
		};
		#endregion

		#region Divide
		/// <summary>Divides two operands.</summary>
		public static Compute<T>.Delegates.Divide Divide = (T left, T right) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Divide Divide = (Numeric _left, Numeric _right) => { return _left / _right; };
#endif

			if (!Meta.Validate.Operator.Division(typeof(T), typeof(T), typeof(T))) { throw new System.ArithmeticException(string.Concat("computation requires a division operator: ", Type_String, " /(", Type_String, ", ", Type_String, ")")); }

			Compute<T>.Divide =
				Meta.Compile<Compute<T>.Delegates.Divide>(
					string.Concat("(", Type_String, " _left, ", Type_String, " _right) => { return _left / _right; }"));

			return Compute<T>.Divide(left, right);
		};
		#endregion

		#region Power
		/// <summary>Takes one operand to the power of another.</summary>
		public static Compute<T>.Delegates.Power Power = (T left, T right) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Power Power =
				(Numeric _left, Numeric _right) =>
				{
					//Numeric 
					return (Numeric)System.Math.Pow((double)_left, (double)_right);
				};
#endif

			if (typeof(T) == typeof(double))
				Compute<double>.Power = System.Math.Pow;
			if (typeof(T) == typeof(float))
				Compute<float>.Power = (float _left, float _right) => { return (float)System.Math.Pow(_left, _right); };
			if (typeof(T) == typeof(int))
				Compute<int>.Power = (int _left, int _right) => { return (int)System.Math.Pow(_left, _right); };
			else
				Compute<T>.Power =
					Meta.Compile<Compute<T>.Delegates.Power>(
						string.Concat("(", Type_String, " _left, ", Type_String, " _right) => { return (", Type_String, ")System.Math.Pow((double)_left, (double)_right); }"));

			return Compute<T>.Power(left, right);
		};
		#endregion

		#region SquareRoot
		/// <summary>Solves for "x": [ x ^ 2 = b ].</summary>
		public static Compute<T>.Delegates.SquareRoot SquareRoot = (T value) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.SquareRoot compile_testing = (Numeric _value) => { return (Numeric)System.Math.Sqrt((double)_value); };
#endif

			Compute<T>.SquareRoot = Meta.Compile<Compute<T>.Delegates.SquareRoot>(
				string.Concat("(", Type_String, " _value) => { return (", Type_String, ")System.Math.Sqrt((double)_value); }"));

			return Compute<T>.SquareRoot(value);
		};

		/// <summary>Solves for "x": [ x ^ r = b ].</summary>
		public static Compute<T>.Delegates.Root Root = (T _base, T root) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Root compile_testing = (Numeric __base, Numeric _root) => { return (Numeric)System.Math.Pow((double)__base, (double)(1 / _root)); };
#endif

			Compute<T>.Root = Meta.Compile<Compute<T>.Delegates.Root>(
				string.Concat("(", Type_String, " __base, ", Type_String, " _root) => { return (", Type_String, ")System.Math.Pow((double)__base, (double)(1 / _root)); }"));

			return Compute<T>.Root(_base, root);
		};
		#endregion

		#region Logarithm
		/// <summary>Computes: [ log_b(n) ].</summary>
		public static Compute<T>.Delegates.Logarithm Logarithm = (T value, T _base) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.log compile_testing = (Numeric _value, Numeric __base) => { return (Numeric)System.Math.Log((double)_value, (double)__base); };
#endif

			Compute<T>.Logarithm =
				Meta.Compile<Compute<T>.Delegates.Logarithm>(
					string.Concat("(" + Type_String + " _value, " + Type_String + " __base) => { return (" + Type_String + ")System.Math.Log((double)_value, (double)__base); }"));

			return Compute<T>.Logarithm(value, _base);
		};
		#endregion

		#endregion

		#region Logic

		#region AbsoluteValue
		/// <summary>Computes the absolute value of a value.</summary>
		public static Compute<T>.Delegates.AbsoluteValue AbsoluteValue = (T n) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.AbsoluteValue compile_testing =
				(Numeric _n) =>
				{
					if (_n < (Numeric)0)
						return -_n;
					else
						return _n;
				};
#endif

			if (!Meta.Validate.Operator.LessThan(typeof(T), typeof(T), typeof(T)))
			{ throw new System.ArithmeticException(string.Concat("computation requires a less than operator: ", Type_String, " <(", Type_String, ", ", Type_String, ")")); }

			Compute<T>.AbsoluteValue =
				Meta.Compile<Compute<T>.Delegates.AbsoluteValue>(
					string.Concat(
"(", Type_String, @" _n) =>
{
	if (_n < (", Type_String, @")0)
		return -_n;
	else
		return _n;
}"));

			return Compute<T>.AbsoluteValue(n);
		};
		#endregion

		#region Maximum
		/// <summary>Finds the max value in a set.</summary>
		public static Compute<T>.Delegates.Maximum Maximum = (Stepper<T> stepper) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Maximum compile_testing =
				(Stepper<Numeric> _stepper) =>
				{
					bool assigned = false;
					Numeric max = default(Numeric);
					_stepper((Numeric step) =>
					{
						if (!assigned)
							max = step;
						else if (step > max)
							max = step;
					});
					return max;
				};
#endif

			if (!Meta.Validate.Operator.GreaterThan(typeof(T), typeof(T), typeof(T))) { throw new System.ArithmeticException(string.Concat("computation requires a greater than operator: ", Type_String, " >(", Type_String, ", ", Type_String, ")")); }

			Compute<T>.Maximum =
				Meta.Compile<Compute<T>.Delegates.Maximum>(
					string.Concat(
@"(Stepper<", Type_String, @"> _stepper) =>
{
	bool assigned = false;
	", Type_String, " max = default(", Type_String, @");
	_stepper((", Type_String, @" step) =>
	{
			if (!assigned)
				max = step;
			else if (step > max)
				max = step;
	});
	return max;
}"));

			return Compute<T>.Maximum(stepper);
		};
		#endregion

		#region Minimum
		/// <summary>Finds the min value in a set.</summary>
		public static Compute<T>.Delegates.Minimum Minimum = (Stepper<T> stepper) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Minimum compile_testing =
				(Stepper<Numeric> _stepper) =>
				{
					bool assigned = false;
					Numeric min = default(Numeric);
					_stepper((Numeric step) =>
					{
						if (!assigned)
							min = step;
						else if (step < min)
							min = step;
					});
					return min;
				};
#endif

			if (!Meta.Validate.Operator.LessThan(typeof(T), typeof(T), typeof(T))) { throw new System.ArithmeticException(string.Concat("computation requires a less than operator: ", Type_String, " >(", Type_String, ", ", Type_String, ")")); }

			Compute<T>.Minimum =
				Meta.Compile<Compute<T>.Delegates.Minimum>(
					string.Concat(
@"(Stepper<", Type_String, @"> _stepper) =>
{
	bool assigned = false;
	", Type_String, " min = default(", Type_String, @");
	_stepper((", Type_String, @" step) =>
	{
		if (!assigned)
			min = step;
		else if (step < min)
			min = step;
	});
	return min;
}"));

			return Compute<T>.Maximum(stepper);
		};
		#endregion

		#region Clamp
		/// <summary>Restricts a value to a min-max range.</summary>
		public static Compute<T>.Delegates.Clamp Clamp = (T value, T minimum, T maximum) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Clamp compile_testing =
				(Numeric _value, Numeric _minimum, Numeric _maximum) =>
				{
#if no_error_checking
					// nothing
#else
					if (!(_minimum < _maximum)) { throw new Error("!(minimum < maximum)"); }
#endif
					if (_value < _minimum)
						return _minimum;
					else if (_value > _maximum)
						return _maximum;
					else
						return _value;
				};
#endif

			if (!Meta.Validate.Operator.GreaterThan(typeof(T), typeof(T), typeof(T))) { throw new System.ArithmeticException(string.Concat("computation requires a greater than operator: ", Type_String, " >(", Type_String, ", ", Type_String, ")")); }
			if (!Meta.Validate.Operator.LessThan(typeof(T), typeof(T), typeof(T))) { throw new System.ArithmeticException(string.Concat("computation requires a less than operator: ", Type_String, " >(", Type_String, ", ", Type_String, ")")); }

			Compute<T>.Clamp =
				Meta.Compile<Compute<T>.Delegates.Clamp>(
					string.Concat(
@"(", Type_String, " _value, ", Type_String, " _minimum, ", Type_String, @" _maximum) =>
{",
#if no_error_checking
							// nothing
#else
@"		if (!(_minimum < _maximum))
			throw new Error(", "\"!(minimum < maximum)\");",
#endif
@"		if (_value < _minimum)
			return _minimum;
		else if (_value > _maximum)
			return _maximum;
		else
			return _value;
}"));

			return Compute<T>.Clamp(value, minimum, maximum);
		};
		#endregion

		#region EqualsLeniency
		/// <summary>Checks for equality by value with a leniency.</summary>
		public static Compute<T>.Delegates.EqualsLeniency EqualsLeniency = (T left, T right, T leniency) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.EqualsLeniency compile_testing =
					(Numeric _left, Numeric _right, Numeric _leniency) =>
					{
						if (_left < _right)
							return (_right - _left) < _leniency;
						else
							return (_left - _right) < _leniency;
					};
#endif

			if (!Meta.Validate.Operator.Equality(typeof(T), typeof(T), typeof(T))) { throw new System.ArithmeticException(string.Concat("computation requires an equality operator: ", Type_String, " >(", Type_String, ", ", Type_String, ")")); }
			if (!Meta.Validate.Operator.LessThan(typeof(T), typeof(T), typeof(T))) { throw new System.ArithmeticException(string.Concat("computation requires a less than operator: ", Type_String, " >(", Type_String, ", ", Type_String, ")")); }
			if (!Meta.Validate.Operator.Subtraction(typeof(T), typeof(T), typeof(T))) { throw new System.ArithmeticException(string.Concat("computation requires a subtraction operator: ", Type_String, " >(", Type_String, ", ", Type_String, ")")); }
			
			Compute<T>.EqualsLeniency =
				Meta.Compile<Compute<T>.Delegates.EqualsLeniency>(
					string.Concat(
@"(", Type_String, " _left, ", Type_String, " _right, ", Type_String, @" _leniency) =>
{
		if (_left < _right)
			return (_right - _left) < _leniency;
		else
			return (_left - _right) < _leniency;
}"));

			return Compute<T>.EqualsLeniency(left, right, leniency);
		};
		#endregion

		#region Compare
		public static Compare<T> Compare = (T left, T right) =>
		{
#if show_Numeric
			Compare<Numeric> compile_testing =
			(Numeric _left, Numeric _right) =>
			{
				if (_left < _right)
					return Comparison.Less;
				else if (_left > _right)
					return Comparison.Greater;
				else
					return Comparison.Equal;
			};
#endif

			if (!Meta.Validate.Operator.LessThan(typeof(T), typeof(T), typeof(T))) { throw new System.ArithmeticException(string.Concat("computation requires a less than operator: ", Type_String, " >(", Type_String, ", ", Type_String, ")")); }

			Compute<T>.Compare =
				Meta.Compile<Compare<T>>(
					string.Concat(
@"(", Type_String, " _left, ", Type_String, @" _right) =>
{
		if (_left < _right)
			return Comparison.Less;
		else if (_right < _left)
			return Comparison.Greater;
		else
			return Comparison.Equal;
}"));

			return Compute<T>.Compare(left, right);
		};
		#endregion

		#region Equals
		public static Equate<T> Equate = Seven.Equate.Default;
		#endregion

		#endregion

		#region Factors & Multiples

		#region GreatestCommonFactor
		/// <summary>Computes (greatest common factor): [ GCF(set) ].</summary>
		public static Compute<T>.Delegates.GreatestCommonFactor GreatestCommonFactor = (Stepper<T> stepper) =>
		{
#if show_Numeric
			Compute<Numeric>.GreatestCommonFactor =
				(Stepper<Numeric> _stepper) =>
				{
					if (_stepper == null) { throw new System.ArgumentNullException("stepper"); }
					bool assigned = false;
					Numeric gcf = (Numeric)0;
					_stepper((Numeric n) =>
						{
							if (n % (Numeric)1 != 0)
								throw new Error("Attempting to find the Greatest Common Factor of a non-integer value.");
							if (!assigned)
							{
								gcf = Compute<Numeric>.AbsoluteValue(n);
								assigned = true;
							}
							else
							{
								if (gcf > (Numeric)1)
								{
									Numeric a = gcf;
									Numeric b = n;
									while (b != 0)
									{
										Numeric remainder = a % b;
										a = b;
										b = remainder;
									}
									gcf = Compute<Numeric>.AbsoluteValue(a);
								}
							}
						});
					if (!assigned)
						throw new Error("No parameters provided in GCF function.");
					return gcf;
				};
#endif

			Compute<T>.GreatestCommonFactor =
				Meta.Compile<Compute<T>.Delegates.GreatestCommonFactor>(
					string.Concat(
@"(Stepper<", Type_String, @"> _stepper) =>
{
	if (_stepper == null) { throw new System.ArgumentNullException(", "\"stepper\"", @"); }
	bool assigned = false;
	", Type_String, " gcf = (", Type_String, @")0;
	_stepper((", Type_String, @" n) =>
	{
		if (n % (", Type_String, @")1 != 0)
			throw new Error(", "\"Attempting to find the Greatest Common Factor of a non-integer value.\"", @");
		if (!assigned)
		{
			gcf = Compute<", Type_String, @">.AbsoluteValue(n);
			assigned = true;
		}
		else
		{
			if (gcf > (", Type_String, @")1)
			{
				", Type_String, @" a = gcf;
				", Type_String, @" b = n;
				while (b != 0)
				{
					", Type_String, @" remainder = a % b;
					a = b;
					b = remainder;
				}
				gcf = Compute<", Type_String, @">.AbsoluteValue(a);
			}
		}
	});
	if (!assigned)
		throw new Error(", "\"No parameters provided in GCF function.\"", @");
	return gcf;
}"));

			return Compute<T>.GreatestCommonFactor(stepper);
		};
		#endregion

		#region LeastCommonMultiple
		/// <summary>Computes (least common multiple): [ LCM(set) ].</summary>
		public static Compute<T>.Delegates.LeastCommonMultiple LeastCommonMultiple = (Stepper<T> stepper) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.LeastCommonMultiple compile_testing =
				(Stepper<Numeric> _stepper) =>
				{
					if (_stepper == null) { throw new Error("Null reference: stepper"); }
					bool assigned = false;
					Numeric lcm = (Numeric)0;
					_stepper((Numeric n) =>
					{
						if (n == 0)
						{
							lcm = 0;
							return;
						}
						if (n % (Numeric)1 != 0)
							throw new Error("Attempting to find the Greatest Common Factor of a non-integer value.");
						if (!assigned)
						{
							lcm = Compute<Numeric>.AbsoluteValue(n);
							assigned = true;
						}
						else
						{
							if (lcm > (Numeric)1)
							{
								lcm = Compute<Numeric>.AbsoluteValue((lcm / Compute<Numeric>.GreatestCommonFactor((Step<Numeric> step) => { step(lcm); step(n); })) * n);
							}
						}
					});
					if (!assigned)
						throw new Error("No parameters provided in LCM function.");
					return lcm;
				};
#endif

			Compute<T>.LeastCommonMultiple =
				Meta.Compile<Compute<T>.Delegates.LeastCommonMultiple>(
					string.Concat(
@"(Stepper<", Type_String, @"> _stepper) =>
{
	if (_stepper == null) { throw new Error(", "\"Null reference: stepper\"", @"); }
	bool assigned = false;
	", Type_String, " lcm = (", Type_String, @")0;
	_stepper((", Type_String, @" n) =>
	{
		if (n == 0)
		{
			lcm = 0;
			return;
		}
		if (n % (", Type_String, @")1 != 0)
			throw new Error(", "\"Attempting to find the Greatest Common Factor of a non-integer value.\"", @");
		if (!assigned)
		{
			lcm = Compute<", Type_String, @">.AbsoluteValue(n);
			assigned = true;
		}
		else
		{
			if (lcm > (", Type_String, @")1)
			{
				lcm = Compute<", Type_String, ">.AbsoluteValue((lcm / Compute<", Type_String, ">.GreatestCommonFactor((Step<", Type_String, @"> step) => { step(lcm); step(n); })) * n);
			}
		}
	});
	if (!assigned)
		throw new Error(", "\"No parameters provided in LCM function.\"", @");
	return lcm;
}"));

			return Compute<T>.LeastCommonMultiple(stepper);
		};
		#endregion

		#region FactorPrimes
		/// <summary>Computes the prime factors of n.</summary>
		public static Compute<T>.Delegates.FactorPrimes FactorPrimes = (T value, Step<T> step) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.FactorPrimes compile_testing =
					(Numeric _value, Step<Numeric> _step) =>
					{
						Numeric __value = _value;
						if (__value % (Numeric)1 != (Numeric)0)
							throw new Error("Attempting to get the pime factors of a non integer");
						if (__value < 0)
						{
							__value = -__value;
							_step((Numeric)(-1));
						}
						while (__value % (Numeric)2 == (Numeric)0)
						{
							_step((Numeric)2);
							__value /= (Numeric)2;
						}
						for (Numeric i = 3; i <= Compute<Numeric>.SquareRoot(__value); i += (Numeric)2)
						{
							while (__value % i == 0)
							{
								_step(i);
								__value = __value / i;
							}
						}
						if (__value > ((Numeric)2))
							_step(__value);
					};
#endif

			Compute<T>.FactorPrimes =
				Meta.Compile<Compute<T>.Delegates.FactorPrimes>(
					string.Concat(
@"(", Type_String, " _value, Step<", Type_String, @"> _step) =>
{
	", Type_String, @" __value = _value;
	if (__value % (", Type_String, ")1 != (", Type_String, @")0)
		throw new Error(", "\"Attempting to get the pime factors of a non integer\"", @");
	if (__value < 0)
	{
		__value = -__value;
		_step((", Type_String, @")(-1));
	}
	while (__value % (", Type_String, ")2 == (", Type_String, @")0)
	{
		_step((", Type_String, @")2);
		__value /= (", Type_String, @")2;
	}
	for (", Type_String, @" i = 3; i <= Compute<", Type_String, ">.SquareRoot(__value); i += (", Type_String, @")2)
	{
		while (__value % i == 0)
		{
			_step(i);
			__value = __value / i;
		}
	}
	if (__value > ((", Type_String, @")2))
		_step(__value);
}"));

			Compute<T>.FactorPrimes(value, step);
		};
		#endregion

		#endregion

		#region Exponential & Natural Logarithm

		#region Exponential
		/// <summary>Computes: [ e ^ x ].</summary>
		public static Compute<T>.Delegates.Exponential Exponential = (T value) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.exp compile_testing = (Compute<Numeric>.delegates.exp)((Numeric _value) => { throw new Error("not yet implemented"); });
#endif

			Compute<T>.Exponential =
				Meta.Compile<Compute<T>.Delegates.Exponential>(
					string.Concat("(", Type_String, " _value) => { return (", Type_String, ")System.Math.Sqrt((double)_value); }"));

			return Compute<T>.Exponential(value);
		};
		#endregion

		#region Natural Logarithm
		/// <summary>Computes (natrual log): [ ln(n) ].</summary>
		public static Compute<T>.Delegates.NaturalLogarithm NaturalLogarithm = (T value) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.ln compile_testing = (Numeric _value) => { throw new Error("not yet implemented"); };
#endif

			Compute<T>.NaturalLogarithm =
				Meta.Compile<Compute<T>.Delegates.NaturalLogarithm>(
					string.Concat("(", Type_String, " _value) => { throw new Error(\"not yet implemented\"); }"));

			return Compute<T>.NaturalLogarithm(value);
		};
		#endregion

		#endregion

		#region Angles

		/// <summary>Converts degrees to radians.</summary>
		public static Compute<T>.Delegates.DegreesToRadians DegreesToRadians = (T degrees) =>
			{
#if show_Numeric
				Compute<Numeric>.DegreesToRadians = (Numeric _degrees) =>
				{
					return _degrees * Compute<Numeric>.Pi / (Numeric)180;
				};
#endif

				Compute<T>.DegreesToRadians =
					Meta.Compile<Compute<T>.Delegates.DegreesToRadians>(
						string.Concat(
@"(", Type_String, @" _degrees) =>
{
	return _degrees * Compute<", Type_String, ">.Pi / (", Type_String, @")180;
}"));

				return Compute<T>.DegreesToRadians(degrees);
			};

		/// <summary>Converts turns to radians.</summary>
		public static Compute<T>.Delegates.TurnsToRadians TurnsToRadians = (T turns) =>
			{
#if show_Numeric
				Compute<Numeric>.TurnsToRadians = (Numeric _turns) =>
				{
					return _turns * 2 * Compute<Numeric>.Pi;
				};
#endif

				Compute<T>.TurnsToRadians =
					Meta.Compile<Compute<T>.Delegates.TurnsToRadians>(
						string.Concat(
@"(", Type_String, @" _turns) =>
{
	return _turns * 2 * Compute<", Type_String, @">.Pi;
}"));

				return Compute<T>.TurnsToRadians(turns);
			};

		/// <summary>Converts gradians to radians.</summary>
		public static Compute<T>.Delegates.GradiansToRadians GradiansToRadians = (T gradians) =>
			{
#if show_Numeric
				Compute<Numeric>.GradiansToRadians = (Numeric _gradians) =>
				{
					return _gradians * Compute<Numeric>.Pi / (Numeric)200;
				};
#endif

				Compute<T>.GradiansToRadians =
					Meta.Compile<Compute<T>.Delegates.GradiansToRadians>(
						string.Concat(
@"(", Type_String, @" _gradians) =>
{
	return _gradians * Compute<", Type_String, ">.Pi / (", Type_String, @")200;
}"));

				return Compute<T>.GradiansToRadians(gradians);
			};

		/// <summary>Converts radians to degrees.</summary>
		public static Compute<T>.Delegates.RadiansToDegrees RadiansToDegrees = (T radians) =>
			{
#if show_Numeric
				Compute<Numeric>.RadiansToDegrees = (Numeric _radians) =>
				{
					return _radians * (Numeric)180 / Compute<Numeric>.Pi;
				};
#endif

				Compute<T>.RadiansToDegrees =
					Meta.Compile<Compute<T>.Delegates.RadiansToDegrees>(
					 string.Concat(
@"(", Type_String, @" _radians) =>
{
	return _radians * (", Type_String, ")180 / Compute<", Type_String, @">.Pi;
}"));

				return Compute<T>.RadiansToDegrees(radians);
			};

		/// <summary>Converts radians to turns.</summary>
		public static Compute<T>.Delegates.RadiansToTurns RadiansToTurns = (T radians) =>
			{
#if show_Numeric
				Compute<Numeric>.RadiansToTurns = (Numeric _radians) =>
				{
					return _radians / (2 * Compute<Numeric>.Pi);
				};
#endif

				Compute<T>.RadiansToTurns =
					Meta.Compile<Compute<T>.Delegates.RadiansToTurns>(
						string.Concat(
@"(", Type_String, @" _radians) =>
{
	return _radians / (2 * Compute<", Type_String, @">.Pi);
}"));

				return Compute<T>.RadiansToTurns(radians);
			};

		/// <summary>Converts radians to gradians.</summary>
		public static Compute<T>.Delegates.RadiansToGradians RadiansToGradians = (T radians) =>
		{
#if show_Numeric
			Compute<Numeric>.RadiansToGradians = (Numeric _gradians) =>
			{
				return _gradians * (Numeric)200 / Compute<Numeric>.Pi;
			};
#endif

			Compute<T>.RadiansToGradians =
				Meta.Compile<Compute<T>.Delegates.RadiansToGradians>(
					string.Concat(
@"(", Type_String, @" _radians) =>
{
	return _radians * (", Type_String, ")200 / Compute<", Type_String, @">.Pi;
}"));

			return Compute<T>.RadiansToGradians(radians);
		};
		
		#endregion

		#region miscellaneous

		/// <summary>Computes (natrual log): [ ln(n) ].</summary>
		public static Compute<T>.Delegates.IsPrime IsPrime = (T value) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.IsPrime compile_testing =
				(Numeric candidate) =>
				{
					if (candidate % (Numeric)1 == 0)
					{
						if (candidate == 2)
							return true;
						Numeric squareRoot = Compute<Numeric>.SquareRoot(candidate);
						for (int divisor = 3; divisor <= squareRoot; divisor += 2)
							if ((candidate % divisor) == 0)
								return false;
						return true;
					}
					else
						return false;
				};
#endif

			Compute<T>.IsPrime =
				Meta.Compile<Compute<T>.Delegates.IsPrime>(
					string.Concat(
@"(", Type_String, @" candidate) =>
{
	if (candidate % (", Type_String, @")1 == 0)
	{
		if (candidate == 2)
			return true;
		", Type_String, @" squareRoot = Compute<", Type_String, @">.SquareRoot(candidate);
		for (int divisor = 3; divisor <= squareRoot; divisor += 2)
			if ((candidate % divisor) == 0)
				return false;
		return true;
	}
	else
		return false;
}"));

			return Compute<T>.IsPrime(value);
		};

		/// <summary>Computes: [ 1 / n ].</summary>
		public static Compute<T>.Delegates.Invert invert = (T value) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Invert compile_testing = (Numeric _value) => { return 1 / _value; };
#endif

			if (!Meta.Validate.Operator.Division(typeof(T), typeof(T), typeof(T))) { throw new System.ArithmeticException(string.Concat("computation requires a division operator: ", Type_String, " /(", Type_String, ", ", Type_String, ")")); }

			Compute<T>.invert =
				Meta.Compile<Compute<T>.Delegates.Invert>(
					string.Concat("(", Type_String, " _value) => { return 1 / _value; }"));

			return Compute<T>.invert(value);
		};

		#endregion

		#region interpolation

		/// <summary>Interpolates in a linear fashion.</summary>
		public static Compute<T>.Delegates.LinearInterpolation LinearInterpolation = (T x, T x0, T x1, T y0, T y1) =>
			{
#if show_Numeric
				Compute<Numeric>.LinearInterpolation = (Numeric _x, Numeric _x0, Numeric _x1, Numeric _y0, Numeric _y1) =>
					{
						if (_x0 > _x1)
							throw new Error("invalid arguments: x0 > x1");
						else if (_x < _x0)
							throw new Error("invalid arguments: x < x0");
						else if (_x > _x1)
							throw new Error("invalid arguments: x > x1");
						else if (_x0 == _x1)
							if (_y0 != _y1)
								throw new Error("invalid arguments: _x0 == _x1 && _y0 != _y1");
							else
								return _y0;
						else
							return _y0 + (_x - _x0) * (_y1 - _y0) / (_x1 - _x0);
					};
#endif

				Compute<T>.LinearInterpolation =
					Meta.Compile<Compute<T>.Delegates.LinearInterpolation>(
						string.Concat(
@"(", Type_String, " _x, ", Type_String, " _x0, ", Type_String, " _x1, ", Type_String, " _y0, ", Type_String, @" _y1) =>
{
	if (_x0 > _x1)
		throw new Error(", "\"invalid arguments: x0 > x1\"", @");
	else if (_x < _x0)
		throw new Error(", "\"invalid arguments: x < x0\"", @");
	else if (_x > _x1)
		throw new Error(", "\"invalid arguments: x > x1\"", @");
	else if (_x0 == _x1)
		if (_y0 != _y1)
			throw new Error(", "\"invalid arguments: _x0 == _x1 && _y0 != _y1\"", @");
		else
			return _y0;
	else
		return _y0 + (_x - _x0) * (_y1 - _y0) / (_x1 - _x0);
}"));

				return Compute<T>.LinearInterpolation(x, x0, x1, y0, y1);
			};

		#endregion

		#region Linear Algebra

		#region vector

		/// <summary>Adds two vectors together.</summary>
		public static Compute<T>.Delegates.Vector_Add Vector_Add = (Vector<T> left, Vector<T> right) =>
		#region code
		{
			// pre-optimization

			//if (object.ReferenceEquals(left, null))
			//	throw new Error("null reference: left");
			//if (object.ReferenceEquals(right, null))
			//	throw new Error("null reference: right");
			//if (left.Dimensions != right.Dimensions)
			//	throw new Error("invalid dimensions on vector addition.");
			//Vector<T> result =
			//	new Vector<T>(left.Dimensions);
			//for (int i = 0; i < left.Dimensions; i++)
			//	result[i] = Compute<T>.Add(left[i], right[i]);
			//return result;

#if show_Numeric
			Compute<Numeric>.Vector_Add =
				(Vector<Numeric> _left, Vector<Numeric> _right) =>
				{
					if (object.ReferenceEquals(_left, null))
						throw new Error("null reference: _left");
					if (object.ReferenceEquals(_right, null))
						throw new Error("null reference: _right");
					if (_left.Dimensions != _right.Dimensions)
						throw new Error("invalid dimensions on vector addition.");
					int length = _left.Dimensions;
					Vector<Numeric> result =
						new Vector<Numeric>(_left.Dimensions);
					Numeric[] _left_flat = _left._vector;
					Numeric[] _right_flat = _right._vector;
					Numeric[] result_flat = result._vector;
					for (int i = 0; i < length; i++)
						result_flat[i] = _left_flat[i] + _right_flat[i];
					return result;
				};
#endif

			Compute<T>.Vector_Add =
					Meta.Compile<Compute<T>.Delegates.Vector_Add>(
						string.Concat(
@"(Vector<", Type_String, "> _left, Vector<", Type_String, @"> _right) =>
{", System.Environment.NewLine,
#if no_error_checking
	// nothing
#else
@"	if (object.ReferenceEquals(_left, null))
			throw new Error(", "\"null reference: _left\"", @");
	if (object.ReferenceEquals(_right, null))
			throw new Error(", "\"null reference: _right\"", @");
	if (_left.Dimensions != _right.Dimensions)
			throw new Error(", "\"invalid dimensions on vector addition.\"", @");", System.Environment.NewLine,
#endif
@"	int length = _left.Dimensions;
	Vector<", Type_String, @"> result =
		new Vector<", Type_String, @">(_left.Dimensions);
	", Type_String, @"[] _left_flat = _left._vector;
	", Type_String, @"[] _right_flat = _right._vector;
	", Type_String, @"[] result_flat = result._vector;
	for (int i = 0; i < length; i++)
		result_flat[i] = _left_flat[i] + _right_flat[i];
	return result;
}"));

			return Compute<T>.Vector_Add(left, right);
		};
		#endregion

		/// <summary>Negates all the values in a vector.</summary>
		public static Compute<T>.Delegates.Vector_Negate Vector_Negate = (Vector<T> vector) =>
		#region code
		{
			// pre-optimization

			//if (object.ReferenceEquals(vector, null))
			//	throw new Error("null reference: vector");
			//Vector<T> result =
			//	new Vector<T>(vector.Dimensions);
			//for (int i = 0; i < vector.Dimensions; i++)
			//	result[i] = Compute<T>.Negate(vector[i]);
			//return result;

#if show_Numeric
			Compute<Numeric>.delegates.Vector_Negate compile_testing =
				(Vector<Numeric> _vector) =>
				{
#if no_error_checking
					// nothing
#else
					if (object.ReferenceEquals(_vector, null))
						throw new Error("null reference: vector");
#endif
					int length = _vector.Dimensions;
					Vector<Numeric> result =
						new Vector<Numeric>(length);
					Numeric[] vector_flat = _vector._vector;
					Numeric[] result_flat = result._vector;
					for (int i = 0; i < length; i++)
						result_flat[i] = -vector_flat[i];
					return result;
				};
#endif
			
			Compute<T>.Vector_Negate =
					Meta.Compile<Compute<T>.Delegates.Vector_Negate>(
						string.Concat(
@"(Vector<", Type_String, @"> _vector) =>
{", System.Environment.NewLine,
#if no_error_checking
	// nothing
#else
@"	if (object.ReferenceEquals(_vector, null))
		throw new Error(", "\"null reference: vector\"", @");", System.Environment.NewLine,
#endif
@"	int length = _vector.Dimensions;
	Vector<", Type_String, @"> result =
		new Vector<", Type_String, @">(length);
	", Type_String, @"[] vector_flat = _vector._vector;
	", Type_String, @"[] result_flat = result._vector;
	for (int i = 0; i < length; i++)
		result_flat[i] = -vector_flat[i];
	return result;
}"));

			return Compute<T>.Vector_Negate(vector);
		};
		#endregion

		/// <summary>Subtracts two vectors.</summary>
		public static Compute<T>.Delegates.Vector_Subtract Vector_Subtract = (Vector<T> left, Vector<T> right) =>
		#region code
		{
			// pre-optimization

			//if (object.ReferenceEquals(left, null))
			//	throw new Error("null reference: left");
			//if (object.ReferenceEquals(right, null))
			//	throw new Error("null reference: right");
			//if (left.Dimensions != right.Dimensions)
			//	throw new Error("invalid dimensions on vector subtraction.");
			//Vector<T> result =
			//	new Vector<T>(left.Dimensions);
			//for (int i = 0; i < left.Dimensions; i++)
			//	result[i] = Compute<T>.Subtract(left[i], right[i]);
			//return result;

#if show_Numeric
			Compute<Numeric>.delegates.Vector_Subtract compile_testing =
				(Vector<Numeric> _left, Vector<Numeric> _right) =>
				{
#if no_error_checking
#else
					if (object.ReferenceEquals(_left, null))
						throw new Error("null reference: _left");
					if (object.ReferenceEquals(_right, null))
						throw new Error("null reference: _right");
					if (_left.Dimensions != _right.Dimensions)
						throw new Error("invalid dimensions on vector subtraction.");
#endif
					int length = _left.Dimensions;
					Vector<Numeric> result =
						new Vector<Numeric>(length);
					Numeric[] _left_flat = _left._vector;
					Numeric[] _right_flat = _right._vector;
					Numeric[] result_flat = result._vector;
					for (int i = 0; i < length; i++)
						result_flat[i] = _left_flat[i] - _right_flat[i];
					return result;
				};
#endif
			
			Compute<T>.Vector_Subtract =
				Meta.Compile<Compute<T>.Delegates.Vector_Subtract>(
					string.Concat(
@"(Vector<", Type_String, "> _left, Vector<", Type_String, @"> _right) =>
{", System.Environment.NewLine,
#if no_error_checking
	// nothing
#else
 @"	if (object.ReferenceEquals(_left, null))
		throw new Error(", "\"null reference: _left\"", @");
	if (object.ReferenceEquals(_right, null))
		throw new Error(", "\"null reference: _right\"", @");
	if (_left.Dimensions != _right.Dimensions)
		throw new Error(", "\"invalid dimensions on vector subtraction.\"", @");", System.Environment.NewLine,
#endif
 @"	int length = _left.Dimensions;
	Vector<", Type_String, @"> result =
		new Vector<", Type_String, @">(length);
	", Type_String, @"[] _left_flat = _left._vector;
	", Type_String, @"[] _right_flat = _right._vector;
	", Type_String, @"[] result_flat = result._vector;
	for (int i = 0; i < length; i++)
		result_flat[i] = _left_flat[i] - _right_flat[i];
	return result;
}"));

			return Compute<T>.Vector_Subtract(left, right);
		};
		#endregion

		/// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
		public static Compute<T>.Delegates.Vector_Multiply Vector_Multiply = (Vector<T> left, T right) =>
		#region code
		{
			// pre-optimization

			//if (left == null)
			//	throw new Error("null reference: left");
			//if (right == null)
			//	throw new Error("null reference: right");
			//Vector<T> result =
			//	new Vector<T>(left.Dimensions);
			//for (int i = 0; i < left.Dimensions; i++)
			//	result[i] = Compute<T>.Multiply(left[i], right);
			//return result;

#if show_Numeric
			Compute<Numeric>.delegates.Vector_Multiply compile_testing =
				(Vector<Numeric> _left, Numeric _right) =>
				{
#if no_error_checking
					// nothing
#else
					if (object.ReferenceEquals(_left, null))
						throw new Error("null reference: _left");
#endif
					int length = _left.Dimensions;
					Vector<Numeric> result =
						new Vector<Numeric>(length);
					Numeric[] left_flat = _left._vector;
					Numeric[] result_flat = result._vector;
					for (int i = 0; i < length; i++)
						result_flat[i] = left_flat[i] * _right;
					return result;
				};
#endif

			Compute<T>.Vector_Multiply =
				Meta.Compile<Compute<T>.Delegates.Vector_Multiply>(
					string.Concat(
"(Vector<", Type_String, "> _left, ", Type_String, @" _right) =>
{", System.Environment.NewLine,
#if no_error_checking
	// nothing
#else
@"	if (object.ReferenceEquals(_left, null))
			throw new Error(", "\"null reference: _left\"", @");", System.Environment.NewLine,
#endif
@"	int length = _left.Dimensions;
	Vector<", Type_String, @"> result =
		new Vector<", Type_String, @">(length);
	", Type_String, @"[] left_flat = _left._vector;
	", Type_String, @"[] result_flat = result._vector;
	for (int i = 0; i < length; i++)
			result_flat[i] = left_flat[i] * _right;
	return result;
}"));

			return Compute<T>.Vector_Multiply(left, right);
		};
		#endregion

		/// <summary>Divides all the components of a vector by a scalar.</summary>
		public static Compute<T>.Delegates.Vector_Divide Vector_Divide = (Vector<T> vector, T right) =>
		#region code
		{
			// pre-optimization

			//if (vector == null)
			//	throw new System.ArgumentNullException("left");
			//if (right == null)
			//	throw new System.ArgumentNullException("right");
			//Vector<T> result =
			//	new Vector<T>(vector.Dimensions);
			//for (int i = 0; i < vector.Dimensions; i++)
			//	result[i] = Compute<T>.Divide(vector[i], right);
			//return result;

#if show_Numeric
			Compute<Numeric>.delegates.Vector_Divide compile_testing =
				(Vector<Numeric> _left, Numeric _right) =>
				{
#if no_error_checking
					// nothing
#else
					if (vector == null)
						throw new System.ArgumentNullException("left");
					if (right == null)
						throw new System.ArgumentNullException("right");
#endif
					int length = _left.Dimensions;
					Vector<Numeric> result =
						new Vector<Numeric>(length);
					Numeric[] _left_flat = _left._vector;
					Numeric[] result_flat = result._vector;
					for (int i = 0; i < length; i++)
						result_flat[i] = _left_flat[i] / _right;
					return result;
				};
#endif

			Compute<T>.Vector_Divide =
				Meta.Compile<Compute<T>.Delegates.Vector_Divide>(
					string.Concat(
@"(Vector<", Type_String, "> _left, ", Type_String, @" _right) =>
{", System.Environment.NewLine,
#if no_error_checking
	// nothing
#else
 @"	if (object.ReferenceEquals(_left, null))
		throw new Error(", "\"null reference: left\"", @");", System.Environment.NewLine,
#endif
 @"	int length = _left.Dimensions;
	Vector<", Type_String, @"> result =
		new Vector<", Type_String, @">(length);
	", Type_String, @"[] _left_flat = _left._vector;
	", Type_String, @"[] result_flat = result._vector;
	for (int i = 0; i < length; i++)
		result_flat[i] = _left_flat[i] / _right;
	return result;
}"));

			return Compute<T>.Vector_Divide(vector, right);
		};
		#endregion

		/// <summary>Computes the dot product between two vectors.</summary>
		public static Compute<T>.Delegates.Vector_DotProduct Vector_DotProduct = (Vector<T> left, Vector<T> right) =>
		#region code
		{
			#region pre-optimization
			//generic result = 0;
			//for (int i = 0; i < left.Dimensions; i++)
			//	result += left[i] * right[i];
			//return result;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Vector_DotProduct compile_testing =
					(Vector<Numeric> _left, Vector<Numeric> _right) =>
					{
#if no_error_checking
									// nothing
#else
						if (object.ReferenceEquals(_left, null))
							throw new Error("null reference: _left");
						if (object.ReferenceEquals(_right, null))
							throw new Error("null reference: _right");
						if (_left.Dimensions != _right.Dimensions)
							throw new Error("invalid dimensions on vector dot product.");
#endif
						int length = _left.Dimensions;
						Numeric result = 0;
#if unsafe_code
									if (typeof(T).IsValueType)
									{
										unsafe
										{
											fixed (Numeric*
											_left_flat = _left._vector,
											_right_flat = _right._vector)
												for (int i = 0; i < length; i++)
													result += _left_flat[i] * _right_flat[i];
										}
									}
									else
									{
										Numeric[] _left_flat = _left._vector;
										Numeric[] _right_flat = _right._vector;
										for (int i = 0; i < length; i++)
											result += _left_flat[i] * _right_flat[i];
									}
#else
						Numeric[] _left_flat = _left._vector;
						Numeric[] _right_flat = _right._vector;
						for (int i = 0; i < length; i++)
							result += _left_flat[i] * _right_flat[i];
#endif
						return result;
					};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Vector_DotProduct_string =
					"(Vector<" + num + "> _left, Vector<" + num + "> _right) =>" +
					"{" +
#if no_error_checking
									 // nothing
#else
 "	if (object.ReferenceEquals(_left, null))" +
					"		throw new Error(\"null reference: _left\");" +
					"	if (object.ReferenceEquals(_right, null))" +
					"		throw new Error(\"null reference: _right\");" +
					"	if (_left.Dimensions != _right.Dimensions)" +
					"		throw new Error(\"invalid dimensions on vector dot product.\");" +
#endif
 "	int length = _left.Dimensions;" +
					"	" + num + " result = 0;";
#if unsafe_code
									 if (typeof(T).IsValueType)
									 {
										 Vector_DotProduct_string +=
								"		unsafe" +
								"		{" +
								"			fixed (" + num + "*" +
								"			_left_flat = _left._vector," +
								"			_right_flat = _right._vector)" +
								"				for (int i = 0; i < length; i++)" +
								"					result += _left_flat[i] * _right_flat[i];" +
								"		}";
									 }
									 else
									 {
										 Vector_DotProduct_string +=
								"		" + num + "[] _left_flat = _left._vector;" +
								"		" + num + "[] _right_flat = _right._vector;" +
								"		for (int i = 0; i < length; i++)" +
								"			result += _left_flat[i] * _right_flat[i];";
									 }
#else
			Vector_DotProduct_string +=
	 "	" + num + "[] _left_flat = _left._vector;" +
	 "	" + num + "[] _right_flat = _right._vector;" +
	 "	for (int i = 0; i < length; i++)" +
	 "		result += _left_flat[i] * _right_flat[i];";
#endif
			Vector_DotProduct_string +=
	 "	return result;" +
	 "}";

			#endregion

			Compute<T>.Vector_DotProduct =
				Meta.Compile<Compute<T>.Delegates.Vector_DotProduct>(Vector_DotProduct_string);

			return Compute<T>.Vector_DotProduct(left, right);
		};
		#endregion

		/// <summary>Computes teh cross product of two vectors.</summary>
		public static Compute<T>.Delegates.Vector_CrossProduct Vector_CrossProduct = (Vector<T> left, Vector<T> right) =>
		#region code
		{
			#region pre-optimization
			//Vector<generic> result = new Vector<generic>(3);
			//result[0] = left[1] * right[2] - left[2] * right[1];
			//result[1] = left[2] * right[0] - left[0] * right[2];
			//result[2] = left[0] * right[1] - left[1] * right[0];
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Vector_CrossProduct compile_testing =
				(Vector<Numeric> _left, Vector<Numeric> _right) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_left, null))
						throw new Error("null reference: _left");
					if (object.ReferenceEquals(_right, null))
						throw new Error("null reference: _right");
					if (_left.Dimensions != _right.Dimensions)
						throw new Error("invalid cross product (_left.Dimensions != _right.Dimensions)");
					if (_left.Dimensions != 3)
						throw new Error("my cross product function is only defined for 3-component vectors.");
#endif
					Vector<Numeric> result =
						new Vector<Numeric>(3);
#if unsafe_code
								if (typeof(T).IsValueType)
								{
									unsafe
									{
										fixed (Numeric*
											_left_flat = _left._vector,
											_right_flat = _right._vector,
											result_flat = result._vector)
										{
											result_flat[0] = _left_flat[1] * _right_flat[2] - _left_flat[2] * _right_flat[1];
											result_flat[1] = _left_flat[2] * _right_flat[0] - _left_flat[0] * _right_flat[2];
											result_flat[2] = _left_flat[0] * _right_flat[1] - _left_flat[1] * _right_flat[0];
										}
									}
								}
								else
								{
									Numeric[] _left_flat = _left._vector;
									Numeric[] _right_flat = _right._vector;
									Numeric[] result_flat = result._vector;
									result_flat[0] = _left_flat[1] * _right_flat[2] - _left_flat[2] * _right_flat[1];
									result_flat[1] = _left_flat[2] * _right_flat[0] - _left_flat[0] * _right_flat[2];
									result_flat[2] = _left_flat[0] * _right_flat[1] - _left_flat[1] * _right_flat[0];
								}
#else
					Numeric[] _left_flat = _left._vector;
					Numeric[] _right_flat = _right._vector;
					Numeric[] result_flat = result._vector;
					result_flat[0] = _left_flat[1] * _right_flat[2] - _left_flat[2] * _right_flat[1];
					result_flat[1] = _left_flat[2] * _right_flat[0] - _left_flat[0] * _right_flat[2];
					result_flat[2] = _left_flat[0] * _right_flat[1] - _left_flat[1] * _right_flat[0];
#endif
					return result;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Vector_CrossProduct_string =
				"(Vector<" + num + "> _left, Vector<" + num + "> _right) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_left, null))" +
				"		throw new Error(\"null reference: _left\");" +
				"	if (object.ReferenceEquals(_right, null))" +
				"		throw new Error(\"null reference: _right\");" +
				"	if (_left.Dimensions != _right.Dimensions)" +
				"		throw new Error(\"invalid cross product (_left.Dimensions != _right.Dimensions)\");" +
				"	if (_left.Dimensions != 3)" +
				"		throw new Error(\"my cross product function is only defined for 3-component vectors.\");" +
#endif
 "	Vector<" + num + "> result =" +
				"		new Vector<" + num + ">(3);";
#if unsafe_code
								 if (typeof(T).IsValueType)
								 {
									 Vector_CrossProduct_string +=
							"		unsafe" +
							"		{" +
							"			fixed (" + num + "*" +
							"				_left_flat = _left._vector," +
							"				_right_flat = _right._vector," +
							"				result_flat = result._vector)" +
							"			{" +
							"				result_flat[0] = _left_flat[1] * _right_flat[2] - _left_flat[2] * _right_flat[1];" +
							"				result_flat[1] = _left_flat[2] * _right_flat[0] - _left_flat[0] * _right_flat[2];" +
							"				result_flat[2] = _left_flat[0] * _right_flat[1] - _left_flat[1] * _right_flat[0];" +
							"			}" +
							"		}";
								 }
								 else
								 {
									 Vector_CrossProduct_string +=
							"		" + num + "[] _left_flat = _left._vector;" +
							"		" + num + "[] _right_flat = _right._vector;" +
							"		" + num + "[] result_flat = result._vector;" +
							"		result_flat[0] = _left_flat[1] * _right_flat[2] - _left_flat[2] * _right_flat[1];" +
							"		result_flat[1] = _left_flat[2] * _right_flat[0] - _left_flat[0] * _right_flat[2];" +
							"		result_flat[2] = _left_flat[0] * _right_flat[1] - _left_flat[1] * _right_flat[0];";
								 }
#else
			Vector_CrossProduct_string +=
	 "	" + num + "[] _left_flat = _left._vector;" +
	 "	" + num + "[] _right_flat = _right._vector;" +
	 "	" + num + "[] result_flat = result._vector;" +
	 "	result_flat[0] = _left_flat[1] * _right_flat[2] - _left_flat[2] * _right_flat[1];" +
	 "	result_flat[1] = _left_flat[2] * _right_flat[0] - _left_flat[0] * _right_flat[2];" +
	 "	result_flat[2] = _left_flat[0] * _right_flat[1] - _left_flat[1] * _right_flat[0];";
#endif
			Vector_CrossProduct_string +=
	 "	return result;" +
	 "}";

			#endregion

			Compute<T>.Vector_CrossProduct =
				Meta.Compile<Compute<T>.Delegates.Vector_CrossProduct>(Vector_CrossProduct_string);

			return Compute<T>.Vector_CrossProduct(left, right);
		};
		#endregion

		/// <summary>Normalizes a vector.</summary>
		public static Compute<T>.Delegates.Vector_Normalize Vector_Normalize = (Vector<T> vector) =>
		#region code
		{
			#region pre-optimization
			//generic magnitude = Vector.Magnitude(vector);
			//if (magnitude != 0)
			//{
			//	Vector<generic> result = 
			//		new Vector<generic>(vector.Dimensions);
			//	for (int i = 0; i < vector.Dimensions; i++)
			//		result[i] = vector[i] / magnitude;
			//	return result;
			//}
			//else
			//	return new generic[vector.Dimensions];
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Vector_Normalize compile_testing =
				(Vector<Numeric> _vector) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_vector, null))
						throw new Error("null reference: _vector");
#endif
					int length = _vector.Dimensions;
					Vector<Numeric> result =
						new Vector<Numeric>(_vector.Dimensions);
					Numeric magnitude = Compute<Numeric>.Vector_Magnitude(_vector);
					if (magnitude != 0)
						return result;
#if unsafe_code
								if (typeof(T).IsValueType)
								{
									unsafe
									{
										fixed (Numeric*
											_vector_flat = _vector._vector,
											result_flat = result._vector)
											for (int i = 0; i < length; i++)
												result_flat[i] = _vector_flat[i] / magnitude;
									}
								}
								else
								{
									Numeric[] _vector_flat = _vector._vector;
									Numeric[] result_flat = result._vector;
									for (int i = 0; i < length; i++)
										result_flat[i] = _vector_flat[i] / magnitude;
								}
#else
					Numeric[] _vector_flat = _vector._vector;
					Numeric[] result_flat = result._vector;
					for (int i = 0; i < length; i++)
						result_flat[i] = _vector_flat[i] / magnitude;
#endif
					return result;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Vector_Normalize_string =
				"(Vector<" + num + "> _vector) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_vector, null))" +
				"		throw new Error(\"null reference: _vector\");" +
#endif
 "	int length = _vector.Dimensions;" +
				"	Vector<" + num + "> result =" +
				"		new Vector<" + num + ">(_vector.Dimensions);" +
				"	" + num + " magnitude = Vector<" + num + ">.Vector_Magnitude(_vector);" +
				"	if (magnitude != 0)" +
				"		return result;";
#if unsafe_code
								 if (typeof(T).IsValueType)
								 {
									 Vector_Normalize_string +=
							"		unsafe" +
							"		{" +
							"			fixed (" + num + "*" +
							"				_vector_flat = _vector.__vector," +
							"				result_flat = result.__vector)" +
							"				for (int i = 0; i < length; i++)" +
							"					result_flat[i] = _vector_flat[i] / magnitude;" +
							"		}";
								 }
								 else
								 {
									 Vector_Normalize_string += 
							"		" + num + "[] _vector_flat = _vector._vector;" +
							"		" + num + "[] result_flat = result._vector;" +
							"		for (int i = 0; i < length; i++)" +
							"			result_flat[i] = _vector_flat[i] / magnitude;";
								 }
#else
			Vector_Normalize_string +=
	 "	" + num + "[] _vector_flat = _vector._vector;" +
	 "	" + num + "[] result_flat = result._vector;" +
	 "	for (int i = 0; i < length; i++)" +
	 "		result_flat[i] = _vector_flat[i] / magnitude;";
#endif
			Vector_Normalize_string +=
	 "	return result;" +
	 "}";

			#endregion

			Compute<T>.Vector_Normalize =
				Meta.Compile<Compute<T>.Delegates.Vector_Normalize>(Vector_Normalize_string);

			return Compute<T>.Vector_Normalize(vector);
		};
		#endregion

		/// <summary>Computes the length of a vector.</summary>
		public static Compute<T>.Delegates.Vector_Magnitude Vector_Magnitude = (Vector<T> vector) =>
		#region code
		{
			#region pre-optimization
			//generic result = 0;
			//for (int i = 0; i < vector.Dimensions; i++)
			//	result += vector[i] * vector[i];
			//return Algebra.sqrt(result);
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Vector_Magnitude compile_testing =
				(Vector<Numeric> _vector) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_vector, null))
						throw new Error("null reference: _vector");
#endif
					int length = _vector.Dimensions;
					Numeric result = 0;
#if unsafe_code
								if (typeof(T).IsValueType)
								{
									unsafe
									{
										fixed (Numeric*
											_vector_flat = _vector._vector)
											for (int i = 0; i < length; i++)
												result += _vector_flat[i] * _vector_flat[i];
									}
								}
								else
								{
									Numeric[] _vector_flat = _vector._vector;
									for (int i = 0; i < length; i++)
										result += _vector_flat[i] * _vector_flat[i];
								}
#else
					Numeric[] _vector_flat = _vector._vector;
					for (int i = 0; i < length; i++)
						result += _vector_flat[i] * _vector_flat[i];
#endif
					return Compute<Numeric>.SquareRoot(result);
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Vector_Magnitude_string =
				"(Vector<" + num + "> _vector) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_vector, null))" +
				"		throw new Error(\"null reference: _vector\");" +
#endif
 "	int length = _vector.Dimensions;" +
				"	" + num + " result = 0;";
#if unsafe_code
								 if (typeof(T).IsValueType)
								 {
									 Vector_Magnitude_string +=
							"		unsafe" +
							"		{" +
							"			fixed (" + num + "*" +
							"				_vector_flat = _vector._vector)" +
							"				for (int i = 0; i < length; i++)" +
							"					result += _vector_flat[i] * _vector_flat[i];" +
							"		}";
								 }
								 else
								 {
									 Vector_Magnitude_string +=
							"		" + num + "[] _vector_flat = _vector._vector;" +
							"		for (int i = 0; i < length; i++)" +
							"			result += _vector_flat[i] * _vector_flat[i];";
								 }
#else
			Vector_Magnitude_string +=
	 "	" + num + "[] _vector_flat = _vector._vector;" +
	 "	for (int i = 0; i < length; i++)" +
	 "		result += _vector_flat[i] * _vector_flat[i];";
#endif
			Vector_Magnitude_string +=
	 "	return Algebra<" + num + ">.sqrt(result);" +
	 "}";

			#endregion

			Compute<T>.Vector_Magnitude =
				Meta.Compile<Compute<T>.Delegates.Vector_Magnitude>(Vector_Magnitude_string);

			return Compute<T>.Vector_Magnitude(vector);
		};
		#endregion

		/// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
		public static Compute<T>.Delegates.Vector_MagnitudeSquared Vector_MagnitudeSquared = (Vector<T> vector) =>
		#region code
		{
			#region pre-optimization
			//generic result = 0;
			//for (int i = 0; i < vector.Dimensions; i++)
			//	result += vector[i] * vector[i];
			//return result;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Vector_MagnitudeSquared compile_testing =
				(Vector<Numeric> _vector) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_vector, null))
						throw new Error("null reference: _vector");
#endif
					int length = _vector.Dimensions;
					Numeric result = 0;
#if unsafe_code
								if (typeof(T).IsValueType)
								{
									unsafe
									{
										fixed (Numeric*
											_vector_flat = _vector._vector)
											for (int i = 0; i < length; i++)
												result += _vector_flat[i] * _vector_flat[i];
									}
								}
								else
								{
									Numeric[] _vector_flat = _vector._vector;
									for (int i = 0; i < length; i++)
										result += _vector_flat[i] * _vector_flat[i];
								}
#else
					Numeric[] _vector_flat = _vector._vector;
					for (int i = 0; i < length; i++)
						result += _vector_flat[i] * _vector_flat[i];
#endif
					return result;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Vector_MagnitudeSquared_string =
				"(Vector<" + num + "> _vector) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_vector, null))" +
				"		throw new Error(\"null reference: _vector\");" +
#endif
 "	int length = _vector.Dimensions;" +
				"	" + num + " result = 0;";
#if unsafe_code
								 if (typeof(T).IsValueType)
								 {
									 Vector_MagnitudeSquared_string +=
							"		unsafe" +
							"		{" +
							"			fixed (" + num + "*" +
							"				_vector_flat = _vector._vector)" +
							"				for (int i = 0; i < length; i++)" +
							"					result += _vector_flat[i] * _vector_flat[i];" +
							"		}";
								 }
								 else
								 {
									 Vector_MagnitudeSquared_string +=
							"		" + num + "[] _vector_flat = _vector._vector;" +
							"		for (int i = 0; i < length; i++)" +
							"			result += _vector_flat[i] * _vector_flat[i];";
								 }
#else
			Vector_MagnitudeSquared_string +=
	 "	" + num + "[] _vector_flat = _vector._vector;" +
	 "	for (int i = 0; i < length; i++)" +
	 "		result += _vector_flat[i] * _vector_flat[i];";
#endif
			Vector_MagnitudeSquared_string +=
	 "	return result;" +
	 "}";

			#endregion

			Compute<T>.Vector_MagnitudeSquared =
				Meta.Compile<Compute<T>.Delegates.Vector_MagnitudeSquared>(Vector_MagnitudeSquared_string);

			return Compute<T>.Vector_MagnitudeSquared(vector);
		};
		#endregion

		/// <summary>Computes the angle between two vectors.</summary>
		public static Compute<T>.Delegates.Vector_Angle Vector_Angle = (Vector<T> first, Vector<T> second) =>
		#region code
		{
			throw new Error("not yet implemented");

			//#region pre-optimization
			//
			//#endregion
			//
			//Vector<generic>.delegates.Vector_Angle compile_testing =
			//	#region code (compile testing)
			//	
			//	#endregion
			//
			//string Vector_Angle_string =
			//	#region code (string)
			//	
			//	#endregion
			//
			//Vector_Angle_string = Vector_Angle_string.Replace("generic", Generate.ToSourceString(typeof(T)));
			//
			//Compute<T>.Vector_Angle =
			//	Generate.Object<Compute<T>.delegates.Vector_Angle>(Vector_Angle_string);
			//
			//return Compute<T>.Vector_Angle(vector);
		};
		#endregion

		/// <summary>Rotates a vector by the specified axis and rotation values.</summary>
		public static Compute<T>.Delegates.Vector_RotateBy Vector_RotateBy = (Vector<T> vector, T angle, T x, T y, T z) =>
		#region code
		{
			throw new Error("not yet implemented");

			//#region pre-optimization

			//#endregion

			//Vector<generic>.delegates.Vector_Angle compile_testing =
			//	#region code (compile testing)

			//	#endregion

			//string Vector_RotateBy_string =
			//	#region code (string)

			//	#endregion

			//Vector_RotateBy_string = Vector_RotateBy_string.Replace("generic", Generate.ToSourceString(typeof(T)));

			//Compute<T>.Vector_RotateBy =
			//	Generate.Object<Compute<T>.delegates.Vector_RotateBy>(Vector_RotateBy_string);

			//return Compute<T>.Vector_RotateBy(vector, angle, x, y, z);
		};
		#endregion

		/// <summary>Computes the linear interpolation between two vectors.</summary>
		public static Compute<T>.Delegates.Vector_Lerp Vector_Lerp = (Vector<T> left, Vector<T> right, T blend) =>
		#region code
		{
			#region pre-optimization
			//Vector<generic> result = new Vector<generic>(left.Dimensions);
			//for (int i = 0; i < left.Dimensions; i++)
			//	result[i] = left[i] + blend * (right[i] - left[i]);
			//return result;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Vector_Lerp compile_testing =
				(Vector<Numeric> _left, Vector<Numeric> _right, Numeric _blend) =>
				{
#if no_error_checking
								// nothing
#else
					if (_blend < 0 || _blend > 1)
						throw new Error("invalid vector lerp _blend value: (_blend < 0.0f || _blend > 1.0f).");
					if (_left.Dimensions != _right.Dimensions)
						throw new Error("invalid vector lerp length: (_left.Dimensions != _right.Dimensions)");
#endif
					int length = _left.Dimensions;
					Vector<Numeric> result =
						new Vector<Numeric>(length);
#if unsafe_code
								if (typeof(T).IsValueType)
								{
									unsafe
									{
										fixed (Numeric*
											_left_flat = _left._vector,
											_right_flat = _right._vector,
											result_flat = result._vector)
											for (int i = 0; i < length; i++)
												result_flat[i] = _left_flat[i] + _blend * (_right_flat[i] - _left_flat[i]);
									}
								}
								else
								{
									Numeric[] _left_flat = _left._vector;
									Numeric[] _right_flat = _right._vector;
									Numeric[] result_flat = result._vector;
									for (int i = 0; i < length; i++)
										result_flat[i] = _left_flat[i] + _blend * (_right_flat[i] - _left_flat[i]);
								}
#else
					Numeric[] _left_flat = _left._vector;
					Numeric[] _right_flat = _right._vector;
					Numeric[] result_flat = result._vector;
					for (int i = 0; i < length; i++)
						result_flat[i] = _left_flat[i] + _blend * (_right_flat[i] - _left_flat[i]);
#endif
					return result;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Vector_Lerp_string =
				"(Vector<" + num + "> _left, Vector<" + num + "> _right, " + num + " _blend) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (_blend < 0 || _blend > 1)" +
				"		throw new Error(\"invalid vector lerp _blend value: (_blend < 0.0f || _blend > 1.0f).\");" +
				"	if (_left.Dimensions != _right.Dimensions)" +
				"		throw new Error(\"invalid vector lerp length: (_left.Dimensions != _right.Dimensions)\");" +
#endif
 "	int length = _left.Dimensions;" +
				"	Vector<" + num + "> result =" +
				"		new Vector<" + num + ">(length);";
#if unsafe_code
								 if (typeof(T).IsValueType)
								 {
									 Vector_Lerp_string +=
							"		unsafe" +
							"		{" +
							"			fixed (" + num + "*" +
							"				_left_flat = _left._vector," +
							"				_right_flat = _right._vector," +
							"				result_flat = result._vector)" +
							"				for (int i = 0; i < length; i++)" +
							"					result_flat[i] = _left_flat[i] + _blend * (_right_flat[i] - _left_flat[i]);" +
							"		}";
								 }
								 else
								 {
									 Vector_Lerp_string +=
							"		" + num + "[] _left_flat = _left._vector;" +
							"		" + num + "[] _right_flat = _right._vector;" +
							"		" + num + "[] result_flat = result._vector;" +
							"		for (int i = 0; i < length; i++)" +
							"			result_flat[i] = _left_flat[i] + _blend * (_right_flat[i] - _left_flat[i]);";
								 }
#else
			Vector_Lerp_string +=
	 "	" + num + "[] _left_flat = _left._vector;" +
	 "	" + num + "[] _right_flat = _right._vector;" +
	 "	" + num + "[] result_flat = result._vector;" +
	 "	for (int i = 0; i < length; i++)" +
	 "		result_flat[i] = _left_flat[i] + _blend * (_right_flat[i] - _left_flat[i]);";
#endif
			Vector_Lerp_string +=
	 "	return result;" +
	 "}";

			#endregion

			Compute<T>.Vector_Lerp =
				Meta.Compile<Compute<T>.Delegates.Vector_Lerp>(Vector_Lerp_string);

			return Compute<T>.Vector_Lerp(left, right, blend);
		};
		#endregion

		/// <summary>Sphereically interpolates between two vectors.</summary>
		public static Compute<T>.Delegates.Vector_Slerp Vector_Slerp = (Vector<T> left, Vector<T> right, T blend) =>
		#region code
		{
			throw new Error("not yet implemented");

			//#region pre-optimization

			//#endregion

			//Vector<generic>.delegates.Vector_Angle compile_testing =
			//	#region code (compile testing)

			//	#endregion

			//string Vector_Slerp_string =
			//	#region code (string)

			//	#endregion

			//Vector_Slerp_string = Vector_Slerp_string.Replace("generic", Generate.ToSourceString(typeof(T)));

			//Compute<T>.Vector_Slerp =
			//	Generate.Object<Compute<T>.delegates.Vector_Slerp>(Vector_Slerp_string);

			//return Compute<T>.Vector_Slerp(left, right, blend);
		};
		#endregion

		/// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
		public static Compute<T>.Delegates.Vector_Blerp Vector_Blerp = (Vector<T> a, Vector<T> b, Vector<T> c, T u, T v) =>
		#region code
		{
			#region pre-optimization
			//return 
			//	Vector.Add(
			//		Vector.Add(
			//			Vector.Multiply(
			//				Vector.Subtract(b, a), u),
			//					Vector.Multiply(
			//						Vector.Subtract(c, a), v)), a);
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Vector_Blerp compile_testing =
				(Vector<Numeric> _a, Vector<Numeric> _b, Vector<Numeric> _c, Numeric _u, Numeric _v) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(a, null))
						throw new Error("null reference: _a");
					if (object.ReferenceEquals(b, null))
						throw new Error("null reference: _b");
					if (object.ReferenceEquals(c, null))
						throw new Error("null reference: _c");
#endif
					return
						Compute<Numeric>.Vector_Add(
							Compute<Numeric>.Vector_Add(
								Compute<Numeric>.Vector_Multiply(
									Compute<Numeric>.Vector_Subtract(_b, _a), _u),
										Compute<Numeric>.Vector_Multiply(
											Compute<Numeric>.Vector_Subtract(_c, _a), _v)), _a);
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Vector_Blerp_string =
				"(Vector<" + num + "> _a, Vector<" + num + "> _b, Vector<" + num + "> _c, " + num + " _u, " + num + " _v) =>" +
				"{" +
#if no_error_checking
							"	// nothing" +
#else
 "	if (object.ReferenceEquals(a, null))" +
				"		throw new Error(\"null reference: _a\");" +
				"	if (object.ReferenceEquals(b, null))" +
				"		throw new Error(\"null reference: _b\");" +
				"	if (object.ReferenceEquals(c, null))" +
				"		throw new Error(\"null reference: _c\");" +
#endif
 "	return" +
				"		Vector<" + num + ">.Vector_Add(" +
				"			Vector<" + num + ">.Vector_Add(" +
				"				Vector<" + num + ">.Vector_Multiply(" +
				"					Vector<" + num + ">.Vector_Subtract(_b, _a), _u)," +
				"						Vector<" + num + ">.Vector_Multiply(" +
				"							Vector<" + num + ">.Vector_Subtract(_c, _a), _v)), _a);" +
				"}";

			#endregion

			Compute<T>.Vector_Blerp =
				Meta.Compile<Compute<T>.Delegates.Vector_Blerp>(Vector_Blerp_string);

			return Compute<T>.Vector_Blerp(a, b, c, u, v);
		};
		#endregion

		/// <summary>Does a value equality check.</summary>
		public static Compute<T>.Delegates.Vector_EqualsValue Vector_EqualsValue = (Vector<T> left, Vector<T> right) =>
		#region code
		{
			#region pre-optimization
			//if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
			//	return true;
			//if (object.ReferenceEquals(left, null))
			//	return false;
			//if (object.ReferenceEquals(right, null))
			//	return false;
			//if (left.Dimensions != right.Dimensions)
			//	return false;
			//for (int i = 0; i < left.Dimensions; i++)
			//	if (left[i] != right[i])
			//		return false;
			//return true;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Vector_EqualsValue compile_testing =
				(Vector<Numeric> _left, Vector<Numeric> _right) =>
				{
					if (object.ReferenceEquals(_left, null) && object.ReferenceEquals(_right, null))
						return true;
					if (object.ReferenceEquals(_left, null))
						return false;
					if (object.ReferenceEquals(_right, null))
						return false;

					if (_left.Dimensions != _right.Dimensions)
						return false;
					for (int i = 0; i < _left.Dimensions; i++)
						if (_left[i] != _right[i])
							return false;
					return true;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Vector_EqualsValue_string =
				"(Vector<" + num + "> _left, Vector<" + num + "> _right) =>" +
				"{" +
#if no_error_checking
							// nothing
#else
 "	if (object.ReferenceEquals(_left, null) && object.ReferenceEquals(_right, null))" +
				"		return true;" +
				"	if (object.ReferenceEquals(_left, null))" +
				"		return false;" +
				"	if (object.ReferenceEquals(_right, null))" +
				"		return false;" +
#endif
 "	if (_left.Dimensions != _right.Dimensions)" +
				"		return false;" +
				"	for (int i = 0; i < _left.Dimensions; i++)" +
				"		if (_left[i] != _right[i])" +
				"			return false;" +
				"	return true;" +
				"}";

			#endregion

			Compute<T>.Vector_EqualsValue =
				Meta.Compile<Compute<T>.Delegates.Vector_EqualsValue>(Vector_EqualsValue_string);

			return Compute<T>.Vector_EqualsValue(left, right);
		};
		#endregion

		/// <summary>Does a value equality check with leniency.</summary>
		public static Compute<T>.Delegates.Vector_EqualsValue_leniency Vector_EqualsValue_leniency = (Vector<T> left, Vector<T> right, T leniency) =>
		#region code
		{
			#region pre-optimization
			//if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
			//	return true;
			//if (object.ReferenceEquals(left, null))
			//	return false;
			//if (object.ReferenceEquals(right, null))
			//	return false;
			//if (left.Dimensions != right.Dimensions)
			//	return false;
			//for (int i = 0; i < left.Dimensions; i++)
			//	if (Logic.Abs(left[i] - right[i]) > leniency)
			//		return false;
			//return true;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Vector_EqualsValue_leniency compile_testing =
				(Vector<Numeric> _left, Vector<Numeric> _right, Numeric _leniency) =>
				{
					if (object.ReferenceEquals(_left, null) && object.ReferenceEquals(_right, null))
						return true;
					if (object.ReferenceEquals(_left, null))
						return false;
					if (object.ReferenceEquals(_right, null))
						return false;
					if (_left.Dimensions != _right.Dimensions)
						return false;
					for (int i = 0; i < _left.Dimensions; i++)
						if (Compute<Numeric>.AbsoluteValue(_left[i] - _right[i]) > _leniency)
							return false;
					return true;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Vector_EqualsValue_leniency_string =
				"(Vector<" + num + "> _left, Vector<" + num + "> _right, " + num + " _leniency) =>" +
				"{" +
				"	if (object.ReferenceEquals(_left, null) && object.ReferenceEquals(_right, null))" +
				"		return true;" +
				"	if (object.ReferenceEquals(_left, null))" +
				"		return false;" +
				"	if (object.ReferenceEquals(_right, null))" +
				"		return false;" +
				"	if (_left.Dimensions != _right.Dimensions)" +
				"		return false;" +
				"	for (int i = 0; i < _left.Dimensions; i++)" +
				"		if (Logic<" + num + ">.Abs(_left[i] - _right[i]) > _leniency)" +
				"			return false;" +
				"	return true;" +
				"}";

			#endregion

			Compute<T>.Vector_EqualsValue_leniency =
				Meta.Compile<Compute<T>.Delegates.Vector_EqualsValue_leniency>(Vector_EqualsValue_leniency_string);

			return Compute<T>.Vector_EqualsValue_leniency(left, right, leniency);
		};
		#endregion

		/// <summary>Rotates a vector by a quaternion.</summary>
		public static Compute<T>.Delegates.Vector_RotateBy_quaternion Vector_RotateBy_quaternion = (Vector<T> vector, Quaternion<T> rotation) =>
		#region code
		{
			return Compute<T>.Quaternion_Rotate(rotation, vector);
		};
		#endregion

		#region generic

		///// <summary>Computes the angle between two vectors.</summary>
		///// <param name="first">The first vector to determine the angle between.</param>
		///// <param name="second">The second vector to determine the angle between.</param>
		///// <returns>The angle between the two vectors in radians.</returns>
		//public static generic Angle(Vector<generic> first, Vector<generic> second)
		//{
		//		throw new Error("requires rational types");

		//		//			#region pre-optimization

		//		//			//return Trigonometry.arccos(
		//		//			//	Vector.DotProduct(first, second) / 
		//		//			//	(Vector.Magnitude(first) * 
		//		//			//	Vector.Magnitude(second)));

		//		//			#endregion

		//		//#if no_error_checking
		//		//			// nothing
		//		//#else
		//		//			if (object.ReferenceEquals(first, null))
		//		//				throw new Error("null reference: first");
		//		//			if (object.ReferenceEquals(second, null))
		//		//				throw new Error("null reference: second");
		//		//#endif

		//		//			return Trigonometry.arccos(
		//		//				Vector.DotProduct(first, second) /
		//		//				(Vector.Magnitude(first) *
		//		//				Vector.Magnitude(second)));
		//		//		}

		//		//		/// <summary>Rotates a 3-component vector by the specified axis and rotation values.</summary>
		//		//		/// <param name="vector">The vector to rotate.</param>
		//		//		/// <param name="angle">The angle of the rotation in radians.</param>
		//		//		/// <param name="x">The x component of the axis vector to rotate about.</param>
		//		//		/// <param name="y">The y component of the axis vector to rotate about.</param>
		//		//		/// <param name="z">The z component of the axis vector to rotate about.</param>
		//		//		/// <returns>The result of the rotation.</returns>
		//		//		public static Vector<generic> RotateBy(Vector<generic> vector, generic angle, generic x, generic y, generic z)
		//		//		{
		//		//			#region pre-optimization

		//		//			//generic sinHalfAngle = Trigonometry.sin(angle / 2);
		//		//			//generic cosHalfAngle = Trigonometry.cos(angle / 2);
		//		//			//x *= sinHalfAngle;
		//		//			//y *= sinHalfAngle;
		//		//			//z *= sinHalfAngle;
		//		//			//generic x2 = cosHalfAngle * vector[0] + y * vector[2] - z * vector[1];
		//		//			//generic y2 = cosHalfAngle * vector[1] + z * vector[0] - x * vector[2];
		//		//			//generic z2 = cosHalfAngle * vector[2] + x * vector[1] - y * vector[0];
		//		//			//generic w2 = -x * vector[0] - y * vector[1] - z * vector[2];
		//		//			//Vector<generic> result = new Vector<generic>();
		//		//			//result[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
		//		//			//result[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
		//		//			//result[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;

		//		//			#endregion

		//		//#if no_error_checking
		//		//			// nothing
		//		//#else
		//		//			if (object.ReferenceEquals(vector, null))
		//		//				throw new Error("null reference: vector");
		//		//			if (vector.Dimensions == 3)
		//		//				throw new Error("my RotateBy() function is only defined for 3-component vectors.");
		//		//#endif

		//		//			Vector<generic> result = new Vector<generic>(3);
		//		//			generic sinHalfAngle = Trigonometry.sin(angle / 2);
		//		//			generic cosHalfAngle = Trigonometry.cos(angle / 2);
		//		//			x *= sinHalfAngle;
		//		//			y *= sinHalfAngle;
		//		//			z *= sinHalfAngle;

		//		//#if unsafe_code
		//		//			unsafe
		//		//			{
		//		//				fixed (generic*
		//		//					vector_flat = vector._vector,
		//		//					result_flat = result._vector)
		//		//				{
		//		//					generic x2 = cosHalfAngle * vector_flat[0] + y * vector_flat[2] - z * vector_flat[1];
		//		//					generic y2 = cosHalfAngle * vector_flat[1] + z * vector_flat[0] - x * vector_flat[2];
		//		//					generic z2 = cosHalfAngle * vector_flat[2] + x * vector_flat[1] - y * vector_flat[0];
		//		//					generic w2 = -x * vector_flat[0] - y * vector_flat[1] - z * vector_flat[2];
		//		//					result_flat[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
		//		//					result_flat[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
		//		//					result_flat[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;
		//		//				}
		//		//			}
		//		//#else
		//		//			generic[] vector_flat = vector._vector;
		//		//			generic[] result_flat = result._vector;
		//		//			generic x2 = cosHalfAngle * vector_flat[0] + y * vector_flat[2] - z * vector_flat[1];
		//		//			generic y2 = cosHalfAngle * vector_flat[1] + z * vector_flat[0] - x * vector_flat[2];
		//		//			generic z2 = cosHalfAngle * vector_flat[2] + x * vector_flat[1] - y * vector_flat[0];
		//		//			generic w2 = -x * vector_flat[0] - y * vector_flat[1] - z * vector_flat[2];
		//		//			result_flat[0] = x * w2 + cosHalfAngle * x2 + y * z2 - z * y2;
		//		//			result_flat[1] = y * w2 + cosHalfAngle * y2 + z * x2 - x * z2;
		//		//			result_flat[2] = z * w2 + cosHalfAngle * z2 + x * y2 - y * x2;
		//		//#endif

		//		//			return result;
		//}

		///// <summary>Rotates a vector by a quaternion rotation.</summary>
		///// <param name="vector">The vector to be rotated.</param>
		///// <param name="quaternion">The rotation to be applied.</param>
		///// <returns>The vector after the rotation.</returns>
		//public static Vector<generic> RotateBy(Vector<generic> vector, Quaternion<generic> quaternion)
		//{
		//		return Rotate(quaternion, vector);
		//}

		///// <summary>Sphereically interpolates between two vectors.</summary>
		///// <param name="left">The starting vector of the interpolation.</param>
		///// <param name="right">The ending vector of the interpolation.</param>
		///// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
		///// <returns>The result of the slerp operation.</returns>
		//public static Vector<generic> Slerp(Vector<generic> left, Vector<generic> right, generic blend)
		//{
		//		throw new Error("requires rational rational types");

		//		//			#region pre-optimization

		//		//			//generic dot = Vector.DotProduct(left, right);
		//		//			//dot = dot < -1 ? -1 : dot;
		//		//			//dot = dot > 1 ? 1 : dot;
		//		//			//generic theta = Trigonometry.arccos(dot) * blend;
		//		//			//return Vector.Multiply(Vector.Add(Vector.Multiply(left, Trigonometry.cos(theta)),
		//		//			//	Vector.Normalize(Vector.Subtract(right, Vector.Multiply(left, dot)))), Trigonometry.sin(theta));

		//		//			#endregion

		//		//#if no_error_checking
		//		//			// nothing
		//		//#else
		//		//			if (object.ReferenceEquals(left, null))
		//		//				throw new Error("null reference: left");
		//		//			if (object.ReferenceEquals(right, null))
		//		//				throw new Error("null reference: right");
		//		//			if (blend < 0 || blend > 1)
		//		//				throw new Error("invalid slerp blend value: (blend < 0.0f || blend > 1.0f).");
		//		//#endif

		//		//			generic dot = Vector.DotProduct(left, right);
		//		//			dot = dot < -1 ? -1 : dot;
		//		//			dot = dot > 1 ? 1 : dot;
		//		//			generic theta = Trigonometry.arccos(dot) * blend;
		//		//			return Vector.Multiply(Vector.Add(Vector.Multiply(left, Trigonometry.cos(theta)),
		//		//				Vector.Normalize(Vector.Subtract(right, Vector.Multiply(left, dot)))), Trigonometry.sin(theta));
		//}

		///// <summary>Does a value equality check with leniency.</summary>
		///// <param name="left">The first matrix to check for equality.</param>
		///// <param name="right">The second matrix to check for equality.</param>
		///// <param name="leniency">How much the values can vary but still be considered equal.</param>
		///// <returns>True if values are equal, false if not.</returns>
		//public static bool EqualsValue(Vector<generic> left, Vector<generic> right, generic leniency)
		//{
		//		#region pre-optimization

		//		//if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
		//		//	return true;
		//		//if (object.ReferenceEquals(left, null))
		//		//	return false;
		//		//if (object.ReferenceEquals(right, null))
		//		//	return false;

		//		//if (left.Dimensions != right.Dimensions)
		//		//	return false;
		//		//for (int i = 0; i < left.Dimensions; i++)
		//		//	if (Logic.Abs(left[i] - right[i]) > leniency)
		//		//		return false;
		//		//return true;

		//		#endregion

		//		if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
		//				return true;
		//		if (object.ReferenceEquals(left, null))
		//				return false;
		//		if (object.ReferenceEquals(right, null))
		//				return false;

		//		if (left.Dimensions != right.Dimensions)
		//				return false;
		//		for (int i = 0; i < left.Dimensions; i++)
		//				if (Logic<generic>.Abs(left[i] - right[i]) > leniency)
		//						return false;
		//		return true;
		//}

		#endregion

		#endregion

		#region matrix

		/// <summary>Creates a zero matrix of the given dimensions.</summary>
		public static Compute<T>.Delegates.Matrix_FactoryZero Matrix_FactoryZero = (int rows, int columns) =>
		#region code
		{
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_FactoryZero compile_testing =
				(int _rows, int _columns) =>
				{
					Matrix<Numeric> matrix;
					try { matrix = new Matrix<Numeric>(_rows, _columns); }
					catch { throw new Error("invalid dimensions."); }
					Numeric[] array = matrix._matrix;
					for (int i = 0; i < array.Length; i++)
						array[0] = 0;
					return matrix;
				};
#endif

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_FactoryZero_string =
				"(int _rows, int _columns) =>" +
				"{" +
				"	Matrix<" + num + "> matrix;" +
				"	try { matrix = new Matrix<" + num + ">(_rows, _columns); }" +
				"	catch { throw new Error(\"invalid dimensions.\"); }" +
				"	" + num + "[] array = matrix._matrix;" +
				"	for (int i = 0; i < array.Length; i++)" +
				"			array[0] = 0;" +
				"	return matrix;" +
				"}";

			#endregion

			Compute<T>.Matrix_FactoryZero =
				Meta.Compile<Compute<T>.Delegates.Matrix_FactoryZero>(Matrix_FactoryZero_string);

			return Compute<T>.Matrix_FactoryZero(rows, columns);
		};
		#endregion

		/// <summary>Creates a ones matrix of the given dimensions.</summary>
		public static Compute<T>.Delegates.Matrix_FactoryOne Matrix_FactoryOne = (int rows, int columns) =>
		#region code
		{
			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_FactoryOne compile_testing =
				(int _rows, int _columns) =>
				{
					Matrix<Numeric> matrix;
					try { matrix = new Matrix<Numeric>(_rows, _columns); }
					catch { throw new Error("invalid dimensions."); }
					Numeric[] array = matrix._matrix;
					for (int i = 0; i < array.Length; i++)
						array[0] = 1;
					return matrix;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_FactoryOne_string =
				"(int _rows, int _columns) =>" +
				"{" +
				"	Matrix<" + num + "> matrix;" +
				"	try { matrix = new Matrix<" + num + ">(_rows, _columns); }" +
				"	catch { throw new Error(\"invalid dimensions.\"); }" +
				"	" + num + "[] array = matrix._matrix;" +
				"	for (int i = 0; i < array.Length; i++)" +
				"			array[0] = 1;" +
				"	return matrix;" +
				"}";

			#endregion

			Compute<T>.Matrix_FactoryOne =
				Meta.Compile<Compute<T>.Delegates.Matrix_FactoryOne>(Matrix_FactoryOne_string);

			return Compute<T>.Matrix_FactoryOne(rows, columns);
		};
		#endregion

		/// <summary>Creates an identity (ones along diagnol, zeros otherwise) matrix of the given dimensions.</summary>
		public static Compute<T>.Delegates.Matrix_FactoryIdentity Matrix_FactoryIdentity = (int rows, int columns) =>
		#region code
		{
			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_FactoryIdentity compile_testing =
				(int _rows, int _columns) =>
				{
					Matrix<Numeric> matrix;
					try { matrix = new Matrix<Numeric>(_rows, _columns); }
					catch { throw new Error("invalid dimensions."); }
					if (_rows <= _columns)
						for (int i = 0; i < _columns; i++)
							matrix[i, i] = 1;
					else
						for (int i = 0; i < _columns; i++)
							matrix[i, i] = 1;
					return matrix;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_FactoryIdentity_string =
				"(int _rows, int _columns) =>" +
				"{" +
				"		Matrix<" + num + "> matrix;" +
				"		try { matrix = new Matrix<" + num + ">(_rows, _columns); }" +
				"		catch { throw new Error(\"invalid dimensions.\"); }" +
				"		if (_rows <= _columns)" +
				"				for (int i = 0; i < _columns; i++)" +
				"						matrix[i, i] = 1;" +
				"		else" +
				"				for (int i = 0; i < _columns; i++)" +
				"						matrix[i, i] = 1;" +
				"		return matrix;" +
				"}";

			#endregion

			Matrix_FactoryIdentity_string = Matrix_FactoryIdentity_string.Replace("generic", Meta.ConvertTypeToCsharpSource(typeof(T)));

			Compute<T>.Matrix_FactoryIdentity =
				Meta.Compile<Compute<T>.Delegates.Matrix_FactoryIdentity>(Matrix_FactoryIdentity_string);

			return Compute<T>.Matrix_FactoryIdentity(rows, columns);
		};
		#endregion

		/// <summary>Determines if a matrix is symetric.</summary>
		public static Compute<T>.Delegates.Matrix_IsSymetric Matrix_IsSymetric = (Matrix<T> matrix) =>
		#region code
		{
			#region pre-optimization
			//if (matrix.Rows != matrix.Columns)
			//	return false;
			//for (int i = 0; i < matrix.Rows; i++)
			//	for (int j = 0; j < matrix.Columns; j++)
			//		if (matrix[i, j] != matrix[j, i])
			//			return false;
			//return true;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_IsSymetric compile_testing =
				(Matrix<Numeric> _matrix) =>
				{
#if no_errorchecking
										//nothing
#else
					if (object.ReferenceEquals(_matrix, null))
						throw new Error("null reference: _matrix");
#endif
					if (_matrix.Rows != _matrix.Columns)
						return false;
					int size = _matrix.Columns;
#if unsafe_code
										if (typeof(T).IsValueType)
										{
											unsafe
											{
												fixed (Numeric* _matrix_flat = _matrix._matrix as Numeric[])
													for (var row = 0; row < size; row++)
														for (var column = row + 1; column < size; column++)
															if (_matrix_flat[row * size + column] != _matrix_flat[column * size + row])
																return false;
											}
										}
										else
										{
											Numeric[] _matrix_flat = _matrix._matrix as Numeric[];
											for (var row = 0; row < size; row++)
												for (var column = row + 1; column < size; column++)
													if (_matrix_flat[row * size + column] != _matrix_flat[column * size + row])
														return false;
										}
#else
					Numeric[] _matrix_flat = _matrix._matrix as Numeric[];
					for (var row = 0; row < size; row++)
						for (var column = row + 1; column < size; column++)
							if (_matrix_flat[row * size + column] != _matrix_flat[column * size + row])
								return false;
#endif
					return true;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_IsSymetric_string =
				"(Matrix<" + num + "> _matrix) =>" +
				"{" +
#if no_error_checking
										 //nothing
#else
 "		if (object.ReferenceEquals(_matrix, null))" +
				"				throw new Error(\"null reference: _matrix\");" +
#endif
 "		if (_matrix.Rows != _matrix.Columns)" +
				"				return false;" +
				"		int size = _matrix.Columns;";
#if unsafe_code
										 if (typeof(T).IsValueType)
										 {
											 Matrix_IsSymetric_string +=
								"			unsafe" +
								"			{" +
								"				fixed (" + num + "* _matrix_flat = _matrix._matrix as " + num + "[])" +
								"					for (var row = 0; row < size; row++)" +
								"						for (var column = row + 1; column < size; column++)" +
								"							if (_matrix_flat[row * size + column] != _matrix_flat[column * size + row])" +
								"								return false;" +
								"			}";
										 }
										 else
										 {
											 Matrix_IsSymetric_string +=
								"			" + num + "[] _matrix_flat = _matrix._matrix as " + num + "[];" +
								"			for (var row = 0; row < size; row++)" +
								"				for (var column = row + 1; column < size; column++)" +
								"					if (_matrix_flat[row * size + column] != _matrix_flat[column * size + row])" +
								"						return false;";
										 }
#else
			Matrix_IsSymetric_string +=
 "		" + num + "[] _matrix_flat = _matrix._matrix as " + num + "[];" +
 "		for (var row = 0; row < size; row++)" +
 "			for (var column = row + 1; column < size; column++)" +
 "				if (_matrix_flat[row * size + column] != _matrix_flat[column * size + row])" +
 "					return false;";
#endif
			Matrix_IsSymetric_string +=
 "		return true;" +
 "}";
			#endregion

			Compute<T>.Matrix_IsSymetric =
			Meta.Compile<Compute<T>.Delegates.Matrix_IsSymetric>(Matrix_IsSymetric_string);

			return Compute<T>.Matrix_IsSymetric(matrix);
		};
		#endregion

		/// <summary>Negates all the values in a matrix.</summary>
		public static Compute<T>.Delegates.Matrix_Negate Matrix_Negate = (Matrix<T> matrix) =>
		#region code
		{
			#region pre-optimization
			//Matrix<generic> result =
			//	new Matrix<generic>(matrix.Rows, matrix.Columns);
			//for (int i = 0; i < matrix.Rows; i++)
			//	for (int j = 0; j < matrix.Rows; j++)
			//		result[i, j] = -matrix[i, j];
			//return result;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_Negate compile_testing =
				(Matrix<Numeric> _matrix) =>
				{
#if no_error_checking
									// nothing
#else
					if (object.ReferenceEquals(_matrix, null))
						throw new Error("null reference: matirx");
#endif
					Matrix<Numeric> result =
						new Matrix<Numeric>(_matrix.Rows, _matrix.Columns);
					int size = result._matrix.Length;
#if unsafe_code
									if (typeof(T).IsValueType)
									{
										unsafe
										{
											fixed (Numeric*
												result_flat = result._matrix as Numeric[],
												_matrix_flat = _matrix._matrix as Numeric[])
													for (int i = 0; i < size; i++)
														result_flat[i] = -_matrix_flat[i];
										}
									}
									else
									{
										Numeric[] result_flat = result._matrix as Numeric[];
										Numeric[] _matrix_flat = _matrix._matrix as Numeric[];
										for (int i = 0; i < size; i++)
											result_flat[i] = -_matrix_flat[i];
									}
#else
					Numeric[] result_flat = result._matrix as Numeric[];
					Numeric[] _matrix_flat = _matrix._matrix as Numeric[];
					for (int i = 0; i < size; i++)
						result_flat[i] = -_matrix_flat[i];
#endif
					return result;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_Negate_string =
					"(Matrix<" + num + "> _matrix) =>" +
					"{" +
#if no_error_checking
									 // nothing
#else
 "	if (object.ReferenceEquals(_matrix, null))" +
					"		throw new Error(\"null reference: matirx\");" +
#endif
 "	Matrix<" + num + "> result =" +
					"		new Matrix<" + num + ">(_matrix.Rows, _matrix.Columns);" +
					"	int size = result._matrix.Length;";
#if unsafe_code
									 if (typeof(T).IsValueType)
									 {
										 Matrix_Negate_string +=
								"		unsafe" +
								"		{" +
								"			fixed (" + num + "*" +
								"				result_flat = result._matrix as " + num + "[]," +
								"				_matrix_flat = _matrix._matrix as " + num + "[])" +
								"					for (int i = 0; i < size; i++)" +
								"						result_flat[i] = -_matrix_flat[i];" +
								"		}";
									 }
									 else
									 {
										 Matrix_Negate_string +=
								"		" + num + "[] result_flat = result._matrix as " + num + "[];" +
								"		" + num + "[] _matrix_flat = _matrix._matrix as " + num + "[];" +
								"		for (int i = 0; i < size; i++)" +
								"			result_flat[i] = -_matrix_flat[i];";
									 }
#else
			Matrix_Negate_string +=
	 "	" + num + "[] result_flat = result._matrix as " + num + "[];" +
	 "	" + num + "[] _matrix_flat = _matrix._matrix as " + num + "[];" +
	 "	for (int i = 0; i < size; i++)" +
	 "			result_flat[i] = -_matrix_flat[i];";
#endif
			Matrix_Negate_string +=
	 "	return result;" +
	 "}";

			#endregion

			Compute<T>.Matrix_Negate =
			Meta.Compile<Compute<T>.Delegates.Matrix_Negate>(Matrix_Negate_string);

			return Compute<T>.Matrix_Negate(matrix);
		};
		#endregion

		/// <summary>Does standard addition of two matrices.</summary>
		public static Compute<T>.Delegates.Matrix_Add Matrix_Add = (Matrix<T> left, Matrix<T> right) =>
		#region code
		{
			#region pre-optimization
			//Matrix<generic> result =
			//	new Matrix<generic>(left.Rows, left.Columns);
			//for (int i = 0; i < left.Rows; i++)
			//	for (int j = 0; j < left.Columns; j++)
			//		result[i, j] = left[i, j] + right[i, j];
			//return result;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_Add compile_testing =
					(Matrix<Numeric> _left, Matrix<Numeric> _right) =>
					{
#if no_error_checking
									// nothing
#else
						if (object.ReferenceEquals(_left, null))
							throw new Error("null reference: _left");
						if (object.ReferenceEquals(_right, null))
							throw new Error("null reference: _right");
						if (_left.Rows != _right.Rows || _left.Columns != _right.Columns)
							throw new Error("invalid matrix addition (dimension miss-match).");
#endif
						Matrix<Numeric> result =
							new Matrix<Numeric>(_left.Rows, _left.Columns);
						int size = _left.Rows * _left.Columns;
#if unsafe_code
									if	(typeof(T).IsValueType)
									{
										unsafe
										{
											fixed (Numeric*
												_left_flat = _left._matrix as Numeric[],
												_right_flat = _right._matrix as Numeric[],
												result_flat = result._matrix as Numeric[])
													for (int i = 0; i < size; i++)
														result_flat[i] = _left_flat[i] + _right_flat[i];
										}
									}
									else
									{
										Numeric[] _left_flat = _left._matrix as Numeric[];
										Numeric[] _right_flat = _right._matrix as Numeric[];
										Numeric[] result_flat = result._matrix as Numeric[];
										for (int i = 0; i < size; i++)
											result_flat[i] = _left_flat[i] + _right_flat[i];
									}
#else
						Numeric[] _left_flat = _left._matrix as Numeric[];
						Numeric[] _right_flat = _right._matrix as Numeric[];
						Numeric[] result_flat = result._matrix as Numeric[];
						for (int i = 0; i < size; i++)
							result_flat[i] = _left_flat[i] + _right_flat[i];
#endif
						return result;
					};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_Add_string =
					"(Matrix<" + num + "> _left, Matrix<" + num + "> _right) =>" +
					"{" +
#if no_error_checking
									 // nothing
#else
 "	if (_left == null)" +
					"			throw new Error(\"null reference: _left\");" +
					"	if (_right == null)" +
					"			throw new Error(\"null reference: _right\");" +
					"	if (_left.Rows != _right.Rows || _left.Columns != _right.Columns)" +
					"			throw new Error(\"invalid matrix addition (dimension miss-match).\");" +
#endif
 "	Matrix<" + num + "> result =" +
					"		new Matrix<" + num + ">(_left.Rows, _left.Columns);" +
					"	int size = _left.Rows * _left.Columns;";
#if unsafe_code
									 if	(typeof(T).IsValueType)
									 {
										 Matrix_Add_string +=
								"		unsafe" +
								"		{" +
								"			fixed (" + num + "*" +
								"				_left_flat = _left._matrix as " + num + "[]," +
								"				_right_flat = _right._matrix as " + num + "[]," +
								"				result_flat = result._matrix as " + num + "[])" +
								"					for (int i = 0; i < size; i++)" +
								"						result_flat[i] = _left_flat[i] + _right_flat[i];" +
								"		}";
									 }
									 else
									 {
										 Matrix_Add_string +=
								"		" + num + "[] _left_flat = _left._matrix as " + num + "[];" +
								"		" + num + "[] _right_flat = _right._matrix as " + num + "[];" +
								"		" + num + "[] result_flat = result._matrix as " + num + "[];" +
								"		for (int i = 0; i < size; i++)" +
								"			result_flat[i] = _left_flat[i] + _right_flat[i];";
									 }
#else
			Matrix_Add_string +=
	 "	" + num + "[] _left_flat = _left._matrix as " + num + "[];" +
	 "	" + num + "[] _right_flat = _right._matrix as " + num + "[];" +
	 "	" + num + "[] result_flat = result._matrix as " + num + "[];" +
	 "	for (int i = 0; i < size; i++)" +
	 "			result_flat[i] = _left_flat[i] + _right_flat[i];";
#endif
			Matrix_Add_string +=
	 "	return result;" +
	 "}";

			#endregion

			Compute<T>.Matrix_Add =
				Meta.Compile<Compute<T>.Delegates.Matrix_Add>(Matrix_Add_string);

			return Compute<T>.Matrix_Add(left, right);
		};
		#endregion

		/// <summary>Subtracts a scalar from all the values in a matrix.</summary>
		public static Compute<T>.Delegates.Matrix_Subtract Matrix_Subtract = (Matrix<T> left, Matrix<T> right) =>
		#region code
		{
			#region pre-optimization
			//Matrix<generic> result =
			//	new Matrix<generic>(left.Rows, left.Columns);
			//for (int i = 0; i < left.Rows; i++)
			//	for (int j = 0; j < left.Columns; j++)
			//		result[i, j] = left[i, j] - right[i, j];
			//return result;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_Subtract compile_testing =
				(Matrix<Numeric> _left, Matrix<Numeric> _right) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_left, null))
						throw new Error("null reference: _left");
					if (object.ReferenceEquals(_right, null))
						throw new Error("null reference: _right");
					if (_left.Rows != _right.Rows || _left.Columns != _right.Columns)
						throw new Error("invalid matrix subtraction (dimension miss-match).");
#endif
					Matrix<Numeric> result =
						new Matrix<Numeric>(_left.Rows, _left.Columns);
					int size = _left.Rows * _left.Columns;
#if unsafe_code
								if (typeof(T).IsValueType)
								{
									unsafe
									{
										fixed (Numeric*
											_left_flat = _left._matrix as Numeric[],
											_right_flat = _right._matrix as Numeric[],
											result_flat = result._matrix as Numeric[])
												for (int i = 0; i < size; i++)
													result_flat[i] = _left_flat[i] - _right_flat[i];
									}
								}
								else
								{
									Numeric[] _left_flat = _left._matrix as Numeric[];
									Numeric[] _right_flat = _right._matrix as Numeric[];
									Numeric[] result_flat = result._matrix as Numeric[];
									for (int i = 0; i < size; i++)
										result_flat[i] = _left_flat[i] - _right_flat[i];
								}
#else
					Numeric[] _left_flat = _left._matrix as Numeric[];
					Numeric[] _right_flat = _right._matrix as Numeric[];
					Numeric[] result_flat = result._matrix as Numeric[];
					for (int i = 0; i < size; i++)
						result_flat[i] = _left_flat[i] - _right_flat[i];
#endif
					return result;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_Subtract_string =
				"(Matrix<" + num + "> _left, Matrix<" + num + "> _right) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_left, null))" +
				"			throw new Error(\"null reference: _left\");" +
				"	if (object.ReferenceEquals(_right, null))" +
				"			throw new Error(\"null reference: _right\");" +
				"	if (_left.Rows != _right.Rows || _left.Columns != _right.Columns)" +
				"			throw new Error(\"invalid matrix subtraction (dimension miss-match).\");" +
#endif
 "	Matrix<" + num + "> result =" +
				"		new Matrix<" + num + ">(_left.Rows, _left.Columns);" +
				"	int size = _left.Rows * _left.Columns;";
#if unsafe_code
								 if (typeof(T).IsValueType)
								 {
									 Matrix_Subtract_string +=
							"		unsafe" +
							"		{" +
							"			fixed (" + num + "*" +
							"				_left_flat = _left._matrix as " + num + "[]," +
							"				_right_flat = _right._matrix as " + num + "[]," +
							"				result_flat = result._matrix as " + num + "[])" +
							"					for (int i = 0; i < size; i++)" +
							"						result_flat[i] = _left_flat[i] - _right_flat[i];" +
							"		}";
								 }
								 else
								 {
									 Matrix_Subtract_string +=
							"		" + num + "[] _left_flat = _left._matrix as " + num + "[];" +
							"		" + num + "[] _right_flat = _right._matrix as " + num + "[];" +
							"		" + num + "[] result_flat = result._matrix as " + num + "[];" +
							"		for (int i = 0; i < size; i++)" +
							"			result_flat[i] = _left_flat[i] - _right_flat[i];";
								 }
#else
			Matrix_Subtract_string +=
	 "	" + num + "[] _left_flat = _left._matrix as " + num + "[];" +
	 "	" + num + "[] _right_flat = _right._matrix as " + num + "[];" +
	 "	" + num + "[] result_flat = result._matrix as " + num + "[];" +
	 "	for (int i = 0; i < size; i++)" +
	 "		result_flat[i] = _left_flat[i] - _right_flat[i];";
#endif
			Matrix_Subtract_string +=
	 "	return result;" +
	 "}";

			#endregion

			Compute<T>.Matrix_Subtract =
				Meta.Compile<Compute<T>.Delegates.Matrix_Subtract>(Matrix_Subtract_string);

			return Compute<T>.Matrix_Subtract(left, right);
		};
		#endregion

		/// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
		public static Compute<T>.Delegates.Matrix_Multiply Matrix_Multiply = (Matrix<T> left, Matrix<T> right) =>
		#region code
		{
			#region pre-optimization
			//if (_left == null)
			//	throw new Error("null reference: _left");
			//if (_right == null)
			//	throw new Error("null reference: _right");
			//if (_left.Columns != _right.Rows)
			//	throw new Error("invalid multiplication (size miss-match).");
			//Matrix<T> result =
			//	new Matrix<T>(left.Rows, right.Columns);
			//for (int i = 0; i < left.Rows; i++)
			//	for (int j = 0; j < right.Columns; j++)
			//		for (int k = 0; k < left.Columns; k++)
			//			result[i, j] = Compute<T>.Add(result[i, j], Compute<T>.Multiply(left[i, k], right[k, j]));
			//return result;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_Multiply compile_testing =
				(Matrix<Numeric> _left, Matrix<Numeric> _right) =>
				{
#if no_error_checking
								// nothing
#else
					if (_left == null)
						throw new Error("null reference: _left");
					if (_right == null)
						throw new Error("null reference: _right");
					if (_left.Columns != _right.Rows)
						throw new Error("invalid multiplication (size miss-match).");
#endif
					Numeric sum;
					int result_rows = _left.Rows;
					int _left_cols = _left.Columns;
					int result_cols = _right.Columns;
					Matrix<Numeric> result =
						new Matrix<Numeric>(result_rows, result_cols);
#if unsafe_code
								if (typeof(T).IsValueType)
								{
									unsafe
									{
										fixed (Numeric*
											result_flat = result._matrix as Numeric[],
											_left_flat = _left._matrix as Numeric[],
											_right_flat = _right._matrix as Numeric[])
												for (int i = 0; i < result_rows; i++)
													for (int j = 0; j < result_cols; j++)
													{
															sum = 0;
															for (int k = 0; k < _left_cols; k++)
																	sum += _left_flat[i * _left_cols + k] * _right_flat[k * result_cols + j];
															result_flat[i * result_cols + j] = sum;
													}
									}
								}
								else
								{
									Numeric[] result_flat = result._matrix as Numeric[];
									Numeric[] _left_flat = _left._matrix as Numeric[];
									Numeric[] _right_flat = _right._matrix as Numeric[];
									for (int i = 0; i < result_rows; i++)
										for (int j = 0; j < result_cols; j++)
										{
												sum = 0;
												for (int k = 0; k < _left_cols; k++)
														sum += _left_flat[i * _left_cols + k] * _right_flat[k * result_cols + j];
												result_flat[i * result_cols + j] = sum;
										}
								}
#else
					Numeric[] result_flat = result._matrix as Numeric[];
					Numeric[] _left_flat = _left._matrix as Numeric[];
					Numeric[] _right_flat = _right._matrix as Numeric[];
					for (int i = 0; i < result_rows; i++)
						for (int j = 0; j < result_cols; j++)
						{
							sum = 0;
							for (int k = 0; k < _left_cols; k++)
								sum += _left_flat[i * _left_cols + k] * _right_flat[k * result_cols + j];
							result_flat[i * result_cols + j] = sum;
						}
#endif
					return result;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_Multiply_string =
				"(Matrix<" + num + "> _left, Matrix<" + num + "> _right) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (_left == null)" +
				"		throw new Error(\"null reference: _left\");" +
				"	if (_right == null)" +
				"		throw new Error(\"null reference: _right\");" +
				"	if (_left.Columns != _right.Rows)" +
				"		throw new Error(\"invalid multiplication (size miss-match).\");" +
#endif
 "	" + num + " sum;" +
				"	int result_rows = _left.Rows;" +
				"	int _left_cols = _left.Columns;" +
				"	int result_cols = _right.Columns;" +
				"	Matrix<" + num + "> result =" +
				"		new Matrix<" + num + ">(result_rows, result_cols);";
#if unsafe_code
								 if (typeof(T).IsValueType)
								 {
									 Matrix_Multiply_string +=
							"		unsafe" +
							"		{" +
							"			fixed (" + num + "*" +
							"				result_flat = result._matrix as " + num + "[]," +
							"				_left_flat = _left._matrix as " + num + "[]," +
							"				_right_flat = _right._matrix as " + num + "[])" +
							"					for (int i = 0; i < result_rows; i++)" +
							"						for (int j = 0; j < result_cols; j++)" +
							"						{" +
							"								sum = 0;" +
							"								for (int k = 0; k < _left_cols; k++)" +
							"										sum += _left_flat[i * _left_cols + k] * _right_flat[k * result_cols + j];" +
							"								result_flat[i * result_cols + j] = sum;" +
							"						}" +
							"		}";
								 }
								 else
								 {
									 Matrix_Multiply_string +=
							"		" + num + "[] result_flat = result._matrix as " + num + "[];" +
							"		" + num + "[] _left_flat = _left._matrix as " + num + "[];" +
							"		" + num + "[] _right_flat = _right._matrix as " + num + "[];" +
							"		for (int i = 0; i < result_rows; i++)" +
							"			for (int j = 0; j < result_cols; j++)" +
							"			{" +
							"					sum = 0;" +
							"					for (int k = 0; k < _left_cols; k++)" +
							"							sum += _left_flat[i * _left_cols + k] * _right_flat[k * result_cols + j];" +
							"					result_flat[i * result_cols + j] = sum;" +
							"			}";
								 }
#else
			Matrix_Multiply_string +=
	"	" + num + "[] result_flat = result._matrix as " + num + "[];" +
	"	" + num + "[] _left_flat = _left._matrix as " + num + "[];" +
	"	" + num + "[] _right_flat = _right._matrix as " + num + "[];" +
	"	for (int i = 0; i < result_rows; i++)" +
	"		for (int j = 0; j < result_cols; j++)" +
	"		{" +
	"			sum = 0;" +
	"			for (int k = 0; k < _left_cols; k++)" +
	"				sum += _left_flat[i * _left_cols + k] * _right_flat[k * result_cols + j];" +
	"			result_flat[i * result_cols + j] = sum;" +
	"		}";
#endif
			Matrix_Multiply_string +=
	"	return result;" +
	"}";

			#endregion

			Compute<T>.Matrix_Multiply =
				Meta.Compile<Compute<T>.Delegates.Matrix_Multiply>(Matrix_Multiply_string);

			return Compute<T>.Matrix_Multiply(left, right);
		};
		#endregion

		/// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
		public static Compute<T>.Delegates.Matrix_Multiply_vector Matrix_Multiply_vector = (Matrix<T> left, Vector<T> right) =>
		#region code
		{
			#region pre-optimization
			//Vector<generic> result = 
			//	new Vector<generic>(right.Dimensions);
			//for (int i = 0; i < left.Rows; i++)
			//	for (int j = 0; j < left.Columns; j++)
			//		result[i] += left[i, j] * right[j];
			//return result;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_Multiply_vector compile_testing =
				(Matrix<Numeric> _left, Vector<Numeric> _right) =>
				{
#if no_error_checking
								// nothing
#else
					if (_left == null)
						throw new Error("null reference: _left");
					if (_right == null)
						throw new Error("null reference: _right");
					if (_left.Columns != _right.Dimensions)
						throw new Error("invalid multiplication (size miss-match).");
#endif
					int _left_row = _left.Rows;
					int _left_col = _left.Columns;
					Vector<Numeric> result = new Vector<Numeric>(_right.Dimensions);
#if unsafe_code
								if (typeof(T).IsValueType)
								{
									unsafe
									{
										fixed (Numeric*
											_left_flat = _left._matrix as Numeric[],
											_right_flat = _right._vector as Numeric[],
											result_flat = result._vector as Numeric[])
												for (int i = 0; i < _left_row; i++)
													for (int j = 0; j < _left_col; j++)
														result_flat[i] += _left_flat[i * _left_col + j] * _right_flat[j];
									}
								}
								else
								{
									Numeric[] _left_flat = _left._matrix as Numeric[];
									Numeric[] _right_flat = _right._vector as Numeric[];
									Numeric[] result_flat = result._vector as Numeric[];
									for (int i = 0; i < _left_row; i++)
											for (int j = 0; j < _left_col; j++)
													result_flat[i] += _left_flat[i * _left_col + j] * _right_flat[j];
								}
#else
					Numeric[] _left_flat = _left._matrix as Numeric[];
					Numeric[] _right_flat = _right._vector as Numeric[];
					Numeric[] result_flat = result._vector as Numeric[];
					for (int i = 0; i < _left_row; i++)
						for (int j = 0; j < _left_col; j++)
							result_flat[i] += _left_flat[i * _left_col + j] * _right_flat[j];
#endif
					return result;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_Multiply_vector_string =
				"(Matrix<" + num + "> _left, Vector<" + num + "> _right) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (_left == null)" +
				"		throw new Error(\"null reference: _left\");" +
				"	if (_right == null)" +
				"		throw new Error(\"null reference: _right\");" +
				"	if (_left.Columns != _right.Dimensions)" +
				"		throw new Error(\"invalid multiplication (size miss-match).\");" +
#endif
 "	int _left_row = _left.Rows;" +
				"	int _left_col = _left.Columns;" +
				"	Vector<" + num + "> result = new Vector<" + num + ">(_right.Dimensions);";
#if unsafe_code
								 if (typeof(T).IsValueType)
								 {
									 Matrix_Multiply_vector_string +=
							"		unsafe" +
							"		{" +
							"			fixed (" + num + "*" +
							"				_left_flat = _left._matrix as " + num + "[]," +
							"				_right_flat = _right._vector as " + num + "[]," +
							"				result_flat = result._vector as " + num + "[])" +
							"					for (int i = 0; i < _left_row; i++)" +
							"						for (int j = 0; j < _left_col; j++)" +
							"							result_flat[i] += _left_flat[i * _left_col + j] * _right_flat[j];" +
							"		}";
								 }
								 else
								 {
									 Matrix_Multiply_vector_string +=
							"		" + num + "[] _left_flat = _left._matrix as " + num + "[];" +
							"		" + num + "[] _right_flat = _right._vector as " + num + "[];" +
							"		" + num + "[] result_flat = result._vector as " + num + "[];" +
							"		for (int i = 0; i < _left_row; i++)" +
							"				for (int j = 0; j < _left_col; j++)" +
							"						result_flat[i] += _left_flat[i * _left_col + j] * _right_flat[j];";
								 }
#else
			Matrix_Multiply_vector_string +=
	 "	" + num + "[] _left_flat = _left._matrix as " + num + "[];" +
	 "	" + num + "[] _right_flat = _right._vector as " + num + "[];" +
	 "	" + num + "[] result_flat = result._vector as " + num + "[];" +
	 "	for (int i = 0; i < _left_row; i++)" +
	 "		for (int j = 0; j < _left_col; j++)" +
	 "			result_flat[i] += _left_flat[i * _left_col + j] * _right_flat[j];";
#endif
			Matrix_Multiply_vector_string +=
	 "	return result;" +
	 "}";

			#endregion

			Compute<T>.Matrix_Multiply_vector =
				Meta.Compile<Compute<T>.Delegates.Matrix_Multiply_vector>(Matrix_Multiply_vector_string);

			return Compute<T>.Matrix_Multiply_vector(left, right);
		};
		#endregion

		/// <summary>Multiplies all the values in a matrix by a scalar.</summary>
		public static Compute<T>.Delegates.Matrix_Multiply_scalar Matrix_Multiply_scalar = (Matrix<T> left, T right) =>
		#region code
		{
			#region pre-optimization
			//Matrix<generic> result = 
			//	new Matrix<generic>(left.Rows, left.Columns);
			//for (int i = 0; i < left.Rows; i++)
			//	for (int j = 0; j < left.Columns; j++)
			//		result[i, j] = left[i, j] * right;
			//return result;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_Multiply_scalar compile_testing =
				(Matrix<Numeric> _left, Numeric _right) =>
				{
#if no_error_checking
								// nothing
#else
					if (_left == null)
						throw new Error("null reference: _left");
					if (_right == null)
						throw new Error("null reference: _right");
#endif
					int rows = _left.Rows;
					int columns = _left.Columns;
					Matrix<Numeric> result = new Matrix<Numeric>(rows, columns);
#if unsafe_code
								if (typeof(T).IsValueType)
								{
									unsafe
									{
										fixed (Numeric*
											_left_flat = _left._matrix as Numeric[],
											result_flat = result._matrix as Numeric[])
												for (int i = 0; i < rows; i++)
													for (int j = 0; j < columns; j++)
														result_flat[i * columns + j] = _left_flat[i * columns + j] * _right;
									}
								}
								else
								{
									for (int i = 0; i < rows; i++)
										for (int j = 0; j < columns; j++)
											result[i, j] = _left[i, j] * _right;
								}
#else
					for (int i = 0; i < rows; i++)
						for (int j = 0; j < columns; j++)
							result[i, j] = _left[i, j] * _right;
#endif
					return result;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_Multiply_scalar_string =
				"(Matrix<" + num + "> _left, " + num + " _right) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (_left == null)" +
				"		throw new Error(\"null reference: _left\");" +
				"	if (_right == null)" +
				"		throw new Error(\"null reference: _right\");" +
#endif
 "	int rows = _left.Rows;" +
				"	int columns = _left.Columns;" +
				"	Matrix<" + num + "> result = new Matrix<" + num + ">(rows, columns);";
#if unsafe_code
								 if (typeof(T).IsValueType)
								 {
									 Matrix_Multiply_scalar_string +=
							"		unsafe" +
							"		{" +
							"			fixed (" + num + "*" +
							"				_left_flat = _left._matrix as " + num + "[]," +
							"				result_flat = result._matrix as " + num + "[])" +
							"					for (int i = 0; i < rows; i++)" +
							"						for (int j = 0; j < columns; j++)" +
							"							result_flat[i * columns + j] = _left_flat[i * columns + j] * _right;" +
							"		}";
								 }
								 else
								 {
									 Matrix_Multiply_scalar_string +=
							"		for (int i = 0; i < rows; i++)" +
							"			for (int j = 0; j < columns; j++)" +
							"				result[i, j] = _left[i, j] * _right;";
								 }
#else
			Matrix_Multiply_scalar_string +=
	 "	for (int i = 0; i < rows; i++)" +
	 "		for (int j = 0; j < columns; j++)" +
	 "			result[i, j] = _left[i, j] * _right;";
#endif
			Matrix_Multiply_scalar_string +=
	 "	return result;" +
	 "}";

			#endregion

			Compute<T>.Matrix_Multiply_scalar =
				Meta.Compile<Compute<T>.Delegates.Matrix_Multiply_scalar>(Matrix_Multiply_scalar_string);

			return Compute<T>.Matrix_Multiply_scalar(left, right);
		};
		#endregion

		/// <summary>Divides all the values in the matrix by a scalar.</summary>
		public static Compute<T>.Delegates.Matrix_Divide Matrix_Divide = (Matrix<T> left, T right) =>
		#region code
		{
			#region pre-optimization
			//Matrix<generic> result = 
			//	new Matrix<generic>(matrix.Rows, matrix.Columns);
			//for (int i = 0; i < matrix.Rows; i++)
			//	for (int j = 0; j < matrix.Columns; j++)
			//		result[i, j] = matrix[i, j] / right;
			//return result;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_Divide compile_testing =
				(Matrix<Numeric> _left, Numeric _right) =>
				{
#if no_error_checking
								// nothing
#else
					if (_left == null)
						throw new Error("null reference: matrix");
					if (_right == null)
						throw new Error("null reference: matrix");
#endif
					int matrix_row = _left.Rows;
					int matrix_col = _left.Columns;
					Matrix<Numeric> result =
						new Matrix<Numeric>(matrix_row, matrix_col);
#if unsafe_code
								if (typeof(T).IsValueType)
								{
									unsafe
									{
										fixed (Numeric*
											matrix_flat = _left._matrix as Numeric[],
											result_flat = result._matrix as Numeric[])
												for (int i = 0; i < matrix_row; i++)
													for (int j = 0; j < matrix_col; j++)
														result_flat[i * matrix_col + j] =
															matrix_flat[i * matrix_col + j] / _right;
									}
								}
								else
								{
									Numeric[] matrix_flat = _left._matrix as Numeric[];
									Numeric[] result_flat = result._matrix as Numeric[];
									for (int i = 0; i < matrix_row; i++)
										for (int j = 0; j < matrix_col; j++)
											result_flat[i * matrix_col + j] = 
												matrix_flat[i * matrix_col + j] / _right;
								}
#else
					Numeric[] matrix_flat = _left._matrix as Numeric[];
					Numeric[] result_flat = result._matrix as Numeric[];
					for (int i = 0; i < matrix_row; i++)
						for (int j = 0; j < matrix_col; j++)
							result_flat[i * matrix_col + j] =
								matrix_flat[i * matrix_col + j] / _right;
#endif
					return result;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_Divide_string =
				"(Matrix<" + num + "> _left, " + num + " _right) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (_left == null)" +
				"		throw new Error(\"null reference: matrix\");" +
				"	if (_right == null)" +
				"			throw new Error(\"null reference: matrix\");" +
#endif
 "	int matrix_row = _left.Rows;" +
				"	int matrix_col = _left.Columns;" +
				"	Matrix<" + num + "> result =" +
				"		new Matrix<" + num + ">(matrix_row, matrix_col);";
#if unsafe_code
								 if (typeof(T).IsValueType)
								 {
									 Matrix_Divide_string +=
							"		unsafe" +
							"		{" +
							"			fixed (" + num + "*" +
							"				matrix_flat = _left._matrix as " + num + "[]," +
							"				result_flat = result._matrix as " + num + "[])" +
							"					for (int i = 0; i < matrix_row; i++)" +
							"						for (int j = 0; j < matrix_col; j++)" +
							"							result_flat[i * matrix_col + j] =" +
							"								matrix_flat[i * matrix_col + j] / _right;" +
							"		}";
								 }
								 else
								 {
									 Matrix_Divide_string +=
							"		" + num + "[] matrix_flat = _left._matrix as " + num + "[];" +
							"		" + num + "[] result_flat = result._matrix as " + num + "[];" +
							"		for (int i = 0; i < matrix_row; i++)" +
							"			for (int j = 0; j < matrix_col; j++)" +
							"				result_flat[i * matrix_col + j] = " +
							"					matrix_flat[i * matrix_col + j] / _right;";
								 }
#else
			Matrix_Divide_string +=
	 "	" + num + "[] matrix_flat = _left._matrix as " + num + "[];" +
	 "	" + num + "[] result_flat = result._matrix as " + num + "[];" +
	 "	for (int i = 0; i < matrix_row; i++)" +
	 "		for (int j = 0; j < matrix_col; j++)" +
	 "			result_flat[i * matrix_col + j] = " +
	 "				matrix_flat[i * matrix_col + j] / _right;";
#endif
			Matrix_Divide_string +=
	 "	return result;" +
	 "}";
			#endregion

			Compute<T>.Matrix_Divide =
				Meta.Compile<Compute<T>.Delegates.Matrix_Divide>(Matrix_Divide_string);

			return Compute<T>.Matrix_Divide(left, right);
		};
		#endregion

		/// <summary>Applies a power to a square matrix.</summary>
		public static Compute<T>.Delegates.Matrix_Power Matrix_Power = (Matrix<T> matrix, int power) =>
		#region code
		{
			#region pre-optimization
			//Matrix<generic> result = _matrix.Clone();
			//for (int i = 0; i < _power; i++)
			//	result = Matrix.Multiply(result, _matrix);
			//return result;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_Power compile_testing =
				(Matrix<Numeric> _matrix, int _power) =>
				{
#if no_error_checking
								// nothing
#else
					if (!(_matrix.Rows == _matrix.Columns))
						throw new Error("invalid _power (!_matrix.IsSquare).");
					if (!(_power >= 0))
						throw new Error("invalid _power !(_power > -1)");
#endif
					if (_power == 0)
						return Compute<Numeric>.Matrix_FactoryIdentity(_matrix.Rows, _matrix.Columns);
					Matrix<Numeric> result = _matrix.Clone();
					for (int i = 0; i < _power; i++)
						result = Compute<Numeric>.Matrix_Multiply(result, _matrix);
					return result;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_Power_string =
				"(Matrix<" + num + "> _matrix, int _power) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (!(_matrix.Rows == _matrix.Columns))" +
				"		throw new Error(\"invalid _power (!_matrix.IsSquare).\");" +
				"	if (!(_power >= 0))" +
				"		throw new Error(\"invalid _power !(_power > -1)\");" +
#endif
 "	if (_power == 0)" +
				"		return Compute<" + num + ">.Matrix_FactoryIdentity(_matrix.Rows, _matrix.Columns);" +
				"	Matrix<" + num + "> result = _matrix.Clone();" +
				"	for (int i = 0; i < _power; i++)" +
				"		result = Compute<" + num + ">.Matrix_Multiply(result, _matrix);" +
				"	return result;" +
				"}";
			#endregion

			Compute<T>.Matrix_Power =
				Meta.Compile<Compute<T>.Delegates.Matrix_Power>(Matrix_Power_string);

			return Compute<T>.Matrix_Power(matrix, power);
		};
		#endregion

		/// <summary>Gets the minor of a matrix.</summary>
		public static Compute<T>.Delegates.Matrix_Minor Matrix_Minor = (Matrix<T> matrix, int row, int column) =>
		#region code
		{
			#region pre-optimization
			//Matrix<generic> minor = 
			//	new Matrix<generic>(_matrix.Rows - 1, _matrix.Columns - 1);
			//int m = 0, n = 0;
			//for (int i = 0; i < _matrix.Rows; i++)
			//{
			//	if (i == _row) continue;
			//	n = 0;
			//	for (int j = 0; j < _matrix.Columns; j++)
			//	{
			//		if (j == _column) continue;
			//		minor[m, n] = _matrix[i, j];
			//		n++;
			//	}
			//	m++;
			//}
			//return minor;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_Minor compile_testing =
				(Matrix<Numeric> _matrix, int _row, int _column) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_matrix, null))
						throw new Error("null reference: _matrix");
					if (_matrix.Rows < 2 || _matrix.Columns < 2)
						throw new Error("invalid _matrix minor: (_matrix.Rows < 2 || _matrix.Columns < 2)");
					if (_row < 0 || _row >= _matrix.Rows)
						throw new Error("invalid _row on _matrix minor: !(0 <= _row < _matrix.Rows)");
					if (_column < 0 || _row >= _matrix.Columns)
						throw new Error("invalid _column on _matrix minor: !(0 <= _column < _matrix.Columns)");
#endif
					Matrix<Numeric> minor =
						new Matrix<Numeric>(_matrix.Rows - 1, _matrix.Columns - 1);
					int _matrix__rows = _matrix.Rows;
					int _matrix_cols = _matrix.Columns;
#if unsafe_code
								if (typeof(T).IsValueType)
								{
									unsafe
									{
										fixed (Numeric*
											_matrix_flat = _matrix._matrix as Numeric[],
											minor_flat = minor._matrix as Numeric[])
										{
											int m = 0, n = 0;
											for (int i = 0; i < _matrix__rows; i++)
											{
												if (i == _row) continue;
												n = 0;
												for (int j = 0; j < _matrix_cols; j++)
												{
													if (j == _column) continue;
													minor_flat[m * _matrix_cols + n] =
														_matrix_flat[i * _matrix_cols + j];
													n++;
												}
												m++;
											}
										}
									}
								}
								else
								{
									int m = 0, n = 0;
										for (int i = 0; i < _matrix.Rows; i++)
										{
											if (i == _row) continue;
											n = 0;
											for (int j = 0; j < _matrix.Columns; j++)
											{
												if (j == _column) continue;
												minor[m, n] = _matrix[i, j];
												n++;
											}
											m++;
										}
								}
#else
					int m = 0, n = 0;
					for (int i = 0; i < _matrix.Rows; i++)
					{
						if (i == _row) continue;
						n = 0;
						for (int j = 0; j < _matrix.Columns; j++)
						{
							if (j == _column) continue;
							minor[m, n] = _matrix[i, j];
							n++;
						}
						m++;
					}
#endif
					return minor;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_Minor_string =
				"(Matrix<" + num + "> _matrix, int _row, int _column) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_matrix, null))" +
				"		throw new Error(\"null reference: _matrix\");" +
				"	if (_matrix.Rows < 2 || _matrix.Columns < 2)" +
				"		throw new Error(\"invalid _matrix minor: (_matrix.Rows < 2 || _matrix.Columns < 2)\");" +
				"	if (_row < 0 || _row >= _matrix.Rows)" +
				"		throw new Error(\"invalid _row on _matrix minor: !(0 <= _row < _matrix.Rows)\");" +
				"	if (_column < 0 || _row >= _matrix.Columns)" +
				"		throw new Error(\"invalid _column on _matrix minor: !(0 <= _column < _matrix.Columns)\");" +
#endif
 "	Matrix<" + num + "> minor =" +
				"		new Matrix<" + num + ">(_matrix.Rows - 1, _matrix.Columns - 1);" +
				"	int _matrix__rows = _matrix.Rows;" +
				"	int _matrix_cols = _matrix.Columns;";
#if unsafe_code
								 if (typeof(T).IsValueType)
								 {
									 Matrix_Minor_string +=
							"		unsafe" +
							"		{" +
							"			fixed (" + num + "*" +
							"				_matrix_flat = _matrix._matrix as " + num + "[]," +
							"				minor_flat = minor._matrix as " + num + "[])" +
							"			{" +
							"				int m = 0, n = 0;" +
							"				for (int i = 0; i < _matrix__rows; i++)" +
							"				{" +
							"					if (i == _row) continue;" +
							"					n = 0;" +
							"					for (int j = 0; j < _matrix_cols; j++)" +
							"					{" +
							"						if (j == _column) continue;" +
							"						minor_flat[m * _matrix_cols + n] =" +
							"							_matrix_flat[i * _matrix_cols + j];" +
							"						n++;" +
							"					}" +
							"					m++;" +
							"				}" +
							"			}" +
							"		}";
								 }
								 else
								 {
									 Matrix_Minor_string +=
							"		int m = 0, n = 0;" +
							"			for (int i = 0; i < _matrix.Rows; i++)" +
							"			{" +
							"				if (i == _row) continue;" +
							"				n = 0;" +
							"				for (int j = 0; j < _matrix.Columns; j++)" +
							"				{" +
							"					if (j == _column) continue;" +
							"					minor[m, n] = _matrix[i, j];" +
							"					n++;" +
							"				}" +
							"				m++;" +
							"			}";
								 }
#else
			Matrix_Minor_string +=
	 "	int m = 0, n = 0;" +
	 "	for (int i = 0; i < _matrix.Rows; i++)" +
	 "	{" +
	 "			if (i == _row) continue;" +
	 "			n = 0;" +
	 "			for (int j = 0; j < _matrix.Columns; j++)" +
	 "			{" +
	 "					if (j == _column) continue;" +
	 "					minor[m, n] = _matrix[i, j];" +
	 "					n++;" +
	 "			}" +
	 "			m++;" +
	 "	}";
#endif
			Matrix_Minor_string +=
	 "	return minor;" +
	 "}";

			#endregion

			Compute<T>.Matrix_Minor =
				Meta.Compile<Compute<T>.Delegates.Matrix_Minor>(Matrix_Minor_string);

			return Compute<T>.Matrix_Minor(matrix, row, column);
		};
		#endregion

		/// <summary>Combines two matrices from left to right (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
		public static Compute<T>.Delegates.Matrix_ConcatenateRowWise Matrix_ConcatenateRowWise = (Matrix<T> left, Matrix<T> right) =>
		#region code
		{
			#region pre-optimization
			//Matrix<generic> result =
			//	new Matrix<generic>(left.Rows, left.Columns + right.Columns);
			//for (int i = 0; i < result.Rows; i++)
			//	for (int j = 0; j < result.Columns; j++)
			//		if (j < left.Columns)
			//			result[i, j] = left[i, j];
			//		else
			//			result[i, j] = right[i, j - left.Columns];
			//return result;
			#endregion

			#region generic
#if hide_generic
						Matrix<generic>.delegates.Matrix_ConcatenateRowWise compile_testing =
							(Matrix<generic> _left, Matrix<generic> _right) =>
							{
#if no_errorChecking
								// nothing
#else
								if (object.ReferenceEquals(_left, null))
										throw new Error("null reference: _left");
								if (object.ReferenceEquals(_right, null))
										throw new Error("null reference: _right");
								if (_left.Rows != _right.Rows)
										throw new Error("invalid row-wise concatenation !(_left.Rows == _right.Rows).");
#endif
								Matrix<generic> result =
									new Matrix<generic>(_left.Rows, _left.Columns + _right.Columns);
								int result_rows = result.Rows;
								int result_cols = result.Columns;
								int _left_cols = _left.Columns;
								int _right_cols = _right.Columns;
#if unsafe_code
								if (typeof(T).IsValueType)
								{
									unsafe
									{
										// OptimizeMe (jump statement)
										fixed (generic*
											_left_flat = _left._matrix as generic[],
											_right_flat = _right._matrix as generic[],
											result_flat = result._matrix as generic[])
												for (int i = 0; i < result_rows; i++)
													for (int j = 0; j < result_cols; j++)
														if (j < _left_cols)
															result_flat[i * result_cols + j] =
																_left_flat[i * _left_cols + j];
														else
															result_flat[i * result_cols + j] =
																_right_flat[i * _right_cols + j - _left_cols];
									}
								}
								else
								{
									for (int i = 0; i < result_rows; i++)
										for (int j = 0; j < result_cols; j++)
											if (j < _left.Columns)
												result[i, j] = _left[i, j];
											else
												result[i, j] = _right[i, j - _left.Columns];
								}
#else
								for (int i = 0; i < result_rows; i++)
									for (int j = 0; j < result_cols; j++)
										if (j < _left.Columns)
											result[i, j] = _left[i, j];
										else
											result[i, j] = _right[i, j - _left.Columns];
#endif
								return result;
							};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_ConcatenateRowWise_string =
				"(Matrix<" + num + "> _left, Matrix<" + num + "> _right) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_left, null))" +
				"			throw new Error(\"null reference: _left\");" +
				"	if (object.ReferenceEquals(_right, null))" +
				"			throw new Error(\"null reference: _right\");" +
				"	if (_left.Rows != _right.Rows)" +
				"			throw new Error(\"invalid row-wise concatenation !(_left.Rows == _right.Rows).\");" +
#endif
 "	Matrix<" + num + "> result =" +
				"		new Matrix<" + num + ">(_left.Rows, _left.Columns + _right.Columns);" +
				"	int result_rows = result.Rows;" +
				"	int result_cols = result.Columns;" +
				"	int _left_cols = _left.Columns;" +
				"	int _right_cols = _right.Columns;";
#if unsafe_code
								 if (typeof(T).IsValueType)
								 {
									 Matrix_ConcatenateRowWise_string +=
							"		unsafe" +
							"		{" +
							"			// OptimizeMe (jump statement)" +
							"			fixed (" + num + "*" +
							"				_left_flat = _left._matrix as " + num + "[]," +
							"				_right_flat = _right._matrix as " + num + "[]," +
							"				result_flat = result._matrix as " + num + "[])" +
							"					for (int i = 0; i < result_rows; i++)" +
							"						for (int j = 0; j < result_cols; j++)" +
							"							if (j < _left_cols)" +
							"								result_flat[i * result_cols + j] =" +
							"									_left_flat[i * _left_cols + j];" +
							"							else" +
							"								result_flat[i * result_cols + j] =" +
							"									_right_flat[i * _right_cols + j - _left_cols];" +
							"		}";
								 }
								 else
								 {
									 Matrix_ConcatenateRowWise_string +=
							"		for (int i = 0; i < result_rows; i++)" +
							"			for (int j = 0; j < result_cols; j++)" +
							"				if (j < _left.Columns)" +
							"					result[i, j] = _left[i, j];" +
							"				else" +
							"					result[i, j] = _right[i, j - _left.Columns];";
								 }
#else
			Matrix_ConcatenateRowWise_string +=
	 "	for (int i = 0; i < result_rows; i++)" +
	 "		for (int j = 0; j < result_cols; j++)" +
	 "			if (j < _left.Columns)" +
	 "				result[i, j] = _left[i, j];" +
	 "			else" +
	 "				result[i, j] = _right[i, j - _left.Columns];";
#endif
			Matrix_ConcatenateRowWise_string +=
	 "	return result;" +
	 "}";

			#endregion

			Compute<T>.Matrix_ConcatenateRowWise =
				Meta.Compile<Compute<T>.Delegates.Matrix_ConcatenateRowWise>(Matrix_ConcatenateRowWise_string);

			return Compute<T>.Matrix_ConcatenateRowWise(left, right);
		};
		#endregion

		/// <summary>Calculates the determinent of a square matrix.</summary>
		public static Compute<T>.Delegates.Matrix_Determinent Matrix_Determinent = (Matrix<T> matrix) =>
		#region code
		{
			#region pre-optimization
			//generic det = 1;
			//Matrix<generic> rref = _matrix.Clone();
			//for (int i = 0; i < _matrix.Rows; i++)
			//{
			//	if (rref[i, i] == 0)
			//		for (int j = i + 1; j < rref.Rows; j++)
			//			if (rref[j, i] != 0)
			//			{
			//				Matrix.SwapRows(rref, i, j);
			//				det *= -1;
			//			}
			//	det *= rref[i, i];
			//	Matrix.RowMultiplication(rref, i, 1 / rref[i, i]);
			//	for (int j = i + 1; j < rref.Rows; j++)
			//		Matrix.RowAddition(rref, j, i, -rref[j, i]);
			//	for (int j = i - 1; j >= 0; j--)
			//		Matrix.RowAddition(rref, j, i, -rref[j, i]);
			//}
			//return det;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_Determinent compile_testing =
				(Matrix<Numeric> _matrix) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_matrix, null))
						throw new Error("null reference: _matrix");
					if (_matrix.Rows != _matrix.Columns)
						throw new Error("invalid _matrix determinent: !(_matrix.IsSquare)");
#endif
					Numeric det = 1;
					Matrix<Numeric> rref = _matrix.Clone();
					for (int i = 0; i < _matrix.Rows; i++)
					{
						if (rref[i, i] == 0)
							for (int j = i + 1; j < rref.Rows; j++)
								if (rref[j, i] != 0)
								{
									Compute<Numeric>.Matrix_SwapRows(rref, i, j);
									det *= -1;
								}
						det *= rref[i, i];
						Compute<Numeric>.Matrix_RowMultiplication(rref, i, 1 / rref[i, i]);
						for (int j = i + 1; j < rref.Rows; j++)
							Compute<Numeric>.Matrix_RowAddition(rref, j, i, -rref[j, i]);
						for (int j = i - 1; j >= 0; j--)
							Compute<Numeric>.Matrix_RowAddition(rref, j, i, -rref[j, i]);
					}
					return det;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_Determinent_string =
				"(Matrix<" + num + "> _matrix) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_matrix, null))" +
				"		throw new Error(\"null reference: _matrix\");" +
				"	if (_matrix.Rows != _matrix.Columns)" +
				"		throw new Error(\"invalid _matrix determinent: !(_matrix.IsSquare)\");" +
#endif
 "	" + num + " det = 1;" +
				"	Matrix<" + num + "> rref = _matrix.Clone();" +
				"	for (int i = 0; i < _matrix.Rows; i++)" +
				"	{" +
				"		if (rref[i, i] == 0)" +
				"			for (int j = i + 1; j < rref.Rows; j++)" +
				"				if (rref[j, i] != 0)" +
				"				{" +
				"					Compute<" + num + ">.Matrix_SwapRows(rref, i, j);" +
				"					det *= -1;" +
				"				}" +
				"		det *= rref[i, i];" +
				"		Compute<" + num + ">.Matrix_RowMultiplication(rref, i, 1 / rref[i, i]);" +
				"		for (int j = i + 1; j < rref.Rows; j++)" +
				"			Compute<" + num + ">.Matrix_RowAddition(rref, j, i, -rref[j, i]);" +
				"		for (int j = i - 1; j >= 0; j--)" +
				"			Compute<" + num + ">.Matrix_RowAddition(rref, j, i, -rref[j, i]);" +
				"	}" +
				"	return det;" +
				"}";

			#endregion

			Compute<T>.Matrix_Determinent =
				Meta.Compile<Compute<T>.Delegates.Matrix_Determinent>(Matrix_Determinent_string);

			return Compute<T>.Matrix_Determinent(matrix);
		};
		#endregion

		/// <summary>Calculates the echelon of a matrix (aka REF).</summary>
		public static Compute<T>.Delegates.Matrix_Echelon Matrix_Echelon = (Matrix<T> matrix) =>
		#region code
		{
			#region pre-optimization
			//Matrix<generic> result = _matrix.Clone();
			//for (int i = 0; i < _matrix.Rows; i++)
			//{
			//	if (result[i, i] == 0)
			//		for (int j = i + 1; j < result.Rows; j++)
			//			if (result[j, i] != 0)
			//				Matrix.SwapRows(result, i, j);
			//	if (result[i, i] == 0)
			//		continue;
			//	if (result[i, i] != 1)
			//		for (int j = i + 1; j < result.Rows; j++)
			//			if (result[j, i] == 1)
			//				Matrix.SwapRows(result, i, j);
			//	Matrix.RowMultiplication(result, i, 1 / result[i, i]);
			//	for (int j = i + 1; j < result.Rows; j++)
			//		Matrix.RowAddition(result, j, i, -result[j, i]);
			#endregion

			#region generic
#if hide_generic
						Matrix<generic>.delegates.Matrix_Echelon compile_testing =
							(Matrix<generic> _matrix) =>
							{
#if no_error_checking
								// nothing
#else
								if (object.ReferenceEquals(_matrix, null))
									throw new Error("null reference: _matrix");
#endif
								Matrix<generic> result = _matrix.Clone();
								for (int i = 0; i < _matrix.Rows; i++)
								{
									if (result[i, i] == 0)
										for (int j = i + 1; j < result.Rows; j++)
											if (result[j, i] != 0)
												Matrix<generic>.Matrix_SwapRows(result, i, j);
									if (result[i, i] == 0)
										continue;
									if (result[i, i] != 1)
										for (int j = i + 1; j < result.Rows; j++)
											if (result[j, i] == 1)
												Matrix<generic>.Matrix_SwapRows(result, i, j);
									Matrix<generic>.Matrix_RowMultiplication(result, i, 1 / result[i, i]);
									for (int j = i + 1; j < result.Rows; j++)
										Matrix<generic>.Matrix_RowAddition(result, j, i, -result[j, i]);
								}
								return result;
							};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_Echelon_string =
				"(Matrix<" + num + "> _matrix) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_matrix, null))" +
				"		throw new Error(\"null reference: _matrix\");" +
#endif
 "	Matrix<" + num + "> result = _matrix.Clone();" +
				"	for (int i = 0; i < _matrix.Rows; i++)" +
				"	{" +
				"		if (result[i, i] == 0)" +
				"			for (int j = i + 1; j < result.Rows; j++)" +
				"				if (result[j, i] != 0)" +
				"					Compute<" + num + ">.Matrix_SwapRows(result, i, j);" +
				"		if (result[i, i] == 0)" +
				"			continue;" +
				"		if (result[i, i] != 1)" +
				"			for (int j = i + 1; j < result.Rows; j++)" +
				"				if (result[j, i] == 1)" +
				"					Compute<" + num + ">.Matrix_SwapRows(result, i, j);" +
				"		Compute<" + num + ">.Matrix_RowMultiplication(result, i, 1 / result[i, i]);" +
				"		for (int j = i + 1; j < result.Rows; j++)" +
				"			Compute<" + num + ">.Matrix_RowAddition(result, j, i, -result[j, i]);" +
				"	}" +
				"	return result;" +
				"}";

			#endregion

			Compute<T>.Matrix_Echelon =
				Meta.Compile<Compute<T>.Delegates.Matrix_Echelon>(Matrix_Echelon_string);

			return Compute<T>.Matrix_Echelon(matrix);
		};
		#endregion

		/// <summary>Calculates the echelon of a matrix and reduces it (aka RREF).</summary>
		public static Compute<T>.Delegates.Matrix_ReducedEchelon Matrix_ReducedEchelon = (Matrix<T> matrix) =>
		#region code
		{
			#region pre-optimization
			//Matrix<generic> result = matrix.Clone();
			//for (int i = 0; i < matrix.Rows; i++)
			//{
			//	if (result[i, i] == 0)
			//		for (int j = i + 1; j < result.Rows; j++)
			//			if (result[j, i] != 0)
			//				Matrix.SwapRows(result, i, j);
			//	if (result[i, i] == 0) continue;
			//	if (result[i, i] != 1)
			//		for (int j = i + 1; j < result.Rows; j++)
			//			if (result[j, i] == 1)
			//				Matrix.SwapRows(result, i, j);
			//	Matrix.RowMultiplication(result, i, 1 / result[i, i]);
			//	for (int j = i + 1; j < result.Rows; j++)
			//		Matrix.RowAddition(result, j, i, -result[j, i]);
			//	for (int j = i - 1; j >= 0; j--)
			//		Matrix.RowAddition(result, j, i, -result[j, i]);
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_ReducedEchelon compile_testing =
				(Matrix<Numeric> _matrix) =>
				{
#if no_error_checking
								// nothing
#else
					if (_matrix == null)
						throw new Error("null reference: _matrix");
#endif
					Matrix<Numeric> result = _matrix.Clone();
					for (int i = 0; i < _matrix.Rows; i++)
					{
						if (result[i, i] == 0)
							for (int j = i + 1; j < result.Rows; j++)
								if (result[j, i] != 0)
									Compute<Numeric>.Matrix_SwapRows(result, i, j);
						if (result[i, i] == 0) continue;
						if (result[i, i] != 1)
							for (int j = i + 1; j < result.Rows; j++)
								if (result[j, i] == 1)
									Compute<Numeric>.Matrix_SwapRows(result, i, j);
						Compute<Numeric>.Matrix_RowMultiplication(result, i, 1 / result[i, i]);
						for (int j = i + 1; j < result.Rows; j++)
							Compute<Numeric>.Matrix_RowAddition(result, j, i, -result[j, i]);
						for (int j = i - 1; j >= 0; j--)
							Compute<Numeric>.Matrix_RowAddition(result, j, i, -result[j, i]);
					}
					return result;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_ReducedEchelon_string =
				"(Matrix<" + num + "> _matrix) =>" +
				"		{" +
#if no_error_checking
								// nothing
#else
 "	if (_matrix == null)" +
				"		throw new Error(\"null reference: _matrix\");" +
#endif
 "	Matrix<" + num + "> result = _matrix.Clone();" +
				"	for (int i = 0; i < _matrix.Rows; i++)" +
				"	{" +
				"		if (result[i, i] == 0)" +
				"			for (int j = i + 1; j < result.Rows; j++)" +
				"				if (result[j, i] != 0)" +
				"					Compute<" + num + ">.Matrix_SwapRows(result, i, j);" +
				"		if (result[i, i] == 0) continue;" +
				"		if (result[i, i] != 1)" +
				"			for (int j = i + 1; j < result.Rows; j++)" +
				"				if (result[j, i] == 1)" +
				"					Compute<" + num + ">.Matrix_SwapRows(result, i, j);" +
				"		Compute<" + num + ">.Matrix_RowMultiplication(result, i, 1 / result[i, i]);" +
				"		for (int j = i + 1; j < result.Rows; j++)" +
				"			Compute<" + num + ">.Matrix_RowAddition(result, j, i, -result[j, i]);" +
				"		for (int j = i - 1; j >= 0; j--)" +
				"			Compute<" + num + ">.Matrix_RowAddition(result, j, i, -result[j, i]);" +
				"	}" +
				"	return result;" +
				"}";

			#endregion

			Compute<T>.Matrix_ReducedEchelon =
				Meta.Compile<Compute<T>.Delegates.Matrix_ReducedEchelon>(Matrix_ReducedEchelon_string);

			return Compute<T>.Matrix_ReducedEchelon(matrix);
		};
		#endregion

		/// <summary>Calculates the inverse of a matrix.</summary>
		public static Compute<T>.Delegates.Matrix_Inverse Matrix_Inverse = (Matrix<T> matrix) =>
		#region code
		{
			#region pre-optimization
			//Matrix<generic> identity = 
			//	Matrix.MatrixFactoryIdentity_generic(matrix.Rows, matrix.Columns);
			//Matrix<generic> rref = matrix.Clone();
			//for (int i = 0; i < matrix.Rows; i++)
			//{
			//	if (rref[i, i] == 0)
			//		for (int j = i + 1; j < rref.Rows; j++)
			//			if (rref[j, i] != 0)
			//			{
			//				Matrix.SwapRows(rref, i, j);
			//				Matrix.SwapRows(identity, i, j);
			//			}
			//	Matrix.RowMultiplication(identity, i, 1 / rref[i, i]);
			//	Matrix.RowMultiplication(rref, i, 1 / rref[i, i]);
			//	for (int j = i + 1; j < rref.Rows; j++)
			//	{
			//		Matrix.RowAddition(identity, j, i, -rref[j, i]);
			//		Matrix.RowAddition(rref, j, i, -rref[j, i]);
			//	}
			//	for (int j = i - 1; j >= 0; j--)
			//	{
			//		Matrix.RowAddition(identity, j, i, -rref[j, i]);
			//		Matrix.RowAddition(rref, j, i, -rref[j, i]);
			//	}
			//}
			//return identity;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_Inverse compile_testing =
				(Matrix<Numeric> _matrix) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_matrix, null))
						throw new Error("null reference: _matrix");
					if (Compute<Numeric>.Matrix_Determinent(_matrix) == 0)
						throw new Error("inverse calculation failed.");
#endif
					Matrix<Numeric> identity = Compute<Numeric>.Matrix_FactoryIdentity(_matrix.Rows, _matrix.Columns);
					Matrix<Numeric> rref = _matrix.Clone();
					for (int i = 0; i < _matrix.Rows; i++)
					{
						if (rref[i, i] == 0)
							for (int j = i + 1; j < rref.Rows; j++)
								if (rref[j, i] != 0)
								{
									Compute<Numeric>.Matrix_SwapRows(rref, i, j);
									Compute<Numeric>.Matrix_SwapRows(identity, i, j);
								}
						Compute<Numeric>.Matrix_RowMultiplication(identity, i, 1 / rref[i, i]);
						Compute<Numeric>.Matrix_RowMultiplication(rref, i, 1 / rref[i, i]);
						for (int j = i + 1; j < rref.Rows; j++)
						{
							Compute<Numeric>.Matrix_RowAddition(identity, j, i, -rref[j, i]);
							Compute<Numeric>.Matrix_RowAddition(rref, j, i, -rref[j, i]);
						}
						for (int j = i - 1; j >= 0; j--)
						{
							Compute<Numeric>.Matrix_RowAddition(identity, j, i, -rref[j, i]);
							Compute<Numeric>.Matrix_RowAddition(rref, j, i, -rref[j, i]);
						}
					}
					return identity;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_Inverse_string =
				"(Matrix<generic>.delegates.Matrix_Inverse)(" +
				"(Matrix<generic> _matrix) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_matrix, null))" +
				"		throw new Error(\"null reference: _matrix\");" +
				"	if (Matrix<generic>.Matrix_Determinent(_matrix) == 0)" +
				"		throw new Error(\"inverse calculation failed.\");" +
#endif
 "	Matrix<generic> identity = Matrix<generic>.Matrix_FactoryIdentity(_matrix.Rows, _matrix.Columns);" +
				"	Matrix<generic> rref = _matrix.Clone();" +
				"	for (int i = 0; i < _matrix.Rows; i++)" +
				"	{" +
				"		if (rref[i, i] == 0)" +
				"			for (int j = i + 1; j < rref.Rows; j++)" +
				"				if (rref[j, i] != 0)" +
				"				{" +
				"					Matrix<generic>.Matrix_SwapRows(rref, i, j);" +
				"					Matrix<generic>.Matrix_SwapRows(identity, i, j);" +
				"				}" +
				"		Matrix<generic>.Matrix_RowMultiplication(identity, i, 1 / rref[i, i]);" +
				"		Matrix<generic>.Matrix_RowMultiplication(rref, i, 1 / rref[i, i]);" +
				"		for (int j = i + 1; j < rref.Rows; j++)" +
				"		{" +
				"				Matrix<generic>.Matrix_RowAddition(identity, j, i, -rref[j, i]);" +
				"				Matrix<generic>.Matrix_RowAddition(rref, j, i, -rref[j, i]);" +
				"		}" +
				"		for (int j = i - 1; j >= 0; j--)" +
				"		{" +
				"				Matrix<generic>.Matrix_RowAddition(identity, j, i, -rref[j, i]);" +
				"				Matrix<generic>.Matrix_RowAddition(rref, j, i, -rref[j, i]);" +
				"		}" +
				"	}" +
				"	return identity;" +
				"}";
			#endregion

			Compute<T>.Matrix_Inverse =
				Meta.Compile<Compute<T>.Delegates.Matrix_Inverse>(Matrix_Inverse_string);

			return Compute<T>.Matrix_Inverse(matrix);
		};
		#endregion

		/// <summary>Calculates the adjoint of a matrix.</summary>
		public static Compute<T>.Delegates.Matrix_Adjoint Matrix_Adjoint = (Matrix<T> matrix) =>
		#region code
		{
			#region pre-optimization
			//Matrix<generic> AdjointMatrix = new Matrix<generic>(_matrix.Rows, _matrix.Columns);
			//for (int i = 0; i < _matrix.Rows; i++)
			//	for (int j = 0; j < _matrix.Columns; j++)
			//		if ((i + j) % 2 == 0)
			//			AdjointMatrix[i, j] = Matrix.Determinent(Matrix.Minor(_matrix, i, j));
			//		else
			//			AdjointMatrix[i, j] = -Matrix.Determinent(Matrix.Minor(_matrix, i, j));
			//return Matrix.Transpose(AdjointMatrix);
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_Adjoint compile_testing =
				(Matrix<Numeric> _matrix) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_matrix, null))
						throw new Error("null reference: _matrix");
					if (!(_matrix.Rows == _matrix.Columns))
						throw new Error("Adjoint of a non-square _matrix does not exists");
#endif
					Matrix<Numeric> AdjointMatrix = new Matrix<Numeric>(_matrix.Rows, _matrix.Columns);
					for (int i = 0; i < _matrix.Rows; i++)
						for (int j = 0; j < _matrix.Columns; j++)
							if ((i + j) % 2 == 0)
								AdjointMatrix[i, j] = Compute<Numeric>.Matrix_Determinent(Compute<Numeric>.Matrix_Minor(_matrix, i, j));
							else
								AdjointMatrix[i, j] = -Compute<Numeric>.Matrix_Determinent(Compute<Numeric>.Matrix_Minor(_matrix, i, j));
					return Compute<Numeric>.Matrix_Transpose(AdjointMatrix);
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_Adjoint_string =
				"(Matrix<" + num + "> _matrix) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_matrix, null))" +
				"		throw new Error(\"null reference: _matrix\");" +
				"	if (!(_matrix.Rows == _matrix.Columns))" +
				"		throw new Error(\"Adjoint of a non-square _matrix does not exists\");" +
#endif
 "	Matrix<" + num + "> AdjointMatrix = new Matrix<" + num + ">(_matrix.Rows, _matrix.Columns);" +
				"	for (int i = 0; i < _matrix.Rows; i++)" +
				"		for (int j = 0; j < _matrix.Columns; j++)" +
				"			if ((i + j) % 2 == 0)" +
				"				AdjointMatrix[i, j] = Matrix<" + num + ">.Matrix_Determinent(Matrix<" + num + ">.Matrix_Minor(_matrix, i, j));" +
				"			else" +
				"				AdjointMatrix[i, j] = -Matrix<" + num + ">.Matrix_Determinent(Matrix<" + num + ">.Matrix_Minor(_matrix, i, j));" +
				"	return Matrix<" + num + ">.Transpose(AdjointMatrix);" +
				"}";

			#endregion

			Compute<T>.Matrix_Adjoint =
				Meta.Compile<Compute<T>.Delegates.Matrix_Adjoint>(Matrix_Adjoint_string);

			return Compute<T>.Matrix_Adjoint(matrix);
		};
		#endregion

		/// <summary>Returns the transpose of a matrix.</summary>
		public static Compute<T>.Delegates.Matrix_Transpose Matrix_Transpose = (Matrix<T> matrix) =>
		#region code
		{
			#region pre-optimization
			//Matrix<generic> transpose = 
			//	new Matrix<generic>(matrix.Columns, matrix.Rows);
			//for (int i = 0; i < transpose.Rows; i++)
			//	for (int j = 0; j < transpose.Columns; j++)
			//		transpose[i, j] = matrix[j, i];
			//return transpose;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_Transpose compile_testing =
				(Matrix<Numeric> _matrix) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_matrix, null))
						throw new Error("null reference: _matrix");
#endif
					Matrix<Numeric> transpose =
						new Matrix<Numeric>(_matrix.Columns, _matrix.Rows);
					for (int i = 0; i < transpose.Rows; i++)
						for (int j = 0; j < transpose.Columns; j++)
							transpose[i, j] = _matrix[j, i];
					return transpose;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_Transpose_string =
				"(Matrix<" + num + "> _matrix) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_matrix, null))" +
				"		throw new Error(\"null reference: _matrix\");" +
#endif
 "	Matrix<" + num + "> transpose =" +
				"		new Matrix<" + num + ">(_matrix.Columns, _matrix.Rows);" +
				"	for (int i = 0; i < transpose.Rows; i++)" +
				"		for (int j = 0; j < transpose.Columns; j++)" +
				"			transpose[i, j] = _matrix[j, i];" +
				"	return transpose;" +
				"}";

			#endregion

			Compute<T>.Matrix_Transpose =
				Meta.Compile<Compute<T>.Delegates.Matrix_Transpose>(Matrix_Transpose_string);

			return Compute<T>.Matrix_Transpose(matrix);
		};
		#endregion

		/// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
		public static Compute<T>.Delegates.Matrix_DecomposeLU Matrix_DecomposeLU = (Matrix<T> matrix, out Matrix<T> lower, out Matrix<T> upper) =>
		#region code
		{
			#region pre-optimization
			//Lower = Matrix.MatrixFactoryIdentity_generic(matrix.Rows, matrix.Columns);
			//Upper = matrix.Clone();
			//int[] permutation = new int[matrix.Rows];
			//for (int i = 0; i < matrix.Rows; i++) permutation[i] = i;
			//generic p = 0, pom2, detOfP = 1;
			//int k0 = 0, pom1 = 0;
			//for (int k = 0; k < matrix.Columns - 1; k++)
			//{
			//	p = 0;
			//	for (int i = k; i < matrix.Rows; i++)
			//		if ((Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k]) > p)
			//		{
			//			p = Upper[i, k] > 0 ? Upper[i, k] : -Upper[i, k];
			//			k0 = i;
			//		}
			//	if (p == 0)
			//		throw new Error("The matrix is singular!");
			//	pom1 = permutation[k];
			//	permutation[k] = permutation[k0];
			//	permutation[k0] = pom1;
			//	for (int i = 0; i < k; i++)
			//	{
			//		pom2 = Lower[k, i];
			//		Lower[k, i] = Lower[k0, i];
			//		Lower[k0, i] = pom2;
			//	}
			//	if (k != k0)
			//		detOfP *= -1;
			//	for (int i = 0; i < matrix.Columns; i++)
			//	{
			//		pom2 = Upper[k, i];
			//		Upper[k, i] = Upper[k0, i];
			//		Upper[k0, i] = pom2;
			//	}
			//	for (int i = k + 1; i < matrix.Rows; i++)
			//	{
			//		Lower[i, k] = Upper[i, k] / Upper[k, k];
			//		for (int j = k; j < matrix.Columns; j++)
			//			Upper[i, j] = Upper[i, j] - Lower[i, k] * Upper[k, j];
			//	}
			//}
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_DecomposeLU compile_testing =
				(Matrix<Numeric> _matrix, out Matrix<Numeric> _Lower, out Matrix<Numeric> _Upper) =>
				{
#if no_error_checking
#else
					if (object.ReferenceEquals(_matrix, null))
						throw new Error("null reference: _matrix");
					if (_matrix.Rows != _matrix.Columns)
						throw new Error("non-square _matrix during DecomposeLU function");
#endif
					_Lower = Compute<Numeric>.Matrix_FactoryIdentity(_matrix.Rows, _matrix.Columns);
					_Upper = _matrix.Clone();
					int[] permutation = new int[_matrix.Rows];
					for (int i = 0; i < _matrix.Rows; i++) permutation[i] = i;
					Numeric p = 0, pom2, detOfP = 1;
					int k0 = 0, pom1 = 0;
					for (int k = 0; k < _matrix.Columns - 1; k++)
					{
						p = 0;
						for (int i = k; i < _matrix.Rows; i++)
							if ((_Upper[i, k] > 0 ? _Upper[i, k] : -_Upper[i, k]) > p)
							{
								p = _Upper[i, k] > 0 ? _Upper[i, k] : -_Upper[i, k];
								k0 = i;
							}
						if (p == 0)
							throw new Error("The _matrix is singular!");
						pom1 = permutation[k];
						permutation[k] = permutation[k0];
						permutation[k0] = pom1;
						for (int i = 0; i < k; i++)
						{
							pom2 = _Lower[k, i];
							_Lower[k, i] = _Lower[k0, i];
							_Lower[k0, i] = pom2;
						}
						if (k != k0)
							detOfP *= -1;
						for (int i = 0; i < _matrix.Columns; i++)
						{
							pom2 = _Upper[k, i];
							_Upper[k, i] = _Upper[k0, i];
							_Upper[k0, i] = pom2;
						}
						for (int i = k + 1; i < _matrix.Rows; i++)
						{
							_Lower[i, k] = _Upper[i, k] / _Upper[k, k];
							for (int j = k; j < _matrix.Columns; j++)
								_Upper[i, j] = _Upper[i, j] - _Lower[i, k] * _Upper[k, j];
						}
					}
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_DecomposeLU_string =
				"(Matrix<" + num + "> _matrix, out Matrix<" + num + "> _Lower, out Matrix<" + num + "> _Upper) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_matrix, null))" +
				"		throw new Error(\"null reference: _matrix\");" +
				"	if (_matrix.Rows != _matrix.Columns)" +
				"		throw new Error(\"non-square _matrix during DecomposeLU function\");" +
#endif
 "	_Lower = Compute<" + num + ">.Matrix_FactoryIdentity(_matrix.Rows, _matrix.Columns);" +
				"	_Upper = _matrix.Clone();" +
				"	int[] permutation = new int[_matrix.Rows];" +
				"	for (int i = 0; i < _matrix.Rows; i++) permutation[i] = i;" +
				"	" + num + " p = 0, pom2, detOfP = 1;" +
				"	int k0 = 0, pom1 = 0;" +
				"	for (int k = 0; k < _matrix.Columns - 1; k++)" +
				"	{" +
				"		p = 0;" +
				"		for (int i = k; i < _matrix.Rows; i++)" +
				"				if ((_Upper[i, k] > 0 ? _Upper[i, k] : -_Upper[i, k]) > p)" +
				"				{" +
				"						p = _Upper[i, k] > 0 ? _Upper[i, k] : -_Upper[i, k];" +
				"						k0 = i;" +
				"				}" +
				"		if (p == 0)" +
				"				throw new Error(\"The _matrix is singular!\");" +
				"		pom1 = permutation[k];" +
				"		permutation[k] = permutation[k0];" +
				"		permutation[k0] = pom1;" +
				"		for (int i = 0; i < k; i++)" +
				"		{" +
				"				pom2 = _Lower[k, i];" +
				"				_Lower[k, i] = _Lower[k0, i];" +
				"				_Lower[k0, i] = pom2;" +
				"		}" +
				"		if (k != k0)" +
				"				detOfP *= -1;" +
				"		for (int i = 0; i < _matrix.Columns; i++)" +
				"		{" +
				"				pom2 = _Upper[k, i];" +
				"				_Upper[k, i] = _Upper[k0, i];" +
				"				_Upper[k0, i] = pom2;" +
				"		}" +
				"		for (int i = k + 1; i < _matrix.Rows; i++)" +
				"		{" +
				"				_Lower[i, k] = _Upper[i, k] / _Upper[k, k];" +
				"				for (int j = k; j < _matrix.Columns; j++)" +
				"						_Upper[i, j] = _Upper[i, j] - _Lower[i, k] * _Upper[k, j];" +
				"		}" +
				"	}" +
				"}";

			#endregion

			Compute<T>.Matrix_DecomposeLU =
				Meta.Compile<Compute<T>.Delegates.Matrix_DecomposeLU>(Matrix_DecomposeLU_string);

			Compute<T>.Matrix_DecomposeLU(matrix, out lower, out upper);
		};
		#endregion

		/// <summary>Does a value equality check.</summary>
		public static Compute<T>.Delegates.Matrix_EqualsByValue Matrix_EqualsByValue = (Matrix<T> left, Matrix<T> right) =>
		#region code
		{
			#region pre-optimization
			//if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
			//	return true;
			//if (object.ReferenceEquals(left, null))
			//	return false;
			//if (object.ReferenceEquals(right, null))
			//	return false;
			//if (left.Rows != right.Rows || left.Columns != right.Columns)
			//	return false;
			//for (int i = 0; i < left.Rows; i++)
			//	for (int j = 0; j < left.Columns; j++)
			//		if (left[i, j] != right[i, j])
			//			return false;
			//return true;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_EqualsByValue compile_testing =
				(Matrix<Numeric> _left, Matrix<Numeric> _right) =>
				{
					if (object.ReferenceEquals(_left, null) && object.ReferenceEquals(_right, null))
						return true;
					if (object.ReferenceEquals(_left, null))
						return false;
					if (object.ReferenceEquals(_right, null))
						return false;
					if (_left.Rows != _right.Rows || _left.Columns != _right.Columns)
						return false;
					for (int i = 0; i < _left.Rows; i++)
						for (int j = 0; j < _left.Columns; j++)
							if (_left[i, j] != _right[i, j])
								return false;
					return true;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_EqualsByValue_string =
				"(Matrix<" + num + "> _left, Matrix<" + num + "> _right) =>" +
				"{" +
				"	if (object.ReferenceEquals(_left, null) && object.ReferenceEquals(_right, null))" +
				"		return true;" +
				"	if (object.ReferenceEquals(_left, null))" +
				"		return false;" +
				"	if (object.ReferenceEquals(_right, null))" +
				"		return false;" +
				"	if (_left.Rows != _right.Rows || _left.Columns != _right.Columns)" +
				"		return false;" +
				"	for (int i = 0; i < _left.Rows; i++)" +
				"		for (int j = 0; j < _left.Columns; j++)" +
				"			if (_left[i, j] != _right[i, j])" +
				"				return false;" +
				"	return true;" +
				"}";

			#endregion

			Compute<T>.Matrix_EqualsByValue =
				Meta.Compile<Compute<T>.Delegates.Matrix_EqualsByValue>(Matrix_EqualsByValue_string);

			return Compute<T>.Matrix_EqualsByValue(left, right);
		};
		#endregion

		/// <summary>Does a value equality check with leniency.</summary>
		public static Compute<T>.Delegates.Matrix_EqualsByValue_leniency Matrix_EqualsByValue_leniency = (Matrix<T> left, Matrix<T> right, T leniency) =>
		#region code
		{
			#region pre-optimization
			//if (object.ReferenceEquals(_left, null) && object.ReferenceEquals(_right, null))
			//	return true;
			//if (object.ReferenceEquals(_left, null))
			//	return false;
			//if (object.ReferenceEquals(_right, null))
			//	return false;
			//if (_left.Rows != _right.Rows || _left.Columns != _right.Columns)
			//	return false;
			//for (int i = 0; i < _left.Rows; i++)
			//	for (int j = 0; j < _left.Columns; j++)
			//		if (Logic.Abs(_left[i, j] - _right[i, j]) > _leniency)
			//			return false;
			//return true;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_EqualsByValue_leniency compile_testing =
				(Matrix<Numeric> _left, Matrix<Numeric> _right, Numeric _leniency) =>
				{
					if (object.ReferenceEquals(_left, null) && object.ReferenceEquals(_right, null))
						return true;
					if (object.ReferenceEquals(_left, null))
						return false;
					if (object.ReferenceEquals(_right, null))
						return false;
					if (_left.Rows != _right.Rows || _left.Columns != _right.Columns)
						return false;
					for (int i = 0; i < _left.Rows; i++)
						for (int j = 0; j < _left.Columns; j++)
							if (Compute<Numeric>.AbsoluteValue(_left[i, j] - _right[i, j]) > _leniency)
								return false;
					return true;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_EqualsByValue_leniency_string =
				"(Matrix<" + num + "> _left, Matrix<" + num + "> _right, " + num + " _leniency) =>" +
				"{" +
				"	if (object.ReferenceEquals(_left, null) && object.ReferenceEquals(_right, null))" +
				"		return true;" +
				"	if (object.ReferenceEquals(_left, null))" +
				"		return false;" +
				"	if (object.ReferenceEquals(_right, null))" +
				"		return false;" +
				"	if (_left.Rows != _right.Rows || _left.Columns != _right.Columns)" +
				"		return false;" +
				"	for (int i = 0; i < _left.Rows; i++)" +
				"		for (int j = 0; j < _left.Columns; j++)" +
				"			if (Logic<" + num + ">.Abs(_left[i, j] - _right[i, j]) > _leniency)" +
				"				return false;" +
				"	return true;" +
				"}";

			#endregion

			Compute<T>.Matrix_EqualsByValue_leniency =
				Meta.Compile<Compute<T>.Delegates.Matrix_EqualsByValue_leniency>(Matrix_EqualsByValue_leniency_string);

			return Compute<T>.Matrix_EqualsByValue_leniency(left, right, leniency);
		};
		#endregion

		public static Compute<T>.Delegates.Matrix_RowMultiplication Matrix_RowMultiplication = (Matrix<T> matrix, int row, T scalar) =>
		#region code
		{
			#region pre-optimization
			//for (int j = 0; j < matrix.Columns; j++)
			//	matrix[row, j] *= scalar;
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_RowMultiplication compile_testing =
				(Matrix<Numeric> _matrix, int _row, Numeric _scalar) =>
				{
					for (int j = 0; j < _matrix.Columns; j++)
						_matrix[_row, j] *= _scalar;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_RowMultiplication_string =
				"(Matrix<" + num + "> _matrix, int _row, " + num + " _scalar) =>" +
				"{" +
				"	for (int j = 0; j < _matrix.Columns; j++)" +
				"		_matrix[_row, j] *= _scalar;" +
				"}";

			#endregion

			Compute<T>.Matrix_RowMultiplication =
				Meta.Compile<Compute<T>.Delegates.Matrix_RowMultiplication>(Matrix_RowMultiplication_string);

			Compute<T>.Matrix_RowMultiplication(matrix, row, scalar);
		};
		#endregion

		public static Compute<T>.Delegates.Matrix_RowAddition Matrix_RowAddition = (Matrix<T> matrix, int target, int second, T scalar) =>
		#region code
		{
			#region pre-optimization
			//for (int j = 0; j < matrix.Columns; j++)
			//	matrix[target, j] += (matrix[second, j] * scalar);
			#endregion

			#region generic
#if hide_generic
						Matrix<generic>.delegates.Matrix_RowAddition compile_testing =
							(Matrix<generic> _matrix, int _target, int _second, generic _scalar) =>
							{
								for (int j = 0; j < _matrix.Columns; j++)
									_matrix[_target, j] += (_matrix[_second, j] * _scalar);
							};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_RowAddition_string =
				"(Matrix<" + num + "> _matrix, int _target, int _second, " + num + " _scalar) =>" +
				"{" +
				"	for (int j = 0; j < _matrix.Columns; j++)" +
				"		_matrix[_target, j] += (_matrix[_second, j] * _scalar);" +
				"}";

			#endregion

			Compute<T>.Matrix_RowAddition =
				Meta.Compile<Compute<T>.Delegates.Matrix_RowAddition>(Matrix_RowAddition_string);

			Compute<T>.Matrix_RowAddition(matrix, target, second, scalar);
		};
		#endregion

		public static Compute<T>.Delegates.Matrix_SwapRows Matrix_SwapRows = (Matrix<T> matrix, int row1, int row2) =>
		#region code
		{
			#region pre-optimization
			//for (int j = 0; j < matrix.Columns; j++)
			//{
			//	generic temp = matrix[row1, j];
			//	matrix[row1, j] = matrix[row2, j];
			//	matrix[row2, j] = temp;
			//}
			#endregion

			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Matrix_SwapRows compile_testing =
				(Matrix<Numeric> _matrix, int _row1, int _row2) =>
				{
					for (int j = 0; j < _matrix.Columns; j++)
					{
						Numeric temp = _matrix[_row1, j];
						_matrix[_row1, j] = _matrix[_row2, j];
						_matrix[_row2, j] = temp;
					}
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Matrix_SwapRows_string =
				"(Matrix<" + num + "> _matrix, int _row1, int _row2) =>" +
				"{" +
				"		for (int j = 0; j < _matrix.Columns; j++)" +
				"		{" +
				"				" + num + " temp = _matrix[_row1, j];" +
				"				_matrix[_row1, j] = _matrix[_row2, j];" +
				"				_matrix[_row2, j] = temp;" +
				"		}" +
				"}";

			#endregion

			Compute<T>.Matrix_SwapRows =
				Meta.Compile<Compute<T>.Delegates.Matrix_SwapRows>(Matrix_SwapRows_string);

			Compute<T>.Matrix_SwapRows(matrix, row1, row2);
		};
		#endregion
		
		#region generic

		//		/// <summary>Negates all the values in a matrix.</summary>
		//		/// <param name="matrix">The matrix to have its values negated.</param>
		//		/// <returns>The resulting matrix after the negations.</returns>
		//		public static Matrix<generic> Negate_parallel(Matrix<generic> matrix)
		//		{
		//			#region error checking

		//#if no_error_checking
		//					// nothing
		//#else
		//			if (object.ReferenceEquals(matrix, null))
		//				throw new Error("null reference: matirx");
		//#endif

		//			#endregion

		//			// At the moment, negation does not benefit from multithreading.
		//			if (false) //matrix.Rows * matrix.Columns > _parallelMinimum)
		//			{
		//				#region flattened array

		//				if (matrix.CurrentFormat == Matrix<generic>.Format.FlattenedArray)
		//				{

		//					Matrix<generic> result =
		//					new Matrix<generic>(matrix.Rows, matrix.Columns);
		//					int size = matrix.Rows * matrix.Columns;

		//#if unsafe_code
		//												unsafe
		//												{
		//														Seven.Parallels.AutoParallel.Divide(
		//															(int current, int max) =>
		//															{
		//																	return () =>
		//																	{
		//																			fixed (generic*
		//																				result_flat = result._matrix as generic[],
		//																				matrix_flat = matrix._matrix as generic[])
		//																					for (int i = current; i < size; i += max)
		//																							result_flat[i] = -matrix_flat[i];
		//																	};
		//															}, Logic.Max(matrix.Rows, matrix.Columns));
		//												}
		//#else
		//					Seven.Parallels.AutoParallel.Divide(
		//						(int current, int max) =>
		//						{
		//							return () =>
		//							{
		//								generic[] matrix_flat = matrix._matrix as generic[];
		//								generic[] result_flat = result._matrix as generic[];
		//								for (int i = current; i < size; i += max)
		//									result_flat[i] = -matrix_flat[i];
		//							};
		//						}, Logic.Max(matrix.Rows, matrix.Columns));
		//#endif
		//					return result;

		//				}

		//				#endregion
		//			}
		//			return LinearAlgebra.Negate(matrix);
		//		}

		//				/// <summary>Does standard addition of two matrices.</summary>
		//				/// <param name="left">The left matrix of the addition.</param>
		//				/// <param name="right">The right matrix of the addition.</param>
		//				/// <returns>The resulting matrix after the addition.</returns>
		//				public static Matrix<generic> Add_parallel(Matrix<generic> left, Matrix<generic> right)
		//				{
		//						#region error checking

		//#if no_error_checking
		//			// nothing
		//#else
		//						if (object.ReferenceEquals(left, null))
		//								throw new Error("null reference: left");
		//						if (object.ReferenceEquals(right, null))
		//								throw new Error("null reference: right");
		//						if (left.Rows != right.Rows || left.Columns != right.Columns)
		//								throw new Error("invalid matrix addition (dimension miss-match).");
		//#endif

		//						#endregion

		//						// At the moment, addition does not benefit from multithreading.
		//						if (false) //matrix.Rows * matrix.Columns > _parallelMinimum)
		//						{
		//								#region flattened array

		//								if (left.CurrentFormat == Matrix<generic>.Format.FlattenedArray)
		//								{

		//										Matrix<generic> result =
		//										new Matrix<generic>(left.Rows, left.Columns);
		//										int size = left.Rows * left.Columns;

		//#if unsafe_code
		//										unsafe
		//										{
		//												Seven.Parallels.AutoParallel.Divide(
		//													(int current, int max) =>
		//													{
		//															return () =>
		//															{
		//																	fixed (generic*
		//																		left_flat = left._matrix as generic[],
		//																		right_flat = right._matrix as generic[],
		//																		result_flat = result._matrix as generic[])
		//																			for (int i = current; i < size; i += max)
		//																					result_flat[i] = left_flat[i] + right_flat[i];
		//															};
		//													}, Logic.Max(left.Rows, left.Columns));
		//										}
		//#else
		//					Seven.Parallels.AutoParallel.Divide(
		//						(int current, int max) =>
		//						{
		//							return () =>
		//							{
		//								generic[] left_flat = left._matrix as generic[];
		//								generic[] right_flat = right._matrix as generic[];
		//								generic[] result_flat = result._matrix as generic[];
		//								for (int i = current; i < size; i += max)
		//									result_flat[i] = left_flat[i] + right_flat[i];
		//							};
		//						}, Logic.Max(left.Rows, left.Columns));
		//#endif
		//										return result;

		//								}

		//								#endregion
		//						}
		//						return LinearAlgebra.Add(left, right);
		//				}

		//				/// <summary>Subtracts a scalar from all the values in a matrix.</summary>
		//				/// <param name="left">The matrix to have the values subtracted from.</param>
		//				/// <param name="right">The scalar to subtract from all the matrix values.</param>
		//				/// <returns>The resulting matrix after the subtractions.</returns>
		//				public static Matrix<generic> Subtract_parallel(Matrix<generic> left, Matrix<generic> right)
		//				{
		//						#region error checking

		//#if no_error_checking
		//			// nothing
		//#else
		//						if (object.ReferenceEquals(left, null))
		//								throw new Error("null reference: left");
		//						if (object.ReferenceEquals(right, null))
		//								throw new Error("null reference: right");
		//						if (left.Rows != right.Rows || left.Columns != right.Columns)
		//								throw new Error("invalid matrix subtraction (dimension miss-match).");
		//#endif

		//						#endregion

		//						// At the moment, subtraction does not benefit from multithreading.
		//						if (false) //matrix.Rows * matrix.Columns > _parallelMinimum)
		//						{
		//								#region flattened arrays

		//								if (left.CurrentFormat == Matrix<generic>.Format.FlattenedArray &&
		//									right.CurrentFormat == Matrix<generic>.Format.FlattenedArray)
		//								{

		//										Matrix<generic> result =
		//										new Matrix<generic>(left.Rows, left.Columns);
		//										int size = left.Rows * left.Columns;

		//#if unsafe_code
		//										unsafe
		//										{
		//												Seven.Parallels.AutoParallel.Divide(
		//													(int current, int max) =>
		//													{
		//															return () =>
		//															{
		//																	fixed (generic*
		//																		left_flat = left._matrix as generic[],
		//																		right_flat = right._matrix as generic[],
		//																		result_flat = result._matrix as generic[])
		//																			for (int i = current; i < size; i += max)
		//																					result_flat[i] = left_flat[i] - right_flat[i];
		//															};
		//													}, Logic.Max(left.Rows, left.Columns));
		//										}
		//#else
		//					Seven.Parallels.AutoParallel.Divide(
		//					(int current, int max) =>
		//					{
		//						return () =>
		//						{
		//							generic[] left_flat = left._matrix as generic[];
		//							generic[] right_flat = right._matrix as generic[];
		//							generic[] result_flat = result._matrix as generic[];
		//								for (int i = current; i < size; i += max)
		//									result_flat[i] = left_flat[i] - right_flat[i];
		//						};
		//					}, Logic.Max(left.Rows, left.Columns));
		//#endif
		//										return result;
		//								}

		//								#endregion
		//						}
		//						return LinearAlgebra.Subtract(left, right);
		//				}

		//				/// <summary>Performs multiplication on two matrices using multi-threading.</summary>
		//				/// <param name="left">The left matrix of the multiplication.</param>
		//				/// <param name="right">The right matrix of the multiplication.</param>
		//				/// <returns>The resulting matrix of the multiplication.</returns>
		//				public static Matrix<generic> Multiply_parrallel(Matrix<generic> left, Matrix<generic> right)
		//				{
		//						#region error checking

		//#if no_error_checking
		//			// nothing
		//#else
		//						if (left == null)
		//								throw new Error("null reference: left");
		//						if (right == null)
		//								throw new Error("null reference: right");
		//						if (left.Columns != right.Rows)
		//								throw new Error("invalid multiplication (dimension miss-match).");
		//#endif

		//						#endregion

		//						int result_rows = left.Rows;
		//						int left_cols = left.Columns;
		//						int result_cols = right.Columns;

		//						// If there are enough rows to warrant multi-threading,
		//						// then multithread the row for-loop.
		//						if (result_rows * result_cols > _parallelMinimum &&
		//							result_rows >= result_cols)
		//						{
		//								#region flattened arrays

		//								if (left.CurrentFormat == Matrix<generic>.Format.FlattenedArray &&
		//									right.CurrentFormat == Matrix<generic>.Format.FlattenedArray)
		//								{

		//										Matrix<generic> result =
		//											new Matrix<generic>(result_rows, result_cols);

		//#if unsafe_code
		//										unsafe
		//										{
		//												Seven.Parallels.AutoParallel.Divide(
		//													(int current, int max) =>
		//													{
		//															return () =>
		//															{
		//																	generic sum;
		//																	int left_i_offest;
		//																	int result_i_offset;

		//																	fixed (generic*
		//																		result_flat = result._matrix as generic[],
		//																		left_flat = left._matrix as generic[],
		//																		right_flat = right._matrix as generic[])
		//																			for (int i = current; i < result_rows; i += max)
		//																			{
		//																					left_i_offest = i * left_cols;
		//																					result_i_offset = i * result_cols;
		//																					for (int j = 0; j < result_cols; j++)
		//																					{
		//																							sum = 0;
		//																							for (int k = 0; k < left_cols; k++)
		//																									sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
		//																							result_flat[result_i_offset + j] = sum;
		//																					}
		//																			}
		//															};
		//													}, result_rows);
		//										}
		//#else
		//				generic[] result_flat = result._matrix as generic[];
		//				generic[] left_flat = left._matrix as generic[];
		//				generic[] right_flat = right._matrix as generic[];

		//				Seven.Parallels.AutoParallel.Divide(
		//						(int current, int max) =>
		//						{
		//							return () =>
		//							{
		//								generic sum;
		//								int left_i_offest;
		//								int result_i_offset;

		//								for (int i = current; i < result_rows; i += max)
		//								{
		//									left_i_offest = i * left_cols;
		//									result_i_offset = i * result_cols;
		//									for (int j = 0; j < result_cols; j++)
		//									{
		//										sum = 0;
		//										for (int k = 0; k < left_cols; k++)
		//											sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
		//										result_flat[result_i_offset + j] = sum;
		//									}
		//								}
		//							};
		//						}, result_rows);

		//#endif

		//										return result;
		//								}

		//								#endregion
		//						}
		//						// If there are enough columns to warrant multi-threading,
		//						// then multithread the column for-loop.
		//						else if (result_rows * result_cols > _parallelMinimum &&
		//							result_rows < result_cols)
		//						{
		//								#region flattened arrays

		//								if (left.CurrentFormat == Matrix<generic>.Format.FlattenedArray &&
		//									right.CurrentFormat == Matrix<generic>.Format.FlattenedArray)
		//								{

		//										Matrix<generic> result =
		//											new Matrix<generic>(result_rows, result_cols);
		//#if unsafe_code
		//										unsafe
		//										{
		//												Seven.Parallels.AutoParallel.Divide(
		//													(int current, int max) =>
		//													{
		//															return () =>
		//															{
		//																	generic sum;
		//																	int left_i_offest;
		//																	int result_i_offset;

		//																	fixed (generic*
		//																		result_flat = result._matrix as generic[],
		//																		left_flat = left._matrix as generic[],
		//																		right_flat = right._matrix as generic[])
		//																			for (int i = 0; i < result_rows; i++)
		//																			{
		//																					left_i_offest = i * left_cols;
		//																					result_i_offset = i * result_cols;
		//																					for (int j = current; j < result_cols; j += max)
		//																					{
		//																							sum = 0;
		//																							for (int k = 0; k < left_cols; k++)
		//																									sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
		//																							result_flat[result_i_offset + j] = sum;
		//																					}
		//																			}
		//															};
		//													}, result_cols);
		//										}
		//#else
		//				generic[] result_flat = result._matrix as generic[];
		//				generic[] left_flat = left._matrix as generic[];
		//				generic[] right_flat = right._matrix as generic[];

		//				Seven.Parallels.AutoParallel.Divide(
		//						(int current, int max) =>
		//						{
		//							return () =>
		//							{
		//								generic sum;
		//								int left_i_offest;
		//								int result_i_offset;

		//								for (int i = 0; i < result_rows; i++)
		//								{
		//									left_i_offest = i * left_cols;
		//									result_i_offset = i * result_cols;
		//									for (int j = current; j < result_cols; j += max)
		//									{
		//										sum = 0;
		//										for (int k = 0; k < left_cols; k++)
		//											sum += left_flat[left_i_offest + k] * right_flat[k * result_cols + j];
		//										result_flat[result_i_offset + j] = sum;
		//									}
		//								}
		//							};
		//						}, result_cols);
		//#endif
		//										return result;

		//								}

		//								#endregion
		//						}
		//						// Multi-threading is not necessary.
		//						return LinearAlgebra.Multiply(left, right);
		//				}

		#endregion
		
		#endregion

		#region quaternion

		/// <summary>Computes the length of quaternion.</summary>
		public static Compute<T>.Delegates.Quaternion_Magnitude Quaternion_Magnitude = (Quaternion<T> quaternion) =>
		#region code
		{
			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Quaternion_Magnitude compile_testing =
				(Quaternion<Numeric> _quaternion) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_quaternion, null))
						throw new Error("null reference: _quaternion");
#endif
					return Compute<Numeric>.SquareRoot(
						(_quaternion.X * _quaternion.X +
						_quaternion.Y * _quaternion.Y +
						_quaternion.Z * _quaternion.Z +
						_quaternion.W * _quaternion.W));
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Quaternion_Magnitude_string =
				"(Quaternion<" + num + "> _quaternion) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_quaternion, null))" +
				"		throw new Error(\"null reference: _quaternion\");" +
#endif
 "	return Algebra<" + num + ">.sqrt(" +
				"		(_quaternion.X * _quaternion.X +" +
				"		_quaternion.Y * _quaternion.Y +" +
				"		_quaternion.Z * _quaternion.Z +" +
				"		_quaternion.W * _quaternion.W));" +
				"}";

			#endregion

			Compute<T>.Quaternion_Magnitude =
				Meta.Compile<Compute<T>.Delegates.Quaternion_Magnitude>(Quaternion_Magnitude_string);

			return Compute<T>.Quaternion_Magnitude(quaternion);
		};
		#endregion

		/// <summary>Computes the length of a quaternion, but doesn't square root it.</summary>
		public static Compute<T>.Delegates.Quaternion_MagnitudeSquared Quaternion_MagnitudeSquared = (Quaternion<T> quaternion) =>
		#region code
		{
			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Quaternion_MagnitudeSquared compile_testing =
				(Quaternion<Numeric> _quaternion) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_quaternion, null))
						throw new Error("null reference: _quaternion");
#endif
					return
						_quaternion.X * _quaternion.X +
						_quaternion.Y * _quaternion.Y +
						_quaternion.Z * _quaternion.Z +
						_quaternion.W * _quaternion.W;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Quaternion_MagnitudeSquared_string =
				"(Quaternion<" + num + "> _quaternion) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_quaternion, null))" +
				"		throw new Error(\"null reference: _quaternion\");" +
#endif
 "	return" +
				"		_quaternion.X * _quaternion.X +" +
				"		_quaternion.Y * _quaternion.Y +" +
				"		_quaternion.Z * _quaternion.Z +" +
				"		_quaternion.W * _quaternion.W;" +
				"}";

			#endregion

			Compute<T>.Quaternion_MagnitudeSquared =
				Meta.Compile<Compute<T>.Delegates.Quaternion_MagnitudeSquared>(Quaternion_MagnitudeSquared_string);

			return Compute<T>.Quaternion_MagnitudeSquared(quaternion);
		};
		#endregion

		/// <summary>Gets the conjugate of the quaternion.</summary>
		public static Compute<T>.Delegates.Quaternion_Conjugate Quaternion_Conjugate = (Quaternion<T> quaternion) =>
		#region code
		{
			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Quaternion_Conjugate compile_testing =
				(Quaternion<Numeric> _quaternion) =>
				{
#if no_error_checking
								// nothing
#else
					if (_quaternion == null)
						throw new Error("null reference: quaternion");
#endif
					return new Quaternion<Numeric>(
						-_quaternion.X,
						-_quaternion.Y,
						-_quaternion.Z,
						_quaternion.W);
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Quaternion_Conjugate_string =
				"(Quaternion<" + num + "> _quaternion) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (_quaternion == null)" +
				"		throw new Error(\"null reference: quaternion\");" +
#endif
 "	return new Quaternion<" + num + ">(" +
				"		-_quaternion.X," +
				"		-_quaternion.Y," +
				"		-_quaternion.Z," +
				"		_quaternion.W);" +
				"}";

			#endregion

			Compute<T>.Quaternion_Conjugate =
				Meta.Compile<Compute<T>.Delegates.Quaternion_Conjugate>(Quaternion_Conjugate_string);

			return Compute<T>.Quaternion_Conjugate(quaternion);
		};
		#endregion

		/// <summary>Adds two quaternions together.</summary>
		public static Compute<T>.Delegates.Quaternion_Add Quaternion_Add = (Quaternion<T> left, Quaternion<T> right) =>
		#region code
		{
			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Quaternion_Add compile_testing =
				(Quaternion<Numeric> _left, Quaternion<Numeric> _right) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_left, null))
						throw new Error("null reference: _left");
					if (object.ReferenceEquals(_right, null))
						throw new Error("null reference: _right");
#endif
					return new Quaternion<Numeric>(
						_left.X + _right.X,
						_left.Y + _right.Y,
						_left.Z + _right.Z,
						_left.W + _right.W);
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Quaternion_Add_string =
				"(Quaternion<" + num + "> _left, Quaternion<" + num + "> _right) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_left, null))" +
				"		throw new Error(\"null reference: _left\");" +
				"	if (object.ReferenceEquals(_right, null))" +
				"		throw new Error(\"null reference: _right\");" +
#endif
 "	return new Quaternion<" + num + ">(" +
				"		_left.X + _right.X," +
				"		_left.Y + _right.Y," +
				"		_left.Z + _right.Z," +
				"		_left.W + _right.W);" +
				"}";

			#endregion

			Compute<T>.Quaternion_Add =
				Meta.Compile<Compute<T>.Delegates.Quaternion_Add>(Quaternion_Add_string);

			return Compute<T>.Quaternion_Add(left, right);
		};
		#endregion

		/// <summary>Subtracts two quaternions.</summary>
		public static Compute<T>.Delegates.Quaternion_Subtract Quaternion_Subtract = (Quaternion<T> left, Quaternion<T> right) =>
		#region code
		{
			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Quaternion_Subtract compile_testing =
				(Quaternion<Numeric> _left, Quaternion<Numeric> _right) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_left, null))
						throw new Error("null reference: _left");
					if (object.ReferenceEquals(_right, null))
						throw new Error("null reference: _right");
#endif
					return new Quaternion<Numeric>(
						_left.X - _right.X,
						_left.Y - _right.Y,
						_left.Z - _right.Z,
						_left.W - _right.W);
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Quaternion_Subtract_string =
				"(Quaternion<" + num + "> _left, Quaternion<" + num + "> _right) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_left, null))" +
				"		throw new Error(\"null reference: _left\");" +
				"	if (object.ReferenceEquals(_right, null))" +
				"		throw new Error(\"null reference: _right\");" +
#endif
 "	return new Quaternion<" + num + ">(" +
				"		_left.X - _right.X," +
				"		_left.Y - _right.Y," +
				"		_left.Z - _right.Z," +
				"		_left.W - _right.W);" +
				"}";

			#endregion

			Compute<T>.Quaternion_Subtract =
				Meta.Compile<Compute<T>.Delegates.Quaternion_Subtract>(Quaternion_Subtract_string);

			return Compute<T>.Quaternion_Subtract(left, right);
		};
		#endregion

		/// <summary>Multiplies two quaternions together.</summary>
		public static Compute<T>.Delegates.Quaternion_Multiply Quaternion_Multiply = (Quaternion<T> left, Quaternion<T> right) =>
		#region code
		{
			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Quaternion_Multiply compile_testing =
				(Quaternion<Numeric> _left, Quaternion<Numeric> _right) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_left, null))
						throw new Error("null reference: _left");
					if (object.ReferenceEquals(_right, null))
						throw new Error("null reference: _right");
#endif
					return new Quaternion<Numeric>(
						_left.X * _right.W + _left.W * _right.X + _left.Y * _right.Z - _left.Z * _right.Y,
						_left.Y * _right.W + _left.W * _right.Y + _left.Z * _right.X - _left.X * _right.Z,
						_left.Z * _right.W + _left.W * _right.Z + _left.X * _right.Y - _left.Y * _right.X,
						_left.W * _right.W - _left.X * _right.X - _left.Y * _right.Y - _left.Z * _right.Z);
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Quaternion_Multiply_string =
				"(Quaternion<" + num + "> _left, Quaternion<" + num + "> _right) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_left, null))" +
				"		throw new Error(\"null reference: _left\");" +
				"	if (object.ReferenceEquals(_right, null))" +
				"		throw new Error(\"null reference: _right\");" +
#endif
 "	return new Quaternion<" + num + ">(" +
				"		_left.X * _right.W + _left.W * _right.X + _left.Y * _right.Z - _left.Z * _right.Y," +
				"		_left.Y * _right.W + _left.W * _right.Y + _left.Z * _right.X - _left.X * _right.Z," +
				"		_left.Z * _right.W + _left.W * _right.Z + _left.X * _right.Y - _left.Y * _right.X," +
				"		_left.W * _right.W - _left.X * _right.X - _left.Y * _right.Y - _left.Z * _right.Z);" +
				"}";

			#endregion

			Compute<T>.Quaternion_Multiply =
				Meta.Compile<Compute<T>.Delegates.Quaternion_Multiply>(Quaternion_Multiply_string);

			return Compute<T>.Quaternion_Multiply(left, right);
		};
		#endregion

		/// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
		public static Compute<T>.Delegates.Quaternion_Multiply_scalar Quaternion_Multiply_scalar = (Quaternion<T> left, T right) =>
		#region code
		{
			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Quaternion_Multiply_scalar compile_testing =
				(Quaternion<Numeric> _left, Numeric _right) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_left, null))
						throw new Error("null reference: _left");
#endif
					return new Quaternion<Numeric>(
						_left.X * _right,
						_left.Y * _right,
						_left.Z * _right,
						_left.W * _right);
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Quaternion_Multiply_scalar_string =
				"(Quaternion<" + num + "> _left, " + num + " _right) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_left, null))" +
				"		throw new Error(\"null reference: _left\");" +
#endif
 "	return new Quaternion<" + num + ">(" +
				"		_left.X * _right," +
				"		_left.Y * _right," +
				"		_left.Z * _right," +
				"		_left.W * _right);" +
				"}";

			#endregion

			Compute<T>.Quaternion_Multiply_scalar =
				Meta.Compile<Compute<T>.Delegates.Quaternion_Multiply_scalar>(Quaternion_Multiply_scalar_string);

			return Compute<T>.Quaternion_Multiply_scalar(left, right);
		};
		#endregion

		/// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
		public static Compute<T>.Delegates.Quaternion_Multiply_Vector Quaternion_Multiply_Vector = (Quaternion<T> left, Vector<T> right) =>
		#region code
		{
			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Quaternion_Multiply_Vector compile_testing =
				(Quaternion<Numeric> _left, Vector<Numeric> _right) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_left, null))
						throw new Error("null reference: _left");
					if (object.ReferenceEquals(_right, null))
						throw new Error("null reference: _right");
					if (_right.Dimensions != 3)
						throw new Error("my quaternion rotations are only defined for 3-component vectors.");
#endif
					return new Quaternion<Numeric>(
						_left.W * _right.X + _left.Y * _right.Z - _left.Z * _right.Y,
						_left.W * _right.Y + _left.Z * _right.X - _left.X * _right.Z,
						_left.W * _right.Z + _left.X * _right.Y - _left.Y * _right.X,
						-_left.X * _right.X - _left.Y * _right.Y - _left.Z * _right.Z);
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Quaternion_Multiply_Vector_string =
				"(Quaternion<" + num + "> _left, Vector<" + num + "> _right) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_left, null))" +
				"		throw new Error(\"null reference: _left\");" +
				"	if (object.ReferenceEquals(_right, null))" +
				"		throw new Error(\"null reference: _right\");" +
				"	if (_right.Dimensions != 3)" +
				"		throw new Error(\"my quaternion rotations are only defined for 3-component vectors.\");" +
#endif
 "	return new Quaternion<" + num + ">(" +
				"		_left.W * _right.X + _left.Y * _right.Z - _left.Z * _right.Y," +
				"		_left.W * _right.Y + _left.Z * _right.X - _left.X * _right.Z," +
				"		_left.W * _right.Z + _left.X * _right.Y - _left.Y * _right.X," +
				"		-_left.X * _right.X - _left.Y * _right.Y - _left.Z * _right.Z);" +
				"}";

			#endregion

			Compute<T>.Quaternion_Multiply_Vector =
				Meta.Compile<Compute<T>.Delegates.Quaternion_Multiply_Vector>(Quaternion_Multiply_Vector_string);

			return Compute<T>.Quaternion_Multiply_Vector(left, right);
		};
		#endregion

		/// <summary>Normalizes the quaternion.</summary>
		public static Compute<T>.Delegates.Quaternion_Normalize Quaternion_Normalize = (Quaternion<T> quaternion) =>
		#region code
		{
			#region generic
#if hide_generic
						Quaternion<generic>.delegates.Quaternion_Normalize compile_testing =
							(Quaternion<generic> _quaternion) =>
							{
#if no_error_checking
								// nothing
#else
								if (object.ReferenceEquals(_quaternion, null))
									throw new Error("null reference: quaternion");
#endif
								generic normalizer = Quaternion<generic>.Magnitude(_quaternion);
								if (normalizer != 0)
									return _quaternion * (1 / normalizer);
								else
									return new Quaternion<generic>(0, 0, 0, 1);
							};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Quaternion_Normalize_string =
				"(Quaternion<" + num + "> _quaternion) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_quaternion, null))" +
				"		throw new Error(\"null reference: quaternion\");" +
#endif
 "	" + num + " normalizer = Quaternion<" + num + ">.Magnitude(_quaternion);" +
				"	if (normalizer != 0)" +
				"		return _quaternion * (1 / normalizer);" +
				"	else" +
				"		return new Quaternion<" + num + ">(0, 0, 0, 1);" +
				"}";

			#endregion

			Compute<T>.Quaternion_Normalize =
				Meta.Compile<Compute<T>.Delegates.Quaternion_Normalize>(Quaternion_Normalize_string);

			return Compute<T>.Quaternion_Normalize(quaternion);
		};
		#endregion

		/// <summary>Inverts a quaternion.</summary>
		public static Compute<T>.Delegates.Quaternion_Invert Quaternion_Invert = (Quaternion<T> quaternion) =>
		#region code
		{
			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Quaternion_Invert compile_testing =
				(Quaternion<Numeric> _quaternion) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_quaternion, null))
						throw new Error("null reference: quaternion");
#endif
					Numeric normalizer = Quaternion<Numeric>.MagnitudeSquared(_quaternion);
					if (normalizer == 0)
						return new Quaternion<Numeric>(_quaternion.X, _quaternion.Y, _quaternion.Z, _quaternion.W);
					normalizer = 1 / normalizer;
					return new Quaternion<Numeric>(
						-_quaternion.X * normalizer,
						-_quaternion.Y * normalizer,
						-_quaternion.Z * normalizer,
						_quaternion.W * normalizer);
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Quaternion_Invert_string =
				"(Quaternion<" + num + "> _quaternion) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_quaternion, null))" +
				"		throw new Error(\"null reference: quaternion\");" +
#endif
 "	" + num + " normalizer = Quaternion<" + num + ">.MagnitudeSquared(_quaternion);" +
				"	if (normalizer == 0)" +
				"		return new Quaternion<" + num + ">(_quaternion.X, _quaternion.Y, _quaternion.Z, _quaternion.W);" +
				"	normalizer = 1 / normalizer;" +
				"	return new Quaternion<" + num + ">(" +
				"		-_quaternion.X * normalizer," +
				"		-_quaternion.Y * normalizer," +
				"		-_quaternion.Z * normalizer," +
				"		_quaternion.W * normalizer);" +
				"}";

			#endregion

			Compute<T>.Quaternion_Invert =
				Meta.Compile<Compute<T>.Delegates.Quaternion_Invert>(Quaternion_Invert_string);

			return Compute<T>.Quaternion_Normalize(quaternion);
		};
		#endregion

		/// <summary>Lenearly interpolates between two quaternions.</summary>
		public static Compute<T>.Delegates.Quaternion_Lerp Quaternion_Lerp = (Quaternion<T> left, Quaternion<T> right, T blend) =>
		#region code
		{
			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Quaternion_Lerp compile_testing =
				(Quaternion<Numeric> _left, Quaternion<Numeric> _right, Numeric _blend) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_left, null))
						throw new Error("null reference: _left");
					if (object.ReferenceEquals(_right, null))
						throw new Error("null reference: _right");
#endif
					if (_blend < 0 || _blend > 1)
						throw new Error("invalid _blending value during lerp !(_blend < 0.0f || _blend > 1.0f).");
					if (Quaternion<Numeric>.MagnitudeSquared(_left) == 0)
					{
						if (Quaternion<Numeric>.MagnitudeSquared(_right) == 0)
							return new Quaternion<Numeric>(0, 0, 0, 1);
						else
							return new Quaternion<Numeric>(_right.X, _right.Y, _right.Z, _right.W);
					}
					else if (Quaternion<Numeric>.MagnitudeSquared(_right) == 0)
						return new Quaternion<Numeric>(_left.X, _left.Y, _left.Z, _left.W);
					Quaternion<Numeric> result = new Quaternion<Numeric>(
						1 - _blend * _left.X + _blend * _right.X,
						1 - _blend * _left.Y + _blend * _right.Y,
						1 - _blend * _left.Z + _blend * _right.Z,
						1 - _blend * _left.W + _blend * _right.W);
					if (Quaternion<Numeric>.MagnitudeSquared(result) > 0)
						return Quaternion<Numeric>.Normalize(result);
					else
						return new Quaternion<Numeric>(0, 0, 0, 1);
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Quaternion_Lerp_string =
				"(Quaternion<" + num + "> _left, Quaternion<" + num + "> _right, " + num + " _blend) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_left, null))" +
				"		throw new Error(\"null reference: _left\");" +
				"	if (object.ReferenceEquals(_right, null))" +
				"		throw new Error(\"null reference: _right\");" +
#endif
 "	if (_blend < 0 || _blend > 1)" +
				"		throw new Error(\"invalid _blending value during lerp !(_blend < 0.0f || _blend > 1.0f).\");" +
				"	if (Quaternion<" + num + ">.MagnitudeSquared(_left) == 0)" +
				"	{" +
				"		if (Quaternion<" + num + ">.MagnitudeSquared(_right) == 0)" +
				"			return new Quaternion<" + num + ">(0, 0, 0, 1);" +
				"		else" +
				"			return new Quaternion<" + num + ">(_right.X, _right.Y, _right.Z, _right.W);" +
				"	}" +
				"	else if (Quaternion<" + num + ">.MagnitudeSquared(_right) == 0)" +
				"		return new Quaternion<" + num + ">(_left.X, _left.Y, _left.Z, _left.W);" +
				"	Quaternion<" + num + "> result = new Quaternion<" + num + ">(" +
				"		1 - _blend * _left.X + _blend * _right.X," +
				"		1 - _blend * _left.Y + _blend * _right.Y," +
				"		1 - _blend * _left.Z + _blend * _right.Z," +
				"		1 - _blend * _left.W + _blend * _right.W);" +
				"	if (Quaternion<" + num + ">.MagnitudeSquared(result) > 0)" +
				"		return Quaternion<" + num + ">.Normalize(result);" +
				"	else" +
				"		return new Quaternion<" + num + ">(0, 0, 0, 1);" +
				"}";

			#endregion

			Compute<T>.Quaternion_Lerp =
				Meta.Compile<Compute<T>.Delegates.Quaternion_Lerp>(Quaternion_Lerp_string);

			return Compute<T>.Quaternion_Lerp(left, right, blend);
		};
		#endregion

		/// <summary>Sphereically interpolates between two quaternions.</summary>
		public static Compute<T>.Delegates.Quaternion_Slerp Quaternion_Slerp = (Quaternion<T> left, Quaternion<T> right, T blend) =>
		#region code
		{
			throw new Error("not yet implemented");

			//Quaternion<generic>.delegates.Quaternion_Slerp compile_testing =
			//	#region code (compile testing)

			//	#endregion

			//string Quaternion_Lerp_string =
			//	#region code (string)

			//	#endregion

			//Quaternion_Slerp_string = Quaternion_Slerp_string.Replace("generic", Generate.ToSourceString(typeof(T)));

			//Compute<T>.Quaternion_Slerp =
			//	Generate.Object<Compute<T>.delegates.Quaternion_Slerp>(Quaternion_Slerp_string);

			//return Compute<T>.Quaternion_Slerp(left, right, blend);
		};
		#endregion

		/// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
		public static Compute<T>.Delegates.Quaternion_Rotate Quaternion_Rotate = (Quaternion<T> rotation, Vector<T> vector) =>
		#region code
		{
			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Quaternion_Rotate compile_testing =
				(Quaternion<Numeric> _rotation, Vector<Numeric> _vector) =>
				{
#if no_error_checking
								// nothing
#else
					if (object.ReferenceEquals(_rotation, null))
						throw new Error("null reference: rotation");
					if (object.ReferenceEquals(_vector, null))
						throw new Error("null reference: vector");
#endif
					if (_vector.Dimensions != 3 && _vector.Dimensions != 4)
						throw new Error("my quaternion rotations are only defined for 3-component vectors.");
					Quaternion<Numeric> answer =
						Compute<Numeric>.Quaternion_Multiply(
						Compute<Numeric>.Quaternion_Multiply_Vector(_rotation, _vector),
						Compute<Numeric>.Quaternion_Conjugate(_rotation));
					return new Vector<Numeric>(answer.X, answer.Y, answer.Z);
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Quaternion_Rotate_string =
				"(Quaternion<" + num + "> _rotation, Vector<" + num + "> _vector) =>" +
				"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_rotation, null))" +
				"		throw new Error(\"null reference: rotation\");" +
				"	if (object.ReferenceEquals(_vector, null))" +
				"		throw new Error(\"null reference: vector\");" +
#endif
 "	if (_vector.Dimensions != 3 && _vector.Dimensions != 4)" +
				"		throw new Error(\"my quaternion rotations are only defined for 3-component vectors.\");" +
				"	Quaternion<" + num + "> answer =" +
				"		Compute<" + num + ">.Quaternion_Multiply(" +
				"		Compute<" + num + ">.Quaternion_Multiply_Vector(_rotation, _vector)," +
				"		Compute<" + num + ">.Quaternion_Conjugate(_rotation));" +
				"	return new Vector<" + num + ">(answer.X, answer.Y, answer.Z);" +
				"}";

			#endregion

			Compute<T>.Quaternion_Rotate =
				Meta.Compile<Compute<T>.Delegates.Quaternion_Rotate>(Quaternion_Rotate_string);

			return Compute<T>.Quaternion_Rotate(rotation, vector);
		};
		#endregion

		/// <summary>Does a value equality check.</summary>
		public static Compute<T>.Delegates.Quaternion_EqualsValue Quaternion_EqualsValue = (Quaternion<T> left, Quaternion<T> right) =>
		#region code
		{
			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Quaternion_EqualsValue compile_testing =
			#region code (compile testing)
 (Quaternion<Numeric> _left, Quaternion<Numeric> _right) =>
 {
	 if (object.ReferenceEquals(_left, null) && object.ReferenceEquals(_right, null))
		 return true;
	 if (object.ReferenceEquals(_left, null))
		 return false;
	 if (object.ReferenceEquals(_right, null))
		 return false;
	 return
		 _left.X == _right.X &&
		 _left.Y == _right.Y &&
		 _left.Z == _right.Z &&
		 _left.W == _right.W;
 };
			#endregion
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Quaternion_EqualsValue_string =
				"(Quaternion<" + num + "> _left, Quaternion<" + num + "> _right) =>" +
				"{" +
				"	if (object.ReferenceEquals(_left, null) && object.ReferenceEquals(_right, null))" +
				"		return true;" +
				"	if (object.ReferenceEquals(_left, null))" +
				"		return false;" +
				"	if (object.ReferenceEquals(_right, null))" +
				"		return false;" +
				"	return" +
				"		_left.X == _right.X &&" +
				"		_left.Y == _right.Y &&" +
				"		_left.Z == _right.Z &&" +
				"		_left.W == _right.W;" +
				"}";

			#endregion

			Compute<T>.Quaternion_EqualsValue =
				Meta.Compile<Compute<T>.Delegates.Quaternion_EqualsValue>(Quaternion_EqualsValue_string);

			return Compute<T>.Quaternion_EqualsValue(left, right);
		};
		#endregion

		/// <summary>Does a value equality check with leniency.</summary>
		public static Compute<T>.Delegates.Quaternion_EqualsValue_leniency Quaternion_EqualsValue_leniency = (Quaternion<T> left, Quaternion<T> right, T leniency) =>
		#region code
		{
			#region generic
#if show_Numeric
			Compute<Numeric>.delegates.Quaternion_EqualsValue_leniency compile_testing =
				(Quaternion<Numeric> _left, Quaternion<Numeric> _right, Numeric _leniency) =>
				{
					if (object.ReferenceEquals(_left, null) && object.ReferenceEquals(_right, null))
						return true;
					if (object.ReferenceEquals(_left, null))
						return false;
					if (object.ReferenceEquals(_right, null))
						return false;
					return
						Compute<Numeric>.AbsoluteValue(_left.X - _right.X) < _leniency &&
						Compute<Numeric>.AbsoluteValue(_left.Y - _right.Y) < _leniency &&
						Compute<Numeric>.AbsoluteValue(_left.Z - _right.Z) < _leniency &&
						Compute<Numeric>.AbsoluteValue(_left.W - _right.W) < _leniency;
				};
#endif
			#endregion

			#region string

			string num = Meta.ConvertTypeToCsharpSource(typeof(T));

			string Quaternion_EqualsValue_leniency_string =
				"(Quaternion<" + num + "> _left, Quaternion<" + num + "> _right, " + num + " _leniency) =>" +
				"{" +
				"	if (object.ReferenceEquals(_left, null) && object.ReferenceEquals(_right, null))" +
				"		return true;" +
				"	if (object.ReferenceEquals(_left, null))" +
				"		return false;" +
				"	if (object.ReferenceEquals(_right, null))" +
				"		return false;" +
				"	return" +
				"		Logic<" + num + ">.Abs(_left.X - _right.X) < _leniency &&" +
				"		Logic<" + num + ">.Abs(_left.Y - _right.Y) < _leniency &&" +
				"		Logic<" + num + ">.Abs(_left.Z - _right.Z) < _leniency &&" +
				"		Logic<" + num + ">.Abs(_left.W - _right.W) < _leniency;" +
				"}";

			#endregion

			Compute<T>.Quaternion_EqualsValue_leniency =
				Meta.Compile<Compute<T>.Delegates.Quaternion_EqualsValue_leniency>(Quaternion_EqualsValue_leniency_string);

			return Compute<T>.Quaternion_EqualsValue_leniency(left, right, leniency);
		};
		#endregion

		#region generic

		///// <summary>Sphereically interpolates between two quaternions.</summary>
		///// <param name="left">The starting point of the interpolation.</param>
		///// <param name="right">The ending point of the interpolation.</param>
		///// <param name="blend">The ratio of how far to interpolate between the left and right quaternions.</param>
		///// <returns>The result of the interpolation.</returns>
		//public static Quaternion<generic> Slerp(Quaternion<generic> left, Quaternion<generic> right, generic blend)
		//{
		//		throw new Error("requires rational rational types");

		//		//#if no_error_checking
		//		//			// nothing
		//		//#else
		//		//			if (object.ReferenceEquals(left, null))
		//		//				throw new Error("null reference: left");
		//		//			if (object.ReferenceEquals(right, null))
		//		//				throw new Error("null reference: right");
		//		//#endif

		//		//			if (blend < 0 || blend > 1)
		//		//				throw new Error("invalid blending value during slerp !(blend < 0.0f || blend > 1.0f).");
		//		//			if (LinearAlgebra.MagnitudeSquared(left) == 0)
		//		//			{
		//		//				if (LinearAlgebra.MagnitudeSquared(right) == 0)
		//		//					return Quaternion<generic>.FactoryIdentity;
		//		//				else
		//		//					return new Quaternion<generic>(right.X, right.Y, right.Z, right.W);
		//		//			}
		//		//			else if (LinearAlgebra.MagnitudeSquared(right) == 0)
		//		//				return new Quaternion<generic>(left.X, left.Y, left.Z, left.W);
		//		//			generic cosHalfAngle = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
		//		//			if (cosHalfAngle >= 1 || cosHalfAngle <= -1)
		//		//				return new Quaternion<generic>(left.X, left.Y, left.Z, left.W);
		//		//			else if (cosHalfAngle < 0)
		//		//			{
		//		//				right = new Quaternion<generic>(-left.X, -left.Y, -left.Z, -left.W);
		//		//				cosHalfAngle = -cosHalfAngle;
		//		//			}
		//		//			generic halfAngle = Trigonometry.arccos(cosHalfAngle);
		//		//			generic sinHalfAngle = Trigonometry.sin(halfAngle);
		//		//			generic blendA = Trigonometry.sin(halfAngle * (1 - blend)) / sinHalfAngle;
		//		//			generic blendB = Trigonometry.sin(halfAngle * blend) / sinHalfAngle;
		//		//			Quaternion<generic> result = new Quaternion<generic>(
		//		//				blendA * left.X + blendB * right.X,
		//		//				blendA * left.Y + blendB * right.Y,
		//		//				blendA * left.Z + blendB * right.Z,
		//		//				blendA * left.W + blendB * right.W);
		//		//			if (LinearAlgebra.MagnitudeSquared(result) > 0)
		//		//				return LinearAlgebra.Normalize(result);
		//		//			else
		//		//				return Quaternion<generic>.FactoryIdentity;
		//}

		#endregion

		#endregion

		#endregion

		#region Combinatorics

		#region Factorial
		/// <summary>Computes: [ N! ].</summary>
		public static Compute<T>.Delegates.Factorial Factorial = (T value) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Factorial compile_testing =
				(Numeric N) =>
				{
					if (N % 1 != 0)
						throw new Error("invalid factorial: N must be a whole number.");
					if (N < 0)
						throw new Error("invalid factorial: [ N < 0 ].");
					try
					{
						checked
						{
							Numeric result = 1;
							for (; N > 1; N--)
								result *= N;
							return result;
						}
					}
					catch
					{
						throw new Error("overflow occured in factorial.");
					}
				};
#endif

			Compute<T>.Factorial =
				Meta.Compile<Compute<T>.Delegates.Factorial>(
					string.Concat(
@"(", Type_String, @" N) =>
{
	if (N % 1 != 0)
		throw new Error(", "\"invalid factorial: N must be a whole number.\"", @");
	if (N < 0)
		throw new Error(", "\"invalid factorial: [ N < 0 ] (N = \\\" + N + \\\").\"", @");
	", Type_String, @" result = 1;
	for (; N > 1; N--)
		result *= N;
	return result;
}"));

			return Compute<T>.Factorial(value);
		};
		#endregion

		#region Combinations
		/// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
		public static Compute<T>.Delegates.Combinations Combinations = (T N, T[] n) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Combinations compile_testing =
				(Numeric _N, Numeric[] _n) =>
				{
					if (_N % 1 != 0)
						throw new Error("invalid combination: N must be a whole number.");
					for (int i = 0; i < _n.Length; i++)
						if (_n[i] % 1 != 0)
							throw new Error("invalid combination: n[" + i + "] must be a whole number.");
					Numeric result = Compute<Numeric>.Factorial(_N);
					Numeric sum = 0;
					for (int i = 0; i < _n.Length; i++)
					{
						result /= Compute<Numeric>.Factorial(_n[i]);
						sum += _n[i];
					}
					if (sum > _N)
						throw new Error("invalid combination: [ N < Sum(n) ].");
					return result;
				};
#endif

			Compute<T>.Combinations =
				Meta.Compile<Compute<T>.Delegates.Combinations>(
					string.Concat(
@"(", Type_String, " _N, ", Type_String, @"[] _n) =>
{
	if (_N % 1 != 0)
		throw new Error(", "\"invalid combination: N must be a whole number.\"", @");
	for (int i = 0; i < _n.Length; i++)
		if (_n[i] % 1 != 0)
			throw new Error(", "\"invalid combination: n[\\\" + i + \\\"] must be a whole number.\"", @");
	", Type_String, " result = Compute<", Type_String, @">.Factorial(_N);
	", Type_String, @" sum = 0;
	for (int i = 0; i < _n.Length; i++)
	{
		result /= Compute<", Type_String, @">.Factorial(_n[i]);
		sum += _n[i];
	}
	if (sum > _N)
		throw new Error(", "\"invalid combination: [ N < Sum(n) ].\"", @");
	return result;
}"));

			return Compute<T>.Combinations(N, n);
		};
		#endregion

		#region Choose
		/// <summary>Computes: [ N! / (N - n)! ]</summary>
		public static Compute<T>.Delegates.Choose Choose = (T N, T n) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Choose compile_testing =
				(Numeric _N, Numeric _n) =>
				{
					if (_N % 1 != 0)
						throw new Error("invalid chose: N must be a whole number.");
					if (_n % 1 != 0)
						throw new Error("invalid combination: n must be a whole number.");
					if (!(_N <= _n || _N >= 0))
						throw new Error("invalid choose: [ !(N <= n || N >= 0) ].");
					return Compute<Numeric>.Factorial(_N) / (Compute<Numeric>.Factorial(_n) * Compute<Numeric>.Factorial(_N - _n));
				};
#endif

			Compute<T>.Choose =
				Meta.Compile<Compute<T>.Delegates.Choose>(
					string.Concat(
@"(", Type_String, " _N, ", Type_String, @" _n) =>
{
	if (_N % 1 != 0)
		throw new Error(", "\"invalid chose: N must be a whole number.\"", @");
	if (_n % 1 != 0)
		throw new Error(", "\"invalid combination: n must be a whole number.\"", @");
	if (!(_N <= _n || _N >= 0))
		throw new Error(", "\"invalid choose: [ !(N <= n || N >= 0) ].\"", @");
	", Type_String, " factorial_N = Compute<", Type_String, @">.Factorial(_N);
	return Compute<", Type_String, ">.Factorial(_N) / (Compute<", Type_String, ">.Factorial(_n) * Compute<", Type_String, @">.Factorial(_N - _n));
}"));

			return Compute<T>.Choose(N, n);
		};
		#endregion

		#endregion

		#region Statistics

		#region Mode
		/// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
		public static Compute<T>.Delegates.Mode Mode = (Stepper<T> stepper) =>
		{
#if show_Numeric
			// This is just a compile test. Vector_Add_string (see below) should match this code exactly.
			Compute<Numeric>.delegates.Mode compile_testing =
				(Stepper<Numeric> _stepper) =>
				{
					Heap_Array<Link<Numeric, int>> heap =
						new Heap_Array<Link<Numeric, int>>(
							(Link<Numeric, int> left, Link<Numeric, int> right) =>
							{
								return Compute<Numeric>.Compare(left.One, right.One);
							});
					_stepper((Numeric step) =>
					{
						bool contains = false;
						heap.Stepper((Link<Numeric, int> nested_step) =>
						{
							if (Seven.Equate.Default<Numeric>(nested_step.One, step))
							{
								contains = true;
								nested_step.Two++;
								heap.Requeue(nested_step);
								return StepStatus.Break;
							}
							else
								return StepStatus.Continue;
						});
						if (!contains)
							heap.Enqueue(new Link<Numeric, int>(step, 1));
					});
					return heap;
				};
#endif

			Compute<T>.Mode =
				Meta.Compile<Compute<T>.Delegates.Mode>(
					string.Concat(
@"(Stepper<", Type_String, @"> stepper) =>
{
	Heap_Array<Link<", Type_String, @", int>> heap =
		new Heap_Array<Link<", Type_String, @", int>>(
			(Link<", Type_String, ", int> left, Link<", Type_String, @", int> right) =>
			{
				return Compute<", Type_String, @">.Compare(left.One, right.One);
			});
	stepper((", Type_String, @" step) =>
	{
		bool contains = false;
		heap.Stepper((Link<", Type_String, @", int> nested_step) =>
		{
			if (Compute<", Type_String, @">.Equate(nested_step.One, step))
			{
				contains = true;
				nested_step.Two++;
				heap.Requeue(nested_step);
				return StepStatus.Break;
			}
			else
				return StepStatus.Continue;
		});
		if (!contains)
			heap.Enqueue(new Link<", Type_String, @", int>(step, 1));
	});
	return heap;
}"));

			return Compute<T>.Mode(stepper);
		};
		#endregion

		#region Mean
		/// <summary>Computes the mean (or average) between multiple values.</summary>
		public static Compute<T>.Delegates.Mean Mean = (Stepper<T> stepper) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Mean compile_testing =
				(Stepper<Numeric> _stepper) =>
				{
					Numeric i = 0;
					Numeric sum = 0;
					_stepper((Numeric step) => { i++; sum += step; });
					return sum / i;
				};
#endif

			Compute<T>.Mean =
				Meta.Compile<Compute<T>.Delegates.Mean>(
					string.Concat(
@"(Stepper<", Type_String, @"> stepper) =>
{
	", Type_String, @" i = 0;
	", Type_String, @" sum = 0;
	stepper((", Type_String, @" step) => { i++; sum += step; });
	return sum / i;
}"));

			return Compute<T>.Mean(stepper);
		};
		#endregion

		#region Median
		/// <summary>Computes the median of a set of values.</summary>
		public static Compute<T>.Delegates.Median Median = (Stepper<T> stepper) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Median compile_testing =
				(Stepper<Numeric> _stepper) =>
				{
					long count = 0;
					_stepper((Numeric step) => { count++; });
					long half = count / 2;
					if (count % 1 == 0)
					{
						Numeric left = default(Numeric);
						Numeric right = default(Numeric);
						count = 0;
						_stepper((Numeric step) =>
						{
							if (count == half)
								left = step;
							else if (count == half + 1)
								right = step;
							count++;
						});
						return (left + right) / (Numeric)2;
					}
					else
					{
						Numeric median = default(Numeric);
						_stepper((Numeric i) =>
						{
							count = 0;
							_stepper((Numeric step) =>
							{
								if (count == half)
									median = step;
								count++;
							});
						});
						return median;
					}
				};
#endif

			Compute<T>.Median =
				Meta.Compile<Compute<T>.Delegates.Median>(
					string.Concat(
@"(Stepper<", Type_String, @"> _stepper) =>
{
	long count =	0;
	_stepper((", Type_String, @" step) => { count++; });
	long half = count / 2;
	if (count % 1 == 0)
	{
		", Type_String, " left = default(", Type_String, @");
		", Type_String, " right = default(", Type_String, @");
		count = 0;
		_stepper((", Type_String, @" step) =>
		{
			if (count == half)
				left = step;
			else if (count == half + 1)
				right = step;
			count++;
		});
		return (left + right) / (", Type_String, @")2;
	}
	else
	{
		", Type_String, " median = default(", Type_String, @");
		_stepper((", Type_String, @" i) =>
		{
			count = 0;
			_stepper((", Type_String, @" step) =>
			{
				if (count == half)
					median = step;
				count++;
			});
		});
		return median;
	}
}"));

			return Compute<T>.Median(stepper);
		};
		#endregion

		#region GeometricMean
		/// <summary>Computes the median of a set of values.</summary>
		public static Compute<T>.Delegates.GeometricMean GeometricMean = (Stepper<T> stepper) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.GeometricMean compile_testing =
				(Stepper<Numeric> _stepper) =>
				{
					Numeric multiple = 1;
					int count = 0;
					_stepper((Numeric current) =>
					{
						count++;
						multiple *= current;
					});
					return Compute<Numeric>.Root(multiple, (Numeric)count);
				};
#endif

			Compute<T>.GeometricMean =
				Meta.Compile<Compute<T>.Delegates.GeometricMean>(
					string.Concat(
@"(Stepper<", Type_String, @"> _stepper) =>
{
	", Type_String, @" multiple = 1;
	int count = 0;
	_stepper((", Type_String, @" current) =>
	{
		count++;
		multiple *= current;
	});
	return Compute<", Type_String, ">.Root(multiple, (", Type_String, @")count);
}"));

			return Compute<T>.GeometricMean(stepper);
		};
		#endregion

		#region Variance
		/// <summary>Computes the variance of a set of values.</summary>
		public static Compute<T>.Delegates.Variance Variance = (Stepper<T> stepper) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Variance compile_testing =
				(Stepper<Numeric> _stepper) =>
				{
#if no_error_checking
						// nothing
#else
					if (stepper == null)
						throw new Error("null reference: stepper");
#endif
					Numeric mean = Compute<Numeric>.Mean(_stepper);
					Numeric variance = 0;
					int count = 0;
					_stepper((Numeric i) =>
						{
							Numeric i_minus_mean = i - mean;
							variance += i_minus_mean * i_minus_mean;
							count++;
						});
					return variance / (Numeric)count;
				};
#endif

			Compute<T>.Variance =
				Meta.Compile<Compute<T>.Delegates.Variance>(
					"(Stepper<" + Type_String + "> _stepper) =>" +
					"{" +
#if no_error_checking
						// nothing
#else
 "	if (_stepper == null)" +
					"		throw new Error(\"null reference: _stepper\");" +
#endif
 "	" + Type_String + " mean = Compute<" + Type_String + ">.Mean(_stepper);" +
					"	" + Type_String + " variance = 0;" +
					"	int count = 0;" +
					"	_stepper((" + Type_String + " i) =>" +
					"		{" +
					"			" + Type_String + " i_minus_mean = i - mean;" +
					"			variance += i_minus_mean * i_minus_mean;" +
					"			count++;" +
					"		});" +
					"	return variance / (" + Type_String + ")count;" +
					"}");

			return Compute<T>.Variance(stepper);
		};
		#endregion

		#region StandardDeviation
		/// <summary>Computes the standard deviation of a set of values.</summary>
		public static Compute<T>.Delegates.StandardDeviation StandardDeviation = (Stepper<T> stepper) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.StandardDeviation compile_testing =
				(Stepper<Numeric> _stepper) =>
				{
#if no_error_checking
					// nothing
#else
					if (_stepper == null)
						throw new Error("null reference: _stepper");
#endif
					return Compute<Numeric>.SquareRoot(Compute<Numeric>.Variance(_stepper));
				};
#endif

			Compute<T>.StandardDeviation =
				Meta.Compile<Compute<T>.Delegates.StandardDeviation>(
					string.Concat(
@"(Stepper<", Type_String, @"> _stepper) =>
{",
#if no_error_checking
	// nothing
#else
@"	if (_stepper == null)
		throw new Error(", "\"null reference: _stepper\");",
#endif
@"	return Compute<", Type_String, ">.SquareRoot(Compute<", Type_String, @">.Variance(_stepper));
}"));

			return Compute<T>.StandardDeviation(stepper);
		};
		#endregion

		#region MeanDeviation
		/// <summary>Computes the mean deviation of a set of values.</summary>
		/// <see cref="Seven.Mathematics.Logic<T>.abs"/>
		/// <see cref="Seven.Mathematics.Compute<T>.Mean"/>
		public static Compute<T>.Delegates.MeanDeviation MeanDeviation = (Stepper<T> stepper) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.MeanDeviation compile_testing =
				(Stepper<Numeric> _stepper) =>
				{
					Numeric mean = Compute<Numeric>.Mean(_stepper);
					Numeric temp = 0;
					int count = 0;
					_stepper((Numeric i) =>
					{
						temp += Compute<Numeric>.AbsoluteValue(i - mean);
						count++;
					});
					return temp / (Numeric)count;
				};
#endif

			Compute<T>.MeanDeviation =
				Meta.Compile<Compute<T>.Delegates.MeanDeviation>(
					string.Concat(
@"(Stepper<", Type_String, @"> _stepper) =>
{
	", Type_String, " mean = Compute<", Type_String, @">.Mean(_stepper);
	", Type_String, @" temp = 0;
	int count = 0;
	_stepper((", Type_String, @" i) =>
	{
		temp += Compute<", Type_String, @">.AbsoluteValue(i - mean);
		count++;
	});
	return temp / (", Type_String, @")count;
}"));

			return Compute<T>.MeanDeviation(stepper);
		};
		#endregion

		#region Range
		/// <summary>Computes the standard deviation of a set of values.</summary>
		public static Compute<T>.Delegates.Range Range = (out T min, out T max, Stepper<T> stepper) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Range compile_testing =
				(out Numeric _min, out Numeric _max, Stepper<Numeric> _stepper) =>
				{
					bool set = false;
					Numeric temp_min = 0;
					Numeric temp_max = 0;
					_stepper((Numeric i) =>
					{
						if (!set)
						{
							temp_min = i;
							temp_max = i;
							set = true;
						}
						else
						{
							temp_min = i < temp_min ? i : temp_min;
							temp_max = i > temp_max ? i : temp_max;
						}
					});
					_min = temp_min;
					_max = temp_max;
				};
#endif

			Compute<T>.Range =
				Meta.Compile<Compute<T>.Delegates.Range>(
					string.Concat(
@"(out ", Type_String, " _min, out ", Type_String, " _max, Stepper<", Type_String, @"> _stepper) =>
{
	bool set = false;
	", Type_String, @" temp_min = 0;
	", Type_String, @" temp_max = 0;
	_stepper((", Type_String, @" i) =>
	{
		if (!set)
		{
			temp_min = i;
			temp_max = i;
			set = true;
		}
		else
		{
			temp_min = i < temp_min ? i : temp_min;
			temp_max = i > temp_max ? i : temp_max;
		}
	});
	_min = temp_min;
	_max = temp_max;
}"));

			Compute<T>.Range(out min, out max, stepper);
		};
		#endregion

		#region Quantiles
		/// <summary>Computes the quantiles of a set of values.</summary>
		public static Compute<T>.Delegates.Quantiles Quantiles = (int quantiles, Stepper<T> stepper) =>
		{
#if show_Numeric
			Compute<Numeric>.delegates.Quantiles compile_testing =
				(int _quantiles, Stepper<Numeric> _stepper) =>
				{
#if no_error_checking
						// nothing
#else
					if (_stepper == null)
						throw new Error("null reference: _stepper");
					if (_quantiles < 1)
						throw new Error("invalid numer of dimensions on Quantile division");
#endif
					int count = 0;
					_stepper((Numeric i) => { count++; });
					Numeric[] ordered = new Numeric[count];
					int a = 0;
					_stepper((Numeric i) => { ordered[a++] = i; });
					Sort<Numeric>.Quick(Compute<Numeric>.Compare, ordered);
					Numeric[] __quantiles = new Numeric[_quantiles + 1];
					__quantiles[0] = ordered[0];
					__quantiles[__quantiles.Length - 1] = ordered[ordered.Length - 1];
					for (int i = 1; i < _quantiles; i++)
					{
						Numeric temp = (ordered.Length / (Numeric)(_quantiles + 1)) * i;
						if (temp % 1 == 0)
							__quantiles[i] = ordered[(int)temp];
						else
							__quantiles[i] = (ordered[(int)temp] + ordered[(int)temp + 1]) / (Numeric)2;
					}
					return __quantiles;
				};
#endif

			Compute<T>.Quantiles =
				Meta.Compile<Compute<T>.Delegates.Quantiles>(
					string.Concat(
@"(int _quantiles, Stepper<", Type_String, @"> _stepper) =>
{",
#if no_error_checking
	// nothing
#else
@"	if (_stepper == null)
		throw new Error(", "\"null reference: _stepper\"", @");
	if (_quantiles < 1)
		throw new Error(", "\"invalid numer of dimensions on Quantile division\");",
#endif
@"	int count = 0;
	_stepper((", Type_String, @" i) => { count++; });
	", Type_String, "[] ordered = new ", Type_String, @"[count];
	int a = 0;
	_stepper((", Type_String, @" i) => { ordered[a++] = i; });
	Algorithms.Sort.Quick<" + Type_String + @">(Logic.compare, ordered);
	", Type_String, "[] __quantiles = new ", Type_String, @"[_quantiles + 1];
	__quantiles[0] = ordered[0];
	__quantiles[__quantiles.Length - 1] = ordered[ordered.Length - 1];
	for (int i = 1; i < _quantiles; i++)
	{
		", Type_String, " temp = (ordered.Length / (", Type_String, @")(_quantiles + 1)) * i;
		if (temp % 1 == 0)
			__quantiles[i] = ordered[(int)temp];
		else
			__quantiles[i] = (ordered[(int)temp] + ordered[(int)temp + 1]) / (", Type_String, @")2;
	}
	return __quantiles;
}"));

			return Compute<T>.Quantiles(quantiles, stepper);
		};
		#endregion

		#region Correlation
		/// <summary>Computes the median of a set of values.</summary>
		public static Compute<T>.Delegates.Correlation Correlation = (Stepper<T> a, Stepper<T> b) =>
		{
			throw new Error("I introduced an error here when I removed the stepref off of structure. will fix soon - seven");

#if show_Numeric
			Compute<Numeric>.delegates.Correlation compile_testing =
				(Stepper<Numeric> _a, Stepper<Numeric> _b) =>
				{
					throw new Error("needs revision");
					//Numeric a_mean = Compute<Numeric>.Mean(_a);
					//Numeric b_mean = Compute<Numeric>.Mean(_b);
					//List<Numeric> a_temp = new List_Linked<Numeric>();
					//_a((Numeric i) => { a_temp.Add(i - b_mean); });
					//List<Numeric> b_temp = new List_Linked<Numeric>();
					//_b((Numeric i) => { b_temp.Add(i - a_mean); });
					//Numeric[] a_cross_b = new Numeric[a_temp.Count * b_temp.Count];
					//int count = 0;
					//a_temp.Stepper((Numeric i_a) =>
					//{
					//	b_temp.Stepper((Numeric i_b) =>
					//	{
					//		a_cross_b[count++] = i_a * i_b;
					//	});
					//});
					//a_temp.Stepper((ref Numeric i) => { i *= i; });
					//b_temp.Stepper((ref Numeric i) => { i *= i; });
					//Numeric sum_a_cross_b = 0;
					//foreach (Numeric i in a_cross_b)
					//	sum_a_cross_b += i;
					//Numeric sum_a_temp = 0;
					//a_temp.Stepper((Numeric i) => { sum_a_temp += i; });
					//Numeric sum_b_temp = 0;
					//b_temp.Stepper((Numeric i) => { sum_b_temp += i; });
					//return sum_a_cross_b / Algebra<Numeric>.sqrt(sum_a_temp * sum_b_temp);
				};
#endif

			Compute<T>.Correlation =
				Meta.Compile<Compute<T>.Delegates.Correlation>(
					string.Concat(
@"(Stepper<", Type_String, "> _a, Stepper<", Type_String, @"> _b) =>
{
	", Type_String, " a_mean = Compute<", Type_String, @">.Mean(_a);
	", Type_String, " b_mean = Compute<", Type_String, @">.Mean(_b);
	List<", Type_String, "> a_temp = new List_Linked<", Type_String, @">();
	_a((", Type_String, @" i) => { a_temp.Add(i - b_mean); });
	List<", Type_String, "> b_temp = new List_Linked<", Type_String, @">();
	_b((", Type_String, @" i) => { b_temp.Add(i - a_mean); });
	", Type_String, "[] a_cross_b = new ", Type_String, @"[a_temp.Count * b_temp.Count];
	int count = 0;
	a_temp.Stepper((", Type_String, @" i_a) =>
	{
		b_temp.Stepper((", Type_String, @" i_b) =>
		{
			a_cross_b[count++] = i_a * i_b;
		});
	});
	a_temp.Stepper((ref ", Type_String, @" i) => { i *= i; });
	b_temp.Stepper((ref ", Type_String, @" i) => { i *= i; });
	", Type_String, @" sum_a_cross_b = 0;
	foreach (", Type_String, @" i in a_cross_b)
		sum_a_cross_b += i;
	", Type_String, @" sum_a_temp = 0;
	a_temp.Stepper((", Type_String, @" i) => { sum_a_temp += i; });
	", Type_String, @" sum_b_temp = 0;
	b_temp.Stepper((", Type_String, @" i) => { sum_b_temp += i; });
	return sum_a_cross_b / Compute<", Type_String, @">.sqrt(sum_a_temp * sum_b_temp);
}"));

			return Compute<T>.Correlation(a, b);
		};
		#endregion

		#endregion

		#region Trigonometry

		/// <summary>Computes the ratio [length of the side opposite to the angle / hypotenuse] in a right triangle.</summary>
		public static Compute<T>.Delegates.Sine Sine = (Angle<T> angle) =>
		{
			if (typeof(T) == typeof(double)) // double optimization
				Compute<double>.Sine = (Angle<double> _angle) => { return System.Math.Sin(_angle.Radians); };
			else if (typeof(T) == typeof(float)) // float optimization
				Compute<float>.Sine = (Angle<float> _angle) => { return (float)System.Math.Sin(_angle.Radians); };
			else // Generic Implementation
			{
				// Series: sin(x) = x - x^3/3! + x^5/5! - x^7/7! ...
				// more terms in computation inproves accuracy

#if show_Numeric
				Compute<Numeric>.Sine = (Angle<Numeric> __angle) =>
				{
					Numeric _angle = __angle.Radians;
					// get the angle into the positive unit circle
					_angle = _angle % (Compute<Numeric>.Pi * 2);
					if (_angle < 0)
						_angle = (Compute<Numeric>.Pi * 2) + _angle;
					if (_angle <= Compute<Numeric>.Pi / 2) // quadrant 1
						goto QuandrantSkip;
					else if (_angle <= Compute<Numeric>.Pi) // quadrant 2
						_angle = (Compute<Numeric>.Pi / 2) - (_angle % (Compute<Numeric>.Pi / 2));
					else if (_angle <= (Compute<Numeric>.Pi * 3) / 2) // quadrant 3
						_angle = _angle % Compute<Numeric>.Pi;
					else // quadrant 4
						_angle = (Compute<Numeric>.Pi / 2) - (_angle % (Compute<Numeric>.Pi / 2));
				QuandrantSkip:
					// do the computation
					Numeric three_factorial = 6; // 3!
					Numeric five_factorial = 120; // 5!
					Numeric seven_factorial = 5040; // 5!
					Numeric angleCubed = _angle * _angle * _angle; // angle ^ 3
					Numeric angleToTheFifth = angleCubed * _angle * _angle; // angle ^ 5
					Numeric angleToTheSeventh = angleToTheFifth * _angle * _angle; // angle ^ 7
					return -(_angle
						- (angleCubed / three_factorial)
						+ (angleToTheFifth / five_factorial)
						- (angleToTheSeventh / seven_factorial));
				};
#endif

				Compute<T>.Sine =
					Meta.Compile<Compute<T>.Delegates.Sine>(
						string.Concat(
@"(", Type_String, @" _angle) =>
{
	// get the angle into the positive unit circle
	_angle = _angle % (Compute<", Type_String, @">.Pi * 2);
	if (_angle < 0)
		_angle = (Compute<", Type_String, @">.Pi * 2) + _angle;
	if (_angle <= Compute<", Type_String, @">.Pi / 2)
		goto QuandrantSkip;
	else if (_angle <= Compute<", Type_String, @">.Pi)
		_angle = (Compute<", Type_String, ">.Pi / 2) - (_angle % (Compute<", Type_String, @">.Pi / 2));
	else if (_angle <= (Compute<", Type_String, @">.Pi * 3) / 2)
		_angle = _angle % Compute<", Type_String, @">.Pi;
	else
		_angle = (Compute<", Type_String, ">.Pi / 2) - (_angle % (Compute<", Type_String, @">.Pi / 2));
QuandrantSkip:
	", Type_String, @" three_factorial = 6;
	", Type_String, @" five_factorial = 120;
	", Type_String, @" seven_factorial = 5040;
	", Type_String, @" angleCubed = _angle * _angle * _angle;
	", Type_String, @" angleToTheFifth = angleCubed * _angle * _angle;
	", Type_String, @" angleToTheSeventh = angleToTheFifth * _angle * _angle;
	return -(_angle
		- (angleCubed / three_factorial)
		+ (angleToTheFifth / five_factorial)
		- (angleToTheSeventh / seven_factorial));
}"));
			}

			return Compute<T>.Sine(angle);
		};

		/// <summary>Computes the ratio [length of the side adjacent to the angle / hypotenuse] in a right triangle.</summary>
		public static Compute<T>.Delegates.Cosine Cosine = (Angle<T> angle) =>
		{
			// rather than computing cos, you could do a phase shift and use sin
			// return Sin(angle + (Pi / 2));

			if (typeof(T) == typeof(double)) // double optimization
				Compute<double>.Cosine = (Angle<double> _angle) => { return System.Math.Cos(_angle.Radians); };
			else if (typeof(T) == typeof(float)) // float optimization
				Compute<float>.Cosine = (Angle<float> _angle) => { return (float)System.Math.Cos(_angle.Radians); };
			else
			{
				// Series: cos(x) = 1 - x^2/2! + x^4/4! - x^6/6! ...
				// more terms in computation inproves accuracy

#if show_Numeric
				Compute<Numeric>.Cosine = (Angle<Numeric> __angle) =>
				{
					Numeric _angle = __angle.Radians;
					// get the angle into the positive unit circle
					_angle = _angle % (Compute<Numeric>.Pi * 2);
					if (_angle < 0)
						_angle = (Compute<Numeric>.Pi * 2) + _angle;
					if (_angle <= Compute<Numeric>.Pi / 2) // quadrant 1
						goto QuandrantSkip;
					else if (_angle <= Compute<Numeric>.Pi) // quadrant 2
						_angle = (Compute<Numeric>.Pi / 2) - (_angle % (Compute<Numeric>.Pi / 2));
					else if (_angle <= (Compute<Numeric>.Pi * 3) / 2) // quadrant 3
						_angle = _angle % Compute<Numeric>.Pi;
					else // quadrant 4
						_angle = (Compute<Numeric>.Pi / 2) - (_angle % (Compute<Numeric>.Pi / 2));
				QuandrantSkip:
					// do the computation
					Numeric one = 1;
					Numeric two_factorial = 2; // 2!
					Numeric four_factorial = 24; // 4!
					Numeric six_factorial = 720; // 6!
					Numeric angleSquared = _angle * _angle; // angle ^ 2
					Numeric angleToTheFourth = angleSquared * _angle * _angle; // angle ^ 4
					Numeric angleToTheSixth = angleToTheFourth * _angle * _angle;  // angle ^ 6
					return one
						- (angleSquared / two_factorial)
						+ (angleToTheFourth / four_factorial)
						- (angleToTheSixth / six_factorial);
				};
#endif

				Compute<T>.Cosine =
					Meta.Compile<Compute<T>.Delegates.Cosine>(
					string.Concat(
@"(", Type_String, @" _angle) =>
{
	// get the angle into the positive unit circle
	_angle = _angle % (Compute<", Type_String, @">.Pi * 2);
	if (_angle < 0)
		_angle = (Compute<", Type_String, @">.Pi * 2) + _angle;
	if (_angle <= Compute<", Type_String, @">.Pi / 2)
		goto QuandrantSkip;
	else if (_angle <= Compute<", Type_String, @">.Pi)
		_angle = (Compute<", Type_String, ">.Pi / 2) - (_angle % (Compute<", Type_String, @">.Pi / 2));
	else if (_angle <= (Compute<", Type_String, @">.Pi * 3) / 2)
		_angle = _angle % Compute<", Type_String, @">.Pi;
	else
		_angle = (Compute<", Type_String, ">.Pi / 2) - (_angle % (Compute<", Type_String, @">.Pi / 2));
QuandrantSkip:
	", Type_String, @" one = 1;
	", Type_String, @" two_factorial = 2;
	", Type_String, @" four_factorial = 24;
	", Type_String, @" six_factorial = 720;
	", Type_String, @" angleSquared = _angle * _angle;
	", Type_String, @" angleToTheFourth = angleSquared * _angle * _angle;
	", Type_String, @" angleToTheSixth = angleToTheFourth * _angle * _angle;
	return one
		- (angleSquared / two_factorial)
		+ (angleToTheFourth / four_factorial)
		- (angleToTheSixth / six_factorial);
}"));
			}

			return Compute<T>.Cosine(angle);
		};

		/// <summary>Computes the ratio [length of the side opposite to the angle / length of the side adjacent to the angle] in a right triangle.</summary>
		public static Compute<T>.Delegates.Tangent Tangent = (Angle<T> angle) =>
		{
			if (typeof(T) == typeof(double)) // double optimization
				Compute<double>.Tangent = (Angle<double> _angle) => { return System.Math.Tan(_angle.Radians); };
			else if (typeof(T) == typeof(float)) // float optimization
				Compute<float>.Tangent = (Angle<float> _angle) => { return (float)System.Math.Tan(_angle.Radians); };
			else
			{
				// Series: tan(x) = x + x^3/3 + 2x^5/15 + 17x^7/315 ...
				// more terms in computation inproves accuracy

#if show_Numeric
				Compute<Numeric>.Tangent = (Angle<Numeric> __angle) =>
				{
					Numeric _angle = __angle.Radians;
					// get the angle into the positive unit circle
					_angle = _angle % (Compute<Numeric>.Pi * 2);
					if (_angle < 0)
						_angle = (Compute<Numeric>.Pi * 2) + _angle;
					if (_angle <= Compute<Numeric>.Pi / 2) // quadrant 1
						goto QuandrantSkip;
					else if (_angle <= Compute<Numeric>.Pi) // quadrant 2
						_angle = (Compute<Numeric>.Pi / 2) - (_angle % (Compute<Numeric>.Pi / 2));
					else if (_angle <= (Compute<Numeric>.Pi * 3) / 2) // quadrant 3
						_angle = _angle % Compute<Numeric>.Pi;
					else // quadrant 4
						_angle = (Compute<Numeric>.Pi / 2) - (_angle % (Compute<Numeric>.Pi / 2));
				QuandrantSkip:
					// do the computation
					Numeric two = 2;
					Numeric three = 3;
					Numeric fifteen = 15;
					Numeric seventeen = 17;
					Numeric threehundredfifteen = 315;
					Numeric angleCubed = _angle * _angle * _angle; // angle ^ 3
					Numeric angleToTheFifth = angleCubed * _angle * _angle; // angle ^ 5
					Numeric angleToTheSeventh = angleToTheFifth * _angle * _angle;  // angle ^ 7
					return angle
						+ (angleCubed / three)
						+ (two * angleToTheFifth / fifteen)
						+ (seventeen * angleToTheSeventh / threehundredfifteen);
				};
#endif

				Compute<T>.Tangent =
					Meta.Compile<Compute<T>.Delegates.Tangent>(
						"(" + Type_String + " _angle) =>" +
						"{" +
						"	// get the angle into the positive unit circle" +
						"	_angle = _angle % (Compute<" + Type_String + ">.Pi * 2);" +
						"	if (_angle < 0)" +
						"		_angle = (Compute<" + Type_String + ">.Pi * 2) + _angle;" +
						"	if (_angle <= Compute<" + Type_String + ">.Pi / 2) // quadrant 1" +
						"		goto QuandrantSkip;" +
						"	else if (_angle <= Compute<" + Type_String + ">.Pi) // quadrant 2" +
						"		_angle = (Compute<" + Type_String + ">.Pi / 2) - (_angle % (Compute<" + Type_String + ">.Pi / 2));" +
						"	else if (_angle <= (Compute<" + Type_String + ">.Pi * 3) / 2) // quadrant 3" +
						"		_angle = _angle % Compute<" + Type_String + ">.Pi;" +
						"	else // quadrant 4" +
						"		_angle = (Compute<" + Type_String + ">.Pi / 2) - (_angle % (Compute<" + Type_String + ">.Pi / 2));" +
						"QuandrantSkip:" +
						"	// do the computation" +
						"	" + Type_String + " two = 2;" +
						"	" + Type_String + " three = 3;" +
						"	" + Type_String + " fifteen = 15;" +
						"	" + Type_String + " seventeen = 17;" +
						"	" + Type_String + " threehundredfifteen = 315;" +
						"	" + Type_String + " angleCubed = _angle * _angle * _angle; // angle ^ 3" +
						"	" + Type_String + " angleToTheFifth = angleCubed * _angle * _angle; // angle ^ 5" +
						"	" + Type_String + " angleToTheSeventh = angleToTheFifth * _angle * _angle;  // angle ^ 7" +
						"	return angle" +
						"		+ (angleCubed / three)" +
						"		+ (two * angleToTheFifth / fifteen)" +
						"		+ (seventeen * angleToTheSeventh / threehundredfifteen);" +
						"}");
			}

			return Compute<T>.Tangent(angle);
		};

		/// <summary>Computes the ratio [hypotenuse / length of the side opposite to the angle] in a right triangle.</summary>
		public static Compute<T>.Delegates.Cosecant Cosecant = (Angle<T> angle) =>
		{
			// Series: csc(x) = x^-1 + x/6 + 7x^3/360 + 31x^5/15120 ...
			// more terms in computation inproves accuracy

#if show_Numeric
			Compute<Numeric>.Cosecant = (Angle<Numeric> _angle) =>
			{
				return (Numeric)1 / Compute<Numeric>.Sine(_angle);
			};
#endif

			Compute<T>.Cosecant =
				Meta.Compile<Compute<T>.Delegates.Cosecant>(
					"(" + Type_String + " _angle) =>" +
					"{" +
					"	return (" + Type_String + ")1 / Compute<" + Type_String + ">.Sine(_angle);" +
					"}");

			return Compute<T>.Cosecant(angle);
		};

		/// <summary>Computes the ratio [hypotenuse / length of the side adjacent to the angle] in a right triangle.</summary>
		public static Compute<T>.Delegates.Secant Secant = (Angle<T> angle) =>
		{
			// Series: sec(x) = ...
			// more terms in computation inproves accuracy

#if show_Numeric
			Compute<Numeric>.Secant = (Angle<Numeric> _angle) =>
			{
				return (Numeric)1 / Compute<Numeric>.Cosine(_angle);
			};
#endif

			Compute<T>.Secant =
				Meta.Compile<Compute<T>.Delegates.Secant>(
					"(" + Type_String + " _angle) =>" +
					"{" +
					"	return (" + Type_String + ")1 / Compute<" + Type_String + ">.Cosine(_angle);" +
					"}");

			return Compute<T>.Secant(angle);
		};

		/// <summary>Computes the ratio [length of the side adjacent to the angle / length of the side opposite to the angle] in a right triangle.</summary>
		public static Compute<T>.Delegates.Cotangent Cotangent = (Angle<T> angle) =>
		{
			// Series: cot(x) = ...
			// more terms in computation inproves accuracy

#if show_Numeric
			Compute<Numeric>.Cotangent = (Angle<Numeric> _angle) =>
			{
				return (Numeric)1 / Compute<Numeric>.Tangent(_angle);
			};
#endif

			Compute<T>.Cotangent =
				Meta.Compile<Compute<T>.Delegates.Cotangent>(
					"(" + Type_String + " _angle) =>" +
					"{" +
					"	return (" + Type_String + ")1 / Compute<" + Type_String + ">.Tangent(_angle);" +
					"}");

			return Compute<T>.Cotangent(angle);
		};

		public static Compute<T>.Delegates.InverseSine InverseSine = (T ratio) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.InverseSine = (double _ratio) => { return Angle<double>.Factory_Radians(System.Math.Asin(_ratio)); };
			else if (typeof(T) == typeof(float))
				Compute<float>.InverseSine = (float _ratio) => { return Angle<float>.Factory_Radians((float)System.Math.Asin(_ratio)); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.InverseSine(ratio);
		};

		public static Compute<T>.Delegates.InverseCosine InverseCosine = (T ratio) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.InverseCosine = (double _ratio) => { return Angle<double>.Factory_Radians(System.Math.Acos(_ratio)); };
			else if (typeof(T) == typeof(float))
				Compute<float>.InverseCosine = (float _ratio) => { return Angle<float>.Factory_Radians((float)System.Math.Acos(_ratio)); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.InverseCosine(ratio);
		};

		public static Compute<T>.Delegates.InverseTangent InverseTangent = (T ratio) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.InverseTangent = (double _ratio) => { return Angle<double>.Factory_Radians(System.Math.Atan(_ratio)); };
			else if (typeof(T) == typeof(float))
				Compute<float>.InverseTangent = (float _ratio) => { return Angle<float>.Factory_Radians((float)System.Math.Atan(_ratio)); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.InverseTangent(ratio);
		};

		public static Compute<T>.Delegates.InverseCosecant InverseCosecant = (T ratio) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.InverseCosecant = (double _ratio) => { return Angle<double>.Factory_Radians(System.Math.Asin(1d / _ratio)); };
			else if (typeof(T) == typeof(float))
				Compute<float>.InverseCosecant = (float _ratio) => { return Angle<float>.Factory_Radians((float)System.Math.Asin(1f / _ratio)); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.InverseCosecant(ratio);
		};

		public static Compute<T>.Delegates.InverseSecant InverseSecant = (T ratio) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.InverseSecant = (double _ratio) => { return Angle<double>.Factory_Radians(System.Math.Acos(1d / _ratio)); };
			else if (typeof(T) == typeof(float))
				Compute<float>.InverseSecant = (float _ratio) => { return Angle<float>.Factory_Radians((float)System.Math.Acos(1f / _ratio)); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.InverseSecant(ratio);
		};

		public static Compute<T>.Delegates.InverseCotangent InverseCotangent = (T ratio) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.InverseCotangent = (double _ratio) => { return Angle<double>.Factory_Radians(System.Math.Atan(1d / _ratio)); };
			else if (typeof(T) == typeof(float))
				Compute<float>.InverseCotangent = (float _ratio) => { return Angle<float>.Factory_Radians((float)System.Math.Atan(1f / _ratio)); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.InverseCotangent(ratio);
		};

		public static Compute<T>.Delegates.HyperbolicSine HyperbolicSine = (Angle<T> angle) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.HyperbolicSine = (Angle<double> _angle) => { return System.Math.Sinh(_angle.Radians); };
			else if (typeof(T) == typeof(float))
				Compute<float>.HyperbolicSine = (Angle<float> _angle) => { return (float)System.Math.Sinh(_angle.Radians); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.HyperbolicSine(angle);
		};

		public static Compute<T>.Delegates.HyperbolicCosine HyperbolicCosine = (Angle<T> angle) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.HyperbolicCosine = (Angle<double> _angle) => { return System.Math.Cosh(_angle.Radians); };
			else if (typeof(T) == typeof(float))
				Compute<float>.HyperbolicCosine = (Angle<float> _angle) => { return (float)System.Math.Cosh(_angle.Radians); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.HyperbolicCosine(angle);
		};

		public static Compute<T>.Delegates.HyperbolicTangent HyperbolicTangent = (Angle<T> angle) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.HyperbolicTangent = (Angle<double> _angle) => { return System.Math.Tanh(_angle.Radians); };
			else if (typeof(T) == typeof(float))
				Compute<float>.HyperbolicTangent = (Angle<float> _angle) => { return (float)System.Math.Tanh(_angle.Radians); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.HyperbolicTangent(angle);
		};

		public static Compute<T>.Delegates.HyperbolicSecant HyperbolicSecant = (Angle<T> angle) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.HyperbolicSecant = (Angle<double> _angle) => { return 1d / System.Math.Cosh(_angle.Radians); };
			else if (typeof(T) == typeof(float))
				Compute<float>.HyperbolicSecant = (Angle<float> _angle) => { return 1f / (float)System.Math.Cosh(_angle.Radians); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.HyperbolicSecant(angle);
		};

		public static Compute<T>.Delegates.HyperbolicCosecant HyperbolicCosecant = (Angle<T> angle) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.HyperbolicCosecant = (Angle<double> _angle) => { return 1d / System.Math.Sinh(_angle.Radians); };
			else if (typeof(T) == typeof(float))
				Compute<float>.HyperbolicCosecant = (Angle<float> _angle) => { return 1f / (float)System.Math.Sinh(_angle.Radians); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.HyperbolicCosecant(angle);
		};

		public static Compute<T>.Delegates.HyperbolicCotangent HyperbolicCotangent = (Angle<T> angle) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.HyperbolicCotangent = (Angle<double> _angle) => { return 1d / System.Math.Tanh(_angle.Radians); };
			else if (typeof(T) == typeof(float))
				Compute<float>.HyperbolicCotangent = (Angle<float> _angle) => { return 1f / (float)System.Math.Tanh(_angle.Radians); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.HyperbolicCotangent(angle);
		};

		public static Compute<T>.Delegates.InverseHyperbolicSine InverseHyperbolicSine = (T ratio) =>
		{
			throw new Error("not implemented");
		};

		public static Compute<T>.Delegates.InverseHyperbolicCosine InverseHyperbolicCosine = (T ratio) =>
		{
			throw new Error("not implemented");
		};

		public static Compute<T>.Delegates.InverseHyperbolicTangent InverseHyperbolicTangent = (T ratio) =>
		{
			throw new Error("not implemented");
		};

		public static Compute<T>.Delegates.InverseHyperbolicCosecant InverseHyperbolicCosecant = (T ratio) =>
		{
			throw new Error("not implemented");
		};

		public static Compute<T>.Delegates.InverseHyperbolicSecant InverseHyperbolicSecant = (T ratio) =>
		{
			throw new Error("not implemented");
		};

		public static Compute<T>.Delegates.InverseHyperbolicCotangent InverseHyperbolicCotangent = (T ratio) =>
		{
			throw new Error("not implemented");
		};

		#endregion
	}
}
