using System.Text;
using RegexAlternative.Quantifiers;

namespace RegexAlternative.Glyphs
{
    internal abstract class AbstractGlyph : IGlyph
    {
        public Anchors Anchors { get; set; }

        public IQuantifier Quantifier { get; set; }

        public virtual bool Validate()
        {
            var result = !(Anchors.HasFlag(Anchors.StartOfWord | Anchors.NotStartOfWord)
                           || Anchors.HasFlag(Anchors.EndOfWord | Anchors.NotEndOfWord)) 
                         && (Quantifier == null || Quantifier.Validate());

            return result;
        }

        public string Compile()
        {
            var stringBuilder = new StringBuilder();

            if (Anchors.HasFlag(Anchors.StartOfString))
            {
                stringBuilder.Append("^");
            }

            if (Anchors.HasFlag(Anchors.StartOfWord))
            {
                stringBuilder.Append(@"\b");
            }
            else if (Anchors.HasFlag(Anchors.NotStartOfWord))
            {
                stringBuilder.Append(@"\B");
            }

            var glyphContent = CompileContent();
            stringBuilder.Append(glyphContent);

            if (Anchors.HasFlag(Anchors.EndOfWord))
            {
                stringBuilder.Append(@"\b");
            }
            else if (Anchors.HasFlag(Anchors.NotEndOfWord))
            {
                stringBuilder.Append(@"\B");
            }

            if (Quantifier != null)
            {
                var compliesContent = Quantifier.Compile();
                stringBuilder.Append(compliesContent);
            }

            if (Anchors.HasFlag(Anchors.EndOfString))
            {
                stringBuilder.Append("$");
            }

            return stringBuilder.ToString();
        }

        protected abstract string CompileContent();
    }
}
