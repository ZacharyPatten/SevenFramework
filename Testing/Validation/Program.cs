using System;

using Seven;
using Seven.Mathematics;


namespace Validation
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Negate:         " + (Compute<int>.Negate(7) == -7));
			Console.WriteLine("Add:            " + (Compute<int>.Add(7, 7) == 14));
			Console.WriteLine("Subtract:       " + (Compute<int>.Subtract(14, 7) == 7));
			Console.WriteLine("Multiply:       " + (Compute<int>.Multiply(7, 7) == 49));
			Console.WriteLine("Divide:         " + (Compute<int>.Divide(14, 7) == 2));
			Console.WriteLine("AbsoluteValue:  " + (Compute<int>.AbsoluteValue(7) == 7 && Compute<int>.AbsoluteValue(-7) == 7));
			Console.WriteLine("Clamp:          " + (Compute<int>.Clamp(7, 6, 8) == 7));
			Console.WriteLine("Maximum:        " + (Compute<int>.Maximum((Step<int> step) => { step(1); step(2); step(3); }) == 3));
			Console.WriteLine("Minimum:        " + (Compute<int>.Minimum((Step<int> step) => { step(1); step(2); step(3); }) == 1));
			Console.WriteLine("LessThan:       " + (Compute<int>.LessThan(1, 2) == true && Compute<int>.LessThan(2, 1) == false));
			Console.WriteLine("GreaterThan:    " + (Compute<int>.GreaterThan(2, 1) == true && Compute<int>.GreaterThan(1, 2) == false));
			Console.WriteLine("Compare:        " + (Compute<int>.Compare(2, 1) == Comparison.Greater && Compute<int>.Compare(1, 2) == Comparison.Less && Compute<int>.Compare(1, 1) == Comparison.Equal));
			Console.WriteLine("Equate:         " + (Compute<int>.Equate(2, 1) == false && Compute<int>.Equate(1, 1) == true));
			Console.WriteLine("EqualsLeniency: " + (Compute<int>.EqualsLeniency(2, 1, 1) == true && Compute<int>.EqualsLeniency(2, 1, 0) == false && Compute<int>.EqualsLeniency(1, 1, 0) == true));
			Console.WriteLine();


			//Console.WriteLine("Range Testing------------------------------");
			//{
			//	Console.WriteLine(" One Dimensional:");
			//	Range<int> range1 = new Range<int>(1, 7);
			//	Console.WriteLine("  range1............................" + range1);// + range1.Min[0] + "-" + range1.Max[0]);
			//	Range<int> range2 = new Range<int>(4, 10);
			//	Console.WriteLine("  range2............................" + range2);// + range2.Min[0] + "-" + range2.Max[0]);
			//	//Range<int> range3 = range1 ^ range2;
			//	//Console.WriteLine("  range1 ^ range2 (Complement)......" + range3);// + range3.Min[0] + "-" + range3.Max[0]);
			//	//Range<int> range4 = range1 | range2;
			//	//Console.WriteLine("  range1 | range2 (Union)..........." + range4);// + range4.Min[0] + "-" + range4.Max[0]);
			//	Range<int> range5 = range1 & range2;
			//	Console.WriteLine("  range1 & range2 (Intersection)...." + range5);// + range5.Min[0] + "-" + range5.Max[0]);
			//}
			//{
			//	Console.WriteLine(" Two Dimensional:");
			//	Range<double> range1 = new Range<double>(new Vector<double>(1, 2), new Vector<double>(7, 8));
			//	Console.WriteLine("  range1............................" + range1);// + range1.Min[0] + "," + range1.Min[1] + ")-(" + range1.Max[0] + "," + range1.Max[1] + ")");
			//	Range<double> range2 = new Range<double>(new Vector<double>(4, 5), new Vector<double>(10, 11));
			//	Console.WriteLine("  range2............................" + range2);// + range2.Min[0] + "," + range2.Min[1] + ")-(" + range2.Max[0] + "," + range2.Max[1] + ")");
			//	//Range<double> range3 = range1 ^ range2;
			//	//Console.WriteLine("  range1 ^ range2 (Complement)......" + range3);// + range3.Min[0] + "," + range3.Min[1] + ")-(" + range3.Max[0] + "," + range3.Max[1] + ")");
			//	//Range<double> range4 = range1 | range2;
			//	//Console.WriteLine("  range1 | range2 (Union)..........." + range4);// + range4.Min[0] + "," + range4.Min[1] + ")-(" + range4.Max[0] + "," + range4.Max[1] + ")");
			//	Range<double> range5 = range1 & range2;
			//	Console.WriteLine("  range1 & range2 (Intersection)...." + range5);// + range5.Min[0] + "," + range5.Min[1] + ")-(" + range5.Max[0] + "," + range5.Max[1] + ")");
			//}

			Console.ReadLine();
		}
	}
}
