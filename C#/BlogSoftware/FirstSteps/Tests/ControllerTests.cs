using System;
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
        private string nicknameString;
        private string indexString;
        private string[] archive;
        public ControllerTests()
        {
            MakeTestPhoBase.DoThat(out pho, out posts);
            controller = new Controller(pho, "password");
            archive = new string[4];
            archive[0] = "98\n" +
                         "\tJuly\n" +
                         "\t\tSecond - Friday, July 25\n";

            archive[1] = "53\n" +
                         "\tJuly\n" +
                         "\t\tFourth - Sunday, July 13\n";

            archive[2] = "34\n" +
                         "\tJune\n" +
                         "\t\tThird - Friday, June 23\n" +
                         "\tApril\n" +
                         "\t\tFirst - Sunday, April 23\n";
            
            archive[3] = "26\n" +
                         "\tJune\n" +
                         "\t\tFifth - Saturday, June 27\n";

            nicknameString = "Fourth\n" +
                             "by Some Guy\n\n" +
                             "fourth post\n\n" +
                             "Sunday, July 13\n";
            
            indexString = "Second\n" +
                          "by John Doe\n\n" +
                          "second post\n\n" +
                          "Friday, July 25\n";
        }
        [Fact]
        public void IndexTest()
        {
            controller.Index().ShouldEqual(indexString);
        }
        
        [Fact]
        public void NicknameTest()
        {
            controller.Nickname("fourth").ShouldEqual(nicknameString);
        }

        [Fact]
        public void ArchiveTest()
        {
            controller.Archives().ShouldEqual(archive[0] + "\n" + archive[1] + "\n" + archive[2] + "\n" + archive[3]);
        }

        [Fact]
        public void AllByAuthorTest()
        {
            controller.AllByAuthor("John Doe").ShouldEqual(archive[0] + "\n" + archive[2] + "\n" + archive[3]);
        }

        [Fact]
        public void TestYear()
        {
            controller.Year(34).ShouldEqual(archive[2]);
        }
        
    }
}
