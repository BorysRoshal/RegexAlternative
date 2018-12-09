namespace RegexAlternative.Builder
{
    public interface IRegexBuilderSymbol
    {
        IRegexBuilderSymbolProperties Symbols(string val);

        IRegexBuilderSymbolProperties NotSymbols(string val);

        IRegexBuilderSymbolProperties String(string val);

        IRegexBuilderSymbolProperties Symbol(char val);

        IRegexBuilderSymbolProperties AnySymbol { get; }

        IRegexBuilderSymbolProperties TextSymbol { get; }

        IRegexBuilderSymbolProperties NotTextSymbol { get; }

        IRegexBuilderSymbolProperties Space { get; }

        IRegexBuilderSymbolProperties NotSpace { get; }

        IRegexBuilderSymbolProperties Number { get; }

        IRegexBuilderSymbolProperties NotNumber { get; }

        IRegexBuilderSymbol Group { get; }

        IRegexBuilderSymbolProperties EndOfGroup { get; }
    }
}
