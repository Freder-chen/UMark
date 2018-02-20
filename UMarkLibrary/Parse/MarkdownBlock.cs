using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMarkLibrary.Interfaces;
using Windows.UI.Xaml.Documents;

namespace UMarkLibrary.Parse
{
    public enum MarkdownBlockType
    {
        Root,
        Paragraph,
        Quote,
        Code,
        Header,
        List,
        ListItemBuilder,
        HorizontalRule,
        Table,
        LinkReference,
    };

    public abstract class MarkdownBlock : MarkdownElement, IMarkdownBlock
    {
        public MarkdownBlockType Type { get { return _type; } }
        private MarkdownBlockType _type;

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
