// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

#ifndef Structures_Structure_H
#define Structures_Structure_H

#include "..\Seven.h"

namespace Seven
{
	namespace Structures
	{
		/// <summary>Polymorphism base for all data structures in the Seven framework.</summary>
		template <typename T>
		struct Structure
		{
		public:

			/// <summary>Invokes a delegate for each entry in the data structure.</summary>
			/// <param name="step">The delegate to invoke on each item in the structure.</param>
			virtual void Stepper(Step<T> step) = 0;
			/// <summary>Invokes a delegate for each entry in the data structure.</summary>
			/// <param name="step">The delegate to invoke on each item in the structure.</param>
			/// <returns>The resulting status of the iteration.</returns>
			//virtual StepStatus Stepper(StepBreak<T> step) = 0;

			/// <summary>Checks to see if a given object is in this data structure.</summary>
			/// <param name="check">The item to check for.</param>
			/// <param name="equate">Delegate for equating two instances of the same type.</param>
			/// <returns>true if the item is in this structure; false if not.</returns>
			bool Contains(T check, Equate<T> equate)
			{
				bool contains = false;
				this->Stepper((T step) = >
				{
					if (equate(step, check))
					{
						contains = true;
						return StepStatus.Break;
					}
					return StepStatus.Continue;
				});
				return contains;
			}

			/// <summary>Checks to see if a given object is in this data structure.</summary>
			/// <param name="key">The key to check for.</param>
			/// <param name="equate">Delegate for equating two instances of different types.</param>
			/// <returns>true if the item is in this structure; false if not.</returns>
			template <typename K>
			bool Contains(K key, Equate<T, K> equate)
			{
				bool contains = false;
				this->Stepper((T step) = >
				{
					if (equate(step, key))
					{
						contains = true;
						return StepStatus.Break;
					}
					return StepStatus.Continue;
				});
				return contains;
			}

			/// <summary>Looks up an item this structure by a given key.</summary>
			/// <param name="key">The key to look up.</param>
			/// <param name="equate">Delegate for equating two instances of different types.</param>
			/// <returns>The item with the corresponding to the given key.</returns>
			template <typename K>
			static T Get(K key, Equate<T, K> equate)
			{
				bool contains = false;
				T item = default(T);
				this->Stepper((T step) = >
				{
					if (equate(step, key))
					{
						contains = true;
						item = step;
						return StepStatus.Break;
					}
					return StepStatus.Continue;
				});
				if (contains == false)
					throw new Error("item not found in structure");
				return item;
			}

			/// <summary>Trys to look up an item this structure by a given key.</summary>
			/// <param name="key">The key to look up.</param>
			/// <param name="equate">Delegate for equating two instances of different types.</param>
			/// <param name="item">The item if it was found or null if not the default(Type) value.</param>
			/// <returns>true if the key was found; false if the key was not found.</returns>
			template <typename K>
			static bool TryGet(K key, Equate<T, K> equate, T* item)
			{
				bool contains = false;
				T* temp = NULL;
				this->Stepper((T step) = >
				{
					if (equate(step, key))
					{
						contains = true;
						temp = &step;
						return StepStatus.Break;
					}
					return StepStatus.Continue;
				});
				item = temp;
				return contains;
			}
		};
	}
}

#endif
