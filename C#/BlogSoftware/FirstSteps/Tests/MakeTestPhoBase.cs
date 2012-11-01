using System;

namespace FirstSteps.Tests
{
    static class MakeTestPhoBase
    {
        public static void DoThat(out PhoBase pho, out Post[] posts)
        {
            pho = new PhoBase();
            posts = new Post[5];
            posts[0] = (new Post("First", "first", "first post", new DateTime(34, 4, 23)));
            posts[1] = (new Post("Second", "second", "second post", new DateTime(98, 7, 25)));
            posts[2] = (new Post("Third", "third", "third post", new DateTime(34, 6, 23)));
            posts[3] = (new Post("Fourth", "fourth", "fourth post", new DateTime(53, 7, 13)));
            posts[4] = (new Post("Fifth", "fifth", "fifth post", new DateTime(26, 6, 27)));
            foreach (Post post in posts)
            {
                pho.Add(post);
            }
        }
    }
}
