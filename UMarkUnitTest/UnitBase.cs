using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UMarkLibrary.Parse;
using UMarkLibrary.Parse.Blocks;
using UMarkLibrary.Parse.Inlines;

namespace UMarkUnitTest
{
    public class UnitBase
    {
        public static void Test(string expected, string expectedText)
        {
            string actual = "";
            MarkdownDocument document = MarkdownDocument.Parse(expectedText);
            if (document != null) actual = GetBlocksText(document.Blocks);
            Assert.AreEqual(expected, actual);
        }

        private static string GetBlocksText(IList<MarkdownBlock> blocks)
        {
            string text = "";
            foreach (var block in blocks)
            {
                if (block is ParagraphBlock)
                    text += GetInlinsText(((ParagraphBlock)block).Inlines);
                else if (block is HeaderBlock)
                    text += GetInlinsText(((HeaderBlock)block).Inlines);
                else if (block is HorizontalRuleBlock)
                    text += "---\r\n";
            }
            return text;
        }

        private static string GetInlinsText(IList<MarkdownInline> inlines)
        {
            string text = "";
            foreach (var inline in inlines)
            {
                if (inline is TextRunInline)
                    text += ((TextRunInline)inline).Text;
            }
            return text;
        }
    }
}
