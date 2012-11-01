using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine(UrlParser.EvalSuffix(@"http://www.some-blog.com/archive"));
        }
    }
}
