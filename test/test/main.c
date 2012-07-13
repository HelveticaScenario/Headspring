//
//  main.c
//  test
//
//  Created by Daniel Lewis on 7/12/12.
//  Copyright (c) 2012 __MyCompanyName__. All rights reserved.
//

#include <stdio.h>
#include <stdlib.h>
#include <dlfcn.h>

typedef void (*bubbleSortPtr)(int[], int);
bubbleSortPtr bubbleSort;

int main(int argc, const char * argv[])
{
    void* test_library = dlopen("libFizzBuzzLib.dylib", RTLD_LAZY);
    if(test_library == NULL) {
        printf("didntwork\n");
        return 1;
    } else {
        void* test = dlsym(test_library, "bubbleSortArray");        
        if(test == NULL) {
            // report error ...
        } else {
            // cast initializer to its proper type and use
            bubbleSort = (bubbleSortPtr) test;

        }
    }
    // insert code here...
    printf("Hello, World!\n");
    return 0;
}

