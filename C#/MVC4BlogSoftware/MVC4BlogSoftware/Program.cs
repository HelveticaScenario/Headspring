using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstSteps.Tests;

namespace FirstSteps
{
    class Program
    {
        static void Main(string[] args)
        {
//            var url = Console.ReadLine();
//            var type = UrlParser.EvalSuffix(url); //@"http://www.some-blog.com/archive");
//            Console.WriteLine(url + " is of type " + type);
//            var phobase = new PhoBase();
//            for (int i = 0; i < 5; i++)
//                phobase.Add(new Post("Title" + i, "nick-name-" + i, "Body " + i, new DateTime()));
//            foreach (Post post in phobase.GetAll())
//            {
//                Console.WriteLine(post.Nickname);
//                Console.WriteLine(post.Body);
//                Console.WriteLine(post.Title);
//                Console.WriteLine(post.TimeStamp);
//            }
//            Console.WriteLine(Controller.MonthName(DateTime.Now));
//            Console.WriteLine(new DateTime(34, 4, 23).DayOfWeek);
//            Console.WriteLine(new DateTime(98, 7, 25).DayOfWeek);
//            Console.WriteLine(new DateTime(34, 6, 23).DayOfWeek);
//            Console.WriteLine(new DateTime(53, 7, 13).DayOfWeek);
//            Console.WriteLine(new DateTime(26, 6, 27).Year.ToString(CultureInfo.InvariantCulture).Length);
//            PhoBase pho;
//            Post[] posts;
//
//            MakeTestPhoBase.DoThat(out pho, out posts);
//            var controller = new Controller(pho);
//            var archive = new string[4];
//            archive[0] = "98\n" +
//                         "\tJuly\n" +
//                         "\t\tSecond - Friday, July 25\n";
//
//            archive[1] = "53\n" +
//                         "\tJuly\n" +
//                         "\t\tFourth - Sunday, July 13\n";
//
//            archive[2] = "34\n" +
//                         "\tJune\n" +
//                         "\t\tThird - Friday, June 23\n" +
//                         "\tApril\n" +
//                         "\t\tFirst - Sunday, April 23\n";
//            
//            archive[3] = "26\n" +
//                         "\tJune\n" +
//                         "\t\tFifth - Saturday, June 27\n";
////            var tmp = posts.OrderByDescending(d => d.TimeStamp).ToArray();
//            Console.WriteLine(@controller.Archives()[40]);
//            Console.WriteLine("hats");
//            Console.WriteLine(Convert.ToInt32("35") );
            PhoBase pho;
            Post[] aray;
            Tests.MakeTestPhoBase.DoThat(out pho, out aray);
            var masterControl = new Controller(pho, "password");
            while (true)
            {
                masterControl.Access();
            }
        }
    }
}
