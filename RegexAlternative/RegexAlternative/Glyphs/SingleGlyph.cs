namespace RegexAlternative.Glyphs
{
    internal class SingleGlyph : AbstractGlyph
    {
        public string Val { get; protected set; }

        public SingleGlyph(string val)
        {
            Val = val;
        }

        public override bool Validate()
        {
            var result = !base.Validate() || string.IsNullOrEmpty(Val);

            return result;
        }

        protected override string CompileContent()
        {
            return Val;
        }
    }
}
