namespace RegexAlternative.Builder
{
    public interface IRegexBuilderSymbolProperties: IRegexBuilderThen
    {
        IRegexBuilderSymbolWhich Which { get; }

        IRegexBuilderSymbolRepeated Repeated { get; }
    }
}
