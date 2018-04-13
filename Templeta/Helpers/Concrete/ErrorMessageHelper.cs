using Templeta.Helpers.Abstract;

namespace Templeta.Helpers.Concrete
{
    public class ErrorMessageHelper: IErrorMessageHelper
    {
        public string FormatValidationError(string specialMessgae, (int line, int column) position, string tagName)
        {
            if (string.IsNullOrWhiteSpace(specialMessgae))
                specialMessgae = "An error found in the tag";
            tagName = string.IsNullOrWhiteSpace(tagName) ? "" : $"{tagName} ";

            return $"{specialMessgae} ({tagName}tag at line {position.line}, column {position.column})";
        }
    }
}
