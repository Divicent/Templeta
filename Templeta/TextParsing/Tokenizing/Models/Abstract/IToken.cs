namespace Templeta.TextParsing.Tokenizing.Models.Abstract
{
    public enum TokenType
    {
        TagDefStart,
        TagDefEnd,
        Text,
        TagEndStart,

    }

    public interface IToken
    {
        TokenType Type { get; }
        string Value { get; }
    }
}
