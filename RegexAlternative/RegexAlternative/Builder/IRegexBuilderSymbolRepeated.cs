namespace RegexAlternative.Builder
{
    public interface IRegexBuilderSymbolRepeated
    {
        IRegexBuilderThen FromNtoMTimes(int n, int m);

        IRegexBuilderThen FromNTimes(int n);

        IRegexBuilderThen NTimes(int n);
    }
}
