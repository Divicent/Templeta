using System.Collections.Generic;

namespace Templeta.TextParsing.Abstract
{
    public interface ITagValidator
    {
        void Validate(IEnumerable<ITagFragment> tags, IEnumerable<ITagFragment> tagFragments);
    }
}
