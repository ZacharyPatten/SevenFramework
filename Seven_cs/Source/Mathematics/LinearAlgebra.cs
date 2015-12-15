// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics
{
	/// <summary>Contains generic mathematics linear algebra operations.</summary>
	public static class LinearAlgebra<T>
	{

		#region static controls

		// The minimum size (rows x columns) that will trigger multithreading 
		// of matrix operations. Example: "A.Multiply_parallel(B)"
		static int _parallelMinimum = 49;
		// The maximum size (rows x columns) that will trigger unsafe code
		// if compiling with the unsafe directive.
		static int _unsafeMaximum = 49;

		#endregion

		#region delegate

		/// <summary>Stores the delegates used for linear algebra.</summary>
		public static class delegates
		{
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
		}

		#endregion

		#region implementation

		#region vector

		/// <summary>Adds two vectors together.</summary>
		public static LinearAlgebra<T>.delegates.Vector_Add Vector_Add = (Vector<T> left, Vector<T> right) =>
			#region code
			{
				#region pre-optimization
				//Vector<generic> result =
				//	new Vector<generic>(left.Dimensions);
				//for (int i = 0; i < left.Dimensions; i++)
				//	result[i] = left[i] + right[i];
				//return result;
				#endregion

				#region generic
#if show_Numeric
							// This is just a compile test. Vector_Add_string (see below) should match this code exactly.
							LinearAlgebra<Numeric>.delegates.Vector_Add compile_testing =
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
														throw new Error("invalid dimensions on vector addition.");
#endif
												int length = _left.Dimensions;
												Vector<Numeric> result =
													new Vector<Numeric>(_left.Dimensions);
#if unsafe_code
												if (typeof(T).IsValueType)
												{
														unsafe
														{
																fixed (generic*
																	_left_flat = _left._vector,
																	_right_flat = _right._vector,
																	result_flat = result._vector)
																		for (int i = 0; i < length; i++)
																				result_flat[i] = _left_flat[i] + _right_flat[i];
														}
												}
												else 
												{
														generic[] _left_flat = _left._vector;
														generic[] _right_flat = _right._vector;
														generic[] result_flat = result._vector;
														for (int i = 0; i < length; i++)
															result_flat[i] = _left_flat[i] + _right_flat[i];
												}
#else
												Numeric[] _left_flat = _left._vector;
												Numeric[] _right_flat = _right._vector;
												Numeric[] result_flat = result._vector;
												for (int i = 0; i < length; i++)
													result_flat[i] = _left_flat[i] + _right_flat[i];
#endif
												return result;
										};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Vector_Add_string =
								"(Vector<" + num + "> _left, Vector<" + num + "> _right) =>" +
								"{" +
#if no_error_checking
												 // nothing
#else
 "		if (object.ReferenceEquals(_left, null))" +
								"				throw new Error(\"null reference: _left\");" +
								"		if (object.ReferenceEquals(_right, null))" +
								"				throw new Error(\"null reference: _right\");" +
								"		if (_left.Dimensions != _right.Dimensions)" +
								"				throw new Error(\"invalid dimensions on vector addition.\");" +
#endif
 "		int length = _left.Dimensions;" +
								"		Vector<" + num + "> result =" +
								"			new Vector<" + num + ">(_left.Dimensions);";
#if unsafe_code
												 if (typeof(T).IsValueType)
												 {
														 Vector_Add_string +=
										"				unsafe" +
										"				{" +
										"						fixed (" + num + "*" +
										"							_left_flat = _left._vector," +
										"							_right_flat = _right._vector," +
										"							result_flat = result._vector)" +
										"								for (int i = 0; i < length; i++)" +
										"										result_flat[i] = _left_flat[i] + _right_flat[i];" +
										"				}";
												 }
												 else 
												 {
														 Vector_Add_string +=
										"				" + num + "[] _left_flat = _left._vector;" +
										"				" + num + "[] _right_flat = _right._vector;" +
										"				" + num + "[] result_flat = result._vector;" +
										"				for (int i = 0; i < length; i++)" +
										"					result_flat[i] = _left_flat[i] + _right_flat[i];";
												 }
#else
				Vector_Add_string +=
	 "		" + num + "[] _left_flat = _left._vector;" +
	 "		" + num + "[] _right_flat = _right._vector;" +
	 "		" + num + "[] result_flat = result._vector;" +
	 "		for (int i = 0; i < length; i++)" +
	 "			result_flat[i] = _left_flat[i] + _right_flat[i];";
#endif
				Vector_Add_string +=
	 "		return result;" +
	 "}";

				#endregion

				Vector_Add_string = Vector_Add_string.Replace("generic", Generate.TypeToCsharp(typeof(T)));

				LinearAlgebra<T>.Vector_Add =
						Generate.Object<LinearAlgebra<T>.delegates.Vector_Add>(Vector_Add_string);

				return LinearAlgebra<T>.Vector_Add(left, right);
			};
			#endregion

		/// <summary>Negates all the values in a vector.</summary>
		public static LinearAlgebra<T>.delegates.Vector_Negate Vector_Negate = (Vector<T> vector) =>
			#region code
			{
				#region pre-optimization
				//Vector<generic> result =
				//	new Vector<generic>(vector.Dimensions);
				//for (int i = 0; i < vector.Dimensions; i++)
				//	result[i] = -vector[i];
				//return result;
				#endregion

				#region generic
#if show_Numeric
							LinearAlgebra<Numeric>.delegates.Vector_Negate compile_testing =
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
#if unsafe_code
											if (typeof(T).IsValueType)
											{
												unsafe
												{
													fixed (generic*
													vector_flat = _vector._vector,
													result_flat = result._vector)
														for (int i = 0; i < length; i++)
															result_flat[i] = -vector_flat[i];
												}
											}
											else 
											{
												generic[] vector_flat = _vector._vector;
												generic[] result_flat = result._vector;
												for (int i = 0; i < length; i++)
														result_flat[i] = -vector_flat[i];
											}
#else
											Numeric[] vector_flat = _vector._vector;
											Numeric[] result_flat = result._vector;
											for (int i = 0; i < length; i++)
												result_flat[i] = -vector_flat[i];
#endif
											return result;
									};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Vector_Negate_string =
						"(Vector<" + num + "> _vector) =>" +
						"{" +
#if no_error_checking
											 // nothing
#else
 "		if (object.ReferenceEquals(_vector, null))" +
						"			throw new Error(\"null reference: vector\");" +
#endif
 "		int length = _vector.Dimensions;" +
						"		Vector<" + num + "> result =" +
						"			new Vector<" + num + ">(length);";
#if unsafe_code
											 if (typeof(T).IsValueType)
											 {
												 unsafe
												 {
													 Vector_Negate_string +=
									"				fixed (" + num + "*" +
									"				vector_flat = _vector._vector," +
									"				result_flat = result._vector)" +
									"					for (int i = 0; i < length; i++)" +
									"						result_flat[i] = -vector_flat[i];";
												 }
											 }
											 else
											 {
												 Vector_Negate_string +=
									"			" + num + "[] vector_flat = _vector._vector;" +
									"			" + num + "[] result_flat = result._vector;" +
									"			for (int i = 0; i < length; i++)" +
									"					result_flat[i] = -vector_flat[i];";
											 }
#else
				Vector_Negate_string +=
				"		" + num + "[] vector_flat = _vector._vector;" +
				"		" + num + "[] result_flat = result._vector;" +
				"		for (int i = 0; i < length; i++)" +
				"			result_flat[i] = -vector_flat[i];";
#endif
				Vector_Negate_string +=
				"		return result;" +
				"}";

				#endregion

				LinearAlgebra<T>.Vector_Negate =
						Generate.Object<LinearAlgebra<T>.delegates.Vector_Negate>(Vector_Negate_string);

				return LinearAlgebra<T>.Vector_Negate(vector);
			};
			#endregion

		/// <summary>Subtracts two vectors.</summary>
		public static LinearAlgebra<T>.delegates.Vector_Subtract Vector_Subtract = (Vector<T> left, Vector<T> right) =>
			#region code
			{
				#region pre-optimization
				//Vector<generic> result =
				//	new Vector<generic>(left.Dimensions);
				//for (int i = 0; i < left.Dimensions; i++)
				//	result[i] = left[i] - right[i];
				//return result;
				#endregion

				#region generic
#if show_Numeric
							LinearAlgebra<Numeric>.delegates.Vector_Subtract compile_testing =
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
														throw new Error("invalid dimensions on vector subtraction.");
#endif
												int length = _left.Dimensions;
												Vector<Numeric> result =
													new Vector<Numeric>(length);
#if unsafe_code
												if (typeof(T).IsValueType)
												{
														unsafe
														{
																fixed (generic*
																	_left_flat = _left._vector,
																	_right_flat = _right._vector,
																	result_flat = result._vector)
																		for (int i = 0; i < length; i++)
																		result_flat[i] = _left_flat[i] - _right_flat[i];
														}
												}
												else
												{
														generic[] _left_flat = _left._vector;
														generic[] _right_flat = _right._vector;
														generic[] result_flat = result._vector;
														for (int i = 0; i < length; i++)
																result_flat[i] = _left_flat[i] - _right_flat[i];
												}
#else
												Numeric[] _left_flat = _left._vector;
												Numeric[] _right_flat = _right._vector;
												Numeric[] result_flat = result._vector;
												for (int i = 0; i < length; i++)
													result_flat[i] = _left_flat[i] - _right_flat[i];
#endif
												return result;
										};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Vector_Subtract_string =
								"(Vector<" + num + "> _left, Vector<" + num + "> _right) =>" +
								"{" +
#if no_error_checking
												 // nothing
#else
 "		if (object.ReferenceEquals(_left, null))" +
								"				throw new Error(\"null reference: _left\");" +
								"		if (object.ReferenceEquals(_right, null))" +
								"				throw new Error(\"null reference: _right\");" +
								"		if (_left.Dimensions != _right.Dimensions)" +
								"				throw new Error(\"invalid dimensions on vector subtraction.\");" +
#endif
 "		int length = _left.Dimensions;" +
								"		Vector<" + num + "> result =" +
								"			new Vector<" + num + ">(length);";
#if unsafe_code
												 if (typeof(T).IsValueType)
												 {
														 Vector_Subtract_string +=
										"				unsafe" +
										"				{" +
										"						fixed (" + num + "*" +
										"							_left_flat = _left._vector," +
										"							_right_flat = _right._vector," +
										"							result_flat = result._vector)" +
										"								for (int i = 0; i < length; i++)" +
										"								result_flat[i] = _left_flat[i] - _right_flat[i];" +
										"				}";
												 }
												 else
												 {
														 Vector_Subtract_string +=
										"				" + num + "[] _left_flat = _left._vector;" +
										"				" + num + "[] _right_flat = _right._vector;" +
										"				" + num + "[] result_flat = result._vector;" +
										"				for (int i = 0; i < length; i++)" +
										"						result_flat[i] = _left_flat[i] - _right_flat[i];";
												 }
#else
				Vector_Subtract_string +=
	 "		" + num + "[] _left_flat = _left._vector;" +
	 "		" + num + "[] _right_flat = _right._vector;" +
	 "		" + num + "[] result_flat = result._vector;" +
	 "		for (int i = 0; i < length; i++)" +
	 "			result_flat[i] = _left_flat[i] - _right_flat[i];";
#endif
				Vector_Subtract_string +=
	 "		return result;" +
	 "}";

				#endregion

				LinearAlgebra<T>.Vector_Subtract =
				Generate.Object<LinearAlgebra<T>.delegates.Vector_Subtract>(Vector_Subtract_string);

				return LinearAlgebra<T>.Vector_Subtract(left, right);
			};
			#endregion

		/// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
		public static LinearAlgebra<T>.delegates.Vector_Multiply Vector_Multiply = (Vector<T> left, T right) =>
			#region code
			{
				#region pre-optimization
				//Vector<generic> result =
				//	new Vector<generic>(left.Dimensions);
				//for (int i = 0; i < left.Dimensions; i++)
				//	result[i] = left[i] * right;
				//return result;
				#endregion

				#region generic
#if show_Numeric
							LinearAlgebra<Numeric>.delegates.Vector_Multiply compile_testing =
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
#if unsafe_code
												unsafe
												{
													fixed (generic*
														_left_flat = _left._vector,
														result_flat = result._vector)
															for (int i = 0; i < length; i++)
																result_flat[i] = _left_flat[i] * _right;
												}
												if (typeof(T).IsValueType)
												{
														unsafe
														{
															fixed (generic*
																_left_flat = _left._vector,
																result_flat = result._vector)
																	for (int i = 0; i < length; i++)
																		result_flat[i] = _left_flat[i] * _right;
														}
												}
												else
												{
													generic[] _left_flat = _left._vector;
													generic[] result_flat = result._vector;
													for (int i = 0; i < length; i++)
														result_flat[i] = _left_flat[i] * _right;
												}
#else
												Numeric[] _left_flat = _left._vector;
												Numeric[] result_flat = result._vector;
												for (int i = 0; i < length; i++)
														result_flat[i] = _left_flat[i] * _right;
#endif
												return result;
										};
#endif
				#endregion

				#region code (string)

				string num = Generate.TypeToCsharp(typeof(T));

				string Vector_Multiply_string =
								"(Vector<" + num + "> _left, " + num + " _right) =>" +
								"{" +
#if no_error_checking
												 // nothing
#else
 "		if (object.ReferenceEquals(_left, null))" +
								"				throw new Error(\"null reference: _left\");" +
#endif
 "		int length = _left.Dimensions;" +
								"		Vector<" + num + "> result =" +
								"			new Vector<" + num + ">(length);";
#if unsafe_code
												 if (typeof(T).IsValueType)
												 {
														 Vector_Multiply_string +=
										"				unsafe" +
										"				{" +
										"					fixed (" + num + "*" +
										"						_left_flat = _left._vector," +
										"						result_flat = result._vector)" +
										"							for (int i = 0; i < length; i++)" +
										"								result_flat[i] = _left_flat[i] * _right;" +
										"				}";
												 }
												 else
												 {
														 Vector_Multiply_string +=
										"			" + num + "[] _left_flat = _left._vector;" +
										"			" + num + "[] result_flat = result._vector;" +
										"			for (int i = 0; i < length; i++)" +
										"				result_flat[i] = _left_flat[i] * _right;";
												 }
#else
				Vector_Multiply_string +=
	 "		" + num + "[] _left_flat = _left._vector;" +
	 "		" + num + "[] result_flat = result._vector;" +
	 "		for (int i = 0; i < length; i++)" +
	 "				result_flat[i] = _left_flat[i] * _right;";
#endif
				Vector_Multiply_string +=
				"		return result;" +
	 "}";

				#endregion

				LinearAlgebra<T>.Vector_Multiply =
				Generate.Object<LinearAlgebra<T>.delegates.Vector_Multiply>(Vector_Multiply_string);

				return LinearAlgebra<T>.Vector_Multiply(left, right);
			};
			#endregion

		/// <summary>Divides all the components of a vector by a scalar.</summary>
		public static LinearAlgebra<T>.delegates.Vector_Divide Vector_Divide = (Vector<T> left, T right) =>
			#region code
			{
				#region pre-optimization(minus error checking)
				//Vector<generic> result =
				//	new Vector<generic>(vector.Dimensions);
				//for (int i = 0; i < vector.Dimensions; i++)
				//	result[i] = vector[i] / right;
				//return result;
				#endregion

				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Vector_Divide compile_testing =
								(Vector<Numeric> _left, Numeric _right) =>
								{
#if no_error_checking
									// nothing
#else
									if (object.ReferenceEquals(_left, null))
										throw new Error("null reference: left");
#endif
									int length = _left.Dimensions;
									Vector<Numeric> result =
										new Vector<Numeric>(length);
#if unsafe_code
									if (typeof(T).IsValueType)
									{
										unsafe
										{
											fixed (generic*
											_left_flat = _left._vector,
											result_flat = result._vector)
												for (int i = 0; i < length; i++)
													result_flat[i] = _left_flat[i] / _right;
										}
									}
									else
									{
										generic[] _left_flat = _left._vector;
										generic[] result_flat = result._vector;
										for (int i = 0; i < length; i++)
											result_flat[i] = _left_flat[i] / _right;
									}
#else
									Numeric[] _left_flat = _left._vector;
									Numeric[] result_flat = result._vector;
									for (int i = 0; i < length; i++)
										result_flat[i] = _left_flat[i] / _right;
#endif
									return result;
								};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Vector_Divide_string =
						"(Vector<" + num + "> _left, " + num + " _right) =>" +
						"{" +
#if no_error_checking
									 // nothing
#else
 "	if (object.ReferenceEquals(_left, null))" +
						"		throw new Error(\"null reference: left\");" +
#endif
 "	int length = _left.Dimensions;" +
						"	Vector<" + num + "> result =" +
						"		new Vector<" + num + ">(length);";
#if unsafe_code
									 if (typeof(T).IsValueType)
									 {
										 Vector_Divide_string +=
								"		unsafe" +
								"		{" +
								"			fixed (" + num + "*" +
								"			_left_flat = _left._vector," +
								"			result_flat = result._vector)" +
								"				for (int i = 0; i < length; i++)" +
								"					result_flat[i] = _left_flat[i] / _right;" +
								"		}";
									 }
									 else
									 {
										 Vector_Divide_string +=
								"		" + num + "[] _left_flat = _left._vector;" +
								"		" + num + "[] result_flat = result._vector;" +
								"		for (int i = 0; i < length; i++)" +
								"			result_flat[i] = _left_flat[i] / _right;";
									 }
#else
				Vector_Divide_string +=
		 "	" + num + "[] _left_flat = _left._vector;" +
		 "	" + num + "[] result_flat = result._vector;" +
		 "	for (int i = 0; i < length; i++)" +
		 "		result_flat[i] = _left_flat[i] / _right;";
#endif
				Vector_Divide_string +=
		 "	return result;" +
		 "}";

				#endregion

				LinearAlgebra<T>.Vector_Divide =
				Generate.Object<LinearAlgebra<T>.delegates.Vector_Divide>(Vector_Divide_string);

				return LinearAlgebra<T>.Vector_Divide(left, right);
			};
			#endregion

		/// <summary>Computes the dot product between two vectors.</summary>
		public static LinearAlgebra<T>.delegates.Vector_DotProduct Vector_DotProduct = (Vector<T> left, Vector<T> right) =>
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
						LinearAlgebra<Numeric>.delegates.Vector_DotProduct compile_testing =
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
											fixed (generic*
											_left_flat = _left._vector,
											_right_flat = _right._vector)
												for (int i = 0; i < length; i++)
													result += _left_flat[i] * _right_flat[i];
										}
									}
									else
									{
										generic[] _left_flat = _left._vector;
										generic[] _right_flat = _right._vector;
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Vector_DotProduct =
					Generate.Object<LinearAlgebra<T>.delegates.Vector_DotProduct>(Vector_DotProduct_string);

				return LinearAlgebra<T>.Vector_DotProduct(left, right);
			};
			#endregion

		/// <summary>Computes teh cross product of two vectors.</summary>
		public static LinearAlgebra<T>.delegates.Vector_CrossProduct Vector_CrossProduct = (Vector<T> left, Vector<T> right) =>
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
						LinearAlgebra<Numeric>.delegates.Vector_CrossProduct compile_testing =
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
										fixed (generic*
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
									generic[] _left_flat = _left._vector;
									generic[] _right_flat = _right._vector;
									generic[] result_flat = result._vector;
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Vector_CrossProduct =
					Generate.Object<LinearAlgebra<T>.delegates.Vector_CrossProduct>(Vector_CrossProduct_string);

				return LinearAlgebra<T>.Vector_CrossProduct(left, right);
			};
			#endregion

		/// <summary>Normalizes a vector.</summary>
		public static LinearAlgebra<T>.delegates.Vector_Normalize Vector_Normalize = (Vector<T> vector) =>
			#region code
			{
				#region pre-optimization
				//generic magnitude = LinearAlgebra.Magnitude(vector);
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
						LinearAlgebra<Numeric>.delegates.Vector_Normalize compile_testing =
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
								Numeric magnitude = LinearAlgebra<Numeric>.Vector_Magnitude(_vector);
								if (magnitude != 0)
									return result;
#if unsafe_code
								if (typeof(T).IsValueType)
								{
									unsafe
									{
										fixed (generic*
											_vector_flat = _vector._vector,
											result_flat = result._vector)
											for (int i = 0; i < length; i++)
												result_flat[i] = _vector_flat[i] / magnitude;
									}
								}
								else
								{
									generic[] _vector_flat = _vector._vector;
									generic[] result_flat = result._vector;
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

				string num = Generate.TypeToCsharp(typeof(T));

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
					"	" + num + " magnitude = LinearAlgebra<" + num + ">.Vector_Magnitude(_vector);" +
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

				LinearAlgebra<T>.Vector_Normalize =
					Generate.Object<LinearAlgebra<T>.delegates.Vector_Normalize>(Vector_Normalize_string);

				return LinearAlgebra<T>.Vector_Normalize(vector);
			};
			#endregion

		/// <summary>Computes the length of a vector.</summary>
		public static LinearAlgebra<T>.delegates.Vector_Magnitude Vector_Magnitude = (Vector<T> vector) =>
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
						LinearAlgebra<Numeric>.delegates.Vector_Magnitude compile_testing =
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
										fixed (generic*
											_vector_flat = _vector._vector)
											for (int i = 0; i < length; i++)
												result += _vector_flat[i] * _vector_flat[i];
									}
								}
								else
								{
									generic[] _vector_flat = _vector._vector;
									for (int i = 0; i < length; i++)
										result += _vector_flat[i] * _vector_flat[i];
								}
#else
								Numeric[] _vector_flat = _vector._vector;
								for (int i = 0; i < length; i++)
									result += _vector_flat[i] * _vector_flat[i];
#endif
								return Algebra<Numeric>.sqrt(result);
							};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Vector_Magnitude =
					Generate.Object<LinearAlgebra<T>.delegates.Vector_Magnitude>(Vector_Magnitude_string);

				return LinearAlgebra<T>.Vector_Magnitude(vector);
			};
			#endregion

		/// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
		public static LinearAlgebra<T>.delegates.Vector_MagnitudeSquared Vector_MagnitudeSquared = (Vector<T> vector) =>
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
						LinearAlgebra<Numeric>.delegates.Vector_MagnitudeSquared compile_testing =
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
										fixed (generic*
											_vector_flat = _vector._vector)
											for (int i = 0; i < length; i++)
												result += _vector_flat[i] * _vector_flat[i];
									}
								}
								else
								{
									generic[] _vector_flat = _vector._vector;
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Vector_MagnitudeSquared =
					Generate.Object<LinearAlgebra<T>.delegates.Vector_MagnitudeSquared>(Vector_MagnitudeSquared_string);

				return LinearAlgebra<T>.Vector_MagnitudeSquared(vector);
			};
			#endregion

		/// <summary>Computes the angle between two vectors.</summary>
		public static LinearAlgebra<T>.delegates.Vector_Angle Vector_Angle = (Vector<T> first, Vector<T> second) =>
			#region code
			{
				throw new Error("not yet implemented");

				//#region pre-optimization
				//
				//#endregion
				//
				//LinearAlgebra<generic>.delegates.Vector_Angle compile_testing =
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
				//LinearAlgebra<T>.Vector_Angle =
				//	Generate.Object<LinearAlgebra<T>.delegates.Vector_Angle>(Vector_Angle_string);
				//
				//return LinearAlgebra<T>.Vector_Angle(vector);
			};
			#endregion

		/// <summary>Rotates a vector by the specified axis and rotation values.</summary>
		public static LinearAlgebra<T>.delegates.Vector_RotateBy Vector_RotateBy = (Vector<T> vector, T angle, T x, T y, T z) =>
			#region code
			{
				throw new Error("not yet implemented");

				//#region pre-optimization

				//#endregion

				//LinearAlgebra<generic>.delegates.Vector_Angle compile_testing =
				//	#region code (compile testing)

				//	#endregion

				//string Vector_RotateBy_string =
				//	#region code (string)

				//	#endregion

				//Vector_RotateBy_string = Vector_RotateBy_string.Replace("generic", Generate.ToSourceString(typeof(T)));

				//LinearAlgebra<T>.Vector_RotateBy =
				//	Generate.Object<LinearAlgebra<T>.delegates.Vector_RotateBy>(Vector_RotateBy_string);

				//return LinearAlgebra<T>.Vector_RotateBy(vector, angle, x, y, z);
			};
			#endregion

		/// <summary>Computes the linear interpolation between two vectors.</summary>
		public static LinearAlgebra<T>.delegates.Vector_Lerp Vector_Lerp = (Vector<T> left, Vector<T> right, T blend) =>
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
						LinearAlgebra<Numeric>.delegates.Vector_Lerp compile_testing =
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
										fixed (generic*
											_left_flat = _left._vector,
											_right_flat = _right._vector,
											result_flat = result._vector)
											for (int i = 0; i < length; i++)
												result_flat[i] = _left_flat[i] + _blend * (_right_flat[i] - _left_flat[i]);
									}
								}
								else
								{
									generic[] _left_flat = _left._vector;
									generic[] _right_flat = _right._vector;
									generic[] result_flat = result._vector;
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Vector_Lerp =
					Generate.Object<LinearAlgebra<T>.delegates.Vector_Lerp>(Vector_Lerp_string);

				return LinearAlgebra<T>.Vector_Lerp(left, right, blend);
			};
			#endregion

		/// <summary>Sphereically interpolates between two vectors.</summary>
		public static LinearAlgebra<T>.delegates.Vector_Slerp Vector_Slerp = (Vector<T> left, Vector<T> right, T blend) =>
			#region code
			{
				throw new Error("not yet implemented");

				//#region pre-optimization

				//#endregion

				//LinearAlgebra<generic>.delegates.Vector_Angle compile_testing =
				//	#region code (compile testing)

				//	#endregion

				//string Vector_Slerp_string =
				//	#region code (string)

				//	#endregion

				//Vector_Slerp_string = Vector_Slerp_string.Replace("generic", Generate.ToSourceString(typeof(T)));

				//LinearAlgebra<T>.Vector_Slerp =
				//	Generate.Object<LinearAlgebra<T>.delegates.Vector_Slerp>(Vector_Slerp_string);

				//return LinearAlgebra<T>.Vector_Slerp(left, right, blend);
			};
			#endregion

		/// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
		public static LinearAlgebra<T>.delegates.Vector_Blerp Vector_Blerp = (Vector<T> a, Vector<T> b, Vector<T> c, T u, T v) =>
			#region code
			{
				#region pre-optimization
				//return 
				//	LinearAlgebra.Add(
				//		LinearAlgebra.Add(
				//			LinearAlgebra.Multiply(
				//				LinearAlgebra.Subtract(b, a), u),
				//					LinearAlgebra.Multiply(
				//						LinearAlgebra.Subtract(c, a), v)), a);
				#endregion

				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Vector_Blerp compile_testing =
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
									LinearAlgebra<Numeric>.Vector_Add(
										LinearAlgebra<Numeric>.Vector_Add(
											LinearAlgebra<Numeric>.Vector_Multiply(
												LinearAlgebra<Numeric>.Vector_Subtract(_b, _a), _u),
													LinearAlgebra<Numeric>.Vector_Multiply(
														LinearAlgebra<Numeric>.Vector_Subtract(_c, _a), _v)), _a);
							};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

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
					"		LinearAlgebra<" + num + ">.Vector_Add(" +
					"			LinearAlgebra<" + num + ">.Vector_Add(" +
					"				LinearAlgebra<" + num + ">.Vector_Multiply(" +
					"					LinearAlgebra<" + num + ">.Vector_Subtract(_b, _a), _u)," +
					"						LinearAlgebra<" + num + ">.Vector_Multiply(" +
					"							LinearAlgebra<" + num + ">.Vector_Subtract(_c, _a), _v)), _a);" +
					"}";

				#endregion

				LinearAlgebra<T>.Vector_Blerp =
					Generate.Object<LinearAlgebra<T>.delegates.Vector_Blerp>(Vector_Blerp_string);

				return LinearAlgebra<T>.Vector_Blerp(a, b, c, u, v);
			};
			#endregion

		/// <summary>Does a value equality check.</summary>
		public static LinearAlgebra<T>.delegates.Vector_EqualsValue Vector_EqualsValue = (Vector<T> left, Vector<T> right) =>
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
						LinearAlgebra<Numeric>.delegates.Vector_EqualsValue compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Vector_EqualsValue =
					Generate.Object<LinearAlgebra<T>.delegates.Vector_EqualsValue>(Vector_EqualsValue_string);

				return LinearAlgebra<T>.Vector_EqualsValue(left, right);
			};
			#endregion

		/// <summary>Does a value equality check with leniency.</summary>
		public static LinearAlgebra<T>.delegates.Vector_EqualsValue_leniency Vector_EqualsValue_leniency = (Vector<T> left, Vector<T> right, T leniency) =>
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
						LinearAlgebra<Numeric>.delegates.Vector_EqualsValue_leniency compile_testing =
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
									if (Logic<Numeric>.abs(_left[i] - _right[i]) > _leniency)
										return false;
								return true;
							};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Vector_EqualsValue_leniency =
					Generate.Object<LinearAlgebra<T>.delegates.Vector_EqualsValue_leniency>(Vector_EqualsValue_leniency_string);

				return LinearAlgebra<T>.Vector_EqualsValue_leniency(left, right, leniency);
			};
			#endregion

		/// <summary>Rotates a vector by a quaternion.</summary>
		public static LinearAlgebra<T>.delegates.Vector_RotateBy_quaternion Vector_RotateBy_quaternion = (Vector<T> vector, Quaternion<T> rotation) =>
			#region code
			{
				return LinearAlgebra<T>.Quaternion_Rotate(rotation, vector);
			};
			#endregion

		#endregion

		#region matrix

		/// <summary>Creates a zero matrix of the given dimensions.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_FactoryZero Matrix_FactoryZero = (int rows, int columns) =>
			#region code
			{
				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Matrix_FactoryZero compile_testing =
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
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Matrix_FactoryZero =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_FactoryZero>(Matrix_FactoryZero_string);

				return LinearAlgebra<T>.Matrix_FactoryZero(rows, columns);
			};
			#endregion

		/// <summary>Creates a ones matrix of the given dimensions.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_FactoryOne Matrix_FactoryOne = (int rows, int columns) =>
			#region code
			{
				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Matrix_FactoryOne compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Matrix_FactoryOne =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_FactoryOne>(Matrix_FactoryOne_string);

				return LinearAlgebra<T>.Matrix_FactoryOne(rows, columns);
			};
			#endregion

		/// <summary>Creates an identity (ones along diagnol, zeros otherwise) matrix of the given dimensions.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_FactoryIdentity Matrix_FactoryIdentity = (int rows, int columns) =>
			#region code
			{
				#region generic
#if show_Numeric
							LinearAlgebra<Numeric>.delegates.Matrix_FactoryIdentity compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				Matrix_FactoryIdentity_string = Matrix_FactoryIdentity_string.Replace("generic", Generate.TypeToCsharp(typeof(T)));

				LinearAlgebra<T>.Matrix_FactoryIdentity =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_FactoryIdentity>(Matrix_FactoryIdentity_string);

				return LinearAlgebra<T>.Matrix_FactoryIdentity(rows, columns);
			};
			#endregion

		/// <summary>Determines if a matrix is symetric.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_IsSymetric Matrix_IsSymetric = (Matrix<T> matrix) =>
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
							LinearAlgebra<Numeric>.delegates.Matrix_IsSymetric compile_testing =
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
												fixed (generic* _matrix_flat = _matrix._matrix as generic[])
													for (var row = 0; row < size; row++)
														for (var column = row + 1; column < size; column++)
															if (_matrix_flat[row * size + column] != _matrix_flat[column * size + row])
																return false;
											}
										}
										else
										{
											generic[] _matrix_flat = _matrix._matrix as generic[];
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Matrix_IsSymetric =
				Generate.Object<LinearAlgebra<T>.delegates.Matrix_IsSymetric>(Matrix_IsSymetric_string);

				return LinearAlgebra<T>.Matrix_IsSymetric(matrix);
			};
			#endregion

		/// <summary>Negates all the values in a matrix.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_Negate Matrix_Negate = (Matrix<T> matrix) =>
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
							LinearAlgebra<Numeric>.delegates.Matrix_Negate compile_testing =
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
											fixed (generic*
												result_flat = result._matrix as generic[],
												_matrix_flat = _matrix._matrix as generic[])
													for (int i = 0; i < size; i++)
														result_flat[i] = -_matrix_flat[i];
										}
									}
									else
									{
										generic[] result_flat = result._matrix as generic[];
										generic[] _matrix_flat = _matrix._matrix as generic[];
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Matrix_Negate =
				Generate.Object<LinearAlgebra<T>.delegates.Matrix_Negate>(Matrix_Negate_string);

				return LinearAlgebra<T>.Matrix_Negate(matrix);
			};
			#endregion

		/// <summary>Does standard addition of two matrices.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_Add Matrix_Add = (Matrix<T> left, Matrix<T> right) =>
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
						LinearAlgebra<Numeric>.delegates.Matrix_Add compile_testing =
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
											fixed (generic*
												_left_flat = _left._matrix as generic[],
												_right_flat = _right._matrix as generic[],
												result_flat = result._matrix as generic[])
													for (int i = 0; i < size; i++)
														result_flat[i] = _left_flat[i] + _right_flat[i];
										}
									}
									else
									{
										generic[] _left_flat = _left._matrix as generic[];
										generic[] _right_flat = _right._matrix as generic[];
										generic[] result_flat = result._matrix as generic[];
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Matrix_Add =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_Add>(Matrix_Add_string);

				return LinearAlgebra<T>.Matrix_Add(left, right);
			};
			#endregion

		/// <summary>Subtracts a scalar from all the values in a matrix.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_Subtract Matrix_Subtract = (Matrix<T> left, Matrix<T> right) =>
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
						LinearAlgebra<Numeric>.delegates.Matrix_Subtract compile_testing =
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
										fixed (generic*
											_left_flat = _left._matrix as generic[],
											_right_flat = _right._matrix as generic[],
											result_flat = result._matrix as generic[])
												for (int i = 0; i < size; i++)
													result_flat[i] = _left_flat[i] - _right_flat[i];
									}
								}
								else
								{
									generic[] _left_flat = _left._matrix as generic[];
									generic[] _right_flat = _right._matrix as generic[];
									generic[] result_flat = result._matrix as generic[];
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Matrix_Subtract =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_Subtract>(Matrix_Subtract_string);

				return LinearAlgebra<T>.Matrix_Subtract(left, right);
			};
			#endregion

		/// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_Multiply Matrix_Multiply = (Matrix<T> left, Matrix<T> right) =>
			#region code
			{
				#region pre-optimization
				//Matrix<generic> result = 
				//	new Matrix<generic>(left.Rows, right.Columns);
				//for (int i = 0; i < left.Rows; i++)
				//	for (int j = 0; j < right.Columns; j++)
				//		for (int k = 0; k < left.Columns; k++)
				//			result[i, j] += left[i, k] * right[k, j];
				//return result;
				#endregion

				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Matrix_Multiply compile_testing =
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
										fixed (generic*
											result_flat = result._matrix as generic[],
											_left_flat = _left._matrix as generic[],
											_right_flat = _right._matrix as generic[])
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
									generic[] result_flat = result._matrix as generic[];
									generic[] _left_flat = _left._matrix as generic[];
									generic[] _right_flat = _right._matrix as generic[];
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Matrix_Multiply =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_Multiply>(Matrix_Multiply_string);

				return LinearAlgebra<T>.Matrix_Multiply(left, right);
			};
			#endregion

		/// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_Multiply_vector Matrix_Multiply_vector = (Matrix<T> left, Vector<T> right) =>
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
						LinearAlgebra<Numeric>.delegates.Matrix_Multiply_vector compile_testing =
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
										fixed (generic*
											_left_flat = _left._matrix as generic[],
											_right_flat = _right._vector as generic[],
											result_flat = result._vector as generic[])
												for (int i = 0; i < _left_row; i++)
													for (int j = 0; j < _left_col; j++)
														result_flat[i] += _left_flat[i * _left_col + j] * _right_flat[j];
									}
								}
								else
								{
									generic[] _left_flat = _left._matrix as generic[];
									generic[] _right_flat = _right._vector as generic[];
									generic[] result_flat = result._vector as generic[];
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Matrix_Multiply_vector =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_Multiply_vector>(Matrix_Multiply_vector_string);

				return LinearAlgebra<T>.Matrix_Multiply_vector(left, right);
			};
			#endregion

		/// <summary>Multiplies all the values in a matrix by a scalar.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_Multiply_scalar Matrix_Multiply_scalar = (Matrix<T> left, T right) =>
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
						LinearAlgebra<Numeric>.delegates.Matrix_Multiply_scalar compile_testing =
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
										fixed (generic*
											_left_flat = _left._matrix as generic[],
											result_flat = result._matrix as generic[])
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Matrix_Multiply_scalar =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_Multiply_scalar>(Matrix_Multiply_scalar_string);

				return LinearAlgebra<T>.Matrix_Multiply_scalar(left, right);
			};
			#endregion

		/// <summary>Divides all the values in the matrix by a scalar.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_Divide Matrix_Divide = (Matrix<T> left, T right) =>
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
						LinearAlgebra<Numeric>.delegates.Matrix_Divide compile_testing =
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
										fixed (generic*
											matrix_flat = _left._matrix as generic[],
											result_flat = result._matrix as generic[])
												for (int i = 0; i < matrix_row; i++)
													for (int j = 0; j < matrix_col; j++)
														result_flat[i * matrix_col + j] =
															matrix_flat[i * matrix_col + j] / _right;
									}
								}
								else
								{
									generic[] matrix_flat = _left._matrix as generic[];
									generic[] result_flat = result._matrix as generic[];
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Matrix_Divide =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_Divide>(Matrix_Divide_string);

				return LinearAlgebra<T>.Matrix_Divide(left, right);
			};
			#endregion

		/// <summary>Applies a power to a square matrix.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_Power Matrix_Power = (Matrix<T> matrix, int power) =>
			#region code
			{
				#region pre-optimization
				//Matrix<generic> result = _matrix.Clone();
				//for (int i = 0; i < _power; i++)
				//	result = LinearAlgebra.Multiply(result, _matrix);
				//return result;
				#endregion

				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Matrix_Power compile_testing =
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
									return LinearAlgebra<Numeric>.Matrix_FactoryIdentity(_matrix.Rows, _matrix.Columns);
								Matrix<Numeric> result = _matrix.Clone();
								for (int i = 0; i < _power; i++)
									result = LinearAlgebra<Numeric>.Matrix_Multiply(result, _matrix);
								return result;
							};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

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
					"		return LinearAlgebra<" + num + ">.Matrix_FactoryIdentity(_matrix.Rows, _matrix.Columns);" +
					"	Matrix<" + num + "> result = _matrix.Clone();" +
					"	for (int i = 0; i < _power; i++)" +
					"		result = LinearAlgebra<" + num + ">.Matrix_Multiply(result, _matrix);" +
					"	return result;" +
					"}";
				#endregion

				LinearAlgebra<T>.Matrix_Power =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_Power>(Matrix_Power_string);

				return LinearAlgebra<T>.Matrix_Power(matrix, power);
			};
			#endregion

		/// <summary>Gets the minor of a matrix.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_Minor Matrix_Minor = (Matrix<T> matrix, int row, int column) =>
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
						LinearAlgebra<Numeric>.delegates.Matrix_Minor compile_testing =
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
										fixed (generic*
											_matrix_flat = _matrix._matrix as generic[],
											minor_flat = minor._matrix as generic[])
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Matrix_Minor =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_Minor>(Matrix_Minor_string);

				return LinearAlgebra<T>.Matrix_Minor(matrix, row, column);
			};
			#endregion

		/// <summary>Combines two matrices from left to right (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
		public static LinearAlgebra<T>.delegates.Matrix_ConcatenateRowWise Matrix_ConcatenateRowWise = (Matrix<T> left, Matrix<T> right) =>
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
						LinearAlgebra<generic>.delegates.Matrix_ConcatenateRowWise compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Matrix_ConcatenateRowWise =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_ConcatenateRowWise>(Matrix_ConcatenateRowWise_string);

				return LinearAlgebra<T>.Matrix_ConcatenateRowWise(left, right);
			};
			#endregion

		/// <summary>Calculates the determinent of a square matrix.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_Determinent Matrix_Determinent = (Matrix<T> matrix) =>
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
				//				LinearAlgebra.SwapRows(rref, i, j);
				//				det *= -1;
				//			}
				//	det *= rref[i, i];
				//	LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
				//	for (int j = i + 1; j < rref.Rows; j++)
				//		LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
				//	for (int j = i - 1; j >= 0; j--)
				//		LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
				//}
				//return det;
				#endregion

				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Matrix_Determinent compile_testing =
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
												LinearAlgebra<Numeric>.Matrix_SwapRows(rref, i, j);
												det *= -1;
											}
									det *= rref[i, i];
									LinearAlgebra<Numeric>.Matrix_RowMultiplication(rref, i, 1 / rref[i, i]);
									for (int j = i + 1; j < rref.Rows; j++)
										LinearAlgebra<Numeric>.Matrix_RowAddition(rref, j, i, -rref[j, i]);
									for (int j = i - 1; j >= 0; j--)
										LinearAlgebra<Numeric>.Matrix_RowAddition(rref, j, i, -rref[j, i]);
								}
								return det;
							};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

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
					"					LinearAlgebra<" + num + ">.Matrix_SwapRows(rref, i, j);" +
					"					det *= -1;" +
					"				}" +
					"		det *= rref[i, i];" +
					"		LinearAlgebra<" + num + ">.Matrix_RowMultiplication(rref, i, 1 / rref[i, i]);" +
					"		for (int j = i + 1; j < rref.Rows; j++)" +
					"			LinearAlgebra<" + num + ">.Matrix_RowAddition(rref, j, i, -rref[j, i]);" +
					"		for (int j = i - 1; j >= 0; j--)" +
					"			LinearAlgebra<" + num + ">.Matrix_RowAddition(rref, j, i, -rref[j, i]);" +
					"	}" +
					"	return det;" +
					"}";

				#endregion

				LinearAlgebra<T>.Matrix_Determinent =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_Determinent>(Matrix_Determinent_string);

				return LinearAlgebra<T>.Matrix_Determinent(matrix);
			};
			#endregion

		/// <summary>Calculates the echelon of a matrix (aka REF).</summary>
		public static LinearAlgebra<T>.delegates.Matrix_Echelon Matrix_Echelon = (Matrix<T> matrix) =>
			#region code
			{
				#region pre-optimization
				//Matrix<generic> result = _matrix.Clone();
				//for (int i = 0; i < _matrix.Rows; i++)
				//{
				//	if (result[i, i] == 0)
				//		for (int j = i + 1; j < result.Rows; j++)
				//			if (result[j, i] != 0)
				//				LinearAlgebra.SwapRows(result, i, j);
				//	if (result[i, i] == 0)
				//		continue;
				//	if (result[i, i] != 1)
				//		for (int j = i + 1; j < result.Rows; j++)
				//			if (result[j, i] == 1)
				//				LinearAlgebra.SwapRows(result, i, j);
				//	LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
				//	for (int j = i + 1; j < result.Rows; j++)
				//		LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
				#endregion

				#region generic
#if hide_generic
						LinearAlgebra<generic>.delegates.Matrix_Echelon compile_testing =
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
												LinearAlgebra<generic>.Matrix_SwapRows(result, i, j);
									if (result[i, i] == 0)
										continue;
									if (result[i, i] != 1)
										for (int j = i + 1; j < result.Rows; j++)
											if (result[j, i] == 1)
												LinearAlgebra<generic>.Matrix_SwapRows(result, i, j);
									LinearAlgebra<generic>.Matrix_RowMultiplication(result, i, 1 / result[i, i]);
									for (int j = i + 1; j < result.Rows; j++)
										LinearAlgebra<generic>.Matrix_RowAddition(result, j, i, -result[j, i]);
								}
								return result;
							};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

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
					"					LinearAlgebra<" + num + ">.Matrix_SwapRows(result, i, j);" +
					"		if (result[i, i] == 0)" +
					"			continue;" +
					"		if (result[i, i] != 1)" +
					"			for (int j = i + 1; j < result.Rows; j++)" +
					"				if (result[j, i] == 1)" +
					"					LinearAlgebra<" + num + ">.Matrix_SwapRows(result, i, j);" +
					"		LinearAlgebra<" + num + ">.Matrix_RowMultiplication(result, i, 1 / result[i, i]);" +
					"		for (int j = i + 1; j < result.Rows; j++)" +
					"			LinearAlgebra<" + num + ">.Matrix_RowAddition(result, j, i, -result[j, i]);" +
					"	}" +
					"	return result;" +
					"}";

				#endregion

				LinearAlgebra<T>.Matrix_Echelon =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_Echelon>(Matrix_Echelon_string);

				return LinearAlgebra<T>.Matrix_Echelon(matrix);
			};
			#endregion

		/// <summary>Calculates the echelon of a matrix and reduces it (aka RREF).</summary>
		public static LinearAlgebra<T>.delegates.Matrix_ReducedEchelon Matrix_ReducedEchelon = (Matrix<T> matrix) =>
			#region code
			{
				#region pre-optimization
				//Matrix<generic> result = matrix.Clone();
				//for (int i = 0; i < matrix.Rows; i++)
				//{
				//	if (result[i, i] == 0)
				//		for (int j = i + 1; j < result.Rows; j++)
				//			if (result[j, i] != 0)
				//				LinearAlgebra.SwapRows(result, i, j);
				//	if (result[i, i] == 0) continue;
				//	if (result[i, i] != 1)
				//		for (int j = i + 1; j < result.Rows; j++)
				//			if (result[j, i] == 1)
				//				LinearAlgebra.SwapRows(result, i, j);
				//	LinearAlgebra.RowMultiplication(result, i, 1 / result[i, i]);
				//	for (int j = i + 1; j < result.Rows; j++)
				//		LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
				//	for (int j = i - 1; j >= 0; j--)
				//		LinearAlgebra.RowAddition(result, j, i, -result[j, i]);
				#endregion

				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Matrix_ReducedEchelon compile_testing =
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
												LinearAlgebra<Numeric>.Matrix_SwapRows(result, i, j);
									if (result[i, i] == 0) continue;
									if (result[i, i] != 1)
										for (int j = i + 1; j < result.Rows; j++)
											if (result[j, i] == 1)
												LinearAlgebra<Numeric>.Matrix_SwapRows(result, i, j);
									LinearAlgebra<Numeric>.Matrix_RowMultiplication(result, i, 1 / result[i, i]);
									for (int j = i + 1; j < result.Rows; j++)
										LinearAlgebra<Numeric>.Matrix_RowAddition(result, j, i, -result[j, i]);
									for (int j = i - 1; j >= 0; j--)
										LinearAlgebra<Numeric>.Matrix_RowAddition(result, j, i, -result[j, i]);
								}
								return result;
							};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Matrix_ReducedEchelon_string =
					"(Matrix<" + num + "> _matrix) =>" +
					"		{"+
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
					"					LinearAlgebra<" + num + ">.Matrix_SwapRows(result, i, j);" +
					"		if (result[i, i] == 0) continue;" +
					"		if (result[i, i] != 1)" +
					"			for (int j = i + 1; j < result.Rows; j++)" +
					"				if (result[j, i] == 1)" +
					"					LinearAlgebra<" + num + ">.Matrix_SwapRows(result, i, j);" +
					"		LinearAlgebra<" + num + ">.Matrix_RowMultiplication(result, i, 1 / result[i, i]);" +
					"		for (int j = i + 1; j < result.Rows; j++)" +
					"			LinearAlgebra<" + num + ">.Matrix_RowAddition(result, j, i, -result[j, i]);" +
					"		for (int j = i - 1; j >= 0; j--)" +
					"			LinearAlgebra<" + num + ">.Matrix_RowAddition(result, j, i, -result[j, i]);" +
					"	}" +
					"	return result;" +
					"}";

				#endregion

				LinearAlgebra<T>.Matrix_ReducedEchelon =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_ReducedEchelon>(Matrix_ReducedEchelon_string);

				return LinearAlgebra<T>.Matrix_ReducedEchelon(matrix);
			};
			#endregion

		/// <summary>Calculates the inverse of a matrix.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_Inverse Matrix_Inverse = (Matrix<T> matrix) =>
			#region code
			{
				#region pre-optimization
				//Matrix<generic> identity = 
				//	LinearAlgebra.MatrixFactoryIdentity_generic(matrix.Rows, matrix.Columns);
				//Matrix<generic> rref = matrix.Clone();
				//for (int i = 0; i < matrix.Rows; i++)
				//{
				//	if (rref[i, i] == 0)
				//		for (int j = i + 1; j < rref.Rows; j++)
				//			if (rref[j, i] != 0)
				//			{
				//				LinearAlgebra.SwapRows(rref, i, j);
				//				LinearAlgebra.SwapRows(identity, i, j);
				//			}
				//	LinearAlgebra.RowMultiplication(identity, i, 1 / rref[i, i]);
				//	LinearAlgebra.RowMultiplication(rref, i, 1 / rref[i, i]);
				//	for (int j = i + 1; j < rref.Rows; j++)
				//	{
				//		LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
				//		LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
				//	}
				//	for (int j = i - 1; j >= 0; j--)
				//	{
				//		LinearAlgebra.RowAddition(identity, j, i, -rref[j, i]);
				//		LinearAlgebra.RowAddition(rref, j, i, -rref[j, i]);
				//	}
				//}
				//return identity;
				#endregion

				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Matrix_Inverse compile_testing =
							(Matrix<Numeric> _matrix) =>
							{
#if no_error_checking
								// nothing
#else
								if (object.ReferenceEquals(_matrix, null))
									throw new Error("null reference: _matrix");
								if (LinearAlgebra<Numeric>.Matrix_Determinent(_matrix) == 0)
									throw new Error("inverse calculation failed.");
#endif
								Matrix<Numeric> identity = LinearAlgebra<Numeric>.Matrix_FactoryIdentity(_matrix.Rows, _matrix.Columns);
								Matrix<Numeric> rref = _matrix.Clone();
								for (int i = 0; i < _matrix.Rows; i++)
								{
									if (rref[i, i] == 0)
										for (int j = i + 1; j < rref.Rows; j++)
											if (rref[j, i] != 0)
											{
												LinearAlgebra<Numeric>.Matrix_SwapRows(rref, i, j);
												LinearAlgebra<Numeric>.Matrix_SwapRows(identity, i, j);
											}
									LinearAlgebra<Numeric>.Matrix_RowMultiplication(identity, i, 1 / rref[i, i]);
									LinearAlgebra<Numeric>.Matrix_RowMultiplication(rref, i, 1 / rref[i, i]);
									for (int j = i + 1; j < rref.Rows; j++)
									{
											LinearAlgebra<Numeric>.Matrix_RowAddition(identity, j, i, -rref[j, i]);
											LinearAlgebra<Numeric>.Matrix_RowAddition(rref, j, i, -rref[j, i]);
									}
									for (int j = i - 1; j >= 0; j--)
									{
											LinearAlgebra<Numeric>.Matrix_RowAddition(identity, j, i, -rref[j, i]);
											LinearAlgebra<Numeric>.Matrix_RowAddition(rref, j, i, -rref[j, i]);
									}
								}
								return identity;
							};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Matrix_Inverse_string =
					"(LinearAlgebra<generic>.delegates.Matrix_Inverse)(" +
					"(Matrix<generic> _matrix) =>" +
					"{" +
#if no_error_checking
								 // nothing
#else
 "	if (object.ReferenceEquals(_matrix, null))" +
					"		throw new Error(\"null reference: _matrix\");" +
					"	if (LinearAlgebra<generic>.Matrix_Determinent(_matrix) == 0)" +
					"		throw new Error(\"inverse calculation failed.\");" +
#endif
 "	Matrix<generic> identity = LinearAlgebra<generic>.Matrix_FactoryIdentity(_matrix.Rows, _matrix.Columns);" +
					"	Matrix<generic> rref = _matrix.Clone();" +
					"	for (int i = 0; i < _matrix.Rows; i++)" +
					"	{" +
					"		if (rref[i, i] == 0)" +
					"			for (int j = i + 1; j < rref.Rows; j++)" +
					"				if (rref[j, i] != 0)" +
					"				{" +
					"					LinearAlgebra<generic>.Matrix_SwapRows(rref, i, j);" +
					"					LinearAlgebra<generic>.Matrix_SwapRows(identity, i, j);" +
					"				}" +
					"		LinearAlgebra<generic>.Matrix_RowMultiplication(identity, i, 1 / rref[i, i]);" +
					"		LinearAlgebra<generic>.Matrix_RowMultiplication(rref, i, 1 / rref[i, i]);" +
					"		for (int j = i + 1; j < rref.Rows; j++)" +
					"		{" +
					"				LinearAlgebra<generic>.Matrix_RowAddition(identity, j, i, -rref[j, i]);" +
					"				LinearAlgebra<generic>.Matrix_RowAddition(rref, j, i, -rref[j, i]);" +
					"		}" +
					"		for (int j = i - 1; j >= 0; j--)" +
					"		{" +
					"				LinearAlgebra<generic>.Matrix_RowAddition(identity, j, i, -rref[j, i]);" +
					"				LinearAlgebra<generic>.Matrix_RowAddition(rref, j, i, -rref[j, i]);" +
					"		}" +
					"	}" +
					"	return identity;" +
					"}";
				#endregion

				LinearAlgebra<T>.Matrix_Inverse =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_Inverse>(Matrix_Inverse_string);

				return LinearAlgebra<T>.Matrix_Inverse(matrix);
			};
			#endregion

		/// <summary>Calculates the adjoint of a matrix.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_Adjoint Matrix_Adjoint = (Matrix<T> matrix) =>
			#region code
			{
				#region pre-optimization
				//Matrix<generic> AdjointMatrix = new Matrix<generic>(_matrix.Rows, _matrix.Columns);
				//for (int i = 0; i < _matrix.Rows; i++)
				//	for (int j = 0; j < _matrix.Columns; j++)
				//		if ((i + j) % 2 == 0)
				//			AdjointMatrix[i, j] = LinearAlgebra.Determinent(LinearAlgebra.Minor(_matrix, i, j));
				//		else
				//			AdjointMatrix[i, j] = -LinearAlgebra.Determinent(LinearAlgebra.Minor(_matrix, i, j));
				//return LinearAlgebra.Transpose(AdjointMatrix);
				#endregion

				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Matrix_Adjoint compile_testing =
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
											AdjointMatrix[i, j] = LinearAlgebra<Numeric>.Matrix_Determinent(LinearAlgebra<Numeric>.Matrix_Minor(_matrix, i, j));
										else
											AdjointMatrix[i, j] = -LinearAlgebra<Numeric>.Matrix_Determinent(LinearAlgebra<Numeric>.Matrix_Minor(_matrix, i, j));
								return LinearAlgebra<Numeric>.Matrix_Transpose(AdjointMatrix);
							};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

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
					"				AdjointMatrix[i, j] = LinearAlgebra<" + num + ">.Matrix_Determinent(LinearAlgebra<" + num + ">.Matrix_Minor(_matrix, i, j));" +
					"			else" +
					"				AdjointMatrix[i, j] = -LinearAlgebra<" + num + ">.Matrix_Determinent(LinearAlgebra<" + num + ">.Matrix_Minor(_matrix, i, j));" +
					"	return LinearAlgebra<" + num + ">.Transpose(AdjointMatrix);" +
					"}";

				#endregion

				LinearAlgebra<T>.Matrix_Adjoint =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_Adjoint>(Matrix_Adjoint_string);

				return LinearAlgebra<T>.Matrix_Adjoint(matrix);
			};
			#endregion

		/// <summary>Returns the transpose of a matrix.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_Transpose Matrix_Transpose = (Matrix<T> matrix) =>
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
						LinearAlgebra<Numeric>.delegates.Matrix_Transpose compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Matrix_Transpose =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_Transpose>(Matrix_Transpose_string);

				return LinearAlgebra<T>.Matrix_Transpose(matrix);
			};
			#endregion

		/// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_DecomposeLU Matrix_DecomposeLU = (Matrix<T> matrix, out Matrix<T> lower, out Matrix<T> upper) =>
			#region code
			{
				#region pre-optimization
				//Lower = LinearAlgebra.MatrixFactoryIdentity_generic(matrix.Rows, matrix.Columns);
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
						LinearAlgebra<Numeric>.delegates.Matrix_DecomposeLU compile_testing =
							(Matrix<Numeric> _matrix, out Matrix<Numeric> _Lower, out Matrix<Numeric> _Upper) =>
							{
#if no_error_checking
#else
								if (object.ReferenceEquals(_matrix, null))
									throw new Error("null reference: _matrix");
								if (_matrix.Rows != _matrix.Columns)
									throw new Error("non-square _matrix during DecomposeLU function");
#endif
								_Lower = LinearAlgebra<Numeric>.Matrix_FactoryIdentity(_matrix.Rows, _matrix.Columns);
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

				string num = Generate.TypeToCsharp(typeof(T));

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
 "	_Lower = LinearAlgebra<" + num + ">.Matrix_FactoryIdentity(_matrix.Rows, _matrix.Columns);" +
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

				LinearAlgebra<T>.Matrix_DecomposeLU =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_DecomposeLU>(Matrix_DecomposeLU_string);

				LinearAlgebra<T>.Matrix_DecomposeLU(matrix, out lower, out upper);
			};
			#endregion

		/// <summary>Does a value equality check.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_EqualsByValue Matrix_EqualsByValue = (Matrix<T> left, Matrix<T> right) =>
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
						LinearAlgebra<Numeric>.delegates.Matrix_EqualsByValue compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Matrix_EqualsByValue =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_EqualsByValue>(Matrix_EqualsByValue_string);

				return LinearAlgebra<T>.Matrix_EqualsByValue(left, right);
			};
			#endregion

		/// <summary>Does a value equality check with leniency.</summary>
		public static LinearAlgebra<T>.delegates.Matrix_EqualsByValue_leniency Matrix_EqualsByValue_leniency = (Matrix<T> left, Matrix<T> right, T leniency) =>
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
						LinearAlgebra<Numeric>.delegates.Matrix_EqualsByValue_leniency compile_testing =
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
										if (Logic<Numeric>.abs(_left[i, j] - _right[i, j]) > _leniency)
											return false;
								return true;
							};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Matrix_EqualsByValue_leniency =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_EqualsByValue_leniency>(Matrix_EqualsByValue_leniency_string);

				return LinearAlgebra<T>.Matrix_EqualsByValue_leniency(left, right, leniency);
			};
			#endregion

		public static LinearAlgebra<T>.delegates.Matrix_RowMultiplication Matrix_RowMultiplication = (Matrix<T> matrix, int row, T scalar) =>
			#region code
			{
				#region pre-optimization
				//for (int j = 0; j < matrix.Columns; j++)
				//	matrix[row, j] *= scalar;
				#endregion

				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Matrix_RowMultiplication compile_testing =
							(Matrix<Numeric> _matrix, int _row, Numeric _scalar) =>
							{
								for (int j = 0; j < _matrix.Columns; j++)
									_matrix[_row, j] *= _scalar;
							};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Matrix_RowMultiplication_string =
					"(Matrix<" + num + "> _matrix, int _row, " + num + " _scalar) =>" +
					"{" +
					"	for (int j = 0; j < _matrix.Columns; j++)" +
					"		_matrix[_row, j] *= _scalar;" +
					"}";

				#endregion

				LinearAlgebra<T>.Matrix_RowMultiplication =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_RowMultiplication>(Matrix_RowMultiplication_string);

				LinearAlgebra<T>.Matrix_RowMultiplication(matrix, row, scalar);
			};
			#endregion

		public static LinearAlgebra<T>.delegates.Matrix_RowAddition Matrix_RowAddition = (Matrix<T> matrix, int target, int second, T scalar) =>
			#region code
			{
				#region pre-optimization
				//for (int j = 0; j < matrix.Columns; j++)
				//	matrix[target, j] += (matrix[second, j] * scalar);
				#endregion

				#region generic
#if hide_generic
						LinearAlgebra<generic>.delegates.Matrix_RowAddition compile_testing =
							(Matrix<generic> _matrix, int _target, int _second, generic _scalar) =>
							{
								for (int j = 0; j < _matrix.Columns; j++)
									_matrix[_target, j] += (_matrix[_second, j] * _scalar);
							};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Matrix_RowAddition_string =
					"(Matrix<" + num + "> _matrix, int _target, int _second, " + num + " _scalar) =>" +
					"{" +
					"	for (int j = 0; j < _matrix.Columns; j++)" +
					"		_matrix[_target, j] += (_matrix[_second, j] * _scalar);" +
					"}";

				#endregion

				LinearAlgebra<T>.Matrix_RowAddition =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_RowAddition>(Matrix_RowAddition_string);

				LinearAlgebra<T>.Matrix_RowAddition(matrix, target, second, scalar);
			};
			#endregion

		public static LinearAlgebra<T>.delegates.Matrix_SwapRows Matrix_SwapRows = (Matrix<T> matrix, int row1, int row2) =>
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
						LinearAlgebra<Numeric>.delegates.Matrix_SwapRows compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Matrix_SwapRows =
					Generate.Object<LinearAlgebra<T>.delegates.Matrix_SwapRows>(Matrix_SwapRows_string);

				LinearAlgebra<T>.Matrix_SwapRows(matrix, row1, row2);
			};
			#endregion

		#endregion

		#region quaternion

		/// <summary>Computes the length of quaternion.</summary>
		public static LinearAlgebra<T>.delegates.Quaternion_Magnitude Quaternion_Magnitude = (Quaternion<T> quaternion) =>
			#region code
			{
				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Quaternion_Magnitude compile_testing =
							(Quaternion<Numeric> _quaternion) =>
							{
#if no_error_checking
								// nothing
#else
								if (object.ReferenceEquals(_quaternion, null))
									throw new Error("null reference: _quaternion");
#endif
								return Algebra<Numeric>.sqrt(
									(_quaternion.X * _quaternion.X +
									_quaternion.Y * _quaternion.Y +
									_quaternion.Z * _quaternion.Z +
									_quaternion.W * _quaternion.W));
							};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Quaternion_Magnitude =
					Generate.Object<LinearAlgebra<T>.delegates.Quaternion_Magnitude>(Quaternion_Magnitude_string);

				return LinearAlgebra<T>.Quaternion_Magnitude(quaternion);
			};
			#endregion

		/// <summary>Computes the length of a quaternion, but doesn't square root it.</summary>
		public static LinearAlgebra<T>.delegates.Quaternion_MagnitudeSquared Quaternion_MagnitudeSquared = (Quaternion<T> quaternion) =>
			#region code
			{
				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Quaternion_MagnitudeSquared compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Quaternion_MagnitudeSquared =
					Generate.Object<LinearAlgebra<T>.delegates.Quaternion_MagnitudeSquared>(Quaternion_MagnitudeSquared_string);

				return LinearAlgebra<T>.Quaternion_MagnitudeSquared(quaternion);
			};
			#endregion

		/// <summary>Gets the conjugate of the quaternion.</summary>
		public static LinearAlgebra<T>.delegates.Quaternion_Conjugate Quaternion_Conjugate = (Quaternion<T> quaternion) =>
			#region code
			{
				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Quaternion_Conjugate compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Quaternion_Conjugate =
					Generate.Object<LinearAlgebra<T>.delegates.Quaternion_Conjugate>(Quaternion_Conjugate_string);

				return LinearAlgebra<T>.Quaternion_Conjugate(quaternion);
			};
			#endregion

		/// <summary>Adds two quaternions together.</summary>
		public static LinearAlgebra<T>.delegates.Quaternion_Add Quaternion_Add = (Quaternion<T> left, Quaternion<T> right) =>
			#region code
			{
				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Quaternion_Add compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Quaternion_Add =
					Generate.Object<LinearAlgebra<T>.delegates.Quaternion_Add>(Quaternion_Add_string);

				return LinearAlgebra<T>.Quaternion_Add(left, right);
			};
			#endregion

		/// <summary>Subtracts two quaternions.</summary>
		public static LinearAlgebra<T>.delegates.Quaternion_Subtract Quaternion_Subtract = (Quaternion<T> left, Quaternion<T> right) =>
			#region code
			{
				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Quaternion_Subtract compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Quaternion_Subtract =
					Generate.Object<LinearAlgebra<T>.delegates.Quaternion_Subtract>(Quaternion_Subtract_string);

				return LinearAlgebra<T>.Quaternion_Subtract(left, right);
			};
			#endregion

		/// <summary>Multiplies two quaternions together.</summary>
		public static LinearAlgebra<T>.delegates.Quaternion_Multiply Quaternion_Multiply = (Quaternion<T> left, Quaternion<T> right) =>
			#region code
			{
				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Quaternion_Multiply compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Quaternion_Multiply =
					Generate.Object<LinearAlgebra<T>.delegates.Quaternion_Multiply>(Quaternion_Multiply_string);

				return LinearAlgebra<T>.Quaternion_Multiply(left, right);
			};
			#endregion

		/// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
		public static LinearAlgebra<T>.delegates.Quaternion_Multiply_scalar Quaternion_Multiply_scalar = (Quaternion<T> left, T right) =>
			#region code
			{
				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Quaternion_Multiply_scalar compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Quaternion_Multiply_scalar =
					Generate.Object<LinearAlgebra<T>.delegates.Quaternion_Multiply_scalar>(Quaternion_Multiply_scalar_string);

				return LinearAlgebra<T>.Quaternion_Multiply_scalar(left, right);
			};
			#endregion

		/// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
		public static LinearAlgebra<T>.delegates.Quaternion_Multiply_Vector Quaternion_Multiply_Vector = (Quaternion<T> left, Vector<T> right) =>
			#region code
			{
				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Quaternion_Multiply_Vector compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Quaternion_Multiply_Vector =
					Generate.Object<LinearAlgebra<T>.delegates.Quaternion_Multiply_Vector>(Quaternion_Multiply_Vector_string);

				return LinearAlgebra<T>.Quaternion_Multiply_Vector(left, right);
			};
			#endregion

		/// <summary>Normalizes the quaternion.</summary>
		public static LinearAlgebra<T>.delegates.Quaternion_Normalize Quaternion_Normalize = (Quaternion<T> quaternion) =>
			#region code
			{
				#region generic
#if hide_generic
						LinearAlgebra<generic>.delegates.Quaternion_Normalize compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Quaternion_Normalize =
					Generate.Object<LinearAlgebra<T>.delegates.Quaternion_Normalize>(Quaternion_Normalize_string);

				return LinearAlgebra<T>.Quaternion_Normalize(quaternion);
			};
			#endregion

		/// <summary>Inverts a quaternion.</summary>
		public static LinearAlgebra<T>.delegates.Quaternion_Invert Quaternion_Invert = (Quaternion<T> quaternion) =>
			#region code
			{
				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Quaternion_Invert compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Quaternion_Invert =
					Generate.Object<LinearAlgebra<T>.delegates.Quaternion_Invert>(Quaternion_Invert_string);

				return LinearAlgebra<T>.Quaternion_Normalize(quaternion);
			};
			#endregion

		/// <summary>Lenearly interpolates between two quaternions.</summary>
		public static LinearAlgebra<T>.delegates.Quaternion_Lerp Quaternion_Lerp = (Quaternion<T> left, Quaternion<T> right, T blend) =>
			#region code
			{
				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Quaternion_Lerp compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Quaternion_Lerp =
					Generate.Object<LinearAlgebra<T>.delegates.Quaternion_Lerp>(Quaternion_Lerp_string);

				return LinearAlgebra<T>.Quaternion_Lerp(left, right, blend);
			};
			#endregion

		/// <summary>Sphereically interpolates between two quaternions.</summary>
		public static LinearAlgebra<T>.delegates.Quaternion_Slerp Quaternion_Slerp = (Quaternion<T> left, Quaternion<T> right, T blend) =>
			#region code
			{
				throw new Error("not yet implemented");

				//LinearAlgebra<generic>.delegates.Quaternion_Slerp compile_testing =
				//	#region code (compile testing)

				//	#endregion

				//string Quaternion_Lerp_string =
				//	#region code (string)

				//	#endregion

				//Quaternion_Slerp_string = Quaternion_Slerp_string.Replace("generic", Generate.ToSourceString(typeof(T)));

				//LinearAlgebra<T>.Quaternion_Slerp =
				//	Generate.Object<LinearAlgebra<T>.delegates.Quaternion_Slerp>(Quaternion_Slerp_string);

				//return LinearAlgebra<T>.Quaternion_Slerp(left, right, blend);
			};
			#endregion

		/// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
		public static LinearAlgebra<T>.delegates.Quaternion_Rotate Quaternion_Rotate = (Quaternion<T> rotation, Vector<T> vector) =>
			#region code
			{
				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Quaternion_Rotate compile_testing =
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
									LinearAlgebra<Numeric>.Quaternion_Multiply(
									LinearAlgebra<Numeric>.Quaternion_Multiply_Vector(_rotation, _vector),
									LinearAlgebra<Numeric>.Quaternion_Conjugate(_rotation));
								return new Vector<Numeric>(answer.X, answer.Y, answer.Z);
							};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

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
					"		LinearAlgebra<" + num + ">.Quaternion_Multiply(" +
					"		LinearAlgebra<" + num + ">.Quaternion_Multiply_Vector(_rotation, _vector)," +
					"		LinearAlgebra<" + num + ">.Quaternion_Conjugate(_rotation));" +
					"	return new Vector<" + num + ">(answer.X, answer.Y, answer.Z);" +
					"}";

				#endregion

				LinearAlgebra<T>.Quaternion_Rotate =
					Generate.Object<LinearAlgebra<T>.delegates.Quaternion_Rotate>(Quaternion_Rotate_string);

				return LinearAlgebra<T>.Quaternion_Rotate(rotation, vector);
			};
			#endregion

		/// <summary>Does a value equality check.</summary>
		public static LinearAlgebra<T>.delegates.Quaternion_EqualsValue Quaternion_EqualsValue = (Quaternion<T> left, Quaternion<T> right) =>
			#region code
			{
				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Quaternion_EqualsValue compile_testing =
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

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Quaternion_EqualsValue =
					Generate.Object<LinearAlgebra<T>.delegates.Quaternion_EqualsValue>(Quaternion_EqualsValue_string);

				return LinearAlgebra<T>.Quaternion_EqualsValue(left, right);
			};
			#endregion

		/// <summary>Does a value equality check with leniency.</summary>
		public static LinearAlgebra<T>.delegates.Quaternion_EqualsValue_leniency Quaternion_EqualsValue_leniency = (Quaternion<T> left, Quaternion<T> right, T leniency) =>
			#region code
			{
				#region generic
#if show_Numeric
						LinearAlgebra<Numeric>.delegates.Quaternion_EqualsValue_leniency compile_testing =
							(Quaternion<Numeric> _left, Quaternion<Numeric> _right, Numeric _leniency) =>
							{
								if (object.ReferenceEquals(_left, null) && object.ReferenceEquals(_right, null))
									return true;
								if (object.ReferenceEquals(_left, null))
									return false;
								if (object.ReferenceEquals(_right, null))
									return false;
								return
									Logic<Numeric>.abs(_left.X - _right.X) < _leniency &&
									Logic<Numeric>.abs(_left.Y - _right.Y) < _leniency &&
									Logic<Numeric>.abs(_left.Z - _right.Z) < _leniency &&
									Logic<Numeric>.abs(_left.W - _right.W) < _leniency;
							};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

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

				LinearAlgebra<T>.Quaternion_EqualsValue_leniency =
					Generate.Object<LinearAlgebra<T>.delegates.Quaternion_EqualsValue_leniency>(Quaternion_EqualsValue_leniency_string);

				return LinearAlgebra<T>.Quaternion_EqualsValue_leniency(left, right, leniency);
			};
			#endregion

		#endregion

		#endregion

		#region generic

		#region vector

		///// <summary>Computes the angle between two vectors.</summary>
		///// <param name="first">The first vector to determine the angle between.</param>
		///// <param name="second">The second vector to determine the angle between.</param>
		///// <returns>The angle between the two vectors in radians.</returns>
		//public static generic Angle(Vector<generic> first, Vector<generic> second)
		//{
		//		throw new Error("requires rational types");

		//		//			#region pre-optimization

		//		//			//return Trigonometry.arccos(
		//		//			//	LinearAlgebra.DotProduct(first, second) / 
		//		//			//	(LinearAlgebra.Magnitude(first) * 
		//		//			//	LinearAlgebra.Magnitude(second)));

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
		//		//				LinearAlgebra.DotProduct(first, second) /
		//		//				(LinearAlgebra.Magnitude(first) *
		//		//				LinearAlgebra.Magnitude(second)));
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

		//		//			//generic dot = LinearAlgebra.DotProduct(left, right);
		//		//			//dot = dot < -1 ? -1 : dot;
		//		//			//dot = dot > 1 ? 1 : dot;
		//		//			//generic theta = Trigonometry.arccos(dot) * blend;
		//		//			//return LinearAlgebra.Multiply(LinearAlgebra.Add(LinearAlgebra.Multiply(left, Trigonometry.cos(theta)),
		//		//			//	LinearAlgebra.Normalize(LinearAlgebra.Subtract(right, LinearAlgebra.Multiply(left, dot)))), Trigonometry.sin(theta));

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

		//		//			generic dot = LinearAlgebra.DotProduct(left, right);
		//		//			dot = dot < -1 ? -1 : dot;
		//		//			dot = dot > 1 ? 1 : dot;
		//		//			generic theta = Trigonometry.arccos(dot) * blend;
		//		//			return LinearAlgebra.Multiply(LinearAlgebra.Add(LinearAlgebra.Multiply(left, Trigonometry.cos(theta)),
		//		//				LinearAlgebra.Normalize(LinearAlgebra.Subtract(right, LinearAlgebra.Multiply(left, dot)))), Trigonometry.sin(theta));
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

		#region matrix

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

		#region quaterion

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

		#region tableau

		//const generic epsilon = 1.0e-8;
		////int equal(generic a, generic b) { return fabs(a - b) < epsilon; }

		//static void pivot_on(ref generic[,] tableau, int row, int col)
		//{
		//	int i, j;
		//	generic pivot;

		//	pivot = tableau[row, col];
		//	if (!(pivot > 0))
		//		throw new Error("possible invalid tableau values (IDK)");
		//	for (j = 0; j < tableau.GetLength(1); j++)
		//		tableau[row, j] /= pivot;
		//	if (!(Logic.Equate(tableau[row, col], 1, epsilon)))
		//		throw new Error("possible invalid tableau values (IDK)");

		//	for (i = 0; i < tableau.GetLength(0); i++)
		//	{ // foreach remaining row i do
		//		generic multiplier = tableau[i, col];
		//		if (i == row) continue;
		//		for (j = 0; j < tableau.GetLength(1); j++)
		//		{ // r[i] = r[i] - z * r[row];
		//			tableau[i, j] -= multiplier * tableau[row, j];
		//		}
		//	}
		//}

		//// Find pivot_col = most negative column in mat[0][1..n]
		//static int find_pivot_column(ref generic[,] tableau)
		//{
		//	int j, pivot_col = 1;
		//	generic lowest = tableau[0, pivot_col];
		//	for (j = 1; j < tableau.GetLength(1); j++)
		//	{
		//		if (tableau[0, j] < lowest)
		//		{
		//			lowest = tableau[0, j];
		//			pivot_col = j;
		//		}
		//	}
		//	//printf("Most negative column in row[0] is col %d = %g.\n", pivot_col, lowest);
		//	if (lowest >= 0)
		//	{
		//		return -1; // All positive columns in row[0], this is optimal.
		//	}
		//	return pivot_col;
		//}

		//// Find the pivot_row, with smallest positive ratio = col[0] / col[pivot]
		//static int find_pivot_row(ref generic[,] tableau, int pivot_col)
		//{
		//	int i, pivot_row = 0;
		//	generic min_ratio = -1;
		//	//printf("Ratios A[row_i,0]/A[row_i,%d] = [", pivot_col);
		//	for (i = 1; i < tableau.GetLength(0); i++)
		//	{
		//		generic ratio = tableau[i, 0] / tableau[i, pivot_col];
		//		//printf("%3.2lf, ", ratio);
		//		if ((ratio > 0 && ratio < min_ratio) || min_ratio < 0)
		//		{
		//			min_ratio = ratio;
		//			pivot_row = i;
		//		}
		//	}
		//	//printf("].\n");
		//	if (min_ratio == -1)
		//		return -1; // Unbounded.
		//	//printf("Found pivot A[%d,%d], min positive ratio=%g in row=%d.\n",
		//	//	pivot_row, pivot_col, min_ratio, pivot_row);
		//	return pivot_row;
		//}

		//static void add_slack_variables(ref generic[,] tableau)
		//{

		//	generic[,] newTableau =
		//		new generic[tableau.GetLength(0), tableau.GetLength(1) + tableau.GetLength(0) - 1];

		//	for (int a = 0, a_max = tableau.GetLength(0); a < a_max; a++)
		//		for (int b = 0, b_max = tableau.GetLength(1); b < b_max; b++)
		//			newTableau[a, b] = tableau[a, b];

		//	int i, j;
		//	for (i = 1; i < tableau.GetLength(0); i++)
		//	{
		//		for (j = 1; j < tableau.GetLength(0); j++)
		//			newTableau[i, j + tableau.GetLength(1) - 1] = (i == j ? 1d : 0d);
		//	}

		//	tableau = newTableau;
		//}

		//static void check_b_positive(ref generic[,] tableau)
		//{
		//	int i;
		//	for (i = 1; i < tableau.GetLength(0); i++)
		//		if (!(tableau[i, 0] >= 0))
		//			throw new Error("possible invalid tableau values (IDK)");
		//}

		//// Given a column of identity matrix, find the row containing 1.
		//// return -1, if the column as not from an identity matrix.
		//static int find_basis_variable(ref generic[,] tableau, int col)
		//{
		//	int i, xi = -1;
		//	for (i = 1; i < tableau.GetLength(0); i++)
		//	{
		//		if (Logic.Equate(tableau[i, col], 1, epsilon))
		//			if (xi == -1)
		//				xi = i;	 // found first '1', save this row number.
		//			else
		//				return -1; // found second '1', not an identity matrix.
		//		else if (!Logic.Equate(tableau[i, col], 0, epsilon))
		//			return -1; // not an identity matrix column.
		//	}
		//	return xi;
		//}

		//static generic[] print_optimal_vector(ref generic[,] tableau)
		//{
		//	generic[] vector = new generic[tableau.GetLength(1)];
		//	int j, xi;
		//	//printf("%s at ", message);
		//	for (j = 1; j < tableau.GetLength(1); j++)
		//	{ // for each column.
		//		xi = find_basis_variable(ref tableau, j);
		//		if (xi != -1)
		//			vector[j] = tableau[xi, 0];
		//		else
		//			vector[j] = j;
		//	}
		//	return vector;
		//}

		//public static generic[] Simplex(ref generic[,] tableau)
		//{
		//	int loop = 0;
		//	add_slack_variables(ref tableau);
		//	check_b_positive(ref tableau);
		//	while (++loop > 0)
		//	{
		//		int pivot_col, pivot_row;

		//		pivot_col = find_pivot_column(ref tableau);
		//		if (pivot_col < 0)
		//			//printf("Found optimal value=A[0,0]=%3.2lf (no negatives in row 0).\n",
		//			//	tableau->mat[0][0]);
		//			return print_optimal_vector(ref tableau);
		//		//printf("Entering variable x%d to be made basic, so pivot_col=%d.\n",
		//		//	pivot_col, pivot_col);

		//		pivot_row = find_pivot_row(ref tableau, pivot_col);
		//		if (pivot_row < 0)
		//			throw new Error("unbounded (no pivot_row)");
		//		//printf("Leaving variable x%d, so pivot_row=%d\n", pivot_row, pivot_row);

		//		pivot_on(ref tableau, pivot_row, pivot_col);
		//		//print_tableau(tableau, "After pivoting");
		//		//return print_optimal_vector(ref tableau);
		//	}
		//	throw new Error("Simplex has a glitch");
		//}

		#endregion

		#endregion

	}

	#region Vector

	/// <summary>Represents a vector with an arbitrary number of components of a generic type.</summary>
	/// <typeparam name="T">The numeric type of this Vector.</typeparam>
	public class Vector<T>
	{
		/// <summary>The array of this vector.</summary>
		public readonly T[] _vector;

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
		{ return LinearAlgebra<T>.Vector_Add(left, right); }
		/// <summary>Subtracts two vectors.</summary>
		/// <param name="left">The left operand of the subtraction.</param>
		/// <param name="right">The right operand of the subtraction.</param>
		/// <returns>The result of the subtraction.</returns>
		public static Vector<T> operator -(Vector<T> left, Vector<T> right)
		{ return LinearAlgebra<T>.Vector_Subtract(left, right); }
		/// <summary>Negates a vector.</summary>
		/// <param name="vector">The vector to negate.</param>
		/// <returns>The result of the negation.</returns>
		public static Vector<T> operator -(Vector<T> vector)
		{ return LinearAlgebra<T>.Vector_Negate(vector); }
		/// <summary>Multiplies all the values in a vector by a scalar.</summary>
		/// <param name="left">The vector to have all its values multiplied.</param>
		/// <param name="right">The scalar to multiply all the vector values by.</param>
		/// <returns>The result of the multiplication.</returns>
		public static Vector<T> operator *(Vector<T> left, T right)
		{ return LinearAlgebra<T>.Vector_Multiply(left, right); }
		/// <summary>Multiplies all the values in a vector by a scalar.</summary>
		/// <param name="left">The scalar to multiply all the vector values by.</param>
		/// <param name="right">The vector to have all its values multiplied.</param>
		/// <returns>The result of the multiplication.</returns>
		public static Vector<T> operator *(T left, Vector<T> right)
		{ return LinearAlgebra<T>.Vector_Multiply(right, left); }
		/// <summary>Divides all the values in the vector by a scalar.</summary>
		/// <param name="left">The vector to have its values divided.</param>
		/// <param name="right">The scalar to divide all the vectors values by.</param>
		/// <returns>The vector after the divisions.</returns>
		public static Vector<T> operator /(Vector<T> left, T right)
		{ return LinearAlgebra<T>.Vector_Divide(left, right); }
		/// <summary>Does an equality check by value. (warning for float errors)</summary>
		/// <param name="left">The first vector of the equality check.</param>
		/// <param name="right">The second vector of the equality check.</param>
		/// <returns>true if the values are equal, false if not.</returns>
		public static bool operator ==(Vector<T> left, Vector<T> right)
		{ return LinearAlgebra<T>.Vector_EqualsValue(left, right); }
		/// <summary>Does an anti-equality check by value. (warning for float errors)</summary>
		/// <param name="left">The first vector of the anit-equality check.</param>
		/// <param name="right">The second vector of the anti-equality check.</param>
		/// <returns>true if the values are not equal, false if they are.</returns>
		public static bool operator !=(Vector<T> left, Vector<T> right)
		{ return !LinearAlgebra<T>.Vector_EqualsValue(left, right); }
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
		{ return LinearAlgebra<T>.Vector_Add(this, right); }
		/// <summary>Negates this vector.</summary>
		/// <returns>The result of the negation.</returns>
		public Vector<T> Negate()
		{ return LinearAlgebra<T>.Vector_Negate(this); }
		/// <summary>Subtracts another vector from this one.</summary>
		/// <param name="right">The vector to subtract from this one.</param>
		/// <returns>The result of the subtraction.</returns>
		public Vector<T> Subtract(Vector<T> right)
		{ return LinearAlgebra<T>.Vector_Subtract(this, right); }
		/// <summary>Multiplies the values in this vector by a scalar.</summary>
		/// <param name="right">The scalar to multiply these values by.</param>
		/// <returns>The result of the multiplications</returns>
		public Vector<T> Multiply(T right)
		{ return LinearAlgebra<T>.Vector_Multiply(this, right); }
		/// <summary>Divides all the values in this vector by a scalar.</summary>
		/// <param name="right">The scalar to divide the values of the vector by.</param>
		/// <returns>The resulting vector after teh divisions.</returns>
		public Vector<T> Divide(T right)
		{ return LinearAlgebra<T>.Vector_Divide(this, right); }
		/// <summary>Computes the dot product between this vector and another.</summary>
		/// <param name="right">The second vector of the dot product operation.</param>
		/// <returns>The result of the dot product.</returns>
		public T DotProduct(Vector<T> right)
		{ return LinearAlgebra<T>.Vector_DotProduct(this, right); }
		/// <summary>Computes the cross product between this vector and another.</summary>
		/// <param name="right">The second vector of the dot product operation.</param>
		/// <returns>The result of the dot product operation.</returns>
		public Vector<T> CrossProduct(Vector<T> right)
		{ return LinearAlgebra<T>.Vector_CrossProduct(this, right); }
		/// <summary>Normalizes this vector.</summary>
		/// <returns>The result of the normalization.</returns>
		public Vector<T> Normalize()
		{ return LinearAlgebra<T>.Vector_Normalize(this); }
		/// <summary>Computes the length of this vector.</summary>
		/// <returns>The length of this vector.</returns>
		public T Magnitude()
		{ return LinearAlgebra<T>.Vector_Magnitude(this); }
		/// <summary>Computes the length of this vector, but doesn't square root it for 
		/// possible optimization purposes.</summary>
		/// <returns>The squared length of the vector.</returns>
		public T MagnitudeSquared()
		{ return LinearAlgebra<T>.Vector_MagnitudeSquared(this); }
		/// <summary>Check for equality by value.</summary>
		/// <param name="right">The other vector of the equality check.</param>
		/// <returns>true if the values were equal, false if not.</returns>
		public bool EqualsValue(Vector<T> right)
		{ return LinearAlgebra<T>.Vector_EqualsValue(this, right); }
		/// <summary>Checks for equality by value with some leniency.</summary>
		/// <param name="right">The other vector of the equality check.</param>
		/// <param name="leniency">The ammount the values can differ but still be considered equal.</param>
		/// <returns>true if the values were cinsidered equal, false if not.</returns>
		public bool EqualsValue(Vector<T> right, T leniency)
		{ return LinearAlgebra<T>.Vector_EqualsValue_leniency(this, right, leniency); }
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
		{ return LinearAlgebra<T>.Vector_RotateBy(this, angle, x, y, z); }
		/// <summary>Computes the linear interpolation between two vectors.</summary>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
		/// <returns>The result of the interpolation.</returns>
		public Vector<T> Lerp(Vector<T> right, T blend)
		{ return LinearAlgebra<T>.Vector_Lerp(this, right, blend); }
		/// <summary>Sphereically interpolates between two vectors.</summary>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
		/// <returns>The result of the slerp operation.</returns>
		public Vector<T> Slerp(Vector<T> right, T blend)
		{ return LinearAlgebra<T>.Vector_Slerp(this, right, blend); }
		/// <summary>Rotates a vector by a quaternion.</summary>
		/// <param name="rotation">The quaternion to rotate the 3-component vector by.</param>
		/// <returns>The result of the rotation.</returns>
		public Vector<T> RotateBy(Quaternion<T> rotation)
		{ return LinearAlgebra<T>.Vector_RotateBy_quaternion(this, rotation); }

		#endregion

		#region static

		/// <summary>Adds two vectors together.</summary>
		/// <param name="left">The first vector of the addition.</param>
		/// <param name="right">The second vector of the addiiton.</param>
		/// <returns>The result of the addiion.</returns>
		public static Vector<T> Add(T[] left, T[] right)
		{ return LinearAlgebra<T>.Vector_Add(left, right); }
		/// <summary>Adds two vectors together.</summary>
		/// <param name="left">The first vector of the addition.</param>
		/// <param name="right">The second vector of the addiiton.</param>
		/// <returns>The result of the addiion.</returns>
		public static Vector<T> Add(Vector<T> left, Vector<T> right)
		{ return LinearAlgebra<T>.Vector_Add(left._vector, right._vector); }
		/// <summary>Negates all the values in a vector.</summary>
		/// <param name="vector">The vector to have its values negated.</param>
		/// <returns>The result of the negations.</returns>
		public static T[] Negate(T[] vector)
		{ return LinearAlgebra<T>.Vector_Negate(vector); }
		/// <summary>Negates all the values in a vector.</summary>
		/// <param name="vector">The vector to have its values negated.</param>
		/// <returns>The result of the negations.</returns>
		public static Vector<T> Negate(Vector<T> vector)
		{ return LinearAlgebra<T>.Vector_Negate(vector); }
		/// <summary>Subtracts two vectors.</summary>
		/// <param name="left">The left vector of the subtraction.</param>
		/// <param name="right">The right vector of the subtraction.</param>
		/// <returns>The result of the vector subtracton.</returns>
		public static T[] Subtract(T[] left, T[] right)
		{ return LinearAlgebra<T>.Vector_Subtract(left, right); }
		/// <summary>Subtracts two vectors.</summary>
		/// <param name="left">The left vector of the subtraction.</param>
		/// <param name="right">The right vector of the subtraction.</param>
		/// <returns>The result of the vector subtracton.</returns>
		public static Vector<T> Subtract(Vector<T> left, Vector<T> right)
		{ return LinearAlgebra<T>.Vector_Subtract(left._vector, right._vector); }
		/// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
		/// <param name="left">The vector to have the components multiplied by.</param>
		/// <param name="right">The scalars to multiply the vector components by.</param>
		/// <returns>The result of the multiplications.</returns>
		public static T[] Multiply(T[] left, T right)
		{ return LinearAlgebra<T>.Vector_Multiply(left, right); }
		/// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
		/// <param name="left">The vector to have the components multiplied by.</param>
		/// <param name="right">The scalars to multiply the vector components by.</param>
		/// <returns>The result of the multiplications.</returns>
		public static Vector<T> Multiply(Vector<T> left, T right)
		{ return LinearAlgebra<T>.Vector_Multiply(left._vector, right); }
		/// <summary>Divides all the components of a vector by a scalar.</summary>
		/// <param name="left">The vector to have the components divided by.</param>
		/// <param name="right">The scalar to divide the vector components by.</param>
		/// <returns>The resulting vector after teh divisions.</returns>
		public static T[] Divide(T[] left, T right)
		{ return LinearAlgebra<T>.Vector_Divide(left, right); }
		/// <summary>Divides all the components of a vector by a scalar.</summary>
		/// <param name="left">The vector to have the components divided by.</param>
		/// <param name="right">The scalar to divide the vector components by.</param>
		/// <returns>The resulting vector after teh divisions.</returns>
		public static Vector<T> Divide(Vector<T> left, T right)
		{ return LinearAlgebra<T>.Vector_Divide(left, right); }
		/// <summary>Computes the dot product between two vectors.</summary>
		/// <param name="left">The first vector of the dot product operation.</param>
		/// <param name="right">The second vector of the dot product operation.</param>
		/// <returns>The result of the dot product operation.</returns>
		public static T DotProduct(T[] left, T[] right)
		{ return LinearAlgebra<T>.Vector_DotProduct(left, right); }
		/// <summary>Computes the dot product between two vectors.</summary>
		/// <param name="left">The first vector of the dot product operation.</param>
		/// <param name="right">The second vector of the dot product operation.</param>
		/// <returns>The result of the dot product operation.</returns>
		public static T DotProduct(Vector<T> left, Vector<T> right)
		{ return LinearAlgebra<T>.Vector_DotProduct(left._vector, right._vector); }
		/// <summary>Computes teh cross product of two vectors.</summary>
		/// <param name="left">The first vector of the cross product operation.</param>
		/// <param name="right">The second vector of the cross product operation.</param>
		/// <returns>The result of the cross product operation.</returns>
		public static T[] CrossProduct(T[] left, T[] right)
		{ return LinearAlgebra<T>.Vector_CrossProduct(left, right); }
		/// <summary>Computes teh cross product of two vectors.</summary>
		/// <param name="left">The first vector of the cross product operation.</param>
		/// <param name="right">The second vector of the cross product operation.</param>
		/// <returns>The result of the cross product operation.</returns>
		public static Vector<T> CrossProduct(Vector<T> left, Vector<T> right)
		{ return LinearAlgebra<T>.Vector_CrossProduct(left, right); }
		/// <summary>Normalizes a vector.</summary>
		/// <param name="vector">The vector to normalize.</param>
		/// <returns>The result of the normalization.</returns>
		public static T[] Normalize(T[] vector)
		{ return LinearAlgebra<T>.Vector_Normalize(vector); }
		/// <summary>Normalizes a vector.</summary>
		/// <param name="vector">The vector to normalize.</param>
		/// <returns>The result of the normalization.</returns>
		public static Vector<T> Normalize(Vector<T> vector)
		{ return LinearAlgebra<T>.Vector_Normalize(vector._vector); }
		/// <summary>Computes the length of a vector.</summary>
		/// <param name="vector">The vector to calculate the length of.</param>
		/// <returns>The computed length of the vector.</returns>
		public static T Magnitude(T[] vector)
		{ return LinearAlgebra<T>.Vector_Magnitude(vector); }
		/// <summary>Computes the length of a vector.</summary>
		/// <param name="vector">The vector to calculate the length of.</param>
		/// <returns>The computed length of the vector.</returns>
		public static T Magnitude(Vector<T> vector)
		{ return LinearAlgebra<T>.Vector_Magnitude(vector); }
		/// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
		/// <param name="vector">The vector to compute the length squared of.</param>
		/// <returns>The computed length squared of the vector.</returns>
		public static T MagnitudeSquared(T[] vector)
		{ return LinearAlgebra<T>.Vector_MagnitudeSquared(vector); }
		/// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
		/// <param name="vector">The vector to compute the length squared of.</param>
		/// <returns>The computed length squared of the vector.</returns>
		public static T MagnitudeSquared(Vector<T> vector)
		{ return LinearAlgebra<T>.Vector_MagnitudeSquared(vector._vector); }
		/// <summary>Computes the angle between two vectors.</summary>
		/// <param name="first">The first vector to determine the angle between.</param>
		/// <param name="second">The second vector to determine the angle between.</param>
		/// <returns>The angle between the two vectors in radians.</returns>
		public static T Angle(T[] first, T[] second)
		{ return LinearAlgebra<T>.Vector_Angle(first, second); }
		/// <summary>Computes the angle between two vectors.</summary>
		/// <param name="first">The first vector to determine the angle between.</param>
		/// <param name="second">The second vector to determine the angle between.</param>
		/// <returns>The angle between the two vectors in radians.</returns>
		public static T Angle(Vector<T> first, Vector<T> second)
		{ return LinearAlgebra<T>.Vector_Angle(first._vector, second._vector); }
		/// <summary>Rotates a vector by the specified axis and rotation values.</summary>
		/// <param name="vector">The vector to rotate.</param>
		/// <param name="angle">The angle of the rotation.</param>
		/// <param name="x">The x component of the axis vector to rotate about.</param>
		/// <param name="y">The y component of the axis vector to rotate about.</param>
		/// <param name="z">The z component of the axis vector to rotate about.</param>
		/// <returns>The result of the rotation.</returns>
		public static T[] RotateBy(T[] vector, T angle, T x, T y, T z)
		{ return LinearAlgebra<T>.Vector_RotateBy(vector, angle, x, y, z); }
		/// <summary>Rotates a vector by the specified axis and rotation values.</summary>
		/// <param name="vector">The vector to rotate.</param>
		/// <param name="angle">The angle of the rotation.</param>
		/// <param name="x">The x component of the axis vector to rotate about.</param>
		/// <param name="y">The y component of the axis vector to rotate about.</param>
		/// <param name="z">The z component of the axis vector to rotate about.</param>
		/// <returns>The result of the rotation.</returns>
		public static Vector<T> RotateBy(Vector<T> vector, T angle, T x, T y, T z)
		{ return LinearAlgebra<T>.Vector_RotateBy(vector._vector, angle, x, y, z); }
		/// <summary>Rotates a vector by a quaternion.</summary>
		/// <param name="vector">The vector to rotate.</param>
		/// <param name="rotation">The quaternion to rotate the 3-component vector by.</param>
		/// <returns>The result of the rotation.</returns>
		public static Vector<T> RotateBy(Vector<T> vector, Quaternion<T> rotation)
		{ return LinearAlgebra<T>.Vector_RotateBy_quaternion(vector._vector, rotation); }
		/// <summary>Computes the linear interpolation between two vectors.</summary>
		/// <param name="left">The starting vector of the interpolation.</param>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
		/// <returns>The result of the interpolation.</returns>
		public static T[] Lerp(T[] left, T[] right, T blend)
		{ return LinearAlgebra<T>.Vector_Lerp(left, right, blend); }
		/// <summary>Computes the linear interpolation between two vectors.</summary>
		/// <param name="left">The starting vector of the interpolation.</param>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
		/// <returns>The result of the interpolation.</returns>
		public static Vector<T> Lerp(Vector<T> left, Vector<T> right, T blend)
		{ return LinearAlgebra<T>.Vector_Lerp(left._vector, right._vector, blend); }
		/// <summary>Sphereically interpolates between two vectors.</summary>
		/// <param name="left">The starting vector of the interpolation.</param>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
		/// <returns>The result of the slerp operation.</returns>
		public static T[] Slerp(T[] left, T[] right, T blend)
		{ return LinearAlgebra<T>.Vector_Slerp(left, right, blend); }
		/// <summary>Sphereically interpolates between two vectors.</summary>
		/// <param name="left">The starting vector of the interpolation.</param>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
		/// <returns>The result of the slerp operation.</returns>
		public static Vector<T> Slerp(Vector<T> left, Vector<T> right, T blend)
		{ return LinearAlgebra<T>.Vector_Slerp(left._vector, right._vector, blend); }
		/// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
		/// <param name="a">The first vector of the interpolation.</param>
		/// <param name="b">The second vector of the interpolation.</param>
		/// <param name="c">The thrid vector of the interpolation.</param>
		/// <param name="u">The "U" value of the barycentric interpolation equation.</param>
		/// <param name="v">The "V" value of the barycentric interpolation equation.</param>
		/// <returns>The resulting vector of the barycentric interpolation.</returns>
		public static T[] Blerp(T[] a, T[] b, T[] c, T u, T v)
		{ return LinearAlgebra<T>.Vector_Blerp(a, b, c, u, v); }
		/// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
		/// <param name="a">The first vector of the interpolation.</param>
		/// <param name="b">The second vector of the interpolation.</param>
		/// <param name="c">The thrid vector of the interpolation.</param>
		/// <param name="u">The "U" value of the barycentric interpolation equation.</param>
		/// <param name="v">The "V" value of the barycentric interpolation equation.</param>
		/// <returns>The resulting vector of the barycentric interpolation.</returns>
		public static Vector<T> Blerp(Vector<T> a, Vector<T> b, Vector<T> c, T u, T v)
		{ return LinearAlgebra<T>.Vector_Blerp(a._vector, b._vector, c._vector, u, v); }
		/// <summary>Does a value equality check.</summary>
		/// <param name="left">The first vector to check for equality.</param>
		/// <param name="right">The second vector	to check for equality.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(T[] left, T[] right)
		{ return LinearAlgebra<T>.Vector_EqualsValue(left, right); }
		/// <summary>Does a value equality check.</summary>
		/// <param name="left">The first vector to check for equality.</param>
		/// <param name="right">The second vector	to check for equality.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(Vector<T> left, Vector<T> right)
		{ return LinearAlgebra<T>.Vector_EqualsValue(left._vector, right._vector); }
		/// <summary>Does a value equality check with leniency.</summary>
		/// <param name="left">The first vector to check for equality.</param>
		/// <param name="right">The second vector to check for equality.</param>
		/// <param name="leniency">How much the values can vary but still be considered equal.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(T[] left, T[] right, T leniency)
		{ return LinearAlgebra<T>.Vector_EqualsValue_leniency(left, right, leniency); }
		/// <summary>Does a value equality check with leniency.</summary>
		/// <param name="left">The first vector to check for equality.</param>
		/// <param name="right">The second vector to check for equality.</param>
		/// <param name="leniency">How much the values can vary but still be considered equal.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(Vector<T> left, Vector<T> right, T leniency)
		{ return LinearAlgebra<T>.Vector_EqualsValue_leniency(left._vector, right._vector, leniency); }
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

	#endregion

	#region Quaternion

	/// <summary>Standard 4-component quaternion [x, y, z, w]. W is the rotation ammount.</summary>
	/// <typeparam name="T">The numeric type of this Quaternion.</typeparam>
	public class Quaternion<T>
	{
		// the values of the quaternion
		protected T _x, _y, _z, _w;

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
		//public static readonly Quaternion<T> FactoryIdentity = new Quaternion<T>(_zero, _zero, _zero, _one);

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
		{ return LinearAlgebra<T>.Quaternion_Add(left, right); }
		/// <summary>Subtracts two quaternions.</summary>
		/// <param name="left">The left quaternion of the subtraction.</param>
		/// <param name="right">The right quaternion of the subtraction.</param>
		/// <returns>The resulting quaternion after the subtraction.</returns>
		public static Quaternion<T> operator -(Quaternion<T> left, Quaternion<T> right)
		{ return LinearAlgebra<T>.Quaternion_Subtract(left, right); }
		/// <summary>Multiplies two quaternions together.</summary>
		/// <param name="left">The first quaternion of the multiplication.</param>
		/// <param name="right">The second quaternion of the multiplication.</param>
		/// <returns>The resulting quaternion after the multiplication.</returns>
		public static Quaternion<T> operator *(Quaternion<T> left, Quaternion<T> right)
		{ return LinearAlgebra<T>.Quaternion_Multiply(left, right); }
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
		{ return LinearAlgebra<T>.Quaternion_Multiply_scalar(left, right); }
		/// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
		/// <param name="left">The scalar of the multiplication.</param>
		/// <param name="right">The quaternion of the multiplication.</param>
		/// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
		public static Quaternion<T> operator *(T left, Quaternion<T> right)
		{ return LinearAlgebra<T>.Quaternion_Multiply_scalar(right, left); }
		/// <summary>Checks for equality by value. (beware float errors)</summary>
		/// <param name="left">The first quaternion of the equality check.</param>
		/// <param name="right">The second quaternion of the equality check.</param>
		/// <returns>true if the values were deemed equal, false if not.</returns>
		public static bool operator ==(Quaternion<T> left, Quaternion<T> right)
		{ return LinearAlgebra<T>.Quaternion_EqualsValue(left, right); }
		/// <summary>Checks for anti-equality by value. (beware float errors)</summary>
		/// <param name="left">The first quaternion of the anti-equality check.</param>
		/// <param name="right">The second quaternion of the anti-equality check.</param>
		/// <returns>false if the values were deemed equal, true if not.</returns>
		public static bool operator !=(Quaternion<T> left, Quaternion<T> right)
		{ return !LinearAlgebra<T>.Quaternion_EqualsValue(left, right); }

		#endregion

		#region instance

		/// <summary>Computes the length of quaternion.</summary>
		/// <returns>The length of the given quaternion.</returns>
		public T Magnitude()
		{ return LinearAlgebra<T>.Quaternion_Magnitude(this); }
		/// <summary>Computes the length of a quaternion, but doesn't square root it
		/// for optimization possibilities.</summary>
		/// <returns>The squared length of the given quaternion.</returns>
		public T MagnitudeSquared()
		{ return LinearAlgebra<T>.Quaternion_MagnitudeSquared(this); }
		/// <summary>Gets the conjugate of the quaternion.</summary>
		/// <returns>The conjugate of teh given quaternion.</returns>
		public Quaternion<T> Conjugate()
		{ return LinearAlgebra<T>.Quaternion_Conjugate(this); }
		/// <summary>Adds two quaternions together.</summary>
		/// <param name="right">The second quaternion of the addition.</param>
		/// <returns>The result of the addition.</returns>
		public Quaternion<T> Add(Quaternion<T> right)
		{ return LinearAlgebra<T>.Quaternion_Add(this, right); }
		/// <summary>Subtracts two quaternions.</summary>
		/// <param name="right">The right quaternion of the subtraction.</param>
		/// <returns>The resulting quaternion after the subtraction.</returns>
		public Quaternion<T> Subtract(Quaternion<T> right)
		{ return LinearAlgebra<T>.Quaternion_Subtract(this, right); }
		/// <summary>Multiplies two quaternions together.</summary>
		/// <param name="right">The second quaternion of the multiplication.</param>
		/// <returns>The resulting quaternion after the multiplication.</returns>
		public Quaternion<T> Multiply(Quaternion<T> right)
		{ return LinearAlgebra<T>.Quaternion_Multiply(this, right); }
		/// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
		/// <param name="right">The scalar of the multiplication.</param>
		/// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
		public Quaternion<T> Multiply(T right)
		{ return LinearAlgebra<T>.Quaternion_Multiply_scalar(this, right); }
		/// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
		/// <param name="right">The vector to be multiplied.</param>
		/// <returns>The resulting quaternion of the multiplication.</returns>
		//public Quaternion<T> Multiply(Vector vector) { return Quaternion<T>.Multiply(this, vector); }
		/// <summary>Normalizes the quaternion.</summary>
		/// <returns>The normalization of the given quaternion.</returns>
		public Quaternion<T> Normalize()
		{ return LinearAlgebra<T>.Quaternion_Normalize(this); }
		/// <summary>Inverts a quaternion.</summary>
		/// <returns>The inverse of the given quaternion.</returns>
		public Quaternion<T> Invert()
		{ return LinearAlgebra<T>.Quaternion_Invert(this); }
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
		/// <param name="right">The second quaternion	to check for equality.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public bool EqualsValue(Quaternion<T> right)
		{ return LinearAlgebra<T>.Quaternion_EqualsValue(this, right); }
		/// <summary>Does a value equality check with leniency.</summary>
		/// <param name="right">The second quaternion to check for equality.</param>
		/// <param name="leniency">How much the values can vary but still be considered equal.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public bool EqualsValue(Quaternion<T> right, T leniency)
		{ return LinearAlgebra<T>.Quaternion_EqualsValue_leniency(this, right, leniency); }
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
		{ return LinearAlgebra<T>.Quaternion_Magnitude(quaternion); }
		/// <summary>Computes the length of a quaternion, but doesn't square root it
		/// for optimization possibilities.</summary>
		/// <param name="quaternion">The quaternion to compute the length squared of.</param>
		/// <returns>The squared length of the given quaternion.</returns>
		public static T MagnitudeSquared(Quaternion<T> quaternion)
		{ return LinearAlgebra<T>.Quaternion_MagnitudeSquared(quaternion); }
		/// <summary>Gets the conjugate of the quaternion.</summary>
		/// <param name="quaternion">The quaternion to conjugate.</param>
		/// <returns>The conjugate of teh given quaternion.</returns>
		public static Quaternion<T> Conjugate(Quaternion<T> quaternion)
		{ return LinearAlgebra<T>.Quaternion_Conjugate(quaternion); }
		/// <summary>Adds two quaternions together.</summary>
		/// <param name="left">The first quaternion of the addition.</param>
		/// <param name="right">The second quaternion of the addition.</param>
		/// <returns>The result of the addition.</returns>
		public static Quaternion<T> Add(Quaternion<T> left, Quaternion<T> right)
		{ return LinearAlgebra<T>.Quaternion_Add(left, right); }
		/// <summary>Subtracts two quaternions.</summary>
		/// <param name="left">The left quaternion of the subtraction.</param>
		/// <param name="right">The right quaternion of the subtraction.</param>
		/// <returns>The resulting quaternion after the subtraction.</returns>
		public static Quaternion<T> Subtract(Quaternion<T> left, Quaternion<T> right)
		{ return LinearAlgebra<T>.Quaternion_Subtract(left, right); }
		/// <summary>Multiplies two quaternions together.</summary>
		/// <param name="left">The first quaternion of the multiplication.</param>
		/// <param name="right">The second quaternion of the multiplication.</param>
		/// <returns>The resulting quaternion after the multiplication.</returns>
		public static Quaternion<T> Multiply(Quaternion<T> left, Quaternion<T> right)
		{ return LinearAlgebra<T>.Quaternion_Multiply(left, right); }
		/// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
		/// <param name="left">The quaternion of the multiplication.</param>
		/// <param name="right">The scalar of the multiplication.</param>
		/// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
		public static Quaternion<T> Multiply(Quaternion<T> left, T right)
		{ return LinearAlgebra<T>.Quaternion_Multiply_scalar(left, right); }
		/// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
		/// <param name="left">The quaternion to pre-multiply the vector by.</param>
		/// <param name="right">The vector to be multiplied.</param>
		/// <returns>The resulting quaternion of the multiplication.</returns>
		public static Quaternion<T> Multiply(Quaternion<T> left, Vector<T> right)
		{ return LinearAlgebra<T>.Quaternion_Multiply_Vector(left, right); }
		/// <summary>Normalizes the quaternion.</summary>
		/// <param name="quaternion">The quaternion to normalize.</param>
		/// <returns>The normalization of the given quaternion.</returns>
		public static Quaternion<T> Normalize(Quaternion<T> quaternion)
		{ return LinearAlgebra<T>.Quaternion_Normalize(quaternion); }
		/// <summary>Inverts a quaternion.</summary>
		/// <param name="quaternion">The quaternion to find the inverse of.</param>
		/// <returns>The inverse of the given quaternion.</returns>
		public static Quaternion<T> Invert(Quaternion<T> quaternion)
		{ return LinearAlgebra<T>.Quaternion_Invert(quaternion); }
		/// <summary>Lenearly interpolates between two quaternions.</summary>
		/// <param name="left">The starting point of the interpolation.</param>
		/// <param name="right">The ending point of the interpolation.</param>
		/// <param name="blend">The ratio 0.0-1.0 of how far to interpolate between the left and right quaternions.</param>
		/// <returns>The result of the interpolation.</returns>
		public static Quaternion<T> Lerp(Quaternion<T> left, Quaternion<T> right, T blend)
		{ return LinearAlgebra<T>.Quaternion_Lerp(left, right, blend); }
		/// <summary>Sphereically interpolates between two quaternions.</summary>
		/// <param name="left">The starting point of the interpolation.</param>
		/// <param name="right">The ending point of the interpolation.</param>
		/// <param name="blend">The ratio of how far to interpolate between the left and right quaternions.</param>
		/// <returns>The result of the interpolation.</returns>
		public static Quaternion<T> Slerp(Quaternion<T> left, Quaternion<T> right, T blend)
		{ return LinearAlgebra<T>.Quaternion_Slerp(left, right, blend); }
		/// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
		/// <param name="rotation">The quaternion to rotate the vector by.</param>
		/// <param name="vector">The vector to be rotated by.</param>
		/// <returns>The result of the rotation.</returns>
		public static Vector<T> Rotate(Quaternion<T> rotation, Vector<T> vector)
		{ return LinearAlgebra<T>.Quaternion_Rotate(rotation, vector); }
		/// <summary>Does a value equality check.</summary>
		/// <param name="left">The first quaternion to check for equality.</param>
		/// <param name="right">The second quaternion	to check for equality.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(Quaternion<T> left, Quaternion<T> right)
		{ return LinearAlgebra<T>.Quaternion_EqualsValue(left, right); }
		/// <summary>Does a value equality check with leniency.</summary>
		/// <param name="left">The first quaternion to check for equality.</param>
		/// <param name="right">The second quaternion to check for equality.</param>
		/// <param name="leniency">How much the values can vary but still be considered equal.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(Quaternion<T> left, Quaternion<T> right, T leniency)
		{ return LinearAlgebra<T>.Quaternion_EqualsValue_leniency(left, right, leniency); }
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

	#endregion

	#region Matrix

	/// <summary>A matrix of arbitrary dimensions implemented as a flattened array.</summary>
	/// <typeparam name="T">The numeric type of this Matrix.</typeparam>
	public class Matrix<T>
	{
		/// <summary>The flattened array of this matrix.</summary>
		public readonly T[] _matrix;
		private int _rows;
		private int _columns;

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
				#region error checking

#if no_error_checking
				// nothing
#else
				if (row < 0 || row > this._rows)
					throw new Error("index out of bounds: row");
				if (column < 0 || column > this._columns)
					throw new Error("index out of bounds: column");
#endif

				#endregion

				return (this._matrix as T[])[row * this._columns + column];
			}
			set
			{
				#region error checking

#if no_error_checking
				// nothing
#else
				if (row < 0 || row > this._rows)
					throw new Error("index out of bounds: row");
				if (column < 0 || column > this._columns)
					throw new Error("index out of bounds: column");
#endif

				#endregion

				(this._matrix as T[])[row * this._columns + column] = value;
			}
		}

		#endregion

		#region constructors

		//		/// <summary>Constructs a new zero-matrix of the given dimensions.</summary>
		//		/// <param name="rows">The number of row dimensions.</param>
		//		/// <param name="columns">The number of column dimensions.</param>
		//		/// <param name="defaultValue">The default value for non-initialized entries in the matrix.</param>
		//		/// <param name="format">The format in which to store the data in memory.</param>
		//		public Matrix(int rows, int columns, Format format, T defaultValue)
		//		{
		//			#region error checking

		//#if no_error_checking
		//			// nothing
		//#else
		//			if (rows < 1)
		//				throw new Error("Invalid rows on matrix contruction");
		//			if (columns < 1)
		//				throw new Error("Invalid columns on matrix contruction");
		//#endif

		//			#endregion

		//			if (format == Matrix<T>.Format.FlattenedArray)
		//			{
		//				this._matrix = new T[rows * columns];
		//				this._rows = rows;
		//				this._columns = columns;
		//			}
		//			else if (format == Matrix<T>.Format.Map)
		//			{
		//				this._matrix = new Map_Linked<T, int>(Logic.Equate, Hash.Compute);
		//				this._rows = rows;
		//				this._columns = columns;
		//			}
		//			else if (format == Matrix<T>.Format.Quadtree)
		//			{
		//				this._matrix =
		//					new Quadtree_Linked<Link<int, int, T>, int>(
		//						0, 0, rows, columns,
		//						(Link<int, int, T> entry, out int x, out int y) =>
		//						{ x = entry.One; y = entry.Two; },
		//						Logic.Compare, Statistics.Mean);
		//				this._rows = rows;
		//				this._columns = columns;
		//			}
		//			else
		//				throw new Error("SevenFramework error - unsupported matrix format");
		//		}

		/// <summary>Constructs a new zero-matrix of the given dimensions (using FlattenedArray format).</summary>
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

		/// <summary>Constructs a matrix from a T[,] (using FlattenedArray format).</summary>
		/// <param name="matrix">The float[,] to wrap in a matrix class.</param>
		public Matrix(T[,] matrix)
		{
			this._rows = matrix.GetLength(0);
			this._columns = matrix.GetLength(1);
			this._matrix = new T[this._rows * this._columns];
			T[] this_matrix_flat = this._matrix as T[]; ;
			for (int i = 0; i < this_matrix_flat.Length; i++)
				this_matrix_flat[i] = matrix[i / this._rows, i % this._columns];
		}

		private Matrix(Matrix<T> matrix)
		{
			this._rows = matrix._rows;
			this._columns = matrix.Columns;
			this._matrix = (matrix._matrix as T[]).Clone() as T[];
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
			return LinearAlgebra<T>.Matrix_FactoryZero(rows, columns);
		}

		/// <summary>Constructs a new identity-matrix of the given dimensions.</summary>
		/// <param name="rows">The number of rows of the matrix.</param>
		/// <param name="columns">The number of columns of the matrix.</param>
		/// <returns>The newly constructed identity-matrix.</returns>
		public static Matrix<T> FactoryIdentity(int rows, int columns)
		{
			return LinearAlgebra<T>.Matrix_FactoryIdentity(rows, columns);
		}

		/// <summary>Constructs a new matrix where every entry is 1.</summary>
		/// <param name="rows">The number of rows of the matrix.</param>
		/// <param name="columns">The number of columns of the matrix.</param>
		/// <returns>The newly constructed matrix filled with 1's.</returns>
		public static Matrix<T> FactoryOne(int rows, int columns)
		{
			return LinearAlgebra<T>.Matrix_FactoryOne(rows, columns);
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
		//	T cos = _cos(angle);
		//	T sin = _sin(angle);
		//	return new Matrix<T>(new T[,] {
		//		{ _one, _zero, _zero },
		//		{ _zero, cos, sin },
		//		{ _zero, _negate(sin), cos }});
		//}

		///// <param name="angle">Angle of rotation in radians.</param>
		//public static Matrix<T> Factory3x3RotationY(T angle)
		//{
		//	T cos = _cos(angle);
		//	T sin = _sin(angle);
		//	return new Matrix<T>(new T[,] {
		//		{ cos, _zero, _negate(sin) },
		//		{ _zero, _one, _zero },
		//		{ sin, _zero, cos }});
		//}

		///// <param name="angle">Angle of rotation in radians.</param>
		//public static Matrix<T> Factory3x3RotationZ(T angle)
		//{
		//	T cos = _cos(angle);
		//	T sin = _sin(angle);
		//	return new Matrix<T>(new T[,] {
		//		{ cos, _negate(sin), _zero },
		//		{ sin, cos, _zero },
		//		{ _zero, _zero, _zero }});
		//}

		///// <param name="angleX">Angle about the X-axis in radians.</param>
		///// <param name="angleY">Angle about the Y-axis in radians.</param>
		///// <param name="angleZ">Angle about the Z-axis in radians.</param>
		//public static Matrix<T> Factory3x3RotationXthenYthenZ(T angleX, T angleY, T angleZ)
		//{
		//	T xCos = _cos(angleX), xSin = _sin(angleX),
		//		yCos = _cos(angleY), ySin = _sin(angleY),
		//		zCos = _cos(angleZ), zSin = _sin(angleZ);
		//	return new Matrix<T>(new T[,] {
		//		{ _multiply(yCos, zCos), _negate(_multiply(yCos, zSin)), ySin },
		//		{ _add(_multiply(xCos, zSin), _multiply(_multiply(xSin, ySin), zCos)), _add(_multiply(xCos, zCos), _multiply(_multiply(xSin, ySin), zSin)), _negate(_multiply(xSin, yCos)) },
		//		{ _subtract(_multiply(xSin, zSin), _multiply(_multiply(xCos, ySin), zCos)), _add(_multiply(xSin, zCos), _multiply(_multiply(xCos, ySin), zSin)), _multiply(xCos, yCos) }});
		//}

		///// <param name="angleX">Angle about the X-axis in radians.</param>
		///// <param name="angleY">Angle about the Y-axis in radians.</param>
		///// <param name="angleZ">Angle about the Z-axis in radians.</param>
		//public static Matrix<T> Factory3x3RotationZthenYthenX(T angleX, T angleY, T angleZ)
		//{
		//	T xCos = _cos(angleX), xSin = _sin(angleX),
		//		yCos = _cos(angleY), ySin = _sin(angleY),
		//		zCos = _cos(angleZ), zSin = _sin(angleZ);
		//	return new Matrix<T>(new T[,] {
		//		{ _multiply(yCos, zCos), _subtract(_multiply(_multiply(zCos, xSin), ySin), _multiply(xCos, zSin)), _add(_multiply(_multiply(xCos, zCos), ySin), _multiply(xSin, zSin)) },
		//		{ _multiply(yCos, zSin), _add(_multiply(xCos, zCos), _multiply(_multiply(xSin, ySin), zSin)), _add(_multiply(_negate(zCos), xSin), _multiply(_multiply(xCos, ySin), zSin)) },
		//		{ _negate(ySin), _multiply(yCos, xSin), _multiply(xCos, yCos) }});
		//}

		///// <summary>Creates a 3x3 matrix initialized with a shearing transformation.</summary>
		///// <param name="shearXbyY">The shear along the X-axis in the Y-direction.</param>
		///// <param name="shearXbyZ">The shear along the X-axis in the Z-direction.</param>
		///// <param name="shearYbyX">The shear along the Y-axis in the X-direction.</param>
		///// <param name="shearYbyZ">The shear along the Y-axis in the Z-direction.</param>
		///// <param name="shearZbyX">The shear along the Z-axis in the X-direction.</param>
		///// <param name="shearZbyY">The shear along the Z-axis in the Y-direction.</param>
		///// <returns>The constructed shearing matrix.</returns>
		//public static Matrix<T> Factory3x3Shear(
		//	T shearXbyY, T shearXbyZ, T shearYbyX,
		//	T shearYbyZ, T shearZbyX, T shearZbyY)
		//{
		//	return new Matrix<T>(new T[,] {
		//		{ _one, shearYbyX, shearZbyX },
		//		{ shearXbyY, _one, shearYbyZ },
		//		{ shearXbyZ, shearYbyZ, _one }});
		//}

		#endregion

		#region operators

		/// <summary>Negates all the values in a matrix.</summary>
		/// <param name="matrix">The matrix to have its values negated.</param>
		/// <returns>The resulting matrix after the negations.</returns>
		public static Matrix<T> operator -(Matrix<T> matrix)
		{ return LinearAlgebra<T>.Matrix_Negate(matrix); }
		/// <summary>Does a standard matrix addition.</summary>
		/// <param name="left">The left matrix of the addition.</param>
		/// <param name="right">The right matrix of the addition.</param>
		/// <returns>The resulting matrix after teh addition.</returns>
		public static Matrix<T> operator +(Matrix<T> left, Matrix<T> right)
		{ return LinearAlgebra<T>.Matrix_Add(left, right); }
		/// <summary>Does a standard matrix subtraction.</summary>
		/// <param name="left">The left matrix of the subtraction.</param>
		/// <param name="right">The right matrix of the subtraction.</param>
		/// <returns>The result of the matrix subtraction.</returns>
		public static Matrix<T> operator -(Matrix<T> left, Matrix<T> right)
		{ return LinearAlgebra<T>.Matrix_Subtract(left, right); }
		/// <summary>Multiplies a vector by a matrix.</summary>
		/// <param name="left">The matrix of the multiplication.</param>
		/// <param name="right">The vector of the multiplication.</param>
		/// <returns>The resulting vector after the multiplication.</returns>
		public static Vector<T> operator *(Matrix<T> left, Vector<T> right)
		{ return LinearAlgebra<T>.Matrix_Multiply_vector(left, right); }
		/// <summary>Does a standard matrix multiplication.</summary>
		/// <param name="left">The left matrix of the multiplication.</param>
		/// <param name="right">The right matrix of the multiplication.</param>
		/// <returns>The resulting matrix after the multiplication.</returns>
		public static Matrix<T> operator *(Matrix<T> left, Matrix<T> right)
		{ return LinearAlgebra<T>.Matrix_Multiply(left, right); }
		/// <summary>Multiplies all the values in a matrix by a scalar.</summary>
		/// <param name="left">The matrix to have its values multiplied.</param>
		/// <param name="right">The scalar to multiply the values by.</param>
		/// <returns>The resulting matrix after the multiplications.</returns>
		public static Matrix<T> operator *(Matrix<T> left, T right)
		{ return LinearAlgebra<T>.Matrix_Multiply_scalar(left, right); }
		/// <summary>Multiplies all the values in a matrix by a scalar.</summary>
		/// <param name="left">The scalar to multiply the values by.</param>
		/// <param name="right">The matrix to have its values multiplied.</param>
		/// <returns>The resulting matrix after the multiplications.</returns>
		public static Matrix<T> operator *(T left, Matrix<T> right)
		{ return LinearAlgebra<T>.Matrix_Multiply_scalar(right, left); }
		/// <summary>Divides all the values in a matrix by a scalar.</summary>
		/// <param name="left">The matrix to have its values divided.</param>
		/// <param name="right">The scalar to divide the values by.</param>
		/// <returns>The resulting matrix after the divisions.</returns>
		public static Matrix<T> operator /(Matrix<T> left, T right)
		{ return LinearAlgebra<T>.Matrix_Divide(left, right); }
		/// <summary>Applies a power to a matrix.</summary>
		/// <param name="left">The matrix to apply a power to.</param>
		/// <param name="right">The power to apply to the matrix.</param>
		/// <returns>The result of the power operation.</returns>
		public static Matrix<T> operator ^(Matrix<T> left, int right)
		{ return LinearAlgebra<T>.Matrix_Power(left, right); }
		/// <summary>Checks for equality by value.</summary>
		/// <param name="left">The left matrix of the equality check.</param>
		/// <param name="right">The right matrix of the equality check.</param>
		/// <returns>True if the values of the matrices are equal, false if not.</returns>
		public static bool operator ==(Matrix<T> left, Matrix<T> right)
		{ return LinearAlgebra<T>.Matrix_EqualsByValue(left, right); }
		/// <summary>Checks for false-equality by value.</summary>
		/// <param name="left">The left matrix of the false-equality check.</param>
		/// <param name="right">The right matrix of the false-equality check.</param>
		/// <returns>True if the values of the matrices are not equal, false if they are.</returns>
		public static bool operator !=(Matrix<T> left, Matrix<T> right)
		{ return !LinearAlgebra<T>.Matrix_EqualsByValue(left, right); }
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
		//	T[,] array = new T[matrix.Rows, matrix.Columns];
		//	for (int i = 0; i < i )
		//	return matrix; }
		#endregion

		#region instance

		/// <summary>Negates all the values in this matrix.</summary>
		/// <returns>The resulting matrix after the negations.</returns>
		public Matrix<T> Negate()
		{ return LinearAlgebra<T>.Matrix_Negate(this); }
		/// <summary>Does a standard matrix addition.</summary>
		/// <param name="right">The matrix to add to this matrix.</param>
		/// <returns>The resulting matrix after the addition.</returns>
		public Matrix<T> Add(Matrix<T> right)
		{ return LinearAlgebra<T>.Matrix_Add(this, right); }
		/// <summary>Does a standard matrix multiplication (triple for loop).</summary>
		/// <param name="right">The matrix to multiply this matrix by.</param>
		/// <returns>The resulting matrix after the multiplication.</returns>
		public Matrix<T> Multiply(Matrix<T> right)
		{ return LinearAlgebra<T>.Matrix_Multiply(this, right); }
		/// <summary>Multiplies all the values in this matrix by a scalar.</summary>
		/// <param name="right">The scalar to multiply all the matrix values by.</param>
		/// <returns>The retulting matrix after the multiplications.</returns>
		public Matrix<T> Multiply(T right)
		{ return LinearAlgebra<T>.Matrix_Multiply_scalar(this, right); }
		/// <summary>Divides all the values in this matrix by a scalar.</summary>
		/// <param name="right">The scalar to divide the matrix values by.</param>
		/// <returns>The resulting matrix after teh divisions.</returns>
		public Matrix<T> Divide(T right)
		{ return LinearAlgebra<T>.Matrix_Divide(this, right); }
		/// <summary>Gets the minor of a matrix.</summary>
		/// <param name="row">The restricted row of the minor.</param>
		/// <param name="column">The restricted column of the minor.</param>
		/// <returns>The minor from the row/column restrictions.</returns>
		public Matrix<T> Minor(int row, int column)
		{ return LinearAlgebra<T>.Matrix_Minor(this, row, column); }
		/// <summary>Combines two matrices from left to right 
		/// (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
		/// <param name="right">The matrix to combine with on the right side.</param>
		/// <returns>The resulting row-wise concatination.</returns>
		public Matrix<T> ConcatenateRowWise(Matrix<T> right)
		{ return LinearAlgebra<T>.Matrix_ConcatenateRowWise(this, right); }
		/// <summary>Computes the determinent if this matrix is square.</summary>
		/// <returns>The computed determinent if this matrix is square.</returns>
		public T Determinent()
		{ return LinearAlgebra<T>.Matrix_Determinent(this); }
		/// <summary>Computes the echelon form of this matrix (aka REF).</summary>
		/// <returns>The computed echelon form of this matrix (aka REF).</returns>
		public Matrix<T> Echelon()
		{ return LinearAlgebra<T>.Matrix_Echelon(this); }
		/// <summary>Computes the reduced echelon form of this matrix (aka RREF).</summary>
		/// <returns>The computed reduced echelon form of this matrix (aka RREF).</returns>
		public Matrix<T> ReducedEchelon()
		{ return LinearAlgebra<T>.Matrix_ReducedEchelon(this); }
		/// <summary>Computes the inverse of this matrix.</summary>
		/// <returns>The inverse of this matrix.</returns>
		public Matrix<T> Inverse()
		{ return LinearAlgebra<T>.Matrix_Inverse(this); }
		/// <summary>Gets the adjoint of this matrix.</summary>
		/// <returns>The adjoint of this matrix.</returns>
		public Matrix<T> Adjoint()
		{ return LinearAlgebra<T>.Matrix_Adjoint(this); }
		/// <summary>Transposes this matrix.</summary>
		/// <returns>The transpose of this matrix.</returns>
		public Matrix<T> Transpose()
		{ return LinearAlgebra<T>.Matrix_Transpose(this); }
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
		{ return LinearAlgebra<T>.Matrix_Negate(matrix); }
		/// <summary>Does standard addition of two matrices.</summary>
		/// <param name="left">The left matrix of the addition.</param>
		/// <param name="right">The right matrix of the addition.</param>
		/// <returns>The resulting matrix after the addition.</returns>
		public static Matrix<T> Add(Matrix<T> left, Matrix<T> right)
		{ return LinearAlgebra<T>.Matrix_Add(left, right); }
		/// <summary>Subtracts a scalar from all the values in a matrix.</summary>
		/// <param name="left">The matrix to have the values subtracted from.</param>
		/// <param name="right">The scalar to subtract from all the matrix values.</param>
		/// <returns>The resulting matrix after the subtractions.</returns>
		public static Matrix<T> Subtract(Matrix<T> left, Matrix<T> right)
		{ return LinearAlgebra<T>.Matrix_Subtract(left, right); }
		/// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
		/// <param name="left">The left matrix of the multiplication.</param>
		/// <param name="right">The right matrix of the multiplication.</param>
		/// <returns>The resulting matrix of the multiplication.</returns>
		public static Matrix<T> Multiply(Matrix<T> left, Matrix<T> right)
		{ return LinearAlgebra<T>.Matrix_Multiply(left, right); }
		/// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
		/// <param name="left">The left matrix of the multiplication.</param>
		/// <param name="right">The right matrix of the multiplication.</param>
		/// <returns>The resulting matrix of the multiplication.</returns>
		public static Vector<T> Multiply(Matrix<T> left, Vector<T> right)
		{ return LinearAlgebra<T>.Matrix_Multiply_vector(left, right._vector); }
		/// <summary>Multiplies all the values in a matrix by a scalar.</summary>
		/// <param name="left">The matrix to have the values multiplied.</param>
		/// <param name="right">The scalar to multiply the values by.</param>
		/// <returns>The resulting matrix after the multiplications.</returns>
		public static Matrix<T> Multiply(Matrix<T> left, T right)
		{ return LinearAlgebra<T>.Matrix_Multiply_scalar(left, right); }
		/// <summary>Applies a power to a square matrix.</summary>
		/// <param name="matrix">The matrix to be powered by.</param>
		/// <param name="power">The power to apply to the matrix.</param>
		/// <returns>The resulting matrix of the power operation.</returns>
		public static Matrix<T> Power(Matrix<T> matrix, int power)
		{ return LinearAlgebra<T>.Matrix_Power(matrix, power); }
		/// <summary>Divides all the values in the matrix by a scalar.</summary>
		/// <param name="matrix">The matrix to divide the values of.</param>
		/// <param name="right">The scalar to divide all the matrix values by.</param>
		/// <returns>The resulting matrix with the divided values.</returns>
		public static Matrix<T> Divide(Matrix<T> matrix, T right)
		{ return LinearAlgebra<T>.Matrix_Divide(matrix, right); }
		/// <summary>Gets the minor of a matrix.</summary>
		/// <param name="matrix">The matrix to get the minor of.</param>
		/// <param name="row">The restricted row to form the minor.</param>
		/// <param name="column">The restricted column to form the minor.</param>
		/// <returns>The minor of the matrix.</returns>
		public static Matrix<T> Minor(Matrix<T> matrix, int row, int column)
		{ return LinearAlgebra<T>.Matrix_Minor(matrix, row, column); }
		/// <summary>Combines two matrices from left to right 
		/// (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
		/// <param name="left">The left matrix of the concatenation.</param>
		/// <param name="right">The right matrix of the concatenation.</param>
		/// <returns>The resulting matrix of the concatenation.</returns>
		public static Matrix<T> ConcatenateRowWise(Matrix<T> left, Matrix<T> right)
		{ return LinearAlgebra<T>.Matrix_ConcatenateRowWise(left, right); }
		/// <summary>Calculates the determinent of a square matrix.</summary>
		/// <param name="matrix">The matrix to calculate the determinent of.</param>
		/// <returns>The determinent of the matrix.</returns>
		public static T Determinent(Matrix<T> matrix)
		{ return LinearAlgebra<T>.Matrix_Determinent(matrix); }
		/// <summary>Calculates the echelon of a matrix (aka REF).</summary>
		/// <param name="matrix">The matrix to calculate the echelon of (aka REF).</param>
		/// <returns>The echelon of the matrix (aka REF).</returns>
		public static Matrix<T> Echelon(Matrix<T> matrix)
		{ return LinearAlgebra<T>.Matrix_Echelon(matrix); }
		/// <summary>Calculates the echelon of a matrix and reduces it (aka RREF).</summary>
		/// <param name="matrix">The matrix matrix to calculate the reduced echelon of (aka RREF).</param>
		/// <returns>The reduced echelon of the matrix (aka RREF).</returns>
		public static Matrix<T> ReducedEchelon(Matrix<T> matrix)
		{ return LinearAlgebra<T>.Matrix_ReducedEchelon(matrix); }
		/// <summary>Calculates the inverse of a matrix.</summary>
		/// <param name="matrix">The matrix to calculate the inverse of.</param>
		/// <returns>The inverse of the matrix.</returns>
		public static Matrix<T> Inverse(Matrix<T> matrix)
		{ return LinearAlgebra<T>.Matrix_Inverse(matrix); }
		/// <summary>Calculates the adjoint of a matrix.</summary>
		/// <param name="matrix">The matrix to calculate the adjoint of.</param>
		/// <returns>The adjoint of the matrix.</returns>
		public static Matrix<T> Adjoint(Matrix<T> matrix)
		{ return LinearAlgebra<T>.Matrix_Adjoint(matrix); }
		/// <summary>Returns the transpose of a matrix.</summary>
		/// <param name="matrix">The matrix to transpose.</param>
		/// <returns>The transpose of the matrix.</returns>
		public static Matrix<T> Transpose(Matrix<T> matrix)
		{ return LinearAlgebra<T>.Matrix_Transpose(matrix); }
		/// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
		/// <param name="matrix">The matrix to decompose.</param>
		/// <param name="lower">The computed lower triangular matrix.</param>
		/// <param name="upper">The computed upper triangular matrix.</param>
		/// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
		/// <param name="matrix">The matrix to decompose.</param>
		/// <param name="lower">The computed lower triangular matrix.</param>
		/// <param name="upper">The computed upper triangular matrix.</param>
		public static void DecomposeLU(Matrix<T> matrix, out Matrix<T> lower, out Matrix<T> upper)
		{ LinearAlgebra<T>.Matrix_DecomposeLU(matrix, out lower, out upper); }
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
		{ return LinearAlgebra<T>.Matrix_EqualsByValue(left, right); }
		/// <summary>Does a value equality check with leniency.</summary>
		/// <param name="left">The first matrix to check for equality.</param>
		/// <param name="right">The second matrix to check for equality.</param>
		/// <param name="leniency">How much the values can vary but still be considered equal.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(Matrix<T> left, Matrix<T> right, T leniency)
		{ return LinearAlgebra<T>.Matrix_EqualsByValue_leniency(left, right, leniency); }
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

	#endregion
}
