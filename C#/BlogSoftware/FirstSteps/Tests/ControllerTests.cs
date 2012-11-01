using System.Linq;
using Xunit;
using Should;

namespace FirstSteps.Tests
{
    public class ControllerTests
    {
        private PhoBase pho;
        private Post[] posts;
        private Controller controller;
        public ControllerTests()
        {
            MakeTestPhoBase.DoThat(out pho, out posts);
            controller = new Controller(pho);
        }
        [Fact]
        public void IndexTest()
        {
            controller.Index().ShouldEqual(posts[1]);
        }

        [Fact]
        public void ArchiveTest()
        {
            Post[] tmp = posts.OrderByDescending(d => d.TimeStamp).ToArray();
            controller.Archives().ShouldEqual(tmp);
        }

        [Fact]
        public void TestYear()
        {
            var expected = new Post[2];
            expected[0] = posts[2];
            expected[1] = posts[0];
            var something = controller.Year(34);
            return;

        }
        
    }
}
