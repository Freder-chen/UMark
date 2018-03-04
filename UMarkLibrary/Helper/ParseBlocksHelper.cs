using UMarkLibrary.Parse;
using UMarkLibrary.Parse.Blocks;

namespace UMarkLibrary.Helper
{
    public class ParseBlocksHelper
    {
        // Root,                           --- Done
        // Paragraph,                      --- Done
        // Header,// #(1-6)、===、---      --- Done
        // HorizontalRule,// ---、***
        // List, // +、-、*、number.       --- Done
        // Code,  // Four spaces or \t
        // Quote, // >
        // ListItemBuilder,
        // Table, // 表 | 1 | 2 |
        // LinkReference, // [name](url)

        internal static MarkdownBlock ParseBlock(string markdownText, int start, int end, out int actualEnd)
        {
            actualEnd = start;
            MarkdownBlock block = null;
            char nonSpaceChar = GetNonSpaceChar(markdownText, start, end, out int nonSpacePos);

            if (nonSpaceChar == '#' && nonSpacePos == start)
                block = HeaderBlock.Parse(markdownText, start, end, out actualEnd);

            if (block == null && (nonSpaceChar == '*' || nonSpaceChar == '-' || nonSpaceChar == '_'))
                block = HorizontalRuleBlock.Parse(markdownText, start, end, out actualEnd);

            if (block == null)
                block = ParagraphBlock.Parse(markdownText, start, end, out actualEnd);

            return block;
        }

        private static char GetNonSpaceChar(string markdownText, int start, int end, out int nonSpacePos)
        {
            nonSpacePos = start;
            return markdownText[start];
        }


        //public static MarkdownBlockType GetBlockType(string markdownText, int start, out int blockLength)
        //{
        //    if (IsHeader(markdownText, start))
        //    {
        //        blockLength = FindLineEnd(markdownText, start, markdownText.Length - 1);
        //        return MarkdownBlockType.Header;
        //    }
        //    else if (IsHorizontalRule(markdownText, start))
        //    {
        //        blockLength = FindLineEnd(markdownText, start, markdownText.Length - 1);
        //        return MarkdownBlockType.HorizontalRule;
        //    }
        //    else if (IsCode(markdownText, start))
        //    {
        //        blockLength = -1;
        //        return MarkdownBlockType.Code;
        //    }
        //    else if (IsList(markdownText, start))
        //    {
        //        blockLength = -1;
        //        return MarkdownBlockType.List;
        //    }
        //    else if (IsQuote(markdownText, start))
        //    {
        //        blockLength = -1;
        //        return MarkdownBlockType.Quote;
        //    }
        //    else if (IsTable(markdownText, start))
        //    {
        //        blockLength = -1;
        //        return MarkdownBlockType.Table;
        //    }
        //    else
        //    {
        //        blockLength = FindLineEnd(markdownText, start, markdownText.Length - 1);
        //        return MarkdownBlockType.Paragraph;
        //    }
        //}

        //#region IsBlock

        //private static bool IsHeader(string markdownText, int start)
        //{
        //    if (markdownText[start] == '#') return true;
        //    else  return false;
        //}

        //private static bool IsHorizontalRule(string markdownText, int start)
        //{
        //    char hrChar = '\0';
        //    int hrCharCount = 0;
        //    int pos = start;
        //    int end = markdownText.Length - start;
        //    while (pos < end)
        //    {
        //        char c = markdownText[pos++];
        //        if (c == '*' || c == '-' || c == '_')
        //        {
        //            if (hrCharCount > 0 && c != hrChar) return false;
        //            hrChar = c;
        //            hrCharCount++;
        //        }
        //        else if (c == '\n') break;
        //        else if (!IsWhiteSpace(c)) return false;
        //    }
        //    return hrCharCount >= 3 ? true : false;
        //}

        //private static bool IsCode(string markdownText, int start)
        //{
        //    //StringBuilder code = null;
        //    //actualEnd = start;

        //    //foreach (var lineInfo in Common.ParseLines(markdown, start, maxEnd, quoteDepth))
        //    //{
        //    //    // Add every line that starts with a tab character or at least 4 spaces.
        //    //    int pos = lineInfo.StartOfLine;
        //    //    if (pos < maxEnd && markdown[pos] == '\t')
        //    //        pos++;
        //    //    else
        //    //    {
        //    //        int spaceCount = 0;
        //    //        while (pos < maxEnd && spaceCount < 4)
        //    //        {
        //    //            if (markdown[pos] == ' ')
        //    //                spaceCount++;
        //    //            else if (markdown[pos] == '\t')
        //    //                spaceCount += 4;
        //    //            else
        //    //                break;
        //    //            pos++;
        //    //        }
        //    //        if (spaceCount < 4)
        //    //        {
        //    //            // We found a line that doesn't start with a tab or 4 spaces.
        //    //            // But don't end the code block until we find a non-blank line.
        //    //            if (lineInfo.IsLineBlank == false)
        //    //                break;
        //    //        }
        //    //    }


        //    //    // Separate each line of the code text.
        //    //    if (code == null)
        //    //        code = new StringBuilder();
        //    //    else
        //    //        code.AppendLine();

        //    //    if (lineInfo.IsLineBlank == false)
        //    //    {
        //    //        // Append the code text, excluding the first tab/4 spaces, and convert tab characters into spaces.
        //    //        string lineText = markdown.Substring(pos, lineInfo.EndOfLine - pos);
        //    //        int startOfLinePos = code.Length;
        //    //        for (int i = 0; i < lineText.Length; i++)
        //    //        {
        //    //            char c = lineText[i];
        //    //            if (c == '\t')
        //    //                code.Append(' ', 4 - ((code.Length - startOfLinePos) % 4));
        //    //            else
        //    //                code.Append(c);
        //    //        }
        //    //    }

        //    //    // Update the end position.
        //    //    actualEnd = lineInfo.StartOfNextLine;
        //    //}

        //    //if (code == null)
        //    //{
        //    //    // Not a valid code block.
        //    //    actualEnd = start;
        //    //    return null;
        //    //}

        //    //// Blank lines should be trimmed from the start and end.
        //    //return new CodeBlock() { Text = code.ToString().Trim('\r', '\n') };
        //    return false;
        //}
        //private static bool IsList(string markdownText, int start)
        //{
        //    return false;
        //}
        //private static bool IsQuote(string markdownText, int start)
        //{
        //    return false;
        //}
        //private static bool IsTable(string markdownText, int start)
        //{
        //    return false;
        //}

        //#endregion IsBlock

        #region Low level handling

        internal static bool IsWhiteSpace(char c)
        {
            return c == ' ' || c == '\t' || c == '\r' || c == '\n';
        }

        internal static int FindLineEnd(string text, int startPos, int endPos)
        {
            int lineFeedPos = text.IndexOf('\n', startPos);
            if (lineFeedPos == -1) return endPos;
            // Check if it was a CRLF.
            if (lineFeedPos > startPos && text[lineFeedPos - 1] == '\r')
                return lineFeedPos;
            else
                return lineFeedPos + 1;
        }

        #endregion Low level handling
    }
}
