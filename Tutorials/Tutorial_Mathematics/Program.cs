using System;
using Seven;
using Seven.Mathematics;
using Seven.Mathematics.Symbolics;
using System.Linq.Expressions;
using Seven.Mathematics.Symbolics.Tools;

using Seven.Mathematics.Syntax;

namespace Tutorial_Mathematics
{
  class Program
  {
    // Gets randomized values
    public static Random random = new Random();

    static void Main(string[] args)
    {
      Console.WriteLine("Welcome To SevenFramework!!!!");
      Console.WriteLine();
      Console.WriteLine("You are runnning the Mathematics tutorial. Its purpose");
      Console.WriteLine("is to show you examples of you to use the mathematics");
      Console.WriteLine("provided in the SevenFramework.");
      Console.WriteLine();
      Console.WriteLine("Mathematics===========================================");
      Console.WriteLine();

      #region Algebra

      Console.WriteLine("  Algebra---------------------------------------------");
      Console.WriteLine();

      // Prime Checking
      int prime_check = random.Next(0, 100000);
      Console.WriteLine("    isprime(" + prime_check + "): " + _.isprime(prime_check));
      Console.WriteLine();

      // Prime Factorization
      int prime_factors = random.Next(0, 100000);
      Console.Write("    prime-factors(" + prime_factors + "): ");
      Algebra.PrimeFactors(prime_factors, (int i) => { Console.Write(i + " "); });
      Console.WriteLine();
      Console.WriteLine();

      // Greatest Common Denominators
      int gdc_1 = random.Next(10000, 100000), gdc_2 = random.Next(10000, 100000);
      Console.Write("    GDC(" + gdc_1 + ", " + gdc_2 + "): " + _.gdc(gdc_1, gdc_2));
      Console.WriteLine();
      Console.WriteLine();

      // Logarithms
      int log_1 = random.Next(0, 11), log_2 = random.Next(0, 100000);
      Console.WriteLine("    log_" + log_1 + "(" + log_2 + "): " + _.log(log_1, log_2));
      Console.WriteLine();

      #endregion

      #region Combinatorics

      Console.WriteLine("  Combinatorics--------------------------------------");
      Console.WriteLine();

      // Factorials
      Console.WriteLine("    7!: " + _.fact(7));
      Console.WriteLine();

      // Combinations
      Console.WriteLine("    7! / (3! * 4!): " + _.combin(7, 3, 4));
      Console.WriteLine();

      // Choose
      Console.WriteLine("    7 choose 2: " + _.choose(7, 2));
      Console.WriteLine();
    
      #endregion

      #region Linear Algebra

      Console.WriteLine("  Linear Algebra------------------------------------");
      Console.WriteLine();

      // Vector Construction
      Vector<double> V = new double[]
      {
        random.NextDouble(),
        random.NextDouble(),
        random.NextDouble(),
        random.NextDouble(),
      };

      Console.WriteLine("    Vector<double> V: ");
      ConsoleWrite(V);

      // Vector Addition
      Console.WriteLine("    V + V (aka 2V): ");
      ConsoleWrite(V + V);

      // Vector Dot Product
      Console.WriteLine("    V dot V: " + V.DotProduct(V));

      Console.WriteLine();

      // Vector Cross Product
      Console.WriteLine("    V cross V: ");
      ConsoleWrite(_.cros(V, V));

      // Matrix Construction
      Matrix<double> M = new double[,]
      {
        { random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble() },
        { random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble() },
        { random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble() },
        { random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble() },
      };

      Console.WriteLine("    Matrix<double> M: ");
      ConsoleWrite(M);

      // Matrix Addition
      Console.WriteLine("    M + M (aka 2M): ");
      ConsoleWrite(M + M);

      // Matrix Multiplication
      Console.WriteLine("    M * M (aka M ^ 2): ");
      ConsoleWrite(M * M);

      // Matrix Power
      Console.WriteLine("    M ^ 3: ");
      ConsoleWrite(M ^ 3);

      // Matrix Reduced Row Echelon
      Console.WriteLine("    rref(M): ");
      ConsoleWrite(_.rref(M));

      // Matrix Determinant
      Console.WriteLine("    determinent(M): " + string.Format("{0:0.00}", _.det(M)));
      Console.WriteLine();

      // Matrix-Vector Multiplication
      Console.WriteLine("    M * V: ");
      ConsoleWrite(M * V);

      // Matrix Lower-Upper Decomposition
      double[,] l, u;
      LinearAlgebra.DecomposeLU(M, out l, out u);
      Console.WriteLine("    Lower-Upper Decomposition:");
      Console.WriteLine();
      Console.WriteLine("      lower(M):");
      ConsoleWrite(l);
      Console.WriteLine("      upper(M):");
      ConsoleWrite(u);

      // Quaternion Construction
      Quaternion<double> Q = new Quaternion<double>(
        random.NextDouble(),
        random.NextDouble(),
        random.NextDouble(),
        1.0d);

      Console.WriteLine("    Quaternion<double> Q: ");
      ConsoleWrite(Q);

      // Quaternion Addition
      Console.WriteLine("    Q + Q (aka 2Q):");
      ConsoleWrite(Q + Q);

      // Quaternion-Vector Rotation
      Console.WriteLine("    Q * V * Q':");
      ConsoleWrite(V.RotateBy(Q));

      #endregion

      #region Symbolic Differentiation

      Console.WriteLine("  Symbolics---------------------------------------");
      Console.WriteLine();

      //Type the function you want to differentiate
      Expression<function_3<double>> function = (x, y, z) => Math.Pow(x, 3) * y - Math.Pow(x, y) + 5 * z;
      var node = Expressions2Tree.Parse(function);
      Console.WriteLine("    Differentiation:");
      Console.WriteLine("      F(x,y,z) = " + node);

      // Differentiation (respect to "x")
      Console.Write("      dF/dx = ");
      var result = ComputerAlgebra.Differentiate(node, variable: "x");
      Console.WriteLine(result);

      // Differentiation (respect to "y")
      Console.Write("      dF/dy = ");
      result = ComputerAlgebra.Differentiate(node, variable: "y");
      Console.WriteLine(result);

      // Differentiation (respect to "z")
      Console.Write("      dF/dz = ");
      result = ComputerAlgebra.Differentiate(node, variable: "z");
      Console.WriteLine(result);
    
      #endregion

      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine("=================================================");
      Console.WriteLine(" Tutorials Complete...");
      Console.ReadLine();
    }

    #region Output Helpers

    public static void ConsoleWrite(Quaternion<double> quaternion)
    {
      Console.WriteLine(
        "      [ x " + 
        string.Format("{0:0.00}", quaternion.X) + ", y " + 
        string.Format("{0:0.00}", quaternion.Y) + ", z " + 
        string.Format("{0:0.00}", quaternion.Z) + ", w " + 
        string.Format("{0:0.00}", quaternion.W) + " ]");
      Console.WriteLine();
    }

    public static void ConsoleWrite(Vector<double> vector)
    {
      Console.Write("      [ ");
      for (int i = 0; i < vector.Dimensions - 1; i++)
        Console.Write(string.Format("{0:0.00}", vector[i]) + ", ");
      Console.WriteLine(string.Format("{0:0.00}", vector[vector.Dimensions - 1] + " ]"));
      Console.WriteLine();
    }

    public static void ConsoleWrite(Matrix<double> matrix)
    {
      for (int i = 0; i < matrix.Rows; i++)
      {
        Console.Write("      [ ");
        for (int j = 0; j < matrix.Columns; j++)
          Console.Write(string.Format("{0:0.00}", matrix[i, j]) + " ");
        Console.WriteLine("]");
      }
      Console.WriteLine();
    }

    #endregion
  }
}
