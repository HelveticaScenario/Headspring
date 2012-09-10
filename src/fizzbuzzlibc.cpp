#include <cstdio>
#include <cstdlib>
#include <iostream>
#include "fizzbuzzlibc.h"
using namespace std;

char* fizzBuzzChar(int value){
	char* three = "Fizz";
	char* five = "Buzz";
	char* both = "FizzBuzz";	
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
	num = (char*)value;
	return (char*)value;
}
