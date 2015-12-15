using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seven.Algorithms
{
	public static class Search
	{
		public static int BinarySearch<T>(T[] array, int index, int length, T value, Compare<T> compare)
		{
			if (array == null)
				throw new Error("array == null");
			int lowerBound = array.GetLowerBound(0);
			if (index < lowerBound || length < 0)
				throw new Error("ArgumentOutOfRange_NeedNonNegNum");
			if (array.Length - (index - lowerBound) < length)
				throw new Error("Argument_InvalidOffLen");

			int low = index;
			int hi = index + length - 1;
			while (low <= hi)
			{
				int median = low + (hi - low >> 1);
				switch (compare(array[median], value))
				{
					case Comparison.Equal:
						return median;
					case Comparison.Greater:
						hi = median - 1;
						break;
					case Comparison.Less:
						low = median + 1;
						break;
					default:
						throw new Error("not implemented");
				}
			}
			return ~low;
		}
	}
}
