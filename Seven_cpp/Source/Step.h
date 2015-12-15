// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

#ifndef Step_H
#define Step_H

#include <functional>

namespace Seven
{
	/// <summary>Status of data structure iteration.</summary>
	enum StepStatus
	{
		/// <summary>Continue normal iteration.</summary>
		Continue = 0,
		/// <summary>Iteration cancelation.</summary>
		Break = 1,
		/// <summary>Restart the iteration./summary>
		Restart = 2,
		/// <summary>Reverse iteration./summary>
		Previous = 3
	};

	/// <summary>Delegate for data structure iteration.</summary>
	/// <param name="current">The current instance of iteration through the data structure.</param>
	template<typename T>
	using Step = std::function<void(T)>;
	
	/// <summary>Delegate for data structure iteration.</summary>
	/// <typeparam name="T">The type of the instances within the data structure.</typeparam>
	/// <param name="current">The current instance of iteration through the data structure.</param>
	/// <returns>The status of the iteration. Allows breaking functionality.</returns>
	template<typename T>
	using StepBreak = std::function<StepStatus(T)>;

	/// <summary>Delegate for a traversal function on a data structure.</summary>
	/// <typeparam name="T">The type of instances the will be traversed.</typeparam>
	/// <param name="function">The foreach function to perform on each iteration.</param>
	template<typename T>
	using Stepper = std::function<void(Step<T>)>;
}

#endif
