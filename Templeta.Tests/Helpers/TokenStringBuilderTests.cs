using Templeta.Helpers.Abstract;
using Templeta.Helpers.Concrete;
using Xunit;
using static Xunit.Assert;

namespace Templeta.Tests.Helpers
{
    public class TokenStringBuilderTests
    {
        [Fact]
        public void ShouldBeAbleToConstructWithText()
        {
            var builder = GetBuilder("test");
            Equal("test", builder.Build());
        }

        [Fact]
        public void InitialValueShouldBeEmpty()
        {
            var builder = GetBuilder();
            Empty(builder.Build());
        }

        [Fact]
        public void Append_ShouldAppend()
        {
            var builder = GetBuilder();
            const string text = "rusith";
            foreach (var c in text)
                builder.Append(c);
         
            Equal(text, builder.Build());
        }

        [Fact]
        public void Build_ShouldClearCurrentValue()
        {
            var builder = GetBuilder("e");
            Equal("e", builder.Build());
            Empty(builder.Build());
        }

        [Fact]
        public void Append_ShouldSupportChaining()
        {
            var builder = GetBuilder();

            var result = builder.Append('a')
                .Append('b').Build();

            Equal("ab", result);


        }

        private static ITokenStringBuilder GetBuilder (string initial = "")=> new TokenStringBuilder(initial); 
    }
}
