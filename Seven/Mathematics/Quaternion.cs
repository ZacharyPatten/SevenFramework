// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics
{
	/// <summary>Standard 4-component quaternion [x, y, z, w]. W is the rotation ammount.</summary>
	/// <typeparam name="T">The numeric type of this Quaternion.</typeparam>
	[System.Serializable]
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
		//	//return Compute<T>.Normalize(new Quaternion<T>(
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
		{ return Compute<T>.Quaternion_Add(left, right); }
		/// <summary>Subtracts two quaternions.</summary>
		/// <param name="left">The left quaternion of the subtraction.</param>
		/// <param name="right">The right quaternion of the subtraction.</param>
		/// <returns>The resulting quaternion after the subtraction.</returns>
		public static Quaternion<T> operator -(Quaternion<T> left, Quaternion<T> right)
		{ return Compute<T>.Quaternion_Subtract(left, right); }
		/// <summary>Multiplies two quaternions together.</summary>
		/// <param name="left">The first quaternion of the multiplication.</param>
		/// <param name="right">The second quaternion of the multiplication.</param>
		/// <returns>The resulting quaternion after the multiplication.</returns>
		public static Quaternion<T> operator *(Quaternion<T> left, Quaternion<T> right)
		{ return Compute<T>.Quaternion_Multiply(left, right); }
		/// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
		/// <param name="left">The quaternion to pre-multiply the vector by.</param>
		/// <param name="vector">The vector to be multiplied.</param>
		/// <returns>The resulting quaternion of the multiplication.</returns>
		//public static Quaternion<T> operator *(Quaternion<T> left, Vector right)
		//{ return Compute<T>.Multiply(left, right); }
		/// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
		/// <param name="left">The quaternion of the multiplication.</param>
		/// <param name="right">The scalar of the multiplication.</param>
		/// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
		public static Quaternion<T> operator *(Quaternion<T> left, T right)
		{ return Compute<T>.Quaternion_Multiply_scalar(left, right); }
		/// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
		/// <param name="left">The scalar of the multiplication.</param>
		/// <param name="right">The quaternion of the multiplication.</param>
		/// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
		public static Quaternion<T> operator *(T left, Quaternion<T> right)
		{ return Compute<T>.Quaternion_Multiply_scalar(right, left); }
		/// <summary>Checks for equality by value. (beware float errors)</summary>
		/// <param name="left">The first quaternion of the equality check.</param>
		/// <param name="right">The second quaternion of the equality check.</param>
		/// <returns>true if the values were deemed equal, false if not.</returns>
		public static bool operator ==(Quaternion<T> left, Quaternion<T> right)
		{ return Compute<T>.Quaternion_EqualsValue(left, right); }
		/// <summary>Checks for anti-equality by value. (beware float errors)</summary>
		/// <param name="left">The first quaternion of the anti-equality check.</param>
		/// <param name="right">The second quaternion of the anti-equality check.</param>
		/// <returns>false if the values were deemed equal, true if not.</returns>
		public static bool operator !=(Quaternion<T> left, Quaternion<T> right)
		{ return !Compute<T>.Quaternion_EqualsValue(left, right); }

		#endregion

		#region instance

		/// <summary>Computes the length of quaternion.</summary>
		/// <returns>The length of the given quaternion.</returns>
		public T Magnitude()
		{ return Compute<T>.Quaternion_Magnitude(this); }
		/// <summary>Computes the length of a quaternion, but doesn't square root it
		/// for optimization possibilities.</summary>
		/// <returns>The squared length of the given quaternion.</returns>
		public T MagnitudeSquared()
		{ return Compute<T>.Quaternion_MagnitudeSquared(this); }
		/// <summary>Gets the conjugate of the quaternion.</summary>
		/// <returns>The conjugate of teh given quaternion.</returns>
		public Quaternion<T> Conjugate()
		{ return Compute<T>.Quaternion_Conjugate(this); }
		/// <summary>Adds two quaternions together.</summary>
		/// <param name="right">The second quaternion of the addition.</param>
		/// <returns>The result of the addition.</returns>
		public Quaternion<T> Add(Quaternion<T> right)
		{ return Compute<T>.Quaternion_Add(this, right); }
		/// <summary>Subtracts two quaternions.</summary>
		/// <param name="right">The right quaternion of the subtraction.</param>
		/// <returns>The resulting quaternion after the subtraction.</returns>
		public Quaternion<T> Subtract(Quaternion<T> right)
		{ return Compute<T>.Quaternion_Subtract(this, right); }
		/// <summary>Multiplies two quaternions together.</summary>
		/// <param name="right">The second quaternion of the multiplication.</param>
		/// <returns>The resulting quaternion after the multiplication.</returns>
		public Quaternion<T> Multiply(Quaternion<T> right)
		{ return Compute<T>.Quaternion_Multiply(this, right); }
		/// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
		/// <param name="right">The scalar of the multiplication.</param>
		/// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
		public Quaternion<T> Multiply(T right)
		{ return Compute<T>.Quaternion_Multiply_scalar(this, right); }
		/// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
		/// <param name="right">The vector to be multiplied.</param>
		/// <returns>The resulting quaternion of the multiplication.</returns>
		//public Quaternion<T> Multiply(Vector vector) { return Compute<T>.Multiply(this, vector); }
		/// <summary>Normalizes the quaternion.</summary>
		/// <returns>The normalization of the given quaternion.</returns>
		public Quaternion<T> Normalize()
		{ return Compute<T>.Quaternion_Normalize(this); }
		/// <summary>Inverts a quaternion.</summary>
		/// <returns>The inverse of the given quaternion.</returns>
		public Quaternion<T> Invert()
		{ return Compute<T>.Quaternion_Invert(this); }
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
		//public Vector Rotate(Vector vector) { return Compute<T>.Rotate(this, vector); }
		/// <summary>Does a value equality check.</summary>
		/// <param name="right">The second quaternion	to check for equality.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public bool EqualsValue(Quaternion<T> right)
		{ return Compute<T>.Quaternion_EqualsValue(this, right); }
		/// <summary>Does a value equality check with leniency.</summary>
		/// <param name="right">The second quaternion to check for equality.</param>
		/// <param name="leniency">How much the values can vary but still be considered equal.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public bool EqualsValue(Quaternion<T> right, T leniency)
		{ return Compute<T>.Quaternion_EqualsValue_leniency(this, right, leniency); }
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
		{ return Compute<T>.Quaternion_Magnitude(quaternion); }
		/// <summary>Computes the length of a quaternion, but doesn't square root it
		/// for optimization possibilities.</summary>
		/// <param name="quaternion">The quaternion to compute the length squared of.</param>
		/// <returns>The squared length of the given quaternion.</returns>
		public static T MagnitudeSquared(Quaternion<T> quaternion)
		{ return Compute<T>.Quaternion_MagnitudeSquared(quaternion); }
		/// <summary>Gets the conjugate of the quaternion.</summary>
		/// <param name="quaternion">The quaternion to conjugate.</param>
		/// <returns>The conjugate of teh given quaternion.</returns>
		public static Quaternion<T> Conjugate(Quaternion<T> quaternion)
		{ return Compute<T>.Quaternion_Conjugate(quaternion); }
		/// <summary>Adds two quaternions together.</summary>
		/// <param name="left">The first quaternion of the addition.</param>
		/// <param name="right">The second quaternion of the addition.</param>
		/// <returns>The result of the addition.</returns>
		public static Quaternion<T> Add(Quaternion<T> left, Quaternion<T> right)
		{ return Compute<T>.Quaternion_Add(left, right); }
		/// <summary>Subtracts two quaternions.</summary>
		/// <param name="left">The left quaternion of the subtraction.</param>
		/// <param name="right">The right quaternion of the subtraction.</param>
		/// <returns>The resulting quaternion after the subtraction.</returns>
		public static Quaternion<T> Subtract(Quaternion<T> left, Quaternion<T> right)
		{ return Compute<T>.Quaternion_Subtract(left, right); }
		/// <summary>Multiplies two quaternions together.</summary>
		/// <param name="left">The first quaternion of the multiplication.</param>
		/// <param name="right">The second quaternion of the multiplication.</param>
		/// <returns>The resulting quaternion after the multiplication.</returns>
		public static Quaternion<T> Multiply(Quaternion<T> left, Quaternion<T> right)
		{ return Compute<T>.Quaternion_Multiply(left, right); }
		/// <summary>Multiplies all the values of the quaternion by a scalar value.</summary>
		/// <param name="left">The quaternion of the multiplication.</param>
		/// <param name="right">The scalar of the multiplication.</param>
		/// <returns>The result of multiplying all the values in the quaternion by the scalar.</returns>
		public static Quaternion<T> Multiply(Quaternion<T> left, T right)
		{ return Compute<T>.Quaternion_Multiply_scalar(left, right); }
		/// <summary>Pre-multiplies a 3-component vector by a quaternion.</summary>
		/// <param name="left">The quaternion to pre-multiply the vector by.</param>
		/// <param name="right">The vector to be multiplied.</param>
		/// <returns>The resulting quaternion of the multiplication.</returns>
		public static Quaternion<T> Multiply(Quaternion<T> left, Vector<T> right)
		{ return Compute<T>.Quaternion_Multiply_Vector(left, right); }
		/// <summary>Normalizes the quaternion.</summary>
		/// <param name="quaternion">The quaternion to normalize.</param>
		/// <returns>The normalization of the given quaternion.</returns>
		public static Quaternion<T> Normalize(Quaternion<T> quaternion)
		{ return Compute<T>.Quaternion_Normalize(quaternion); }
		/// <summary>Inverts a quaternion.</summary>
		/// <param name="quaternion">The quaternion to find the inverse of.</param>
		/// <returns>The inverse of the given quaternion.</returns>
		public static Quaternion<T> Invert(Quaternion<T> quaternion)
		{ return Compute<T>.Quaternion_Invert(quaternion); }
		/// <summary>Lenearly interpolates between two quaternions.</summary>
		/// <param name="left">The starting point of the interpolation.</param>
		/// <param name="right">The ending point of the interpolation.</param>
		/// <param name="blend">The ratio 0.0-1.0 of how far to interpolate between the left and right quaternions.</param>
		/// <returns>The result of the interpolation.</returns>
		public static Quaternion<T> Lerp(Quaternion<T> left, Quaternion<T> right, T blend)
		{ return Compute<T>.Quaternion_Lerp(left, right, blend); }
		/// <summary>Sphereically interpolates between two quaternions.</summary>
		/// <param name="left">The starting point of the interpolation.</param>
		/// <param name="right">The ending point of the interpolation.</param>
		/// <param name="blend">The ratio of how far to interpolate between the left and right quaternions.</param>
		/// <returns>The result of the interpolation.</returns>
		public static Quaternion<T> Slerp(Quaternion<T> left, Quaternion<T> right, T blend)
		{ return Compute<T>.Quaternion_Slerp(left, right, blend); }
		/// <summary>Rotates a vector by a quaternion [v' = qvq'].</summary>
		/// <param name="rotation">The quaternion to rotate the vector by.</param>
		/// <param name="vector">The vector to be rotated by.</param>
		/// <returns>The result of the rotation.</returns>
		public static Vector<T> Rotate(Quaternion<T> rotation, Vector<T> vector)
		{ return Compute<T>.Quaternion_Rotate(rotation, vector); }
		/// <summary>Does a value equality check.</summary>
		/// <param name="left">The first quaternion to check for equality.</param>
		/// <param name="right">The second quaternion	to check for equality.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(Quaternion<T> left, Quaternion<T> right)
		{ return Compute<T>.Quaternion_EqualsValue(left, right); }
		/// <summary>Does a value equality check with leniency.</summary>
		/// <param name="left">The first quaternion to check for equality.</param>
		/// <param name="right">The second quaternion to check for equality.</param>
		/// <param name="leniency">How much the values can vary but still be considered equal.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(Quaternion<T> left, Quaternion<T> right, T leniency)
		{ return Compute<T>.Quaternion_EqualsValue_leniency(left, right, leniency); }
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
}
