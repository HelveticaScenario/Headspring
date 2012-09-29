using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassicFizzBuzz
{
    public class FizzBuzz
    {
        public String[] Run(int length=5)
        {
            //int length = 5;
            var list = new List<string>();
            for (int i = 1; i <= length; i++)
                list.Add(Entry(i));
            return list.ToArray();
        }

        private static string Entry(int i)
        {
            string entry = "";
            if (i%3 == 0)
                entry += "Fizz";
            if (i%5 == 0)
                entry += "Buzz";
            if (entry == "")
                entry += i;
            return entry;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new FizzBuzz().Run();
        }
    }
}
