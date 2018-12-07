using System.Text;
using RegexAlternative.Repeated;

namespace RegexAlternative.Glyphs
{
    internal abstract class AbstractGlyph : IGlyph
    {
        public bool IsStartOfWord { get; set; } = false;

        public bool IsEndOfWord { get; set; } = false;

        public bool IsNotStartOfWord { get; set; } = false;

        public bool IsNotEndOfWord { get; set; } = false;

        public bool IsStartOfString { get; set; } = false;

        public bool IsEndOfString { get; set; } = false;

        public IRepeated Repeated { get; set; }

        public virtual bool Validate()
        {
            var result = !(IsStartOfWord && IsNotStartOfWord || IsEndOfWord && IsNotEndOfWord) && (Repeated == null || Repeated.Validate());

            return result;
        }

        public string Compile()
        {
            var stringBuilder = new StringBuilder();

            if (IsStartOfString)
            {
                stringBuilder.Append("^");
            }

            if (IsStartOfWord)
            {
                stringBuilder.Append(@"\b");
            }
            else if (IsNotStartOfWord)
            {
                stringBuilder.Append(@"\B");
            }

            var glyphContent = CompileContent();
            stringBuilder.Append(glyphContent);

            if (IsEndOfWord)
            {
                stringBuilder.Append(@"\b");
            }
            else if (IsNotEndOfWord)
            {
                stringBuilder.Append(@"\B");
            }

            if (Repeated != null)
            {
                var compliesContent = Repeated.Compile();
                stringBuilder.Append(compliesContent);
            }

            if (IsEndOfString)
            {
                stringBuilder.Append("$");
            }

            return stringBuilder.ToString();
        }

        protected abstract string CompileContent();
    }
}
