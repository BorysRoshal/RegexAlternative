namespace RegexAlternative.Builder
{
    public interface IRegexBuilderSymbolWhich
    {
        IRegexBuilderSymbolProperties StartOfWord { get; }

        IRegexBuilderSymbolProperties EndOfWord { get; }

        IRegexBuilderSymbolProperties NotStartOfWord { get; }

        IRegexBuilderSymbolProperties NotEndOfWord { get; }

        IRegexBuilderSymbolProperties StartOfString { get; }

        IRegexBuilderSymbolProperties EndOfString { get; }
    }
}
