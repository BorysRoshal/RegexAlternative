namespace RegexAlternative.Glyphs
{
    internal class GlyphFactory : IGlyphFactory
    {
        public IGlyph CreateSymbolsGlyph(string val)
        {
            return new SingleGlyph($"[{val}]");
        }

        public IGlyph CreateNotSymbolsGlyph(string val)
        {
            return new SingleGlyph($"[^{val}]");
        }

        public IGlyph CreateStringGlyph(string val)
        {
            return new SingleGlyph($"(?:{val})");
        }

        public IGlyph CreateSymbolGlyph(char val)
        {
            return new SingleGlyph(val.ToString());
        }

        public IGlyph CreateAnySymbolGlyph()
        {
            return new SingleGlyph(".");
        }

        public IGlyph CreateWordSymbolGlyph()
        {
            return new SingleGlyph(@"\w"); 
        }

        public IGlyph CreateNotWordSymbolGlyph()
        {
            return new SingleGlyph(@"\W");
        }

        public IGlyph CreateSpaceGlyph()
        {

            return new SingleGlyph(@"\s");

        }

        public IGlyph CreateNotSpaceGlyph()
        {

            return new SingleGlyph(@"\S");

        }

        public IGlyph CreateNumberGlyph()
        {
            return new SingleGlyph(@"\d");
        }

        public IGlyph CreateNotNumberGlyph()
        {
            return new SingleGlyph(@"\D");
        }

        public IGlyph CreateSymbolInUnicodeCategoryGlyph(string unicodeCategory)
        {
            return new SingleGlyph(@"\p{" + unicodeCategory + "}");
        }

        public IGlyph CreateSymbolNotInUnicodeCategoryGlyph(string unicodeCategory)
        {
            return new SingleGlyph(@"\P{" + unicodeCategory + "}");
        }

        public IGlyph CreateOrGlyph()
        {
            return new SingleGlyph("|");
        }
    }
}
