namespace Templeta.TextParsing.Abstract.Models
{
    /// <summary>
    /// A tag fragment represents the location of a tag inside a string and its content
    /// </summary>
    public interface ITagFragment
    {
        string Text { get; }
        int StartIndex { get; }
        int EndIndex { get; }
        string Name { get; }
        string TagContent { get; }
        bool IsStartTag { get; }
    }
}
