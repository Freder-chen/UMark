using UMarkLibrary.Interfaces;

namespace UMarkLibrary.Parse
{
    public enum MarkdownBlockType
    {
        Root,
        Paragraph,
        Header,// #(1-6)、===、---
        HorizontalRule,// ---、***
        Quote, // >
        Code,  // Four spaces or \t
        List, // +、-、*、number.
        //ListItemBuilder,
        Table, // 表 | 1 | 2 | 3 |
        LinkReference, // [name](url)
    };

    public abstract class MarkdownBlock : MarkdownElement, IMarkdownBlock
    {
        private MarkdownBlockType _type;
        public MarkdownBlockType Type => _type;

        internal MarkdownBlock(MarkdownBlockType type)
        {
            _type = type;
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj) || !(obj is MarkdownBlock))
                return false;
            return Type == ((MarkdownBlock)obj).Type;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ Type.GetHashCode();
        }
    }
}
