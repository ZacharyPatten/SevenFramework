// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics
{
	/// <summary>Contains generic mathematics algebra operations.</summary>
	public static class Algebra<T>
	{
		#region delegate

		/// <summary>Contains the delegates for algebra mathematical operations.</summary>
		public static class delegates
		{

			/// <summary>Computes (natrual log): [ ln(n) ].</summary>
			/// <param name="n">The value to compute the natural log of.</param>
			/// <returns>The result of the natrual log operation.</returns>
			public delegate T ln(T n);
			/// <summary>Computes: [ log_b(n) ].</summary>
			/// <param name="n">The value to be log-ed.</param>
			/// <param name="b">The base of the log operation.</param>
			/// <returns>[ log_b(n) ]</returns>
			public delegate T log(T n, T b);
			/// <summary>Solves for "x": [ x ^ 2 = b ].</summary>
			/// <param name="b">The value to be square rooted.</param>
			/// <returns>x from: [ x ^ 2 = b ]</returns>
			public delegate T sqrt(T b);
			/// <summary>Solves for "x": [ x ^ r = b ].</summary>
			/// <param name="b">The number to be rooted.</param>
			/// <param name="r">The root to find of b.</param>
			/// <returns>x from: [ x ^ r = b ]</returns>
			public delegate T root(T b, T r);
			/// <summary>Computes: [ e ^ x ].</summary>
			/// <param name="x">The exponent.</param>
			/// <returns>[ e ^ x ]</returns>
			public delegate T exp(T x);
			/// <summary>Computes the prime factors of n.</summary>
			/// <typeparam name="T">The numeric type of the operation.</typeparam>
			/// <param name="n">The value to find the prime roots of.</param>
			/// <returns>The prime factors.</returns>
			public delegate void factorPrimes(T n, Step<T> step);
			/// <summary>Computes: [ 1 / n ].</summary>
			/// <param name="n">The value to be inverted.</param>
			/// <returns>The result of the inversion.</returns>
			public delegate T invert(T n);
			/// <summary>Compuates the algebraic summation [ Σ (stepper) ].</summary>
			/// <param name="stepper">The items to perform the summation on.</param>
			/// <returns>The summation of the provided items.</returns>
			public delegate T summation(Stepper<T> stepper);

		}

		#endregion

		#region implementation

		/// <summary>Computes (natrual log): [ ln(n) ].</summary>
		public static Algebra<T>.delegates.ln ln = (T value) =>
			#region code
			{
				#region generic
#if show_Numeric
				Algebra<Numeric>.delegates.ln compile_testing = (Numeric _value) => { throw new Error("not yet implemented"); };
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string ln_string = "(" + num + " _value) => { throw new Error(\"not yet implemented\"); }";

				#endregion

				Algebra<T>.ln = Generate.Object<Algebra<T>.delegates.ln>(ln_string);

				return Algebra<T>.ln(value);
			};
			#endregion

		/// <summary>Computes: [ log_b(n) ].</summary>
		public static Algebra<T>.delegates.log log = (T value, T _base) =>
			#region code
			{
				#region generic
#if show_Numeric
				Algebra<Numeric>.delegates.log compile_testing = (Numeric _value, Numeric __base) => { return (Numeric)System.Math.Log((double)_value, (double)__base); };
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string log_string = "(" + num + " _value, " + num + " __base) => { return (" + num + ")System.Math.Log((double)_value, (double)__base); }";

				#endregion

				Algebra<T>.log = Generate.Object<Algebra<T>.delegates.log>(log_string);

				return Algebra<T>.log(value, _base);
			};
			#endregion

		/// <summary>Solves for "x": [ x ^ 2 = b ].</summary>
		public static Algebra<T>.delegates.sqrt sqrt = (T value) =>
			#region code
			{
				#region generic
#if show_Numeric
				Algebra<Numeric>.delegates.sqrt compile_testing = (Numeric _value) => { return (Numeric)System.Math.Sqrt((double)_value); };
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string sqrt_string = "(" + num + " _value) => { return (" + num + ")System.Math.Sqrt((double)_value); }";

				#endregion

				Algebra<T>.sqrt = Generate.Object<Algebra<T>.delegates.sqrt>(sqrt_string);

				return Algebra<T>.sqrt(value);
			};
			#endregion

		/// <summary>Solves for "x": [ x ^ r = b ].</summary>
		public static Algebra<T>.delegates.root root = (T _base, T root) =>
			#region code
			{
				#region generic
#if show_Numeric
				Algebra<Numeric>.delegates.root compile_testing = (Numeric __base, Numeric _root) => { return (Numeric)System.Math.Pow((double)__base, (double)(1 / _root)); };
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string root_string = "(" + num + " __base, " + num + " _root) => { return (" + num + ")System.Math.Pow((double)__base, (double)(1 / _root)); }";

				#endregion

				Algebra<T>.root = Generate.Object<Algebra<T>.delegates.root>(root_string);

				return Algebra<T>.root(_base, root);
			};
			#endregion

		/// <summary>Computes: [ e ^ x ].</summary>
		public static Algebra<T>.delegates.exp exp = (T value) =>
			#region code
			{
				#region generic
#if show_Numeric
				Algebra<Numeric>.delegates.exp compile_testing = (Algebra<Numeric>.delegates.exp)((Numeric _value) => { throw new Error("not yet implemented"); });
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string exp_string = "(" + num + " _value) => { return (" + num + ")System.Math.Sqrt((double)_value); }";

				#endregion

				Algebra<T>.exp = Generate.Object<Algebra<T>.delegates.exp>(exp_string);

				return Algebra<T>.exp(value);
			};
			#endregion

		/// <summary>Computes the prime factors of n.</summary>
		public static Algebra<T>.delegates.factorPrimes factorPrimes = (T value, Step<T> step) =>
			#region code
			{
#region generic
#if show_Numeric
				Algebra<Numeric>.delegates.factorPrimes compile_testing =
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
						for (Numeric i = 3; i <= Algebra.sqrt(__value); i += (Numeric)2)
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
#endregion

#region string
				string num = Generate.TypeToCsharp(typeof(T));

				string factorPrimes_string =
					"(" + num + " _value, Step<" + num + "> _step) =>" +
					"{" +
					"	" + num + " __value = _value;" +
					"	if (__value % (" + num + ")1 != (" + num + ")0)" +
					"		throw new Error(\"Attempting to get the pime factors of a non integer\");" +
					"	if (__value < 0)" +
					"	{" +
					"		__value = -__value;" +
					"		_step((" + num + ")(-1));" +
					"	}" +
					"	while (__value % (" + num + ")2 == (" + num + ")0)" +
					"	{" +
					"		_step((" + num + ")2);" +
					"		__value /= (" + num + ")2;" +
					"	}" +
					"	for (" + num + " i = 3; i <= Algebra.sqrt(__value); i += (" + num + ")2)" +
					"	{" +
					"		while (__value % i == 0)" +
					"		{" +
					"			_step(i);" +
					"			__value = __value / i;" +
					"		}" +
					"	}" +
					"	if (__value > ((" + num + ")2))" +
					"		_step(__value);" +
					"}";
#endregion

				Algebra<T>.factorPrimes = Generate.Object<Algebra<T>.delegates.factorPrimes>(factorPrimes_string);

				Algebra<T>.factorPrimes(value, step);
			};
			#endregion

		/// <summary>Computes: [ 1 / n ].</summary>
		public static Algebra<T>.delegates.invert invert = (T value) =>
			#region code
			{
				#region generic
#if show_Numeric
				Algebra<Numeric>.delegates.invert compile_testing = (Numeric _value) => { return 1 / _value; };
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string invert_string = "(" + num + " _value) => { return 1 / _value; }";

				#endregion

				Algebra<T>.invert = Generate.Object<Algebra<T>.delegates.invert>(invert_string);

				return Algebra<T>.invert(value);
			};
			#endregion

		/// <summary>Compuates the algebraic summation [ Σ (stepper) ].</summary>
		public static Algebra<T>.delegates.summation summation = (Stepper<T> stepper) =>
			#region code
			{
				#region generic
#if show_Numeric
			Algebra<Numeric>.delegates.summation compile_testing = (Stepper<Numeric> _stepper) => { Numeric sum = 0; _stepper((Numeric i) => { sum += i; }); return sum; };
#endif
			#endregion

				#region string

			string num = Generate.TypeToCsharp(typeof(T));

			string summation_string = "(Stepper<" + num + "> _stepper) => { " + num + " sum = 0; _stepper((" + num + " i) => { sum += i; }); return sum; }";

			#endregion

				Algebra<T>.summation = Generate.Object<Algebra<T>.delegates.summation>(summation_string);

				return Algebra<T>.summation(stepper);
			};
		#endregion

		#endregion

		#region future

		//static public decimal Lerp(decimal x, decimal x0, decimal x1, decimal y0, decimal y1)
		//{
		//	if ((x1 - x0) == 0M)
		//		return (y0 + y1) / 2M;
		//	return y0 + (x - x0) * (y1 - y0) / (x1 - x0);
		//}

		//public static decimal Lerp(decimal x, decimal x0, decimal x1)
		//{
		//	if (x < 0M || x > 1M)
		//		throw new Error("invalid lerp blend value: (blend < 0.0f || blend > 1.0f).");
		//	return x0 + x * (x1 - x0);
		//}

		#endregion
	}

	/// <summary>Provides extensions for the Algebra interface.</summary>
	public static class Algebra
	{
		#region mappings

		/// <summary>Computes (natrual log): [ ln(n) ].</summary>
		/// <typeparam name="T">The numeric type of the operation.</typeparam>
		/// <param name="n">The value to compute the natural log of.</param>
		/// <returns>The result of the natrual log operation.</returns>
		public static T ln<T>(T n) { return Algebra<T>.ln(n); }
		/// <summary>Computes: [ log_b(n) ].</summary>
		/// <typeparam name="T">The numeric type of the operation.</typeparam>
		/// <param name="n">The value to be log-ed.</param>
		/// <param name="b">The base of the log operation.</param>
		/// <returns>[ log_b(n) ]</returns>
		public static T log<T>(T n, T b) { return Algebra<T>.log(n, b); }
		/// <summary>Solves for "x": [ x ^ 2 = b ].</summary>
		/// <typeparam name="T">The numeric type of the operation.</typeparam>
		/// <param name="b">The value to be square rooted.</param>
		/// <returns>x from: [ x ^ 2 = b ]</returns>
		public static T sqrt<T>(T b) { return Algebra<T>.sqrt(b); }
		/// <summary>Solves for "x": [ x ^ r = b ].</summary>
		/// <typeparam name="T">The numeric type of the operation.</typeparam>
		/// <param name="b">The number to be rooted.</param>
		/// <param name="r">The root to find of b.</param>
		/// <returns>x from: [ x ^ r = b ]</returns>
		public static T root<T>(T b, T r) { return Algebra<T>.root(b, r); }
		/// <summary>Computes: [ e ^ x ].</summary>
		/// <typeparam name="T">The numeric type of the operation.</typeparam>
		/// <param name="x">The exponent.</param>
		/// <returns>[ e ^ x ]</returns>
		public static T exp<T>(T x) { return Algebra<T>.exp(x); }
		/// <summary>Computes the prime factors of n.</summary>
		/// <typeparam name="T">The numeric type of the operation.</typeparam>
		/// <param name="n">The value to find the prime roots of.</param>
		/// <param name="step">The step function for the prime factors.</param>
		/// <returns>The prime factors.</returns>
		public static void factorPrimes<T>(T n, Step<T> step) { Algebra<T>.factorPrimes(n, step); }
		/// <summary>Computes: [ 1 / n ].</summary>
		/// <typeparam name="T">The numeric type of the operation.</typeparam>
		/// <param name="n">The value to be inverted.</param>
		/// <returns>The result of the inversion.</returns>
		public static T invert<T>(T n) { return Algebra<T>.invert(n); }

		#endregion
	}
}
