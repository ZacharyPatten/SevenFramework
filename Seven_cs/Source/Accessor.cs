using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seven
{
	/// <summary>Delegate for getting a value at a specified index.</summary>
	/// <param name="index">The index to get the value of.</param>
	/// <returns>The value at the given index.</returns>
	[System.Serializable]
	public delegate T Get<T>(int index);

	/// <summary>Delegate for setting a value at a specified index.</summary>
	/// <param name="index">The index to set the value of.</param>
	/// <param name="value">The value to set at the given index.</param>
	[System.Serializable]
	public delegate void Assign<T>(int index, T value);

	[System.Serializable]
	public static class Accessor
	{
		public static Get<T> Get<T>(IList<T> ilist)
		{
			return (int index) => { return ilist[index]; };
		}

		public static Assign<T> Assign<T>(IList<T> ilist)
		{
			return (int index, T value) => { ilist[index] = value; };
		}
	}
}
