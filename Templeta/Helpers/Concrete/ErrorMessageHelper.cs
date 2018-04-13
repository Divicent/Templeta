using Templeta.Helpers.Abstract;

namespace Templeta.Helpers.Concrete
{
    public class ErrorMessageHelper: IErrorMessageHelper
    {
        public string FormatValidationError(string specialMessgae, (int line, int column) position, string tagName)
        {
            return $"{specialMessgae} ({tagName} tag at line {position.line}, column {position.column})";
        }
    }
}
