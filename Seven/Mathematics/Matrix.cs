// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics
{
	/// <summary>A matrix of arbitrary dimensions implemented as a flattened array.</summary>
	/// <typeparam name="T">The numeric type of this Matrix.</typeparam>
	[System.Serializable]
	public class Matrix<T>
	{
		/// <summary>The flattened array of this matrix.</summary>
		public readonly T[] _matrix;
		private int _rows;
		private int _columns;

		#region properties

		/// <summary>The number of rows in the matrix.</summary>
		public int Rows { get { return this._rows; } }
		/// <summary>The number of columns in the matrix.</summary>
		public int Columns { get { return this._columns; } }
		/// <summary>Determines if the matrix is square.</summary>
		public bool IsSquare { get { return this._rows == this._columns; } }
		/// <summary>Determines if the matrix is a vector.</summary>
		public bool IsVector { get { return this._columns == 1; } }
		/// <summary>Determines if the matrix is a 2 component vector.</summary>
		public bool Is2x1 { get { return this._rows == 2 && this._columns == 1; } }
		/// <summary>Determines if the matrix is a 3 component vector.</summary>
		public bool Is3x1 { get { return this._rows == 3 && this._columns == 1; } }
		/// <summary>Determines if the matrix is a 4 component vector.</summary>
		public bool Is4x1 { get { return this._rows == 4 && this._columns == 1; } }
		/// <summary>Determines if the matrix is a 2 square matrix.</summary>
		public bool Is2x2 { get { return this._rows == 2 && this._columns == 2; } }
		/// <summary>Determines if the matrix is a 3 square matrix.</summary>
		public bool Is3x3 { get { return this._rows == 3 && this._columns == 3; } }
		/// <summary>Determines if the matrix is a 4 square matrix.</summary>
		public bool Is4x4 { get { return this._rows == 4 && this._columns == 4; } }

		/// <summary>Standard row-major matrix indexing.</summary>
		/// <param name="row">The row index.</param>
		/// <param name="column">The column index.</param>
		/// <returns>The value at the given indeces.</returns>
		public T this[int row, int column]
		{
			get
			{
				#region error checking

#if no_error_checking
				// nothing
#else
				if (row < 0 || row > this._rows)
					throw new Error("index out of bounds: row");
				if (column < 0 || column > this._columns)
					throw new Error("index out of bounds: column");
#endif

				#endregion

				return (this._matrix as T[])[row * this._columns + column];
			}
			set
			{
				#region error checking

#if no_error_checking
				// nothing
#else
				if (row < 0 || row > this._rows)
					throw new Error("index out of bounds: row");
				if (column < 0 || column > this._columns)
					throw new Error("index out of bounds: column");
#endif

				#endregion

				(this._matrix as T[])[row * this._columns + column] = value;
			}
		}

		#endregion

		#region constructors

		/// <summary>Constructs a new zero-matrix of the given dimensions (using FlattenedArray format).</summary>
		/// <param name="rows">The number of row dimensions.</param>
		/// <param name="columns">The number of column dimensions.</param>
		public Matrix(int rows, int columns)
		{
			if (rows < 1)
				throw new Error("Invalid rows on matrix contruction");
			if (columns < 1)
				throw new Error("Invalid columns on matrix contruction");

			this._matrix = new T[rows * columns];
			this._rows = rows;
			this._columns = columns;
		}

		/// <summary>Constructs a matrix from a T[,] (using FlattenedArray format).</summary>
		/// <param name="matrix">The float[,] to wrap in a matrix class.</param>
		public Matrix(T[,] matrix)
		{
			this._rows = matrix.GetLength(0);
			this._columns = matrix.GetLength(1);
			this._matrix = new T[this._rows * this._columns];
			T[] this_matrix_flat = this._matrix as T[]; ;
			for (int i = 0; i < this_matrix_flat.Length; i++)
				this_matrix_flat[i] = matrix[i / this._rows, i % this._columns];
		}

		private Matrix(Matrix<T> matrix)
		{
			this._rows = matrix._rows;
			this._columns = matrix.Columns;
			this._matrix = (matrix._matrix as T[]).Clone() as T[];
		}

		internal Matrix(Vector<T> vector)
		{
			this._rows = vector.Dimensions;
			this._columns = 1;
			this._matrix = vector._vector.Clone() as T[];
		}

		#endregion

		#region factories

		/// <summary>Constructs a new zero-matrix of the given dimensions.</summary>
		/// <param name="rows">The number of rows of the matrix.</param>
		/// <param name="columns">The number of columns of the matrix.</param>
		/// <returns>The newly constructed zero-matrix.</returns>
		public static Matrix<T> FactoryZero(int rows, int columns)
		{
			return Compute<T>.Matrix_FactoryZero(rows, columns);
		}

		/// <summary>Constructs a new identity-matrix of the given dimensions.</summary>
		/// <param name="rows">The number of rows of the matrix.</param>
		/// <param name="columns">The number of columns of the matrix.</param>
		/// <returns>The newly constructed identity-matrix.</returns>
		public static Matrix<T> FactoryIdentity(int rows, int columns)
		{
			return Compute<T>.Matrix_FactoryIdentity(rows, columns);
		}

		/// <summary>Constructs a new matrix where every entry is 1.</summary>
		/// <param name="rows">The number of rows of the matrix.</param>
		/// <param name="columns">The number of columns of the matrix.</param>
		/// <returns>The newly constructed matrix filled with 1's.</returns>
		public static Matrix<T> FactoryOne(int rows, int columns)
		{
			return Compute<T>.Matrix_FactoryOne(rows, columns);
		}

		/// <summary>Constructs a new matrix where every entry is the same uniform value.</summary>
		/// <param name="rows">The number of rows of the matrix.</param>
		/// <param name="columns">The number of columns of the matrix.</param>
		/// <param name="uniform">The value to assign every spot in the matrix.</param>
		/// <returns>The newly constructed matrix filled with the uniform value.</returns>
		public static Matrix<T> FactoryUniform(int rows, int columns, T uniform)
		{
			Matrix<T> matrix;
			try { matrix = new Matrix<T>(rows, columns); }
			catch { throw new Error("invalid dimensions."); }
			for (int i = 0; i < rows; i++)
				for (int j = 0; j < columns; j++)
					matrix[i, j] = uniform;
			return matrix;
		}

		/// <summary>Constructs a 2-component vector matrix with all values being 0.</summary>
		/// <returns>The constructed 2-component vector matrix.</returns>
		public static Matrix<T> Factory2x1() { return new Matrix<T>(2, 1); }
		/// <summary>Constructs a 3-component vector matrix with all values being 0.</summary>
		/// <returns>The constructed 3-component vector matrix.</returns>
		public static Matrix<T> Factory3x1() { return new Matrix<T>(3, 1); }
		/// <summary>Constructs a 4-component vector matrix with all values being 0.</summary>
		/// <returns>The constructed 4-component vector matrix.</returns>
		public static Matrix<T> Factory4x1() { return new Matrix<T>(4, 1); }

		/// <summary>Constructs a 2x2 matrix with all values being 0.</summary>
		/// <returns>The constructed 2x2 matrix.</returns>
		public static Matrix<T> Factory2x2() { return new Matrix<T>(2, 2); }
		/// <summary>Constructs a 3x3 matrix with all values being 0.</summary>
		/// <returns>The constructed 3x3 matrix.</returns>
		public static Matrix<T> Factory3x3() { return new Matrix<T>(3, 3); }
		/// <summary>Constructs a 4x4 matrix with all values being 0.</summary>
		/// <returns>The constructed 4x4 matrix.</returns>
		public static Matrix<T> Factory4x4() { return new Matrix<T>(4, 4); }

		///// <param name="angle">Angle of rotation in radians.</param>
		//public static Matrix<T> Factory3x3RotationX(T angle)
		//{
		//	T cos = _cos(angle);
		//	T sin = _sin(angle);
		//	return new Matrix<T>(new T[,] {
		//		{ _one, _zero, _zero },
		//		{ _zero, cos, sin },
		//		{ _zero, _negate(sin), cos }});
		//}

		///// <param name="angle">Angle of rotation in radians.</param>
		//public static Matrix<T> Factory3x3RotationY(T angle)
		//{
		//	T cos = _cos(angle);
		//	T sin = _sin(angle);
		//	return new Matrix<T>(new T[,] {
		//		{ cos, _zero, _negate(sin) },
		//		{ _zero, _one, _zero },
		//		{ sin, _zero, cos }});
		//}

		///// <param name="angle">Angle of rotation in radians.</param>
		//public static Matrix<T> Factory3x3RotationZ(T angle)
		//{
		//	T cos = _cos(angle);
		//	T sin = _sin(angle);
		//	return new Matrix<T>(new T[,] {
		//		{ cos, _negate(sin), _zero },
		//		{ sin, cos, _zero },
		//		{ _zero, _zero, _zero }});
		//}

		///// <param name="angleX">Angle about the X-axis in radians.</param>
		///// <param name="angleY">Angle about the Y-axis in radians.</param>
		///// <param name="angleZ">Angle about the Z-axis in radians.</param>
		//public static Matrix<T> Factory3x3RotationXthenYthenZ(T angleX, T angleY, T angleZ)
		//{
		//	T xCos = _cos(angleX), xSin = _sin(angleX),
		//		yCos = _cos(angleY), ySin = _sin(angleY),
		//		zCos = _cos(angleZ), zSin = _sin(angleZ);
		//	return new Matrix<T>(new T[,] {
		//		{ _multiply(yCos, zCos), _negate(_multiply(yCos, zSin)), ySin },
		//		{ _add(_multiply(xCos, zSin), _multiply(_multiply(xSin, ySin), zCos)), _add(_multiply(xCos, zCos), _multiply(_multiply(xSin, ySin), zSin)), _negate(_multiply(xSin, yCos)) },
		//		{ _subtract(_multiply(xSin, zSin), _multiply(_multiply(xCos, ySin), zCos)), _add(_multiply(xSin, zCos), _multiply(_multiply(xCos, ySin), zSin)), _multiply(xCos, yCos) }});
		//}

		///// <param name="angleX">Angle about the X-axis in radians.</param>
		///// <param name="angleY">Angle about the Y-axis in radians.</param>
		///// <param name="angleZ">Angle about the Z-axis in radians.</param>
		//public static Matrix<T> Factory3x3RotationZthenYthenX(T angleX, T angleY, T angleZ)
		//{
		//	T xCos = _cos(angleX), xSin = _sin(angleX),
		//		yCos = _cos(angleY), ySin = _sin(angleY),
		//		zCos = _cos(angleZ), zSin = _sin(angleZ);
		//	return new Matrix<T>(new T[,] {
		//		{ _multiply(yCos, zCos), _subtract(_multiply(_multiply(zCos, xSin), ySin), _multiply(xCos, zSin)), _add(_multiply(_multiply(xCos, zCos), ySin), _multiply(xSin, zSin)) },
		//		{ _multiply(yCos, zSin), _add(_multiply(xCos, zCos), _multiply(_multiply(xSin, ySin), zSin)), _add(_multiply(_negate(zCos), xSin), _multiply(_multiply(xCos, ySin), zSin)) },
		//		{ _negate(ySin), _multiply(yCos, xSin), _multiply(xCos, yCos) }});
		//}

		///// <summary>Creates a 3x3 matrix initialized with a shearing transformation.</summary>
		///// <param name="shearXbyY">The shear along the X-axis in the Y-direction.</param>
		///// <param name="shearXbyZ">The shear along the X-axis in the Z-direction.</param>
		///// <param name="shearYbyX">The shear along the Y-axis in the X-direction.</param>
		///// <param name="shearYbyZ">The shear along the Y-axis in the Z-direction.</param>
		///// <param name="shearZbyX">The shear along the Z-axis in the X-direction.</param>
		///// <param name="shearZbyY">The shear along the Z-axis in the Y-direction.</param>
		///// <returns>The constructed shearing matrix.</returns>
		//public static Matrix<T> Factory3x3Shear(
		//	T shearXbyY, T shearXbyZ, T shearYbyX,
		//	T shearYbyZ, T shearZbyX, T shearZbyY)
		//{
		//	return new Matrix<T>(new T[,] {
		//		{ _one, shearYbyX, shearZbyX },
		//		{ shearXbyY, _one, shearYbyZ },
		//		{ shearXbyZ, shearYbyZ, _one }});
		//}

		#endregion

		#region operators

		/// <summary>Negates all the values in a matrix.</summary>
		/// <param name="matrix">The matrix to have its values negated.</param>
		/// <returns>The resulting matrix after the negations.</returns>
		public static Matrix<T> operator -(Matrix<T> matrix)
		{ return Compute<T>.Matrix_Negate(matrix); }
		/// <summary>Does a standard matrix addition.</summary>
		/// <param name="left">The left matrix of the addition.</param>
		/// <param name="right">The right matrix of the addition.</param>
		/// <returns>The resulting matrix after teh addition.</returns>
		public static Matrix<T> operator +(Matrix<T> left, Matrix<T> right)
		{ return Compute<T>.Matrix_Add(left, right); }
		/// <summary>Does a standard matrix subtraction.</summary>
		/// <param name="left">The left matrix of the subtraction.</param>
		/// <param name="right">The right matrix of the subtraction.</param>
		/// <returns>The result of the matrix subtraction.</returns>
		public static Matrix<T> operator -(Matrix<T> left, Matrix<T> right)
		{ return Compute<T>.Matrix_Subtract(left, right); }
		/// <summary>Multiplies a vector by a matrix.</summary>
		/// <param name="left">The matrix of the multiplication.</param>
		/// <param name="right">The vector of the multiplication.</param>
		/// <returns>The resulting vector after the multiplication.</returns>
		public static Vector<T> operator *(Matrix<T> left, Vector<T> right)
		{ return Compute<T>.Matrix_Multiply_vector(left, right); }
		/// <summary>Does a standard matrix multiplication.</summary>
		/// <param name="left">The left matrix of the multiplication.</param>
		/// <param name="right">The right matrix of the multiplication.</param>
		/// <returns>The resulting matrix after the multiplication.</returns>
		public static Matrix<T> operator *(Matrix<T> left, Matrix<T> right)
		{ return Compute<T>.Matrix_Multiply(left, right); }
		/// <summary>Multiplies all the values in a matrix by a scalar.</summary>
		/// <param name="left">The matrix to have its values multiplied.</param>
		/// <param name="right">The scalar to multiply the values by.</param>
		/// <returns>The resulting matrix after the multiplications.</returns>
		public static Matrix<T> operator *(Matrix<T> left, T right)
		{ return Compute<T>.Matrix_Multiply_scalar(left, right); }
		/// <summary>Multiplies all the values in a matrix by a scalar.</summary>
		/// <param name="left">The scalar to multiply the values by.</param>
		/// <param name="right">The matrix to have its values multiplied.</param>
		/// <returns>The resulting matrix after the multiplications.</returns>
		public static Matrix<T> operator *(T left, Matrix<T> right)
		{ return Compute<T>.Matrix_Multiply_scalar(right, left); }
		/// <summary>Divides all the values in a matrix by a scalar.</summary>
		/// <param name="left">The matrix to have its values divided.</param>
		/// <param name="right">The scalar to divide the values by.</param>
		/// <returns>The resulting matrix after the divisions.</returns>
		public static Matrix<T> operator /(Matrix<T> left, T right)
		{ return Compute<T>.Matrix_Divide(left, right); }
		/// <summary>Applies a power to a matrix.</summary>
		/// <param name="left">The matrix to apply a power to.</param>
		/// <param name="right">The power to apply to the matrix.</param>
		/// <returns>The result of the power operation.</returns>
		public static Matrix<T> operator ^(Matrix<T> left, int right)
		{ return Compute<T>.Matrix_Power(left, right); }
		/// <summary>Checks for equality by value.</summary>
		/// <param name="left">The left matrix of the equality check.</param>
		/// <param name="right">The right matrix of the equality check.</param>
		/// <returns>True if the values of the matrices are equal, false if not.</returns>
		public static bool operator ==(Matrix<T> left, Matrix<T> right)
		{ return Compute<T>.Matrix_EqualsByValue(left, right); }
		/// <summary>Checks for false-equality by value.</summary>
		/// <param name="left">The left matrix of the false-equality check.</param>
		/// <param name="right">The right matrix of the false-equality check.</param>
		/// <returns>True if the values of the matrices are not equal, false if they are.</returns>
		public static bool operator !=(Matrix<T> left, Matrix<T> right)
		{ return !Compute<T>.Matrix_EqualsByValue(left, right); }
		/// <summary>Automatically converts a float[,] into a matrix if necessary.</summary>
		/// <param name="matrix">The float[,] to convert to a matrix.</param>
		/// <returns>The reference to the matrix representing the T[,].</returns>
		public static explicit operator Matrix<T>(T[,] matrix)
		{ return new Matrix<T>(matrix); }
		///// <summary>Automatically converts a matrix into a T[,] if necessary.</summary>
		///// <param name="matrix">The matrix to convert to a T[,].</param>
		///// <returns>The reference to the T[,] representing the matrix.</returns>
		//public static explicit operator T[,](Matrix<T> matrix)
		//{ 
		//	T[,] array = new T[matrix.Rows, matrix.Columns];
		//	for (int i = 0; i < i )
		//	return matrix; }
		#endregion

		#region instance

		/// <summary>Negates all the values in this matrix.</summary>
		/// <returns>The resulting matrix after the negations.</returns>
		public Matrix<T> Negate()
		{ return Compute<T>.Matrix_Negate(this); }
		/// <summary>Does a standard matrix addition.</summary>
		/// <param name="right">The matrix to add to this matrix.</param>
		/// <returns>The resulting matrix after the addition.</returns>
		public Matrix<T> Add(Matrix<T> right)
		{ return Compute<T>.Matrix_Add(this, right); }
		/// <summary>Does a standard matrix multiplication (triple for loop).</summary>
		/// <param name="right">The matrix to multiply this matrix by.</param>
		/// <returns>The resulting matrix after the multiplication.</returns>
		public Matrix<T> Multiply(Matrix<T> right)
		{ return Compute<T>.Matrix_Multiply(this, right); }
		/// <summary>Multiplies all the values in this matrix by a scalar.</summary>
		/// <param name="right">The scalar to multiply all the matrix values by.</param>
		/// <returns>The retulting matrix after the multiplications.</returns>
		public Matrix<T> Multiply(T right)
		{ return Compute<T>.Matrix_Multiply_scalar(this, right); }
		/// <summary>Divides all the values in this matrix by a scalar.</summary>
		/// <param name="right">The scalar to divide the matrix values by.</param>
		/// <returns>The resulting matrix after teh divisions.</returns>
		public Matrix<T> Divide(T right)
		{ return Compute<T>.Matrix_Divide(this, right); }
		/// <summary>Gets the minor of a matrix.</summary>
		/// <param name="row">The restricted row of the minor.</param>
		/// <param name="column">The restricted column of the minor.</param>
		/// <returns>The minor from the row/column restrictions.</returns>
		public Matrix<T> Minor(int row, int column)
		{ return Compute<T>.Matrix_Minor(this, row, column); }
		/// <summary>Combines two matrices from left to right 
		/// (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
		/// <param name="right">The matrix to combine with on the right side.</param>
		/// <returns>The resulting row-wise concatination.</returns>
		public Matrix<T> ConcatenateRowWise(Matrix<T> right)
		{ return Compute<T>.Matrix_ConcatenateRowWise(this, right); }
		/// <summary>Computes the determinent if this matrix is square.</summary>
		/// <returns>The computed determinent if this matrix is square.</returns>
		public T Determinent()
		{ return Compute<T>.Matrix_Determinent(this); }
		/// <summary>Computes the echelon form of this matrix (aka REF).</summary>
		/// <returns>The computed echelon form of this matrix (aka REF).</returns>
		public Matrix<T> Echelon()
		{ return Compute<T>.Matrix_Echelon(this); }
		/// <summary>Computes the reduced echelon form of this matrix (aka RREF).</summary>
		/// <returns>The computed reduced echelon form of this matrix (aka RREF).</returns>
		public Matrix<T> ReducedEchelon()
		{ return Compute<T>.Matrix_ReducedEchelon(this); }
		/// <summary>Computes the inverse of this matrix.</summary>
		/// <returns>The inverse of this matrix.</returns>
		public Matrix<T> Inverse()
		{ return Compute<T>.Matrix_Inverse(this); }
		/// <summary>Gets the adjoint of this matrix.</summary>
		/// <returns>The adjoint of this matrix.</returns>
		public Matrix<T> Adjoint()
		{ return Compute<T>.Matrix_Adjoint(this); }
		/// <summary>Transposes this matrix.</summary>
		/// <returns>The transpose of this matrix.</returns>
		public Matrix<T> Transpose()
		{ return Compute<T>.Matrix_Transpose(this); }
		/// <summary>Copies this matrix.</summary>
		/// <returns>The copy of this matrix.</returns>
		public Matrix<T> Clone()
		{ return Matrix<T>.Clone(this); }

		#endregion

		#region static

		/// <summary>Negates all the values in a matrix.</summary>
		/// <param name="matrix">The matrix to have its values negated.</param>
		/// <returns>The resulting matrix after the negations.</returns>
		public static Matrix<T> Negate(Matrix<T> matrix)
		{ return Compute<T>.Matrix_Negate(matrix); }
		/// <summary>Does standard addition of two matrices.</summary>
		/// <param name="left">The left matrix of the addition.</param>
		/// <param name="right">The right matrix of the addition.</param>
		/// <returns>The resulting matrix after the addition.</returns>
		public static Matrix<T> Add(Matrix<T> left, Matrix<T> right)
		{ return Compute<T>.Matrix_Add(left, right); }
		/// <summary>Subtracts a scalar from all the values in a matrix.</summary>
		/// <param name="left">The matrix to have the values subtracted from.</param>
		/// <param name="right">The scalar to subtract from all the matrix values.</param>
		/// <returns>The resulting matrix after the subtractions.</returns>
		public static Matrix<T> Subtract(Matrix<T> left, Matrix<T> right)
		{ return Compute<T>.Matrix_Subtract(left, right); }
		/// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
		/// <param name="left">The left matrix of the multiplication.</param>
		/// <param name="right">The right matrix of the multiplication.</param>
		/// <returns>The resulting matrix of the multiplication.</returns>
		public static Matrix<T> Multiply(Matrix<T> left, Matrix<T> right)
		{ return Compute<T>.Matrix_Multiply(left, right); }
		/// <summary>Does a standard (triple for looped) multiplication between matrices.</summary>
		/// <param name="left">The left matrix of the multiplication.</param>
		/// <param name="right">The right matrix of the multiplication.</param>
		/// <returns>The resulting matrix of the multiplication.</returns>
		public static Vector<T> Multiply(Matrix<T> left, Vector<T> right)
		{ return Compute<T>.Matrix_Multiply_vector(left, right._vector); }
		/// <summary>Multiplies all the values in a matrix by a scalar.</summary>
		/// <param name="left">The matrix to have the values multiplied.</param>
		/// <param name="right">The scalar to multiply the values by.</param>
		/// <returns>The resulting matrix after the multiplications.</returns>
		public static Matrix<T> Multiply(Matrix<T> left, T right)
		{ return Compute<T>.Matrix_Multiply_scalar(left, right); }
		/// <summary>Applies a power to a square matrix.</summary>
		/// <param name="matrix">The matrix to be powered by.</param>
		/// <param name="power">The power to apply to the matrix.</param>
		/// <returns>The resulting matrix of the power operation.</returns>
		public static Matrix<T> Power(Matrix<T> matrix, int power)
		{ return Compute<T>.Matrix_Power(matrix, power); }
		/// <summary>Divides all the values in the matrix by a scalar.</summary>
		/// <param name="matrix">The matrix to divide the values of.</param>
		/// <param name="right">The scalar to divide all the matrix values by.</param>
		/// <returns>The resulting matrix with the divided values.</returns>
		public static Matrix<T> Divide(Matrix<T> matrix, T right)
		{ return Compute<T>.Matrix_Divide(matrix, right); }
		/// <summary>Gets the minor of a matrix.</summary>
		/// <param name="matrix">The matrix to get the minor of.</param>
		/// <param name="row">The restricted row to form the minor.</param>
		/// <param name="column">The restricted column to form the minor.</param>
		/// <returns>The minor of the matrix.</returns>
		public static Matrix<T> Minor(Matrix<T> matrix, int row, int column)
		{ return Compute<T>.Matrix_Minor(matrix, row, column); }
		/// <summary>Combines two matrices from left to right 
		/// (result.Rows = left.Rows && result.Columns = left.Columns + right.Columns).</summary>
		/// <param name="left">The left matrix of the concatenation.</param>
		/// <param name="right">The right matrix of the concatenation.</param>
		/// <returns>The resulting matrix of the concatenation.</returns>
		public static Matrix<T> ConcatenateRowWise(Matrix<T> left, Matrix<T> right)
		{ return Compute<T>.Matrix_ConcatenateRowWise(left, right); }
		/// <summary>Calculates the determinent of a square matrix.</summary>
		/// <param name="matrix">The matrix to calculate the determinent of.</param>
		/// <returns>The determinent of the matrix.</returns>
		public static T Determinent(Matrix<T> matrix)
		{ return Compute<T>.Matrix_Determinent(matrix); }
		/// <summary>Calculates the echelon of a matrix (aka REF).</summary>
		/// <param name="matrix">The matrix to calculate the echelon of (aka REF).</param>
		/// <returns>The echelon of the matrix (aka REF).</returns>
		public static Matrix<T> Echelon(Matrix<T> matrix)
		{ return Compute<T>.Matrix_Echelon(matrix); }
		/// <summary>Calculates the echelon of a matrix and reduces it (aka RREF).</summary>
		/// <param name="matrix">The matrix matrix to calculate the reduced echelon of (aka RREF).</param>
		/// <returns>The reduced echelon of the matrix (aka RREF).</returns>
		public static Matrix<T> ReducedEchelon(Matrix<T> matrix)
		{ return Compute<T>.Matrix_ReducedEchelon(matrix); }
		/// <summary>Calculates the inverse of a matrix.</summary>
		/// <param name="matrix">The matrix to calculate the inverse of.</param>
		/// <returns>The inverse of the matrix.</returns>
		public static Matrix<T> Inverse(Matrix<T> matrix)
		{ return Compute<T>.Matrix_Inverse(matrix); }
		/// <summary>Calculates the adjoint of a matrix.</summary>
		/// <param name="matrix">The matrix to calculate the adjoint of.</param>
		/// <returns>The adjoint of the matrix.</returns>
		public static Matrix<T> Adjoint(Matrix<T> matrix)
		{ return Compute<T>.Matrix_Adjoint(matrix); }
		/// <summary>Returns the transpose of a matrix.</summary>
		/// <param name="matrix">The matrix to transpose.</param>
		/// <returns>The transpose of the matrix.</returns>
		public static Matrix<T> Transpose(Matrix<T> matrix)
		{ return Compute<T>.Matrix_Transpose(matrix); }
		/// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
		/// <param name="matrix">The matrix to decompose.</param>
		/// <param name="lower">The computed lower triangular matrix.</param>
		/// <param name="upper">The computed upper triangular matrix.</param>
		/// <summary>Decomposes a matrix into lower-upper reptresentation.</summary>
		/// <param name="matrix">The matrix to decompose.</param>
		/// <param name="lower">The computed lower triangular matrix.</param>
		/// <param name="upper">The computed upper triangular matrix.</param>
		public static void DecomposeLU(Matrix<T> matrix, out Matrix<T> lower, out Matrix<T> upper)
		{ Compute<T>.Matrix_DecomposeLU(matrix, out lower, out upper); }
		/// <summary>Creates a copy of a matrix.</summary>
		/// <param name="matrix">The matrix to copy.</param>
		/// <returns>A copy of the matrix.</returns>
		public static Matrix<T> Clone(Matrix<T> matrix)
		{ return new Matrix<T>(matrix); }
		/// <summary>Does a value equality check.</summary>
		/// <param name="left">The first matrix to check for equality.</param>
		/// <param name="right">The second matrix to check for equality.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(Matrix<T> left, Matrix<T> right)
		{ return Compute<T>.Matrix_EqualsByValue(left, right); }
		/// <summary>Does a value equality check with leniency.</summary>
		/// <param name="left">The first matrix to check for equality.</param>
		/// <param name="right">The second matrix to check for equality.</param>
		/// <param name="leniency">How much the values can vary but still be considered equal.</param>
		/// <returns>True if values are equal, false if not.</returns>
		public static bool EqualsValue(Matrix<T> left, Matrix<T> right, T leniency)
		{ return Compute<T>.Matrix_EqualsByValue_leniency(left, right, leniency); }
		/// <summary>Checks if two matrices are equal by reverences.</summary>
		/// <param name="left">The left matric of the equality check.</param>
		/// <param name="right">The right matrix of the equality check.</param>
		/// <returns>True if the references are equal, false if not.</returns>
		public static bool EqualsReference(Matrix<T> left, Matrix<T> right)
		{ return object.ReferenceEquals(left, right); }

		#endregion

		#region overrides

		/// <summary>Prints out a string representation of this matrix.</summary>
		/// <returns>A string representing this matrix.</returns>
		public override string ToString()
		{ return base.ToString(); }
		/// <summary>Computes a hash code from the values of this matrix.</summary>
		/// <returns>A hash code for the matrix.</returns>
		public override int GetHashCode()
		{ return this._matrix.GetHashCode(); }
		/// <summary>Does an equality check by value.</summary>
		/// <param name="right">The object to compare to.</param>
		/// <returns>True if the references are equal, false if not.</returns>
		public override bool Equals(object right)
		{
			if (!(right is Matrix<T>))
				return Matrix<T>.EqualsValue(this, (Matrix<T>)right);
			return false;
		}

		#endregion
	}
}
