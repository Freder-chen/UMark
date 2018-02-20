using System.Collections.Generic;
using System.Text;
using UMarkLibrary.Interfaces.IBlocks;
using UMarkLibrary.Parse.Inlines;

namespace UMarkLibrary.Parse.Blocks
{
    public class ParagraphBlock : MarkdownBlock, IParagraphBlock
    {
        public ParagraphBlock(string markdownText) : base(MarkdownBlockType.Paragraph) { Parse(markdownText); }

        private IList<MarkdownInline> _inlines;
        public IList<MarkdownInline> Inlines => _inlines;

        private void Parse(string markdownText)
        {
            _inlines = ParseInlines(markdownText, 0, markdownText.Length);
        }

        private static IList<MarkdownInline> ParseInlines(string markdownText, int start, int end)
        {
            var inlines = new List<MarkdownInline>();
            string paragraphText = markdownText.Substring(start, end - start);
            if (paragraphText.Length > 0)
                inlines.Add(new TextRunInline(paragraphText));
            return inlines;
        }
    }
}