using System.Collections.Generic;

namespace Templeta.TextParsing.Abstract.Models
{
    public interface ITagInfo
    {
        bool IsAStartingTag { get; }
        int StartIndexInTheText { get; }
        int EndIndexInTheString { get; }
        string OriginalTextRepresentation { get; }
        string TagName { get; }
        ITagInfo RelatedTag { get; set; }
        string InnerContent { get; set; }
        ICollection<IAttributeInfo> Attributes { get; set; }
    }
}