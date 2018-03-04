using System;
using System.Collections.Generic;
using UMarkLibrary.Helper;
using UMarkLibrary.Interfaces.IBlocks;

namespace UMarkLibrary.Parse.Blocks
{
    public enum ListStyle
    {
        Null,
        Bulleted,
        Numbered,
    }

    public class ListBlockItem : IListBlockItem
    {
        public ListBlockItem() { }
        public IList<MarkdownBlock> Blocks { get; set; }

        internal static ListBlockItem Parse(string markdownText, int start, int end, out int actualEnd)
        {
            actualEnd = GetItemTextEnd(markdownText, start, end);
            return actualEnd > start ?
                new ListBlockItem
                {
                    Blocks = Common.ParseBlocks(markdownText, start, actualEnd),
                } : null;
        }

        private static int GetItemTextEnd(string markdownText, int start, int end)
        {
            throw new NotImplementedException();
        }
    }

    public class ListBlock : MarkdownBlock, IListBlock
    {
        public ListBlock() : base(MarkdownBlockType.List) { }
        public IList<ListBlockItem> Items { get; set; }
        public ListStyle Style { get; set; }

        internal static ListBlock Parse(string markdownText, int start, int end, out int actualEnd)
        {
            ListStyle style = ListStyle.Null;
            IList<ListBlockItem> items = new List<ListBlockItem>();
            int itemTextPos = start;
            while (itemTextPos < end)
            {
                style = GetStyle(markdownText, itemTextPos, end, out itemTextPos);
                if (style == ListStyle.Null) break;
                ListBlockItem item = ListBlockItem.Parse(markdownText, itemTextPos, end, out itemTextPos);
                if (item == null) break;
                items.Add(item);
            }
            actualEnd = itemTextPos;
            return (items.Count > 0 && style != ListStyle.Null) ?
                new ListBlock
                {
                    Items = items,
                    Style = style,
                } : null;
        }

        private static ListStyle GetStyle(string markdownText, int itemTextPos1, int end, out int itemTextPos2)
        {
            throw new NotImplementedException();
        }
    }
}
