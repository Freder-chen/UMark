using UMarkLibrary.Interfaces.IInlines;

namespace UMarkLibrary.Parse.Inlines
{
    public class TextRunInline : MarkdownInline, ITextRunInline
    {
        public TextRunInline(string markdownText) : base(MarkdownInlineType.TextRun) { Text = markdownText; }

        public string Text { get; set; }
    }
}
