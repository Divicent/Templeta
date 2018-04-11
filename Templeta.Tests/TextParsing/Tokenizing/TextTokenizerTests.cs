using Templeta.TextParsing.Tokenizing.Abstract;
using Templeta.TextParsing.Tokenizing.Concrete;
using Xunit;

namespace Templeta.Tests.TextParsing.Tokenizing
{
    public class TextTokenizerTests
    {
        [Fact]
        public void TokenizerShouldConstruct()
        {
            ITextTokenizer textTokenizer = new TextTokenizer();
        }
    }
}
