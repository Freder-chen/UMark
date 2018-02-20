using System.Collections.Generic;
using UMarkLibrary.Parse;

namespace UMarkLibrary.Interfaces.IBlocks
{
    internal interface IHeaderBlock : IMarkdownBlock
    {
        int HeaderLevel { get; }
        IList<MarkdownInline> Inlines { get; }
    }
}
