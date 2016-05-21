// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven
{
	public static class Extensions
	{
		#region char

		/// <summary>Creates a string of a repreated character a provided number of times.</summary>
		/// <param name="character">The character to repeat.</param>
		/// <param name="count">The number of repetitions of the charater (aka resulting string length).</param>
		/// <returns>The string of the repeated character.</returns>
		public static string Repeat(this char character, int count)
		{
			if (count < 0)
				throw new System.ArgumentOutOfRangeException("count");
			char[] sets = new char[count];
			for (int i = 0; i < count; i++)
				sets[i] = character;
			return new string(sets);
		}

		#endregion

		#region string

		internal static string RemoveCarriageReturns(this string str)
		{
			return str.Replace("\r", string.Empty);
		}

		/// <summary>Removes carriage returns and then replaces all new line characters with System.Environment.NewLine.</summary>
		/// <param name="str">The string to standardize the new lines of.</param>
		/// <returns>The new line standardized string.</returns>
		internal static string StandardizeNewLines(this string str)
		{
			return str.RemoveCarriageReturns().Replace("\n", System.Environment.NewLine);
		}

		/// <summary>Creates a string of a repreated string a provided number of times.</summary>
		/// <param name="str">The string to repeat.</param>
		/// <param name="count">The number of repetitions of the string to repeat.</param>
		/// <returns>The string of the repeated string to repeat.</returns>
		public static string Repeat(this string str, int count)
		{
			if (object.ReferenceEquals(null, str))
				throw new System.ArgumentNullException(str);
			if (count < 0)
				throw new System.ArgumentOutOfRangeException("count");
			string[] sets = new string[count];
			for (int i = 0; i < count; i++)
				sets[i] = str;
			return string.Concat(sets);
		}

		/// <summary>Splits the string into the individual lines.</summary>
		/// <param name="str">The string to get the lines of.</param>
		/// <returns>an array of the individual lines of the string.</returns>
		public static string[] SplitLines(this string str)
		{
			return str.RemoveCarriageReturns().Split('\n');
		}

		/// <summary>Indents every line in a string with a single tab character.</summary>
		/// /// <param name="str">The string to indent the lines of.</param>
		/// <returns>The indented string.</returns>
		public static string IndentLines(this string str)
		{
			return PadLinesLeft(str, "\t");
		}

		/// <summary>Indents every line in a string with a given number of tab characters.</summary>
		/// <param name="str">The string to indent the lines of.</param>
		/// <param name="count">The number of tabs of the indention.</param>
		/// <returns>The indented string.</returns>
		public static string IndentLines(this string str, int count)
		{
			return PadLinesLeft(str, '\t'.Repeat(count));
		}

		/// <summary>Indents after every new line sequence found between two string indeces.</summary>
		/// <param name="str">The string to be indented.</param>
		/// <param name="start">The starting index to look for new line sequences to indent.</param>
		/// <param name="end">The starting index to look for new line sequences to indent.</param>
		/// <returns>The indented string.</returns>
		public static string IndentNewLinesBetweenIndeces(this string str, int start, int end)
		{
			return PadLinesLeftBetweenIndeces(str, "\t", start, end);
		}

		/// <summary>Indents after every new line sequence found between two string indeces.</summary>
		/// <param name="str">The string to be indented.</param>
		/// <param name="count">The number of tabs of this indention.</param>
		/// <param name="start">The starting index to look for new line sequences to indent.</param>
		/// <param name="end">The starting index to look for new line sequences to indent.</param>
		/// <returns>The indented string.</returns>
		public static string IndentNewLinesBetweenIndeces(this string str, int count, int start, int end)
		{
			return PadLinesLeftBetweenIndeces(str, '\t'.Repeat(count), start, end);
		}

		/// <summary>Indents a range of line numbers in a string.</summary>
		/// <param name="str">The string to indent specified lines of.</param>
		/// <param name="startingLineNumber">The line number to start line indention on.</param>
		/// <param name="endingLineNumber">The line number to stop line indention on.</param>
		/// <returns>The string with the specified lines indented.</returns>
		public static string IndentLineNumbers(this string str, int startingLineNumber, int endingLineNumber)
		{
			return PadLinesLeft(str, "\t", startingLineNumber, endingLineNumber);
		}

		/// <summary>Indents a range of line numbers in a string.</summary>
		/// <param name="str">The string to indent specified lines of.</param>
		/// <param name="count">The number of tabs for the indention.</param>
		/// <param name="startingLineNumber">The line number to start line indention on.</param>
		/// <param name="endingLineNumber">The line number to stop line indention on.</param>
		/// <returns>The string with the specified lines indented.</returns>
		public static string IndentLineNumbers(this string str, int count, int startingLineNumber, int endingLineNumber)
		{
			return PadLinesLeft(str, '\t'.Repeat(count), startingLineNumber, endingLineNumber);
		}

		/// <summary>Adds a string onto the beginning of every line in a string.</summary>
		/// <param name="str">The string to pad.</param>
		/// <param name="padding">The padding to add to the front of every line.</param>
		/// <returns>The padded string.</returns>
		public static string PadLinesLeft(this string str, string padding)
		{
			if (object.ReferenceEquals(null, str))
				throw new System.ArgumentNullException(str);
			if (object.ReferenceEquals(null, padding))
				throw new System.ArgumentNullException(padding);
			if (padding.CompareTo(string.Empty) == 0)
				return str;
			return string.Concat(padding, str.RemoveCarriageReturns().Replace("\n", System.Environment.NewLine + padding));
		}

		/// <summary>Adds a string onto the end of every line in a string.</summary>
		/// <param name="str">The string to pad.</param>
		/// <param name="padding">The padding to add to the front of every line.</param>
		/// <returns>The padded string.</returns>
		public static string PadSubstringLinesRight(this string str, string padding)
		{
			if (object.ReferenceEquals(null, str))
				throw new System.ArgumentNullException(str);
			if (object.ReferenceEquals(null, padding))
				throw new System.ArgumentNullException(padding);
			if (padding.CompareTo(string.Empty) == 0)
				return str;
			return string.Concat(str.RemoveCarriageReturns().Replace("\n", padding + System.Environment.NewLine), padding);
		}

		/// <summary>Adds a string after every new line squence found between two indeces of a string.</summary>
		/// <param name="str">The string to be padded.</param>
		/// <param name="padding">The padding to apply after every newline sequence found.</param>
		/// <param name="start">The starting index of the string to search for new line sequences.</param>
		/// <param name="end">The ending index of the string to search for new line sequences.</param>
		/// <returns>The padded string.</returns>
		public static string PadLinesLeftBetweenIndeces(this string str, string padding, int start, int end)
		{
			if (object.ReferenceEquals(null, str))
				throw new System.ArgumentNullException(str);
			if (object.ReferenceEquals(null, padding))
				throw new System.ArgumentNullException(padding);
			if (start < 0 || start >= str.Length)
				throw new System.ArgumentOutOfRangeException("start");
			if (end >= str.Length || end < start)
				throw new System.ArgumentOutOfRangeException("end");
			string header = str.Substring(0, start).StandardizeNewLines();
			string body = string.Concat(str.Substring(start, end - start).RemoveCarriageReturns().Replace("\n", System.Environment.NewLine + padding));
			string footer = str.Substring(end).StandardizeNewLines();
			return string.Concat(header, body, footer);
		}

		/// <summary>Adds a string before every new line squence found between two indeces of a string.</summary>
		/// <param name="str">The string to be padded.</param>
		/// <param name="padding">The padding to apply before every newline sequence found.</param>
		/// <param name="start">The starting index of the string to search for new line sequences.</param>
		/// <param name="end">The ending index of the string to search for new line sequences.</param>
		/// <returns>The padded string.</returns>
		public static string PadLinesRightBetweenIndeces(this string str, string padding, int start, int end)
		{
			if (object.ReferenceEquals(null, str))
				throw new System.ArgumentNullException(str);
			if (object.ReferenceEquals(null, padding))
				throw new System.ArgumentNullException(padding);
			if (start < 0 || start >= str.Length)
				throw new System.ArgumentOutOfRangeException("start");
			if (end >= str.Length || end < start)
				throw new System.ArgumentOutOfRangeException("end");
			string header = str.Substring(0, start).StandardizeNewLines();
			string body = string.Concat(str.Substring(start, end - start).RemoveCarriageReturns().Replace("\n", padding + System.Environment.NewLine));
			string footer = str.Substring(end).StandardizeNewLines();
			return string.Concat(header, body, footer);
		}

		/// <summary>Adds a string after every new line squence found between two indeces of a string.</summary>
		/// <param name="str">The string to be padded.</param>
		/// <param name="padding">The padding to apply after every newline sequence found.</param>
		/// <param name="start">The starting index of the string to search for new line sequences.</param>
		/// <param name="end">The ending index of the string to search for new line sequences.</param>
		/// <returns>The padded string.</returns>
		public static string PadLinesLeft(this string str, string padding, int startingLineNumber, int endingLineNumber)
		{
			if (object.ReferenceEquals(null, str))
				throw new System.ArgumentNullException(str);
			if (object.ReferenceEquals(null, padding))
				throw new System.ArgumentNullException(padding);
			string[] lines = str.SplitLines();
			if (startingLineNumber < 0 || startingLineNumber >= lines.Length)
				throw new System.ArgumentOutOfRangeException("startingLineNumber");
			if (endingLineNumber >= lines.Length || endingLineNumber < startingLineNumber)
				throw new System.ArgumentOutOfRangeException("endingLineNumber");
			for (int i = startingLineNumber; i <= endingLineNumber; i++)
				lines[i] = padding + lines[i];
			return string.Concat(lines);
		}

		/// <summary>Adds a string before every new line squence found between two indeces of a string.</summary>
		/// <param name="str">The string to be padded.</param>
		/// <param name="padding">The padding to apply before every newline sequence found.</param>
		/// <param name="startingLineNumber">The starting index of the string to search for new line sequences.</param>
		/// <param name="endingLineNumber">The ending index of the string to search for new line sequences.</param>
		/// <returns>The padded string.</returns>
		public static string PadLinesRight(this string str, string padding, int startingLineNumber, int endingLineNumber)
		{
			if (object.ReferenceEquals(null, str))
				throw new System.ArgumentNullException(str);
			if (object.ReferenceEquals(null, padding))
				throw new System.ArgumentNullException(padding);
			string[] lines = str.SplitLines();
			if (startingLineNumber < 0 || startingLineNumber >= lines.Length)
				throw new System.ArgumentOutOfRangeException("startingLineNumber");
			if (endingLineNumber >= lines.Length || endingLineNumber < startingLineNumber)
				throw new System.ArgumentOutOfRangeException("endingLineNumber");
			for (int i = startingLineNumber; i <= endingLineNumber; i++)
				lines[i] += padding;
			return string.Concat(lines);
		}

		/// <summary>Reverses the characters in a string.</summary>
		/// <param name="str">The string to reverse the characters of.</param>
		/// <returns>The reversed character string.</returns>
		public static string Reverse(this string str)
		{
			char[] characters = str.ToCharArray();
			System.Array.Reverse(characters);
			return new string(characters);
		}
	
		#endregion

		#region Random

		/// <summary>Generates a random string of a given length using the System.Random generator.</summary>
		/// <param name="length">The length of the randomized string to generate.</param>
		/// <returns>The generated randomized string.</returns>
		public static string RandomString(this System.Random random, int length)
		{
			char[] randomstring = new char[length];
			for (int i = 0; i < randomstring.Length; i++)
				randomstring[i] = (char)random.Next(char.MinValue, char.MaxValue);
			return new string(randomstring);
		}

		/// <summary>Generates a random string of a given length using the System.Random generator with a specific set of characters.</summary>
		/// <param name="length">The length of the randomized string to generate.</param>
		/// <param name="allowableChars">The set of allowable characters.</param>
		/// <returns>The generated randomized string.</returns>
		public static string RandomString(this System.Random random, int length, char[] allowableChars)
		{
			char[] randomstring = new char[length];
			for (int i = 0; i < randomstring.Length; i++)
				randomstring[i] = allowableChars[random.Next(0, allowableChars.Length)];
			return new string(randomstring);
		}

		/// <summary>Generates a random alphanumeric string of a given length using the System.Random generator.</summary>
		/// <param name="length">The length of the randomized alphanumeric string to generate.</param>
		/// <returns>The generated randomized alphanumeric string.</returns>
		public static string RandomAlphaNumericString(this System.Random random, int length)
		{
			return RandomString(random, length, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray());
		}

		/// <summary>Generates a random numeric string of a given length using the System.Random generator.</summary>
		/// <param name="length">The length of the randomized numeric string to generate.</param>
		/// <returns>The generated randomized numeric string.</returns>
		public static string RandomNumericString(this System.Random random, int length)
		{
			return RandomString(random, length, "0123456789".ToCharArray());
		}

		/// <summary>Generates a random alhpabetical string of a given length using the System.Random generator.</summary>
		/// <param name="length">The length of the randomized alphabetical string to generate.</param>
		/// <returns>The generated randomized alphabetical string.</returns>
		public static string RandomAlphabeticString(this System.Random random, int length)
		{
			return RandomString(random, length, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray());
		}

		#endregion

		#region Delegate

		/// <summary>Compares delgates for equality (see source code for criteria).</summary>
		/// <param name="a">One of the delegates to compare.</param>
		/// <param name="b">One of the delegates to compare.</param>
		/// <returns>True if deemed equal, False if not.</returns>
		public static bool Equate(this System.Delegate a, System.Delegate b)
		{
			// remove delegate assignment overhead
			while (a.Target is System.Delegate)
				a = a.Target as System.Delegate;
			while (b.Target is System.Delegate)
				b = b.Target as System.Delegate;

			// (1) method and target match
			if (a == b)
				return true;

			// null
			if (a == null || b == null)
				return false;

			// (2) compiled method bodies match
			if (a.Target != b.Target)
				return false;
			byte[] a_body = a.Method.GetMethodBody().GetILAsByteArray();
			byte[] b_body = b.Method.GetMethodBody().GetILAsByteArray();
			if (a_body.Length != b_body.Length)
				return false;
			for (int i = 0; i < a_body.Length; i++)
			{
				if (a_body[i] != b_body[i])
					return false;
			}
			return true;
		}

		/// <summary>Removes the overhead caused by delegate assignment.</summary>
		/// <param name="del">The delegate to truncate.</param>
		/// <returns>The truncated delegate.</returns>
		public static System.Delegate Truncate(this System.Delegate del)
		{
			while (del.Target is System.Delegate)
				del = del.Target as System.Delegate;
			return del;
		}

		#endregion
	}
}
