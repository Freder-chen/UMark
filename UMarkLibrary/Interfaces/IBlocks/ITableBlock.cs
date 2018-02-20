using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMarkLibrary.Parse;

namespace UMarkLibrary.Interfaces.IBlocks
{
    internal interface ITableBlock : IMarkdownBlock
    {
        int Row { get; }
        int Col { get; }
        IList<MarkdownBlock> Blocks { get; }
    }
}
