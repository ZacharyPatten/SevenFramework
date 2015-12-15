// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

#ifndef Structures_Array_h
#define Structures_Array_h

#include <string>
#include "..\Seven.h"

namespace Seven
{
	namespace Structures
	{
		/// <summary>Contiguous fixed-sized data structure.</summary>
		template <typename T>
		struct Array : Structure<T>
		{
			/// <summary>Allows indexed access of the array.</summary>
			/// <param name="index">The index of the array to set.</param>
			/// <returns>The value at the desired index.</returns>
			virtual T Get(int index) = 0;
			///<summary>Sets the value at a given index.</summary>
			/// <param name="index">The index of the array to set.</param>
			/// <param name="value">The value to set at the given index.</param>
			virtual void Set(int index, T value) = 0;
			/// <summary>The length of the array.</summary>
			virtual int Length() = 0;
		};

		/// <summary>Contiguous fixed-sized data structure.</summary>
		template<typename T>
		class Array_Array : public Array<T>
		{
		private:
			T* _array;
			int _length;
		public:
			/// <summary>Constructs a new instance of an Arra_Array.</summary>
			Array_Array(int length)
			{
				_array = new T[length];
				_length = length;
			}
			/// <summary>Destructs an instance of an Arra_Array.</summary>
			~Array_Array()
			{
				delete this->_array;
			}
			/// <summary>The length of the array.</summary>
			T& operator[](int index)
			{
				if (index >= this->_length || index < 0)
					throw new Error(new std::string("Index out of bounds."));
				return this->_array[index];
			}
			/// <summary>The length of the array.</summary>
			int Length() override
			{
				return this->_length;
			}
			/// <summary>Allows indexed access of the array.</summary>
			T Get(int index) override
			{
				if (index >= this->_length || index < 0)
					throw new Error(new std::string("Index out of bounds."));
				return this->_array[index];
			}
			/// <summary>Sets the value at a given index..</summary>
			void Set(int index, T value) override
			{
				if (index >= this->_length || index < 0)
					throw new Error(new std::string("Index out of bounds."));
				this->_array[index] = value;
			}
			/// <summary>Invokes a delegate for each entry in the data structure.</summary>
			/// <param name="step">The delegate to invoke on each item in the structure.</param>
			void Stepper(Step<T> step) override
			{
				for (int i = 0; i < this->_length; i++)
					step(this->_array[i]);
			}
			///// <summary>Invokes a delegate for each entry in the data structure.</summary>
			///// <param name="step_delegate">The delegate to invoke on each item in the structure.</param>
			///// <returns>The resulting status of the iteration.</returns>
			//StepStatus Stepper(StepBreak<T> step) override
			//{
			//	throw new Error(new std::string("Not Implemented."));
			//	//for (int i = 0; i < this->_length; i++)
			//	//	step(this->_array[index]);
			//}
		};

		/// <summary>Contiguous fixed-sized data structure.</summary>
		template<typename T, int length>
		class Array_Fixed : public Array<T>
		{
		private:
			T* _array;
		public:
			/// <summary>Constructs a new instance of an Arra_Array.</summary>
			Array_Fixed()
			{
				_array = new T[length];
			}
			/// <summary>Destructs an instance of an Arra_Array.</summary>
			~Array_Fixed()
			{
				delete this->_array;
			}
			/// <summary>The length of the array.</summary>
			T& operator[](int index)
			{
				if (index >= length || index < 0)
					throw new Error(new std::string("Index out of bounds."));
				return this->_array[index];
			}
			/// <summary>The length of the array.</summary>
			int Length() override
			{
				return length;
			}
			/// <summary>Allows indexed access of the array.</summary>
			T Get(int index) override
			{
				if (index >= length || index < 0)
					throw new Error(new std::string("Index out of bounds."));
				return this->_array[index];
			}
			/// <summary>Sets the value at a given index..</summary>
			void Set(int index, T value) override
			{
				if (index >= length || index < 0)
					throw new Error(new std::string("Index out of bounds."));
				this->_array[index] = value;
			}
			/// <summary>Invokes a delegate for each entry in the data structure.</summary>
			/// <param name="step">The delegate to invoke on each item in the structure.</param>
			void Stepper(Step<T> step) override
			{
				for (int i = 0; i < length; i++)
					step(this->_array[i]);
			}
			///// <summary>Invokes a delegate for each entry in the data structure.</summary>
			///// <param name="step_delegate">The delegate to invoke on each item in the structure.</param>
			///// <returns>The resulting status of the iteration.</returns>
			//StepStatus Stepper(StepBreak<T> step) override
			//{
			//	throw new Error(new std::string("Not Implemented."));
			//	//for (int i = 0; i < this->_length; i++)
			//	//	step(this->_array[index]);
			//}
		};
	}
}

#endif