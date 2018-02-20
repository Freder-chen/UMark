using System.Collections.Generic;
using UMarkLibrary.Parse;

namespace UMarkLibrary.Interfaces.IBlocks
{
    internal interface IParagraphBlock : IMarkdownBlock
    {
        IList<MarkdownInline> Inlines { get; }
    }
}
