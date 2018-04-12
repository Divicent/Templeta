using System.Collections.Generic;
using System.Linq;
using Templeta.Helpers.Concrete;
using Templeta.TextParsing.Tokenizing.Abstract;
using Templeta.TextParsing.Tokenizing.Concrete;
using Templeta.TextParsing.Tokenizing.Models.Abstract;
using Xunit;

namespace Templeta.Tests.TextParsing.Tokenizing
{
    public class TextTokenizerTests
    {
        [Fact]
        public void TokenizerShouldConstruct()
        {
            ITextTokenizer textTokenizer = new TextTokenizer(new TextHelper());
        }

        [Fact]
        public void Tokenizer_Parse_JustText()
        {
            var result = Tokenize("text");
            Assert.Single(result);

            Assert.Equal(TokenType.Text, result[0].Type);
            Assert.Equal("text", result[0].Value);

        }

        [Fact]
        public void Tokenizer_Tokenize_EmptyTag()
        {
            var result = Tokenize("<_t >");
            Assert.Single(result);
            var first = result[0];

            Assert.Equal(TokenType.TagStart, first.Type);
            Assert.Equal("t", first.Value);
        }

        private static List<IToken> Tokenize(string text)
        {
            ITextTokenizer tokenizer = new TextTokenizer(new TextHelper());
            return tokenizer.Tokenize(text).ToList();
        }
    }
}
