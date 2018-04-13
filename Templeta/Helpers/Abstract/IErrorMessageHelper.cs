namespace Templeta.Helpers.Abstract
{
    public interface IErrorMessageHelper
    {

        /// <summary>
        /// Get formatted error message
        /// </summary>
        /// <returns></returns>
        string FormatValidationError(string specialMessgae, (int line, int column) position, string tagName);
    }
}
