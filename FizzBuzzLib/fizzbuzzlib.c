//
//  fizzbuzzlib.c
//  FizzBuzzLib
//
//  Created by Daniel Lewis on 7/12/12.
//  Copyright (c) 2012 __MyCompanyName__. All rights reserved.
//

#include <stdio.h>


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
