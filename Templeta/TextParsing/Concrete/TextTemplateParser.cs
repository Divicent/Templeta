
using System;
using Templeta.TextParsing.Abstract;

namespace Templeta.TextParsing.Concrete
{
    public class TextTemplateParser: ITemplateTextParser
    {
        public void Parse(string textToParse)
        {
            if(string.IsNullOrWhiteSpace(textToParse))
                throw new ArgumentException("Provided string is not a valid template string");
        }
    }
}
