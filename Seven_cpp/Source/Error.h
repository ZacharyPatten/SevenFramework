// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

#ifndef Error_H
#define Error_H

// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

#include <string>

namespace Seven
{
	/// <summary>The polymorphism base of all the errors in the Seven framework.</summary>
	struct Error
	{
	public:
		/// <summary>The file path from which this exception was triggered.</summary>
		std::string* Message;

		/// <summary>Creates an exception.</summary>
		/// <param name="message">The message to represent/describe the exception.</param>
		Error(std::string* message)
		{
			this->Message = message;
		}

		~Error()
		{
			delete this->Message;
		}
	};
}

#endif