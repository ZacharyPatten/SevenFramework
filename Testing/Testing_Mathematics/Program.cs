using System;
using System.Diagnostics;

using SevenMath = Seven.Mathematics;
// SevenFramework

using MathDotNet = MathNet.Numerics.LinearAlgebra;
using System.Runtime.InteropServices;
// Math.Net
// Link: https://github.com/mathnet/mathnet-numerics

namespace ConsoleApplication
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome To SevenFramework!!!!");
      Console.WriteLine();
      Console.WriteLine("You are runnning the Testing project. Its purpose");
      Console.WriteLine("test the functionality of the Seven framework and");
      Console.WriteLine("its speed compared to other available frameworks.");
      Console.WriteLine("FOR ACCUTATE SPEED TESTING BE SURE THE APPROPRIATE");
      Console.WriteLine("COMPILATION WAS USED (PREPROCESSOR DIRECTIVES) AND");
      Console.WriteLine("THE EXE IS RUN OUTSIDE OF A DEBUGGER.");
      Console.WriteLine();
      Console.WriteLine("Mathematics===========================================");
      Console.WriteLine();

      Seven_vs_MathNet();
      Seven_vs_Structs();

      Console.WriteLine();
      Console.WriteLine("=================================================");
      Console.WriteLine(" Testing Complete...");
      Console.ReadLine();
    }

    #region Seven_vs_MathNet

    public enum MatrixOperation { Negate, Add, Subtract, Multiply, RowReduceEchelon };
    public enum MatrixType { Double, Float, Long, Int, Decimal };

    public static void Seven_vs_MathNet()
    {
      Test_Matrix(MatrixType.Double, 3, 3, 100000, MatrixOperation.Negate);
      Test_Matrix(MatrixType.Double, 1000, 1000, 1, MatrixOperation.Negate);

      Test_Matrix(MatrixType.Double, 3, 3, 100000, MatrixOperation.Add);
      Test_Matrix(MatrixType.Double, 1000, 1000, 1, MatrixOperation.Add);

      Test_Matrix(MatrixType.Double, 3, 3, 100000, MatrixOperation.Subtract);
      Test_Matrix(MatrixType.Double, 1000, 1000, 1, MatrixOperation.Subtract);

      Test_Matrix(MatrixType.Double, 3, 3, 100000, MatrixOperation.Multiply);
      Test_Matrix(MatrixType.Double, 1000, 1000, 1, MatrixOperation.Multiply);

      //Test_Matrix(MatrixType.Decimal, 3, 3, 100000, MatrixOperation.Negate);
      //Test_Matrix(MatrixType.Decimal, 1000, 1000, 1, MatrixOperation.Negate);

      //Test_Matrix(MatrixType.Decimal, 3, 3, 100000, MatrixOperation.Add);
      //Test_Matrix(MatrixType.Decimal, 1000, 1000, 1, MatrixOperation.Add);

      //Test_Matrix(MatrixType.Decimal, 3, 3, 100000, MatrixOperation.Subtract);
      //Test_Matrix(MatrixType.Decimal, 1000, 1000, 1, MatrixOperation.Subtract);

      //Test_Matrix(MatrixType.Decimal, 3, 3, 100000, MatrixOperation.Multiply);
      //Test_Matrix(MatrixType.Decimal, 1000, 1000, 1, MatrixOperation.Multiply);

      //Test_Matrix(MatrixType.Float, 3, 3, 100000, MatrixOperation.Negate);
      //Test_Matrix(MatrixType.Float, 1000, 1000, 1, MatrixOperation.Negate);

      //Test_Matrix(MatrixType.Float, 3, 3, 100000, MatrixOperation.Add);
      //Test_Matrix(MatrixType.Float, 1000, 1000, 1, MatrixOperation.Add);

      //Test_Matrix(MatrixType.Float, 3, 3, 100000, MatrixOperation.Subtract);
      //Test_Matrix(MatrixType.Float, 1000, 1000, 1, MatrixOperation.Subtract);

      //Test_Matrix(MatrixType.Float, 3, 3, 100000, MatrixOperation.Multiply);
      //Test_Matrix(MatrixType.Float, 1000, 1000, 1, MatrixOperation.Multiply);

      //Test_Matrix(MatrixType.Int, 3, 3, 100000, MatrixOperation.Negate);
      //Test_Matrix(MatrixType.Int, 1000, 1000, 1, MatrixOperation.Negate);

      //Test_Matrix(MatrixType.Int, 3, 3, 100000, MatrixOperation.Add);
      //Test_Matrix(MatrixType.Int, 1000, 1000, 1, MatrixOperation.Add);

      //Test_Matrix(MatrixType.Int, 3, 3, 100000, MatrixOperation.Subtract);
      //Test_Matrix(MatrixType.Int, 1000, 1000, 1, MatrixOperation.Subtract);

      //Test_Matrix(MatrixType.Int, 3, 3, 100000, MatrixOperation.Multiply);
      //Test_Matrix(MatrixType.Int, 1000, 1000, 1, MatrixOperation.Multiply);
    }

    public static void Test_Matrix(MatrixType type, int rows, int columns, int iterations, MatrixOperation operation)
    {
      Console.WriteLine("Testing Matrix<" + type.ToString() + "> " + 
        operation.ToString() + " " + rows + "x" + columns + " " + iterations + " iterations");

      Random random = new Random();
      Stopwatch timer = new Stopwatch();

      if (type == MatrixType.Double)
      {
        #region double

        double[,] A = new double[rows, columns];
        for (int i = 0; i < rows; i++)
          for (int j = 0; j < columns; j++)
            A[i, j] = random.NextDouble();

        double[,] B = new double[rows, columns];
        for (int i = 0; i < rows; i++)
          for (int j = 0; j < columns; j++)
            B[i, j] = random.NextDouble();

        #region Math.Net

        MathDotNet.Matrix<double> mathnet_matrix_a = MathDotNet.Matrix<double>.Build.DenseOfArray(A.Clone() as double[,]);
        MathDotNet.Matrix<double> mathnet_matrix_b = MathDotNet.Matrix<double>.Build.DenseOfArray(B.Clone() as double[,]);
        MathDotNet.Matrix<double> mathnet_matrix_r;
        if (operation == MatrixOperation.Negate)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            mathnet_matrix_r = -mathnet_matrix_a;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Add)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            mathnet_matrix_r = mathnet_matrix_a + mathnet_matrix_b;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Multiply)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            mathnet_matrix_r = mathnet_matrix_a * mathnet_matrix_b;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Subtract)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            mathnet_matrix_r = mathnet_matrix_a - mathnet_matrix_b;
          timer.Stop();
        }
        Console.WriteLine("  Math.Net:\t" + timer.ElapsedTicks);

        #endregion

        #region Seven

        SevenMath.Matrix<double> seven_matrix_a = new SevenMath.Matrix<double>(A.Clone() as double[,]);
        SevenMath.Matrix<double> seven_matrix_b = new SevenMath.Matrix<double>(B.Clone() as double[,]);
        SevenMath.Matrix<double> seven_matrix_r;
        if (operation == MatrixOperation.Negate)
        {
          if (rows + columns > 64)
          {
            timer.Restart();
            for (int i = 0; i < iterations; i++)
              seven_matrix_r = SevenMath.LinearAlgebra.Negate_parallel(seven_matrix_a);
            timer.Stop();
          }
          else
          {
            timer.Restart();
            for (int i = 0; i < iterations; i++)
              seven_matrix_r = -seven_matrix_a;
            timer.Stop();
          }
        }
        else if (operation == MatrixOperation.Multiply)
        {
          if (rows + columns > 64)
          {
            timer.Restart();
            for (int i = 0; i < iterations; i++)
              seven_matrix_r = SevenMath.LinearAlgebra.Multiply_parrallel(seven_matrix_a, seven_matrix_b);
            timer.Stop();
          }
          else
          {
            timer.Restart();
            for (int i = 0; i < iterations; i++)
              seven_matrix_r = seven_matrix_a * seven_matrix_b;
            timer.Stop();
          }
        }
        else if (operation == MatrixOperation.Subtract)
        {
          if (rows + columns > 64)
          {
            timer.Restart();
            for (int i = 0; i < iterations; i++)
              seven_matrix_r = SevenMath.LinearAlgebra.Subtract_parallel(seven_matrix_a, seven_matrix_b);
            timer.Stop();
          }
          else
          {
            timer.Restart();
            for (int i = 0; i < iterations; i++)
              seven_matrix_r = seven_matrix_a - seven_matrix_b;
            timer.Stop();
          }
        }
        else if (operation == MatrixOperation.Add)
        {
          if (rows + columns > 64)
          {
            timer.Restart();
            for (int i = 0; i < iterations; i++)
              seven_matrix_r = SevenMath.LinearAlgebra.Add_parallel(seven_matrix_a, seven_matrix_b);
            timer.Stop();
          }
          else
          {
            timer.Restart();
            for (int i = 0; i < iterations; i++)
              seven_matrix_r = seven_matrix_a + seven_matrix_b;
            timer.Stop();
          }
        }
        Console.WriteLine("  Seven:\t" + timer.ElapsedTicks);

        #endregion

        #endregion
      }
      else if (type == MatrixType.Decimal)
      {
        #region decimal

        decimal[,] A = new decimal[rows, columns];
        for (int i = 0; i < rows; i++)
          for (int j = 0; j < columns; j++)
            A[i, j] = (decimal)random.NextDouble();

        decimal[,] B = new decimal[rows, columns];
        for (int i = 0; i < rows; i++)
          for (int j = 0; j < columns; j++)
            B[i, j] = (decimal)random.NextDouble();

        #region Math.Net

        MathDotNet.Matrix<decimal> mathnet_matrix_a = MathDotNet.Matrix<decimal>.Build.DenseOfArray(A.Clone() as decimal[,]);
        MathDotNet.Matrix<decimal> mathnet_matrix_b = MathDotNet.Matrix<decimal>.Build.DenseOfArray(B.Clone() as decimal[,]);
        MathDotNet.Matrix<decimal> mathnet_matrix_r;
        if (operation == MatrixOperation.Negate)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            mathnet_matrix_r = -mathnet_matrix_a;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Add)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            mathnet_matrix_r = mathnet_matrix_a + mathnet_matrix_b;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Multiply)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            mathnet_matrix_r = mathnet_matrix_a * mathnet_matrix_b;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Subtract)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            mathnet_matrix_r = mathnet_matrix_a - mathnet_matrix_b;
          timer.Stop();
        }
        Console.WriteLine("  Math.Net:\t" + timer.ElapsedTicks);

        #endregion

        #region Seven

        SevenMath.Matrix<decimal> seven_matrix_a = new SevenMath.Matrix<decimal>(A.Clone() as decimal[,]);
        SevenMath.Matrix<decimal> seven_matrix_b = new SevenMath.Matrix<decimal>(B.Clone() as decimal[,]);
        SevenMath.Matrix<decimal> seven_matrix_r;
        if (operation == MatrixOperation.Negate)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            seven_matrix_r = -seven_matrix_a;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Multiply)
        {
          if (rows + columns > 64)
          {
            timer.Restart();
            for (int i = 0; i < iterations; i++)
              seven_matrix_r = SevenMath.LinearAlgebra.Multiply_parrallel(seven_matrix_a, seven_matrix_b);
            timer.Stop();
          }
          else
          {
            timer.Restart();
            for (int i = 0; i < iterations; i++)
              seven_matrix_r = seven_matrix_a * seven_matrix_b;
            timer.Stop();
          }
        }
        else if (operation == MatrixOperation.Subtract)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            seven_matrix_r = seven_matrix_a - seven_matrix_b;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Add)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            seven_matrix_r = seven_matrix_a + seven_matrix_b;
          timer.Stop();
        }
        Console.WriteLine("  Seven:\t" + timer.ElapsedTicks);

        #endregion

        #endregion
      }
      else if (type == MatrixType.Float)
      {
        #region float

        float[,] A = new float[rows, columns];
        for (int i = 0; i < rows; i++)
          for (int j = 0; j < columns; j++)
            A[i, j] = (float)random.NextDouble();

        float[,] B = new float[rows, columns];
        for (int i = 0; i < rows; i++)
          for (int j = 0; j < columns; j++)
            B[i, j] = (float)random.NextDouble();

        #region Math.Net

        MathDotNet.Matrix<float> mathnet_matrix_a = MathDotNet.Matrix<float>.Build.DenseOfArray(A.Clone() as float[,]);
        MathDotNet.Matrix<float> mathnet_matrix_b = MathDotNet.Matrix<float>.Build.DenseOfArray(B.Clone() as float[,]);
        MathDotNet.Matrix<float> mathnet_matrix_r;
        if (operation == MatrixOperation.Negate)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            mathnet_matrix_r = -mathnet_matrix_a;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Add)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            mathnet_matrix_r = mathnet_matrix_a + mathnet_matrix_b;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Multiply)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            mathnet_matrix_r = mathnet_matrix_a * mathnet_matrix_b;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Subtract)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            mathnet_matrix_r = mathnet_matrix_a - mathnet_matrix_b;
          timer.Stop();
        }
        Console.WriteLine("  Math.Net:\t" + timer.ElapsedTicks);

        #endregion

        #region Seven

        SevenMath.Matrix<float> seven_matrix_a = new SevenMath.Matrix<float>(A.Clone() as float[,]);
        SevenMath.Matrix<float> seven_matrix_b = new SevenMath.Matrix<float>(B.Clone() as float[,]);
        SevenMath.Matrix<float> seven_matrix_r;
        if (operation == MatrixOperation.Negate)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            seven_matrix_r = -seven_matrix_a;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Multiply)
        {
          if (rows + columns > 64)
          {
            timer.Restart();
            for (int i = 0; i < iterations; i++)
              seven_matrix_r = SevenMath.LinearAlgebra.Multiply_parrallel(seven_matrix_a, seven_matrix_b);
            timer.Stop();
          }
          else
          {
            timer.Restart();
            for (int i = 0; i < iterations; i++)
              seven_matrix_r = seven_matrix_a * seven_matrix_b;
            timer.Stop();
          }
        }
        else if (operation == MatrixOperation.Subtract)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            seven_matrix_r = seven_matrix_a - seven_matrix_b;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Add)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            seven_matrix_r = seven_matrix_a + seven_matrix_b;
          timer.Stop();
        }
        Console.WriteLine("  Seven:\t" + timer.ElapsedTicks);

        #endregion

        #endregion
      }
      else if (type == MatrixType.Int)
      {
        #region int

        int[,] A = new int[rows, columns];
        for (int i = 0; i < rows; i++)
          for (int j = 0; j < columns; j++)
            A[i, j] = random.Next();

        int[,] B = new int[rows, columns];
        for (int i = 0; i < rows; i++)
          for (int j = 0; j < columns; j++)
            B[i, j] = random.Next();

        #region Math.Net

        MathDotNet.Matrix<int> mathnet_matrix_a = MathDotNet.Matrix<int>.Build.DenseOfArray(A.Clone() as int[,]);
        MathDotNet.Matrix<int> mathnet_matrix_b = MathDotNet.Matrix<int>.Build.DenseOfArray(B.Clone() as int[,]);
        MathDotNet.Matrix<int> mathnet_matrix_r;
        if (operation == MatrixOperation.Negate)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            mathnet_matrix_r = -mathnet_matrix_a;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Add)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            mathnet_matrix_r = mathnet_matrix_a + mathnet_matrix_b;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Multiply)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            mathnet_matrix_r = mathnet_matrix_a * mathnet_matrix_b;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Subtract)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            mathnet_matrix_r = mathnet_matrix_a - mathnet_matrix_b;
          timer.Stop();
        }
        Console.WriteLine("  Math.Net:\t" + timer.ElapsedTicks);

        #endregion

        #region Seven

        SevenMath.Matrix<int> seven_matrix_a = new SevenMath.Matrix<int>(A.Clone() as int[,]);
        SevenMath.Matrix<int> seven_matrix_b = new SevenMath.Matrix<int>(B.Clone() as int[,]);
        SevenMath.Matrix<int> seven_matrix_r;
        if (operation == MatrixOperation.Negate)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            seven_matrix_r = -seven_matrix_a;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Multiply)
        {
          if (rows + columns > 64)
          {
            timer.Restart();
            for (int i = 0; i < iterations; i++)
              seven_matrix_r = SevenMath.LinearAlgebra.Multiply_parrallel(seven_matrix_a, seven_matrix_b);
            timer.Stop();
          }
          else
          {
            timer.Restart();
            for (int i = 0; i < iterations; i++)
              seven_matrix_r = seven_matrix_a * seven_matrix_b;
            timer.Stop();
          }
        }
        else if (operation == MatrixOperation.Subtract)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            seven_matrix_r = seven_matrix_a - seven_matrix_b;
          timer.Stop();
        }
        else if (operation == MatrixOperation.Add)
        {
          timer.Restart();
          for (int i = 0; i < iterations; i++)
            seven_matrix_r = seven_matrix_a + seven_matrix_b;
          timer.Stop();
        }
        Console.WriteLine("  Seven:\t" + timer.ElapsedTicks);

        #endregion

        #endregion
      }
    }

    #endregion

    #region Seven_vs_Structs

    public static void Seven_vs_Structs()
    {
      int iterations = 1000000;

      Random random = new Random();

      double[,] A = new double[,]
      {
        { random.NextDouble(), random.NextDouble(), random.NextDouble() },
        { random.NextDouble(), random.NextDouble(), random.NextDouble() },
        { random.NextDouble(), random.NextDouble(), random.NextDouble() },
      };

      double[,] B = new double[,]
      {
        { random.NextDouble(), random.NextDouble(), random.NextDouble() },
        { random.NextDouble(), random.NextDouble(), random.NextDouble() },
        { random.NextDouble(), random.NextDouble(), random.NextDouble() },
      };

      SevenMath.Matrix<double> seven_A = new SevenMath.Matrix<double>(A.Clone() as double[,]);
      SevenMath.Matrix<double> seven_B = new SevenMath.Matrix<double>(A.Clone() as double[,]);
      SevenMath.Matrix<double> seven_R;

      Matrix3d struct_A = new Matrix3d(
        A[0, 0], A[0, 1], A[0, 2],
        A[1, 0], A[1, 1], A[1, 2],
        A[2, 0], A[2, 1], A[2, 2]);

      Matrix3d struct_B = new Matrix3d(
        B[0, 0], B[0, 1], B[0, 2],
        B[1, 0], B[1, 1], B[1, 2],
        B[2, 0], B[2, 1], B[2, 2]);

      Matrix3d struct_R;

      Console.WriteLine("Testing Matrix 3x3 (struct vs Seven) Multiplication");

      Stopwatch timer = new Stopwatch();

      timer.Restart();
      for (int i = 0; i < iterations; i++)
        seven_R = seven_A * seven_B;
      timer.Stop();
      long seven_ticks = timer.ElapsedTicks;
      Console.WriteLine("Seven: " + timer.ElapsedTicks);

      timer.Restart();
      for (int i = 0; i < iterations; i++)
        Matrix3d.Mult(ref struct_A, ref struct_B, out struct_R);
      timer.Stop();
      long struct_ticks = timer.ElapsedTicks;
      Console.WriteLine("Struct: " + timer.ElapsedTicks);

      Console.WriteLine("Ratio: " + ((decimal)seven_ticks / (decimal)struct_ticks));
    }

    #region Vector3 (from OpenTK)

    /// <summary>
    /// Represents a 3D vector using three double-precision floating-point numbers.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3d : IEquatable<Vector3d>
    {
      #region Fields

      /// <summary>
      /// The X component of the Vector3.
      /// </summary>
      public double X;

      /// <summary>
      /// The Y component of the Vector3.
      /// </summary>
      public double Y;

      /// <summary>
      /// The Z component of the Vector3.
      /// </summary>
      public double Z;

      #endregion

      #region Constructors

      /// <summary>
      /// Constructs a new instance.
      /// </summary>
      /// <param name="value">The value that will initialize this instance.</param>
      public Vector3d(double value)
      {
        X = value;
        Y = value;
        Z = value;
      }

      /// <summary>
      /// Constructs a new Vector3.
      /// </summary>
      /// <param name="x">The x component of the Vector3.</param>
      /// <param name="y">The y component of the Vector3.</param>
      /// <param name="z">The z component of the Vector3.</param>
      public Vector3d(double x, double y, double z)
      {
        X = x;
        Y = y;
        Z = z;
      }

      /// <summary>
      /// Constructs a new instance from the given Vector3d.
      /// </summary>
      /// <param name="v">The Vector3d to copy components from.</param>
      public Vector3d(Vector3d v)
      {
        X = v.X;
        Y = v.Y;
        Z = v.Z;
      }

      #endregion

      #region Public Members

      /// <summary>
      /// Gets or sets the value at the index of the Vector.
      /// </summary>
      public double this[int index]
      {
        get
        {
          if (index == 0) return X;
          else if (index == 1) return Y;
          else if (index == 2) return Z;
          throw new IndexOutOfRangeException("You tried to access this vector at index: " + index);
        }
        set
        {
          if (index == 0) X = value;
          else if (index == 1) Y = value;
          else if (index == 2) Z = value;
          else throw new IndexOutOfRangeException("You tried to set this vector at index: " + index);
        }
      }

      #region Instance

      #region public void Add()

      /// <summary>Add the Vector passed as parameter to this instance.</summary>
      /// <param name="right">Right operand. This parameter is only read from.</param>
      [CLSCompliant(false)]
      [Obsolete("Use static Add() method instead.")]
      public void Add(Vector3d right)
      {
        this.X += right.X;
        this.Y += right.Y;
        this.Z += right.Z;
      }

      /// <summary>Add the Vector passed as parameter to this instance.</summary>
      /// <param name="right">Right operand. This parameter is only read from.</param>
      [CLSCompliant(false)]
      [Obsolete("Use static Add() method instead.")]
      public void Add(ref Vector3d right)
      {
        this.X += right.X;
        this.Y += right.Y;
        this.Z += right.Z;
      }

      #endregion public void Add()

      #region public void Sub()

      /// <summary>Subtract the Vector passed as parameter from this instance.</summary>
      /// <param name="right">Right operand. This parameter is only read from.</param>
      [CLSCompliant(false)]
      [Obsolete("Use static Subtract() method instead.")]
      public void Sub(Vector3d right)
      {
        this.X -= right.X;
        this.Y -= right.Y;
        this.Z -= right.Z;
      }

      /// <summary>Subtract the Vector passed as parameter from this instance.</summary>
      /// <param name="right">Right operand. This parameter is only read from.</param>
      [CLSCompliant(false)]
      [Obsolete("Use static Subtract() method instead.")]
      public void Sub(ref Vector3d right)
      {
        this.X -= right.X;
        this.Y -= right.Y;
        this.Z -= right.Z;
      }

      #endregion public void Sub()

      #region public void Mult()

      /// <summary>Multiply this instance by a scalar.</summary>
      /// <param name="f">Scalar operand.</param>
      [Obsolete("Use static Multiply() method instead.")]
      public void Mult(double f)
      {
        this.X *= f;
        this.Y *= f;
        this.Z *= f;
      }

      #endregion public void Mult()

      #region public void Div()

      /// <summary>Divide this instance by a scalar.</summary>
      /// <param name="f">Scalar operand.</param>
      [Obsolete("Use static Divide() method instead.")]
      public void Div(double f)
      {
        double mult = 1.0 / f;
        this.X *= mult;
        this.Y *= mult;
        this.Z *= mult;
      }

      #endregion public void Div()

      #region public double Length

      /// <summary>
      /// Gets the length (magnitude) of the vector.
      /// </summary>
      /// <see cref="LengthFast"/>
      /// <seealso cref="LengthSquared"/>
      public double Length
      {
        get
        {
          return System.Math.Sqrt(X * X + Y * Y + Z * Z);
        }
      }

      #endregion


      #region public double LengthSquared

      /// <summary>
      /// Gets the square of the vector length (magnitude).
      /// </summary>
      /// <remarks>
      /// This property avoids the costly square root operation required by the Length property. This makes it more suitable
      /// for comparisons.
      /// </remarks>
      /// <see cref="Length"/>
      /// <seealso cref="LengthFast"/>
      public double LengthSquared
      {
        get
        {
          return X * X + Y * Y + Z * Z;
        }
      }

      #endregion

      /// <summary>
      /// Returns a copy of the Vector3d scaled to unit length.
      /// </summary>
      /// <returns></returns>
      public Vector3d Normalized()
      {
        Vector3d v = this;
        v.Normalize();
        return v;
      }

      #region public void Normalize()

      /// <summary>
      /// Scales the Vector3d to unit length.
      /// </summary>
      public void Normalize()
      {
        double scale = 1.0 / this.Length;
        X *= scale;
        Y *= scale;
        Z *= scale;
      }

      #endregion

      #region public void NormalizeFast()

      #region public void Scale()

      /// <summary>
      /// Scales the current Vector3d by the given amounts.
      /// </summary>
      /// <param name="sx">The scale of the X component.</param>
      /// <param name="sy">The scale of the Y component.</param>
      /// <param name="sz">The scale of the Z component.</param>
      [Obsolete("Use static Multiply() method instead.")]
      public void Scale(double sx, double sy, double sz)
      {
        this.X = X * sx;
        this.Y = Y * sy;
        this.Z = Z * sz;
      }

      /// <summary>Scales this instance by the given parameter.</summary>
      /// <param name="scale">The scaling of the individual components.</param>
      [Obsolete("Use static Multiply() method instead.")]
      [CLSCompliant(false)]
      public void Scale(Vector3d scale)
      {
        this.X *= scale.X;
        this.Y *= scale.Y;
        this.Z *= scale.Z;
      }

      /// <summary>Scales this instance by the given parameter.</summary>
      /// <param name="scale">The scaling of the individual components.</param>
      [Obsolete("Use static Multiply() method instead.")]
      [CLSCompliant(false)]
      public void Scale(ref Vector3d scale)
      {
        this.X *= scale.X;
        this.Y *= scale.Y;
        this.Z *= scale.Z;
      }

      #endregion public void Scale()

      #endregion

      #region Static

      #region Fields

      /// <summary>
      /// Defines a unit-length Vector3d that points towards the X-axis.
      /// </summary>
      public static readonly Vector3d UnitX = new Vector3d(1, 0, 0);

      /// <summary>
      /// Defines a unit-length Vector3d that points towards the Y-axis.
      /// </summary>
      public static readonly Vector3d UnitY = new Vector3d(0, 1, 0);

      /// <summary>
      /// /// Defines a unit-length Vector3d that points towards the Z-axis.
      /// </summary>
      public static readonly Vector3d UnitZ = new Vector3d(0, 0, 1);

      /// <summary>
      /// Defines a zero-length Vector3.
      /// </summary>
      public static readonly Vector3d Zero = new Vector3d(0, 0, 0);

      /// <summary>
      /// Defines an instance with all components set to 1.
      /// </summary>
      public static readonly Vector3d One = new Vector3d(1, 1, 1);

      /// <summary>
      /// Defines the size of the Vector3d struct in bytes.
      /// </summary>
      public static readonly int SizeInBytes = Marshal.SizeOf(new Vector3d());

      #endregion

      #region Obsolete

      #region Sub

      /// <summary>
      /// Subtract one Vector from another
      /// </summary>
      /// <param name="a">First operand</param>
      /// <param name="b">Second operand</param>
      /// <returns>Result of subtraction</returns>
      [Obsolete("Use static Subtract() method instead.")]
      public static Vector3d Sub(Vector3d a, Vector3d b)
      {
        a.X -= b.X;
        a.Y -= b.Y;
        a.Z -= b.Z;
        return a;
      }

      /// <summary>
      /// Subtract one Vector from another
      /// </summary>
      /// <param name="a">First operand</param>
      /// <param name="b">Second operand</param>
      /// <param name="result">Result of subtraction</param>
      [Obsolete("Use static Subtract() method instead.")]
      public static void Sub(ref Vector3d a, ref Vector3d b, out Vector3d result)
      {
        result.X = a.X - b.X;
        result.Y = a.Y - b.Y;
        result.Z = a.Z - b.Z;
      }

      #endregion

      #region Mult

      /// <summary>
      /// Multiply a vector and a scalar
      /// </summary>
      /// <param name="a">Vector operand</param>
      /// <param name="f">Scalar operand</param>
      /// <returns>Result of the multiplication</returns>
      [Obsolete("Use static Multiply() method instead.")]
      public static Vector3d Mult(Vector3d a, double f)
      {
        a.X *= f;
        a.Y *= f;
        a.Z *= f;
        return a;
      }

      /// <summary>
      /// Multiply a vector and a scalar
      /// </summary>
      /// <param name="a">Vector operand</param>
      /// <param name="f">Scalar operand</param>
      /// <param name="result">Result of the multiplication</param>
      [Obsolete("Use static Multiply() method instead.")]
      public static void Mult(ref Vector3d a, double f, out Vector3d result)
      {
        result.X = a.X * f;
        result.Y = a.Y * f;
        result.Z = a.Z * f;
      }

      #endregion

      #region Div

      /// <summary>
      /// Divide a vector by a scalar
      /// </summary>
      /// <param name="a">Vector operand</param>
      /// <param name="f">Scalar operand</param>
      /// <returns>Result of the division</returns>
      [Obsolete("Use static Divide() method instead.")]
      public static Vector3d Div(Vector3d a, double f)
      {
        double mult = 1.0 / f;
        a.X *= mult;
        a.Y *= mult;
        a.Z *= mult;
        return a;
      }

      /// <summary>
      /// Divide a vector by a scalar
      /// </summary>
      /// <param name="a">Vector operand</param>
      /// <param name="f">Scalar operand</param>
      /// <param name="result">Result of the division</param>
      [Obsolete("Use static Divide() method instead.")]
      public static void Div(ref Vector3d a, double f, out Vector3d result)
      {
        double mult = 1.0 / f;
        result.X = a.X * mult;
        result.Y = a.Y * mult;
        result.Z = a.Z * mult;
      }

      #endregion

      #endregion

      #region Add

      /// <summary>
      /// Adds two vectors.
      /// </summary>
      /// <param name="a">Left operand.</param>
      /// <param name="b">Right operand.</param>
      /// <returns>Result of operation.</returns>
      public static Vector3d Add(Vector3d a, Vector3d b)
      {
        Add(ref a, ref b, out a);
        return a;
      }

      /// <summary>
      /// Adds two vectors.
      /// </summary>
      /// <param name="a">Left operand.</param>
      /// <param name="b">Right operand.</param>
      /// <param name="result">Result of operation.</param>
      public static void Add(ref Vector3d a, ref Vector3d b, out Vector3d result)
      {
        result = new Vector3d(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
      }

      #endregion

      #region Subtract

      /// <summary>
      /// Subtract one Vector from another
      /// </summary>
      /// <param name="a">First operand</param>
      /// <param name="b">Second operand</param>
      /// <returns>Result of subtraction</returns>
      public static Vector3d Subtract(Vector3d a, Vector3d b)
      {
        Subtract(ref a, ref b, out a);
        return a;
      }

      /// <summary>
      /// Subtract one Vector from another
      /// </summary>
      /// <param name="a">First operand</param>
      /// <param name="b">Second operand</param>
      /// <param name="result">Result of subtraction</param>
      public static void Subtract(ref Vector3d a, ref Vector3d b, out Vector3d result)
      {
        result = new Vector3d(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
      }

      #endregion

      #region Multiply

      /// <summary>
      /// Multiplies a vector by a scalar.
      /// </summary>
      /// <param name="vector">Left operand.</param>
      /// <param name="scale">Right operand.</param>
      /// <returns>Result of the operation.</returns>
      public static Vector3d Multiply(Vector3d vector, double scale)
      {
        Multiply(ref vector, scale, out vector);
        return vector;
      }

      /// <summary>
      /// Multiplies a vector by a scalar.
      /// </summary>
      /// <param name="vector">Left operand.</param>
      /// <param name="scale">Right operand.</param>
      /// <param name="result">Result of the operation.</param>
      public static void Multiply(ref Vector3d vector, double scale, out Vector3d result)
      {
        result = new Vector3d(vector.X * scale, vector.Y * scale, vector.Z * scale);
      }

      /// <summary>
      /// Multiplies a vector by the components a vector (scale).
      /// </summary>
      /// <param name="vector">Left operand.</param>
      /// <param name="scale">Right operand.</param>
      /// <returns>Result of the operation.</returns>
      public static Vector3d Multiply(Vector3d vector, Vector3d scale)
      {
        Multiply(ref vector, ref scale, out vector);
        return vector;
      }

      /// <summary>
      /// Multiplies a vector by the components of a vector (scale).
      /// </summary>
      /// <param name="vector">Left operand.</param>
      /// <param name="scale">Right operand.</param>
      /// <param name="result">Result of the operation.</param>
      public static void Multiply(ref Vector3d vector, ref Vector3d scale, out Vector3d result)
      {
        result = new Vector3d(vector.X * scale.X, vector.Y * scale.Y, vector.Z * scale.Z);
      }

      #endregion

      #region Divide

      /// <summary>
      /// Divides a vector by a scalar.
      /// </summary>
      /// <param name="vector">Left operand.</param>
      /// <param name="scale">Right operand.</param>
      /// <returns>Result of the operation.</returns>
      public static Vector3d Divide(Vector3d vector, double scale)
      {
        Divide(ref vector, scale, out vector);
        return vector;
      }

      /// <summary>
      /// Divides a vector by a scalar.
      /// </summary>
      /// <param name="vector">Left operand.</param>
      /// <param name="scale">Right operand.</param>
      /// <param name="result">Result of the operation.</param>
      public static void Divide(ref Vector3d vector, double scale, out Vector3d result)
      {
        Multiply(ref vector, 1 / scale, out result);
      }

      /// <summary>
      /// Divides a vector by the components of a vector (scale).
      /// </summary>
      /// <param name="vector">Left operand.</param>
      /// <param name="scale">Right operand.</param>
      /// <returns>Result of the operation.</returns>
      public static Vector3d Divide(Vector3d vector, Vector3d scale)
      {
        Divide(ref vector, ref scale, out vector);
        return vector;
      }

      /// <summary>
      /// Divide a vector by the components of a vector (scale).
      /// </summary>
      /// <param name="vector">Left operand.</param>
      /// <param name="scale">Right operand.</param>
      /// <param name="result">Result of the operation.</param>
      public static void Divide(ref Vector3d vector, ref Vector3d scale, out Vector3d result)
      {
        result = new Vector3d(vector.X / scale.X, vector.Y / scale.Y, vector.Z / scale.Z);
      }

      #endregion

      #region ComponentMin

      /// <summary>
      /// Calculate the component-wise minimum of two vectors
      /// </summary>
      /// <param name="a">First operand</param>
      /// <param name="b">Second operand</param>
      /// <returns>The component-wise minimum</returns>
      public static Vector3d ComponentMin(Vector3d a, Vector3d b)
      {
        a.X = a.X < b.X ? a.X : b.X;
        a.Y = a.Y < b.Y ? a.Y : b.Y;
        a.Z = a.Z < b.Z ? a.Z : b.Z;
        return a;
      }

      /// <summary>
      /// Calculate the component-wise minimum of two vectors
      /// </summary>
      /// <param name="a">First operand</param>
      /// <param name="b">Second operand</param>
      /// <param name="result">The component-wise minimum</param>
      public static void ComponentMin(ref Vector3d a, ref Vector3d b, out Vector3d result)
      {
        result.X = a.X < b.X ? a.X : b.X;
        result.Y = a.Y < b.Y ? a.Y : b.Y;
        result.Z = a.Z < b.Z ? a.Z : b.Z;
      }

      #endregion

      #region ComponentMax

      /// <summary>
      /// Calculate the component-wise maximum of two vectors
      /// </summary>
      /// <param name="a">First operand</param>
      /// <param name="b">Second operand</param>
      /// <returns>The component-wise maximum</returns>
      public static Vector3d ComponentMax(Vector3d a, Vector3d b)
      {
        a.X = a.X > b.X ? a.X : b.X;
        a.Y = a.Y > b.Y ? a.Y : b.Y;
        a.Z = a.Z > b.Z ? a.Z : b.Z;
        return a;
      }

      /// <summary>
      /// Calculate the component-wise maximum of two vectors
      /// </summary>
      /// <param name="a">First operand</param>
      /// <param name="b">Second operand</param>
      /// <param name="result">The component-wise maximum</param>
      public static void ComponentMax(ref Vector3d a, ref Vector3d b, out Vector3d result)
      {
        result.X = a.X > b.X ? a.X : b.X;
        result.Y = a.Y > b.Y ? a.Y : b.Y;
        result.Z = a.Z > b.Z ? a.Z : b.Z;
      }

      #endregion

      #region Min

      /// <summary>
      /// Returns the Vector3d with the minimum magnitude
      /// </summary>
      /// <param name="left">Left operand</param>
      /// <param name="right">Right operand</param>
      /// <returns>The minimum Vector3</returns>
      public static Vector3d Min(Vector3d left, Vector3d right)
      {
        return left.LengthSquared < right.LengthSquared ? left : right;
      }

      #endregion

      #region Max

      /// <summary>
      /// Returns the Vector3d with the minimum magnitude
      /// </summary>
      /// <param name="left">Left operand</param>
      /// <param name="right">Right operand</param>
      /// <returns>The minimum Vector3</returns>
      public static Vector3d Max(Vector3d left, Vector3d right)
      {
        return left.LengthSquared >= right.LengthSquared ? left : right;
      }

      #endregion

      #region Clamp

      /// <summary>
      /// Clamp a vector to the given minimum and maximum vectors
      /// </summary>
      /// <param name="vec">Input vector</param>
      /// <param name="min">Minimum vector</param>
      /// <param name="max">Maximum vector</param>
      /// <returns>The clamped vector</returns>
      public static Vector3d Clamp(Vector3d vec, Vector3d min, Vector3d max)
      {
        vec.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
        vec.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
        vec.Z = vec.Z < min.Z ? min.Z : vec.Z > max.Z ? max.Z : vec.Z;
        return vec;
      }

      /// <summary>
      /// Clamp a vector to the given minimum and maximum vectors
      /// </summary>
      /// <param name="vec">Input vector</param>
      /// <param name="min">Minimum vector</param>
      /// <param name="max">Maximum vector</param>
      /// <param name="result">The clamped vector</param>
      public static void Clamp(ref Vector3d vec, ref Vector3d min, ref Vector3d max, out Vector3d result)
      {
        result.X = vec.X < min.X ? min.X : vec.X > max.X ? max.X : vec.X;
        result.Y = vec.Y < min.Y ? min.Y : vec.Y > max.Y ? max.Y : vec.Y;
        result.Z = vec.Z < min.Z ? min.Z : vec.Z > max.Z ? max.Z : vec.Z;
      }

      #endregion

      #region Normalize

      /// <summary>
      /// Scale a vector to unit length
      /// </summary>
      /// <param name="vec">The input vector</param>
      /// <returns>The normalized vector</returns>
      public static Vector3d Normalize(Vector3d vec)
      {
        double scale = 1.0 / vec.Length;
        vec.X *= scale;
        vec.Y *= scale;
        vec.Z *= scale;
        return vec;
      }

      /// <summary>
      /// Scale a vector to unit length
      /// </summary>
      /// <param name="vec">The input vector</param>
      /// <param name="result">The normalized vector</param>
      public static void Normalize(ref Vector3d vec, out Vector3d result)
      {
        double scale = 1.0 / vec.Length;
        result.X = vec.X * scale;
        result.Y = vec.Y * scale;
        result.Z = vec.Z * scale;
      }

      #endregion

      #region Dot

      /// <summary>
      /// Calculate the dot (scalar) product of two vectors
      /// </summary>
      /// <param name="left">First operand</param>
      /// <param name="right">Second operand</param>
      /// <returns>The dot product of the two inputs</returns>
      public static double Dot(Vector3d left, Vector3d right)
      {
        return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
      }

      /// <summary>
      /// Calculate the dot (scalar) product of two vectors
      /// </summary>
      /// <param name="left">First operand</param>
      /// <param name="right">Second operand</param>
      /// <param name="result">The dot product of the two inputs</param>
      public static void Dot(ref Vector3d left, ref Vector3d right, out double result)
      {
        result = left.X * right.X + left.Y * right.Y + left.Z * right.Z;
      }

      #endregion

      #region Cross

      /// <summary>
      /// Caclulate the cross (vector) product of two vectors
      /// </summary>
      /// <param name="left">First operand</param>
      /// <param name="right">Second operand</param>
      /// <returns>The cross product of the two inputs</returns>
      public static Vector3d Cross(Vector3d left, Vector3d right)
      {
        Vector3d result;
        Cross(ref left, ref right, out result);
        return result;
      }

      /// <summary>
      /// Caclulate the cross (vector) product of two vectors
      /// </summary>
      /// <param name="left">First operand</param>
      /// <param name="right">Second operand</param>
      /// <returns>The cross product of the two inputs</returns>
      /// <param name="result">The cross product of the two inputs</param>
      public static void Cross(ref Vector3d left, ref Vector3d right, out Vector3d result)
      {
        result = new Vector3d(left.Y * right.Z - left.Z * right.Y,
            left.Z * right.X - left.X * right.Z,
            left.X * right.Y - left.Y * right.X);
      }

      #endregion

      #region Lerp

      /// <summary>
      /// Returns a new Vector that is the linear blend of the 2 given Vectors
      /// </summary>
      /// <param name="a">First input vector</param>
      /// <param name="b">Second input vector</param>
      /// <param name="blend">The blend factor. a when blend=0, b when blend=1.</param>
      /// <returns>a when blend=0, b when blend=1, and a linear combination otherwise</returns>
      public static Vector3d Lerp(Vector3d a, Vector3d b, double blend)
      {
        a.X = blend * (b.X - a.X) + a.X;
        a.Y = blend * (b.Y - a.Y) + a.Y;
        a.Z = blend * (b.Z - a.Z) + a.Z;
        return a;
      }

      /// <summary>
      /// Returns a new Vector that is the linear blend of the 2 given Vectors
      /// </summary>
      /// <param name="a">First input vector</param>
      /// <param name="b">Second input vector</param>
      /// <param name="blend">The blend factor. a when blend=0, b when blend=1.</param>
      /// <param name="result">a when blend=0, b when blend=1, and a linear combination otherwise</param>
      public static void Lerp(ref Vector3d a, ref Vector3d b, double blend, out Vector3d result)
      {
        result.X = blend * (b.X - a.X) + a.X;
        result.Y = blend * (b.Y - a.Y) + a.Y;
        result.Z = blend * (b.Z - a.Z) + a.Z;
      }

      #endregion

      #region Barycentric

      /// <summary>
      /// Interpolate 3 Vectors using Barycentric coordinates
      /// </summary>
      /// <param name="a">First input Vector</param>
      /// <param name="b">Second input Vector</param>
      /// <param name="c">Third input Vector</param>
      /// <param name="u">First Barycentric Coordinate</param>
      /// <param name="v">Second Barycentric Coordinate</param>
      /// <returns>a when u=v=0, b when u=1,v=0, c when u=0,v=1, and a linear combination of a,b,c otherwise</returns>
      public static Vector3d BaryCentric(Vector3d a, Vector3d b, Vector3d c, double u, double v)
      {
        return a + u * (b - a) + v * (c - a);
      }

      /// <summary>Interpolate 3 Vectors using Barycentric coordinates</summary>
      /// <param name="a">First input Vector.</param>
      /// <param name="b">Second input Vector.</param>
      /// <param name="c">Third input Vector.</param>
      /// <param name="u">First Barycentric Coordinate.</param>
      /// <param name="v">Second Barycentric Coordinate.</param>
      /// <param name="result">Output Vector. a when u=v=0, b when u=1,v=0, c when u=0,v=1, and a linear combination of a,b,c otherwise</param>
      public static void BaryCentric(ref Vector3d a, ref Vector3d b, ref Vector3d c, double u, double v, out Vector3d result)
      {
        result = a; // copy

        Vector3d temp = b; // copy
        Subtract(ref temp, ref a, out temp);
        Multiply(ref temp, u, out temp);
        Add(ref result, ref temp, out result);

        temp = c; // copy
        Subtract(ref temp, ref a, out temp);
        Multiply(ref temp, v, out temp);
        Add(ref result, ref temp, out result);
      }

      #endregion

      #region CalculateAngle

      /// <summary>
      /// Calculates the angle (in radians) between two vectors.
      /// </summary>
      /// <param name="first">The first vector.</param>
      /// <param name="second">The second vector.</param>
      /// <returns>Angle (in radians) between the vectors.</returns>
      /// <remarks>Note that the returned angle is never bigger than the constant Pi.</remarks>
      public static double CalculateAngle(Vector3d first, Vector3d second)
      {
        return System.Math.Acos((Vector3d.Dot(first, second)) / (first.Length * second.Length));
      }

      /// <summary>Calculates the angle (in radians) between two vectors.</summary>
      /// <param name="first">The first vector.</param>
      /// <param name="second">The second vector.</param>
      /// <param name="result">Angle (in radians) between the vectors.</param>
      /// <remarks>Note that the returned angle is never bigger than the constant Pi.</remarks>
      public static void CalculateAngle(ref Vector3d first, ref Vector3d second, out double result)
      {
        double temp;
        Vector3d.Dot(ref first, ref second, out temp);
        result = System.Math.Acos(temp / (first.Length * second.Length));
      }

      #endregion

      #endregion

      #region Operators

      /// <summary>
      /// Adds two instances.
      /// </summary>
      /// <param name="left">The first instance.</param>
      /// <param name="right">The second instance.</param>
      /// <returns>The result of the calculation.</returns>
      public static Vector3d operator +(Vector3d left, Vector3d right)
      {
        left.X += right.X;
        left.Y += right.Y;
        left.Z += right.Z;
        return left;
      }

      /// <summary>
      /// Subtracts two instances.
      /// </summary>
      /// <param name="left">The first instance.</param>
      /// <param name="right">The second instance.</param>
      /// <returns>The result of the calculation.</returns>
      public static Vector3d operator -(Vector3d left, Vector3d right)
      {
        left.X -= right.X;
        left.Y -= right.Y;
        left.Z -= right.Z;
        return left;
      }

      /// <summary>
      /// Negates an instance.
      /// </summary>
      /// <param name="vec">The instance.</param>
      /// <returns>The result of the calculation.</returns>
      public static Vector3d operator -(Vector3d vec)
      {
        vec.X = -vec.X;
        vec.Y = -vec.Y;
        vec.Z = -vec.Z;
        return vec;
      }

      /// <summary>
      /// Multiplies an instance by a scalar.
      /// </summary>
      /// <param name="vec">The instance.</param>
      /// <param name="scale">The scalar.</param>
      /// <returns>The result of the calculation.</returns>
      public static Vector3d operator *(Vector3d vec, double scale)
      {
        vec.X *= scale;
        vec.Y *= scale;
        vec.Z *= scale;
        return vec;
      }

      /// <summary>
      /// Multiplies an instance by a scalar.
      /// </summary>
      /// <param name="scale">The scalar.</param>
      /// <param name="vec">The instance.</param>
      /// <returns>The result of the calculation.</returns>
      public static Vector3d operator *(double scale, Vector3d vec)
      {
        vec.X *= scale;
        vec.Y *= scale;
        vec.Z *= scale;
        return vec;
      }

      /// <summary>
      /// Component-wise multiplication between the specified instance by a scale vector.
      /// </summary>
      /// <param name="scale">Left operand.</param>
      /// <param name="vec">Right operand.</param>
      /// <returns>Result of multiplication.</returns>
      public static Vector3d operator *(Vector3d vec, Vector3d scale)
      {
        vec.X *= scale.X;
        vec.Y *= scale.Y;
        vec.Z *= scale.Z;
        return vec;
      }

      /// <summary>
      /// Divides an instance by a scalar.
      /// </summary>
      /// <param name="vec">The instance.</param>
      /// <param name="scale">The scalar.</param>
      /// <returns>The result of the calculation.</returns>
      public static Vector3d operator /(Vector3d vec, double scale)
      {
        double mult = 1 / scale;
        vec.X *= mult;
        vec.Y *= mult;
        vec.Z *= mult;
        return vec;
      }

      /// <summary>
      /// Compares two instances for equality.
      /// </summary>
      /// <param name="left">The first instance.</param>
      /// <param name="right">The second instance.</param>
      /// <returns>True, if left equals right; false otherwise.</returns>
      public static bool operator ==(Vector3d left, Vector3d right)
      {
        return left.Equals(right);
      }

      /// <summary>
      /// Compares two instances for inequality.
      /// </summary>
      /// <param name="left">The first instance.</param>
      /// <param name="right">The second instance.</param>
      /// <returns>True, if left does not equa lright; false otherwise.</returns>
      public static bool operator !=(Vector3d left, Vector3d right)
      {
        return !left.Equals(right);
      }

      #endregion

      #region Overrides

      #region public override string ToString()

      private static string listSeparator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
      /// <summary>
      /// Returns a System.String that represents the current Vector3.
      /// </summary>
      /// <returns></returns>
      public override string ToString()
      {
        return String.Format("({0}{3} {1}{3} {2})", X, Y, Z, listSeparator);
      }

      #endregion

      #region public override int GetHashCode()

      /// <summary>
      /// Returns the hashcode for this instance.
      /// </summary>
      /// <returns>A System.Int32 containing the unique hashcode for this instance.</returns>
      public override int GetHashCode()
      {
        return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
      }

      #endregion

      #region public override bool Equals(object obj)

      /// <summary>
      /// Indicates whether this instance and a specified object are equal.
      /// </summary>
      /// <param name="obj">The object to compare to.</param>
      /// <returns>True if the instances are equal; false otherwise.</returns>
      public override bool Equals(object obj)
      {
        if (!(obj is Vector3d))
          return false;

        return this.Equals((Vector3d)obj);
      }

      #endregion

      #endregion

      #endregion

      #region IEquatable<Vector3> Members

      /// <summary>Indicates whether the current vector is equal to another vector.</summary>
      /// <param name="other">A vector to compare with this vector.</param>
      /// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
      public bool Equals(Vector3d other)
      {
        return
            X == other.X &&
            Y == other.Y &&
            Z == other.Z;
      }

      #endregion

      #endregion
    }

    #endregion

    #region Matrix3x3 (from OpenTK)

    /// <summary>
    /// Represents a 3x3 matrix containing 3D rotation and scale with double-precision components.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix3d : IEquatable<Matrix3d>
    {
      #region Fields

      /// <summary>
      /// First row of the matrix.
      /// </summary>
      public Vector3d Row0;

      /// <summary>
      /// Second row of the matrix.
      /// </summary>
      public Vector3d Row1;

      /// <summary>
      /// Third row of the matrix.
      /// </summary>
      public Vector3d Row2;

      /// <summary>
      /// The identity matrix.
      /// </summary>
      public static Matrix3d Identity = new Matrix3d(Vector3d.UnitX, Vector3d.UnitY, Vector3d.UnitZ);

      #endregion

      #region Constructors

      /// <summary>
      /// Constructs a new instance.
      /// </summary>
      /// <param name="row0">Top row of the matrix</param>
      /// <param name="row1">Second row of the matrix</param>
      /// <param name="row2">Bottom row of the matrix</param>
      public Matrix3d(Vector3d row0, Vector3d row1, Vector3d row2)
      {
        Row0 = row0;
        Row1 = row1;
        Row2 = row2;
      }

      /// <summary>
      /// Constructs a new instance.
      /// </summary>
      /// <param name="m00">First item of the first row of the matrix.</param>
      /// <param name="m01">Second item of the first row of the matrix.</param>
      /// <param name="m02">Third item of the first row of the matrix.</param>
      /// <param name="m10">First item of the second row of the matrix.</param>
      /// <param name="m11">Second item of the second row of the matrix.</param>
      /// <param name="m12">Third item of the second row of the matrix.</param>
      /// <param name="m20">First item of the third row of the matrix.</param>
      /// <param name="m21">Second item of the third row of the matrix.</param>
      /// <param name="m22">Third item of the third row of the matrix.</param>
      public Matrix3d(
          double m00, double m01, double m02,
          double m10, double m11, double m12,
          double m20, double m21, double m22)
      {
        Row0 = new Vector3d(m00, m01, m02);
        Row1 = new Vector3d(m10, m11, m12);
        Row2 = new Vector3d(m20, m21, m22);
      }

      #endregion

      #region Public Members

      #region Properties

      /// <summary>
      /// Gets the determinant of this matrix.
      /// </summary>
      public double Determinant
      {
        get
        {
          double m11 = Row0.X, m12 = Row0.Y, m13 = Row0.Z,
          m21 = Row1.X, m22 = Row1.Y, m23 = Row1.Z,
          m31 = Row2.X, m32 = Row2.Y, m33 = Row2.Z;

          return
              m11 * m22 * m33 + m12 * m23 * m31 + m13 * m21 * m32
                  - m13 * m22 * m31 - m11 * m23 * m32 - m12 * m21 * m33;
        }
      }

      /// <summary>
      /// Gets the first column of this matrix.
      /// </summary>
      public Vector3d Column0
      {
        get { return new Vector3d(Row0.X, Row1.X, Row2.X); }
      }

      /// <summary>
      /// Gets the second column of this matrix.
      /// </summary>
      public Vector3d Column1
      {
        get { return new Vector3d(Row0.Y, Row1.Y, Row2.Y); }
      }

      /// <summary>
      /// Gets the third column of this matrix.
      /// </summary>
      public Vector3d Column2
      {
        get { return new Vector3d(Row0.Z, Row1.Z, Row2.Z); }
      }

      /// <summary>
      /// Gets or sets the value at row 1, column 1 of this instance.
      /// </summary>
      public double M11 { get { return Row0.X; } set { Row0.X = value; } }

      /// <summary>
      /// Gets or sets the value at row 1, column 2 of this instance.
      /// </summary>
      public double M12 { get { return Row0.Y; } set { Row0.Y = value; } }

      /// <summary>
      /// Gets or sets the value at row 1, column 3 of this instance.
      /// </summary>
      public double M13 { get { return Row0.Z; } set { Row0.Z = value; } }

      /// <summary>
      /// Gets or sets the value at row 2, column 1 of this instance.
      /// </summary>
      public double M21 { get { return Row1.X; } set { Row1.X = value; } }

      /// <summary>
      /// Gets or sets the value at row 2, column 2 of this instance.
      /// </summary>
      public double M22 { get { return Row1.Y; } set { Row1.Y = value; } }

      /// <summary>
      /// Gets or sets the value at row 2, column 3 of this instance.
      /// </summary>
      public double M23 { get { return Row1.Z; } set { Row1.Z = value; } }

      /// <summary>
      /// Gets or sets the value at row 3, column 1 of this instance.
      /// </summary>
      public double M31 { get { return Row2.X; } set { Row2.X = value; } }

      /// <summary>
      /// Gets or sets the value at row 3, column 2 of this instance.
      /// </summary>
      public double M32 { get { return Row2.Y; } set { Row2.Y = value; } }

      /// <summary>
      /// Gets or sets the value at row 3, column 3 of this instance.
      /// </summary>
      public double M33 { get { return Row2.Z; } set { Row2.Z = value; } }

      /// <summary>
      /// Gets or sets the values along the main diagonal of the matrix.
      /// </summary>
      public Vector3d Diagonal
      {
        get
        {
          return new Vector3d(Row0.X, Row1.Y, Row2.Z);
        }
        set
        {
          Row0.X = value.X;
          Row1.Y = value.Y;
          Row2.Z = value.Z;
        }
      }

      /// <summary>
      /// Gets the trace of the matrix, the sum of the values along the diagonal.
      /// </summary>
      public double Trace { get { return Row0.X + Row1.Y + Row2.Z; } }

      #endregion

      #region Indexers

      /// <summary>
      /// Gets or sets the value at a specified row and column.
      /// </summary>
      public double this[int rowIndex, int columnIndex]
      {
        get
        {
          if (rowIndex == 0) return Row0[columnIndex];
          else if (rowIndex == 1) return Row1[columnIndex];
          else if (rowIndex == 2) return Row2[columnIndex];
          throw new IndexOutOfRangeException("You tried to access this matrix at: (" + rowIndex + ", " + columnIndex + ")");
        }
        set
        {
          if (rowIndex == 0) Row0[columnIndex] = value;
          else if (rowIndex == 1) Row1[columnIndex] = value;
          else if (rowIndex == 2) Row2[columnIndex] = value;
          else throw new IndexOutOfRangeException("You tried to set this matrix at: (" + rowIndex + ", " + columnIndex + ")");
        }
      }

      #endregion

      #region Instance

      #region public void Invert()

      /// <summary>
      /// Converts this instance into its inverse.
      /// </summary>
      public void Invert()
      {
        this = Matrix3d.Invert(this);
      }

      #endregion

      #region public void Transpose()

      /// <summary>
      /// Converts this instance into its transpose.
      /// </summary>
      public void Transpose()
      {
        this = Matrix3d.Transpose(this);
      }

      #endregion

      /// <summary>
      /// Returns a normalised copy of this instance.
      /// </summary>
      public Matrix3d Normalized()
      {
        Matrix3d m = this;
        m.Normalize();
        return m;
      }

      /// <summary>
      /// Divides each element in the Matrix by the <see cref="Determinant"/>.
      /// </summary>
      public void Normalize()
      {
        var determinant = this.Determinant;
        Row0 /= determinant;
        Row1 /= determinant;
        Row2 /= determinant;
      }

      /// <summary>
      /// Returns an inverted copy of this instance.
      /// </summary>
      public Matrix3d Inverted()
      {
        Matrix3d m = this;
        if (m.Determinant != 0)
          m.Invert();
        return m;
      }


      /// <summary>
      /// Returns a copy of this Matrix3 without scale.
      /// </summary>
      public Matrix3d ClearScale()
      {
        Matrix3d m = this;
        m.Row0 = m.Row0.Normalized();
        m.Row1 = m.Row1.Normalized();
        m.Row2 = m.Row2.Normalized();
        return m;
      }
      /// <summary>
      /// Returns a copy of this Matrix3 without rotation.
      /// </summary>
      public Matrix3d ClearRotation()
      {
        Matrix3d m = this;
        m.Row0 = new Vector3d(m.Row0.Length, 0, 0);
        m.Row1 = new Vector3d(0, m.Row1.Length, 0);
        m.Row2 = new Vector3d(0, 0, m.Row2.Length);
        return m;
      }

      /// <summary>
      /// Returns the scale component of this instance.
      /// </summary>
      public Vector3d ExtractScale() { return new Vector3d(Row0.Length, Row1.Length, Row2.Length); }

      #region Static

      #region CreateFromAxisAngle

      /// <summary>
      /// Build a rotation matrix from the specified axis/angle rotation.
      /// </summary>
      /// <param name="axis">The axis to rotate about.</param>
      /// <param name="angle">Angle in radians to rotate counter-clockwise (looking in the direction of the given axis).</param>
      /// <param name="result">A matrix instance.</param>
      public static void CreateFromAxisAngle(Vector3d axis, double angle, out Matrix3d result)
      {
        //normalize and create a local copy of the vector.
        axis.Normalize();
        double axisX = axis.X, axisY = axis.Y, axisZ = axis.Z;

        //calculate angles
        double cos = System.Math.Cos(-angle);
        double sin = System.Math.Sin(-angle);
        double t = 1.0f - cos;

        //do the conversion math once
        double tXX = t * axisX * axisX,
        tXY = t * axisX * axisY,
        tXZ = t * axisX * axisZ,
        tYY = t * axisY * axisY,
        tYZ = t * axisY * axisZ,
        tZZ = t * axisZ * axisZ;

        double sinX = sin * axisX,
        sinY = sin * axisY,
        sinZ = sin * axisZ;

        result.Row0.X = tXX + cos;
        result.Row0.Y = tXY - sinZ;
        result.Row0.Z = tXZ + sinY;
        result.Row1.X = tXY + sinZ;
        result.Row1.Y = tYY + cos;
        result.Row1.Z = tYZ - sinX;
        result.Row2.X = tXZ - sinY;
        result.Row2.Y = tYZ + sinX;
        result.Row2.Z = tZZ + cos;
      }

      /// <summary>
      /// Build a rotation matrix from the specified axis/angle rotation.
      /// </summary>
      /// <param name="axis">The axis to rotate about.</param>
      /// <param name="angle">Angle in radians to rotate counter-clockwise (looking in the direction of the given axis).</param>
      /// <returns>A matrix instance.</returns>
      public static Matrix3d CreateFromAxisAngle(Vector3d axis, double angle)
      {
        Matrix3d result;
        CreateFromAxisAngle(axis, angle, out result);
        return result;
      }

      #endregion

      #region CreateRotation[XYZ]

      /// <summary>
      /// Builds a rotation matrix for a rotation around the x-axis.
      /// </summary>
      /// <param name="angle">The counter-clockwise angle in radians.</param>
      /// <param name="result">The resulting Matrix3d instance.</param>
      public static void CreateRotationX(double angle, out Matrix3d result)
      {
        double cos = System.Math.Cos(angle);
        double sin = System.Math.Sin(angle);

        result = Identity;
        result.Row1.Y = cos;
        result.Row1.Z = sin;
        result.Row2.Y = -sin;
        result.Row2.Z = cos;
      }

      /// <summary>
      /// Builds a rotation matrix for a rotation around the x-axis.
      /// </summary>
      /// <param name="angle">The counter-clockwise angle in radians.</param>
      /// <returns>The resulting Matrix3d instance.</returns>
      public static Matrix3d CreateRotationX(double angle)
      {
        Matrix3d result;
        CreateRotationX(angle, out result);
        return result;
      }

      /// <summary>
      /// Builds a rotation matrix for a rotation around the y-axis.
      /// </summary>
      /// <param name="angle">The counter-clockwise angle in radians.</param>
      /// <param name="result">The resulting Matrix3d instance.</param>
      public static void CreateRotationY(double angle, out Matrix3d result)
      {
        double cos = System.Math.Cos(angle);
        double sin = System.Math.Sin(angle);

        result = Identity;
        result.Row0.X = cos;
        result.Row0.Z = -sin;
        result.Row2.X = sin;
        result.Row2.Z = cos;
      }

      /// <summary>
      /// Builds a rotation matrix for a rotation around the y-axis.
      /// </summary>
      /// <param name="angle">The counter-clockwise angle in radians.</param>
      /// <returns>The resulting Matrix3d instance.</returns>
      public static Matrix3d CreateRotationY(double angle)
      {
        Matrix3d result;
        CreateRotationY(angle, out result);
        return result;
      }

      /// <summary>
      /// Builds a rotation matrix for a rotation around the z-axis.
      /// </summary>
      /// <param name="angle">The counter-clockwise angle in radians.</param>
      /// <param name="result">The resulting Matrix3d instance.</param>
      public static void CreateRotationZ(double angle, out Matrix3d result)
      {
        double cos = System.Math.Cos(angle);
        double sin = System.Math.Sin(angle);

        result = Identity;
        result.Row0.X = cos;
        result.Row0.Y = sin;
        result.Row1.X = -sin;
        result.Row1.Y = cos;
      }

      /// <summary>
      /// Builds a rotation matrix for a rotation around the z-axis.
      /// </summary>
      /// <param name="angle">The counter-clockwise angle in radians.</param>
      /// <returns>The resulting Matrix3d instance.</returns>
      public static Matrix3d CreateRotationZ(double angle)
      {
        Matrix3d result;
        CreateRotationZ(angle, out result);
        return result;
      }

      #endregion

      #region CreateScale

      /// <summary>
      /// Creates a scale matrix.
      /// </summary>
      /// <param name="scale">Single scale factor for the x, y, and z axes.</param>
      /// <returns>A scale matrix.</returns>
      public static Matrix3d CreateScale(double scale)
      {
        Matrix3d result;
        CreateScale(scale, out result);
        return result;
      }

      /// <summary>
      /// Creates a scale matrix.
      /// </summary>
      /// <param name="scale">Scale factors for the x, y, and z axes.</param>
      /// <returns>A scale matrix.</returns>
      public static Matrix3d CreateScale(Vector3d scale)
      {
        Matrix3d result;
        CreateScale(ref scale, out result);
        return result;
      }

      /// <summary>
      /// Creates a scale matrix.
      /// </summary>
      /// <param name="x">Scale factor for the x axis.</param>
      /// <param name="y">Scale factor for the y axis.</param>
      /// <param name="z">Scale factor for the z axis.</param>
      /// <returns>A scale matrix.</returns>
      public static Matrix3d CreateScale(double x, double y, double z)
      {
        Matrix3d result;
        CreateScale(x, y, z, out result);
        return result;
      }

      /// <summary>
      /// Creates a scale matrix.
      /// </summary>
      /// <param name="scale">Single scale factor for the x, y, and z axes.</param>
      /// <param name="result">A scale matrix.</param>
      public static void CreateScale(double scale, out Matrix3d result)
      {
        result = Identity;
        result.Row0.X = scale;
        result.Row1.Y = scale;
        result.Row2.Z = scale;
      }

      /// <summary>
      /// Creates a scale matrix.
      /// </summary>
      /// <param name="scale">Scale factors for the x, y, and z axes.</param>
      /// <param name="result">A scale matrix.</param>
      public static void CreateScale(ref Vector3d scale, out Matrix3d result)
      {
        result = Identity;
        result.Row0.X = scale.X;
        result.Row1.Y = scale.Y;
        result.Row2.Z = scale.Z;
      }

      /// <summary>
      /// Creates a scale matrix.
      /// </summary>
      /// <param name="x">Scale factor for the x axis.</param>
      /// <param name="y">Scale factor for the y axis.</param>
      /// <param name="z">Scale factor for the z axis.</param>
      /// <param name="result">A scale matrix.</param>
      public static void CreateScale(double x, double y, double z, out Matrix3d result)
      {
        result = Identity;
        result.Row0.X = x;
        result.Row1.Y = y;
        result.Row2.Z = z;
      }

      #endregion

      #region Multiply Functions

      /// <summary>
      /// Multiplies two instances.
      /// </summary>
      /// <param name="left">The left operand of the multiplication.</param>
      /// <param name="right">The right operand of the multiplication.</param>
      /// <returns>A new instance that is the result of the multiplication</returns>
      public static Matrix3d Mult(Matrix3d left, Matrix3d right)
      {
        Matrix3d result;
        Mult(ref left, ref right, out result);
        return result;
      }

      /// <summary>
      /// Multiplies two instances.
      /// </summary>
      /// <param name="left">The left operand of the multiplication.</param>
      /// <param name="right">The right operand of the multiplication.</param>
      /// <param name="result">A new instance that is the result of the multiplication</param>
      public static void Mult(ref Matrix3d left, ref Matrix3d right, out Matrix3d result)
      {
        double lM11 = left.Row0.X, lM12 = left.Row0.Y, lM13 = left.Row0.Z,
        lM21 = left.Row1.X, lM22 = left.Row1.Y, lM23 = left.Row1.Z,
        lM31 = left.Row2.X, lM32 = left.Row2.Y, lM33 = left.Row2.Z,
        rM11 = right.Row0.X, rM12 = right.Row0.Y, rM13 = right.Row0.Z,
        rM21 = right.Row1.X, rM22 = right.Row1.Y, rM23 = right.Row1.Z,
        rM31 = right.Row2.X, rM32 = right.Row2.Y, rM33 = right.Row2.Z;

        result.Row0.X = ((lM11 * rM11) + (lM12 * rM21)) + (lM13 * rM31);
        result.Row0.Y = ((lM11 * rM12) + (lM12 * rM22)) + (lM13 * rM32);
        result.Row0.Z = ((lM11 * rM13) + (lM12 * rM23)) + (lM13 * rM33);
        result.Row1.X = ((lM21 * rM11) + (lM22 * rM21)) + (lM23 * rM31);
        result.Row1.Y = ((lM21 * rM12) + (lM22 * rM22)) + (lM23 * rM32);
        result.Row1.Z = ((lM21 * rM13) + (lM22 * rM23)) + (lM23 * rM33);
        result.Row2.X = ((lM31 * rM11) + (lM32 * rM21)) + (lM33 * rM31);
        result.Row2.Y = ((lM31 * rM12) + (lM32 * rM22)) + (lM33 * rM32);
        result.Row2.Z = ((lM31 * rM13) + (lM32 * rM23)) + (lM33 * rM33);
      }

      #endregion

      #region Invert Functions

      /// <summary>
      /// Calculate the inverse of the given matrix
      /// </summary>
      /// <param name="mat">The matrix to invert</param>
      /// <param name="result">The inverse of the given matrix if it has one, or the input if it is singular</param>
      /// <exception cref="InvalidOperationException">Thrown if the Matrix3d is singular.</exception>
      public static void Invert(ref Matrix3d mat, out Matrix3d result)
      {
        int[] colIdx = { 0, 0, 0 };
        int[] rowIdx = { 0, 0, 0 };
        int[] pivotIdx = { -1, -1, -1 };

        double[,] inverse = {{mat.Row0.X, mat.Row0.Y, mat.Row0.Z},
                {mat.Row1.X, mat.Row1.Y, mat.Row1.Z},
                {mat.Row2.X, mat.Row2.Y, mat.Row2.Z}};

        int icol = 0;
        int irow = 0;
        for (int i = 0; i < 3; i++)
        {
          double maxPivot = 0.0;
          for (int j = 0; j < 3; j++)
          {
            if (pivotIdx[j] != 0)
            {
              for (int k = 0; k < 3; ++k)
              {
                if (pivotIdx[k] == -1)
                {
                  double absVal = System.Math.Abs(inverse[j, k]);
                  if (absVal > maxPivot)
                  {
                    maxPivot = absVal;
                    irow = j;
                    icol = k;
                  }
                }
                else if (pivotIdx[k] > 0)
                {
                  result = mat;
                  return;
                }
              }
            }
          }

          ++(pivotIdx[icol]);

          if (irow != icol)
          {
            for (int k = 0; k < 3; ++k)
            {
              double f = inverse[irow, k];
              inverse[irow, k] = inverse[icol, k];
              inverse[icol, k] = f;
            }
          }

          rowIdx[i] = irow;
          colIdx[i] = icol;

          double pivot = inverse[icol, icol];

          if (pivot == 0.0)
          {
            throw new InvalidOperationException("Matrix is singular and cannot be inverted.");
          }

          double oneOverPivot = 1.0 / pivot;
          inverse[icol, icol] = 1.0;
          for (int k = 0; k < 3; ++k)
            inverse[icol, k] *= oneOverPivot;

          for (int j = 0; j < 3; ++j)
          {
            if (icol != j)
            {
              double f = inverse[j, icol];
              inverse[j, icol] = 0.0;
              for (int k = 0; k < 3; ++k)
                inverse[j, k] -= inverse[icol, k] * f;
            }
          }
        }

        for (int j = 2; j >= 0; --j)
        {
          int ir = rowIdx[j];
          int ic = colIdx[j];
          for (int k = 0; k < 3; ++k)
          {
            double f = inverse[k, ir];
            inverse[k, ir] = inverse[k, ic];
            inverse[k, ic] = f;
          }
        }

        result.Row0.X = inverse[0, 0];
        result.Row0.Y = inverse[0, 1];
        result.Row0.Z = inverse[0, 2];
        result.Row1.X = inverse[1, 0];
        result.Row1.Y = inverse[1, 1];
        result.Row1.Z = inverse[1, 2];
        result.Row2.X = inverse[2, 0];
        result.Row2.Y = inverse[2, 1];
        result.Row2.Z = inverse[2, 2];
      }

      /// <summary>
      /// Calculate the inverse of the given matrix
      /// </summary>
      /// <param name="mat">The matrix to invert</param>
      /// <returns>The inverse of the given matrix if it has one, or the input if it is singular</returns>
      /// <exception cref="InvalidOperationException">Thrown if the Matrix4 is singular.</exception>
      public static Matrix3d Invert(Matrix3d mat)
      {
        Matrix3d result;
        Invert(ref mat, out result);
        return result;
      }

      #endregion

      #region Transpose

      /// <summary>
      /// Calculate the transpose of the given matrix
      /// </summary>
      /// <param name="mat">The matrix to transpose</param>
      /// <returns>The transpose of the given matrix</returns>
      public static Matrix3d Transpose(Matrix3d mat)
      {
        return new Matrix3d(mat.Column0, mat.Column1, mat.Column2);
      }

      /// <summary>
      /// Calculate the transpose of the given matrix
      /// </summary>
      /// <param name="mat">The matrix to transpose</param>
      /// <param name="result">The result of the calculation</param>
      public static void Transpose(ref Matrix3d mat, out Matrix3d result)
      {
        result.Row0 = mat.Column0;
        result.Row1 = mat.Column1;
        result.Row2 = mat.Column2;
      }

      #endregion

      #endregion

      #region Operators

      /// <summary>
      /// Matrix multiplication
      /// </summary>
      /// <param name="left">left-hand operand</param>
      /// <param name="right">right-hand operand</param>
      /// <returns>A new Matrix3d which holds the result of the multiplication</returns>
      public static Matrix3d operator *(Matrix3d left, Matrix3d right)
      {
        return Matrix3d.Mult(left, right);
      }

      /// <summary>
      /// Compares two instances for equality.
      /// </summary>
      /// <param name="left">The first instance.</param>
      /// <param name="right">The second instance.</param>
      /// <returns>True, if left equals right; false otherwise.</returns>
      public static bool operator ==(Matrix3d left, Matrix3d right)
      {
        return left.Equals(right);
      }

      /// <summary>
      /// Compares two instances for inequality.
      /// </summary>
      /// <param name="left">The first instance.</param>
      /// <param name="right">The second instance.</param>
      /// <returns>True, if left does not equal right; false otherwise.</returns>
      public static bool operator !=(Matrix3d left, Matrix3d right)
      {
        return !left.Equals(right);
      }

      #endregion

      #region Overrides

      #region public override string ToString()

      /// <summary>
      /// Returns a System.String that represents the current Matrix3d.
      /// </summary>
      /// <returns>The string representation of the matrix.</returns>
      public override string ToString()
      {
        return String.Format("{0}\n{1}\n{2}", Row0, Row1, Row2);
      }

      #endregion

      #region public override int GetHashCode()

      /// <summary>
      /// Returns the hashcode for this instance.
      /// </summary>
      /// <returns>A System.Int32 containing the unique hashcode for this instance.</returns>
      public override int GetHashCode()
      {
        return Row0.GetHashCode() ^ Row1.GetHashCode() ^ Row2.GetHashCode();
      }

      #endregion

      #region public override bool Equals(object obj)

      /// <summary>
      /// Indicates whether this instance and a specified object are equal.
      /// </summary>
      /// <param name="obj">The object to compare to.</param>
      /// <returns>True if the instances are equal; false otherwise.</returns>
      public override bool Equals(object obj)
      {
        if (!(obj is Matrix3d))
          return false;

        return this.Equals((Matrix3d)obj);
      }

      #endregion

      #endregion

      #endregion

      #region IEquatable<Matrix3d> Members

      /// <summary>Indicates whether the current matrix is equal to another matrix.</summary>
      /// <param name="other">A matrix to compare with this matrix.</param>
      /// <returns>true if the current matrix is equal to the matrix parameter; otherwise, false.</returns>
      public bool Equals(Matrix3d other)
      {
        return
            Row0 == other.Row0 &&
                Row1 == other.Row1 &&
                Row2 == other.Row2;
      }

      #endregion
    }
    #endregion
    #endregion

    #endregion
  }
}
