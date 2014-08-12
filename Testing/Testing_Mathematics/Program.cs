using System;
//using MathNet.Numerics.LinearAlgebra.Double;
using System.Diagnostics;
using Seven.Mathematics;

namespace ConsoleApplication
{
  class Program
  {
    static Random random = new Random();

    static void Main(string[] args)
    {
      Console.Write("The Testing_Mathematics Project is not yet ready.");
      Console.ReadLine();
      return;

      int iterations3x3 = 1000000;
      int iterations1000x1000 = 1;

      Stopwatch timer = new Stopwatch();

      double[,] A = new double[,]
      { 
        { random.NextDouble(), random.NextDouble(), random.NextDouble() },
        { random.NextDouble(), random.NextDouble(), random.NextDouble() },
        { random.NextDouble(), random.NextDouble(), random.NextDouble() }
      };

      double[,] B = new double[,]
      { 
        { random.NextDouble(), random.NextDouble(), random.NextDouble() },
        { random.NextDouble(), random.NextDouble(), random.NextDouble() },
        { random.NextDouble(), random.NextDouble(), random.NextDouble() }
      };

      double[,] C = new double[1000, 1000];
      for (int i = 0; i < 1000; i++)
        for (int j = 0; j < 1000; j++)
          C[i, j] = random.NextDouble();

      double[,] D = new double[1000, 1000];
      for (int i = 0; i < 1000; i++)
        for (int j = 0; j < 1000; j++)
          D[i, j] = random.NextDouble();

      ////DenseMatrix mathnet_matrix_a = DenseMatrix.OfArray(A.Clone() as double[,]);
      ////DenseMatrix mathnet_matrix_b = DenseMatrix.OfArray(B.Clone() as double[,]);
      ////DenseMatrix mathnet_matrix_r;
      //timer.Restart();
      //for (int i = 0; i < iterations3x3; i++)
      //  mathnet_matrix_r = mathnet_matrix_a * mathnet_matrix_b;
      //timer.Stop();
      //Console.WriteLine("Math.Net:\t" + timer.ElapsedTicks);

      Matrix<double> seven_matrix_a = A.Clone() as double[,];
      Matrix<double> seven_matrix_b = B.Clone() as double[,];
      Matrix<double> seven_matrix_r;
      timer.Restart();
      for (int i = 0; i < iterations3x3; i++)
        seven_matrix_r = seven_matrix_a * seven_matrix_b;
      timer.Stop();
      Console.WriteLine("Matrix:\t\t" + timer.ElapsedTicks);

      double[,] R;
      timer.Restart();
      for (int i = 0; i < iterations3x3; i++)
        R = A.Multiply(B);
      timer.Stop();
      Console.WriteLine("Extension:\t" + timer.ElapsedTicks);

      Matrix_flat<double> seven_matrix_flat_a = new Matrix_flat<double>(A.Clone() as double[,]);
      Matrix_flat<double> seven_matrix_flat_b = new Matrix_flat<double>(B.Clone() as double[,]);
      Matrix_flat<double> seven_matrix_flat_r;
      timer.Restart();
      for (int i = 0; i < iterations3x3; i++)
        seven_matrix_flat_r = LinearAlgebra.Multiply(seven_matrix_flat_a, seven_matrix_flat_b);
      timer.Stop();
      Console.WriteLine("Flat:\t\t" + timer.ElapsedTicks);

      //Matrix_flat<double> seven_matrix_flat_a = new Matrix_flat<double>(A.Clone() as double[,]);
      //Matrix_flat<double> seven_matrix_flat_b = new Matrix_flat<double>(B.Clone() as double[,]);
      //Matrix_flat<double> seven_matrix_flat_r;
      timer.Restart();
      for (int i = 0; i < iterations3x3; i++)
        seven_matrix_flat_r = LinearAlgebra.Multiply(seven_matrix_flat_a, seven_matrix_flat_b);
      timer.Stop();
      Console.WriteLine("Unsafe:\t\t" + timer.ElapsedTicks);




      //DenseMatrix mathnet__matrix__a = DenseMatrix.OfArray(C.Clone() as double[,]);
      //DenseMatrix mathnet__matrix__b = DenseMatrix.OfArray(D.Clone() as double[,]);
      //DenseMatrix mathnet__matrix__r;
      //timer.Restart();
      //for (int i = 0; i < iterations1000x1000; i++)
      //  mathnet__matrix__r = mathnet__matrix__a * mathnet__matrix__b;
      //timer.Stop();
      //Console.WriteLine("Math.Net(1000x1000):\t" + timer.ElapsedTicks);

      //Matrix<double> seven__matrix__a = C.Clone() as double[,];
      //Matrix<double> seven__matrix__b = D.Clone() as double[,];
      //Matrix<double> seven__matrix__r;
      //timer.Restart();
      //for (int i = 0; i < iterations1000x1000; i++)
      //  seven__matrix__r = seven__matrix__a * seven__matrix__b;
      //timer.Stop();
      //Console.WriteLine("Matrix(1000x1000):\t\t" + timer.ElapsedTicks);

      //double[,] R2;
      //timer.Restart();
      //for (int i = 0; i < iterations1000x1000; i++)
      //  R2 = C.Multiply(B);
      //timer.Stop();
      //Console.WriteLine("Extension(1000x1000):\t" + timer.ElapsedTicks);

      Matrix_flat<double> seven__matrix__flat__a = new Matrix_flat<double>(C.Clone() as double[,]);
      Matrix_flat<double> seven__matrix__flat__b = new Matrix_flat<double>(D.Clone() as double[,]);
      Matrix_flat<double> seven__matrix__flat__r;
      //timer.Restart();
      //for (int i = 0; i < iterations1000x1000; i++)
      //  seven__matrix__flat__r = LinearAlgebra.Multiply(seven__matrix__flat__a, seven__matrix__flat__b);
      //timer.Stop();
      //Console.WriteLine("Flat(1000x1000):\t\t" + timer.ElapsedTicks);

      ////Matrix__flat<double> seven__matrix__flat__a = new Matrix__flat<double>(C.Clone() as double[,]);
      ////Matrix__flat<double> seven__matrix__flat__b = new Matrix__flat<double>(D.Clone() as double[,]);
      ////Matrix__flat<double> seven__matrix__flat__r;
      //timer.Restart();
      //for (int i = 0; i < iterations1000x1000; i++)
      //  seven__matrix__flat__r = LinearAlgebra.Multiply_unsafe(seven__matrix__flat__a, seven__matrix__flat__b);
      //timer.Stop();
      //Console.WriteLine("Unsafe(1000x1000):\t" + timer.ElapsedTicks);



      Console.ReadLine();
    }
  }
}
