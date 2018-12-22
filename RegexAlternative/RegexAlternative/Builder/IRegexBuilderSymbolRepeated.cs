using System.ComponentModel;

namespace RegexAlternative.Builder
{
    public interface IRegexBuilderSymbolRepeated
    {
        [Description("Matches the previous element at least n times, but no more than m times.")]
        IRegexBuilderThen FromNtoMTimes(int n, int m);

        [Description("Matches the previous element at least n times.")]
        IRegexBuilderThen AtLeastNTimes(int n);

        [Description("Matches the previous element exactly n times.")] 
        IRegexBuilderThen ExactlyNTimes(int n);
    }
}
