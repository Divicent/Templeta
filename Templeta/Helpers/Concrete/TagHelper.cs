using System;
using System.Collections.Generic;
using System.Text;
using Templeta.Helpers.Abstract;

namespace Templeta.Helpers.Concrete
{
    public class TagHelper: ITagHelper
    {
        private readonly string[] _validTagNames = new[]
        {
            "if",
            "for"
        };


        public IReadOnlyList<string> GetAllValidTags()
        {
            return _validTagNames;
        }
    }
}
