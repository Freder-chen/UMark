using System.Collections.Generic;
using UMarkLibrary.Parse;
using UMarkLibrary.Parse.Inlines;

namespace UMarkLibrary.Helper
{
    public class Common
    {
        internal static IList<MarkdownInline> ParseInlines(string markdownText, int start, int end)
        {
            var inlines = new List<MarkdownInline>();
            string paragraphText = markdownText.Substring(start, end - start + 1);
            if (paragraphText.Length > 0)
                inlines.Add(new TextRunInline(paragraphText));
            return inlines;
        }

        internal static List<MarkdownBlock> ParseBlocks(string markdownText, int start, int end)
        {
            var blocks = new List<MarkdownBlock>();
            int startPos = start;
            while (startPos < end)
            {
                MarkdownBlock newBlock = ParseBlocksHelper.ParseBlock(markdownText, startPos, end, out int endPos);
                if (newBlock != null) blocks.Add(newBlock);
                startPos = endPos + 1;
            }
            return blocks;
        }
    }
}