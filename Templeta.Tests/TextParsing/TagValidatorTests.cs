using System;
using System.Collections.Generic;
using System.Linq;
using Templeta.TextParsing.Abstract;
using Templeta.TextParsing.Abstract.Models;
using Templeta.TextParsing.Concrete;
using Xunit;
using static Xunit.Assert;
using TagInfo = Templeta.TextParsing.Concrete.Models.TagInfo;

namespace Templeta.Tests.TextParsing
{
    public class TagValidatorTests
    {
        private readonly ITagValidator _validator = new TagValidator();

        [Fact]
        public void Validate_StartingAndEndingTagCountShouldBeSame()
        {

            var result = Validate(new List<string> { "if" }, new List<string> { "if", "if" });
            False(result.Valid);
            Equal("Count of end tags and star tags should be the same",  result.SpecialMessage);

        }

        [Theory]
        [InlineData("if|for", "if|if", false, "The tag does not have an ending tag", "for")]
        [InlineData("if", "if", true, null, null)]
        [InlineData("if|if", "if|if", true, null, null)]
        [InlineData("if|for|for", "if|if|if", false, "The tag does not have an ending tag", "for")]
        [InlineData("if|for|else", "else|for|if", true, null, null)]
        [InlineData("", "", true, null, null)]
        public void Validate_ShouldReturnCorrectResult(string startingtags, string endingTags, bool valid, string message, string tag)
        {
            var result = Validate(startingtags.Split("|", StringSplitOptions.RemoveEmptyEntries).ToList(), endingTags.Split("|", StringSplitOptions.RemoveEmptyEntries).ToList());
            Equal(valid, result.Valid);
            if (!valid)
            {
                Equal(message, result.SpecialMessage);
                Equal(tag, result.InvalidTagName);
            }
            
        }

        [Fact]
        public void Validate_ShouldSetTheRelatedTag()
        {
            var startTag = new TagInfo {TagName = "if"};
            var endTag = new TagInfo {TagName = "if"};
            _validator.Validate(new List<ITagInfo> {startTag}, new List<ITagInfo> {endTag});

            Same(startTag.RelatedTag, endTag);
            Same(endTag.RelatedTag, startTag);
        }

        private ITagValidationResult Validate(IEnumerable<string> s, IEnumerable<string> e) => _validator.Validate(Tags(s), Tags(e));
        private static IEnumerable<ITagInfo> Tags(IEnumerable<string> li) => li.Select(l => new TagInfo { TagName = l }).ToList();
    }
}
