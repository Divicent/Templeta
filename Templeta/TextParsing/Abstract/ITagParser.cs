using Templeta.TextParsing.Abstract.Models;

namespace Templeta.TextParsing.Abstract
{
    /// <summary>
    /// This will parse attributes of the tag
    /// </summary>
    public interface ITagParser
    {
        void ParseTagContent(ITagInfo tag);
    }
}
