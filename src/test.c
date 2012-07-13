//
//  test.c
//  test
//
//  Created by Daniel Lewis on 7/12/12.
//  Copyright (c) 2012 __MyCompanyName__. All rights reserved.
//

#include <stdio.h>
#include <stdlib.h>
#include <dlfcn.h>
#include "fizzbuzzlib.h"

int main(int argc, const char * argv[])
{
    printf("Hello, World!\n");
    fizzBuzzPrintf(1, 100, "a", "b", "c");
    return 0;
}

