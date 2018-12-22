namespace RegexAlternative.Quantifiers
{
    internal class QuantifierFromNTimes : AbstractQuantifier
    {
        public int N { get; set; }

        public QuantifierFromNTimes(int n)
        {
            N = n;
        }

        public override bool Validate()
        {
            return N >= 0;
        }

        public override string Compile()
        {
            switch (N)
            {
                case 0:
                    return "*";
                case 1:
                    return "+";
                default:
                    return base.Compile();
            }
        }

        protected override string CompileContent()
        {
            return $"{N},";
        }
    }
}
