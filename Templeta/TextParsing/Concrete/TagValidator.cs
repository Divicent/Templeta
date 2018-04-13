using System.Collections.Generic;
using System.Linq;
using Templeta.TextParsing.Abstract;

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
        public ITagValidationResult Validate(IEnumerable<ITagFragment> starting, IEnumerable<ITagFragment> ending)
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

                if (start.Name != end.Name)
                {
                    return new TagValidationResult
                    {
                        Valid = false,
                        InvalidTagName = start.Name,
                        InvalidTagPosition = start.Start,
                        SpecialMessage = "The tag does not have an ending tag"
                    };
                }
            }

            return new TagValidationResult {Valid = true};
        }
    }
}
