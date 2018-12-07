namespace RegexAlternative.Repeated
{
    internal abstract class AbstractRepeated : IRepeated
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
