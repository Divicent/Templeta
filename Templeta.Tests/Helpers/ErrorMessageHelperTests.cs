using Templeta.Helpers.Abstract;
using Templeta.Helpers.Concrete;
using Xunit;

namespace Templeta.Tests.Helpers
{
    public class ErrorMessageHelperTests
    {
        [Theory]
        [InlineData("Tag does not have an ending tag", 1, 3, "if", "Tag does not have an ending tag (if tag at line 1, column 3)")]
        public void FormatValidationError_ShouldFormatTheMessageCorrectly(string specialMessgae, int line, int column, string tagName, string message)
        {
            IErrorMessageHelper helper = new ErrorMessageHelper();
            Assert.Equal(message, helper.FormatValidationError(specialMessgae, (line, column), tagName));
        }
    }
}
