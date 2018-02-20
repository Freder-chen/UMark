using System;
using System.Collections.Generic;
using UMarkLibrary.Interfaces.IBlocks;
using UMarkLibrary.Parse.Inlines;

namespace UMarkLibrary.Parse.Blocks
{
    public class HeaderBlock : MarkdownBlock, IHeaderBlock
    {
        public HeaderBlock(string markdownText) : base(MarkdownBlockType.Header) { Parse(markdownText); }

        private int _headerLevel;
        public int HeaderLevel { get { return _headerLevel; } }

        private IList<MarkdownInline> _inlines;
        public IList<MarkdownInline> Inlines => _inlines;

        private void Parse(string markdownText)
        {
            _inlines = ParseInlines(markdownText, 0, markdownText.Length);
        }

        private IList<MarkdownInline> ParseInlines(string markdownText, int start, int end)
        {
            var inlines = new List<MarkdownInline>();
            int pos = start;
            while (pos < end && markdownText[pos] == '#' && pos - start < 6)
                pos++;
            _headerLevel = pos - start;

            if (_headerLevel == 0) return null;
            string inlineText = markdownText.Substring(pos, end - pos);
            if (inlineText.Length > 0)
                inlines.Add(new TextRunInline(inlineText));

            return inlines;
        }
    }
} 