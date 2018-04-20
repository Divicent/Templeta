using Templeta.Helpers.Concrete;
using Templeta.TextParsing.Abstract;
using Templeta.TextParsing.Concrete;
using Xunit;
using static Xunit.Assert;

namespace Templeta.Tests.TextParsing
{
    public class TagFinderTests
    {
        private readonly ITagFinder _finder = new TagFinder(new TagHelper());

        [Fact]
        public void Find_ShouldNotMatchTagsNotStartingWithAnUnderscore()
        {
            var (starting, ending) = _finder.Find("<td> </td>");
            Empty(starting);
            Empty(ending);
        }

        [Theory]
        [InlineData("<_if>", "")]
        [InlineData("<_if >", " ")]
        [InlineData("<_if dsa>", " dsa")]
        [InlineData("<_if dsa=\"\">", " dsa=\"\"")]
        [InlineData("<_if dsa=\"dsa\">", " dsa=\"dsa\"")]
        [InlineData("<_if a b c>", " a b c")]
        public void Find_ShouldFindSimpleStartingTag(string feed, string innerContent)
        {
            var (startingTags, _) = _finder.Find(feed);
            NotNull(startingTags);
            Single(startingTags);
            var first = startingTags[0];

            Equal(feed, first.OriginalTextRepresentation);
            True(first.IsAStartingTag);
            Equal("if", first.TagName);
            Equal(0, first.StartIndexInTheText);
            Equal(first.EndIndexInTheString, feed.Length);
            Equal(first.InnerContent , innerContent);
        }

        [Theory]
        [InlineData("< _if>")]
        [InlineData("_if >")]
        [InlineData("<_i f dsa>")]
        [InlineData("<_if dsa")]
        [InlineData("<>")]
        [InlineData("<if>")]
        [InlineData("<if=>")]
        public void Find_ShoulNotMatchWrongStartingTags(string feed)
        {
            var (startingTags, _) = _finder.Find(feed);
            Empty(startingTags);
        }

        [Theory]
        [InlineData("</>")]
        [InlineData("/_if>")]
        [InlineData("</_i f>")]
        [InlineData("</_if")]
        [InlineData("</_if d ")]
        public void Find_ShoulNotMatchWrongEndingTags(string feed)
        {
            var (_, endingTags) = _finder.Find(feed);
            Empty(endingTags);
        }

        [Theory]
        [InlineData("</_if>")]
        [InlineData("</_if >")]
        [InlineData("</_if  >")]
        public void Find_ShouldMatchSimpleEndTag(string feed)
        {
            var (_, endingTags) = _finder.Find(feed);
            NotNull(endingTags);
            Single(endingTags);
            var first = endingTags[0];

            Equal(feed, first.OriginalTextRepresentation);
            False(first.IsAStartingTag);
            Equal("if", first.TagName);
            Equal(0, first.StartIndexInTheText);
            Equal(feed.Length, first.EndIndexInTheString);
        }

        [Fact]
        public void Find_ShouldMatchForTag()
        {
            var (startingTags, _) = _finder.Find("<_for>");
            NotNull(startingTags);
            Single(startingTags);
            var first = startingTags[0];
            Equal("for", first.TagName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Find_ShouldReturnEmptyListForNllEmptyOrWhiteSpaceString(string feed)
        {
            var (startingTags, endingTags) = _finder.Find(feed);
            Empty(startingTags);
            Empty(endingTags);
        }
    }


}
