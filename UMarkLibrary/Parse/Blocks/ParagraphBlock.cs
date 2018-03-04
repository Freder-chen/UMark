using System.Collections.Generic;
using UMarkLibrary.Helper;
using UMarkLibrary.Interfaces.IBlocks;

namespace UMarkLibrary.Parse.Blocks
{
    public class ParagraphBlock : MarkdownBlock, IParagraphBlock
    {
        public ParagraphBlock() : base(MarkdownBlockType.Paragraph) { }
        public IList<MarkdownInline> Inlines { get; set; }

        internal static ParagraphBlock Parse(string markdownText, int start, int end, out int actualEnd)
        {
            if (start > end)
            {
                actualEnd = start;
                return null;
            }
            actualEnd = ParseBlocksHelper.FindLineEnd(markdownText, start, end);
            return new ParagraphBlock
            {
                Inlines = Common.ParseInlines(markdownText, start, actualEnd),
            };
        }
    }
}