using RegexAlternative.Repeated;

namespace RegexAlternative.Glyphs
{
    internal interface IGlyph: ICompilable
    {
        bool IsStartOfWord { get; set; }
        bool IsEndOfWord { get; set; }
        bool IsNotStartOfWord { get; set; }
        bool IsNotEndOfWord { get; set; }
        bool IsStartOfString { get; set; }
        bool IsEndOfString { get; set; }

        IRepeated Repeated { get; set; }
    }
}
