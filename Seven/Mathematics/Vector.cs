// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics
{
	/// <summary>Represents a vector with an arbitrary number of components of a generic type.</summary>
	/// <typeparam name="T">The numeric type of this Vector.</typeparam>
	[System.Serializable]
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
		{ return Compute<T>.Vector_Add(left, right); }
		/// <summary>Subtracts two vectors.</summary>
		/// <param name="left">The left operand of the subtraction.</param>
		/// <param name="right">The right operand of the subtraction.</param>
		/// <returns>The result of the subtraction.</returns>
		public static Vector<T> operator -(Vector<T> left, Vector<T> right)
		{ return Compute<T>.Vector_Subtract(left, right); }
		/// <summary>Negates a vector.</summary>
		/// <param name="vector">The vector to negate.</param>
		/// <returns>The result of the negation.</returns>
		public static Vector<T> operator -(Vector<T> vector)
		{ return Compute<T>.Vector_Negate(vector); }
		/// <summary>Multiplies all the values in a vector by a scalar.</summary>
		/// <param name="left">The vector to have all its values multiplied.</param>
		/// <param name="right">The scalar to multiply all the vector values by.</param>
		/// <returns>The result of the multiplication.</returns>
		public static Vector<T> operator *(Vector<T> left, T right)
		{ return Compute<T>.Vector_Multiply(left, right); }
		/// <summary>Multiplies all the values in a vector by a scalar.</summary>
		/// <param name="left">The scalar to multiply all the vector values by.</param>
		/// <param name="right">The vector to have all its values multiplied.</param>
		/// <returns>The result of the multiplication.</returns>
		public static Vector<T> operator *(T left, Vector<T> right)
		{ return Compute<T>.Vector_Multiply(right, left); }
		/// <summary>Divides all the values in the vector by a scalar.</summary>
		/// <param name="left">The vector to have its values divided.</param>
		/// <param name="right">The scalar to divide all the vectors values by.</param>
		/// <returns>The vector after the divisions.</returns>
		public static Vector<T> operator /(Vector<T> left, T right)
		{ return Compute<T>.Vector_Divide(left, right); }
		/// <summary>Does an equality check by value. (warning for float errors)</summary>
		/// <param name="left">The first vector of the equality check.</param>
		/// <param name="right">The second vector of the equality check.</param>
		/// <returns>true if the values are equal, false if not.</returns>
		public static bool operator ==(Vector<T> left, Vector<T> right)
		{ return Compute<T>.Vector_EqualsValue(left, right); }
		/// <summary>Does an anti-equality check by value. (warning for float errors)</summary>
		/// <param name="left">The first vector of the anit-equality check.</param>
		/// <param name="right">The second vector of the anti-equality check.</param>
		/// <returns>true if the values are not equal, false if they are.</returns>
		public static bool operator !=(Vector<T> left, Vector<T> right)
		{ return !Compute<T>.Vector_EqualsValue(left, right); }
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
		{ return Compute<T>.Vector_Add(this, right); }
		/// <summary>Negates this vector.</summary>
		/// <returns>The result of the negation.</returns>
		public Vector<T> Negate()
		{ return Compute<T>.Vector_Negate(this); }
		/// <summary>Subtracts another vector from this one.</summary>
		/// <param name="right">The vector to subtract from this one.</param>
		/// <returns>The result of the subtraction.</returns>
		public Vector<T> Subtract(Vector<T> right)
		{ return Compute<T>.Vector_Subtract(this, right); }
		/// <summary>Multiplies the values in this vector by a scalar.</summary>
		/// <param name="right">The scalar to multiply these values by.</param>
		/// <returns>The result of the multiplications</returns>
		public Vector<T> Multiply(T right)
		{ return Compute<T>.Vector_Multiply(this, right); }
		/// <summary>Divides all the values in this vector by a scalar.</summary>
		/// <param name="right">The scalar to divide the values of the vector by.</param>
		/// <returns>The resulting vector after teh divisions.</returns>
		public Vector<T> Divide(T right)
		{ return Compute<T>.Vector_Divide(this, right); }
		/// <summary>Computes the dot product between this vector and another.</summary>
		/// <param name="right">The second vector of the dot product operation.</param>
		/// <returns>The result of the dot product.</returns>
		public T DotProduct(Vector<T> right)
		{ return Compute<T>.Vector_DotProduct(this, right); }
		/// <summary>Computes the cross product between this vector and another.</summary>
		/// <param name="right">The second vector of the dot product operation.</param>
		/// <returns>The result of the dot product operation.</returns>
		public Vector<T> CrossProduct(Vector<T> right)
		{ return Compute<T>.Vector_CrossProduct(this, right); }
		/// <summary>Normalizes this vector.</summary>
		/// <returns>The result of the normalization.</returns>
		public Vector<T> Normalize()
		{ return Compute<T>.Vector_Normalize(this); }
		/// <summary>Computes the length of this vector.</summary>
		/// <returns>The length of this vector.</returns>
		public T Magnitude()
		{ return Compute<T>.Vector_Magnitude(this); }
		/// <summary>Computes the length of this vector, but doesn't square root it for 
		/// possible optimization purposes.</summary>
		/// <returns>The squared length of the vector.</returns>
		public T MagnitudeSquared()
		{ return Compute<T>.Vector_MagnitudeSquared(this); }
		/// <summary>Check for equality by value.</summary>
		/// <param name="right">The other vector of the equality check.</param>
		/// <returns>true if the values were equal, false if not.</returns>
		public bool EqualsValue(Vector<T> right)
		{ return Compute<T>.Vector_EqualsValue(this, right); }
		/// <summary>Checks for equality by value with some leniency.</summary>
		/// <param name="right">The other vector of the equality check.</param>
		/// <param name="leniency">The ammount the values can differ but still be considered equal.</param>
		/// <returns>true if the values were cinsidered equal, false if not.</returns>
		public bool EqualsValue(Vector<T> right, T leniency)
		{ return Compute<T>.Vector_EqualsValue_leniency(this, right, leniency); }
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
		{ return Compute<T>.Vector_RotateBy(this, angle, x, y, z); }
		/// <summary>Computes the linear interpolation between two vectors.</summary>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
		/// <returns>The result of the interpolation.</returns>
		public Vector<T> Lerp(Vector<T> right, T blend)
		{ return Compute<T>.Vector_Lerp(this, right, blend); }
		/// <summary>Sphereically interpolates between two vectors.</summary>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
		/// <returns>The result of the slerp operation.</returns>
		public Vector<T> Slerp(Vector<T> right, T blend)
		{ return Compute<T>.Vector_Slerp(this, right, blend); }
		/// <summary>Rotates a vector by a quaternion.</summary>
		/// <param name="rotation">The quaternion to rotate the 3-component vector by.</param>
		/// <returns>The result of the rotation.</returns>
		public Vector<T> RotateBy(Quaternion<T> rotation)
		{ return Compute<T>.Vector_RotateBy_quaternion(this, rotation); }

		#endregion

		#region static

		/// <summary>Adds two vectors together.</summary>
		/// <param name="left">The first vector of the addition.</param>
		/// <param name="right">The second vector of the addiiton.</param>
		/// <returns>The result of the addiion.</returns>
		public static Vector<T> Add(T[] left, T[] right)
		{ return Compute<T>.Vector_Add(left, right); }
		/// <summary>Adds two vectors together.</summary>
		/// <param name="left">The first vector of the addition.</param>
		/// <param name="right">The second vector of the addiiton.</param>
		/// <returns>The result of the addiion.</returns>
		public static Vector<T> Add(Vector<T> left, Vector<T> right)
		{ return Compute<T>.Vector_Add(left._vector, right._vector); }
		/// <summary>Negates all the values in a vector.</summary>
		/// <param name="vector">The vector to have its values negated.</param>
		/// <returns>The result of the negations.</returns>
		public static T[] Negate(T[] vector)
		{ return Compute<T>.Vector_Negate(vector); }
		/// <summary>Negates all the values in a vector.</summary>
		/// <param name="vector">The vector to have its values negated.</param>
		/// <returns>The result of the negations.</returns>
		public static Vector<T> Negate(Vector<T> vector)
		{ return Compute<T>.Vector_Negate(vector); }
		/// <summary>Subtracts two vectors.</summary>
		/// <param name="left">The left vector of the subtraction.</param>
		/// <param name="right">The right vector of the subtraction.</param>
		/// <returns>The result of the vector subtracton.</returns>
		public static T[] Subtract(T[] left, T[] right)
		{ return Compute<T>.Vector_Subtract(left, right); }
		/// <summary>Subtracts two vectors.</summary>
		/// <param name="left">The left vector of the subtraction.</param>
		/// <param name="right">The right vector of the subtraction.</param>
		/// <returns>The result of the vector subtracton.</returns>
		public static Vector<T> Subtract(Vector<T> left, Vector<T> right)
		{ return Compute<T>.Vector_Subtract(left._vector, right._vector); }
		/// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
		/// <param name="left">The vector to have the components multiplied by.</param>
		/// <param name="right">The scalars to multiply the vector components by.</param>
		/// <returns>The result of the multiplications.</returns>
		public static T[] Multiply(T[] left, T right)
		{ return Compute<T>.Vector_Multiply(left, right); }
		/// <summary>Multiplies all the components of a vecotr by a scalar.</summary>
		/// <param name="left">The vector to have the components multiplied by.</param>
		/// <param name="right">The scalars to multiply the vector components by.</param>
		/// <returns>The result of the multiplications.</returns>
		public static Vector<T> Multiply(Vector<T> left, T right)
		{ return Compute<T>.Vector_Multiply(left._vector, right); }
		/// <summary>Divides all the components of a vector by a scalar.</summary>
		/// <param name="left">The vector to have the components divided by.</param>
		/// <param name="right">The scalar to divide the vector components by.</param>
		/// <returns>The resulting vector after teh divisions.</returns>
		public static T[] Divide(T[] left, T right)
		{ return Compute<T>.Vector_Divide(left, right); }
		/// <summary>Divides all the components of a vector by a scalar.</summary>
		/// <param name="left">The vector to have the components divided by.</param>
		/// <param name="right">The scalar to divide the vector components by.</param>
		/// <returns>The resulting vector after teh divisions.</returns>
		public static Vector<T> Divide(Vector<T> left, T right)
		{ return Compute<T>.Vector_Divide(left, right); }
		/// <summary>Computes the dot product between two vectors.</summary>
		/// <param name="left">The first vector of the dot product operation.</param>
		/// <param name="right">The second vector of the dot product operation.</param>
		/// <returns>The result of the dot product operation.</returns>
		public static T DotProduct(T[] left, T[] right)
		{ return Compute<T>.Vector_DotProduct(left, right); }
		/// <summary>Computes the dot product between two vectors.</summary>
		/// <param name="left">The first vector of the dot product operation.</param>
		/// <param name="right">The second vector of the dot product operation.</param>
		/// <returns>The result of the dot product operation.</returns>
		public static T DotProduct(Vector<T> left, Vector<T> right)
		{ return Compute<T>.Vector_DotProduct(left._vector, right._vector); }
		/// <summary>Computes teh cross product of two vectors.</summary>
		/// <param name="left">The first vector of the cross product operation.</param>
		/// <param name="right">The second vector of the cross product operation.</param>
		/// <returns>The result of the cross product operation.</returns>
		public static T[] CrossProduct(T[] left, T[] right)
		{ return Compute<T>.Vector_CrossProduct(left, right); }
		/// <summary>Computes teh cross product of two vectors.</summary>
		/// <param name="left">The first vector of the cross product operation.</param>
		/// <param name="right">The second vector of the cross product operation.</param>
		/// <returns>The result of the cross product operation.</returns>
		public static Vector<T> CrossProduct(Vector<T> left, Vector<T> right)
		{ return Compute<T>.Vector_CrossProduct(left, right); }
		/// <summary>Normalizes a vector.</summary>
		/// <param name="vector">The vector to normalize.</param>
		/// <returns>The result of the normalization.</returns>
		public static T[] Normalize(T[] vector)
		{ return Compute<T>.Vector_Normalize(vector); }
		/// <summary>Normalizes a vector.</summary>
		/// <param name="vector">The vector to normalize.</param>
		/// <returns>The result of the normalization.</returns>
		public static Vector<T> Normalize(Vector<T> vector)
		{ return Compute<T>.Vector_Normalize(vector._vector); }
		/// <summary>Computes the length of a vector.</summary>
		/// <param name="vector">The vector to calculate the length of.</param>
		/// <returns>The computed length of the vector.</returns>
		public static T Magnitude(T[] vector)
		{ return Compute<T>.Vector_Magnitude(vector); }
		/// <summary>Computes the length of a vector.</summary>
		/// <param name="vector">The vector to calculate the length of.</param>
		/// <returns>The computed length of the vector.</returns>
		public static T Magnitude(Vector<T> vector)
		{ return Compute<T>.Vector_Magnitude(vector); }
		/// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
		/// <param name="vector">The vector to compute the length squared of.</param>
		/// <returns>The computed length squared of the vector.</returns>
		public static T MagnitudeSquared(T[] vector)
		{ return Compute<T>.Vector_MagnitudeSquared(vector); }
		/// <summary>Computes the length of a vector but doesn't square root it for efficiency (length remains squared).</summary>
		/// <param name="vector">The vector to compute the length squared of.</param>
		/// <returns>The computed length squared of the vector.</returns>
		public static T MagnitudeSquared(Vector<T> vector)
		{ return Compute<T>.Vector_MagnitudeSquared(vector._vector); }
		/// <summary>Computes the angle between two vectors.</summary>
		/// <param name="first">The first vector to determine the angle between.</param>
		/// <param name="second">The second vector to determine the angle between.</param>
		/// <returns>The angle between the two vectors in radians.</returns>
		public static T Angle(T[] first, T[] second)
		{ return Compute<T>.Vector_Angle(first, second); }
		/// <summary>Computes the angle between two vectors.</summary>
		/// <param name="first">The first vector to determine the angle between.</param>
		/// <param name="second">The second vector to determine the angle between.</param>
		/// <returns>The angle between the two vectors in radians.</returns>
		public static T Angle(Vector<T> first, Vector<T> second)
		{ return Compute<T>.Vector_Angle(first._vector, second._vector); }
		/// <summary>Rotates a vector by the specified axis and rotation values.</summary>
		/// <param name="vector">The vector to rotate.</param>
		/// <param name="angle">The angle of the rotation.</param>
		/// <param name="x">The x component of the axis vector to rotate about.</param>
		/// <param name="y">The y component of the axis vector to rotate about.</param>
		/// <param name="z">The z component of the axis vector to rotate about.</param>
		/// <returns>The result of the rotation.</returns>
		public static T[] RotateBy(T[] vector, T angle, T x, T y, T z)
		{ return Compute<T>.Vector_RotateBy(vector, angle, x, y, z); }
		/// <summary>Rotates a vector by the specified axis and rotation values.</summary>
		/// <param name="vector">The vector to rotate.</param>
		/// <param name="angle">The angle of the rotation.</param>
		/// <param name="x">The x component of the axis vector to rotate about.</param>
		/// <param name="y">The y component of the axis vector to rotate about.</param>
		/// <param name="z">The z component of the axis vector to rotate about.</param>
		/// <returns>The result of the rotation.</returns>
		public static Vector<T> RotateBy(Vector<T> vector, T angle, T x, T y, T z)
		{ return Compute<T>.Vector_RotateBy(vector._vector, angle, x, y, z); }
		/// <summary>Rotates a vector by a quaternion.</summary>
		/// <param name="vector">The vector to rotate.</param>
		/// <param name="rotation">The quaternion to rotate the 3-component vector by.</param>
		/// <returns>The result of the rotation.</returns>
		public static Vector<T> RotateBy(Vector<T> vector, Quaternion<T> rotation)
		{ return Compute<T>.Vector_RotateBy_quaternion(vector._vector, rotation); }
		/// <summary>Computes the linear interpolation between two vectors.</summary>
		/// <param name="left">The starting vector of the interpolation.</param>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
		/// <returns>The result of the interpolation.</returns>
		public static T[] Lerp(T[] left, T[] right, T blend)
		{ return Compute<T>.Vector_Lerp(left, right, blend); }
		/// <summary>Computes the linear interpolation between two vectors.</summary>
		/// <param name="left">The starting vector of the interpolation.</param>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 of the interpolation between the start and end.</param>
		/// <returns>The result of the interpolation.</returns>
		public static Vector<T> Lerp(Vector<T> left, Vector<T> right, T blend)
		{ return Compute<T>.Vector_Lerp(left._vector, right._vector, blend); }
		/// <summary>Sphereically interpolates between two vectors.</summary>
		/// <param name="left">The starting vector of the interpolation.</param>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
		/// <returns>The result of the slerp operation.</returns>
		public static T[] Slerp(T[] left, T[] right, T blend)
		{ return Compute<T>.Vector_Slerp(left, right, blend); }
		/// <summary>Sphereically interpolates between two vectors.</summary>
		/// <param name="left">The starting vector of the interpolation.</param>
		/// <param name="right">The ending vector of the interpolation.</param>
		/// <param name="blend">The ratio 0.0 to 1.0 defining the interpolation distance between the two vectors.</param>
		/// <returns>The result of the slerp operation.</returns>
		public static Vector<T> Slerp(Vector<T> left, Vector<T> right, T blend)
		{ return Compute<T>.Vector_Slerp(left._vector, right._vector, blend); }
		/// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
		/// <param name="a">The first vector of the interpolation.</param>
		/// <param name="b">The second vector of the interpolation.</param>
		/// <param name="c">The thrid vector of the interpolation.</param>
		/// <param name="u">The "U" value of the barycentric interpolation equation.</param>
		/// <param name="v">The "V" value of the barycentric interpolation equation.</param>
		/// <returns>The resulting vector of the barycentric interpolation.</returns>
		public static T[] Blerp(T[] a, T[] b, T[] c, T u, T v)
		{ return Compute<T>.Vector_Blerp(a, b, c, u, v); }
		/// <summary>Interpolates between three vectors using barycentric coordinates.</summary>
		/// <param name="a">The first vector of the interpolation.</param>
		/// <param name="b">The second vector of the interpolation.</param>
		/// <param name="c">The thrid vector of the interpolation.</param>
		/// <param name="u">The "U" value of the barycentric interpolation equation.</param>
		/// <param name="v">The "V" value of the barycentric interpolation equation.</param>
		/// <returns>The resulting vector of the barycentric interpolation.</returns>
		public static Vector<T> Blerp(Vector<T> a, Vector<T> b, Vector<T> c, T u, T v)
		{ return Compute<T>.Vector_Blerp(a._vector, b._vector, c._vector, u, v); }
		/// <summary>Does a value equality check.</summary>
		/// <param name="left">The first vector to check for equality.</param>
		/// <param name="right">The second vector	to check for equality.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(T[] left, T[] right)
		{ return Compute<T>.Vector_EqualsValue(left, right); }
		/// <summary>Does a value equality check.</summary>
		/// <param name="left">The first vector to check for equality.</param>
		/// <param name="right">The second vector	to check for equality.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(Vector<T> left, Vector<T> right)
		{ return Compute<T>.Vector_EqualsValue(left._vector, right._vector); }
		/// <summary>Does a value equality check with leniency.</summary>
		/// <param name="left">The first vector to check for equality.</param>
		/// <param name="right">The second vector to check for equality.</param>
		/// <param name="leniency">How much the values can vary but still be considered equal.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(T[] left, T[] right, T leniency)
		{ return Compute<T>.Vector_EqualsValue_leniency(left, right, leniency); }
		/// <summary>Does a value equality check with leniency.</summary>
		/// <param name="left">The first vector to check for equality.</param>
		/// <param name="right">The second vector to check for equality.</param>
		/// <param name="leniency">How much the values can vary but still be considered equal.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(Vector<T> left, Vector<T> right, T leniency)
		{ return Compute<T>.Vector_EqualsValue_leniency(left._vector, right._vector, leniency); }
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
}
