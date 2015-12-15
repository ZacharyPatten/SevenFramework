// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics
{
	/// <summary>Contains generic mathematics arithmetic operations.</summary>
	public static class Arithmetic<T>
	{
		#region delegate

		/// <summary>Contains the delegates for arithmetic operations.</summary>
		public static class delegates
		{

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
			/// <summary>Takes one operand to the power of another.</summary>
			/// <param name="left">The base of the power operaition.</param>
			/// <param name="right">The exponent of the power operation.</param>
			/// <returns>The result of the power operation.</returns>
			public delegate T Power(T left, T right);

		}

		#endregion

		#region implementation

		/// <summary>Negates a value.</summary>
		public static Arithmetic<T>.delegates.Negate Negate = (T value) =>
			#region code
			{
				#region generic
#if show_Numeric
				Arithmetic<Numeric>.delegates.Negate Negate = (Numeric _value) => { return -_value; };
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Negate_string = "(" + num + " _value) => { return -_value; }";

				#endregion

				Arithmetic<T>.Negate =
					Generate.Object<Arithmetic<T>.delegates.Negate>(Negate_string);

				return Arithmetic<T>.Negate(value);
			};
			#endregion

		/// <summary>Adds two operands together.</summary>
		public static Arithmetic<T>.delegates.Add Add = (T left, T right) =>
			#region code
			{
				#region generic
#if show_Numeric
				Arithmetic<Numeric>.delegates.Add Add = (Numeric _left, Numeric _right) => { return _left + _right; };
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Add_string = "(" + num + " _left, " + num + " _right) => { return _left + _right; }";

				#endregion

				Arithmetic<T>.Add =
					Generate.Object<Arithmetic<T>.delegates.Add>(Add_string);

				return Arithmetic<T>.Add(left, right);
			};
			#endregion

		/// <summary>Subtracts two operands.</summary>
		public static Arithmetic<T>.delegates.Subtract Subtract = (T left, T right) =>
			#region code
			{
				#region generic
#if show_Numeric
				Arithmetic<Numeric>.delegates.Subtract Add = (Numeric _left, Numeric _right) => { return _left - _right; };
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Subtract_string = "(" + num + " _left, " + num + " _right) => { return _left - _right; }";

				#endregion

				Arithmetic<T>.Subtract =
					Generate.Object<Arithmetic<T>.delegates.Subtract>(Subtract_string);

				return Arithmetic<T>.Subtract(left, right);
			};
			#endregion

		/// <summary>Multiplies two operands together.</summary>
		public static Arithmetic<T>.delegates.Multiply Multiply = (T left, T right) =>
			#region code
			{
				#region generic
#if show_Numeric
				Arithmetic<Numeric>.delegates.Multiply Add = (Numeric _left, Numeric _right) => { return _left * _right; };
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Multiply_string = "(" + num + " _left, " + num + " _right) => { return _left * _right; }";

				#endregion

				Arithmetic<T>.Multiply =
					Generate.Object<Arithmetic<T>.delegates.Multiply>(Multiply_string);

				return Arithmetic<T>.Multiply(left, right);
			};
			#endregion

		/// <summary>Divides two operands.</summary>
		public static Arithmetic<T>.delegates.Divide Divide = (T left, T right) =>
			#region code
			{
				#region generic
#if show_Numeric
				Arithmetic<Numeric>.delegates.Divide Divide = (Numeric _left, Numeric _right) => { return _left / _right; };
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Divide_string = "(" + num + " _left, " + num + " _right) => { return _left / _right; }";

				#endregion

				Arithmetic<T>.Divide =
					Generate.Object<Arithmetic<T>.delegates.Divide>(Divide_string);

				return Arithmetic<T>.Divide(left, right);
			};
			#endregion

		/// <summary>Takes one operand to the power of another.</summary>
		public static Arithmetic<T>.delegates.Power Power = (T left, T right) =>
			#region code
			{
				#region generic
#if show_Numeric
				Arithmetic<Numeric>.delegates.Power Power = (Numeric _left, Numeric _right) => { return (Numeric)System.Math.Pow((double)_left, (double)_right); };
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Power_string = "(" + num + " _left, " + num + " _right) => { return (" + num + ")System.Math.Pow((double)_left, (double)_right); }";

				#endregion

				Arithmetic<T>.Power =
					Generate.Object<Arithmetic<T>.delegates.Power>(Power_string);

				return Arithmetic<T>.Power(left, right);
			};
			#endregion

		#endregion
	}

	/// <summary>Contains generic mathematics arithmetic operations.</summary>
	public static class Arithmetic
	{
		#region mappings

		/// <summary>Negates a value.</summary>
		/// <param name="value">The value to negate.</param>
		/// <returns>The result of the negation.</returns>
		public static T Negate<T>(T value) { return Arithmetic<T>.Negate(value); }
		/// <summary>Adds two operands together.</summary>
		/// <typeparam name="T">The type of the values to be added.</typeparam>
		/// <param name="left">The left operand of the addition.</param>
		/// <param name="right">The right operand of the addition.</param>
		/// <returns>The result of the addition.</returns>
		public static T Add<T>(T left, T right) { return Arithmetic<T>.Add(left, right); }
		/// <summary>Subtracts two operands.</summary>
		/// <param name="left">The left operand of the subtraction.</param>
		/// <param name="right">The right operand of the subtraction.</param>
		/// <returns>The result of the subtraction.</returns>
		public static T Subtract<T>(T left, T right) { return Arithmetic<T>.Subtract(left, right); }
		/// <summary>Multiplies two operands together.</summary>
		/// <param name="left">The left operand of the multiplication.</param>
		/// <param name="right">The right operand of the multiplication.</param>
		/// <returns>The result of the multiplication.</returns>
		public static T Multiply<T>(T left, T right) { return Arithmetic<T>.Multiply(left, right); }
		/// <summary>Divides two operands.</summary>
		/// <param name="left">The left operand of the division.</param>
		/// <param name="right">The right operand of the division.</param>
		/// <returns>The result of the division.</returns>
		public static T Divide<T>(T left, T right) { return Arithmetic<T>.Divide(left, right); }
		/// <summary>Takes one operand to the power of another.</summary>
		/// <param name="left">The base of the power operaition.</param>
		/// <param name="right">The exponent of the power operation.</param>
		/// <returns>The result of the power operation.</returns>
		public static T Power<T>(T left, T right) { return Arithmetic<T>.Power(left, right); }

		#endregion
	}
}
