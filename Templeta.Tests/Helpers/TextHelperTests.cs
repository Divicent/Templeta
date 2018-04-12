using Templeta.Helpers.Abstract;
using Templeta.Helpers.Concrete;
using Xunit;

namespace Templeta.Tests.Helpers
{
    public class TextHelperTests
    {
        [Fact]
        public void ConvertStringToCharArray_ShouldReturnNull_IfTextIsNull()
        {
            var helper = GetHelper();
            var result = helper.ConvertStringToCharArray(null);

            Assert.Null(result);
        }

        [Fact]
        public void ConvertStringToCharArray_ShouldReturnEmptyArray_IfTextIsEmpty()
        {
            var helper = GetHelper();
            var result = helper.ConvertStringToCharArray("");

            Assert.True(result.Length == 0);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("abc")]
        [InlineData("12345")]
        [InlineData("0978369&(*^^#)")]
        [InlineData("dsds589/432/4*3/2*/5*/5*/489&(*^*&%&^$&^$#&%&%&*")]
        public void ConvertStringToCharArray_ShouldReturnCharArray_ForString(string text)
        {
            var helper = GetHelper();
            var result = helper.ConvertStringToCharArray(text);

            Assert.Equal(text.Length, result.Length);
            for (var i = 0; i < text.Length; i++)
            {
                Assert.Equal(result[i], text[i]);
            }
        }

        private static ITextHelper GetHelper() => new TextHelper();
    }
}
