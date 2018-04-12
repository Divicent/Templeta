using Templeta.TextParsing.Tokenizing.Models.Abstract;

namespace Templeta.TextParsing.Tokenizing.Models.Concrete
{
    internal class Token: IToken
    {
        internal Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public TokenType Type { get; }
        public string Value { get; }
    }
}
