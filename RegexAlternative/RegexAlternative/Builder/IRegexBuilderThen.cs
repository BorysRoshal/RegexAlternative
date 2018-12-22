using System.ComponentModel;

namespace RegexAlternative.Builder
{
    public interface IRegexBuilderThen
    {
        [Description("Add a character or group.")]
        IRegexBuilderSymbol Then { get; }

        [Description("Matches any one element.")]
        IRegexBuilderSymbol Or { get; }
    }
}
