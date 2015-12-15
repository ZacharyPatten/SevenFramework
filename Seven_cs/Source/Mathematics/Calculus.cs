// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics
{
	/// <summary>Contains generic mathematics calculus operations.</summary>
	public static class Calculus<T>
	{
		// still in development
		#region delegates

		public static class delegates
		{
			/// <summary>Finds the limit of a 2D function at the given input coordinate.</summary>
			/// <param name="expression">The 2D function to compute the limit of.</param>
			/// <param name="N">The coordinate to compute the limit of the function on.</param>
			/// <returns>The computed limit at the provided coordinate.</returns>
			public delegate T Limit(System.Linq.Expressions.Expression<System.Func<T, T>> expression, T N);
		}

		#endregion

		#region implementation

		/// <summary>Finds the limit of a 2D function at the given input coordinate.</summary>
		public static Calculus<T>.delegates.Limit Limit = (System.Linq.Expressions.Expression<System.Func<T, T>> expression, T N) =>
			#region code
			{
				#region generic
#if show_Numeric
				Calculus<T>.delegates.Limit compile_testing = (System.Linq.Expressions.Expression<System.Func<T, T>> _expression, T _N) => 
				{
					throw new Error("not yet implemented");
				};
#endif
				#endregion

				#region string

				string num = Generate.TypeToCsharp(typeof(T));

				string Limit_string = "(" + num + " _value) => { throw new Error(\"not yet implemented\"); }";

				#endregion

				Calculus<T>.Limit = Generate.Object<Calculus<T>.delegates.Limit>(Limit_string);

				return Calculus<T>.Limit(expression, N);
			};
			#endregion
		
		#endregion
	}
}
