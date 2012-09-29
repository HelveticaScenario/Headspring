using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassicFizzBuzz
{
    class ClassicFizzBuzz
    {
        static void Main(string[] args)
        {
            int length = 100;
            for (int i = 1; i <= length; i++)
            {
                if (i % 3 == 0)
                {
                    if (i % 5 == 0)
                    {
                        Console.WriteLine("FizzBuzz");
                        continue;
                    }
                    Console.WriteLine("Fizz");
                    continue;
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                    continue;
                }
                Console.WriteLine(i);
            }
        }
    }
}
