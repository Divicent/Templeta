using System.Collections.Generic;
using Templeta.TextParsing.Abstract;
using Templeta.TextParsing.Abstract.Models;

namespace Templeta.TextParsing.Concrete
{
    public class TagParser : ITagParser
    {
        public ICollection<IAttributeInfo> ParseTagContent(string innerContent)
        {
            if(string.IsNullOrWhiteSpace(innerContent))
                return new List<IAttributeInfo>();

            
        }
    }
}
