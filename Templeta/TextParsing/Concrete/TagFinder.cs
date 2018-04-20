using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Templeta.Helpers.Concrete;
using Templeta.TextParsing.Abstract;
using Templeta.TextParsing.Abstract.Models;

namespace Templeta.TextParsing.Concrete
{
    public class TagFinder : ITagFinder
    {
        private readonly TagHelper _tagHelper;

        public TagFinder(TagHelper tagHelper)
        {
            _tagHelper = tagHelper;
        }

        public (List<ITagInfo> StartingTags, List<ITagInfo> EndingTags) Find(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return (new List<ITagInfo>(), new List<ITagInfo>());
            var names = $"{_tagHelper.GetAllValidTags().Aggregate((c, n) => $"{c}|{n}").Trim('|')}";
            return (FindStartingTags(text, names).ToList(), FindEndTags(text, names).ToList());
        }

        private static IEnumerable<ITagInfo> FindStartingTags(string text, string names)
        {
            var regex = $@"<_({names})(.*)>";
            var matches = Regex.Matches(text, regex);
            return matches.Select(m => Convert(m, true));
        }

        private static IEnumerable<ITagInfo> FindEndTags(string text, string names)
        {
            var regex = $@"</_({names})\s*>";
            var matches = Regex.Matches(text, regex);
            return matches.Select(m => Convert(m, false));
        }

        private static Models.TagInfo Convert(Match m, bool starting) => new Models.TagInfo
        {
            OriginalTextRepresentation = m.Value,
            StartIndexInTheText = m.Index,
            EndIndexInTheString = m.Index + m.Length,
            TagName = m.Groups[1].Value,
            InnerContent = m.Groups[2].Value,
            IsAStartingTag = starting
        };
    }
}
