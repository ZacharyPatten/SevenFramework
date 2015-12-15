using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seven
{
	/// <summary>Contains </summary>
	public static class Delegate_extensions
	{
		/// <summary>Compares delgates for equality (see source code for criteria).</summary>
		/// <param name="a">One of the delegates to compare.</param>
		/// <param name="b">One of the delegates to compare.</param>
		/// <returns>True if deemed equal, False if not.</returns>
		public static bool Equate(this Delegate a, Delegate b)
		{
			// remove delegate assignment overhead
			while (a.Target is Delegate)
				a = a.Target as Delegate;
			while (b.Target is Delegate)
				b = b.Target as Delegate;

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
		public static Delegate Truncate(this Delegate del)
		{
			while (del.Target is Delegate)
				del = del.Target as Delegate;
			return del;
		}
	}
}
