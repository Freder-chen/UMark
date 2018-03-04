using System;
using System.Collections.Generic;
using UMarkLibrary.Helper;
using UMarkLibrary.Interfaces.IBlocks;

namespace UMarkLibrary.Parse.Blocks
{
    public class HeaderBlock : MarkdownBlock, IHeaderBlock
    {
        public HeaderBlock() : base(MarkdownBlockType.Header) { }
        public int HeaderLevel { get; set; }
        public IList<MarkdownInline> Inlines { get; set; }

        internal static HeaderBlock Parse(string markdownText, int start, int end, out int actualEnd)
        {
            int headerLevel = GetHeaderLevel(markdownText, start, end, out int textStart);
            if (headerLevel == 0 || 
                textStart > end  || 
                markdownText[textStart] == '\r' ||
                markdownText[textStart] == '\n')
            {
                actualEnd = start;
                return null;
            }
            actualEnd = ParseBlocksHelper.FindLineEnd(markdownText, textStart, end);
            return new HeaderBlock
            {
                HeaderLevel = headerLevel,
                Inlines = Common.ParseInlines(markdownText, textStart, actualEnd),
            };
        }

        private static int GetHeaderLevel(string markdownText, int start, int end, out int pos)
        {
            // Parse header sigh.
            pos = start;
            while (pos < end && markdownText[pos] == '#' && pos < 6)
                pos++;
            int headerLevel = pos;
            if (headerLevel < 0 || headerLevel > 6)
            {
                pos = start;
                return 0;
            }
            // Judge whether there is space.
            if (pos <= end && markdownText[pos] == ' ')
                pos++;
            return headerLevel;
        }
    }
} 