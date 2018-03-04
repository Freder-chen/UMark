using UMarkLibrary.Interfaces;

namespace UMarkLibrary.Parse
{
    public enum MarkdownInlineType
    {
        TextRun,
        Bold,
        Italic,
        MarkdownLink,
        RawHyperlink,
        RawSubreddit,
        Strikethrough,
        Superscript,
        Code,
    };

    public abstract class MarkdownInline : MarkdownElement, IMarkdownInline
    {
        private MarkdownInlineType _type;
        public MarkdownInlineType Type => _type;

        internal MarkdownInline(MarkdownInlineType type)
        {
            _type = type;
        }
    }
}
