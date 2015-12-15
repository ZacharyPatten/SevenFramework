// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

// compile with: /doc:Statistics.xml

using Seven.Structures;

namespace Seven.Mathematics
{
	/// <summary>Contains generic mathematics statistics operations.</summary>
	public class Statistics<T>
	{
		#region delegates

		public static class delegates
		{

			/// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
			/// <param name="stepper">The values to find the mode(s) of.</param>
			/// <returns>A heap containing all the values sorted on their occurence count.</returns>
			public delegate Heap<Link<T, int>> Mode(Stepper<T> stepper);
			/// <summary>Computes the mean (or average) between multiple values.</summary>
			/// <param name="stepper">The operands in the mean operation.</param>
			/// <returns>The mean (or average between the operands).</returns>
			public delegate T Mean(Stepper<T> stepper);
			/// <summary>Computes the median of a set of values.</summary>
			/// <param name="stepper">The values to compute the median of.</param>
			/// <returns>The computed median from the set of values.</returns>
			public delegate T Median(Stepper<T> stepper);
			/// <summary>Computes the geometric mean of a set of values.</summary>
			/// <param name="stepper">The values to compute the geometric mean of.</param>
			/// <returns>The computed geometric mean from the set of values.</returns>
			public delegate T GeometricMean(Stepper<T> stepper);
			/// <summary>Computes the variance of a set of values.</summary>
			/// <param name="stepper">The values to compute the variance of.</param>
			/// <returns>The computed variance from the set of values.</returns>
			public delegate T Variance(Stepper<T> stepper);
			/// <summary>Computes the standard deviation of a set of values.</summary>
			/// <param name="stepper">The values to compute the standard deviation of.</param>
			/// <returns>The computed standard deviation from the set of values.</returns>
			public delegate T StandardDeviation(Stepper<T> stepper);
			/// <summary>Computes the mean deviation of a set of values.</summary>
			/// <param name="stepper">The values to compute the mean deviation of.</param>
			/// <returns>The computed mean deviation from the set of values.</returns>
			public delegate T MeanDeviation(Stepper<T> stepper);
			/// <summary>Computes the range of a set of values.</summary>
			/// <param name="stepper">The values to compute the range of.</param>
			/// <param name="min">The found minimum value.</param>
			/// <param name="max">The found maximum value.</param>
			/// <returns>The computed range from the set of values.</returns>
			public delegate void Range(out T min, out T max, Stepper<T> stepper);
			/// <summary>Computes the quantiles of a set of values.</summary>
			/// <param name="quantiles">The number of quntiles to split the set by.</param>
			/// <param name="stepper">The values to compute the quantiles of.</param>
			/// <returns>The computed quantiles from the set of values.</returns>
			public delegate T[] Quantiles(int quantiles, Stepper<T> stepper);
			/// <summary>Relationship between two random variables or two sets of data.</summary>
			/// <param name="a">One of the two sets to find the correlation of.</param>
			/// <param name="b">One of the two sets to find the correlation of.</param>
			/// <returns>The correlation value.</returns>
			public delegate T Correlation(Stepper<T> a, Stepper<T> b);

		}

		#endregion

		#region implementations

		/// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
		public static Statistics<T>.delegates.Mode Mode = (Stepper<T> stepper) =>
			#region code
			{
				#region generic
#if show_Numeric
				// This is just a compile test. Vector_Add_string (see below) should match this code exactly.
				Statistics<Numeric>.delegates.Mode compile_testing =
					(Stepper<Numeric> _stepper) =>
					{
						Heap_Array<Link<Numeric, int>> heap =
							new Heap_Array<Link<Numeric, int>>(
								(Link<Numeric, int> left, Link<Numeric, int> right) =>
								{
									return Logic<Numeric>.compare(left.One, right.One);
								});
						_stepper((Numeric step) =>
						{
							bool contains = false;
							heap.Stepper((Link<Numeric, int> nested_step) =>
							{
								if (Equate.Default<Numeric>(nested_step.One, step))
								{
									contains = true;
									nested_step.Two++;
									heap.Requeue(nested_step);
									return StepStatus.Break;
								}
								else
									return StepStatus.Continue;
							});
							if (!contains)
								heap.Enqueue(new Link<Numeric, int>(step, 1));
						});
						return heap;
					};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Mode_string =
					"(Stepper<" + num + "> stepper) =>" +
					"{" +
					"	Heap_Array<Link<" + num + ", int>> heap =" +
					"		new Heap_Array<Link<" + num + ", int>>(" +
					"			(Link<" + num + ", int> left, Link<" + num + ", int> right) =>" +
					"			{" +
					"				return Logic<" + num + ">.compare(left.One, right.One);" +
					"			});" +
					"	stepper((" + num + " step) =>" +
					"	{" +
					"		bool contains = false;" +
					"		heap.Stepper((Link<" + num + ", int> nested_step) =>" +
					"		{" +
					"			if (Equate.Default<" + num + ">(nested_step.One, step))" +
					"			{" +
					"				contains = true;" +
					"				nested_step.Two++;" +
					"				heap.Requeue(nested_step);" +
					"				return StepStatus.Break;" +
					"			}" +
					"			else" +
					"				return StepStatus.Continue;" +
					"		});" +
					"		if (!contains)" +
					"			heap.Enqueue(new Link<" + num + ", int>(step, 1));" +
					"	});" +
					"	return heap;" +
					"}";

				#endregion

				Statistics<T>.Mode =
						Generate.Object<Statistics<T>.delegates.Mode>(Mode_string);

				return Statistics<T>.Mode(stepper);
			};
			#endregion

		/// <summary>Computes the mean (or average) between multiple values.</summary>
		public static Statistics<T>.delegates.Mean Mean = (Stepper<T> stepper) =>
			#region code
			{
				#region generic
#if show_Numeric
				Statistics<Numeric>.delegates.Mean compile_testing =
					(Stepper<Numeric> _stepper) =>
					{
						Numeric i = 0;
						Numeric sum = 0;
						_stepper((Numeric step) => { i++; sum += step; });
						return sum / i;
					};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Mean_string =
					"(Stepper<" + num + "> stepper) =>" +
					"{" +
					"	" + num + " i = 0;" +
					"	" + num + " sum = 0;" +
					"	stepper((" + num + " step) => { i++; sum += step; });" +
					"	return sum / i;" +
					"}";

				#endregion

				Statistics<T>.Mean =
						Generate.Object<Statistics<T>.delegates.Mean>(Mean_string);

				return Statistics<T>.Mean(stepper);
			};
			#endregion

		/// <summary>Computes the median of a set of values.</summary>
		public static Statistics<T>.delegates.Median Median = (Stepper<T> stepper) =>
			#region code
			{
				#region generic
#if show_Numeric
				Statistics<Numeric>.delegates.Median compile_testing =
					(Stepper<Numeric> _stepper) =>
					{
						long count = 0;
						_stepper((Numeric step) => { count++; });
						long half = count / 2;
						if (count % 1 == 0)
						{
							Numeric left = default(Numeric);
							Numeric right = default(Numeric);
							count = 0;
							_stepper((Numeric step) =>
							{
								if (count == half)
									left = step;
								else if (count == half + 1)
									right = step;
								count++;
							});
							return (left + right) / (Numeric)2;
						}
						else
						{
							Numeric median = default(Numeric);
							_stepper((Numeric i) =>
							{
								count = 0;
								_stepper((Numeric step) =>
								{
									if (count == half)
										median = step;
									count++;
								});
							});
							return median;
						}
					};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Median_string =
					"(Stepper<" + num + "> _stepper) =>" +
					"{" +
					"	long count =	0;" +
					"	_stepper((" + num + " step) => { count++; });" +
					"	long half = count / 2;" +
					"	if (count % 1 == 0)" +
					"	{" +
					"		" + num + " left = default(" + num + ");" +
					"		" + num + " right = default(" + num + ");" +
					"		count = 0;" +
					"		_stepper((" + num + " step) =>" +
					"		{" +
					"			if (count == half)" +
					"				left = step;" +
					"			else if (count == half + 1)" +
					"				right = step;" +
					"			count++;" +
					"		});" +
					"		return (left + right) / (" + num + ")2;" +
					"	}" +
					"	else" +
					"	{" +
					"		" + num + " median = default(" + num + ");" +
					"		_stepper((" + num + " i) =>" +
					"		{" +
					"			count = 0;" +
					"			_stepper((" + num + " step) =>" +
					"			{" +
					"				if (count == half)" +
					"					median = step;" +
					"				count++;" +
					"			});" +
					"		});" +
					"		return median;" +
					"	}" +
					"}";
				#endregion

				Statistics<T>.Median =
						Generate.Object<Statistics<T>.delegates.Median>(Median_string);

				return Statistics<T>.Median(stepper);
			};
			#endregion

		/// <summary>Computes the median of a set of values.</summary>
		public static Statistics<T>.delegates.GeometricMean GeometricMean = (Stepper<T> stepper) =>
			#region code
			{
				#region generic
#if show_Numeric
				Statistics<Numeric>.delegates.GeometricMean compile_testing =
					(Stepper<Numeric> _stepper) =>
					{
						Numeric multiple = 1;
						int count = 0;
						_stepper((Numeric current) =>
						{
							count++;
							multiple *= current;
						});
						return Algebra<Numeric>.root(multiple, (Numeric)count);
					};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string GeometricMean_string =
					"(Stepper<" + num + "> _stepper) =>" +
					"{" +
					"	" + num + " multiple = 1;" +
					"	int count = 0;" +
					"	_stepper((" + num + " current) =>" +
					"	{" +
					"		count++;" +
					"		multiple *= current;" +
					"	});" +
					"	return Algebra<" + num + ">.root(multiple, (" + num + ")count);" +
					"}";
					
				#endregion

				Statistics<T>.GeometricMean =
						Generate.Object<Statistics<T>.delegates.GeometricMean>(GeometricMean_string);

				return Statistics<T>.GeometricMean(stepper);
			};
			#endregion

		/// <summary>Computes the variance of a set of values.</summary>
		public static Statistics<T>.delegates.Variance Variance = (Stepper<T> stepper) =>
			#region code
			{
				#region generic
#if show_Numeric
				Statistics<Numeric>.delegates.Variance compile_testing =
					(Stepper<Numeric> _stepper) =>
					{
#if no_error_checking
						// nothing
#else
						if (stepper == null)
							throw new Error("null reference: stepper");
#endif
						Numeric mean = Statistics<Numeric>.Mean(_stepper);
						Numeric variance = 0;
						int count = 0;
						_stepper((Numeric i) =>
							{
								Numeric i_minus_mean = i - mean;
								variance += i_minus_mean * i_minus_mean;
								count++;
							});
						return variance / (Numeric)count;
					};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Variance_string =
					"(Stepper<" + num + "> _stepper) =>" +
					"{" +
#if no_error_checking
						// nothing
#else
					"	if (_stepper == null)" +
					"		throw new Error(\"null reference: _stepper\");" +
#endif
					"	" + num + " mean = Statistics<" + num + ">.Mean(_stepper);" +
					"	" + num + " variance = 0;" +
					"	int count = 0;" +
					"	_stepper((" + num + " i) =>" +
					"		{" +
					"			" + num + " i_minus_mean = i - mean;" +
					"			variance += i_minus_mean * i_minus_mean;" +
					"			count++;" +
					"		});" +
					"	return variance / (" + num + ")count;" +
					"}";

				#endregion

				Statistics<T>.Variance =
						Generate.Object<Statistics<T>.delegates.Variance>(Variance_string);

				return Statistics<T>.Variance(stepper);
			};
			#endregion

		/// <summary>Computes the standard deviation of a set of values.</summary>
		public static Statistics<T>.delegates.StandardDeviation StandardDeviation = (Stepper<T> stepper) =>
			#region code
			{
				#region generic
#if show_Numeric
				Statistics<Numeric>.delegates.StandardDeviation compile_testing =
					(Stepper<Numeric> _stepper) =>
					{
#if no_error_checking
					// nothing
#else
						if (_stepper == null)
							throw new Error("null reference: _stepper");
#endif
						return Algebra<Numeric>.sqrt(Statistics<Numeric>.Variance(_stepper));
					};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string StandardDeviation_string =
					"(Stepper<" + num + "> _stepper) =>" +
					"{" +
#if no_error_checking
					// nothing
#else
 "	if (_stepper == null)" +
					"		throw new Error(\"null reference: _stepper\");" +
#endif
 "	return Algebra<" + num + ">.sqrt(Statistics<" + num + ">.Variance(_stepper));" +
					"}";

				#endregion

				Statistics<T>.StandardDeviation =
					Generate.Object<Statistics<T>.delegates.StandardDeviation>(StandardDeviation_string);

				return Statistics<T>.StandardDeviation(stepper);
			};
			#endregion

		/// <summary>Computes the mean deviation of a set of values.</summary>
		/// <see cref="Seven.Mathematics.Logic<T>.abs"/>
		/// <see cref="Seven.Mathematics.Statistics<T>.Mean"/>
		public static Statistics<T>.delegates.MeanDeviation MeanDeviation = (Stepper<T> stepper) =>
			#region code
			{
				#region generic
#if show_Numeric
				Statistics<Numeric>.delegates.MeanDeviation compile_testing =
					(Stepper<Numeric> _stepper) =>
					{
						Numeric mean = Statistics<Numeric>.Mean(_stepper);
						Numeric temp = 0;
						int count = 0;
						_stepper((Numeric i) =>
						{
							temp += Logic<Numeric>.abs(i - mean);
							count++;
						});
						return temp / (Numeric)count;
					};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string MeanDeviation_string =
					"(Stepper<" + num + "> _stepper) =>" +
					"{" +
					"	" + num + " mean = Statistics<" + num + ">.Mean(_stepper);" +
					"	" + num + " temp = 0;" +
					"	int count = 0;" +
					"	_stepper((" + num + " i) =>" +
					"	{" +
					"		temp += Logic<" + num + ">.abs(i - mean);" +
					"		count++;" +
					"	});" +
					"	return temp / (" + num + ")count;" +
					"}";

				#endregion

				Statistics<T>.MeanDeviation =
					Generate.Object<Statistics<T>.delegates.MeanDeviation>(MeanDeviation_string);

				return Statistics<T>.MeanDeviation(stepper);
			};
			#endregion

		/// <summary>Computes the standard deviation of a set of values.</summary>
		public static Statistics<T>.delegates.Range Range = (out T min, out T max, Stepper<T> stepper) =>
			#region code
			{
				#region generic
#if show_Numeric
				Statistics<Numeric>.delegates.Range compile_testing =
					(out Numeric _min, out Numeric _max, Stepper<Numeric> _stepper) =>
					{
						bool set = false;
						Numeric temp_min = 0;
						Numeric temp_max = 0;
						_stepper((Numeric i) =>
						{
							if (!set)
							{
								temp_min = i;
								temp_max = i;
								set = true;
							}
							else
							{
								temp_min = i < temp_min ? i : temp_min;
								temp_max = i > temp_max ? i : temp_max;
							}
						});
						_min = temp_min;
						_max = temp_max;
					};
#endif
				#endregion
	
				#region string
	
				string num = Generate.TypeToCsharp(typeof(T));

				string Range_string =
					"(out " + num + " _min, out " + num + " _max, Stepper<" + num + "> _stepper) =>" +
					"{" +
					"	bool set = false;" +
					"	" + num + " temp_min = 0;" +
					"	" + num + " temp_max = 0;" +
					"	_stepper((" + num + " i) =>" +
					"	{" +
					"		if (!set)" +
					"		{" +
					"			temp_min = i;" +
					"			temp_max = i;" +
					"			set = true;" +
					"		}" +
					"		else" +
					"		{" +
					"			temp_min = i < temp_min ? i : temp_min;" +
					"			temp_max = i > temp_max ? i : temp_max;" +
					"		}" +
					"	});" +
					"	_min = temp_min;" +
					"	_max = temp_max;" +
					"}";
					
				#endregion
	
				Statistics<T>.Range =
					Generate.Object<Statistics<T>.delegates.Range>(Range_string);
	
				Statistics<T>.Range(out min, out max, stepper);
			};
			#endregion

		/// <summary>Computes the quantiles of a set of values.</summary>
		public static Statistics<T>.delegates.Quantiles Quantiles = (int quantiles, Stepper<T> stepper) =>
			#region code
			{
				#region generic
#if show_Numeric
				Statistics<Numeric>.delegates.Quantiles compile_testing =
					(int _quantiles, Stepper<Numeric> _stepper) =>
					{
#if no_error_checking
						// nothing
#else
						if (_stepper == null)
							throw new Error("null reference: _stepper");
						if (_quantiles < 1)
							throw new Error("invalid numer of dimensions on Quantile division");
#endif
						int count = 0;
						_stepper((Numeric i) => { count++; });
						Numeric[] ordered = new Numeric[count];
						int a = 0;
						_stepper((Numeric i) => { ordered[a++] = i; });
						Algorithms.Sort.Quick<Numeric>(Logic.compare, ordered);
						Numeric[] __quantiles = new Numeric[_quantiles + 1];
						__quantiles[0] = ordered[0];
						__quantiles[__quantiles.Length - 1] = ordered[ordered.Length - 1];
						for (int i = 1; i < _quantiles; i++)
						{
							Numeric temp = (ordered.Length / (Numeric)(_quantiles + 1)) * i;
							if (temp % 1 == 0)
								__quantiles[i] = ordered[(int)temp];
							else
								__quantiles[i] = (ordered[(int)temp] + ordered[(int)temp + 1]) / (Numeric)2;
						}
						return __quantiles;
					};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));
	
				string Quantiles_string =
					"(int _quantiles, Stepper<" + num + "> _stepper) =>" +
					"{" +
#if no_error_checking
						// nothing
#else			
					"	if (_stepper == null)" +
					"		throw new Error(\"null reference: _stepper\");" +
					"	if (_quantiles < 1)" +
					"		throw new Error(\"invalid numer of dimensions on Quantile division\");" +
#endif		
					"	int count = 0;" +
					"	_stepper((" + num + " i) => { count++; });" +
					"	" + num + "[] ordered = new " + num + "[count];" +
					"	int a = 0;" +
					"	_stepper((" + num + " i) => { ordered[a++] = i; });" +
					"	Algorithms.Sort.Quick<" + num + ">(Logic.compare, ordered);" +
					"	" + num + "[] __quantiles = new " + num + "[_quantiles + 1];" +
					"	__quantiles[0] = ordered[0];" +
					"	__quantiles[__quantiles.Length - 1] = ordered[ordered.Length - 1];" +
					"	for (int i = 1; i < _quantiles; i++)" +
					"	{" +
					"		" + num + " temp = (ordered.Length / (" + num + ")(_quantiles + 1)) * i;" +
					"		if (temp % 1 == 0)" +
					"			__quantiles[i] = ordered[(int)temp];" +
					"		else" +
					"			__quantiles[i] = (ordered[(int)temp] + ordered[(int)temp + 1]) / (" + num + ")2;" +
					"	}" +
					"	return __quantiles;" +
					"}";

				#endregion

				Statistics<T>.Quantiles =
					Generate.Object<Statistics<T>.delegates.Quantiles>(Quantiles_string);

				return Statistics<T>.Quantiles(quantiles, stepper);
			};
			#endregion

		/// <summary>Computes the median of a set of values.</summary>
		public static Statistics<T>.delegates.Correlation Correlation = (Stepper<T> a, Stepper<T> b) =>
			#region code
			{
				throw new Error("I introduced an error here when I removed the stepref off of structure. will fix soon - seven");

				#region generic
#if show_Numeric
				Statistics<Numeric>.delegates.Correlation compile_testing =
					(Stepper<Numeric> _a, Stepper<Numeric> _b) =>
					{
						throw new Error("needs revision");
						//Numeric a_mean = Statistics<Numeric>.Mean(_a);
						//Numeric b_mean = Statistics<Numeric>.Mean(_b);
						//List<Numeric> a_temp = new List_Linked<Numeric>();
						//_a((Numeric i) => { a_temp.Add(i - b_mean); });
						//List<Numeric> b_temp = new List_Linked<Numeric>();
						//_b((Numeric i) => { b_temp.Add(i - a_mean); });
						//Numeric[] a_cross_b = new Numeric[a_temp.Count * b_temp.Count];
						//int count = 0;
						//a_temp.Stepper((Numeric i_a) =>
						//{
						//	b_temp.Stepper((Numeric i_b) =>
						//	{
						//		a_cross_b[count++] = i_a * i_b;
						//	});
						//});
						//a_temp.Stepper((ref Numeric i) => { i *= i; });
						//b_temp.Stepper((ref Numeric i) => { i *= i; });
						//Numeric sum_a_cross_b = 0;
						//foreach (Numeric i in a_cross_b)
						//	sum_a_cross_b += i;
						//Numeric sum_a_temp = 0;
						//a_temp.Stepper((Numeric i) => { sum_a_temp += i; });
						//Numeric sum_b_temp = 0;
						//b_temp.Stepper((Numeric i) => { sum_b_temp += i; });
						//return sum_a_cross_b / Algebra<Numeric>.sqrt(sum_a_temp * sum_b_temp);
					};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));
	
				string Correlation_string =
					"(Stepper<" + num + "> _a, Stepper<" + num + "> _b) =>" +
					"{" +
					"	" + num + " a_mean = Statistics<" + num + ">.Mean(_a);" +
					"	" + num + " b_mean = Statistics<" + num + ">.Mean(_b);" +
					"	List<" + num + "> a_temp = new List_Linked<" + num + ">();" +
					"	_a((" + num + " i) => { a_temp.Add(i - b_mean); });" +
					"	List<" + num + "> b_temp = new List_Linked<" + num + ">();" +
					"	_b((" + num + " i) => { b_temp.Add(i - a_mean); });" +
					"	" + num + "[] a_cross_b = new " + num + "[a_temp.Count * b_temp.Count];" +
					"	int count = 0;" +
					"	a_temp.Stepper((" + num + " i_a) =>" +
					"	{" +
					"		b_temp.Stepper((" + num + " i_b) =>" +
					"		{" +
					"			a_cross_b[count++] = i_a * i_b;" +
					"		});" +
					"	});" +
					"	a_temp.Stepper((ref " + num + " i) => { i *= i; });" +
					"	b_temp.Stepper((ref " + num + " i) => { i *= i; });" +
					"	" + num + " sum_a_cross_b = 0;" +
					"	foreach (" + num + " i in a_cross_b)" +
					"		sum_a_cross_b += i;" +
					"	" + num + " sum_a_temp = 0;" +
					"	a_temp.Stepper((" + num + " i) => { sum_a_temp += i; });" +
					"	" + num + " sum_b_temp = 0;" +
					"	b_temp.Stepper((" + num + " i) => { sum_b_temp += i; });" +
					"	return sum_a_cross_b / Algebra<" + num + ">.sqrt(sum_a_temp * sum_b_temp);" +
					"}";
					
				#endregion
	
				Statistics<T>.Correlation =
						Generate.Object<Statistics<T>.delegates.Correlation>(Correlation_string);
	
				return Statistics<T>.Correlation(a, b);
			};
			#endregion

		#endregion

	}

	/// <summary>Contains generic mathematics statistics operations.</summary>
	public class Statistics
	{
		#region mappings

		/// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
		/// <param name="stepper">The values to find the mode(s) of.</param>
		/// <returns>A heap containing all the values sorted on their occurence count.</returns>
		public static Heap<Link<T, int>> Mode<T>(Stepper<T> stepper)
		{
			return Statistics<T>.Mode(stepper);
		}

		/// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
		/// <param name="stepper">The values to find the mode(s) of.</param>
		/// <returns>A heap containing all the values sorted on their occurence count.</returns>
		public static Heap<Link<T, int>> Mode<T>(params T[] stepper)
		{
			return Statistics<T>.Mode(stepper.Stepper());
		}

		/// <summary>Computes the mean (or average) between multiple values.</summary>
		/// <param name="stepper">The operands in the mean operation.</param>
		/// <returns>The mean (or average between the operands).</returns>
		public static T Mean<T>(Stepper<T> stepper)
		{
			return Statistics<T>.Mean(stepper);
		}

		/// <summary>Computes the mean (or average) between multiple values.</summary>
		/// <param name="stepper">The operands in the mean operation.</param>
		/// <returns>The mean (or average between the operands).</returns>
		public static T Mean<T>(params T[] stepper)
		{
			return Statistics<T>.Mean(stepper.Stepper());
		}

		/// <summary>Computes the mean (or average) between multiple values.</summary>
		/// <param name="stepper">The operands in the mean operation.</param>
		/// <returns>The mean (or average between the operands).</returns>
		public static T Mean<T>(T left, T right)
		{
			return Statistics<T>.Mean((Step<T> step) => { step(left); step(right); });
		}

		/// <summary>Computes the median of a set of values.</summary>
		/// <param name="stepper">The values to compute the median of.</param>
		/// <returns>The computed median from the set of values.</returns>
		public static T Median<T>(Stepper<T> stepper)
		{
			return Statistics<T>.Median(stepper);
		}

		/// <summary>Computes the median of a set of values.</summary>
		/// <param name="stepper">The values to compute the median of.</param>
		/// <returns>The computed median from the set of values.</returns>
		public static T Median<T>(params T[] stepper)
		{
			return Statistics<T>.Median(stepper.Stepper());
		}

		#endregion
	}
}
