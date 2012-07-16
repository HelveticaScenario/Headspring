#include <cstdio>
#include <cstdlib>
#include <iostream>
#include "fizzbuzzlibc.h"
using namespace std;

char const* fizzBuzzChar(int value){
	char const* three = "Fizz";
	char const* five = "Buzz";
	char const* both = "FizzBuzz";	
	char const* num;
	if (value % 3 == 0){
		if (value % 5 == 0){
			return both;
		}
		return three;
	}
	if (value % 5 == 0){
		return five;
	}
	sprintf(num, "%d", value);
	return num;
}
