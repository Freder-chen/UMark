using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMarkLibrary.Interfaces.IBlocks;

namespace UMarkLibrary.Parse.Blocks
{
    public enum ListStyle
    {
        Bulleted,
        Numbered,
    }

    public class ListBlockItem : IListBlockItem
    {
        public IList<MarkdownBlock> Blocks => throw new NotImplementedException();
    }

    public class ListBlock : MarkdownBlock, IListBlock
    {
        public ListBlock(string markdownText) : base(MarkdownBlockType.List) { Prase(markdownText); }

        private IList<ListBlockItem> _items;
        public IList<ListBlockItem> Items { get { return _items; } }

        public ListStyle Style { get; set; }

        private void Prase(string markdownText)
        {
            throw new NotImplementedException();
        }
    }
}
