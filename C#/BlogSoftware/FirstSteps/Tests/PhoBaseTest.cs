using System;
using Xunit;
using Should;

namespace FirstSteps.Tests
{
    public class PhoBaseTest
    {
        private PhoBase pho;
        private Post[] posts;

        public PhoBaseTest()
        {
            MakeTestPhoBase.DoThat(out pho, out posts);
        }
        [Fact]
        public void TestGetAll()
        {
            pho.GetAll().ShouldEqual(posts);
        }

        [Fact]
        public void TestGetPost()
        {
            pho.Get(posts[3].Nickname).ShouldEqual(posts[3]);
        }

        [Fact]
        public void TestDelete() // all thats really needed
        {
            var tmp = new Post[4];
            for (int i = 0; i < 4; i++)
            {
                tmp[i] = posts[i];
            }
            pho.Delete(pho.Get("fifth"));
            pho.GetAll().ShouldEqual(tmp);
        }
    }
}
