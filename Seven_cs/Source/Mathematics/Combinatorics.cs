// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics
{
	/// <summary>Contains generic mathematics combinatorics operations.</summary>
	public static class Combinatorics<T>
	{
		#region delegates

		public static class delegates
		{
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
		}

		#endregion

		#region implementations

		/// <summary>Computes: [ N! ].</summary>
		public static Combinatorics<T>.delegates.Factorial Factorial = (T value) =>
			#region code
			{
				#region generic
#if show_Numeric
				Combinatorics<Numeric>.delegates.Factorial compile_testing =
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
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Factorial_string =
					"(" + num + " N) =>" +
					"{" +
					"	if (N % 1 != 0)" +
					"		throw new Error(\"invalid factorial: N must be a whole number.\");" +
					"	if (N < 0)" +
					"		throw new Error(\"invalid factorial: [ N < 0 ] (N = \" + N + \").\");" +
					"	try" +
					"	{" +
					"		checked" +
					"		{" +
					"			" + num + " result = 1;" +
					"			for (; N > 1; N--)" +
					"				result *= N;" +
					"			return result;" +
					"		}" +
					"	}" +
					"	catch" +
					"	{" +
					"		throw new Error(\"overflow occured in factorial.\");" +
					"	}" +
					"}";

				#endregion

				Combinatorics<T>.Factorial =
					Generate.Object<Combinatorics<T>.delegates.Factorial>(Factorial_string);

				return Combinatorics<T>.Factorial(value);
			};
			#endregion

		/// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
		public static Combinatorics<T>.delegates.Combinations Combinations = (T N, T[] n) =>
			#region code
			{
				#region generic
#if show_Numeric
				Combinatorics<Numeric>.delegates.Combinations compile_testing =
					(Numeric _N, Numeric[] _n) =>
					{
						if (_N % 1 != 0)
							throw new Error("invalid combination: N must be a whole number.");
						for (int i = 0; i < _n.Length; i++)
							if (_n[i] % 1 != 0)
								throw new Error("invalid combination: n[" + i + "] must be a whole number.");
						Numeric result = Combinatorics<Numeric>.Factorial(_N);
						Numeric sum = 0;
						for (int i = 0; i < _n.Length; i++)
						{
							result /= Combinatorics<Numeric>.Factorial(_n[i]);
							sum += _n[i];
						}
						if (sum > _N)
							throw new Error("invalid combination: [ N < Sum(n) ].");
						return result;
					};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Combinations_string =
					"(" + num + " _N, " + num + "[] _n) =>" +
					"{" +
					"	if (_N % 1 != 0)" +
					"		throw new Error(\"invalid combination: N must be a whole number.\");" +
					"	for (int i = 0; i < _n.Length; i++)" +
					"		if (_n[i] % 1 != 0)" +
					"			throw new Error(\"invalid combination: n[\" + i + \"] must be a whole number.\");" +
					"	" + num + " result = Combinatorics<" + num + ">.Factorial(_N);" +
					"	" + num + " sum = 0;" +
					"	for (int i = 0; i < _n.Length; i++)" +
					"	{" +
					"		result /= Combinatorics<" + num + ">.Factorial(_n[i]);" +
					"		sum += _n[i];" +
					"	}" +
					"	if (sum > _N)" +
					"		throw new Error(\"invalid combination: [ N < Sum(n) ].\");" +
					"	return result;" +
					"}";

				#endregion

				Combinatorics<T>.Combinations =
					Generate.Object<Combinatorics<T>.delegates.Combinations>(Combinations_string);

				return Combinatorics<T>.Combinations(N, n);
			};
			#endregion

		/// <summary>Computes: [ N! / (N - n)! ]</summary>
		public static Combinatorics<T>.delegates.Choose Choose = (T N, T n) =>
			#region code
			{
				#region generic
#if show_Numeric
				Combinatorics<Numeric>.delegates.Choose compile_testing =
					(Numeric _N, Numeric _n) =>
					{
						if (_N % 1 != 0)
							throw new Error("invalid chose: N must be a whole number.");
						if (_n % 1 != 0)
							throw new Error("invalid combination: n must be a whole number.");
						if (!(_N <= _n || _N >= 0))
							throw new Error("invalid choose: [ !(N <= n || N >= 0) ].");
						return Combinatorics<Numeric>.Factorial(_N) / (Combinatorics<Numeric>.Factorial(_n) * Combinatorics<Numeric>.Factorial(_N - _n));
					};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Choose_string =
					"(" + num + " _N, " + num + " _n) =>" +
					"{" +
					"	if (_N % 1 != 0)" +
					"		throw new Error(\"invalid chose: N must be a whole number.\");" +
					"	if (_n % 1 != 0)" +
					"		throw new Error(\"invalid combination: n must be a whole number.\");" +
					"	if (!(_N <= _n || _N >= 0))" +
					"		throw new Error(\"invalid choose: [ !(N <= n || N >= 0) ].\");" +
					"	" + num + " factorial_N = Combinatorics<" + num + ">.Factorial(_N);" +
					"	return Combinatorics<" + num + ">.Factorial(_N) / (Combinatorics<" + num + ">.Factorial(_n) * Combinatorics<" + num + ">.Factorial(_N - _n));" +
					"}";

				#endregion

				Combinatorics<T>.Choose =
					Generate.Object<Combinatorics<T>.delegates.Choose>(Choose_string);

				return Combinatorics<T>.Choose(N, n);
			};
			#endregion

		#endregion
	}

	/// <summary>Contains generic mathematics combinatorics operations.</summary>
	public static class Combinatorics
	{
		#region mappings

		/// <summary>Computes: [ N! ].</summary>
		/// <typeparam name="T">The numeric type of the operation.</typeparam>
		/// <param name="N">The number to compute the factorial of.</param>
		/// <returns>[ N! ]</returns>
		public static T Factorial<T>(T N) { return Combinatorics<T>.Factorial(N); }
		/// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
		/// <typeparam name="T">The numeric type of the operation.</typeparam>
		/// <param name="N">The total number of items in the set.</param>
		/// <param name="n">The number of items in the respective sub-sets.</param>
		/// <returns>[ N! / (n[0]! + n[1]! + n[3]! ...) ]</returns>
		public static T Combinations<T>(T N, T[] n) { return Combinatorics<T>.Combinations(N, n); }
		/// <summary>Computes: [ N! / (N - n)! ]</summary>
		/// <typeparam name="T">The numeric type of the operation.</typeparam>
		/// <param name="N">The total number of items.</param>
		/// <param name="n">The number of items to choose.</param>
		/// <returns>[ N! / (N - n)! ]</returns>
		public static T Choose<T>(T N, T n) { return Combinatorics<T>.Choose(N, n); }

		#endregion
	}
}
