using Templeta.TextParsing.Abstract;
using Templeta.TextParsing.Concrete;
using Templeta.TextParsing.Concrete.Models;
using Xunit;

namespace Templeta.Tests.TextParsing
{
    public class TagParserTests
    {
        [Fact]
        public void ParseEmptyTag()
        {
            ITagParser tagParser = new TagParser();
            var tag = new TagInfo {OriginalTextRepresentation = "<_if>"};
            tagParser.ParseTagContent(tag);
        }

        public void ParseTagContent_ShouldSetAttributeCollection()
        {
        }
    }
}
