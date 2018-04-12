namespace Templeta.Helpers.Abstract
{
    /// <summary>
    /// Provides basic functionalities on strings
    /// </summary>
    public interface ITextHelper
    {
        /// <summary>
        /// Converts the provided text into a char array
        /// </summary>
        /// <param name="text">Text to convert</param>
        /// <returns>A char array</returns>
        char[] ConvertStringToCharArray(string text);
    }
}
