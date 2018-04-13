using System;
using System.Linq;
using Templeta.Helpers.Abstract;

namespace Templeta.Helpers.Concrete
{
    public class TextHelper : ITextHelper
    {
        public char[] ConvertStringToCharArray(string text)
        {
            return text?.ToCharArray();
        }

        public (int line, int column) GetLinePosition(string text, int start)
        {
            if (string.IsNullOrEmpty(text) || text.Length <= start)
                return (1, 1);

            var splitted = text.Substring(0, start)
                .Split(new[] {Environment.NewLine, "\n", "\r\n"}, StringSplitOptions.None);

            return splitted.Length < 1 || (splitted.Length == 1 && splitted[0] == "")
                ? (1, start + 1)
                : (splitted.Length, splitted.Last().Length + 1);

        }
    }
}
