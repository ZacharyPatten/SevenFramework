// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

#ifndef Equate_H
#define Equate_H

#include <functional>

namespace Seven
{
	/// <summary>Delegate for equating two instances of the same type.</summary>
	/// <returns>Whether the equate is valid (true) or not (false).</returns>
	template<typename T, typename ... T2>
	using Equate = std::function < bool(T, T2...) >;
}

#endif