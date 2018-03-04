using System.Collections.Generic;
using UMarkLibrary.Helper;
using UMarkLibrary.Interfaces;

namespace UMarkLibrary.Parse
{
    public class MarkdownDocument : MarkdownBlock, IMarkdownDocument
    {
        public MarkdownDocument() : base(MarkdownBlockType.Root) { }

        public IList<MarkdownBlock> Blocks { get; set; }

        public static MarkdownDocument Parse(string markdownText)
        {
            return markdownText.Length > 0 ?
                new MarkdownDocument {
                    Blocks = Common.ParseBlocks(markdownText, 0, markdownText.Length - 1),
                } : null;
        }
    }
}
