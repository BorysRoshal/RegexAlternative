namespace RegexAlternative.Quantifiers
{
    internal class QuantifierNTimes : AbstractQuantifier
    {
        public int N { get; set; }

        public QuantifierNTimes(int n)
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
