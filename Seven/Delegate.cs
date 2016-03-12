// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven
{
	/// <summary>Contains </summary>
	public static class Delegate_extensions
	{
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
	}
}
