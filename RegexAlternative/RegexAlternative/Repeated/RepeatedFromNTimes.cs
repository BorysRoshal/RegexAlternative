namespace RegexAlternative.Repeated
{
    internal class RepeatedFromNTimes : AbstractRepeated
    {
        public int N { get; set; }

        public RepeatedFromNTimes(int n)
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
