using System;
using System.Collections.Generic;
using System.Text;
using Templeta.Helpers.Abstract;
using Templeta.Helpers.Concrete;
using Xunit;
using static Xunit.Assert;

namespace Templeta.Tests.Helpers
{
    public class TagHelperTests
    {
        private readonly ITagHelper _tagHelper = new TagHelper();

        [Fact]
        public void GetAllValidTags_ShouldReturnSetOfTagNames()
        {
            var tags = _tagHelper.GetAllValidTags();
            NotNull(tags);
            NotEmpty(tags);
        }
    }
}
