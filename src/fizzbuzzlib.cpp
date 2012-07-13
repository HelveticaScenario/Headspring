//
//  fizzbuzzlib.cpp
//  FizzBuzzLib
//
//  Created by Daniel Lewis on 7/12/12.
//  Copyright (c) 2012 __MyCompanyName__. All rights reserved.
//
//This program prints to the console the numbers 1 through
//100, with the exception of those numbers evenly divisible
//by 3, 5, or both 3 and 5, for which it prints the words
//"Fizz", "Buzz", or "FizzBuzz" respectively.
//
#include <cstdio>
#include <iostream>
#include <string>
#include <fstream>
#include "fizzbuzzlib.h"
using namespace std;

/*
void bubbleSortArray(int arr[], int SIZE)
{
	int i, tmp;
	for (i = 0; i < SIZE; i++)
	{
		if((i < SIZE - 1) && (arr[i] > arr[i + 1]))
		{
			tmp = arr[i];
			arr[i] = arr[i + 1];
			arr[i + 1] = tmp;
			i = -1;
		}
	}		
}
*/


void fizzBuzzPrintf(signed int min = 1, 
              signed int max = 100, 
              char *five = "Buzz", 
              char *three = "Fizz", 
              char *both = "FizzBuzz"){
	
	for (int i = min; i <= max; ++i)
	{
		if (i % 3 == 0)
		{
			if (i % 5 == 0)
			{
				printf("%s\n", both);
				continue;
			}
			printf("%s\n", three);
			continue;
		}
		if (i % 5 == 0)
		{
			printf("%s\n", five);
			continue;
		}
		printf("%d\n", i);
		continue;
	}
    
}

void fizzBuzzStreams(ostream &os, 
					signed int min = 1, 
					signed int max = 100,
					string three = "Fizz", 
					string five = "Buzz",
					string both = "FizzBuzz"){	
	//filebuf fb;
	//extern streambuf *fbs;
	//ostream os(streambuf fb);
	for (int i = min; i <= max; ++i)
	{
		if (i % 3 == 0)
		{
			if (i % 5 == 0)
			{
				os << both << endl;
				continue;
			}
				os << three << endl;
			continue;
		}
		if (i % 5 == 0)
		{
				os << five << endl;
			continue;
		}
		printf("%d\n", i);
		continue;
	}
	return;
}



