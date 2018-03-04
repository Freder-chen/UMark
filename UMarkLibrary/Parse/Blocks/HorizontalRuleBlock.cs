using System;
using UMarkLibrary.Helper;
using UMarkLibrary.Interfaces.IBlocks;

namespace UMarkLibrary.Parse.Blocks
{
    public class HorizontalRuleBlock : MarkdownBlock, IHorizontalRuleBlock
    {
        public HorizontalRuleBlock() : base(MarkdownBlockType.HorizontalRule) { }

        internal static HorizontalRuleBlock Parse(string markdownText, int start, int end, out int actualEnd)
        {
            int hrCount = GetHRCount(markdownText, start, end, out actualEnd);
            return hrCount >= 3 ? new HorizontalRuleBlock() : null;
        }

        private static int GetHRCount(string markdownText, int start, int end, out int actulEnd)
        {
            actulEnd = start;
            char hrChar = '\0';
            int hrCharCount = 0;
            int pos = start;
            while (pos < end)
            {
                char c = markdownText[pos++];
                if (c == '*' || c == '-' || c == '_')
                {
                    if (hrCharCount > 0 && c != hrChar) return -1;
                    hrChar = c;
                    hrCharCount++;
                }
                else if (c == '\n') break;
                else if (!ParseBlocksHelper.IsWhiteSpace(c)) return -1;
            }
            actulEnd = pos;
            return hrCharCount;
        }
    }
}
