// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

#ifndef Compare_h
#define Compare_h

#include <functional>

namespace Seven
{
	/// <summary>Comparison operator between two operands in a logical expression.</summary>
	enum Comparison
	{
		/// <summary>The left operand is less than the right operand.</summary>
		Less = -1,
		/// <summary>The left operand is equal to the right operand.</summary>
		Equal = 0,
		/// <summary>The left operand is greater than the right operand.</summary>
		Greater = 1
	};

	/// <summary>Delegate for comparing two instances of the same type.</summary>
	/// <returns>The Comparison operator between the operands to form a true logic statement.</returns>
	template<typename T, typename ... T2>
	using Compare = std::function < Comparison(T, T2...) > ;

	// TODO: fix this template
	/*template<typename ... T>
	struct Compare_static
	{
		static:
			Compare<T...> Invert(Compare<T...> compare)
			{
				return [](T...)
				{
					Comparison comparison = compare(T...)
					if (comparison == Comparison::Less)
							return Comparison::Greater;
					else if (comparison == Comparison::Greater)
						return Comparison::Less;
					else
						return Comparison::Equal;
				};
			}
	};*/
}

#endif