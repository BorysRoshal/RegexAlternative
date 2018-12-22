namespace RegexAlternative.Quantifiers
{
    internal abstract class AbstractQuantifier : IQuantifier
    {
        public abstract bool Validate();

        public virtual string Compile()
        {
            var compliesContent = CompileContent();
            return "{" + compliesContent + "}";
        }

        protected abstract string CompileContent();
    }
}
