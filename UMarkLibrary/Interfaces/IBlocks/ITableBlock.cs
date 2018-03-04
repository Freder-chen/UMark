using System.Collections.Generic;
using UMarkLibrary.Parse;
using UMarkLibrary.Parse.Blocks;

namespace UMarkLibrary.Interfaces.IBlocks
{
    internal interface ITableBlock : IMarkdownBlock
    {
        IList<TableBlockItem> Items { get; }
    }
}
