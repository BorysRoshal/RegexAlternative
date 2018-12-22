using System.ComponentModel;

namespace RegexAlternative.Builder
{
    public interface IRegexBuilderSymbolWhich
    {
        [Description("The match must occur on a boundary between an alphanumeric and a nonalphanumeric character.")]
        IRegexBuilderSymbolProperties StartOfWord { get; }

        [Description("The match must occur on a boundary between an alphanumeric and a nonalphanumeric character.")]
        IRegexBuilderSymbolProperties EndOfWord { get; }

        [Description("The match must not occur on a boundary between an alphanumeric and a nonalphanumeric character.")]
        IRegexBuilderSymbolProperties NotStartOfWord { get; }

        [Description("The match must not occur on a boundary between an alphanumeric and a nonalphanumeric character.")]
        IRegexBuilderSymbolProperties NotEndOfWord { get; }

        [Description("The match must start at the beginning of the line.")]
        IRegexBuilderSymbolProperties StartOfString { get; }

        [Description(@"The match must occur before the end of the line or before \n at the end of the line.")]
        IRegexBuilderSymbolProperties EndOfString { get; }
    }
}
