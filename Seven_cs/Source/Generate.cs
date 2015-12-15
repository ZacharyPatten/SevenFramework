// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven
{
	/// <summary>Generates code and executabel code at runtime.</summary>
	public static class Generate
	{
		/// <summary>Generates a generic object at runtime.</summary>
		/// <typeparam name="T">The type of the generic object to create.</typeparam>
		/// <param name="code">The object to generate.</param>
		/// <param name="method">The name of the method to generate the object in.</param>
		/// <param name="_class">The name of the class to generate the object in.</param>
		/// <param name="_namespace">The name of the namespace to generate the object in.</param>
		/// <param name="name_spaces">The required namespaces.</param>
		/// <param name="_unsafe">Is unsafe code allowed?</param>
		/// <param name="references">The required assembly references.</param>
		/// <returns>The generated object.</returns>
		public static T ObjectInternal<T>(
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

		/// <summary>Generates a generic object at runtime.</summary>
		/// <typeparam name="T">The type of the generic object to create.</typeparam>
		/// <param name="code">The object to generate.</param>
		/// <returns>The generated object.</returns>
		internal static T Object<T>(string code)
		{
#if no_error_shecking
			// nothing
#else
			if (code == null)
				throw new Error("code == null");
#endif

			string type_string = Generate.TypeToCsharp(typeof(T));

			string full_code = string.Empty;

			full_code +=
				"using Seven;" +
				"using Seven.Structures;" +
				"using Seven.Mathematics;" +
				"namespace Seven.Generated {" +
				"public class Generator {" +
				"public static object Generate() { return (" + type_string + ")(" + code + "); } } }";

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
		public static string TypeToCsharp(System.Type type)
		{
#if no_error_shecking
			// nothing
#else
			if (type == null)
				throw new Error("type == null");
#endif
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
					text += TypeToCsharp(generics[i]);
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
					types_strings[i] = TypeToCsharp(generic_types[i]);
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
	}
}
