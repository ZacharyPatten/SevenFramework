// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

using System;
using System.Linq.Expressions;

namespace Seven.Mathematics
{
	/// <summary>Contains syntax definitions for the Seven.Mathematics language.</summary>
	/// <typeparam name="T"></typeparam>
	public static class Syntax<T>
	{
		#region Definition

		public abstract class Node
		{
			public static implicit operator Node(T constant) { return new Constant(constant); }

			public Node Simplify() { return Syntax<T>.Simplify(this); }
			public Node Assign(string variable, T value) { return Syntax<T>.Assign(this, variable, value); }
			public Node Derive(string variable) { return Syntax<T>.Derive(this, variable); }
			public Node Integrate(string variable) { return Syntax<T>.Integrate(this, variable); }
		}

		public class Constant : Node
		{
			T _constant;

			public T Value { get { return this._constant; } }
			
			public Constant(T constant)
			{
				this._constant = constant;
			}

			public static implicit operator T(Constant constant) { return constant._constant; }
			
			public override string ToString() { return this._constant.ToString(); }
		}

		public class Variable : Node
		{
			public string _name;

			public string Name { get { return this._name; } }
			
			public Variable(string name)
			{
				this._name = name;
			}
			
			public override string ToString() { return this._name; }
		}

		public abstract class Operation : Node
		{
		}

		public abstract class Unary : Operation
		{
			protected Node _operand;

			public Node Operand
			{
				get { return this._operand; }
				set { this._operand = value; }
			}

			public Unary() : base() { }

			public Unary(Node operand)
			{
				this._operand = operand;
			}
		}

		public class Negate : Unary
		{
			public Negate() : base() { }

			public Negate(Node operand) : base(operand) { }

			public override string ToString() { return string.Concat("-", this._operand); }
		}

		public class Sine : Unary
		{
			public Sine() : base() { }

			public Sine(Node operand) : base(operand) { }

			public override string ToString() { return string.Concat("Sine(", this._operand, ")"); }
		}

		public class Cosine : Unary
		{
			public Cosine() : base() { }

			public Cosine(Node operand) : base(operand) { }

			public override string ToString() { return string.Concat("Cosine(", this._operand, ")"); }
		}

		public class Tangent : Unary
		{
			public Tangent() : base() { }

			public Tangent(Node operand) : base(operand) { }

			public override string ToString() { return string.Concat("Tangent(", this._operand, ")"); }
		}

		public class NaturalLog : Unary
		{
			public NaturalLog() : base() { }

			public NaturalLog(Node operand) : base(operand) { }

			public override string ToString() { return string.Concat("ln(", this._operand, ")"); }
		}

		public class SquareRoot : Unary
		{
			public SquareRoot() : base() { }

			public SquareRoot(Node operand) : base(operand) { }

			public override string ToString() { return string.Concat("sqrt(", this._operand, ")"); }
		}

		public class Exponential : Unary
		{
			public Exponential() : base() { }

			public Exponential(Node operand) : base(operand) { }

			public override string ToString() { return string.Concat("e^(", this._operand, ")"); }
		}

		public class Invert : Unary
		{
			public Invert() : base() { }

			public Invert(Node operand) : base(operand) { }
		}

		public class Determinent : Unary
		{
			public Determinent() : base() { }

			public Determinent(Node operand) : base(operand) { }
		}

		public abstract class Binary : Operation
		{
			protected Node _left;
			protected Node _right;

			public Node Left
			{
				get { return this._left; }
				set { this._left = value; }
			}

			public Node Right
			{
				get { return this._right; }
				set { this._right = value; }
			}

			public Binary() { }

			public Binary(Node left, Node right)
			{
				this._left = left;
				this._right = right;
			}
		}

		public class Addition : Binary
		{
			public Addition() : base() { }

			public Addition(Node left, Node right) : base(left, right) { }

			public override string ToString()
			{
				string left = this._left.ToString();
				if (this._left is Multiplication || this._left is Division && left is Constant && Compute<T>.Compare(left as Constant, Compute<T>.Zero) == Comparison.Less)
					left = string.Concat("(", left, ")");
				string right = this._right.ToString();
				if (this._right is Addition || this._right is Subtraction || this._left is Multiplication || this._left is Division)
					right = string.Concat("(", right, ")");
				if (this._right is Constant && Compute<T>.Compare(this._right as Constant, Compute<T>.Zero) == Comparison.Less)
					return string.Concat(left, " - ", Compute<T>.Multiply(this._right as Constant, Compute<T>.IntCast(-1)));
				return string.Concat(left, " + ", right);
			}
		}

		public class Subtraction : Binary
		{
			public Subtraction() : base() { }

			public Subtraction(Node left, Node right) : base(left, right) { }

			public override string ToString()
			{
				string left = this._left.ToString();
				if (this._left is Multiplication || this._left is Division)
					left = string.Concat("(", left, ")");
				string right = this._right.ToString();
				if (this._right is Addition || this._right is Subtraction || this._left is Multiplication || this._left is Division)
					right = string.Concat("(", right, ")");
				return string.Concat(left, " - ", right);
			}
		}

		public class Multiplication : Binary
		{
			public Multiplication() : base() { }

			public Multiplication(Node left, Node right) : base(left, right) { }

			public override string ToString()
			{
				string left = this._left.ToString();
				//if (this._left is Multiplication || this._left is Division)
				//	left = string.Concat("(", left, ")");
				string right = this._right.ToString();
				if (this._right is Multiplication || this._right is Division)
					right = string.Concat("(", right, ")");
				return string.Concat(left, " * ", right);
			}
		}

		public class Division : Binary
		{
			public Division() : base() { }

			public Division(Node left, Node right) : base(left, right) { }

			public override string ToString()
			{
				string left = this._left.ToString();
				//if (this._left is Multiplication || this._left is Division)
				//	left = string.Concat("(", left, ")");
				string right = this._right.ToString();
				if (this._right is Multiplication || this._right is Division)
					right = string.Concat("(", right, ")");
				return string.Concat(left, " / ", right);
			}
		}

		public class Power : Binary
		{
			public Power() : base() { }

			public Power(Node left, Node right) : base(left, right) { }

			public override string ToString() { return string.Concat(this._left, " ^ ", this._right); }
		}

		public class Root : Binary
		{
			public Root() : base() { }

			public Root(Node left, Node right) : base(left, right) { }

			public override string ToString() { return string.Concat(this._left, " ^ (1 / ", this._right, ")"); }
		}

		public class Equate : Binary
		{
			public Equate() : base() { }

			public Equate(Node left, Node right) : base(left, right) { }

			public override string ToString() { return string.Concat(this._left, " = ", this._right); }
		}

		public abstract class Ternary : Operation
		{
			protected Node _one;
			protected Node _two;
			protected Node _three;

			public Node One
			{
				get { return this._one; }
				set { this._one = value; }
			}

			public Node Two
			{
				get { return this._two; }
				set { this._two = value; }
			}

			public Node Three
			{
				get { return this._three; }
				set { this._three = value; }
			}

			public Ternary() { }

			public Ternary(Node one, Node two, Node three)
			{
				this._one = one;
				this._two = two;
				this._three = three;
			}
		}

		public abstract class Multinary : Operation
		{
			protected Node[] _operands;

			public Node[] Operands
			{
				get { return this._operands; }
				set { this._operands = value; }
			}

			public Multinary() { }

			public Multinary(Node[] operands)
			{
				this._operands = operands;
			}
		}

		public class Summation : Multinary
		{
			public Summation() : base() { }

			public Summation(Node[] array) : base(array) { }
		}

		#endregion

		#region Parsing

		public static Node Parse(Expression e)
		{
			try
			{
				Func<Expression, Node> recursive = null;
				Func<InvocationExpression, Node> invocationExpression_to_node = null;

				recursive =
					(Expression expression) =>
					{
						UnaryExpression unary_expression = expression as UnaryExpression;
						BinaryExpression binary_expression = expression as BinaryExpression;

						switch (expression.NodeType)
						{
							// Lambda
							case ExpressionType.Lambda:
								//labmda_expression.Parameters
								return recursive((expression as LambdaExpression).Body);
							// constant
							case ExpressionType.Constant:
								return new Constant((T)(expression as ConstantExpression).Value);
							// variable
							case ExpressionType.Parameter:
								return new Variable((expression as ParameterExpression).Name);
							// unary
							case ExpressionType.Negate:
								return new Negate(recursive(unary_expression.Operand));
							case ExpressionType.UnaryPlus:
								return recursive(unary_expression.Operand);
							// binary
							case ExpressionType.Add:
								return new Addition(recursive(binary_expression.Left), recursive(binary_expression.Right));
							case ExpressionType.Subtract:
								return new Subtraction(recursive(binary_expression.Left), recursive(binary_expression.Right));
							case ExpressionType.Multiply:
								return new Multiplication(recursive(binary_expression.Left), recursive(binary_expression.Right));
							case ExpressionType.Divide:
								return new Division(recursive(binary_expression.Left), recursive(binary_expression.Right));
							case ExpressionType.Power:
								return new Power(recursive(binary_expression.Left), recursive(binary_expression.Right));
							// call
							case ExpressionType.Call:
								throw new ArithmeticException("Invalid syntax parse (only members of Seven.MathematicsCompute<T> allowed): " + expression);
							// Invocation
							case ExpressionType.Invoke:
								return invocationExpression_to_node(expression as InvocationExpression);
						}
						throw new ArithmeticException("Invalid syntax parse (unexpected expression node type): " + expression);
					};

				invocationExpression_to_node =
					(InvocationExpression invocationExpression) =>
					{
						MemberExpression member_expression = invocationExpression.Expression as MemberExpression;
						if (member_expression == null || member_expression.Member.DeclaringType != typeof(Compute<T>))
							throw new ArithmeticException("Invalid syntax parse (only members of Seven.MathematicsCompute<T> allowed): " + invocationExpression);

						Node[] nodes = null;
						if (invocationExpression.Arguments != null)
						{
							nodes = new Node[invocationExpression.Arguments.Count];
							for (int i = 0; i < nodes.Length; i++)
								nodes[i] = recursive(invocationExpression.Arguments[i]);
						}

						switch (member_expression.Member.Name)
						{
							// constants
							case "Pi": break;
							// arithmetic
							case "Negate": return new Negate(nodes[0]);
							case "Add": return new Addition(nodes[0], nodes[1]);
							case "Summation": return new Summation(nodes);
							case "Subtract": return new Subtraction(nodes[0], nodes[1]);
							case "Multiply": return new Multiplication(nodes[0], nodes[1]);
							case "Divide": return new Division(nodes[0], nodes[1]);
							case "Power": return new Power(nodes[0], nodes[1]);
							case "SquareRoot": return new SquareRoot(nodes[0]);
							case "Root": return new Root(nodes[0], nodes[1]);
							// logic
							case "AbsoluteValue": break;
							case "max": break;
							case "min": break;
							case "clamp": break;
							case "equ_len": break;
							case "Compare": break;
							case "Equate": return new Equate(nodes[0], nodes[1]);
							// factoring
							case "GreatestCommonFactor": break;
							case "LeastCommonMultiple": break;
							case "factorPrimes": break;
							// eponentials
							case "exp": break;
							case "ln": break;
							case "log": break;
							// angle
							case "DegreesToRadians": break;
							case "TurnsToRadians": break;
							case "GradiansToRadians": break;
							case "RadiansToDegrees": break;
							case "RadiansToTurns": break;
							case "RadiansToGradians": break;
							// miscelaneous
							case "IsPrime": break;
							case "invert": break;
							// interpolation
							case "LinearInterpolation": break;
							// Vector
							case "Vector_Add": break;
							case "Vector_Negate": break;
							case "Vector_Subtract": break;
							case "Vector_Multiply": break;
							case "Vector_Divide": break;
							case "Vector_DotProduct": break;
							case "Vector_CrossProduct": break;
							case "Vector_Normalize": break;
							case "Vector_Magnitude": break;
							case "Vector_MagnitudeSquared": break;
							case "Vector_Angle": break;
							case "Vector_RotateBy": break;
							case "Vector_Lerp": break;
							case "Vector_Slerp": break;
							case "Vector_Blerp": break;
							case "Vector_EqualsValue": break;
							case "Vector_EqualsValue_leniency": break;
							case "Vector_RotateBy_quaternion": break;
							// Matrix
							case "Matrix_FactoryZero": break;
							case "Matrix_FactoryOne": break;
							case "Matrix_FactoryIdentity": break;
							case "Matrix_IsSymetric": break;
							case "Matrix_Negate": break;
							case "Matrix_Add": break;
							case "Matrix_Subtract": break;
							case "Matrix_Multiply": break;
							case "Matrix_Multiply_vector": break;
							case "Matrix_Multiply_scalar": break;
							case "Matrix_Divide": break;
							case "Matrix_Power": break;
							case "Matrix_Minor": break;
							case "Matrix_ConcatenateRowWise": break;
							case "Matrix_Determinent": break;
							case "Matrix_Echelon": break;
							case "Matrix_ReducedEchelon": break;
							case "Matrix_Inverse": break;
							case "Matrix_Adjoint": break;
							case "Matrix_Transpose": break;
							case "Matrix_DecomposeLU": break;
							case "Matrix_EqualsByValue": break;
							case "Matrix_EqualsByValue_leniency": break;
							case "Matrix_RowMultiplication": break;
							case "Matrix_RowAddition": break;
							case "Matrix_SwapRows": break;
							// Quaternion
							case "Quaternion_Magnitude": break;
							case "Quaternion_MagnitudeSquared": break;
							case "Quaternion_Conjugate": break;
							case "Quaternion_Add": break;
							case "Quaternion_Subtract": break;
							case "Quaternion_Multiply": break;
							case "Quaternion_Multiply_scalar": break;
							case "Quaternion_Multiply_Vector": break;
							case "Quaternion_Normalize": break;
							case "Quaternion_Invert": break;
							case "Quaternion_Lerp": break;
							case "Quaternion_Slerp": break;
							case "Quaternion_Rotate": break;
							case "Quaternion_EqualsValue": break;
							case "Quaternion_EqualsValue_leniency": break;
							// combinatorics
							case "Factorial": break;
							case "Combinations": break;
							case "Choose": break;
							// statistics
							case "Mode": break;
							case "Mean": break;
							case "Median": break;
							case "GeometricMean": break;
							case "Variance": break;
							case "StandardDeviation": break;
							case "MeanDeviation": break;
							case "Range": break;
							case "Quantiles": break;
							case "Correlation": break;
							// trigonometry
							case "Sine": return new Sine(nodes[0]);
							case "Cosine": return new Cosine(nodes[0]);
							case "Tangent": return new Tangent(nodes[0]);
							case "Cosecant": break;
							case "Secant": break;
							case "Cotangent": break;
							case "InverseSine": break;
							case "InverseCosine": break;
							case "InverseTangent": break;
							case "InverseCosecant": break;
							case "InverseSecant": break;
							case "InverseCotangent": break;
							case "HyperbolicSine": break;
							case "HyperbolicCosine": break;
							case "HyperbolicTangent": break;
							case "HyperbolicSecant": break;
							case "HyperbolicCosecant": break;
							case "HyperbolicCotangent": break;
							case "InverseHyperbolicSine": break;
							case "InverseHyperbolicCosine": break;
							case "InverseHyperbolicTangent": break;
							case "InverseHyperbolicCosecant": break;
							case "InverseHyperbolicSecant": break;
							case "InverseHyperbolicCotangent": break;
						}
						throw new ArithmeticException("Invalid syntax parse (only members of Seven.MathematicsCompute<T> allowed): " + invocationExpression);
					};

				return recursive(e);
			}
			catch (ArithmeticException exception_specific)
			{
				throw new ArithmeticException("failed to parse expression into SevenFramework mathematical syntax: " + e, exception_specific);
			}
		}

		private static Node Parse(string tree)
		{
			throw new System.NotImplementedException();

			//			// constant node: "7", "7.7", or ".7"
			//			if (char.IsDigit(tree[0]) || tree[0] == '.')
			//			{

			//				#region error checking
			//#if no_error_checking
			//				// nothing
			//#else
			//				bool comma = false;
			//				for (int i = 0; i < tree.Length; i++)
			//					if (char.IsDigit(tree[i]))
			//						continue;
			//					else if (tree[i] == '.' && !comma)
			//						comma = true;
			//					else
			//						throw new Error("mathematics parsing error");
			//#endif
			//				#endregion

			//				throw new Error("mathematics parsing error");
			//			}
			//			// variable node: "[variable]"
			//			else if (tree[0] == '[')
			//			{

			//				#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//				if (tree[tree.Length - 1] != ']')
			//					throw new Error("mathematics parsing error");
			//#endif
			//				#endregion

			//				string variable = tree.Substring(1, tree.Length - 2);
			//				return new Node.variable(variable);
			//			}
			//			// operation node: "token(argument[0], argument[1], ...)"
			//			else
			//			{

			//				#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//				if (tree[tree.Length - 1] != ')')
			//					throw new Error("mathematics parsing error");
			//#endif
			//				#endregion

			//				// get the token
			//				string token = tree.Substring(0, tree.IndexOf('('));

			//				// get the substring of arguments
			//				int arguments_start = token.Length + 2;
			//				int arguments_length = (tree.Length - 1) - arguments_start;
			//				string list = tree.Substring(arguments_start, arguments_length);

			//				// count the number of arguments
			//				int scope = 0;
			//				int argument = 0;
			//				for (int b = 0; b < list.Length; b++)
			//					switch (list[b])
			//					{
			//						case '(':
			//							scope++;
			//							break;
			//						case ')':
			//							scope--;
			//							break;
			//						case ',':
			//							if (scope == 0)
			//								argument++;
			//							break;
			//					}

			//				// get the arguments
			//				string[] arguments = new string[argument];
			//				argument = 0;
			//				scope = 0;
			//				int a = 0;
			//				for (int b = 0; b < list.Length; b++)
			//					switch (list[b])
			//					{
			//						case '(':
			//							scope++;
			//							break;
			//						case ')':
			//							scope--;
			//							break;
			//						case ',':
			//							if (scope == 0)
			//							{
			//								arguments[argument] = list.Substring(a, b - a);
			//								a = b + 1;
			//								argument++;
			//							}
			//							break;
			//					}

			//				// recursive calls
			//				Node[] nodes = new Node[arguments.Length];
			//				for (int i = 0; i < nodes.Length; i++)
			//					nodes[i] = Parse(arguments[i]);

			//				// node creation
			//				switch (token)
			//				{

			//					case "add":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 2)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.binary.add(nodes[0], nodes[1]);

			//					case "subtract":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 2)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.binary.subtract(nodes[0], nodes[1]);

			//					case "multiply":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 2)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.binary.multiply(nodes[0], nodes[1]);

			//					case "divide":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 2)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.binary.divide(nodes[0], nodes[1]);

			//					case "power":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 2)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.binary.power(nodes[0], nodes[1]);

			//					case "negate":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 1)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.unary.negate(nodes[0]);

			//					case "sin":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 1)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.unary.sin(nodes[0]);

			//					case "cos":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 1)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.unary.cos(nodes[0]);

			//					case "tan":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 1)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.unary.tan(nodes[0]);

			//					case "csc":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 1)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.unary.csc(nodes[0]);

			//					case "sec":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 1)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.unary.sec(nodes[0]);

			//					case "cot":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 1)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.unary.cot(nodes[0]);

			//					case "arcsin":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 1)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.unary.arcsin(nodes[0]);

			//					case "arccos":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 1)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.unary.arccos(nodes[0]);

			//					case "arctan":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 1)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.unary.arctan(nodes[0]);

			//					case "arccsc":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 1)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.unary.arccsc(nodes[0]);

			//					case "arcsec":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 1)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.unary.arcsec(nodes[0]);

			//					case "arccot":
			//						#region error checking
			//#if no_error_checking
			//					//nothing
			//#else
			//						if (nodes.Length != 1)
			//							throw new Error("mathematics parsing error");
			//#endif
			//						#endregion
			//						return new Node.operations.unary.arccot(nodes[0]);

			//					case "equate":
			//						return new Node.operations.multinary.equate(nodes);

			//					case "less":
			//						return new Node.operations.multinary.equate(nodes);

			//					//case "derive":
			//					//	return;
			//					//case "integrate":
			//					//	return;
			//					//case "integrate":
			//					//	return;

			//					default:
			//						throw new Error("mathematics parsing error");

			//				}
			//			}
		}

		#endregion

		#region Simplification

		public static Node Simplify(Node node)
		{
			#region Constant
			if (node is Constant)
			{
				return new Constant((node as Constant).Value);
			}
			#endregion
			#region Variable
			else if (node is Variable)
			{
				return new Variable((node as Variable)._name);
			}
			#endregion
			#region Operation
			else if (node is Operation)
			{
				#region Unary
				if (node is Unary)
				{
					Unary unary = node as Unary;
					Node operand = Simplify(unary.Operand);

					#region Negate
					if (node is Negate)
					{
						// Rule: [-A] => [B] where A is constant and B is -A
						if (unary.Operand is Constant)
						{
							var A = unary.Operand as Constant;
							var B = Compute<T>.Negate(A);
							return B;
						}
					}
					#endregion

					return Activator.CreateInstance(
						node.GetType(),
						new object[]
						{ 
							operand,
						}) as Node;
				}
				#endregion
				#region Binary
				else if (node is Binary)
				{
					Binary binary = node as Binary;
					Node left = Simplify(binary.Left);
					Node right = Simplify(binary.Right);

					#region Addition
					if (node is Addition)
					{
						#region Computation
						// Rule: [A + B] => [C] where A is constant, B is constant, and C is A + B
						if (left is Constant && right is Constant)
						{
							var A = left as Constant;
							var B = right as Constant;
							var C = Compute<T>.Add(A, B);
							return C;
						}
						#endregion
						#region Additive Identity Property
						// Rule: [X + 0] => [X]
						if (right is Constant && Compute<T>.Equate((right as Constant).Value, Compute<T>.Zero))
						{
							var X = left;
							return X;
						}
						// Rule: [0 + X] => [X]
						if (left is Constant && Compute<T>.Equate((left as Constant).Value, Compute<T>.Zero))
						{
							var X = right;
							return X;
						}
						#endregion
						#region Commutative/Associative Property
						// Rule: ['X + A' + B] => [X + C] where A is constant, B is constant, and C is A + B
						if (left is Addition && (left as Addition).Right is Constant && right is Constant)
						{
							var A = (left as Addition).Right as Constant;
							var B = right as Constant;
							var C = Compute<T>.Add(A, B);
							var X = (left as Addition).Left;
							return new Addition(X, C);
						}
						// Rule: ['A + X' + B] => [X + C] where A is constant, B is constant, and C is A + B
						if (left is Addition && (left as Addition).Left is Constant && right is Constant)
						{
							var A = (left as Addition).Left as Constant;
							var B = right as Constant;
							var C = Compute<T>.Add(A, B);
							var X = (left as Addition).Right;
							return new Addition(X, C);
						}
						// Rule: [B + 'X + A'] => [X + C] where A is constant, B is constant, and C is A + B
						if (right is Addition && (right as Addition).Right is Constant && left is Constant)
						{
							var A = (right as Addition).Right as Constant;
							var B = left as Constant;
							var C = Compute<T>.Add(A, B);
							var X = (right as Addition).Left;
							return new Addition(X, C);
						}
						// Rule: [B + 'A + X'] => [X + C] where A is constant, B is constant, and C is A + B
						if (right is Addition && (right as Addition).Left is Constant && left is Constant)
						{
							var A = (right as Addition).Left as Constant;
							var B = left as Constant;
							var C = Compute<T>.Add(A, B);
							var X = (right as Addition).Right;
							return new Addition(X, C);
						}
						// Rule: ['X - A' + B] => [X + C] where A is constant, B is constant, and C is B - A
						if (left is Subtraction && (left as Subtraction).Right is Constant && right is Constant)
						{
							var A = (left as Subtraction).Right as Constant;
							var B = right as Constant;
							var C = Compute<T>.Subtract(B, A);
							var X = (left as Subtraction).Left;
							return new Addition(X, C);
						}
						// Rule: ['A - X' + B] => [C - X] where A is constant, B is constant, and C is A + B
						if (left is Subtraction && (left as Subtraction).Left is Constant && right is Constant)
						{
							var A = (left as Subtraction).Left as Constant;
							var B = right as Constant;
							var C = Compute<T>.Add(A, B);
							var X = (left as Subtraction).Right;
							return new Subtraction(C, X);
						}
						// Rule: [B + 'X - A'] => [X + C] where A is constant, B is constant, and C is B - A
						if (right is Subtraction && (right as Subtraction).Right is Constant && left is Constant)
						{
							var A = (right as Subtraction).Right as Constant;
							var B = left as Constant;
							var C = Compute<T>.Subtract(B, A);
							var X = (right as Subtraction).Left;
							return new Addition(X, C);
						}
						// Rule: [B + 'A - X'] => [C - X] where A is constant, B is constant, and C is A + B
						if (right is Subtraction && (right as Subtraction).Left is Constant && left is Constant)
						{
							var A = (right as Subtraction).Left as Constant;
							var B = left as Constant;
							var C = Compute<T>.Subtract(B, A);
							var X = (right as Subtraction).Right;
							return new Addition(X, C);
						}
						#endregion
					}
					#endregion
					#region Subtraction
					if (node is Subtraction)
					{
						#region Computation
						// Rule: [A - B] => [C] where A is constant, B is constant, and C is A - B
						if (left is Constant && right is Constant)
						{
							var A = left as Constant;
							var B = right as Constant;
							var C = Compute<T>.Subtract(A, B);
							return C;
						}
						#endregion
						#region Identity Property
						// Rule: [X - 0] => [X]
						if (right is Constant && Compute<T>.Equate((right as Constant).Value, Compute<T>.Zero))
						{
							var X = left;
							return X;
						}
						// Rule: [0 - X] => [-X]
						if (left is Constant && Compute<T>.Equate((left as Constant).Value, Compute<T>.Zero))
						{
							var X = right;
							return new Negate(X);
						}
						#endregion
						#region Commutative/Associative Property
						// Rule: ['X - A' - B] => [X - C] where A is constant, B is constant, and C is A + B
						if (left is Subtraction && (left as Subtraction).Right is Constant && right is Constant)
						{
							var A = (left as Subtraction).Right as Constant;
							var B = right as Constant;
							var C = Compute<T>.Add(A, B);
							var X = (left as Subtraction).Left;
							return new Subtraction(X, C);
						}
						// Rule: ['A - X' - B] => [C - X] where A is constant, B is constant, and C is A - B
						if (left is Subtraction && (left as Subtraction).Left is Constant && right is Constant)
						{
							var A = (left as Subtraction).Left as Constant;
							var B = right as Constant;
							var C = Compute<T>.Subtract(A, B);
							var X = (left as Subtraction).Right;
							return new Subtraction(C, X);
						}
						// Rule: [B - 'X - A'] => [C - X] where A is constant, B is constant, and C is B - A
						if (right is Subtraction && (right as Subtraction).Right is Constant && left is Constant)
						{
							var A = (right as Subtraction).Right as Constant;
							var B = left as Constant;
							var C = Compute<T>.Subtract(B, A);
							var X = (right as Subtraction).Left;
							return new Subtraction(C, X);
						}
						// Rule: [B - 'A - X'] => [C - X] where A is constant, B is constant, and C is B - A
						if (right is Subtraction && (right as Subtraction).Left is Constant && left is Constant)
						{
							var A = (right as Subtraction).Left as Constant;
							var B = left as Constant;
							var C = Compute<T>.Subtract(B, A);
							var X = (right as Subtraction).Left;
							return new Subtraction(C, X);
						}
						// Rule: ['X + A' - B] => [X + C] where A is constant, B is constant, and C is A - B
						if (left is Addition && (left as Addition).Right is Constant && right is Constant)
						{
							var A = (left as Addition).Right as Constant;
							var B = right as Constant;
							var C = Compute<T>.Subtract(A, B);
							var X = (left as Addition).Left;
							return new Addition(X, C);
						}
						// Rule: ['A + X' - B] => [C + X] where A is constant, B is constant, and C is A - B
						if (left is Addition && (left as Addition).Right is Constant && right is Constant)
						{
							var A = (left as Addition).Left as Constant;
							var B = right as Constant;
							var C = Compute<T>.Subtract(A, B);
							var X = (left as Addition).Right;
							return new Addition(X, C);
						}
						// Rule: [B - 'X + A'] => [C - X] where A is constant, B is constant, and C is A + B
						if (right is Addition && (right as Addition).Right is Constant && left is Constant)
						{
							var A = (right as Addition).Right as Constant;
							var B = left as Constant;
							var C = Compute<T>.Add(A, B);
							var X = (right as Addition).Left;
							return new Subtraction(C, X);
						}
						// Rule: [B - 'A + X'] => [C + X] where A is constant, B is constant, and C is B - A
						if (right is Addition && (right as Addition).Left is Constant && left is Constant)
						{
							var A = (right as Addition).Left as Constant;
							var B = left as Constant;
							var C = Compute<T>.Subtract(B, A);
							var X = (right as Addition).Right;
							return new Addition(C, X);
						}
						#endregion
					}
					#endregion
					#region Multiplication
					if (node is Multiplication)
					{
						#region Computation
						// Rule: [A * B] => [C] where A is constant, B is constant, and C is A * B
						if (left is Constant && right is Constant)
						{
							var A = left as Constant;
							var B = right as Constant;
							var C = Compute<T>.Multiply(A, B);
							return C;
						}
						#endregion
						#region Zero Property
						// Rule: [X * 0] => [0]
						if (right is Constant && Compute<T>.Equate((right as Constant).Value, Compute<T>.Zero))
						{
							return Compute<T>.Zero;
						}
						// Rule: [0 * X] => [0]
						if (left is Constant && Compute<T>.Equate((left as Constant).Value, Compute<T>.Zero))
						{
							return Compute<T>.Zero;
						}
						#endregion
						#region Identity Property
						// Rule: [X * 1] => [X]
						if (right is Constant && Compute<T>.Equate((right as Constant).Value, Compute<T>.One))
						{
							var A = left;
							return A;
						}
						// Rule: [1 * X] => [X]
						if (left is Constant && Compute<T>.Equate((left as Constant).Value, Compute<T>.One))
						{
							var A = right;
							return A;
						}
						#endregion
						#region Commutative/Associative Property
						// Rule: [(X * A) * B] => [X * C] where A is constant, B is constant, and C is A * B
						if (left is Multiplication && (left as Multiplication).Right is Constant && right is Constant)
						{
							var A = (left as Multiplication).Right as Constant;
							var B = right as Constant;
							var C = Compute<T>.Multiply(A, B);
							var X = (left as Multiplication).Left;
							return new Multiplication(X, C);
						}
						// Rule: [(A * X) * B] => [X * C] where A is constant, B is constant, and C is A * B
						if (left is Multiplication && (left as Multiplication).Left is Constant && right is Constant)
						{
							var A = (left as Multiplication).Left as Constant;
							var B = right as Constant;
							var C = Compute<T>.Multiply(A, B);
							var X = (left as Multiplication).Right;
							return new Multiplication(X, C);
						}
						// Rule: [B * (X * A)] => [X * C] where A is constant, B is constant, and C is A * B
						if (right is Multiplication && (right as Multiplication).Right is Constant && left is Constant)
						{
							var A = (right as Multiplication).Right as Constant;
							var B = left as Constant;
							var C = Compute<T>.Multiply(A, B);
							var X = (left as Multiplication).Left;
							return new Multiplication(X, C);
						}
						// Rule: [B * (A * X)] => [X * C] where A is constant, B is constant, and C is A * B
						if (right is Multiplication && (right as Multiplication).Left is Constant && left is Constant)
						{
							var A = (right as Multiplication).Left as Constant;
							var B = left as Constant;
							var C = Compute<T>.Multiply(A, B);
							var X = (right as Multiplication).Right;
							return new Multiplication(X, C);
						}
						// Rule: [(X / A) * B] => [X * C] where A is constant, B is constant, and C is B / A
						if (left is Division && (left as Division).Right is Constant && right is Constant)
						{
							var A = (left as Division).Right as Constant;
							var B = right as Constant;
							var C = Compute<T>.Divide(B, A);
							var X = (right as Division).Left;
							return new Multiplication(X, C);
						}
						// Rule: [(A / X) * B] => [C / X] where A is constant, B is constant, and C is A * B
						if (left is Division && (left as Division).Left is Constant && right is Constant)
						{
							var A = (left as Division).Left as Constant;
							var B = right as Constant;
							var C = Compute<T>.Multiply(A, B);
							var X = (left as Division).Right;
							return new Division(C, X);
						}
						// Rule: [B * (X / A)] => [X * C] where A is constant, B is constant, and C is B / A
						if (right is Division && (right as Division).Right is Constant && left is Constant)
						{
							var A = (right as Division).Right as Constant;
							var B = left as Constant;
							var C = Compute<T>.Divide(B, A);
							var X = (right as Division).Left;
							return new Multiplication(X, C);
						}
						// Rule: [B * (A / X)] => [C / X] where A is constant, B is constant, and C is A * B
						if (right is Division && (right as Division).Left is Constant && left is Constant)
						{
							var A = (right as Division).Left as Constant;
							var B = left as Constant;
							var C = Compute<T>.Multiply(A, B);
							var X = (right as Division).Right;
							return new Division(C, X);
						}
						#endregion
					}
					#endregion
					#region Division
					if (node is Division)
					{
						#region Error Handling
						// Rule: [X / 0] => Error
						if (right is Constant && Compute<T>.Equate((right as Constant).Value, Compute<T>.Zero))
						{
							throw new System.DivideByZeroException();
						}
						#endregion
						#region Computation
						// Rule: [A / B] => [C] where A is constant, B is constant, and C is A / B
						if (left is Constant && right is Constant)
						{
							var A = left as Constant;
							var B = right as Constant;
							var C = Compute<T>.Divide(A, B);
							return C;
						}
						#endregion
						#region Zero Property
						// Rule: [0 / X] => [0]
						if (left is Constant && Compute<T>.Equate((left as Constant).Value, Compute<T>.Zero))
						{
							return left;
						}
						#endregion
						#region Identity Property
						// Rule: [X / 1] => [X]
						if (right is Constant && Compute<T>.Equate((right as Constant).Value, Compute<T>.One))
						{
							return left;
						}
						#endregion
						#region Commutative/Associative Property
						// Rule: [(X / A) / B] => [X / C] where A is constant, B is constant, and C is A * B
						if (left is Division && (left as Division).Right is Constant && right is Constant)
						{
							var A = (left as Division).Right as Constant;
							var B = right as Constant;
							var C = Compute<T>.Multiply(A, B);
							var X = (left as Division).Left;
							return new Division(X, C);
						}
						// Rule: [(A / X) / B] => [C / X] where A is constant, B is constant, and C is A / B
						if (left is Division && (left as Division).Left is Constant && right is Constant)
						{
							var A = (left as Division).Left as Constant;
							var B = right as Constant;
							var C = Compute<T>.Divide(A, B);
							var X = (left as Division).Right;
							return new Division(C, X);
						}
						// Rule: [B / (X / A)] => [C / X] where A is constant, B is constant, and C is B / A
						if (right is Division && (right as Division).Right is Constant && left is Constant)
						{
							var A = (right as Division).Right as Constant;
							var B = left as Constant;
							var C = Compute<T>.Divide(B, A);
							var X = (left as Division).Left;
							return new Division(X, C);
						}
						// Rule: [B / (A / X)] => [C / X] where A is constant, B is constant, and C is B / A
						if (right is Division && (right as Division).Left is Constant && left is Constant)
						{
							var A = (right as Division).Left as Constant;
							var B = left as Constant;
							var C = Compute<T>.Divide(B, A);
							var X = (right as Division).Right;
							return new Division(C, X);
						}
						// Rule: [(X * A) / B] => [X * C] where A is constant, B is constant, and C is A / B
						if (left is Multiplication && (left as Multiplication).Right is Constant && right is Constant)
						{
							var A = (left as Multiplication).Right as Constant;
							var B = right as Constant;
							var C = Compute<T>.Divide(A, B);
							var X = (right as Multiplication).Left;
							return new Multiplication(X, C);
						}
						// Rule: [(A * X) / B] => [X * C] where A is constant, B is constant, and C is A / B
						if (left is Multiplication && (left as Multiplication).Left is Constant && right is Constant)
						{
							var A = (left as Multiplication).Left as Constant;
							var B = right as Constant;
							var C = Compute<T>.Divide(A, B);
							var X = (left as Multiplication).Right;
							return new Multiplication(X, C);
						}
						// Rule: [B / (X * A)] => [C / X] where A is constant, B is constant, and C is A * B
						if (right is Multiplication && (right as Multiplication).Right is Constant && left is Constant)
						{
							var A = (right as Multiplication).Right as Constant;
							var B = left as Constant;
							var C = Compute<T>.Multiply(A, B);
							var X = (right as Multiplication).Left;
							return new Division(C, X);
						}
						// Rule: [B / (A * X)] => [X * C] where A is constant, B is constant, and C is B / A
						if (right is Multiplication && (right as Multiplication).Left is Constant && left is Constant)
						{
							var A = (right as Multiplication).Left as Constant;
							var B = left as Constant;
							var C = Compute<T>.Divide(B, A);
							var X = (right as Multiplication).Right;
							return new Multiplication(X, C);
						}
						#endregion
					}
					#endregion
					#region Power
					if (node is Power)
					{
						#region Computation
						// Rule: [A ^ B] => [C] where A is constant, B is constant, and C is A ^ B
						if (left is Constant && right is Constant)
						{
							var A = left as Constant;
							var B = right as Constant;
							var C = Compute<T>.Power(A, B);
							return new Constant(Compute<T>.Power((left as Constant).Value, (right as Constant).Value));
						}
						#endregion
						#region Zero Base
						// Rule: [0 ^ X] => [0]
						if (left is Constant && Compute<T>.Equate((left as Constant).Value, Compute<T>.Zero))
						{
							return Compute<T>.Zero;
						}
						#endregion
						#region One Power
						// Rule: [X ^ 1] => [X]
						if (right is Constant && Compute<T>.Equate((right as Constant).Value, Compute<T>.One))
						{
							var A = left;
							return A;
						}
						#endregion
						#region Zero Power
						// Rule: [X ^ 0] => [1]
						if (right is Constant && Compute<T>.Equate(right as Constant, Compute<T>.Zero))
						{
							return new Constant(Compute<T>.One);
						}
						#endregion
					}
					#endregion

					return Activator.CreateInstance(
						node.GetType(),
						new object[]
						{ 
							left,
							right,
						}) as Node;
				}
				#endregion
				#region Ternary
				else if (node is Ternary)
				{
					Ternary ternary = node as Ternary;
					Node one = Simplify(ternary.One);
					Node two = Simplify(ternary.Two);
					Node three = Simplify(ternary.Three);


					return Activator.CreateInstance(
						node.GetType(),
						new object[]
						{ 
							one,
							two,
							three
						}) as Node;
				}
				#endregion
				#region Multinary
				else if (node is Multinary)
				{
					Multinary multinary = node as Multinary;
					Node[] operands = new Node[multinary.Operands.Length];
					for (int i = 0; i < operands.Length; i++)
						operands[i] = Simplify(multinary.Operands[i]);

				}
				#endregion
			}
			#endregion
			throw new System.NotImplementedException();
		}

		#endregion

		#region Assign

		public static Node Assign(Node node, string variable, T value)
		{
			#region Constant
			if (node is Constant)
			{
				return new Constant((node as Constant).Value);
			}
			#endregion
			#region Variable
			else if (node is Variable)
			{
				if ((node as Variable).Name.CompareTo(variable) == 0)
					return new Constant(value);
				return new Variable((node as Variable)._name);
			}
			#endregion
			#region Operation
			else if (node is Operation)
			{
				#region Unary
				if (node is Unary)
				{
					return Activator.CreateInstance(
						node.GetType(), 
						new object[]
						{ 
							Assign((node as Unary).Operand, variable, value)
						}) as Node;
				}
				#endregion
				#region Binary
				else if (node is Binary)
				{
					return Activator.CreateInstance(
						node.GetType(),
						new object[]
						{ 
							Assign((node as Binary).Left, variable, value),
							Assign((node as Binary).Right, variable, value),
						}) as Node;
				}
				#endregion
				#region Ternary
				else if (node is Ternary)
				{
					return Activator.CreateInstance(
						node.GetType(),
						new object[]
						{ 
							Assign((node as Ternary).One, variable, value),
							Assign((node as Ternary).Two, variable, value),
							Assign((node as Ternary).Three, variable, value),
						}) as Node;
				}
				#endregion
				#region Multinary
				else if (node is Multinary)
				{
					throw new System.NotImplementedException();
				}
				#endregion
			}
			#endregion
			throw new System.NotImplementedException();
		}

		#endregion

		#region Derive

		public static Node Derive(Node node, string variable)
		{
			throw new System.NotImplementedException();
		}

		#endregion

		#region Integrate

		public static Node Integrate(Node node, string variable)
		{
			throw new System.NotImplementedException();
		}

		#endregion
	}
}
