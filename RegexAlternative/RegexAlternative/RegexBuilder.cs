using System;
using System.Collections.Generic;
using System.Text;
using RegexAlternative.Builder;
using RegexAlternative.Glyphs;
using RegexAlternative.Quantifiers;

namespace RegexAlternative
{
    public class RegexBuilder: IRegexBuilderSymbolWhich, IRegexBuilderSymbolRepeated, IRegexBuilderSymbol, IRegexBuilderSymbolProperties
    {
        private List<IGlyph> Glyphs { get; }  = new List<IGlyph>();

        private readonly RegexBuilder _parentBuilder;

        private IGlyph _currentGlyph;

        private IGlyphFactory _glyphFactory;

        public static IRegexBuilderSymbol Create()
        {
            return new RegexBuilder();
        }

        protected RegexBuilder()
        {
            _glyphFactory = new GlyphFactory();
        }

        protected RegexBuilder(RegexBuilder parentBuilder) : this()
        {
            _parentBuilder = parentBuilder;
        }

        public IRegexBuilderSymbolProperties Symbols(string val)
        {
            AddGlyph(_glyphFactory.CreateSymbolsGlyph(val));

            return this;
        }

        public IRegexBuilderSymbolProperties NotSymbols(string val)
        {
            AddGlyph(_glyphFactory.CreateNotSymbolsGlyph(val));

            return this;
        }

        public IRegexBuilderSymbolProperties String(string val)
        {
            AddGlyph(_glyphFactory.CreateStringGlyph(val));

            return this;
        }

        public IRegexBuilderSymbolProperties Symbol(char val)
        {
            AddGlyph(_glyphFactory.CreateSymbolGlyph(val));

            return this;
        }

        public IRegexBuilderSymbolProperties AnySymbol
        {
            get
            {
                AddGlyph(_glyphFactory.CreateAnySymbolGlyph());

                return this;
            }
        }

        public IRegexBuilderSymbolProperties WordSymbol
        {
            get
            {
                AddGlyph(_glyphFactory.CreateWordSymbolGlyph());

                return this;
            }
        }

        public IRegexBuilderSymbolProperties NotWordSymbol
        {
            get
            {
                AddGlyph(_glyphFactory.CreateNotWordSymbolGlyph());

                return this;
            }
        }

        public IRegexBuilderSymbolProperties Space
        {
            get
            {
                AddGlyph(_glyphFactory.CreateSpaceGlyph());

                return this;
            }
        }

        public IRegexBuilderSymbolProperties NotSpace
        {
            get
            {
                AddGlyph(_glyphFactory.CreateNotSpaceGlyph());

                return this;
            }
        }

        public IRegexBuilderSymbolProperties Number
        {
            get
            {
                AddGlyph(_glyphFactory.CreateNumberGlyph());

                return this;
            }
        }

        public IRegexBuilderSymbolProperties NotNumber
        {
            get
            {
                AddGlyph(_glyphFactory.CreateNotNumberGlyph());

                return this;
            }
        }

        public IRegexBuilderSymbolProperties SymbolInUnicodeCategory(string name)
        {
            AddGlyph(_glyphFactory.CreateSymbolInUnicodeCategoryGlyph(name));

            return this;
        }

        public IRegexBuilderSymbolProperties SymbolNotInUnicodeCategory(string name)
        {
            AddGlyph(_glyphFactory.CreateSymbolNotInUnicodeCategoryGlyph(name));

            return this;
        }

        public IRegexBuilderSymbolProperties StartOfWord
        {
            get
            {
                _currentGlyph.Anchors |= Anchors.StartOfWord;

                return this;
            }
        }

        public IRegexBuilderSymbolProperties EndOfWord
        {
            get
            {
                _currentGlyph.Anchors |= Anchors.EndOfWord;

                return this;
            }
        }

        public IRegexBuilderSymbolProperties NotStartOfWord
        {
            get
            {
                _currentGlyph.Anchors |= Anchors.NotStartOfWord;

                return this;
            }
        }

        public IRegexBuilderSymbolProperties NotEndOfWord
        {
            get
            {
                _currentGlyph.Anchors |= Anchors.NotEndOfWord;

                return this;
            }
        }

        public IRegexBuilderSymbolProperties StartOfString
        {
            get
            {
                _currentGlyph.Anchors |= Anchors.StartOfString;

                return this;
            }
        }

        public IRegexBuilderSymbolProperties EndOfString
        {
            get
            {
                _currentGlyph.Anchors |= Anchors.EndOfString;

                return this;
            }
        }

        public IRegexBuilderSymbolWhich Which => this;

        public IRegexBuilderSymbolRepeated Repeated => this;

        public IRegexBuilderThen FromNtoMTimes(int n, int m)
        {
            _currentGlyph.Quantifier = new QuantifierNtoMTimes(n, m);

            return this;
        }

        public IRegexBuilderThen AtLeastNTimes(int n)
        {
            _currentGlyph.Quantifier = new QuantifierFromNTimes(n);

            return this;
        }

        public IRegexBuilderThen ExactlyNTimes(int n)
        {
            _currentGlyph.Quantifier = new QuantifierNTimes(n);

            return this;
        }

        public IRegexBuilderSymbol BeginGroup => new RegexBuilder(this);

        public IRegexBuilderSymbolProperties EndGroup
        {
            get
            {
                if (_parentBuilder == null)
                {
                    throw new Exception("Group wasn't opened.");
                }

                _parentBuilder.AddGlyph(new GroupGlyph(Glyphs));

                return _parentBuilder;
            }
        }

        public IRegexBuilderSymbol Group(IRegexBuilderThen builder)
        {
            AddGlyph(new GroupGlyph(((RegexBuilder)builder).Glyphs));

            return this;
        }

        public IRegexBuilderSymbol Then => this;

        public IRegexBuilderSymbol Or
        {
            get
            {
                AddGlyph(_glyphFactory.CreateOrGlyph());

                return this;
            }
        }

        public IRegexBuilderThen End => this;

        public override string ToString()
        {
            var builder = new StringBuilder();

            Glyphs.ForEach(x => builder.Append(x.Compile()));

            return builder.ToString();
        }

        private void AddGlyph(IGlyph glyph)
        {
            Glyphs.Add(glyph);
            _currentGlyph = glyph;
        }
    }
}
