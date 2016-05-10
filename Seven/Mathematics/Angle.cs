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
		#region Delegates

		public class Delegates
		{
			public delegate T DegreesToRadians(T degrees);
			public delegate T TurnsToRadians(T turns);
			public delegate T GradiansToRadians(T gradians);
			public delegate T RadiansToDegrees(T radians);
			public delegate T RadiansToTurns(T radians);
			public delegate T RadiansToGradians(T radians);
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

		#region fields

		T _radians;

		#endregion

		#region construct

		private Angle(T radians)
		{
			this._radians = radians;
		}

		#endregion

		#region factory

		public static Angle<T> Factory_Degrees(T degrees)
		{
			return new Angle<T>(Angle<T>.DegreesToRadians(degrees));
		}

		public static Angle<T> Factory_Radians(T radians)
		{
			return new Angle<T>(radians);
		}

		public static Angle<T> Factory_Turns(T turns)
		{
			return new Angle<T>(Angle<T>.TurnsToRadians(turns));
		}

		public static Angle<T> Factory_Gradians(T gradians)
		{
			return new Angle<T>(Angle<T>.GradiansToRadians(gradians));
		}

		#endregion

		#region property

		public T Degrees
		{
			get { return Angle<T>.RadiansToDegrees(this._radians); }
		}

		public T Radians
		{
			get { return this._radians; }
		}

		public T Turns
		{
			get { return Angle<T>.RadiansToTurns(this._radians); }
		}

		public T Gradians
		{
			get { return Angle<T>.RadiansToGradians(this._radians); }
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

		#region Instance

		#endregion

		#region static

		#region Angles

		/// <summary>Converts degrees to radians.</summary>
		public static Angle<T>.Delegates.DegreesToRadians DegreesToRadians = (T degrees) =>
		{
			Angle<T>.DegreesToRadians =
				Meta.Compile<Angle<T>.Delegates.DegreesToRadians>(
					string.Concat(
@"(", Type_String, @" _degrees) =>
{
	return _degrees * Compute<", Type_String, ">.Pi / (", Type_String, @")180;
}"));

			return Angle<T>.DegreesToRadians(degrees);
		};

		/// <summary>Converts turns to radians.</summary>
		public static Angle<T>.Delegates.TurnsToRadians TurnsToRadians = (T turns) =>
		{
			Angle<T>.TurnsToRadians =
				Meta.Compile<Angle<T>.Delegates.TurnsToRadians>(
					string.Concat(
@"(", Type_String, @" _turns) =>
{
	return _turns * 2 * Compute<", Type_String, @">.Pi;
}"));

			return Angle<T>.TurnsToRadians(turns);
		};

		/// <summary>Converts gradians to radians.</summary>
		public static Angle<T>.Delegates.GradiansToRadians GradiansToRadians = (T gradians) =>
		{
			Angle<T>.GradiansToRadians =
				Meta.Compile<Angle<T>.Delegates.GradiansToRadians>(
					string.Concat(
@"(", Type_String, @" _gradians) =>
{
	return _gradians * Compute<", Type_String, ">.Pi / (", Type_String, @")200;
}"));

			return Angle<T>.GradiansToRadians(gradians);
		};

		/// <summary>Converts radians to degrees.</summary>
		public static Angle<T>.Delegates.RadiansToDegrees RadiansToDegrees = (T radians) =>
		{
			Angle<T>.RadiansToDegrees =
				Meta.Compile<Angle<T>.Delegates.RadiansToDegrees>(
				 string.Concat(
@"(", Type_String, @" _radians) =>
{
	return _radians * (", Type_String, ")180 / Compute<", Type_String, @">.Pi;
}"));

			return Angle<T>.RadiansToDegrees(radians);
		};

		/// <summary>Converts radians to turns.</summary>
		public static Angle<T>.Delegates.RadiansToTurns RadiansToTurns = (T radians) =>
		{
			Angle<T>.RadiansToTurns =
				Meta.Compile<Angle<T>.Delegates.RadiansToTurns>(
					string.Concat(
@"(", Type_String, @" _radians) =>
{
	return _radians / (2 * Compute<", Type_String, @">.Pi);
}"));

			return Angle<T>.RadiansToTurns(radians);
		};

		/// <summary>Converts radians to gradians.</summary>
		public static Angle<T>.Delegates.RadiansToGradians RadiansToGradians = (T radians) =>
		{
			Angle<T>.RadiansToGradians =
				Meta.Compile<Angle<T>.Delegates.RadiansToGradians>(
					string.Concat(
@"(", Type_String, @" _radians) =>
{
	return _radians * (", Type_String, ")200 / Compute<", Type_String, @">.Pi;
}"));

			return Angle<T>.RadiansToGradians(radians);
		};

		#endregion

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