namespace RegexAlternative.Repeated
{
    internal class RepeatedNTimes : AbstractRepeated
    {
        public int N { get; set; }

        public RepeatedNTimes(int n)
        {
            N = n;
        }

        public override bool Validate()
        {
            return N >= 0;
        }

        protected override string CompileContent()
        {
            return N.ToString();
        }
    }
}
