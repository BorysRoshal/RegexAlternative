namespace RegexAlternative.Builder
{
    public interface IRegexBuilderSymbolProperties: IRegexBuilderThen
    {
        IRegexBuilderSymbolProperties WhichStartOfWord { get; }

        IRegexBuilderSymbolProperties WhichEndOfWord { get; }

        IRegexBuilderSymbolProperties WhichNotStartOfWord { get; }

        IRegexBuilderSymbolProperties WhichNotEndOfWord { get; }

        IRegexBuilderSymbolProperties WhichStartOfString { get; }

        IRegexBuilderSymbolProperties WhichEndOfString { get; }

        IRegexBuilderSymbolRepeated Repeated { get; }
    }
}
