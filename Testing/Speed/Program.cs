using Seven;
using Seven.Mathematics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Speed
{
	public class IntegerClass
	{
		public int _int;

		public IntegerClass(int integer)
		{
			this._int = integer;
		}

		public static bool operator <(IntegerClass a, IntegerClass b)
		{
			return a._int < b._int;
		}

		public static bool operator >(IntegerClass a, IntegerClass b)
		{
			return a._int > b._int;
		}

		public static bool operator ==(IntegerClass a, IntegerClass b)
		{
			if (object.ReferenceEquals(a, null))
				if (object.ReferenceEquals(b, null))
					return true;
				else
					return false;
			if (object.ReferenceEquals(b, null))
				return false;
			return a._int == b._int;
		}

		public static bool operator !=(IntegerClass a, IntegerClass b)
		{
			if (object.ReferenceEquals(a, null))
				if (object.ReferenceEquals(b, null))
					return false;
				else
					return true;
			if (object.ReferenceEquals(b, null))
				return true;
			return a._int != b._int;
		}

		public override bool Equals(object obj)
		{
			if (obj is IntegerClass)
				return this == (obj as IntegerClass);
			return base.Equals(obj);
		}

		public static implicit operator IntegerClass(int integer)
		{
			return new IntegerClass(integer);
		}
	}

	class Program
	{

		static void Main(string[] args)
		{
			Console.WriteLine("This example is mainly for speed testing during development.");
			Console.WriteLine("See the other examples provided for clearer usage examples.");
			Console.WriteLine();

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

			Console.WriteLine("Range Testing------------------------------");
			{
				Console.WriteLine(" One Dimensional:");
				Range<int> range1 = new Range<int>(1, 7);
				Console.WriteLine("  range1............................" + range1);// + range1.Min[0] + "-" + range1.Max[0]);
				Range<int> range2 = new Range<int>(4, 10);
				Console.WriteLine("  range2............................" + range2);// + range2.Min[0] + "-" + range2.Max[0]);
				Range<int> range3 = range1 ^ range2;
				Console.WriteLine("  range1 ^ range2 (Complement)......" + range3);// + range3.Min[0] + "-" + range3.Max[0]);
				Range<int> range4 = range1 | range2;
				Console.WriteLine("  range1 | range2 (Union)..........." + range4);// + range4.Min[0] + "-" + range4.Max[0]);
				Range<int> range5 = range1 & range2;
				Console.WriteLine("  range1 & range2 (Intersection)...." + range5);// + range5.Min[0] + "-" + range5.Max[0]);
			}
			{
				Console.WriteLine(" Two Dimensional:");
				Range<double> range1 = new Range<double>(new Vector<double>(1, 2), new Vector<double>(7, 8));
				Console.WriteLine("  range1............................" + range1);// + range1.Min[0] + "," + range1.Min[1] + ")-(" + range1.Max[0] + "," + range1.Max[1] + ")");
				Range<double> range2 = new Range<double>(new Vector<double>(4, 5), new Vector<double>(10, 11));
				Console.WriteLine("  range2............................" + range2);// + range2.Min[0] + "," + range2.Min[1] + ")-(" + range2.Max[0] + "," + range2.Max[1] + ")");
				Range<double> range3 = range1 ^ range2;
				Console.WriteLine("  range1 ^ range2 (Complement)......" + range3);// + range3.Min[0] + "," + range3.Min[1] + ")-(" + range3.Max[0] + "," + range3.Max[1] + ")");
				Range<double> range4 = range1 | range2;
				Console.WriteLine("  range1 | range2 (Union)..........." + range4);// + range4.Min[0] + "," + range4.Min[1] + ")-(" + range4.Max[0] + "," + range4.Max[1] + ")");
				Range<double> range5 = range1 & range2;
				Console.WriteLine("  range1 & range2 (Intersection)...." + range5);// + range5.Min[0] + "," + range5.Min[1] + ")-(" + range5.Max[0] + "," + range5.Max[1] + ")");
			}

			#region Vector Test

			//Console.WriteLine();
			//Console.WriteLine("Vector Testing-------------------------------------");

			//Random random = new Random();
			//const int vector_size = 4;
			//const int vector_iterations = int.MaxValue / 100;

			//Vector<double> vector_a = new Vector<double>(vector_size);
			//Vector<double> vector_b = new Vector<double>(vector_size);
			//Vector<double> vector_c;

			//for (int i = 0; i < vector_size; i++)
			//{
			//	vector_a[i] = random.Next();
			//	vector_b[i] = random.Next();
			//}

			//Console.WriteLine("Compile 1: " + Seven.Diagnostics.Performance.Time(() => { vector_c = Vector<double>.Vector_Add(vector_a, vector_b); }));
			//Console.WriteLine("Compile 2: " + Seven.Diagnostics.Performance.Time(() => { vector_c = Vector<double>.Vector_Add2(vector_a, vector_b); }));
			//Console.WriteLine("Compile 3: " + Seven.Diagnostics.Performance.Time(() => { vector_c = Vector<double>.Vector_Add3(vector_a, vector_b); }));
			//Console.WriteLine("Compile 4: " + Seven.Diagnostics.Performance.Time(() => { vector_c = Vector<double>.Vector_Add4(vector_a, vector_b); }));

			//Console.WriteLine("Test 1:    " + Seven.Diagnostics.Performance.Time(() => {
			//	for (int i = 0; i < vector_iterations; i++)
			//		vector_c = Vector<double>.Vector_Add(vector_a, vector_b);
			//}));

			//Console.WriteLine("Test 2:    " + Seven.Diagnostics.Performance.Time(() =>
			//{
			//	for (int i = 0; i < vector_iterations; i++)
			//		vector_c = Vector<double>.Vector_Add2(vector_a, vector_b);
			//}));

			//Console.WriteLine("Test 3:    " + Seven.Diagnostics.Performance.Time(() =>
			//{
			//	for (int i = 0; i < vector_iterations; i++)
			//		vector_c = Vector<double>.Vector_Add3(vector_a, vector_b);
			//}));

			//Console.WriteLine("Test 4:    " + Seven.Diagnostics.Performance.Time(() =>
			//{
			//	for (int i = 0; i < vector_iterations; i++)
			//		vector_c = Vector<double>.Vector_Add4(vector_a, vector_b);
			//}));

			#endregion

			//Random random = new Random();
			//const int matrix_rows = 4;
			//const int matrix_columns = 4;
			//const int matrix_iterations = int.MaxValue / 100;

			//{

			//	Seven.Mathematics.Matrix<double> matrix_a = new Seven.Mathematics.Matrix<double>(matrix_rows, matrix_columns);
			//	Seven.Mathematics.Matrix<double> matrix_b = new Seven.Mathematics.Matrix<double>(matrix_rows, matrix_columns);
			//	Seven.Mathematics.Matrix<double> matrix_c;

			//	matrix_c = matrix_a + matrix_b;
			//	matrix_c = matrix_b + matrix_a;
			//	//matrix_a = matrix_b + matrix_c;
			//	//matrix_a = matrix_c + matrix_b;

			//	for (int i = 0; i < matrix_rows; i++)
			//		for (int j = 0; j < matrix_columns; j++)
			//		{
			//			matrix_a[i, j] = random.Next();
			//			matrix_b[i, j] = random.Next();
			//		}

			//	Console.WriteLine("Test 1:    " + Seven.Diagnostics.Performance.Time(() =>
			//	{
			//		for (int i = 0; i < matrix_iterations; i++)
			//			matrix_c = matrix_a + matrix_b;
			//	}));

			//matrix_c = Matrix<double>.Matrix_Negate2(matrix_a);
			//Console.WriteLine("Test 2:    " + Seven.Diagnostics.Performance.Time(() =>
			//{
			//	for (int i = 0; i < matrix_iterations; i++)
			//		matrix_c = Matrix<double>.Matrix_Negate2(matrix_a);
			//}));

			//Console.WriteLine("Test 2:    " + Seven.Diagnostics.Performance.Time(() =>
			//{
			//	for (int i = 0; i < matrix_iterations; i++)
			//		Matrix<double>.Matrix_IsSymetric2(matrix_a);
			//}));

			//Console.WriteLine("Compile 1: " + Seven.Diagnostics.Performance.Time(() => { matrix_c = matrix_a + matrix_b; }));

			//Console.WriteLine("Test 1:    " + Seven.Diagnostics.Performance.Time(() =>
			//{
			//	for (int i = 0; i < matrix_iterations; i++)
			//		matrix_c = matrix_a + matrix_b;
			//}));

			//}

			Console.WriteLine();
			Console.WriteLine("Done...");
			Console.ReadLine();
		}
	}
}
