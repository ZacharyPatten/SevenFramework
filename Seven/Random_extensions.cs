//// Seven
//// https://github.com/53V3N1X/SevenFramework
//// LISCENSE: See "LISCENSE.md" in th root project directory.
//// SUPPORT: See "SUPPORT.md" in the root project directory.

//namespace Seven
//{
//	public static class Random_extensions
//	{
//		/// <summary>Generates a random string of a given length using the System.Random generator.</summary>
//		/// <param name="length">The length of the randomized string to generate.</param>
//		/// <returns>The generated randomized string.</returns>
//		public static string RandomString(this System.Random random, int length)
//		{
//			char[] randomstring = new char[length];
//			for (int i = 0; i < randomstring.Length; i++)
//				randomstring[i] = (char)random.Next(char.MinValue, char.MaxValue);
//			return new string(randomstring);
//		}

//		/// <summary>Generates a random string of a given length using the System.Random generator with a specific set of characters.</summary>
//		/// <param name="length">The length of the randomized string to generate.</param>
//		/// <param name="allowableChars">The set of allowable characters.</param>
//		/// <returns>The generated randomized string.</returns>
//		public static string RandomString(this System.Random random, int length, char[] allowableChars)
//		{
//			char[] randomstring = new char[length];
//			for (int i = 0; i < randomstring.Length; i++)
//				randomstring[i] = allowableChars[random.Next(0, allowableChars.Length)];
//			return new string(randomstring);
//		}

//		/// <summary>Generates a random alphanumeric string of a given length using the System.Random generator.</summary>
//		/// <param name="length">The length of the randomized alphanumeric string to generate.</param>
//		/// <returns>The generated randomized alphanumeric string.</returns>
//		public static string RandomAlphaNumericString(this System.Random random, int length)
//		{
//			return RandomString(random, length, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray());
//		}

//		/// <summary>Generates a random numeric string of a given length using the System.Random generator.</summary>
//		/// <param name="length">The length of the randomized numeric string to generate.</param>
//		/// <returns>The generated randomized numeric string.</returns>
//		public static string RandomNumericString(this System.Random random, int length)
//		{
//			return RandomString(random, length, "0123456789".ToCharArray());
//		}

//		/// <summary>Generates a random alhpabetical string of a given length using the System.Random generator.</summary>
//		/// <param name="length">The length of the randomized alphabetical string to generate.</param>
//		/// <returns>The generated randomized alphabetical string.</returns>
//		public static string RandomAlphabeticString(this System.Random random, int length)
//		{
//			return RandomString(random, length, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray());
//		}
//	}
//}
