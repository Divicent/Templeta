using System.Collections.Generic;
using System.Linq;
using Templeta.TextParsing.Abstract;
using Templeta.TextParsing.Concrete;
using Xunit;
using static Xunit.Assert;

namespace Templeta.Tests.TextParsing
{
    public class TagValidatorTests
    {
        private readonly ITagValidator _validator = new TagValidator();

        [Fact]
        public void Validate_StartingAndEndingTagCountShouldBeSame()
        {

            var result = Validate(new List<string> { "if" }, new List<string> { "if", "if" });
            False(result.Success);
            Equal("Count of end tags and star tags should be the same",  result.SpecialMessage);

        }

        [Fact]
        public void Validate_StartingTagShouldHaveEndingTag()
        {
            var result = Validate(new List<string> { "if", "for" }, new List<string> { "if", "if" });
            False(result.Success);
            Equal("The tag does not have an ending tag", result.SpecialMessage);
            Equal("for", result.InvalidTagName);
        }

        private ITagValidationResult Validate(IEnumerable<string> s, IEnumerable<string> e) => _validator.Validate(Tags(s), Tags(e));
        private static IEnumerable<ITagFragment> Tags(IEnumerable<string> li) => li.Select(l => new TagFragment { Name = l }).ToList();
    }
}
