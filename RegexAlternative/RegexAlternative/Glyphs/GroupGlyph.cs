using System.Collections.Generic;
using System.Linq;

namespace RegexAlternative.Glyphs
{
    internal class GroupGlyph: AbstractGlyph
    {
        public List<IGlyph> Glyphs { get; protected set; }

        public GroupGlyph(List<IGlyph> glyphs)
        {
            Glyphs = glyphs;
        }

        public override bool Validate()
        {
            var result = Glyphs.TrueForAll(x => x.Validate());

            return result;
        }

        protected override string CompileContent()
        {
            var result = string.Concat(Glyphs.Select(x => x.Compile()));

            return $"({result})";
        }
    }
}
