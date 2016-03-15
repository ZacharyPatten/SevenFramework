using Seven;
using Seven.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Speed
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("This example is mainly for speed testing during development.");
			Console.WriteLine("See the other examples provided for clearer usage examples.");
			Console.WriteLine();

			foreach (var member in typeof(Compute<double>).GetMembers())
				Console.WriteLine(member.Name);
			Console.ReadLine();

			const int reflection_iterations = int.MaxValue / 1000;
			Type[] types;
			DateTime reflection_start0 = DateTime.Now;
			for (int i = 0; i < reflection_iterations; i++)
				types = typeof(Symbolics<double>).GetNestedTypes();
			DateTime reflection_end0 = DateTime.Now;
			Console.WriteLine("Reflection test: \t\t" + (reflection_end0 - reflection_start0));
			Console.ReadLine();

			Console.WriteLine("Vector Testing-------------------------------------");

			const int vector_size = 4;
			const int vector_iterations = int.MaxValue / 1000;
			
			Vector<double> vector_a = new Vector<double>(vector_size);
			Vector<double> vector_b = new Vector<double>(vector_size);
			Vector<double> vector_c;

			for (int i = 0; i < vector_size; i++)
			{
				vector_a[i] = i + 1;
				vector_b[i] = i + 1;
			}

			for (int i = 0; i < vector_iterations; i++)
				vector_c = Vector_Add_Test1(vector_a, vector_b);

			Console.WriteLine("Addition...");

			DateTime vector_add_start0 = DateTime.Now;
			vector_c = vector_a + vector_b;
			DateTime vector_add_end0 = DateTime.Now;
			Console.WriteLine("Time to compile string: \t\t" + (vector_add_end0 - vector_add_start0));

			DateTime vector_add_start1 = DateTime.Now;
			for (int i = 0; i < vector_iterations; i++)
				vector_c = Vector_Add_Test1(vector_a, vector_b);
			DateTime vector_add_end1 = DateTime.Now;
			Console.WriteLine("Compile Time Method: \t\t\t" + (vector_add_end1 - vector_add_start1));
			
			Func<Vector<double>, Vector<double>, Vector<double>> vector_function = Vector_Add_Test1;
			DateTime vector_add_start3 = DateTime.Now;
			for (int i = 0; i < vector_iterations; i++)
				vector_c = vector_function(vector_a, vector_b);
			DateTime vector_add_end3 = DateTime.Now;
			Console.WriteLine("Delegate (compile-time method): \t" + (vector_add_end3 - vector_add_start3));

			DateTime vector_add_start2 = DateTime.Now;
			for (int i = 0; i < vector_iterations; i++)
				vector_c = vector_a + vector_b;
			DateTime vector_add_end2 = DateTime.Now;
			Console.WriteLine("SevenFramework operator: \t\t" + (vector_add_end2 - vector_add_start2));

			Console.WriteLine("Negation...");

			DateTime vector_negate_start0 = DateTime.Now;
			vector_c = -vector_a;
			DateTime vector_negate_end0 = DateTime.Now;
			Console.WriteLine("Time to compile string: \t\t" + (vector_add_end0 - vector_add_start0));

			DateTime vector_negate_start1 = DateTime.Now;
			for (int i = 0; i < vector_iterations; i++)
				vector_c = Vector_Negate_Test1(vector_a);
			DateTime vector_negate_end1 = DateTime.Now;
			Console.WriteLine("Delegate (compile-time method V1): \t" + (vector_add_end1 - vector_add_start1));

			DateTime vector_negate_start2 = DateTime.Now;
			for (int i = 0; i < vector_iterations; i++) 
				vector_c = Vector_Negate_Test2(vector_a);
			DateTime vector_negate_end2 = DateTime.Now;
			Console.WriteLine("Delegate (compile-time method V2): \t" + (vector_add_end2 - vector_add_start2));

			DateTime vector_negate_start3 = DateTime.Now;
			for (int i = 0; i < vector_iterations; i++)
				vector_c = -vector_a;
			DateTime vector_negate_end3 = DateTime.Now;
			Console.WriteLine("SevenFramework operator: \t\t" + (vector_add_end3 - vector_add_start3));

			Console.WriteLine();

			Console.WriteLine("Matrix Testing...");

			const int matrix_size = 100;
			const int matrix_iterations = int.MaxValue / 10000000;

			double[,] matrix = new double[ matrix_size, matrix_size];
			for (int i = 0; i < matrix_size; i++)
				for (int j = 0; j < matrix_size; j++)
					matrix[i, j] = i * 100 + j;

			Matrix<double> matrix_a = (Matrix<double>)(matrix.Clone() as double[,]);
			Matrix<double> matrix_b = (Matrix<double>)(matrix.Clone() as double[,]);
			Matrix<double> matrix_c;

			DateTime matrix_start0 = DateTime.Now;
			matrix_c = matrix_a + matrix_b;
			DateTime matrix_end0 = DateTime.Now;
			Console.WriteLine("Time to compile: \t\t\t" + (matrix_end0 - matrix_start0));

			//DateTime matrix_start1 = DateTime.Now;
			//for (int i = 0; i < matrix_iterations; i++)
			//	matrix_c = Matrix_Multiply_Test1<double>(matrix_a, matrix_b);
			//DateTime matrix_end1 = DateTime.Now;
			//Console.WriteLine("Compile Time Method (V1): \t\t" + (matrix_end1 - matrix_start1));

			DateTime matrix_start2 = DateTime.Now;
			for (int i = 0; i < matrix_iterations; i++)
				matrix_c = Matrix_Multiply_Test2(matrix_a, matrix_b);
			DateTime matrix_end2 = DateTime.Now;
			Console.WriteLine("Compile Time Method (V2): \t\t" + (matrix_end2 - matrix_start2));

			DateTime matrix_start3 = DateTime.Now;
			for (int i = 0; i < matrix_iterations; i++)
				matrix_c = Matrix_Multiply_Test3(matrix_a, matrix_b);
			DateTime matrix_end3 = DateTime.Now;
			Console.WriteLine("Compile Time Method (V3): \t\t" + (matrix_end3 - matrix_start3));

			Func<Matrix<double>, Matrix<double>, Matrix<double>> matrix_function = Matrix_Multiply_Test2;
			DateTime matrix_start4 = DateTime.Now;
			for (int i = 0; i < matrix_iterations; i++)
				matrix_c = matrix_function(matrix_a, matrix_b);
			DateTime matrix_end4 = DateTime.Now;
			Console.WriteLine("Delegate (compile-time method V2): \t" + (matrix_end4 - matrix_start4));

			DateTime matrix_start5 = DateTime.Now;
			for (int i = 0; i < matrix_iterations; i++)
				matrix_c = matrix_a * matrix_b;
			DateTime matrix_end5 = DateTime.Now;
			Console.WriteLine("SevenFramework operator: \t\t" + (matrix_end5 - matrix_start5));

			Console.WriteLine();
			Console.WriteLine("Done...");
			Console.ReadLine();
		}

		public static Vector<double> Vector_Add_Test1(Vector<double> a, Vector<double> b)
		{
			if (object.ReferenceEquals(a, null))
				throw new Error("null reference: _left");
			if (object.ReferenceEquals(b, null))
				throw new Error("null reference: _right");
			int length = a.Dimensions;
			Vector<double> result =
				new Vector<double>(a.Dimensions);
			double[] _left_flat = a._vector;
			double[] _right_flat = b._vector;
			if (_left_flat.Length != _right_flat.Length)
				throw new Error("invalid dimensions on vector addition.");
			double[] result_flat = result._vector;
			for (int i = 0; i < length; i++)
				result_flat[i] = _left_flat[i] + _right_flat[i];
			return result;
		}

		public static Matrix<T> Matrix_Multiply_Test1<T>(Matrix<T> a, Matrix<T> b)
		{
			Matrix<T> result =
				new Matrix<T>(a.Rows, b.Columns);
			for (int i = 0; i < a.Rows; i++)
				for (int j = 0; j < b.Columns; j++)
					for (int k = 0; k < a.Columns; k++)
						result[i, j] = Compute<T>.Add(result[i, j], Compute<T>.Multiply(a[i, k], b[k, j]));
			return result;
		}

		public static Vector<double> Vector_Negate_Test1(Vector<double> a)
		{
			if (object.ReferenceEquals(a, null))
				throw new Error("null reference: vector");
			int length = a.Dimensions;
			Vector<double> result =
				new Vector<double>(length);
			double[] vector_flat = a._vector;
			double[] result_flat = result._vector;
			for (int i = 0; i < length; i++)
				result_flat[i] = -vector_flat[i];
			return result;
		}

		public static Vector<double> Vector_Negate_Test2(Vector<double> a)
		{
			if (object.ReferenceEquals(a, null))
				throw new Error("null reference: vector");
			int length = a.Dimensions;
			Vector<double> result =
				new Vector<double>(length);
			unsafe
			{
				fixed (double*
				vector_flat = a._vector,
				result_flat = result._vector)
					for (int i = 0; i < length; i++)
						result_flat[i] = -vector_flat[i];
			}
			return result;
		}

		public static Matrix<double> Matrix_Multiply_Test2(Matrix<double> a, Matrix<double> b)
		{
			if (a == null)
				throw new Error("null reference: _left");
			if (b == null)
				throw new Error("null reference: _right");
			if (a.Columns != b.Rows)
				throw new Error("invalid multiplication (size miss-match).");
			double sum;
			int result_rows = a.Rows;
			int _left_cols = a.Columns;
			int result_cols = b.Columns;
			Matrix<double> result =
				new Matrix<double>(result_rows, result_cols);
			double[] result_flat = result._matrix as double[];
			double[] _left_flat = a._matrix as double[];
			double[] _right_flat = b._matrix as double[];
			for (int i = 0; i < result_rows; i++)
				for (int j = 0; j < result_cols; j++)
				{
					sum = 0;
					for (int k = 0; k < _left_cols; k++)
						sum += _left_flat[i * _left_cols + k] * _right_flat[k * result_cols + j];
					result_flat[i * result_cols + j] = sum;
				}
			return result;
		}

		public static Matrix<double> Matrix_Multiply_Test3(Matrix<double> a, Matrix<double> b)
		{
			if (a == null)
				throw new Error("null reference: _left");
			if (b == null)
				throw new Error("null reference: _right");
			if (a.Columns != b.Rows)
				throw new Error("invalid multiplication (size miss-match).");
			double sum;
			int result_rows = a.Rows;
			int _left_cols = a.Columns;
			int result_cols = b.Columns;
			Matrix<double> result =
				new Matrix<double>(result_rows, result_cols);
			unsafe
			{
				fixed (double*
					result_flat = result._matrix as double[],
					_left_flat = a._matrix as double[],
					_right_flat = b._matrix as double[])
						for (int i = 0; i < result_rows; i++)
							for (int j = 0; j < result_cols; j++)
							{
									sum = 0;
									for (int k = 0; k < _left_cols; k++)
											sum += _left_flat[i * _left_cols + k] * _right_flat[k * result_cols + j];
									result_flat[i * result_cols + j] = sum;
							}
			}
			return result;
		}
	}
}
