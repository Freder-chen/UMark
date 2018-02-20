using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UMarkLibrary.Interfaces;
using UMarkLibrary.Parse.Blocks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

namespace UMarkLibrary.Parse
{
    public class MarkdownDocument : MarkdownBlock, IMarkdownDocument
    {
        public MarkdownDocument(string markdownText) : base(MarkdownBlockType.Root) { Parse(markdownText); }

        private IList<MarkdownBlock> _blocks;
        public IList<MarkdownBlock> Blocks { get { return _blocks; } }

        /// <summary>
        /// Parse <paramref name="MarkdownText"/> and generate <see cref="Blocks"/>.
        /// </summary>
        /// <param name="markdownText">The text should parse.</param>
        private void Parse(string markdownText)
        {
            _blocks = Parse(markdownText, 0, markdownText.Length);
        }

        private IList<MarkdownBlock> Parse(string markdownText, int start, int end)
        {
            var blocks = new List<MarkdownBlock>();
            var paragraphText = new StringBuilder();
            int startOfLine = start;

            // Go line by line.
            while (startOfLine < end)
            {
                char c = markdownText[startOfLine];
                int endOfLine = FindNextLine(markdownText, startOfLine, end);
                if (c == '#') // Header
                {
                    string blockText = markdownText.Substring(startOfLine, endOfLine - startOfLine);
                    var block = new HeaderBlock(blockText);
                    blocks.Add(block);
                }
                //else if (c == '*' || c == '-' || c == '_') // List
                //{
                //    string blockText = markdownText.Substring(startOfLine, endOfLine - startOfLine);
                //    var block = new ListBlock(blockText);
                //    blocks.Add(block);
                //}
                else // Paragraph
                {
                    string blockText = markdownText.Substring(startOfLine, endOfLine - startOfLine);
                    var block = new ParagraphBlock(blockText);
                    blocks.Add(block);
                }
                startOfLine = endOfLine + 2;
            }

            //paragraphText.Append(markdownText.Substring(start, end));
            //if (paragraphText.Length > 0)
            //    blocks.Add(new ParagraphBlock(paragraphText.ToString()));

            return blocks;
        }

        private int FindNextLine(string text, int startPos, int endPos)
        {
            int lineFeedPos = text.IndexOf('\n', startPos);
            if (lineFeedPos == -1) return endPos;
            // Check if it was a CRLF.
            if (lineFeedPos > startPos && text[lineFeedPos - 1] == '\r')
                return lineFeedPos - 1;
            return lineFeedPos;
        }
    }
}
