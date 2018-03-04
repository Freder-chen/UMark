using UMarkLibrary.Interfaces.IInlines;

namespace UMarkLibrary.Parse.Inlines
{
    public class TextRunInline : MarkdownInline, ITextRunInline
    {
        public TextRunInline(string markdownText) : base(MarkdownInlineType.TextRun) { _text = markdownText; }

        private string _text;
        public string Text => _text;
    }
}
