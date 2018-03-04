using System.Collections.Generic;
using UMarkLibrary.Helper;
using UMarkLibrary.Interfaces.IBlocks;

namespace UMarkLibrary.Parse.Blocks
{
    public class QuoteBlock : MarkdownBlock, IQuoteBlock
    {
        public QuoteBlock(string markdownText, int start, int length) : base(MarkdownBlockType.Quote)
        {
            Parse(markdownText,start, length);
        }

        private IList<MarkdownBlock> _blocks;
        public IList<MarkdownBlock> Blocks => _blocks;

        private void Parse(string markdownText, int start, int length)
        {
            _blocks = Common.ParseBlocks(markdownText, start, length);
        }
    }
}
