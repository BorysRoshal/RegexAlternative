﻿namespace RegexAlternative.Quantifiers
{
    internal class QuantifierNtoMTimes: AbstractQuantifier
    {
        public int N { get; set; }

        public int M { get; set; }

        public QuantifierNtoMTimes(int n, int m)
        {
            N = n;
            M = m;
        }

        public override bool Validate()
        {
            return N >= 0 && M >= 0 && N < M;
        }

        public override string Compile()
        {
            if (N == 0 && M == 1)
            {
                return "?";
            }

            return base.Compile();
        }

        protected override string CompileContent()
        {
            return $"{N},{M}";
        }
    }
}
