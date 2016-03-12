// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

using System; // needed for the reflection extension methods

namespace Seven
{
	/// <summary>Generates code and executabel code at runtime.</summary>
	public static class Meta
	{
		/// <summary>Generates a generic object at runtime (typically delegates).</summary>
		/// <typeparam name="T">The type of the generic object to create.</typeparam>
		/// <param name="code">The object to generate.</param>
		/// <param name="method">The name of the method to generate the object in.</param>
		/// <param name="_class">The name of the class to generate the object in.</param>
		/// <param name="_namespace">The name of the namespace to generate the object in.</param>
		/// <param name="name_spaces">The required namespaces.</param>
		/// <param name="_unsafe">Is unsafe code allowed?</param>
		/// <param name="references">The required assembly references.</param>
		/// <returns>The generated object.</returns>
		public static T Compile<T>(
			string code, string method, string _class, string _namespace, bool _unsafe, string[] name_spaces, string[] references)
		{
#if no_error_shecking
			// nothing
#else
			if (code == null)
				throw new Error("code == null");
			if (method == null)
				throw new Error("method == null");
			if (_class == null)
				throw new Error("_class == null");
			if (_namespace == null)
				throw new Error("_namespace == null");
#endif

			string full_code = string.Empty;

			if (name_spaces != null)
				for (int i = 0; i < name_spaces.Length; i++)
					full_code += "using " + name_spaces[i] + ";";

			full_code += "namespace " + _namespace + " {";
			full_code += "public class " + _class + " {";
			full_code += "public static object " + method + "() { return " + code + "; } } }";

			System.CodeDom.Compiler.CompilerParameters parameters = 
					new System.CodeDom.Compiler.CompilerParameters();

			if (references != null)
				foreach (string reference in references)
					parameters.ReferencedAssemblies.Add(reference);
			
			parameters.GenerateInMemory = true;

			if (_unsafe)
				parameters.CompilerOptions = "/optimize /unsafe";

			System.CodeDom.Compiler.CompilerResults results = 
					new Microsoft.CSharp.CSharpCodeProvider().CompileAssemblyFromSource(parameters, full_code);

			if (results.Errors.HasErrors)
			{
				string error = string.Empty;

				foreach (System.CodeDom.Compiler.CompilerError compiler_error in results.Errors)
					error += compiler_error.ErrorText.ToString() + "\n";

				throw new Error(error);
			}

			System.Reflection.MethodInfo generate =
					results.CompiledAssembly.GetType(_namespace + "." + _class).GetMethod(method);

			return (T)generate.Invoke(null, null);
		}

		/// <summary>Generates a generic object at runtime (typically delegates).</summary>
		/// <typeparam name="T">The type of the generic object to create.</typeparam>
		/// <param name="code">The object to generate.</param>
		/// <returns>The generated object.</returns>
		public static T Compile<T>(string code)
		{
#if no_error_shecking
			// nothing
#else
			if (code == null)
				throw new Error("code == null");
#endif

			string type_string = Meta.ConvertTypeToCsharpSource(typeof(T));

			string full_code = 
				string.Concat(
@"using Seven;
using Seven.Structures;
using Seven.Mathematics;
namespace Seven.Generated
{
	public class Generator
	{
		public static object Generate()
		{
			return (", type_string, ")(", code, @");
		}
	}
}");

			System.CodeDom.Compiler.CompilerParameters parameters =
					new System.CodeDom.Compiler.CompilerParameters();

			parameters.ReferencedAssemblies.Add("Seven.dll");

			parameters.GenerateInMemory = true;

			parameters.CompilerOptions = "/optimize";

#if unsafe_code
				parameters.CompilerOptions = "/unsafe";
#endif

			System.CodeDom.Compiler.CompilerResults results =
					new Microsoft.CSharp.CSharpCodeProvider().CompileAssemblyFromSource(parameters, full_code);

			if (results.Errors.HasErrors)
			{
				string error = "Generation Error\nType: " + type_string + "\nObject: " + code + "\n\nCompilation Error:";

				Exception[] exceptions = new Exception[results.Errors.Count];
				foreach (System.CodeDom.Compiler.CompilerError compiler_error in results.Errors)
					error += compiler_error.ErrorText.ToString() + "\n";

				throw new Error(error);
			}

			System.Reflection.MethodInfo generate =
					results.CompiledAssembly.GetType("Seven.Generated.Generator").GetMethod("Generate");

			return (T)generate.Invoke(null, null);
		}

		/// <summary>Converts a "System.Type" into a string as it would appear in C# source code.</summary>
		/// <param name="type">The "System.Type" to convert to a string.</param>
		/// <returns>The string as the "System.Type" would appear in C# source code.</returns>
		public static string ConvertTypeToCsharpSource(System.Type type)
		{
			if (type == null)
				throw new Error("type == null");
			// no generics
			if (!type.IsGenericType)
				return type.ToString();
			// non-nested generics
			else if (!(type.IsNested && type.DeclaringType.IsGenericType))
			{
				// non-generic initial parents
				string text = type.ToString();
				text = text.Substring(0, text.IndexOf('`')) + "<";
				text = text.Replace('+', '.');
				// generic string arguments
				System.Type[] generics = type.GetGenericArguments();
				for (int i = 0; i < generics.Length; i++)
				{
					if (i > 0)
						text += ", ";
					text += Meta.ConvertTypeToCsharpSource(generics[i]);
				}
				return text + ">";
			}
			// nested generics
			else
			{
				string text = string.Empty;
				// non-generic initial parents
				for (System.Type temp = type; temp != null; temp = temp.DeclaringType)
					if (!temp.IsGenericType)
					{
						text += temp.ToString() + '.';
						break;
					}
				// count generic parents
				int parent_count = 0;
				for (System.Type temp = type; temp != null && temp.IsGenericType; temp = temp.DeclaringType)
					parent_count++;
				// generic parents types
				System.Type[] parents = new System.Type[parent_count];
				System.Type _temp = type;
				for (int i = 0; _temp != null && _temp.IsGenericType; _temp = _temp.DeclaringType, i++)
					parents[i] = _temp;
				// count generic arguments per parent
				int[] generics_per_parent = new int[parent_count];
				for (int i = 0; i < parents.Length; i++)
					generics_per_parent[i] = parents[i].GetGenericArguments().Length;
				for (int i = parents.Length - 1, sum = 0; i > -1; i--)
				{
					generics_per_parent[i] -= sum;
					sum += generics_per_parent[i];
				}
				// generic string arguments
				System.Type[] generic_types = type.GetGenericArguments();
				string[] types_strings = new string[generic_types.Length];
				for (int i = 0; i < generic_types.Length; i++)
					types_strings[i] = ConvertTypeToCsharpSource(generic_types[i]);
				// combine types and generic arguments into result
				for (int i = parents.Length - 1, k = 0; i > -1; i--)
				{
					if (generics_per_parent[i] == 0)
					{
						text += parents[i].Name;
					}
					else
					{
						string current_type = parents[i].Name.Substring(0, parents[i].Name.IndexOf('`')) + '<';
						for (int j = 0; j < generics_per_parent[i]; j++)
						{
							current_type += types_strings[k++];
							if (j + 1 != generics_per_parent[i])
								current_type += ',';
						}
						current_type += ">";
						text += current_type;
					}
					if (i > 0)
						text += '.';
				}
				return text;
			}
		}

		public class Validate
		{
			public class Operator
			{
				/// <summary>Checks if an implicit cast exists from type A to type B.</summary>
				/// <param name="A">The parameter of the implicit cast to check for.</param>
				/// <param name="B">The return type of the implicit cast to check for.</param>
				/// <returns>True if the implicit cast exists. False if not.</returns>
				public static bool ImplicitCast(Type A, Type B)
				{
					System.Reflection.MethodInfo[] methods = A.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
					foreach (System.Reflection.MethodInfo method in methods)
					{
						if (method.Name != "op_Implicit")
						 continue;
						System.Reflection.ParameterInfo[] parameters = method.GetParameters();
						if (parameters.Length != 1 && parameters[0].ParameterType != A)
							continue;
						if (method.ReturnParameter.ParameterType != B)
							continue;
						if (!method.IsSpecialName)
							continue;
						return true;
					}
					return false;
				}

				/// <summary>Checks if an explicit cast exists from type A to type B.</summary>
				/// <param name="A">The parameter of the explicit cast to check for.</param>
				/// <param name="B">The return type of the explicit cast to check for.</param>
				/// <returns>True if the explicit cast exists. False if not.</returns>
				public static bool ExplicitCast(Type A, Type B)
				{
					if (A.IsPrimitive && !(A is bool) && B.IsPrimitive && !(B is bool))
						return true;

					System.Reflection.MethodInfo[] methods = A.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
					foreach (System.Reflection.MethodInfo method in methods)
					{
						if (method.Name != "op_Explicit")
							continue;
						System.Reflection.ParameterInfo[] parameters = method.GetParameters();
						if (parameters.Length != 1 && parameters[0].ParameterType != A)
							continue;
						if (method.ReturnParameter.ParameterType != B)
							continue;
						if (!method.IsSpecialName)
							continue;
						return true;
					}
					return false;
				}

				/// <summary>Checks for the existence of a valid binary operator described by the arguments.</summary>
				/// <param name="methodName">The name of the operator as a compiled method.</param>
				/// <param name="operandType">The expected type of the operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				private static bool Unary(string methodName, System.Type operandType, System.Type returnType)
				{
					var op_Addition = operandType.GetMethod(methodName, new Type[] { operandType });
					if (op_Addition == null) return false;
					if (op_Addition.ReturnParameter.ParameterType != returnType) return false;
					if (!op_Addition.IsSpecialName) return false;

					return true;
				}

				/// <summary>Checks for the existence of a valid unary negation operator described by the arguments.</summary>
				/// <param name="operandType">The expected type of the left hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool UnaryNegation(System.Type operandType, System.Type returnType)
				{
					return Unary("op_UnaryNegation", operandType, returnType);
				}

				/// <summary>Checks for the existence of a valid unary plus operator described by the arguments.</summary>
				/// <param name="operandType">The expected type of the left hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool UnaryPlus(System.Type operandType, System.Type returnType)
				{
					return Unary("op_UnaryPlus", operandType, returnType);
				}

				/// <summary>Checks for the existence of a valid logical not operator described by the arguments.</summary>
				/// <param name="operandType">The expected type of the left hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool LogicalNot(System.Type operandType, System.Type returnType)
				{
					return Unary("op_LogicalNot", operandType, returnType);
				}

				/// <summary>Checks for the existence of a valid ones complement operator described by the arguments.</summary>
				/// <param name="operandType">The expected type of the left hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool OnesComplement(System.Type operandType, System.Type returnType)
				{
					return Unary("op_OnesComplement", operandType, returnType);
				}

				/// <summary>Checks for the existence of a valid false operator described by the arguments.</summary>
				/// <param name="operandType">The expected type of the left hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool False(System.Type operandType, System.Type returnType)
				{
					return Unary("op_False", operandType, returnType);
				}

				/// <summary>Checks for the existence of a valid true operator described by the arguments.</summary>
				/// <param name="operandType">The expected type of the left hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool True(System.Type operandType, System.Type returnType)
				{
					return Unary("op_True", operandType, returnType);
				}

				/// <summary>Checks for the existence of a valid increment operator described by the arguments.</summary>
				/// <param name="operandType">The expected type of the left hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool Increment(System.Type operandType, System.Type returnType)
				{
					return Unary("op_Increment", operandType, returnType);
				}

				/// <summary>Checks for the existence of a valid decrement operator described by the arguments.</summary>
				/// <param name="operandType">The expected type of the left hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool Decrement(System.Type operandType, System.Type returnType)
				{
					return Unary("op_Decrement", operandType, returnType);
				}

				/// <summary>Checks for the existence of a valid binary operator described by the arguments.</summary>
				/// <param name="methodName">The name of the operator as a compiled method.</param>
				/// <param name="leftOperandType">The expected type of the left hand operand.</param>
				/// <param name="rightOperandType">The expected type of the right hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				private static bool Binary(string methodName, System.Type leftOperandType, System.Type rightOperandType, System.Type returnType)
				{
					// Primitives: Boolean, Byte, SByte, Int16, UInt16, Int32, UInt32, Int64, UInt64, IntPtr, UIntPtr, Char, Double, and Single.
					if (leftOperandType.IsPrimitive && rightOperandType.IsPrimitive && returnType.IsPrimitive)
						return true;
					var operation =
						leftOperandType.GetMethod(methodName, new Type[] { leftOperandType, rightOperandType })
						??
						rightOperandType.GetMethod(methodName, new Type[] { leftOperandType, rightOperandType });
					if (operation == null) return false;
					if (operation.ReturnParameter.ParameterType != returnType) return false;
					if (!operation.IsSpecialName) return false;
					return true;
				}

				/// <summary>Checks for the existence of a valid addition operator described by the arguments.</summary>
				/// <param name="leftOperandType">The expected type of the left hand operand.</param>
				/// <param name="rightOperandType">The expected type of the right hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool Addition(System.Type leftOperandType, System.Type rightOperandType, System.Type returnType)
				{
					return Binary("op_Addition", leftOperandType, rightOperandType, returnType);
				}

				/// <summary>Checks for the existence of a valid subtraction operator described by the arguments.</summary>
				/// <param name="leftOperandType">The expected type of the left hand operand.</param>
				/// <param name="rightOperandType">The expected type of the right hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool Subtraction(System.Type leftOperandType, System.Type rightOperandType, System.Type returnType)
				{
					return Binary("op_Subtraction", leftOperandType, rightOperandType, returnType);
				}

				/// <summary>Checks for the existence of a valid multiplication operator described by the arguments.</summary>
				/// <param name="leftOperandType">The expected type of the left hand operand.</param>
				/// <param name="rightOperandType">The expected type of the right hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool Multiplication(System.Type leftOperandType, System.Type rightOperandType, System.Type returnType)
				{
					return Binary("op_Multiply", leftOperandType, rightOperandType, returnType);
				}

				/// <summary>Checks for the existence of a valid division operator described by the arguments.</summary>
				/// <param name="leftOperandType">The expected type of the left hand operand.</param>
				/// <param name="rightOperandType">The expected type of the right hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool Division(System.Type leftOperandType, System.Type rightOperandType, System.Type returnType)
				{
					return Binary("op_Division", leftOperandType, rightOperandType, returnType);
				}

				/// <summary>Checks for the existence of a valid modulus operator described by the arguments.</summary>
				/// <param name="leftOperandType">The expected type of the left hand operand.</param>
				/// <param name="rightOperandType">The expected type of the right hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool Modulus(System.Type leftOperandType, System.Type rightOperandType, System.Type returnType)
				{
					return Binary("op_Modulus", leftOperandType, rightOperandType, returnType);
				}

				/// <summary>Checks for the existence of a valid equality operator described by the arguments.</summary>
				/// <param name="leftOperandType">The expected type of the left hand operand.</param>
				/// <param name="rightOperandType">The expected type of the right hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool Equality(System.Type leftOperandType, System.Type rightOperandType, System.Type returnType)
				{
					return Binary("op_Equality", leftOperandType, rightOperandType, returnType);
				}

				/// <summary>Checks for the existence of a valid inequality operator described by the arguments.</summary>
				/// <param name="leftOperandType">The expected type of the left hand operand.</param>
				/// <param name="rightOperandType">The expected type of the right hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool Inequality(System.Type leftOperandType, System.Type rightOperandType, System.Type returnType)
				{
					return Binary("op_Inequality", leftOperandType, rightOperandType, returnType);
				}

				/// <summary>Checks for the existence of a valid greater than operator described by the arguments.</summary>
				/// <param name="leftOperandType">The expected type of the left hand operand.</param>
				/// <param name="rightOperandType">The expected type of the right hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool GreaterThan(System.Type leftOperandType, System.Type rightOperandType, System.Type returnType)
				{
					return Binary("op_GreaterThan", leftOperandType, rightOperandType, returnType);
				}

				/// <summary>Checks for the existence of a valid less than operator described by the arguments.</summary>
				/// <param name="leftOperandType">The expected type of the left hand operand.</param>
				/// <param name="rightOperandType">The expected type of the right hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool LessThan(System.Type leftOperandType, System.Type rightOperandType, System.Type returnType)
				{
					return Binary("op_LessThan", leftOperandType, rightOperandType, returnType);
				}

				/// <summary>Checks for the existence of a valid greater than or equal operator described by the arguments.</summary>
				/// <param name="leftOperandType">The expected type of the left hand operand.</param>
				/// <param name="rightOperandType">The expected type of the right hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool GreaterThanOrEqual(System.Type leftOperandType, System.Type rightOperandType, System.Type returnType)
				{
					return Binary("op_GreaterThanOrEqual", leftOperandType, rightOperandType, returnType);
				}

				/// <summary>Checks for the existence of a valid less than or equal operator described by the arguments.</summary>
				/// <param name="leftOperandType">The expected type of the left hand operand.</param>
				/// <param name="rightOperandType">The expected type of the right hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool LessThanOrEqual(System.Type leftOperandType, System.Type rightOperandType, System.Type returnType)
				{
					return Binary("op_LessThanOrEqual", leftOperandType, rightOperandType, returnType);
				}

				/// <summary>Checks for the existence of a valid bitwise and operator described by the arguments.</summary>
				/// <param name="leftOperandType">The expected type of the left hand operand.</param>
				/// <param name="rightOperandType">The expected type of the right hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool BitwiseAnd(System.Type leftOperandType, System.Type rightOperandType, System.Type returnType)
				{
					return Binary("op_BitwiseAnd", leftOperandType, rightOperandType, returnType);
				}

				/// <summary>Checks for the existence of a valid bitwise or operator described by the arguments.</summary>
				/// <param name="leftOperandType">The expected type of the left hand operand.</param>
				/// <param name="rightOperandType">The expected type of the right hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool BitwiseOr(System.Type leftOperandType, System.Type rightOperandType, System.Type returnType)
				{
					return Binary("op_BitwiseOr", leftOperandType, rightOperandType, returnType);
				}

				/// <summary>Checks for the existence of a valid left shift operator described by the arguments.</summary>
				/// <param name="leftOperandType">The expected type of the left hand operand.</param>
				/// <param name="rightOperandType">The expected type of the right hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool LeftShift(System.Type leftOperandType, System.Type rightOperandType, System.Type returnType)
				{
					return Binary("op_LeftShift", leftOperandType, rightOperandType, returnType);
				}

				/// <summary>Checks for the existence of a valid right shift operator described by the arguments.</summary>
				/// <param name="leftOperandType">The expected type of the left hand operand.</param>
				/// <param name="rightOperandType">The expected type of the right hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool RightShift(System.Type leftOperandType, System.Type rightOperandType, System.Type returnType)
				{
					return Binary("op_RightShift", leftOperandType, rightOperandType, returnType);
				}

				/// <summary>Checks for the existence of a valid exclusive or operator described by the arguments.</summary>
				/// <param name="leftOperandType">The expected type of the left hand operand.</param>
				/// <param name="rightOperandType">The expected type of the right hand operand.</param>
				/// <param name="returnType">The expected return type.</param>
				/// <returns>True if the expected operator exists; False if not.</returns>
				public static bool ExclusiveOr(System.Type leftOperandType, System.Type rightOperandType, System.Type returnType)
				{
					return Binary("op_ExclusiveOr", leftOperandType, rightOperandType, returnType);
				}
			}
		}
	}
}
