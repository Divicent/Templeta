using System.Collections.Generic;

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
        ITagValidationResult Validate(IEnumerable<ITagFragment> tags, IEnumerable<ITagFragment> tagFragments);
    }
}
