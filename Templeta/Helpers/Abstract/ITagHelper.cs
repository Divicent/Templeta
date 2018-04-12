

using System.Collections.Generic;

namespace Templeta.Helpers.Abstract
{
    public interface ITagHelper
    {
        IReadOnlyList<string> GetAllValidTags();
    }
}
