using Xunit;
using Xunit.Extensions;
using Should;

namespace FirstSteps.Tests
{
    public class UrlParserTest
    {
        [Theory,
        InlineData(@"http://www.some-blog.com/archive", "ARCHIVE"),
        InlineData(@"http://www.some-blog.com/archive/", "ARCHIVE"),
        InlineData(@"http://www.some-blog.com/", ""),
        InlineData(@"http://www.some-blog.com/archive/hi", "ARCHIVE/HI")
        ]
        public void TestGetSuffix(string url, string actual)
        {
            
            UrlParser.GetSuffix(url).ShouldEqual(actual);
        }
        [Fact]
        public void TestIsHomepage()
        {
            UrlParser.IsHomePage("").ShouldBeTrue();
            UrlParser.IsHomePage("ARCHIVE").ShouldBeFalse();
        }
        [Fact]
        public void TestIsArchive()
        {
            UrlParser.IsArchive("ARCHIVE").ShouldBeTrue();
            UrlParser.IsArchive("ARCHIVE").ShouldBeTrue();
            UrlParser.IsArchive("Hat").ShouldBeFalse();
        }
        [Fact]
        public void TestIsYear()
        {
            UrlParser.IsYear("1992").ShouldBeTrue();
            UrlParser.IsYear("05").ShouldBeTrue();
            UrlParser.IsYear("005").ShouldBeFalse();
            UrlParser.IsYear("05505").ShouldBeFalse();
            UrlParser.IsYear("Hat").ShouldBeFalse();
        }
        [Fact]
        public void TestIsNickName()
        {
            UrlParser.IsNickName("blah-blah-blah").ShouldBeTrue();
            UrlParser.IsNickName("blah blah blah").ShouldBeFalse();
            UrlParser.IsNickName("ARCHIVE").ShouldBeFalse();
            UrlParser.IsNickName("").ShouldBeFalse();
            UrlParser.IsNickName("1984").ShouldBeFalse();
        }

        [Theory,
        InlineData(@"http://www.some-blog.com/archive", "Archive"),
        InlineData(@"http://www.some-blog.com/5000/", "Year"),
        InlineData(@"http://www.some-blog.com/", "HomePage"),
        InlineData(@"http://www.some-blog.com/hi-buddy/", "Nickname")
        ]
        public void TestEvalSuffixTrue(string url, string expected)
        {
            UrlParser.EvalSuffix(url).ToString().ShouldEqual(expected);
        }
    }
}
