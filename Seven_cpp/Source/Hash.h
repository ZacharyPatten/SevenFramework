// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

#ifndef Hash_H
#define Hash_H

#include <functional>

namespace Seven
{
	/// <summary>Unary operator for hash code computation.</summary>
	/// <returns>The computed hash of the given item.</returns>
	template<typename T>
	using Hash = std::function<int(T)>;
}

#endif