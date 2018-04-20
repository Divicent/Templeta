using System.Collections.Generic;
using System.Linq;
using Templeta.TextParsing.Abstract;
using Templeta.TextParsing.Abstract.Models;

namespace Templeta.TextParsing.Concrete
{
    public class TagValidationResult : ITagValidationResult
    {
        public bool Valid { get; set; }
        public int InvalidTagPosition { get; set; }
        public string InvalidTagName { get; set; }
        public string SpecialMessage { get; set; }
    }

    public class TagValidator : ITagValidator
    {
        public ITagValidationResult Validate(IEnumerable<ITagInfo> starting, IEnumerable<ITagInfo> ending)
        {
            var startingTags = starting.ToList();
            var endingTags = ending.ToList();

            if (startingTags.Count != endingTags.Count)
            {
                return new TagValidationResult
                {
                    Valid = false,
                    SpecialMessage = "Count of end tags and star tags should be the same"
                };
            }

            var startingIndex = -1;
            var endingIndex = startingTags.Count;
            while (startingIndex < startingTags.Count - 1)
            {
                startingIndex++;
                endingIndex--;

                var start = startingTags[startingIndex];
                var end = endingTags[endingIndex];

                if (start.TagName != end.TagName)
                {
                    return new TagValidationResult
                    {
                        Valid = false,
                        InvalidTagName = start.TagName,
                        InvalidTagPosition = start.StartIndexInTheText,
                        SpecialMessage = "The tag does not have an ending tag"
                    };
                }

                start.RelatedTag = end;
                end.RelatedTag = start;
            }

            return new TagValidationResult {Valid = true};
        }
    }
}
