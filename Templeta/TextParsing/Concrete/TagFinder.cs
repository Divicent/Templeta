using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Templeta.Helpers.Concrete;
using Templeta.TextParsing.Abstract;

namespace Templeta.TextParsing.Concrete
{
    public class TagFragment:ITagFragment
    {
        public int Start { get; set; }
        public int End { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public string Row { get; set; }
        public string Column { get; set; }
    }

    public class TagFinder : ITagFinder
    {
        private readonly TagHelper _tagHelper;

        public TagFinder(TagHelper tagHelper)
        {
            _tagHelper = tagHelper;
        }

        public (List<ITagFragment> StartingTags, List<ITagFragment> EndingTags) Find(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
                return (new List<ITagFragment>(), new List<ITagFragment>());
            var names = $"{_tagHelper.GetAllValidTags().Aggregate((c, n) => $"{c}|{n}").Trim('|')}";
            return (FindStartingTags(text, names).ToList(), FindEndTags(text, names).ToList());
        }

        private static IEnumerable<ITagFragment> FindStartingTags(string text, string names)
        {
            var regex = $@"<_({names})(.*)>";
            var matches = Regex.Matches(text, regex);
            return matches.Select(Convert);
        }

        private static IEnumerable<ITagFragment> FindEndTags(string text, string names)
        {
            var regex = $@"</_({names})\s*>";
            var matches = Regex.Matches(text, regex);
            return matches.Select(Convert);
        }

        private static TagFragment Convert(Match m) => new TagFragment
        {
            Content = m.Value,
            Start = m.Index,
            End = m.Index + m.Length,
            Name = m.Groups[1].Value
        };
    }
}
