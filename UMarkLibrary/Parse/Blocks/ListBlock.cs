using System;
using System.Collections.Generic;
using UMarkLibrary.Helper;
using UMarkLibrary.Interfaces.IBlocks;

namespace UMarkLibrary.Parse.Blocks
{
    public enum ListStyle
    {
        Bulleted,
        Numbered,
    }

    #region Temporary use list
    public class ListElement : MarkdownBlock
    {
        public ListElement() : base(MarkdownBlockType.ListElement) { }
        public ListStyle Style { get; set; }
        public IList<MarkdownInline> Inlines { get; set; }

        internal static ListElement Parse(string markdownText, int start, int end, out int actualEnd)
        {
            actualEnd = start;
            int contentStartPos = GetContentStartPos(markdownText, start, end, out ListStyle style);
            if (contentStartPos == start) return null;
            actualEnd = ParseBlocksHelper.FindLineEnd(markdownText, contentStartPos, end);
            return actualEnd > start ?
                new ListElement
                {
                    Inlines = Common.ParseInlines(markdownText, contentStartPos, actualEnd),
                    Style = style,
                } : null;
        }

        private static int GetContentStartPos(string markdownText, int start, int end, out ListStyle style)
        {
            style = ListStyle.Bulleted;
            int textPos = start;
            if (markdownText[textPos] == '*' || markdownText[textPos] == '-' || markdownText[textPos] == '+')
            {
                style = ListStyle.Bulleted;
                textPos++;
            }
            else if (markdownText[textPos] >= '0' && markdownText[textPos] <= '9')
            {
                style = ListStyle.Numbered;
                textPos++;
                while (textPos < end)
                {
                    char c = markdownText[textPos];
                    if (c < '0' || c > '9') break;
                    textPos++;
                }
                if (textPos == end || markdownText[textPos] != '.') return start;
                textPos++;
                return textPos;
            }
            else return start;
            // Next should be a space.
            if (textPos == end || (markdownText[textPos] != ' ' && markdownText[textPos] != '\t')) return start;
            textPos++;
            return textPos;
        }
    }
    #endregion Temporary use list

    #region I can not write it out.
    public class ListBlock : MarkdownBlock, IListBlock
    {
        public ListBlock() : base(MarkdownBlockType.List) { }
        public IList<ListBlockItem> Items { get; set; }
        public ListStyle Style { get; set; }

        internal static ListBlock Parse(string markdownText, int start, int end, out int actualEnd)
        {
            ListItemPreamble preamble = null;
            IList<ListBlockItem> items = new List<ListBlockItem>();
            int itemStartPos = start;
            while (itemStartPos < end)
            {
                preamble = GetListItemPreamble(markdownText, itemStartPos, end);
                if (preamble == null) break;
                var item = ListBlockItem.Parse(markdownText, preamble.ContentStartPos, end, out int itemEndPos);
                if (item == null) break;
                items.Add(item);
                itemStartPos = itemEndPos + 1;
            }
            actualEnd = itemStartPos;
            return (items.Count > 0 && preamble != null) ?
                new ListBlock
                {
                    Items = items,
                    Style = preamble.Style,
                } : null;
        }

        private class ListItemPreamble
        {
            public ListStyle Style;
            public int ContentStartPos;
        }

        private static ListItemPreamble GetListItemPreamble(string markdownText, int start, int end)
        {
            ListStyle style;
            if (markdownText[start] == '*' || markdownText[start] == '-' || markdownText[start] == '+')
            {
                style = ListStyle.Bulleted;
                start++;
            }
            else if (markdownText[start] >= '0' && markdownText[start] <= '9')
            {
                style = ListStyle.Numbered;
                start++;
                while (start < end)
                {
                    char c = markdownText[start];
                    if (c < '0' || c > '9') break;
                    start++;
                }
                if (start == end || markdownText[start] != '.') return null;
                start++;
            }
            else return null;
            // Next should be a space.
            if (start == end || (markdownText[start] != ' ' && markdownText[start] != '\t')) return null;
            start++;
            return new ListItemPreamble { Style = style, ContentStartPos = start };
        }
    }

    public class ListBlockItem : MarkdownBlock, IListBlockItem
    {
        public ListBlockItem() : base(MarkdownBlockType.ListElement) { }
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
    #endregion I can not write it out.
}
