//
//  test.c
//  test
//
//  Created by Daniel Lewis on 7/12/12.
//  Copyright (c) 2012 __MyCompanyName__. All rights reserved.
//

#include <iostream>
#include <string>
//#include <cstdlib.h>
#include <dlfcn.h>
#include <cctype>
#include "fizzbuzzlib.h"
#include "fizzbuzzlibc.h"

using namespace std;

//void fizzBuzzStreams(ostream& os,
//					signed int min = 1,
//					signed int max = 100,
//					string three = "Fizz",
//					string five = "Buzz",
//					string both = "FizzBuzz"){
//	//filebuf fb;
//	//extern streambuf *fbs;
//	//ostream os(streambuf fb);
//	for (int i = min; i <= max; ++i)
//	{
//		if (i % 3 == 0)
//		{
//			if (i % 5 == 0)
//			{
//				os << both << endl;
//				continue;
//			}
//				os << three << endl;
//			continue;
//		}
//		else if (i % 5 == 0)
//		{
//				os << five << endl;
//			continue;
//		}
//		else{
//			os << i << endl;
//			continue;
//		}
//	}
//	return;
//}

int main(int argc, const char * argv[])
{
    cout << "Printf\n";
    fizzBuzzPrintf(1, 100, "a", "b", "c");

    cout << "\nStreams\n";
    //ostream cout;
    fizzBuzzStreams(cout, 1, 100, "a", "b", "c");
    cout << "Simple\n";
    for (int i = 0; i <= 100; ++i)
    {
    	cout << fizzBuzzString(i, "a", "b", "c");
    }
    /*for (int i = 0; i < 100; ++i)
    {
        if (isprint((int)fizzBuzzChar[1:](i)))
            cout << fizzBuzzChar(i) << endl;
    }*/
    return 0;
}

