using System;
using System.Linq.Expressions;

using Seven;
using Seven.Structures;
using Seven.Mathematics;
using Seven.Mathematics.Symbolics;
using Seven.Mathematics.Symbolics.Tools;
using System.Reflection;

namespace Tutorial_Mathematics
{
	class Program
	{
		// Gets randomized values
		public static Random random = new Random();

		static void Main(string[] args)
		{
			Console.WriteLine("Welcome To SevenFramework! :)");
			Console.WriteLine();
			Console.WriteLine("You are runnning the Mathematics example.");
			Console.WriteLine("==========================================");
			Console.WriteLine();

			#region Number Theory

			Console.WriteLine("	Number Theory--------------------------------------");
			Console.WriteLine();

			// Prime Checking
			int prime_check = random.Next(0, 100000);
			Console.WriteLine("		isPrime(" + prime_check + "): " + NumberTheory.isPrime(prime_check));
			Console.WriteLine();

			// GCF Checking
			int[] gcf = new int[] { random.Next(0, 500) * 2, random.Next(0, 500) * 2, random.Next(0, 500) * 2 };
			Console.WriteLine("		GCF(" + gcf[0] + ", " + gcf[1] + ", " + gcf[2] + "): " + NumberTheory.GreatestCommonFactor(gcf));
			Console.WriteLine();

			// LCM Checking
			int[] lcm = new int[] { random.Next(0, 500) * 2, random.Next(0, 500) * 2, random.Next(0, 500) * 2 };
			Console.WriteLine("		LCM(" + lcm[0] + ", " + lcm[1] + ", " + lcm[2] + "): " + NumberTheory.LeastCommonMultiple(lcm));
			Console.WriteLine();

			#endregion

			#region Statistics

			Console.WriteLine("	Statistics-----------------------------------------");
			Console.WriteLine();

			// Makin some random data...
			double mode_temp = random.NextDouble() * 100;
			double[] statistics_data = new double[]
			{
				random.NextDouble() * 100,
				mode_temp,
				random.NextDouble() * 100,
				random.NextDouble() * 100,
				random.NextDouble() * 100,
				random.NextDouble() * 100,
				mode_temp
			};

			// Print the data to the console...
			Console.WriteLine("		data: [" +
				string.Format("{0:0.00}", statistics_data[0]) + ", " +
				string.Format("{0:0.00}", statistics_data[1]) + ", " +
				string.Format("{0:0.00}", statistics_data[2]) + ", " +
				string.Format("{0:0.00}", statistics_data[3]) + ", " +
				string.Format("{0:0.00}", statistics_data[4]) + ", " +
				string.Format("{0:0.00}", statistics_data[5]) + ", " +
				string.Format("{0:0.00}", statistics_data[6]) + "]");
			Console.WriteLine();

			// Mean
			Console.WriteLine("		Mean(data): " + string.Format("{0:0.00}", Statistics.Mean<double>(statistics_data)));
			Console.WriteLine();

			// Median
			Console.WriteLine("		Median(data): " + string.Format("{0:0.00}", Statistics.Median<double>(statistics_data)));
			Console.WriteLine();

			// Mode
			Console.WriteLine("		Mode(data): ");
			int ocurrences;
			Heap<Link<double, int>> modes = Statistics<double>.Mode(statistics_data.Stepper());
			while (modes.Count > 0)
			{
				Link<double, int> link = modes.Dequeue();
				Console.WriteLine("			Point: " + string.Format("{0:0.00}", link.One) + " Occurences: " + link.Two);
			}
			Console.WriteLine();
			Console.WriteLine();

			// Geometric Mean
			Console.WriteLine("		Geometric Mean(data): " + string.Format("{0:0.00}", Statistics<double>.GeometricMean(statistics_data.Stepper())));
			Console.WriteLine();

			// Range
			double range_min, range_max;
			Statistics<double>.Range(out range_min, out range_max, statistics_data.Stepper());
			Console.WriteLine("		Range(data): " + string.Format("{0:0.00}", range_min) + "-" + string.Format("{0:0.00}", range_max));
			Console.WriteLine();

			// Variance
			Console.WriteLine("		Variance(data): " + string.Format("{0:0.00}", Statistics<double>.Variance(statistics_data.Stepper())));
			Console.WriteLine();

			// Standard Deviation
			Console.WriteLine("		Standard Deviation(data): " + string.Format("{0:0.00}", Statistics<double>.StandardDeviation(statistics_data.Stepper())));
			Console.WriteLine();

			// Mean Deviation
			Console.WriteLine("		Mean Deviation(data): " + string.Format("{0:0.00}", Statistics<double>.MeanDeviation(statistics_data.Stepper())));
			Console.WriteLine();

			// Quantiles
			//double[] quatiles = Statistics<double>.Quantiles(4, statistics_data.Stepper());
			//Console.Write("		Quartiles(data):");
			//foreach (double i in quatiles)
			//	Console.Write(string.Format(" {0:0.00}", i));
			//Console.WriteLine();
			//Console.WriteLine();

			#endregion

			#region Algebra

			Console.WriteLine("	Algebra---------------------------------------------");
			Console.WriteLine();

			// Prime Factorization
			int prime_factors = random.Next(0, 100000);
			Console.Write("		Prime Factors(" + prime_factors + "): ");
			Algebra<int>.factorPrimes(prime_factors, (int i) => { Console.Write(i + " "); });
			Console.WriteLine();
			Console.WriteLine();

			// Logarithms
			int log_1 = random.Next(0, 11), log_2 = random.Next(0, 100000);
			Console.WriteLine("		log_" + log_1 + "(" + log_2 + "): " + string.Format("{0:0.00}", Algebra<double>.log((double)log_1, (double)log_2)));
			Console.WriteLine();

			// Summation
			double[] summation_values = new double[]
			{
				random.NextDouble(),
				random.NextDouble(),
				random.NextDouble(),
				random.NextDouble(),
			};
			double summation = Algebra<double>.summation(summation_values.Stepper());
			Console.Write("		Σ (" + string.Format("{0:0.00}", summation_values[0]));
			for (int i = 1; i < summation_values.Length; i++)
				Console.Write(", " + string.Format("{0:0.00}", summation_values[i]));
			Console.WriteLine(") = " + string.Format("{0:0.00}", summation));
			Console.WriteLine();

			#endregion

			#region Combinatorics

			Console.WriteLine("	Combinatorics--------------------------------------");
			Console.WriteLine();

			// Factorials
			Console.WriteLine("		7!: " + Combinatorics<int>.Factorial(7));
			Console.WriteLine();

			// Combinations
			Console.WriteLine("		7! / (3! * 4!): " + Combinatorics<int>.Combinations(7, new int[] { 3, 4 }));
			Console.WriteLine();

			// Choose
			Console.WriteLine("		7 choose 2: " + Combinatorics<int>.Choose(7, 2));
			Console.WriteLine();

			#endregion

			#region Linear Algebra

			Console.WriteLine("	Linear Algebra------------------------------------");
			Console.WriteLine();

			// Vector Construction
			Vector<double> V = new double[]
			{
				random.NextDouble(),
				random.NextDouble(),
				random.NextDouble(),
				random.NextDouble(),
			};

			Console.WriteLine("		Vector<double> V: ");
			ConsoleWrite(V);

			// Vector Addition
			Console.WriteLine("		V + V (aka 2V): ");
			ConsoleWrite(V + V);

			// Vector Dot Product
			Console.WriteLine("		V dot V: " + LinearAlgebra<double>.Vector_DotProduct(V, V));
			Console.WriteLine();

			// Vector Cross Product
			Vector<double> V3 = new double[]
			{
				random.NextDouble(),
				random.NextDouble(),
				random.NextDouble(),
			};

			Console.WriteLine("		Vector<double> V3: ");
			ConsoleWrite(V3);
			Console.WriteLine("		V3 cross V3: ");
			ConsoleWrite(LinearAlgebra<double>.Vector_CrossProduct(V3, V3));

			// Matrix Construction
			Matrix<double> M = (Matrix<double>)new double[,]
			{
				{ random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble() },
				{ random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble() },
				{ random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble() },
				{ random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble() },
			};

			Console.WriteLine("		Matrix<double> M: ");
			ConsoleWrite(M);

			// Matrix Negation
			Console.WriteLine("		-M: ");
			ConsoleWrite(-M);

			// Matrix Addition
			Console.WriteLine("		M + M (aka 2M): ");
			ConsoleWrite(M + M);

			// Matrix Subtraction
			Console.WriteLine("		M - M: ");
			ConsoleWrite(M - M);

			// Matrix Multiplication
			Console.WriteLine("		M * M (aka M ^ 2): ");
			ConsoleWrite(M * M);

			// If you have a large matrix that you want to multi-thread the multiplication,
			// use the function: "LinearAlgebra.Multiply_parallel". This function will
			// automatically parrallel the multiplication to the number of cores on your
			// personal computer.

			// Matrix Power
			Console.WriteLine("		M ^ 3: ");
			ConsoleWrite(M ^ 3);

			// Matrix Multiplication
			Console.WriteLine("		minor(M, 1, 1): ");
			ConsoleWrite(M.Minor(1, 1));

			// Matrix Reduced Row Echelon
			Console.WriteLine("		rref(M): ");
			ConsoleWrite(LinearAlgebra<double>.Matrix_ReducedEchelon(M));

			// Matrix Determinant
			Console.WriteLine("		determinent(M): " + string.Format("{0:0.00}", LinearAlgebra<double>.Matrix_Determinent(M)));
			Console.WriteLine();

			// Matrix-Vector Multiplication
			Console.WriteLine("		M * V: ");
			ConsoleWrite(M * V);

			// Matrix Lower-Upper Decomposition
			Matrix<double> l, u;
			LinearAlgebra<double>.Matrix_DecomposeLU(M, out l, out u);
			Console.WriteLine("		Lower-Upper Decomposition:");
			Console.WriteLine();
			Console.WriteLine("			lower(M):");
			ConsoleWrite(l);
			Console.WriteLine("			upper(M):");
			ConsoleWrite(u);

			// Quaternion Construction
			Quaternion<double> Q = new Quaternion<double>(
				random.NextDouble(),
				random.NextDouble(),
				random.NextDouble(),
				1.0d);

			Console.WriteLine("		Quaternion<double> Q: ");
			ConsoleWrite(Q);

			// Quaternion Addition
			Console.WriteLine("		Q + Q (aka 2Q):");
			ConsoleWrite(Q + Q);

			// Quaternion-Vector Rotation
			Console.WriteLine("		Q * V3 * Q':");
			// Note: the vector should be normalized on the 4th component 
			// for a proper rotation. (I did not do that)
			ConsoleWrite(V3.RotateBy(Q));

			#endregion

			#region Convex Optimization

			//Console.WriteLine("	Convex Optimization-----------------------------------");
			//Console.WriteLine();

			//double[,] tableau = new double[,]
			//{																	
			//	{ 0.0, -0.5, -3.0, -1.0, -4.0, },
			//	{ 40.0, 1.0, 1.0, 1.0, 1.0, },
			//	{ 10.0, -2.0, -1.0, 1.0, 1.0, },
			//	{ 10.0, 0.0, 1.0, 0.0, -1.0, },
			//};

			//Console.WriteLine("		tableau (double): ");
			//ConsoleWrite(tableau); Console.WriteLine();

			//Vector<double> simplex_result = LinearAlgebra.Simplex(ref tableau);

			//Console.WriteLine("		simplex(tableau): ");
			//ConsoleWrite(tableau); Console.WriteLine();

			//Console.WriteLine("		resulting maximization: ");
			//ConsoleWrite(simplex_result);

			#endregion

			#region Symbolic Differentiation

			Console.WriteLine("	Symbolics---------------------------------------");
			Console.WriteLine();

			//Type the function you want to differentiate
			Expression<Func<double, double, double, double>> function = (x, y, z) => Math.Pow(x, 3) * y - Math.Pow(x, y) + 5 * z;
			var node = Expressions2Tree.Parse(function);
			Console.WriteLine("		Differentiation:");
			Console.WriteLine("			F(x,y,z) = " + node);

			// Differentiation (respect to "x")
			Console.Write("			dF/dx = ");
			var result = ComputerAlgebra.Differentiate(node, variable: "x");
			Console.WriteLine(result);

			// Differentiation (respect to "y")
			Console.Write("			dF/dy = ");
			result = ComputerAlgebra.Differentiate(node, variable: "y");
			Console.WriteLine(result);

			// Differentiation (respect to "z")
			Console.Write("			dF/dz = ");
			result = ComputerAlgebra.Differentiate(node, variable: "z");
			Console.WriteLine(result);
			Console.WriteLine();

			#endregion

			Console.WriteLine();
			Console.WriteLine("=================================================");
			Console.WriteLine("Example Complete...");
			Console.ReadLine();
		}

		#region Output Helpers

		public static void ConsoleWrite(Quaternion<double> quaternion)
		{
			Console.WriteLine(
				"			[ x " +
				string.Format("{0:0.00}", quaternion.X) + ", y " +
				string.Format("{0:0.00}", quaternion.Y) + ", z " +
				string.Format("{0:0.00}", quaternion.Z) + ", w " +
				string.Format("{0:0.00}", quaternion.W) + " ]");
			Console.WriteLine();
		}

		public static void ConsoleWrite(Vector<double> vector)
		{
			Console.Write("			[ ");
			for (int i = 0; i < vector.Dimensions - 1; i++)
				Console.Write(string.Format("{0:0.00}", vector[i]) + ", ");
			Console.WriteLine(string.Format("{0:0.00}", vector[vector.Dimensions - 1] + " ]"));
			Console.WriteLine();
		}

		public static void ConsoleWrite(Matrix<double> matrix)
		{
			for (int i = 0; i < matrix.Rows; i++)
			{
				Console.Write("			[ ");
				for (int j = 0; j < matrix.Columns; j++)
					Console.Write(string.Format("{0:0.00}", matrix[i, j]) + " ");
				Console.WriteLine("]");
			}
			Console.WriteLine();
		}

		public static void ConsoleWrite(double[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				Console.Write("			[ ");
				for (int j = 0; j < matrix.GetLength(1); j++)
					Console.Write(string.Format("{0:0.00}", matrix[i, j]) + " ");
				Console.WriteLine("]");
			}
			Console.WriteLine();
		}

		#endregion
	}
}
