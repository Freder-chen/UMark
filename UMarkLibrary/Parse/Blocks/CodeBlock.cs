using UMarkLibrary.Interfaces.IBlocks;

namespace UMarkLibrary.Parse.Blocks
{
    public class CodeBlock : MarkdownBlock, ICodeBlock
    {
        public CodeBlock(string markdownText) : base(MarkdownBlockType.Code)
        {
            Parse(markdownText);
        }

        private string _codeText;
        public string CodeText => _codeText;

        private string _languageText;
        public string LanguageText => _languageText;


        private void Parse(string markdownText)
        {
            _codeText = ParseCode(markdownText, out _languageText);
        }

        private static string ParseCode(string markdownText, out string languageText)
        {
            //int pos = 0;
            //while (pos < markdownText.Length && markdownText[pos] == '`')
            //    pos++;
            //if (pos != 3)
            //{
            //    languageText = null;
            //    return null;
            //}
            //while (pos < markdownText.Length && markdownText[pos] == ' ')
            //    pos++;
            //if (markdownText[pos] == '\r' || markdownText[pos] == '\n')
            //    languageText = "";
            //else



            //languageText = "xx";

            //return markdownText.Substring(start, length);
            languageText = "";
            return "";
        }
    }
}