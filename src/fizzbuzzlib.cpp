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
#include <sstream>
#include <fstream>
#include "fizzbuzzlib.h"
using namespace std;

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

void fizzBuzzStreams(ostream& os,
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
		else if (i % 5 == 0)
		{
				os << five << endl;
			continue;
		}
		else{
			os << i << endl;
			continue;
		}
	}
	return;
}


string fizzBuzzString(int value,
					string three = "Fizz", 
					string five = "Buzz",
					string both = "FizzBuzz"){	
	if (value % 3 == 0){
		if (value % 5 == 0){
			return both+"\n";
		}
		return three+"\n";
	}
	else if (value % 5 == 0){
		return five+"\n";
	}
	ostringstream toString;
	toString << value << endl;
	return toString.str();
}



