// DataStructures.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

// just include "Seven.h"
#include "..\..\..\Seven_cpp\Source\Seven.h"
using namespace Seven;
using namespace Seven::Structures;


int _tmain(int argc, _TCHAR* argv[])
{
	#define test 10

	std::cout << "Welcome To SevenFramework (C++)! :)";
	std::cout << std::endl;
	std::cout << "You are runnning the Data-Structures example.";
	std::cout << std::endl;
	std::cout << "======================================================";
	std::cout << std::endl;
	std::cout << std::endl;

	#pragma region Link



	#pragma endregion

	#pragma region Array

	std::cout << "	Testing Array_Array<int>-------------------";
	Array<int>* array_array = new Array_Array<int>(test);
	for (int i = 0; i < test; i++)
		array_array->Set(i, i);
	std::cout << std::endl;
	std::cout << "		Step: ";
	array_array->Stepper([](int current) { std::cout << current; });
	std::cout << std::endl;
	std::cout << std::endl;

	std::cout << "	Testing Array_Fixed<int, " << test << ">---------------";
	Array<int>* array_fixed = new Array_Fixed<int, test>();
	for (int i = 0; i < test; i++)
		array_fixed->Set(i, i);
	std::cout << std::endl;
	std::cout << "		Step: ";
	array_fixed->Stepper([](int current) { std::cout << current; });
	std::cout << std::endl;

	#pragma endregion

	std::cout << std::endl;
	std::cout << "============================================";
	std::cout << std::endl;
	std::cout << "Example Complete...";
	getchar();

	return 0;
}

