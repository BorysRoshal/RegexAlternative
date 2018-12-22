using System.ComponentModel;

namespace RegexAlternative.Builder
{
    public interface IRegexBuilderSymbolProperties: IRegexBuilderThen
    {
        [Description("Add an anchor.")]
        IRegexBuilderSymbolWhich Which { get; }

        [Description("Add a quantifiers.")]
        IRegexBuilderSymbolRepeated Repeated { get; }
    }
}
