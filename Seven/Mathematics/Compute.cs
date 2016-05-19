// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

using Seven;
using Seven.Structures;
using System.Linq.Expressions;

namespace Seven.Mathematics
{
	/// <summary>Primary class for generic mathematics in the SevenFramework.</summary>
	/// <typeparam name="T">The generic type to perform mathematics on (expected to be numeric).</typeparam>
	public static class Compute<T>
	{
		#region Delegates

		/// <summary>Static storage class for all the Delegates used in the Compute class.</summary>
		public static class Delegates
		{
			public delegate T FromInt32(int value);
			public delegate T ComputePi();
			/// <summary>Negates a value.</summary>
			/// <param name="value">The value to negate.</param>
			/// <returns>The result of the negation.</returns>
			public delegate T Negate(T value);
			/// <summary>Adds two operands together.</summary>
			/// <typeparam name="T">The type of the values to be added.</typeparam>
			/// <param name="left">The left operand of the addition.</param>
			/// <param name="right">The right operand of the addition.</param>
			/// <returns>The result of the addition.</returns>
			public delegate T Add(T left, T right);
			/// <summary>Compuates the algebraic summation [ Σ (stepper) ].</summary>
			/// <param name="stepper">The items to perform the summation on.</param>
			/// <returns>The summation of the provided items.</returns>
			public delegate T Summation(Stepper<T> stepper);
			/// <summary>Subtracts two operands.</summary>
			/// <param name="left">The left operand of the subtraction.</param>
			/// <param name="right">The right operand of the subtraction.</param>
			/// <returns>The result of the subtraction.</returns>
			public delegate T Subtract(T left, T right);
			/// <summary>Multiplies two operands together.</summary>
			/// <param name="left">The left operand of the multiplication.</param>
			/// <param name="right">The right operand of the multiplication.</param>
			/// <returns>The result of the multiplication.</returns>
			public delegate T Multiply(T left, T right);
			/// <summary>Divides two operands.</summary>
			/// <param name="left">The left operand of the division.</param>
			/// <param name="right">The right operand of the division.</param>
			/// <returns>The result of the division.</returns>
			public delegate T Divide(T left, T right);
			/// <summary>Finds the remainder between two operands.</summary>
			/// <param name="left">The left operand of the modulus.</param>
			/// <param name="right">The right operand of the modulus.</param>
			/// <returns>The result of the modulus.</returns>
			public delegate T Modulus(T left, T right);
			/// <summary>Takes one operand to the power of another.</summary>
			/// <param name="left">The base of the power operaition.</param>
			/// <param name="right">The exponent of the power operation.</param>
			/// <returns>The result of the power operation.</returns>
			public delegate T Power(T left, T right);
			/// <summary>Solves for "x": [ x ^ 2 = b ].</summary>
			/// <param name="b">The value to be square rooted.</param>
			/// <returns>x from: [ x ^ 2 = b ]</returns>
			public delegate T SquareRoot(T b);
			/// <summary>Solves for "x": [ x ^ r = b ].</summary>
			/// <param name="b">The number to be rooted.</param>
			/// <param name="r">The root to find of b.</param>
			/// <returns>x from: [ x ^ r = b ]</returns>
			public delegate T Root(T b, T r);
			/// <summary>Computes: [ log_b(n) ].</summary>
			/// <param name="n">The value to be log-ed.</param>
			/// <param name="b">The base of the log operation.</param>
			/// <returns>[ log_b(n) ]</returns>
			public delegate T Logarithm(T n, T b);
			/// <summary>Computes the absolute value of a value.</summary>
			/// <param name="n">The value to be absolut-ed.</param>
			/// <returns>The result of the absolute value operation.</returns>
			public delegate T AbsoluteValue(T n);
			/// <summary>Finds the max value in a set.</summary>
			/// <param name="stepper">The set to find the max value within.</param>
			/// <returns>The max value in the set.</returns>
			public delegate T Maximum(Stepper<T> stepper);
			/// <summary>Finds the min value in a set.</summary>
			/// <param name="stepper">The set to find the min value within.</param>
			/// <returns>The min value in the set.</returns>
			public delegate T Minimum(Stepper<T> stepper);
			/// <summary>Restricts a value to a min-max range.</summary>
			/// <param name="value">The value to be clamped.</param>
			/// <param name="minimum">The minimum value allowed.</param>
			/// <param name="maximum">The maximum value allowed.</param>
			/// <returns>The possibly clamped value.</returns>
			public delegate T Clamp(T value, T minimum, T maximum);
			/// <summary>Checks for equality by value with a leniency.</summary>
			/// <param name="left">The left operand of the equate operation.</param>
			/// <param name="right">The right operand of the equate operation.</param>
			/// <param name="leniency">The leniency of the equate operation.</param>
			/// <returns>True if the operand are within the leniency of each other.</returns>
			public delegate bool EqualsLeniency(T left, T right, T leniency);
			/// <summary>Determines if one operand is less than another.</summary>
			/// <param name="left">Left hand operand.</param>
			/// <param name="right">Right hand operand.</param>
			/// <returns>Returns (left < right).</returns>
			public delegate bool LessThan(T left, T right);
			/// <summary>Determines if one operand is greater than another.</summary>
			/// <param name="left">Left hand operand.</param>
			/// <param name="right">Right hand operand.</param>
			/// <returns>Returns (left > right).</returns>
			public delegate bool GreaterThan(T left, T right);
			/// <summary>Finds the greatest common factor between multiple integers.</summary>
			/// <param name="stepper">The stepper function for the set.</param>
			/// <returns>The greatest common factor.</returns>
			public delegate T GreatestCommonFactor(Stepper<T> stepper);
			/// <summary>Finds the least common multiple between multiple integers.</summary>
			/// <param name="stepper">The stepper function for the set.</param>
			/// <returns>The least common multiple.</returns>
			public delegate T LeastCommonMultiple(Stepper<T> stepper);
			/// <summary>Computes the prime factors of n.</summary>
			/// <typeparam name="T">The numeric type of the operation.</typeparam>
			/// <param name="n">The value to find the prime roots of.</param>
			/// <returns>The prime factors.</returns>
			public delegate void FactorPrimes(T n, Step<T> step);
			/// <summary>Computes: [ e ^ x ].</summary>
			/// <param name="x">The exponent.</param>
			/// <returns>[ e ^ x ]</returns>
			public delegate T Exponential(T x);
			/// <summary>Computes (natrual log): [ ln(n) ].</summary>
			/// <param name="n">The value to compute the natural log of.</param>
			/// <returns>The result of the natrual log operation.</returns>
			public delegate T NaturalLogarithm(T n);
			/// <summary>Computes: [ 1 / n ].</summary>
			/// <param name="n">The value to be inverted.</param>
			/// <returns>The result of the inversion.</returns>
			public delegate T Invert(T n);
			/// <summary>Determines if a number is a prime number.</summary>
			/// <param name="n">The number to determine the prime status of.</param>
			/// <returns>True if prime. False if not prime.</returns>
			public delegate bool IsPrime(T n);
			public delegate T LinearInterpolation(T x, T x0, T x1, T y0, T y1);
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
			public delegate Range<T> Range(Stepper<T> stepper);
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
			/// <summary>Computes the ratio [length of the side opposite to the angle / hypotenuse] in a right triangle.</summary>
			/// <param name="angle">The angle to compute the trigonometric function of.</param>
			/// <returns>The computed ratio.</returns>
			public delegate T Sine(Angle<T> angle);
			/// <summary>Computes the ratio [length of the side adjacent to the angle / hypotenuse] in a right triangle.</summary>
			/// <param name="angle">The angle to compute the trigonometric function of.</param>
			/// <returns>The computed ratio.</returns>
			public delegate T Cosine(Angle<T> angle);
			/// <summary>Computes the ratio [length of the side opposite to the angle / length of the side adjacent to the angle] in a right triangle.</summary>
			/// <param name="angle">The angle to compute the trigonometric function of.</param>
			/// <returns>The computed ratio.</returns>
			public delegate T Tangent(Angle<T> angle);
			/// <summary>Computes the ratio [hypotenuse / length of the side opposite to the angle] in a right triangle.</summary>
			/// <param name="angle">The angle to compute the trigonometric function of.</param>
			/// <returns>The computed ratio.</returns>
			public delegate T Cosecant(Angle<T> angle);
			/// <summary>Computes the ratio [hypotenuse / length of the side adjacent to the angle] in a right triangle.</summary>
			/// <param name="angle">The angle to compute the trigonometric function of.</param>
			/// <returns>The computed ratio.</returns>
			public delegate T Secant(Angle<T> angle);
			/// <summary>Computes the ratio [length of the side adjacent to the angle / length of the side opposite to the angle] in a right triangle.</summary>
			/// <param name="angle">The angle to compute the trigonometric function of.</param>
			/// <returns>The computed ratio.</returns>
			public delegate T Cotangent(Angle<T> angle);
			public delegate Angle<T> InverseSine(T ratio);
			public delegate Angle<T> InverseCosine(T ratio);
			public delegate Angle<T> InverseTangent(T ratio);
			public delegate Angle<T> InverseCosecant(T ratio);
			public delegate Angle<T> InverseSecant(T ratio);
			public delegate Angle<T> InverseCotangent(T ratio);
			public delegate T HyperbolicSine(Angle<T> angle);
			public delegate T HyperbolicCosine(Angle<T> angle);
			public delegate T HyperbolicTangent(Angle<T> angle);
			public delegate T HyperbolicCosecant(Angle<T> angle);
			public delegate T HyperbolicSecant(Angle<T> angle);
			public delegate T HyperbolicCotangent(Angle<T> angle);
			public delegate Angle<T> InverseHyperbolicSine(T ratio);
			public delegate Angle<T> InverseHyperbolicCosine(T ratio);
			public delegate Angle<T> InverseHyperbolicTangent(T ratio);
			public delegate Angle<T> InverseHyperbolicCosecant(T ratio);
			public delegate Angle<T> InverseHyperbolicSecant(T ratio);
			public delegate Angle<T> InverseHyperbolicCotangent(T ratio);
		}

		#endregion

		#region Type_String

		private static string type_string = null;
		private static string T_source
		{
			get
			{
				if (type_string != null)
					return type_string;
				return type_string = Meta.ConvertTypeToCsharpSource(typeof(T));
			}
		}

		#endregion

		#region Pi
		private const int pi_maximum_iterations = 100;
		// NOTE: decimal accuracy for pi requires pi_maximum_iterations = 92
		private static bool _pi_computed = false;
		private static T _pi;
		/// <summary>The mathematical constant for pi. [3.14159265...]</summary>
		/// <remarks>The accuracy can be adjusted with the "pi_maximum_iterations" constant.</remarks>
		public static T Pi
		{
			get
			{
				if (_pi_computed)
					return _pi;

				// Series: PI = 2 * (1 + 1/3 * (1 + 2/5 * (1 + 3/7 * (...))))
				// more terms in computation inproves accuracy

				Compute<T>.Delegates.ComputePi computation =
					Meta.Compile<Compute<T>.Delegates.ComputePi>(
					string.Concat(
@"() =>
{
	int j = 1, max = 1;
	// the actual computation
	Compute<", T_source, @">.Delegates.ComputePi function = null;
	function = () =>
		{
			if (j > max)
				return 1;
			return 1 + j / ((", T_source, @")2 * (j++) + 1) * function();
		};
	// continually compute with higher accuracy
	", T_source, @" pi = 1, previous = 0;
	for (int i = 1; previous != pi && i < ", pi_maximum_iterations, @"; i++)
	{
		previous = pi;
		j = 1;
		max = i;
		pi = ((", T_source, @")2) * function();
	}
	return pi;
}"));


				Compute<T>._pi = computation();
				Compute<T>._pi_computed = true;
				return _pi;
			}
		}
		#endregion

		#region FromInt32
		public static Compute<T>.Delegates.FromInt32 FromInt32 = (int value) =>
		{
			// compile checks
			if (!Meta.ValidateConvert<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.IntCast; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks explicit casting from int operator.");
			// shared expressions
			ParameterExpression _value = Expression.Parameter(typeof(int));
			LabelTarget _label = Expression.Label(typeof(T));
			// code builder
			ListLinked<Expression> expressions = new ListLinked<Expression>();
			// null checks
			if (!typeof(T).IsValueType) // is nullable?
			{
				expressions.Add(
					Expression.IfThen(
						Expression.Equal(_value, Expression.Constant(null, typeof(T))),
						Expression.Throw(Expression.New(typeof(System.ArgumentNullException).GetConstructor(new System.Type[] { typeof(string) }), Expression.Constant("value")))));
			}
			// code
			expressions.Add(Expression.Return(_label, Expression.Convert(_value, typeof(T))));
			expressions.Add(Expression.Label(_label, Expression.Constant(default(T))));
			// compilation
			Compute<T>.FromInt32 = Expression.Lambda<Compute<T>.Delegates.FromInt32>(
				Expression.Block(expressions.ToArray()),
				_value).Compile();
			// invocation
			return Compute<T>.FromInt32(value);
		};
		#endregion

		#region Zero
		private static bool _zero_computed = false;
		private static T _zero;
		public static T Zero
		{
			get
			{
				if (_zero_computed)
					return _zero;
				_zero = Compute<T>.FromInt32(0);
				_zero_computed = true;
				return _zero;
			}
		}
		#endregion

		#region One
		private static bool _one_computed = false;
		private static T _one;
		public static T One
		{
			get
			{
				if (_one_computed)
					return _one;
				_one = Compute<T>.FromInt32(0);
				_one_computed = true;
				return _one;
			}
		}
		#endregion

		#region Negate
		/// <summary>Negates a value.</summary>
		public static Compute<T>.Delegates.Negate Negate = (T value) =>
		{
			// compile checks
			if (!Meta.ValidateNegate<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Negate; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks unary negation (-) operator.");
			// shared expressions
			ParameterExpression _value = Expression.Parameter(typeof(T));
			LabelTarget _label = Expression.Label(typeof(T));
			// code builder
			ListLinked<Expression> expressions = new ListLinked<Expression>();
			// null checks
			if (!typeof(T).IsValueType) // is nullable?
			{
				expressions.Add(
					Expression.IfThen(
						Expression.Equal(_value, Expression.Constant(null, typeof(T))),
						Expression.Throw(Expression.New(typeof(System.ArgumentNullException).GetConstructor(new System.Type[] { typeof(string) }), Expression.Constant("value")))));
			}
			// code
			expressions.Add(Expression.Return(_label, Expression.Negate(_value), typeof(T)));
			expressions.Add(Expression.Label(_label, Expression.Constant(default(T))));
			// compilation
			Compute<T>.Negate = Expression.Lambda<Compute<T>.Delegates.Negate>(
				Expression.Block(expressions.ToArray()),
				_value).Compile();
			// invocation
			return Compute<T>.Negate(value);
		};
		#endregion

		#region Add
		/// <summary>Adds two operands together.</summary>
		public static Compute<T>.Delegates.Add Add = (T left, T right) =>
		{
			// compile checks
			if (!Meta.ValidateAdd<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Add; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks addition (+) operator.");
			// compile the operation
			Compute<T>.Add = Meta.BinaryOperationHelper<Compute<T>.Delegates.Add, T, T, T>(
				(Expression _left, Expression _right, LabelTarget _returnLabel) =>
				{
					return Expression.Return(_returnLabel, Expression.Add(_left, _right), typeof(T));
				});
			// invoke (recursion)
			return Compute<T>.Add(left, right);
		};
		#endregion

		#region Summation
		/// <summary>Compuates the algebraic summation [ Σ (stepper) ].</summary>
		public static Compute<T>.Delegates.Summation Summation = (Stepper<T> stepper) =>
		{
			if (!Meta.ValidateAdd<T>()) { throw new System.ArithmeticException(string.Concat("computation requires an addition operator: ", T_source, " +(", T_source, ", ", T_source, ")")); }

			Compute<T>.Summation =
				Meta.Compile<Compute<T>.Delegates.Summation>(
					string.Concat(
					"(Stepper<", T_source, "> _stepper) => { ", T_source, " sum = 0; _stepper((", T_source, " i) => { sum += i; }); return sum; }"));

			return Compute<T>.Summation(stepper);
		};
		#endregion

		#region Subtract
		/// <summary>Subtracts two operands.</summary>
		public static Compute<T>.Delegates.Subtract Subtract = (T left, T right) =>
		{
			// compile checks
			if (!Meta.ValidateSubtract<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Subtract; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks subtraction (-) operator.");
			// compile the operation
			Compute<T>.Subtract = Meta.BinaryOperationHelper<Compute<T>.Delegates.Subtract, T, T, T>(
				(Expression _left, Expression _right, LabelTarget _returnLabel) =>
				{
					return Expression.Return(_returnLabel, Expression.Subtract(_left, _right), typeof(T));
				});
			// invoke (recursion)
			return Compute<T>.Subtract(left, right);
		};
		#endregion

		#region Multiply
		/// <summary>Multiplies two operands together.</summary>
		public static Compute<T>.Delegates.Multiply Multiply = (T left, T right) =>
		{
			// compile checks
			if (!Meta.ValidateMultiply<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Multiply; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks multiplication (*) operator.");
			// compile the operation
			Compute<T>.Multiply = Meta.BinaryOperationHelper<Compute<T>.Delegates.Multiply, T, T, T>(
				(Expression _left, Expression _right, LabelTarget _returnLabel) =>
				{
					return Expression.Return(_returnLabel, Expression.Multiply(_left, _right), typeof(T));
				});
			// invoke (recursion)
			return Compute<T>.Multiply(left, right);
		};
		#endregion

		#region Divide
		/// <summary>Divides two operands.</summary>
		public static Compute<T>.Delegates.Divide Divide = (T left, T right) =>
		{
			// compile checks
			if (!Meta.ValidateDivide<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Divide; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks division (/) operator.");
			// compile the operation
			Compute<T>.Divide = Meta.BinaryOperationHelper<Compute<T>.Delegates.Divide, T, T, T>(
				(Expression _left, Expression _right, LabelTarget _returnLabel) =>
				{
					return Expression.Return(_returnLabel, Expression.Divide(_left, _right), typeof(T));
				});
			// invoke (recursion)
			return Compute<T>.Divide(left, right);
		};
		#endregion

		#region Modulus
		/// <summary>Modulus of two operands.</summary>
		public static Compute<T>.Delegates.Modulus Modulus = (T left, T right) =>
		{
			// compile checks
			if (!Meta.ValidateModulo<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Modulus; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks modulus (%) operator.");
			// compile the operation
			Compute<T>.Modulus = Meta.BinaryOperationHelper<Compute<T>.Delegates.Modulus, T, T, T>(
				(Expression _left, Expression _right, LabelTarget _returnLabel) =>
				{
					return Expression.Return(_returnLabel, Expression.Modulo(_left, _right), typeof(T));
				});
			// invoke (recursion)
			return Compute<T>.Modulus(left, right);
		};
		#endregion

		#region Power
		/// <summary>Takes one operand to the power of another.</summary>
		public static Compute<T>.Delegates.Power Power = (T left, T right) =>
		{
			#region Optimizations
			if (typeof(T) == typeof(short))
			{
				Compute<short>.Power = (short _left, short _right) => { return (short)System.Math.Pow(_left, _right); };
				return Compute<T>.Power(left, right);
			}
			if (typeof(T) == typeof(ushort))
			{
				Compute<ushort>.Power = (ushort _left, ushort _right) => { return (ushort)System.Math.Pow(_left, _right); };
				return Compute<T>.Power(left, right);
			}
			if (typeof(T) == typeof(int))
			{
				Compute<int>.Power = (int _left, int _right) => { return (int)System.Math.Pow(_left, _right); };
				return Compute<T>.Power(left, right);
			}
			if (typeof(T) == typeof(uint))
			{
				Compute<uint>.Power = (uint _left, uint _right) => { return (uint)System.Math.Pow(_left, _right); };
				return Compute<T>.Power(left, right);
			}
			if (typeof(T) == typeof(long))
			{
				Compute<long>.Power = (long _left, long _right) => { return (long)System.Math.Pow(_left, _right); };
				return Compute<T>.Power(left, right);
			}
			if (typeof(T) == typeof(ulong))
			{
				Compute<ulong>.Power = (ulong _left, ulong _right) => { return (ulong)System.Math.Pow(_left, _right); };
				return Compute<T>.Power(left, right);
			}
			if (typeof(T) == typeof(float))
			{
				Compute<float>.Power = (float _left, float _right) => { return (float)System.Math.Pow(_left, _right); };
				return Compute<T>.Power(left, right);
			}
			#endregion

			throw new System.NotImplementedException();

//#if math_debug
//			ConstantExpression operand_left = Expression.Constant(left, typeof(T));
//			ConstantExpression operand_right = Expression.Constant(right, typeof(T));
//#else
//			ParameterExpression operand_left = Expression.Parameter(typeof(T), "operand_left");
//			ParameterExpression operand_right = Expression.Parameter(typeof(T), "operand_right");
//#endif

//			ParameterExpression result = Expression.Variable(typeof(T), "result");
//			ParameterExpression i = Expression.Variable(typeof(T), "i");
//			LabelTarget label = Expression.Label(typeof(int));
			
//			Expression code = 
//				Expression.Loop(
				
				
				
//				);



//			Expression loop = Expression.Loop(
//					 Expression.IfThenElse(
//							 Expression.GreaterThan(value, Expression.Constant(1)),
//							 Expression.MultiplyAssign(result,
//									 Expression.PostDecrementAssign(value)),
//							 Expression.Break(label, result)
//					 ),
//				 label
//					);

//			Expression code = Expression.Power(operand_left, operand_right);

//#if math_debug
//			return Expression.Lambda<System.Func<T>>(code).Compile()();
//#else
//			Compute<T>.Power = Expression.Lambda<Compute<T>.Delegates.Power>(code, operand_left, operand_right).Compile();
//			return Compute<T>.Power(left, right);
//#endif
		};
		#endregion

		#region SquareRoot
		/// <summary>Solves for "x": [ x ^ 2 = b ].</summary>
		public static Compute<T>.Delegates.SquareRoot SquareRoot = (T value) =>
		{
			Compute<T>.SquareRoot = Meta.Compile<Compute<T>.Delegates.SquareRoot>(
				string.Concat("(", T_source, " _value) => { return (", T_source, ")System.Math.Sqrt((double)_value); }"));

			return Compute<T>.SquareRoot(value);
		};

		/// <summary>Solves for "x": [ x ^ r = b ].</summary>
		public static Compute<T>.Delegates.Root Root = (T _base, T root) =>
		{
			Compute<T>.Root = Meta.Compile<Compute<T>.Delegates.Root>(
				string.Concat("(", T_source, " __base, ", T_source, " _root) => { return (", T_source, ")System.Math.Pow((double)__base, (double)(1 / _root)); }"));

			return Compute<T>.Root(_base, root);
		};
		#endregion

		#region Logarithm
		/// <summary>Computes: [ log_b(n) ].</summary>
		public static Compute<T>.Delegates.Logarithm Logarithm = (T value, T _base) =>
		{
			Compute<T>.Logarithm =
				Meta.Compile<Compute<T>.Delegates.Logarithm>(
					string.Concat("(" + T_source + " _value, " + T_source + " __base) => { return (" + T_source + ")System.Math.Log((double)_value, (double)__base); }"));

			return Compute<T>.Logarithm(value, _base);
		};
		#endregion

		#region AbsoluteValue
		/// <summary>Computes the absolute value of a value.</summary>
		public static Compute<T>.Delegates.AbsoluteValue AbsoluteValue = (T value) =>
		{
			// compile checks
			if (!Meta.ValidateEqual<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.AbsoluteValue; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks equality (==) operator.");
			if (!Meta.ValidateLessThan<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.AbsoluteValue; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (<) operator.");
			if (!Meta.ValidateNegate<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.AbsoluteValue; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks unary negation (-) operator.");
			if (!Meta.ValidateConvert<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.AbsoluteValue; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks explicit casting from int operator.");
			// compile the operation
			Compute<T>.AbsoluteValue = Meta.UnaryOperationHelper<Compute<T>.Delegates.AbsoluteValue, T, T>(
				(Expression _operand, LabelTarget _returnLabel) =>
				{
					return Expression.IfThenElse(
						Expression.LessThan(_operand, Expression.Constant(Compute<T>.FromInt32(0), typeof(T))),
						Expression.Return(_returnLabel, Expression.Negate(_operand), typeof(T)),
						Expression.Return(_returnLabel, _operand, typeof(T)));
				});
			// invoke (recursion)
			return Compute<T>.AbsoluteValue(value);

			#region Alternate Version
//			Compute<T>.AbsoluteValueOLD =
//				Meta.Compile<Compute<T>.Delegates.AbsoluteValue>(
//					string.Concat(
//"(", Type_String, @" _n) =>
//{
//	if (_n < (", Type_String, @")0)
//		return -_n;
//	else
//		return _n;
//}"));

//			return Compute<T>.AbsoluteValueOLD(n);
			#endregion
		};
		#endregion

		#region Maximum
		/// <summary>Finds the max value in a set.</summary>
		public static Compute<T>.Delegates.Maximum Maximum = (Stepper<T> stepper) =>
		{
			// compile checks
			if (!Meta.ValidateEqual<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Maximum; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks equality (==) operator.");
			if (!Meta.ValidateLessThan<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Maximum; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (<) operator.");
			// compilation
			if (!typeof(T).IsValueType)
			{
				Compute<T>.Maximum =
				(Stepper<T> _stepper) =>
				{
					if (_stepper == null)
						throw new System.Exception();
					bool assigned = false;
					T max = default(T);
					_stepper((T step) =>
					{
						if (step == null)
							throw new System.ArgumentNullException("step");
						if (!assigned)
						{
							max = step;
							assigned = true;
						}
						else if (Compute<T>.LessThan(max, step))
							max = step;
					});
					return max;
				};
			}
			else
			{
				Compute<T>.Maximum =
				(Stepper<T> _stepper) =>
				{
					bool assigned = false;
					T max = default(T);
					_stepper((T step) =>
					{
						if (!assigned)
						{
							max = step;
							assigned = true;
						}
						else if (Compute<T>.LessThan(max, step))
							max = step;
					});
					return max;
				};
			}
			// invocation
			return Compute<T>.Maximum(stepper);

			#region Alternate Version
			//// compile checks
			//if (!Meta.ValidateOperator.Equality(typeof(T), typeof(T), typeof(T)))
			//	throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Maximum; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks equality (==) operator.");
			//if (!Meta.ValidateOperator.LessThan(typeof(T), typeof(T), typeof(T)))
			//	throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Maximum; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (<) operator.");
			//// shared expressions
			//ParameterExpression _stepper = Expression.Parameter(typeof(Stepper<T>));
			//ParameterExpression assigned = Expression.Variable(typeof(bool));
			//ParameterExpression max = Expression.Variable(typeof(T));
			//ParameterExpression step = Expression.Parameter(typeof(T));
			//LabelTarget label = Expression.Label(typeof(T));
			//// code builder
			//List_Linked<Expression> expressions = new List_Linked<Expression>();
			//// null checks
			//expressions.Add(
			//	Expression.IfThen(
			//		Expression.Equal(_stepper, Expression.Constant(null, typeof(Stepper<T>))),
			//		Expression.Throw(Expression.New(typeof(System.ArgumentNullException).GetConstructor(new System.Type[] { typeof(string) }), Expression.Constant("stepper")))));
			//// code
			//expressions.Add(
			//	Expression.Assign(assigned, Expression.Constant(false, typeof(bool))));
			//expressions.Add(
			//	Expression.Assign(max, Expression.Constant(default(T), typeof(T))));
			//List_Linked<Expression> inner_expressions = new List_Linked<Expression>();
			//if (!typeof(T).IsValueType) // is nullable?
			//{
			//	expressions.Add(
			//		Expression.IfThen(
			//			Expression.Equal(step, Expression.Constant(null, typeof(T))),
			//			Expression.Throw(Expression.New(typeof(System.ArgumentNullException).GetConstructor(new System.Type[] { typeof(string) }), Expression.Constant("step")))));
			//}
			//inner_expressions.Add(
			//	Expression.IfThen(
			//		Expression.IsFalse(assigned),
			//		Expression.Block(
			//			Expression.Assign(max, step),
			//			Expression.Assign(assigned, Expression.Constant(true)))));
			//inner_expressions.Add(
			//	Expression.IfThen(
			//		Expression.LessThan(max, step),
			//		Expression.Assign(max, step)));
			//expressions.Add(
			//	Expression.Invoke(_stepper,
			//		Expression.Lambda<Step<T>>(
			//			Expression.Block(inner_expressions.ToArray()),
			//			step)));
			//expressions.Add(
			//	Expression.Return(label, max, typeof(T)));
			//expressions.Add(
			//	Expression.Label(label, Expression.Constant(default(T))));
			//// compilation
			//var lamb = Expression.Lambda<Compute<T>.Delegates.Maximum>(
			//	Expression.Block(new ParameterExpression[] { assigned, max }, expressions.ToArray()),
			//	_stepper);
			//Compute<T>.Maximum = lamb.Compile();
			//// invocation
			//return Compute<T>.Maximum(stepper);
			#endregion

			#region Alternate Version
//			// compile checks
//			if (!Meta.ValidateOperator.Equality(typeof(T), typeof(T), typeof(T)))
//				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Maximum; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks equality (==) operator.");
//			if (!Meta.ValidateOperator.LessThan(typeof(T), typeof(T), typeof(T)))
//				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Maximum; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (<) operator.");

//			if (!typeof(T).IsValueType)
//			{
//				Compute<T>.Maximum2 =
//					Meta.Compile<Compute<T>.Delegates.Maximum>(
//						string.Concat(
//@"(Stepper<", Type_String, @"> _stepper) =>
//{
//	if (_stepper == null)
//		throw new System.Exception();
//	bool assigned = false;
//	", Type_String, " max = default(", Type_String, @");
//	_stepper((", Type_String, @" step) =>
//	{
//		if (step == null)
//			throw new System.NullArgumentException(" + "\"step\"" + @");
//		if (!assigned)
//			max = step;
//		else if (step > max)
//			max = step;
//	});
//	return max;
//}"));
//			}
//			else
//			{
//				Compute<T>.Maximum =
//					Meta.Compile<Compute<T>.Delegates.Maximum>(
//						string.Concat(
//@"(Stepper<", Type_String, @"> _stepper) =>
//{
//	if (_stepper == null)
//		throw new System.Exception();
//	bool assigned = false;
//	", Type_String, " max = default(", Type_String, @");
//	_stepper((", Type_String, @" step) =>
//	{
//		if (!assigned)
//			max = step;
//		else if (step > max)
//			max = step;
//	});
//	return max;
//}"));
//			}

//			return Compute<T>.Maximum(stepper);
			#endregion
		};
		#endregion

		#region Minimum
		/// <summary>Finds the min value in a set.</summary>
		public static Compute<T>.Delegates.Minimum Minimum = (Stepper<T> stepper) =>
		{
			// compile checks
			if (!Meta.ValidateEqual<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Minimum; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks equality (==) operator.");
			if (!Meta.ValidateLessThan<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Minimum; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (<) operator.");
			// compilation
			if (!typeof(T).IsValueType)
			{
				Compute<T>.Minimum =
				(Stepper<T> _stepper) =>
				{
					if (_stepper == null)
						throw new System.Exception();
					bool assigned = false;
					T min = default(T);
					_stepper((T step) =>
					{
						if (step == null)
							throw new System.ArgumentNullException("step");
						if (!assigned)
						{
							min = step;
							assigned = true;
						}
						else if (Compute<T>.LessThan(step, min))
							min = step;
					});
					return min;
				};
			}
			else
			{
				Compute<T>.Minimum =
				(Stepper<T> _stepper) =>
				{
					bool assigned = false;
					T min = default(T);
					_stepper((T step) =>
					{
						if (!assigned)
						{
							min = step;
							assigned = true;
						}
						else if (Compute<T>.LessThan(step, min))
							min = step;
					});
					return min;
				};
			}
			// invocation
			return Compute<T>.Minimum(stepper);

			#region Alternate Version
			//// compile checks
			//if (!Meta.ValidateOperator.Equality(typeof(T), typeof(T), typeof(T)))
			//	throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Minimum; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks equality (==) operator.");
			//if (!Meta.ValidateOperator.LessThan(typeof(T), typeof(T), typeof(T)))
			//	throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Minimum; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (<) operator.");
			//// shared expressions
			//ParameterExpression _stepper = Expression.Parameter(typeof(Stepper<T>));
			//ParameterExpression assigned = Expression.Variable(typeof(bool));
			//ParameterExpression min = Expression.Variable(typeof(T));
			//ParameterExpression step = Expression.Parameter(typeof(T));
			//LabelTarget label = Expression.Label(typeof(T));
			//// code builder
			//List_Linked<Expression> expressions = new List_Linked<Expression>();
			//// null checks
			//expressions.Add(
			//	Expression.IfThen(
			//		Expression.Equal(_stepper, Expression.Constant(null, typeof(Stepper<T>))),
			//		Expression.Throw(Expression.New(typeof(System.ArgumentNullException).GetConstructor(new System.Type[] { typeof(string) }), Expression.Constant("stepper")))));
			//// code
			//expressions.Add(
			//	Expression.Assign(assigned, Expression.Constant(false, typeof(bool))));
			//expressions.Add(
			//	Expression.Assign(min, Expression.Constant(default(T), typeof(T))));
			//List_Linked<Expression> inner_expressions = new List_Linked<Expression>();
			//if (!typeof(T).IsValueType) // is nullable?
			//{
			//	expressions.Add(
			//		Expression.IfThen(
			//			Expression.Equal(step, Expression.Constant(null, typeof(T))),
			//			Expression.Throw(Expression.New(typeof(System.ArgumentNullException).GetConstructor(new System.Type[] { typeof(string) }), Expression.Constant("step")))));
			//}
			//inner_expressions.Add(
			//	Expression.IfThen(
			//		Expression.Not(assigned),
			//		Expression.Block(
			//			Expression.Assign(min, step),
			//			Expression.Assign(assigned, Expression.Constant(true)))));
			//inner_expressions.Add(
			//	Expression.IfThen(
			//		Expression.LessThan(step, min),
			//		Expression.Assign(min, step)));
			//expressions.Add(
			//	Expression.Invoke(_stepper,
			//		Expression.Lambda<Step<T>>(
			//			Expression.Block(inner_expressions.ToArray()),
			//			step)));
			//expressions.Add(
			//	Expression.Return(label, min, typeof(T)));
			//expressions.Add(
			//	Expression.Label(label, Expression.Constant(default(T))));
			//// compilation
			//Compute<T>.Minimum = Expression.Lambda<Compute<T>.Delegates.Minimum>(
			//	Expression.Block(new ParameterExpression[] { assigned, min }, expressions.ToArray()),
			//	_stepper).Compile();
			//// invocation
			//return Compute<T>.Minimum(stepper);
			#endregion

			#region Alternate Version
			//			// compile checks
			//			if (!Meta.ValidateOperator.Equality(typeof(T), typeof(T), typeof(T)))
			//				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Minimum; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks equality (==) operator.");
			//			if (!Meta.ValidateOperator.LessThan(typeof(T), typeof(T), typeof(T)))
			//				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Minimum; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (<) operator.");

			//			if (!typeof(T).IsValueType)
			//			{
			//				Compute<T>.Minimum =
			//					Meta.Compile<Compute<T>.Delegates.Minimum>(
			//						string.Concat(
			//@"(Stepper<", Type_String, @"> _stepper) =>
			//{
			//	if (_stepper == null)
			//		throw new System.Exception();
			//	bool assigned = false;
			//	", Type_String, " min = default(", Type_String, @");
			//	_stepper((", Type_String, @" step) =>
			//	{
			//		if (step == null)
			//			throw new System.NullArgumentException(" + "\"step\"" + @");
			//		if (!assigned)
			//			min = step;
			//		else if (min > step)
			//			min = step;
			//	});
			//	return min;
			//}"));
			//			}
			//			else
			//			{
			//				Compute<T>.Minimum =
			//					Meta.Compile<Compute<T>.Delegates.Minimum>(
			//						string.Concat(
			//@"(Stepper<", Type_String, @"> _stepper) =>
			//{
			//	if (_stepper == null)
			//		throw new System.Exception();
			//	bool assigned = false;
			//	", Type_String, " min = default(", Type_String, @");
			//	_stepper((", Type_String, @" step) =>
			//	{
			//		if (!assigned)
			//			min = step;
			//		else if (min > step)
			//			min = step;
			//	});
			//	return min;
			//}"));
			//			}

			//			return Compute<T>.Minimum(stepper);
			#endregion
		};
		#endregion

		#region Clamp
		/// <summary>Restricts a value to a min-max range.</summary>
		public static Compute<T>.Delegates.Clamp Clamp = (T value, T minimum, T maximum) =>
		{
			// compile checks
			if (!Meta.ValidateEqual<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Clamp; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks equality (==) operator.");
			if (!Meta.ValidateLessThan<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Clamp; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (<) operator.");
			// shared expressions
			ParameterExpression _value = Expression.Parameter(typeof(T));
			ParameterExpression _minimum = Expression.Parameter(typeof(T));
			ParameterExpression _maximum = Expression.Parameter(typeof(T));
			LabelTarget _label = Expression.Label(typeof(T));
			// code builder
			ListLinked<Expression> expressions = new ListLinked<Expression>();
			// null checks
			if (!typeof(T).IsValueType) // is nullable?
			{
				expressions.Add(
					Expression.IfThen(
						Expression.Equal(_value, Expression.Constant(null, typeof(T))),
						Expression.Throw(Expression.New(typeof(System.ArgumentNullException).GetConstructor(new System.Type[] { typeof(string) }), Expression.Constant("value")))));
				expressions.Add(
					Expression.IfThen(
						Expression.Equal(_minimum, Expression.Constant(null, typeof(T))),
						Expression.Throw(Expression.New(typeof(System.ArgumentNullException).GetConstructor(new System.Type[] { typeof(string) }), Expression.Constant("minimum")))));
				expressions.Add(
					Expression.IfThen(
						Expression.Equal(_maximum, Expression.Constant(null, typeof(T))),
						Expression.Throw(Expression.New(typeof(System.ArgumentNullException).GetConstructor(new System.Type[] { typeof(string) }), Expression.Constant("maximum")))));
			}
			// argument checks
			expressions.Add(
				Expression.IfThen(
					Expression.LessThan(_maximum, _minimum),
					Expression.Throw(Expression.New(typeof(System.ArithmeticException).GetConstructor(new System.Type[] { typeof(string) }), Expression.Constant("Compute.Clamp: !(minimum < maximum)")))));
			// code
			expressions.Add(
				Expression.IfThen(
					Expression.LessThan(_value, _minimum),
					Expression.Return(_label, _minimum, typeof(T))));
			expressions.Add(
				Expression.IfThen(
					Expression.LessThan(_maximum, _value),
					Expression.Return(_label, _maximum, typeof(T))));
			expressions.Add(
				Expression.Return(_label, _value, typeof(T)));
			expressions.Add(
				Expression.Label(_label, Expression.Constant(default(T), typeof(T))));
			// compilation
			Compute<T>.Clamp = Expression.Lambda<Compute<T>.Delegates.Clamp>(
				Expression.Block(expressions.ToArray()),
				_value, _minimum, _maximum).Compile();
			// invocation
			return Compute<T>.Clamp(value, minimum, maximum);
		};
		#endregion

		#region EqualsLeniency
		/// <summary>Checks for equality by value with a leniency.</summary>
		public static Compute<T>.Delegates.EqualsLeniency EqualsLeniency = (T left, T right, T leniency) =>
		{
			// compile checks
			if (!Meta.ValidateEqual<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.EqualsLeniency; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (==) operator.");
			if (!Meta.ValidateGreaterThan<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.EqualsLeniency; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks greater than (>) operator.");
			if (!Meta.ValidateAdd<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.EqualsLeniency; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks addition (+) operator.");
			// shared expressions
			ParameterExpression _left = Expression.Parameter(typeof(T));
			ParameterExpression _right = Expression.Parameter(typeof(T));
			ParameterExpression _leniency = Expression.Parameter(typeof(T));
			LabelTarget _label = Expression.Label(typeof(bool));
			// code builder
			ListLinked<Expression> expressions = new ListLinked<Expression>();
			// null checks
			if (!typeof(T).IsValueType) // is nullable?
			{
				expressions.Add(
					Expression.IfThen(
						Expression.Equal(_left, Expression.Constant(null, typeof(T))),
						Expression.Throw(Expression.New(typeof(System.ArgumentNullException).GetConstructor(new System.Type[] { typeof(string) }), Expression.Constant("left")))));
				expressions.Add(
					Expression.IfThen(
						Expression.Equal(_left, Expression.Constant(null, typeof(T))),
						Expression.Throw(Expression.New(typeof(System.ArgumentNullException).GetConstructor(new System.Type[] { typeof(string) }), Expression.Constant("right")))));
				expressions.Add(
					Expression.IfThen(
						Expression.Equal(_leniency, Expression.Constant(null, typeof(T))),
						Expression.Throw(Expression.New(typeof(System.ArgumentNullException).GetConstructor(new System.Type[] { typeof(string) }), Expression.Constant("leniency")))));
			}
			// code
			expressions.Add(
				Expression.IfThenElse(
					Expression.LessThan(_left, _right),
					Expression.Return(_label, Expression.GreaterThanOrEqual(Expression.Add(_left, _leniency), _right)),
					Expression.Return(_label, Expression.GreaterThanOrEqual(Expression.Add(_right, _leniency), _left))));
			expressions.Add(
				Expression.Label(_label, Expression.Constant(default(bool))));
			// compilation
			Compute<T>.EqualsLeniency = Expression.Lambda<Compute<T>.Delegates.EqualsLeniency>(
				Expression.Block(expressions.ToArray()),
				_left, _right, _leniency).Compile();
			// invocation
			return Compute<T>.EqualsLeniency(left, right, leniency);

			#region Alternate Version
//			// compile checks
//			if (!Meta.ValidateEqual<T>())
//				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.EqualsLeniency; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (==) operator.");
//			if (!Meta.ValidateLessThan<T>())
//				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.EqualsLeniency; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (<) operator.");
//			if (!Meta.ValidateSubtract<T>())
//				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.EqualsLeniency; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks subtraction (-) operator.");
//			// compilation
//			Compute<T>.EqualsLeniency2 =
//				Meta.Compile<Compute<T>.Delegates.EqualsLeniency>(
//					string.Concat(
//@"(", Type_String, " _left, ", Type_String, " _right, ", Type_String, @" _leniency) =>
//{
//		if (_left < _right)
//			return (_left + _leniency) > _right;
//		else
//			return (_right + _leniency) > _left;
//}"));
//			// invocation
//			return Compute<T>.EqualsLeniency2(left, right, leniency);
			#endregion

			#region Alternate Version
			//// compile checks
			//if (!Meta.ValidateEqual<T>())
			//	throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.EqualsLeniency; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (==) operator.");
			//if (!Meta.ValidateLessThan<T>())
			//	throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.EqualsLeniency; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (<) operator.");
			//if (!Meta.ValidateSubtract<T>())
			//	throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.EqualsLeniency; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks subtraction (-) operator.");
			//// compilation
			//Compute<T>.EqualsLeniency3 =
			//	(T _left, T _right, T _leniency) =>
			//	{
			//		if (Compute<T>.LessThan(_left, _right))
			//			return (Compute<T>.GreaterThan(Compute<T>.Add(_left, _leniency), _right));
			//		else
			//			return (Compute<T>.GreaterThan(Compute<T>.Add(_right, _leniency), _left));
			//	};
			//// invocation
			//return Compute<T>.EqualsLeniency3(left, right, leniency);
			#endregion
		};
		#endregion

		#region Compare
		/// <summary>Compares two operands of </summary>
		public static Compare<T> Compare = (T left, T right) =>
		{
			// compile checks
			if (!Meta.ValidateLessThan<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Compare; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (<) operator.");
			// compile the operation
			Compute<T>.Compare = Meta.BinaryOperationHelper<Compare<T>, T, T, Comparison>(
				(Expression _left, Expression _right, LabelTarget _returnLabel) =>
				{
					return Expression.Block(
						Expression.IfThen(
							Expression.LessThan(_left, _right),
							Expression.Return(_returnLabel, Expression.Constant(Comparison.Less))),
						Expression.IfThen(
							Expression.GreaterThan(_left, _right),
							Expression.Return(_returnLabel, Expression.Constant(Comparison.Greater))),
						Expression.Return(_returnLabel, Expression.Constant(Comparison.Equal)));
				});
			// invoke (recursion)
			return Compute<T>.Compare(left, right);

			#region Alternate Version
//			if (!Meta.ValidateLessThan<T>())
//				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Compare; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (<) operator.");
//			Compute<T>.Compare2 =
//				Meta.Compile<Compare<T>>(
//					string.Concat(
//	@"(", Type_String, " _left, ", Type_String, @" _right) =>
//{
//		if (_left < _right)
//			return Comparison.Less;
//		else if (_right < _left)
//			return Comparison.Greater;
//		else
//			return Comparison.Equal;
//}"));
//			return Compute<T>.Compare2(left, right);
			#endregion

			#region Alternate Version
			//if (!Meta.ValidateLessThan<T>()) { throw new System.ArithmeticException(string.Concat("computation requires a less than operator: ", Type_String, " >(", Type_String, ", ", Type_String, ")")); }

			//Compute<T>.Compare3 =
			//	(T _left, T _right) =>
			//	{
			//		if (Compute<T>.LessThan(_left, _right))
			//			return Comparison.Less;
			//		else if (Compute<T>.LessThan(_right, _left))
			//			return Comparison.Greater;
			//		else
			//			return Comparison.Equal;
			//	};

			//return Compute<T>.Compare3(left, right);
			#endregion
		};
		#endregion

		#region Equate
		public static Equate<T> Equate = (T left, T right) =>
		{
			// compile checks
			if (!Meta.ValidateEqual<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.Equate; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (==) operator.");
			// compile the operation
			Compute<T>.Equate = Meta.BinaryOperationHelper<Equate<T>, T, T, bool>(
				(Expression _left, Expression _right, LabelTarget _returnLabel) =>
				{
					return Expression.Return(_returnLabel, Expression.Equal(_left, _right));
				});
			// invoke (recursion)
			return Compute<T>.Equate(left, right);
		};
		#endregion

		#region LessThan
		public static Compute<T>.Delegates.LessThan LessThan = (T left, T right) =>
		{
			// compile checks
			if (!Meta.ValidateLessThan<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.LessThan; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (<) operator.");
			// compile the operation
			Compute<T>.LessThan = Meta.BinaryOperationHelper<Compute<T>.Delegates.LessThan, T, T, bool>(
				(Expression _left, Expression _right, LabelTarget _returnLabel) =>
				{
					return Expression.Return(_returnLabel, Expression.LessThan(_left, _right));
				});
			// invoke (recursion)
			return Compute<T>.LessThan(left, right);
		};
		#endregion

		#region Greater
		public static Compute<T>.Delegates.GreaterThan GreaterThan = (T left, T right) =>
		{
			// compile checks
			if (!Meta.ValidateLessThan<T>())
				throw new System.ArithmeticException("Cannot perform Compute<" + Meta.ConvertTypeToCsharpSource(typeof(T)) + ">.LessThan; " + Meta.ConvertTypeToCsharpSource(typeof(T)) + " lacks less than (<) operator.");
			// compile the operation
			Compute<T>.GreaterThan = Meta.BinaryOperationHelper<Compute<T>.Delegates.GreaterThan, T, T, bool>(
				(Expression _left, Expression _right, LabelTarget _returnLabel) =>
				{
					return Expression.Return(_returnLabel, Expression.GreaterThan(_left, _right));
				});
			// invoke (recursion)
			return Compute<T>.GreaterThan(left, right);
		};
		#endregion

		#region GreatestCommonFactor
		/// <summary>Computes (greatest common factor): [ GCF(set) ].</summary>
		public static Compute<T>.Delegates.GreatestCommonFactor GreatestCommonFactor = (Stepper<T> stepper) =>
		{
			Compute<T>.GreatestCommonFactor =
				Meta.Compile<Compute<T>.Delegates.GreatestCommonFactor>(
					string.Concat(
@"(Stepper<", T_source, @"> _stepper) =>
{
	if (_stepper == null) { throw new System.ArgumentNullException(", "\"stepper\"", @"); }
	bool assigned = false;
	", T_source, " gcf = (", T_source, @")0;
	_stepper((", T_source, @" n) =>
	{
		if (n % (", T_source, @")1 != 0)
			throw new Error(", "\"Attempting to find the Greatest Common Factor of a non-integer value.\"", @");
		if (!assigned)
		{
			gcf = Compute<", T_source, @">.AbsoluteValue(n);
			assigned = true;
		}
		else
		{
			if (gcf > (", T_source, @")1)
			{
				", T_source, @" a = gcf;
				", T_source, @" b = n;
				while (b != 0)
				{
					", T_source, @" remainder = a % b;
					a = b;
					b = remainder;
				}
				gcf = Compute<", T_source, @">.AbsoluteValue(a);
			}
		}
	});
	if (!assigned)
		throw new Error(", "\"No parameters provided in GCF function.\"", @");
	return gcf;
}"));

			return Compute<T>.GreatestCommonFactor(stepper);
		};
		#endregion

		#region LeastCommonMultiple
		/// <summary>Computes (least common multiple): [ LCM(set) ].</summary>
		public static Compute<T>.Delegates.LeastCommonMultiple LeastCommonMultiple = (Stepper<T> stepper) =>
		{
			Compute<T>.LeastCommonMultiple =
				Meta.Compile<Compute<T>.Delegates.LeastCommonMultiple>(
					string.Concat(
@"(Stepper<", T_source, @"> _stepper) =>
{
	if (_stepper == null) { throw new Error(", "\"Null reference: stepper\"", @"); }
	bool assigned = false;
	", T_source, " lcm = (", T_source, @")0;
	_stepper((", T_source, @" n) =>
	{
		if (n == 0)
		{
			lcm = 0;
			return;
		}
		if (n % (", T_source, @")1 != 0)
			throw new Error(", "\"Attempting to find the Greatest Common Factor of a non-integer value.\"", @");
		if (!assigned)
		{
			lcm = Compute<", T_source, @">.AbsoluteValue(n);
			assigned = true;
		}
		else
		{
			if (lcm > (", T_source, @")1)
			{
				lcm = Compute<", T_source, ">.AbsoluteValue((lcm / Compute<", T_source, ">.GreatestCommonFactor((Step<", T_source, @"> step) => { step(lcm); step(n); })) * n);
			}
		}
	});
	if (!assigned)
		throw new Error(", "\"No parameters provided in LCM function.\"", @");
	return lcm;
}"));

			return Compute<T>.LeastCommonMultiple(stepper);
		};
		#endregion

		#region FactorPrimes
		/// <summary>Computes the prime factors of n.</summary>
		public static Compute<T>.Delegates.FactorPrimes FactorPrimes = (T value, Step<T> step) =>
		{
			Compute<T>.FactorPrimes =
				Meta.Compile<Compute<T>.Delegates.FactorPrimes>(
					string.Concat(
@"(", T_source, " _value, Step<", T_source, @"> _step) =>
{
	", T_source, @" __value = _value;
	if (__value % (", T_source, ")1 != (", T_source, @")0)
		throw new Error(", "\"Attempting to get the pime factors of a non integer\"", @");
	if (__value < 0)
	{
		__value = -__value;
		_step((", T_source, @")(-1));
	}
	while (__value % (", T_source, ")2 == (", T_source, @")0)
	{
		_step((", T_source, @")2);
		__value /= (", T_source, @")2;
	}
	for (", T_source, @" i = 3; i <= Compute<", T_source, ">.SquareRoot(__value); i += (", T_source, @")2)
	{
		while (__value % i == 0)
		{
			_step(i);
			__value = __value / i;
		}
	}
	if (__value > ((", T_source, @")2))
		_step(__value);
}"));

			Compute<T>.FactorPrimes(value, step);
		};
		#endregion

		#region Exponential
		/// <summary>Computes: [ e ^ x ].</summary>
		public static Compute<T>.Delegates.Exponential Exponential = (T value) =>
		{
			Compute<T>.Exponential =
				Meta.Compile<Compute<T>.Delegates.Exponential>(
					string.Concat("(", T_source, " _value) => { return (", T_source, ")System.Math.Sqrt((double)_value); }"));

			return Compute<T>.Exponential(value);
		};
		#endregion

		#region Natural Logarithm
		/// <summary>Computes (natrual log): [ ln(n) ].</summary>
		public static Compute<T>.Delegates.NaturalLogarithm NaturalLogarithm = (T value) =>
		{
			Compute<T>.NaturalLogarithm =
				Meta.Compile<Compute<T>.Delegates.NaturalLogarithm>(
					string.Concat("(", T_source, " _value) => { throw new Error(\"not yet implemented\"); }"));

			return Compute<T>.NaturalLogarithm(value);
		};
		#endregion

		#region IsPrime
		/// <summary>Computes (natrual log): [ ln(n) ].</summary>
		public static Compute<T>.Delegates.IsPrime IsPrime = (T value) =>
		{
			Compute<T>.IsPrime =
				Meta.Compile<Compute<T>.Delegates.IsPrime>(
					string.Concat(
@"(", T_source, @" candidate) =>
{
	if (candidate % (", T_source, @")1 == 0)
	{
		if (candidate == 2)
			return true;
		", T_source, @" squareRoot = Compute<", T_source, @">.SquareRoot(candidate);
		for (int divisor = 3; divisor <= squareRoot; divisor += 2)
			if ((candidate % divisor) == 0)
				return false;
		return true;
	}
	else
		return false;
}"));

			return Compute<T>.IsPrime(value);
		};
		#endregion

		#region Invert
		/// <summary>Computes: [ 1 / n ].</summary>
		public static Compute<T>.Delegates.Invert invert = (T value) =>
		{
			if (!Meta.ValidateDivide<T>()) { throw new System.ArithmeticException(string.Concat("computation requires a division operator: ", T_source, " /(", T_source, ", ", T_source, ")")); }

			Compute<T>.invert =
				Meta.Compile<Compute<T>.Delegates.Invert>(
					string.Concat("(", T_source, " _value) => { return 1 / _value; }"));

			return Compute<T>.invert(value);
		};
		#endregion

		#region LinearInterpolation
		/// <summary>Interpolates in a linear fashion.</summary>
		public static Compute<T>.Delegates.LinearInterpolation LinearInterpolation = (T x, T x0, T x1, T y0, T y1) =>
			{
				Compute<T>.LinearInterpolation =
					Meta.Compile<Compute<T>.Delegates.LinearInterpolation>(
						string.Concat(
@"(", T_source, " _x, ", T_source, " _x0, ", T_source, " _x1, ", T_source, " _y0, ", T_source, @" _y1) =>
{
	if (_x0 > _x1)
		throw new Error(", "\"invalid arguments: x0 > x1\"", @");
	else if (_x < _x0)
		throw new Error(", "\"invalid arguments: x < x0\"", @");
	else if (_x > _x1)
		throw new Error(", "\"invalid arguments: x > x1\"", @");
	else if (_x0 == _x1)
		if (_y0 != _y1)
			throw new Error(", "\"invalid arguments: _x0 == _x1 && _y0 != _y1\"", @");
		else
			return _y0;
	else
		return _y0 + (_x - _x0) * (_y1 - _y0) / (_x1 - _x0);
}"));

				return Compute<T>.LinearInterpolation(x, x0, x1, y0, y1);
			};
		#endregion

		#region Factorial
		/// <summary>Computes: [ N! ].</summary>
		public static Compute<T>.Delegates.Factorial Factorial = (T value) =>
		{
			Compute<T>.Factorial =
				Meta.Compile<Compute<T>.Delegates.Factorial>(
					string.Concat(
@"(", T_source, @" N) =>
{
	if (N % 1 != 0)
		throw new Error(", "\"invalid factorial: N must be a whole number.\"", @");
	if (N < 0)
		throw new Error(", "\"invalid factorial: [ N < 0 ] (N = \\\" + N + \\\").\"", @");
	", T_source, @" result = 1;
	for (; N > 1; N--)
		result *= N;
	return result;
}"));

			return Compute<T>.Factorial(value);
		};

		///// <summary>Computes: [ N! ].</summary>
		//public static Compute<T>.Delegates.Factorial Factorial2 = (T value) =>
		//{
		//	Compute<T>.Factorial2 =
		//		(T N) =>
		//		{
		//			if (N % 1 != 0)
		//				throw new Error("invalid factorial: N must be a whole number.");
		//			if (N < 0)
		//				throw new Error("invalid factorial: [ N < 0 ] (N = \\\" + N + \\\").");
		//			T result = 1;
		//			for (; N > 1; N--)
		//				result *= N;
		//			return result;
		//		};

		//	return Compute<T>.Factorial2(value);
		//};
		#endregion

		#region Combinations
		/// <summary>Computes: [ N! / (n[0]! + n[1]! + n[3]! ...) ].</summary>
		public static Compute<T>.Delegates.Combinations Combinations = (T N, T[] n) =>
		{
			Compute<T>.Combinations =
				Meta.Compile<Compute<T>.Delegates.Combinations>(
					string.Concat(
@"(", T_source, " _N, ", T_source, @"[] _n) =>
{
	if (_N % 1 != 0)
		throw new Error(", "\"invalid combination: N must be a whole number.\"", @");
	for (int i = 0; i < _n.Length; i++)
		if (_n[i] % 1 != 0)
			throw new Error(", "\"invalid combination: n[\\\" + i + \\\"] must be a whole number.\"", @");
	", T_source, " result = Compute<", T_source, @">.Factorial(_N);
	", T_source, @" sum = 0;
	for (int i = 0; i < _n.Length; i++)
	{
		result /= Compute<", T_source, @">.Factorial(_n[i]);
		sum += _n[i];
	}
	if (sum > _N)
		throw new Error(", "\"invalid combination: [ N < Sum(n) ].\"", @");
	return result;
}"));

			return Compute<T>.Combinations(N, n);
		};
		#endregion

		#region Choose
		/// <summary>Computes: [ N! / (N - n)! ]</summary>
		public static Compute<T>.Delegates.Choose Choose = (T N, T n) =>
		{
			Compute<T>.Choose =
				Meta.Compile<Compute<T>.Delegates.Choose>(
					string.Concat(
@"(", T_source, " _N, ", T_source, @" _n) =>
{
	if (_N % 1 != 0)
		throw new Error(", "\"invalid chose: N must be a whole number.\"", @");
	if (_n % 1 != 0)
		throw new Error(", "\"invalid combination: n must be a whole number.\"", @");
	if (!(_N <= _n || _N >= 0))
		throw new Error(", "\"invalid choose: [ !(N <= n || N >= 0) ].\"", @");
	", T_source, " factorial_N = Compute<", T_source, @">.Factorial(_N);
	return Compute<", T_source, ">.Factorial(_N) / (Compute<", T_source, ">.Factorial(_n) * Compute<", T_source, @">.Factorial(_N - _n));
}"));

			return Compute<T>.Choose(N, n);
		};
		#endregion

		#region Mode
		/// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
		public static Compute<T>.Delegates.Mode Mode = (Stepper<T> stepper) =>
		{
			string heap_type = typeof(HeapArray<Link<T, int>>).ToCsharpSource();
			string link_type = typeof(Link<T, int>).ToCsharpSource();
			Compute<T>.Mode =
				Meta.Compile<Compute<T>.Delegates.Mode>(
					string.Concat(
@"(Stepper<", T_source, @"> stepper) =>
{
	", heap_type, @" heap =
		new ", heap_type, @"(
			(Link<", T_source, ", int> left, Link<", T_source, @", int> right) =>
			{
				return Compute<", T_source, @">.Compare(left.One, right.One);
			});
	stepper((", T_source, @" step) =>
	{
		bool contains = false;
		heap.Stepper((", link_type, @" nested_step) =>
		{
			if (Compute<", T_source, @">.Equate(nested_step.One, step))
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
			heap.Enqueue(new ", link_type, @"(step, 1));
	});
	return heap;
}"));

			return Compute<T>.Mode(stepper);
		};
		#endregion

		#region Mean
		/// <summary>Computes the mean (or average) between multiple values.</summary>
		public static Compute<T>.Delegates.Mean Mean = (Stepper<T> stepper) =>
		{
			Compute<T>.Mean =
				Meta.Compile<Compute<T>.Delegates.Mean>(
					string.Concat(
@"(Stepper<", T_source, @"> stepper) =>
{
	", T_source, @" i = 0;
	", T_source, @" sum = 0;
	stepper((", T_source, @" step) => { i++; sum += step; });
	return sum / i;
}"));

			return Compute<T>.Mean(stepper);
		};
		#endregion

		#region Median
		/// <summary>Computes the median of a set of values.</summary>
		public static Compute<T>.Delegates.Median Median = (Stepper<T> stepper) =>
		{
			Compute<T>.Median =
				Meta.Compile<Compute<T>.Delegates.Median>(
					string.Concat(
@"(Stepper<", T_source, @"> _stepper) =>
{
	long count =	0;
	_stepper((", T_source, @" step) => { count++; });
	long half = count / 2;
	if (count % 1 == 0)
	{
		", T_source, " left = default(", T_source, @");
		", T_source, " right = default(", T_source, @");
		count = 0;
		_stepper((", T_source, @" step) =>
		{
			if (count == half)
				left = step;
			else if (count == half + 1)
				right = step;
			count++;
		});
		return (left + right) / (", T_source, @")2;
	}
	else
	{
		", T_source, " median = default(", T_source, @");
		_stepper((", T_source, @" i) =>
		{
			count = 0;
			_stepper((", T_source, @" step) =>
			{
				if (count == half)
					median = step;
				count++;
			});
		});
		return median;
	}
}"));

			return Compute<T>.Median(stepper);
		};
		#endregion

		#region GeometricMean
		/// <summary>Computes the median of a set of values.</summary>
		public static Compute<T>.Delegates.GeometricMean GeometricMean = (Stepper<T> stepper) =>
		{
			Compute<T>.GeometricMean =
				Meta.Compile<Compute<T>.Delegates.GeometricMean>(
					string.Concat(
@"(Stepper<", T_source, @"> _stepper) =>
{
	", T_source, @" multiple = 1;
	int count = 0;
	_stepper((", T_source, @" current) =>
	{
		count++;
		multiple *= current;
	});
	return Compute<", T_source, ">.Root(multiple, (", T_source, @")count);
}"));

			return Compute<T>.GeometricMean(stepper);
		};
		#endregion

		#region Variance
		/// <summary>Computes the variance of a set of values.</summary>
		public static Compute<T>.Delegates.Variance Variance = (Stepper<T> stepper) =>
		{
			Compute<T>.Variance =
				Meta.Compile<Compute<T>.Delegates.Variance>(
					"(Stepper<" + T_source + "> _stepper) =>" +
					"{" +
 "	if (_stepper == null)" +
					"		throw new Error(\"null reference: _stepper\");" +
 "	" + T_source + " mean = Compute<" + T_source + ">.Mean(_stepper);" +
					"	" + T_source + " variance = 0;" +
					"	int count = 0;" +
					"	_stepper((" + T_source + " i) =>" +
					"		{" +
					"			" + T_source + " i_minus_mean = i - mean;" +
					"			variance += i_minus_mean * i_minus_mean;" +
					"			count++;" +
					"		});" +
					"	return variance / (" + T_source + ")count;" +
					"}");

			return Compute<T>.Variance(stepper);
		};
		#endregion

		#region StandardDeviation
		/// <summary>Computes the standard deviation of a set of values.</summary>
		public static Compute<T>.Delegates.StandardDeviation StandardDeviation = (Stepper<T> stepper) =>
		{
			Compute<T>.StandardDeviation =
				Meta.Compile<Compute<T>.Delegates.StandardDeviation>(
					string.Concat(
@"(Stepper<", T_source, @"> _stepper) =>
{",
@"	if (_stepper == null)
		throw new Error(", "\"null reference: _stepper\");",
@"	return Compute<", T_source, ">.SquareRoot(Compute<", T_source, @">.Variance(_stepper));
}"));

			return Compute<T>.StandardDeviation(stepper);
		};
		#endregion

		#region MeanDeviation
		/// <summary>Computes the mean deviation of a set of values.</summary>
		/// <see cref="Seven.Mathematics.Logic<T>.abs"/>
		/// <see cref="Seven.Mathematics.Compute<T>.Mean"/>
		public static Compute<T>.Delegates.MeanDeviation MeanDeviation = (Stepper<T> stepper) =>
		{
			Compute<T>.MeanDeviation =
				Meta.Compile<Compute<T>.Delegates.MeanDeviation>(
					string.Concat(
@"(Stepper<", T_source, @"> _stepper) =>
{
	", T_source, " mean = Compute<", T_source, @">.Mean(_stepper);
	", T_source, @" temp = 0;
	int count = 0;
	_stepper((", T_source, @" i) =>
	{
		temp += Compute<", T_source, @">.AbsoluteValue(i - mean);
		count++;
	});
	return temp / (", T_source, @")count;
}"));

			return Compute<T>.MeanDeviation(stepper);
		};
		#endregion

		#region Range
		/// <summary>Computes the standard deviation of a set of values.</summary>
		public static Compute<T>.Delegates.Range Range = (Stepper<T> stepper) =>
		{
			Compute<T>.Range =
				Meta.Compile<Compute<T>.Delegates.Range>(
					string.Concat(
@"(Stepper<", T_source, @"> _stepper) =>
{
	bool set = false;
	", T_source, @" temp_min = 0;
	", T_source, @" temp_max = 0;
	_stepper((", T_source, @" i) =>
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
	return new Range<", T_source, @">(temp_min, temp_max);
}"));

			return Compute<T>.Range(stepper);
		};
		#endregion

		#region Quantiles
		/// <summary>Computes the quantiles of a set of values.</summary>
		public static Compute<T>.Delegates.Quantiles Quantiles = (int quantiles, Stepper<T> stepper) =>
		{
			Compute<T>.Quantiles =
				Meta.Compile<Compute<T>.Delegates.Quantiles>(
					string.Concat(
@"(int _quantiles, Stepper<", T_source, @"> _stepper) =>
{",
@"	if (_stepper == null)
		throw new Error(", "\"null reference: _stepper\"", @");
	if (_quantiles < 1)
		throw new Error(", "\"invalid numer of dimensions on Quantile division\");",
@"	int count = 0;
	_stepper((", T_source, @" i) => { count++; });
	", T_source, "[] ordered = new ", T_source, @"[count];
	int a = 0;
	_stepper((", T_source, @" i) => { ordered[a++] = i; });
	Algorithms.Sort.Quick<" + T_source + @">(Logic.compare, ordered);
	", T_source, "[] __quantiles = new ", T_source, @"[_quantiles + 1];
	__quantiles[0] = ordered[0];
	__quantiles[__quantiles.Length - 1] = ordered[ordered.Length - 1];
	for (int i = 1; i < _quantiles; i++)
	{
		", T_source, " temp = (ordered.Length / (", T_source, @")(_quantiles + 1)) * i;
		if (temp % 1 == 0)
			__quantiles[i] = ordered[(int)temp];
		else
			__quantiles[i] = (ordered[(int)temp] + ordered[(int)temp + 1]) / (", T_source, @")2;
	}
	return __quantiles;
}"));

			return Compute<T>.Quantiles(quantiles, stepper);
		};
		#endregion

		#region Correlation
		/// <summary>Computes the median of a set of values.</summary>
		public static Compute<T>.Delegates.Correlation Correlation = (Stepper<T> a, Stepper<T> b) =>
		{
			throw new Error("I introduced an error here when I removed the stepref off of structure. will fix soon - seven");

			Compute<T>.Correlation =
				Meta.Compile<Compute<T>.Delegates.Correlation>(
					string.Concat(
@"(Stepper<", T_source, "> _a, Stepper<", T_source, @"> _b) =>
{
	", T_source, " a_mean = Compute<", T_source, @">.Mean(_a);
	", T_source, " b_mean = Compute<", T_source, @">.Mean(_b);
	List<", T_source, "> a_temp = new List_Linked<", T_source, @">();
	_a((", T_source, @" i) => { a_temp.Add(i - b_mean); });
	List<", T_source, "> b_temp = new List_Linked<", T_source, @">();
	_b((", T_source, @" i) => { b_temp.Add(i - a_mean); });
	", T_source, "[] a_cross_b = new ", T_source, @"[a_temp.Count * b_temp.Count];
	int count = 0;
	a_temp.Stepper((", T_source, @" i_a) =>
	{
		b_temp.Stepper((", T_source, @" i_b) =>
		{
			a_cross_b[count++] = i_a * i_b;
		});
	});
	a_temp.Stepper((ref ", T_source, @" i) => { i *= i; });
	b_temp.Stepper((ref ", T_source, @" i) => { i *= i; });
	", T_source, @" sum_a_cross_b = 0;
	foreach (", T_source, @" i in a_cross_b)
		sum_a_cross_b += i;
	", T_source, @" sum_a_temp = 0;
	a_temp.Stepper((", T_source, @" i) => { sum_a_temp += i; });
	", T_source, @" sum_b_temp = 0;
	b_temp.Stepper((", T_source, @" i) => { sum_b_temp += i; });
	return sum_a_cross_b / Compute<", T_source, @">.sqrt(sum_a_temp * sum_b_temp);
}"));

			return Compute<T>.Correlation(a, b);
		};
		#endregion

		#region Sine
		/// <summary>Computes the ratio [length of the side opposite to the angle / hypotenuse] in a right triangle.</summary>
		public static Compute<T>.Delegates.Sine Sine = (Angle<T> angle) =>
		{
			if (typeof(T) == typeof(double)) // double optimization
				Compute<double>.Sine = (Angle<double> _angle) => { return System.Math.Sin(_angle.Radians); };
			else if (typeof(T) == typeof(float)) // float optimization
				Compute<float>.Sine = (Angle<float> _angle) => { return (float)System.Math.Sin(_angle.Radians); };
			else // Generic Implementation
			{
				// Series: sin(x) = x - x^3/3! + x^5/5! - x^7/7! ...
				// more terms in computation inproves accuracy

				Compute<T>.Sine =
					Meta.Compile<Compute<T>.Delegates.Sine>(
						string.Concat(
@"(", T_source, @" _angle) =>
{
	// get the angle into the positive unit circle
	_angle = _angle % (Compute<", T_source, @">.Pi * 2);
	if (_angle < 0)
		_angle = (Compute<", T_source, @">.Pi * 2) + _angle;
	if (_angle <= Compute<", T_source, @">.Pi / 2)
		goto QuandrantSkip;
	else if (_angle <= Compute<", T_source, @">.Pi)
		_angle = (Compute<", T_source, ">.Pi / 2) - (_angle % (Compute<", T_source, @">.Pi / 2));
	else if (_angle <= (Compute<", T_source, @">.Pi * 3) / 2)
		_angle = _angle % Compute<", T_source, @">.Pi;
	else
		_angle = (Compute<", T_source, ">.Pi / 2) - (_angle % (Compute<", T_source, @">.Pi / 2));
QuandrantSkip:
	", T_source, @" three_factorial = 6;
	", T_source, @" five_factorial = 120;
	", T_source, @" seven_factorial = 5040;
	", T_source, @" angleCubed = _angle * _angle * _angle;
	", T_source, @" angleToTheFifth = angleCubed * _angle * _angle;
	", T_source, @" angleToTheSeventh = angleToTheFifth * _angle * _angle;
	return -(_angle
		- (angleCubed / three_factorial)
		+ (angleToTheFifth / five_factorial)
		- (angleToTheSeventh / seven_factorial));
}"));
			}

			return Compute<T>.Sine(angle);
		};
		#endregion

		#region Cosine
		/// <summary>Computes the ratio [length of the side adjacent to the angle / hypotenuse] in a right triangle.</summary>
		public static Compute<T>.Delegates.Cosine Cosine = (Angle<T> angle) =>
		{
			// rather than computing cos, you could do a phase shift and use sin
			// return Sin(angle + (Pi / 2));

			if (typeof(T) == typeof(double)) // double optimization
				Compute<double>.Cosine = (Angle<double> _angle) => { return System.Math.Cos(_angle.Radians); };
			else if (typeof(T) == typeof(float)) // float optimization
				Compute<float>.Cosine = (Angle<float> _angle) => { return (float)System.Math.Cos(_angle.Radians); };
			else
			{
				// Series: cos(x) = 1 - x^2/2! + x^4/4! - x^6/6! ...
				// more terms in computation inproves accuracy

				Compute<T>.Cosine =
					Meta.Compile<Compute<T>.Delegates.Cosine>(
					string.Concat(
@"(", T_source, @" _angle) =>
{
	// get the angle into the positive unit circle
	_angle = _angle % (Compute<", T_source, @">.Pi * 2);
	if (_angle < 0)
		_angle = (Compute<", T_source, @">.Pi * 2) + _angle;
	if (_angle <= Compute<", T_source, @">.Pi / 2)
		goto QuandrantSkip;
	else if (_angle <= Compute<", T_source, @">.Pi)
		_angle = (Compute<", T_source, ">.Pi / 2) - (_angle % (Compute<", T_source, @">.Pi / 2));
	else if (_angle <= (Compute<", T_source, @">.Pi * 3) / 2)
		_angle = _angle % Compute<", T_source, @">.Pi;
	else
		_angle = (Compute<", T_source, ">.Pi / 2) - (_angle % (Compute<", T_source, @">.Pi / 2));
QuandrantSkip:
	", T_source, @" one = 1;
	", T_source, @" two_factorial = 2;
	", T_source, @" four_factorial = 24;
	", T_source, @" six_factorial = 720;
	", T_source, @" angleSquared = _angle * _angle;
	", T_source, @" angleToTheFourth = angleSquared * _angle * _angle;
	", T_source, @" angleToTheSixth = angleToTheFourth * _angle * _angle;
	return one
		- (angleSquared / two_factorial)
		+ (angleToTheFourth / four_factorial)
		- (angleToTheSixth / six_factorial);
}"));
			}

			return Compute<T>.Cosine(angle);
		};
		#endregion

		#region Tangent
		/// <summary>Computes the ratio [length of the side opposite to the angle / length of the side adjacent to the angle] in a right triangle.</summary>
		public static Compute<T>.Delegates.Tangent Tangent = (Angle<T> angle) =>
		{
			if (typeof(T) == typeof(double)) // double optimization
				Compute<double>.Tangent = (Angle<double> _angle) => { return System.Math.Tan(_angle.Radians); };
			else if (typeof(T) == typeof(float)) // float optimization
				Compute<float>.Tangent = (Angle<float> _angle) => { return (float)System.Math.Tan(_angle.Radians); };
			else
			{
				// Series: tan(x) = x + x^3/3 + 2x^5/15 + 17x^7/315 ...
				// more terms in computation inproves accuracy

				Compute<T>.Tangent =
					Meta.Compile<Compute<T>.Delegates.Tangent>(
						"(" + T_source + " _angle) =>" +
						"{" +
						"	// get the angle into the positive unit circle" +
						"	_angle = _angle % (Compute<" + T_source + ">.Pi * 2);" +
						"	if (_angle < 0)" +
						"		_angle = (Compute<" + T_source + ">.Pi * 2) + _angle;" +
						"	if (_angle <= Compute<" + T_source + ">.Pi / 2) // quadrant 1" +
						"		goto QuandrantSkip;" +
						"	else if (_angle <= Compute<" + T_source + ">.Pi) // quadrant 2" +
						"		_angle = (Compute<" + T_source + ">.Pi / 2) - (_angle % (Compute<" + T_source + ">.Pi / 2));" +
						"	else if (_angle <= (Compute<" + T_source + ">.Pi * 3) / 2) // quadrant 3" +
						"		_angle = _angle % Compute<" + T_source + ">.Pi;" +
						"	else // quadrant 4" +
						"		_angle = (Compute<" + T_source + ">.Pi / 2) - (_angle % (Compute<" + T_source + ">.Pi / 2));" +
						"QuandrantSkip:" +
						"	// do the computation" +
						"	" + T_source + " two = 2;" +
						"	" + T_source + " three = 3;" +
						"	" + T_source + " fifteen = 15;" +
						"	" + T_source + " seventeen = 17;" +
						"	" + T_source + " threehundredfifteen = 315;" +
						"	" + T_source + " angleCubed = _angle * _angle * _angle; // angle ^ 3" +
						"	" + T_source + " angleToTheFifth = angleCubed * _angle * _angle; // angle ^ 5" +
						"	" + T_source + " angleToTheSeventh = angleToTheFifth * _angle * _angle;  // angle ^ 7" +
						"	return angle" +
						"		+ (angleCubed / three)" +
						"		+ (two * angleToTheFifth / fifteen)" +
						"		+ (seventeen * angleToTheSeventh / threehundredfifteen);" +
						"}");
			}

			return Compute<T>.Tangent(angle);
		};
		#endregion

		#region Cosecant
		/// <summary>Computes the ratio [hypotenuse / length of the side opposite to the angle] in a right triangle.</summary>
		public static Compute<T>.Delegates.Cosecant Cosecant = (Angle<T> angle) =>
		{
			// Series: csc(x) = x^-1 + x/6 + 7x^3/360 + 31x^5/15120 ...
			// more terms in computation inproves accuracy

			Compute<T>.Cosecant =
				Meta.Compile<Compute<T>.Delegates.Cosecant>(
					"(" + T_source + " _angle) =>" +
					"{" +
					"	return (" + T_source + ")1 / Compute<" + T_source + ">.Sine(_angle);" +
					"}");

			return Compute<T>.Cosecant(angle);
		};
		#endregion

		#region Secant
		/// <summary>Computes the ratio [hypotenuse / length of the side adjacent to the angle] in a right triangle.</summary>
		public static Compute<T>.Delegates.Secant Secant = (Angle<T> angle) =>
		{
			// Series: sec(x) = ...
			// more terms in computation inproves accuracy

			Compute<T>.Secant =
				Meta.Compile<Compute<T>.Delegates.Secant>(
					"(" + T_source + " _angle) =>" +
					"{" +
					"	return (" + T_source + ")1 / Compute<" + T_source + ">.Cosine(_angle);" +
					"}");

			return Compute<T>.Secant(angle);
		};
		#endregion

		#region Cotangent
		/// <summary>Computes the ratio [length of the side adjacent to the angle / length of the side opposite to the angle] in a right triangle.</summary>
		public static Compute<T>.Delegates.Cotangent Cotangent = (Angle<T> angle) =>
		{
			// Series: cot(x) = ...
			// more terms in computation inproves accuracy

			Compute<T>.Cotangent =
				Meta.Compile<Compute<T>.Delegates.Cotangent>(
					"(" + T_source + " _angle) =>" +
					"{" +
					"	return (" + T_source + ")1 / Compute<" + T_source + ">.Tangent(_angle);" +
					"}");

			return Compute<T>.Cotangent(angle);
		};
		#endregion

		#region InverseSine
		public static Compute<T>.Delegates.InverseSine InverseSine = (T ratio) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.InverseSine = (double _ratio) => { return Angle<double>.Factory_Radians(System.Math.Asin(_ratio)); };
			else if (typeof(T) == typeof(float))
				Compute<float>.InverseSine = (float _ratio) => { return Angle<float>.Factory_Radians((float)System.Math.Asin(_ratio)); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.InverseSine(ratio);
		};
		#endregion

		#region InverseCosine
		public static Compute<T>.Delegates.InverseCosine InverseCosine = (T ratio) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.InverseCosine = (double _ratio) => { return Angle<double>.Factory_Radians(System.Math.Acos(_ratio)); };
			else if (typeof(T) == typeof(float))
				Compute<float>.InverseCosine = (float _ratio) => { return Angle<float>.Factory_Radians((float)System.Math.Acos(_ratio)); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.InverseCosine(ratio);
		};
		#endregion

		#region InverseTangent
		public static Compute<T>.Delegates.InverseTangent InverseTangent = (T ratio) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.InverseTangent = (double _ratio) => { return Angle<double>.Factory_Radians(System.Math.Atan(_ratio)); };
			else if (typeof(T) == typeof(float))
				Compute<float>.InverseTangent = (float _ratio) => { return Angle<float>.Factory_Radians((float)System.Math.Atan(_ratio)); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.InverseTangent(ratio);
		};
		#endregion

		#region InverseCosecant
		public static Compute<T>.Delegates.InverseCosecant InverseCosecant = (T ratio) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.InverseCosecant = (double _ratio) => { return Angle<double>.Factory_Radians(System.Math.Asin(1d / _ratio)); };
			else if (typeof(T) == typeof(float))
				Compute<float>.InverseCosecant = (float _ratio) => { return Angle<float>.Factory_Radians((float)System.Math.Asin(1f / _ratio)); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.InverseCosecant(ratio);
		};
		#endregion

		#region InverseSecant
		public static Compute<T>.Delegates.InverseSecant InverseSecant = (T ratio) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.InverseSecant = (double _ratio) => { return Angle<double>.Factory_Radians(System.Math.Acos(1d / _ratio)); };
			else if (typeof(T) == typeof(float))
				Compute<float>.InverseSecant = (float _ratio) => { return Angle<float>.Factory_Radians((float)System.Math.Acos(1f / _ratio)); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.InverseSecant(ratio);
		};
		#endregion

		#region InverseCotangent
		public static Compute<T>.Delegates.InverseCotangent InverseCotangent = (T ratio) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.InverseCotangent = (double _ratio) => { return Angle<double>.Factory_Radians(System.Math.Atan(1d / _ratio)); };
			else if (typeof(T) == typeof(float))
				Compute<float>.InverseCotangent = (float _ratio) => { return Angle<float>.Factory_Radians((float)System.Math.Atan(1f / _ratio)); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.InverseCotangent(ratio);
		};
		#endregion

		#region HyperbolicSine
		public static Compute<T>.Delegates.HyperbolicSine HyperbolicSine = (Angle<T> angle) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.HyperbolicSine = (Angle<double> _angle) => { return System.Math.Sinh(_angle.Radians); };
			else if (typeof(T) == typeof(float))
				Compute<float>.HyperbolicSine = (Angle<float> _angle) => { return (float)System.Math.Sinh(_angle.Radians); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.HyperbolicSine(angle);
		};
		#endregion

		#region HyperbolicCosine
		public static Compute<T>.Delegates.HyperbolicCosine HyperbolicCosine = (Angle<T> angle) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.HyperbolicCosine = (Angle<double> _angle) => { return System.Math.Cosh(_angle.Radians); };
			else if (typeof(T) == typeof(float))
				Compute<float>.HyperbolicCosine = (Angle<float> _angle) => { return (float)System.Math.Cosh(_angle.Radians); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.HyperbolicCosine(angle);
		};
		#endregion

		#region HyperbolicTangent
		public static Compute<T>.Delegates.HyperbolicTangent HyperbolicTangent = (Angle<T> angle) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.HyperbolicTangent = (Angle<double> _angle) => { return System.Math.Tanh(_angle.Radians); };
			else if (typeof(T) == typeof(float))
				Compute<float>.HyperbolicTangent = (Angle<float> _angle) => { return (float)System.Math.Tanh(_angle.Radians); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.HyperbolicTangent(angle);
		};
		#endregion

		#region HyperbolicSecant
		public static Compute<T>.Delegates.HyperbolicSecant HyperbolicSecant = (Angle<T> angle) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.HyperbolicSecant = (Angle<double> _angle) => { return 1d / System.Math.Cosh(_angle.Radians); };
			else if (typeof(T) == typeof(float))
				Compute<float>.HyperbolicSecant = (Angle<float> _angle) => { return 1f / (float)System.Math.Cosh(_angle.Radians); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.HyperbolicSecant(angle);
		};
		#endregion

		#region HyperbolicCosecant
		public static Compute<T>.Delegates.HyperbolicCosecant HyperbolicCosecant = (Angle<T> angle) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.HyperbolicCosecant = (Angle<double> _angle) => { return 1d / System.Math.Sinh(_angle.Radians); };
			else if (typeof(T) == typeof(float))
				Compute<float>.HyperbolicCosecant = (Angle<float> _angle) => { return 1f / (float)System.Math.Sinh(_angle.Radians); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.HyperbolicCosecant(angle);
		};
		#endregion

		#region HyperbolicCotangent
		public static Compute<T>.Delegates.HyperbolicCotangent HyperbolicCotangent = (Angle<T> angle) =>
		{
			if (typeof(T) == typeof(double))
				Compute<double>.HyperbolicCotangent = (Angle<double> _angle) => { return 1d / System.Math.Tanh(_angle.Radians); };
			else if (typeof(T) == typeof(float))
				Compute<float>.HyperbolicCotangent = (Angle<float> _angle) => { return 1f / (float)System.Math.Tanh(_angle.Radians); };
			else
				throw new Error("unsupported parameter type for Cot function");

			return Compute<T>.HyperbolicCotangent(angle);
		};
		#endregion

		#region InverseHyperbolicSine
		public static Compute<T>.Delegates.InverseHyperbolicSine InverseHyperbolicSine = (T ratio) =>
		{
			throw new Error("not implemented");
		};
		#endregion

		#region InverseHyperbolicCosine
		public static Compute<T>.Delegates.InverseHyperbolicCosine InverseHyperbolicCosine = (T ratio) =>
		{
			throw new Error("not implemented");
		};
		#endregion

		#region InverseHyperbolicTangent
		public static Compute<T>.Delegates.InverseHyperbolicTangent InverseHyperbolicTangent = (T ratio) =>
		{
			throw new Error("not implemented");
		};
		#endregion

		#region InverseHyperbolicCosecant
		public static Compute<T>.Delegates.InverseHyperbolicCosecant InverseHyperbolicCosecant = (T ratio) =>
		{
			throw new Error("not implemented");
		};
		#endregion

		#region InverseHyperbolicSecant
		public static Compute<T>.Delegates.InverseHyperbolicSecant InverseHyperbolicSecant = (T ratio) =>
		{
			throw new Error("not implemented");
		};
		#endregion

		#region InverseHyperbolicCotangent
		public static Compute<T>.Delegates.InverseHyperbolicCotangent InverseHyperbolicCotangent = (T ratio) =>
		{
			throw new Error("not implemented");
		};
		#endregion
	}
}
