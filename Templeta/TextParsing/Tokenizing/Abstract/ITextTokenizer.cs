using System.Collections.Generic;
using Templeta.TextParsing.Tokenizing.Models.Abstract;

namespace Templeta.TextParsing.Tokenizing.Abstract
{
    /// <summary>
    /// This should tokenize the given text
    /// </summary>
    public interface ITextTokenizer
    {
        IEnumerable<IToken> Tokenize(string text);
    }
}
