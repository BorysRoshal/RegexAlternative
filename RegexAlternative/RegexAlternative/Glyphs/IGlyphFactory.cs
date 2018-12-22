namespace RegexAlternative.Glyphs
{
    internal interface IGlyphFactory
    {
        IGlyph CreateSymbolsGlyph(string val);
        IGlyph CreateNotSymbolsGlyph(string val);
        IGlyph CreateStringGlyph(string val);
        IGlyph CreateSymbolGlyph(char val);
        IGlyph CreateAnySymbolGlyph();
        IGlyph CreateWordSymbolGlyph();
        IGlyph CreateNotWordSymbolGlyph();
        IGlyph CreateSpaceGlyph();
        IGlyph CreateNotSpaceGlyph();
        IGlyph CreateNumberGlyph();
        IGlyph CreateNotNumberGlyph();
        IGlyph CreateSymbolInUnicodeCategoryGlyph(string unicodeCategory);
        IGlyph CreateSymbolNotInUnicodeCategoryGlyph(string unicodeCategory);
        IGlyph CreateOrGlyph();
    }
}