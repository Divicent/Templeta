using System.Collections.Generic;
using Templeta.TextParsing.Abstract.Models;

namespace Templeta.TextParsing.Concrete.Models
{
    public class TagInfo : ITagInfo
    {
        public bool IsAStartingTag { get; set; }
        public int StartIndexInTheText { get; set; }
        public int EndIndexInTheString { get; set; }
        public string OriginalTextRepresentation { get; set; }
        public string TagName { get; set; }
        public ITagInfo RelatedTag { get; set; }
        public string InnerContent { get; set; }
        public ICollection<IAttributeInfo> Attributes { get; set; } = new List<IAttributeInfo>();
    }
}