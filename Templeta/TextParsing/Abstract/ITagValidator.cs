using System.Collections.Generic;
using Templeta.TextParsing.Abstract.Models;

namespace Templeta.TextParsing.Abstract
{
    public interface ITagValidationResult
    {
        bool Valid { get; }
        int InvalidTagPosition { get; }
        string InvalidTagName { get; }
        string SpecialMessage { get; }
    }

    public interface ITagValidator
    {
        ITagValidationResult Validate(IEnumerable<ITagInfo> tags, IEnumerable<ITagInfo> tagFragments);
    }
}
