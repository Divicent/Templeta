using System;
using System.Collections.Generic;
using System.Text;
using Templeta.Helpers.Abstract;
using Templeta.Helpers.Concrete;
using Templeta.TextParsing.Tokenizing.Abstract;
using Templeta.TextParsing.Tokenizing.Models.Abstract;
using Templeta.TextParsing.Tokenizing.Models.Concrete;

namespace Templeta.TextParsing.Tokenizing.Concrete
{
    public class TextTokenizer: ITextTokenizer
    {
        private enum Context
        {
            Word,
            TagDefinition,
        }


        private readonly ITextHelper _textHelper;
        private readonly List<IToken> _tokens;
        private Context _context = Context.Text;
        private char[] _chars = {};
        private int _currentIndex = 0;
        private readonly ITokenStringBuilder _builder = new TokenStringBuilder();
        private char _currentChar = ' ';

        public TextTokenizer(ITextHelper textHelper)
        {
            _textHelper = textHelper;
            _tokens = new List<IToken>();
        }

        public IEnumerable<IToken> Tokenize(string text)
        {
            _chars = _textHelper.ConvertStringToCharArray(text);
            Loop();
            return End();
        }


        private void Loop()
        {
            for (_currentIndex = 0; _currentIndex < _chars.Length; _currentIndex++)
                Process(_chars[_currentIndex]);
        }

        private void Process(char c)
        {
            _currentChar = c;
            if (_currentChar == '<' && Next() == '_')
            {
                _tokens.Add(new Token(TokenType.TagStart, null));
                _currentIndex = +2;
                return;
            }
            else if(_currentChar == '>')
            {

            }
            else
            {
                _builder.Append(_currentChar);
            }

            if (_currentChar == ' ')
            {
               _tokens.Add(TokenType._builder.Build());
            }

            if (_context == Context.Text)
            {
                _builder.Append(_currentChar);
            }
        }

        private List<IToken> End()
        {
            if (_context == Context.Text)
            {
                _tokens.Add(new Token(TokenType.Text, _builder.Build()));
            }

            return _tokens;
        }

        private void ProcessTagDefinition(int tagNameStartingIndex)
        {
            var name = new StringBuilder();
            var context = "NAME";

            for (_currentIndex = tagNameStartingIndex; _currentIndex < _chars.Length; _currentIndex++)
            {
                _currentChar = _chars[_currentIndex];
                if (_currentChar == '>')
                {
                    return;
                }
                if (_currentChar == ' ')
                {
                    if (context == "NAME")
                    {
                        if (name.ToString() == "")
                        {
                            throw new Exception("A tag should have a name");
                        }
                        else
                        {
                            _tokens.Add(new Token(TokenType.TagStart, name.ToString()));
                            context = "INSIDE";
                        }
                    }
                }
                else
                {
                    if (context == "NAME")
                    {
                        name.Append(_currentChar);
                    }
                }
            }

        }



        private char Next(int next = 1)
        {
            return _currentIndex + next < _chars.Length - 1 ? _chars[_currentIndex + next] : '\n';
        }
    }
}
