
using System;
using Templeta.TextParsing.Abstract;
using Templeta.TextParsing.Concrete;
using Xunit;

namespace Templeta.Tests.Parser
{
    public class TemplateTextParserTests
    {
        [Fact]
        public void ParserShouldConstruct()
        {
            GetTextTemplateParser();
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void TextParserShouldNotAcceptNullOrEmptyValues(string text)
        {
            ShouldThrowExceptionWithMessage<ArgumentException>(() => { GetTextTemplateParser().Parse(text); }, "Provided string is not a valid template string");
        }

        private static ITemplateTextParser GetTextTemplateParser () => new TextTemplateParser();

        private static void ShouldThrowExceptionWithMessage<T>(Action func, string message) where T:Exception
        {
            var exception = Assert.Throws<T>(func);
            Assert.Equal(message, exception.Message);
        }
    }


}
