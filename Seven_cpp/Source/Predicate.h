// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

#ifndef Predicate_H
#define Predicate_H

#include <functional>

namespace Seven
{
	/// <summary>Unary operator for criteria testing.</summary>
	/// <returns>True if the item passes the criteria test. False if not.</returns>
	template<typename T>
	using Predicate = std::function<bool(T)>;
}

#endif