using System.Collections.Generic;
using Templeta.TextParsing.Abstract.Models;

namespace Templeta.TextParsing.Abstract
{
    /// <summary>
    /// This will be able to find tag locations in a string
    /// </summary>
    public interface ITagFinder
    {
        (List<ITagInfo> StartingTags, List<ITagInfo> EndingTags) Find(string text);
    }
}
