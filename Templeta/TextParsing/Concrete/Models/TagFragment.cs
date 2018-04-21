using Templeta.TextParsing.Abstract.Models;

namespace Templeta.TextParsing.Concrete.Models
{
    public class TagFragment: ITagFragment
    {
        public string Text { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public string Name { get; set; }
        public string TagContent { get; set; }
        public bool IsStartTag { get; set; }
    }
}
