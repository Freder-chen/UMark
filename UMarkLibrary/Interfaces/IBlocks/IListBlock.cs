using System.Collections.Generic;
using UMarkLibrary.Parse;
using UMarkLibrary.Parse.Blocks;

namespace UMarkLibrary.Interfaces.IBlocks
{
    internal interface IListBlock : IMarkdownBlock
    {
        IList<ListBlockItem> Items { get; }
    }
    internal interface IListBlockItem
    {
        IList<MarkdownBlock> Blocks { get; }
    }
}
