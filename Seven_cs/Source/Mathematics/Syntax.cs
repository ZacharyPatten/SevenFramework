// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

using Seven.Structures;
using System.Linq;

namespace Seven.Mathematics
{
	/// <summary>Contains syntax definitions for the Seven.Mathematics language.</summary>
	/// <typeparam name="T"></typeparam>
	public static class Syntax<T>
	{
		#region parse Seven.Mathematics syntax tree

		/// <summary>Parses a Seven.Mathematics syntax tree represented as a string.</summary>
		/// <param name="tree"></param>
		/// <returns></returns>
		private static node Parse(string tree)
		{
			// constant node: "7", "7.7", or ".7"
			if (char.IsDigit(tree[0]) || tree[0] == '.')
			{

				#region error checking
#if no_error_checking
				// nothing
#else
				bool comma = false;
				for (int i = 0; i < tree.Length; i++)
					if (char.IsDigit(tree[i]))
						continue;
					else if (tree[i] == '.' && !comma)
						comma = true;
					else
						throw new Error("mathematics parsing error");
#endif
				#endregion

				throw new Error("mathematics parsing error");
			}
			// variable node: "[variable]"
			else if (tree[0] == '[')
			{
				
				#region error checking
#if no_error_checking
					//nothing
#else
				if (tree[tree.Length - 1] != ']')
					throw new Error("mathematics parsing error");
#endif
				#endregion

				string variable = tree.Substring(1, tree.Length - 2);
				return new node.variable(variable);
			}
			// operation node: "token(argument[0], argument[1], ...)"
			else
			{

				#region error checking
#if no_error_checking
					//nothing
#else
				if (tree[tree.Length - 1] != ')')
					throw new Error("mathematics parsing error");
#endif
				#endregion

				// get the token
				string token = tree.Substring(0, tree.IndexOf('('));

				// get the substring of arguments
				int arguments_start = token.Length + 2;
				int arguments_length = (tree.Length - 1) - arguments_start;
				string list = tree.Substring(arguments_start, arguments_length);

				// count the number of arguments
				int scope = 0;
				int argument = 0;
				for (int b = 0; b < list.Length; b++)
					switch (list[b])
					{
						case '(':
							scope++;
							break;
						case ')':
							scope--;
							break;
						case ',':
							if (scope == 0)
								argument++;
							break;
					}

				// get the arguments
				string[] arguments = new string[argument];
				argument = 0;
				scope = 0;
				int a = 0;
				for (int b = 0; b < list.Length; b++)
					switch (list[b])
					{
						case '(':
							scope++;
							break;
						case ')':
							scope--;
							break;
						case ',':
							if (scope == 0)
							{
								arguments[argument] = list.Substring(a, b - a);
								a = b + 1;
								argument++;
							}
							break;
					}

				// recursive calls
				node[] nodes = new node[arguments.Length];
				for (int i = 0; i < nodes.Length; i++)
					nodes[i] = Parse(arguments[i]);

				// node creation
				switch (token)
				{

					case "add":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 2)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.binary.add(nodes[0], nodes[1]);

					case "subtract":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 2)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.binary.subtract(nodes[0], nodes[1]);

					case "multiply":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 2)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.binary.multiply(nodes[0], nodes[1]);

					case "divide":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 2)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.binary.divide(nodes[0], nodes[1]);

					case "power":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 2)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.binary.power(nodes[0], nodes[1]);

					case "negate":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 1)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.unary.negate(nodes[0]);

					case "sin":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 1)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.unary.sin(nodes[0]);

					case "cos":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 1)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.unary.cos(nodes[0]);

					case "tan":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 1)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.unary.tan(nodes[0]);

					case "csc":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 1)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.unary.csc(nodes[0]);

					case "sec":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 1)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.unary.sec(nodes[0]);

					case "cot":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 1)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.unary.cot(nodes[0]);

					case "arcsin":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 1)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.unary.arcsin(nodes[0]);

					case "arccos":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 1)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.unary.arccos(nodes[0]);

					case "arctan":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 1)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.unary.arctan(nodes[0]);

					case "arccsc":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 1)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.unary.arccsc(nodes[0]);

					case "arcsec":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 1)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.unary.arcsec(nodes[0]);

					case "arccot":
						#region error checking
#if no_error_checking
					//nothing
#else
						if (nodes.Length != 1)
							throw new Error("mathematics parsing error");
#endif
						#endregion
						return new node.operations.unary.arccot(nodes[0]);

					case "equate":
						return new node.operations.multinary.equate(nodes);

					case "less":
						return new node.operations.multinary.equate(nodes);

					//case "derive":
					//	return;
					//case "integrate":
					//	return;
					//case "integrate":
					//	return;

					default:
						throw new Error("mathematics parsing error");

				}
			}
		}

		#endregion

		#region syntax definition tree

		public abstract class node
		{
			//public interface evaluation<T> : node
			//{
			//	T Evaluate();
			//}

			public class constant : node
			{
				T _constant;

				public constant(T constant)
				{
					this._constant = constant;
				}
			}

			public class variable : node
			{
				string _variable;

				public variable(string variable)
				{
					this._variable = variable;
				}
			}

			public abstract class operations : node
			{
				public abstract class unary : operations
				{
					node _operand;

					public unary(node operand)
					{
						this._operand = operand;
					}

					public class negate : unary
					{
						public negate(node operand) : base(operand) { }
					}

					public class sin : unary
					{
						public sin(node operand) : base(operand) { }
					}

					public class cos : unary
					{
						public cos(node operand) : base(operand) { }
					}

					public class tan : unary
					{
						public tan(node operand) : base(operand) { }
					}

					public class csc : unary
					{
						public csc(node operand) : base(operand) { }
					}

					public class sec : unary
					{
						public sec(node operand) : base(operand) { }
					}

					public class cot : unary
					{
						public cot(node operand) : base(operand) { }
					}

					public class arcsin : unary
					{
						public arcsin(node operand) : base(operand) { }
					}

					public class arccos : unary
					{
						public arccos(node operand) : base(operand) { }
					}

					public class arctan : unary
					{
						public arctan(node operand) : base(operand) { }
					}

					public class arccsc : unary
					{
						public arccsc(node operand) : base(operand) { }
					}

					public class arcsec : unary
					{
						public arcsec(node operand) : base(operand) { }
					}

					public class arccot : unary
					{
						public arccot(node operand) : base(operand) { }
					}
					
					public class ln : unary
					{
						public ln(node operand) : base(operand) { }
					}

					public class sqrt : unary
					{
						public sqrt(node operand) : base(operand) { }
					}

					public class exp : unary
					{
						public exp(node operand) : base(operand) { }
					}

					public class invert : unary
					{
						public invert(node operand) : base(operand) { }
					}

					public class determinent : unary
					{
						public determinent(node operand) : base(operand) { }
					}

					public class derive : unary
					{
						public derive(node _operand) : base(_operand) { }
					}
				}

				public abstract class binary : operations
				{
					node _left;
					node _right;

					public binary(node left, node right)
					{
						this._left = left;
						this._right = right;
					}

					public class add : binary
					{
						public add(node left, node right) : base(left, right) { }
					}

					public class subtract : binary
					{
						public subtract(node left, node right) : base(left, right) { }
					}

					public class multiply : binary
					{
						public multiply(node left, node right) : base(left, right) { }
					}

					public class divide : binary
					{
						public divide(node left, node right) : base(left, right) { }
					}

					public class power : binary
					{
						public power(node left, node right) : base(left, right) { }
					}
				}

				public abstract class ternary : operations
				{
					node _one;
					node _two;
					node _three;

					public ternary(node one, node two, node three)
					{
						this._one = one;
						this._two = two;
						this._three = three;
					}
				}

				public abstract class multinary : operations
				{
					node[] _array;

					public multinary(node[] array)
					{
						this._array = array;
					}

					public class summation : multinary
					{
						public summation(node[] array) : base(array) { }
					}

					public class equate : multinary
					{
						public equate(node[] array) : base(array) { }
					}
				}
			}
		}

		#endregion
	}
}
