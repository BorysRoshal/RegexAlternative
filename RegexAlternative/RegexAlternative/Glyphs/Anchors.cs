using System;

namespace RegexAlternative.Glyphs
{
    [Flags]
    internal enum Anchors
    {
        StartOfWord = 1 << 0,
        EndOfWord = 1 << 1,
        NotStartOfWord = 1 << 2,
        NotEndOfWord = 1 << 3,
        StartOfString = 1 << 4,
        EndOfString = 1 << 5,
    }
}
