//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Seven.Logic
//{
//	public class Logic<T>
//	{
//		public const string material_implication = "⇒";
//		public const string double_material_implication = "⇔";
//		public const string negation = "¬";
//		public const string logical_conjunction = "∧";
//		public const string inclusive_logical_disjunction = "∨";
//		public const string exclusive_disjunction = "⊕";
//		public const string tautology = "⊤";
//		public const string contradiction = "⊥";
//		public const string universal_quantification = "∀";
//		public const string existential_quantification = "∃";
//		public const string uniqueness_quantification = "∃!";
//		public const string definition = ":=";
//		public const string precedence_grouping_preceding = "(";
//		public const string precedence_grouping_proceeding = "(";
//		public const string turnstile = "⊢";
//		public const string double_turnstile = "⊨";
//		public const string negated_logical_conjunction = "⊼";
//		public const string negated_inclusive_logical_disjunction = "⊽";

//		public class material_implication
//		{
//			T _left;
//			T _right;

//			public T Left { get { return this._left; } }
//			public T Right { get { return this._right; } }

//			private material_implication(T left, T right)
//			{
//				this._left = left;
//				this._right = right;
//			}
//		}

//		public class double_material_implication
//		{
//			T _left;
//			T _right;

//			public T Left { get { return this._left; } }
//			public T Right { get { return this._right; } }

//			private double_material_implication(T left, T right)
//			{
//				this._left = left;
//				this._right = right;
//			}
//		}

//		public class negation
//		{
//			T _operand;

//			public T Left { get { return this._operand; } }

//			private negation(T operand)
//			{
//				this._operand = operand;
//			}
//		}

//		public class logical_conjunction
//		{
//			T _left;
//			T _right;

//			public T Left { get { return this._left; } }
//			public T Right { get { return this._right; } }

//			private logical_conjunction(T left, T right)
//			{
//				this._left = left;
//				this._right = right;
//			}
//		}

//		public class inclusive_logical_disjunction
//		{
//			T _left;
//			T _right;

//			public T Left { get { return this._left; } }
//			public T Right { get { return this._right; } }

//			private inclusive_logical_disjunction(T left, T right)
//			{
//				this._left = left;
//				this._right = right;
//			}
//		}

//		public class exclusive_disjunction
//		{
//			T _left;
//			T _right;

//			public T Left { get { return this._left; } }
//			public T Right { get { return this._right; } }

//			private exclusive_disjunction(T left, T right)
//			{
//				this._left = left;
//				this._right = right;
//			}
//		}

//		public class tautology
//		{
//			T _left;

//			public T Left { get { return this._left; } }

//			private tautology(T left, T right)
//			{
//				this._left = left;
//			}
//		}

//		public class contradiction
//		{
//			T _left;

//			public T Left { get { return this._left; } }

//			private contradiction(T left, T right)
//			{
//				this._left = left;
//			}
//		}

//		public class universal_quantification
//		{

//		}

//		public class existential_quantification
//		{
//		}

//		public class uniqueness_quantification
//		{
//		}

//		public class definition
//		{
//		}

//		public class precedence_grouping_preceding
//		{
//		}

//		public class precedence_grouping_proceeding
//		{
//		}

//		public class turnstile
//		{
//		}

//		public class double_turnstile
//		{
//		}

//		public class negated_logical_conjunction
//		{
//		}

//		public class negated_inclusive_logical_disjunction
//		{
//		}

//	}
//}
