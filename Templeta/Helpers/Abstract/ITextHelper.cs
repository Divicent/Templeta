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

        /// <summary>
        /// Will return line number and position by using the given exact position in the string
        /// </summary>
        /// <param name="text">Text to be used</param>
        /// <param name="start">StartIndexInTheText index of the target string</param>
        /// <returns></returns>
        (int line, int column) GetLinePosition(string text, int start);
    }
}
