using System.Collections.Generic;
using Templeta.TextParsing.Abstract.Models;

namespace Templeta.TextParsing.Abstract
{
    /// <summary>
    /// This will parse attributes of the tag
    /// </summary>
    public interface ITagParser
    {
        ICollection<IAttributeInfo> ParseTagContent(string innerContent);
    }
}
