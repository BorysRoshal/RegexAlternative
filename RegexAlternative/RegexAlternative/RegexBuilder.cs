using System.Collections.Generic;
using System.Text;
using RegexAlternative.Builder;
using RegexAlternative.Repeated;
using RegexAlternative.Glyphs;

namespace RegexAlternative
{
    public class RegexBuilder: IRegexBuilderSymbolProperties, IRegexBuilderSymbolRepeated, IRegexBuilderSymbol
    {
        private readonly List<IGlyph> _glyphs = new List<IGlyph>();

        private readonly RegexBuilder _parentBuilder;

        private IGlyph _currentGlyph;

        public static IRegexBuilderSymbol Create()
        {
            return new RegexBuilder();
        }

        protected RegexBuilder()
        {
        }

        protected RegexBuilder(RegexBuilder parentBuilder)
        {
            _parentBuilder = parentBuilder;
        }

        public IRegexBuilderSymbolProperties Symbols(string val)
        {
            AddGlyph(new SingleGlyph($"[{val}]"));

            return this;
        }

        public IRegexBuilderSymbolProperties NotSymbols(string val)
        {
            AddGlyph(new SingleGlyph($"[^{val}]"));

            return this;
        }

        public IRegexBuilderSymbolProperties Symbol
        {
            get
            {
                AddGlyph(new SingleGlyph("."));

                return this;
            }
        }

        public IRegexBuilderSymbolProperties TextSymbol
        {
            get
            {
                AddGlyph(new SingleGlyph(@"\w"));

                return this;
            }
        }

        public IRegexBuilderSymbolProperties NotTextSymbol
        {
            get
            {
                AddGlyph(new SingleGlyph(@"\W"));

                return this;
            }
        }

        public IRegexBuilderSymbolProperties Space
        {
            get
            {
                AddGlyph(new SingleGlyph(@"\s"));

                return this;
            }
        }

        public IRegexBuilderSymbolProperties NotSpace
        {
            get
            {
                AddGlyph(new SingleGlyph(@"\S"));

                return this;
            }
        }

        public IRegexBuilderSymbolProperties Number
        {
            get
            {
                AddGlyph(new SingleGlyph(@"\d"));

                return this;
            }
        }

        public IRegexBuilderSymbolProperties NotNumber
        {
            get
            {
                AddGlyph(new SingleGlyph(@"\D"));

                return this;
            }
        }

        public IRegexBuilderSymbolProperties WhichStartOfWord
        {
            get
            {
                _currentGlyph.IsStartOfWord = true;

                return this;
            }
        }

        public IRegexBuilderSymbolProperties WhichEndOfWord
        {
            get
            {
                _currentGlyph.IsEndOfWord = true;

                return this;
            }
        }

        public IRegexBuilderSymbolProperties WhichNotStartOfWord
        {
            get
            {
                _currentGlyph.IsNotStartOfWord = true;

                return this;
            }
        }

        public IRegexBuilderSymbolProperties WhichNotEndOfWord
        {
            get
            {
                _currentGlyph.IsNotEndOfWord = true;

                return this;
            }
        }

        public IRegexBuilderSymbolProperties WhichStartOfString
        {
            get
            {
                _currentGlyph.IsStartOfString = true;

                return this;
            }
        }

        public IRegexBuilderSymbolProperties WhichEndOfString
        {
            get
            {
                _currentGlyph.IsEndOfString = true;

                return this;
            }
        }

        public IRegexBuilderSymbolRepeated Repeated => this;

        public IRegexBuilderThen FromNtoMTimes(int n, int m)
        {
            _currentGlyph.Repeated = new RepeatedFromNtoMTimes(n, m);

            return this;
        }

        public IRegexBuilderThen FromNTimes(int n)
        {
            _currentGlyph.Repeated = new RepeatedFromNTimes(n);

            return this;
        }

        public IRegexBuilderThen NTimes(int n)
        {
            _currentGlyph.Repeated = new RepeatedNTimes(n);

            return this;
        }

        public IRegexBuilderSymbol Group
        {
            get
            {
                return new RegexBuilder(this);
            }
        }

        public IRegexBuilderSymbolProperties EndOfGroup
        {
            get
            {
                _parentBuilder.AddGlyph(new GroupGlyph(_glyphs));

                return _parentBuilder;
            }
        }

        public IRegexBuilderSymbol Then => this;

        public override string ToString()
        {
            var builder = new StringBuilder();

            _glyphs.ForEach(x => builder.Append(x.Compile()));

            return builder.ToString();
        }

        private void AddGlyph(IGlyph glyph)
        {
            _glyphs.Add(glyph);
            _currentGlyph = glyph;
        }
    }
}
