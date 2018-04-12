
namespace Templeta.Helpers.Abstract
{
    /// <summary>
    /// A re usable string builder which resets its content when calling the ToString method
    /// </summary>
    public interface ITokenStringBuilder
    {
        /// <summary>
        /// Append a charactor
        /// </summary>
        /// <param name="c">Charactor to append</param>
        /// <returns>This builder</returns>
        ITokenStringBuilder Append(char c);

        /// <summary>
        /// This will build the result string and cler the current string
        /// </summary>
        /// <returns>Result string</returns>
        string Build();
    }
}
