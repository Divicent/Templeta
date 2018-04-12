using Templeta.Helpers.Abstract;

namespace Templeta.Helpers.Concrete
{
    public class TextHelper : ITextHelper
    {
        public char[] ConvertStringToCharArray(string text)
        {
            return text?.ToCharArray();
        }
    }
}
