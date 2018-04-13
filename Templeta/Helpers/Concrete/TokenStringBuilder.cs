using System.Text;
using Templeta.Helpers.Abstract;

namespace Templeta.Helpers.Concrete
{
    public class TokenStringBuilder: ITokenStringBuilder
    {
        private readonly StringBuilder _internalStringBuilder;

        public TokenStringBuilder(string initialString)
        {
            _internalStringBuilder = new StringBuilder(initialString);
        }

        public ITokenStringBuilder Append(char c)
        {
            _internalStringBuilder.Append(c);
            return this;
        }

        public string Build()
        {
            var result = _internalStringBuilder.ToString();
            _internalStringBuilder.Clear();
            return result;
        }
    }
}
