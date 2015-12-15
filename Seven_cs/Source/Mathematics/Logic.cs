// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics
{
	/// <summary>Contains generic mathematics logic operations.</summary>
	public static class Logic<T>
	{
		#region delegate

		/// <summary>Contaisn the delegates for logic mathematical operations.</summary>
		public static class delegates
		{

			/// <summary>Computes the absolute value of a value.</summary>
			/// <param name="n">The value to be absolut-ed.</param>
			/// <returns>The result of the absolute value operation.</returns>
			public delegate T abs(T n);
			/// <summary>Finds the max value in a set.</summary>
			/// <param name="stepper">The set to find the max value within.</param>
			/// <returns>The max value in the set.</returns>
			public delegate T max(Stepper<T> stepper);
			/// <summary>Finds the min value in a set.</summary>
			/// <param name="stepper">The set to find the min value within.</param>
			/// <returns>The min value in the set.</returns>
			public delegate T min(Stepper<T> stepper);
			/// <summary>Restricts a value to a min-max range.</summary>
			/// <param name="value">The value to be clamped.</param>
			/// <param name="minimum">The minimum value allowed.</param>
			/// <param name="maximum">The maximum value allowed.</param>
			/// <returns>The possibly clamped value.</returns>
			public delegate T clamp(T value, T minimum, T maximum);
			/// <summary>Checks for equality by value with a leniency.</summary>
			/// <param name="left">The left operand of the equate operation.</param>
			/// <param name="right">The right operand of the equate operation.</param>
			/// <param name="leniency">The leniency of the equate operation.</param>
			/// <returns>True if the operand are within the leniency of each other.</returns>
			public delegate bool equ_len(T left, T right, T leniency);

		}

		#endregion

		#region Implementations

		/// <summary>Computes the absolute value of a value.</summary>
		public static Logic<T>.delegates.abs abs = (T n) =>
			#region code
			{
				#region generic
#if show_Numeric
				Logic<Numeric>.delegates.abs compile_testing =
					(Numeric _n) =>
					{
						if (_n < 0)
							return -_n;
						else
							return _n;
					};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string abs_string =
					"(" + num + " _n) =>" +
					"{" +
					"	if (_n < 0)" +
					"		return -_n;" +
					"	else" +
					"		return _n;" +
					"}";

				#endregion

				Logic<T>.abs =
					Generate.Object<Logic<T>.delegates.abs>(abs_string);

				return Logic<T>.abs(n);
			};
			#endregion

		/// <summary>Finds the max value in a set.</summary>
		public static Logic<T>.delegates.max max = (Stepper<T> stepper) =>
			#region code
			{
				#region generic
#if show_Numeric
				Logic<Numeric>.delegates.max compile_testing =
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
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string max_string =
					"(Stepper<" + num + "> _stepper) =>" +
					"{" +
					"	bool assigned = false;" +
					"	" + num + " max = default(" + num + ");" +
					"	_stepper((" + num + " step) =>" +
					"	{" +
					"			if (!assigned)" +
					"				max = step;" +
					"			else if (step > max)" +
					"				max = step;" +
					"	});" +
					"	return max;" +
					"}";

				#endregion

				Logic<T>.max =
					Generate.Object<Logic<T>.delegates.max>(max_string);

				return Logic<T>.max(stepper);
			};
			#endregion

		/// <summary>Finds the min value in a set.</summary>
		public static Logic<T>.delegates.min min = (Stepper<T> stepper) =>
			#region code
			{
				#region generic
#if show_Numeric
				Logic<Numeric>.delegates.min compile_testing =
					(Stepper<Numeric> _stepper) =>
					{
						bool assigned = false;
						Numeric min = default(Numeric);
						_stepper((Numeric step) =>
						{
							if (!assigned)
								min = step;
							else if (step > min)
								min = step;
						});
						return min;
					};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string min_string =
					"(Stepper<" + num + "> _stepper) =>" +
					"{" +
					"	bool assigned = false;" +
					"	" + num + " min = default(" + num + ");" +
					"	_stepper((" + num + " step) =>" +
					"	{" +
					"		if (!assigned)" +
					"			min = step;" +
					"		else if (step > min)" +
					"			min = step;" +
					"	});" +
					"	return min;" +
					"}";

				#endregion

				Logic<T>.min =
					Generate.Object<Logic<T>.delegates.min>(min_string);

				return Logic<T>.max(stepper);
			};
			#endregion

		/// <summary>Restricts a value to a min-max range.</summary>
		public static Logic<T>.delegates.clamp clamp = (T value, T minimum, T maximum) =>
			#region code
			{
				#region generic
#if show_Numeric
				Logic<Numeric>.delegates.clamp compile_testing =
					(Numeric _value, Numeric _minimum, Numeric _maximum) =>
					{
#if no_error_checking
							// nothing
#else
							if (!(_minimum < _maximum))
								throw new Error("!(minimum < maximum)");
#endif
							if (_value < _minimum)
								return _minimum;
							else if (_value > _maximum)
								return _maximum;
							else
								return _value;
					};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string clamp_string =
					"(" + num + " _value, " + num + " _minimum, " + num + " _maximum) =>" +
					"{" +
#if no_error_checking
							 // nothing
#else
 "		if (!(_minimum < _maximum))" +
					"			throw new Error(\"!(minimum < maximum)\");" +
#endif
 "		if (_value < _minimum)" +
					"			return _minimum;" +
					"		else if (_value > _maximum)" +
					"			return _maximum;" +
					"		else" +
					"			return _value;" +
					"}";

				#endregion

				Logic<T>.clamp =
					Generate.Object<Logic<T>.delegates.clamp>(clamp_string);

				return Logic<T>.clamp(value, minimum, maximum);
			};
			#endregion

		/// <summary>Checks for equality by value with a leniency.</summary>
		public static Logic<T>.delegates.equ_len equ_len = (T left, T right, T leniency) =>
			#region code
			{
				#region generic
#if show_Numeric
				Logic<Numeric>.delegates.equ_len compile_testing =
					(Numeric _left, Numeric _right, Numeric _leniency) =>
					{
							if (_left < _right)
								return (_right - _left) < _leniency;
							else
								return (_left - _right) < _leniency;
					};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string equ_len_string =
					"(" + num + " _left, " + num + " _right, " + num + " _leniency) =>" +
					"{" +
					"		if (_left < _right)" +
					"			return (_right - _left) < _leniency;" +
					"		else" +
					"			return (_left - _right) < _leniency;" +
					"}";

				#endregion

				Logic<T>.equ_len =
					Generate.Object<Logic<T>.delegates.equ_len>(equ_len_string);

				return Logic<T>.equ_len(left, right, leniency);
			};
			#endregion

		public static Compare<T> compare = (T left, T right) =>
			#region code
			{
				#region generic
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
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string compare_string =
				"(" + num + " _left, " + num + " _right) =>" +
				"{" +
				"		if (_left < _right)" +
				"			return Comparison.Less;" +
				"		else if (_left > _right)" +
				"			return Comparison.Greater;" +
				"		else" +
				"			return Comparison.Equal;" +
				"}";

				#endregion

				Logic<T>.compare =
					Generate.Object<Compare<T>>(compare_string);

				return Logic<T>.compare(left, right);
			};
			#endregion

		public static Equate<T> equate = Equate.Default;
			#region code
//			{
//				#region generic
//#if show_Numeric
//				Equate<Numeric> compile_testing =
//				(Numeric _left, Numeric _right) =>
//				{
//						return Equate.Default<T>(left, right);
//				};
//#endif
//				#endregion

//				#region string

//				string num = Generate.TypeToCsharp(typeof(T));

//				string equate_string =
//					"(" + num + " _left, " + num + " _right) =>" +
//					"{" +
//					"		return Equate.Default<" + num + ">(_left, _right);" +
//					"}";

//				#endregion

//				Logic<T>.equate =
//					Generate.Object<Equate<T>>(equate_string);

//				return Logic<T>.equate(left, right);
//			};
			#endregion

		#endregion
	}

	public static class Logic
	{
		#region mappings

		/// <summary>Computes the absolute value of a value.</summary>
		public static T abs<T>(T n) { return Logic<T>.abs(n); }
		/// <summary>Finds the max value in a set.</summary>
		public static T max<T>(Stepper<T> stepper) { return Logic<T>.max(stepper); }
		/// <summary>Finds the max value in a set.</summary>
		public static T max<T>(params T[] stepper) { return Logic<T>.max(stepper.Stepper()); }
		/// <summary>Finds the min value in a set.</summary>
		public static T min<T>(Stepper<T> stepper) { return Logic<T>.min(stepper); }
		/// <summary>Finds the min value in a set.</summary>
		public static T min<T>(params T[] stepper) { return Logic<T>.min(stepper.Stepper()); }
		/// <summary>Restricts a value to a min-max range.</summary>
		public static T clamp<T>(T value, T minimum, T maximum) { return Logic<T>.clamp(value, minimum, maximum); }
		/// <summary>Checks for equality by value with a leniency.</summary>
		public static bool equ_len<T>(T left, T right, T leniency) { return Logic<T>.equ_len(left, right, leniency); }
		/// <summary>Delegate for comparing two instances of the same type.</summary>
		public static Comparison compare<T>(T left, T right) { return Logic<T>.compare(left, right); }
		/// <summary>Delegate for equating two instances of different types.</summary>
		public static bool equate<T>(T left, T right) { return Logic<T>.equate(left, right); }

		#endregion
	}
}
