// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics.SetTheory
{
	public class PointRadius<T>
	{
		#region fields

		private Vector<T> _center;
		private T _radius;

		#endregion

		#region constructor

		public PointRadius(Vector<T> center, T radius)
		{
			if (object.ReferenceEquals(null, center))
				throw new System.ArgumentNullException("center");
			if (object.ReferenceEquals(null, radius))
				throw new System.ArgumentNullException("radius");
			if (!Compute<T>.GreaterThan(radius, Compute<T>.Zero))
				throw new System.ArithmeticException("invalid radius on PointRadius construction !(radius > 0)");
			this._center = center;
			this._radius = radius;
		}

		#endregion

		#region static

		public static bool Contains(PointRadius<T> range, Vector<T> vector)
		{
			throw new System.NotImplementedException();
		}

		public static bool Contains(PointRadius<T> a, PointRadius<T> b)
		{
			throw new System.NotImplementedException();
		}

		public static bool Overlaps(PointRadius<T> a, PointRadius<T> b)
		{
			throw new System.NotImplementedException();
		}

		public static Space<T> Intersect(PointRadius<T> a, PointRadius<T> b)
		{
			throw new System.NotImplementedException();
		}

		public static Space<T> Union(PointRadius<T> a, PointRadius<T> b)
		{
			throw new System.NotImplementedException();
		}

		public static Space<T> Complement(PointRadius<T> a, PointRadius<T> b)
		{
			throw new System.NotImplementedException();
		}

		public new static bool Equals(PointRadius<T> a, PointRadius<T> b)
		{
			throw new System.NotImplementedException();
		}

		#endregion

		#region instance

		public bool Contains(Vector<T> vector)
		{ return PointRadius<T>.Contains(this, vector); }
		public bool Contains(PointRadius<T> b)
		{ return PointRadius<T>.Contains(this, b); }
		public bool Overlaps(PointRadius<T> b)
		{ return PointRadius<T>.Overlaps(this, b); }
		public Space<T> Intersect(PointRadius<T> b)
		{ return PointRadius<T>.Intersect(this, b); }
		public Space<T> Union(PointRadius<T> b)
		{ return PointRadius<T>.Union(this, b); }
		public Space<T> Complement(PointRadius<T> b)
		{ return PointRadius<T>.Complement(this, b); }

		#endregion

		#region operators

		public static bool operator ==(PointRadius<T> a, PointRadius<T> b)
		{ return Equals(a, b); }
		public static bool operator !=(PointRadius<T> a, PointRadius<T> b)
		{ return !Equals(a, b); }
		/// <summary>Complement</summary>
		public static Space<T> operator ^(PointRadius<T> a, PointRadius<T> b)
		{ return PointRadius<T>.Complement(a, b); }
		/// <summary>Union</summary>
		public static Space<T> operator |(PointRadius<T> a, PointRadius<T> b)
		{ return PointRadius<T>.Union(a, b); }
		/// <summary>Intersection</summary>
		public static Space<T> operator &(PointRadius<T> a, PointRadius<T> b)
		{ return PointRadius<T>.Intersect(a, b); }

		#endregion
	}
}
