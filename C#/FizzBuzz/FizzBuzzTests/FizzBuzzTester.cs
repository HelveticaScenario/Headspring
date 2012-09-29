using ClassicFizzBuzz;
using NUnit.Framework;
using Should;

namespace FizzBuzzTests
{
    [TestFixture]
    public class FizzBuzzTester
    {
        [Test]
        public void ShouldProduceTheFirst5Numbers()
        {
            var expected = new string[] {"1", "2", "Fizz", "4", "Buzz"};
            new FizzBuzz().Run(5).ShouldEqual(expected);
        }
        [Test]
        public void ShouldProduceTheFirst15Numbers()
        {
            var expected = new string[] { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" };
            new FizzBuzz().Run(15).ShouldEqual(expected);
        }

        /*
         1. Make this test pass by making a real assertion.
         2. Make FizzBuzz.Run() accept an int as its input, for how many items to return.
         3. Make a second test to prove that sending a different int to it produces different result.
         4. Now that we have tests that provide confidence, rewrite the original algorithm to not use 'continue'.         
         */
    }
}
