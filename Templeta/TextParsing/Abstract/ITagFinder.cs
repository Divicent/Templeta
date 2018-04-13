using System.Collections.Generic;

namespace Templeta.TextParsing.Abstract
{
    public interface ITagFragment
    {
        int Start { get; }
        int End { get; }
        string Content { get; }
        string Name { get; }
    }

    /// <summary>
    /// This will be able to find tag locations in a string
    /// </summary>
    public interface ITagFinder
    {
        (List<ITagFragment> StartingTags, List<ITagFragment> EndingTags) Find(string text);
    }
}
