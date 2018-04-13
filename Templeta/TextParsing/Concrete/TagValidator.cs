using System;
using System.Collections.Generic;
using System.Linq;
using Templeta.TextParsing.Abstract;

namespace Templeta.TextParsing.Concrete
{
    public class TagValidationResult : ITagValidationResult
    {
        public bool Success { get; set; }
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
                    Success = false,
                    SpecialMessage = "Count of end tags and star tags should be the same"
                };
            }

            var startingIndex = 0;
            var endingIndex = startingTags.Count - 1;
            while (startingIndex < startingTags.Count)
            {
                startingIndex++;
                endingIndex--;

                var start = startingTags[startingIndex];
                var end = endingTags[endingIndex];

                if (start.Name != end.Name)
                {
                    return new TagValidationResult
                    {
                        Success = false,
                        InvalidTagName = start.Name,
                        InvalidTagPosition = start.Start,
                        SpecialMessage = "The tag does not have an ending tag"
                    };
                }
            }

            throw new NotImplementedException();
        }
    }
}
