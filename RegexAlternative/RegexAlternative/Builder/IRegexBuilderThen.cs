namespace RegexAlternative.Builder
{
    public interface IRegexBuilderThen
    {
        IRegexBuilderSymbol Then { get; }

        IRegexBuilderSymbol Or { get; }
    }
}
