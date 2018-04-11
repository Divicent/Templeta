namespace Templeta.TextParsing.Abstract
{
    /// <summary>
    /// This is the main component that will convert
    /// the text template in to set of tags
    /// </summary>
    public interface ITemplateTextParser
    {
        void Parse(string textToParse);
    }
}
