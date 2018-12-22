using System.ComponentModel;

namespace RegexAlternative.Builder
{
    public interface IRegexBuilderSymbol
    {
        [Description("Matches any single character in val. The match is case-sensitive.")]
        IRegexBuilderSymbolProperties Symbols(string val);

        [Description("Matches any single character that is not in val. The match is case-sensitive.")]
        IRegexBuilderSymbolProperties NotSymbols(string val);

        [Description("Matches any single character in val. The match is case-sensitive.")]
        IRegexBuilderSymbolProperties String(string val);

        [Description("Matches single character val. The match is case-sensitive.")]
        IRegexBuilderSymbolProperties Symbol(char val);

        [Description(@"Matches any single character except \n.")]
        IRegexBuilderSymbolProperties AnySymbol { get; }

        [Description("Matches any word character.")]
        IRegexBuilderSymbolProperties WordSymbol { get; }

        [Description("Matches any non-word character.")]
        IRegexBuilderSymbolProperties NotWordSymbol { get; }

        [Description("Matches any white-space character.")]
        IRegexBuilderSymbolProperties Space { get; }

        [Description("Matches any non-white-space character.")]
        IRegexBuilderSymbolProperties NotSpace { get; }

        [Description("Matches any decimal digit.")]
        IRegexBuilderSymbolProperties Number { get; }

        [Description("Matches any character other than a decimal digit.")]
        IRegexBuilderSymbolProperties NotNumber { get; }

        [Description("Matches any single character in the Unicode general category or named block specified by name.")] 
        IRegexBuilderSymbolProperties SymbolInUnicodeCategory(string name);

        [Description("Matches any single character that is not in the Unicode general category or named block specified by name.")]
        IRegexBuilderSymbolProperties SymbolNotInUnicodeCategory(string name);

        [Description("Begin group.")]
        IRegexBuilderSymbol BeginGroup { get; }

        [Description("End of group.")]
        IRegexBuilderSymbolProperties EndGroup { get; }

        [Description("Group from builder.")]
        IRegexBuilderSymbol Group(IRegexBuilderThen builder);
    }
}
