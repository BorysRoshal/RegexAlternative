using RegexAlternative.Quantifiers;

namespace RegexAlternative.Glyphs
{
    internal interface IGlyph: ICompilable
    {
        Anchors Anchors { get; set; }

        IQuantifier Quantifier { get; set; }
    }
}
