// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics
{
	/// <summary>Contains generic mathematics number theory operations.</summary>
	public static class NumberTheory<T>
	{
		#region delegate

		/// <summary>Contains the delegates for algebra mathematical operations.</summary>
		public static class delegates
		{

			/// <summary>Determines if a number is a prime number.</summary>
			/// <param name="n">The number to determine the prime status of.</param>
			/// <returns>True if prime. False if not prime.</returns>
			public delegate bool isPrime(T n);
			/// <summary>Finds the greatest common factor between multiple integers.</summary>
			/// <param name="stepper">The stepper function for the set.</param>
			/// <returns>The greatest common factor.</returns>
			public delegate T GreatestCommonFactor(Stepper<T> stepper);
			/// <summary>Finds the least common multiple between multiple integers.</summary>
			/// <param name="stepper">The stepper function for the set.</param>
			/// <returns>The least common multiple.</returns>
			public delegate T LeastCommonMultiple(Stepper<T> stepper);
		}

		#endregion

		#region implementation

		/// <summary>Computes (natrual log): [ ln(n) ].</summary>
		public static NumberTheory<T>.delegates.isPrime isPrime = (T value) =>
			#region code
			{
				#region generic
#if show_Numeric
				NumberTheory<Numeric>.delegates.isPrime compile_testing =
					(Numeric candidate) =>
					{
						if (candidate % (Numeric)1 == 0)
						{
							if (candidate == 2)
								return true;
							Numeric squareRoot = Algebra<Numeric>.sqrt(candidate);
							for (int divisor = 3; divisor <= squareRoot; divisor += 2)
								if ((candidate % divisor) == 0)
									return false;
							return true;
						}
						else
							return false;
					};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string isPrime_string =
					"(" + num + " candidate) =>" +
					"{" +
					"	if (candidate % 1 == 0)" +
					"	{" +
					"		if (candidate == 2)" +
					"			return true;" +
					"		" + num + " squareRoot = Algebra<" + num + ">.sqrt(candidate);" +
					"		for (int divisor = 3; divisor <= squareRoot; divisor += 2)" +
					"			if ((candidate % divisor) == 0)" +
					"				return false;" +
					"		return true;" +
					"	}" +
					"	else" +
					"		return false;" +
					"}";

				#endregion

				NumberTheory<T>.isPrime = Generate.Object<NumberTheory<T>.delegates.isPrime>(isPrime_string);

				return NumberTheory<T>.isPrime(value);
			};
			#endregion

		/// <summary>Computes (greatest common factor): [ GCF(set) ].</summary>
		public static NumberTheory<T>.delegates.GreatestCommonFactor GreatestCommonFactor = (Stepper<T> stepper) =>
			#region code
			{
				#region generic
#if show_Numeric
			NumberTheory<Numeric>.delegates.GreatestCommonFactor compile_testing =
				(Stepper<Numeric> _stepper) =>
				{
					if (_stepper == null)
						throw new Error("Null reference: stepper");
					bool assigned = false;
					Numeric gcf = (Numeric)0;
					_stepper((Numeric n) =>
						{
							if (n % (Numeric)1 != 0)
								throw new Error("Attempting to find the Greatest Common Factor of a non-integer value.");
							if (!assigned)
							{
								gcf = Logic.abs(n);
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
									gcf = Logic.abs(a);
								}
							}
						});
					if (!assigned)
						throw new Error("No parameters provided in GCF function.");
					return gcf;
				};
#endif
			#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string compile_string =
					"(Stepper<" + num + "> _stepper) =>" +
					"{" +
					"	if (_stepper == null)" +
					"		throw new Error(\"Null reference: stepper\");" +
					"	bool assigned = false;" +
					"	" + num + " gcf = (" + num + ")0;" +
					"	_stepper((" + num + " n) =>" +
					"		{" +
					"			if (n % (" + num + ")1 != 0)" +
					"				throw new Error(\"Attempting to find the Greatest Common Factor of a non-integer value.\");" +
					"			if (!assigned)" +
					"			{" +
					"				gcf = Logic.abs(n);" +
					"				assigned = true;" +
					"			}" +
					"			else" +
					"			{" +
					"				if (gcf > (" + num + ")1)" +
					"				{" +
					"					" + num + " a = gcf;" +
					"					" + num + " b = n;" +
					"					while (b != 0)" +
					"					{" +
					"						" + num + " remainder = a % b;" +
					"						a = b;" +
					"						b = remainder;" +
					"					}" +
					"					gcf = Logic.abs(a);" +
					"				}" +
					"			}" +
					"		});" +
					"		if (!assigned)" +
					"			throw new Error(\"No parameters provided in GCF function.\");" +
					"	return gcf;" +
					"}";

			#endregion

				NumberTheory<T>.GreatestCommonFactor = Generate.Object<NumberTheory<T>.delegates.GreatestCommonFactor>(compile_string);

				return NumberTheory<T>.GreatestCommonFactor(stepper);
			};
			#endregion

		/// <summary>Computes (least common multiple): [ LCM(set) ].</summary>
		public static NumberTheory<T>.delegates.LeastCommonMultiple LeastCommonMultiple = (Stepper<T> stepper) =>
			#region code
			{
				#region generic
#if show_Numeric
				NumberTheory<Numeric>.delegates.LeastCommonMultiple compile_testing =
					(Stepper<Numeric> _stepper) =>
					{
						if (_stepper == null)
							throw new Error("Null reference: stepper");
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
								lcm = Logic.abs(n);
								assigned = true;
							}
							else
							{
								if (lcm > (Numeric)1)
								{
									lcm = Logic.abs((lcm / NumberTheory<Numeric>.GreatestCommonFactor((Step<Numeric> step) => { step(lcm); step(n); })) * n);
								}
							}
						});
						if (!assigned)
							throw new Error("No parameters provided in LCM function.");
						return lcm;
					};
#endif
			#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string compile_string =
					"(Stepper<" + num + "> _stepper) =>" +
					"{" +
					"	if (_stepper == null)" +
					"		throw new Error(\"Null reference: stepper\");" +
					"	bool assigned = false;" +
					"	" + num + " lcm = (" + num + ")0;" +
					"	_stepper((" + num + " n) =>" +
					"	{" +
					"		if (n == 0)" +
					"		{" +
					"			lcm = 0;" +
					"			return;" +
					"		}" +
					"		if (n % (" + num + ")1 != 0)" +
					"			throw new Error(\"Attempting to find the Greatest Common Factor of a non-integer value.\");" +
					"		if (!assigned)" +
					"		{" +
					"			lcm = Logic.abs(n);" +
					"			assigned = true;" +
					"		}" +
					"		else" +
					"		{" +
					"			if (lcm > (" + num + ")1)" +
					"			{" +
					"				lcm = Logic.abs((lcm / NumberTheory<" + num + ">.GreatestCommonFactor((Step<" + num + "> step) => { step(lcm); step(n); })) * n);" +
					"			}" +
					"		}" +
					"	});" +
					"	if (!assigned)" +
					"		throw new Error(\"No parameters provided in LCM function.\");" +
					"	return lcm;" +
					"}";

				#endregion

				NumberTheory<T>.LeastCommonMultiple = Generate.Object<NumberTheory<T>.delegates.LeastCommonMultiple>(compile_string);

				return NumberTheory<T>.LeastCommonMultiple(stepper);
			};
			#endregion

		#endregion
	}

	/// <summary>Contains generic mathematics number theory operations.</summary>
	public static class NumberTheory
	{
		#region mappings

		/// <summary>Determines if a number is a prime number.</summary>
		/// <param name="n">The number to determine the prime status of.</param>
		/// <returns>True if prime. False if not prime.</returns>
		public static bool isPrime<T>(T n) { return NumberTheory<T>.isPrime(n); }

		public static T GreatestCommonFactor<T>(Stepper<T> stepper) { return NumberTheory<T>.GreatestCommonFactor(stepper); }

		public static T GreatestCommonFactor<T>(params T[] set)
		{
			return NumberTheory.GreatestCommonFactor(
				(Step<T> step) =>
				{
					for (int i = 0; i < set.Length; i++)
						step(set[i]);
				});
		}

		public static T LeastCommonMultiple<T>(Stepper<T> stepper) { return NumberTheory<T>.LeastCommonMultiple(stepper); }

		public static T LeastCommonMultiple<T>(params T[] set)
		{
			return NumberTheory.LeastCommonMultiple(
				(Step<T> step) =>
				{
					for (int i = 0; i < set.Length; i++)
						step(set[i]);
				});
		}

		#endregion
	}
}
