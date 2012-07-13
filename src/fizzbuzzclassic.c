#include <stdio.h>

//This program prints to the console the numbers 1 through
//100, with the exception of those numbers evenly divisible
//by 3, 5, or both 3 and 5, for which it prints the words
//"Fizz", "Buzz", or "FizzBuzz" respectively.

int main(){
	char *five = "Buzz";
	char *three = "Fizz";
	char *both = "FizzBuzz";
	for (int i = 1; i <= 100; ++i)
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

	return 0;
}