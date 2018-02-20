using System.Collections.Generic;
using UMarkLibrary.Parse;

namespace UMarkLibrary.Interfaces
{
    internal interface IMarkdownDocument : IMarkdownBlock
    {
        IList<MarkdownBlock> Blocks { get; }
    }
}
