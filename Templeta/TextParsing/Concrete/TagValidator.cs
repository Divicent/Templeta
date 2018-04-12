using System;
using System.Collections.Generic;
using System.Linq;
using Templeta.TextParsing.Abstract;

namespace Templeta.TextParsing.Concrete
{
    public class TagValidator: ITagValidator
    {
        public void Validate(IEnumerable<ITagFragment> starting, IEnumerable<ITagFragment> ending)
        {
            var startingTags = starting.ToList();
            var endingTags = ending.ToList();

            if(startingTags.Count != endingTags.Count)
                throw new Exception("Count of end tags and star tags should be the same.");
        }
    }
}
