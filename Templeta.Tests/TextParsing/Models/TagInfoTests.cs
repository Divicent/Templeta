using Templeta.TextParsing.Abstract.Models;
using Templeta.TextParsing.Concrete.Models;
using Xunit;

namespace Templeta.Tests.TextParsing.Models
{
    public class TagInfoTests
    {
        [Fact]
        public void AttributesShouldNotBeNull()
        {
            ITagInfo info  = new TagInfo();
            Assert.NotNull(info.Attributes);
            Assert.Empty(info.Attributes);
        }
    }
}
