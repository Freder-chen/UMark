using UMarkLibrary.Parse;

namespace UMarkLibrary.Interfaces
{
    internal interface IMarkdownInline : IMarkdownElement
    {
        MarkdownInlineType Type { get; }
    }
}
