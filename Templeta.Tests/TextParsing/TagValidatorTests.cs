using System;
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

            var exception = Validate(new List<string> { "if" }, new List<string> { "if", "if" });
            Equal("Count of end tags and star tags should be the same.", exception.Message);

        }

        [Fact]
        public void Validate_StartingTagShouldHaveEndingTag()
        {
            var exception = Validate(new List<string> { "if" }, new List<string> { "if", "if" });
            Equal("Count of end tags and star tags should be the same.", exception.Message);
        }

        private Exception Validate(IEnumerable<string> s, IEnumerable<string> e) => Throws<Exception>(() =>
        {
            _validator.Validate(Tags(s), Tags(e));
        });
        private static IEnumerable<ITagFragment> Tags(IEnumerable<string> li) => li.Select(l => new TagFragment { Name = l }).ToList();
    }
}
