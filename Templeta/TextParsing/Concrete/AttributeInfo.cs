using Templeta.TextParsing.Abstract.Models;

namespace Templeta.TextParsing.Concrete
{
    public class AttributeInfo: IAttributeInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}