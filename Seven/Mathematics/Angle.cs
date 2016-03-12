// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics
{
	/// <summary>A measurement of an angle.</summary>
	/// <typeparam name="T">The generic numeric type used to store the angle measurement.</typeparam>
	public struct Angle<T>
	{
		T _radians;

		#region construct

		private Angle(T radians)
		{
			this._radians = radians;
		}

		#endregion

		#region factory

		public static Angle<T> Factory_Degrees(T degrees)
		{
			return new Angle<T>(Compute<T>.DegreesToRadians(degrees));
		}

		public static Angle<T> Factory_Radians(T radians)
		{
			return new Angle<T>(radians);
		}

		public static Angle<T> Factory_Turns(T turns)
		{
			return new Angle<T>(Compute<T>.TurnsToRadians(turns));
		}

		public static Angle<T> Factory_Gradians(T gradians)
		{
			return new Angle<T>(Compute<T>.GradiansToRadians(gradians));
		}

		#endregion

		#region property

		public T Degrees
		{
			get { return Compute<T>.RadiansToDegrees(this._radians); }
		}

		public T Radians
		{
			get { return this._radians; }
		}

		public T Turns
		{
			get { return Compute<T>.RadiansToTurns(this._radians); }
		}

		public T Gradians
		{
			get { return Compute<T>.RadiansToGradians(this._radians); }
		}

		#endregion

		#region operator

		public static Angle<T> operator +(Angle<T> left, Angle<T> right)
		{ return new Angle<T>(Compute<T>.Add(left._radians, right._radians)); }
		public static Angle<T> operator -(Angle<T> left, Angle<T> right)
		{ return new Angle<T>(Compute<T>.Subtract(left._radians, right._radians)); }
		public static Angle<T> operator /(Angle<T> left, Angle<T> right)
		{ return new Angle<T>(Compute<T>.Divide(left._radians, right._radians)); }
		public static Angle<T> operator *(Angle<T> angle, T multiplier)
		{ return new Angle<T>(Compute<T>.Multiply(angle._radians, multiplier)); }
		public static Angle<T> operator *(T multiplier, Angle<T> angle)
		{ return new Angle<T>(Compute<T>.Multiply(multiplier, angle._radians)); }
		public static Angle<T> operator /(Angle<T> angle, T divisor)
		{ return new Angle<T>(Compute<T>.Divide(angle._radians, divisor)); }
		public static bool operator <(Angle<T> left, Angle<T> right)
		{ return Compute<T>.Compare(left._radians, right._radians) == Comparison.Less; }
		public static bool operator >(Angle<T> left, Angle<T> right)
		{ return Compute<T>.Compare(left._radians, right._radians) == Comparison.Greater; }
		public static bool operator <=(Angle<T> left, Angle<T> right)
		{ return Compute<T>.Compare(left._radians, right._radians) == (Comparison.Less | Comparison.Equal); }
		public static bool operator >=(Angle<T> left, Angle<T> right)
		{ return Compute<T>.Compare(left._radians, right._radians) == (Comparison.Greater | Comparison.Equal); }
		public static bool operator ==(Angle<T> left, Angle<T> right)
		{ return Compute<T>.Compare(left._radians, right._radians) == Comparison.Equal; }
		public static bool operator !=(Angle<T> left, Angle<T> right)
		{ return Compute<T>.Compare(left._radians, right._radians) != Comparison.Equal; }
		#endregion operators

		#region instance

		#endregion

		#region static

		#endregion

		#region overrides

		public override string ToString()
		{
			return base.ToString();
		}

		public override bool Equals(object obj)
		{
			if (obj is Angle<T>)
				return this._radians.Equals(((Angle<T>)obj)._radians);
			return false;
		}

		public override int GetHashCode()
		{
			return this._radians.GetHashCode();
		}

		#endregion
	}
}