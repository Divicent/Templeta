using Templeta.TextParsing.Abstract;
using Templeta.TextParsing.Concrete;
using Xunit;

namespace Templeta.Tests.TextParsing
{
    public class TagParserTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void ParseTagContent_ShouldReturnEmptyListForEmptyContent(string content)
        {
            ITagParser tagParser = new TagParser();
            var result = tagParser.ParseTagContent(content);

            Assert.Empty(result);
        }
    }
}
